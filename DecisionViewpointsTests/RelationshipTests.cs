using System;
using System.Linq;
using DecisionViewpoints.Logic.Validation;
using DecisionViewpoints.Model;
using DecisionViewpointsTests.Logic;
using DecisionViewpointsTests.Model.EventProperties;
using EA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecisionViewpointsTests
{
    [TestClass]
    [DeploymentItem(@"EATestFiles\UnitTestRelationships.eap", "EATestFiles")]
    public class RelationshipTests : BaseTests
    {
        private RelationshipsRepositoryFile _f;

        [TestInitialize]
        public void InitRelationshipTests()
        {
            _f = new RelationshipsRepositoryFile(Repo);
            _f.Open();
        }

        [TestCleanup]
        public void CleanUpRelationshipsTests()
        {
            _f.Close();
        }

        #region CausedBy

        [TestMethod]
        public void CausedBy_InvalidRelationships()
        {
            _f.Reset();
            // Any State _ CausedBy _ {idea}
            AnyToIdea(DVStereotypes.RelationCausedBy);
            // {idea} _ CausedBy _ Any State
            IdeaToAny(DVStereotypes.RelationCausedBy);
            // Any State _ CausedBy _ {discarded}
            foreach (var state in DVStereotypes.States.Where(state => state != DVStereotypes.StateIdea))
            {
                Assert.IsFalse(ValidateConnector(state, DVStereotypes.StateDiscarded, DVStereotypes.RelationCausedBy),
                               AssertionFailedMessage(state, DVStereotypes.StateDiscarded,
                                                      DVStereotypes.RelationCausedBy));
            }
            _f.Reset();
        }

        [TestMethod]
        public void CausedBy_ValidRelationships()
        {
            _f.Reset();
            // Any State _ CausedBy _ {tentative, decided, approved, challenged, rejected}
            var validTargetStates = new[]
                {
                    DVStereotypes.StateTentative, DVStereotypes.StateDecided,
                    DVStereotypes.StateApproved, DVStereotypes.StateChallenged, DVStereotypes.StateRejected
                };
            foreach (
                var state in
                    DVStereotypes.States.Where(state => state != DVStereotypes.StateIdea)
                )
            {
                foreach (var targetState in validTargetStates)
                {
                    Assert.IsTrue(ValidateConnector(state, targetState, DVStereotypes.RelationCausedBy),
                                  AssertionFailedMessage(state, targetState, DVStereotypes.RelationCausedBy));
                }
            }
            _f.Reset();
        }

        #endregion

        #region DependsOn

        [TestMethod]
        public void DependsOn_InvalidRelationships()
        {
            _f.Reset();
            // Any State _ DependsOn _ {idea}
            AnyToIdea(DVStereotypes.RelationDependsOn);
            // {idea} _ DependsOn _ Any State
            IdeaToAny(DVStereotypes.RelationDependsOn);
            // Any State _ DependsOn _ {discarded, rejected}
            var invalidTargetStates = new[]
                {
                    DVStereotypes.StateDiscarded, DVStereotypes.StateRejected
                };
            foreach (var state in DVStereotypes.States.Where(state => state != DVStereotypes.StateIdea))
            {
                foreach (var targetState in invalidTargetStates)
                {
                    Assert.IsFalse(ValidateConnector(state, targetState, DVStereotypes.RelationDependsOn),
                                   AssertionFailedMessage(state, targetState, DVStereotypes.RelationDependsOn));
                }
            }
            _f.Reset();
        }

        [TestMethod]
        public void DependsOn_ValidRelationships()
        {
            _f.Reset();
            // Any State _ DependsOn _ {tentative, decided, approved, challenged}
            var validTargetStates = new[]
                {
                    DVStereotypes.StateTentative, DVStereotypes.StateDecided, DVStereotypes.StateApproved,
                    DVStereotypes.StateChallenged
                };
            foreach (
                var state in
                    DVStereotypes.States.Where(s => s != DVStereotypes.StateIdea))
            {
                foreach (var targetState in validTargetStates)
                {
                    Assert.IsTrue(ValidateConnector(state, targetState, DVStereotypes.RelationDependsOn),
                                  AssertionFailedMessage(state, targetState, DVStereotypes.RelationDependsOn));
                }
            }
            _f.Reset();
        }

        #endregion

        #region ExcludedBy

        [TestMethod]
        public void ExcludedBy_InvalidRelationships()
        {
            _f.Reset();
            // Any State _ExcludedBy _ {idea}
            AnyToIdea(DVStereotypes.RelationExcludedBy);
            // {idea} _ ExcludedBy _ Any State
            IdeaToAny(DVStereotypes.RelationExcludedBy);
            // Any State _ ExcludedBy _ {tentative, discarded, rejected}
            var invalidTargetStates = new[]
                {
                    DVStereotypes.StateTentative, DVStereotypes.StateDiscarded, DVStereotypes.StateRejected
                };
            foreach (
                var state in
                    DVStereotypes.States.Where(state => state != DVStereotypes.StateIdea)
                )
            {
                foreach (var targetState in invalidTargetStates)
                {
                    Assert.IsFalse(ValidateConnector(state, targetState, DVStereotypes.RelationExcludedBy),
                                   AssertionFailedMessage(state, targetState, DVStereotypes.RelationExcludedBy));
                }
            }
            _f.Reset();
        }

        [TestMethod]
        public void ExcludedBy_ValidRelationships()
        {
            _f.Reset();
            // {tentative, discarded, rejected} _ ExcludedBy _ Any State
            var validSourceStates = new[]
                {
                    DVStereotypes.StateTentative, DVStereotypes.StateDiscarded, DVStereotypes.StateRejected
                };
            foreach (
                var state in
                    DVStereotypes.States.Where(
                        state => state != DVStereotypes.StateIdea && !(validSourceStates.Contains(state)))
                )
            {
                foreach (var sourceState in validSourceStates)
                    Assert.IsTrue(ValidateConnector(sourceState, state, DVStereotypes.RelationExcludedBy),
                                  AssertionFailedMessage(sourceState, state, DVStereotypes.RelationExcludedBy));
            }
            _f.Reset();
        }

        #endregion

        #region Replaces

        [TestMethod]
        public void Replaces_InvalidRelationships()
        {
            _f.Reset();
            // Any State Replaces _ {idea}
            AnyToIdea(DVStereotypes.RelationReplaces);
            // {idea} _ Replaces _ Any State
            IdeaToAny(DVStereotypes.RelationReplaces);
            // Any State _ Replaces _ {tentative, discarded, decided, challenged, approved}
            var invalidTargetStates = new[]
                {
                    DVStereotypes.StateTentative, DVStereotypes.StateDiscarded, DVStereotypes.StateDecided,
                    DVStereotypes.StateChallenged, DVStereotypes.StateApproved
                };
            foreach (var state in DVStereotypes.States.Where(state => state != DVStereotypes.StateIdea))
            {
                foreach (var targetState in invalidTargetStates)
                {
                    Assert.IsFalse(ValidateConnector(state, targetState, DVStereotypes.RelationReplaces),
                                   AssertionFailedMessage(state, targetState, DVStereotypes.RelationReplaces));
                }
            }
            _f.Reset();
        }

        [TestMethod]
        public void Replaces_ValidRelationships()
        {
            _f.Reset();
            // Any State _ Replaces _ {rejected}
            foreach (var state in DVStereotypes.States.Where(state => state != DVStereotypes.StateIdea))
            {
                Assert.IsTrue(ValidateConnector(state, DVStereotypes.StateRejected, DVStereotypes.RelationReplaces),
                              AssertionFailedMessage(state, DVStereotypes.StateRejected, DVStereotypes.RelationReplaces));
            }
            _f.Reset();
        }

        #endregion

        #region AlternativeFor

        [TestMethod]
        public void AlternativeFor_InvalidRelationships()
        {
            _f.Reset();
            // Any State _ AlternativeFor _ {idea}
            AnyToIdea(DVStereotypes.RelationAlternativeFor);
            // {idea} _ AlternativeFor _ Any State
            IdeaToAny(DVStereotypes.RelationAlternativeFor);
            // Any State _ AlternativeFor _ {discarded}
            foreach (var state in DVStereotypes.States.Where(s => s != DVStereotypes.StateIdea))
            {
                Assert.IsFalse(
                    ValidateConnector(state, DVStereotypes.StateDiscarded, DVStereotypes.RelationAlternativeFor),
                    AssertionFailedMessage(state, DVStereotypes.StateDiscarded, DVStereotypes.RelationAlternativeFor));
            }
            _f.Reset();
        }

        [TestMethod]
        public void AlternativeFor_ValidRelationships()
        {
            _f.Reset();
            // {tentative, discarded} _ AlternativeFor _ {tentative, decided, approved, challenged, rejected}
            var validSourceStates = new[]
                {
                    DVStereotypes.StateTentative, DVStereotypes.StateDiscarded
                };
            foreach (
                var state in
                    DVStereotypes.States.Where(
                        state => state != DVStereotypes.StateIdea && state != DVStereotypes.StateDiscarded))
            {
                foreach (var sourceState in validSourceStates)
                {
                    Assert.IsTrue(ValidateConnector(sourceState, state, DVStereotypes.RelationAlternativeFor),
                                  AssertionFailedMessage(sourceState, state, DVStereotypes.RelationAlternativeFor));
                }
            }
            _f.Reset();
        }

        #endregion

        private void IdeaToAny(string relationship)
        {
            foreach (var state in DVStereotypes.States)
            {
                Assert.IsFalse(ValidateConnector(DVStereotypes.StateIdea, state, relationship),
                               AssertionFailedMessage(DVStereotypes.StateIdea, state, relationship));
            }
        }

        private void AnyToIdea(string relationship)
        {
            foreach (var state in DVStereotypes.States)
            {
                Assert.IsFalse(ValidateConnector(state, DVStereotypes.StateIdea, relationship),
                               AssertionFailedMessage(state, DVStereotypes.StateIdea, relationship));
            }
        }

        private bool ValidateConnector(string clientState, string supplierState, string relationshipStereotype)
        {
            Package root = Repo.Models.GetAt(0);
            Package view = root.Packages.GetAt(0);
            Diagram diagram = view.Diagrams.GetAt(0);
            // Get the supplier Decision element from the Repository
            Element supplier = view.Elements.GetByName(String.Format("{0}_supplier", supplierState));
            // Get the client Decision element from the Repository
            Element client = view.Elements.GetByName(String.Format("{0}_client", clientState));
            // Test if the relationship can be created
            const string type = "ControlFlow";
            var info = EAEventPropertiesHelper.GetInstance(type, "", relationshipStereotype, client.ElementID,
                                                           supplier.ElementID, diagram.DiagramID);
            var connector = EAConnectorWrapper.Wrap(info);
            string message;
            return RuleManager.Instance.ValidateConnector(connector, out message);
        }

        private static string AssertionFailedMessage(string clientState, string supplierState, string relationshipType)
        {
            return
                String.Format("Assertion Failed with:\nClient State: {0}\nRelationship Type: {1}\nSupplier State: {2}",
                              clientState, relationshipType, supplierState);
        }
    }
}