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

using DecisionViewpoints.View.Controller;
using System;
using System.Windows.Forms;

namespace DecisionViewpoints.View
{
    public partial class TopicDetailView : Form, ITopicDetailView
    {
        private ITopicDetailController _controller; 

        public TopicDetailView()
        {
            InitializeComponent();
        }

        public string TopicName { 
        get {return  txtName.Text.Trim(' ');}
        set {txtName.Text = value;} 
        }

        public string TopicDescription {
            get { return txtDescription.Text.Trim(' '); }
            set { txtDescription.Text = value; }
        }

        private void TopicDetailView_Load(object sender, EventArgs e)
        {
            if (txtName.Text.Length < 50)
                Text = txtName.Text;
            else
                Text = txtName.Text.Substring(0, 40) + " ...";
        }

        public void ShowAsDialog()
        {
            ShowDialog();
        }

        public void SetController(ITopicDetailController controller)
        {
            _controller = controller;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _controller.Save();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        
    }
}