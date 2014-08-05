﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecisionViewpoints
{
    public partial class HyperLinkWindow : Form
    {
        public string Address
        {
            get { return txtAddress.Text.Trim(' '); }
        }

        public string TargetName
        {
            get { return txtTargetName.Text.Trim(' '); }
        }

        public HyperLinkWindow()
            : this("")
        { }

        public HyperLinkWindow(string targetName)
        {
            InitializeComponent();
            txtTargetName.Text = targetName;
        }

        private void HyperLinkWindow_Load(object sender, EventArgs e)
        {
            //cmboxType.Text = "Web Site";
            this.ActiveControl = txtAddress;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            // _controller.Save();
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        //private void cmboxType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ComboBox comboBox = (ComboBox)sender;

        //    string fileType = (string)comboBox.SelectedItem;

        //    if (fileType == "File")
        //    {
        //        btnMore.Visible = true;
        //    }
        //    else // fileType == "Web Site";
        //    {
        //        btnMore.Visible = false;
        //    }
        //}

        private void btnMore_Click(object sender, EventArgs e)
        {
            OpenFileDialog browseFile = new OpenFileDialog();
            //browseFile.Filter = "XML Files (*.xml)|*.xml";
            //browseFile.Title = "Browse XML file";
            if (browseFile.ShowDialog() == DialogResult.Cancel)
                return;

            try
            {
                txtAddress.Text = browseFile.FileName;
                MessageBox.Show("" + browseFile.FileName + " | " + txtAddress.Text);

            }
            catch (Exception)
            {
                MessageBox.Show("Error opening file", "File Error",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /**
          * Method to extract the content of the field and past it into the textbox at cursor location
          */
        //public string GetHyperLinkAddress()
        //{
        //    if (this.SelectedType == "File" && File.Exists(txtAddress.Text))
        //    {
        //        return "file://" + txtAddress.Text;
        //    }
        //    return txtAddress.Text;
        //}

        private void txtAddress_keyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            KeyEventArgs ke = e as KeyEventArgs;
            if (ke != null && ke.KeyCode == Keys.Return)
            {
                this.btnOK.PerformClick();
            }
            if (ke != null && ke.KeyCode == Keys.Escape)
            {
                this.btnCancel.PerformClick();
            }
        }
    }
}
