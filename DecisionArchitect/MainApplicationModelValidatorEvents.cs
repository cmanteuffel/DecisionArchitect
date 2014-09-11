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
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect
{
    public partial class MainApplication
    {
        private ModelValidator _modelValidator;

        public override void EA_OnInitializeUserRules(Repository repository)
        {
            EAMain.UpdateRepository(repository);
            _modelValidator = ModelValidator.Initialize(repository);
        }

        public override void EA_OnStartValidation(Repository repository, params object[] args)
        {
            EAMain.UpdateRepository(repository);
            _modelValidator.OnStart(repository, args);
        }

        public override void EA_OnRunConnectorRule(Repository repository, string ruleId, int connectorId)
        {
            EAMain.UpdateRepository(repository);
            IEAConnector connector = EAMain.Repository.GetConnectorByID(connectorId);
            _modelValidator.ValidateConectorUsingRuleID(repository, ruleId, connector);
        }

        public override void EA_OnRunElementRule(Repository repository, string ruleId, Element element)
        {
            EAMain.UpdateRepository(repository);
            IEAElement wrappedElement = EAMain.WrapElement(element);
            _modelValidator.ValidateElementUsingRuleID(repository, ruleId, wrappedElement);
        }
    }
}