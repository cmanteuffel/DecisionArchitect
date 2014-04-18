using System;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Chronological
{
    public class DecisionStateChange
    {
        public IEAElement Element { get; set; }
        public DateTime DateModified { get; set; }
        public String State { get; set; }

        public static int CompareByDateModified(DecisionStateChange x, DecisionStateChange y)
        {
            return DateTime.Compare(x.DateModified, y.DateModified);
        }
    }
}