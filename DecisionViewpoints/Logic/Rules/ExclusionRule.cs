using System.Collections.Generic;
using DecisionViewpoints.Model;

namespace DecisionViewpoints.Logic.Rules
{
    internal class ExclusionRule : ConnectorRule
    {
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

        public override bool ValidateConnector(EAConnectorWrapper connector)
        {
            if (_relationType.Count == 0 || _relationType.Contains(connector.Stereotype))
            {
                if (_clientState.Count == 0 || _clientState.Contains(connector.GetClient().GetStereotypeList()))
                {
                    if (_supplierState.Count == 0 ||
                        _supplierState.Contains(connector.GetSupplier().GetStereotypeList()))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static readonly string[] Any = new string[0];
    }
}