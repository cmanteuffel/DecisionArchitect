namespace DecisionViewpoints.Model.Rules
{
    internal interface IConnectorRule
    {
        bool ValidateConnector(PreConnector connector, out string message);
    }
}