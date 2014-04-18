using System;
using System.Linq;
using DecisionViewpoints.Logic.Validation;
using DecisionViewpointsTests.Logic;
using DecisionViewpointsTests.Model.EventProperties;
using EA;
using EAFacade;
using EAFacade.Model;
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
            AnyToIdea(EAConstants.RelationCausedBy);
            // {idea} _ CausedBy _ Any State
            IdeaToAny(EAConstants.RelationCausedBy);
            // Any State _ CausedBy _ {discarded}
            foreach (var state in EAConstants.States.Where(state => state != EAConstants.StateIdea))
            {
                Assert.IsFalse(ValidateConnector(state, EAConstants.StateDiscarded, EAConstants.RelationCausedBy),
                               AssertionFailedMessage(state, EAConstants.StateDiscarded,
                                                      EAConstants.RelationCausedBy));
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
                    EAConstants.StateTentative, EAConstants.StateDecided,
                    EAConstants.StateApproved, EAConstants.StateChallenged, EAConstants.StateRejected
                };
            foreach (
                var state in
                    EAConstants.States.Where(state => state != EAConstants.StateIdea)
                )
            {
                foreach (var targetState in validTargetStates)
                {
                    Assert.IsTrue(ValidateConnector(state, targetState, EAConstants.RelationCausedBy),
                                  AssertionFailedMessage(state, targetState, EAConstants.RelationCausedBy));
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
            AnyToIdea(EAConstants.RelationDependsOn);
            // {idea} _ DependsOn _ Any State
            IdeaToAny(EAConstants.RelationDependsOn);
            // Any State _ DependsOn _ {discarded, rejected}
            var invalidTargetStates = new[]
                {
                    EAConstants.StateDiscarded, EAConstants.StateRejected
                };
            foreach (var state in EAConstants.States.Where(state => state != EAConstants.StateIdea))
            {
                foreach (var targetState in invalidTargetStates)
                {
                    Assert.IsFalse(ValidateConnector(state, targetState, EAConstants.RelationDependsOn),
                                   AssertionFailedMessage(state, targetState, EAConstants.RelationDependsOn));
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
                    EAConstants.StateTentative, EAConstants.StateDecided, EAConstants.StateApproved,
                    EAConstants.StateChallenged
                };
            foreach (
                var state in
                    EAConstants.States.Where(s => s != EAConstants.StateIdea))
            {
                foreach (var targetState in validTargetStates)
                {
                    Assert.IsTrue(ValidateConnector(state, targetState, EAConstants.RelationDependsOn),
                                  AssertionFailedMessage(state, targetState, EAConstants.RelationDependsOn));
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
            AnyToIdea(EAConstants.RelationExcludedBy);
            // {idea} _ ExcludedBy _ Any State
            IdeaToAny(EAConstants.RelationExcludedBy);
            // Any State _ ExcludedBy _ {tentative, discarded, rejected}
            var invalidTargetStates = new[]
                {
                    EAConstants.StateTentative, EAConstants.StateDiscarded, EAConstants.StateRejected
                };
            foreach (
                var state in
                    EAConstants.States.Where(state => state != EAConstants.StateIdea)
                )
            {
                foreach (var targetState in invalidTargetStates)
                {
                    Assert.IsFalse(ValidateConnector(state, targetState, EAConstants.RelationExcludedBy),
                                   AssertionFailedMessage(state, targetState, EAConstants.RelationExcludedBy));
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
                    EAConstants.StateTentative, EAConstants.StateDiscarded, EAConstants.StateRejected
                };
            foreach (
                var state in
                    EAConstants.States.Where(
                        state => state != EAConstants.StateIdea && !(validSourceStates.Contains(state)))
                )
            {
                foreach (var sourceState in validSourceStates)
                    Assert.IsTrue(ValidateConnector(sourceState, state, EAConstants.RelationExcludedBy),
                                  AssertionFailedMessage(sourceState, state, EAConstants.RelationExcludedBy));
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
            AnyToIdea(EAConstants.RelationReplaces);
            // {idea} _ Replaces _ Any State
            IdeaToAny(EAConstants.RelationReplaces);
            // Any State _ Replaces _ {tentative, discarded, decided, challenged, approved}
            var invalidTargetStates = new[]
                {
                    EAConstants.StateTentative, EAConstants.StateDiscarded, EAConstants.StateDecided,
                    EAConstants.StateChallenged, EAConstants.StateApproved
                };
            foreach (var state in EAConstants.States.Where(state => state != EAConstants.StateIdea))
            {
                foreach (var targetState in invalidTargetStates)
                {
                    Assert.IsFalse(ValidateConnector(state, targetState, EAConstants.RelationReplaces),
                                   AssertionFailedMessage(state, targetState, EAConstants.RelationReplaces));
                }
            }
            _f.Reset();
        }

        [TestMethod]
        public void Replaces_ValidRelationships()
        {
            _f.Reset();
            // Any State _ Replaces _ {rejected}
            foreach (var state in EAConstants.States.Where(state => state != EAConstants.StateIdea))
            {
                Assert.IsTrue(ValidateConnector(state, EAConstants.StateRejected, EAConstants.RelationReplaces),
                              AssertionFailedMessage(state, EAConstants.StateRejected, EAConstants.RelationReplaces));
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
            AnyToIdea(EAConstants.RelationAlternativeFor);
            // {idea} _ AlternativeFor _ Any State
            IdeaToAny(EAConstants.RelationAlternativeFor);
            // Any State _ AlternativeFor _ {discarded}
            foreach (var state in EAConstants.States.Where(s => s != EAConstants.StateIdea))
            {
                Assert.IsFalse(
                    ValidateConnector(state, EAConstants.StateDiscarded, EAConstants.RelationAlternativeFor),
                    AssertionFailedMessage(state, EAConstants.StateDiscarded, EAConstants.RelationAlternativeFor));
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
                    EAConstants.StateTentative, EAConstants.StateDiscarded
                };
            foreach (
                var state in
                    EAConstants.States.Where(
                        state => state != EAConstants.StateIdea && state != EAConstants.StateDiscarded))
            {
                foreach (var sourceState in validSourceStates)
                {
                    Assert.IsTrue(ValidateConnector(sourceState, state, EAConstants.RelationAlternativeFor),
                                  AssertionFailedMessage(sourceState, state, EAConstants.RelationAlternativeFor));
                }
            }
            _f.Reset();
        }

        #endregion

        private void IdeaToAny(string relationship)
        {
            foreach (var state in EAConstants.States)
            {
                Assert.IsFalse(ValidateConnector(EAConstants.StateIdea, state, relationship),
                               AssertionFailedMessage(EAConstants.StateIdea, state, relationship));
            }
        }

        private void AnyToIdea(string relationship)
        {
            foreach (var state in EAConstants.States)
            {
                Assert.IsFalse(ValidateConnector(state, EAConstants.StateIdea, relationship),
                               AssertionFailedMessage(state, EAConstants.StateIdea, relationship));
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
            var connector = EAFacade.EA.WrapVolatileConnector(info);
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