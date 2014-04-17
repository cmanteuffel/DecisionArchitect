using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DecisionViewpoints.Model;
using EA;

namespace DecisionViewpoints.Logic.Rules
{
    internal class NameUniquenessRule : ElementRule
    {
        public NameUniquenessRule(string errorMessage)
            : base(errorMessage)
        {
        }

        public override bool ValidateElement(EAElement element)
        {
            return (element.Element == null) || !(from Element e in element.Repository.GetElementSet(null, 0)
                     where DVStereotypes.States.Contains(e.Stereotype)
                     where (!e.ElementGUID.Equals(element.Element.ElementGUID))
                     where element.Element.Name.Equals(e.Name)
                     select e).Any();
        }
    }
}
