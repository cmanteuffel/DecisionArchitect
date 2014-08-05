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

using DecisionArchitect.View.RichTextBox;

namespace DecisionArchitect.View.TopicView
{
    partial class TopicViewController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTopicName = new System.Windows.Forms.TextBox();
            this.lblTopicName = new System.Windows.Forms.Label();
            this.gpbTopicInformation = new System.Windows.Forms.GroupBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.rtbDescription = new CustomRichTextBox();
            this.gpbTopicInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTopicName
            // 
            this.txtTopicName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTopicName.Location = new System.Drawing.Point(76, 19);
            this.txtTopicName.Name = "txtTopicName";
            this.txtTopicName.Size = new System.Drawing.Size(351, 20);
            this.txtTopicName.TabIndex = 113;
            // 
            // lblTopicName
            // 
            this.lblTopicName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTopicName.AutoSize = true;
            this.lblTopicName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTopicName.Location = new System.Drawing.Point(32, 22);
            this.lblTopicName.Name = "lblTopicName";
            this.lblTopicName.Size = new System.Drawing.Size(38, 13);
            this.lblTopicName.TabIndex = 112;
            this.lblTopicName.Text = "Name:";
            // 
            // gpbTopicInformation
            // 
            this.gpbTopicInformation.BackColor = System.Drawing.Color.Transparent;
            this.gpbTopicInformation.Controls.Add(this.rtbDescription);
            this.gpbTopicInformation.Controls.Add(this.lblDescription);
            this.gpbTopicInformation.Controls.Add(this.lblTopicName);
            this.gpbTopicInformation.Controls.Add(this.txtTopicName);
            this.gpbTopicInformation.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpbTopicInformation.Location = new System.Drawing.Point(0, 0);
            this.gpbTopicInformation.Name = "gpbTopicInformation";
            this.gpbTopicInformation.Size = new System.Drawing.Size(440, 247);
            this.gpbTopicInformation.TabIndex = 124;
            this.gpbTopicInformation.TabStop = false;
            this.gpbTopicInformation.Text = "Topic";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDescription.Location = new System.Drawing.Point(7, 47);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 120;
            this.lblDescription.Text = "Description:";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDescription.Location = new System.Drawing.Point(3, 63);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(431, 184);
            this.rtbDescription.TabIndex = 121;
            // 
            // TopicViewController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpbTopicInformation);
            this.Name = "TopicViewController";
            this.Size = new System.Drawing.Size(440, 269);
            this.Load += new System.EventHandler(this.TopicDetailView_Load);
            this.gpbTopicInformation.ResumeLayout(false);
            this.gpbTopicInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTopicName;
        private System.Windows.Forms.Label lblTopicName;
        private System.Windows.Forms.GroupBox gpbTopicInformation;
        private System.Windows.Forms.Label lblDescription;
        private CustomRichTextBox rtbDescription;


    }
}
