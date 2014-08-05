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

using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DecisionViewpoints.Model;
using DecisionViewpoints.View.Controller;
using DecisionViewpoints.Logic.Events;
using System.Runtime.InteropServices;
using DocumentFormat.OpenXml.Wordprocessing;
using EAFacade;
using EAFacade.Model;
using System.IO;
using Font = System.Drawing.Font;
using DecisionViewpoints.Logic.Detail;
using DecisionViewpoints.Logic.Chronological;
using System.Collections.Generic;

namespace DecisionViewpoints.View.DecisionView
{
    [ComVisible(true)]
    [Guid("D65970AD-12A7-402A-9F88-ED50D8C1DD81")]
    [ProgId("DecisionViewpoints.DetailViewController")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(IDetailViewController))]
   
    public partial class DetailViewController : UserControl, IDetailViewController
    {
        private IDecision _decision;
        private ITopic _topic;
        public DetailViewController()
        {
            InitializeComponent();
            // Default decision has no topic
            DisableTopicGroupBox();
        }

        public DetailViewController(IDecision decision)
            : this()
        {
            SetDecision(decision);
            LoadDecisionContent();
        }

        public DetailViewController(IDecision decision, ITopic topic)
            : this(decision)
        {
            SetTopic(topic);
            LoadTopicContent();
        }

        private void LoadDecisionContent()
        {
            if (_decision != null)
            {
                // Decision
                LoadDecisionGroupBox();

                // Rationale
                LoadRationaleGroupBox();

                // Additional Information
                LoadAdditionalInformationGroupBox();
            }
        }

        private void LoadTopicContent()
        {
            // Topic
            if (_decision.HasTopic())
            {
                EnableTopicGroupBox();
                LoadTopicGroupBox();
            }
            else
            {
                DisableTopicGroupBox();
            }
        }

        public void Save()
        {
            if (_decision != null)
            {
                _decision.Name = DecisionName;
                _decision.State = DecisionState;
                _decision.Author = DecisionAuthor;
                _decision.Modified = Modified;
                _decision.Rationale = DecisionRationale;

                if (_decision.HasTopic())
                {
                    _topic.Name = TopicName;
                    _topic.Description = TopicDescription;
                    _topic.Save();
                }

                _decision.History = History;
                _decision.Save();
            }
        }

        public void Update()
        {
            LoadDecisionContent();
            LoadTopicContent();
  
            // Update OpenTab?
            // DetailHandler.
        }

        public void SetDecision(IDecision decision)
        {
            _decision = decision;
            if (_decision != null)
            {
                LoadDecisionContent();
            }
        }

        public void SetTopic(ITopic topic)
        {
            _topic = topic;
            if (_topic != null)
            {
                EnableTopicGroupBox();
                LoadTopicGroupBox();
            }
        }

        /// <summary>
        /// This method is called when the form is loaded. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailViewController_Load(object sender, EventArgs e)
        {
            SetHistoryControls();

            //SetInformationChangedListeners();
            //txtAlternativeDetails.Enabled = false;

            ClearAllFocus();
        }

        /********************************************************************************************
         ********************************************************************************************
         ** DECISION GROUPBOX 
         ******************************************************************************************** 
         ********************************************************************************************/
        private void LoadDecisionGroupBox()
        {
            DecisionName = _decision.Name;
            DecisionState = _decision.State;
            Modified = _decision.Modified;
            DecisionAuthor = _decision.Author;
        }

        /// <summary>
        /// Callback state change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxState_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = (ComboBox)sender;
            DecisionState = cb.Text;
        }

        public string DecisionName
        {
            get { return txtDecisionName.Text.Trim(' '); }
            set { txtDecisionName.Text = value; }
        }

        public string DecisionState
        {
            get { return cbxState.Text.Trim(' '); }
            set
            {
                cbxState.Text = value;
                cbxState.BackColor = DecisionStateColor.ConvertStateToColor(value);
            }
        }

        public DateTime Modified
        {
            get { return dtModified.Value; }
            set { dtModified.Value = value; }
        }

        public string DecisionAuthor
        {
            get { return txtAuthor.Text.Trim(' '); }
            set { txtAuthor.Text = value; }
        }

        /********************************************************************************************
         ********************************************************************************************
         ** RATIONALE GROUPBOX 
         ******************************************************************************************** 
         ********************************************************************************************/
        private void LoadRationaleGroupBox()
        {
            DecisionRationale = _decision.Rationale;
        }

        public string DecisionRationale
        {
            get
            {
                return this.rtbRationale.GetRichText();
            }
            set
            {
                rtbRationale.SetRichText(value);
            }
        }

        /********************************************************************************************
         ********************************************************************************************
         ** TOPIC GROUPBOX 
         ******************************************************************************************** 
         ********************************************************************************************/
        private void LoadTopicGroupBox()
        {
            TopicName = _decision.Topic.Name;
            TopicDescription = _decision.Topic.Description;
        }

        public string TopicName
        {
            get { return txtTopicName.Text.Trim(' '); }
            set { txtTopicName.Text = value; }
        }

        //public string TopicDescription
        //{
        //    get { return txtTopicDescription.Rtf.Trim(' '); }
        //    set
        //    {
        //        txtTopicDescription.Rtf = value.Contains("\\rtf1")
        //            ? value
        //            : Utilities.PlaintextToRtf(value);
        //    }
        //}
        public string TopicDescription
        {
            get
            {
                return rtbTopicDescription.GetRichText();
            }
            set
            {
                rtbTopicDescription.SetRichText(value);
            }
        }

        private void EnableTopicGroupBox()
        {
            txtTopicName.Enabled = true;
            rtbTopicDescription.SetEnabled(true);
        }

        private void DisableTopicGroupBox()
        {
            txtTopicName.Enabled = false;
            txtTopicName.Text = "";
            rtbTopicDescription.SetEnabled(false);
            rtbTopicDescription.TextBox.Text = "";
        }

        /********************************************************************************************
         ********************************************************************************************
         ** ADDITIONAL INFORMATION GROUPBOX 
         ******************************************************************************************** 
         ********************************************************************************************/
        private void LoadAdditionalInformationGroupBox()
        {
            LoadAlternativeDecisions();
            LoadRelatedDecisions();
            LoadTraces();
            LoadForces();
            LoadStakeholders();
            LoadHistory();
        }

        /********************************************************************************************
         ** Alternative Decisions 
         ********************************************************************************************/
        private void LoadAlternativeDecisions()
        {
            // Update Alternative Decisions field
            foreach (
                var connector in
                    _decision.Connectors.Where(
                        connector => connector.IsRelationship() && connector.Stereotype.Equals("alternative for")))
            {
                // If yourself, turn around relation
                if (connector.ClientId == _decision.ID)
                {
                    AddAlternativeDecisionToGrid(new Decision(connector.GetSupplier()));
                }
                else
                {
                    AddAlternativeDecisionToGrid(new Decision(connector.GetClient()));
                }
            }
        }

        private void AddAlternativeDecisionToGrid(IDecision decision)
        {
            RemovePossibleDuplicateEntry(decision.GUID, clmAlternativeGuid as DataGridViewColumn, dgvAlternativeDecisions);
            dgvAlternativeDecisions.Rows.Add(decision.GUID, decision.ID, decision.Name, decision.State, decision.Rationale);

            // Color the last added cell
            int rowIndex = dgvAlternativeDecisions.Rows.Count - 1;
            //ColorCellAccordingToState(dgvAlternativeDecisions.Rows[rowIndex].Cells[clmAlternativeState.Name], decision.State);
            ColorRowAccordingToState(dgvAlternativeDecisions.Rows[rowIndex], decision.State);
        }

        // alternative datagridview single click
        private void dgvAlternativeDecisions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var cell = dgvAlternativeDecisions.Rows[e.RowIndex].Cells[clmAlternativeGuid.Name] as DataGridViewTextBoxCell;
            if (cell != null)
            {
                string elementGUID = dgvAlternativeDecisions[0, e.RowIndex].Value.ToString();
                DetailHandler.InvokeViewChange(elementGUID, EANativeType.Element);
            }
        }

        // alternative datagridview double click
        private void dgvAlternativeDecisions_CellContentDubbelClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != clmAlternativeName.Index || e.RowIndex < 0)
                return;

            var cell = dgvAlternativeDecisions.Rows[e.RowIndex].Cells[clmAlternativeGuid.Name] as DataGridViewTextBoxCell;
            if (cell != null)
            {
                string elementGUID = dgvAlternativeDecisions[0, e.RowIndex].Value.ToString();
                DetailHandler.InvokeViewChange(elementGUID, EANativeType.Element);
            }
        }

        private void dgvAlternativeDecisions_Leave(object sender, System.EventArgs e)
        {
            ClearSelection(dgvAlternativeDecisions);
        }

        private void ClearSelection(DataGridView dgv)
        {
            //dgv.ClearSelection();
            //dgv.CurrentCell = null;
            //dgv.Refresh();
        }


        /********************************************************************************************
         ** Related Decisions 
         ********************************************************************************************/
        private void LoadRelatedDecisions()
        {
            // Update Related Decisions field
            foreach (
                var connector in
                    _decision.Connectors.Where(
                        connector => connector.IsRelationship() && !connector.Stereotype.Equals("alternative for")))
            {
                // If this is the case we need the inverse relation
                if (connector.ClientId == _decision.ID)
                {
                    AddRelatedDecisionToGrid(new Decision(connector.GetSupplier()), connector.Stereotype);
                }
                else
                {
                    AddRelatedDecisionToGrid(new Decision(connector.GetClient()), Utilities.AntonymRelation(connector.Stereotype));
                }
            }
        }

        private void AddRelatedDecisionToGrid(IDecision decision, string relation)
        {
            RemovePossibleDuplicateEntry(decision.GUID, clmRelatedGuid as DataGridViewColumn, dgvRelatedDecisions);
            dgvRelatedDecisions.Rows.Add(new object[] { decision.GUID, relation, decision.Name, decision.State, decision.State });

            // Color the last added cell
            int rowIndex = dgvRelatedDecisions.Rows.Count - 1;
            //ColorCellAccordingToState(dgvRelatedDecisions.Rows[rowIndex].Cells[clmRelatedName.Name], decision.State);
            ColorRowAccordingToState(dgvRelatedDecisions.Rows[rowIndex], decision.State);
        }

        // related decision single click
        private void dgvRelatedDecisions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != clmRelatedName.Index || e.RowIndex < 0)
                return;

            var cell = dgvRelatedDecisions.Rows[e.RowIndex].Cells[clmRelatedGuid.Name] as DataGridViewTextBoxCell;
            if (cell != null)
            {
                string elementGUID = dgvRelatedDecisions[0, e.RowIndex].Value.ToString();
                // Invoke DetailHandler with request to open elementGUID
                DetailHandler.InvokeViewChange(elementGUID, EANativeType.Element);
            }
        }

        // related double click
        private void dgvRelatedDecisions_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != clmRelatedName.Index || e.RowIndex < 0)
                return;

            var cell = dgvRelatedDecisions.Rows[e.RowIndex].Cells[clmRelatedGuid.Name] as DataGridViewTextBoxCell;
            if (cell != null)
            {
                string elementGUID = dgvRelatedDecisions[0, e.RowIndex].Value.ToString();
                // Invoke DetailHandler with request to open elementGUID
                DetailHandler.InvokeViewChange(elementGUID, EANativeType.Element);
            }
        }

        private void dgvRelatedDecisions_Leave(object sender, EventArgs e)
        {
            dgvRelatedDecisions.ClearSelection();
        }

        /********************************************************************************************
         ** Traces 
         ********************************************************************************************/
        private void LoadTraces()
        {
            // Update Traces
            var traces = from IEAConnector trace in _decision.Connectors
                         where trace.Stereotype.Equals("trace")
                         select (trace.SupplierId == _decision.ID
                             ? trace.GetClient()
                             : trace.GetSupplier()
                             );
            foreach (IEAElement tracedElement in traces)
            {
                AddTraceToGrid(tracedElement.GUID,
                    tracedElement.Name,
                    tracedElement.Type
                    );
            }
        }

        private void AddTraceToGrid(string guid, string traceName, string traceType)
        {
            RemovePossibleDuplicateEntry(guid, clmTraceGuid as DataGridViewColumn, dgvTraces);
            dgvTraces.Rows.Add(new object[] { guid, traceName, traceType });
        }

        // traces single click
        private void dgvTraces_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != clmTraceName.Index || e.RowIndex < 0)
                return;

            var cell = dgvTraces.Rows[e.RowIndex].Cells[clmTraceGuid.Name] as DataGridViewTextBoxCell;
            if (cell != null)
            {
                string elementGUID = dgvTraces[0, e.RowIndex].Value.ToString();
                // Invoke DetailHandler with request to open elementGUID
                DetailHandler.InvokeViewChange(elementGUID, EANativeType.Diagram);
            }
        }

        // traces double click
        private void dgvTraces_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != clmTraceName.Index || e.RowIndex < 0)
                return;

            var cell = dgvTraces.Rows[e.RowIndex].Cells[clmTraceGuid.Name] as DataGridViewTextBoxCell;
            if (cell != null)
            {
                string elementGUID = dgvTraces[0, e.RowIndex].Value.ToString();
                // Invoke DetailHandler with request to open elementGUID
                DetailHandler.InvokeViewChange(elementGUID, EANativeType.Diagram);
            }
        }

        private void dgvTraces_Leave(object sender, EventArgs e)
        {
            dgvTraces.ClearSelection();
        }

        /********************************************************************************************
         ** Forces 
         ********************************************************************************************/
        private void LoadForces()
        {
            // Update Forces
            var forces = _decision.GetForces();
            foreach (var rating in forces)
            {
                IEAElement force = EAFacade.EA.Repository.GetElementByGUID(rating.ForceGUID);
                IEAElement concern = EAFacade.EA.Repository.GetElementByGUID(rating.ConcernGUID);

                AddRelatedForceToGrid(rating.ForceGUID,
                    force.Name,
                    rating.Value,
                    concern.Name,
                    force.Notes
                    );
            }
        }

        private void AddRelatedForceToGrid(string guid, string forceName, string forceRating, string forceConcern, string description)
        {
            RemovePossibleDuplicateEntry(guid, clmForceGuid as DataGridViewColumn, dgvForces);
            dgvForces.Rows.Add(new object[] { guid, forceName, forceConcern, forceRating, description });
        }

        // forces single click
        private void dgvForces_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != clmForcesName.Index || e.RowIndex < 0)
                return;
        }

        // forces double click
        private void dgvForces_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != clmForcesName.Index || e.RowIndex < 0)
                return;

            var cell = dgvForces.Rows[e.RowIndex].Cells[clmForceGuid.Name] as DataGridViewTextBoxCell;
            if (cell != null)
            {
                string elementGUID = dgvForces[0, e.RowIndex].Value.ToString();
                // Invoke DetailHandler with request to open elementGUID
                DetailHandler.InvokeViewChange(elementGUID, EANativeType.Diagram);
            }
        }

        private void dgvForces_Leave(object sender, EventArgs e)
        {
            dgvForces.ClearSelection();
        }

        /********************************************************************************************
         ** Stakeholders 
         ********************************************************************************************/
        private void LoadStakeholders()
        {
            // Update Stakeholder field
            foreach (var connector in _decision.Connectors.Where(connector => connector.IsAction()))
            {
                if (connector.ClientId == _decision.ID) continue;
                var stakeholder = connector.GetClient();
                AddStakeholderToGrid(stakeholder.GUID,
                    stakeholder.Name,
                    stakeholder.Stereotype,
                    connector.Stereotype,
                    _decision.State
                    );
            }
        }

        private void AddStakeholderToGrid(string guid, string stakeholderName, string stereotype, string s, string state)
        {
            RemovePossibleDuplicateEntry(guid, clmStakeholderGuid as DataGridViewColumn, dgvStakeholder);
            string stakeholderText = string.Format("{0}\n<<{1}>>", stakeholderName, stereotype);
            dgvStakeholder.Rows.Add(new object[] { guid, stakeholderText, s, state });
        }

        // stakeholder single click
        private void dgvStakeholder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != clmStakeholderName.Index || e.RowIndex < 0)
                return;
        }

        // stakeholder double click
        private void dgvStakeholder_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != clmStakeholderName.Index || e.RowIndex < 0)
                return;

            var cell = dgvStakeholder.Rows[e.RowIndex].Cells[clmStakeholderGuid.Name] as DataGridViewTextBoxCell;
            if (cell != null)
            {
                // ShowInProjectView???
                // Invoke DetailHandler with request to open elementGUID
                string elementGUID = dgvStakeholder[0, e.RowIndex].Value.ToString();
                DetailHandler.InvokeViewChange(elementGUID, EANativeType.Diagram);
            }
        }


        private void dgvStakeholder_Leave(object sender, EventArgs e)
        {
            dgvStakeholder.ClearSelection();
        }

        /********************************************************************************************
         ** History 
         ********************************************************************************************/
        public IList<DecisionStateChange> History { get; set; }

        private void LoadHistory()
        {
            // clear the current history grid
            dgvHistory.Rows.Clear();
            // Load History from decision
            History = _decision.History;
            // Enter in grid
            foreach (DecisionStateChange entry in History)
            {
                AddHistoryEntryToGrid(entry.State,
                    entry.DateModified
                    );
            }
        }

        private void SetHistoryControls()
        {
            dtpHistoryCell = new DateTimePicker();
            dtpHistoryCell.Format = DateTimePickerFormat.Custom;
            dtpHistoryCell.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern;
            dtpHistoryCell.Visible = false;
            dtpHistoryCell.Width = clmHistoryDate.Width;
            dgvHistory.Controls.Add(dtpHistoryCell);

            this.dgvHistory.CellBeginEdit += this.dgvHistory_CellBeginEdit;
            this.dgvHistory.CellEndEdit += this.dgvHistory_CellEndEdit;

            dtpHistoryCell.ValueChanged += dtpHistoryCell_ValueChanged;
        }

        private void AddHistoryEntryToGrid(string historyState, DateTime dateModfied)
        {
            RemovePossibleDuplicateEntry(dateModfied.ToString(), clmHistoryGuid as DataGridViewColumn, dgvHistory);
            dgvHistory.Rows.Add(new object[] { dateModfied, historyState, dateModfied.ToShortDateString() });

            // Color the last added cell
            int rowIndex = dgvHistory.Rows.Count - 1;
            ColorCellAccordingToState(dgvHistory.Rows[rowIndex].Cells[clmHistoryState.Name], historyState);

            // Sort is descending
            dgvHistory.Sort(dgvHistory.Columns[clmHistoryGuid.Name], System.ComponentModel.ListSortDirection.Descending);
        }

        /// <summary>
        /// Replaces the datagridview on rowindex with the state and new date
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="state"></param>
        /// <param name="modified"></param>
        private void ReplaceHistoryDataGridRow(int rowIndex, string state, DateTime modified)
        {
            var guidCell = dgvHistory.Rows[rowIndex].Cells[this.clmHistoryGuid.Name];
            var stateCell = dgvHistory.Rows[rowIndex].Cells[this.clmHistoryState.Name];
            var dateCell = dgvHistory.Rows[rowIndex].Cells[this.clmHistoryDate.Name];

            guidCell.Value = modified.ToString();
            stateCell.Value = state;
            dateCell.Value = modified.ToShortDateString();

            // Colorcel
            ColorCellAccordingToState(stateCell, state);

        }

        /// Replaces the history entry state and date by the provided new state and date.
        private void ReplaceHistoryRow(int rowIndex, string oldState, string newState, DateTime oldDate, DateTime newDate)
        {
            foreach (DecisionStateChange dsc in History)
            {
                if (dsc.State == oldState && dsc.DateModified == oldDate)
                {
                    // Update the model
                    dsc.DateModified = newDate;
                    dsc.State = newState;

                    // Update the view
                    ReplaceHistoryDataGridRow(rowIndex, newState, newDate);
                }
            }
        }

        /// <summary>
        /// Method that is middle men for the generic method.
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="state">
        /// State is both new and oldstate in the 
        /// </param>
        /// <param name="oldDate"></param>
        /// <param name="newDate"></param>
        private void ReplaceHistoryRow(int rowIndex, string state, DateTime oldDate, DateTime newDate)
        {
            ReplaceHistoryRow(rowIndex, state, state, oldDate, newDate);
        }

        /// <summary>
        /// Method that is callback for the changing of a history entry.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpHistoryCell_ValueChanged(object sender, EventArgs e)
        {
            // If the value in choosen is different that the current one change this
            if (dgvHistory.CurrentCell != null && dgvHistory.CurrentCell.Value != dtpHistoryCell.Text)
            {
                var rowIndex = dgvHistory.CurrentCell.RowIndex;
                var guidCell = dgvHistory.Rows[rowIndex].Cells[this.clmHistoryGuid.Name];
                var stateCell = dgvHistory.Rows[rowIndex].Cells[this.clmHistoryState.Name];

                string currentState = stateCell.Value.ToString();
                DateTime oldDate = Convert.ToDateTime(guidCell.Value.ToString());
                DateTime newDate = dtpHistoryCell.Value;

                // The dateTime picker doesnt choose time. So we take the old time.
                TimeSpan ts = new TimeSpan(oldDate.Hour, oldDate.Minute, oldDate.Second);
                newDate = newDate.Date + ts;

                // Replace the history Entry date
                ReplaceHistoryRow(rowIndex, currentState, oldDate, newDate);


            }

        }

        private void dgvHistory_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if ((dgvHistory.Focused) && (dgvHistory.CurrentCell.ColumnIndex == 2))
                {
                    // Place the DateTimePicker in the current cell
                    dtpHistoryCell.Location = dgvHistory.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                    dtpHistoryCell.Visible = true;
                    if (dgvHistory.CurrentCell.Value != null)
                    {
                        dtpHistoryCell.Value = Convert.ToDateTime(dgvHistory.CurrentCell.Value.ToString());
                    }
                }
                else
                {
                    dtpHistoryCell.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Je EXCEPTIE:! " + ex.Message + " is null? " + (dtpHistoryCell == null).ToString());
                System.Diagnostics.Debug.WriteLine("Je EXCEPTIE:! " + ex.Message + " is null? " + (dtpHistoryCell == null).ToString());
            }
        }

        private void dgvHistory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((dgvHistory.CurrentCell.ColumnIndex == 2))
                {
                    dgvHistory.CurrentCell.Value = dtpHistoryCell.Value.ToShortDateString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Mouse Leave Event. Clear the selection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvHistory_Leave(object sender, System.EventArgs e)
        {
            dtpHistoryCell.Visible = false;
           // dgvHistory.ClearSelection();
        }

        /********************************************************************************************
         ******************************************************************************************** 
         ** Auxillery methods
         ******************************************************************************************** 
         ********************************************************************************************/
        //// Set richtext in a RichTextBox 
        //private void setTextInTextBox(string text, RichTextBox richTextBox)
        //{
        //    if (text.Contains("\\rtf1"))
        //    {
        //        richTextBox.Rtf = GetSubstring(RichTextPanel.DataTags.RtfData, text);
        //        richTextBox.SetLinkPositions(GetSubstring(RichTextPanel.DataTags.LinkPositions, text));
        //    }
        //    else
        //    {
        //        richTextBox.Rtf = Utilities.PlaintextToRtf(text);
        //    }
        //}
        //// MC: this needs to be refactored. DUP code With decision Topic etc.
        //private string GetSubstring(string tag, string rtfString)
        //{
        //    int first = rtfString.IndexOf(tag, StringComparison.Ordinal) + tag.Length;
        //    int last = rtfString.LastIndexOf(tag, StringComparison.Ordinal);
        //    return last > first ? rtfString.Substring(first, last - first) : "";
        //}

        // Color the cell according to the State
        private void ColorCellAccordingToState(DataGridViewCell cell, string state)
        {
            cell.Style.BackColor = DecisionStateColor.ConvertStateToColor(state);
        }

        private void ColorRowAccordingToState(DataGridViewRow row, string state)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                ColorCellAccordingToState(cell, state);
            }
        }

        // Removes a possible guid from the datagrid to make sure duplicates do not happen 
        private void RemovePossibleDuplicateEntry(string targetGuid, DataGridViewColumn column, DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // If the ID's are the same Remove row.
                if (targetGuid == row.Cells[column.Name].Value as String)
                {
                    dataGridView.Rows.Remove(row);
                }
            }
        }

        /// <summary>
        /// Method to remove all the focus from the fields and buttons
        /// </summary>
        private void ClearAllFocus()
        {
            // Dont ask me why, but this is necesarry to remove all the darn focus
            dgvAlternativeDecisions_Leave(this, EventArgs.Empty);
            //dgvRelatedDecisions_Leave(this, EventArgs.Empty);
            //dgvForces_Leave(this, EventArgs.Empty);
            //dgvTraces_Leave(this, EventArgs.Empty);
            //dgvStakeholder_Leave(this, EventArgs.Empty);
            //dgvHistory_Leave(this, EventArgs.Empty);
        }

        private void spltDetailView_SplitterMoved(object sender, SplitterEventArgs e)
        {
            cbxState.Refresh();

            if (dtpHistoryCell != null)
            {
                dtpHistoryCell.Width = clmHistoryDate.Width;
            }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
        

        /********************************************************************************************
         ** TextChanged Events    
         ********************************************************************************************/
        //private bool recentlyChangedFlag;

        //public bool IsRecentlyChanged()
        //{
        //    return recentlyChangedFlag;
        //}

        //private void SetInformationChangedListeners()
        //{
        //    // Decision groupbox
        //    this.txtDecisionName.TextChanged += new EventHandler(InformationChanged);
        //    this.cbxState.TextChanged += new EventHandler(InformationChanged);
        //    this.dtDecided.ValueChanged += new EventHandler(InformationChanged);
        //    this.txtAuthor.TextChanged += new EventHandler(InformationChanged);

        //    // Rationale groupbox
        //    this.pnlRichTextBox.TextBox.TextChanged += new EventHandler(InformationChanged);

        //    // Topic groupbox
        //    this.txtTopicName.TextChanged += new EventHandler(InformationChanged);
        //    this.txtTopicDescription.TextChanged += new EventHandler(InformationChanged);
        //}

        //private void InformationChanged(object sender, EventArgs e)
        //{
        //    recentlyChangedFlag = true;
        //}






    }
}


///*
//   * Load method called to make sure everything is set properly.
//   */ 
//  private void DetailView_Load(object sender, EventArgs e)
//  {
//      System.Diagnostics.Debug.WriteLine("DetailView DetailView_Load");

//      // Same as above, if you comment this out the combobox starts off selecting the font...
//      string intialFont = this.cmboxFont.Text;
//      this.cmboxFont.Text = "";
//      this.cmboxFont.Text = intialFont;

//      //Initial space for the Current decision in the GridView.
//      this.dgvCurrentDecision.Rows.Add("ID", "Decision Name");

//      // Dont ask me why, but this is necesarry to remove all the darn focus
//      dgvCurrentDecision_Leave(this, EventArgs.Empty);
//      dgvAlternativeDecisions_Leave(this, EventArgs.Empty);

//      // Dunno if neccesarry
//      this.UpdateView();
//  }

//  public string DecisionGroup
//  {
//      get { return txtTopic.Text.Trim(' '); }
//      set { txtTopic.Text = value; }
//  }
//  //public string DecisionIssuePlainText
//  //{
//  //    get { return txtIssue.Text; }
//  //}



//private void txtIssue_LinkClicked(object sender, LinkClickedEventArgs e)
//{
//    Process.Start(e.LinkText);
//}

//private void txtDecision_LinkClicked(object sender, LinkClickedEventArgs e)
//{
//    Process.Start(e.LinkText);
//}

//private void txtArguments_LinkClicked(object sender, LinkClickedEventArgs e)
//{
//    Process.Start(e.LinkText);
//}