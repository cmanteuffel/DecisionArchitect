namespace DecisionArchitect.View.Chronology
{
    partial class GenerateChronologyView
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
            this.label1 = new System.Windows.Forms.Label();
            this.viewName = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.listSelectedDecisions = new System.Windows.Forms.ListBox();
            this.treeAllDecisions = new System.Windows.Forms.TreeView();
            this.add = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // viewName
            // 
            this.viewName.Location = new System.Drawing.Point(69, 9);
            this.viewName.Name = "viewName";
            this.viewName.Size = new System.Drawing.Size(369, 20);
            this.viewName.TabIndex = 1;
            this.viewName.TextChanged += new System.EventHandler(this.viewName_TextChanged);
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Enabled = false;
            this.okButton.Location = new System.Drawing.Point(282, 327);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "Generate";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(363, 327);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // listSelectedDecisions
            // 
            this.listSelectedDecisions.FormattingEnabled = true;
            this.listSelectedDecisions.Location = new System.Drawing.Point(270, 60);
            this.listSelectedDecisions.Name = "listSelectedDecisions";
            this.listSelectedDecisions.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listSelectedDecisions.Size = new System.Drawing.Size(168, 251);
            this.listSelectedDecisions.TabIndex = 6;
            // 
            // treeAllDecisions
            // 
            this.treeAllDecisions.Location = new System.Drawing.Point(15, 60);
            this.treeAllDecisions.Name = "treeAllDecisions";
            this.treeAllDecisions.Size = new System.Drawing.Size(168, 251);
            this.treeAllDecisions.TabIndex = 7;
            this.treeAllDecisions.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeAllDecisions_AfterSelect);
            // 
            // add
            // 
            this.add.Enabled = false;
            this.add.Location = new System.Drawing.Point(189, 159);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 8;
            this.add.Text = "->";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // remove
            // 
            this.remove.Enabled = false;
            this.remove.Location = new System.Drawing.Point(189, 188);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(75, 23);
            this.remove.TabIndex = 9;
            this.remove.Text = "<-";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Available Decisions";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Selected Decisions";
            // 
            // GenerateChronologyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 361);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.add);
            this.Controls.Add(this.treeAllDecisions);
            this.Controls.Add(this.listSelectedDecisions);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.viewName);
            this.Controls.Add(this.label1);
            this.Name = "GenerateChronologyView";
            this.Text = "Generate Chronology View";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox viewName;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ListBox listSelectedDecisions;
        private System.Windows.Forms.TreeView treeAllDecisions;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}