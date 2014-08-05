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

namespace DecisionArchitect.Logic.StakeholderInvolvement
{
    public class StakeholderInvolvementHandler : RepositoryAdapter
    {
        public override void OnPostOpenDiagram(IEADiagram diagram)
        {
            if (!diagram.IsStakeholderInvolvementView()) return;
            diagram.HideConnectors(new[]
                {
                    EAConstants.RelationAlternativeFor, EAConstants.RelationCausedBy,
                    EAConstants.RelationDependsOn, EAConstants.RelationExcludedBy,
                    EAConstants.RelationReplaces, EAConstants.RelationFollowedBy
                });
        }
    }
}
