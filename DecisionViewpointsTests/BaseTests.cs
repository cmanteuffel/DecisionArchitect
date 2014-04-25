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
