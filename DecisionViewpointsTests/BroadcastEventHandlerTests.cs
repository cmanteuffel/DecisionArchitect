using EA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}