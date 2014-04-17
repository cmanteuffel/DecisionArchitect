using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionViewpoints.Model;

namespace DecisionViewpoints.Logic.Rules
{
    public abstract class ElementRule : AbstractRule
    {
        public ElementRule(string errorMessage) : base(errorMessage)
        {
        }

        public override sealed RuleType GetRuleType()
        {
            return RuleType.Element;
        }
    }
}
