using System;
using DecisionViewpointsTests.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecisionViewpointsTests
{
    [TestClass]
    [DeploymentItem(@"EATestFiles\UnitTestEmpty.eap", "EATestFiles")]
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
            throw new NotSupportedException();
            //string[] subMenus = {AddinEventHandler.MenuCreateProjectStructure};
           // var retrievedSubMenus = (string[]) MainApp.EA_GetMenuItems(Repo, "TreeView", AddinEventHandler.MenuHeader);
           // Assert.AreEqual(subMenus[0], retrievedSubMenus[0]);
        }

        [TestMethod]
        public void GetMenuState_FileClosed_ReturnFalse()
        {
            throw new NotSupportedException();
            // Here we need to close the file first in order for the test to pass and then open it again
           /* _f.Close();
            var isEnabled = false;
            var isChecked = false;
            MainApp.EA_GetMenuState(Repo, "TreeView", AddinEventHandler.MenuHeader,
                                    AddinEventHandler.MenuCreateProjectStructure,
                                    ref isEnabled, ref isChecked);
            _f.Open();
            Assert.IsFalse(isEnabled);*/
        }

        [TestMethod]
        public void GetMenuState_FileOpen_ReturnTrue()
        {
            throw new NotSupportedException();
            /*var isEnabled = false;
            var isChecked = false;
            MainApp.EA_GetMenuState(Repo, "TreeView", AddinEventHandler.MenuHeader, AddinEventHandler.MenuCreateProjectStructure,
                                    ref isEnabled, ref isChecked);
            Assert.IsTrue(isEnabled);*/
        }

        [TestMethod]
        public void MenuClick_CreateProjectStructure_ExpectedStructureCreated()
        {
            throw new NotSupportedException();
            /*_f.Reset();
            MainApp.EA_MenuClick(Repo, "TreeView", AddinEventHandler.MenuHeader, AddinEventHandler.MenuCreateProjectStructure);
            Package root = Repo.Models.GetAt(0);
            Package rv = root.Packages.GetAt(0);
            Diagram rd = rv.Diagrams.GetAt(0);
            Package cv = root.Packages.GetAt(1);
            Diagram cd = cv.Diagrams.GetAt(0);
            Package siv = root.Packages.GetAt(2);
            Diagram sid = siv.Diagrams.GetAt(0);
            _f.Reset();
            Assert.AreEqual("Relationship", rv.Name);
            Assert.AreEqual("Diagram1", rd.Name);
            Assert.AreEqual("Chronological", cv.Name);
            Assert.AreEqual("Diagram1", cd.Name);
            Assert.AreEqual("Stakeholder Involvement", siv.Name);
            Assert.AreEqual("Diagram1", sid.Name);*/
        }
    }
}