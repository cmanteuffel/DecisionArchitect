using DecisionViewpoints.Model;

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
  
    }
}