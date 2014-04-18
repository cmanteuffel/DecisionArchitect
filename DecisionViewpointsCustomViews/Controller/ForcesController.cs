using DecisionViewpointsCustomViews.Model;
using DecisionViewpointsCustomViews.View;

namespace DecisionViewpointsCustomViews.Controller
{
    public class ForcesController
    {
        private readonly ICustomView _view;
        private readonly ForcesModel _model;

        public ForcesController(ICustomView view, ForcesModel model)
        {
            _view = view;
            _model = model;
            view.SetController(this);
        }

        public string DiagramGUID()
        {
            return _view.DiagramGUID;
        }

        public void UpdateTable()
        {
            _view.UpdateTable(_model);
        }
    }
}
