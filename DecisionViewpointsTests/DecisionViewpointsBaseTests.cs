﻿using System.Diagnostics;
using System.IO;
using DecisionViewpoints;
using EA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecisionViewpointsTests
{
    [TestClass]
    public class DecisionViewpointsBaseTests
    {
        //all .eap files should be one location - path to be added later
        private const string UnitTestEmty = "\\EATestFiles\\UntiTestEmpty.eap";
        private const string UnitTestBasicStructure = "\\EATestFiles\\UntiTestBasicStructure.eap";
        private const string UnitTestRelationships = "\\EATestFiles\\UntiTestRelationships.eap";

        public MainApplication MainApp { get; private set; }

        public Repository Repo { get; private set; }

        public enum RepositoryType
        {
            Empty, BasicStructure, Relationships
        }

        public void OpenRepositoryFile(RepositoryType rt)
        {
            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            if (directoryInfo == null) return;
            var projectDirectory = directoryInfo.FullName;
            var filename = "";
            switch (rt)
            {
                case RepositoryType.Empty:
                    filename = projectDirectory + UnitTestEmty;
                    break;
                case RepositoryType.BasicStructure:
                    filename = projectDirectory + UnitTestBasicStructure;
                    break;
                case RepositoryType.Relationships:
                    filename = projectDirectory + UnitTestRelationships;
                    break;
            } 
            Repo.OpenFile(filename);
        }

        public void CloseRepositoryFile()
        {
            Repo.CloseFile();
        }

        public void ResetRepository(RepositoryType rt)
        {
            Package root;
            switch (rt)
            {
                case RepositoryType.Empty:
                    root = Repo.Models.GetAt(0);
                    for (var packageIndex = (short) (root.Packages.Count - 1); packageIndex != -1; packageIndex--)
                    {
                        root.Packages.Delete(packageIndex);
                    }
                    break;
                case RepositoryType.BasicStructure:
                    break;
                case RepositoryType.Relationships:
                    root = Repo.Models.GetAt(0);
                    for (var index = (short)(root.Elements.Count - 1); index != -1; index--)
                    {
                        Element e = root.Elements.GetAt(index);
                        
                    }
                    break;
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
            MainApp = new MainApplication();
        }

        private void CreateRepository()
        {
            Repo = new Repository();
        }

        [TestCleanup]
        public void RunAfterEachTest()
        {
            MainApp.EA_Disconnect();
        }
    }
}
