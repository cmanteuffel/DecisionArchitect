using DecisionViewpoints.Logic;
using DecisionViewpointsTests.Logic;
using EA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecisionViewpointsTests
{
    [TestClass]
    public class AddinEventHandlerTests : BaseTests
    {
        private EmptyRepositoryFile _f;

        [TestInitialize]
        public void InitAddinEventHandlerTest()
        {
            _f = new EmptyRepositoryFile(Repo);
            _f.Open();
        }

        [TestCleanup]
        public void CleanUpAddinEventHandlerTests()
        {
            _f.Close();
        }

        [TestMethod]
        public void EaConnect_ReturnConnected()
        {
            Assert.AreEqual("", MainApp.EA_Connect(Repo));
        }

        [TestMethod]
        public void GetMenuItems_ReturnCorrectSubmenus()
        {
            string[] subMenus = {AddinEventHandler.MenuCreateProjectStructure};
            var retrievedSubMenus = (string[]) MainApp.EA_GetMenuItems(Repo, "TreeView", AddinEventHandler.MenuHeader);
            Assert.AreEqual(subMenus[0], retrievedSubMenus[0]);
        }

        [TestMethod]
        public void GetMenuState_FileClosed_ReturnFalse()
        {
            // Here we need to close the file first in order for the test to pass and then open it again
            _f.Close();
            var isEnabled = false;
            var isChecked = false;
            MainApp.EA_GetMenuState(Repo, "TreeView", AddinEventHandler.MenuHeader,
                                    AddinEventHandler.MenuCreateProjectStructure,
                                    ref isEnabled, ref isChecked);
            _f.Open();
            Assert.IsFalse(isEnabled);
        }

        [TestMethod]
        public void GetMenuState_FileOpen_ReturnTrue()
        {
            var isEnabled = false;
            var isChecked = false;
            MainApp.EA_GetMenuState(Repo, "TreeView", AddinEventHandler.MenuHeader, AddinEventHandler.MenuCreateProjectStructure,
                                    ref isEnabled, ref isChecked);
            Assert.IsTrue(isEnabled);
        }

        [TestMethod]
        public void MenuClick_CreateProjectStructure_ExpectedStructureCreated()
        {
            _f.Reset();
            MainApp.EA_MenuClick(Repo, "TreeView", AddinEventHandler.MenuHeader, AddinEventHandler.MenuCreateProjectStructure);
            Package root = Repo.Models.GetAt(0);
            Package view = root.Packages.GetAt(0);
            Diagram diagram = view.Diagrams.GetAt(0);
            _f.Reset();
            Assert.AreEqual("Decision Relationship View", view.Name);
            Assert.AreEqual("Diagram1", diagram.Name);
        }
    }
}