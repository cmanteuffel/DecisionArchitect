﻿using System;
using System.Diagnostics;
using System.Reflection;
using EA;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DecisionViewpoints.Model;

namespace DecisionViewpointsTests
{
    [TestClass]
    public class DecisionViewpointsBroadcastEventHandlerTests : DecisionViewpointsBaseTests
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
        public void OnPreNewConnector_CausedBy_RelationshipIsNotCreated()
        {
            OpenRepositoryFile(RepositoryType.Relationships);
            ResetRepository(RepositoryType.Relationships);
            const string relationshipType = "Caused By";
            var states = new States();
            // Any Decision to decision with state Idea
            foreach (var s in states.Get())
            {
                Assert.IsFalse(ValidateConnector(s, States.Idea, relationshipType), 
                    AssertionFailedMessage(s, States.Idea, relationshipType));
            }
            // Decision with state Idea to Any Decision
            foreach (var s in states.Get())
            {
                Assert.IsFalse(ValidateConnector(States.Idea, s, relationshipType),
                    AssertionFailedMessage(States.Idea, s, relationshipType));
            }
            // Any decision to decision with state Discarded
            foreach (var s in states.Get())
            {
                Assert.IsFalse(ValidateConnector(s, States.Discarded, relationshipType),
                    AssertionFailedMessage(s, States.Discarded, relationshipType));
            }
            ResetRepository(RepositoryType.Relationships);
            CloseRepositoryFile();
        }

        [TestMethod]
        public void OnPreNewConnector_CausedBy_RelationshipIsCreated()
        {
            OpenRepositoryFile(RepositoryType.Relationships);
            ResetRepository(RepositoryType.Relationships);
            //const string relationshipType = "Caused By";
            //
            ResetRepository(RepositoryType.Relationships);
            CloseRepositoryFile(); 
        }

        [TestMethod]
        public void OnPreNewConnector_DependsOn_RelationshipIsNotCreated()
        {
            OpenRepositoryFile(RepositoryType.Relationships);
            ResetRepository(RepositoryType.Relationships);
            //const string relationshipType = "Depends On";
            // Any Decision to decision with state Idea
            /*Assert.IsFalse(ValidateConnector(Decided, Idea, relationshipType));
            Assert.IsFalse(ValidateConnector(Tentative, Idea, relationshipType));
            Assert.IsFalse(ValidateConnector(Approved, Idea, relationshipType));
            Assert.IsFalse(ValidateConnector(Challenged, Idea, relationshipType));
            Assert.IsFalse(ValidateConnector(Rejected, Idea, relationshipType));
            Assert.IsFalse(ValidateConnector(Discarded, Idea, relationshipType));
            // Decision with state Idea to Any Decision
            Assert.IsFalse(ValidateConnector(Idea, Decided, relationshipType));
            Assert.IsFalse(ValidateConnector(Idea, Tentative, relationshipType));
            Assert.IsFalse(ValidateConnector(Idea, Approved, relationshipType));
            Assert.IsFalse(ValidateConnector(Idea, Challenged, relationshipType));
            Assert.IsFalse(ValidateConnector(Idea, Rejected, relationshipType));
            Assert.IsFalse(ValidateConnector(Idea, Discarded, relationshipType));
            // Any Decision to decision with states {tentative, decided, approved, challenged}
            Assert.IsFalse(ValidateConnector(Idea, Decided, relationshipType));
            Assert.IsFalse(ValidateConnector(Idea, Tentative, relationshipType));
            Assert.IsFalse(ValidateConnector(Idea, Approved, relationshipType));
            Assert.IsFalse(ValidateConnector(Idea, Challenged, relationshipType));*/
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
            info.Set(EventPropertyKeys.ClientId, client.ElementID.ToString());
            info.Set(EventPropertyKeys.SupplierId, supplier.ElementID.ToString());
            info.Set(EventPropertyKeys.DiagramId, diagram.DiagramID.ToString());
            return MainApp.EA_OnPreNewConnector(Repo, info);
        }

        private string AssertionFailedMessage(string clientState, string supplierState, string relationshipType)
        {
            return String.Format("Assertion Failed with client state {0}, supplier state: {1}, and relationship type: {2}", 
                    clientState, supplierState, relationshipType);
        }
    }
}