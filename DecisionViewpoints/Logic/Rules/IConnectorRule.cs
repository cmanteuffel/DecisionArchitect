using DecisionViewpoints.Model;

namespace DecisionViewpoints.Logic.Rules
{
    internal interface IConnectorRule
    {
        bool ValidateConnector(EAConnectorWrapper connectorWrapper, out string message);
        string getErrorMessage();
    }
}