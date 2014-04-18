﻿using System;
using System.Collections.Generic;
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
            EADiagram diagram = null;
            switch (type)
            {
                case NativeType.Diagram:
                    diagram = repository.GetDiagramByGuid(guid);
                    if (!diagram.IsForces()) return;
                    break;
                case NativeType.Element:
                    var element = repository.GetElementByGUID(guid);
                    foreach (var eaDiagram in element.GetDiagrams())
                    {
                        // what if it appears in many diagrams?
                        if (!eaDiagram.IsForces()) continue;
                        diagram = eaDiagram;
                        break;
                    }
                    break;
            }
            if (diagram == null) return;
            var forcesDiagramModel = new ForcesDiagramModel
                {
                    DiagramModel = diagram,
                    Name = CreateForcesTabName(diagram.Name)
                };
            if (repository.IsTabOpen(forcesDiagramModel.Name) <= 0) return;
            var forcesController = new ForcesController(_views[forcesDiagramModel.DiagramGUID], forcesDiagramModel);
            forcesController.UpdateTable();
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

        private static string CreateForcesTabName(string diagramName)
        {
            return String.Format("{0} (Forces)", diagramName);
        }

        // TODO: if an element is deleted from the browser then we need to update the table
    }
}