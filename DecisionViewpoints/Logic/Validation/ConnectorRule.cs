using DecisionViewpoints.Logic.Validation;
using EAWrapper.Model;

namespace DecisionViewpoints.Logic.Rules
{
    public abstract class ConnectorRule : AbstractRule
    {
        
        protected ConnectorRule(string errorMessage) : base(errorMessage)
        {
        }

        public override sealed RuleType GetRuleType()
        {
            return RuleType.Connector;
        }

        public new abstract bool ValidateConnector(EAConnectorWrapper element);
  
    }
}