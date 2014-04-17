using System.Diagnostics;
using System.Globalization;
using DecisionViewpoints;
using EA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecisionViewpointsTests
{
    [TestClass]
    public class DecisionViewpointsBroadcastEventHandlerTests : DecisionViewpointsBaseTests
    {
        [TestMethod]
        public void OnPostOpenDiagram_ToolboxActivated_True()
        {
            OpenRepositoryFile();
            MainApp.EA_MenuClick(Repo, "TreeView", "-&DecisionVS", "Create Decision &Views");
            Package root = Repo.Models.GetAt(0);
            Package view = root.Packages.GetAt(0);
            Diagram diagram = view.Diagrams.GetAt(0);
            Repo.OpenDiagram(diagram.DiagramID);
            var toolboxActivated = MainApp.EA_OnPostOpenDiagram(Repo, diagram.DiagramID);
            Assert.IsTrue(toolboxActivated);
        }
    }
}
