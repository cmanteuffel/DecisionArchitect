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

        public override bool ValidateConnector(PreConnector connector, out string message)
        {
            message = "";
            if (connector.SupplierId == connector.ClientId)
            {
                message = _errorMessage;
                return false;
            }
            return true;
        }
    }
}