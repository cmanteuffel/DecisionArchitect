using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using DecisionArchitect.Model;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.View.Forces
{
    public class DecisionEvaluation: Entity, IPersistableModel
    {
        public IDecision Decision { get; set; }


        private string _rating;
        private string _rationale;
        private int _color;

        public string Rating
        {
            get { return _rating; }
            set { SetField(ref _rating, value, "Rating"); }
        }

        public string Rationale
        {
            get { return _rationale; }
            set { SetField(ref _rationale, value, "Rationale"); }
        }

        public int BackgroundColor
        {
            get { return _color; }
            set { SetField(ref _color, value, "BackgroundColor"); }
        }

        private IConcern Concern { get; set; }
        private IForce Force { get; set; }

        private readonly string RatingTag = "Rating";
        private const string RationaleTag = "Rationale";
        private const string ColorTag = "Color";

        public DecisionEvaluation(IDecision decision, IConcern concern, IForce force)
        {
            Decision = decision;
            Concern = concern;
            Force = force;
            var connector = GetConnector(Force.Element);
            
            if (connector == null)
            {
                Rating = string.Empty;
                Rationale = string.Empty;
                BackgroundColor = Color.White.ToArgb();
                Changed = true; //this is new so it has changed
                PropertyChanged += OnPropertyChanged;
                return;
            }
            Rating = connector.GetTaggedValueByName(RatingTag);
            Rationale = connector.GetTaggedValueByName(RationaleTag);
            int temp;
            int.TryParse(connector.GetTaggedValueByName(ColorTag), out temp);
            BackgroundColor = temp;

            PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Changed")) return;
            Changed = true;
        }

        private IEAConnector GetConnector(IEAElement forceElement)
        {
            return (from x in forceElement.GetConnectors()
             where
                 x.GetSupplier().GUID.Equals(Decision.GUID) && x.TaggedValueExists(EAConstants.ConcernUID) &&
                 x.GetTaggedValueByName(EAConstants.ConcernUID).Equals(Concern.UID)
             select x).FirstOrDefault();
        }

        public bool Changed { get; private set; }
        public bool SaveChanges()
        {
            var forceElement = Force.Element;
            var connector = GetConnector(forceElement);
            if (connector == null)
            {
                var decisionElement = EAMain.Repository.GetElementByGUID(Decision.GUID);
                connector = forceElement.ConnectTo(decisionElement, EAConstants.RelationTrace, EAConstants.RelationTrace);
                connector.AddTaggedValue(EAConstants.ConcernUID, Concern.UID);
                connector.AddTaggedValue(RatingTag, Rating);
                connector.AddTaggedValue(RationaleTag, Rationale);
                connector.AddTaggedValue(ColorTag, BackgroundColor.ToString());
            }
            else
            {
                connector.UpdateTaggedValue(RatingTag, Rating);
                connector.UpdateTaggedValue(RationaleTag, Rationale);
                connector.UpdateTaggedValue(ColorTag, BackgroundColor.ToString());
            }
            return true;
        }

        public void Delete(IEAElement forceElement)
        {
            var connector = GetConnector(forceElement);
            if (connector != null)
                forceElement.RemoveConnector(connector);
        }

        public void DiscardChanges()
        {
            throw new NotImplementedException();
        }
    }

}
