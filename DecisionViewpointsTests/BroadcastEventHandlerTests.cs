/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
*/

using System.Diagnostics;
using DecisionViewpointsTests.Logic;
using EA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecisionViewpointsTests
{
    [TestClass]
    [DeploymentItem(@"EATestFiles\UnitTestBasicStructure.eap", "EATestFiles")]
    public class BroadcastEventHandlerTests : BaseTests
    {
        private BasicStructureRepositoryFile _f;

        [TestInitialize]
        public void InitBroadcastEventHandlerTests()
        {
            _f = new BasicStructureRepositoryFile(Repo);
            _f.Open();
        }

        [TestCleanup]
        public void CleanUpBroadcastEventHandlerTests()
        {
            _f.Close();
        }

        [TestMethod]
        public void OnPostOpenDiagram_OpenDecisionViewpointDiagram_ToolboxActivated()
        {
            /*_f.Reset();
            Package root = Repo.Models.GetAt(0);
            Package view = root.Packages.GetAt(0);
            Diagram diagram = view.Diagrams.GetAt(0);
            Repo.OpenDiagram(diagram.DiagramID);
            var toolboxName = MainApp.EA_OnPostOpenDiagram(Repo, diagram.DiagramID);
            _f.Reset();
            Assert.AreEqual("DecisionVS", toolboxName);*/
        }
    }
}
