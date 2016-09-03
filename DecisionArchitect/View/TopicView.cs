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
    Mathieu Kalksma (University of Groningen)
*/

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DecisionArchitect.Logic.EventHandler;
using DecisionArchitect.Model;
using DecisionArchitect.Utilities;
using DecisionArchitect.View.Chronology;
using DecisionArchitect.View.Dialogs;
using DecisionArchitect.View.Forces;
using DecisionArchitect.View.Stakeholders;

namespace DecisionArchitect.View
{
    [ComVisible(true)]
    public interface ITopicViewController
    {
        ITopic Topic { get; set; }
    }

    [ComVisible(true)]
    [Guid("D65970AD-12A7-402A-9F88-ED50D8C1DD90")]
    [ProgId("DecisionViewpoints.TopicViewController")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof (ITopicViewController))]
    public partial class TopicViewController : DecisionArchitectControl, ITopicViewController
    {
        // Model
        private ITopic _topic;
        //use other class to keep track of events as it is a twisted mess otherwise
        //this will keep track of changes that affect multiple views at once
        //like the deleting of forces or decisions 
        private TopicViewDelegater _eventDelegater;

        public TopicForceView ForcesView { get { return topicForceView1; } }
        public ChronologyView ChronologyView { get { return chronologyView1;  }}
        public StakeholdersView StakeholdersView { get { return stakeholdersView1;  }}

        public TopicViewController()
        {
            InitializeComponent();
            tableDetails.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
        }

        public TopicViewController(ITopic topic)
            : this()
        {
            Topic = topic;
        }


        public string TopicName
        {
            get { return txtTopicName.Text.Trim(' '); }
            set { txtTopicName.Text = value; }
        }

        public string TopicDescription
        {
            get { return rtbDescription.RichText; }
            set { rtbDescription.RichText = value; }
        }

        public ITopic Topic
        {
            get { return _topic; }
            set
            {
                if (value == null || value.Equals(_topic))
                {
                    txtTopicName.DataBindings.Clear();
                    rtbDescription.DataBindings.Clear();
                    btnSave.DataBindings.Clear();
                    btnRevert.DataBindings.Clear();
                }

                _topic = value;
                if (_topic != null)
                {
                    txtTopicName.DataBindings.Add("Text", Topic, "Name");
                    rtbDescription.DataBindings.Add("RichText", Topic, "Description");
                    btnSave.DataBindings.Add("Enabled", Topic, "Changed");
                    btnRevert.DataBindings.Add("Enabled", Topic, "Changed");
                    UpdateDecisionsDgv();
                    UpdateForcesDgv();
                    BindForces();
                    BindStakeholders();
                    BindInfo();
                    UpdateFilesDgv();
                    BindChronology();

                    _eventDelegater = new TopicViewDelegater(this);
                }
            }
        }

        private void BindChronology()
        {
            chronologyView1.Refresh(Topic.Decisions);
        }

        #region Forces

        public void UpdateForcesDgv()
        {
            var forces = Topic.Forces.OrderBy(f => f.Concern.Name).ThenBy(f => f.Force.Name).ToList();
            treeForces.Nodes.Clear();
            var concerns =
                forces.Select(c => c.Concern).GroupBy(c => c.ConcernGUID).Select(g => g.First()).ToList();
            foreach (var concern in concerns)
            {
                var node =  treeForces.Nodes.Add(concern.ConcernGUID, concern.Name);
                var relevantForces =
                    // ReSharper disable once AccessToForEachVariableInClosure
                    (from f in forces where f.Concern.ConcernGUID.Equals(concern.ConcernGUID) select f.Force)
                        .Distinct();
                foreach (var force in relevantForces)
                {
                    node.Nodes.Add(force.ForceGUID, force.Name);
                }
            }
            treeForces.ExpandAll();
        }

        private void BindForces()
        {
            ForcesView.Init(Topic);
        }

        private void treeForces_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                forcesMenuStrip.Show(Cursor.Position);
        }

        private void addNewForceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new SelectForceDialog(Topic.Forces);
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Topic.Forces.Add(new TopicForceEvaluation(Topic, dialog.Force, dialog.Concern, Topic.Decisions));
            }
        }


        #endregion

        #region Decisions

        public void UpdateDecisionsDgv()
        {
            dgvDecisions.Rows.Clear();
            foreach (var decision in Topic.Decisions.Where(x => !x.DoDelete))
                dgvDecisions.Rows.Add(decision.Name, decision.State);
        }

        private void dgvDecisions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0) return;
            var row = e.RowIndex;
            var decision = Topic.Decisions[row];
            DetailViewHandler.Instance.OpenDecisionDetailView(decision);
        }

        private void dgvDecisions_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (var i = e.RowIndex; i < e.RowIndex + e.RowCount; i++)
            {
                var state = Topic.Decisions[i].State;
                dgvDecisions.Rows[i].Cells[1].Value = state;
                ColorRowAccordingToState(dgvDecisions.Rows[i], Topic.Decisions[i].State);
            }
            AutoResizeDataGridView(dgvDecisions, true);
        }


        private void dgvDecisions_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                decisionMenuStrip.Show(Cursor.Position);
        }

        private void deleteDecisionMenu_Click(object sender, EventArgs e)
        {
            var decision = Topic.Decisions[_selectedDecisioToDeleteIndex];
            decision.DoDelete = true;
            //_eventDelegater.DeleteDecision(decision);
        }

        private int _selectedDecisioToDeleteIndex;
        private void dgvDecisions_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            _selectedDecisioToDeleteIndex = e.RowIndex;
            decisionDeleteMenuStrip.Show(Cursor.Position);
        }

        private void newDecisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var element = Topic.Element;
            var dialog = new CreateDecisionDialog(string.Format(Messages.NameSuggestionDecision, element.Name));

            if (dialog.ShowDialog() == DialogResult.OK)
                Topic.Decisions.Add(Decision.Create(dialog.GetName(), dialog.GetState(), Topic));

        }

        private void dgvDecisions_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 0) return;
            toolTip1.Show(Utils.FormattedRtfToPlainText(Topic.Decisions[e.RowIndex].Rationale), this,
                PointToClient(Cursor.Position));
        }

        private void dgvDecisions_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void dgvDecisions_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var comboBox = e.Control as ComboBox;
            if (comboBox == null) return;
            comboBox.SelectedValueChanged -= ComboBoxOnSelectedValueChanged;
            comboBox.SelectedValueChanged += ComboBoxOnSelectedValueChanged;
        }

        private void ComboBoxOnSelectedValueChanged(object sender, EventArgs eventArgs)
        {
            if (dgvDecisions.CurrentRow == null)
                return;
            var comboBox = (ComboBox)sender;
            var newState = comboBox.Text;
            var decision = Topic.Decisions[dgvDecisions.CurrentRow.Index];
            decision.State = newState;
        }


        #endregion

        #region Stakeholders

        private void BindStakeholders()
        {
            stakeholdersView1.Show(this, Topic.Decisions);
            UpdateStakeholdersDgv();
        }

        public void UpdateStakeholdersDgv()
        {
            dgvStakeholders.AutoGenerateColumns = false;
            var list = Topic.Decisions.SelectMany(decision => decision.Stakeholders)
                .Where(action => !action.DoDelete && !action.Decision.DoDelete)
                .Select(x => x.Stakeholder)
                .GroupBy(s => s.GUID)
                .Select(g => g.First())
                .ToList();

            dgvStakeholders.DataSource = new BindingSource(list, null);
        }

        private void dgvStakeholders_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            AutoResizeDataGridView((DataGridView)sender, false);
        }


        #endregion

        private void BindInfo()
        {
            dgvInfo.Rows.Add("Last modified", Topic.Modified);
            dgvInfo.Rows.Add("Author", Topic.Author);
        }


        #region Persist
        public void Save()
        {
            _topic.SaveChanges();
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(Messages.WarningRevertChanges,
                                                        Messages.WarningRevertChangesTitle, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Topic.DiscardChanges();
                _eventDelegater.RevertAllChanges();
                UpdateFilesDgv();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Topic.SaveChanges())
            {
                ChronologyView.RefreshAll(Topic.Decisions);
            }
        }

        #endregion

        #region rendering

        private static void AutoResizeDataGridView(DataGridView view, bool includeHeaderHeight)
        {
            view.Height = view.Rows.GetRowsHeight(DataGridViewElementStates.None) + (includeHeaderHeight ? view.ColumnHeadersHeight : 0) + 2;
            view.Width = view.Columns.GetColumnsWidth(DataGridViewElementStates.None) + view.RowHeadersWidth + 2 - SystemInformation.VerticalScrollBarWidth;
        }




        #endregion

        #region Files

        private void UpdateFilesDgv()
        {
            dgvFiles.AutoGenerateColumns = false;
            dgvFiles.DataSource = new BindingSource(Topic.Files.Where(x => !x.DoDelete), null);
        }

        private void AddFileMenu_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Multiselect = false
            };
            var result = fileDialog.ShowDialog(this);
            if (result != DialogResult.OK) return;
            Topic.Files.Add(new DAFile(fileDialog.FileName, Topic.GUID));
            UpdateFilesDgv();
        }

        private void dgvFiles_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            fileMenuStrip.Tag = Topic.Files[e.RowIndex];
            fileMenuStrip.Show(Cursor.Position);
        }

        private void DeleteFileMenu_Click(object sender, EventArgs e)
        {
            var file = (DAFile)fileMenuStrip.Tag;
            file.DoDelete = true;
            UpdateFilesDgv();
        }

        private void dgvFiles_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            addFileMenuStrip.Show(Cursor.Position);
        }

        private void dgvFiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var file = Topic.Files.Where(x => !x.DoDelete).ToList()[e.RowIndex];
            if (File.Exists(file.Path))
            {
                Process.Start(file.Path);
            }
            else
            {
                MessageBox.Show("File doesn't exists!");
            }
        }

        #endregion

    }
}