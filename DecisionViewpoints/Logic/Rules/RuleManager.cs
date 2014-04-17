using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DecisionViewpoints.Model;
using EA;

namespace DecisionViewpoints.Logic.Rules
{
    public sealed class RuleManager
    {
        private static readonly RuleManager Singleton = new RuleManager();
        private readonly IList<AbstractRule> _rules = new List<AbstractRule>();

        public IList<AbstractRule> Rules
        {
            get { return _rules; }
        }


        private RuleManager()
        {
            CreateConnectorRules();
            CreateElementRules();
        }


        public static RuleManager Instance
        {
            get { return Singleton; }
        }

        public bool ValidateElement(EAElementWrapper element, out string message)
        {
            message = "";

            if (!DVStereotypes.States.Contains(element.Stereotype))
            {
                return true;
            }


            foreach (var rule in Rules.Where(r => r.GetRuleType() == RuleType.Element))
            {
                if (!rule.Validate(element, out message))
                {
                    return false;
                }
            }
            return true;
        }

        public bool ValidateConnector(EAConnectorWrapper conector, out string message)
        {
            message = "";

            if (!DVStereotypes.Relationships.Contains(conector.Stereotype))
            {
                return true;
            }

            foreach (var rule in _rules.Where(r => r.GetRuleType() == RuleType.Connector))
            {
                if (!rule.Validate(conector, out message))
                {
                    return false;
                }
            }
            return true;
        }

        private void CreateElementRules()
        {
            var decisionNameUniqueness = new NameUniquenessRule(Messages.NameUniqueness);
            _rules.Add(decisionNameUniqueness);
        }

        private void CreateConnectorRules()
        {
            var notOriginateFromIdea = new ExclusionRule(Messages.NotOriginateFromIdea,
                                                         new[] {DVStereotypes.StateIdea},
                                                         ExclusionRule.Any,
                                                         ExclusionRule.Any);
            var notPointToIdea = new ExclusionRule(Messages.NotPointToIdea, ExclusionRule.Any, ExclusionRule.Any,
                                                   new[] {DVStereotypes.StateIdea}
                );
            var causedByNotPointTo = new ExclusionRule(Messages.CausedByNotPointTo, ExclusionRule.Any,
                                                       new[] {DVStereotypes.RelationCausedBy},
                                                       new[] {DVStereotypes.StateDiscarded}
                );
            var dependsOnOnlyPointTo = new ExclusionRule(Messages.DependsOnOnlyPointTo,
                                                         ExclusionRule.Any,
                                                         new[] {DVStereotypes.RelationDependsOn},
                                                         new[]
                                                             {DVStereotypes.StateDiscarded, DVStereotypes.StateRejected}
                );
            var excludedByNotPointTo = new ExclusionRule(Messages.ExcludedByNotPointTo,
                                                         ExclusionRule.Any,
                                                         new[] {DVStereotypes.RelationExcludedBy},
                                                         new[]
                                                             {
                                                                 DVStereotypes.StateTentative, DVStereotypes.StateDiscarded
                                                                 , DVStereotypes.StateRejected
                                                             }
                );
            var excludedByOnlyOriginateFrom = new ExclusionRule(Messages.ExcludedOnlyOriginateFrom,
                                                                new[]
                                                                    {
                                                                        DVStereotypes.StateApproved,
                                                                        DVStereotypes.StateDecided
                                                                    },
                                                                new[] {DVStereotypes.RelationExcludedBy},
                                                                ExclusionRule.Any
                );
            var replacesOnlyPointTo = new ExclusionRule(Messages.ReplacesOnlyPointTo,
                                                        ExclusionRule.Any,
                                                        new[] {DVStereotypes.RelationReplaces},
                                                        new[]
                                                            {
                                                                DVStereotypes.StateApproved, DVStereotypes.StateChallenged,
                                                                DVStereotypes.StateDecided, DVStereotypes.StateDiscarded
                                                                , DVStereotypes.StateTentative
                                                            }
                );
            var alternativeForNotPointTo = new ExclusionRule(Messages.AlternativeForNotPointTo,
                                                             ExclusionRule.Any,
                                                             new[] {DVStereotypes.RelationAlternativeFor},
                                                             new[] {DVStereotypes.StateDiscarded}
                );

            var alternativeForOnlyOriginateFrom = new ExclusionRule(Messages.AlternativeForOnlyOriginateFrom,
                                                                    new[]
                                                                        {
                                                                            DVStereotypes.StateApproved,
                                                                            DVStereotypes.StateDecided,
                                                                            DVStereotypes.StateChallenged,
                                                                            DVStereotypes.StateRejected
                                                                        },
                                                                    new[] {DVStereotypes.RelationAlternativeFor},
                                                                    DVStereotypes.States);

            var noLoop = new NoLoopRule(Messages.NoLoops);

            _rules.Add(notOriginateFromIdea);
            _rules.Add(notPointToIdea);
            _rules.Add(causedByNotPointTo);
            _rules.Add(dependsOnOnlyPointTo);
            _rules.Add(excludedByNotPointTo);
            _rules.Add(excludedByOnlyOriginateFrom);
            _rules.Add(replacesOnlyPointTo);
            _rules.Add(alternativeForNotPointTo);
            _rules.Add(alternativeForOnlyOriginateFrom);
            _rules.Add(noLoop);
        }
    }
}