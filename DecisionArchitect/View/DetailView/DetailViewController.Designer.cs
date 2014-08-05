/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    Marc Holterman (University of Groningen)
*/

using System.Windows.Forms;
using DecisionArchitect.View.RichTextBox;

namespace DecisionArchitect.View.DetailView
{
    partial class DetailViewController
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
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.spltDetailView = new System.Windows.Forms.SplitContainer();
            this.gpbDecisionInformation = new System.Windows.Forms.GroupBox();
            this.lblModified = new System.Windows.Forms.Label();
            this.gpbRationale = new System.Windows.Forms.GroupBox();
            this.lblDecisionState = new System.Windows.Forms.Label();
            this.cbxState = new System.Windows.Forms.ComboBox();
            this.lblDecisionName = new System.Windows.Forms.Label();
            this.txtDecisionName = new System.Windows.Forms.TextBox();
            this.dtModified = new System.Windows.Forms.DateTimePicker();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gpbTopicInformation = new System.Windows.Forms.GroupBox();
            this.grpDescription = new System.Windows.Forms.GroupBox();
            this.lblTopicName = new System.Windows.Forms.Label();
            this.txtTopicName = new System.Windows.Forms.TextBox();
            this.gpbAdditionalInformation = new System.Windows.Forms.GroupBox();
            this.pnlAccordion = new System.Windows.Forms.Panel();
            this.vAccordionPane = new VIBlend.WinForms.Controls.vNavPane();
            this.vAlternativePane = new VIBlend.WinForms.Controls.vNavPaneItem();
            this.dgvAlternativeDecisions = new System.Windows.Forms.DataGridView();
            this.clmAlternativeGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAlternativeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAlternativeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAlternativeState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAlternativeRationale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vRelatedPane = new VIBlend.WinForms.Controls.vNavPaneItem();
            this.dgvRelatedDecisions = new System.Windows.Forms.DataGridView();
            this.clmRelatedGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRelation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRelatedName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRelatedTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRelatedUid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vForcesPane = new VIBlend.WinForms.Controls.vNavPaneItem();
            this.dgvForces = new System.Windows.Forms.DataGridView();
            this.clmForceGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmForcesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmForceConcern = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmForceRating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmForceDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vTracesPane = new VIBlend.WinForms.Controls.vNavPaneItem();
            this.dgvTraces = new System.Windows.Forms.DataGridView();
            this.clmTraceGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTraceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTraceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vStakeholderPane = new VIBlend.WinForms.Controls.vNavPaneItem();
            this.dgvStakeholder = new System.Windows.Forms.DataGridView();
            this.clmStakeholderGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStakeholderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStakeholderAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vHistoryPane = new VIBlend.WinForms.Controls.vNavPaneItem();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.clmHistoryGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHistoryState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHistoryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Content = new VIBlend.WinForms.Controls.vContentPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.rtbRationale = new CustomRichTextBox();
            this.rtbTopicDescription = new CustomRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.spltDetailView)).BeginInit();
            this.spltDetailView.Panel1.SuspendLayout();
            this.spltDetailView.Panel2.SuspendLayout();
            this.spltDetailView.SuspendLayout();
            this.gpbDecisionInformation.SuspendLayout();
            this.gpbRationale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gpbTopicInformation.SuspendLayout();
            this.grpDescription.SuspendLayout();
            this.gpbAdditionalInformation.SuspendLayout();
            this.pnlAccordion.SuspendLayout();
            this.vAccordionPane.SuspendLayout();
            this.vAlternativePane.ItemPanel.SuspendLayout();
            this.vAlternativePane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlternativeDecisions)).BeginInit();
            this.vRelatedPane.ItemPanel.SuspendLayout();
            this.vRelatedPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatedDecisions)).BeginInit();
            this.vForcesPane.ItemPanel.SuspendLayout();
            this.vForcesPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForces)).BeginInit();
            this.vTracesPane.ItemPanel.SuspendLayout();
            this.vTracesPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraces)).BeginInit();
            this.vStakeholderPane.ItemPanel.SuspendLayout();
            this.vStakeholderPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStakeholder)).BeginInit();
            this.vHistoryPane.ItemPanel.SuspendLayout();
            this.vHistoryPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // spltDetailView
            // 
            this.spltDetailView.BackColor = System.Drawing.Color.Transparent;
            this.spltDetailView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spltDetailView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltDetailView.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spltDetailView.Location = new System.Drawing.Point(0, 0);
            this.spltDetailView.Name = "spltDetailView";
            // 
            // spltDetailView.Panel1
            // 
            this.spltDetailView.Panel1.Controls.Add(this.gpbDecisionInformation);
            this.spltDetailView.Panel1MinSize = 400;
            // 
            // spltDetailView.Panel2
            // 
            this.spltDetailView.Panel2.Controls.Add(this.splitContainer1);
            this.spltDetailView.Panel2MinSize = 300;
            this.spltDetailView.Size = new System.Drawing.Size(916, 769);
            this.spltDetailView.SplitterDistance = 590;
            this.spltDetailView.TabIndex = 0;
            this.spltDetailView.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.spltDetailView_SplitterMoved);
            // 
            // gpbDecisionInformation
            // 
            this.gpbDecisionInformation.BackColor = System.Drawing.SystemColors.Control;
            this.gpbDecisionInformation.Controls.Add(this.lblModified);
            this.gpbDecisionInformation.Controls.Add(this.gpbRationale);
            this.gpbDecisionInformation.Controls.Add(this.lblDecisionState);
            this.gpbDecisionInformation.Controls.Add(this.cbxState);
            this.gpbDecisionInformation.Controls.Add(this.lblDecisionName);
            this.gpbDecisionInformation.Controls.Add(this.txtDecisionName);
            this.gpbDecisionInformation.Controls.Add(this.dtModified);
            this.gpbDecisionInformation.Controls.Add(this.lblAuthor);
            this.gpbDecisionInformation.Controls.Add(this.txtAuthor);
            this.gpbDecisionInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbDecisionInformation.Location = new System.Drawing.Point(0, 0);
            this.gpbDecisionInformation.Name = "gpbDecisionInformation";
            this.gpbDecisionInformation.Size = new System.Drawing.Size(586, 765);
            this.gpbDecisionInformation.TabIndex = 57;
            this.gpbDecisionInformation.TabStop = false;
            this.gpbDecisionInformation.Text = "Decision";
            // 
            // lblModified
            // 
            this.lblModified.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModified.AutoSize = true;
            this.lblModified.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblModified.Location = new System.Drawing.Point(408, 45);
            this.lblModified.Name = "lblModified";
            this.lblModified.Size = new System.Drawing.Size(65, 13);
            this.lblModified.TabIndex = 138;
            this.lblModified.Text = "Modified on:";
            // 
            // gpbRationale
            // 
            this.gpbRationale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbRationale.BackColor = System.Drawing.Color.Transparent;
            this.gpbRationale.Controls.Add(this.rtbRationale);
            this.gpbRationale.Location = new System.Drawing.Point(3, 96);
            this.gpbRationale.Name = "gpbRationale";
            this.gpbRationale.Size = new System.Drawing.Size(580, 663);
            this.gpbRationale.TabIndex = 137;
            this.gpbRationale.TabStop = false;
            this.gpbRationale.Text = "   Rationale:";
            // 
            // lblDecisionState
            // 
            this.lblDecisionState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDecisionState.AutoSize = true;
            this.lblDecisionState.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDecisionState.Location = new System.Drawing.Point(38, 45);
            this.lblDecisionState.Name = "lblDecisionState";
            this.lblDecisionState.Size = new System.Drawing.Size(35, 13);
            this.lblDecisionState.TabIndex = 135;
            this.lblDecisionState.Text = "State:";
            // 
            // cbxState
            // 
            this.cbxState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxState.FormattingEnabled = true;
            this.cbxState.Items.AddRange(new object[] {
            "Idea",
            "Tentative",
            "Decided",
            "Approved",
            "Challenged",
            "Discarded",
            "Rejected"});
            this.cbxState.Location = new System.Drawing.Point(79, 43);
            this.cbxState.Name = "cbxState";
            this.cbxState.Size = new System.Drawing.Size(323, 21);
            this.cbxState.TabIndex = 136;
            this.cbxState.SelectedIndexChanged += new System.EventHandler(this.cbxState_SelectedIndexChanged);
            // 
            // lblDecisionName
            // 
            this.lblDecisionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDecisionName.AutoSize = true;
            this.lblDecisionName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDecisionName.Location = new System.Drawing.Point(35, 20);
            this.lblDecisionName.Name = "lblDecisionName";
            this.lblDecisionName.Size = new System.Drawing.Size(38, 13);
            this.lblDecisionName.TabIndex = 130;
            this.lblDecisionName.Text = "Name:";
            // 
            // txtDecisionName
            // 
            this.txtDecisionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDecisionName.Location = new System.Drawing.Point(79, 17);
            this.txtDecisionName.Name = "txtDecisionName";
            this.txtDecisionName.Size = new System.Drawing.Size(499, 20);
            this.txtDecisionName.TabIndex = 131;
            // 
            // dtModified
            // 
            this.dtModified.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtModified.CustomFormat = "dd.MM.yyyy";
            this.dtModified.Enabled = false;
            this.dtModified.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtModified.Location = new System.Drawing.Point(479, 43);
            this.dtModified.Name = "dtModified";
            this.dtModified.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtModified.Size = new System.Drawing.Size(99, 20);
            this.dtModified.TabIndex = 129;
            // 
            // lblAuthor
            // 
            this.lblAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAuthor.Location = new System.Drawing.Point(32, 73);
            this.lblAuthor.MaximumSize = new System.Drawing.Size(41, 13);
            this.lblAuthor.MinimumSize = new System.Drawing.Size(41, 13);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(41, 13);
            this.lblAuthor.TabIndex = 123;
            this.lblAuthor.Text = "Author:";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthor.Location = new System.Drawing.Point(79, 70);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(499, 20);
            this.txtAuthor.TabIndex = 122;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gpbTopicInformation);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gpbAdditionalInformation);
            this.splitContainer1.Panel2MinSize = 400;
            this.splitContainer1.Size = new System.Drawing.Size(322, 769);
            this.splitContainer1.SplitterDistance = 326;
            this.splitContainer1.TabIndex = 126;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // gpbTopicInformation
            // 
            this.gpbTopicInformation.BackColor = System.Drawing.SystemColors.Control;
            this.gpbTopicInformation.Controls.Add(this.grpDescription);
            this.gpbTopicInformation.Controls.Add(this.lblTopicName);
            this.gpbTopicInformation.Controls.Add(this.txtTopicName);
            this.gpbTopicInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbTopicInformation.Location = new System.Drawing.Point(0, 0);
            this.gpbTopicInformation.Name = "gpbTopicInformation";
            this.gpbTopicInformation.Size = new System.Drawing.Size(318, 322);
            this.gpbTopicInformation.TabIndex = 123;
            this.gpbTopicInformation.TabStop = false;
            this.gpbTopicInformation.Text = "Topic";
            // 
            // grpDescription
            // 
            this.grpDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDescription.Controls.Add(this.rtbTopicDescription);
            this.grpDescription.Location = new System.Drawing.Point(3, 43);
            this.grpDescription.Name = "grpDescription";
            this.grpDescription.Size = new System.Drawing.Size(309, 273);
            this.grpDescription.TabIndex = 122;
            this.grpDescription.TabStop = false;
            this.grpDescription.Text = "Description:";
            // 
            // lblTopicName
            // 
            this.lblTopicName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTopicName.AutoSize = true;
            this.lblTopicName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTopicName.Location = new System.Drawing.Point(32, 20);
            this.lblTopicName.Name = "lblTopicName";
            this.lblTopicName.Size = new System.Drawing.Size(38, 13);
            this.lblTopicName.TabIndex = 112;
            this.lblTopicName.Text = "Name:";
            // 
            // txtTopicName
            // 
            this.txtTopicName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTopicName.Location = new System.Drawing.Point(76, 17);
            this.txtTopicName.Name = "txtTopicName";
            this.txtTopicName.Size = new System.Drawing.Size(225, 20);
            this.txtTopicName.TabIndex = 113;
            // 
            // gpbAdditionalInformation
            // 
            this.gpbAdditionalInformation.BackColor = System.Drawing.SystemColors.Control;
            this.gpbAdditionalInformation.Controls.Add(this.pnlAccordion);
            this.gpbAdditionalInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbAdditionalInformation.Location = new System.Drawing.Point(0, 0);
            this.gpbAdditionalInformation.Name = "gpbAdditionalInformation";
            this.gpbAdditionalInformation.Size = new System.Drawing.Size(318, 435);
            this.gpbAdditionalInformation.TabIndex = 124;
            this.gpbAdditionalInformation.TabStop = false;
            this.gpbAdditionalInformation.Text = "Additional information";
            // 
            // pnlAccordion
            // 
            this.pnlAccordion.Controls.Add(this.vAccordionPane);
            this.pnlAccordion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAccordion.Location = new System.Drawing.Point(3, 16);
            this.pnlAccordion.Name = "pnlAccordion";
            this.pnlAccordion.Padding = new System.Windows.Forms.Padding(5, 0, 5, 13);
            this.pnlAccordion.Size = new System.Drawing.Size(312, 416);
            this.pnlAccordion.TabIndex = 123;
            // 
            // vAccordionPane
            // 
            this.vAccordionPane.Controls.Add(this.vAlternativePane);
            this.vAccordionPane.Controls.Add(this.vRelatedPane);
            this.vAccordionPane.Controls.Add(this.vForcesPane);
            this.vAccordionPane.Controls.Add(this.vTracesPane);
            this.vAccordionPane.Controls.Add(this.vStakeholderPane);
            this.vAccordionPane.Controls.Add(this.vHistoryPane);
            this.vAccordionPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vAccordionPane.Items.Add(this.vAlternativePane);
            this.vAccordionPane.Items.Add(this.vRelatedPane);
            this.vAccordionPane.Items.Add(this.vForcesPane);
            this.vAccordionPane.Items.Add(this.vTracesPane);
            this.vAccordionPane.Items.Add(this.vStakeholderPane);
            this.vAccordionPane.Items.Add(this.vHistoryPane);
            this.vAccordionPane.Location = new System.Drawing.Point(5, 0);
            this.vAccordionPane.Name = "vAccordionPane";
            this.vAccordionPane.Padding = new System.Windows.Forms.Padding(20);
            this.vAccordionPane.Size = new System.Drawing.Size(302, 403);
            this.vAccordionPane.TabIndex = 122;
            this.vAccordionPane.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.STEEL;
            // 
            // vAlternativePane
            // 
            this.vAlternativePane.BackColor = System.Drawing.Color.White;
            this.vAlternativePane.HeaderText = "Alternatives";
            // 
            // vAlternativePane.ItemPanel
            // 
            this.vAlternativePane.ItemPanel.AutoScroll = true;
            this.vAlternativePane.ItemPanel.Controls.Add(this.dgvAlternativeDecisions);
            this.vAlternativePane.ItemPanel.Location = new System.Drawing.Point(1, 30);
            this.vAlternativePane.ItemPanel.Name = "ItemPanel";
            this.vAlternativePane.ItemPanel.Size = new System.Drawing.Size(300, 222);
            this.vAlternativePane.ItemPanel.TabIndex = 1;
            this.vAlternativePane.Location = new System.Drawing.Point(0, 0);
            this.vAlternativePane.Name = "vAlternativePane";
            this.vAlternativePane.Size = new System.Drawing.Size(302, 253);
            this.vAlternativePane.TabIndex = 0;
            this.vAlternativePane.Text = "Alternatives";
            this.vAlternativePane.TooltipText = "Alternatives";
            // 
            // dgvAlternativeDecisions
            // 
            this.dgvAlternativeDecisions.AllowUserToAddRows = false;
            this.dgvAlternativeDecisions.AllowUserToDeleteRows = false;
            this.dgvAlternativeDecisions.AllowUserToResizeRows = false;
            this.dgvAlternativeDecisions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlternativeDecisions.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvAlternativeDecisions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAlternativeDecisions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvAlternativeDecisions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlternativeDecisions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmAlternativeGuid,
            this.clmAlternativeID,
            this.clmAlternativeName,
            this.clmAlternativeState,
            this.clmAlternativeRationale});
            this.dgvAlternativeDecisions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlternativeDecisions.GridColor = System.Drawing.SystemColors.Control;
            this.dgvAlternativeDecisions.Location = new System.Drawing.Point(0, 0);
            this.dgvAlternativeDecisions.Name = "dgvAlternativeDecisions";
            this.dgvAlternativeDecisions.ReadOnly = true;
            this.dgvAlternativeDecisions.RowHeadersVisible = false;
            this.dgvAlternativeDecisions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlternativeDecisions.Size = new System.Drawing.Size(300, 222);
            this.dgvAlternativeDecisions.TabIndex = 105;
            this.dgvAlternativeDecisions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlternativeDecisions_CellContentClick);
            this.dgvAlternativeDecisions.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlternativeDecisions_CellContentDubbelClick);
            this.dgvAlternativeDecisions.Leave += new System.EventHandler(this.dgvAlternativeDecisions_Leave);
            // 
            // clmAlternativeGuid
            // 
            this.clmAlternativeGuid.FillWeight = 66.8797F;
            this.clmAlternativeGuid.HeaderText = "alternativeGuid";
            this.clmAlternativeGuid.Name = "clmAlternativeGuid";
            this.clmAlternativeGuid.ReadOnly = true;
            this.clmAlternativeGuid.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmAlternativeGuid.Visible = false;
            // 
            // clmAlternativeID
            // 
            this.clmAlternativeID.FillWeight = 25.46421F;
            this.clmAlternativeID.HeaderText = "Id";
            this.clmAlternativeID.Name = "clmAlternativeID";
            this.clmAlternativeID.ReadOnly = true;
            this.clmAlternativeID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmAlternativeID.Visible = false;
            // 
            // clmAlternativeName
            // 
            this.clmAlternativeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmAlternativeName.FillWeight = 149.2733F;
            this.clmAlternativeName.HeaderText = "Decision";
            this.clmAlternativeName.Name = "clmAlternativeName";
            this.clmAlternativeName.ReadOnly = true;
            this.clmAlternativeName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmAlternativeName.ToolTipText = "Dubble click to open the selected Decision";
            // 
            // clmAlternativeState
            // 
            this.clmAlternativeState.FillWeight = 89.28613F;
            this.clmAlternativeState.HeaderText = "State";
            this.clmAlternativeState.Name = "clmAlternativeState";
            this.clmAlternativeState.ReadOnly = true;
            this.clmAlternativeState.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // clmAlternativeRationale
            // 
            this.clmAlternativeRationale.FillWeight = 80.41162F;
            this.clmAlternativeRationale.HeaderText = "alternativeRationale";
            this.clmAlternativeRationale.Name = "clmAlternativeRationale";
            this.clmAlternativeRationale.ReadOnly = true;
            this.clmAlternativeRationale.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmAlternativeRationale.Visible = false;
            // 
            // vRelatedPane
            // 
            this.vRelatedPane.BackColor = System.Drawing.Color.White;
            this.vRelatedPane.HeaderText = "Related Decisions";
            // 
            // vRelatedPane.ItemPanel
            // 
            this.vRelatedPane.ItemPanel.AutoScroll = true;
            this.vRelatedPane.ItemPanel.Controls.Add(this.dgvRelatedDecisions);
            this.vRelatedPane.ItemPanel.Location = new System.Drawing.Point(1, 30);
            this.vRelatedPane.ItemPanel.Name = "ItemPanel";
            this.vRelatedPane.ItemPanel.Size = new System.Drawing.Size(300, 0);
            this.vRelatedPane.ItemPanel.TabIndex = 1;
            this.vRelatedPane.Location = new System.Drawing.Point(0, 253);
            this.vRelatedPane.Name = "vRelatedPane";
            this.vRelatedPane.Size = new System.Drawing.Size(302, 30);
            this.vRelatedPane.TabIndex = 1;
            this.vRelatedPane.Text = "Related Decisions";
            this.vRelatedPane.TooltipText = "Related Decisions";
            // 
            // dgvRelatedDecisions
            // 
            this.dgvRelatedDecisions.AllowUserToAddRows = false;
            this.dgvRelatedDecisions.AllowUserToDeleteRows = false;
            this.dgvRelatedDecisions.AllowUserToResizeRows = false;
            this.dgvRelatedDecisions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRelatedDecisions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelatedDecisions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmRelatedGuid,
            this.clmRelation,
            this.clmRelatedName,
            this.clmRelatedTo,
            this.clmRelatedUid});
            this.dgvRelatedDecisions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRelatedDecisions.Location = new System.Drawing.Point(0, 0);
            this.dgvRelatedDecisions.Name = "dgvRelatedDecisions";
            this.dgvRelatedDecisions.ReadOnly = true;
            this.dgvRelatedDecisions.RowHeadersVisible = false;
            this.dgvRelatedDecisions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRelatedDecisions.Size = new System.Drawing.Size(300, 0);
            this.dgvRelatedDecisions.TabIndex = 19;
            this.dgvRelatedDecisions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRelatedDecisions_CellContentClick);
            this.dgvRelatedDecisions.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRelatedDecisions_CellContentDoubleClick);
            this.dgvRelatedDecisions.Leave += new System.EventHandler(this.dgvRelatedDecisions_Leave);
            // 
            // clmRelatedGuid
            // 
            this.clmRelatedGuid.HeaderText = "relatedGuid";
            this.clmRelatedGuid.Name = "clmRelatedGuid";
            this.clmRelatedGuid.ReadOnly = true;
            this.clmRelatedGuid.Visible = false;
            // 
            // clmRelation
            // 
            this.clmRelation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmRelation.HeaderText = "Relation";
            this.clmRelation.Name = "clmRelation";
            this.clmRelation.ReadOnly = true;
            // 
            // clmRelatedName
            // 
            this.clmRelatedName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmRelatedName.HeaderText = "Decision";
            this.clmRelatedName.Name = "clmRelatedName";
            this.clmRelatedName.ReadOnly = true;
            this.clmRelatedName.ToolTipText = "Dubble click to open the selected Decision";
            // 
            // clmRelatedTo
            // 
            this.clmRelatedTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmRelatedTo.HeaderText = "Related to";
            this.clmRelatedTo.Name = "clmRelatedTo";
            this.clmRelatedTo.ReadOnly = true;
            this.clmRelatedTo.Visible = false;
            // 
            // clmRelatedUid
            // 
            this.clmRelatedUid.HeaderText = "relatedUid";
            this.clmRelatedUid.Name = "clmRelatedUid";
            this.clmRelatedUid.ReadOnly = true;
            this.clmRelatedUid.Visible = false;
            // 
            // vForcesPane
            // 
            this.vForcesPane.BackColor = System.Drawing.Color.White;
            this.vForcesPane.HeaderText = "Forces";
            // 
            // vForcesPane.ItemPanel
            // 
            this.vForcesPane.ItemPanel.AutoScroll = true;
            this.vForcesPane.ItemPanel.Controls.Add(this.dgvForces);
            this.vForcesPane.ItemPanel.Location = new System.Drawing.Point(1, 30);
            this.vForcesPane.ItemPanel.Name = "ItemPanel";
            this.vForcesPane.ItemPanel.Size = new System.Drawing.Size(300, 0);
            this.vForcesPane.ItemPanel.TabIndex = 1;
            this.vForcesPane.Location = new System.Drawing.Point(0, 283);
            this.vForcesPane.Name = "vForcesPane";
            this.vForcesPane.Size = new System.Drawing.Size(302, 30);
            this.vForcesPane.TabIndex = 2;
            this.vForcesPane.Text = "Related Forces";
            this.vForcesPane.TooltipText = "Forces";
            // 
            // dgvForces
            // 
            this.dgvForces.AllowUserToAddRows = false;
            this.dgvForces.AllowUserToDeleteRows = false;
            this.dgvForces.AllowUserToResizeRows = false;
            this.dgvForces.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvForces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvForces.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmForceGuid,
            this.clmForcesName,
            this.clmForceConcern,
            this.clmForceRating,
            this.clmForceDescription});
            this.dgvForces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvForces.Location = new System.Drawing.Point(0, 0);
            this.dgvForces.Name = "dgvForces";
            this.dgvForces.ReadOnly = true;
            this.dgvForces.RowHeadersVisible = false;
            this.dgvForces.Size = new System.Drawing.Size(300, 0);
            this.dgvForces.TabIndex = 19;
            this.dgvForces.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvForces_CellContentClick);
            this.dgvForces.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvForces_CellContentDoubleClick);
            this.dgvForces.Leave += new System.EventHandler(this.dgvForces_Leave);
            // 
            // clmForceGuid
            // 
            this.clmForceGuid.HeaderText = "forceGuid";
            this.clmForceGuid.Name = "clmForceGuid";
            this.clmForceGuid.ReadOnly = true;
            this.clmForceGuid.Visible = false;
            // 
            // clmForcesName
            // 
            this.clmForcesName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmForcesName.HeaderText = "Force";
            this.clmForcesName.Name = "clmForcesName";
            this.clmForcesName.ReadOnly = true;
            // 
            // clmForceConcern
            // 
            this.clmForceConcern.HeaderText = "Concern";
            this.clmForceConcern.Name = "clmForceConcern";
            this.clmForceConcern.ReadOnly = true;
            // 
            // clmForceRating
            // 
            this.clmForceRating.HeaderText = "Rating";
            this.clmForceRating.Name = "clmForceRating";
            this.clmForceRating.ReadOnly = true;
            // 
            // clmForceDescription
            // 
            this.clmForceDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmForceDescription.HeaderText = "Description";
            this.clmForceDescription.Name = "clmForceDescription";
            this.clmForceDescription.ReadOnly = true;
            this.clmForceDescription.Visible = false;
            // 
            // vTracesPane
            // 
            this.vTracesPane.BackColor = System.Drawing.Color.White;
            this.vTracesPane.HeaderText = "Traces";
            // 
            // vTracesPane.ItemPanel
            // 
            this.vTracesPane.ItemPanel.AutoScroll = true;
            this.vTracesPane.ItemPanel.Controls.Add(this.dgvTraces);
            this.vTracesPane.ItemPanel.Location = new System.Drawing.Point(1, 30);
            this.vTracesPane.ItemPanel.Name = "ItemPanel";
            this.vTracesPane.ItemPanel.Size = new System.Drawing.Size(300, 0);
            this.vTracesPane.ItemPanel.TabIndex = 1;
            this.vTracesPane.Location = new System.Drawing.Point(0, 313);
            this.vTracesPane.Name = "vTracesPane";
            this.vTracesPane.Size = new System.Drawing.Size(302, 30);
            this.vTracesPane.TabIndex = 3;
            this.vTracesPane.Text = "Traces";
            this.vTracesPane.TooltipText = "Traces";
            // 
            // dgvTraces
            // 
            this.dgvTraces.AllowUserToAddRows = false;
            this.dgvTraces.AllowUserToDeleteRows = false;
            this.dgvTraces.AllowUserToResizeRows = false;
            this.dgvTraces.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTraces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraces.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmTraceGuid,
            this.clmTraceName,
            this.clmTraceType});
            this.dgvTraces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTraces.Location = new System.Drawing.Point(0, 0);
            this.dgvTraces.Name = "dgvTraces";
            this.dgvTraces.ReadOnly = true;
            this.dgvTraces.RowHeadersVisible = false;
            this.dgvTraces.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTraces.Size = new System.Drawing.Size(300, 0);
            this.dgvTraces.TabIndex = 19;
            this.dgvTraces.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTraces_CellContentClick);
            this.dgvTraces.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTraces_CellContentDoubleClick);
            this.dgvTraces.Leave += new System.EventHandler(this.dgvTraces_Leave);
            // 
            // clmTraceGuid
            // 
            this.clmTraceGuid.HeaderText = "traceGuid";
            this.clmTraceGuid.Name = "clmTraceGuid";
            this.clmTraceGuid.ReadOnly = true;
            this.clmTraceGuid.Visible = false;
            // 
            // clmTraceName
            // 
            this.clmTraceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmTraceName.HeaderText = "Trace name";
            this.clmTraceName.Name = "clmTraceName";
            this.clmTraceName.ReadOnly = true;
            // 
            // clmTraceType
            // 
            this.clmTraceType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmTraceType.HeaderText = "Type";
            this.clmTraceType.Name = "clmTraceType";
            this.clmTraceType.ReadOnly = true;
            // 
            // vStakeholderPane
            // 
            this.vStakeholderPane.BackColor = System.Drawing.Color.White;
            this.vStakeholderPane.HeaderText = "Stakeholders";
            // 
            // vStakeholderPane.ItemPanel
            // 
            this.vStakeholderPane.ItemPanel.AutoScroll = true;
            this.vStakeholderPane.ItemPanel.Controls.Add(this.dgvStakeholder);
            this.vStakeholderPane.ItemPanel.Location = new System.Drawing.Point(1, 30);
            this.vStakeholderPane.ItemPanel.Name = "ItemPanel";
            this.vStakeholderPane.ItemPanel.Size = new System.Drawing.Size(300, 0);
            this.vStakeholderPane.ItemPanel.TabIndex = 1;
            this.vStakeholderPane.Location = new System.Drawing.Point(0, 343);
            this.vStakeholderPane.Name = "vStakeholderPane";
            this.vStakeholderPane.Size = new System.Drawing.Size(302, 30);
            this.vStakeholderPane.TabIndex = 4;
            this.vStakeholderPane.Text = "Stakeholder";
            this.vStakeholderPane.TooltipText = "Stakeholders";
            // 
            // dgvStakeholder
            // 
            this.dgvStakeholder.AllowUserToAddRows = false;
            this.dgvStakeholder.AllowUserToDeleteRows = false;
            this.dgvStakeholder.AllowUserToResizeRows = false;
            this.dgvStakeholder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStakeholder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStakeholder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmStakeholderGuid,
            this.clmStakeholderName,
            this.clmStakeholderAction});
            this.dgvStakeholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStakeholder.Location = new System.Drawing.Point(0, 0);
            this.dgvStakeholder.Name = "dgvStakeholder";
            this.dgvStakeholder.ReadOnly = true;
            this.dgvStakeholder.RowHeadersVisible = false;
            this.dgvStakeholder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStakeholder.Size = new System.Drawing.Size(300, 0);
            this.dgvStakeholder.TabIndex = 19;
            this.dgvStakeholder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStakeholder_CellContentClick);
            this.dgvStakeholder.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStakeholder_CellContentDoubleClick);
            this.dgvStakeholder.Leave += new System.EventHandler(this.dgvStakeholder_Leave);
            // 
            // clmStakeholderGuid
            // 
            this.clmStakeholderGuid.HeaderText = "stakeholderGuid";
            this.clmStakeholderGuid.Name = "clmStakeholderGuid";
            this.clmStakeholderGuid.ReadOnly = true;
            this.clmStakeholderGuid.Visible = false;
            // 
            // clmStakeholderName
            // 
            this.clmStakeholderName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmStakeholderName.HeaderText = "Stakeholder";
            this.clmStakeholderName.Name = "clmStakeholderName";
            this.clmStakeholderName.ReadOnly = true;
            // 
            // clmStakeholderAction
            // 
            this.clmStakeholderAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmStakeholderAction.HeaderText = "Action";
            this.clmStakeholderAction.Name = "clmStakeholderAction";
            this.clmStakeholderAction.ReadOnly = true;
            // 
            // vHistoryPane
            // 
            this.vHistoryPane.BackColor = System.Drawing.Color.White;
            this.vHistoryPane.HeaderText = "History";
            // 
            // vHistoryPane.ItemPanel
            // 
            this.vHistoryPane.ItemPanel.AutoScroll = true;
            this.vHistoryPane.ItemPanel.Controls.Add(this.dgvHistory);
            this.vHistoryPane.ItemPanel.Location = new System.Drawing.Point(1, 30);
            this.vHistoryPane.ItemPanel.Name = "ItemPanel";
            this.vHistoryPane.ItemPanel.Size = new System.Drawing.Size(300, 0);
            this.vHistoryPane.ItemPanel.TabIndex = 1;
            this.vHistoryPane.Location = new System.Drawing.Point(0, 373);
            this.vHistoryPane.Name = "vHistoryPane";
            this.vHistoryPane.Size = new System.Drawing.Size(302, 30);
            this.vHistoryPane.TabIndex = 5;
            this.vHistoryPane.Text = "History";
            this.vHistoryPane.TooltipText = "History";
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AllowUserToResizeRows = false;
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmHistoryGuid,
            this.clmHistoryState,
            this.clmHistoryDate});
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.Location = new System.Drawing.Point(0, 0);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.Size = new System.Drawing.Size(300, 0);
            this.dgvHistory.TabIndex = 0;
            this.dgvHistory.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvHistory_CellBeginEdit);
            this.dgvHistory.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistory_CellEndEdit);
            this.dgvHistory.Leave += new System.EventHandler(this.dgvHistory_Leave);
            // 
            // clmHistoryGuid
            // 
            this.clmHistoryGuid.HeaderText = "historyGuid";
            this.clmHistoryGuid.Name = "clmHistoryGuid";
            this.clmHistoryGuid.Visible = false;
            // 
            // clmHistoryState
            // 
            this.clmHistoryState.HeaderText = "State";
            this.clmHistoryState.Name = "clmHistoryState";
            this.clmHistoryState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmHistoryDate
            // 
            this.clmHistoryDate.HeaderText = "Date";
            this.clmHistoryDate.Name = "clmHistoryDate";
            this.clmHistoryDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Content
            // 
            this.Content.BackColor = System.Drawing.Color.Transparent;
            this.Content.Location = new System.Drawing.Point(0, 0);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(200, 100);
            this.Content.TabIndex = 0;
            // 
            // rtbRationale
            // 
            this.rtbRationale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbRationale.Location = new System.Drawing.Point(3, 16);
            this.rtbRationale.Name = "rtbRationale";
            this.rtbRationale.Size = new System.Drawing.Size(574, 644);
            this.rtbRationale.TabIndex = 1;
            // 
            // rtbTopicDescription
            // 
            this.rtbTopicDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbTopicDescription.Location = new System.Drawing.Point(3, 16);
            this.rtbTopicDescription.Name = "rtbTopicDescription";
            this.rtbTopicDescription.Size = new System.Drawing.Size(303, 254);
            this.rtbTopicDescription.TabIndex = 121;
            // 
            // DetailViewController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spltDetailView);
            this.Name = "DetailViewController";
            this.Size = new System.Drawing.Size(916, 769);
            this.Load += new System.EventHandler(this.DetailViewController_Load);
            this.spltDetailView.Panel1.ResumeLayout(false);
            this.spltDetailView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltDetailView)).EndInit();
            this.spltDetailView.ResumeLayout(false);
            this.gpbDecisionInformation.ResumeLayout(false);
            this.gpbDecisionInformation.PerformLayout();
            this.gpbRationale.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gpbTopicInformation.ResumeLayout(false);
            this.gpbTopicInformation.PerformLayout();
            this.grpDescription.ResumeLayout(false);
            this.gpbAdditionalInformation.ResumeLayout(false);
            this.pnlAccordion.ResumeLayout(false);
            this.vAccordionPane.ResumeLayout(false);
            this.vAlternativePane.ItemPanel.ResumeLayout(false);
            this.vAlternativePane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlternativeDecisions)).EndInit();
            this.vRelatedPane.ItemPanel.ResumeLayout(false);
            this.vRelatedPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatedDecisions)).EndInit();
            this.vForcesPane.ItemPanel.ResumeLayout(false);
            this.vForcesPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvForces)).EndInit();
            this.vTracesPane.ItemPanel.ResumeLayout(false);
            this.vTracesPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraces)).EndInit();
            this.vStakeholderPane.ItemPanel.ResumeLayout(false);
            this.vStakeholderPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStakeholder)).EndInit();
            this.vHistoryPane.ItemPanel.ResumeLayout(false);
            this.vHistoryPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FontDialog fontDialog1;
        private SplitContainer spltDetailView;
        private VIBlend.WinForms.Controls.vContentPanel Content;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DateTimePicker dtpHistoryCell;
        private SplitContainer splitContainer1;
        private GroupBox gpbTopicInformation;
        private Label lblTopicName;
        private TextBox txtTopicName;
        private GroupBox gpbAdditionalInformation;
        private Panel pnlAccordion;
        private VIBlend.WinForms.Controls.vNavPane vAccordionPane;
        private VIBlend.WinForms.Controls.vNavPaneItem vAlternativePane;
        private VIBlend.WinForms.Controls.vNavPaneItem vRelatedPane;
        private DataGridView dgvRelatedDecisions;
        private VIBlend.WinForms.Controls.vNavPaneItem vForcesPane;
        private DataGridView dgvForces;
        private VIBlend.WinForms.Controls.vNavPaneItem vTracesPane;
        private DataGridView dgvTraces;
        private DataGridViewTextBoxColumn clmTraceGuid;
        private DataGridViewTextBoxColumn clmTraceName;
        private DataGridViewTextBoxColumn clmTraceType;
        private VIBlend.WinForms.Controls.vNavPaneItem vStakeholderPane;
        private DataGridView dgvStakeholder;
        private DataGridViewTextBoxColumn clmStakeholderGuid;
        private DataGridViewTextBoxColumn clmStakeholderName;
        private DataGridViewTextBoxColumn clmStakeholderAction;
        private VIBlend.WinForms.Controls.vNavPaneItem vHistoryPane;
        private DataGridView dgvHistory;
        private GroupBox gpbDecisionInformation;
        private GroupBox gpbRationale;
        private CustomRichTextBox pnlRichTextBox;
        private Label lblDecisionState;
        private ComboBox cbxState;
        private Label lblDecisionName;
        private TextBox txtDecisionName;
        private DateTimePicker dtModified;
        private Label lblAuthor;
        private TextBox txtAuthor;
        private Label lblModified;
        private DataGridViewTextBoxColumn clmHistoryGuid;
        private DataGridViewTextBoxColumn clmHistoryState;
        private DataGridViewTextBoxColumn clmHistoryDate;
        private DataGridViewTextBoxColumn clmRelatedGuid;
        private DataGridViewTextBoxColumn clmRelation;
        private DataGridViewTextBoxColumn clmRelatedName;
        private DataGridViewTextBoxColumn clmRelatedTo;
        private DataGridViewTextBoxColumn clmRelatedUid;
        private DataGridViewTextBoxColumn clmForceGuid;
        private DataGridViewTextBoxColumn clmForcesName;
        private DataGridViewTextBoxColumn clmForceConcern;
        private DataGridViewTextBoxColumn clmForceRating;
        private DataGridViewTextBoxColumn clmForceDescription;
        private DataGridView dgvAlternativeDecisions;
        private DataGridViewTextBoxColumn clmAlternativeGuid;
        private DataGridViewTextBoxColumn clmAlternativeID;
        private DataGridViewTextBoxColumn clmAlternativeName;
        private DataGridViewTextBoxColumn clmAlternativeState;
        private DataGridViewTextBoxColumn clmAlternativeRationale;
        private CustomRichTextBox pnlTopicDescription;
        private CustomRichTextBox rtbTopicDescription;
        private CustomRichTextBox rtbRationale;
        private GroupBox grpDescription;
    }
}