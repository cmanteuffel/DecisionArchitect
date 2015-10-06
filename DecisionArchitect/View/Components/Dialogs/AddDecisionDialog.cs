/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Mark Hoekstra (University of Groningen)
*/

using System;
using System.Windows.Forms;
using DecisionArchitect.View.Forces;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.View.Dialogs
{
    public class AddDecisionDialog : Form
    {
        private readonly IForcesController _controller;
        private readonly IDecisionDialogListener _listener;

        private Button _btnAddDecision;
        private Button _btnCancel;
        private bool _closeWindow; // Form will only be closed when at least one decision is added.
        private Label _lblDecision;
        private TreeView _tvDecision;

        public AddDecisionDialog(IDecisionDialogListener callbackListener)
        {
            _listener = callbackListener;
            InitializeComponent();
            var populateTreeView = new PopulateTreeView(_tvDecision, true);
            populateTreeView.Populate();
        }

        public AddDecisionDialog(IForcesController controller)
        {
            _controller = controller;
            InitializeComponent();

            var populateTreeView = new PopulateTreeView(_tvDecision, true);
            populateTreeView.Populate();
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._tvDecision = new System.Windows.Forms.TreeView();
            this._btnAddDecision = new System.Windows.Forms.Button();
            this._lblDecision = new System.Windows.Forms.Label();
            this._btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _tvDecision
            // 
            this._tvDecision.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
            this._tvDecision.HideSelection = false;
            this._tvDecision.Location = new System.Drawing.Point(15, 27);
            this._tvDecision.Name = "_tvDecision";
            this._tvDecision.Size = new System.Drawing.Size(210, 330);
            this._tvDecision.TabIndex = 0;
            this._tvDecision.NodeMouseDoubleClick +=
                new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._tvDecision_NodeMouseDoubleClick);
            // 
            // _btnAddDecision
            // 
            this._btnAddDecision.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAddDecision.AutoSize = true;
            this._btnAddDecision.Location = new System.Drawing.Point(64, 363);
            this._btnAddDecision.Name = "_btnAddDecision";
            this._btnAddDecision.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._btnAddDecision.Size = new System.Drawing.Size(80, 23);
            this._btnAddDecision.TabIndex = 1;
            this._btnAddDecision.Text = "Add Decision";
            this._btnAddDecision.UseVisualStyleBackColor = true;
            this._btnAddDecision.Click += new System.EventHandler(this._btnAddDecision_Click);
            // 
            // _lblDecision
            // 
            this._lblDecision.AutoSize = true;
            this._lblDecision.BackColor = System.Drawing.Color.Transparent;
            this._lblDecision.Location = new System.Drawing.Point(12, 9);
            this._lblDecision.Name = "_lblDecision";
            this._lblDecision.Size = new System.Drawing.Size(45, 13);
            this._lblDecision.TabIndex = 4;
            this._lblDecision.Text = "Element";
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.AutoSize = true;
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(150, 363);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(80, 23);
            this._btnCancel.TabIndex = 5;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddDecision
            // 
            this.AcceptButton = this._btnAddDecision;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(242, 395);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._lblDecision);
            this.Controls.Add(this._btnAddDecision);
            this.Controls.Add(this._tvDecision);
            this.MinimumSize = new System.Drawing.Size(258, 340);
            this.Name = "AddDecision";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Decision";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        /// <summary>
        ///     Adds the element(s) that is/are selected in the TreeView to the forces diagram
        /// </summary>
        private void AddAllDecisionsToDiagram()
        {
            TreeNode selectedNode = _tvDecision.SelectedNode;
            if (selectedNode == null) return; //nothing selected

            AddFromNode(selectedNode);

            //Window does not have to be closed and no update needed
            if (!_closeWindow) return;

            IEARepository repository = EAMain.Repository;
            _controller.SetDiagramModel(repository.GetDiagramByGuid(_controller.Model.DiagramGUID));
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        ///     Add all elements that do not contain children
        /// </summary>
        /// <param name="node"></param>
        private void AddFromNode(TreeNode node)
        {
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode n in node.Nodes) AddFromNode(n);
            }
            else
            {
                IEARepository repository = EAMain.Repository;
                IEAElement element = repository.GetElementByGUID(node.ImageKey);
                if (EAMain.IsDecision(element)) AddDecisionToDiagram(element);
            }
        }

        /// <summary>
        ///     Add deicsion to the diagram and TaggedValue to the decision if it doesn't exist already
        /// </summary>
        /// <param name="element"></param>
        private void AddDecisionToDiagram(IEAElement element)
        {
            if (_listener != null)
            {
                _listener.OnDecisionSelected(element);
                return;
            }

            IEARepository repository = EAMain.Repository;

            string diagramGuid = _controller.Model.DiagramGUID;
            IEADiagram diagram = repository.GetDiagramByGuid(diagramGuid);

            diagram.AddElement(element);

            // Only add the TaggedValue once, because the element is already a decision
            if (!element.TaggedValueExists(EATaggedValueKeys.IsDecisionElement, diagramGuid))
            {
                element.AddTaggedValue(EATaggedValueKeys.IsDecisionElement, diagramGuid);
                _closeWindow = true;
            }
            else
            {
                MessageBox.Show(string.Format(Messages.ForcesViewDecisionExists, element.Name),
                                Messages.ForcesViewDecisionExistsTitle,
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        ///     Decision(s) will be added by clicking on a button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnAddDecision_Click(object sender, EventArgs e)
        {
            AddAllDecisionsToDiagram();
        }

        /// <summary>
        ///     Decision(s) will be added by double clicking in the TreeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _tvDecision_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            AddAllDecisionsToDiagram();
        }
    }
}