/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Mark Hoekstra (University of Groningen)
*/

using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DecisionViewpoints.View;
using DecisionViewpoints.View.Controller;
using ExcelInterop = Microsoft.Office.Interop.Excel;

namespace DecisionViewpoints.Logic.Forces
{
    public class Excel
    {
        private readonly IForcesController _controller;

        private ExcelInterop.Application _application = new ExcelInterop.Application { Visible = false };
        private ExcelInterop.Workbook _workbook;
        private ExcelInterop.Worksheet _worksheet;
        private ExcelInterop.Worksheet _worksheetHidden; // used for storing mapping information
        private readonly DataGridView _forcesTable;

        // Index of row used to store the GUIDs for mapping. 
        // The location of the value belonging to the GUID is stored into the row right of it
        private const int DiagramMappingIndex = 1,
            RequirementMappingIndex = 2,
            ConcernMappingIndex = 4,
            DecisionMappingIndex =  6,
            RatingMappingIndex = 8;
        private const int StartColumn = 2, StartRow = 2; // Index for start column/row. Excel starts counting at 1 and Row/Column header takes up a row/column
      
        public Excel(IForcesController controller, DataGridView forcesTable)
        {
            _controller = controller;
            _forcesTable = forcesTable;
            Initialize();
        }

        /// <summary>
        /// Quit the open excel application
        /// </summary>
        ~Excel()
        {
            if (_application != null)
            {
                _application.Quit();
                Marshal.ReleaseComObject(_application);
            }
        }

        private void Initialize()
        {
            //_application.Workbooks.add(...) is not possible. 
            //2 dots must be avoided to release wrappers: http://support.microsoft.com/kb/317109
            var workbooks = _application.Workbooks;
            _workbook = workbooks.Add(Missing.Value);
            var worksheets = _workbook.Worksheets;
            _worksheet = (ExcelInterop.Worksheet)_workbook.ActiveSheet;
            _worksheetHidden = (ExcelInterop.Worksheet)worksheets.Add();
            
            // Release wrapper objects
            Marshal.ReleaseComObject(worksheets);
            Marshal.ReleaseComObject(workbooks);

            _worksheetHidden.Name = "Mapping Information";
            _worksheetHidden.Visible = ExcelInterop.XlSheetVisibility.xlSheetVeryHidden;

            //Event handlers
            _worksheet.Change += Event_ChangeEvent;
            _application.WorkbookBeforeClose +=_application_WorkbookBeforeClose;

            Populate();
            _application.Visible = true; //Show the application after it's populated
        }

        /// <summary>
        /// Convert the data from the forces table to the excel and its mapping information
        /// </summary>
        private void Populate()
        {
            _worksheetHidden.Cells[1, DiagramMappingIndex] = _controller.Model.DiagramGUID; // Store diagram GUID in first row

            for (int i = 0; i < _forcesTable.Rows.Count-1; i++) //Last row can be ignored
            {
                int amountColHidden = 0; //For ignoring these in excel
                
                RequirementCell(i);

                for (int j = 0; j < _forcesTable.Rows[i].Cells.Count; j++)
                {
                    if (!_forcesTable.Columns[j].Visible) amountColHidden++;

                    if (j == ForcesTableContext.ConcernColumnIndex) // Concern
                    {
                        ConcernCell(i, j, amountColHidden);

                    } else if (j >= ForcesTableContext.DecisionColumnIndex) // Decision/rating
                    {
                        if (i == 0) DecisionCell(i, j, amountColHidden);

                        RatingCell(i, j, amountColHidden);
                    }
                }
            }
        }

        /// <summary>
        /// Value for a cell containing a requirement and its mapping information
        /// </summary>
        /// <param name="i"></param>
        private void RequirementCell(int i)
        {
            int row = i + StartRow, col = 1;
            _worksheet.Cells[row, col] = _forcesTable.Rows[i].HeaderCell.Value;

            object guid = _forcesTable.Rows[i].Cells[ForcesTableContext.RequirementGUIDColumnIndex].Value;
            UpdateMapping(row, col, RequirementMappingIndex, guid);
        }

        /// <summary>
        /// Value for a cell containing a concern and its mapping information
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="amountColHidden"></param>
        private void ConcernCell(int i, int j, int amountColHidden)
        {
            // Header
            if (i == 0) _worksheet.Cells[i + 1, j + 1] = _forcesTable.Columns[j].HeaderText;

            int row = i + StartRow, col = j + StartColumn - amountColHidden;
            _worksheet.Cells[row, col] = _forcesTable.Rows[i].Cells[j].Value;

            object guid = _forcesTable.Rows[i].Cells[ForcesTableContext.ConcernGUIDColumnIndex].Value;
            UpdateMapping(row, col, ConcernMappingIndex, guid);
        }

        /// <summary>
        /// Value for a cell containing a decision and its mapping information
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="amountColHidden"></param>
        private void DecisionCell(int i, int j, int amountColHidden)
        {
            int row = i + 1, col = j + StartColumn - amountColHidden;
            _worksheet.Cells[row, col] = _forcesTable.Columns[j].HeaderText;

            object guid = _forcesTable.Rows[_forcesTable.Rows.Count - 1].Cells[j].Value;
            UpdateMapping(row, col, DecisionMappingIndex, guid);
        }

        /// <summary>
        /// Value for a cell containing a rating and its mapping information
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="amountColHidden"></param>
        private void RatingCell(int i, int j, int amountColHidden)
        {
            int row = i + StartRow, col = j + StartColumn - amountColHidden;
            _worksheet.Cells[row, col] = _forcesTable.Rows[i].Cells[j].Value;

            var reqGuid = _forcesTable.Rows[i].Cells[ForcesTableContext.RequirementGUIDColumnIndex];
            var conGuid = _forcesTable.Rows[i].Cells[ForcesTableContext.ConcernGUIDColumnIndex];
            var decGuid = _forcesTable.Rows[_forcesTable.Rows.Count - 1].Cells[j];
            var ratingGuids = reqGuid.Value + ";" + conGuid.Value + ";" + decGuid.Value;
            UpdateMapping(row, col, RatingMappingIndex, ratingGuids);
        }

        /// <summary>
        /// Stores mapping information: GUID and location of value
        /// </summary>
        /// <param name="row"> Index of row of the value stored in Excel</param>
        /// <param name="col"> Index of column of the value stored in Excel</param>
        /// <param name="mappingIndex"> Index of column used to stored the mapping information in Excel</param>
        /// <param name="guid"> one or more guids. Multiple GUIDs are separated by ';'</param>
        private void UpdateMapping(int row, int col, int mappingIndex, object guid)
        {
            int lastRowIndex = GetLastRow(_worksheetHidden, mappingIndex);
            
            //Store GUID
            _worksheetHidden.Cells[lastRowIndex, mappingIndex] = guid;

            //Store location of value next to GUID
            ExcelInterop.Range range = _worksheet.Cells[row, col];
            _worksheetHidden.Cells[lastRowIndex, mappingIndex + 1] = range.AddressLocal[false, false];
        }

        /// <summary>
        /// Retrieves the last used row of columnIndex in worksheet
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        private int GetLastRow(ExcelInterop.Worksheet worksheet, int columnIndex)
        {
            for (int i = 1; i < worksheet.Rows.Count; i++)
            {
                if (((ExcelInterop.Range)worksheet.Cells[i, columnIndex]).Value2 == null)
                {
                    return i; // First cell that is empty
                }
            }
            return 1;
        }

        // EVENT HANDLERS

        private void Event_ChangeEvent(ExcelInterop.Range range)
        {
            //TODO connect with ForcesViewpoint
        }

        private void _application_WorkbookBeforeClose(ExcelInterop.Workbook wb, ref bool cancel)
        {
            _application.Quit(); //Shutdown
            Marshal.FinalReleaseComObject(_application); // Remove references
            _application = null; //Set to null, so it will not be used anymore in destructor
        }
    }
}
