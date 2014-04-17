using DecisionViewpoints.Model;

namespace DecisionViewpoints.Logic.Rules
{
    internal abstract class ConnectorRule : IConnectorRule
    {
        public static readonly string[] Any = new string[0];
        public abstract bool ValidateConnector(EAConnectorWrapper connectorWrapper, out string message);
    }
}