/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Mark Hoekstra (University of Groningen)
*/

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DecisionArchitect.View.Forces;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace DecisionArchitect.Logic
{
    public class ExcelSynchronization
    {
        // Index of column used to store the GUIDs for mapping. 
        // The location of the value belonging to the GUID is stored into the column right of it
        private const int DiagramMappingIndex = 1,
                          ForceMappingIndex = 2,
                          ConcernMappingIndex = 4,
                          DecisionMappingIndex = 6,
                          RatingMappingIndex = 8;

        private const int StartColumn = 2, StartRow = 2;
        // Index for start column/row. Excel starts counting at 1 and Row/Column header takes up a row/column

        private readonly IForcesController _controller;
        private readonly DataGridView _forcesTable;
        private Application _application = new Application {Visible = false};
        private Workbook _workbook;
        private Worksheet _worksheet;
        private Worksheet _worksheetHidden; // used for storing mapping information

        public ExcelSynchronization(IForcesController controller, DataGridView forcesTable)
        {
            _controller = controller;
            _forcesTable = forcesTable;
            Initialize();
        }

        ~ExcelSynchronization()
        {
            Dispose();
        }

        /// <summary>
        ///     Release ComObjects to remove the process EXCEL.exe.
        /// </summary>
        private void Dispose()
        {
            if (_application == null) return;

            _application.Quit();

            // Manual disposal because of COM
            while (Marshal.ReleaseComObject(_application) != 0)
            {
            }
            while (Marshal.ReleaseComObject(_workbook) != 0)
            {
            }
            while (Marshal.ReleaseComObject(_worksheet) != 0)
            {
            }
            while (Marshal.ReleaseComObject(_worksheetHidden) != 0)
            {
            }

            _application = null;
            _workbook = null;
            _worksheet = null;
            _worksheetHidden = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        /// <summary>
        ///     Setup workbooks/worksheets and populate them
        /// </summary>
        private void Initialize()
        {
            //_application.Workbooks.add(...) is not possible. 
            //2 dots must be avoided to release wrappers: http://support.microsoft.com/kb/317109
            Workbooks workbooks = _application.Workbooks;
            _workbook = workbooks.Add(Missing.Value);

            Sheets worksheets = _workbook.Worksheets;
            _worksheet = (Worksheet) _workbook.ActiveSheet;
            _worksheetHidden = (Worksheet) worksheets.Add();

            // Release wrapper objects
            Marshal.FinalReleaseComObject(worksheets);
            Marshal.FinalReleaseComObject(workbooks);

            _worksheetHidden.Name = "Mapping Information";
            _worksheetHidden.Visible = XlSheetVisibility.xlSheetVeryHidden;

            //Event handlers
            _worksheet.Change += Event_ChangeEvent;

            Populate();

            _application.Visible = true; //Show the application after it's populated
        }

        /// <summary>
        ///     Convert the data from the forces table to the excel and its mapping information
        /// </summary>
        private void Populate()
        {
            _worksheetHidden.Cells[1, DiagramMappingIndex] = _controller.Model.DiagramGUID;
            // Store diagram GUID in first row

            for (int i = 0; i < _forcesTable.Rows.Count - 1; i++) //Last row can be ignored
            {
                int amountColHidden = 0; //For ignoring these columns in excel

                ForceCell(i);

                for (int j = 0; j < _forcesTable.Rows[i].Cells.Count; j++)
                {
                    if (!_forcesTable.Columns[j].Visible) amountColHidden++;

                    if (j == ForcesTableContext.ConcernColumnIndex) // Concern
                    {
                        ConcernCell(i, j, amountColHidden);
                    }
                    else if (j >= ForcesTableContext.DecisionColumnIndex) // Decision/rating
                    {
                        if (i == 0) DecisionCell(i, j, amountColHidden);
                        RatingCell(i, j, amountColHidden);
                    }
                }
            }
        }

        /// <summary>
        ///     Value for a cell containing a force and its mapping information
        /// </summary>
        /// <param name="i"></param>
        private void ForceCell(int i)
        {
            int row = i + StartRow;
            const int col = 1;
            _worksheet.Cells[row, col] = _forcesTable.Rows[i].HeaderCell.Value;

            object guid = _forcesTable.Rows[i].Cells[ForcesTableContext.ForceGUIDColumnIndex].Value;
            UpdateMapping(row, col, ForceMappingIndex, guid);
        }

        /// <summary>
        ///     Value for a cell containing a concern and its mapping information
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
        ///     Value for a cell containing a decision and its mapping information
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
        ///     Value for a cell containing a rating and its mapping information
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="amountColHidden"></param>
        private void RatingCell(int i, int j, int amountColHidden)
        {
            int row = i + StartRow, col = j + StartColumn - amountColHidden;
            _worksheet.Cells[row, col] = _forcesTable.Rows[i].Cells[j].Value;

            DataGridViewCell forGuid = _forcesTable.Rows[i].Cells[ForcesTableContext.ForceGUIDColumnIndex];
            DataGridViewCell conGuid = _forcesTable.Rows[i].Cells[ForcesTableContext.ConcernGUIDColumnIndex];
            DataGridViewCell decGuid = _forcesTable.Rows[_forcesTable.Rows.Count - 1].Cells[j];
            string ratingGuids = forGuid.Value + ";" + conGuid.Value + ";" + decGuid.Value;
            UpdateMapping(row, col, RatingMappingIndex, ratingGuids);
        }

        /// <summary>
        ///     Stores mapping information: GUID and location of value
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
            Range range = _worksheet.Cells[row, col];
            _worksheetHidden.Cells[lastRowIndex, mappingIndex + 1] = range.AddressLocal[false, false];
            Marshal.ReleaseComObject(range);
        }

        /// <summary>
        ///     Retrieves the last used row of columnIndex in worksheet
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        private int GetLastRow(Worksheet worksheet, int columnIndex)
        {
            for (int i = 1; i < worksheet.Rows.Count; i++)
            {
                var range = (Range) worksheet.Cells[i, columnIndex];
                if (range.Value2 == null)
                {
                    Marshal.ReleaseComObject(range);
                    return i; // First cell that is empty
                }
                Marshal.ReleaseComObject(range);
            }
            return 1;
        }


        // EVENT HANDLERS

        private void Event_ChangeEvent(Range range)
        {
            //TODO connect with ForcesViewpoint
        }
    }
}