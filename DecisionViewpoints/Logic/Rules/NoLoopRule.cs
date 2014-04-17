using DecisionViewpoints.Model;

namespace DecisionViewpoints.Logic.Rules
{
    internal class NoLoopRule : ConnectorRule
    {
        public NoLoopRule(string errorMessage) : base(errorMessage)
        {
        }

        public override bool ValidateConnector(EAConnectorWrapper connectorWrapper, out string message)
        {
            message = "";
            if (connectorWrapper.SupplierId == connectorWrapper.ClientId)
            {
                message = getErrorMessage();
                return false;
            }
            return true;
        }

    }
}