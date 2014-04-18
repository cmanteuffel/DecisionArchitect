using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DecisionViewpointsCustomViews.Controller;
using DecisionViewpointsCustomViews.Model;
namespace DecisionViewpointsCustomViews.View

{
    public partial class DetailViewNew : Form, IDetailView
    {
        private IDetailViewController _controller;

        public DetailViewNew()
        {
            InitializeComponent();
        }

        public void Update(IDecision model)
        {
            throw new NotImplementedException();
        }

        public string DecisionName
        {
            get { return txtName.Text.Trim(' '); }
            set { txtName.Text = value; }
        }

        public string DecisionState
        {
            get { return cbxState.Text.Trim(' '); }
            set { cbxState.Text = value; }
        }

        public string DecisionIssue
        {
            // original
           get { return txtIssue.Text.Trim(' '); }
           set { txtIssue.Text = value; }
             
           // get { return txtIssue.Rtf.Trim(' '); }//angor
          //  set{txtIssue.Rtf = value;}
        }
        
        public string DecisionText
        {   
            // original
            get { return txtDecision.Text.Trim(' '); }
            set { txtDecision.Text = value; }
             
        //    get { return txtDecision.Rtf.Trim(' '); }//angor
        //    set{txtDecision.Rtf = value;}//angor
        }
         

        public string DecisionAlternatives { get; set; }
        /*
        public string DecisionAlternatives
        {
            get { return txtAlternatives.Text.Trim(' '); }
            set { txtAlternatives.Text = value; }
        }
         */

        public string DecisionArguments
        {
            // original
            get { return txtArguments.Text.Trim(' '); }
            set { txtArguments.Text = value; }
             
         //   get { return txtArguments.Rtf.Trim(' '); }
          //  set { txtArguments.Rtf = value; }
        }

         

        public string DecisionRelatedRequirements { get; set; }
        /*
        public string DecisionRelatedRequirements
        {
            get { return txtRelatedRequirements.Text.Trim(' '); }
            set { txtRelatedRequirements.Text = value; }
        }
         */

        public void ShowAsDialog()
        {
            ShowDialog();
        }

        public void SetController(IDetailViewController controller)
        {
            _controller = controller;
        }

        public void AddRelatedDecision(string relationship, string name, bool isClient)
        {
            dgvRelatedDecisions.Rows.Add(isClient 
                ? new object[] { "<<this>> " + txtName.Text, relationship, name } 
                : new object[] { name, relationship, "<<this>> " + txtName.Text });
        }

        public void AddHistoryEntry(string name, string stereotype, string s, string state)
        {
            var stakeholderText = string.Format("{0}\n<<{1}>>", name, stereotype);
            dgvHistory.Rows.Add(new object[] { stakeholderText, s, state });
        }

        public void AddAlternativeDecision(string relationship, string name, bool isClient)
        {
            dgvAlternatives.Rows.Add(isClient 
                ? new object[] { "<<this>> " + txtName.Text, name } 
                : new object[] { name, "<<this>> " + txtName.Text });
        }

        public void AddTrace(string name, string type)
        {
            dgvTraces.Rows.Add(new object[] {name, type});
        }

        public void AddRelatedRequirement(string name, string rating, string description)
        {
            dgvRelatedRequirements.Rows.Add(new object[] { name, "", "", description });
        }


        /* original
        public void rtf_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
         */

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DetailViewNew_Load(object sender, EventArgs e)
        {
            if (txtName.Text.Length < 50)
                Text = txtName.Text + " (" + cbxState.Text + ")";
            else
                Text = txtName.Text.Substring(0,40) + "... (" + cbxState.Text + ")";
            
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            _controller.Save();
            Close();
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            if (tbCnrtlModifiable.SelectedTab == ProblemTab)
            {
                
                txtIssue.SelectionFont = txtIssue.SelectionFont.Bold 
                    ? new Font(txtIssue.SelectionFont, FontStyle.Regular) 
                    : new Font(txtIssue.SelectionFont, FontStyle.Bold);
                 
            }
            else if (tbCnrtlModifiable.SelectedTab == DescriptionTab)
            {
                txtDecision.SelectionFont = txtDecision.SelectionFont.Bold
                    ? new Font(txtDecision.SelectionFont, FontStyle.Regular)
                    : new Font(txtDecision.SelectionFont, FontStyle.Bold);
            }
            else if (tbCnrtlModifiable.SelectedTab == ArgumentsTab)
            {
                txtArguments.SelectionFont = txtArguments.SelectionFont.Bold
                    ? new Font(txtArguments.SelectionFont, FontStyle.Regular)
                    : new Font(txtArguments.SelectionFont, FontStyle.Bold);
            }
        }

        private void btnItalics_Click(object sender, EventArgs e)
        {
            if (tbCnrtlModifiable.SelectedTab == ProblemTab)
            {
                txtIssue.SelectionFont = txtIssue.SelectionFont.Italic
                    ? new Font(txtIssue.SelectionFont, FontStyle.Regular)
                    : new Font(txtIssue.SelectionFont, FontStyle.Italic);
            }
            else if (tbCnrtlModifiable.SelectedTab == DescriptionTab)
            {
                txtDecision.SelectionFont = txtDecision.SelectionFont.Italic
                    ? new Font(txtDecision.SelectionFont, FontStyle.Regular)
                    : new Font(txtDecision.SelectionFont, FontStyle.Italic);
            }
            else if (tbCnrtlModifiable.SelectedTab == ArgumentsTab)
            {
                txtArguments.SelectionFont = txtArguments.SelectionFont.Italic
                    ? new Font(txtArguments.SelectionFont, FontStyle.Regular)
                    : new Font(txtArguments.SelectionFont, FontStyle.Italic);
            }
        }
    }
}


/*
* angor ->  TO DO
*  hyperlink button functionality
*/