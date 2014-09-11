using System.ComponentModel;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Model.New
{
    public interface IDecisionRelation : INotifyPropertyChanged
    {
        IDecision Decision { get; }
        IDecision RelatedDecision { get; }
        DecisionRelationDirection Direction { get; }
        string Type { get; set; }
        string DirectedType { get; set; }
        string RelationGUID { get; }
    }

    public enum DecisionRelationDirection
    {
        Incoming,
        Outgoing
    }

    public class DecisionRelation : Entity, IDecisionRelation
    {
        private string _type;

        public DecisionRelation(Decision decision, IEAConnector eaConnector)
        {
            IEAElement client = eaConnector.GetClient();
            IEAElement supplier = eaConnector.GetSupplier();
            if (client.GUID.Equals(decision.GUID))
            {
                Decision = decision;
                RelatedDecision = New.Decision.Load(supplier);
                Direction = DecisionRelationDirection.Incoming;
            }
            else
            {
                Decision = decision;
                RelatedDecision = New.Decision.Load(client);
                Direction = DecisionRelationDirection.Outgoing;
            }
            RelationGUID = eaConnector.GUID;
            Type = eaConnector.Stereotype;
        }

        public IDecision Decision { get; private set; }
        public IDecision RelatedDecision { get; private set; }
        public DecisionRelationDirection Direction { get; set; }

        public string Type
        {
            get { return _type; }
            set { SetField(ref _type, value, "Type"); }
        }

        public string DirectedType {
            get
            {
                if (Direction == DecisionRelationDirection.Incoming)
                {
                    return EAConstants.ConvertInverse[Type];
                }
                return Type;
            } 
            set
            {
                if (EAConstants.Relationships.Contains(value))
                {
                    Type = value;
                    Direction = DecisionRelationDirection.Incoming;
                } else if (EAConstants.InverseRelationships.Contains(value))
                {
                    Direction = DecisionRelationDirection.Outgoing;
                    Type = EAConstants.ConvertToRelationship[value];
                }
            } }

        public string RelationGUID { get; private set; }
    }
}