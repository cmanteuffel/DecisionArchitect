using DecisionViewpointsCustomViews.Model;
using DecisionViewpointsCustomViews.View;

namespace DecisionViewpointsCustomViews.Controller
{
    public class ForcesController
    {
        private readonly ICustomView _view;

        public ForcesController(ICustomView view)
        {
            _view = view;
            view.SetController(this);
        }

        public void UpdateTable(ForcesModel forcesModel)
        {
            _view.UpdateTable(forcesModel);
        }
    }
}
