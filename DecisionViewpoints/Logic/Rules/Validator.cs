using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DecisionViewpoints.Model;
using EA;

namespace DecisionViewpoints.Logic.Rules
{
    public sealed class Validator
    {
        private static readonly Validator Singleton = new Validator();
        private readonly IList<IConnectorRule> rules = new List<IConnectorRule>();
        private readonly IDictionary<string, IConnectorRule> lookup = new Dictionary<string, IConnectorRule>();
        private string categoryID;

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

            if (!DVStereotypes.Relationships.Contains(connectorWrapper.Stereotype))
            {
                return true;
            }

            foreach (IConnectorRule rule in rules)
            {
                if (!rule.ValidateConnector(connectorWrapper, out message))
                {
                    return false;
                }
            }
            return true;
        }

        public void SetupModelValidator(Repository repository)
        {
            Project project = repository.GetProjectInterface();
            categoryID = project.DefineRuleCategory(Messages.ModelValidationCategory);

            foreach (IConnectorRule rule in rules)
            {
                var id = project.DefineRule(categoryID, EnumMVErrorType.mvError, rule.getErrorMessage());
                lookup[id] = rule;
            }
        }

        public void RunConnectorRule(Repository repository, string ruleID, int connectorID)
        {
            Project project = repository.GetProjectInterface();
            IConnectorRule rule = lookup[ruleID];
            if (rule != null)
            {
                EAConnectorWrapper connector = EAConnectorWrapper.Wrap(repository, connectorID);
                string message = "";
                if (!rule.ValidateConnector(connector, out message))
                {
                    string supplierStereotype = connector.GetSupplier().GetStereotypeList();
                    string clientStereotype = connector.GetClient().GetStereotypeList();
                    string errorMessage = string.Format(Messages.ModelValidationMessage, clientStereotype,
                                                        connector.Stereotype, supplierStereotype, message);
                    project.PublishResult(ruleID, EnumMVErrorType.mvError, errorMessage);
                }
            }
        }

        private void CreateConnectorRules()
        {
            var notOriginateFromIdea = new ExclusionRule(Messages.NotOriginateFromIdea,
                                                         new[] {DVStereotypes.StateIdea},
                                                         ConnectorRule.Any,
                                                         ConnectorRule.Any);
            var notPointToIdea = new ExclusionRule(Messages.NotPointToIdea, ConnectorRule.Any, ConnectorRule.Any,
                                                   new[] {DVStereotypes.StateIdea}
                );
            var causedByNotPointTo = new ExclusionRule(Messages.CausedByNotPointTo, ConnectorRule.Any,
                                                       new[] {DVStereotypes.RelationCausedBy},
                                                       new[] {DVStereotypes.StateDiscarded}
                );
            var dependsOnOnlyPointTo = new ExclusionRule(Messages.DependsOnOnlyPointTo,
                                                         ConnectorRule.Any,
                                                         new[] {DVStereotypes.RelationDependsOn},
                                                         new[]
                                                             {DVStereotypes.StateDiscarded, DVStereotypes.StateRejected}
                );
            var excludedByNotPointTo = new ExclusionRule(Messages.ExcludedByNotPointTo,
                                                         ConnectorRule.Any,
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
                                                                ConnectorRule.Any
                );
            var replacesOnlyPointTo = new ExclusionRule(Messages.ReplacesOnlyPointTo,
                                                        ConnectorRule.Any,
                                                        new[] {DVStereotypes.RelationReplaces},
                                                        new[]
                                                            {
                                                                DVStereotypes.StateApproved, DVStereotypes.StateChallenged,
                                                                DVStereotypes.StateDecided, DVStereotypes.StateDiscarded
                                                                , DVStereotypes.StateTentative
                                                            }
                );
            var alternativeForNotPointTo = new ExclusionRule(Messages.AlternativeForNotPointTo,
                                                             ConnectorRule.Any,
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

            rules.Add(notOriginateFromIdea);
            rules.Add(notPointToIdea);
            rules.Add(causedByNotPointTo);
            rules.Add(dependsOnOnlyPointTo);
            rules.Add(excludedByNotPointTo);
            rules.Add(excludedByOnlyOriginateFrom);
            rules.Add(replacesOnlyPointTo);
            rules.Add(alternativeForNotPointTo);
            rules.Add(alternativeForOnlyOriginateFrom);
            rules.Add(noLoop);
        }
    }
}