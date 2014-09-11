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
        private IDecision _relatedDecision;
        private string _type;

        public DecisionRelation(Decision decision, IEAConnector eaConnector)
        {
            IEAElement client = eaConnector.GetClient();
            Direction = client.GUID.Equals(decision.GUID)
                            ? DecisionRelationDirection.Incoming
                            : DecisionRelationDirection.Outgoing;

            Decision = decision;
            RelationGUID = eaConnector.GUID;
            Type = eaConnector.Stereotype;
        }

        public IDecision Decision { get; private set; }

        public IDecision RelatedDecision
        {
            get
            {
                if (_relatedDecision == null)
                {
                    IEAConnector eaConnector = EAMain.Repository.GetConnectorByGUID(RelationGUID);
                    _relatedDecision =
                        New.Decision.Load(Direction == DecisionRelationDirection.Incoming
                                              ? eaConnector.GetSupplier()
                                              : eaConnector.GetClient());
                }
                return _relatedDecision;
            }
        }

        public DecisionRelationDirection Direction { get; set; }

        public string Type
        {
            get { return _type; }
            set { SetField(ref _type, value, "Type"); }
        }

        public string DirectedType
        {
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
                }
                else if (EAConstants.InverseRelationships.Contains(value))
                {
                    Direction = DecisionRelationDirection.Outgoing;
                    Type = EAConstants.ConvertToRelationship[value];
                }
            }
        }

        public string RelationGUID { get; private set; }
    }
}