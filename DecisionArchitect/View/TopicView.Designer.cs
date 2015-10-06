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

using DecisionArchitect.View.Components.RichTextBox;

namespace DecisionArchitect.View
{
    partial class TopicViewController
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
            this.forcesMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewForceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRevert = new System.Windows.Forms.Button();
            this.gpbTopicInformation = new System.Windows.Forms.GroupBox();
            this.tableSplitter = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabOverview = new System.Windows.Forms.TabPage();
            this.tableOverview = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTopicName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.rtbDescription = new DecisionArchitect.View.Components.RichTextBox.CustomRichTextBox();
            this.tabForces = new System.Windows.Forms.TabPage();
            this.topicForceView1 = new DecisionArchitect.View.Forces.TopicForceView();
            this.tabStakeholders = new System.Windows.Forms.TabPage();
            this.stakeholdersView1 = new DecisionArchitect.View.Stakeholders.StakeholdersView();
            this.tabChronology = new System.Windows.Forms.TabPage();
            this.chronologyView1 = new DecisionArchitect.View.Chronology.ChronologyView();
            this.tableDetails = new System.Windows.Forms.TableLayoutPanel();
            this.vNavPane1 = new VIBlend.WinForms.Controls.vNavPane();
            this.vNavPaneItemDecisions = new VIBlend.WinForms.Controls.vNavPaneItem();
            this.dgvDecisions = new System.Windows.Forms.DataGridView();
            this.dgvDecisionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDecisionState = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.vNavPaneItemForces = new VIBlend.WinForms.Controls.vNavPaneItem();
            this.treeForces = new System.Windows.Forms.TreeView();
            this.vNavPaneItemStakeholders = new VIBlend.WinForms.Controls.vNavPaneItem();
            this.dgvStakeholders = new System.Windows.Forms.DataGridView();
            this.dgvStakeholdersName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vNavPaneItemInfo = new VIBlend.WinForms.Controls.vNavPaneItem();
            this.dgvInfo = new System.Windows.Forms.DataGridView();
            this.dgvInfoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvInfoValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vNavPaneItemFiles = new VIBlend.WinForms.Controls.vNavPaneItem();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.dgvFilesFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.decisionMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newDecisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decisionDeleteMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.fileMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAddFile = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addFileMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forcesMenuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gpbTopicInformation.SuspendLayout();
            this.tableSplitter.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabOverview.SuspendLayout();
            this.tableOverview.SuspendLayout();
            this.tabForces.SuspendLayout();
            this.tabStakeholders.SuspendLayout();
            this.tabChronology.SuspendLayout();
            this.tableDetails.SuspendLayout();
            this.vNavPane1.SuspendLayout();
            this.vNavPaneItemDecisions.ItemPanel.SuspendLayout();
            this.vNavPaneItemDecisions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDecisions)).BeginInit();
            this.vNavPaneItemForces.ItemPanel.SuspendLayout();
            this.vNavPaneItemForces.SuspendLayout();
            this.vNavPaneItemStakeholders.ItemPanel.SuspendLayout();
            this.vNavPaneItemStakeholders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStakeholders)).BeginInit();
            this.vNavPaneItemInfo.ItemPanel.SuspendLayout();
            this.vNavPaneItemInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            this.vNavPaneItemFiles.ItemPanel.SuspendLayout();
            this.vNavPaneItemFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.decisionMenuStrip.SuspendLayout();
            this.decisionDeleteMenuStrip.SuspendLayout();
            this.fileMenuStrip.SuspendLayout();
            this.addFileMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // forcesMenuStrip
            // 
            this.forcesMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewForceToolStripMenuItem});
            this.forcesMenuStrip.Name = "forcesMenuStrip";
            this.forcesMenuStrip.Size = new System.Drawing.Size(152, 26);
            // 
            // addNewForceToolStripMenuItem
            // 
            this.addNewForceToolStripMenuItem.Name = "addNewForceToolStripMenuItem";
            this.addNewForceToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.addNewForceToolStripMenuItem.Text = "Add new force";
            this.addNewForceToolStripMenuItem.Click += new System.EventHandler(this.addNewForceToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.gpbTopicInformation, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(669, 467);
            this.tableLayoutPanel1.TabIndex = 127;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnRevert);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 432);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 32);
            this.panel1.TabIndex = 126;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(504, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 125;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRevert
            // 
            this.btnRevert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevert.Location = new System.Drawing.Point(585, 3);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(75, 23);
            this.btnRevert.TabIndex = 126;
            this.btnRevert.Text = "Revert";
            this.btnRevert.UseVisualStyleBackColor = true;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // gpbTopicInformation
            // 
            this.gpbTopicInformation.BackColor = System.Drawing.Color.Transparent;
            this.gpbTopicInformation.Controls.Add(this.tableSplitter);
            this.gpbTopicInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbTopicInformation.Location = new System.Drawing.Point(3, 3);
            this.gpbTopicInformation.Name = "gpbTopicInformation";
            this.gpbTopicInformation.Size = new System.Drawing.Size(663, 423);
            this.gpbTopicInformation.TabIndex = 124;
            this.gpbTopicInformation.TabStop = false;
            this.gpbTopicInformation.Text = "Topic";
            // 
            // tableSplitter
            // 
            this.tableSplitter.ColumnCount = 2;
            this.tableSplitter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableSplitter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableSplitter.Controls.Add(this.tabControl1, 0, 0);
            this.tableSplitter.Controls.Add(this.tableDetails, 1, 0);
            this.tableSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableSplitter.Location = new System.Drawing.Point(3, 16);
            this.tableSplitter.Name = "tableSplitter";
            this.tableSplitter.RowCount = 1;
            this.tableSplitter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableSplitter.Size = new System.Drawing.Size(657, 404);
            this.tableSplitter.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabOverview);
            this.tabControl1.Controls.Add(this.tabForces);
            this.tabControl1.Controls.Add(this.tabStakeholders);
            this.tabControl1.Controls.Add(this.tabChronology);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(453, 398);
            this.tabControl1.TabIndex = 0;
            // 
            // tabOverview
            // 
            this.tabOverview.Controls.Add(this.tableOverview);
            this.tabOverview.Location = new System.Drawing.Point(4, 22);
            this.tabOverview.Name = "tabOverview";
            this.tabOverview.Size = new System.Drawing.Size(445, 372);
            this.tabOverview.TabIndex = 0;
            this.tabOverview.Text = "Overview";
            this.tabOverview.UseVisualStyleBackColor = true;
            // 
            // tableOverview
            // 
            this.tableOverview.ColumnCount = 1;
            this.tableOverview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableOverview.Controls.Add(this.lblTitle, 0, 0);
            this.tableOverview.Controls.Add(this.txtTopicName, 0, 1);
            this.tableOverview.Controls.Add(this.lblDescription, 0, 2);
            this.tableOverview.Controls.Add(this.rtbDescription, 0, 3);
            this.tableOverview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableOverview.Location = new System.Drawing.Point(0, 0);
            this.tableOverview.Name = "tableOverview";
            this.tableOverview.RowCount = 4;
            this.tableOverview.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableOverview.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableOverview.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableOverview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableOverview.Size = new System.Drawing.Size(445, 372);
            this.tableOverview.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(439, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title:";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTopicName
            // 
            this.txtTopicName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTopicName.Location = new System.Drawing.Point(3, 16);
            this.txtTopicName.Name = "txtTopicName";
            this.txtTopicName.Size = new System.Drawing.Size(439, 20);
            this.txtTopicName.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescription.Location = new System.Drawing.Point(3, 39);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(439, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description:";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rtbDescription
            // 
            this.rtbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDescription.Location = new System.Drawing.Point(4, 56);
            this.rtbDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.RichText = "{rtfData}{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1043{\\fonttbl{\\f0\\fnil\\fcharset0 Mi" +
    "crosoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17\\par\r\n}\r\n{rtfData}{linkPositio" +
    "ns}{linkPositions}";
            this.rtbDescription.Size = new System.Drawing.Size(437, 312);
            this.rtbDescription.TabIndex = 3;
            // 
            // tabForces
            // 
            this.tabForces.Controls.Add(this.topicForceView1);
            this.tabForces.Location = new System.Drawing.Point(4, 22);
            this.tabForces.Name = "tabForces";
            this.tabForces.Size = new System.Drawing.Size(446, 373);
            this.tabForces.TabIndex = 1;
            this.tabForces.Text = "Forces";
            this.tabForces.UseVisualStyleBackColor = true;
            // 
            // topicForceView1
            // 
            this.topicForceView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topicForceView1.Location = new System.Drawing.Point(0, 0);
            this.topicForceView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.topicForceView1.Name = "topicForceView1";
            this.topicForceView1.Size = new System.Drawing.Size(446, 373);
            this.topicForceView1.TabIndex = 0;
            // 
            // tabStakeholders
            // 
            this.tabStakeholders.Controls.Add(this.stakeholdersView1);
            this.tabStakeholders.Location = new System.Drawing.Point(4, 22);
            this.tabStakeholders.Name = "tabStakeholders";
            this.tabStakeholders.Size = new System.Drawing.Size(446, 373);
            this.tabStakeholders.TabIndex = 2;
            this.tabStakeholders.Text = "Stakeholders";
            this.tabStakeholders.UseVisualStyleBackColor = true;
            // 
            // stakeholdersView1
            // 
            this.stakeholdersView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stakeholdersView1.Location = new System.Drawing.Point(0, 0);
            this.stakeholdersView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stakeholdersView1.Name = "stakeholdersView1";
            this.stakeholdersView1.Size = new System.Drawing.Size(446, 373);
            this.stakeholdersView1.TabIndex = 0;
            // 
            // tabChronology
            // 
            this.tabChronology.Controls.Add(this.chronologyView1);
            this.tabChronology.Location = new System.Drawing.Point(4, 22);
            this.tabChronology.Name = "tabChronology";
            this.tabChronology.Size = new System.Drawing.Size(446, 373);
            this.tabChronology.TabIndex = 3;
            this.tabChronology.Text = "Chronology";
            this.tabChronology.UseVisualStyleBackColor = true;
            // 
            // chronologyView1
            // 
            this.chronologyView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chronologyView1.Location = new System.Drawing.Point(0, 0);
            this.chronologyView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chronologyView1.Name = "chronologyView1";
            this.chronologyView1.Size = new System.Drawing.Size(446, 373);
            this.chronologyView1.TabIndex = 0;
            // 
            // tableDetails
            // 
            this.tableDetails.AutoScroll = true;
            this.tableDetails.BackColor = System.Drawing.Color.Transparent;
            this.tableDetails.ColumnCount = 1;
            this.tableDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableDetails.Controls.Add(this.vNavPane1, 0, 0);
            this.tableDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableDetails.Location = new System.Drawing.Point(462, 3);
            this.tableDetails.Name = "tableDetails";
            this.tableDetails.RowCount = 1;
            this.tableDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 399F));
            this.tableDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 399F));
            this.tableDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 399F));
            this.tableDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 399F));
            this.tableDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 399F));
            this.tableDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 399F));
            this.tableDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 399F));
            this.tableDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 399F));
            this.tableDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 399F));
            this.tableDetails.Size = new System.Drawing.Size(192, 398);
            this.tableDetails.TabIndex = 1;
            // 
            // vNavPane1
            // 
            this.vNavPane1.Controls.Add(this.vNavPaneItemDecisions);
            this.vNavPane1.Controls.Add(this.vNavPaneItemForces);
            this.vNavPane1.Controls.Add(this.vNavPaneItemStakeholders);
            this.vNavPane1.Controls.Add(this.vNavPaneItemInfo);
            this.vNavPane1.Controls.Add(this.vNavPaneItemFiles);
            this.vNavPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vNavPane1.Items.Add(this.vNavPaneItemDecisions);
            this.vNavPane1.Items.Add(this.vNavPaneItemForces);
            this.vNavPane1.Items.Add(this.vNavPaneItemStakeholders);
            this.vNavPane1.Items.Add(this.vNavPaneItemInfo);
            this.vNavPane1.Items.Add(this.vNavPaneItemFiles);
            this.vNavPane1.Location = new System.Drawing.Point(3, 3);
            this.vNavPane1.Name = "vNavPane1";
            this.vNavPane1.Size = new System.Drawing.Size(186, 392);
            this.vNavPane1.TabIndex = 16;
            this.vNavPane1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.STEEL;
            // 
            // vNavPaneItemDecisions
            // 
            this.vNavPaneItemDecisions.BackColor = System.Drawing.Color.White;
            this.vNavPaneItemDecisions.HeaderText = "Decisions";
            // 
            // vNavPaneItemDecisions.ItemPanel
            // 
            this.vNavPaneItemDecisions.ItemPanel.AutoScroll = true;
            this.vNavPaneItemDecisions.ItemPanel.Controls.Add(this.dgvDecisions);
            this.vNavPaneItemDecisions.ItemPanel.Location = new System.Drawing.Point(1, 30);
            this.vNavPaneItemDecisions.ItemPanel.Name = "ItemPanel";
            this.vNavPaneItemDecisions.ItemPanel.Size = new System.Drawing.Size(184, 241);
            this.vNavPaneItemDecisions.ItemPanel.TabIndex = 1;
            this.vNavPaneItemDecisions.Location = new System.Drawing.Point(0, 0);
            this.vNavPaneItemDecisions.Name = "vNavPaneItemDecisions";
            this.vNavPaneItemDecisions.Size = new System.Drawing.Size(186, 272);
            this.vNavPaneItemDecisions.TabIndex = 0;
            this.vNavPaneItemDecisions.Text = "Decisions";
            this.vNavPaneItemDecisions.TooltipText = "Decisions";
            // 
            // dgvDecisions
            // 
            this.dgvDecisions.AllowUserToAddRows = false;
            this.dgvDecisions.AllowUserToDeleteRows = false;
            this.dgvDecisions.AllowUserToResizeColumns = false;
            this.dgvDecisions.AllowUserToResizeRows = false;
            this.dgvDecisions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDecisions.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDecisions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDecisions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvDecisionName,
            this.dgvDecisionState});
            this.dgvDecisions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDecisions.Location = new System.Drawing.Point(0, 0);
            this.dgvDecisions.MultiSelect = false;
            this.dgvDecisions.Name = "dgvDecisions";
            this.dgvDecisions.RowHeadersVisible = false;
            this.dgvDecisions.Size = new System.Drawing.Size(184, 241);
            this.dgvDecisions.TabIndex = 1;
            this.dgvDecisions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDecisions_CellDoubleClick);
            this.dgvDecisions.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDecisions_CellMouseClick);
            this.dgvDecisions.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDecisions_CellMouseEnter);
            this.dgvDecisions.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDecisions_CellMouseLeave);
            this.dgvDecisions.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDecisions_EditingControlShowing);
            this.dgvDecisions.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvDecisions_RowsAdded);
            this.dgvDecisions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvDecisions_MouseClick);
            // 
            // dgvDecisionName
            // 
            this.dgvDecisionName.DataPropertyName = "Name";
            this.dgvDecisionName.HeaderText = "Decision";
            this.dgvDecisionName.Name = "dgvDecisionName";
            this.dgvDecisionName.ReadOnly = true;
            // 
            // dgvDecisionState
            // 
            this.dgvDecisionState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgvDecisionState.HeaderText = "State";
            this.dgvDecisionState.Items.AddRange(new object[] {
            "idea",
            "tentative",
            "decided",
            "approved",
            "challenged",
            "discarded",
            "rejected"});
            this.dgvDecisionState.Name = "dgvDecisionState";
            // 
            // vNavPaneItemForces
            // 
            this.vNavPaneItemForces.BackColor = System.Drawing.Color.White;
            this.vNavPaneItemForces.HeaderText = "Relevant Forces";
            // 
            // vNavPaneItemForces.ItemPanel
            // 
            this.vNavPaneItemForces.ItemPanel.AutoScroll = true;
            this.vNavPaneItemForces.ItemPanel.Controls.Add(this.treeForces);
            this.vNavPaneItemForces.ItemPanel.Location = new System.Drawing.Point(1, 30);
            this.vNavPaneItemForces.ItemPanel.Name = "ItemPanel";
            this.vNavPaneItemForces.ItemPanel.Size = new System.Drawing.Size(184, 0);
            this.vNavPaneItemForces.ItemPanel.TabIndex = 1;
            this.vNavPaneItemForces.Location = new System.Drawing.Point(0, 272);
            this.vNavPaneItemForces.Name = "vNavPaneItemForces";
            this.vNavPaneItemForces.Size = new System.Drawing.Size(186, 30);
            this.vNavPaneItemForces.TabIndex = 1;
            this.vNavPaneItemForces.Text = "Forces";
            this.vNavPaneItemForces.TooltipText = "Relevant Forces";
            // 
            // treeForces
            // 
            this.treeForces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeForces.Location = new System.Drawing.Point(0, 0);
            this.treeForces.Name = "treeForces";
            this.treeForces.Size = new System.Drawing.Size(184, 0);
            this.treeForces.TabIndex = 15;
            this.treeForces.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeForces_MouseClick);
            // 
            // vNavPaneItemStakeholders
            // 
            this.vNavPaneItemStakeholders.BackColor = System.Drawing.Color.White;
            this.vNavPaneItemStakeholders.HeaderText = "Stakeholders";
            // 
            // vNavPaneItemStakeholders.ItemPanel
            // 
            this.vNavPaneItemStakeholders.ItemPanel.AutoScroll = true;
            this.vNavPaneItemStakeholders.ItemPanel.Controls.Add(this.dgvStakeholders);
            this.vNavPaneItemStakeholders.ItemPanel.Location = new System.Drawing.Point(1, 30);
            this.vNavPaneItemStakeholders.ItemPanel.Name = "ItemPanel";
            this.vNavPaneItemStakeholders.ItemPanel.Size = new System.Drawing.Size(184, 0);
            this.vNavPaneItemStakeholders.ItemPanel.TabIndex = 1;
            this.vNavPaneItemStakeholders.Location = new System.Drawing.Point(0, 302);
            this.vNavPaneItemStakeholders.Name = "vNavPaneItemStakeholders";
            this.vNavPaneItemStakeholders.Size = new System.Drawing.Size(186, 30);
            this.vNavPaneItemStakeholders.TabIndex = 2;
            this.vNavPaneItemStakeholders.Text = "vNavPaneItem1";
            this.vNavPaneItemStakeholders.TooltipText = "Stakeholders";
            // 
            // dgvStakeholders
            // 
            this.dgvStakeholders.AllowUserToAddRows = false;
            this.dgvStakeholders.AllowUserToDeleteRows = false;
            this.dgvStakeholders.AllowUserToResizeColumns = false;
            this.dgvStakeholders.AllowUserToResizeRows = false;
            this.dgvStakeholders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStakeholders.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvStakeholders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStakeholders.ColumnHeadersVisible = false;
            this.dgvStakeholders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvStakeholdersName});
            this.dgvStakeholders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStakeholders.Location = new System.Drawing.Point(0, 0);
            this.dgvStakeholders.Name = "dgvStakeholders";
            this.dgvStakeholders.RowHeadersVisible = false;
            this.dgvStakeholders.Size = new System.Drawing.Size(184, 0);
            this.dgvStakeholders.TabIndex = 7;
            this.dgvStakeholders.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvStakeholders_RowsAdded);
            // 
            // dgvStakeholdersName
            // 
            this.dgvStakeholdersName.DataPropertyName = "Name";
            this.dgvStakeholdersName.HeaderText = "Stakeholder";
            this.dgvStakeholdersName.Name = "dgvStakeholdersName";
            this.dgvStakeholdersName.ReadOnly = true;
            // 
            // vNavPaneItemInfo
            // 
            this.vNavPaneItemInfo.BackColor = System.Drawing.Color.White;
            this.vNavPaneItemInfo.HeaderText = "Info";
            // 
            // vNavPaneItemInfo.ItemPanel
            // 
            this.vNavPaneItemInfo.ItemPanel.AutoScroll = true;
            this.vNavPaneItemInfo.ItemPanel.Controls.Add(this.dgvInfo);
            this.vNavPaneItemInfo.ItemPanel.Location = new System.Drawing.Point(1, 30);
            this.vNavPaneItemInfo.ItemPanel.Name = "ItemPanel";
            this.vNavPaneItemInfo.ItemPanel.Size = new System.Drawing.Size(184, 0);
            this.vNavPaneItemInfo.ItemPanel.TabIndex = 1;
            this.vNavPaneItemInfo.Location = new System.Drawing.Point(0, 332);
            this.vNavPaneItemInfo.Name = "vNavPaneItemInfo";
            this.vNavPaneItemInfo.Size = new System.Drawing.Size(186, 30);
            this.vNavPaneItemInfo.TabIndex = 3;
            this.vNavPaneItemInfo.Text = "vNavPaneItem1";
            this.vNavPaneItemInfo.TooltipText = "Info";
            // 
            // dgvInfo
            // 
            this.dgvInfo.AllowUserToAddRows = false;
            this.dgvInfo.AllowUserToDeleteRows = false;
            this.dgvInfo.AllowUserToResizeColumns = false;
            this.dgvInfo.AllowUserToResizeRows = false;
            this.dgvInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInfo.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfo.ColumnHeadersVisible = false;
            this.dgvInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvInfoName,
            this.dgvInfoValue});
            this.dgvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.RowHeadersVisible = false;
            this.dgvInfo.Size = new System.Drawing.Size(184, 0);
            this.dgvInfo.TabIndex = 9;
            // 
            // dgvInfoName
            // 
            this.dgvInfoName.HeaderText = "Name";
            this.dgvInfoName.Name = "dgvInfoName";
            this.dgvInfoName.ReadOnly = true;
            // 
            // dgvInfoValue
            // 
            this.dgvInfoValue.HeaderText = "Value";
            this.dgvInfoValue.Name = "dgvInfoValue";
            this.dgvInfoValue.ReadOnly = true;
            // 
            // vNavPaneItemFiles
            // 
            this.vNavPaneItemFiles.BackColor = System.Drawing.Color.White;
            this.vNavPaneItemFiles.HeaderText = "Files";
            // 
            // vNavPaneItemFiles.ItemPanel
            // 
            this.vNavPaneItemFiles.ItemPanel.AutoScroll = true;
            this.vNavPaneItemFiles.ItemPanel.Controls.Add(this.dgvFiles);
            this.vNavPaneItemFiles.ItemPanel.Location = new System.Drawing.Point(1, 30);
            this.vNavPaneItemFiles.ItemPanel.Name = "ItemPanel";
            this.vNavPaneItemFiles.ItemPanel.Size = new System.Drawing.Size(184, 0);
            this.vNavPaneItemFiles.ItemPanel.TabIndex = 1;
            this.vNavPaneItemFiles.Location = new System.Drawing.Point(0, 362);
            this.vNavPaneItemFiles.Name = "vNavPaneItemFiles";
            this.vNavPaneItemFiles.Size = new System.Drawing.Size(186, 30);
            this.vNavPaneItemFiles.TabIndex = 4;
            this.vNavPaneItemFiles.Text = "vNavPaneItem1";
            this.vNavPaneItemFiles.TooltipText = "Files";
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.AllowUserToDeleteRows = false;
            this.dgvFiles.AllowUserToResizeColumns = false;
            this.dgvFiles.AllowUserToResizeRows = false;
            this.dgvFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFiles.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.ColumnHeadersVisible = false;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvFilesFile});
            this.dgvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFiles.Location = new System.Drawing.Point(0, 0);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.RowHeadersVisible = false;
            this.dgvFiles.Size = new System.Drawing.Size(184, 0);
            this.dgvFiles.TabIndex = 12;
            this.dgvFiles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiles_CellDoubleClick);
            this.dgvFiles.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFiles_CellMouseClick);
            this.dgvFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvFiles_MouseDown);
            // 
            // dgvFilesFile
            // 
            this.dgvFilesFile.DataPropertyName = "Name";
            this.dgvFilesFile.HeaderText = "File";
            this.dgvFilesFile.Name = "dgvFilesFile";
            // 
            // decisionMenuStrip
            // 
            this.decisionMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDecisionToolStripMenuItem});
            this.decisionMenuStrip.Name = "decisionMenuStrip";
            this.decisionMenuStrip.Size = new System.Drawing.Size(146, 26);
            // 
            // newDecisionToolStripMenuItem
            // 
            this.newDecisionToolStripMenuItem.Name = "newDecisionToolStripMenuItem";
            this.newDecisionToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.newDecisionToolStripMenuItem.Text = "New decision";
            this.newDecisionToolStripMenuItem.Click += new System.EventHandler(this.newDecisionToolStripMenuItem_Click);
            // 
            // decisionDeleteMenuStrip
            // 
            this.decisionDeleteMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.deleteToolStripMenuItem});
            this.decisionDeleteMenuStrip.Name = "decisionMenuStrip";
            this.decisionDeleteMenuStrip.Size = new System.Drawing.Size(146, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.toolStripMenuItem1.Text = "New decision";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.newDecisionToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteDecisionMenu_Click);
            // 
            // fileMenuStrip
            // 
            this.fileMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddFile,
            this.deleteToolStripMenuItem1});
            this.fileMenuStrip.Name = "addFileMenuStrip";
            this.fileMenuStrip.Size = new System.Drawing.Size(116, 48);
            // 
            // menuAddFile
            // 
            this.menuAddFile.Name = "menuAddFile";
            this.menuAddFile.Size = new System.Drawing.Size(115, 22);
            this.menuAddFile.Text = "Add file";
            this.menuAddFile.Click += new System.EventHandler(this.AddFileMenu_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.DeleteFileMenu_Click);
            // 
            // addFileMenuStrip
            // 
            this.addFileMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFileToolStripMenuItem});
            this.addFileMenuStrip.Name = "addFileMenuStrip";
            this.addFileMenuStrip.Size = new System.Drawing.Size(116, 26);
            // 
            // addFileToolStripMenuItem
            // 
            this.addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
            this.addFileToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.addFileToolStripMenuItem.Text = "Add file";
            this.addFileToolStripMenuItem.Click += new System.EventHandler(this.AddFileMenu_Click);
            // 
            // TopicViewController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TopicViewController";
            this.Size = new System.Drawing.Size(669, 467);
            this.forcesMenuStrip.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gpbTopicInformation.ResumeLayout(false);
            this.tableSplitter.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabOverview.ResumeLayout(false);
            this.tableOverview.ResumeLayout(false);
            this.tableOverview.PerformLayout();
            this.tabForces.ResumeLayout(false);
            this.tabStakeholders.ResumeLayout(false);
            this.tabChronology.ResumeLayout(false);
            this.tableDetails.ResumeLayout(false);
            this.vNavPane1.ResumeLayout(false);
            this.vNavPaneItemDecisions.ItemPanel.ResumeLayout(false);
            this.vNavPaneItemDecisions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDecisions)).EndInit();
            this.vNavPaneItemForces.ItemPanel.ResumeLayout(false);
            this.vNavPaneItemForces.ResumeLayout(false);
            this.vNavPaneItemStakeholders.ItemPanel.ResumeLayout(false);
            this.vNavPaneItemStakeholders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStakeholders)).EndInit();
            this.vNavPaneItemInfo.ItemPanel.ResumeLayout(false);
            this.vNavPaneItemInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            this.vNavPaneItemFiles.ItemPanel.ResumeLayout(false);
            this.vNavPaneItemFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.decisionMenuStrip.ResumeLayout(false);
            this.decisionDeleteMenuStrip.ResumeLayout(false);
            this.fileMenuStrip.ResumeLayout(false);
            this.addFileMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbTopicInformation;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRevert;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableSplitter;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabOverview;
        private System.Windows.Forms.TabPage tabForces;
        private System.Windows.Forms.TabPage tabStakeholders;
        private System.Windows.Forms.TabPage tabChronology;
        private System.Windows.Forms.TableLayoutPanel tableOverview;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTopicName;
        private System.Windows.Forms.Label lblDescription;
        private CustomRichTextBox rtbDescription;
        private System.Windows.Forms.TableLayoutPanel tableDetails;
        private System.Windows.Forms.DataGridView dgvDecisions;
        private System.Windows.Forms.DataGridView dgvStakeholders;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvStakeholdersName;
        private System.Windows.Forms.DataGridView dgvInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvInfoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvInfoValue;
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFilesFile;
        private Forces.TopicForceView topicForceView1;
        private System.Windows.Forms.TreeView treeForces;
        private Chronology.ChronologyView chronologyView1;
        private VIBlend.WinForms.Controls.vNavPane vNavPane1;
        private VIBlend.WinForms.Controls.vNavPaneItem vNavPaneItemDecisions;
        private VIBlend.WinForms.Controls.vNavPaneItem vNavPaneItemForces;
        private VIBlend.WinForms.Controls.vNavPaneItem vNavPaneItemStakeholders;
        private VIBlend.WinForms.Controls.vNavPaneItem vNavPaneItemInfo;
        private VIBlend.WinForms.Controls.vNavPaneItem vNavPaneItemFiles;
        private System.Windows.Forms.ContextMenuStrip forcesMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addNewForceToolStripMenuItem;
        private Stakeholders.StakeholdersView stakeholdersView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDecisionName;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvDecisionState;
        private System.Windows.Forms.ContextMenuStrip decisionMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem newDecisionToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip decisionDeleteMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip fileMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuAddFile;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip addFileMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addFileToolStripMenuItem;
        

    }
}
