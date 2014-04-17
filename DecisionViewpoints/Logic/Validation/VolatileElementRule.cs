using DecisionViewpoints.Logic.Rules;
using DecisionViewpoints.Model;

namespace DecisionViewpoints.Logic.Validation
{
    public abstract class VolatileElementRule : AbstractRule
    {
        public VolatileElementRule(string errorMessage) : base(errorMessage)
        {
        }

        public override sealed RuleType GetRuleType()
        {
            return RuleType.VolatileElement;
        }

        public new abstract bool ValidateElement(EAVolatileElement element);
    }
}
