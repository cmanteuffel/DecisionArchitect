using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DecisionViewpointsCustomViews.Model;
using DecisionViewpointsCustomViews.View;
using EAFacade.Model;

namespace DecisionViewpointsCustomViews.Controller
{
    public class ForcesController : ICustomViewController
    {
        private ICustomView _view;
        private ICustomViewModel _model;

        public ForcesController(ICustomView view, ICustomViewModel model)
        {
            _view = view;
            _model = model;
            _view.SetController(this);
            _model.AddObserver(_view);
        }

        public void SetModel(ICustomViewModel model)
        {
            _model = model;
            _model.AddObserver(_view);
        }

        public void SetView(ICustomView view)
        {
            _view = view;
            _view.SetController(this);
        }

        public void UpdateTable()
        {
            _view.UpdateTable(_model);
        }

        public void SaveRatings()
        {
            // Data structure: <decisionGUID, <r:requirementGUID:concernGUID, rating>>
            var data = new Dictionary<string, Dictionary<string, string>>();
            var decisionColumnIndex = 3;
            foreach (var decisionGUID in _view.DecisionGUID)
            {
                var requirementRowIndex = 0;
                var reqConcRating = new Dictionary<string, string>();
                foreach (var requirementGUID in _view.RequirementGUID)
                {
                    var concernGUID = _view.ConcernGUID[requirementRowIndex];
                    var rating = _view.GetRating(requirementRowIndex, decisionColumnIndex);
                    var reqConcKey = String.Format("r:{0}:{1}", requirementGUID, concernGUID);
                    reqConcRating.Add(reqConcKey, rating);
                    requirementRowIndex++;
                }
                data.Add(decisionGUID, reqConcRating);
                decisionColumnIndex++;
            }
            _model.SaveRatings(data);
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

        public void RemoveDecision(EAElement element)
        {
            _view.RemoveDecision(element.GUID);
        }

        public void RemoveRequirement(EAElement element)
        {
            _view.RemoveRequirement(element.GUID);
        }

        public void RemoveConcern(EAElement element)
        {
            _view.RemoveConcern(element.GUID);
        }
    }
}
