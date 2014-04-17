using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionViewpoints.Model.Rules
{
    public sealed class Validator : IConnectorRule
    {
        private static readonly Validator instance = new Validator();
        private readonly ICompositeRule _connectorRules = new CompositeRule();

        private Validator()
        {
            CreateConnectorRules();
        }


        public static Validator Instance
        {
            get { return instance; }
        }

        public bool ValidateConnector(PreConnector connector, out string message)
        {
            return _connectorRules.ValidateConnector(connector, out message);
        }

        private void CreateConnectorRules()
        {
            var notOriginateFromIdea = new ExclusionRule(new[] {Stereotypes.StateIdea},
                                                         ConnectorRule.Any,
                                                         ConnectorRule.Any,
                                                         Messages.NotOriginateFromIdea);
            var notPointToIdea = new ExclusionRule(ConnectorRule.Any,
                                                   ConnectorRule.Any,
                                                   new[] {Stereotypes.StateIdea},
                                                   Messages.NotPointToIdea);
            var causedByNotPointTo = new ExclusionRule(ConnectorRule.Any,
                                                       new[] {Stereotypes.RelationCausedBy},
                                                       new[] {Stereotypes.StateDiscarded},
                                                       Messages.CausedByNotPointTo);
            var dependsOnOnlyPointTo = new ExclusionRule(ConnectorRule.Any,
                                                         new[] {Stereotypes.RelationDependsOn},
                                                         new[] {Stereotypes.StateDiscarded, Stereotypes.StateRejected},
                                                         Messages.DependsOnOnlyPointTo);
            var excludedByNotPointTo = new ExclusionRule(ConnectorRule.Any,
                                                         new[] {Stereotypes.RelationExcludedBy},
                                                         new[]
                                                             {
                                                                 Stereotypes.StateTentative, Stereotypes.StateDiscarded,
                                                                 Stereotypes.StateRejected
                                                             },
                                                         Messages.ExcludedByNotPointTo);
            var excludedByOnlyOriginateFrom =
                new ExclusionRule(new[] {Stereotypes.StateApproved, Stereotypes.StateDecided},
                                  new[] {Stereotypes.RelationExcludedBy},
                                  ConnectorRule.Any,
                                  Messages.ExcludedOnlyOriginateFrom);
            var replacesOnlyPointTo = new ExclusionRule(ConnectorRule.Any,
                                                        new[] {Stereotypes.RelationReplaces},
                                                        new[]
                                                            {
                                                                Stereotypes.StateApproved, Stereotypes.StateChallenged,
                                                                Stereotypes.StateDecided, Stereotypes.StateDiscarded,
                                                                Stereotypes.StateTentative
                                                            },
                                                        Messages.ReplacesOnlyPointTo);
            var alternativeForNotPointTo = new ExclusionRule(ConnectorRule.Any,
                                                             new[] {Stereotypes.RelationAlternativeFor},
                                                             new[] {Stereotypes.StateDiscarded},
                                                             Messages.AlternativeForNotPointTo);
            var alternativeForOnlyOriginateFrom =
                new ExclusionRule(
                    new[]
                        {
                            Stereotypes.StateApproved, Stereotypes.StateDecided, Stereotypes.StateChallenged,
                            Stereotypes.StateRejected
                        },
                    new[] {Stereotypes.RelationAlternativeFor},
                    Stereotypes.States,
                    Messages.AlternativeForOnlyOriginateFrom);

            var noLoop = new NoLoopRule(Messages.NoLoops);

            _connectorRules.Add(notOriginateFromIdea);
            _connectorRules.Add(notPointToIdea);
            _connectorRules.Add(causedByNotPointTo);
            _connectorRules.Add(dependsOnOnlyPointTo);
            _connectorRules.Add(excludedByNotPointTo);
            _connectorRules.Add(excludedByOnlyOriginateFrom);
            _connectorRules.Add(replacesOnlyPointTo);
            _connectorRules.Add(alternativeForNotPointTo);
            _connectorRules.Add(alternativeForOnlyOriginateFrom);
            _connectorRules.Add(noLoop);
        }
    }
}