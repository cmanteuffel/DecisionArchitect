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
using EA;
using EAFacade;
using EAFacade.Model;
using NUnit.Framework;

namespace EATestSupport
{
    public class Example
    {
        private readonly ExampleRepositoryFile _f;

        public Example()
        {
            Repo = new Repository();
            _f = new ExampleRepositoryFile(Repo);
            _f.Open();
        }

        public Repository Repo { get; private set; }

        ~Example()
        {
            _f.Close();
        }

        public IEAPackage GetDecisionPackage()
        {
            IEAPackage decisions = null;
            Assert.IsNotNull(Repo);
            EAMain.UpdateRepository(Repo);
            IEnumerable<IEAPackage> packages = EAMain.Repository.GetAllPackages();
            Assert.IsNotNull(packages);
            // Top level package
            IEAPackage example = packages.First();
            // Use the first decision package
            decisions = example.GetSubpackageByName("Decisions");
            Assert.IsNotNull(decisions);
            return decisions;
        }

        public IEAPackage GetDecisionPackageTopic()
        {
            IEAPackage package = GetDecisionPackage();
            IList<IEAPackage> topics = package.Packages;
            Assert.IsTrue(0 < topics.Count());
            // Use first topic
            return topics.First();
        }

        public IEADiagram GetDecisionForcesDiagram()
        {
            IEADiagram diagram = null;
            IEAPackage topic = this.GetDecisionPackageTopic();
            IEnumerable<IEADiagram> diagrams = topic.GetAllDiagrams();
            Assert.IsNotNull(diagrams);
            // Find a forces viewpoint
            foreach (IEADiagram d in diagrams)
            {
                if (d.IsRelationshipView())
                {
                    diagram = d;
                    break;
                }
            }
            Assert.IsNotNull(diagram);
            return diagram;
        }

        public IEADiagramObject GetForcesDiagramObject()
        {
            IEADiagramObject obj;
            IEADiagram diagram = GetDecisionForcesDiagram();
            IEnumerable<IEADiagramObject> objects = diagram.GetElements();
            Assert.IsNotNull(objects);
            obj = objects.ElementAt(0);
            Assert.IsNotNull(obj);
            return obj;
        }

        public Element GetDecisionPackageElement()
        {
            Element element;
            IEAPackage package = GetDecisionPackageTopic();
            Package root = Repo.Models.GetAt(0);
            Assert.IsNotNull(root);
            Package example = root.Packages.GetByName("Example");
            Assert.IsNotNull(example);
            Package decisions = example.Packages.GetByName("Decisions");
            Assert.IsNotNull(decisions);
            Package topics = decisions.Packages.GetByName(package.Name);
            Assert.IsNotNull(topics);
            Assert.IsTrue(0 < topics.Elements.Count);
            element = topics.Elements.GetAt(0);
            Assert.IsNotNull(element);
            return element;
        }

        public Connector GetForcesElementConnector()
        {
            Connector connector;
            Element element = GetDecisionPackageElement();
            Collection connectors = element.Connectors;
            Assert.IsNotNull(connectors);
            connector = connectors.GetAt(0);
            Assert.IsNotNull(connector);
            return connector;
        }
    }
}