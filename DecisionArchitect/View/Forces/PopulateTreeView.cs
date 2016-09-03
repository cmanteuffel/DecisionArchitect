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

namespace DecisionArchitect.View.Forces
{
    public class PopulateTreeView
    {
        private readonly bool _decision; //Specifies whether decisions or all elements should be added
        private readonly TreeView _tv;

        public PopulateTreeView(TreeView tv, bool decision)
        {
            _tv = tv;
            _decision = decision;
        }

        /// <summary>
        ///     Populates the treeview with the elements from the repository
        /// </summary>
        public void Populate()
        {
            IEARepository repository = EAMain.Repository;
            foreach (IEAPackage package in repository.GetAllRootPackages())
            {
                //Skip history package
                if (package.Stereotype.Equals(EAConstants.ChronologicalStereoType)) continue;
                TreeNode node = AddPackageNode(new TreeNode(), package);
                if (null != node)
                {
                    node.Expand();
                    _tv.Nodes.Add(node);
                }
            }
            if (_decision) _tv.ExpandAll();
        }

        /// <summary>
        ///     Adds a package and its children to the node
        /// </summary>
        /// <param name="node">Node to be added to</param>
        /// <param name="package">Package to be added</param>
        /// <returns>A node with the package information and its children</returns>
        private TreeNode AddPackageNode(TreeNode node, IEAPackage package)
        {
            node.ImageKey = package.GUID;
            node.Text = package.Name;

            foreach (IEAPackage subPackage in package.Packages)
            {
                //Skip history package and packages without elements
                if (subPackage.Stereotype.Equals(EAConstants.ChronologicalStereoType) ||
                    !subPackage.GetAllElementsOfSubTree().Any()) continue;
                TreeNode subPackageNode = AddPackageNode(new TreeNode(), subPackage);
                if (null != subPackageNode)
                {
                    node.Nodes.Add(subPackageNode);
                }
            }

            int count = 0;
            foreach (IEAElement element in package.Elements)
            {
                if (element.Name.Equals("") || EAMain.IsHistoryDecision(element)) continue;
                if (_decision && (!EAMain.IsDecision(element) && !EAMain.IsTopic(element))) continue;
                node.Nodes.Add(AddElementToNode(new TreeNode(), element));
                ++count;
            }
            if (node.GetNodeCount(true) == 0)
            {
                return null;
            }
            return node;
        }

        /// <summary>
        ///     Adds an element and its children to the node
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
                if (el.Name.Equals("") || EAMain.IsHistoryDecision(el)) continue;
                if (_decision && (!EAMain.IsDecision(el) && !EAMain.IsTopic(el)))
                {
                    continue;
                }
                node.Nodes.Add((AddElementToNode(new TreeNode(), el)));
            }
            return node;
        }
    }
}