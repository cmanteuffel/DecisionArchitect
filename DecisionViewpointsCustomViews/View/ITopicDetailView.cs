using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionViewpointsCustomViews.Controller;
using DecisionViewpointsCustomViews.Model;

namespace DecisionViewpointsCustomViews.View
{
    public interface ITopicDetailView : ICustomView
    {
        string TopicName { get; set; }
        string TopicDescription { get; set; }

        void ShowAsDialog();
        void SetController(ITopicDetailController controller);
    }
}
