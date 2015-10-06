namespace DecisionArchitect.View.Stakeholders
{
    partial class StakeholdersView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.stakeholderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCreate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newStakeholderInvolvementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newStakeholderInvolvementToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.menuCreate.SuspendLayout();
            this.menuDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 60;
            this.dataGridView1.Size = new System.Drawing.Size(745, 395);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // Column1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stakeholderToolStripMenuItem,
            this.decisionToolStripMenuItem,
            this.actionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(745, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // stakeholderToolStripMenuItem
            // 
            this.stakeholderToolStripMenuItem.Name = "stakeholderToolStripMenuItem";
            this.stakeholderToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.stakeholderToolStripMenuItem.Text = "Stakeholder";
            this.stakeholderToolStripMenuItem.Click += new System.EventHandler(this.stakeholderToolStripMenuItem_Click);
            // 
            // decisionToolStripMenuItem
            // 
            this.decisionToolStripMenuItem.Name = "decisionToolStripMenuItem";
            this.decisionToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.decisionToolStripMenuItem.Text = "Decision";
            this.decisionToolStripMenuItem.Click += new System.EventHandler(this.decisionToolStripMenuItem_Click);
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.actionToolStripMenuItem.Text = "Action";
            this.actionToolStripMenuItem.Click += new System.EventHandler(this.actionToolStripMenuItem_Click);
            // 
            // menuCreate
            // 
            this.menuCreate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newStakeholderInvolvementToolStripMenuItem});
            this.menuCreate.Name = "contextMenuStrip1";
            this.menuCreate.Size = new System.Drawing.Size(232, 26);
            // 
            // newStakeholderInvolvementToolStripMenuItem
            // 
            this.newStakeholderInvolvementToolStripMenuItem.Name = "newStakeholderInvolvementToolStripMenuItem";
            this.newStakeholderInvolvementToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.newStakeholderInvolvementToolStripMenuItem.Text = "New stakeholder involvement";
            this.newStakeholderInvolvementToolStripMenuItem.Click += new System.EventHandler(this.newStakeholderInvolvementToolStripMenuItem_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.newStakeholderInvolvementToolStripMenuItem1});
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(232, 70);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // newStakeholderInvolvementToolStripMenuItem1
            // 
            this.newStakeholderInvolvementToolStripMenuItem1.Name = "newStakeholderInvolvementToolStripMenuItem1";
            this.newStakeholderInvolvementToolStripMenuItem1.Size = new System.Drawing.Size(231, 22);
            this.newStakeholderInvolvementToolStripMenuItem1.Text = "New stakeholder involvement";
            this.newStakeholderInvolvementToolStripMenuItem1.Click += new System.EventHandler(this.newStakeholderInvolvementToolStripMenuItem_Click);
            // 
            // StakeholdersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "StakeholdersView";
            this.Size = new System.Drawing.Size(745, 419);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuCreate.ResumeLayout(false);
            this.menuDelete.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem stakeholderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decisionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip menuCreate;
        private System.Windows.Forms.ToolStripMenuItem newStakeholderInvolvementToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip menuDelete;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newStakeholderInvolvementToolStripMenuItem1;
    }
}
