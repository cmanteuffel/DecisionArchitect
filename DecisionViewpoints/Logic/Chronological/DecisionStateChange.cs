using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Chronological
{
    class DecisionStateChange
    {
        public EAElement Element { get; set; }
        public DateTime DateModified { get; set; }
        public String State { get; set; }

        public static int CompareByDateModified(DecisionStateChange x, DecisionStateChange y)
        {
            return DateTime.Compare(x.DateModified, y.DateModified);
        }

        public static IEnumerable<DecisionStateChange> GetHistory(EAElement element)
        {
            var history = from taggedValue in element.TaggedValues
                          where IsHistoryTag(taggedValue.Name)
                          select new DecisionStateChange
                          {
                              Element = element,
                              DateModified = GetDateModifiedFromTaggedValue(taggedValue.Value),
                              State = GetStateFromTaggedValue(taggedValue.Value),
                          };
            return history;
        }

        public static void SaveStateChange(EAElement element, String newState, DateTime dateModified)
        {
            element.AddTaggedValue(DVTaggedValueKeys.DecisionStateChange,
                                   string.Format("{0}|{1}", newState, DateTime.Now.ToString(CultureInfo.InvariantCulture)));
        }

        private static String GetStateFromTaggedValue(string value)
        {
            return value.Split('|')[0];
        }

        private static DateTime GetDateModifiedFromTaggedValue(string value)
        {
            return DateTime.Parse(value.Split('|')[1]);
        }

        private static bool IsHistoryTag(string name)
        {
            return name.StartsWith(DVTaggedValueKeys.DecisionStateChange);
        }
    }
}