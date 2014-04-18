namespace DecisionViewpoints
{
    partial class CreateDecision
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
            this.components = new System.ComponentModel.Container();
            this.textName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelState = new System.Windows.Forms.Label();
            this.comboState = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(124, 19);
            this.textName.Margin = new System.Windows.Forms.Padding(6);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(416, 31);
            this.textName.TabIndex = 0;
            this.textName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingView);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(21, 22);
            this.labelName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(71, 26);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name";
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(21, 65);
            this.labelState.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(63, 26);
            this.labelState.TabIndex = 2;
            this.labelState.Text = "State";
            // 
            // comboState
            // 
            this.comboState.FormattingEnabled = true;
            this.comboState.Location = new System.Drawing.Point(124, 62);
            this.comboState.Margin = new System.Windows.Forms.Padding(6);
            this.comboState.Name = "comboState";
            this.comboState.Size = new System.Drawing.Size(416, 33);
            this.comboState.TabIndex = 3;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(390, 180);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(6);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(150, 44);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // createButton
            // 
            this.createButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.createButton.Location = new System.Drawing.Point(168, 180);
            this.createButton.Margin = new System.Windows.Forms.Padding(6);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(210, 44);
            this.createButton.TabIndex = 4;
            this.createButton.Text = "Create Decision";
            this.createButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Package";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(124, 107);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(416, 33);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.comboBox1_Format);
            this.comboBox1.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingView);
            // 
            // CreateDecision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 262);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.comboState);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CreateDecision";
            this.Text = "CreateDecision";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.ComboBox comboState;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}