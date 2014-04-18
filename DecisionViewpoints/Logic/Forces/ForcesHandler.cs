using System;
using DecisionViewpointsCustomViews.Controller;
using DecisionViewpointsCustomViews.Model;
using DecisionViewpointsCustomViews.View;
using EA;
using EAWrapper.Model;

namespace DecisionViewpoints.Logic.Forces
{
    public class ForcesHandler : RepositoryAdapter
    {
        private ICustomViewController _forcesController;

        public override bool OnContextItemDoubleClicked(string guid, ObjectType type)
        {
            if (!IsForcesDiagram(guid, type)) return false;
            var repository = EARepository.Instance;
            var diagram = repository.GetDiagramByGuid(guid);
            var forcesDiagramModel = new ForcesDiagramModel
                {
                    DiagramModel = diagram,
                    Name = String.Format("{0} (Forces)", diagram.Name)
                };
            if (repository.IsTabOpen(forcesDiagramModel.Name) > 0)
            {
                repository.ActivateTab(forcesDiagramModel.Name);
                return true;
            }
            ICustomView forcesView = repository.AddTab(forcesDiagramModel.Name,
                                                       "DecisionViewpointsCustomViews.CustomViewControl");
            _forcesController = new ForcesController(forcesView, forcesDiagramModel);
            _forcesController.UpdateTable();
            return true;
        }

        public override void OnNotifyContextItemModified(string guid, ObjectType type)
        {
            if (!IsForcesDiagram(guid, type)) return;
            var repository = EARepository.Instance;
            var diagram = repository.GetDiagramByGuid(guid);
            if (_forcesController == null) return;
            _forcesController.SetDiagramModel(diagram);
        }

        private static bool IsForcesDiagram(string guid, ObjectType type)
        {
            if (ObjectType.otDiagram != type) return false;
            var repository = EARepository.Instance;
            return repository.GetDiagramByGuid(guid).IsForces();
        }
    }
}