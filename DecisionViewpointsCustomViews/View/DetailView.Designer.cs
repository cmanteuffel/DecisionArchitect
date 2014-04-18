﻿namespace DecisionViewpointsCustomViews.View
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailView));
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tbCntrlUnodifiable = new System.Windows.Forms.TabControl();
            this.HistoryTb = new System.Windows.Forms.TabPage();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.Iteration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stakeholder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stakeholderuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TracesTb = new System.Windows.Forms.TabPage();
            this.dgvTraces = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.traceUid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelatedRequirementsTb = new System.Windows.Forms.TabPage();
            this.dgvRelatedRequirements = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.concern = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reqUid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelatedDecisionsTb = new System.Windows.Forms.TabPage();
            this.dgvRelatedDecisions = new System.Windows.Forms.DataGridView();
            this.relatedUid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelatedTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Relation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelatedName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlternativeTb = new System.Windows.Forms.TabPage();
            this.dgvAlternatives = new System.Windows.Forms.DataGridView();
            this.AlternativeFor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlternativeUid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlternativeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.decisionUid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnunderline = new System.Windows.Forms.Button();
            this.btnItalics = new System.Windows.Forms.Button();
            this.btnBold = new System.Windows.Forms.Button();
            this.cbxState = new System.Windows.Forms.ComboBox();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.txtTopicDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTopicDescription = new System.Windows.Forms.Label();
            this.lblTopicName = new System.Windows.Forms.Label();
            this.tbCnrtlModifiable = new System.Windows.Forms.TabControl();
            this.ArgumentsTab = new System.Windows.Forms.TabPage();
            this.txtArguments = new System.Windows.Forms.RichTextBox();
            this.DescriptionTab = new System.Windows.Forms.TabPage();
            this.txtDecision = new System.Windows.Forms.RichTextBox();
            this.ProblemTab = new System.Windows.Forms.TabPage();
            this.txtIssue = new System.Windows.Forms.RichTextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tbCntrlUnodifiable.SuspendLayout();
            this.HistoryTb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.TracesTb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraces)).BeginInit();
            this.RelatedRequirementsTb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatedRequirements)).BeginInit();
            this.RelatedDecisionsTb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatedDecisions)).BeginInit();
            this.AlternativeTb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlternatives)).BeginInit();
            this.tbCnrtlModifiable.SuspendLayout();
            this.ArgumentsTab.SuspendLayout();
            this.DescriptionTab.SuspendLayout();
            this.ProblemTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            resources.ApplyResources(this.buttonOk, "buttonOk");
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // tbCntrlUnodifiable
            // 
            resources.ApplyResources(this.tbCntrlUnodifiable, "tbCntrlUnodifiable");
            this.tbCntrlUnodifiable.Controls.Add(this.AlternativeTb);
            this.tbCntrlUnodifiable.Controls.Add(this.RelatedDecisionsTb);
            this.tbCntrlUnodifiable.Controls.Add(this.RelatedRequirementsTb);
            this.tbCntrlUnodifiable.Controls.Add(this.TracesTb);
            this.tbCntrlUnodifiable.Controls.Add(this.HistoryTb);
            this.tbCntrlUnodifiable.Name = "tbCntrlUnodifiable";
            this.tbCntrlUnodifiable.SelectedIndex = 0;
            // 
            // HistoryTb
            // 
            this.HistoryTb.BackColor = System.Drawing.SystemColors.Control;
            this.HistoryTb.Controls.Add(this.dgvHistory);
            resources.ApplyResources(this.HistoryTb, "HistoryTb");
            this.HistoryTb.Name = "HistoryTb";
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stakeholderuid,
            this.Stakeholder,
            this.Action,
            this.Status,
            this.Iteration});
            resources.ApplyResources(this.dgvHistory, "dgvHistory");
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistory_CellContentClick);
            // 
            // Iteration
            // 
            this.Iteration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Iteration, "Iteration");
            this.Iteration.Name = "Iteration";
            this.Iteration.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Status, "Status");
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Action
            // 
            this.Action.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Action, "Action");
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            // 
            // Stakeholder
            // 
            this.Stakeholder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Stakeholder, "Stakeholder");
            this.Stakeholder.Name = "Stakeholder";
            this.Stakeholder.ReadOnly = true;
            // 
            // stakeholderuid
            // 
            resources.ApplyResources(this.stakeholderuid, "stakeholderuid");
            this.stakeholderuid.Name = "stakeholderuid";
            this.stakeholderuid.ReadOnly = true;
            // 
            // TracesTb
            // 
            this.TracesTb.BackColor = System.Drawing.SystemColors.Control;
            this.TracesTb.Controls.Add(this.dgvTraces);
            resources.ApplyResources(this.TracesTb, "TracesTb");
            this.TracesTb.Name = "TracesTb";
            // 
            // dgvTraces
            // 
            this.dgvTraces.AllowUserToAddRows = false;
            this.dgvTraces.AllowUserToDeleteRows = false;
            this.dgvTraces.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTraces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraces.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.traceUid,
            this.dataGridViewTextBoxColumn4,
            this.Type});
            resources.ApplyResources(this.dgvTraces, "dgvTraces");
            this.dgvTraces.Name = "dgvTraces";
            this.dgvTraces.ReadOnly = true;
            this.dgvTraces.RowHeadersVisible = false;
            this.dgvTraces.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTraces_CellContentClick);
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Type, "Type");
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // traceUid
            // 
            resources.ApplyResources(this.traceUid, "traceUid");
            this.traceUid.Name = "traceUid";
            this.traceUid.ReadOnly = true;
            // 
            // RelatedRequirementsTb
            // 
            this.RelatedRequirementsTb.BackColor = System.Drawing.SystemColors.Control;
            this.RelatedRequirementsTb.Controls.Add(this.dgvRelatedRequirements);
            resources.ApplyResources(this.RelatedRequirementsTb, "RelatedRequirementsTb");
            this.RelatedRequirementsTb.Name = "RelatedRequirementsTb";
            // 
            // dgvRelatedRequirements
            // 
            this.dgvRelatedRequirements.AllowUserToAddRows = false;
            this.dgvRelatedRequirements.AllowUserToDeleteRows = false;
            this.dgvRelatedRequirements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRelatedRequirements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelatedRequirements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reqUid,
            this.dataGridViewTextBoxColumn2,
            this.concern,
            this.rating,
            this.dataGridViewTextBoxColumn3});
            resources.ApplyResources(this.dgvRelatedRequirements, "dgvRelatedRequirements");
            this.dgvRelatedRequirements.Name = "dgvRelatedRequirements";
            this.dgvRelatedRequirements.ReadOnly = true;
            this.dgvRelatedRequirements.RowHeadersVisible = false;
            this.dgvRelatedRequirements.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRelatedRequirements_CellContentClick);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // rating
            // 
            resources.ApplyResources(this.rating, "rating");
            this.rating.Name = "rating";
            this.rating.ReadOnly = true;
            // 
            // concern
            // 
            resources.ApplyResources(this.concern, "concern");
            this.concern.Name = "concern";
            this.concern.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // reqUid
            // 
            resources.ApplyResources(this.reqUid, "reqUid");
            this.reqUid.Name = "reqUid";
            this.reqUid.ReadOnly = true;
            // 
            // RelatedDecisionsTb
            // 
            this.RelatedDecisionsTb.BackColor = System.Drawing.SystemColors.Control;
            this.RelatedDecisionsTb.Controls.Add(this.dgvRelatedDecisions);
            resources.ApplyResources(this.RelatedDecisionsTb, "RelatedDecisionsTb");
            this.RelatedDecisionsTb.Name = "RelatedDecisionsTb";
            // 
            // dgvRelatedDecisions
            // 
            this.dgvRelatedDecisions.AllowUserToAddRows = false;
            this.dgvRelatedDecisions.AllowUserToDeleteRows = false;
            this.dgvRelatedDecisions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRelatedDecisions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelatedDecisions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.RelatedName,
            this.Relation,
            this.RelatedTo,
            this.relatedUid});
            resources.ApplyResources(this.dgvRelatedDecisions, "dgvRelatedDecisions");
            this.dgvRelatedDecisions.Name = "dgvRelatedDecisions";
            this.dgvRelatedDecisions.ReadOnly = true;
            this.dgvRelatedDecisions.RowHeadersVisible = false;
            this.dgvRelatedDecisions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRelatedDecisions_CellContentClick);
            // 
            // relatedUid
            // 
            resources.ApplyResources(this.relatedUid, "relatedUid");
            this.relatedUid.Name = "relatedUid";
            this.relatedUid.ReadOnly = true;
            // 
            // RelatedTo
            // 
            this.RelatedTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.RelatedTo, "RelatedTo");
            this.RelatedTo.Name = "RelatedTo";
            this.RelatedTo.ReadOnly = true;
            // 
            // Relation
            // 
            this.Relation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Relation, "Relation");
            this.Relation.Name = "Relation";
            this.Relation.ReadOnly = true;
            // 
            // RelatedName
            // 
            this.RelatedName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.RelatedName, "RelatedName");
            this.RelatedName.Name = "RelatedName";
            this.RelatedName.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // AlternativeTb
            // 
            this.AlternativeTb.BackColor = System.Drawing.SystemColors.Control;
            this.AlternativeTb.Controls.Add(this.dgvAlternatives);
            resources.ApplyResources(this.AlternativeTb, "AlternativeTb");
            this.AlternativeTb.Name = "AlternativeTb";
            // 
            // dgvAlternatives
            // 
            this.dgvAlternatives.AllowUserToAddRows = false;
            this.dgvAlternatives.AllowUserToDeleteRows = false;
            this.dgvAlternatives.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlternatives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlternatives.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.decisionUid,
            this.AlternativeName,
            this.AlternativeUid,
            this.AlternativeFor});
            resources.ApplyResources(this.dgvAlternatives, "dgvAlternatives");
            this.dgvAlternatives.Name = "dgvAlternatives";
            this.dgvAlternatives.ReadOnly = true;
            this.dgvAlternatives.RowHeadersVisible = false;
            this.dgvAlternatives.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlternatives_CellContentDoubleClick);
            // 
            // AlternativeFor
            // 
            this.AlternativeFor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.AlternativeFor, "AlternativeFor");
            this.AlternativeFor.Name = "AlternativeFor";
            this.AlternativeFor.ReadOnly = true;
            // 
            // AlternativeUid
            // 
            resources.ApplyResources(this.AlternativeUid, "AlternativeUid");
            this.AlternativeUid.Name = "AlternativeUid";
            this.AlternativeUid.ReadOnly = true;
            // 
            // AlternativeName
            // 
            this.AlternativeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.AlternativeName, "AlternativeName");
            this.AlternativeName.Name = "AlternativeName";
            this.AlternativeName.ReadOnly = true;
            // 
            // decisionUid
            // 
            resources.ApplyResources(this.decisionUid, "decisionUid");
            this.decisionUid.Name = "decisionUid";
            this.decisionUid.ReadOnly = true;
            // 
            // btnunderline
            // 
            resources.ApplyResources(this.btnunderline, "btnunderline");
            this.btnunderline.Name = "btnunderline";
            this.btnunderline.UseVisualStyleBackColor = true;
            this.btnunderline.Click += new System.EventHandler(this.btnunderline_Click);
            // 
            // btnItalics
            // 
            resources.ApplyResources(this.btnItalics, "btnItalics");
            this.btnItalics.Name = "btnItalics";
            this.btnItalics.UseVisualStyleBackColor = true;
            this.btnItalics.Click += new System.EventHandler(this.btnItalics_Click);
            // 
            // btnBold
            // 
            resources.ApplyResources(this.btnBold, "btnBold");
            this.btnBold.Name = "btnBold";
            this.btnBold.UseVisualStyleBackColor = true;
            this.btnBold.Click += new System.EventHandler(this.btnBold_Click);
            // 
            // cbxState
            // 
            resources.ApplyResources(this.cbxState, "cbxState");
            this.cbxState.FormattingEnabled = true;
            this.cbxState.Items.AddRange(new object[] {
            resources.GetString("cbxState.Items"),
            resources.GetString("cbxState.Items1"),
            resources.GetString("cbxState.Items2"),
            resources.GetString("cbxState.Items3"),
            resources.GetString("cbxState.Items4"),
            resources.GetString("cbxState.Items5"),
            resources.GetString("cbxState.Items6")});
            this.cbxState.Name = "cbxState";
            // 
            // txtGroup
            // 
            resources.ApplyResources(this.txtGroup, "txtGroup");
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.ReadOnly = true;
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            // 
            // NameLabel
            // 
            resources.ApplyResources(this.NameLabel, "NameLabel");
            this.NameLabel.Name = "NameLabel";
            // 
            // txtTopicDescription
            // 
            resources.ApplyResources(this.txtTopicDescription, "txtTopicDescription");
            this.txtTopicDescription.Name = "txtTopicDescription";
            this.txtTopicDescription.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblTopicDescription
            // 
            resources.ApplyResources(this.lblTopicDescription, "lblTopicDescription");
            this.lblTopicDescription.Name = "lblTopicDescription";
            // 
            // lblTopicName
            // 
            resources.ApplyResources(this.lblTopicName, "lblTopicName");
            this.lblTopicName.Name = "lblTopicName";
            // 
            // tbCnrtlModifiable
            // 
            resources.ApplyResources(this.tbCnrtlModifiable, "tbCnrtlModifiable");
            this.tbCnrtlModifiable.Controls.Add(this.ProblemTab);
            this.tbCnrtlModifiable.Controls.Add(this.DescriptionTab);
            this.tbCnrtlModifiable.Controls.Add(this.ArgumentsTab);
            this.tbCnrtlModifiable.Name = "tbCnrtlModifiable";
            this.tbCnrtlModifiable.SelectedIndex = 0;
            // 
            // ArgumentsTab
            // 
            this.ArgumentsTab.Controls.Add(this.txtArguments);
            resources.ApplyResources(this.ArgumentsTab, "ArgumentsTab");
            this.ArgumentsTab.Name = "ArgumentsTab";
            this.ArgumentsTab.UseVisualStyleBackColor = true;
            // 
            // txtArguments
            // 
            resources.ApplyResources(this.txtArguments, "txtArguments");
            this.txtArguments.Name = "txtArguments";
            this.txtArguments.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtArguments_LinkClicked);
            // 
            // DescriptionTab
            // 
            this.DescriptionTab.Controls.Add(this.txtDecision);
            resources.ApplyResources(this.DescriptionTab, "DescriptionTab");
            this.DescriptionTab.Name = "DescriptionTab";
            this.DescriptionTab.UseVisualStyleBackColor = true;
            // 
            // txtDecision
            // 
            resources.ApplyResources(this.txtDecision, "txtDecision");
            this.txtDecision.Name = "txtDecision";
            this.txtDecision.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtDecision_LinkClicked);
            // 
            // ProblemTab
            // 
            this.ProblemTab.Controls.Add(this.txtIssue);
            resources.ApplyResources(this.ProblemTab, "ProblemTab");
            this.ProblemTab.Name = "ProblemTab";
            this.ProblemTab.UseVisualStyleBackColor = true;
            // 
            // txtIssue
            // 
            resources.ApplyResources(this.txtIssue, "txtIssue");
            this.txtIssue.Name = "txtIssue";
            this.txtIssue.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtIssue_LinkClicked);
            // 
            // notifyIcon1
            // 
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            // 
            // DetailView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblTopicName);
            this.Controls.Add(this.tbCnrtlModifiable);
            this.Controls.Add(this.lblTopicDescription);
            this.Controls.Add(this.cbxState);
            this.Controls.Add(this.txtTopicDescription);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.tbCntrlUnodifiable);
            this.Controls.Add(this.btnItalics);
            this.Controls.Add(this.btnunderline);
            this.Controls.Add(this.btnBold);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DetailView";
            this.ShowIcon = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DetailViewNew_Load);
            this.tbCntrlUnodifiable.ResumeLayout(false);
            this.HistoryTb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.TracesTb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraces)).EndInit();
            this.RelatedRequirementsTb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatedRequirements)).EndInit();
            this.RelatedDecisionsTb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatedDecisions)).EndInit();
            this.AlternativeTb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlternatives)).EndInit();
            this.tbCnrtlModifiable.ResumeLayout(false);
            this.ArgumentsTab.ResumeLayout(false);
            this.DescriptionTab.ResumeLayout(false);
            this.ProblemTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabControl tbCntrlUnodifiable;
        private System.Windows.Forms.TabPage AlternativeTb;
        private System.Windows.Forms.DataGridView dgvAlternatives;
        private System.Windows.Forms.DataGridViewTextBoxColumn decisionUid;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlternativeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlternativeUid;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlternativeFor;
        private System.Windows.Forms.TabPage RelatedDecisionsTb;
        private System.Windows.Forms.DataGridView dgvRelatedDecisions;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelatedName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Relation;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelatedTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn relatedUid;
        private System.Windows.Forms.TabPage RelatedRequirementsTb;
        private System.Windows.Forms.DataGridView dgvRelatedRequirements;
        private System.Windows.Forms.DataGridViewTextBoxColumn reqUid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn concern;
        private System.Windows.Forms.DataGridViewTextBoxColumn rating;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TabPage TracesTb;
        private System.Windows.Forms.DataGridView dgvTraces;
        private System.Windows.Forms.DataGridViewTextBoxColumn traceUid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.TabPage HistoryTb;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn stakeholderuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stakeholder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iteration;
        private System.Windows.Forms.Button btnunderline;
        private System.Windows.Forms.Button btnItalics;
        private System.Windows.Forms.Button btnBold;
        private System.Windows.Forms.ComboBox cbxState;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox txtTopicDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTopicDescription;
        private System.Windows.Forms.Label lblTopicName;
        private System.Windows.Forms.TabControl tbCnrtlModifiable;
        private System.Windows.Forms.TabPage ProblemTab;
        private System.Windows.Forms.RichTextBox txtIssue;
        private System.Windows.Forms.TabPage DescriptionTab;
        private System.Windows.Forms.RichTextBox txtDecision;
        private System.Windows.Forms.TabPage ArgumentsTab;
        private System.Windows.Forms.RichTextBox txtArguments;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}