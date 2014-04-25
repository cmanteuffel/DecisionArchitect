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

using System.Linq;
using EAFacade;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Validation
{
    internal class NameUniquenessRule : ElementRule
    {
        public NameUniquenessRule(string errorMessage)
            : base(errorMessage)
        {
        }

        public override bool ValidateElement(IEAElement element)
        {
            var repository = EAFacade.EA.Repository;
            return !(from IEAElement e in repository.GetAllElements()
                     where EAConstants.States.Contains(e.Stereotype)
                     where (!e.GUID.Equals(element.GUID))
                     where element.Name.Equals(e.Name)
                     select e).Any();
        }
    }
}
