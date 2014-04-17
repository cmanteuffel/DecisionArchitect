using System.IO;
using DecisionViewpoints;
using EA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecisionViewpointsTests
{
    [TestClass]
    public class BaseTests
    {
        public MainApplication MainApp { get; private set; }
        public Repository Repo { get; private set; }

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