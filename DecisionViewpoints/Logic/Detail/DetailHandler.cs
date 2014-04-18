using System.Windows.Forms;
using DecisionViewpoints.Model;
using DecisionViewpoints.View;
using DecisionViewpoints.View.Controller;
using EAFacade;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Detail
{
    public class DetailHandler : RepositoryAdapter
    {
        public override bool OnContextItemDoubleClicked(string guid, EANativeType type)
        {
            if (type != EANativeType.Element) return false;
            IEARepository repository = EAFacade.EA.Repository;
            IEAElement element = repository.GetElementByGUID(guid);
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
                    string originalguid = element.GetTaggedValue(EATaggedValueKeys.OriginalDecisionGuid);
                    IEAElement decision = repository.GetElementByGUID(originalguid);
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

        public override bool OnPostNewElement(IEAElement element)
        {
            if (!element.IsDecision() && !element.IsTopic()) return false;

            EAFacade.EA.Repository.SuppressDefaultDialogs(true);
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