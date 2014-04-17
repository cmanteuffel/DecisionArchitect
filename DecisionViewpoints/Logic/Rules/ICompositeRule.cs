namespace DecisionViewpoints.Logic.Rules
{
    internal interface ICompositeRule : IConnectorRule
    {
        void Add(ConnectorRule rule);
        void Remove(ConnectorRule rule);
    }
}