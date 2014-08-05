using System;
using System.Globalization;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Chronological
{
    internal class ModifedDateHandler : RepositoryAdapter
    {
        public override bool OnPostNewElement(IEAElement element)
        {
            if (element.IsDecision())
            {
                element.AddTaggedValue(EATaggedValueKeys.DecisionState, element.Stereotype);
                element.AddTaggedValue(EATaggedValueKeys.IsHistoryDecision, false.ToString());
            }
            if (element.IsDecision() || element.IsTopic())
            {
                element.AddTaggedValue(EATaggedValueKeys.DecisionStateModifiedDate,
                                       element.Modified.ToString(CultureInfo.InvariantCulture));
            }
            return true;
        }

        public override void OnNotifyContextItemModified(string guid, EANativeType type)
        {
            if (type != EANativeType.Element) return;
            IEAElement element = EAFacade.EA.Repository.GetElementByGUID(guid);
            if (element.IsDecision())
            {
                string oldState = element.GetTaggedValue(EATaggedValueKeys.DecisionState);
                if (oldState == null || element.Stereotype.Equals(oldState)) return;
                // TODO: create tagged value with old state
                string name = string.Format("{0}:{1}", EATaggedValueKeys.DecisionHistoryState, Guid.NewGuid());
                string data = string.Format("{0}:{1}", oldState, element.Modified.ToString(CultureInfo.InvariantCulture));
                element.AddTaggedValue(name, data);
                element.UpdateTaggedValue(EATaggedValueKeys.DecisionStateModifiedDate,
                                          element.Modified.ToString(CultureInfo.InvariantCulture));
                element.UpdateTaggedValue(EATaggedValueKeys.DecisionState, element.Stereotype);
            }
        }
    }
}