using DecisionViewpoints.Model;

namespace DecisionViewpoints.Logic.Rules
{
    public sealed class Validator : IConnectorRule
    {
        private static readonly Validator Singleton = new Validator();
        private readonly ICompositeRule _connectorRules = new CompositeRule();

        private Validator()
        {
            CreateConnectorRules();
        }


        public static Validator Instance
        {
            get { return Singleton; }
        }

        public bool ValidateConnector(EAConnectorWrapper connectorWrapper, out string message)
        {
            message = "";
            return !DVStereotypes.Relationships.Contains(connectorWrapper.Stereotype) ||
                   _connectorRules.ValidateConnector(connectorWrapper, out message);
        }

        private void CreateConnectorRules()
        {
            var notOriginateFromIdea = new ExclusionRule(new[] {DVStereotypes.StateIdea},
                                                         ConnectorRule.Any,
                                                         ConnectorRule.Any,
                                                         Messages.NotOriginateFromIdea);
            var notPointToIdea = new ExclusionRule(ConnectorRule.Any,
                                                   ConnectorRule.Any,
                                                   new[] {DVStereotypes.StateIdea},
                                                   Messages.NotPointToIdea);
            var causedByNotPointTo = new ExclusionRule(ConnectorRule.Any,
                                                       new[] {DVStereotypes.RelationCausedBy},
                                                       new[] {DVStereotypes.StateDiscarded},
                                                       Messages.CausedByNotPointTo);
            var dependsOnOnlyPointTo = new ExclusionRule(ConnectorRule.Any,
                                                         new[] {DVStereotypes.RelationDependsOn},
                                                         new[]
                                                             {DVStereotypes.StateDiscarded, DVStereotypes.StateRejected},
                                                         Messages.DependsOnOnlyPointTo);
            var excludedByNotPointTo = new ExclusionRule(ConnectorRule.Any,
                                                         new[] {DVStereotypes.RelationExcludedBy},
                                                         new[]
                                                             {
                                                                 DVStereotypes.StateTentative,
                                                                 DVStereotypes.StateDiscarded,
                                                                 DVStereotypes.StateRejected
                                                             },
                                                         Messages.ExcludedByNotPointTo);
            var excludedByOnlyOriginateFrom =
                new ExclusionRule(new[] {DVStereotypes.StateApproved, DVStereotypes.StateDecided},
                                  new[] {DVStereotypes.RelationExcludedBy},
                                  ConnectorRule.Any,
                                  Messages.ExcludedOnlyOriginateFrom);
            var replacesOnlyPointTo = new ExclusionRule(ConnectorRule.Any,
                                                        new[] {DVStereotypes.RelationReplaces},
                                                        new[]
                                                            {
                                                                DVStereotypes.StateApproved,
                                                                DVStereotypes.StateChallenged,
                                                                DVStereotypes.StateDecided, DVStereotypes.StateDiscarded
                                                                ,
                                                                DVStereotypes.StateTentative
                                                            },
                                                        Messages.ReplacesOnlyPointTo);
            var alternativeForNotPointTo = new ExclusionRule(ConnectorRule.Any,
                                                             new[] {DVStereotypes.RelationAlternativeFor},
                                                             new[] {DVStereotypes.StateDiscarded},
                                                             Messages.AlternativeForNotPointTo);
            var alternativeForOnlyOriginateFrom =
                new ExclusionRule(
                    new[]
                        {
                            DVStereotypes.StateApproved, DVStereotypes.StateDecided, DVStereotypes.StateChallenged,
                            DVStereotypes.StateRejected
                        },
                    new[] {DVStereotypes.RelationAlternativeFor},
                    DVStereotypes.States,
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