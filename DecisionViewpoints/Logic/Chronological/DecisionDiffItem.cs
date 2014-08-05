using System;
using System.Linq;
using EAFacade.Model;
using EAFacade.Model.Baselines;

namespace DecisionViewpoints.Logic.Chronological
{
    internal class DecisionDiffItem
    {
        public DecisionDiffItem(DiffItem item, EAElement current)
        {
            Current = current;
            Guid = item.Guid;
            string dateModified = item.Properties.Where(p => p.Name.Equals("DateModified"))
                           .Select(p => p.BaselineValue).First();
            DateTime tmpDate;
            Modified = DateTime.MinValue;
            if (DateTime.TryParse(dateModified, out tmpDate))
            {
                Modified = tmpDate;
            }
            Stereotype = item.Properties.Where(p => p.Name.Equals("Stereotype"))
                             .Select(p => p.BaselineValue).First();
        }

        public EAElement Current { get; set; }
        public string Guid { get; set; }
        public DateTime Modified { get; set; }
        public string Stereotype { get; set; }

        public static int CompareByDateModified(DecisionDiffItem x, DecisionDiffItem y)
        {
            return DateTime.Compare(x.Modified, y.Modified);
        }
    }
}