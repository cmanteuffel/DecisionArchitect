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
using DecisionArchitect.Logic.EventHandler;
using DecisionArchitect.Logic.Forces;
using DecisionArchitect.Model;
using DecisionArchitect.Utilities;
using DecisionArchitect.View.Controller;
using EAFacade;
using EAFacade.Model;
using Decision = DecisionArchitect.Model.Decision;
using IDecision = DecisionArchitect.Model.IDecision;

namespace DecisionArchitect.View.Forces
{
    [ComVisible(true)]
    [Guid("B2219386-7889-4250-86A5-74760300A1F8")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof (IForcesView))]
    [ProgId("DecisionViewpoints.Forces")]
    public class ForcesView : UserControl, IForcesView
    {
        private Button _btnAddDecision;
        private Button _btnAddForce;
        private Button _btnConfigure;
        private Button _btnOpenExcel;
        private IForcesController _controller;
        private DataGridView _forcesTable;

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
            // ForceGUID, Concern, ConcernGUID
            data.Columns.Add(ForcesTableContext.ForceGUIDHeader);
            data.Columns.Add(ForcesTableContext.ConcernHeader);
            data.Columns.Add(ForcesTableContext.ConcernGUIDHeader);

            // insert the decisions names as new columns in the table
            InsertDecisions(model, data);

            // insert the force guids, force, concerns and concerns guids
            _forcesTable.DataSource = data;
            InsertForcesAndConcerns(model, data);

            // insert the decision guids in the table
            data.Rows.Add(new object[]
                {
                    ForcesTableContext.EmptyCellValue, ForcesTableContext.EmptyCellValue, ForcesTableContext.EmptyCellValue
                });
            InsertDecisionGuids(model, data);
            _forcesTable.DataSource = data;
            _forcesTable.Rows[_forcesTable.Rows.Count - 1].HeaderCell.Value = ForcesTableContext.DecisionGUIDHeader;
            HideRow(_forcesTable.Rows.Count - 1);

            if (data.Columns.Count <= 0) return;


            // hide the columns and row which contain the guids of the elements
            HideColumn(ForcesTableContext.ForceGUIDHeader);
            HideColumn(ForcesTableContext.ConcernGUIDHeader);
            ReadOnlyColumn(ForcesTableContext.ConcernHeader);

            foreach (DataGridViewColumn column in _forcesTable.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                // Colour decision header
                ColourDecisionHeader(_forcesTable.Columns.IndexOf(column));
            }

            //Colour each row header
            foreach (DataGridViewRow row in _forcesTable.Rows)
            {
                ColourForceHeader(_forcesTable.Rows.IndexOf(row));
            }

            // insert the ratings in the table
            InsertRatings(model, data);
            //activate cell value listener
            _forcesTable.Columns[0].Frozen = true;
            _forcesTable.Columns[1].Frozen = true;
            _forcesTable.CellValueChanged += _forcesTable_CellValueChanged;

            //Update view
            Invalidate();
        }

        /// <summary>
        ///     Update a decision's name and its colour
        /// </summary>
        /// <param name="element"></param>
        public void UpdateDecision(IEAElement element)
        {
            int columnIndex = 0;
            foreach (DataGridViewCell cell in _forcesTable.Rows[_forcesTable.Rows.Count - 1].Cells)
            {
                if (cell.Value.ToString().Equals(element.GUID))
                {
                    _forcesTable.Columns[columnIndex].HeaderText = String.Format("<<{0}>>\n{1}", element.Stereotype,
                                                                                 element.Name);
                    ColourDecisionHeader(columnIndex);
                    break;
                }
                columnIndex++;
            }
        }

        /// <summary>
        ///     Update a force's name and its colour if it's a decision
        /// </summary>
        /// <param name="element"></param>
        public void UpdateForce(IEAElement element)
        {
            int rowIndex = 0;
            foreach (
                DataGridViewRow row in
                    _forcesTable.Rows.Cast<DataGridViewRow>()
                                .Where(
                                    row =>
                                    row.Cells[ForcesTableContext.ForceGUIDColumnIndex].Value.ToString()
                                                                                      .Equals(element.GUID)))
            {
                row.HeaderCell.Value = element.Name;
                ColourForceHeader(rowIndex);
                rowIndex++;
            }
        }

        /// <summary>
        ///     Update the concern's name
        /// </summary>
        /// <param name="element"></param>
        public void UpdateConcern(IEAElement element)
        {
            foreach (
                DataGridViewRow row in
                    _forcesTable.Rows.Cast<DataGridViewRow>()
                                .Where(
                                    row =>
                                    row.Cells[ForcesTableContext.ConcernGUIDColumnIndex].Value.ToString()
                                                                                        .Equals(element.GUID)))
            {
                row.Cells[ForcesTableContext.ConcernColumnIndex].Value = element.Name;
            }
        }

        /// <summary>
        ///     Remove the decision from the ForcesView
        /// </summary>
        /// <param name="element"></param>
        public void RemoveDecision(IEAElement element)
        {
            RemoveDecisionFromDiagram(element);
            IEARepository repository = EAMain.Repository;
            _controller.SetDiagramModel(repository.GetDiagramByGuid(_controller.Model.DiagramGUID));
        }

        /// <summary>
        ///     Remove the force from the ForcesView
        /// </summary>
        /// <param name="element"></param>
        public void RemoveForce(IEAElement element)
        {
            for (int i = _forcesTable.Rows.Count - 1; i >= 0; i--)
            {
                //Skip other elements
                if (
                    _forcesTable.Rows[i].Cells[ForcesTableContext.ForceGUIDColumnIndex].Value.Equals(
                        ForcesTableContext.EmptyCellValue)) continue;
                if (
                    !_forcesTable.Rows[i].Cells[ForcesTableContext.ForceGUIDColumnIndex].Value.ToString()
                                                                                        .Equals(element.GUID)) continue;
                RemoveForceFromDiagram(i);
            }

            IEARepository repository = EAMain.Repository;
            _controller.SetDiagramModel(repository.GetDiagramByGuid(_controller.Model.DiagramGUID));
        }

        /// <summary>
        ///     Remove the concern from the ForcesView (Will remove the force with the concern)
        /// </summary>
        /// <param name="element"></param>
        public void RemoveConcern(IEAElement element)
        {
            for (int i = _forcesTable.Rows.Count - 1; i >= 0; i--)
            {
                //Skip other elements
                if (
                    _forcesTable.Rows[i].Cells[ForcesTableContext.ConcernGUIDColumnIndex].Value.Equals(
                        ForcesTableContext.EmptyCellValue)) continue;
                if (
                    !_forcesTable.Rows[i].Cells[ForcesTableContext.ConcernGUIDColumnIndex].Value.ToString()
                                                                                          .Equals(element.GUID))
                    continue;
                RemoveForceFromDiagram(i);
            }

            IEARepository repository = EAMain.Repository;
            _controller.SetDiagramModel(repository.GetDiagramByGuid(_controller.Model.DiagramGUID));
        }

        public string[] ForceGuids
        {
            get
            {
                return
                    _forcesTable.Rows.Cast<DataGridViewRow>()
                                .Select(row => row.Cells[ForcesTableContext.ForceGUIDColumnIndex].Value.ToString())
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
                                                                     .Where(
                                                                         value =>
                                                                         !value.Equals(ForcesTableContext.EmptyCellValue))
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
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._forcesTable = new System.Windows.Forms.DataGridView();
            this._btnConfigure = new System.Windows.Forms.Button();
            this._btnAddDecision = new System.Windows.Forms.Button();
            this._btnOpenExcel = new System.Windows.Forms.Button();
            this._btnAddForce = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this._forcesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // _forcesTable
            // 
            this._forcesTable.AllowUserToAddRows = false;
            this._forcesTable.AllowUserToDeleteRows = false;
            this._forcesTable.AllowUserToResizeColumns = false;
            this._forcesTable.AllowUserToResizeRows = false;
            this._forcesTable.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
            this._forcesTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._forcesTable.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._forcesTable.EnableHeadersVisualStyles = false;
            this._forcesTable.Location = new System.Drawing.Point(0, 32);
            this._forcesTable.Name = "_forcesTable";
            this._forcesTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._forcesTable.RowHeadersWidthSizeMode =
                System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this._forcesTable.RowTemplate.Height = 33;
            this._forcesTable.Size = new System.Drawing.Size(850, 657);
            this._forcesTable.TabIndex = 2;
            this._forcesTable.CellValueChanged +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this._forcesTable_CellValueChanged);
            this._forcesTable.ColumnHeaderMouseClick +=
                new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._forcesTable_ColumnHeaderMouseClick);
            this._forcesTable.ColumnHeaderMouseDoubleClick +=
                new System.Windows.Forms.DataGridViewCellMouseEventHandler(
                    this._forcesTable_ColumnHeaderMouseDoubleClick);
            this._forcesTable.RowHeaderMouseClick +=
                new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._forcesTable_RowHeaderMouseClick);
            // 
            // _btnConfigure
            // 
            this._btnConfigure.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnConfigure.Location = new System.Drawing.Point(772, 3);
            this._btnConfigure.Name = "_btnConfigure";
            this._btnConfigure.Size = new System.Drawing.Size(75, 23);
            this._btnConfigure.TabIndex = 3;
            this._btnConfigure.Text = global::DecisionArchitect.Messages.ForcesViewConfigureButton;
            this._btnConfigure.UseVisualStyleBackColor = true;
            this._btnConfigure.Visible = false;
            this._btnConfigure.Click += new System.EventHandler(this._btnConfigure_Click);
            // 
            // _btnAddDecision
            // 
            this._btnAddDecision.AutoSize = true;
            this._btnAddDecision.FlatAppearance.BorderSize = 0;
            this._btnAddDecision.Location = new System.Drawing.Point(3, 3);
            this._btnAddDecision.Name = "_btnAddDecision";
            this._btnAddDecision.Size = new System.Drawing.Size(80, 23);
            this._btnAddDecision.TabIndex = 4;
            this._btnAddDecision.Text = "Add Decision";
            this._btnAddDecision.UseVisualStyleBackColor = true;
            this._btnAddDecision.Click += new System.EventHandler(this._btnAddDecision_Click);
            // 
            // _btnOpenExcel
            // 
            this._btnOpenExcel.AutoSize = true;
            this._btnOpenExcel.FlatAppearance.BorderSize = 0;
            this._btnOpenExcel.Location = new System.Drawing.Point(173, 3);
            this._btnOpenExcel.Name = "_btnOpenExcel";
            this._btnOpenExcel.Size = new System.Drawing.Size(80, 23);
            this._btnOpenExcel.TabIndex = 5;
            this._btnOpenExcel.Text = "Excel";
            this._btnOpenExcel.UseVisualStyleBackColor = true;
            this._btnOpenExcel.Click += new System.EventHandler(this._btnOpenExcel_Click);
            // 
            // _btnAddForce
            // 
            this._btnAddForce.Location = new System.Drawing.Point(89, 3);
            this._btnAddForce.Name = "_btnAddForce";
            this._btnAddForce.Size = new System.Drawing.Size(80, 23);
            this._btnAddForce.TabIndex = 6;
            this._btnAddForce.Text = "Add Force";
            this._btnAddForce.UseVisualStyleBackColor = true;
            this._btnAddForce.Click += new System.EventHandler(this._btnAddForce_Click);
            // 
            // ForcesView
            // 
            this.Controls.Add(this._btnAddForce);
            this.Controls.Add(this._btnOpenExcel);
            this.Controls.Add(this._btnAddDecision);
            this.Controls.Add(this._btnConfigure);
            this.Controls.Add(this._forcesTable);
            this.Name = "ForcesView";
            this.Size = new System.Drawing.Size(850, 689);
            ((System.ComponentModel.ISupportInitialize) (this._forcesTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        /// <summary>
        ///     Colours the header of a decision column according to the state of the decision
        /// </summary>
        /// <param name="i"></param>
        private void ColourDecisionHeader(int i)
        {
            if (i < ForcesTableContext.DecisionColumnIndex) return;
            string decisionGuid = _forcesTable.Rows[_forcesTable.Rows.Count - 1].Cells[i].Value.ToString();
            DataGridViewColumn column = _forcesTable.Columns[i];
            if (column.HeaderCell == null) return;
            IEARepository repository = EAMain.Repository;
            column.HeaderCell.Style.BackColor =
                RetrieveColorByState(repository.GetElementByGUID(decisionGuid).Stereotype);
        }

        /// <summary>
        ///     Colours the header of a row according to the state of the element in the row if it is a decision
        /// </summary>
        /// <param name="i"></param>
        private void ColourForceHeader(int i)
        {
            DataGridViewRow row = _forcesTable.Rows[i];
            string guid = row.Cells[ForcesTableContext.ForceGUIDColumnIndex].Value.ToString();
            if (guid.Equals(ForcesTableContext.EmptyCellValue)) return;
            IEARepository repository = EAMain.Repository;
            IEAElement element = repository.GetElementByGUID(guid);
            if (element == null || row.HeaderCell == null || !EAMain.IsDecision(element)) return;
            row.HeaderCell.Style.BackColor = RetrieveColorByState(element.Stereotype);
        }

        /// <summary>
        ///     Retrieves the colour belonging to the state
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        private Color RetrieveColorByState(string state)
        {
            return DecisionStateColor.ConvertStateToColor(state);
        }

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
                    if (row[ForcesTableContext.ForceGUIDColumnIndex].Equals(rating.ForceGUID) &&
                        row[ForcesTableContext.ConcernGUIDColumnIndex].Equals(rating.ConcernGUID))
                    {
                        row[decisionColumnIndex] = rating.Value;
                    }
                }
            }
        }

        private void InsertForcesAndConcerns(IForcesModel model, DataTable table)
        {
            int rowIndex = 0;
            foreach (var dictionary in model.GetConcernsPerForce())
            {
                IEAElement force = dictionary.Key;
                List<IEAElement> concerns = dictionary.Value;

                foreach (IEAElement concern in concerns)
                {
                    //in first column add force and concern guid
                    var forceConcernGuid = new object[] {force.GUID};
                    DataRow row = table.Rows.Add(forceConcernGuid);
                    _forcesTable.DataSource = table;
                    _forcesTable.Rows[rowIndex++].HeaderCell.Value = force.Name;

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
                if (!decision.TaggedValueExists(EATaggedValueKeys.IsDecisionElement, model.DiagramGUID)) continue;
                data.Rows[data.Rows.Count - 1][decisionIndex++ + ForcesTableContext.DecisionColumnIndex] = decision.GUID;
            }
        }

        private void InsertDecisions(IForcesModel model, DataTable data)
        {
            foreach (IEAElement decision in model.GetDecisions())
            {
                if (!decision.TaggedValueExists(EATaggedValueKeys.IsDecisionElement, model.DiagramGUID)) continue;
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
        ///     Opens de Detail Viewpoint on double clicking on a header.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _forcesTable_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Only for decisions
            if (e.ColumnIndex < ForcesTableContext.DecisionColumnIndex) return;

            string elementGuid =
                _forcesTable.Rows[_forcesTable.Rows.Count - 1].Cells[e.ColumnIndex].Value.ToString();
            IEAElement decision = EAMain.Repository.GetElementByGUID(elementGuid);
            OpenInDetailView(Decision.Load(decision));
        }

        /// <summary>
        ///     Defines MenuItems for a right click on a column's header
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _forcesTable_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Only for decisions
            if (e.ColumnIndex < ForcesTableContext.DecisionColumnIndex) return;

            string elementGuid =
                _forcesTable.Rows[_forcesTable.Rows.Count - 1].Cells[e.ColumnIndex].Value.ToString();
            IEAElement decision = EAMain.Repository.GetElementByGUID(elementGuid);
            if (e.Button == MouseButtons.Right)
            {
                var menu = new ContextMenu();

                // Menuitem for opening a decision in its diagram
                menu.MenuItems.Add(Messages.ForcesViewOpenDecisionInDiagrams,
                                   (o, args) => OpenDecisionInDiagrams(decision));

                // Menuitem for opening the detailviewpoint of a decision
                menu.MenuItems.Add(Messages.ForcesViewOpenDecisionInDetailView,
                                   (sender1, e1) => OpenInDetailView(Decision.Load(decision)));

                // Menuitem for a separator
                menu.MenuItems.Add("-");

                // Menuitem for removing a decision
                menu.MenuItems.Add(Messages.ForcesViewRemoveDecision, (sender1, e1) =>
                    {
                        RemoveDecisionFromDiagram(decision);
                        IEARepository repository = EAMain.Repository;
                        _controller.SetDiagramModel(repository.GetDiagramByGuid(_controller.Model.DiagramGUID));
                    });

                // Meneitem for removing all decision
                menu.MenuItems.Add(Messages.ForcesViewRemoveAllDecisions,
                                   (sender1, e1) => RemoveAllDecisionsFromDiagram());

                Point relativeMousePosition = PointToClient(Cursor.Position);
                menu.Show(this, relativeMousePosition);
            }
        }

        private void OpenDecisionInDiagrams(IEAElement decision)
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
        }

        /// <summary>
        ///     Defines MenuItems for right clicking on a row's header
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _forcesTable_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var menu = new ContextMenu();
                // Menuitem for removing a force
                menu.MenuItems.Add(Messages.ForcesViewRemoveForce, (sender1, e1) =>
                    {
                        RemoveForceFromDiagram(e.RowIndex);
                        IEARepository repository = EAMain.Repository;
                        _controller.SetDiagramModel(repository.GetDiagramByGuid(_controller.Model.DiagramGUID));
                    });

                // Menuitem for removing all forces
                menu.MenuItems.Add(Messages.ForcesViewRemoveAllForces, (sender1, e1) => RemoveAllForcesFromDiagram());

                Point relativeMousePosition = PointToClient(Cursor.Position);
                menu.Show(this, relativeMousePosition);
            }
        }

        /// <summary>
        ///     Removes a decision from the table and diagram
        /// </summary>
        /// <param name="decision">The element to be removed</param>
        private void RemoveDecisionFromDiagram(IEAElement decision)
        {
            IEARepository repository = EAMain.Repository;
            string diagramGuid = _controller.Model.DiagramGUID;
            IEADiagram diagram = repository.GetDiagramByGuid(diagramGuid);

            //Remove the TaggedValue of the decision
            decision.RemoveTaggedValue(EATaggedValueKeys.IsDecisionElement, diagramGuid);

            //Delete the element if it is not used in the diagram/table anymore
            if (!ElementExistsInDiagram(decision, diagramGuid)) diagram.RemoveElement(decision);
        }

        /// <summary>
        ///     Removes all decisions from the table and diagram
        /// </summary>
        private void RemoveAllDecisionsFromDiagram()
        {
            IEARepository repository = EAMain.Repository;
            string diagramGuid = _controller.Model.DiagramGUID;
            IEADiagram diagram = repository.GetDiagramByGuid(diagramGuid);

            for (int i = ForcesTableContext.DecisionColumnIndex; i < _forcesTable.Columns.Count; i++)
            {
                string decisionGuid = _forcesTable.Rows[_forcesTable.Rows.Count - 1].Cells[i].Value.ToString();
                IEAElement decision = EAMain.Repository.GetElementByGUID(decisionGuid);
                RemoveDecisionFromDiagram(decision);
            }
            _controller.SetDiagramModel(diagram);
        }

        /// <summary>
        ///     Removes a force/concern from the table and diagram (if necessary). Diagram should be update afterwards
        /// </summary>
        /// <param name="rowIndex">The element to be removed</param>
        private void RemoveForceFromDiagram(int rowIndex)
        {
            //Get the GUIDs from the diagram, force and concern
            string diagramGuid = _controller.Model.DiagramGUID;
            string forceGuid =
                _forcesTable.Rows[rowIndex].Cells[ForcesTableContext.ForceGUIDColumnIndex].Value.ToString();
            string concernGuid =
                _forcesTable.Rows[rowIndex].Cells[ForcesTableContext.ConcernGUIDColumnIndex].Value.ToString();

            //Get the diagram, force and concern objects
            IEARepository repository = EAMain.Repository;
            IEADiagram diagram = repository.GetDiagramByGuid(diagramGuid);
            IEAElement force = repository.GetElementByGUID(forceGuid);
            IEAElement concern = repository.GetElementByGUID(concernGuid);

            foreach (
                IEAConnector connector in
                    force.FindConnectors(concern, EAConstants.RelationClassifiedBy, EAConstants.ForcesConnectorType))
            {
                if (connector.TaggedValueExists(EATaggedValueKeys.IsForceConnector, diagramGuid))
                {
                    connector.RemoveTaggedValue(EATaggedValueKeys.IsForceConnector, diagramGuid);
                    if (!connector.TaggedValueExists(EATaggedValueKeys.IsForceConnector))
                    {
                        force.RemoveConnector(connector);
                        concern.RemoveConnector(connector);
                    }
                    break;
                }
            }

            //Remove the TaggedValue of the force and concern
            force.RemoveTaggedValue(EATaggedValueKeys.IsForceElement, diagramGuid);
            concern.RemoveTaggedValue(EATaggedValueKeys.IsConcernElement, diagramGuid);

            //Delete the element if it is not used in the diagram/table anymore
            if (!ElementExistsInDiagram(force, diagramGuid)) diagram.RemoveElement(force);
            if (!ElementExistsInDiagram(concern, diagramGuid)) diagram.RemoveElement(concern);
        }

        private void RemoveAllForcesFromDiagram()
        {
            for (int i = _forcesTable.Rows.Count - 1; i >= 0; i--)
            {
                if (
                    _forcesTable.Rows[i].Cells[ForcesTableContext.ForceGUIDColumnIndex].Value.Equals(
                        ForcesTableContext.EmptyCellValue)) continue;
                RemoveForceFromDiagram(i);
            }

            IEARepository repository = EAMain.Repository;
            _controller.SetDiagramModel(repository.GetDiagramByGuid(_controller.Model.DiagramGUID));
        }

        /// <summary>
        ///     Checks if element el exists in the diagram, with GUID diagramGuid, as a decision, force or concern by looking at its taggedvalues
        /// </summary>
        /// <param name="el"></param>
        /// <param name="diagramGuid"></param>
        /// <returns></returns>
        private bool ElementExistsInDiagram(IEAElement el, string diagramGuid)
        {
            return el.TaggedValueExists(EATaggedValueKeys.IsForceElement, diagramGuid) ||
                   el.TaggedValueExists(EATaggedValueKeys.IsDecisionElement, diagramGuid) ||
                   el.TaggedValueExists(EATaggedValueKeys.IsConcernElement, diagramGuid);
        }

        private void OpenInDetailView(IDecision decision)
        {
            DetailViewHandler.Instance.OpenDecisionDetailView(decision);
        }

        private void _btnConfigure_Click(object sender, EventArgs e)
        {
            _controller.Configure();
        }

        private void _btnOpenExcel_Click(object sender, EventArgs e)
        {
            new ExcelSynchronization(_controller, _forcesTable);
        }

        private void _btnAddDecision_Click(object sender, EventArgs e)
        {
            var addDecision = new AddDecision(_controller);
            addDecision.ShowDialog();
        }

        private void _btnAddForce_Click(object sender, EventArgs e)
        {
            var addForce = new AddForce(_controller);
            addForce.ShowDialog();
        }
    }
}