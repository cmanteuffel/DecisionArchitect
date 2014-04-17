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
        private const string EapTestProjectName = "\\DecisionViewUnitTestsProject.eap";

        public MainApplication MainApp { get; private set; }

        public Repository Repo { get; private set; }

        public void OpenRepositoryFile()
        {
            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            if (directoryInfo == null) return;
            var projectDirectory = directoryInfo.FullName;
            var filename = projectDirectory + EapTestProjectName;
            Repo.OpenFile(filename);
        }

        public void CloseRepositoryFile()
        {
            Repo.CloseFile();
        }

        public void ClearRepository()
        {
            Package root = Repo.Models.GetAt(0);
            for (short packageIndex = (short) (root.Packages.Count - 1); packageIndex != -1; packageIndex--)
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
