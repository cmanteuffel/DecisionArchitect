using System.Windows.Forms;
using DecisionViewpointsCustomViews.Controller;
using DecisionViewpointsCustomViews.Model;
using DecisionViewpointsCustomViews.View;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Detail
{
    public class DetailHandler : RepositoryAdapter
    {
        public override bool OnContextItemDoubleClicked(string guid, NativeType type)
        {
            if (type != NativeType.Element) return false;
            EARepository repository = EARepository.Instance;
            EAElement element = repository.GetElementByGUID(guid);
            if (!element.IsDecision() && !element.IsTopic()) return false;
            if (element.IsDecision() && !element.IsHistoryDecision())
            {
                var detailController = new DetailController(new Decision(element), new DetailView());
                detailController.ShowDetailView();
            }
            else if (element.IsDecision() && element.IsHistoryDecision())
            {
                DialogResult dialogResult =
                    MessageBox.Show(
                        Messages.DialogOpenLatestDecision,
                        Messages.DialogOpenLatestDecisionTitle,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    var originalguid = element.GetTaggedValue(DVTaggedValueKeys.OriginalDecisionGuid);
                    var decision = EARepository.Instance.GetElementByGUID(originalguid);
                    var detailController = new DetailController(new Decision(decision), new DetailView());
                    detailController.ShowDetailView();

                }
            }
            else if (element.IsTopic())
            {
                var topicDetailController = new TopicDetailController(new Topic(element), new TopicDetailView());
                topicDetailController.ShowDetailView();
            }
            return true;
        }

        public override bool OnPostNewElement(EAElement element)
        {
            if (!element.IsDecision() && !element.IsTopic()) return false;

            EARepository.Instance.SuppressDefaultDialogs(true);
            if (element.IsDecision())
            {
                var detailController = new DetailController(new Decision(element), new DetailView()); //angor
                detailController.ShowDetailView();
            }
            else if (element.IsTopic())
            {
                var topicDetailController = new TopicDetailController(new Topic(element), new TopicDetailView());
                topicDetailController.ShowDetailView();
            }
            return false;
        }
    }
}