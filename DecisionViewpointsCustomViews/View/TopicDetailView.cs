using DecisionViewpointsCustomViews.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecisionViewpointsCustomViews.View
{
    public partial class TopicDetailView : Form, ITopicDetailView
    {
        private ITopicDetailController _controller; 

        public TopicDetailView()
        {
            InitializeComponent();
        }

        public string TopicName { 
        get {return  txtName.Text.Trim(' ');}
        set {txtName.Text = value;} 
        }

        public string TopicDescription {
            get { return txtDescription.Text.Trim(' '); }
            set { txtDescription.Text = value; }
        }

        private void TopicDetailView_Load(object sender, EventArgs e)
        {

        }

        public void ShowAsDialog()
        {
            ShowDialog();
        }

        public void SetController(ITopicDetailController controller)
        {
            _controller = controller;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _controller.Save();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        
    }
}
