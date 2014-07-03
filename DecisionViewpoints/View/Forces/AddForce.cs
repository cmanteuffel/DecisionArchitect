/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Mark Hoekstra (University of Groningen)
*/

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DecisionViewpoints.View.Controller;
using EAFacade;
using EAFacade.Model;

namespace DecisionViewpoints.View.Forces
{
    public partial class AddForce: Form
    {

        private readonly IForcesController _controller;
        private bool _closeWindow; // Form will only be closed when at least one force is added.

        public AddForce(IForcesController controller)
        {
            _controller = controller;
            InitializeComponent();

            var addElement = new AddElement(_tvForce, false);
            addElement.PopulateTreeView();

            PopulateConcerns();
        }

        /// <summary>
        /// Populates the listbox with the concerns from the repository
        /// </summary>
        private void PopulateConcerns()
        {
            IEARepository repository = EAFacade.EA.Repository;

            var concerns =
                repository.GetAllElements()
                    .Where(element => element != null && element.IsConcern())
                    .ToDictionary(element => element.GUID, element => element.Name+ " (" + element.ParentPackage.Name + ")");
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
        /// Adds the elements that are selected in the TreeView and ListBox
        /// </summary>
        public void AddElements()
        {
            TreeNode selectedNode = _tvForce.SelectedNode;
            // Cannot add force if no force or concern is selected
            if (selectedNode == null || _lbConcern.SelectedItems.Count < 1) return;

            IEARepository repository = EAFacade.EA.Repository;
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
        /// Add a new force for each concern if the combination not exists already
        /// </summary>
        /// <param name="force"></param>
        private void AddForceConcerns(IEAElement force)
        {
            IEARepository repository = EAFacade.EA.Repository;
            string diagramGuid = _controller.Model.DiagramGUID;
            IEADiagram diagram = repository.GetDiagramByGuid(diagramGuid);

            //Add the force for each selected concern
            foreach (var item in _lbConcern.SelectedItems)
            {
                var selectedItem = (KeyValuePair<string, string>)item;
                IEAElement concern = repository.GetElementByGUID(selectedItem.Key);

                diagram.AddElement(concern);

                IEAConnector connector = force.ConnectTo(concern, EAConstants.ForcesConnectorType, EAConstants.RelationClassifiedBy);
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
                        "Force already exists", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        /// Forces can be added by clicking on a button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnAddForce_Click(object sender, System.EventArgs e)
        {
            AddElements();
        }

        /// <summary>
        /// Forces can be added by double clicking in the TreeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _tvForce_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            AddElements();
        }
        
        /// <summary>
        /// The selection in the ListBox for the concerns has changed. 
        /// Now check if the button AddForce can be enabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _lbConcern_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            _btnAddForce.Enabled = ButtonEnabled();
        }

        /// <summary>
        /// The selection in the TreeView for the forces has changed. 
        /// Now check if the button AddForce can be enabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _tvForce_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _btnAddForce.Enabled = ButtonEnabled();
        }

        /// <summary>
        /// Checks whether the _btnAddForce should be enabled or disabled
        /// </summary>
        /// <returns></returns>
        private bool ButtonEnabled()
        {
            return _tvForce.SelectedNode != null && _lbConcern.SelectedIndex >= 0;
        }
    }
}
