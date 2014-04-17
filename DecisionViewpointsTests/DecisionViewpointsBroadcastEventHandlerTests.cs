using EA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void OnPreNewConnector_ValidateInvalidRelationship_RelationshipIsNotCreated()
        {
            OpenRepositoryFile(RepositoryType.Relationships);
            ResetRepository(RepositoryType.Relationships);
            var result = ValidateConnector("Decided", "Idea", "Caused By");
            ResetRepository(RepositoryType.Relationships);
            CloseRepositoryFile();
            Assert.IsFalse(result);
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
