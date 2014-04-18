using System.Linq;
using EAFacade;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Validation
{
    internal class NameUniquenessRule : ElementRule
    {
        public NameUniquenessRule(string errorMessage)
            : base(errorMessage)
        {
        }

        public override bool ValidateElement(IEAElement element)
        {
            var repository = EAFacade.EA.Repository;
            return !(from IEAElement e in repository.GetAllElements()
                     where EAConstants.States.Contains(e.Stereotype)
                     where (!e.GUID.Equals(element.GUID))
                     where element.Name.Equals(e.Name)
                     select e).Any();
        }
    }
}
