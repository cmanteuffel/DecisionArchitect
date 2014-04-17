using EA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecisionViewpointsTests
{
    [TestClass]
    public class DecisionViewpointsBroadcastEventHandlerTests : DecisionViewpointsBaseTests
    {
        private const string Idea = "Idea";
        private const string Tentative = "Tentative";
        private const string Decided = "Decided";
        private const string Approved = "Approved";
        private const string Challenged = "Challenged";
        private const string Rejected = "Decided";
        private const string Discarded = "Discarded";

        [TestMethod]
        public void OnPostOpenDiagram_OpenDecisionViewpointDiagram_ToolboxActivated()
        {
            OpenRepositoryFile(RepositoryType.BasicStructure);
            ResetRepository(RepositoryType.BasicStructure);
            Package root = Repo.Models.GetAt(0);
            Package view = root.Packages.GetAt(0);
            Diagram diagram = view.Diagrams.GetAt(0);
            Repo.OpenDiagram(diagram.DiagramID);
            string toolboxName = MainApp.EA_OnPostOpenDiagram(Repo, diagram.DiagramID);
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
            // Any decision to decision with state Idea
            Assert.IsFalse(ValidateConnector(Decided, Idea, relationshipType));
            Assert.IsFalse(ValidateConnector(Tentative, Idea, relationshipType));
            Assert.IsFalse(ValidateConnector(Approved, Idea, relationshipType));
            Assert.IsFalse(ValidateConnector(Challenged, Idea, relationshipType));
            Assert.IsFalse(ValidateConnector(Rejected, Idea, relationshipType));
            Assert.IsFalse(ValidateConnector(Discarded, Idea, relationshipType));
            // Decision with state Idea to any Decision
            Assert.IsFalse(ValidateConnector(Idea, Decided, relationshipType));
            Assert.IsFalse(ValidateConnector(Idea, Tentative, relationshipType));
            Assert.IsFalse(ValidateConnector(Idea, Approved, relationshipType));
            Assert.IsFalse(ValidateConnector(Idea, Challenged, relationshipType));
            Assert.IsFalse(ValidateConnector(Idea, Rejected, relationshipType));
            Assert.IsFalse(ValidateConnector(Idea, Discarded, relationshipType));
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
            var info = EventPropertiesHelper.Create(type, "", relationshipStereotype, client.ElementID,
                                                                      supplier.ElementID, diagram.DiagramID);
            return MainApp.EA_OnPreNewConnector(Repo, info);
        }
    }
}