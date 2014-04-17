using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DecisionViewpoints;
using EA;

namespace DecisionViewpointsTests
{
    [TestClass]
    public class DecisionViewpointsAddinEventHandlerTests
    {
        [TestMethod]
        public void ConnectToRepository()
        {
            var mainApp = new MainApplication();
            var repository = new Repository();
            Assert.AreEqual("connected", mainApp.EA_Connect(repository));
        }

        [TestMethod]
        public void GetMenuItems()
        {
            var mainApp = new MainApplication();
            var repository = new Repository();
            string[] subMenus = {"Create Decision &Views"};
            var retrievedSubMenus = (string[])mainApp.EA_GetMenuItems(repository, "TreeView", "-&DecisionVS");
            Assert.AreEqual(subMenus[0], retrievedSubMenus[0]);
        }

        [TestMethod]
        public void CreateProjectStructure()
        {
            var mainApp = new MainApplication();
            var repository = new Repository();
            const string filename =
                "F:\\DecisionViewpoints\\ViewpointsAddIn\\src\\DecisionViewpointsTests\\DecisionViewUnitTestsProject.eap";
            Assert.IsTrue(repository.OpenFile(filename));
            mainApp.EA_MenuClick(repository, "TreeView", "-&DecisionVS", "Create Decision &Views");
            Package root = repository.Models.GetAt(0);
            Package view = root.Packages.GetAt(0);
            Assert.AreEqual("Decision Relationship View", view.Name);
            Diagram diagram = view.Diagrams.GetAt(0);
            Assert.AreEqual("Decision Relationship View", diagram.Name);
            // Delete whatever we added so the file is clean and close the file.
            for (var packageIndex = (short)(root.Packages.Count - 1); packageIndex != -1; packageIndex--)
            {
                root.Packages.Delete(packageIndex);
            }
            repository.CloseFile();
        }
    }
}
