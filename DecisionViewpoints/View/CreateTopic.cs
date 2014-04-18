using System;
using System.ComponentModel;
using System.Windows.Forms;
using EAFacade.Model;

namespace DecisionViewpoints
{
    public partial class CreateTopic : Form
    {
        public CreateTopic(string nameproposal)
        {
            InitializeComponent();
            txtName.Text = nameproposal;
            comboBox1.DataSource = EAFacade.EA.Repository.GetAllDecisionViewPackages();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "GUID";
            if (comboBox1.Items.Count == 0)
            {
                errorProvider1.SetError(comboBox1, Messages.ErrorSelectDecisionViewPackage);
                btnCreateTopic.Enabled = false;   
            }
        }

        public String GetName()
        {
            return txtName.Text;
        }

        public IEAPackage GetDecisionViewPackage()
        {
            return (IEAPackage)comboBox1.SelectedItem;
        }

        private void comboBox1_Format(object sender, ListControlConvertEventArgs e)
        {
            string name = ((IEAPackage)e.ListItem).Name;
            string path = ((IEAPackage)e.ListItem).GetProjectPath();
            e.Value = path + "/" + name;
        }

        private void ValidatingView(object sender, CancelEventArgs e)
        {
            bool error = false;
            if (txtName.Text.Length < 1)
            {
                errorProvider1.SetError(txtName, Messages.ErrorNoNameForDecision);
                btnCreateTopic.Enabled = false;
                error = true;
            }

            if (comboBox1.SelectedValue == null)
            {
                errorProvider1.SetError(comboBox1, Messages.ErrorSelectDecisionViewPackage);
                btnCreateTopic.Enabled = false;
                error = true;
            }

            if (!error)
            {
                errorProvider1.Clear();
                btnCreateTopic.Enabled = true;
            }
        }    

    }
}
