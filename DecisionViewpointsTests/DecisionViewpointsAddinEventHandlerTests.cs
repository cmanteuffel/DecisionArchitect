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
            string[] subMenus = {"Create Decision &Views", "Create Decision &Group"};
            var retrievedSubMenus = (string[])mainApp.EA_GetMenuItems(repository, "TreeView", "-&DecisionVS");
            Assert.AreEqual(subMenus[0], retrievedSubMenus[0]);
            Assert.AreEqual(subMenus[1], retrievedSubMenus[1]);
        }

        [TestMethod]
        public void CreateProjectStructure()
        {
            
        }
    }
}
