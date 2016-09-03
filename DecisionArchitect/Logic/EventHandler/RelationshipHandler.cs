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
    public class RelationshipHandler : RepositoryAdapter
    {
        public override void OnPostOpenDiagram(IEADiagram diagram)
        {
            if (!diagram.IsRelationshipView()) return;
            diagram.HideConnectors(new[]
                {
                    EAConstants.RelationFollowedBy
                });
        }

        public override void OnNotifyContextItemModified(string guid, EANativeType type)
        {
            if (EANativeType.Diagram.Equals(type))
            {
                IEADiagram diagram = EAMain.Repository.GetDiagramByGuid(guid);
                if (!diagram.IsRelationshipView()) return;
                diagram.HideConnectors(new[]
                    {
                        EAConstants.RelationFollowedBy
                    });
            }
        }
    }
}