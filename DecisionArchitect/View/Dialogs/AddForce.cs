/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Mark Hoekstra (University of Groningen)
    Christian Manteuffel (")
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DecisionArchitect.View.Forces;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.View.Dialogs
{
    public partial class AddForce : Form
    {
        private readonly IForcesController _controller;
        private bool _closeWindow; // Form will only be closed when at least one force is added.

        public AddForce(IForcesController controller)
        {
            _controller = controller;
            InitializeComponent();

            var populateTreeView = new PopulateTreeView(_tvForce, false);
            populateTreeView.Populate();

            PopulateConcerns();
        }

        /// <summary>
        ///     Populates the listbox with the concerns from the repository
        /// </summary>
        private void PopulateConcerns()
        {
            IEARepository repository = EAMain.Repository;

            Dictionary<string, string> concerns =
                repository.GetAllElements()
                          .Where(element => element != null && EAMain.IsConcern(element))
                          .ToDictionary(element => element.GUID,
                                        element => element.Name + " (" + element.ParentPackage.Name + ")");
            if (concerns.Count <= 0) //No concerns found
            {
                _btnAddForce.Enabled = false;
                return;
            }
            _lbConcern.DataSource = new BindingSource(concerns, null);
            _lbConcern.DisplayMember = "Value";
            _lbConcern.ValueMember = "Key";
        }

        /// <summary>
        ///     Adds the forces and concerns that are selected in the TreeView and ListBox to the forces diagram
        /// </summary>
        private void AddForceToForcesDiagram()
        {
            TreeNode selectedNode = _tvForce.SelectedNode;
            // Cannot add force if no force or concern is selected
            if (selectedNode == null || _lbConcern.SelectedItems.Count < 1) return;

            IEARepository repository = EAMain.Repository;
            string diagramGuid = _controller.Model.DiagramGUID;
            IEADiagram diagram = repository.GetDiagramByGuid(diagramGuid);

            IEAElement force = repository.GetElementByGUID(selectedNode.ImageKey);
//            if (force.Type.Equals("Package")) return; // User cannot add packages as a force
            diagram.AddElement(force); //Will not be added if already exists

            AddForceConcerns(force);

            //Window does not have to be closed and no update needed
            if (!_closeWindow) return;

            _controller.SetDiagramModel(repository.GetDiagramByGuid(_controller.Model.DiagramGUID));
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        ///     Add a new force for each concern if the combination not exists already
        /// </summary>
        /// <param name="force"></param>
        private void AddForceConcerns(IEAElement force)
        {
            IEARepository repository = EAMain.Repository;
            string diagramGuid = _controller.Model.DiagramGUID;
            IEADiagram diagram = repository.GetDiagramByGuid(diagramGuid);

            //Add the force for each selected concern
            foreach (object item in _lbConcern.SelectedItems)
            {
                var selectedItem = (KeyValuePair<string, string>) item;
                IEAElement concern = repository.GetElementByGUID(selectedItem.Key);

                diagram.AddElement(concern);

                IEAConnector connector = force.ConnectTo(concern, EAConstants.ForcesConnectorType,
                                                         EAConstants.RelationClassifiedBy);
                if (!connector.TaggedValueExists(EATaggedValueKeys.IsForceConnector, diagramGuid))
                {
                    // Add TaggedValue for new force and concern (having multiple TaggedValues of the same name/data is possible). 
                    // The amount of TaggedValues with the same name and data is the amount of forces/concerns in the table.
                    force.AddTaggedValue(EATaggedValueKeys.IsForceElement, diagramGuid);
                    concern.AddTaggedValue(EATaggedValueKeys.IsConcernElement, diagramGuid);

                    // Add the diagramGuid as a TaggedValue (ConnectorTag) to the connector
                    connector.AddTaggedValue(EATaggedValueKeys.IsForceConnector, diagramGuid);
                    _closeWindow = true;
                }
                else //Force concern combination (connector) already exists
                {
                    MessageBox.Show(string.Format(Messages.ForcesViewForceExists, force.Name, concern.Name),
                                    Messages.ForcesViewForceExistsWindowTitle, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        ///     Forces can be added by clicking on a button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnAddForce_Click(object sender, EventArgs e)
        {
            AddForceToForcesDiagram();
        }

        /// <summary>
        ///     Forces can be added by double clicking in the TreeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _tvForce_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            AddForceToForcesDiagram();
        }

        /// <summary>
        ///     The selection in the ListBox for the concerns has changed.
        ///     Now check if the button AddForce can be enabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _lbConcern_SelectedIndexChanged(object sender, EventArgs e)
        {
            _btnAddForce.Enabled = ButtonEnabled();
        }

        /// <summary>
        ///     The selection in the TreeView for the forces has changed.
        ///     Now check if the button AddForce can be enabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _tvForce_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _btnAddForce.Enabled = ButtonEnabled();
        }

        /// <summary>
        ///     Checks whether the _btnAddForce should be enabled or disabled
        ///     Cannot add force if no force or concern is selected or if selected element is a model or package
        /// </summary>
        /// <returns></returns>
        private bool ButtonEnabled()
        {
            TreeNode selectedNode = _tvForce.SelectedNode;
            if (selectedNode == null || _lbConcern.SelectedItems.Count < 1) return false;

            EANativeType type = EAUtilities.IdentifyGUIDType(selectedNode.ImageKey);
            if (type == EANativeType.Model || type == EANativeType.Package)
            {
                return false;
            }

            return true;
        }
    }
}