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
using System.Windows.Forms;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.View.Dialogs
{
    public partial class CreateTopicDialog : Form
    {
        public CreateTopicDialog(string nameproposal)
        {
            InitializeComponent();
            txtName.Text = nameproposal;
            comboBox1.DataSource = EAMain.Repository.GetAllPackages();
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
            return (IEAPackage) comboBox1.SelectedItem;
        }

        private void comboBox1_Format(object sender, ListControlConvertEventArgs e)
        {
            string name = ((IEAPackage) e.ListItem).Name;
            string path = ((IEAPackage) e.ListItem).GetProjectPath();
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