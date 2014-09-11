using EAFacade.Model;

namespace DecisionArchitect.Model
{
    public interface IStakeholderAction
    {
        string Action { get; }
        IStakeholder Stakeholder { get; }
        string ConnectorGUID { get; }
        IDecision Decision { get; }
    }

    public class StakeholderAction : IStakeholderAction
    {
        public StakeholderAction(IDecision decision, IEAConnector connector)
        {
            Stakeholder = Model.Stakeholder.Load(connector.GetClient());
            Action = connector.Stereotype;
            ConnectorGUID = connector.GUID;
            Decision = decision;
        }

        public string Action { get; private set; }
        public IStakeholder Stakeholder { get; private set; }
        public string ConnectorGUID { get; private set; }
        public IDecision Decision { get; private set; }
    }
}