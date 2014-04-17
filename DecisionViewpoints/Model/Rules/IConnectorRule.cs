namespace DecisionViewpoints.Model.Rules
{
    internal interface IConnectorRule
    {
        bool ValidateConnector(EAConnectorWrapper connectorWrapper, out string message);
    }
}