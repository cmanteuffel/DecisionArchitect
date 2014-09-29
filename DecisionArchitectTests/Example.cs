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

namespace DecisionArchitectTests
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

        public IEAPackage GetDecisionPackageFolder()
        {
            IEAPackage package = GetDecisionPackage();
            IList<IEAPackage> folder = package.Packages;
            Assert.IsTrue(0 < folder.Count());
            // Use first topic
            return folder.First();
        }

        public IEADiagram GetDecisionForcesDiagram()
        {
            IEADiagram diagram = null;
            IEAPackage folder = this.GetDecisionPackageFolder();
            IList<IEAElement> topics = folder.Elements;
            Assert.IsTrue(0 < topics.Count());
            // Use the first topic
            IEAElement topic = topics.First<IEAElement>();
            IEnumerable<IEADiagram> diagrams = topic.GetDiagrams();
            Assert.IsNotNull(diagrams);
            // Find a forces viewpoint
            foreach (IEADiagram d in diagrams)
            {
                if (d.IsStakeholderInvolvementView())
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
            IEAPackage folder = GetDecisionPackageFolder();
            Package root = Repo.Models.GetAt(0);
            Assert.IsNotNull(root);
            Package example = root.Packages.GetByName("Example");
            Assert.IsNotNull(example);
            Package decisions = example.Packages.GetByName("Decisions");
            Assert.IsNotNull(decisions);
            Package topics = decisions.Packages.GetByName(folder.Name);
            Assert.IsNotNull(topics);
            Assert.IsTrue(0 < topics.Elements.Count);
            element = topics.Elements.GetAt(0);
            Assert.IsNotNull(element);
            return element;
        }

        public IEADiagram GetDecisionRelationshipDiagram()
        {
            IEADiagram diagram = null;
            IEAPackage package = GetDecisionPackage();
            IEnumerable<IEADiagram> diagrams = package.GetAllDiagrams();
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

        public IEADiagram GetDecisionStakeholderDiagram()
        {
            IEADiagram diagram = null;
            IEAPackage package = GetDecisionPackage();
            IEnumerable<IEADiagram> diagrams = package.GetAllDiagrams();
            Assert.IsNotNull(diagrams);
            // Find a forces viewpoint
            foreach (IEADiagram d in diagrams)
            {
                if (d.IsStakeholderInvolvementView())
                {
                    diagram = d;
                    break;
                }
            }
            Assert.IsNotNull(diagram);
            return diagram;
        }

        public IEADiagram GetDecisionChronologicalDiagram()
        {
            IEADiagram diagram = null;
            IEAPackage folder = GetDecisionPackageFolder();
            IList<IEAElement> topics = folder.Elements;
            Assert.IsTrue(0 < topics.Count());
            // Use the first topic
            IEAElement topic = topics.First<IEAElement>();
            IEnumerable<IEADiagram> diagrams = topic.GetDiagrams();
            Assert.IsNotNull(diagrams);
            // Find a forces viewpoint
            foreach (IEADiagram d in diagrams)
            {
                if (d.IsChronologicalView())
                {
                    diagram = d;
                    break;
                }
            }
            Assert.IsNotNull(diagram);
            return diagram;
        }

        public IEAElement GetForcesDecisionElement()
        {
            IEAElement element = null;
            IEADiagram diagram = GetDecisionForcesDiagram();
            IEARepository repository = EAFacade.EAMain.Repository;
            IEAElement[] elements = (from diagramObject in diagram.GetElements()
                                       select repository.GetElementByID(diagramObject.ElementID)
                                       into elem
                                       where EAConstants.DecisionMetaType == elem.MetaType
                                       select elem).ToArray();
            Assert.IsNotNull(elements);
            element = elements.ElementAt<IEAElement>(0);
            Assert.IsNotNull(element);
            return element;
        }

        public IEAElement GetRelationshipDecisionElement()
        {
            IEAElement element = null;
            IEADiagram diagram = GetDecisionRelationshipDiagram();
            IEARepository repository = EAFacade.EAMain.Repository;
            IEAElement[] elements = (from diagramObject in diagram.GetElements()
                                     select repository.GetElementByID(diagramObject.ElementID)
                                         into elem
                                         where EAConstants.DecisionMetaType == elem.MetaType
                                         select elem).ToArray();
            Assert.IsNotNull(elements);
            element = elements.ElementAt<IEAElement>(0);
            Assert.IsNotNull(element);
            return element;
        }

        public IEAElement GetStakeholderActorElement()
        {
            IEAElement element = null;
            IEADiagram diagram = GetDecisionStakeholderDiagram();
            IEARepository repository = EAFacade.EAMain.Repository;
            IEAElement[] elements = (from diagramObject in diagram.GetElements()
                                     select repository.GetElementByID(diagramObject.ElementID)
                                         into elem
                                         where EAConstants.StakeholderMetaType == elem.MetaType
                                         select elem).ToArray();
            Assert.IsNotNull(elements);
            element = elements.ElementAt<IEAElement>(0);
            Assert.IsNotNull(element);
            return element;
        }

        public IEAElement GetChronologyDecisionElement()
        {
            IEAElement element = null;
            IEADiagram diagram = GetDecisionChronologicalDiagram();
            IEARepository repository = EAFacade.EAMain.Repository;
            IEAElement[] elements = (from diagramObject in diagram.GetElements()
                                     select repository.GetElementByID(diagramObject.ElementID)
                                         into elem
                                         where EAConstants.DecisionMetaType == elem.MetaType
                                         select elem).ToArray();
            Assert.IsNotNull(elements);
            element = elements.ElementAt<IEAElement>(0);
            Assert.IsNotNull(element);
            return element;
        }

        public IEAElement GetChronologyTopicElement()
        {
            IEAElement element = null;
            IEADiagram diagram = GetDecisionChronologicalDiagram();
            IEARepository repository = EAFacade.EAMain.Repository;
            IEAElement[] elements = (from diagramObject in diagram.GetElements()
                                     select repository.GetElementByID(diagramObject.ElementID)
                                         into elem
                                         where EAConstants.TopicMetaType == elem.MetaType
                                         select elem).ToArray();
            Assert.IsNotNull(elements);
            element = elements.ElementAt<IEAElement>(0);
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

        public IEAConnector GetForcesDecisionConnector()
        {
            IEAConnector connect = null;
            IEAElement decision = GetForcesDecisionElement();
            List<IEAConnector> connectors = decision.GetConnectors();
            Assert.IsTrue(0 < connectors.Count());
            connect = connectors.ElementAt<IEAConnector>(0);
            return connect;
        }

        public IEAConnector GetRelationshipDecisionConnector()
        {
            IEAConnector connect = null;
            IEAElement decision = GetRelationshipDecisionElement();
            List<IEAConnector> connectors = decision.GetConnectors();
            Assert.IsTrue(0 < connectors.Count());
            connect = connectors.ElementAt<IEAConnector>(0);
            return connect;
        }

        public IEAConnector GetStakeholderDecisionConnector()
        {
            IEAConnector connect = null;
            IEAElement decision = GetStakeholderActorElement();
            List<IEAConnector> connectors = decision.GetConnectors();
            Assert.IsTrue(0 < connectors.Count());
            connect = connectors.ElementAt<IEAConnector>(0);
            return connect;
        }

        public IEAConnector GetChronologyDecisionConnector()
        {
            IEAConnector connect = null;
            IEAElement decision = GetChronologyDecisionElement();
            List<IEAConnector> connectors = decision.GetConnectors();
            Assert.IsTrue(0 < connectors.Count());
            connect = connectors.ElementAt<IEAConnector>(0);
            return connect;
        }
    }
}