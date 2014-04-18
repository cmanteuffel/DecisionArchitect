﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DecisionViewpoints.Model;
using EAFacade.Model;


namespace DecisionViewpoints.Logic.Chronological
{
    internal class DecisionStateChange
    {
        public IEAElement Element { get; set; }
        public DateTime DateModified { get; set; }
        public String State { get; set; }

        public static int CompareByDateModified(DecisionStateChange x, DecisionStateChange y)
        {
            return DateTime.Compare(x.DateModified, y.DateModified);
        }

        public static IEnumerable<DecisionStateChange> GetHistory(IEAElement element)
        {
            var decision = new Decision(element);
            IEnumerable<DecisionStateChange> history = decision.GetHistory().Select(entry => new DecisionStateChange
                {
                    Element = element,
                    DateModified = entry.Value,
                    State = entry.Key
                });

            return history;
        }

        public static void SaveStateChange(IEAElement element, String newState, DateTime dateModified)
        {
            element.AddTaggedValue(EATaggedValueKeys.DecisionStateChange,
                                   string.Format("{0}|{1}", newState,
                                                 DateTime.Now.ToString(CultureInfo.InvariantCulture)));
        }
    }
}