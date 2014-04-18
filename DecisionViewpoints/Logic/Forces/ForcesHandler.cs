using System;
using System.Collections.Generic;
using System.Linq;
using DecisionViewpointsCustomViews.Controller;
using DecisionViewpointsCustomViews.Model;
using DecisionViewpointsCustomViews.View;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Forces
{
    public class ForcesHandler : RepositoryAdapter
    {
        // hold referecnes to the created views so to respond to the changed events (might need to change)
        private readonly Dictionary<string, ICustomViewController> _controllers =
            new Dictionary<string, ICustomViewController>();

        public override bool OnContextItemDoubleClicked(string guid, NativeType type)
        {
            if (NativeType.Diagram != type) return false;
            var repository = EARepository.Instance;
            var diagram = repository.GetDiagramByGuid(guid);
            if (!diagram.IsForces()) return false;
            var forcesDiagramModel = new ForcesDiagramModel
                {
                    DiagramModel = diagram,
                    Name = CreateForcesTabName(diagram.Name)
                };
            if (repository.IsTabOpen(forcesDiagramModel.Name) > 0)
            {
                // naming is not optimal as tabs can have same names... need to find a solution that we can
                // distinguish tabs more optimal
                repository.ActivateTab(forcesDiagramModel.Name);
                return true;
            }

            ICustomView forcesView = repository.AddTab(forcesDiagramModel.Name,
                                                       "DecisionViewpointsCustomViews.ForcesView");
            ICustomViewController forcesController;

            if (!_controllers.ContainsKey(forcesDiagramModel.DiagramGUID))
            {
                forcesController = new ForcesController(forcesView, forcesDiagramModel);
                _controllers.Add(forcesDiagramModel.DiagramGUID, forcesController);
            }
            else
            {
                forcesController = _controllers[forcesDiagramModel.DiagramGUID];
                forcesController.View = forcesView;
                forcesController.Model = forcesDiagramModel;
            }

            forcesController.UpdateTable();
            return true;
        }

        public override void OnNotifyContextItemModified(string guid, NativeType type)
        {
            var repository = EARepository.Instance;
            var diagrams = new List<EADiagram>();
            switch (type)
            {
                case NativeType.Diagram:
                    var diagram = repository.GetDiagramByGuid(guid);
                    if (!diagram.IsForces()) return;
                    diagrams.Add(diagram);
                    break;
                case NativeType.Element:
                    var element = repository.GetElementByGUID(guid);
                    diagrams.AddRange(element.GetDiagrams().Where(eaDiagram => eaDiagram.IsForces()));
                    break;
            }
            if (diagrams.Count == 0) return;
            foreach (var diagram in diagrams)
            {
                ICustomViewController forcesController;
                if (repository.IsTabOpen(CreateForcesTabName(diagram.Name)) <= 0)
                {
                    // if the name of a diagram changed and the forces tab is open then close it to avoid conflicts
                    if (!_controllers.ContainsKey(diagram.GUID)) continue;
                    forcesController = _controllers[diagram.GUID];
                    if (repository.IsTabOpen(forcesController.Model.Name) > 0)
                        repository.RemoveTab(forcesController.Model.Name);
                    continue;
                }
                if (!_controllers.ContainsKey(diagram.GUID)) continue;
                forcesController = _controllers[diagram.GUID];
                forcesController.SetDiagramModel(diagram);
            }
        }

        public override bool OnPreDeleteDiagram(EAVolatileDiagram volatileDiagram)
        {
            var repository = EARepository.Instance;
            var diagram = repository.GetDiagramByID(volatileDiagram.DiagramID);
            if (!diagram.IsForces()) return true;
            if (_controllers.ContainsKey(diagram.GUID))
            {
                if (repository.IsTabOpen(CreateForcesTabName(diagram.Name)) > 0)
                    repository.RemoveTab(CreateForcesTabName(diagram.Name));
                _controllers.Remove(diagram.GUID);
            }
            return true;
        }

        public override bool OnPreDeleteElement(EAElement element)
        {
            if (!element.IsDecision() && !element.IsConcern() && !element.IsRequirement()) return true;
            var diagrams = new List<EADiagram>();
            diagrams.AddRange(element.GetDiagrams().Where(eaDiagram => eaDiagram.IsForces()));
            if (diagrams.Count == 0) return true;
            var repository = EARepository.Instance;
            foreach (
                var forcesController in
                    from diagram in diagrams
                    where repository.IsTabOpen(CreateForcesTabName(diagram.Name)) > 0
                    select _controllers[diagram.GUID])
            {
                // we cannot update the view with a new diagram model here, as the diagram changes are applied
                // after the deletion event is successful
                if (element.IsDecision())
                    forcesController.RemoveDecision(element);
                else if (element.IsConcern())
                    forcesController.RemoveConcern(element);
                else if (element.IsRequirement())
                    forcesController.RemoveRequirement(element);
            }
            return true;
        }

        public override void OnFileOpen()
        {
            _controllers.Clear();
        }

        private static string CreateForcesTabName(string diagramName)
        {
            return String.Format("{0} (Forces)", diagramName);
        }
    }
}