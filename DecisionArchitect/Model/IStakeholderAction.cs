/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
*/

using EAFacade.Model;

namespace DecisionArchitect.Model
{
    public interface IStakeholderAction
    {
        string Action { get; }
        IStakeholder Stakeholder { get; }
        string ConnectorGUID { get; }
        IDecision Decision { get; }
    }

    public class StakeholderAction : IStakeholderAction
    {
        public StakeholderAction(IDecision decision, IEAConnector connector)
        {
            Stakeholder = Model.Stakeholder.Load(connector.GetClient());
            Action = connector.Stereotype;
            ConnectorGUID = connector.GUID;
            Decision = decision;
        }

        public string Action { get; private set; }
        public IStakeholder Stakeholder { get; private set; }
        public string ConnectorGUID { get; private set; }
        public IDecision Decision { get; private set; }
    }
}