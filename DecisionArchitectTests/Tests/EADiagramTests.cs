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
using System.IO;
using EAFacade;
using EAFacade.Model;
using NUnit.Framework;

namespace DecisionArchitectTests.Tests
{
    [TestFixture]
    public class EADiagramTests
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
        ///     Diagram exercises the diagram properties and operations
        /// </summary>
        [Test]
        public void EA_DiagramTests()
        {
            // Properties

            {
                IEADiagram diagram = _e.GetDecisionForcesDiagram();
                Assert.IsTrue(DateTime.Now > diagram.Created);
                Assert.IsTrue(EANativeType.Diagram == diagram.EANativeType);
                Assert.IsTrue("" != diagram.GUID);
                Assert.IsTrue(0 < diagram.ID);
                Assert.IsTrue("" != diagram.Metatype);
                Assert.IsTrue(DateTime.Now > diagram.Modified);
                Assert.IsTrue("" != diagram.Name);
                Assert.IsTrue("" == diagram.Notes);
                Assert.IsNotNull(diagram.ParentElement);
                Assert.IsNotNull(diagram.ParentPackage);
                Assert.IsTrue("" != diagram.Version);
            }

            // Operations

            {
                // IsForcesView / AddElement / Contains / OpenAndSelectElement / HideConnectors / RemoveElement
                IEAPackage package = _e.GetDecisionPackage();
                IEADiagram diagram = _e.GetDecisionForcesDiagram();
                IEAElement element = package.CreateElement("MyNote", "MyStereotype", "Note");
                package.RefreshElements();
                diagram.AddElement(element);
                Assert.IsTrue(diagram.Contains(element));
                diagram.OpenAndSelectElement(element);
                diagram.HideConnectors(new[]
                    {
                        EAConstants.RelationAlternativeFor, EAConstants.RelationCausedBy,
                        EAConstants.RelationDependsOn,
                        EAConstants.RelationExcludedBy, EAConstants.RelationReplaces, EAConstants.RelationFollowedBy
                    });
                diagram.RemoveElement(element);
                Assert.IsFalse(diagram.Contains(element));
                Assert.IsTrue(deleteElementFromPackage(package, element));
            }

            {
                // ShowInProjectView / DiagramToStream
                IEAPackage package = _e.GetDecisionPackage();
                IEADiagram diagram = _e.GetDecisionForcesDiagram();
                diagram.ShowInProjectView();
                FileStream fs = diagram.DiagramToStream();
                Assert.IsNotNull(fs);
                Assert.IsTrue(fs.Name.Contains(".emf"));
            }

            {
                // GetElements
                IEAPackage package = _e.GetDecisionPackage();
                IEADiagram diagram = _e.GetDecisionForcesDiagram();
                List<IEADiagramObject> objs = diagram.GetElements();
                Assert.IsNotNull(objs);
                Assert.IsTrue(0 < objs.Count);
            }

            /* TODO: adjust for Decision Architect MDG
            {  // IsChronologicalView
                IEAPackage package = _e.GetDecisionPackage();
                IEADiagram diagram = _e.GetDecisionChronologicalDiagram();
            }

            {  // IsRelationshipView
                IEAPackage package = _e.GetDecisionPackage();
                IEADiagram diagram = _e.GetDecisionRelationshipDiagram();
            }

            {  // IsStakeholderInvolvementView
                IEAPackage package = _e.GetDecisionPackage();
                IEADiagram diagram = _e.GetDecisionStakeholderDiagram();
            }
             */
        }
    }
}