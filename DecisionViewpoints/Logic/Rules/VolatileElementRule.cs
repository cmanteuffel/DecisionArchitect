using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionViewpoints.Model;

namespace DecisionViewpoints.Logic.Rules
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
