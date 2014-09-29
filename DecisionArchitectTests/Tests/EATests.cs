/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    K. Eric Harper (ABB Corporate Research)
*/

using System;
using System.Collections.Generic;
using System.Linq;
using EA;
using EAFacade;
using EAFacade.Model;
using NUnit.Framework;

namespace DecisionArchitectTests
{
    [TestFixture]
    public class EATests
    {
        private Example _e;

        [SetUp]
        public void InitEATests()
        {
            _e = new Example();
        }

        [TearDown]
        public void CleanupEATests()
        {
        }

        /// <summary>
        ///     ConfirmMDG verifies if the Decision type is recognized.
        ///     This test will fail if the MDG file DecisionArchitectMDG.xml is not manually added to the
        ///     SparxSystems/EAMain/MDGTechnologies folder. The decision elements will have the Action instead of DADecision type.
        /// </summary>
        [Test]
        public void EA_ConfirmMDG()
        {
            bool validMDG = false;
            IEAPackage package = _e.GetDecisionPackage();
            IEnumerable<IEAElement> topics = package.GetAllTopics();
            Assert.IsTrue(0 < topics.Count());
            foreach (IEAElement topic in topics)
            {
                // Confirm the topic contains decision elements
                IEnumerable<IEAElement> elems = topic.GetElements();
                foreach (IEAElement elem in elems)
                {
                    if (EAConstants.DecisionMetaType == elem.MetaType)
                    {
                        validMDG = true;
                        break;
                    }
                }
                if (validMDG)
                {
                    break;
                }
            }
            Assert.IsTrue(validMDG);
        }
    }
}
