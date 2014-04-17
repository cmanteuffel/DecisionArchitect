using System;
using System.Linq;
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
            var repository = EARepository.Instance;
            return !(from EAElement e in repository.GetAllElements()
                     where DVStereotypes.States.Contains(e.Stereotype)
                     where (!e.GUID.Equals(element.GUID))
                     where element.Name.Equals(e.Name)
                     select e).Any();
        }
    }
}
