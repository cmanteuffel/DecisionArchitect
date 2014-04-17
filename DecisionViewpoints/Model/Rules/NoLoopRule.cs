using DecisionViewpoints.Model.Rules;

namespace DecisionViewpoints.Model.Rules
{
    internal class NoLoopRule : ConnectorRule
    {
        private readonly string _errorMessage;

        public NoLoopRule(string errorMessage)
        {
            _errorMessage = errorMessage;
        }

        public override bool ValidateConnector(EAConnectorWrapper connectorWrapper, out string message)
        {
            message = "";
            if (connectorWrapper.SupplierId == connectorWrapper.ClientId)
            {
                message = _errorMessage;
                return false;
            }
            return true;
        }
    }
}