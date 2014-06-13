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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EA;
using EAFacade;
using EAFacade.Model;
using EAFacade.Model.Impl;
using EAFacadeTests.Model;
using EAFacadeTests.Model.EventProperties;
using EAFacadeTests.Logic;
using NUnit.Framework;
namespace EAFacade.Tests
{
    [TestFixture()]
    public class EATests
    {
        public Repository Repo { get; private set; }

        private ExampleRepositoryFile _f;

        private IEAPackage GetDecisionPackage()
        {
            IEAPackage package = null;
            Assert.IsNotNull(Repo);
            EA.UpdateRepository(Repo);
            IEnumerable<IEAPackage> packages = EA.Repository.GetAllDecisionViewPackages();
            Assert.IsNotNull(packages);
            // Use the first decision package
            package = packages.ElementAt<IEAPackage>(0);
            Assert.IsNotNull(package);
            return package;
        }

        private IEADiagram GetDecisionForcesDiagram()
        {
            IEADiagram diagram = null;
            IEAPackage package = GetDecisionPackage();
            IEnumerable<IEADiagram> diagrams = package.GetAllDiagrams();
            Assert.IsNotNull(diagrams);
            // Find a forces viewpoint
            foreach(IEADiagram d in diagrams)
            {
                if (d.IsForcesView())
                {
                    diagram = d;
                    break;
                }
            }
            Assert.IsNotNull(diagram);
            return diagram;
        }

        private IEADiagramObject GetForcesDiagramObject()
        {
            IEADiagramObject obj = null;
            IEADiagram diagram = GetDecisionForcesDiagram();
            IEnumerable<IEADiagramObject> objects = diagram.GetElements();
            Assert.IsNotNull(objects);
            obj = objects.ElementAt<IEADiagramObject>(0);
            Assert.IsNotNull(obj);
            return obj;
        }

        private Element GetDecisionPackageElement()
        {
            Element element = null;
            IEAPackage package = GetDecisionPackage();
            Package root = Repo.Models.GetAt(0);
            Assert.IsNotNull(root);
            Package view = root.Packages.GetByName(package.Name);
            Assert.IsNotNull(view);
            element = view.Elements.GetAt(0);
            Assert.IsNotNull(element);
            return element;
        }

        private Connector GetForcesElementConnector()
        {
            Connector connector = null;
            Element element = GetDecisionPackageElement();
            Collection connectors = element.Connectors;
            Assert.IsNotNull(connectors);
            connector = connectors.GetAt(0);
            Assert.IsNotNull(connector);
            return connector;
        }

        [SetUp()]
        public void InitEATests()
        {
            Repo = new Repository();
            _f = new ExampleRepositoryFile(Repo);
            _f.Open();
        }

        [TearDown()]
        public void CleanupEATests()
        {
            _f.Close();
        }

        /// <summary>
        /// UpdateRepository ensures the Repository singleton is initialized
        /// </summary>
        [Test()]
        public void EA_UpdateRepositoryTest()
        {
            GetDecisionPackage();
        }

        /// <summary>
        /// WrapElement creates an object that adds instance properties to a diagram object element with the ID specified in the event properties
        /// </summary>
        [Test()]
        public void EA_WrapElement_eventPropertiesTest()
        {
            IEADiagramObject obj = GetForcesDiagramObject();
            EventProperties properties = EAEventPropertiesHelper.GetInstance("", "", "", 0, 0, 0, obj.ElementID, 0);
            IEAElement e = EA.WrapElement(properties);
            Assert.IsTrue(obj.ElementID == e.ID);
        }

        /// <summary>
        /// WrapElement creates an object that adds instance properties to to a package element
        /// </summary>
        [Test()]
        public void EA_WrapElement_elementTest()
        {
            Element element = GetDecisionPackageElement();
            IEAElement e = EA.WrapElement(element);
            Assert.IsTrue(element.ElementID == e.ID);
        }

        /// <summary>
        /// WrapConnector creates an object that adds instance properties to a diagram connector
        /// </summary>
        [Test()]
        public void EA_WrapConnectorTest()
        {
            Connector connector = GetForcesElementConnector();
            IEAConnector c = EA.WrapConnector(connector);
            Assert.IsTrue(connector.ConnectorID == c.ID);
        }

        /// <summary>
        /// WrapVolatileConnector creates an object that adds instance properties to a diagram connector with the ID specified in the event properties
        /// </summary>
        [Test()]
        public void EA_WrapVolatileConnectorTest()
        {
            Connector connector = GetForcesElementConnector();
            EventProperties properties = EAEventPropertiesHelper.GetInstance(
                connector.Type, connector.Subtype, connector.Stereotype, connector.ClientID, connector.SupplierID, connector.DiagramID, 0, 0);
            IEAVolatileConnector c = EA.WrapVolatileConnector(properties);
            Assert.IsTrue(connector.Type == c.Type);
            Assert.IsTrue(connector.Subtype == c.Subtype);
            Assert.IsTrue(connector.ClientID == c.Client.ID);
            Assert.IsTrue(connector.SupplierID == c.Supplier.ID);
            Assert.IsNull(c.Diagram);  // Connector diagram ID is zero
        }

        /// <summary>
        /// WrapVolatileDiagram creates an object that holds the diagram ID specified in the event properties
        /// </summary>
        [Test()]
        public void EA_WrapVolatileDiagramTest()
        {
            IEADiagram diagram = GetDecisionForcesDiagram();
            EventProperties properties = EAEventPropertiesHelper.GetInstance("", "", "", 0, 0, diagram.ID, 0, 0);
            IEAVolatileDiagram d = EA.WrapVolatileDiagram(properties);
            Assert.IsTrue(diagram.ID == d.DiagramID);
        }

        /// <summary>
        /// WrapVolatileElement creates an object that adds instance properties to a package element with the ID specified in the event properties
        /// </summary>
        [Test()]
        public void EA_WrapVolatileElement_elementTest()
        {
            Element element = GetDecisionPackageElement();
            EventProperties properties = EAEventPropertiesHelper.GetInstance(
                EAConstants.EventPropertyTypeElement, element.Subtype.ToString(), element.Stereotype, 0, 0, 0, 0, element.ElementID);
            IEAVolatileElement e = EA.WrapVolatileElement(properties);
            Assert.IsTrue(element.ElementID == e.ParentElement.ID);
        }

        /// <summary>
        /// WrapVolatileElement creates an object that adds instance properties to a package diagram with the ID specified in the event properties
        /// </summary>
        [Test()]
        public void EA_WrapVolatileElement_diagramTest()
        {
            IEADiagram diagram = GetDecisionForcesDiagram();
            EventProperties properties = EAEventPropertiesHelper.GetInstance("", "", "", 0, 0, diagram.ID, 0, 0);
            IEAVolatileElement e = EA.WrapVolatileElement(properties);
            Assert.IsTrue(diagram.ID == e.Diagram.ID);
        }
    }
}
