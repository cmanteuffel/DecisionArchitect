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
    public partial class SelectForceDiagram : Form
    {


        public delegate void ForceSelectedHandler(object sender, ForceSelectEventArgs e);

        public event ForceSelectedHandler OnForceSelected;

        public SelectForceDiagram()
        {
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
            var selectedNode = _tvForce.SelectedNode;
            // Cannot add force if no force or concern is selected
            if (selectedNode == null || _lbConcern.SelectedItems.Count < 1) return;

            var repository = EAMain.Repository;
            var force = repository.GetElementByGUID(selectedNode.ImageKey);
            AddForceConcerns(force);

            //Window does not have to be closed and no update needed
            //if (!_closeWindow) return;

            Close();
        }

        /// <summary>
        ///     Add a new force for each concern if the combination not exists already
        /// </summary>
        /// <param name="force"></param>
        private void AddForceConcerns(IEAElement force)
        {
            var repository = EAMain.Repository;

            //Add the force for each selected concern
            foreach (var item in _lbConcern.SelectedItems)
            {
                var selectedItem = (KeyValuePair<string, string>) item;
                var concern = repository.GetElementByGUID(selectedItem.Key);

                if (OnForceSelected == null) return;
                OnForceSelected(this, new ForceSelectEventArgs(force, concern));
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

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public class ForceSelectEventArgs : EventArgs
    {
        public IEAElement ForceElement { get; private set; }
        public IEAElement ConcernElement { get; private set; }

        public ForceSelectEventArgs(IEAElement forceElement, IEAElement concernElement)
        {
            ForceElement = forceElement;
            ConcernElement = concernElement;
        }
    }
}