namespace DecisionArchitect.View.Dialogs
{
    partial class CreateStakeholderActionDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmboAction = new System.Windows.Forms.ComboBox();
            this.cmboDecision = new System.Windows.Forms.ComboBox();
            this.cmboStakeholder = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.cmboAction, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmboDecision, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmboStakeholder, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnOk, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(439, 111);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cmboAction
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmboAction, 2);
            this.cmboAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmboAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboAction.FormattingEnabled = true;
            this.cmboAction.Items.AddRange(new object[] {
            "Formulates",
            "Proposes",
            "Discards",
            "Validates",
            "Confirms",
            "Challenges",
            "Rejects"});
            this.cmboAction.Location = new System.Drawing.Point(3, 30);
            this.cmboAction.Name = "cmboAction";
            this.cmboAction.Size = new System.Drawing.Size(433, 21);
            this.cmboAction.TabIndex = 1;
            // 
            // cmboDecision
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmboDecision, 2);
            this.cmboDecision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmboDecision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboDecision.FormattingEnabled = true;
            this.cmboDecision.Location = new System.Drawing.Point(3, 57);
            this.cmboDecision.Name = "cmboDecision";
            this.cmboDecision.Size = new System.Drawing.Size(433, 21);
            this.cmboDecision.TabIndex = 2;
            // 
            // cmboStakeholder
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmboStakeholder, 2);
            this.cmboStakeholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmboStakeholder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboStakeholder.FormattingEnabled = true;
            this.cmboStakeholder.Location = new System.Drawing.Point(3, 3);
            this.cmboStakeholder.Name = "cmboStakeholder";
            this.cmboStakeholder.Size = new System.Drawing.Size(433, 21);
            this.cmboStakeholder.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3, 84);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(361, 84);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // CreateStakeholderActionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 111);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CreateStakeholderActionDialog";
            this.Text = "Add stakeholder interaction";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cmboAction;
        private System.Windows.Forms.ComboBox cmboDecision;
        private System.Windows.Forms.ComboBox cmboStakeholder;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}