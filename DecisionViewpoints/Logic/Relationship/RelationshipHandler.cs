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

using System.Windows.Forms;
using EAFacade;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Relationship
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
                var diagram = EAFacade.EA.Repository.GetDiagramByGuid(guid);
                if (!diagram.IsRelationshipView()) return;
                diagram.HideConnectors(new[]
                {
                    EAConstants.RelationFollowedBy
                });
                
            }
        }

    }
}
