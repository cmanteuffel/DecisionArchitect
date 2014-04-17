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
                        message = getErrorMessage();
                        return false;
                    }
                }
            }
            return true;
        }
    }
}