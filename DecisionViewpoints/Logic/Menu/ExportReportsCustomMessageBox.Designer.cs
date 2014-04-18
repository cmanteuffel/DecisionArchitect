namespace DecisionViewpoints.Logic.Menu
{
    partial class ExportReportsCustomMessageBox
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
            this.buttonOpenReport = new System.Windows.Forms.Button();
            this.buttonOpenFolder = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelReportDetails = new System.Windows.Forms.Label();
            this.labelReportFolderDetails = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOpenReport
            // 
            this.buttonOpenReport.Location = new System.Drawing.Point(24, 58);
            this.buttonOpenReport.Name = "buttonOpenReport";
            this.buttonOpenReport.Size = new System.Drawing.Size(106, 23);
            this.buttonOpenReport.TabIndex = 1;
            this.buttonOpenReport.Text = "Open report file";
            this.buttonOpenReport.UseVisualStyleBackColor = true;
            this.buttonOpenReport.Click += new System.EventHandler(this.buttonOpenReport_Click);
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.Location = new System.Drawing.Point(136, 57);
            this.buttonOpenFolder.Name = "buttonOpenFolder";
            this.buttonOpenFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenFolder.TabIndex = 2;
            this.buttonOpenFolder.Text = "Open Folder";
            this.buttonOpenFolder.UseVisualStyleBackColor = true;
            this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(303, 58);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelReportDetails
            // 
            this.labelReportDetails.AutoSize = true;
            this.labelReportDetails.Location = new System.Drawing.Point(21, 9);
            this.labelReportDetails.Name = "labelReportDetails";
            this.labelReportDetails.Size = new System.Drawing.Size(35, 13);
            this.labelReportDetails.TabIndex = 4;
            this.labelReportDetails.Text = "label1";
            // 
            // labelReportFolderDetails
            // 
            this.labelReportFolderDetails.AutoSize = true;
            this.labelReportFolderDetails.Location = new System.Drawing.Point(21, 31);
            this.labelReportFolderDetails.Name = "labelReportFolderDetails";
            this.labelReportFolderDetails.Size = new System.Drawing.Size(35, 13);
            this.labelReportFolderDetails.TabIndex = 5;
            this.labelReportFolderDetails.Text = "label2";
            // 
            // ExportReportsCustomMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 102);
            this.Controls.Add(this.labelReportFolderDetails);
            this.Controls.Add(this.labelReportDetails);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonOpenFolder);
            this.Controls.Add(this.buttonOpenReport);
            this.Name = "ExportReportsCustomMessageBox";
            this.Text = "ExportReportsCustomMessageBox";
            this.Load += new System.EventHandler(this.ExportReportsCustomMessageBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenReport;
        private System.Windows.Forms.Button buttonOpenFolder;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelReportDetails;
        private System.Windows.Forms.Label labelReportFolderDetails;

    }
}