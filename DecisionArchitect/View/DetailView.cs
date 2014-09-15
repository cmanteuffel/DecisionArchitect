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
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DecisionArchitect.Logic.EventHandler;
using DecisionArchitect.Model;
using DecisionArchitect.Utilities;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.View
{
    internal interface IDetailView
    {
        IDecision Decision { get; set; }
    }

    [ComVisible(true)]
    [Guid("D65970AD-12A7-402A-9F88-ED50D8C1DD81")]
    [ProgId("DecisionViewpoints.DetailView")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof (IDetailView))]
    public partial class DetailView : UserControl, IDetailView
    {
        private const double SelectionLuminosityFactor = .65;
        private const double SelectionSaturationFactor = .55;
        private IDecision _decision;
        private string _orginalDecisionName = "";

        public DetailView()
        {
            InitializeComponent();
            Disposed += Cleanup;
            SynchronizationManager.Instance.ModelChanged += OnModelChanged;
        }

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
                        //http://stackoverflow.com/questions/8894103/does-data-binding-support-nested-properties-in-windows-forms
                        var bindingSourceFix = new BindingSource(Decision, null);
                        txtTopicName.DataBindings.Add("Text", bindingSourceFix, "Topic.Name");
                        rtbTopicDescription.DataBindings.Add("RichText", bindingSourceFix, "Topic.Description");
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

        private void Cleanup(object sender, EventArgs e)
        {
            UnbindAllComponents();
            Decision = null;
            SynchronizationManager.Instance.ModelChanged -= OnModelChanged;
        }

        private void OnModelChanged(object sender, ModelChangedEventArgs args)
        {
            if (Decision==null) return;
            string changedElement = args.GUID;
            
            if (args.Type == ModelChangedType.RemovedElement)
            {
               if (changedElement.Equals(Decision.GUID))
                    {
                        DetailViewHandler.Instance.CloseDecisionDetailView(Decision);
                        return;
                    }
                    if (Decision.Topic != null && changedElement.Equals(Decision.Topic.GUID))
                    {
                        //topic has been removed.
                        txtTopicName.DataBindings.Clear();
                        rtbTopicDescription.DataBindings.Clear();
                        txtTopicName.Name = "";
                        rtbTopicDescription.RichText = "";
                        DisableTopicGroupBox();
                        return;
                    }
            }
            if (args.Type == ModelChangedType.ModifiedElement) {
                if (Decision.HasTopic() && changedElement.Equals(Decision.Topic.GUID) )
                {
                    Decision.Topic.DiscardChanges(); 
                }
            }
            if (args.Type == ModelChangedType.RemovedConnector)
            {
                var connector = EAMain.Repository.GetConnectorByGUID(args.GUID);
                if (EAConstants.Relationships.Contains(connector.Stereotype))
                {
                    foreach (var related in Decision.RelatedDecisions.ToArray())
                    {
                        if (related.RelationGUID.Equals(changedElement))
                        {
                            Decision.RelatedDecisions.Remove(related);
                            return;
                        }
                    }
                    foreach (var related in Decision.Alternatives.ToArray())
                    {
                        if (related.RelationGUID.Equals(changedElement))
                        {
                            Decision.Alternatives.Remove(related);
                            return;
                        }
                    }
                }
            }
            if (args.Type == ModelChangedType.NewConnector)
            {
                
                var connector = EAMain.Repository.GetConnectorByGUID(args.GUID);
                if (!EAConstants.Relationships.Contains(connector.Stereotype)) return;
                if (connector.ClientId != Decision.ID && connector.SupplierId != Decision.ID) return;
                
                var related = new DecisionRelation(Decision, connector);
                if (connector.Stereotype.Equals(EAConstants.RelationAlternativeFor))
                {
                    Decision.Alternatives.Add(related);
                }
                else
                {
                    Decision.RelatedDecisions.Add(related);
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
                    DialogResult result = MessageBox.Show(Messages.WarningReloadDetailView,
                                                          Messages.WarningReloadDetailViewTitle,
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
                    CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern + " " + Application.CurrentCulture.DateTimeFormat.ShortTimePattern,
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
            try
            {
                if ((row.DataBoundItem != null) &&
                    (grid.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
                {
                    e.Value = BindProperty(
                        row.DataBoundItem,
                        grid.Columns[e.ColumnIndex].DataPropertyName
                        );
                }
            }
            catch (IndexOutOfRangeException)
            {
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
                try
                {
                    var decisionRelation = (IDecisionRelation) row.DataBoundItem;
                    if (decisionRelation != null)
                        ColorRowAccordingToState(row, decisionRelation.RelatedDecision.State);
                }
                catch (IndexOutOfRangeException)
                {
                }
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
            string guid = null;
            DataGridViewRow row = grid.Rows[e.RowIndex];

            // ReSharper disable CanBeReplacedWithTryCastAndCheckForNull
            if (row.DataBoundItem is IDecisionRelation)
            {
                var link = (IDecisionRelation) row.DataBoundItem;
                DetailViewHandler.Instance.OpenDecisionDetailView(link.RelatedDecision);
            }
            else
            {
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

                if (guid != null && !"".Equals(guid))
                {
                    IEAElement element = EAMain.Repository.GetElementByGUID(guid);
                    element.ShowInDiagrams();
                }
            }
            // ReSharper restore CanBeReplacedWithTryCastAndCheckForNull
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

        private void AlternativesAndRelatedDecisionMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                var grid = (DataGridView) sender;
                var decisionRelation = (IDecisionRelation) grid.Rows[e.RowIndex].DataBoundItem;

                var menu = new ContextMenu();

                // Menuitem for opening a decision in its diagram
                menu.MenuItems.Add("Open in Detail View",
                                   (o, arg) =>
                                   DetailViewHandler.Instance.OpenDecisionDetailView(decisionRelation.RelatedDecision));
                menu.MenuItems.Add("Open in Diagrams",
                                   (o, arg) =>
                                   EAMain.Repository.GetElementByGUID(decisionRelation.RelatedDecision.GUID)
                                         .ShowInDiagrams());
                menu.MenuItems.Add("-");
                if (sender == dgvAlternativeDecisions)
                {
                    menu.MenuItems.Add("Delete", (o, arg) => Decision.Alternatives.Remove(decisionRelation));
                }
                else
                {
                    menu.MenuItems.Add("Delete", (o, arg) => Decision.RelatedDecisions.Remove(decisionRelation));
                }

                // Menuitem for a separator
                menu.Show(this, PointToClient(Cursor.Position));
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
    }
}