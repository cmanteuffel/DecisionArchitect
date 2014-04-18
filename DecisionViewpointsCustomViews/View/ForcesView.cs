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
        private Button _btnSave;
        private DataGridView _forcesTable;
        private Button _btnConfigure;
        private ICustomViewController _controller;

        private const int DecisionColumnIndex = 2;
        private const int ConcernColumnIndex = 1;

        private const string ConcernHeader = "Concern";
        private const string RequirementGUIDHeader = "RequirementGUID";
        private const string DecisionGUIDHeader = "DecisionGUID";

        public ForcesView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this._btnSave = new System.Windows.Forms.Button();
            this._forcesTable = new System.Windows.Forms.DataGridView();
            this._btnConfigure = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this._forcesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(35, 644);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(75, 23);
            this._btnSave.TabIndex = 1;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
            // 
            // _forcesTable
            // 
            this._forcesTable.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._forcesTable.Location = new System.Drawing.Point(35, 30);
            this._forcesTable.Name = "_forcesTable";
            this._forcesTable.RowHeadersWidthSizeMode =
                System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this._forcesTable.RowTemplate.Height = 33;
            this._forcesTable.Size = new System.Drawing.Size(762, 582);
            this._forcesTable.TabIndex = 2;
            // 
            // _btnConfigure
            // 
            this._btnConfigure.Location = new System.Drawing.Point(116, 644);
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
            this.Controls.Add(this._btnSave);
            this.Name = "ForcesView";
            this.Size = new System.Drawing.Size(850, 696);
            ((System.ComponentModel.ISupportInitialize) (this._forcesTable)).EndInit();
            this.ResumeLayout(false);
        }

        private void _btnSave_Click(object sender, System.EventArgs e)
        {
            _controller.SaveRatings();
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

            data.Columns.Add(RequirementGUIDHeader);
            data.PrimaryKey = new[] {data.Columns[RequirementGUIDHeader]};
            data.Columns.Add(ConcernHeader);

            foreach (var decision in model.GetDecisions())
            {
                data.Columns.Add(decision.Name);
            }
            foreach (var requirement in model.GetRequirements())
            {
                data.Rows.Add(new object[] {requirement.GUID});
            }
            data.Rows.Add(new object[] {0});

            foreach (var reqConcerns in model.GetConcerns())
            {
                var concerns = new StringBuilder();
                var concernIndex = 0;
                foreach (var concern in reqConcerns.Value)
                {
                    if (concernIndex++ > 0)
                        concerns.Append(", ");
                    concerns.Append(concern.Name);
                }
                data.Rows.Find(reqConcerns.Key.GUID)[ConcernColumnIndex] = concerns;
            }

            var decisionIndex = 0;
            foreach (var decision in model.GetDecisions())
            {
                data.Rows[data.Rows.Count - 1][decisionIndex++ + DecisionColumnIndex] = decision.GUID;
            }

            _forcesTable.DataSource = data;

            if (data.Columns.Count <= 0) return;

            for (var index = 0; index < model.GetRequirements().Count; index++)
            {
                _forcesTable.Rows[index].HeaderCell.Value = model.GetRequirements()[index].Name;
            }
            _forcesTable.Rows[_forcesTable.Rows.Count - DecisionColumnIndex].HeaderCell.Value = DecisionGUIDHeader;

            var requirementGUIDColumn = _forcesTable.Columns[RequirementGUIDHeader];
            if (requirementGUIDColumn != null)
                requirementGUIDColumn.Visible = false;

            _forcesTable.Rows[_forcesTable.Rows.Count - DecisionColumnIndex].Visible = false;

            _forcesTable.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            // TODO: deactivate the concern column, and row and column headers
            // TODO: permit only certain symbols for ratings
            // TODO: bug when deleting element from project browser
        }

        public void RemoveDecision(string name)
        {
            _forcesTable.Columns.Remove(name);
        }

        public void RemoveRequirement(string name)
        {
            foreach (
                var row in
                    _forcesTable.Rows.Cast<DataGridViewRow>().Where(row => row.HeaderCell.Value.Equals(name)))
            {
                _forcesTable.Rows.Remove(row);
            }
        }
    }
}