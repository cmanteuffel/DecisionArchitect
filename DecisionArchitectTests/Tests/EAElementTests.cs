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
using EAFacade.Model;
using NUnit.Framework;

namespace DecisionArchitectTests.Tests
{
    [TestFixture]
    public class EAElementTests
    {
        [SetUp]
        public void InitEATests()
        {
            _e = new Example();
        }

        [TearDown]
        public void CleanupEATests()
        {
        }

        private Example _e;

        /// <summary>
        ///     Element exercises the element properties and operations
        /// </summary>
        [Test]
        public void EA_ElementTests()
        {
            // Properties
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
                Assert.IsTrue(DateTime.Now > element.Created);
                Assert.IsTrue(0 < element.CustomProperties.Count);
                Assert.IsTrue(0 < element.Diagrams.Count);
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
                Assert.IsTrue(DateTime.Now > element.Modified);
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
                Assert.IsTrue(1 == element.TreePos);
                Assert.IsTrue("" != element.Type);
                Assert.IsTrue("" != element.Version);
                Assert.IsTrue("" != element.Visibility);
            }

            // Operations

            {
                // GetTracedElements (no traced elements in example model)
                IEAElement element = _e.GetForcesDecisionElement();
                IEnumerable<IEAElement> elements = element.GetTracedElements();
                Assert.IsTrue(!elements.Any());
            }

            {
                // GetDiagrams
                IEAElement element = _e.GetForcesDecisionElement();
                IEADiagram[] diagrams = element.GetDiagrams();
                Assert.IsTrue(diagrams.Any());
            }

            {
                // GetConnectors / ConnectTo / Update / Refresh / FindConnectors / RemoveConnector
                IEAElement element = _e.GetForcesDecisionElement();
                const string myType = "Dependency";
                const string mySterotype = "my stereotype";
                List<IEAConnector> connectors = element.GetConnectors();
                Assert.IsTrue(connectors.Any());
                IEAConnector c = connectors.ElementAt(0);
                IEAElement client = c.GetClient();
                IEAConnector nc = client.ConnectTo(element, myType, mySterotype);
                Assert.IsTrue(element.Update());
                element.Refresh();
                IList<IEAConnector> flows = client.FindConnectors(element, mySterotype, myType);
                Assert.IsNotNull(flows);
                Assert.IsTrue(flows.Any());
                element.RemoveConnector(nc);
                Assert.IsTrue(element.Update());
                element.Refresh();
                flows = client.FindConnectors(element, mySterotype, myType);
                Assert.IsNotNull(flows);
                Assert.IsFalse(flows.Any());
            }

            /* Disabled pending better understanding of Chronological view
            {  // GetElements
                IEAElement element = _e.GetChronologyTopicElement();
                List<IEAElement> children = element.GetElements();
                Assert.IsTrue(0 < children.Count());
            }

            {  // AddTaggedValue / TaggedValueExists / GetTaggedValue / RemoveTaggedValue
                string taggedValueLabel = "MyTaggedValue";
                string taggedValueData = "my data";
                IEAElement element = _e.GetChronologyDecisionElement();
                Assert.IsFalse(element.TaggedValueExists(taggedValueLabel));
                element.AddTaggedValue(taggedValueLabel, taggedValueData);
                Assert.IsTrue(element.TaggedValueExists(taggedValueLabel));
                Assert.IsTrue(element.TaggedValueExists(taggedValueLabel, taggedValueData));
                string myData = element.GetTaggedValueByName(taggedValueLabel);
                Assert.IsTrue(myData == taggedValueData);
                element.RemoveTaggedValue(taggedValueLabel, taggedValueData);
                Assert.IsFalse(element.TaggedValueExists(taggedValueLabel));
            }
             */
        }
    }
}