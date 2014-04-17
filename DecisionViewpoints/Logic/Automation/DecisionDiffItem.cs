using System;
using System.Linq;
using DecisionViewpoints.Model;
using DecisionViewpoints.Model.Baselines;

namespace DecisionViewpoints.Logic.Automation
{
    internal class DecisionDiffItem
    {
        public DecisionDiffItem(DiffItem item, EAElement current)
        {
            Current = current;
            Guid = item.Guid;
            Modified = item.Properties.Where(p => p.Name.Equals("DateModified"))
                           .Select(p => p.BaselineValue).First();
            Stereotype = item.Properties.Where(p => p.Name.Equals("Stereotype"))
                             .Select(p => p.BaselineValue).First();
        }

        public EAElement Current { get; set; }
        public string Guid { get; set; }
        public string Modified { get; set; }
        public string Stereotype { get; set; }

        public static int CompareByDateModified(DecisionDiffItem x, DecisionDiffItem y)
        {
            return String.Compare(x.Modified, y.Modified, StringComparison.Ordinal);
        }
    }
}