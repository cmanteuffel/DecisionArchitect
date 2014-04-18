using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DecisionViewpoints.Model;
using DecisionViewpoints.View.Controller;
using EAFacade;
using EAFacade.Model;

namespace DecisionViewpoints.View

{
    public partial class DetailView : Form, IDetailView
    {
        private IDetailViewController _controller;
        private bool _hasTopic;

        public DetailView()
        {
            InitializeComponent();
        }

        public string DecisionGroup
        {
            get { return txtGroup.Text.Trim(' '); }
            set { txtGroup.Text = value; }
        }

        public string DecisionIssuePlainText
        {
            get { return txtIssue.Text; }
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
            get { return txtIssue.Text.Trim(' '); }
            set { txtIssue.Text = value; }

            //Get-Set for formatted Test.
            //Non-formatted text is first converted to Rtf format
            /*
            get { return txtIssue.Rtf.Trim(' '); }
            set
            {
                txtIssue.Rtf = value.Contains("\\rtf1")
                    ? value
                    : PlaintextToRtf(value);
            }
             */
        }

        public string DecisionText
        {
            get { return txtDecision.Text.Trim(' '); }
            set { txtDecision.Text = value; }

            //Get-Set for formatted Text. 
            //Non-formatted text is first converted to Rtf format
            /*
            get { return txtDecision.Rtf.Trim(' '); }
            set
            {
                txtDecision.Rtf = value.Contains("\\rtf1")
                    ? value
                    : PlaintextToRtf(value);
            }
             */
        }

        public string DecisionArguments
        {
            get { return txtArguments.Text.Trim(' '); }
            set { txtArguments.Text = value; }

            //Get-Set for formatted Test. 
            //Non-formatted text is first converted to Rtf format
            /*
            get { return txtArguments.Rtf.Trim(' '); }
            set
            {
                txtArguments.Rtf = value.Contains("\\rtf1")
                    ? value
                    : PlaintextToRtf(value);
            }
             */
        }

        public string DecisionRelatedRequirements { get; set; }


        public string DecisionAlternatives { get; set; }


        public void ShowAsDialog()
        {
            ShowDialog();
        }

        public void SetController(IDetailViewController controller)
        {
            _controller = controller;
        }

        public void AddRelatedDecision(string relationship, string name, bool isClient, string decisionuid,
                                       string relateduid)
        {
            dgvRelatedDecisions.Rows.Add(isClient
                                             ? new object[]
                                                 {
                                                     relateduid, "<<this>> " + txtName.Text, relationship, name,
                                                     decisionuid
                                                 }
                                             : new object[]
                                                 {
                                                     decisionuid, name, relationship, "<<this>> " + txtName.Text,
                                                     relateduid
                                                 });
        }

        public void AddStakeholderEntry(string name, string stereotype, string s, string state, string stakeholderuid)
        {
            string stakeholderText = string.Format("{0}\n<<{1}>>", name, stereotype);
            dgvStakeholder.Rows.Add(new object[] {stakeholderuid, stakeholderText, s, state});
        }

        public void AddHistoryEntry(string state, DateTime dateModfied)
        {
            dvgHistory.Rows.Add(new object[] {state, dateModfied.ToString(CultureInfo.CurrentUICulture)});
        }

        public void AddAlternativeDecision(string relationship, string name, bool isClient, string decisionUid,
                                           string alternativeuid)
        {
            dgvAlternatives.Rows.Add(isClient
                                         ? new object[] {decisionUid, "<<this>> " + txtName.Text, alternativeuid, name}
                                         : new object[] {alternativeuid, name, decisionUid, "<<this>> " + txtName.Text});
        }

        public void AddTrace(string name, string type, string uid)
        {
            dgvTraces.Rows.Add(new object[] {uid, name, type});
        }

        public void AddRelatedRequirement(string name, string rating, string description, string uid, string concern)
        {
            dgvRelatedRequirements.Rows.Add(new object[] {uid, name, concern, rating, description});
        }

        public void AddTopic(string name, string description, bool hasTopic)
        {
            _hasTopic = hasTopic;
            txtGroup.Text = name;
            txtTopicDescription.Text = description;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DetailViewNew_Load(object sender, EventArgs e)
        {
            if (txtName.Text.Length < 50)
                Text = txtName.Text + " (" + cbxState.Text + ")";
            else
                Text = txtName.Text.Substring(0, 40) + "... (" + cbxState.Text + ")";

            if (!_hasTopic)
            {
                lblTopicName.Visible = false;
                txtGroup.Visible = false;
                lblTopicDescription.Visible = false;
                txtTopicDescription.Visible = false;
            }
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

        private void btnunderline_Click(object sender, EventArgs e)
        {
            if (tbCnrtlModifiable.SelectedTab == ProblemTab)
            {
                txtIssue.SelectionFont = txtIssue.SelectionFont.Underline
                                             ? new Font(txtIssue.SelectionFont, FontStyle.Regular)
                                             : new Font(txtIssue.SelectionFont, FontStyle.Underline);
            }
            else if (tbCnrtlModifiable.SelectedTab == DescriptionTab)
            {
                txtDecision.SelectionFont = txtDecision.SelectionFont.Underline
                                                ? new Font(txtDecision.SelectionFont, FontStyle.Regular)
                                                : new Font(txtDecision.SelectionFont, FontStyle.Underline);
            }
            else if (tbCnrtlModifiable.SelectedTab == ArgumentsTab)
            {
                txtArguments.SelectionFont = txtArguments.SelectionFont.Underline
                                                 ? new Font(txtArguments.SelectionFont, FontStyle.Regular)
                                                 : new Font(txtArguments.SelectionFont, FontStyle.Underline);
            }
        }

        /* Tranfors unformatted text to RTF.
         * This method is usable with the format buttons of the DetailView (current hidden)
         */

        public static String PlaintextToRtf(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return "";

            string escapedPlainText = plainText.Replace(@"\", @"\\").Replace("{", @"\{").Replace("}", @"\}");
            string rtf = @"{\rtf1\ansi\ansicpg1253\deff0\deflang1032{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}
                            {\f1\fnil\fcharset161 Microsoft Sans Serif;}}\viewkind4\uc1\pard\lang1033\f0\fs17 ";
            rtf += escapedPlainText.Replace(Environment.NewLine, "\\lang1032\\f1\\par");
            rtf += " }";
            return rtf;
        }

        private void txtIssue_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void txtDecision_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start("IExplore.exe", e.LinkText);
        }

        private void txtArguments_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start("IExplore.exe", e.LinkText);
        }

        private void showDiagramsForEAElement(string elementGUID)
        {
            EAElement element = EARepository.Instance.GetElementByGUID(elementGUID);
            EADiagram[] diagrams = element.GetDiagrams();
            if (diagrams.Count() == 1)
            {
                EADiagram diagram = diagrams[0];
                diagram.OpenAndSelectElement(element);
            }
            else if (diagrams.Count() >= 2)
            {
                var selectForm = new SelectDiagram(diagrams);
                if (selectForm.ShowDialog() == DialogResult.OK)
                {
                    EADiagram diagram = selectForm.GetSelectedDiagram();
                    diagram.OpenAndSelectElement(element);
                }
            }
            element.ShowInProjectView();
        }

        private void dgvAlternatives_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1 && e.ColumnIndex != 3)
                return;
            if (e.ColumnIndex == 1)
            {
                string elementGUID = dgvAlternatives[0, e.RowIndex].Value.ToString();
                showDiagramsForEAElement(elementGUID);
            }
            else if (e.ColumnIndex == 3)
            {
                string elementGUID = dgvAlternatives[2, e.RowIndex].Value.ToString();
                showDiagramsForEAElement(elementGUID);
            }
        }

        private void dgvRelatedDecisions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1 && e.ColumnIndex != 3) return;
            if (e.ColumnIndex == 1)
            {
                string elementGUID = dgvRelatedDecisions[0, e.RowIndex].Value.ToString();
                showDiagramsForEAElement(elementGUID);
            }
            else if (e.ColumnIndex == 3)
            {
                string elementGUID = dgvRelatedDecisions[4, e.RowIndex].Value.ToString();
                showDiagramsForEAElement(elementGUID);
            }
        }

        private void dgvRelatedRequirements_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1)
                return;
            else
            {
                string elementGUID = dgvRelatedRequirements[0, e.RowIndex].Value.ToString();
                showDiagramsForEAElement(elementGUID);
            }
        }

        private void dgvTraces_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1)
                return;
            else
            {
                string elementGUID = dgvTraces[0, e.RowIndex].Value.ToString();
                showDiagramsForEAElement(elementGUID);
            }
        }

        private void dgvStakeholder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1)
                return;
            else
            {
                string elementGUID = dgvStakeholder[0, e.RowIndex].Value.ToString();
                showDiagramsForEAElement(elementGUID);
            }
        }

        private void dgvAlternatives_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}