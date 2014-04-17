using System.IO;
using DecisionViewpoints;
using EA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecisionViewpointsTests
{
    [TestClass]
    [DeploymentItem(@"EATestFiles\", "EATestFiles")]
    public class BaseTests
    {
        public MainApplication MainApp { get; private set; }
        public Repository Repo { get; private set; }

        [TestInitialize]
        public void InitBaseTests()
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
        public void CleanUpBaseTests()
        {
            MainApp.EA_Disconnect();
        }
    }
}