using DecisionViewpoints.Logic.Rules;
using DecisionViewpoints.Model;

namespace DecisionViewpoints.Logic.Validation
{
    public abstract class ElementRule : AbstractRule
    {
        public ElementRule(string errorMessage)
            : base(errorMessage)
        {
        }

        public override sealed RuleType GetRuleType()
        {
            return RuleType.Element;
        }

        public new abstract bool ValidateElement(EAElement element);
    }
}