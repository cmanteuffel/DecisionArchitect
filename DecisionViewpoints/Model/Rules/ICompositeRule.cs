using DecisionViewpoints.Model.Rules;

namespace DecisionViewpoints.Model.Rules
{
    internal interface ICompositeRule : IConnectorRule
    {
        void Add(ConnectorRule rule);
        void Remove(ConnectorRule rule);
    }
}