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

namespace DecisionArchitect.View.Dialogs
{
    partial class SelectDiagramDialog
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
            this.listDiagrams = new System.Windows.Forms.ListBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listDiagrams
            // 
            this.listDiagrams.FormattingEnabled = true;
            this.listDiagrams.ItemHeight = 25;
            this.listDiagrams.Location = new System.Drawing.Point(13, 13);
            this.listDiagrams.Name = "listDiagrams";
            this.listDiagrams.Size = new System.Drawing.Size(401, 129);
            this.listDiagrams.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(309, 148);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(105, 46);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // openButton
            // 
            this.openButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.openButton.Location = new System.Drawing.Point(119, 148);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(184, 46);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Open Diagram";
            this.openButton.UseVisualStyleBackColor = true;
            // 
            // SelectDiagram
            // 
            this.AcceptButton = this.openButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(425, 206);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.listDiagrams);
            this.Name = "SelectDiagram";
            this.ShowIcon = false;
            this.Text = "Select Diagram";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listDiagrams;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button openButton;
    }
}
