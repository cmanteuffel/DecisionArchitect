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
using DecisionArchitect.Logic.EventHandler;
using DecisionArchitect.Model;
using DecisionArchitect.Utilities;
using DecisionArchitect.View.Controller;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.View.DetailView
{
    internal interface IDetailViewController
    {
        IDecision Decision { get; set; }
    }

    [ComVisible(true)]
    [Guid("D65970AD-12A7-402A-9F88-ED50D8C1DD81")]
    [ProgId("DecisionViewpoints.DetailViewController")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof (IDetailViewController))]
    public partial class DetailViewController : UserControl, IDetailViewController
    {
        private const double SelectionLuminosityFactor = .65;
        private const double SelectionSaturationFactor = .55;
        private IDecision _decision;
        private string _orginalDecisionName = "";

        public DetailViewController()
        {
            InitializeComponent();
            this.Disposed += Cleanup;
        }

        private void Cleanup(object sender, EventArgs e)
        {
            UnbindAllComponents();
            Decision = null;
        }

        public ITopic Topic { get; set; }

        public IDecision Decision
        {
            get { return _decision; }
            set
            {
                if (value == null || value.Equals(_decision))
                {
                    UnbindAllComponents();
                }

                _decision = value;

                if (_decision != null)
                {
                    btnSave.DataBindings.Add("Enabled", Decision, "Changed");
                    btnRevert.DataBindings.Add("Enabled", Decision, "Changed");
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

                    _orginalDecisionName = Decision.Name;
                }
            }
        }

        

        private void UnbindAllComponents()
        {
            btnSave.DataBindings.Clear();
            btnRevert.DataBindings.Clear();
            txtDecisionName.DataBindings.Clear();
            txtAuthor.DataBindings.Clear();
            rtbRationale.DataBindings.Clear();
            txtTopicName.DataBindings.Clear();
            rtbTopicDescription.DataBindings.Clear();
            dtModified.DataBindings.Clear();
            dgvAlternativeDecisions.DataBindings.Clear();
            dgvForces.DataBindings.Clear();
            dgvRelatedDecisions.DataBindings.Clear();
            dgvStakeholder.DataBindings.Clear();
            dgvHistory.DataBindings.Clear();
            dgvTraces.DataBindings.Clear();
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(Messages.WarningRevertChanges,
                                                        Messages.WarningRevertChangesTitle,
                                                        MessageBoxButtons.YesNo);
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

                string newDecisionName = Decision.Name;
                Decision.SaveChanges();
                if (!_orginalDecisionName.Equals(newDecisionName))
                {
                    DialogResult result = MessageBox.Show(Messages.WarningReloadDetailView, Messages.WarningReloadDetailViewTitle,
                                                          MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DetailViewHandler.Instance.ReloadDecisionDetailView(Decision);
                    }
                }
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
            var source = new BindingSource(Decision.Alternatives, null);
            dgvAlternativeDecisions.DataSource = source;
        }

        private void BindRelatedDecisions()
        {
            dgvRelatedDecisions.AutoGenerateColumns = false;
            var source = new BindingSource(Decision.RelatedDecisions, null);
            dgvRelatedDecisions.DataSource = source;
        }


        private void BindForces()
        {
            dgvForces.AutoGenerateColumns = false;
            var source = new BindingSource(Decision.Forces, null);
            dgvForces.DataSource = source;
        }

        private void BindTraces()
        {
            dgvTraces.AutoGenerateColumns = false;
            var source = new BindingSource(Decision.Traces, null);
            dgvTraces.DataSource = source;
        }


        private void BindStakeholders()
        {
            dgvStakeholder.AutoGenerateColumns = false;
            var source = new BindingSource(Decision.Stakeholders, null);
            dgvStakeholder.DataSource = source;
        }

        private void BindHistory()
        {
            dtpHistoryCell = new DateTimePicker
                {
                    Format = DateTimePickerFormat.Custom,
                    CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern,
                    Visible = false,
                    Width = clmHistoryDate.Width
                };
            dgvHistory.Controls.Add(dtpHistoryCell);
            dgvHistory.CellBeginEdit += dgvHistory_CellBeginEdit;
            dgvHistory.CellEndEdit += dgvHistory_CellEndEdit;

            foreach (string state in EAConstants.States)
            {
                clmHistoryState.Items.Add(state);
            }

            dgvHistory.AutoGenerateColumns = false;
            var source = new BindingSource(Decision.History, null);
            dgvHistory.DataSource = source;
            dgvHistory.Sort(clmHistoryState, ListSortDirection.Descending);
        }


        private void dgvHistory_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if ((dgvHistory.Focused) && (dgvHistory.CurrentCell.ColumnIndex == clmHistoryDate.Index))
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


        /// <summary>
        ///     Fix nested property binding in datagridviews
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColoringAndNestingBinding(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = (DataGridView) sender;
            DataGridViewRow row = grid.Rows[e.RowIndex];
            if ((row.DataBoundItem != null) &&
                (grid.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(
                    row.DataBoundItem,
                    grid.Columns[e.ColumnIndex].DataPropertyName
                    );
            }


            //coloring
            if (grid == dgvHistory)
            {
                var historyEntry = (IHistoryEntry) row.DataBoundItem;
                if (historyEntry != null)
                {
                    ColorRowAccordingToState(row, historyEntry.State);
                }
            }
            else if (grid == dgvAlternativeDecisions || grid == dgvRelatedDecisions)
            {
                var decisionRelation = (IDecisionRelation) row.DataBoundItem;
                if (decisionRelation != null)
                    ColorRowAccordingToState(row, decisionRelation.RelatedDecision.State);
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
            string guid;
            DataGridViewRow row = grid.Rows[e.RowIndex];

            // ReSharper disable CanBeReplacedWithTryCastAndCheckForNull
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
                var link = (IDecisionRelation) row.DataBoundItem;
                guid = link.RelatedDecision.GUID;
            }
            else
            {
                throw new NotSupportedException();
            }
            // ReSharper restore CanBeReplacedWithTryCastAndCheckForNull
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

        /********************************************************************************************
         ******************************************************************************************** 
         ** Auxillery methods
         ******************************************************************************************** 
         ********************************************************************************************/

        // Color the cell according to the State
        private void ColorCellAccordingToState(DataGridViewCell cell, string state)
        {
            cell.Style.BackColor = DecisionStateColor.ConvertStateToColor(state);
            HSLColor hsl = DecisionStateColor.ConvertStateToColor(state);
            hsl.Luminosity = (hsl.Luminosity*SelectionLuminosityFactor);
            hsl.Saturation = (hsl.Saturation*SelectionSaturationFactor);
            cell.Style.SelectionBackColor = hsl;
        }

        private void ColorRowAccordingToState(DataGridViewRow row, string state)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                ColorCellAccordingToState(cell, state);
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
                string leftPropertyName = propertyName.Substring(0, propertyName.IndexOf(".", StringComparison.Ordinal));
                PropertyInfo[] arrayProperties = property.GetType().GetProperties();

                foreach (PropertyInfo propertyInfo in arrayProperties)
                {
                    if (propertyInfo.Name == leftPropertyName)
                    {
                        retValue = BindProperty(
                            propertyInfo.GetValue(property, null),
                            propertyName.Substring(propertyName.IndexOf(".", StringComparison.Ordinal) + 1));
                        break;
                    }
                }
            }
            else
            {
                Type propertyType = property.GetType();
                PropertyInfo propertyInfo = propertyType.GetProperty(propertyName);
                retValue = propertyInfo.GetValue(property, null).ToString();
            }

            return retValue;
        }

        private void HistoryMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                var historyEntry = (IHistoryEntry) dgvHistory.Rows[e.RowIndex].DataBoundItem;

                var menu = new ContextMenu();

                // Menuitem for opening a decision in its diagram
                menu.MenuItems.Add("Delete", (o, arg) => Decision.History.Remove(historyEntry));

                // Menuitem for a separator
                menu.MenuItems.Add("-");
                menu.Show(this, PointToClient(Cursor.Position));
            }
        }
    }
}