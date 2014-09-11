/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
*/

using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DecisionArchitect.Utilities;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.View
{
    public partial class CreateDecision : Form
    {
        public CreateDecision(string nameProposal)
        {
            InitializeComponent();
            comboState.DataSource = EAConstants.States.ToList();
            comboState.SelectedItem = EAConstants.StateDecided;
            comboState.BackColor = DecisionStateColor.ConvertStateToColor(EAConstants.StateDecided);
            textName.Text = nameProposal;
            comboBox1.DataSource = EAMain.Repository.GetAllPackages();
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
            return (IEAPackage) comboBox1.SelectedItem;
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
            string name = ((IEAPackage) e.ListItem).Name;
            string path = ((IEAPackage) e.ListItem).GetProjectPath();
            e.Value = path + "/" + name;
        }

        private void comboState_SelectedValueChanged(object sender, EventArgs e)
        {
            comboState.BackColor = DecisionStateColor.ConvertStateToColor(GetState());
        }
    }
}