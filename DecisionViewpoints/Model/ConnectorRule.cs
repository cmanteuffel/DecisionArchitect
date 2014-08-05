using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace DecisionViewpoints.Model
{
    internal abstract class ConnectorRule
    {
        public static readonly string[] Any = new string[0];
        public abstract bool Validate(PreConnector connector, out string message);
    }

    internal class ExclusionConnectorRule : ConnectorRule
    {
        private readonly HashSet<string> _clientState = new HashSet<string>();
        private readonly HashSet<string> _relationType = new HashSet<string>();
        private readonly HashSet<string> _supplierState = new HashSet<string>();
        private readonly string _errorMessage;

        public ExclusionConnectorRule(IEnumerable<string> clientStates, IEnumerable<string> relationTypes,
                                      IEnumerable<string> supplierStates, string errorMessage)
        {
            _errorMessage = errorMessage;
            _clientState.UnionWith(clientStates);
            _relationType.UnionWith(relationTypes);
            _supplierState.UnionWith(supplierStates);
        }

        public override bool Validate(PreConnector connector, out string message)
        {
            message = "";
            if (_relationType.Count == 0 || _relationType.Contains(connector.Stereotype))
            {
                if (_clientState.Count == 0 || _clientState.Contains(connector.GetClient().GetStereotypeList()))
                {
                    if (_supplierState.Count == 0 ||
                        _supplierState.Contains(connector.GetSupplier().GetStereotypeList()))
                    {
                        message = _errorMessage;
                        return false;
                    }
                }
            }
            return true;
        }
    }

    internal class InclusionConnectorRule : ConnectorRule
    {
        private readonly HashSet<string> _clientState = new HashSet<string>();
        private readonly HashSet<string> _relationType = new HashSet<string>();
        private readonly HashSet<string> _supplierState = new HashSet<string>();
        private readonly string _errorMessage;

        public InclusionConnectorRule(IEnumerable<string> clientStates, IEnumerable<string> relationTypes,
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

    internal interface ICompositeRule
    {
        void Add(ConnectorRule rule);
        void Remove(ConnectorRule rule);
    }

    internal class CompositeRule : ConnectorRule, ICompositeRule
    {
        private readonly ICollection<ConnectorRule> _childRules = new Collection<ConnectorRule>();

        public override bool Validate(PreConnector connector, out string message)
        {
            message = "";
            foreach (ConnectorRule rule in _childRules)
            {
                if (!rule.Validate(connector, out message))
                {
                    return false;
                }
            }
            return true;
        }

        public void Add(ConnectorRule rule)
        {
            _childRules.Add(rule);
        }

        public void Remove(ConnectorRule rule)
        {
            _childRules.Remove(rule);
        }
    }
}