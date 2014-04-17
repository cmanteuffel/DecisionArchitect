using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DecisionViewpoints;

namespace DecisionViewpointsTests
{
    [TestClass]
    public class DecisionViewpointsEventHandlerTests
    {
        [TestMethod]
        public void Connect()
        {
            var eventHandler = new DecisionViewpoints.EventHandler();

            Assert.AreEqual("connected", eventHandler.Connect());
        }
    }
}
