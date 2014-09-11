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

using System.Collections.Generic;
using EAFacade.Model;

namespace DecisionArchitect.Logic.Validation
{
    internal class ExclusionRule : ConnectorRule
    {
        public static readonly string[] Any = new string[0];
        private readonly HashSet<string> _clientState = new HashSet<string>();
        private readonly HashSet<string> _relationType = new HashSet<string>();
        private readonly HashSet<string> _supplierState = new HashSet<string>();

        public ExclusionRule(string errorMessage, IEnumerable<string> clientStates, IEnumerable<string> relationTypes,
                             IEnumerable<string> supplierStates) : base(errorMessage)
        {
            _clientState.UnionWith(clientStates);
            _relationType.UnionWith(relationTypes);
            _supplierState.UnionWith(supplierStates);
        }

        public override bool ValidateConnector(IEAConnector connector)
        {
            if (_relationType.Count == 0 || _relationType.Contains(connector.Stereotype))
            {
                if (_clientState.Count == 0 || _clientState.Contains(connector.GetClient().Stereotype))
                {
                    if (_supplierState.Count == 0 ||
                        _supplierState.Contains(connector.GetSupplier().Stereotype))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}