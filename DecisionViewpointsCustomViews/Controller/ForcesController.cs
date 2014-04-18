using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DecisionViewpointsCustomViews.Model;
using DecisionViewpointsCustomViews.View;
using EAFacade.Model;

namespace DecisionViewpointsCustomViews.Controller
{
    public class ForcesController : IForcesController
    {
        private IForcesView _view;
        private IForcesModel _model;

        public ForcesController(IForcesView view, IForcesModel model)
        {
            _view = view;
            _model = model;
            _view.SetController(this);
            _model.AddObserver(_view);
        }

        public IForcesModel Model
        {
            get { return _model; }
            set
            {
                _model = value;
                _model.AddObserver(_view);
            }
        }

        public IForcesView View
        {
            get { return _view; }
            set
            {
                _view = value;
                _view.SetController(this);
            }
        }

        public void Update()
        {
            _view.UpdateTable(_model);
        }

        public void Save()
        {
            var ratings = new List<Rating>();
            var decisionColumnIndex = 3;
            foreach (var decisionGUID in _view.DecisionGuids)
            {
                var requirementRowIndex = 0;
                foreach (var requirementGUID in _view.RequirementGuids)
                {
                    var rating = _view.GetRating(requirementRowIndex, decisionColumnIndex);
                    var concernGUID = _view.GetRating(requirementRowIndex, 2);
                    ratings.Add(new Rating
                        {
                            DecisionGUID = decisionGUID,
                            RequirementGUID = requirementGUID,
                            ConcernGUID = concernGUID,
                            Value = rating
                        });
                    requirementRowIndex++;
                }
                decisionColumnIndex++;
            }
            _model.SaveRatings(ratings);
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

        public void UpdateDecision(EAElement element)
        {
            _view.UpdateDecision(element);
        }

        public void UpdateRequirement(EAElement element)
        {
            _view.UpdateRequirement(element);
        }

        public void UpdateConcern(EAElement element)
        {
            _view.UpdateConcern(element);
        }

        public void RemoveDecision(EAElement element)
        {
            _view.RemoveDecision(element);
        }

        public void RemoveRequirement(EAElement element)
        {
            _view.RemoveRequirement(element);
        }

        public void RemoveConcern(EAElement element)
        {
            _view.RemoveConcern(element);
        }
    }
}