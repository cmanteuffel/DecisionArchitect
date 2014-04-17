using System;
using System.Globalization;
using System.Linq;
using EA;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DecisionViewpoints.Model;

namespace DecisionViewpointsTests
{
    [TestClass]
    public class BroadcastEventHandlerTests : BaseTests
    {
        [TestMethod]
        public void OnPostOpenDiagram_OpenDecisionViewpointDiagram_ToolboxActivated()
        {
            OpenRepositoryFile(RepositoryType.BasicStructure);
            ResetRepository(RepositoryType.BasicStructure);
            Package root = Repo.Models.GetAt(0);
            Package view = root.Packages.GetAt(0);
            Diagram diagram = view.Diagrams.GetAt(0);
            Repo.OpenDiagram(diagram.DiagramID);
            var toolboxName = MainApp.EA_OnPostOpenDiagram(Repo, diagram.DiagramID);
            ResetRepository(RepositoryType.BasicStructure);
            CloseRepositoryFile();
            Assert.AreEqual("DecisionVS", toolboxName);
        }

        [TestMethod]
        public void OnPreNewConnector_CausedBy_InvalidRelationships()
        {
            OpenRepositoryFile(RepositoryType.Relationships);
            ResetRepository(RepositoryType.Relationships);
            // Any Decision to decision with state Idea
            foreach (var s in Stereotypes.States)
            {
                Assert.IsFalse(ValidateConnector(s, Stereotypes.StateIdea, Stereotypes.RelationCausedBy),
                    AssertionFailedMessage(s, States.Idea, Stereotypes.RelationCausedBy));
            }
            // Decision with state Idea to Any Decision
            foreach (var s in Stereotypes.States)
            {
                Assert.IsFalse(ValidateConnector(States.Idea, s, Stereotypes.RelationCausedBy),
                    AssertionFailedMessage(States.Idea, s, Stereotypes.RelationCausedBy));
            }
            // Any decision to decision with state Discarded
            foreach (var s in Stereotypes.States.Where(s => s != Stereotypes.StateIdea))
            {
                Assert.IsFalse(ValidateConnector(s, Stereotypes.StateDiscarded, Stereotypes.RelationCausedBy),
                    AssertionFailedMessage(s, States.Discarded, Stereotypes.RelationCausedBy));
            }
            ResetRepository(RepositoryType.Relationships);
            CloseRepositoryFile();
        }

        [TestMethod]
        public void OnPreNewConnector_CausedBy_ValidRelationships()
        {
            OpenRepositoryFile(RepositoryType.Relationships);
            ResetRepository(RepositoryType.Relationships);
            // Any decision to decision with state {tentative, decided, approved, challenged, rejected}
            foreach (var s in Stereotypes.States.Where(s => s != Stereotypes.StateIdea && s != Stereotypes.StateTentative &&
                s != Stereotypes.StateDecided && s != Stereotypes.StateApproved && s != Stereotypes.StateChallenged && s != Stereotypes.StateRejected))
            {
                Assert.IsTrue(ValidateConnector(s, Stereotypes.StateTentative, Stereotypes.RelationCausedBy),
                              AssertionFailedMessage(s, Stereotypes.StateTentative, Stereotypes.RelationCausedBy));
                Assert.IsTrue(ValidateConnector(s, Stereotypes.StateDecided, Stereotypes.RelationCausedBy),
                              AssertionFailedMessage(s, Stereotypes.StateDecided, Stereotypes.RelationCausedBy));
                Assert.IsTrue(ValidateConnector(s, Stereotypes.StateApproved, Stereotypes.RelationCausedBy),
                              AssertionFailedMessage(s, Stereotypes.StateApproved, Stereotypes.RelationCausedBy));
                Assert.IsTrue(ValidateConnector(s, Stereotypes.StateChallenged, Stereotypes.RelationCausedBy),
                              AssertionFailedMessage(s, Stereotypes.StateChallenged, Stereotypes.RelationCausedBy));
                Assert.IsTrue(ValidateConnector(s, Stereotypes.StateRejected, Stereotypes.RelationCausedBy),
                              AssertionFailedMessage(s, Stereotypes.StateRejected, Stereotypes.RelationCausedBy));
            }
            ResetRepository(RepositoryType.Relationships);
            CloseRepositoryFile(); 
        }

        [TestMethod]
        public void OnPreNewConnector_DependsOn_InvalidRelationships()
        {
            OpenRepositoryFile(RepositoryType.Relationships);
            ResetRepository(RepositoryType.Relationships);
            // Any Decision to decision with state Idea
            foreach (var s in Stereotypes.States)
            {
                Assert.IsFalse(ValidateConnector(s, Stereotypes.StateIdea, Stereotypes.RelationDependsOn),
                    AssertionFailedMessage(s, States.Idea, Stereotypes.RelationDependsOn));
            }
            // Decision with state Idea to Any Decision
            foreach (var s in Stereotypes.States)
            {
                Assert.IsFalse(ValidateConnector(States.Idea, s, Stereotypes.RelationDependsOn),
                    AssertionFailedMessage(States.Idea, s, Stereotypes.RelationDependsOn));
            }
            ResetRepository(RepositoryType.Relationships);
            CloseRepositoryFile();
        }

        [TestMethod]
        public void OnPreNewConnector_DependsOn_ValidRelationships()
        {
            OpenRepositoryFile(RepositoryType.Relationships);
            ResetRepository(RepositoryType.Relationships);
            // Any Decision to decision with states {tentative, decided, approved, challenged}
            foreach (var s in Stereotypes.States.Where(s => s != Stereotypes.StateIdea && s != Stereotypes.StateTentative && 
                s != Stereotypes.StateDecided && s != Stereotypes.StateApproved && s != Stereotypes.StateChallenged))
            {
                Assert.IsTrue(ValidateConnector(s, Stereotypes.StateTentative, Stereotypes.RelationDependsOn),
                              AssertionFailedMessage(s, Stereotypes.StateTentative, Stereotypes.RelationDependsOn));
                Assert.IsTrue(ValidateConnector(s, Stereotypes.StateDecided, Stereotypes.RelationDependsOn),
                              AssertionFailedMessage(s, Stereotypes.StateDecided, Stereotypes.RelationDependsOn));
                Assert.IsTrue(ValidateConnector(s, Stereotypes.StateApproved, Stereotypes.RelationDependsOn),
                              AssertionFailedMessage(s, Stereotypes.StateApproved, Stereotypes.RelationDependsOn));
                Assert.IsTrue(ValidateConnector(s, Stereotypes.StateChallenged, Stereotypes.RelationDependsOn),
                              AssertionFailedMessage(s, Stereotypes.StateChallenged, Stereotypes.RelationDependsOn));
            }
            ResetRepository(RepositoryType.Relationships);
            CloseRepositoryFile();
        }

        [TestMethod]
        public void OnPreNewConnector_ExcludedBy_InvalidRelationships()
        {
            OpenRepositoryFile(RepositoryType.Relationships);
            ResetRepository(RepositoryType.Relationships);
            // Any Decision to decision with state Idea
            foreach (var s in Stereotypes.States)
            {
                Assert.IsFalse(ValidateConnector(s, Stereotypes.StateIdea, Stereotypes.RelationExcludedBy),
                    AssertionFailedMessage(s, States.Idea, Stereotypes.RelationExcludedBy));
            }
            // Decision with state Idea to Any Decision
            foreach (var s in Stereotypes.States)
            {
                Assert.IsFalse(ValidateConnector(States.Idea, s, Stereotypes.RelationExcludedBy),
                    AssertionFailedMessage(States.Idea, s, Stereotypes.RelationExcludedBy));
            }
            // Any Decision to decision with state {tentative, discarded, rejected}
            foreach (var s in Stereotypes.States.Where(s => s != Stereotypes.StateIdea && s != Stereotypes.StateTentative &&
                s != Stereotypes.StateDiscarded && s != Stereotypes.StateRejected))
            {
                Assert.IsFalse(ValidateConnector(s, Stereotypes.StateTentative, Stereotypes.RelationExcludedBy),
                              AssertionFailedMessage(s, Stereotypes.StateTentative, Stereotypes.RelationExcludedBy));
                Assert.IsFalse(ValidateConnector(s, Stereotypes.StateDiscarded, Stereotypes.RelationExcludedBy),
                              AssertionFailedMessage(s, Stereotypes.StateDiscarded, Stereotypes.RelationExcludedBy));
                Assert.IsFalse(ValidateConnector(s, Stereotypes.StateRejected, Stereotypes.RelationExcludedBy),
                              AssertionFailedMessage(s, Stereotypes.StateRejected, Stereotypes.RelationExcludedBy));
            }
            ResetRepository(RepositoryType.Relationships);
            CloseRepositoryFile();
        }

        [TestMethod]
        public void OnPreNewConnector_ExcludedBy_ValidRelationships()
        {
            OpenRepositoryFile(RepositoryType.Relationships);
            ResetRepository(RepositoryType.Relationships);
            // Decision with state {tentative, discarded, rejected} to any decision
            foreach (var s in Stereotypes.States.Where(s => s != Stereotypes.StateIdea && s != Stereotypes.StateTentative &&
                s != Stereotypes.StateDiscarded && s != Stereotypes.StateRejected))
            {
                Assert.IsTrue(ValidateConnector(Stereotypes.StateTentative, s, Stereotypes.RelationExcludedBy),
                              AssertionFailedMessage(Stereotypes.StateTentative, s, Stereotypes.RelationExcludedBy));
                Assert.IsTrue(ValidateConnector(Stereotypes.StateDiscarded, s, Stereotypes.RelationExcludedBy),
                              AssertionFailedMessage(Stereotypes.StateDiscarded, s, Stereotypes.RelationExcludedBy));
                Assert.IsTrue(ValidateConnector(Stereotypes.StateRejected, s, Stereotypes.RelationExcludedBy),
                              AssertionFailedMessage(Stereotypes.StateRejected, s, Stereotypes.RelationExcludedBy));
            }
            ResetRepository(RepositoryType.Relationships);
            CloseRepositoryFile();
        }

        [TestMethod]
        public void OnPreNewConnector_Replaces_InvalidRelationships()
        {
            OpenRepositoryFile(RepositoryType.Relationships);
            ResetRepository(RepositoryType.Relationships);
            //
            ResetRepository(RepositoryType.Relationships);
            CloseRepositoryFile();
        }

        [TestMethod]
        public void OnPreNewConnector_Replaces_ValidRelationships()
        {
            OpenRepositoryFile(RepositoryType.Relationships);
            ResetRepository(RepositoryType.Relationships);
            // Any decision to decision with state Rejected
            foreach (var s in Stereotypes.States.Where(s => s != Stereotypes.StateIdea && s != Stereotypes.StateRejected))
            {
                Assert.IsTrue(ValidateConnector(s, Stereotypes.StateRejected, Stereotypes.RelationReplaces),
                              AssertionFailedMessage(s, Stereotypes.StateRejected, Stereotypes.RelationReplaces));
            }
            ResetRepository(RepositoryType.Relationships);
            CloseRepositoryFile();
        }

        [TestMethod]
        public void OnPreNewConnector_AlternativeFor_InvalidRelationships()
        {
            OpenRepositoryFile(RepositoryType.Relationships);
            ResetRepository(RepositoryType.Relationships);
            // Any Decision to decision with state Idea
            foreach (var s in Stereotypes.States)
            {
                Assert.IsFalse(ValidateConnector(s, Stereotypes.StateIdea, Stereotypes.RelationAlternativeFor),
                    AssertionFailedMessage(s, States.Idea, Stereotypes.RelationAlternativeFor));
            }
            // Decision with state Idea to Any Decision
            foreach (var s in Stereotypes.States)
            {
                Assert.IsFalse(ValidateConnector(States.Idea, s, Stereotypes.RelationAlternativeFor),
                    AssertionFailedMessage(States.Idea, s, Stereotypes.RelationAlternativeFor));
            }
            // Any decision to decision with state Discarded
            foreach (var s in Stereotypes.States.Where(s => s != Stereotypes.StateIdea && s != Stereotypes.StateDiscarded))
            {
                Assert.IsFalse(ValidateConnector(s, Stereotypes.StateDiscarded, Stereotypes.RelationAlternativeFor),
                              AssertionFailedMessage(s, Stereotypes.StateDiscarded, Stereotypes.RelationAlternativeFor));
            }
            ResetRepository(RepositoryType.Relationships);
            CloseRepositoryFile();
        }

        [TestMethod]
        public void OnPreNewConnector_AlternativeFor_ValidRelationships()
        {
            OpenRepositoryFile(RepositoryType.Relationships);
            ResetRepository(RepositoryType.Relationships);
            // Decision with state {tentative, discarded} to any decision
            foreach (var s in Stereotypes.States.Where(s => s != Stereotypes.StateIdea && s != Stereotypes.StateTentative
                && s != Stereotypes.StateDiscarded))
            {
                Assert.IsTrue(ValidateConnector(Stereotypes.StateTentative, s, Stereotypes.RelationAlternativeFor),
                              AssertionFailedMessage(Stereotypes.StateTentative, s, Stereotypes.RelationAlternativeFor));
                Assert.IsTrue(ValidateConnector(Stereotypes.StateDiscarded, s, Stereotypes.RelationAlternativeFor),
                              AssertionFailedMessage(Stereotypes.StateDiscarded, s, Stereotypes.RelationAlternativeFor));
            }
            ResetRepository(RepositoryType.Relationships);
            CloseRepositoryFile();
        }

        private bool ValidateConnector(string supplierState, string clientState, string relationshipStereotype)
        {
            Package root = Repo.Models.GetAt(0);
            Package view = root.Packages.GetAt(0);
            Diagram diagram = view.Diagrams.GetAt(0);
            // Get the supplier Decision element from the Repository
            Element supplier = view.Elements.GetByName(clientState);
            // Get the client Decision element from the Repository
            Element client = view.Elements.GetByName(supplierState);
            // Create a Relationship between them
            const string type = "ControlFlow";
            Connector c = client.Connectors.AddNew("", type);
            c.Stereotype = relationshipStereotype;
            c.SupplierID = supplier.ElementID;
            c.Update();
            supplier.Connectors.Refresh();
            client.Connectors.Refresh();
            // Test if the relationship can be created
            var info = new EventPropertiesHelper();
            info.Set(EventPropertyKeys.Type, type);
            info.Set(EventPropertyKeys.Subtype, "");
            info.Set(EventPropertyKeys.Stereotype, relationshipStereotype);
            info.Set(EventPropertyKeys.ClientId, client.ElementID.ToString(CultureInfo.InvariantCulture));
            info.Set(EventPropertyKeys.SupplierId, supplier.ElementID.ToString(CultureInfo.InvariantCulture));
            info.Set(EventPropertyKeys.DiagramId, diagram.DiagramID.ToString(CultureInfo.InvariantCulture));
            return MainApp.EA_OnPreNewConnector(Repo, info);
        }

        private static string AssertionFailedMessage(string clientState, string supplierState, string relationshipType)
        {
            return String.Format("Assertion Failed with client state {0}, supplier state: {1}, and relationship type: {2}", 
                    clientState, supplierState, relationshipType);
        }
    }
}