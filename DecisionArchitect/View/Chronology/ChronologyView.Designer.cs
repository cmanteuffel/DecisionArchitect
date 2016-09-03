namespace DecisionArchitect.View.Chronology
{
    partial class ChronologyView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timerShowState = new System.Windows.Forms.Timer(this.components);
            this.vApplicationMenuItem2 = new VIBlend.WinForms.Controls.vApplicationMenuItem();
            this.vApplicationMenuItem3 = new VIBlend.WinForms.Controls.vApplicationMenuItem();
            this.vApplicationMenuItem4 = new VIBlend.WinForms.Controls.vApplicationMenuItem();
            this.vApplicationMenuItem5 = new VIBlend.WinForms.Controls.vApplicationMenuItem();
            this.vApplicationMenuItem6 = new VIBlend.WinForms.Controls.vApplicationMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 28);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowTemplate.Height = 60;
            this.dataGridView1.Size = new System.Drawing.Size(839, 557);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseMove);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.MouseLeave += new System.EventHandler(this.dataGridView1_MouseLeave);
            // 
            // DateColumn
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DateColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.DateColumn.HeaderText = "Column1";
            this.DateColumn.MinimumWidth = 120;
            this.DateColumn.Name = "DateColumn";
            this.DateColumn.ReadOnly = true;
            this.DateColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DateColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // timerShowState
            // 
            this.timerShowState.Interval = 400;
            this.timerShowState.Tick += new System.EventHandler(this.timerShowState_Tick);
            // 
            // vApplicationMenuItem2
            // 
            this.vApplicationMenuItem2.ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.vApplicationMenuItem2.ItemType = VIBlend.WinForms.Controls.vApplicationMenuItemType.MenuItem;
            this.vApplicationMenuItem2.Location = new System.Drawing.Point(0, 0);
            this.vApplicationMenuItem2.Name = "vApplicationMenuItem2";
            this.vApplicationMenuItem2.SelectedChildMenuItem = null;
            this.vApplicationMenuItem2.Size = new System.Drawing.Size(180, 20);
            this.vApplicationMenuItem2.TabIndex = 0;
            this.vApplicationMenuItem2.Text = "vApplicationMenuItem2";
            this.vApplicationMenuItem2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.vApplicationMenuItem2.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // vApplicationMenuItem3
            // 
            this.vApplicationMenuItem3.ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.vApplicationMenuItem3.ItemType = VIBlend.WinForms.Controls.vApplicationMenuItemType.MenuItem;
            this.vApplicationMenuItem3.Location = new System.Drawing.Point(0, 0);
            this.vApplicationMenuItem3.Name = "vApplicationMenuItem3";
            this.vApplicationMenuItem3.SelectedChildMenuItem = null;
            this.vApplicationMenuItem3.Size = new System.Drawing.Size(180, 20);
            this.vApplicationMenuItem3.TabIndex = 0;
            this.vApplicationMenuItem3.Text = "vApplicationMenuItem3";
            this.vApplicationMenuItem3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.vApplicationMenuItem3.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // vApplicationMenuItem4
            // 
            this.vApplicationMenuItem4.ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.vApplicationMenuItem4.ItemType = VIBlend.WinForms.Controls.vApplicationMenuItemType.MenuItem;
            this.vApplicationMenuItem4.Location = new System.Drawing.Point(0, 0);
            this.vApplicationMenuItem4.Name = "vApplicationMenuItem4";
            this.vApplicationMenuItem4.SelectedChildMenuItem = null;
            this.vApplicationMenuItem4.Size = new System.Drawing.Size(180, 20);
            this.vApplicationMenuItem4.TabIndex = 0;
            this.vApplicationMenuItem4.Text = "vApplicationMenuItem4";
            this.vApplicationMenuItem4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.vApplicationMenuItem4.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // vApplicationMenuItem5
            // 
            this.vApplicationMenuItem5.ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.vApplicationMenuItem5.ItemType = VIBlend.WinForms.Controls.vApplicationMenuItemType.MenuItem;
            this.vApplicationMenuItem5.Location = new System.Drawing.Point(0, 0);
            this.vApplicationMenuItem5.Name = "vApplicationMenuItem5";
            this.vApplicationMenuItem5.SelectedChildMenuItem = null;
            this.vApplicationMenuItem5.Size = new System.Drawing.Size(180, 20);
            this.vApplicationMenuItem5.TabIndex = 0;
            this.vApplicationMenuItem5.Text = "vApplicationMenuItem5";
            this.vApplicationMenuItem5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.vApplicationMenuItem5.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // vApplicationMenuItem6
            // 
            this.vApplicationMenuItem6.ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.vApplicationMenuItem6.ItemType = VIBlend.WinForms.Controls.vApplicationMenuItemType.MenuItem;
            this.vApplicationMenuItem6.Location = new System.Drawing.Point(0, 0);
            this.vApplicationMenuItem6.Name = "vApplicationMenuItem6";
            this.vApplicationMenuItem6.SelectedChildMenuItem = null;
            this.vApplicationMenuItem6.Size = new System.Drawing.Size(180, 20);
            this.vApplicationMenuItem6.TabIndex = 0;
            this.vApplicationMenuItem6.Text = "vApplicationMenuItem6";
            this.vApplicationMenuItem6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.vApplicationMenuItem6.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noneToolStripMenuItem,
            this.hourToolStripMenuItem,
            this.dayToolStripMenuItem,
            this.weekToolStripMenuItem,
            this.monthToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(839, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.noneToolStripMenuItem.Text = "None";
            this.noneToolStripMenuItem.Click += new System.EventHandler(this.noneToolStripMenuItem_Click);
            // 
            // hourToolStripMenuItem
            // 
            this.hourToolStripMenuItem.Name = "hourToolStripMenuItem";
            this.hourToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.hourToolStripMenuItem.Text = "Hour";
            this.hourToolStripMenuItem.Click += new System.EventHandler(this.hourToolStripMenuItem_Click);
            // 
            // dayToolStripMenuItem
            // 
            this.dayToolStripMenuItem.Name = "dayToolStripMenuItem";
            this.dayToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.dayToolStripMenuItem.Text = "Day";
            this.dayToolStripMenuItem.Click += new System.EventHandler(this.dayToolStripMenuItem_Click);
            // 
            // weekToolStripMenuItem
            // 
            this.weekToolStripMenuItem.Name = "weekToolStripMenuItem";
            this.weekToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.weekToolStripMenuItem.Text = "Week";
            this.weekToolStripMenuItem.Click += new System.EventHandler(this.weekToolStripMenuItem_Click);
            // 
            // monthToolStripMenuItem
            // 
            this.monthToolStripMenuItem.Name = "monthToolStripMenuItem";
            this.monthToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.monthToolStripMenuItem.Text = "Month";
            this.monthToolStripMenuItem.Click += new System.EventHandler(this.monthToolStripMenuItem_Click);
            // 
            // ChronologyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChronologyView";
            this.Size = new System.Drawing.Size(839, 585);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timerShowState;
        private VIBlend.WinForms.Controls.vApplicationMenuItem vApplicationMenuItem2;
        private VIBlend.WinForms.Controls.vApplicationMenuItem vApplicationMenuItem3;
        private VIBlend.WinForms.Controls.vApplicationMenuItem vApplicationMenuItem4;
        private VIBlend.WinForms.Controls.vApplicationMenuItem vApplicationMenuItem5;
        private VIBlend.WinForms.Controls.vApplicationMenuItem vApplicationMenuItem6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateColumn;
    }
}
