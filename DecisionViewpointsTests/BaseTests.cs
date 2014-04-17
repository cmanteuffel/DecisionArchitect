using System.Diagnostics;
using System.IO;
using DecisionViewpoints;
using DecisionViewpoints.Model.Rules;
using EA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecisionViewpointsTests
{
    [TestClass]
    public class BaseTests
    {
        //all .eap files should be one location - path to be added later
        private const string UnitTestEmty = "\\EATestFiles\\UntiTestEmpty.eap";
        private const string UnitTestBasicStructure = "\\EATestFiles\\UntiTestBasicStructure.eap";
        private const string UnitTestRelationships = "\\EATestFiles\\UntiTestRelationships.eap";

        public MainApplication MainApp { get; private set; }
        public Repository Repo { get; private set; }

        public enum RepositoryType
        {
            Empty,
            BasicStructure,
            Relationships
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
                    ResetEmptyRepository(root);
                    break;
                case RepositoryType.BasicStructure:
                    break;
                case RepositoryType.Relationships:
                    root = Repo.Models.GetAt(0);
                    ResetRelationshipRepository(root);
                    break;
            }
        }

        private static void ResetEmptyRepository(IDualPackage root)
        {
            for (var packageIndex = (short) (root.Packages.Count - 1); packageIndex != -1; packageIndex--)
            {
                root.Packages.Delete(packageIndex);
            }
        }

        private static void ResetRelationshipRepository(IDualPackage root)
        {
            Package view = root.Packages.GetAt(0);
            for (var elemIndex = (short) (view.Elements.Count - 1); elemIndex != -1; elemIndex--)
            {
                Element e = view.Elements.GetAt(elemIndex);
                for (var conIndex = (short) (e.Connectors.Count - 1); conIndex != -1; conIndex--)
                {
                    e.Connectors.Delete(conIndex);
                }
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