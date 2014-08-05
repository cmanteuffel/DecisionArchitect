using System.Collections.Generic;
using System.Collections.ObjectModel;
using DecisionViewpoints.Model.Rules;

namespace DecisionViewpoints.Model.Rules
{
    internal class CompositeRule : ConnectorRule, ICompositeRule
    {
        private readonly ICollection<ConnectorRule> _childRules = new Collection<ConnectorRule>();

        public override bool ValidateConnector(EAConnectorWrapper connectorWrapper, out string message)
        {
            message = "";
            foreach (ConnectorRule rule in _childRules)
            {
                if (!rule.ValidateConnector(connectorWrapper, out message))
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