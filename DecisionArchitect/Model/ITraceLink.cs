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
    public interface ITraceLink
    {
        string TracedElementGUID { get; }
        string TracedElementName { get; }
        string ConnectorGUID { get; }
    }

    public class TraceLink : ITraceLink
    {
        public TraceLink(IDecision decision, IEAConnector connector)
        {
            IEAElement tracedElement = (connector.ClientId == decision.ID)
                                           ? connector.GetSupplier()
                                           : connector.GetClient();

            TracedElementGUID = tracedElement.GUID;
            TracedElementName = tracedElement.Name;
            ConnectorGUID = connector.GUID;
        }

        public string TracedElementGUID { get; private set; }
        public string TracedElementName { get; private set; }
        public string ConnectorGUID { get; private set; }
    }
}