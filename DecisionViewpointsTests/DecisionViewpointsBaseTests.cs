using System.IO;
using DecisionViewpoints;
using EA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecisionViewpointsTests
{
    [TestClass]
    public class DecisionViewpointsBaseTests
    {
        public MainApplication MainApp { get; private set; }

        public Repository Repo { get; private set; }

        public void OpenRepositoryFile()
        {
            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            if (directoryInfo == null) return;
            var projectDirectory = directoryInfo.FullName;
            var filename = projectDirectory + "\\DecisionViewUnitTestsProject.eap";
            Repo.OpenFile(filename);
        }

        public void CloseRepositoryFile()
        {
            Repo.CloseFile();
        }

        public void ClearRepository()
        {
            Package root = Repo.Models.GetAt(0);
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
