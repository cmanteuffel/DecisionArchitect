﻿using EA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecisionViewpointsTests
{
    [TestClass]
    public class DecisionViewpointsAddinEventHandlerTests : DecisionViewpointsBaseTests
    {
        [TestMethod]
        public void EaConnect_ReturnConnected()
        {
            Assert.AreEqual("connected", MainApp.EA_Connect(Repo));
        }

        [TestMethod]
        public void GetMenuItems_ReturnCorrectSubmenus()
        {
            string[] subMenus = {"Create Decision &Views"};
            var retrievedSubMenus = (string[])MainApp.EA_GetMenuItems(Repo, "TreeView", "-&DecisionVS");
            Assert.AreEqual(subMenus[0], retrievedSubMenus[0]);
        }

        [TestMethod]
        public void GetMenuState_FileClosed_ReturnFalse()
        {
            var isEnabled = false;
            var isChecked = false;
            MainApp.EA_GetMenuState(Repo, "TreeView", "-&DecisionVS", "Create Decision &Views",
                ref isEnabled, ref isChecked);
            Assert.IsFalse(isEnabled);
        }

        [TestMethod]
        public void GetMenuState_FileOpen_ReturnTrue()
        {
            OpenRepositoryFile();
            var isEnabled = false;
            var isChecked = false;
            MainApp.EA_GetMenuState(Repo, "TreeView", "-&DecisionVS", "Create Decision &Views",
                ref isEnabled, ref isChecked);
            CloseRepositoryFile();
            Assert.IsTrue(isEnabled);
        }

        [TestMethod]
        public void MenuClick_CreateProjectStructure_ExpectedStructureCreated()
        {
            OpenRepositoryFile();
            ClearRepository();
            MainApp.EA_MenuClick(Repo, "TreeView", "-&DecisionVS", "Create Decision &Views");
            Package root = Repo.Models.GetAt(0);
            Package view = root.Packages.GetAt(0);
            Diagram diagram = view.Diagrams.GetAt(0);
            ClearRepository();
            CloseRepositoryFile();
            Assert.AreEqual("Decision Relationship View", view.Name);
            Assert.AreEqual("Decision Relationship View", diagram.Name);
        }
    }
}
