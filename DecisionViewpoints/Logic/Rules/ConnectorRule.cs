using DecisionViewpoints.Model;

namespace DecisionViewpoints.Logic.Rules
{
    internal abstract class ConnectorRule : IConnectorRule
    {
        private readonly string _errorMessage;
        

        public static readonly string[] Any = new string[0];

        protected ConnectorRule(string errorMessage)
        {
            _errorMessage = errorMessage;
        }

        public abstract bool ValidateConnector(EAConnectorWrapper connectorWrapper, out string message);
        public string getErrorMessage()
        {
            return _errorMessage;
        }
    
    }
}