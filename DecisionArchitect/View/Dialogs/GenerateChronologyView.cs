using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.View.Dialogs
{
    public partial class GenerateChronologyView : Form
    {
        public List<IEAElement> Decisions = new List<IEAElement>();

        public GenerateChronologyView()
        {
            InitializeComponent();
            PopulateTreeView();
            listSelectedDecisions.DisplayMember = "Name";
            listSelectedDecisions.ValueMember = "GUID";
        }

        public string ViewName { get; set; }

        private void PopulateTreeView()
        {
            foreach (IEAPackage rootPackage in EAMain.Repository.GetAllRootPackages())
            {
                var rootNode = new TreeNode(Name = rootPackage.Name) {ImageKey = rootPackage.GUID};
                IEnumerable<TreeNode> nodes = rootPackage.Packages.Select(CreateTreeNode).Where(n => n != null);
                foreach (TreeNode node in nodes)
                {
                    rootNode.Nodes.Add(node);
                }
                rootNode.ExpandAll();
                treeAllDecisions.Nodes.Add(rootNode);
            }
        }

        private TreeNode CreateTreeNode(IEAPackage package)
        {
            TreeNode packageNode = null;
            IEnumerable<TreeNode> decisions =
                package.Elements.Where(e => EAMain.IsDecision(e) && !EAMain.IsHistoryDecision(e))
                       .Select(e => new TreeNode(Name = e.Name) {ImageKey = e.GUID});
            IEnumerable<TreeNode> subpackages = package.Packages.Select(CreateTreeNode).Where(node => node != null);
            IOrderedEnumerable<TreeNode> subtree = decisions.Union(subpackages).OrderBy(node => node.Name);
            if (subtree.Any())
            {
                packageNode = new TreeNode(package.Name, subtree.ToArray()) {ImageKey = package.GUID};
            }
            return packageNode;
        }

        private void add_Click(object sender, EventArgs e)
        {
            TreeNode node = treeAllDecisions.SelectedNode;
            string guid = node.ImageKey;
            switch (EAUtilities.IdentifyGUIDType(guid))
            {
                case EANativeType.Package:
                case EANativeType.Model:
                    IEAPackage package = EAMain.Repository.GetPackageByGUID(guid);
                    foreach (IEAElement d in package.GetAllDecisions())
                    {
                        if (!Decisions.Contains(d))
                        {
                            Decisions.Add(d);
                            listSelectedDecisions.Items.Add(d);
                            node.Checked = true;
                        }
                    }

                    break;
                case EANativeType.Element:
                    IEAElement decision = EAMain.Repository.GetElementByGUID(guid);
                    if (!Decisions.Contains(decision))
                    {
                        Decisions.Add(decision);
                        listSelectedDecisions.Items.Add(decision);
                        node.Checked = true;
                    }
                    break;
            }
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            okButton.Enabled = (Decisions.Count > 0 && viewName.Text.Length > 0);
            remove.Enabled = (Decisions.Count > 0);
        }

        private void remove_Click(object sender, EventArgs e)
        {
            var list = new object[listSelectedDecisions.SelectedItems.Count];
            listSelectedDecisions.SelectedItems.CopyTo(list, 0);
            foreach (object item in list)
            {
                var decision = (IEAElement) item;
                listSelectedDecisions.Items.Remove(item);
                Decisions.Remove(decision);
            }
            UpdateButtonStates();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
        }

        private void treeAllDecisions_AfterSelect(object sender, TreeViewEventArgs e)
        {
            add.Enabled = true;
        }

        private void viewName_TextChanged(object sender, EventArgs e)
        {
            ViewName = viewName.Text;
            UpdateButtonStates();
        }
    }
}