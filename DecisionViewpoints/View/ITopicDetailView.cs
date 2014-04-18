using DecisionViewpoints.View.Controller;

namespace DecisionViewpoints.View
{
    public interface ITopicDetailView : ICustomView
    {
        string TopicName { get; set; }
        string TopicDescription { get; set; }

        void ShowAsDialog();
        void SetController(ITopicDetailController controller);
    }
}