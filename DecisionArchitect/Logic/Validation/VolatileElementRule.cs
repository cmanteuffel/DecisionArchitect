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

using EAFacade.Model;

namespace DecisionArchitect.Logic.Validation
{
    public abstract class VolatileElementRule : AbstractRule
    {
        public VolatileElementRule(string errorMessage) : base(errorMessage)
        {
        }

        public override sealed RuleType GetRuleType()
        {
            return RuleType.VolatileElement;
        }

        public new abstract bool ValidateElement(IEAVolatileElement element);
    }
}