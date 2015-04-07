/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    Marc Holterman (University of Groningen)
*/

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DecisionArchitect.Model;

namespace DecisionArchitect.View
{
    [ComVisible(true)]
    public interface ITopicViewController
    {
        ITopic Topic { get; set; }
    }

    [ComVisible(true)]
    [Guid("D65970AD-12A7-402A-9F88-ED50D8C1DD90")]
    [ProgId("DecisionViewpoints.TopicViewController")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof (ITopicViewController))]
    public partial class TopicViewController : UserControl, ITopicViewController
    {
        // Model
        private ITopic _topic;

        public TopicViewController()
        {
            InitializeComponent();
        }

        public TopicViewController(ITopic topic)
            : this()
        {
            Topic = topic;
        }


        public string TopicName
        {
            get { return txtTopicName.Text.Trim(' '); }
            set { txtTopicName.Text = value; }
        }

        public string TopicDescription
        {
            get { return rtbDescription.RichText; }
            set { rtbDescription.RichText = value; }
        }

        public ITopic Topic
        {
            get { return _topic; }
            set
            {
                if (value == null || value.Equals(_topic))
                {
                    txtTopicName.DataBindings.Clear();
                    rtbDescription.DataBindings.Clear();
                    btnSave.DataBindings.Clear();
                    btnRevert.DataBindings.Clear();
                }

                _topic = value;
                if (_topic != null)
                {
                    txtTopicName.DataBindings.Add("Text", Topic, "Name");
                    rtbDescription.DataBindings.Add("RichText", Topic, "Description");
                    btnSave.DataBindings.Add("Enabled", Topic, "Changed");
                    btnRevert.DataBindings.Add("Enabled", Topic, "Changed");
                }
            }
        }

        public void Save()
        {
            _topic.SaveChanges();
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(Messages.WarningRevertChanges,
                                                        Messages.WarningRevertChangesTitle, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Topic.DiscardChanges();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Topic.SaveChanges();
        }
    }
}