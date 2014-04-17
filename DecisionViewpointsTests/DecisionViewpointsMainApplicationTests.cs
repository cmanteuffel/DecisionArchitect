using Microsoft.VisualStudio.TestTools.UnitTesting;
using DecisionViewpoints;
using EA;

namespace DecisionViewpointsTests
{
    [TestClass]
    public class DecisionViewpointsMainApplicationTests
    {
        [TestMethod]
        public void ConnectToRepository()
        {
            var mainApp = new MainApplication();
            var repository = new Repository();
            Assert.AreEqual("connected", mainApp.EA_Connect(repository));
        }
    }
}
