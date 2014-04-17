namespace DecisionViewpoints.Model.Rules
{
    internal abstract class ConnectorRule
    {
        public static readonly string[] Any = new string[0];
        public abstract bool Validate(PreConnector connector, out string message);
    }
}