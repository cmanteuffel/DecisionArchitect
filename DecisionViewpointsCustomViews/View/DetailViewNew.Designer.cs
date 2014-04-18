namespace DecisionViewpointsCustomViews.View
{
    partial class DetailViewNew
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxState = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.tbCnrtlModifiable = new System.Windows.Forms.TabControl();
            this.ProblemTab = new System.Windows.Forms.TabPage();
            this.txtIssue = new System.Windows.Forms.RichTextBox();
            this.DescriptionTab = new System.Windows.Forms.TabPage();
            this.txtDecision = new System.Windows.Forms.RichTextBox();
            this.ArgumentsTab = new System.Windows.Forms.TabPage();
            this.txtArguments = new System.Windows.Forms.RichTextBox();
            this.btnBold = new System.Windows.Forms.Button();
            this.btnItalics = new System.Windows.Forms.Button();
            this.btnunderline = new System.Windows.Forms.Button();
            this.btnHyperlink = new System.Windows.Forms.Button();
            this.tbCntrlUnodifiable = new System.Windows.Forms.TabControl();
            this.AlternativeTb = new System.Windows.Forms.TabPage();
            this.dgvAlternatives = new System.Windows.Forms.DataGridView();
            this.AlternativeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlternativeFor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelatedDecisionsTb = new System.Windows.Forms.TabPage();
            this.dgvRelatedDecisions = new System.Windows.Forms.DataGridView();
            this.RelatedName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Relation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelatedTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelatedFilesTb = new System.Windows.Forms.TabPage();
            this.dgvRelatedFiles = new System.Windows.Forms.DataGridView();
            this.RelatedRequirementsTb = new System.Windows.Forms.TabPage();
            this.dgvRelatedRequirements = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concern = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TracesTb = new System.Windows.Forms.TabPage();
            this.dgvTraces = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HistoryTb = new System.Windows.Forms.TabPage();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.Stakeholder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iteration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tbCnrtlModifiable.SuspendLayout();
            this.ProblemTab.SuspendLayout();
            this.DescriptionTab.SuspendLayout();
            this.ArgumentsTab.SuspendLayout();
            this.tbCntrlUnodifiable.SuspendLayout();
            this.AlternativeTb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlternatives)).BeginInit();
            this.RelatedDecisionsTb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatedDecisions)).BeginInit();
            this.RelatedFilesTb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatedFiles)).BeginInit();
            this.RelatedRequirementsTb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatedRequirements)).BeginInit();
            this.TracesTb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraces)).BeginInit();
            this.HistoryTb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(13, 13);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(55, 10);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(502, 20);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "State:";
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
            this.cbxState.Location = new System.Drawing.Point(55, 36);
            this.cbxState.Name = "cbxState";
            this.cbxState.Size = new System.Drawing.Size(162, 21);
            this.cbxState.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Group:";
            // 
            // txtGroup
            // 
            this.txtGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGroup.Location = new System.Drawing.Point(55, 63);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(502, 20);
            this.txtGroup.TabIndex = 6;
            // 
            // tbCnrtlModifiable
            // 
            this.tbCnrtlModifiable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCnrtlModifiable.Controls.Add(this.ProblemTab);
            this.tbCnrtlModifiable.Controls.Add(this.DescriptionTab);
            this.tbCnrtlModifiable.Controls.Add(this.ArgumentsTab);
            this.tbCnrtlModifiable.Location = new System.Drawing.Point(16, 95);
            this.tbCnrtlModifiable.MinimumSize = new System.Drawing.Size(0, 140);
            this.tbCnrtlModifiable.Name = "tbCnrtlModifiable";
            this.tbCnrtlModifiable.SelectedIndex = 0;
            this.tbCnrtlModifiable.Size = new System.Drawing.Size(512, 210);
            this.tbCnrtlModifiable.TabIndex = 7;
            // 
            // ProblemTab
            // 
            this.ProblemTab.Controls.Add(this.txtIssue);
            this.ProblemTab.Location = new System.Drawing.Point(4, 22);
            this.ProblemTab.Name = "ProblemTab";
            this.ProblemTab.Padding = new System.Windows.Forms.Padding(3);
            this.ProblemTab.Size = new System.Drawing.Size(504, 184);
            this.ProblemTab.TabIndex = 0;
            this.ProblemTab.Text = "Problem";
            this.ProblemTab.UseVisualStyleBackColor = true;
            // 
            // txtIssue
            // 
            this.txtIssue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIssue.Location = new System.Drawing.Point(2, 2);
            this.txtIssue.Margin = new System.Windows.Forms.Padding(2);
            this.txtIssue.Name = "txtIssue";
            this.txtIssue.Size = new System.Drawing.Size(500, 180);
            this.txtIssue.TabIndex = 0;
            this.txtIssue.Text = "";
            this.txtIssue.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtIssue_LinkClicked);
            // 
            // DescriptionTab
            // 
            this.DescriptionTab.Controls.Add(this.txtDecision);
            this.DescriptionTab.Location = new System.Drawing.Point(4, 22);
            this.DescriptionTab.Name = "DescriptionTab";
            this.DescriptionTab.Padding = new System.Windows.Forms.Padding(3);
            this.DescriptionTab.Size = new System.Drawing.Size(504, 184);
            this.DescriptionTab.TabIndex = 1;
            this.DescriptionTab.Text = "Decision";
            this.DescriptionTab.UseVisualStyleBackColor = true;
            // 
            // txtDecision
            // 
            this.txtDecision.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDecision.Location = new System.Drawing.Point(2, 2);
            this.txtDecision.Margin = new System.Windows.Forms.Padding(2);
            this.txtDecision.Name = "txtDecision";
            this.txtDecision.Size = new System.Drawing.Size(500, 180);
            this.txtDecision.TabIndex = 0;
            this.txtDecision.Text = "";
            // 
            // ArgumentsTab
            // 
            this.ArgumentsTab.Controls.Add(this.txtArguments);
            this.ArgumentsTab.Location = new System.Drawing.Point(4, 22);
            this.ArgumentsTab.Name = "ArgumentsTab";
            this.ArgumentsTab.Size = new System.Drawing.Size(504, 184);
            this.ArgumentsTab.TabIndex = 2;
            this.ArgumentsTab.Text = "Arguments";
            this.ArgumentsTab.UseVisualStyleBackColor = true;
            // 
            // txtArguments
            // 
            this.txtArguments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArguments.Location = new System.Drawing.Point(2, 2);
            this.txtArguments.Margin = new System.Windows.Forms.Padding(2);
            this.txtArguments.Name = "txtArguments";
            this.txtArguments.Size = new System.Drawing.Size(500, 180);
            this.txtArguments.TabIndex = 0;
            this.txtArguments.Text = "";
            // 
            // btnBold
            // 
            this.btnBold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBold.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnBold.Location = new System.Drawing.Point(530, 121);
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(29, 24);
            this.btnBold.TabIndex = 8;
            this.btnBold.Text = "B";
            this.btnBold.UseVisualStyleBackColor = true;
            this.btnBold.Click += new System.EventHandler(this.btnBold_Click);
            // 
            // btnItalics
            // 
            this.btnItalics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnItalics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItalics.Font = new System.Drawing.Font("Castellar", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItalics.Location = new System.Drawing.Point(530, 150);
            this.btnItalics.Name = "btnItalics";
            this.btnItalics.Size = new System.Drawing.Size(29, 25);
            this.btnItalics.TabIndex = 9;
            this.btnItalics.Text = "I";
            this.btnItalics.UseVisualStyleBackColor = true;
            this.btnItalics.Click += new System.EventHandler(this.btnItalics_Click);
            // 
            // btnunderline
            // 
            this.btnunderline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnunderline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnunderline.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Underline);
            this.btnunderline.Location = new System.Drawing.Point(530, 180);
            this.btnunderline.Name = "btnunderline";
            this.btnunderline.Size = new System.Drawing.Size(29, 25);
            this.btnunderline.TabIndex = 10;
            this.btnunderline.Text = "U";
            this.btnunderline.UseVisualStyleBackColor = true;
            this.btnunderline.Click += new System.EventHandler(this.btnunderline_Click);
            // 
            // btnHyperlink
            // 
            this.btnHyperlink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHyperlink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHyperlink.Location = new System.Drawing.Point(530, 210);
            this.btnHyperlink.Name = "btnHyperlink";
            this.btnHyperlink.Size = new System.Drawing.Size(29, 24);
            this.btnHyperlink.TabIndex = 11;
            this.btnHyperlink.Text = "h";
            this.btnHyperlink.UseVisualStyleBackColor = true;
            // 
            // tbCntrlUnodifiable
            // 
            this.tbCntrlUnodifiable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCntrlUnodifiable.Controls.Add(this.AlternativeTb);
            this.tbCntrlUnodifiable.Controls.Add(this.RelatedDecisionsTb);
            this.tbCntrlUnodifiable.Controls.Add(this.RelatedFilesTb);
            this.tbCntrlUnodifiable.Controls.Add(this.RelatedRequirementsTb);
            this.tbCntrlUnodifiable.Controls.Add(this.TracesTb);
            this.tbCntrlUnodifiable.Controls.Add(this.HistoryTb);
            this.tbCntrlUnodifiable.Location = new System.Drawing.Point(16, 311);
            this.tbCntrlUnodifiable.Name = "tbCntrlUnodifiable";
            this.tbCntrlUnodifiable.SelectedIndex = 0;
            this.tbCntrlUnodifiable.Size = new System.Drawing.Size(541, 210);
            this.tbCntrlUnodifiable.TabIndex = 12;
            // 
            // AlternativeTb
            // 
            this.AlternativeTb.BackColor = System.Drawing.SystemColors.Control;
            this.AlternativeTb.Controls.Add(this.dgvAlternatives);
            this.AlternativeTb.Location = new System.Drawing.Point(4, 22);
            this.AlternativeTb.Name = "AlternativeTb";
            this.AlternativeTb.Padding = new System.Windows.Forms.Padding(3);
            this.AlternativeTb.Size = new System.Drawing.Size(533, 184);
            this.AlternativeTb.TabIndex = 0;
            this.AlternativeTb.Text = "Alternatives";
            // 
            // dgvAlternatives
            // 
            this.dgvAlternatives.AllowUserToAddRows = false;
            this.dgvAlternatives.AllowUserToDeleteRows = false;
            this.dgvAlternatives.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlternatives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlternatives.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AlternativeName,
            this.AlternativeFor});
            this.dgvAlternatives.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlternatives.Location = new System.Drawing.Point(3, 3);
            this.dgvAlternatives.Name = "dgvAlternatives";
            this.dgvAlternatives.ReadOnly = true;
            this.dgvAlternatives.RowHeadersVisible = false;
            this.dgvAlternatives.Size = new System.Drawing.Size(527, 178);
            this.dgvAlternatives.TabIndex = 19;
            // 
            // AlternativeName
            // 
            this.AlternativeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AlternativeName.HeaderText = "Decision Name";
            this.AlternativeName.Name = "AlternativeName";
            this.AlternativeName.ReadOnly = true;
            // 
            // AlternativeFor
            // 
            this.AlternativeFor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AlternativeFor.HeaderText = "Alternative for";
            this.AlternativeFor.Name = "AlternativeFor";
            this.AlternativeFor.ReadOnly = true;
            // 
            // RelatedDecisionsTb
            // 
            this.RelatedDecisionsTb.BackColor = System.Drawing.SystemColors.Control;
            this.RelatedDecisionsTb.Controls.Add(this.dgvRelatedDecisions);
            this.RelatedDecisionsTb.Location = new System.Drawing.Point(4, 22);
            this.RelatedDecisionsTb.Name = "RelatedDecisionsTb";
            this.RelatedDecisionsTb.Padding = new System.Windows.Forms.Padding(3);
            this.RelatedDecisionsTb.Size = new System.Drawing.Size(533, 184);
            this.RelatedDecisionsTb.TabIndex = 1;
            this.RelatedDecisionsTb.Text = "Related Decisions";
            // 
            // dgvRelatedDecisions
            // 
            this.dgvRelatedDecisions.AllowUserToAddRows = false;
            this.dgvRelatedDecisions.AllowUserToDeleteRows = false;
            this.dgvRelatedDecisions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRelatedDecisions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelatedDecisions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RelatedName,
            this.Relation,
            this.RelatedTo});
            this.dgvRelatedDecisions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRelatedDecisions.Location = new System.Drawing.Point(3, 3);
            this.dgvRelatedDecisions.Name = "dgvRelatedDecisions";
            this.dgvRelatedDecisions.ReadOnly = true;
            this.dgvRelatedDecisions.RowHeadersVisible = false;
            this.dgvRelatedDecisions.Size = new System.Drawing.Size(527, 178);
            this.dgvRelatedDecisions.TabIndex = 19;
            // 
            // RelatedName
            // 
            this.RelatedName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RelatedName.HeaderText = "Decision Name";
            this.RelatedName.Name = "RelatedName";
            this.RelatedName.ReadOnly = true;
            // 
            // Relation
            // 
            this.Relation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Relation.HeaderText = "Relation";
            this.Relation.Name = "Relation";
            this.Relation.ReadOnly = true;
            // 
            // RelatedTo
            // 
            this.RelatedTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RelatedTo.HeaderText = "Related to";
            this.RelatedTo.Name = "RelatedTo";
            this.RelatedTo.ReadOnly = true;
            // 
            // RelatedFilesTb
            // 
            this.RelatedFilesTb.BackColor = System.Drawing.SystemColors.Control;
            this.RelatedFilesTb.Controls.Add(this.dgvRelatedFiles);
            this.RelatedFilesTb.Location = new System.Drawing.Point(4, 22);
            this.RelatedFilesTb.Name = "RelatedFilesTb";
            this.RelatedFilesTb.Size = new System.Drawing.Size(533, 184);
            this.RelatedFilesTb.TabIndex = 2;
            this.RelatedFilesTb.Text = "Related Files";
            // 
            // dgvRelatedFiles
            // 
            this.dgvRelatedFiles.AllowUserToAddRows = false;
            this.dgvRelatedFiles.AllowUserToDeleteRows = false;
            this.dgvRelatedFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRelatedFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelatedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRelatedFiles.Location = new System.Drawing.Point(0, 0);
            this.dgvRelatedFiles.Name = "dgvRelatedFiles";
            this.dgvRelatedFiles.ReadOnly = true;
            this.dgvRelatedFiles.RowHeadersVisible = false;
            this.dgvRelatedFiles.Size = new System.Drawing.Size(533, 184);
            this.dgvRelatedFiles.TabIndex = 19;
            // 
            // RelatedRequirementsTb
            // 
            this.RelatedRequirementsTb.BackColor = System.Drawing.SystemColors.Control;
            this.RelatedRequirementsTb.Controls.Add(this.dgvRelatedRequirements);
            this.RelatedRequirementsTb.Location = new System.Drawing.Point(4, 22);
            this.RelatedRequirementsTb.Name = "RelatedRequirementsTb";
            this.RelatedRequirementsTb.Size = new System.Drawing.Size(533, 184);
            this.RelatedRequirementsTb.TabIndex = 3;
            this.RelatedRequirementsTb.Text = "Related Requirements";
            // 
            // dgvRelatedRequirements
            // 
            this.dgvRelatedRequirements.AllowUserToAddRows = false;
            this.dgvRelatedRequirements.AllowUserToDeleteRows = false;
            this.dgvRelatedRequirements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRelatedRequirements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelatedRequirements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.Concern,
            this.Rating,
            this.dataGridViewTextBoxColumn3});
            this.dgvRelatedRequirements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRelatedRequirements.Location = new System.Drawing.Point(0, 0);
            this.dgvRelatedRequirements.Name = "dgvRelatedRequirements";
            this.dgvRelatedRequirements.ReadOnly = true;
            this.dgvRelatedRequirements.RowHeadersVisible = false;
            this.dgvRelatedRequirements.Size = new System.Drawing.Size(533, 184);
            this.dgvRelatedRequirements.TabIndex = 19;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Requirement Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Concern
            // 
            this.Concern.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Concern.HeaderText = "Concern";
            this.Concern.Name = "Concern";
            this.Concern.ReadOnly = true;
            // 
            // Rating
            // 
            this.Rating.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Rating.HeaderText = "Rating";
            this.Rating.Name = "Rating";
            this.Rating.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Description";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // TracesTb
            // 
            this.TracesTb.BackColor = System.Drawing.SystemColors.Control;
            this.TracesTb.Controls.Add(this.dgvTraces);
            this.TracesTb.Location = new System.Drawing.Point(4, 22);
            this.TracesTb.Name = "TracesTb";
            this.TracesTb.Size = new System.Drawing.Size(533, 184);
            this.TracesTb.TabIndex = 4;
            this.TracesTb.Text = "Traces";
            // 
            // dgvTraces
            // 
            this.dgvTraces.AllowUserToAddRows = false;
            this.dgvTraces.AllowUserToDeleteRows = false;
            this.dgvTraces.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTraces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraces.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.Type});
            this.dgvTraces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTraces.Location = new System.Drawing.Point(0, 0);
            this.dgvTraces.Name = "dgvTraces";
            this.dgvTraces.ReadOnly = true;
            this.dgvTraces.RowHeadersVisible = false;
            this.dgvTraces.Size = new System.Drawing.Size(533, 184);
            this.dgvTraces.TabIndex = 19;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Trace Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // HistoryTb
            // 
            this.HistoryTb.BackColor = System.Drawing.SystemColors.Control;
            this.HistoryTb.Controls.Add(this.dgvHistory);
            this.HistoryTb.Location = new System.Drawing.Point(4, 22);
            this.HistoryTb.Name = "HistoryTb";
            this.HistoryTb.Size = new System.Drawing.Size(533, 184);
            this.HistoryTb.TabIndex = 5;
            this.HistoryTb.Text = "History";
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Stakeholder,
            this.Action,
            this.Status,
            this.Iteration});
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.Location = new System.Drawing.Point(0, 0);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.Size = new System.Drawing.Size(533, 184);
            this.dgvHistory.TabIndex = 19;
            // 
            // Stakeholder
            // 
            this.Stakeholder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Stakeholder.HeaderText = "Stakeholder";
            this.Stakeholder.Name = "Stakeholder";
            this.Stakeholder.ReadOnly = true;
            // 
            // Action
            // 
            this.Action.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Iteration
            // 
            this.Iteration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Iteration.HeaderText = "Iteration";
            this.Iteration.Name = "Iteration";
            this.Iteration.ReadOnly = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(454, 525);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(36, 23);
            this.buttonOk.TabIndex = 13;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(496, 525);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(57, 23);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // DetailViewNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 557);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.tbCntrlUnodifiable);
            this.Controls.Add(this.btnHyperlink);
            this.Controls.Add(this.btnunderline);
            this.Controls.Add(this.btnItalics);
            this.Controls.Add(this.btnBold);
            this.Controls.Add(this.tbCnrtlModifiable);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxState);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.NameLabel);
            this.MinimumSize = new System.Drawing.Size(240, 520);
            this.Name = "DetailViewNew";
            this.ShowIcon = false;
            this.Text = "DetailViewNew";
            this.Load += new System.EventHandler(this.DetailViewNew_Load);
            this.tbCnrtlModifiable.ResumeLayout(false);
            this.ProblemTab.ResumeLayout(false);
            this.DescriptionTab.ResumeLayout(false);
            this.ArgumentsTab.ResumeLayout(false);
            this.tbCntrlUnodifiable.ResumeLayout(false);
            this.AlternativeTb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlternatives)).EndInit();
            this.RelatedDecisionsTb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatedDecisions)).EndInit();
            this.RelatedFilesTb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatedFiles)).EndInit();
            this.RelatedRequirementsTb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatedRequirements)).EndInit();
            this.TracesTb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraces)).EndInit();
            this.HistoryTb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxState;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.TabControl tbCnrtlModifiable;
        private System.Windows.Forms.TabPage ProblemTab;
        private System.Windows.Forms.TabPage DescriptionTab;
        private System.Windows.Forms.TabPage ArgumentsTab;
        private System.Windows.Forms.RichTextBox txtIssue;
        private System.Windows.Forms.RichTextBox txtDecision;
        private System.Windows.Forms.RichTextBox txtArguments;
        private System.Windows.Forms.Button btnBold;
        private System.Windows.Forms.Button btnItalics;
        private System.Windows.Forms.Button btnunderline;
        private System.Windows.Forms.Button btnHyperlink;
        private System.Windows.Forms.TabControl tbCntrlUnodifiable;
        private System.Windows.Forms.TabPage AlternativeTb;
        private System.Windows.Forms.TabPage RelatedDecisionsTb;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabPage RelatedFilesTb;
        private System.Windows.Forms.TabPage RelatedRequirementsTb;
        private System.Windows.Forms.TabPage TracesTb;
        private System.Windows.Forms.TabPage HistoryTb;
        private System.Windows.Forms.DataGridView dgvAlternatives;
        private System.Windows.Forms.DataGridView dgvRelatedDecisions;
        private System.Windows.Forms.DataGridView dgvRelatedFiles;
        private System.Windows.Forms.DataGridView dgvRelatedRequirements;
        private System.Windows.Forms.DataGridView dgvTraces;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stakeholder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iteration;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concern;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rating;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlternativeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlternativeFor;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelatedName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Relation;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelatedTo;
    }
}