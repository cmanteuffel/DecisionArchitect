using System;
using System.Globalization;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.General
{
    internal class DecisionStateModifedDateHandler : RepositoryAdapter
    {
        public override bool OnPostNewElement(EAElement element)
        {
            if (element.IsDecision())
            {
                element.AddTaggedValue(DVTaggedValueKeys.DecisionState, element.Stereotype);
                element.AddTaggedValue(DVTaggedValueKeys.DecisionStateModifiedDate,
                                       element.Modified.ToString(CultureInfo.InvariantCulture));
            }
            return true;
        }

        public override void OnNotifyContextItemModified(string guid, NativeType type)
        {
            if (type != NativeType.Element) return;
            var element = EARepository.Instance.GetElementByGUID(guid);
            if (!element.IsDecision()) return;
            var oldState = element.GetTaggedValue(DVTaggedValueKeys.DecisionState);
            if (oldState == null || element.Stereotype.Equals(oldState)) return;
            // TODO: create tagged value with old state
            var name = string.Format("{0}:{1}", DVTaggedValueKeys.DecisionHistoryState, Guid.NewGuid());
            var data = string.Format("{0}:{1}", oldState, element.Modified.ToString(CultureInfo.InvariantCulture));
            element.AddTaggedValue(name, data);
            element.UpdateTaggedValue(DVTaggedValueKeys.DecisionStateModifiedDate,
                                      element.Modified.ToString(CultureInfo.InvariantCulture));
            element.UpdateTaggedValue(DVTaggedValueKeys.DecisionState, element.Stereotype);
        }
    }
}