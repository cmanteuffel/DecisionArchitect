using EAFacade.Model;

namespace DecisionViewpoints.Logic.Validation
{
    internal class NoLoopRule : ConnectorRule
    {
        public NoLoopRule(string errorMessage) : base(errorMessage)
        {
        }

        public override bool ValidateConnector(EAConnector connector)
        {
            if (connector.SupplierId == connector.ClientId)
            {
                return false;
            }
            return true;
        }
    }
}