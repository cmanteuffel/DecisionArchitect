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

using DecisionArchitect.Logic.Validation;
using EA;

namespace DecisionArchitect
{
    public partial class MainApplication
    {
        private ModelValidator _modelValidator;

        public override void EA_OnInitializeUserRules(Repository repository)
        {
            EAFacade.EA.UpdateRepository(repository);
            _modelValidator = ModelValidator.Initialize(repository);
        }

        public override void EA_OnStartValidation(Repository repository, params object[] args)
        {
            EAFacade.EA.UpdateRepository(repository);
            _modelValidator.OnStart(repository, args);
        }

        public override void EA_OnRunConnectorRule(Repository repository, string ruleId, int connectorId)
        {
            EAFacade.EA.UpdateRepository(repository);
            var connector = EAFacade.EA.Repository.GetConnectorByID(connectorId);
            _modelValidator.ValidateConectorUsingRuleID(repository, ruleId, connector);
        }

        public override void EA_OnRunElementRule(Repository repository, string ruleId, Element element)
        {
            EAFacade.EA.UpdateRepository(repository);
            var wrappedElement = EAFacade.EA.WrapElement(element);
            _modelValidator.ValidateElementUsingRuleID(repository, ruleId, wrappedElement);
        }
    }
}
