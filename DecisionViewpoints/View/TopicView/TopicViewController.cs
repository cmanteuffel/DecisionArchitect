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

using DecisionViewpoints.Model;
using DecisionViewpoints.View.Controller;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DecisionViewpoints.View.TopicView
{
    [ComVisible(true)]
    [Guid("D65970AD-12A7-402A-9F88-ED50D8C1DD90")]
    [ProgId("DecisionViewpoints.TopicViewController")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(ITopicViewController))]
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
            setTopic(topic);
            LoadContent();
        }

        /// <summary>
        /// 
        /// </summary>
        public void LoadContent()
        {
            if (_topic != null)
            {
                // Topic
                LoadTopicGroupBox();
            }
        }

        public void Save()
        {
            _topic.Name = TopicName;
            _topic.Description = TopicDescription;
            //MessageBox.Show("Saved: " + _topic.Name);

            _topic.Save();
        }

        public void Update()
        {
           // MessageBox.Show("Updated: " + _topic.Name);
            LoadContent();
        }

        public void setTopic(ITopic topic)
        {
            _topic = topic;
            if (_topic != null)
            {
                LoadTopicGroupBox();
            }
        }

        private void TopicDetailView_Load(object sender, EventArgs e)
        {
            if (txtTopicName.Text.Length < 50)
                Text = txtTopicName.Text;
            else
                Text = txtTopicName.Text.Substring(0, 40) + " ...";
        }

        /********************************************************************************************
         ********************************************************************************************
         ** TOPIC GROUPBOX 
         ******************************************************************************************** 
         ********************************************************************************************/
        private void LoadTopicGroupBox()
        {
            TopicName = _topic.Name;
            TopicDescription = _topic.Description;
        }

        public string TopicName
        {
            get { return txtTopicName.Text.Trim(' '); }
            set { txtTopicName.Text = value; }
        }

        //public string TopicDescription
        //{
        //    get { return txtTopicDescription.Rtf.Trim(' '); }
        //    set
        //    {
        //        txtTopicDescription.Rtf = value.Contains("\\rtf1")
        //            ? value
        //            : Utilities.PlaintextToRtf(value);
        //    }
        //}

        public string TopicDescription
        {
            get
            {
                return rtbDescription.GetRichText();
            }
            set
            {
                rtbDescription.SetRichText(value);
            }
        }
    }
}
