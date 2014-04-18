using EAFacade.Model;

namespace DecisionViewpoints.Logic.Validation
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

        public new abstract bool ValidateConnector(IEAConnector connector);
  
    }
}