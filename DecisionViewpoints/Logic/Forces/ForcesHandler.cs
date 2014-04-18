using System;
using System.Collections.Generic;
using DecisionViewpointsCustomViews.Controller;
using DecisionViewpointsCustomViews.Model;
using DecisionViewpointsCustomViews.View;
using EA;
using EAWrapper.Model;

namespace DecisionViewpoints.Logic.Forces
{
    public class ForcesHandler : RepositoryAdapter
    {
        // hold referecnes to the created views so to respond to the changed events (might need to change)
        private readonly Dictionary<string, ICustomView> _views = new Dictionary<string, ICustomView>();

        public override bool OnContextItemDoubleClicked(string guid, ObjectType type)
        {
            if (!IsForcesDiagram(guid, type)) return false;
            var repository = EARepository.Instance;
            var diagram = repository.GetDiagramByGuid(guid);
            var modelName = String.Format("{0} (Forces)", diagram.Name);
            var forcesDiagramModel = new ForcesDiagramModel
                {
                    DiagramModel = diagram,
                    Name = modelName
                };
            if (repository.IsTabOpen(forcesDiagramModel.Name) > 0)
            {
                repository.ActivateTab(forcesDiagramModel.Name);
                return true;
            }
            ICustomView forcesView = repository.AddTab(forcesDiagramModel.Name,
                                                       "DecisionViewpointsCustomViews.CustomViewControl");
            _views.Add(forcesDiagramModel.Name, forcesView);
            var forcesController = new ForcesController(forcesView, forcesDiagramModel);
            forcesController.UpdateTable();
            return true;
        }

        public override void OnNotifyContextItemModified(string guid, ObjectType type)
        {
            if (!IsForcesDiagram(guid, type)) return;
            var repository = EARepository.Instance;
            var diagram = repository.GetDiagramByGuid(guid);
            var modelName = String.Format("{0} (Forces)", diagram.Name);
            var forcesModel = new ForcesDiagramModel
                {
                    DiagramModel = diagram,
                    Name = modelName
                };
            var forcesController = new ForcesController(_views[modelName], forcesModel);
            forcesController.UpdateTable();
        }

        private static bool IsForcesDiagram(string guid, ObjectType type)
        {
            if (ObjectType.otDiagram != type) return false;
            var repository = EARepository.Instance;
            return repository.GetDiagramByGuid(guid).IsForces();
        }
    }
}