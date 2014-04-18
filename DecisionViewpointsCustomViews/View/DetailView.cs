using System.Windows.Forms;
using DecisionViewpointsCustomViews.Controller;
using DecisionViewpointsCustomViews.Model;

namespace DecisionViewpointsCustomViews.View
{
    public partial class DetailView : Form, IDetailView
    {
        private IDetailViewController _controller;

        public DetailView()
        {
            InitializeComponent();
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
        }

        public string DecisionText
        {
            get { return txtDecision.Text.Trim(' '); }
            set { txtDecision.Text = value; }
        }

        public string DecisionAlternatives
        {
            get { return txtAlternatives.Text.Trim(' '); }
            set { txtAlternatives.Text = value; }
        }

        public string DecisionArguments
        {
            get { return txtArguments.Text.Trim(' '); }
            set { txtArguments.Text = value; }
        }

        public string DecisionRelatedRequirements
        {
            get { return txtRelatedRequirements.Text.Trim(' '); }
            set { txtRelatedRequirements.Text = value; }
        }

        public void AddRelatedDecision(string relationship, string name, bool isClient, string uid)
        {
            lbxRelatedDecisions.Items.Add(isClient
                                              ? string.Format("This <<{1}>> {0}", name, relationship)
                                              : string.Format("{0} <<{1}>> This", name, relationship));
        }

        //angor START task156
        //IMPORTANT!!! --> added a Alternative Decisions listbox on top of the old textbox..
        public void AddAlternativeDecision(string relationship, string name,bool isClient, string uid)
        {
            lbxAlternativesDecision.Items.Add(isClient
                ? string.Format("This <<{1}>> {0}", name, relationship)
                : string.Format("{0} <<{1}>> This", name, relationship));
        }
        //angor END task156

        //angor START task157
        public void AddTrace(string name, string type, string uid)
        {
            lbxTraces.Items.Add(name + " (" + type + ")");
        }
        //angor END task157

        //angor START task159
        //IMPORTANT!!! --> added a related Requirements listBox on top of the old textbox..
        public void AddRelatedRequirement(string name, string rating, string description, string uid)
        {
            lbxRelatedRequirements.Items.Add(name + " : " /*+ rating + " : "*/ + description);
        }
        //angor END task159


        public void AddHistoryEntry(string name, string stereotype, string s, string state)
        {
            var stakeholderText = string.Format("{0}\n<<{1}>>", name, stereotype);
            dgvHistory.Rows.Add(new object[] { stakeholderText, s, state });
        }

        public void ShowAsDialog()
        {
            ShowDialog();
        }

        public void SetController(IDetailViewController controller)
        {
            _controller = controller;
        }

        public void Update(IDecision model)
        {
            throw new System.NotImplementedException();
        }

        private void buttonOk_Click(object sender, System.EventArgs e)
        {
            _controller.Save();
        }

        private void rtf_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void DetailView_Load(object sender, System.EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {

        }
    }
}
