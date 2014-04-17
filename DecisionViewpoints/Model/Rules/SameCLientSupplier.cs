using DecisionViewpoints.Model.Rules;

namespace DecisionViewpoints.Model.Rules
{
    internal class SameClientSupplier : ConnectorRule
    {
        private readonly string _errorMessage;

        public SameClientSupplier(string errorMessage)
        {
            _errorMessage = errorMessage;
        }

        public override bool Validate(PreConnector connector, out string message)
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