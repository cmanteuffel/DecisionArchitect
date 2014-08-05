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

using System;
using System.Globalization;
using System.Linq;
using DecisionArchitect.Model;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Logic.Chronological
{
    internal class ChronologicalViewpointHandler : RepositoryAdapter
    {
        public override void OnNotifyContextItemModified(string guid, EANativeType type)
        {
            switch (type)
            {
                case EANativeType.Diagram:
                    IEADiagram diagram = EAFacade.EA.Repository.GetDiagramByGuid(guid);
                    if (!diagram.IsChronologicalView()) break;
                    diagram.HideConnectors(new[]
                        {
                            EAConstants.RelationAlternativeFor, EAConstants.RelationCausedBy,
                            EAConstants.RelationDependsOn,
                            EAConstants.RelationExcludedBy, EAConstants.RelationReplaces
                        });
                    break;
                case EANativeType.Element:
                    IEAElement element = EAFacade.EA.Repository.GetElementByGUID(guid);

                    if (element == null) throw new Exception("element is null");

                    //save state change
                    if (element.IsDecision())
                    {

                        var decision = new Decision(element);
                        var newState = element.Stereotype;
                        var history = decision.GetHistory().ToList();
                        history.Sort(DecisionStateChange.CompareByDateModified);
                        if (history.Count > 0)
                        {
                            //check if there was actually a state change (current state != new state)s
                            var currentState = history.Last();
                            if (currentState.State != newState)
                            {
                               decision.AddHistory(newState, decision.Modified);       
                            }
                        }
                        else
                        {
                            decision.AddHistory(newState, decision.Modified);
                        }

                        string oldState = element.GetTaggedValue(EATaggedValueKeys.DecisionState);
                        if (oldState == null || element.Stereotype.Equals(oldState)) return;

                        element.UpdateTaggedValue(EATaggedValueKeys.DecisionStateModifiedDate,
                                                  element.Modified.ToString(CultureInfo.InvariantCulture));
                        element.UpdateTaggedValue(EATaggedValueKeys.DecisionState, element.Stereotype);
                        
                    }
                    break;
            }
        }

        public override bool OnPostNewElement(IEAElement element)
        {
            if (element.IsDecision())
            {
                element.AddTaggedValue(EATaggedValueKeys.DecisionState, element.Stereotype);
                element.AddTaggedValue(EATaggedValueKeys.IsHistoryDecision, false.ToString());
            }
            if (element.IsDecision() || element.IsTopic())
            {
                element.AddTaggedValue(EATaggedValueKeys.DecisionStateModifiedDate,
                                       element.Modified.ToString(CultureInfo.InvariantCulture));
            }
            return true;
        }

        public override void OnPostOpenDiagram(IEADiagram diagram)
        {
            if (!diagram.IsChronologicalView()) return;
            diagram.HideConnectors(new[]
                {
                    EAConstants.RelationAlternativeFor, EAConstants.RelationCausedBy,
                    EAConstants.RelationDependsOn,
                    EAConstants.RelationExcludedBy, EAConstants.RelationReplaces
                });
        }
        
    }
}
