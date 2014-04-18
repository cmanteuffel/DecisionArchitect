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
            comboState.DataSource = DVStereotypes.States.ToList();
            comboState.SelectedItem = DVStereotypes.StateDecided;
            textName.Text = nameProposal;
            comboBox1.DataSource = EARepository.Instance.GetAllDecisionViewPackages();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "GUID";
            if (comboBox1.Items.Count == 0)
            {
                errorProvider1.SetError(comboBox1, Messages.ErrorSelectDecisionViewPackage);
                createButton.Enabled = false;
            }
        }

        public EAPackage GetDecisionViewPackage()
        {
            return (EAPackage)comboBox1.SelectedItem;
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
            string name = ((EAPackage)e.ListItem).Name;
            string path = ((EAPackage)e.ListItem).GetProjectPath();
            e.Value = path + "/" + name;
        }
    }
}
