using System.Windows.Forms;
using DecisionViewpointsCustomViews.Controller;

namespace DecisionViewpointsCustomViews.View
{
    public partial class DetailView : Form
    {
        private DetailController _controller;

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

        public void AddRelatedDecision(string relationship, string name, bool isClient)
        {
            lbxRelatedDecisions.Items.Add(isClient
                                              ? string.Format("This <<{1}>> {0}", name, relationship)
                                              : string.Format("{0} <<{1}>> This", name, relationship));
        }

        public void SetController(DetailController controller)
        {
            _controller = controller;
        }

        private void buttonOk_Click(object sender, System.EventArgs e)
        {
            _controller.Save();
        }

        private void rtf_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
