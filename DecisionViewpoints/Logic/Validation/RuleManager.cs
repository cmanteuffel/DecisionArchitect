/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
*/

using System.Collections.Generic;
using System.Linq;
using EAFacade;
using EAFacade.Model;


namespace DecisionViewpoints.Logic.Validation
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

        public bool ValidateElement(IEAVolatileElement element, out string message)
        {
            message = "";

            if (!EAConstants.States.Contains(element.Stereotype))
            {
                return true;
            }


            foreach (var rule in Rules.Where(r => r.GetRuleType() == RuleType.VolatileElement))
            {
                if (!rule.Validate(element, out message))
                {
                    return false;
                }
            }
            return true;
        }

        public bool ValidateElement(IEAElement element, out string message)
        {
            message = "";

            if (!EAConstants.States.Contains(element.Stereotype))
            {
                return true;
            }


            foreach (var rule in Rules.Where(r => (r.GetRuleType() == RuleType.Element)))
            {
                if (!rule.Validate(element, out message))
                {
                    return false;
                }
            }
            return true;
        }

        public bool ValidateConnector(IEAConnector connector, out string message)
        {
            message = "";

            if (!EAConstants.Relationships.Contains(connector.Stereotype))
            {
                return true;
            }

            foreach (var rule in _rules.Where(r => r.GetRuleType() == RuleType.Connector))
            {
                if (!rule.Validate(connector, out message))
                {
                    return false;
                }
            }
            return true;
        }

        public bool ValidateConnector(IEAVolatileConnector connector, out string message)
        {
            message = "";

            if (!EAConstants.Relationships.Contains(connector.Stereotype))
            {
                return true;
            }

            foreach (var rule in _rules.Where(r => r.GetRuleType() == RuleType.Connector))
            {
                if (!rule.Validate(connector, out message))
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
                                                         new[] {EAConstants.StateIdea},
                                                         ExclusionRule.Any,
                                                         ExclusionRule.Any);
            var notPointToIdea = new ExclusionRule(Messages.NotPointToIdea, ExclusionRule.Any, ExclusionRule.Any,
                                                   new[] {EAConstants.StateIdea}
                );
            var causedByNotPointTo = new ExclusionRule(Messages.CausedByNotPointTo, ExclusionRule.Any,
                                                       new[] {EAConstants.RelationCausedBy},
                                                       new[] {EAConstants.StateDiscarded}
                );
            var dependsOnOnlyPointTo = new ExclusionRule(Messages.DependsOnOnlyPointTo,
                                                         ExclusionRule.Any,
                                                         new[] {EAConstants.RelationDependsOn},
                                                         new[]
                                                             {EAConstants.StateDiscarded, EAConstants.StateRejected}
                );
            var excludedByNotPointTo = new ExclusionRule(Messages.ExcludedByNotPointTo,
                                                         ExclusionRule.Any,
                                                         new[] {EAConstants.RelationExcludedBy},
                                                         new[]
                                                             {
                                                                 EAConstants.StateTentative, EAConstants.StateDiscarded
                                                                 , EAConstants.StateRejected
                                                             }
                );
            var excludedByOnlyOriginateFrom = new ExclusionRule(Messages.ExcludedOnlyOriginateFrom,
                                                                new[]
                                                                    {
                                                                        EAConstants.StateApproved,
                                                                        EAConstants.StateDecided
                                                                    },
                                                                new[] {EAConstants.RelationExcludedBy},
                                                                ExclusionRule.Any
                );
            var replacesOnlyPointTo = new ExclusionRule(Messages.ReplacesOnlyPointTo,
                                                        ExclusionRule.Any,
                                                        new[] {EAConstants.RelationReplaces},
                                                        new[]
                                                            {
                                                                EAConstants.StateApproved, EAConstants.StateChallenged,
                                                                EAConstants.StateDecided, EAConstants.StateDiscarded
                                                                , EAConstants.StateTentative
                                                            }
                );
            var alternativeForNotPointTo = new ExclusionRule(Messages.AlternativeForNotPointTo,
                                                             ExclusionRule.Any,
                                                             new[] {EAConstants.RelationAlternativeFor},
                                                             new[] {EAConstants.StateDiscarded}
                );

            var alternativeForOnlyOriginateFrom = new ExclusionRule(Messages.AlternativeForOnlyOriginateFrom,
                                                                    new[]
                                                                        {
                                                                            EAConstants.StateApproved,
                                                                            EAConstants.StateDecided,
                                                                            EAConstants.StateChallenged,
                                                                            EAConstants.StateRejected
                                                                        },
                                                                    new[] {EAConstants.RelationAlternativeFor},
                                                                    EAConstants.States);

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
