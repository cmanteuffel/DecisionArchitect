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
using EATestSupport;
using EATestSupport.Model;
using EATestSupport.Model.EventProperties;
using EATestSupport.Logic;
using NUnit.Framework;

namespace EAFacade.Tests
{
    [TestFixture()]
    public class EATests
    {
        private Example _e;

        [SetUp()]
        public void InitEATests()
        {
            _e = new Example();
        }

        [TearDown()]
        public void CleanupEATests()
        {
        }

        private bool deleteElementFromPackage(IEAPackage package, IEAElement element)
        {
            short i = 0;
            bool found = false;
            foreach (IEAElement e in package.Elements)
            {
                if (element.ID == e.ID)
                {
                    package.DeleteElement(i);
                    found = true;
                    break;
                }
                i++;
            }
            return found;
        }

        /// <summary>
        /// Package exercises the package properties and operations
        /// </summary>
        [Test()]
        public void EA_PackageTest()
        {
            // Properties
            
            {
                IEAPackage package = _e.GetDecisionPackage();
                Assert.IsTrue(System.DateTime.Today > package.Created);
                Assert.IsTrue(EANativeType.Package == package.EANativeType);
                Assert.IsTrue(0 < package.Elements.Count<IEAElement>());
                Assert.IsTrue("" != package.GUID);
                Assert.IsTrue(0 < package.ID);
                Assert.IsTrue(System.DateTime.Today > package.Modified);
                Assert.IsTrue("" != package.Name);
                Assert.IsTrue("" == package.Notes);
                Assert.IsTrue(0 < package.Packages.Count<IEAPackage>());
                Assert.IsNotNull(package.ParentPackage);
                Assert.IsTrue("" == package.Version);
                Assert.IsTrue("" == package.Stereotype);
            }

            // Operations
            // See the Type property in the EAMain Element class documentation for a list of valid element types.

            {  // CreatePackage / DeletePackage
                IEAPackage package = _e.GetDecisionPackage();
                IEAPackage inner = package.CreatePackage("MyPackage", "MyStereotype");
                Assert.IsNotNull(inner);
                package.RefreshElements();
                Assert.IsTrue("MyPackage" == inner.Name);
                Assert.IsTrue("MyStereotype" == inner.Stereotype);
                package.DeletePackage(inner);
            }

            {  // CreateElement
                IEAPackage package = _e.GetDecisionPackage();
                IEAElement element = package.CreateElement("MyNote", "MyStereotype", "Note");
                Assert.IsNotNull(element);
                package.RefreshElements();
                Assert.IsTrue("MyNote" == element.Name);
                Assert.IsTrue("MyStereotype" == element.Stereotype);
                Assert.IsTrue("Note" == element.Type);
                Assert.IsTrue(deleteElementFromPackage(package, element));
            }

            {  // GetAllDiagrams / GetDiagram
                IEAPackage package = _e.GetDecisionPackage();
                IEnumerable<IEADiagram> diagrams = package.GetAllDiagrams();
                Assert.IsNotNull(diagrams);
                IEADiagram first = diagrams.ElementAt<IEADiagram>(0);
                IEADiagram diagram = package.GetDiagram(first.Name);
                Assert.IsNotNull(diagram);
                Assert.IsTrue(first.ID == diagram.ID);
            }

            {  // RefreshElements
                IEAPackage package = _e.GetDecisionPackage();
                package.RefreshElements();
            }

            {  // AddElement / DeleteElement
                IEAPackage package = _e.GetDecisionPackage();
                IEAElement element = package.AddElement("MyNote", "Note");
                Assert.IsNotNull(element);
                package.RefreshElements();
                Assert.IsTrue("MyNote" == element.Name);
                Assert.IsTrue("" == element.Stereotype);
                Assert.IsTrue("Note" == element.Type);
                Assert.IsTrue(deleteElementFromPackage(package, element));
            }

            {  // GetAllElementsOfSubTree
                IEAPackage package = _e.GetDecisionPackage();
                IEnumerable<IEAElement> elements = package.GetAllElementsOfSubTree();
                Assert.IsNotNull(elements);
                Assert.IsTrue(0 < elements.Count<IEAElement>());
            }

            {  // GetAllDecisions
                IEAPackage package = _e.GetDecisionPackage();
                IEnumerable<IEAElement> actions = package.GetAllDecisions();
                Assert.IsNotNull(actions);
                Assert.IsTrue(0 < actions.Count<IEAElement>());
            }

            {  // GetAllTopics
                IEAPackage package = _e.GetDecisionPackage();
                IEnumerable<IEAElement> elements = package.GetAllTopics();
                Assert.IsNotNull(elements);
                Assert.IsTrue(0 < elements.Count<IEAElement>());
            }

            {  // GetSubpackageByName / FindDecisionViewPackage / IsDecisionViewPackage
                IEAPackage package = _e.GetDecisionPackage();
                IEAPackage components = package.GetSubpackageByName("Component Model");
                Assert.IsNotNull(components);
                IEAPackage decisionView = components.FindDecisionViewPackage();
                Assert.IsNotNull(decisionView);
                Assert.IsTrue(EANativeType.Package == decisionView.EANativeType);
                Assert.IsTrue(package.ID == decisionView.ID);
                Assert.IsTrue(decisionView.IsDecisionViewPackage());
            }

            {  // GetDiagrams
                IEAPackage package = _e.GetDecisionPackage();
                IEnumerable<IEADiagram> diagrams = package.GetDiagrams();
                Assert.IsNotNull(diagrams);
                Assert.IsTrue(0 < diagrams.Count<IEADiagram>());
            }
        }

        /// <summary>
        /// Diagram exercises the diagram properties and operations
        /// </summary>
        [Test()]
        public void EA_DiagramTest()
        {
            // Properties

            {
                IEADiagram diagram = _e.GetDecisionForcesDiagram();
                Assert.IsTrue(System.DateTime.Today > diagram.Created);
                Assert.IsTrue(EANativeType.Diagram == diagram.EANativeType);
                Assert.IsTrue("" != diagram.GUID);
                Assert.IsTrue(0 < diagram.ID);
                Assert.IsTrue("" != diagram.Metatype);
                Assert.IsTrue(System.DateTime.Today > diagram.Modified);
                Assert.IsTrue("" != diagram.Name);
                Assert.IsTrue("" == diagram.Notes);
                Assert.IsNull(diagram.ParentElement);
                Assert.IsNotNull(diagram.ParentPackage);
                Assert.IsTrue("" != diagram.Version);
            }

            // Operations

            {  // AddToDiagram / Contains / RemoveFromDiagram
                IEAPackage package = _e.GetDecisionPackage();
                IEADiagram diagram = _e.GetDecisionForcesDiagram();
                IEAElement element = package.CreateElement("MyNote", "MyStereotype", "Note");
                /*
                package.RefreshElements();
                diagram.AddToDiagram(element);
                Assert.IsTrue(diagram.Contains(element));
                diagram.RemoveFromDiagram(element);
                 * */
                Assert.IsTrue(deleteElementFromPackage(package, element));
            }
        }

        /// <summary>
        /// Element exercises the element properties and operations
        /// </summary>
        [Test()]
        public void EA_ElementTest()
        {
            Element element = _e.GetDecisionPackageElement();
            Assert.IsTrue("" != element.Abstract);
            Assert.IsTrue("" == element.ActionFlags);
            Assert.IsTrue("" == element.Alias);
            Assert.IsTrue(0 == element.AssociationClassConnectorID);
            Assert.IsTrue(0 == element.Attributes.Count);
            Assert.IsTrue(0 == element.AttributesEx.Count);
            Assert.IsTrue("" != element.Author);
            Assert.IsTrue(0 == element.BaseClasses.Count);
            Assert.IsTrue(0 == element.ClassfierID);
            Assert.IsTrue(0 == element.ClassifierID);
            Assert.IsTrue("" == element.ClassifierName);
            Assert.IsTrue("" == element.ClassifierType);
            Assert.IsTrue("" != element.Complexity);
            Assert.IsNull(element.CompositeDiagram);
            Assert.IsTrue(0 < element.Connectors.Count);
            Assert.IsTrue(0 == element.Constraints.Count);
            Assert.IsTrue(0 == element.ConstraintsEx.Count);
            Assert.IsTrue(System.DateTime.Today > element.Created);
            Assert.IsTrue(0 < element.CustomProperties.Count);
            Assert.IsTrue(0 == element.Diagrams.Count);
            Assert.IsTrue("" == element.Difficulty);
            Assert.IsTrue(0 == element.Efforts.Count);
            Assert.IsTrue("" != element.ElementGUID);
            Assert.IsTrue(0 < element.ElementID);
            Assert.IsTrue(0 < element.Elements.Count);
            Assert.IsTrue(0 == element.EmbeddedElements.Count);
            Assert.IsTrue("" == element.EventFlags);
            Assert.IsTrue("" == element.ExtensionPoints);
            Assert.IsTrue(0 == element.Files.Count);
            Assert.IsTrue("" == element.Genfile);
            Assert.IsTrue("" == element.Genlinks);
            Assert.IsTrue("" != element.Gentype);
            Assert.IsTrue("" == element.Header1);
            Assert.IsTrue("" == element.Header2);
            Assert.IsFalse(element.IsActive);
            Assert.IsFalse(element.IsComposite);
            Assert.IsFalse(element.IsLeaf);
            Assert.IsTrue(element.IsNew);
            Assert.IsFalse(element.IsSpec);
            Assert.IsTrue(0 == element.Issues.Count);
            Assert.IsFalse(element.Locked);
            Assert.IsTrue("" != element.MetaType);
            Assert.IsTrue(0 == element.Methods.Count);
            Assert.IsTrue(0 == element.MethodsEx.Count);
            Assert.IsTrue(0 == element.Metrics.Count);
            Assert.IsTrue("" == element.MiscData[0]);
            Assert.IsTrue(System.DateTime.Today > element.Modified);
            Assert.IsTrue("" == element.Multiplicity);
            Assert.IsTrue("" != element.Name);
            Assert.IsTrue("" == element.Notes);
            Assert.IsTrue(ObjectType.otElement == element.ObjectType);
            Assert.IsTrue(0 < element.PackageID);
            Assert.IsTrue(0 == element.ParentID);
            Assert.IsTrue(0 == element.Partitions.Count);
            Assert.IsTrue("" == element.Persistence);
            Assert.IsTrue("" != element.Phase);
            Assert.IsTrue("" == element.Priority);
            Assert.IsNotNull(element.Properties);
            Assert.IsTrue(0 == element.PropertyType);
            Assert.IsTrue(0 == element.Realizes.Count);
            Assert.IsTrue(0 == element.Requirements.Count);
            Assert.IsTrue(0 == element.RequirementsEx.Count);
            Assert.IsTrue(0 == element.Resources.Count);
            Assert.IsTrue(0 == element.Risks.Count);
            Assert.IsTrue("" == element.RunState);
            Assert.IsTrue(0 == element.Scenarios.Count);
            Assert.IsTrue(0 == element.StateTransitions.Count);
            Assert.IsTrue("" != element.Status);
            Assert.IsTrue("" != element.Stereotype);
            Assert.IsTrue("" != element.StereotypeEx);
            Assert.IsTrue("" == element.StyleEx);
            Assert.IsTrue(0 == element.Subtype);
            Assert.IsTrue("" == element.Tablespace);
            Assert.IsTrue("" == element.Tag);
            Assert.IsTrue(0 < element.TaggedValues.Count);
            Assert.IsTrue(0 < element.TaggedValuesEx.Count);
            Assert.IsTrue(0 == element.Tests.Count);
            Assert.IsTrue(0 == element.TreePos);
            Assert.IsTrue("" != element.Type);
            Assert.IsTrue("" != element.Version);
            Assert.IsTrue("" != element.Visibility);
        }

        /// <summary>
        /// UpdateRepository ensures the Repository singleton is initialized
        /// </summary>
        [Test()]
        public void EA_UpdateRepositoryTest()
        {
            _e.GetDecisionPackage();
        }

        /// <summary>
        /// ConfirmMDG verifies if the Decision type is recognized.
        /// This test will fail if the MDG file DecisionViewpoints.xml is not manually added to the
        /// SparxSystems/EAMain/MDGTechnologies folder. The package will have the Action instead of Decision type.
        /// </summary>
        [Test()]
        public void EA_ConfirmMDG()
        {
            IEAPackage package = _e.GetDecisionPackage();
            IEAPackage components = package.GetSubpackageByName("Component Model");
            Assert.IsNotNull(components);
            IEAPackage decisionView = components.FindDecisionViewPackage();
            Assert.IsNotNull(decisionView);
            Assert.IsTrue(decisionView.IsDecisionViewPackage());
        }

        /// <summary>
        /// WrapElement creates an object that adds instance properties to a diagram object element with the ID specified in the event properties
        /// </summary>
        [Test()]
        public void EA_WrapElement_eventPropertiesTest()
        {
            IEADiagramObject obj = _e.GetForcesDiagramObject();
            EventProperties properties = EAEventPropertiesHelper.GetInstance("", "", "", 0, 0, 0, obj.ElementID, 0);
            IEAElement e = EAMain.WrapElement(properties);
            Assert.IsTrue(obj.ElementID == e.ID);
        }

        /// <summary>
        /// WrapElement creates an object that adds instance properties to to a package element
        /// </summary>
        [Test()]
        public void EA_WrapElement_elementTest()
        {
            Element element = _e.GetDecisionPackageElement();
            IEAElement e = EAMain.WrapElement(element);
            Assert.IsTrue(element.ElementID == e.ID);
        }

        /// <summary>
        /// WrapConnector creates an object that adds instance properties to a diagram connector
        /// </summary>
        [Test()]
        public void EA_WrapConnectorTest()
        {
            Connector connector = _e.GetForcesElementConnector();
            IEAConnector c = EAMain.WrapConnector(connector);
            Assert.IsTrue(connector.ConnectorID == c.ID);
        }

        /// <summary>
        /// WrapVolatileConnector creates an object that adds instance properties to a diagram connector with the ID specified in the event properties
        /// </summary>
        [Test()]
        public void EA_WrapVolatileConnectorTest()
        {
            Connector connector = _e.GetForcesElementConnector();
            EventProperties properties = EAEventPropertiesHelper.GetInstance(
                connector.Type, connector.Subtype, connector.Stereotype, connector.ClientID, connector.SupplierID, connector.DiagramID, 0, 0);
            IEAVolatileConnector c = EAMain.WrapVolatileConnector(properties);
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
            IEADiagram diagram = _e.GetDecisionForcesDiagram();
            EventProperties properties = EAEventPropertiesHelper.GetInstance("", "", "", 0, 0, diagram.ID, 0, 0);
            IEAVolatileDiagram d = EAMain.WrapVolatileDiagram(properties);
            Assert.IsTrue(diagram.ID == d.DiagramID);
        }

        /// <summary>
        /// WrapVolatileElement creates an object that adds instance properties to a package element with the ID specified in the event properties
        /// </summary>
        [Test()]
        public void EA_WrapVolatileElement_elementTest()
        {
            Element element = _e.GetDecisionPackageElement();
            EventProperties properties = EAEventPropertiesHelper.GetInstance(
                EAConstants.EventPropertyTypeElement, element.Subtype.ToString(), element.Stereotype, 0, 0, 0, 0, element.ElementID);
            IEAVolatileElement e = EAMain.WrapVolatileElement(properties);
            Assert.IsTrue(element.ElementID == e.ParentElement.ID);
        }

        /// <summary>
        /// WrapVolatileElement creates an object that adds instance properties to a package diagram with the ID specified in the event properties
        /// </summary>
        [Test()]
        public void EA_WrapVolatileElement_diagramTest()
        {
            IEADiagram diagram = _e.GetDecisionForcesDiagram();
            EventProperties properties = EAEventPropertiesHelper.GetInstance("", "", "", 0, 0, diagram.ID, 0, 0);
            IEAVolatileElement e = EAMain.WrapVolatileElement(properties);
            Assert.IsTrue(diagram.ID == e.Diagram.ID);
        }
    }
}
