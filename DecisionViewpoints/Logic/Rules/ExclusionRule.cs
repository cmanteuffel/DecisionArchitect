using System.Collections.Generic;
using DecisionViewpoints.Logic.Rules;

namespace DecisionViewpoints.Model.Rules
{
    internal class ExclusionRule : ConnectorRule
    {
        private readonly HashSet<string> _clientState = new HashSet<string>();
        private readonly string _errorMessage;
        private readonly HashSet<string> _relationType = new HashSet<string>();
        private readonly HashSet<string> _supplierState = new HashSet<string>();

        public ExclusionRule(IEnumerable<string> clientStates, IEnumerable<string> relationTypes,
                             IEnumerable<string> supplierStates, string errorMessage)
        {
            _errorMessage = errorMessage;
            _clientState.UnionWith(clientStates);
            _relationType.UnionWith(relationTypes);
            _supplierState.UnionWith(supplierStates);
        }

        public override bool ValidateConnector(EAConnectorWrapper connectorWrapper, out string message)
        {
            message = "";
            if (_relationType.Count == 0 || _relationType.Contains(connectorWrapper.Stereotype))
            {
                if (_clientState.Count == 0 || _clientState.Contains(connectorWrapper.GetClient().GetStereotypeList()))
                {
                    if (_supplierState.Count == 0 ||
                        _supplierState.Contains(connectorWrapper.GetSupplier().GetStereotypeList()))
                    {
                        message = _errorMessage;
                        return false;
                    }
                }
            }
            return true;
        }
    }
}