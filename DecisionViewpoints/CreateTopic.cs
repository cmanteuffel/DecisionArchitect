using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecisionViewpoints
{
    public partial class CreateTopic : Form
    {
        public CreateTopic(string nameproposal)
        {
            InitializeComponent();
            txtName.Text = nameproposal;
        }

        public String GetName()
        {
            return txtName.Text;
        }

        private void validating(object sender, EventArgs e)
        {

            if (txtName.Text.Length < 1)
            {
                errorProvider1.SetError(txtName, "Name of a topic must be supplied.");
                btnCreateTopic.Enabled = false;
            }
            else
            {
                errorProvider1.Clear();
                btnCreateTopic.Enabled = true;
            }
        }

    }
}
