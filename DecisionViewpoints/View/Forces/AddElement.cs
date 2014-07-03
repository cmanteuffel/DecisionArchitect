/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Mark Hoekstra (University of Groningen)
*/

using System.Linq;
using System.Windows.Forms;
using EAFacade;
using EAFacade.Model;

namespace DecisionViewpoints.View.Forces
{
    public class AddElement
    {
        private readonly TreeView _tv;
        private readonly bool _decision; //Specifies whether decisions or all elements should be added

        public AddElement(TreeView tv, bool decision)
        {
            _tv = tv;
            _decision = decision;
        }

        /// <summary>
        /// Populates the treeview with the elements from the repository
        /// </summary>
        public void PopulateTreeView()
        {
            IEARepository repository = EAFacade.EA.Repository;
            foreach (IEAPackage package in repository.GetAllDecisionViewPackages())
            {
                //Skip history package
                if (package.Stereotype.Equals(EAConstants.ChronologicalStereoType)) continue;
                TreeNode node = AddPackageNode(new TreeNode(), package);
                node.Expand();
                _tv.Nodes.Add(node);

            }
            if(_decision) _tv.ExpandAll();
        }

        /// <summary>
        /// Adds a package and its children to the node
        /// </summary>
        /// <param name="node">Node to be added to</param>
        /// <param name="package">Package to be added</param>
        /// <returns>A node with the package information and its children</returns>
        private TreeNode AddPackageNode(TreeNode node, IEAPackage package)
        {
            node.ImageKey = package.GUID;
            node.Text = package.Name;

            foreach (IEAPackage el in package.Packages)
            {
                //Skip history package and packages without elements
                if (el.Stereotype.Equals(EAConstants.ChronologicalStereoType) || !el.GetAllElementsOfSubTree().Any()) continue;
                node.Nodes.Add(AddPackageNode(new TreeNode(), el));
            }

            foreach (IEAElement el in package.Elements)
            {
                if (el.Name.Equals("") || el.IsHistoryDecision()) continue;
                if (_decision && (!el.IsDecision() && !el.IsTopic())) continue;

                node.Nodes.Add(AddElementToNode(new TreeNode(), el));
            }
            return node;
        }

        /// <summary>
        /// Adds an element and its children to the node
        /// </summary>
        /// <param name="node">Node to be added to</param>
        /// <param name="element"></param>
        /// <returns>A node with element information and its children</returns>
        private TreeNode AddElementToNode(TreeNode node, IEAElement element)
        {
            node.ImageKey = element.GUID;
            node.Text = element.Name;

            foreach (IEAElement el in element.GetElements())
            {
                if (el.Name.Equals("") || el.IsHistoryDecision()) continue;
                if (_decision && (!el.IsDecision() && !el.IsTopic())) {continue;}
                node.Nodes.Add((AddElementToNode(new TreeNode(), el)));
            }
            return node;
        }
    }
}
