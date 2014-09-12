﻿/*
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
            IEAPackage package = null;
            Assert.IsNotNull(Repo);
            EAMain.UpdateRepository(Repo);
           // IEnumerable<IEAPackage> packages = EAMain.Repository.GetAllDecisionViewPackages();
            //Assert.IsNotNull(packages);
            // Use the first decision package
            //package = packages.ElementAt(0);
            //Assert.IsNotNull(package);
            return package;
        }

        public IEADiagram GetDecisionForcesDiagram()
        {
            IEADiagram diagram = null;
            IEAPackage package = GetDecisionPackage();
            IEnumerable<IEADiagram> diagrams = package.GetAllDiagrams();
            Assert.IsNotNull(diagrams);
            // Find a forces viewpoint
            foreach (IEADiagram d in diagrams)
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
            IEAPackage package = GetDecisionPackage();
            Package root = Repo.Models.GetAt(0);
            Assert.IsNotNull(root);
            Package view = root.Packages.GetByName(package.Name);
            Assert.IsNotNull(view);
            element = view.Elements.GetAt(0);
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