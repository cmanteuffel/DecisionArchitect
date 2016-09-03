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

using System.Globalization;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Logic.EventHandler
{
    internal class DecisionStateChangeEventHandler : RepositoryAdapter
    {
        public override bool OnPostNewElement(IEAElement element)
        {
            if (EAMain.IsDecision(element))
            {
                element.AddTaggedValue(EATaggedValueKeys.DecisionState, element.Stereotype);
                element.AddTaggedValue(EATaggedValueKeys.IsHistoryDecision, false.ToString());
            }
            if (EAMain.IsDecision(element) || EAMain.IsTopic(element))
            {
                element.AddTaggedValue(EATaggedValueKeys.DecisionStateModifiedDate,
                                       element.Modified.ToString(CultureInfo.InvariantCulture));
            }
            return true;
        }
    }
}