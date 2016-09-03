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
using EAFacade.Model;
using NUnit.Framework;

namespace DecisionArchitectTests.Tests
{
    [TestFixture]
    public class EAPackageTests
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
        ///     Package exercises the package properties and operations
        /// </summary>
        [Test]
        public void EA_PackageTests()
        {
            // Properties

            {
                IEAPackage folder = _e.GetDecisionPackageFolder();
                Assert.IsTrue(DateTime.Now > folder.Created);
                Assert.IsTrue(EANativeType.Package == folder.EANativeType);
                Assert.IsTrue(folder.Elements.Any());
                Assert.IsTrue("" != folder.GUID);
                Assert.IsTrue(0 < folder.ID);
                Assert.IsTrue(DateTime.Now > folder.Modified);
                Assert.IsTrue("" != folder.Name);
                Assert.IsTrue("" == folder.Notes);
                Assert.IsTrue(!folder.Packages.Any());
                Assert.IsNotNull(folder.ParentPackage);
                Assert.IsTrue("1.0" == folder.Version);
                Assert.IsTrue("system" == folder.Stereotype);
            }

            // Operations
            // See the Type property in the EAMain Element class documentation for a list of valid element types.

            {
                // CreatePackage / DeletePackage
                IEAPackage package = _e.GetDecisionPackage();
                IEAPackage inner = package.CreatePackage("MyPackage", "MyStereotype");
                Assert.IsNotNull(inner);
                package.RefreshElements();
                Assert.IsTrue("MyPackage" == inner.Name);
                Assert.IsTrue("MyStereotype" == inner.Stereotype);
                package.DeletePackage(inner);
            }

            {
                // CreateElement
                IEAPackage package = _e.GetDecisionPackage();
                IEAElement element = package.CreateElement("MyNote", "MyStereotype", "Note");
                Assert.IsNotNull(element);
                package.RefreshElements();
                Assert.IsTrue("MyNote" == element.Name);
                Assert.IsTrue("MyStereotype" == element.Stereotype);
                Assert.IsTrue("Note" == element.Type);
                Assert.IsTrue(deleteElementFromPackage(package, element));
            }

            {
                // GetAllDiagrams / GetDiagram
                IEAPackage folder = _e.GetDecisionPackageFolder();
                IEnumerable<IEADiagram> diagrams = folder.GetAllDiagrams();
                Assert.IsNotNull(diagrams);
                IEADiagram first = diagrams.ElementAt(0);
                IEADiagram diagram = folder.GetDiagram(first.Name);
                Assert.IsNotNull(diagram);
                Assert.IsTrue(first.ID == diagram.ID);
            }

            {
                // RefreshElements
                IEAPackage package = _e.GetDecisionPackage();
                package.RefreshElements();
            }

            {
                // AddElement / DeleteElement
                IEAPackage package = _e.GetDecisionPackage();
                IEAElement element = package.AddElement("MyNote", "Note");
                Assert.IsNotNull(element);
                package.RefreshElements();
                Assert.IsTrue("MyNote" == element.Name);
                Assert.IsTrue("" == element.Stereotype);
                Assert.IsTrue("Note" == element.Type);
                Assert.IsTrue(deleteElementFromPackage(package, element));
            }

            {
                // GetAllElementsOfSubTree
                IEAPackage package = _e.GetDecisionPackage();
                IEnumerable<IEAElement> elements = package.GetAllElementsOfSubTree();
                Assert.IsNotNull(elements);
                Assert.IsTrue(elements.Any());
            }

            {
                // GetAllDecisions
                IEAPackage package = _e.GetDecisionPackage();
                IEnumerable<IEAElement> actions = package.GetAllDecisions();
                Assert.IsNotNull(actions);
                Assert.IsTrue(actions.Any());
            }

            {
                // GetAllTopics
                IEAPackage package = _e.GetDecisionPackage();
                IEnumerable<IEAElement> elements = package.GetAllTopics();
                Assert.IsNotNull(elements);
                Assert.IsTrue(elements.Any());
            }

            {
                // GetSubpackageByName
                IEAPackage package = _e.GetDecisionPackage();
                IEAPackage subPackage = package.GetSubpackageByName("High-level Decisions");
                Assert.IsNotNull(subPackage);
            }

            {
                // GetDiagrams
                IEAPackage folder = _e.GetDecisionPackageFolder();
                IEnumerable<IEADiagram> diagrams = folder.GetDiagrams();
                Assert.IsNotNull(diagrams);
                Assert.IsTrue(diagrams.Any());
            }
        }
    }
}