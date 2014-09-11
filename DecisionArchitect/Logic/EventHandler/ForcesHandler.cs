/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    Mark Hoekstra (University of Groningen)
*/

using System.Collections.Generic;
using System.Linq;
using DecisionArchitect.Model;
using DecisionArchitect.View.Controller;
using DecisionArchitect.View.Forces;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Logic.EventHandler
{
    public class ForcesHandler : RepositoryAdapter
    {
        // hold references to the created views so to respond to the changed events (might need to change)
        private readonly Dictionary<string, IForcesController> _controllers =
            new Dictionary<string, IForcesController>();

        public override bool OnContextItemDoubleClicked(string guid, EANativeType type)
        {
            if (EANativeType.Diagram != type) return false;
            IEARepository repository = EAMain.Repository;
            IEADiagram diagram = repository.GetDiagramByGuid(guid);
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
                                                       "DecisionViewpoints.Forces");
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
            IEARepository repository = EAMain.Repository;
            IForcesController forcesController;
            switch (type)
            {
                    // the diagram is modified when we remove an element or a connector from it
                case EANativeType.Diagram:
                    IEADiagram diagram = repository.GetDiagramByGuid(guid);
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
                    IEAElement element = repository.GetElementByGUID(guid);
                    foreach (
                        IEADiagram eaDiagram in
                            element.GetDiagrams()
                                   .Where(eaDiagram => eaDiagram.IsForcesView())
                                   .Where(eaDiagram => _controllers.ContainsKey(eaDiagram.GUID)))
                    {
                        forcesController = _controllers[eaDiagram.GUID];
                        // An element can be of multiple types:
                        if (element.TaggedValueExists(EATaggedValueKeys.IsDecisionElement, eaDiagram.GUID))
                            forcesController.UpdateDecision(element);
                        if (element.TaggedValueExists(EATaggedValueKeys.IsConcernElement, eaDiagram.GUID))
                            forcesController.UpdateConcern(element);
                        if (element.TaggedValueExists(EATaggedValueKeys.IsForceElement, eaDiagram.GUID))
                            forcesController.UpdateForce(element);
                    }
                    break;
            }
        }

        public override bool OnPreDeleteDiagram(IEAVolatileDiagram volatileDiagram)
        {
            IEARepository repository = EAMain.Repository;
            IEADiagram diagram = repository.GetDiagramByID(volatileDiagram.DiagramID);
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
            if (!element.TaggedValueExists(EATaggedValueKeys.IsDecisionElement) &&
                !element.TaggedValueExists(EATaggedValueKeys.IsConcernElement) &&
                !element.TaggedValueExists(EATaggedValueKeys.IsForceElement)) return true;

            var diagrams = new List<IEADiagram>();
            diagrams.AddRange(element.GetDiagrams().Where(eaDiagram => eaDiagram.IsForcesView()));
            if (diagrams.Count == 0) return true;
            IEARepository repository = EAMain.Repository;

            foreach (
                IForcesController forcesController in
                    from diagram in diagrams
                    where repository.IsTabOpen(ForcesModel.CreateForcesTabName(diagram.Name)) > 0
                    select _controllers[diagram.GUID])
            {
                string diagramGuid = forcesController.Model.DiagramGUID;
                // we cannot update the view with a new diagram model here, as the diagram changes are applied
                // after the deletion event is successful
                if (element.TaggedValueExists(EATaggedValueKeys.IsDecisionElement, diagramGuid))
                    forcesController.RemoveDecision(element);
                if (element.TaggedValueExists(EATaggedValueKeys.IsConcernElement, diagramGuid))
                    forcesController.RemoveConcern(element);
                if (element.TaggedValueExists(EATaggedValueKeys.IsForceElement, diagramGuid))
                    forcesController.RemoveForce(element);
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