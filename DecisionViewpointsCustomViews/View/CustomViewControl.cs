using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DecisionViewpointsCustomViews.Controller;
using DecisionViewpointsCustomViews.Events;
using DecisionViewpointsCustomViews.Model;

namespace DecisionViewpointsCustomViews.View
{
    [ComVisible(true)]
    [Guid("D65970AD-12A7-402A-9F88-ED50D8C1DD82")]
    [ProgId("DecisionViewpointsCustomViews.CustomViewControl")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(ICustomView))]
    public class CustomViewControl : UserControl, ICustomView
    {
        private Button _btnSave;
        private DataGridView _forcesTable;
        private ForcesController _controller;
        private Button _btnConfigure;
        private Label _diagramGUID;
        private Button _btnUpdate;
        private readonly IList<ICustomViewListener> _listeners = new List<ICustomViewListener>();
        
        public CustomViewControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this._btnSave = new System.Windows.Forms.Button();
            this._forcesTable = new System.Windows.Forms.DataGridView();
            this._btnConfigure = new System.Windows.Forms.Button();
            this._diagramGUID = new System.Windows.Forms.Label();
            this._btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._forcesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(35, 644);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(91, 26);
            this._btnSave.TabIndex = 1;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
            // 
            // _forcesTable
            // 
            this._forcesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._forcesTable.Location = new System.Drawing.Point(35, 30);
            this._forcesTable.Name = "_forcesTable";
            this._forcesTable.RowTemplate.Height = 33;
            this._forcesTable.Size = new System.Drawing.Size(762, 582);
            this._forcesTable.TabIndex = 2;
            // 
            // _btnConfigure
            // 
            this._btnConfigure.Location = new System.Drawing.Point(146, 644);
            this._btnConfigure.Name = "_btnConfigure";
            this._btnConfigure.Size = new System.Drawing.Size(75, 23);
            this._btnConfigure.TabIndex = 3;
            this._btnConfigure.Text = "Configure";
            this._btnConfigure.UseVisualStyleBackColor = true;
            this._btnConfigure.Click += new System.EventHandler(this._btnConfigure_Click);
            // 
            // _diagramGUID
            // 
            this._diagramGUID.AutoSize = true;
            this._diagramGUID.Location = new System.Drawing.Point(516, 641);
            this._diagramGUID.Name = "_diagramGUID";
            this._diagramGUID.Size = new System.Drawing.Size(70, 26);
            this._diagramGUID.TabIndex = 4;
            this._diagramGUID.Text = "label1";
            this._diagramGUID.Visible = false;
            // 
            // _btnUpdate
            // 
            this._btnUpdate.Location = new System.Drawing.Point(256, 644);
            this._btnUpdate.Name = "_btnUpdate";
            this._btnUpdate.Size = new System.Drawing.Size(75, 23);
            this._btnUpdate.TabIndex = 5;
            this._btnUpdate.Text = "Update";
            this._btnUpdate.UseVisualStyleBackColor = true;
            this._btnUpdate.Click += new System.EventHandler(this._btnUpdate_Click);
            // 
            // CustomViewControl
            // 
            this.Controls.Add(this._btnUpdate);
            this.Controls.Add(this._diagramGUID);
            this.Controls.Add(this._btnConfigure);
            this.Controls.Add(this._forcesTable);
            this.Controls.Add(this._btnSave);
            this.Name = "CustomViewControl";
            this.Size = new System.Drawing.Size(850, 696);
            ((System.ComponentModel.ISupportInitialize)(this._forcesTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void _btnSave_Click(object sender, System.EventArgs e)
        {
            foreach (var listener in _listeners)
            {
                listener.Save(this);
            }
        }

        private void _btnConfigure_Click(object sender, System.EventArgs e)
        {
            foreach (var listener in _listeners)
            {
                listener.Configure(this);
            }
        }

        private void _btnUpdate_Click(object sender, System.EventArgs e)
        {
            foreach (var listener in _listeners)
            {
                listener.Update(this);
            }
        }

        public void SetController(ForcesController controller)
        {
            _controller = controller;
        }

        public void AddListener(ICustomViewListener l)
        {
            _listeners.Add(l);
        }

        public void UpdateTable(ForcesModel forcesModel)
        {
            _forcesTable.DataSource = forcesModel;

            if (forcesModel.Columns.Count <= 0) return;

            for (var index = 0; index < forcesModel.Rows.Count; index++ )
            {
                _forcesTable.Rows[index].HeaderCell.Value = forcesModel.Requirements[index].Name;
            }
        }

        public string DiagramGUID
        {
            get { return _diagramGUID.Text; }
            set { _diagramGUID.Text = value; }
        }

        
    }
}
