/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    K. Eric Harper (ABB Corporate Research)
*/

using System.Collections.Generic;
using System.Linq;
using EAFacade;
using EAFacade.Model;
using NUnit.Framework;

namespace DecisionArchitectTests.Tests
{
    [TestFixture]
    public class EAConnectorTests
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
        ///     Connector exercises the connector properties and operations
        /// </summary>
        [Test]
        public void EA_ConnectorTests()
        {
            // Properties

            {
                IEAConnector connect = _e.GetForcesDecisionConnector();
                Assert.IsTrue("ControlFlow" == connect.Type);
                Assert.IsTrue(EAConstants.RelationAlternativeFor == connect.Stereotype);
                Assert.IsTrue(0 < connect.SupplierId);
                Assert.IsTrue(0 < connect.ClientId);
                Assert.IsTrue(EAConstants.RelationMetaType == connect.MetaType);
                List<IEAConnectorTag> tags = connect.TaggedValues;
                Assert.IsTrue(!tags.Any());
            }

            // Operations

            {
                // GetSupplier / GetClient
                IEAConnector connect = _e.GetForcesDecisionConnector();
                IEAElement supplier = connect.GetSupplier();
                Assert.IsNotNull(supplier);
                Assert.IsTrue(connect.SupplierId == supplier.ID);
                IEAElement client = connect.GetClient();
                Assert.IsNotNull(client);
                Assert.IsTrue(connect.ClientId == client.ID);
            }

            /* TODO: adjust for Decision Architect MDG
            {  // IsRelationship
                IEAConnector connect = _e.GetRelationshipDecisionConnector();
                Assert.IsTrue(connect.IsRelationship());
            }

            {  // IsAction
                IEAConnector connect = _e.GetStakeholderDecisionConnector();
                Assert.IsTrue(connect.IsAction());
            }

            {  // AddTaggedValue / TaggedValueExists / RemoveTaggedValue
                string taggedValueLabel = "MyTaggedValue";
                string taggedValueData = "my data";
                IEAConnector connect = _e.GetChronologyDecisionConnector();
                Assert.IsFalse(connect.TaggedValueExists(taggedValueLabel));
                connect.AddTaggedValue(taggedValueLabel, taggedValueData);
                Assert.IsTrue(connect.TaggedValueExists(taggedValueLabel));
                Assert.IsTrue(connect.TaggedValueExists(taggedValueLabel, taggedValueData));
                connect.RemoveTaggedValue(taggedValueLabel, taggedValueData);
                Assert.IsFalse(connect.TaggedValueExists(taggedValueLabel));
            }
             */
        }
    }
}