/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    Antonis Gkortzis (University of Groningen)   
    Mark Hoekstra (University of Groningen)
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DecisionViewpoints.Logic.Forces;
using DecisionViewpoints.Model;
using DecisionViewpoints.View.Controller;
using EAFacade;
using EAFacade.Model;


//using MenuItem = DecisionViewpointsCustomViews.Model.Menu.MenuItem;

namespace DecisionViewpoints.View
{
    [ComVisible(true)]
    [Guid("D65970AD-12A7-402A-9F88-ED50D8C1DD82")]
    [ProgId("DecisionViewpoints.ForcesView")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(IForcesView))]
    public class ForcesView: UserControl, IForcesView
    {
        private Button _btnConfigure;
        private IForcesController _controller;
        private DataGridView _forcesTable;
        private Button _btnOpenExcel;

        private ToolTip datagridToolTip = new ToolTip();

        public ForcesView()
        {
            InitializeComponent();
        }

        public void UpdateTable(IForcesModel model)
        {
            //deactivate cell value listener
            _forcesTable.CellValueChanged -= _forcesTable_CellValueChanged;

            var data = new DataTable();

            // the first three rows are:
            // RequirementGUID, Concern, ConcernGUID
            data.Columns.Add(ForcesTableContext.RequirementGUIDHeader);
            data.Columns.Add(ForcesTableContext.ConcernHeader);
            data.Columns.Add(ForcesTableContext.ConcernGUIDHeader);

            // insert the decisions names as new columns in the table
            InsertDecisions(model, data);

            // insert the requirement guids, requirements, concerns and concerns guids


            _forcesTable.DataSource = data;
            InsertRequirementsAndConcerns(model, data);


            // insert the decision guids in the table
            data.Rows.Add(new object[] { ForcesTableContext.EmptyCellValue, ForcesTableContext.EmptyCellValue, ForcesTableContext.EmptyCellValue });
            InsertDecisionGuids(model, data);
            _forcesTable.DataSource = data;
            _forcesTable.Rows[_forcesTable.Rows.Count - 1].HeaderCell.Value = ForcesTableContext.DecisionGUIDHeader;
            HideRow(_forcesTable.Rows.Count - 1);

            if (data.Columns.Count <= 0) return;


            // hide the columns and row which contain the guids of the elements
            HideColumn(ForcesTableContext.RequirementGUIDHeader);
            HideColumn(ForcesTableContext.ConcernGUIDHeader);
            ReadOnlyColumn(ForcesTableContext.ConcernHeader);

            foreach (DataGridViewColumn column in _forcesTable.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            // insert the ratings in the table
            InsertRatings(model, data);
            //activate cell value listener
            _forcesTable.Columns[0].Frozen = true;
            _forcesTable.Columns[1].Frozen = true;
            _forcesTable.CellValueChanged += _forcesTable_CellValueChanged;

            //Change button height according to the height of the last row
            Update_btnLocation(_btnOpenExcel);

            //Update view
            Invalidate(); 

        }

        /// <summary>
        /// Changes the y-position of a button according to the height of the table
        /// </summary>
        /// <param name="button">button to be repositioned</param>
        private void Update_btnLocation(Button button)
        {
            const int offset = 5;
            var height = offset + _forcesTable.ColumnHeadersHeight;

            for (var i = 1; i < _forcesTable.Rows.Count; i++)
            {
                height += _forcesTable.Rows[i].Height;
            }
            button.Top = height;
        }

        public void UpdateDecision(IEAElement element)
        {
            int columnIndex = 0;
            foreach (DataGridViewCell cell in _forcesTable.Rows[_forcesTable.Rows.Count - 1].Cells)
            {
                if (cell.Value.ToString().Equals(element.GUID))
                {
                    _forcesTable.Columns[columnIndex].HeaderText = String.Format("<<{0}>>\n{1}", element.Stereotype,
                                                                                 element.Name);
                    break;
                }
                columnIndex++;
            }
        }

        public void UpdateRequirement(IEAElement element)
        {
            foreach (
                DataGridViewRow row in
                    _forcesTable.Rows.Cast<DataGridViewRow>()
                                .Where(
                                    row => row.Cells[ForcesTableContext.RequirementGUIDColumnIndex].Value.ToString().Equals(element.GUID)))
            {
                row.HeaderCell.Value = element.Name;
            }
        }

        public void UpdateConcern(IEAElement element)
        {
            foreach (
                DataGridViewRow row in
                    _forcesTable.Rows.Cast<DataGridViewRow>()
                                .Where(row => row.Cells[ForcesTableContext.ConcernGUIDColumnIndex].Value.ToString().Equals(element.GUID)))
            {
                row.Cells[ForcesTableContext.ConcernColumnIndex].Value = element.Name;
            }
        }

        public void RemoveDecision(IEAElement element)
        {
            int columnIndex =
                _forcesTable.Rows[_forcesTable.Rows.Count - 1].Cells.Cast<DataGridViewCell>()
                                                              .Count(cell => !cell.Value.ToString().Equals(element.GUID));
            _forcesTable.Columns.RemoveAt(columnIndex);
        }

        public void RemoveRequirement(IEAElement element)
        {
            foreach (
                DataGridViewRow row in
                    _forcesTable.Rows.Cast<DataGridViewRow>()
                                .Where(
                                    row => row.Cells[ForcesTableContext.RequirementGUIDColumnIndex].Value.ToString().Equals(element.GUID)))
            {
                _forcesTable.Rows.Remove(row);
                HideRow(_forcesTable.Rows.Count - 1);
                break;
            }
        }

        public void RemoveConcern(IEAElement element)
        {
            foreach (
                DataGridViewRow row in
                    _forcesTable.Rows.Cast<DataGridViewRow>()
                                .Where(row => row.Cells[ForcesTableContext.ConcernGUIDColumnIndex].Value.ToString().Equals(element.GUID)))
            {
                row.Cells[ForcesTableContext.ConcernColumnIndex].Value = "";
            }
        }

        public string[] RequirementGuids
        {
            get
            {
                return
                    _forcesTable.Rows.Cast<DataGridViewRow>()
                                .Select(row => row.Cells[ForcesTableContext.RequirementGUIDColumnIndex].Value.ToString())
                                .Where(value => !value.Equals(ForcesTableContext.EmptyCellValue))
                                .ToArray();
            }
        }

        public string[] ConcernGuids
        {
            get
            {
                return _forcesTable.Rows.Cast<DataGridViewRow>()
                                   .Select(row => row.Cells[ForcesTableContext.ConcernGUIDColumnIndex].Value.ToString())
                                   .Where(value => !value.Equals(ForcesTableContext.EmptyCellValue))
                                   .ToArray();
            }
        }

        public string[] DecisionGuids
        {
            get
            {
                return _forcesTable.Rows[_forcesTable.Rows.Count - 1].Cells.Cast<DataGridViewCell>()
                                                                     .Select(cell => cell.Value.ToString())
                                                                     .Where(value => !value.Equals(ForcesTableContext.EmptyCellValue))
                                                                     .ToArray();
            }
        }

        public string GetRating(int row, int column)
        {
            return _forcesTable[column, row].Value.ToString();
        }

        public void SetController(IForcesController controller)
        {
            _controller = controller;
        }

        public void Update(IForcesModel model)
        {
            UpdateTable(model);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._forcesTable = new System.Windows.Forms.DataGridView();
            this._btnConfigure = new System.Windows.Forms.Button();
            this._btnOpenExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._forcesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // _forcesTable
            // 
            this._forcesTable.AllowUserToAddRows = false;
            this._forcesTable.AllowUserToDeleteRows = false;
            this._forcesTable.AllowUserToResizeColumns = false;
            this._forcesTable.AllowUserToResizeRows = false;
            this._forcesTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._forcesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._forcesTable.Location = new System.Drawing.Point(0, 0);
            this._forcesTable.Name = "_forcesTable";
            this._forcesTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this._forcesTable.RowTemplate.Height = 33;
            this._forcesTable.Size = new System.Drawing.Size(850, 696);
            this._forcesTable.TabIndex = 2;
            this._forcesTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this._forcesTable_CellValueChanged);
            this._forcesTable.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._forcesTable_ColumnHeaderMouseClick);
            this._forcesTable.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._forcesTable_ColumnHeaderMouseDoubleClick);
            // 
            // _btnConfigure
            // 
            this._btnConfigure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnConfigure.Location = new System.Drawing.Point(772, 2);
            this._btnConfigure.Name = "_btnConfigure";
            this._btnConfigure.Size = new System.Drawing.Size(75, 23);
            this._btnConfigure.TabIndex = 3;
            this._btnConfigure.Text = global::DecisionViewpoints.Messages.ForcesViewConfigureButton;
            this._btnConfigure.UseVisualStyleBackColor = true;
            this._btnConfigure.Click += new System.EventHandler(this._btnConfigure_Click);
            // 
            // _btnOpenExcel
            // 
            this._btnOpenExcel.FlatAppearance.BorderSize = 0;
            this._btnOpenExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnOpenExcel.Location = new System.Drawing.Point(2, 2);
            this._btnOpenExcel.Name = "_btnOpenExcel";
            this._btnOpenExcel.Size = new System.Drawing.Size(75, 23);
            this._btnOpenExcel.TabIndex = 5;
            this._btnOpenExcel.Text = "Excel";
            this._btnOpenExcel.UseVisualStyleBackColor = true;
            this._btnOpenExcel.Click += new System.EventHandler(this._btnOpenExcel_Click);
            // 
            // ForcesView
            // 
            this.Controls.Add(this._btnOpenExcel);
            this.Controls.Add(this._btnConfigure);
            this.Controls.Add(this._forcesTable);
            this.Name = "ForcesView";
            this.Size = new System.Drawing.Size(850, 696);
            ((System.ComponentModel.ISupportInitialize)(this._forcesTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private void ReadOnlyColumn(string header)
        {
            DataGridViewColumn column = _forcesTable.Columns[header];
            if (column != null) column.ReadOnly = true;
        }

        private void HideColumn(string header)
        {
            DataGridViewColumn column = _forcesTable.Columns[header];
            if (column != null)
                column.Visible = false;
        }

        private static void InsertRatings(IForcesModel model, DataTable data)
        {
            foreach (Rating rating in model.GetRatings())
            {
                int decisionColumnIndex = 0;
                for (int index = ForcesTableContext.DecisionColumnIndex; index < data.Columns.Count; index++)
                {
                    if (!data.Rows[data.Rows.Count - 1][index].ToString().Equals(rating.DecisionGUID))
                        continue;
                    decisionColumnIndex = index;
                    break;
                }
                if (decisionColumnIndex == 0) continue;

                foreach (DataRow row in data.Rows)
                {
                    if (row[ForcesTableContext.RequirementGUIDColumnIndex].Equals(rating.RequirementGUID) &&
                        row[ForcesTableContext.ConcernGUIDColumnIndex].Equals(rating.ConcernGUID))
                    {
                        row[decisionColumnIndex] = rating.Value;
                    }
                }
            }
        }

        private void InsertRequirementsAndConcerns(IForcesModel model, DataTable table)
        {
            int rowIndex = 0;
            foreach (var dictionary in model.GetConcernsPerRequirement())
            {
                IEAElement requirement = dictionary.Key;
                List<IEAElement> concerns = dictionary.Value;


                foreach (IEAElement concern in concerns)
                {
                    //in first column add requirement and concern guid
                    var requirementConcernGUID = new object[] { requirement.GUID };
                    DataRow row = table.Rows.Add(requirementConcernGUID);
                    _forcesTable.DataSource = table;
                    _forcesTable.Rows[rowIndex++].HeaderCell.Value = requirement.Name;

                    row[ForcesTableContext.ConcernColumnIndex] = concern.Name;
                    row[ForcesTableContext.ConcernGUIDColumnIndex] = concern.GUID;
                }
            }
        }

        private static void InsertDecisionGuids(IForcesModel model, DataTable data)
        {
            int decisionIndex = 0;
            foreach (IEAElement decision in model.GetDecisions())
            {
                data.Rows[data.Rows.Count - 1][decisionIndex++ + ForcesTableContext.DecisionColumnIndex] = decision.GUID;
            }
        }

        private void InsertDecisions(IForcesModel model, DataTable data)
        {
            foreach (IEAElement decision in model.GetDecisions())
            {
                data.Columns.Add(string.Format("<<{0}>>\n{1}", decision.Stereotype, decision.Name));
            }
        }

        private void HideRow(int index)
        {
            // we need this to hide the last row for when the table has no rows
            // and it is visible as a tab and the user adds new elements
            _forcesTable.CurrentCell = null;
            _forcesTable.Rows[index].Visible = false;
        }

        private void _forcesTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _controller.Save();
        }

        /// <summary>
        /// Opens de Detail Viewpoint on double clicking on a header.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _forcesTable_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Only for decisions
            if (e.ColumnIndex < ForcesTableContext.DecisionColumnIndex) return;

            string elementGUID =
                _forcesTable.Rows[_forcesTable.Rows.Count - 1].Cells[e.ColumnIndex].Value.ToString();
            IEAElement decision = EAFacade.EA.Repository.GetElementByGUID(elementGUID);
            OpenInDetailView(new Decision(decision));
        }

        /// <summary>
        ///  Opens a diagram for the decision that is clicked on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _forcesTable_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Only for decisions
            if (e.ColumnIndex < ForcesTableContext.DecisionColumnIndex) return;

            string elementGUID =
                _forcesTable.Rows[_forcesTable.Rows.Count - 1].Cells[e.ColumnIndex].Value.ToString();
            IEAElement decision = EAFacade.EA.Repository.GetElementByGUID(elementGUID);
            if (e.Button == MouseButtons.Right)
            {
                var menu = new ContextMenu();

                // Menuitem for opening a decision in its diagram
                menu.MenuItems.Add(Messages.ForcesViewOpenDecisionInDiagrams, (o, args) =>
                {
                    IEADiagram[] diagrams = decision.GetDiagrams();
                    if (diagrams.Count() == 1) // open the diagram with the decision if there is only one diagram
                    {
                        IEADiagram diagram = diagrams[0];
                        diagram.OpenAndSelectElement(decision);
                    }
                    else if (diagrams.Count() >= 2) // let the user decide which diagram to open
                    {
                        var selectForm = new SelectDiagram(diagrams);
                        if (selectForm.ShowDialog() == DialogResult.OK)
                        {
                            IEADiagram diagram = selectForm.GetSelectedDiagram();
                            diagram.OpenAndSelectElement(decision);
                        }
                    }
                    decision.ShowInProjectView();
                });
                // Menuitem for opening the detailviewpoint of a decision
                menu.MenuItems.Add(Messages.ForcesViewOpenDecisionInDetailView,
                                   (sender1, e1) => OpenInDetailView(new Decision(decision)));
                // Menuitem for removing a decision
                menu.MenuItems.Add(Messages.ForcesViewRemoveDecision, (sender1, e1) => RemoveFromForces(decision));
                Point relativeMousePosition = PointToClient(Cursor.Position);
                menu.Show(this, relativeMousePosition);
            }
        }

        /// <summary>
        /// Removes an element from the table and diagram
        /// </summary>
        /// <param name="decision">The element to be removed</param>
        private void RemoveFromForces(IEAElement decision)
        {
            IEARepository repository = EAFacade.EA.Repository;
            IEADiagram diagram = repository.GetDiagramByGuid(_controller.Model.DiagramGUID);
            diagram.RemoveFromDiagram(decision);
        }

        private void OpenInDetailView(Decision decision)
        {
            var detailController = new DetailController(decision, new DetailView());
            detailController.ShowDetailView();
        }

        private void _btnConfigure_Click(object sender, EventArgs e)
        {
            _controller.Configure();
        }

        private void _btnOpenExcel_Click(object sender, EventArgs e)
        {
            new Excel(_controller, _forcesTable);
        }
    }
}
