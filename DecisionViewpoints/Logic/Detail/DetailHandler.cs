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
            var repository = EARepository.Instance;
            var element = repository.GetElementByGUID(guid);
            if (!element.IsDecision()) return false;
            var detailController = new DetailController(new Decision(element), new DetailView());
            detailController.UpdateView();
            return true;
        }

        public override void OnNotifyContextItemModified(string guid, NativeType type)
        {
            if (type != NativeType.Element) return;
            var repository = EARepository.Instance;
            var element = repository.GetElementByGUID(guid);
            if (!element.IsDecision()) return;
            MessageBox.Show(element.Stereotype);
        }
    }
}
