using System;
using System.ComponentModel;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Model.New
{
    public interface IForceEvaluation : IPersistableModel, INotifyPropertyChanged
    {
        IForce Force { get; }
        IConcern Concern { get; }
        string Result { get; set; }
        string TaggedValueGUID { get; }
    }


    public class ForceEvaluation : Entity, IForceEvaluation
    {
        private const char Separator = ':';
        private readonly string _decisionGUID;
        private string _result;

        public ForceEvaluation(IDecision decision, IForce force, IConcern concern, string result)
        {
            _decisionGUID = decision.GUID;
            Force = force;
            Concern = concern;
            Result = result;
        }

        public ForceEvaluation(IDecision decision, IEATaggedValue taggedValue)
        {
            TaggedValueGUID = taggedValue.GUID;
            _decisionGUID = decision.GUID;
            if (IsForceTag(taggedValue.Name))
            {
                DeserializeName(taggedValue.Name);
                Result = taggedValue.Value;
            }
            else throw new Exception();
        }


        public IForce Force { get; private set; }
        public IConcern Concern { get; private set; }

        public string Result
        {
            get { return _result; }
            set { SetField(ref _result, value, "Result"); }
        }

        public string TaggedValueGUID { get; private set; }


        public bool SaveChanges()
        {
            IEARepository repository = EAMain.Repository;
            //should not happen, need to know where the evaluation result should be saved.
            if (null == _decisionGUID) throw new Exception();

            //detect if it is a new rating entry
            if ("".Equals(TaggedValueGUID))
            {
                IEAElement element = repository.GetElementByGUID(_decisionGUID);
                element.AddTaggedValue(SerializeName(), Result);
            }
            else
            {
                //only update
                IEAElement element = repository.GetElementByGUID(_decisionGUID);
                return element.UpdateTaggedValue(TaggedValueGUID, SerializeName(), Result);
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
                //should not happen, need to know where the rating should be loaded from.
                if (null == _decisionGUID) throw new Exception();
                IEAElement element = repository.GetElementByGUID(_decisionGUID);
                IEATaggedValue taggedValue = element.GetTaggedValueByGUID(TaggedValueGUID);
                DeserializeName(taggedValue.Name);
                Result = taggedValue.Value;
            }
        }

        private void DeserializeName(string value)
        {
            string forceGUID = value.Split(Separator)[1];
            string concernGUID = value.Split(Separator)[2];
            Force = new Force(forceGUID);
            Concern = new Concern(concernGUID);
        }

        private string SerializeName()
        {
            return String.Format(EATaggedValueKeys.ForceEvaluation + Separator + "{0}" + Separator + "{1}",
                                 Force.ForceGUID, Concern.ConcernGUID);
        }

        private bool IsForceTag(string name)
        {
            return name.StartsWith(EATaggedValueKeys.ForceEvaluation);
        }
    }
}