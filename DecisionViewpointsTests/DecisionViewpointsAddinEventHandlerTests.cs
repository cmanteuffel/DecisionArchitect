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
        public void EaConnect_ReturnConnected()
        {
            Assert.AreEqual("connected", _mainApp.EA_Connect(_repository));
        }

        [TestMethod]
        public void GetMenuItems_ReturnCorrectSubmenus()
        {
            string[] subMenus = {"Create Decision &Views"};
            var retrievedSubMenus = (string[])_mainApp.EA_GetMenuItems(_repository, "TreeView", "-&DecisionVS");
            Assert.AreEqual(subMenus[0], retrievedSubMenus[0]);
        }

        [TestMethod]
        public void GetMenuState_FileClosed_ReturnFalse()
        {
            var isEnabled = false;
            var isChecked = false;
            _mainApp.EA_GetMenuState(_repository, "TreeView", "-&DecisionVS", "Create Decision &Views",
                ref isEnabled, ref isChecked);
            Assert.IsFalse(isEnabled);
            
        }

        [TestMethod]
        public void GetMenuState_FileOpen_ReturnTrue()
        {
            OpenRepositoryFile();
            var isEnabled = false;
            var isChecked = false;
            _mainApp.EA_GetMenuState(_repository, "TreeView", "-&DecisionVS", "Create Decision &Views",
                ref isEnabled, ref isChecked);
            Assert.IsTrue(isEnabled);
            CloseRepositoryFile();
        }

        [TestMethod]
        public void MenuClick_CreateProjectStructure_ExpectedStructureCreated()
        {
            OpenRepositoryFile();
            _mainApp.EA_MenuClick(_repository, "TreeView", "-&DecisionVS", "Create Decision &Views");
            Package root = _repository.Models.GetAt(0);
            Package view = root.Packages.GetAt(0);
            Assert.AreEqual("Decision Relationship View", view.Name);
            Diagram diagram = view.Diagrams.GetAt(0);
            Assert.AreEqual("Decision Relationship View", diagram.Name);
            ClearRepository();
            CloseRepositoryFile();
        }

        private void OpenRepositoryFile()
        {
            const string filename =
                "F:\\DecisionViewpoints\\ViewpointsAddIn\\src\\DecisionViewpointsTests\\DecisionViewUnitTestsProject.eap";
            _repository.OpenFile(filename);
        }

        private void CloseRepositoryFile()
        {
            _repository.CloseFile();
        }

        private void ClearRepository()
        {
            Package root = _repository.Models.GetAt(0);
            for (var packageIndex = (short)(root.Packages.Count - 1); packageIndex != -1; packageIndex--)
            {
                root.Packages.Delete(packageIndex);
            }
        }

        [TestInitialize]
        public void RunBeforeEachTest()
        {
            CreateMainApplication();
            CreateRepository();
        }

        private void CreateMainApplication()
        {
            _mainApp = new MainApplication();
        }

        private void CreateRepository()
        {
            _repository = new Repository();
        }

        private MainApplication _mainApp;
        private Repository _repository;

        [TestCleanup]
        public void RunAfterEachTest()
        {
            _mainApp.EA_Disconnect();
        }
    }
}
