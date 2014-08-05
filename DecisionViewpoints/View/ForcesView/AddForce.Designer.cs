/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Mark Hoekstra (University of Groningen)
*/

namespace DecisionViewpoints.View.Forces
{
    partial class AddForce
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
            this._lbConcern = new System.Windows.Forms.ListBox();
            this._lblConcern = new System.Windows.Forms.Label();
            this._tvForce = new System.Windows.Forms.TreeView();
            this._lblForce = new System.Windows.Forms.Label();
            this._btnAddForce = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _lbConcern
            // 
            this._lbConcern.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lbConcern.FormattingEnabled = true;
            this._lbConcern.IntegralHeight = false;
            this._lbConcern.Location = new System.Drawing.Point(200, 19);
            this._lbConcern.Name = "_lbConcern";
            this._lbConcern.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this._lbConcern.Size = new System.Drawing.Size(192, 295);
            this._lbConcern.TabIndex = 4;
            this._lbConcern.SelectedIndexChanged += new System.EventHandler(this._lbConcern_SelectedIndexChanged);
            // 
            // _lblConcern
            // 
            this._lblConcern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblConcern.AutoSize = true;
            this._lblConcern.BackColor = System.Drawing.Color.Transparent;
            this._lblConcern.Location = new System.Drawing.Point(200, 3);
            this._lblConcern.Name = "_lblConcern";
            this._lblConcern.Size = new System.Drawing.Size(47, 13);
            this._lblConcern.TabIndex = 6;
            this._lblConcern.Text = "Concern";
            // 
            // _tvForce
            // 
            this._tvForce.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tvForce.FullRowSelect = true;
            this._tvForce.HideSelection = false;
            this._tvForce.Location = new System.Drawing.Point(3, 19);
            this._tvForce.Name = "_tvForce";
            this._tvForce.Size = new System.Drawing.Size(191, 295);
            this._tvForce.TabIndex = 7;
            this._tvForce.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this._tvForce_AfterSelect);
            this._tvForce.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._tvForce_NodeMouseDoubleClick);
            // 
            // _lblForce
            // 
            this._lblForce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblForce.AutoSize = true;
            this._lblForce.BackColor = System.Drawing.Color.Transparent;
            this._lblForce.Location = new System.Drawing.Point(3, 3);
            this._lblForce.Name = "_lblForce";
            this._lblForce.Size = new System.Drawing.Size(34, 13);
            this._lblForce.TabIndex = 8;
            this._lblForce.Text = "Force";
            // 
            // _btnAddForce
            // 
            this._btnAddForce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAddForce.Enabled = false;
            this._btnAddForce.Location = new System.Drawing.Point(251, 335);
            this._btnAddForce.Name = "_btnAddForce";
            this._btnAddForce.Size = new System.Drawing.Size(75, 23);
            this._btnAddForce.TabIndex = 9;
            this._btnAddForce.Text = "Add Force";
            this._btnAddForce.UseVisualStyleBackColor = true;
            this._btnAddForce.Click += new System.EventHandler(this._btnAddForce_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(332, 335);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 10;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this._lblForce, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._tvForce, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._lbConcern, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this._lblConcern, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.362776F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.63722F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(395, 317);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // AddForce
            // 
            this.AcceptButton = this._btnAddForce;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(419, 370);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnAddForce);
            this.MinimumSize = new System.Drawing.Size(435, 300);
            this.Name = "AddForce";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Force";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox _lbConcern;
        private System.Windows.Forms.Label _lblConcern;
        private System.Windows.Forms.Label _lblForce;
        private System.Windows.Forms.Button _btnAddForce;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView _tvForce;
    }
}