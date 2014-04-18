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
            detailController.ShowDetailView();
            return true;
        }
    }
}
