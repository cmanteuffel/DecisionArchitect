using DecisionViewpoints.Logic.Rules;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Validation
{
    internal class NoLoopRule : ConnectorRule
    {
        public NoLoopRule(string errorMessage) : base(errorMessage)
        {
        }

        public override bool ValidateConnector(EAConnectorWrapper connector)
        {
            if (connector.SupplierId == connector.ClientId)
            {
                return false;
            }
            return true;
        }
    }
}