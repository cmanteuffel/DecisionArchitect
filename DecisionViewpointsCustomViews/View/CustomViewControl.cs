using System.Runtime.InteropServices;
using System.Windows.Forms;
using DecisionViewpointsCustomViews.Controller;
using DecisionViewpointsCustomViews.Model;
using DecisionViewpointsCustomViews.View;

namespace DecisionViewpointsCustomViews
{
    [ComVisible(true)]
    [Guid("D65970AD-12A7-402A-9F88-ED50D8C1DD82")]
    [ProgId("DecisionViewpointsCustomViews.CustomViewControl")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(ICustomView))]
    public class CustomViewControl : UserControl, ICustomView
    {
        private Button btnSave;
        private DataGridView forcesTable;
        private ForcesController _controller;
        
        public CustomViewControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.forcesTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.forcesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(35, 644);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 26);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // forcesTable
            // 
            this.forcesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.forcesTable.Location = new System.Drawing.Point(35, 30);
            this.forcesTable.Name = "forcesTable";
            this.forcesTable.RowTemplate.Height = 33;
            this.forcesTable.Size = new System.Drawing.Size(762, 582);
            this.forcesTable.TabIndex = 2;
            // 
            // CustomViewControl
            // 
            this.Controls.Add(this.forcesTable);
            this.Controls.Add(this.btnSave);
            this.Name = "CustomViewControl";
            this.Size = new System.Drawing.Size(850, 696);
            ((System.ComponentModel.ISupportInitialize)(this.forcesTable)).EndInit();
            this.ResumeLayout(false);

        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            
        }

        public void SetController(ForcesController controller)
        {
            _controller = controller;
        }

        public void UpdateTable(ForcesModel forcesModel)
        {
            foreach (var requirement in forcesModel.Requirements)
            {
                MessageBox.Show(requirement.Name);
            }
        }
    }
}
