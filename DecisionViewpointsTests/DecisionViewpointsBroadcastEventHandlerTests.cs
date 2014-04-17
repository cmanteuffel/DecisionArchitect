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
            OpenRepositoryFile();
            ClearRepository();
            MainApp.EA_MenuClick(Repo, "TreeView", "-&Decision Viewpoints", "&Create Project Structure");
            Package root = Repo.Models.GetAt(0);
            Package view = root.Packages.GetAt(0);
            Diagram diagram = view.Diagrams.GetAt(0);
            Repo.OpenDiagram(diagram.DiagramID);
            var toolboxActivated = MainApp.EA_OnPostOpenDiagram(Repo, diagram.DiagramID);
            ClearRepository();
            CloseRepositoryFile();
            Assert.IsTrue(toolboxActivated);
        }
    }
}
