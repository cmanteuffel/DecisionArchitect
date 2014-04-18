using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DecisionViewpointsCustomViews.Controller;
using DecisionViewpointsCustomViews.Model;
using EAFacade;
using EAFacade.Model;

//using MenuItem = DecisionViewpointsCustomViews.Model.Menu.MenuItem; //angor task 149

namespace DecisionViewpointsCustomViews.View
{
    [ComVisible(true)]
    [Guid("D65970AD-12A7-402A-9F88-ED50D8C1DD82")]
    [ProgId("DecisionViewpointsCustomViews.ForcesView")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof (IForcesView))]
    public class ForcesView : UserControl, IForcesView
    {
        private const string EmptyCellValue = "-";

        private const int RequirementGUIDColumnIndex = 0;
        private const int RequirementGUIDRowIndex = 0;
        private const int ConcernColumnIndex = 1;
        private const int ConcernGUIDColumnIndex = 2;
        private const int DecisionColumnIndex = 3;

        private const string ConcernHeader = "Concern";
        private const string ConcernGUIDHeader = "ConcernGUID";
        private const string RequirementGUIDHeader = "RequirementGUID";
        private const string DecisionGUIDHeader = "DecisionGUID";
        private Button _btnConfigure;
        private IForcesController _controller;
        private DataGridView _forcesTable;

        //angor task149 ContextMenu
        private ToolTip datagridToolTip = new ToolTip();

        public ForcesView()
        {
            InitializeComponent();
        }

        public void SetController(IForcesController controller)
        {
            _controller = controller;
        }

        public void Update(IForcesModel model)
        {
            UpdateTable(model);
        }

        public void UpdateTable(IForcesModel model)
        {
            //deactivate cell value listener
            _forcesTable.CellValueChanged -= _forcesTable_CellValueChanged;

            var data = new DataTable();

            // the first three rows are:
            // RequirementGUID, Concern, ConcernGUID
            data.Columns.Add(RequirementGUIDHeader);
            data.Columns.Add(ConcernHeader);
            data.Columns.Add(ConcernGUIDHeader);

            // insert the decisions names as new columns in the table
            InsertDecisions(model, data);

            // insert the requirement guids, requirements, concerns and concerns guids

            

            _forcesTable.DataSource = data;
            InsertRequirementsAndConcerns(model, data);

            

            // insert the decision guids in the table
            data.Rows.Add(new object[] {EmptyCellValue, EmptyCellValue, EmptyCellValue});
            InsertDecisionGuids(model, data);
            _forcesTable.DataSource = data;
            _forcesTable.Rows[_forcesTable.Rows.Count - 1].HeaderCell.Value = DecisionGUIDHeader;
            HideRow(_forcesTable.Rows.Count - 1);

            if (data.Columns.Count <= 0) return;


            // hide the columns and row which contain the guids of the elements
            HideColumn(RequirementGUIDHeader);
            HideColumn(ConcernGUIDHeader);
            ReadOnlyColumn(ConcernHeader);

            foreach (DataGridViewColumn column in _forcesTable.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            // insert the ratings in the table
            InsertRatings(model, data);
            //activate cell value listener
            _forcesTable.CellValueChanged += _forcesTable_CellValueChanged;
        }

        public void UpdateDecision(EAElement element)
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

        public void UpdateRequirement(EAElement element)
        {
            foreach (
                DataGridViewRow row in
                    _forcesTable.Rows.Cast<DataGridViewRow>()
                                .Where(
                                    row => row.Cells[RequirementGUIDColumnIndex].Value.ToString().Equals(element.GUID)))
            {
                row.HeaderCell.Value = element.Name;
            }
        }

        public void UpdateConcern(EAElement element)
        {
            foreach (
                DataGridViewRow row in
                    _forcesTable.Rows.Cast<DataGridViewRow>()
                                .Where(row => row.Cells[ConcernGUIDColumnIndex].Value.ToString().Equals(element.GUID)))
            {
                row.Cells[ConcernColumnIndex].Value = element.Name;
            }
        }

        public void RemoveDecision(EAElement element)
        {
            int columnIndex =
                _forcesTable.Rows[_forcesTable.Rows.Count - 1].Cells.Cast<DataGridViewCell>()
                                                              .Count(cell => !cell.Value.ToString().Equals(element.GUID));
            _forcesTable.Columns.RemoveAt(columnIndex);
        }

        public void RemoveRequirement(EAElement element)
        {
            foreach (
                DataGridViewRow row in
                    _forcesTable.Rows.Cast<DataGridViewRow>()
                                .Where(
                                    row => row.Cells[RequirementGUIDColumnIndex].Value.ToString().Equals(element.GUID)))
            {
                _forcesTable.Rows.Remove(row);
                HideRow(_forcesTable.Rows.Count - 1);
                break;
            }
        }

        public void RemoveConcern(EAElement element)
        {
            foreach (
                DataGridViewRow row in
                    _forcesTable.Rows.Cast<DataGridViewRow>()
                                .Where(row => row.Cells[ConcernGUIDColumnIndex].Value.ToString().Equals(element.GUID)))
            {
                row.Cells[ConcernColumnIndex].Value = "";
            }
        }

        public string[] RequirementGuids
        {
            get
            {
                return
                    _forcesTable.Rows.Cast<DataGridViewRow>()
                                .Select(row => row.Cells[RequirementGUIDColumnIndex].Value.ToString())
                                .Where(value => !value.Equals(EmptyCellValue))
                                .ToArray();
            }
        }

        public string[] ConcernGuids
        {
            get
            {
                return _forcesTable.Rows.Cast<DataGridViewRow>()
                                   .Select(row => row.Cells[ConcernGUIDColumnIndex].Value.ToString())
                                   .Where(value => !value.Equals(EmptyCellValue))
                                   .ToArray();
            }
        }

        public string[] DecisionGuids
        {
            get
            {
                return _forcesTable.Rows[_forcesTable.Rows.Count - 1].Cells.Cast<DataGridViewCell>()
                                                                     .Select(cell => cell.Value.ToString())
                                                                     .Where(value => !value.Equals(EmptyCellValue))
                                                                     .ToArray();
            }
        }

        public string GetRating(int row, int column)
        {
            return _forcesTable[column, row].Value.ToString();
        }

        private void InitializeComponent()
        {
            _forcesTable = new DataGridView();
            _btnConfigure = new Button();
            ((ISupportInitialize) (_forcesTable)).BeginInit();
            SuspendLayout();
            // 
            // _forcesTable
            // 
            _forcesTable.AllowUserToAddRows = false;
            _forcesTable.AllowUserToDeleteRows = false;
            _forcesTable.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom)
                                   | AnchorStyles.Left)
                                  | AnchorStyles.Right;
            _forcesTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _forcesTable.Location = new Point(35, 30);
            _forcesTable.Name = "_forcesTable";
            _forcesTable.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            _forcesTable.RowTemplate.Height = 33;
            _forcesTable.Size = new Size(762, 582);
            _forcesTable.TabIndex = 2;
            _forcesTable.CellValueChanged += _forcesTable_CellValueChanged;
            _forcesTable.ColumnHeaderMouseClick += _forcesTable_ColumnHeaderMouseClick;
            _forcesTable.ColumnHeaderMouseDoubleClick += _forcesTable_ColumnHeaderMouseDoubleClick;
            // 
            // _btnConfigure
            // 
            _btnConfigure.Anchor = (((AnchorStyles.Bottom | AnchorStyles.Left)));
            _btnConfigure.Location = new Point(35, 644);
            _btnConfigure.Name = "_btnConfigure";
            _btnConfigure.Size = new Size(75, 23);
            _btnConfigure.TabIndex = 3;
            _btnConfigure.Text = "Configure";
            _btnConfigure.UseVisualStyleBackColor = true;
            _btnConfigure.Click += _btnConfigure_Click;
            // 
            // ForcesView
            // 
            Controls.Add(_btnConfigure);
            Controls.Add(_forcesTable);
            Name = "ForcesView";
            Size = new Size(850, 696);
            ((ISupportInitialize) (_forcesTable)).EndInit();
            ResumeLayout(false);

            //angor task 149
        }

        private void _btnConfigure_Click(object sender, EventArgs e)
        {
            _controller.Configure();
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
                for (int index = DecisionColumnIndex; index != data.Columns.Count; index++)
                {
                    if (!data.Rows[data.Rows.Count - 1][index].ToString().Equals(rating.DecisionGUID))
                        continue;
                    decisionColumnIndex = index;
                    break;
                }
                if (decisionColumnIndex == 0) continue;

                foreach (DataRow row in data.Rows)
                {
                    if (row[RequirementGUIDColumnIndex].Equals(rating.RequirementGUID) &&
                        row[ConcernGUIDColumnIndex].Equals(rating.ConcernGUID))
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
                EAElement requirement = dictionary.Key;
                List<EAElement> concerns = dictionary.Value;


                foreach (EAElement concern in concerns)
                {
                    //in first column add requirement and concern guid
                    var requirementConcernGUID = new object[] {requirement.GUID};
                    DataRow row = table.Rows.Add(requirementConcernGUID);
                    _forcesTable.DataSource = table;
                    _forcesTable.Rows[rowIndex++].HeaderCell.Value = requirement.Name;

                    row[ConcernColumnIndex] = concern.Name;
                    row[ConcernGUIDColumnIndex] = concern.GUID;
                }
            }
        }

        private static void InsertDecisionGuids(IForcesModel model, DataTable data)
        {
            int decisionIndex = 0;
            foreach (EAElement decision in model.GetDecisions())
            {
                data.Rows[data.Rows.Count - 1][decisionIndex++ + DecisionColumnIndex] = decision.GUID;
            }
        }

        private static void InsertDecisions(IForcesModel model, DataTable data)
        {
            foreach (EAElement decision in model.GetDecisions())
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

        private void _forcesTable_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < DecisionColumnIndex) return;

            string elementGUID = _forcesTable.Rows[_forcesTable.Rows.Count - 1].Cells[e.ColumnIndex].Value.ToString();
            EAElement element = EARepository.Instance.GetElementByGUID(elementGUID);
            EADiagram[] diagrams = element.GetDiagrams();
            if (diagrams.Count() == 1)
            {
                EADiagram diagram = diagrams[0];
                diagram.OpenAndSelectElement(element);
            }
            else if (diagrams.Count() >= 2)
            {
                var selectForm = new SelectDiagram(diagrams);
                if (selectForm.ShowDialog() == DialogResult.OK)
                {
                    EADiagram diagram = selectForm.GetSelectedDiagram();
                    diagram.OpenAndSelectElement(element);
                }
            }
            element.ShowInProjectView();
        }

        private void _forcesTable_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < DecisionColumnIndex) return;
            if (e.Button == MouseButtons.Right)
            {
                string elementGUID =
                    _forcesTable.Rows[_forcesTable.Rows.Count - 1].Cells[e.ColumnIndex].Value.ToString();
                EAElement decision = EARepository.Instance.GetElementByGUID(elementGUID);
                var detailController = new DetailController(new Decision(decision), new DetailView()); //angor
                Point pos = PointToClient(Cursor.Position);

                detailController.ShowDetailView();

                // ContextMenu menu = new ContextMenu();
                /*
                var details = new Model.Menu.Menu("Details View")
                {
                    ClickDelegate = () =>
                        {
                            MessageBox.Show("It works");
                        }
                };
                 * */
            }
        }
    }
}