using System;
using System.Windows.Forms;
using DecisionViewpointsCustomViews.Model;
using DecisionViewpointsCustomViews.View;
using EAWrapper.Model;

namespace DecisionViewpointsCustomViews.Controller
{
    public class ForcesController : ICustomViewController
    {
        private readonly ICustomView _view;
        private readonly ICustomViewModel _model;

        public ForcesController(ICustomView view, ICustomViewModel model)
        {
            _view = view;
            _model = model;
            _view.SetController(this);
            _model.AddObserver(_view);
        }

        public void UpdateTable()
        {
            _view.UpdateTable(_model);
        }

        public void SaveRatings()
        {
            _model.SaveRatings();
        }

        public void Configure()
        {
            var repository = EARepository.Instance;
            try
            {
                var diagram = repository.GetDiagramByGuid(_model.DiagramGUID);
                repository.OpenDiagram(diagram.ID);
            }
            catch (Exception)
            {
                MessageBox.Show("no diagram");
            }
        }

        public void SetDiagramModel(EADiagram diagram)
        {
            _model.DiagramModel = diagram;
        }
    }
}
