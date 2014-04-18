using DecisionViewpointsCustomViews.Controller;
using DecisionViewpointsCustomViews.Model;
using DecisionViewpointsCustomViews.View;
using EAFacade.Model;
using System.Windows.Forms;

namespace DecisionViewpoints.Logic.Detail
{
    public class DetailHandler : RepositoryAdapter
    {
        /*
        public override bool OnContextItemDoubleClicked(string guid, NativeType type)
        {
            if (type != NativeType.Element) return false;
            var repository = EARepository.Instance;
            var element = repository.GetElementByGUID(guid);
            if (!element.IsDecision()) return false;
            //var detailController = new DetailController(new Decision(element), new DetailView());//original
            var detailController = new DetailController(new Decision(element), new DetailViewNew());//angor
            detailController.ShowDetailView();
            return true;
        }
         */
        //angor task189 START
        public override bool OnContextItemDoubleClicked(string guid, NativeType type)
        {
            if (type != NativeType.Element) return false;
            var repository = EARepository.Instance;
            var element = repository.GetElementByGUID(guid);
            if (!element.IsDecision() && !element.IsTopic()) return false;
            if (element.IsDecision())
            {
                //var detailController = new DetailController(new Decision(element), new DetailView());//original
                var detailController = new DetailController(new Decision(element), new DetailView());//angor
                detailController.ShowDetailView();
            }
            else if (element.IsTopic())
            {
                //MessageBox.Show("Topic: OnContextItemDoubleClicked");
                var topicDetailController = new TopicDetailController(new Topic(element), new TopicDetailView());
                topicDetailController.ShowDetailView();
            }
            return true;

        }
        //angor task189 END

        /*
        public override bool OnPostNewElement(EAElement element)
        {
            if (!element.IsDecision()) return false;
            EARepository.Instance.SuppressDefaultDialogs(true);
            //var detailController = new DetailController(new Decision(element), new DetailView());//original
            var detailController = new DetailController(new Decision(element), new DetailViewNew());//angor
            detailController.ShowDetailView();
            return false;
        }
         */
        //angor task189 START
        public override bool OnPostNewElement(EAElement element)
        {
            if (!element.IsDecision() && !element.IsTopic()) return false;

            EARepository.Instance.SuppressDefaultDialogs(true);
            if (element.IsDecision())
            {
                var detailController = new DetailController(new Decision(element), new DetailView());//angor
                detailController.ShowDetailView();
            }
            else if(element.IsTopic())
            {
                //MessageBox.Show("Topic: OnPostNewElement");
                var topicDetailController = new TopicDetailController(new Topic(element), new TopicDetailView());
                topicDetailController.ShowDetailView();
            }
            return false;
        }
        //angor task189 END
    }
}
