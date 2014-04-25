/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
*/

using System.Collections.Generic;
using System.Linq;
using DecisionViewpoints.Model;
using DecisionViewpoints.View;
using DecisionViewpoints.View.Controller;
using EAFacade;
using EAFacade.Model;


namespace DecisionViewpoints.Logic.Forces
{
    public class ForcesHandler : RepositoryAdapter
    {
        // hold referecnes to the created views so to respond to the changed events (might need to change)
        private readonly Dictionary<string, IForcesController> _controllers =
            new Dictionary<string, IForcesController>();

        public override bool OnContextItemDoubleClicked(string guid, EANativeType type)
        {
            if (EANativeType.Diagram != type) return false;
            var repository = EAFacade.EA.Repository;
            var diagram = repository.GetDiagramByGuid(guid);
            if (!diagram.IsForcesView()) return false;
            var forcesDiagramModel = new ForcesModel(diagram);
            if (repository.IsTabOpen(forcesDiagramModel.Name) > 0)
            {
                // naming is not optimal as tabs can have same names... need to find a solution that we can
                // distinguish tabs more optimal
                repository.ActivateTab(forcesDiagramModel.Name);
                return true;
            }

            IForcesView forcesView = repository.AddTab(forcesDiagramModel.Name,
                                                       "DecisionViewpoints.ForcesView");
            IForcesController forcesController;

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

            forcesController.Update();
            return true;
        }

        public override void OnNotifyContextItemModified(string guid, EANativeType type)
        {
            var repository = EAFacade.EA.Repository;
            IForcesController forcesController;
            switch (type)
            {
                // the diagram is modified when we remove an element or a connector from it
                case EANativeType.Diagram:
                    var diagram = repository.GetDiagramByGuid(guid);
                    if (!diagram.IsForcesView()) return;
                    // if the name of a diagram changed and the forces tab is open then close it to avoid conflicts
                    if (repository.IsTabOpen(ForcesModel.CreateForcesTabName(diagram.Name)) <= 0)
                    {
                        if (!_controllers.ContainsKey(diagram.GUID)) break;
                        forcesController = _controllers[diagram.GUID];
                        if (repository.IsTabOpen(forcesController.Model.Name) > 0)
                            repository.RemoveTab(forcesController.Model.Name);
                        break;
                    }
                    if (!_controllers.ContainsKey(diagram.GUID)) break;
                    forcesController = _controllers[diagram.GUID];
                    forcesController.SetDiagramModel(diagram);
                    break;
                case EANativeType.Element:
                    var element = repository.GetElementByGUID(guid);
                    foreach (
                        var eaDiagram in
                            element.GetDiagrams()
                                   .Where(eaDiagram => eaDiagram.IsForcesView())
                                   .Where(eaDiagram => _controllers.ContainsKey(eaDiagram.GUID)))
                    {
                        forcesController = _controllers[eaDiagram.GUID];
                        if (element.IsDecision())
                            forcesController.UpdateDecision(element);
                        else if (element.IsConcern())
                            forcesController.UpdateConcern(element);
                        else if (element.IsRequirement())
                            forcesController.UpdateRequirement(element);
                    }
                    break;
            }
        }

        public override bool OnPreDeleteDiagram(IEAVolatileDiagram volatileDiagram)
        {
            var repository = EAFacade.EA.Repository;
            var diagram = repository.GetDiagramByID(volatileDiagram.DiagramID);
            if (!diagram.IsForcesView()) return true;
            if (_controllers.ContainsKey(diagram.GUID))
            {
                if (repository.IsTabOpen(ForcesModel.CreateForcesTabName(diagram.Name)) > 0)
                    repository.RemoveTab(ForcesModel.CreateForcesTabName(diagram.Name));
                _controllers.Remove(diagram.GUID);
            }
            return true;
        }

        public override bool OnPreDeleteElement(IEAElement element)
        {
            if (!element.IsDecision() && !element.IsConcern() && !element.IsRequirement()) return true;
            var diagrams = new List<IEADiagram>();
            diagrams.AddRange(element.GetDiagrams().Where(eaDiagram => eaDiagram.IsForcesView()));
            if (diagrams.Count == 0) return true;
            var repository = EAFacade.EA.Repository;
            foreach (
                var forcesController in
                    from diagram in diagrams
                    where repository.IsTabOpen(ForcesModel.CreateForcesTabName(diagram.Name)) > 0
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

        public override void OnPostOpenDiagram(IEADiagram diagram)
        {
            if (!diagram.IsForcesView()) return;
            diagram.HideConnectors(new[]
                {
                    EAConstants.RelationAlternativeFor, EAConstants.RelationCausedBy,
                    EAConstants.RelationDependsOn,
                    EAConstants.RelationExcludedBy, EAConstants.RelationReplaces, EAConstants.RelationFollowedBy
                });
        }
    }
}
