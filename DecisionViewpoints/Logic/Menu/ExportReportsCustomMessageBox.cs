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
            this.Text = string.Format(Messages.ReportSuccessful, reportType);
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
            Process.Start(this.filename);
            Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            var reportFolderpath = this.filename.Substring(0, filename.LastIndexOf("\\"));
            //MessageBox.Show("Report Folderpath:" + reportFolderpath);//DEBUG
            Process.Start(reportFolderpath);
            Close();
        }
    }
}
