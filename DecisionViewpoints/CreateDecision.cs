using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DecisionViewpoints.Model;

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
        }

        public String GetState()
        {
            return comboState.SelectedItem as String;
        }

        public String GetName()
        {
            return textName.Text;
        }

        private void validating(object sender, EventArgs e)
        {

            if (textName.Text.Length < 1)
            {
                errorProvider1.SetError(textName, "Name of a decision must be supplied.");
                createButton.Enabled = false;
            }
            else
            {
                errorProvider1.Clear();
                createButton.Enabled = true;
            }
        }
    }
}
