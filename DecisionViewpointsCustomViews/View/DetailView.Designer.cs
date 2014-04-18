namespace DecisionViewpointsCustomViews.View
{
    partial class DetailView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxState = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtIssue = new System.Windows.Forms.RichTextBox();
            this.txtDecision = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAlternatives = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtArguments = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRelatedRequirements = new System.Windows.Forms.RichTextBox();
            this.lbxRelatedDecisions = new System.Windows.Forms.ListBox();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.StakeholderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IterationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.lbxAlternativesDecision = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lbxTraces = new System.Windows.Forms.ListBox();
            this.lbxRelatedRequirements = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current State:";
            // 
            // cbxState
            // 
            this.cbxState.FormattingEnabled = true;
            this.cbxState.Items.AddRange(new object[] {
            "idea",
            "tentative",
            "decided",
            "approved",
            "challenged",
            "discarded",
            "rejected"});
            this.cbxState.Location = new System.Drawing.Point(126, 29);
            this.cbxState.Margin = new System.Windows.Forms.Padding(2);
            this.cbxState.Name = "cbxState";
            this.cbxState.Size = new System.Drawing.Size(120, 21);
            this.cbxState.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(126, 6);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(403, 20);
            this.txtName.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(59, 2);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(62, 20);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(2, 2);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(53, 20);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Problem/Issue:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 144);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Decision:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonOk);
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(406, 599);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(123, 27);
            this.flowLayoutPanel1.TabIndex = 20;
            // 
            // txtIssue
            // 
            this.txtIssue.AcceptsTab = true;
            this.txtIssue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIssue.Location = new System.Drawing.Point(126, 88);
            this.txtIssue.Margin = new System.Windows.Forms.Padding(2);
            this.txtIssue.Name = "txtIssue";
            this.txtIssue.Size = new System.Drawing.Size(403, 52);
            this.txtIssue.TabIndex = 7;
            this.txtIssue.Text = "";
            // 
            // txtDecision
            // 
            this.txtDecision.AcceptsTab = true;
            this.txtDecision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDecision.Location = new System.Drawing.Point(126, 144);
            this.txtDecision.Margin = new System.Windows.Forms.Padding(2);
            this.txtDecision.Name = "txtDecision";
            this.txtDecision.Size = new System.Drawing.Size(403, 52);
            this.txtDecision.TabIndex = 9;
            this.txtDecision.Text = "";
            this.txtDecision.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtf_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 203);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Alternatives:";
            // 
            // txtAlternatives
            // 
            this.txtAlternatives.AcceptsTab = true;
            this.txtAlternatives.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlternatives.Location = new System.Drawing.Point(137, 215);
            this.txtAlternatives.Margin = new System.Windows.Forms.Padding(2);
            this.txtAlternatives.Name = "txtAlternatives";
            this.txtAlternatives.Size = new System.Drawing.Size(377, 26);
            this.txtAlternatives.TabIndex = 11;
            this.txtAlternatives.Text = "";
            this.txtAlternatives.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtf_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 259);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Arguments:";
            // 
            // txtArguments
            // 
            this.txtArguments.AcceptsTab = true;
            this.txtArguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArguments.Location = new System.Drawing.Point(126, 256);
            this.txtArguments.Margin = new System.Windows.Forms.Padding(2);
            this.txtArguments.Name = "txtArguments";
            this.txtArguments.Size = new System.Drawing.Size(403, 52);
            this.txtArguments.TabIndex = 13;
            this.txtArguments.Text = "";
            this.txtArguments.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtf_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 54);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Decision Group:";
            // 
            // txtGroup
            // 
            this.txtGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGroup.BackColor = System.Drawing.SystemColors.Window;
            this.txtGroup.Location = new System.Drawing.Point(126, 54);
            this.txtGroup.Margin = new System.Windows.Forms.Padding(2);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.ReadOnly = true;
            this.txtGroup.Size = new System.Drawing.Size(403, 20);
            this.txtGroup.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 312);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Related Decisions:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 375);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Related Requirements:";
            // 
            // txtRelatedRequirements
            // 
            this.txtRelatedRequirements.AcceptsTab = true;
            this.txtRelatedRequirements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRelatedRequirements.Location = new System.Drawing.Point(208, 388);
            this.txtRelatedRequirements.Margin = new System.Windows.Forms.Padding(2);
            this.txtRelatedRequirements.Name = "txtRelatedRequirements";
            this.txtRelatedRequirements.Size = new System.Drawing.Size(243, 21);
            this.txtRelatedRequirements.TabIndex = 17;
            this.txtRelatedRequirements.Text = "";
            // 
            // lbxRelatedDecisions
            // 
            this.lbxRelatedDecisions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxRelatedDecisions.FormattingEnabled = true;
            this.lbxRelatedDecisions.Location = new System.Drawing.Point(126, 312);
            this.lbxRelatedDecisions.Margin = new System.Windows.Forms.Padding(2);
            this.lbxRelatedDecisions.Name = "lbxRelatedDecisions";
            this.lbxRelatedDecisions.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbxRelatedDecisions.Size = new System.Drawing.Size(403, 56);
            this.lbxRelatedDecisions.TabIndex = 15;
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StakeholderColumn,
            this.ActionColumn,
            this.StatusColumn,
            this.IterationColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.916231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistory.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHistory.Location = new System.Drawing.Point(126, 488);
            this.dgvHistory.Margin = new System.Windows.Forms.Padding(2);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowTemplate.Height = 33;
            this.dgvHistory.Size = new System.Drawing.Size(403, 107);
            this.dgvHistory.TabIndex = 19;
            // 
            // StakeholderColumn
            // 
            this.StakeholderColumn.HeaderText = "Stakeholder";
            this.StakeholderColumn.Name = "StakeholderColumn";
            this.StakeholderColumn.ReadOnly = true;
            // 
            // ActionColumn
            // 
            this.ActionColumn.HeaderText = "Action";
            this.ActionColumn.Name = "ActionColumn";
            this.ActionColumn.ReadOnly = true;
            // 
            // StatusColumn
            // 
            this.StatusColumn.HeaderText = "Status";
            this.StatusColumn.Name = "StatusColumn";
            this.StatusColumn.ReadOnly = true;
            // 
            // IterationColumn
            // 
            this.IterationColumn.HeaderText = "Iteration";
            this.IterationColumn.Name = "IterationColumn";
            this.IterationColumn.ReadOnly = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 488);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "History:";
            // 
            // lbxAlternativesDecision
            // 
            this.lbxAlternativesDecision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxAlternativesDecision.FormattingEnabled = true;
            this.lbxAlternativesDecision.Location = new System.Drawing.Point(126, 198);
            this.lbxAlternativesDecision.Margin = new System.Windows.Forms.Padding(2);
            this.lbxAlternativesDecision.Name = "lbxAlternativesDecision";
            this.lbxAlternativesDecision.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbxAlternativesDecision.Size = new System.Drawing.Size(401, 56);
            this.lbxAlternativesDecision.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 428);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Traces";
            // 
            // lbxTraces
            // 
            this.lbxTraces.FormattingEnabled = true;
            this.lbxTraces.Location = new System.Drawing.Point(126, 427);
            this.lbxTraces.Name = "lbxTraces";
            this.lbxTraces.Size = new System.Drawing.Size(403, 56);
            this.lbxTraces.TabIndex = 23;
            // 
            // lbxRelatedRequirements
            // 
            this.lbxRelatedRequirements.FormattingEnabled = true;
            this.lbxRelatedRequirements.HorizontalScrollbar = true;
            this.lbxRelatedRequirements.Location = new System.Drawing.Point(126, 370);
            this.lbxRelatedRequirements.Name = "lbxRelatedRequirements";
            this.lbxRelatedRequirements.Size = new System.Drawing.Size(403, 56);
            this.lbxRelatedRequirements.TabIndex = 24;
            // 
            // DetailView
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(540, 638);
            this.Controls.Add(this.lbxRelatedRequirements);
            this.Controls.Add(this.lbxTraces);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbxAlternativesDecision);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.lbxRelatedDecisions);
            this.Controls.Add(this.txtRelatedRequirements);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtArguments);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAlternatives);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDecision);
            this.Controls.Add(this.txtIssue);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cbxState);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(408, 504);
            this.Name = "DetailView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detail View";
            this.Load += new System.EventHandler(this.DetailView_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxState;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RichTextBox txtIssue;
        private System.Windows.Forms.RichTextBox txtDecision;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtAlternatives;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtArguments;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox txtRelatedRequirements;
        private System.Windows.Forms.ListBox lbxRelatedDecisions;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn StakeholderColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IterationColumn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lbxAlternativesDecision;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox lbxTraces;
        private System.Windows.Forms.ListBox lbxRelatedRequirements;
    }
}