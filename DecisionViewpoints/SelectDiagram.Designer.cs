namespace DecisionViewpoints
{
    partial class SelectDiagram
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
            this.openButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listDiagrams
            // 
            this.listDiagrams.FormattingEnabled = true;
            this.listDiagrams.Location = new System.Drawing.Point(3, 3);
            this.listDiagrams.Name = "listDiagrams";
            this.listDiagrams.Size = new System.Drawing.Size(278, 108);
            this.listDiagrams.TabIndex = 0;
            // 
            // openButton
            // 
            this.openButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.openButton.Location = new System.Drawing.Point(95, 117);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(105, 23);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Open Diagram";
            this.openButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(206, 117);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // SelectDiagram
            // 
            this.AcceptButton = this.openButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 144);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.listDiagrams);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectDiagram";
            this.Text = "Select Diagram";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listDiagrams;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button cancelButton;

    }
}