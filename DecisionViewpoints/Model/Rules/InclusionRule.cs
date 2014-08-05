using System.Collections.Generic;
using DecisionViewpoints.Model.Rules;

namespace DecisionViewpoints.Model.Rules
{
    internal class InclusionRule : ConnectorRule
    {
        private readonly HashSet<string> _clientState = new HashSet<string>();
        private readonly HashSet<string> _relationType = new HashSet<string>();
        private readonly HashSet<string> _supplierState = new HashSet<string>();
        private readonly string _errorMessage;

        public InclusionRule(IEnumerable<string> clientStates, IEnumerable<string> relationTypes,
                             IEnumerable<string> supplierStates, string errorMessage)
        {
            _errorMessage = errorMessage;
            _clientState.UnionWith(clientStates);
            _relationType.UnionWith(relationTypes);
            _supplierState.UnionWith(supplierStates);
        }

        public override bool Validate(PreConnector connector, out string message)
        {
            message = _errorMessage;
            if (_relationType.Count == 0 || _relationType.Contains(connector.Stereotype))
            {
                if (_clientState.Count == 0 || _clientState.Contains(connector.GetClient().GetStereotypeList()))
                {
                    if (_supplierState.Count == 0 ||
                        _supplierState.Contains(connector.GetSupplier().GetStereotypeList()))
                    {
                        message = "";
                        return true;
                    }
                }
            }
            return false;
        }
    }
}