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
using DecisionArchitectTests.Model.EventProperties;
using NUnit.Framework;

namespace DecisionArchitectTests
{
    [TestFixture]
    public class EAFacadeTests
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
        ///     UpdateRepository ensures the Repository singleton is initialized
        /// </summary>
        [Test]
        public void EA_UpdateRepositoryTest()
        {
            _e.GetDecisionPackage();
        }

        /// <summary>
        ///     WrapConnector creates an object that adds instance properties to a diagram connector
        /// </summary>
        [Test]
        public void EA_WrapConnectorTest()
        {
            Connector connector = _e.GetForcesElementConnector();
            IEAConnector c = EAMain.WrapConnector(connector);
            Assert.IsTrue(connector.ConnectorID == c.ID);
        }

        /// <summary>
        ///     WrapElement creates an object that adds instance properties to to a package element
        /// </summary>
        [Test]
        public void EA_WrapElement_elementTest()
        {
            Element element = _e.GetDecisionPackageElement();
            IEAElement e = EAMain.WrapElement(element);
            Assert.IsTrue(element.ElementID == e.ID);
        }

        /// <summary>
        ///     WrapElement creates an object that adds instance properties to a diagram object element with the ID specified in the event properties
        /// </summary>
        [Test]
        public void EA_WrapElement_eventPropertiesTest()
        {
            IEADiagramObject obj = _e.GetForcesDiagramObject();
            EventProperties properties = EAEventPropertiesHelper.GetInstance("", "", "", 0, 0, 0, obj.ElementID, 0);
            IEAElement e = EAMain.WrapElement(properties);
            Assert.IsTrue(obj.ElementID == e.ID);
        }

        /// <summary>
        ///     WrapVolatileConnector creates an object that adds instance properties to a diagram connector with the ID specified in the event properties
        /// </summary>
        [Test]
        public void EA_WrapVolatileConnectorTest()
        {
            Connector connector = _e.GetForcesElementConnector();
            EventProperties properties = EAEventPropertiesHelper.GetInstance(
                connector.Type, connector.Subtype, connector.Stereotype, connector.ClientID, connector.SupplierID,
                connector.DiagramID, 0, 0);
            IEAVolatileConnector c = EAMain.WrapVolatileConnector(properties);
            Assert.IsTrue(connector.Type == c.Type);
            Assert.IsTrue(connector.Subtype == c.Subtype);
            Assert.IsTrue(connector.ClientID == c.Client.ID);
            Assert.IsTrue(connector.SupplierID == c.Supplier.ID);
            Assert.IsNull(c.Diagram); // Connector diagram ID is zero
        }

        /// <summary>
        ///     WrapVolatileDiagram creates an object that holds the diagram ID specified in the event properties
        /// </summary>
        [Test]
        public void EA_WrapVolatileDiagramTest()
        {
            IEADiagram diagram = _e.GetDecisionForcesDiagram();
            EventProperties properties = EAEventPropertiesHelper.GetInstance("", "", "", 0, 0, diagram.ID, 0, 0);
            IEAVolatileDiagram d = EAMain.WrapVolatileDiagram(properties);
            Assert.IsTrue(diagram.ID == d.DiagramID);
        }

        /// <summary>
        ///     WrapVolatileElement creates an object that adds instance properties to a package diagram with the ID specified in the event properties
        /// </summary>
        [Test]
        public void EA_WrapVolatileElement_diagramTest()
        {
            IEADiagram diagram = _e.GetDecisionForcesDiagram();
            EventProperties properties = EAEventPropertiesHelper.GetInstance("", "", "", 0, 0, diagram.ID, 0, 0);
            IEAVolatileElement e = EAMain.WrapVolatileElement(properties);
            Assert.IsTrue(diagram.ID == e.Diagram.ID);
        }

        /// <summary>
        ///     WrapVolatileElement creates an object that adds instance properties to a package element with the ID specified in the event properties
        /// </summary>
        [Test]
        public void EA_WrapVolatileElement_elementTest()
        {
            Element element = _e.GetDecisionPackageElement();
            EventProperties properties = EAEventPropertiesHelper.GetInstance(
                EAConstants.EventPropertyTypeElement, element.Subtype.ToString(), element.Stereotype, 0, 0, 0, 0,
                element.ElementID);
            IEAVolatileElement e = EAMain.WrapVolatileElement(properties);
            Assert.IsTrue(element.ElementID == e.ParentElement.ID);
        }
    }
}
