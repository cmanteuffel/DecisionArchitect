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
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DecisionArchitect.Model.New;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.View.DetailView
{
    [ComVisible(true)]
    [Guid("D65970AD-12A7-402A-9F88-ED50D8C1DD81")]
    [ProgId("DecisionViewpoints.DetailViewController")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof (IDetailViewController))]
    public partial class DetailViewController : UserControl, IDetailViewController
    {
        private IDecision _decision;

        public DetailViewController()
        {
            InitializeComponent();
        }

        public ITopic Topic { get; set; }

        public IDecision Decision
        {
            get { return _decision; }
            set
            {
                if (value == null || value.Equals(_decision))
                {
                    txtDecisionName.DataBindings.Clear();
                    txtAuthor.DataBindings.Clear();
                    rtbRationale.DataBindings.Clear();
                    txtTopicName.DataBindings.Clear();
                    rtbTopicDescription.DataBindings.Clear();
                    dtModified.DataBindings.Clear();
                }

                _decision = value;

                if (_decision != null)
                {
                    txtDecisionName.DataBindings.Add("Text", Decision, "Name");
                    txtAuthor.DataBindings.Add("Text", Decision, "Author");
                    dtModified.DataBindings.Add("Value", Decision, "Modified");
                    cbxState.DataBindings.Add("Text", Decision, "State");
                    cbxState.BackColor = DecisionStateColor.ConvertStateToColor(Decision.State);
                    rtbRationale.DataBindings.Add("RichText", Decision, "Rationale");
                    BindAlternatives();
                    BindRelatedDecisions();
                    BindHistory();
                    BindStakeholders();
                    BindTraces();
                    BindForces();

                    if (Decision.HasTopic())
                    {
                        txtTopicName.DataBindings.Add("Text", Decision.Topic, "Name");
                        rtbTopicDescription.DataBindings.Add("RichText", Decision.Topic, "Description");
                        EnableTopicGroupBox();
                    }
                    else
                    {
                        DisableTopicGroupBox();
                    }
                }
            }
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure that you want to revert all changes?",
                                                        "Revert Changes", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Decision.DiscardChanges();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Decision != null)
            {
                //update history and other additional information.

                if (Decision.HasTopic())
                {
                    Decision.Topic.SaveChanges();
                }

                Decision.SaveChanges();
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

        private void BindAlternatives()
        {
            dgvAlternativeDecisions.AutoGenerateColumns = false;
            var source = new BindingSource(new BindingList<IDecisionRelation>(Decision.Alternatives), null);
            dgvAlternativeDecisions.DataSource = source;
        }

        private void BindRelatedDecisions()
        {
            dgvRelatedDecisions.AutoGenerateColumns = false;
            var source = new BindingSource(new BindingList<IDecisionRelation>(Decision.RelatedDecisions), null);
            dgvRelatedDecisions.DataSource = source;
        }


        private void BindForces()
        {
            dgvForces.AutoGenerateColumns = false;
            var source = new BindingSource(new BindingList<IForceEvaluation>(Decision.Forces), null);
            dgvForces.DataSource = source;
        }

        private void BindTraces()
        {
            dgvTraces.AutoGenerateColumns = false;
            var source = new BindingSource(new BindingList<ITraceLink>(Decision.Traces), null);
            dgvTraces.DataSource = source;
        }


        private void BindStakeholders()
        {
            dgvStakeholder.AutoGenerateColumns = false;
            var source = new BindingSource(new BindingList<IStakeholderAction>(Decision.Stakeholders), null);
            dgvStakeholder.DataSource = source;
        }

        private void BindHistory()
        {
            dtpHistoryCell = new DateTimePicker();
            dtpHistoryCell.Format = DateTimePickerFormat.Custom;
            dtpHistoryCell.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern;
            dtpHistoryCell.Visible = false;
            dtpHistoryCell.Width = clmHistoryDate.Width;
            dgvHistory.Controls.Add(dtpHistoryCell);
            dgvHistory.CellBeginEdit += dgvHistory_CellBeginEdit;
            dgvHistory.CellEndEdit += dgvHistory_CellEndEdit;

            foreach (string state in EAConstants.States)
            {
                clmHistoryState.Items.Add(state);
            }
            dgvHistory.CellValueChanged += dgvHistory_CellValueChanged;

            dgvHistory.AutoGenerateColumns = false;
            var decisionHistory = new BindingList<IHistoryEntry>(Decision.History);
            var source = new BindingSource(decisionHistory, null);
            dgvHistory.DataSource = source;
            foreach (DataGridViewRow row in dgvHistory.Rows)
            {
                ColorRowAccordingToState(row, row.Cells[clmHistoryState.Index].Value.ToString());
            }
        }

        private void dgvHistory_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //check if the cell that contains the state has been changed.
            if (e.ColumnIndex == clmHistoryState.Index)
            {
                DataGridViewRow row = dgvHistory.Rows[e.RowIndex];
                DataGridViewCell cell = row.Cells[clmHistoryState.Name];
                string state = cell.Value.ToString();
                ColorRowAccordingToState(row, state);
            }
        }


        private void dgvHistory_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if ((dgvHistory.Focused) && (dgvHistory.CurrentCell.ColumnIndex == 3))
            {
                // Place the DateTimePicker in the current cell
                dtpHistoryCell.Location =
                    dgvHistory.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
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

        private void dgvHistory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmHistoryDate.Index)
            {
                DataGridViewCell cell = dgvHistory.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = dtpHistoryCell.Value;
            }
        }

        /// <summary>
        ///     Change background color of state combobox to state color.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxState_SelectedValueChanged(object sender, EventArgs e)
        {
            cbxState.BackColor = DecisionStateColor.ConvertStateToColor(cbxState.Text);
        }

        /********************************************************************************************
         ******************************************************************************************** 
         ** Auxillery methods
         ******************************************************************************************** 
         ********************************************************************************************/

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

        /// <summary>
        ///     Open selected element in diagram and select in project browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView) sender;
            string guid = "";
            DataGridViewRow row = grid.Rows[e.RowIndex];

            if (row.DataBoundItem is IStakeholderAction)
            {
                var stakeholderAction = (IStakeholderAction) row.DataBoundItem;
                guid = stakeholderAction.Stakeholder.GUID;
            }
            else if (row.DataBoundItem is ITraceLink)
            {
                var link = (ITraceLink) row.DataBoundItem;
                guid = link.TracedElementGUID;
            }
            else if (row.DataBoundItem is IDecisionRelation)
            {
                var link = (IDecisionRelation)row.DataBoundItem;
                guid = link.RelatedDecision.GUID;
            }
            else
            {
                throw new NotSupportedException();
            }
            if (guid != null && !"".Equals(guid))
            {
                IEAElement element = EAMain.Repository.GetElementByGUID(guid);
                IEADiagram[] diagrams = element.GetDiagrams();
                if (diagrams.Length == 1)
                {
                    IEADiagram diagram = diagrams[0];
                    diagram.OpenAndSelectElement(element);
                }
                else if (diagrams.Length >= 2)
                {
                    var selectForm = new SelectDiagram(diagrams);
                    if (selectForm.ShowDialog() == DialogResult.OK)
                    {
                        IEADiagram diagram = selectForm.GetSelectedDiagram();
                        diagram.OpenAndSelectElement(element);
                    }
                }
                element.ShowInProjectView();
            }
        }

        /// <summary>
        ///     Fix nested property binding in datagridviews
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = (DataGridView) sender;
            if ((grid.Rows[e.RowIndex].DataBoundItem != null) &&
                (grid.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(
                    grid.Rows[e.RowIndex].DataBoundItem,
                    grid.Columns[e.ColumnIndex].DataPropertyName
                    );
            }
        }

        /// <summary>
        ///     Require for nested property binding.
        /// </summary>
        /// <param name="property"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private string BindProperty(object property, string propertyName)
        {
            string retValue = "";

            if (propertyName.Contains("."))
            {
                PropertyInfo[] arrayProperties;
                string leftPropertyName;

                leftPropertyName = propertyName.Substring(0, propertyName.IndexOf("."));
                arrayProperties = property.GetType().GetProperties();

                foreach (PropertyInfo propertyInfo in arrayProperties)
                {
                    if (propertyInfo.Name == leftPropertyName)
                    {
                        retValue = BindProperty(
                            propertyInfo.GetValue(property, null),
                            propertyName.Substring(propertyName.IndexOf(".") + 1));
                        break;
                    }
                }
            }
            else
            {
                Type propertyType;
                PropertyInfo propertyInfo;

                propertyType = property.GetType();
                propertyInfo = propertyType.GetProperty(propertyName);
                retValue = propertyInfo.GetValue(property, null).ToString();
            }

            return retValue;
        }
    }
}