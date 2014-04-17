using System;
using System.Globalization;
using System.Linq;
using DecisionViewpoints.Logic.Rules;
using DecisionViewpoints.Model;
using DecisionViewpointsTests.Logic;
using DecisionViewpointsTests.Model.EventProperties;
using EA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecisionViewpointsTests
{
    [TestClass]
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
            foreach (var state in DVStereotypes.States)
            {
                Assert.IsFalse(ValidateConnector(state, DVStereotypes.StateIdea, DVStereotypes.RelationCausedBy),
                               AssertionFailedMessage(state, DVStereotypes.StateIdea, DVStereotypes.RelationCausedBy));
            }
            // {idea} _ CausedBy _ Any State
            foreach (var state in DVStereotypes.States)
            {
                Assert.IsFalse(ValidateConnector(DVStereotypes.StateIdea, state, DVStereotypes.RelationCausedBy),
                               AssertionFailedMessage(DVStereotypes.StateIdea, state, DVStereotypes.RelationCausedBy));
            }
            // Any State _ CausedBy _ {discarded}
            foreach (var state in DVStereotypes.States.Where(state => state != DVStereotypes.StateIdea))
            {
                Assert.IsFalse(ValidateConnector(state, DVStereotypes.StateDiscarded, DVStereotypes.RelationCausedBy),
                               AssertionFailedMessage(state, DVStereotypes.StateDiscarded, DVStereotypes.RelationCausedBy));
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
                    //Debug.Write(String.Format("{0} {1} {2}\n", state, DVStereotypes.RelationCausedBy, targetState));
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
            foreach (var state in DVStereotypes.States)
            {
                Assert.IsFalse(ValidateConnector(state, DVStereotypes.StateIdea, DVStereotypes.RelationDependsOn),
                               AssertionFailedMessage(state, DVStereotypes.StateIdea, DVStereotypes.RelationDependsOn));
            }
            // {idea} _ DependsOn _ Any State
            foreach (var state in DVStereotypes.States)
            {
                Assert.IsFalse(ValidateConnector(DVStereotypes.StateIdea, state, DVStereotypes.RelationDependsOn),
                               AssertionFailedMessage(DVStereotypes.StateIdea, state, DVStereotypes.RelationDependsOn));
            }
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
            //Debug.Write(String.Format("{0} {1} {2}\n", state, DVStereotypes.RelationCausedBy, targetState));
            // Any State _ExcludedBy _ {idea}
            foreach (var state in DVStereotypes.States)
            {
                Assert.IsFalse(ValidateConnector(state, DVStereotypes.StateIdea, DVStereotypes.RelationExcludedBy),
                               AssertionFailedMessage(state, DVStereotypes.StateIdea, DVStereotypes.RelationExcludedBy));
            }
            // {idea} _ ExcludedBy _ Any State
            foreach (var state in DVStereotypes.States)
            {
                Assert.IsFalse(ValidateConnector(DVStereotypes.StateIdea, state, DVStereotypes.RelationExcludedBy),
                               AssertionFailedMessage(DVStereotypes.StateIdea, state, DVStereotypes.RelationExcludedBy));
            }
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
            foreach (var state in DVStereotypes.States)
            {
                Assert.IsFalse(ValidateConnector(state, DVStereotypes.StateIdea, DVStereotypes.RelationReplaces),
                               AssertionFailedMessage(state, DVStereotypes.StateIdea, DVStereotypes.RelationReplaces));
            }
            // {idea} _ Replaces _ Any State
            foreach (var state in DVStereotypes.States)
            {
                Assert.IsFalse(ValidateConnector(DVStereotypes.StateIdea, state, DVStereotypes.RelationReplaces),
                               AssertionFailedMessage(DVStereotypes.StateIdea, state, DVStereotypes.RelationReplaces));
            }
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
            foreach (var state in DVStereotypes.States)
            {
                Assert.IsFalse(ValidateConnector(state, DVStereotypes.StateIdea, DVStereotypes.RelationAlternativeFor),
                               AssertionFailedMessage(state, DVStereotypes.StateIdea,
                                                      DVStereotypes.RelationAlternativeFor));
            }
            // {idea} _ AlternativeFor _ Any State
            foreach (var state in DVStereotypes.States)
            {
                Assert.IsFalse(ValidateConnector(DVStereotypes.StateIdea, state, DVStereotypes.RelationAlternativeFor),
                               AssertionFailedMessage(DVStereotypes.StateIdea, state,
                                                      DVStereotypes.RelationAlternativeFor));
            }
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
            foreach (var state in DVStereotypes.States.Where(state => state != DVStereotypes.StateIdea && state != DVStereotypes.StateDiscarded))
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

        private bool ValidateConnector(string clientState, string supplierState, string relationshipStereotype)
        {
            Package root = Repo.Models.GetAt(0);
            Package view = root.Packages.GetAt(0);
            Diagram diagram = view.Diagrams.GetAt(0);
            // Get the supplier Decision element from the Repository
            Element supplier = view.Elements.GetByName(String.Format("{0}_supplier", supplierState));
            // Get the client Decision element from the Repository
            Element client = view.Elements.GetByName(String.Format("{0}_client", clientState));
            // Create a Relationship between them
            const string type = "ControlFlow";
            Connector c = client.Connectors.AddNew("", type);
            c.Stereotype = relationshipStereotype;
            c.SupplierID = supplier.ElementID;
            c.Update();
            supplier.Connectors.Refresh();
            client.Connectors.Refresh();
            // Test if the relationship can be created
            var info = CreatePropertiesHelper(type, "", relationshipStereotype, client.ElementID,
                                              supplier.ElementID, diagram.DiagramID);
            var connector = EAConnectorWrapper.Wrap(Repo, info);
            string message;
            return Validator.Instance.ValidateConnector(connector, out message);
        }

        private static EAEventPropertiesHelper CreatePropertiesHelper(string type, string subtype, string stereotype,
            int clientid, int supplierid, int diagramid)
        {
            var info = new EAEventPropertiesHelper();
            info.Set(EAEventPropertyKeys.Type, type);
            info.Set(EAEventPropertyKeys.Subtype, subtype);
            info.Set(EAEventPropertyKeys.Stereotype, stereotype);
            info.Set(EAEventPropertyKeys.ClientId, clientid.ToString(CultureInfo.InvariantCulture));
            info.Set(EAEventPropertyKeys.SupplierId, supplierid.ToString(CultureInfo.InvariantCulture));
            info.Set(EAEventPropertyKeys.DiagramId, diagramid.ToString(CultureInfo.InvariantCulture));
            return info;
        }

        private static string AssertionFailedMessage(string clientState, string supplierState, string relationshipType)
        {
            return
                String.Format("Assertion Failed with:\nClient State: {0}\nRelationship Type: {1}\nSupplier State: {2}",
                              clientState, relationshipType, supplierState);
        }
    }
}