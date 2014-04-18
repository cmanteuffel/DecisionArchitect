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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.StakeholderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IterationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 26);
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
            this.cbxState.Location = new System.Drawing.Point(253, 68);
            this.cbxState.Name = "cbxState";
            this.cbxState.Size = new System.Drawing.Size(235, 33);
            this.cbxState.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(253, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(561, 31);
            this.txtName.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(134, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(125, 38);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(3, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(125, 38);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Problem/Issue:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 26);
            this.label4.TabIndex = 8;
            this.label4.Text = "Decision:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.buttonOk);
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(588, 1176);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(266, 47);
            this.flowLayoutPanel1.TabIndex = 20;
            // 
            // txtIssue
            // 
            this.txtIssue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIssue.Location = new System.Drawing.Point(253, 182);
            this.txtIssue.Name = "txtIssue";
            this.txtIssue.Size = new System.Drawing.Size(529, 96);
            this.txtIssue.TabIndex = 7;
            this.txtIssue.Text = "";
            // 
            // txtDecision
            // 
            this.txtDecision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDecision.Location = new System.Drawing.Point(253, 303);
            this.txtDecision.Name = "txtDecision";
            this.txtDecision.Size = new System.Drawing.Size(529, 96);
            this.txtDecision.TabIndex = 9;
            this.txtDecision.Text = "";
            this.txtDecision.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtf_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 424);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 26);
            this.label5.TabIndex = 10;
            this.label5.Text = "Alternatives:";
            // 
            // txtAlternatives
            // 
            this.txtAlternatives.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlternatives.Location = new System.Drawing.Point(253, 424);
            this.txtAlternatives.Name = "txtAlternatives";
            this.txtAlternatives.Size = new System.Drawing.Size(529, 96);
            this.txtAlternatives.TabIndex = 11;
            this.txtAlternatives.Text = "";
            this.txtAlternatives.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtf_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 545);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 26);
            this.label6.TabIndex = 12;
            this.label6.Text = "Arguments:";
            // 
            // txtArguments
            // 
            this.txtArguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArguments.Location = new System.Drawing.Point(253, 545);
            this.txtArguments.Name = "txtArguments";
            this.txtArguments.Size = new System.Drawing.Size(529, 96);
            this.txtArguments.TabIndex = 13;
            this.txtArguments.Text = "";
            this.txtArguments.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtf_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 26);
            this.label7.TabIndex = 4;
            this.label7.Text = "Decision Group:";
            // 
            // txtGroup
            // 
            this.txtGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGroup.BackColor = System.Drawing.SystemColors.Window;
            this.txtGroup.Location = new System.Drawing.Point(253, 126);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.ReadOnly = true;
            this.txtGroup.Size = new System.Drawing.Size(529, 31);
            this.txtGroup.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 666);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(194, 26);
            this.label8.TabIndex = 14;
            this.label8.Text = "Related Decisions:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 795);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(235, 26);
            this.label9.TabIndex = 16;
            this.label9.Text = "Related Requirements:";
            // 
            // txtRelatedRequirements
            // 
            this.txtRelatedRequirements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRelatedRequirements.Location = new System.Drawing.Point(253, 795);
            this.txtRelatedRequirements.Name = "txtRelatedRequirements";
            this.txtRelatedRequirements.Size = new System.Drawing.Size(529, 96);
            this.txtRelatedRequirements.TabIndex = 17;
            this.txtRelatedRequirements.Text = "";
            // 
            // lbxRelatedDecisions
            // 
            this.lbxRelatedDecisions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxRelatedDecisions.FormattingEnabled = true;
            this.lbxRelatedDecisions.ItemHeight = 25;
            this.lbxRelatedDecisions.Location = new System.Drawing.Point(253, 666);
            this.lbxRelatedDecisions.Name = "lbxRelatedDecisions";
            this.lbxRelatedDecisions.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbxRelatedDecisions.Size = new System.Drawing.Size(529, 104);
            this.lbxRelatedDecisions.TabIndex = 15;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StakeholderColumn,
            this.ActionColumn,
            this.StatusColumn,
            this.IterationColumn});
            this.dataGridView1.Location = new System.Drawing.Point(253, 916);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(529, 206);
            this.dataGridView1.TabIndex = 19;
            // 
            // StakeholderColumn
            // 
            this.StakeholderColumn.HeaderText = "Stakeholder";
            this.StakeholderColumn.Name = "StakeholderColumn";
            // 
            // ActionColumn
            // 
            this.ActionColumn.HeaderText = "Action";
            this.ActionColumn.Name = "ActionColumn";
            // 
            // StatusColumn
            // 
            this.StatusColumn.HeaderText = "Status";
            this.StatusColumn.Name = "StatusColumn";
            // 
            // IterationColumn
            // 
            this.IterationColumn.HeaderText = "Iteration";
            this.IterationColumn.Name = "IterationColumn";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 916);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 26);
            this.label10.TabIndex = 18;
            this.label10.Text = "History:";
            // 
            // DetailView
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(866, 1235);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridView1);
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
            this.MinimumSize = new System.Drawing.Size(800, 1050);
            this.Name = "DetailView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detail View";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StakeholderColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IterationColumn;
        private System.Windows.Forms.Label label10;
    }
}