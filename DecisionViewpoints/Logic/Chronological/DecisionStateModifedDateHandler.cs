using EAFacade.Model;

namespace DecisionViewpoints.Logic.Chronological
{
    class DecisionStateModifedDateHandler : RepositoryAdapter
    {
        public override bool OnPostNewElement(EAElement element)
        {
            if (element.IsDecision()) {
                element.AddTaggedValue(DVTaggedValueKeys.DecisionState,element.Stereotype);
                element.AddTaggedValue(DVTaggedValueKeys.DecisionStateModifiedDate, element.Modified.ToString());
            }
            return true;
        }

        public override void OnNotifyContextItemModified(string guid, NativeType type) {

            if (type == NativeType.Element)
            {
                EAElement element = EARepository.Instance.GetElementByGUID(guid);
                if (element.IsDecision())
                {
                    string oldState = element.GetTaggedValue(DVTaggedValueKeys.DecisionState);
                    if (oldState != null && !element.Stereotype.Equals(oldState))
                    {
                        element.UpdateTaggedValue(DVTaggedValueKeys.DecisionStateModifiedDate, element.Modified.ToString());
                        element.UpdateTaggedValue(DVTaggedValueKeys.DecisionState, element.Stereotype);
                    }
                }
            }
            
        }
    }
}
