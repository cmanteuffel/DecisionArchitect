using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecisionViewpoints.Logic.Menu
{
    public partial class ExportReportsCustomMessageBox : Form
    {
        private string filename;
        public ExportReportsCustomMessageBox()
        {
            InitializeComponent();
        }
        public ExportReportsCustomMessageBox(string reportType, string filename)
        {
            InitializeComponent();
            this.Text = reportType + " report was generated succesfully!";
            this.filename = filename;
            this.labelReportDetails.Text = filename.Substring(filename.LastIndexOf("\\")+1);
            this.labelReportFolderDetails.Text = filename.Substring(0, filename.LastIndexOf("\\"));
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;   //remove Maximize Button
            this.MinimizeBox = false;   //remove Minimize Button
        }

        private void ExportReportsCustomMessageBox_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonOpenReport_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this.filename);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            var reportFolderpath = this.filename.Substring(0, this.filename.LastIndexOf("\\"));
            //MessageBox.Show("Report Folderpath:" + reportFolderpath);//DEBUG
            Process.Start(reportFolderpath);
        }
    }
}
