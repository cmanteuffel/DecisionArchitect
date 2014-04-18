using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using EAFacade.Model;

namespace DecisionViewpoints
{
    public partial class CreateDecision : Form
    {
        public CreateDecision(string nameProposal)
        {
            InitializeComponent();
            comboState.DataSource = EAConstants.States.ToList();
            comboState.SelectedItem = EAConstants.StateDecided;
            textName.Text = nameProposal;
            comboBox1.DataSource = EAFacade.EA.Repository.GetAllDecisionViewPackages();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "GUID";
            if (comboBox1.Items.Count == 0)
            {
                errorProvider1.SetError(comboBox1, Messages.ErrorSelectDecisionViewPackage);
                createButton.Enabled = false;
            }
        }

        public IEAPackage GetDecisionViewPackage()
        {
            return (IEAPackage)comboBox1.SelectedItem;
        }

        public String GetState()
        {
            return comboState.SelectedItem as String;
        }

        public String GetName()
        {
            return textName.Text;
        }

      
        private void ValidatingView(object sender, CancelEventArgs e)
        {
            bool error = false;
            if (textName.Text.Length < 1)
            {
                errorProvider1.SetError(textName, Messages.ErrorNoNameForDecision);
                createButton.Enabled = false;
                error = true;
            }

            if (comboBox1.SelectedValue == null)
            {
                errorProvider1.SetError(comboBox1, Messages.ErrorSelectDecisionViewPackage);
                createButton.Enabled = false;
                error = true;
            }

            if (!error)
            {
                errorProvider1.Clear();
                createButton.Enabled = true;
            }
        }

        private void comboBox1_Format(object sender, ListControlConvertEventArgs e)
        {
            string name = ((IEAPackage)e.ListItem).Name;
            string path = ((IEAPackage)e.ListItem).GetProjectPath();
            e.Value = path + "/" + name;
        }
    }
}
