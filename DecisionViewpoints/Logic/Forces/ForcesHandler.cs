using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DecisionViewpointsCustomViews.Controller;
using DecisionViewpointsCustomViews.Model;
using DecisionViewpointsCustomViews.View;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Forces
{
    public class ForcesHandler : RepositoryAdapter
    {
        // hold referecnes to the created views so to respond to the changed events (might need to change)
        private readonly Dictionary<string, ICustomView> _views = new Dictionary<string, ICustomView>();

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
                repository.ActivateTab(forcesDiagramModel.Name);
                return true;
            }

            ICustomView forcesView = repository.AddTab(forcesDiagramModel.Name,
                                                       "DecisionViewpointsCustomViews.ForcesView");
            if (!_views.ContainsKey(forcesDiagramModel.DiagramGUID))
                _views.Add(forcesDiagramModel.DiagramGUID, forcesView);
            else
                _views[forcesDiagramModel.DiagramGUID] = forcesView;

            var forcesController = new ForcesController(forcesView, forcesDiagramModel);
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
                var forcesDiagramModel = new ForcesDiagramModel
                    {
                        DiagramModel = diagram,
                        Name = CreateForcesTabName(diagram.Name)
                    };
                if (repository.IsTabOpen(forcesDiagramModel.Name) <= 0) continue;
                var forcesController = new ForcesController(_views[forcesDiagramModel.DiagramGUID], forcesDiagramModel);
                forcesController.UpdateTable();
            }
        }

        public override bool OnPreDeleteDiagram(EAVolatileDiagram volatileDiagram)
        {
            var repository = EARepository.Instance;
            var diagram = repository.GetDiagramByID(volatileDiagram.DiagramID);
            if (!diagram.IsForces()) return true;
            if (_views.ContainsKey(diagram.GUID))
            {
                if (repository.IsTabOpen(CreateForcesTabName(diagram.Name)) > 0)
                    repository.RemoveTab(CreateForcesTabName(diagram.Name));
                _views.Remove(diagram.GUID);
            }
            return true;
        }

        public override bool OnPreDeleteElement(EAElement element)
        {
            if (!element.IsDecision() && !element.IsConcern() && !element.MetaType.Equals("Requirement")) return true;
            var diagrams = new List<EADiagram>();
            diagrams.AddRange(element.GetDiagrams().Where(eaDiagram => eaDiagram.IsForces()));
            if (diagrams.Count == 0) return true;
            var repository = EARepository.Instance;
            foreach (var diagram in diagrams)
            {
                var forcesDiagramModel = new ForcesDiagramModel
                {
                    DiagramModel = diagram,
                    Name = CreateForcesTabName(diagram.Name)
                };
                if (repository.IsTabOpen(forcesDiagramModel.Name) <= 0) continue;
                var forcesController = new ForcesController(_views[forcesDiagramModel.DiagramGUID], forcesDiagramModel);
                if (element.IsDecision())
                    forcesController.RemoveDecision(element);
                if (element.MetaType.Equals("Requirement"))
                    forcesController.RemoveRequirement(element);
            }
            return true;
        }

        private static string CreateForcesTabName(string diagramName)
        {
            return String.Format("{0} (Forces)", diagramName);
        }
    }
}