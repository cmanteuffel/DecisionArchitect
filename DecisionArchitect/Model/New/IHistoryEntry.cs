using System;
using System.ComponentModel;
using System.Globalization;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Model.New
{
    public interface IHistoryEntry : IPersistableModel, INotifyPropertyChanged 
    {
        string State { get; set; }
        DateTime Modified { get; set; }
        IDecision Decision { get; }
        string TaggedValueGUID { get; }
    }

    public class HistoryEntry : Entity, IHistoryEntry
    {
        private const char Separator = '|';
        private static readonly CultureInfo Culture = CultureInfo.InvariantCulture;
        private DateTime _modified;
        private string _state;


        public HistoryEntry(IDecision decision, string state, DateTime modified)
        {
            State = state;
            Modified = modified;
            TaggedValueGUID = "";
            Decision = decision;
        }

        internal HistoryEntry(IDecision decision, IEATaggedValue taggedValue)
        {
            TaggedValueGUID = taggedValue.GUID;
            Decision = decision;
            if (IsHistoryTag(taggedValue.Name))
            {
                Deserialize(taggedValue.Value);
            }
            else throw new Exception();
        }

        public IDecision Decision { get; private set; }
        public string TaggedValueGUID { get; private set; }

        public string State
        {
            get { return _state; }
            set { SetField(ref _state, value, "State"); }
        }

        public DateTime Modified
        {
            get { return _modified; }
            set { SetField(ref _modified, value, "Modified"); }
        }


        public bool SaveChanges()
        {
            IEARepository repository = EAMain.Repository;
            //should not happen, need to know where the History Entry should be saved.
            if (null == Decision) throw new Exception();

            //detect if it is a new history entry
            if ("".Equals(TaggedValueGUID))
            {
                IEAElement element = repository.GetElementByGUID(Decision.GUID);
                element.AddTaggedValue(EATaggedValueKeys.DecisionStateChange, Serialize());
            }
            else
            {
                //only update
                IEAElement element = repository.GetElementByGUID(Decision.GUID);
                return element.UpdateTaggedValue(TaggedValueGUID, EATaggedValueKeys.DecisionStateChange, Serialize());
            }
            return true;
        }

        public void DiscardChanges()
        {
            if ("".Equals(TaggedValueGUID))
            {
                //no changes have been saved to the repository, its a fresh history entry
            }
            else
            {
                IEARepository repository = EAMain.Repository;
                //should not happen, need to know where the History Entry should be loaded from.
                if (null == Decision) throw new Exception();
                IEAElement element = repository.GetElementByGUID(Decision.GUID);
                IEATaggedValue taggedValue = element.GetTaggedValueByGUID(TaggedValueGUID);
                Deserialize(taggedValue.Value);
            }
        }


        private string Serialize()
        {
            return String.Format("{0}" + Separator + "{1}", State, Modified.ToString(Culture));
        }

        private void Deserialize(string serializedValue)
        {
            State = serializedValue.Split(Separator)[0];
            string dateString = serializedValue.Split(Separator)[1];
            Modified = Utilities.TryParseDateTime(dateString, DateTime.MinValue, Culture);
        }

        private bool IsHistoryTag(string name)
        {
            return name.StartsWith(EATaggedValueKeys.DecisionStateChange);
        }
    }
}