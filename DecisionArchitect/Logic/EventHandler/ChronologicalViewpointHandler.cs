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

using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Logic.EventHandler
{
    internal class ChronologicalViewpointHandler : RepositoryAdapter
    {
        public override void OnNotifyContextItemModified(string guid, EANativeType type)
        {
            switch (type)
            {
                case EANativeType.Diagram:
                    IEADiagram diagram = EAMain.Repository.GetDiagramByGuid(guid);
                    if (!diagram.IsChronologicalView()) break;
                    diagram.HideConnectors(new[]
                        {
                            EAConstants.RelationAlternativeFor, EAConstants.RelationCausedBy,
                            EAConstants.RelationDependsOn,
                            EAConstants.RelationExcludedBy, EAConstants.RelationReplaces
                        });
                    break;
            }
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