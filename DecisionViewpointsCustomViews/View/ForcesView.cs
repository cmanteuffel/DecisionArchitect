using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using DecisionViewpointsCustomViews.Controller;
using DecisionViewpointsCustomViews.Model;

namespace DecisionViewpointsCustomViews.View
{
    [ComVisible(true)]
    [Guid("D65970AD-12A7-402A-9F88-ED50D8C1DD82")]
    [ProgId("DecisionViewpointsCustomViews.ForcesView")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof (ICustomView))]
    public class ForcesView : UserControl, ICustomView
    {
        private DataGridView _forcesTable;
        private Button _btnConfigure;
        private ICustomViewController _controller;

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

        public ForcesView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this._forcesTable = new System.Windows.Forms.DataGridView();
            this._btnConfigure = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._forcesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // _forcesTable
            // 
            this._forcesTable.AllowUserToAddRows = false;
            this._forcesTable.AllowUserToDeleteRows = false;
            this._forcesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._forcesTable.Location = new System.Drawing.Point(35, 30);
            this._forcesTable.Name = "_forcesTable";
            this._forcesTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this._forcesTable.RowTemplate.Height = 33;
            this._forcesTable.Size = new System.Drawing.Size(762, 582);
            this._forcesTable.TabIndex = 2;
            this._forcesTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this._forcesTable_CellValueChanged);
            // 
            // _btnConfigure
            // 
            this._btnConfigure.Location = new System.Drawing.Point(35, 644);
            this._btnConfigure.Name = "_btnConfigure";
            this._btnConfigure.Size = new System.Drawing.Size(75, 23);
            this._btnConfigure.TabIndex = 3;
            this._btnConfigure.Text = "Configure";
            this._btnConfigure.UseVisualStyleBackColor = true;
            this._btnConfigure.Click += new System.EventHandler(this._btnConfigure_Click);
            // 
            // ForcesView
            // 
            this.Controls.Add(this._btnConfigure);
            this.Controls.Add(this._forcesTable);
            this.Name = "ForcesView";
            this.Size = new System.Drawing.Size(850, 696);
            ((System.ComponentModel.ISupportInitialize)(this._forcesTable)).EndInit();
            this.ResumeLayout(false);

        }

        private void _btnConfigure_Click(object sender, System.EventArgs e)
        {
            _controller.Configure();
        }

        public void SetController(ICustomViewController controller)
        {
            _controller = controller;
        }

        public void Update(ICustomViewModel model)
        {
            UpdateTable(model);
        }

        public void UpdateTable(ICustomViewModel model)
        {
            var data = new DataTable();

            // the first three rows are:
            // RequirementGUID, Concern, ConcernGUID
            data.Columns.Add(RequirementGUIDHeader);
            data.PrimaryKey = new[] {data.Columns[RequirementGUIDHeader]};
            data.Columns.Add(ConcernHeader);
            data.Columns.Add(ConcernGUIDHeader);

            // add columns with the decisions names
            foreach (var decision in model.GetDecisions())
            {
                data.Columns.Add(decision.Name);
            }

            // insert the requirement guids in the table
            foreach (var requirement in model.GetRequirements())
            {
                data.Rows.Add(new object[] {requirement.GUID});
            }

            // insert the decision guids in the table
            data.Rows.Add(new object[] {EmptyCellValue, EmptyCellValue, EmptyCellValue});
            var decisionIndex = 0;
            foreach (var decision in model.GetDecisions())
            {
                data.Rows[data.Rows.Count - 1][decisionIndex++ + DecisionColumnIndex] = decision.GUID;
            }

            // insert the concenrs and concerns guids in the table
            foreach (var reqConcerns in model.GetConcerns())
            {
                var concerns = new StringBuilder();
                var concernsGUID = new StringBuilder();
                var concernIndex = 0;
                foreach (var concern in reqConcerns.Value)
                {
                    if (concernIndex++ > 0)
                    {
                        concerns.Append(", ");
                        concernsGUID.Append(", ");
                    }
                    concerns.Append(concern.Name);
                    concernsGUID.Append(concern.GUID);
                }
                data.Rows.Find(reqConcerns.Key.GUID)[ConcernColumnIndex] = concerns;
                data.Rows.Find(reqConcerns.Key.GUID)[ConcernGUIDColumnIndex] = concernsGUID;
            }

            // insert the ratings in the table
            foreach (var rating in model.GetRatings())
            {
                var decisionColumnIndex = 0;
                for (var index = DecisionColumnIndex; index != data.Columns.Count; index++)
                {
                    if (!data.Rows[data.Rows.Count - 1][index].ToString().Equals(rating.DecisionGUID))
                        continue;
                    decisionColumnIndex = index;
                    break;
                }
                if (decisionColumnIndex == 0) continue;
                var row = data.Rows.Find(rating.RequirementGUID.Split(':')[1]);
                if (row == null) continue;
                row[decisionColumnIndex] = rating.Value;
            }

            _forcesTable.DataSource = data;

            if (data.Columns.Count <= 0) return;

            for (var index = 0; index < model.GetRequirements().Count; index++)
            {
                _forcesTable.Rows[RequirementGUIDRowIndex + index].HeaderCell.Value =
                    model.GetRequirements()[index].Name;
            }
            _forcesTable.Rows[_forcesTable.Rows.Count - 1].HeaderCell.Value = DecisionGUIDHeader;

            // hide the columns which contain the guids of the elements
            var requirementGUIDColumn = _forcesTable.Columns[RequirementGUIDHeader];
            if (requirementGUIDColumn != null)
                requirementGUIDColumn.Visible = false;

            var concernGUIDColumn = _forcesTable.Columns[ConcernGUIDHeader];
            if (concernGUIDColumn != null)
                concernGUIDColumn.Visible = false;

            HideDecisionGUIDRow();

            var concernColumn = _forcesTable.Columns[ConcernHeader];
            if (concernColumn != null) concernColumn.ReadOnly = true;

            foreach (DataGridViewColumn column in _forcesTable.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void RemoveDecision(string guid)
        {
            var columnIndex =
                _forcesTable.Rows[_forcesTable.Rows.Count - 1].Cells.Cast<DataGridViewCell>()
                                                              .Count(cell => !cell.Value.ToString().Equals(guid));
            _forcesTable.Columns.RemoveAt(columnIndex);
        }

        public void RemoveRequirement(string guid)
        {
            foreach (
                var row in
                    _forcesTable.Rows.Cast<DataGridViewRow>()
                                .Where(row => row.Cells[RequirementGUIDColumnIndex].Value.ToString().Equals(guid)))
            {
                _forcesTable.Rows.Remove(row);
                HideDecisionGUIDRow();
                break;
            }
        }

        public void RemoveConcern(string guid)
        {
        }

        public List<string> RequirementGuids
        {
            get
            {
                return
                    _forcesTable.Rows.Cast<DataGridViewRow>()
                                .Select(row => row.Cells[RequirementGUIDColumnIndex].Value.ToString())
                                .Where(value => !value.Equals(EmptyCellValue))
                                .ToList();
            }
        }

        public List<string> ConcernGuids
        {
            get
            {
                return _forcesTable.Rows.Cast<DataGridViewRow>()
                                   .Select(row => row.Cells[ConcernGUIDColumnIndex].Value.ToString())
                                   .Where(value => !value.Equals(EmptyCellValue))
                                   .ToList();
            }
        }

        public List<string> DecisionGuids
        {
            get
            {
                return _forcesTable.Rows[_forcesTable.Rows.Count - 1].Cells.Cast<DataGridViewCell>()
                                                                     .Select(cell => cell.Value.ToString())
                                                                     .Where(value => !value.Equals(EmptyCellValue))
                                                                     .ToList();
            }
        }

        public string GetRating(int row, int column)
        {
            return _forcesTable[column, row].Value.ToString();
        }

        private void HideDecisionGUIDRow()
        {
            _forcesTable.CurrentCell = null;    // we need this to hide the last row for when the table has no rows
                                                // and it is visible as a tab and the user adds new elements
            _forcesTable.Rows[_forcesTable.Rows.Count - 1].Visible = false;
        }

        private void _forcesTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _controller.SaveRatings();
        }
    }
}