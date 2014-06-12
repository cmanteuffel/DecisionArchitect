/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    Mark Hoekstra (University of Groningen)
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using EA;

namespace EAFacade.Model.Impl
{
    internal sealed class EAElement : IEAElement
    {
        private readonly Element _native;

        private EAElement(Element native)
        {
            _native = native;
        }

        public string Type
        {
            get { return _native.Type; }
        }

        public string Stereotype
        {
            get { return _native.Stereotype; }
            set { _native.Stereotype = value; }
        }

        public string MetaType
        {
            get { return _native.MetaType; }
            set { _native.MetaType = value; }
        }

        public IEAElement ParentElement
        {
            get
            {
                IEAElement parentElmt = null;
                if (_native.ParentID != 0)
                {
                    parentElmt = EARepository.Instance.GetElementByID(_native.ParentID);
                }
                return parentElmt;
            }
            set { _native.ParentID = value.ID; }
        }

        public List<IEATaggedValue> TaggedValues
        {
            get
            {
                return _native.TaggedValues.Cast<TaggedValue>()
                              .Select(EATaggedValue.Wrap).ToList();
            }
        }

        public string StereotypeList
        {
            get { return _native.StereotypeEx; }
            set { _native.StereotypeEx = value; }
        }

        public bool Equals(IEAElement element)
        {
            if (element == null) return false;
            return _native.ElementGUID == element.GUID;
        }

        public string GUID
        {
            get { return _native.ElementGUID; }
        }

        public int ID
        {
            get { return _native.ElementID; }
        }

        public EANativeType EANativeType
        {
            get { return EANativeType.Element; }
        }

        public string Name
        {
            get { return _native.Name; }
            set { _native.Name = value; }
        }

        public string Notes
        {
            get { return _native.Notes; }
            set { _native.Notes = value; }
        }

        public DateTime Created
        {
            get { return _native.Created; }
            set { _native.Created = value; }
        }

        public DateTime Modified
        {
            get { return _native.Modified; }
            set { _native.Modified = value; }
        }

        public string Version
        {
            get { return _native.Version; }
            set { _native.Version = value; }
        }

        public IEAPackage ParentPackage
        {
            get
            {
                IEAPackage parentPkg = EARepository.Instance.GetPackageByID(_native.PackageID);
                return parentPkg;
            }
            set { _native.PackageID = value.ID; }
        }

        // To modify the stereotype we need to modify the list and not the stereotype directly

        public void ShowInProjectView()
        {
            EARepository.Instance.Native.ShowInProjectView(_native);
        }

        public string GetProjectPath()
        {
            IEAPackage current = ParentPackage;
            string path = current.Name;

            while (!current.IsModelRoot())
            {
                current = current.ParentPackage;
                path = current.Name + "/" + path;
            }
            path = "//" + path;
            return path;
        }


        public IEnumerable<IEAElement> GetTracedElements()
        {
            if (_native == null)
            {
                return new EAElement[0];
            }
            IList<IEAConnector> connectors =
                (from Connector c in _native.Connectors select EAConnector.Wrap(c)).ToList();

            IEnumerable<IEAElement> traces = from IEAConnector trace in connectors
                                             where trace.Stereotype.Equals(EAConstants.RelationTrace)
                                             select (trace.SupplierId == ID
                                                         ? trace.GetClient()
                                                         : trace.GetSupplier()
                                                    );
            return traces;
        }

        [Obsolete("Should be moved to topic", false)]
        public IEnumerable<IEAElement> GetDecisionsForTopic()
        {
            if (!IsTopic())
            {
                throw new Exception("EAElementImpl is not a topic");
            }

            return from EAElement e in GetElements() where e.IsDecision() select e;
        }

        [Obsolete("Should be moved to appropriate domain class", false)]
        public IEnumerable<IEAElement> GetConnectedConcerns()
        {
            if (_native == null)
            {
                return new EAElement[0];
            }
            IList<IEAConnector> connectors =
                (from Connector c in _native.Connectors select EAConnector.Wrap(c)).ToList();

            IEnumerable<IEAElement> connectedConcerns = from IEAConnector connector in connectors
                                                        where connector.Stereotype.Equals("classified by")
                                                        select (connector.GetSupplier());

            return connectedConcerns;
        }

        [Obsolete("Should be moved to appropriate domain class", false)]
        public IEnumerable<IEAElement> GetConnectedRequirements()
        {
            if (_native == null)
            {
                return new EAElement[0];
            }
            IList<IEAConnector> connectors =
                (from Connector c in _native.Connectors select EAConnector.Wrap(c)).ToList();

            IEnumerable<IEAElement> connectedRequirements = from IEAConnector connector in connectors
                                                            where connector.Stereotype.Equals("classified by")
                                                            select (connector.GetClient());

            return connectedRequirements;
        }

        public IEADiagram[] GetDiagrams()
        {
            string sql =
                @"Select t_diagramobjects.Diagram_ID FROM t_diagramobjects WHERE t_diagramobjects.Object_ID = " + ID +
                ";";
            IEARepository repository = EARepository.Instance;
            var document = new XmlDocument();
            document.LoadXml(repository.Query(sql));
            XmlNodeList diagramIDs = document.GetElementsByTagName(@"Diagram_ID");

            var diagrams = new List<IEADiagram>();
            foreach (XmlNode diagramID in diagramIDs)
            {
                int id = EAUtilities.ParseToInt32(diagramID.InnerText, -1);
                if (id > 0)
                {
                    diagrams.Add(repository.GetDiagramByID(id));
                }
            }

            return diagrams.ToArray();
        }

        public IList<IEAConnector> FindConnectors(IEAElement suppliedElement, String type, String stereotype)
        {
            return GetConnectors().Where(c =>
                {
                    return c.GetSupplier().GUID.Equals(suppliedElement.GUID) &&
                           c.Stereotype.Equals(stereotype) &&
                           c.Type.Equals(type);
                }).ToList();
        }

        public void ConnectTo(IEAElement suppliedElement, String type, String stereotype)
        {
            //check if two elements are already connected with this connector
            if (FindConnectors(suppliedElement, type, stereotype).Count > 0)
            {
                return;
            }

            Connector connector = _native.Connectors.AddNew("", type);
            connector.Stereotype = stereotype;
            connector.SupplierID = suppliedElement.ID;
            connector.Update();
            _native.Connectors.Refresh();
            ((EAElement) suppliedElement)._native.Connectors.Refresh();
        }


        public bool IsDecision()
        {
            return EAConstants.DecisionMetaType.Equals(MetaType.Trim());
            //return EAConstants.DecisionMetaType.Equals(MetaType);
        }

        public bool IsConcern()
        {
            return EAConstants.ConcernMetaType.Equals(MetaType);
        }

        public bool IsRequirement()
        {
            return EAConstants.RequirementMetaType.Equals(MetaType);
        }

        public bool IsTopic()
        {
            return EAConstants.TopicMetaType.Equals(MetaType);
        }

        public bool IsHistoryDecision()
        {
            return true.ToString().Equals(GetTaggedValue(EATaggedValueKeys.IsHistoryDecision));
        }

        public bool Update()
        {
            return _native.Update();
        }

        public void Refresh()
        {
            _native.Refresh();
        }

        public List<IEAElement> GetElements()
        {
            return _native.Elements.Cast<Element>().Select(Wrap).ToList();
        }

        public List<IEAConnector> GetConnectors()
        {
            return _native.Connectors.Cast<Connector>().Select(EAConnector.Wrap).ToList();
        }

        public string GetLinkedDocument()
        {
            return _native.GetLinkedDocument();
        }

        public void LoadLinkedDocument(string fileName)
        {
            _native.LoadLinkedDocument(fileName);
        }

        public string GetTaggedValue(string dvDecisionviewpackage)
        {
            TaggedValue value = _native.TaggedValues.GetByName(dvDecisionviewpackage);
            return value == null ? null : value.Value;
        }

        public void AddTaggedValue(string name, string data)
        {
            TaggedValue taggedValue = _native.TaggedValues.AddNew(name, "");
            taggedValue.Value = data;
            taggedValue.Update();
            _native.TaggedValues.Refresh();
            Update();
        }

        public void UpdateTaggedValue(string name, string data)
        {
            TaggedValue taggedValue = _native.TaggedValues.GetByName(name);
            if (taggedValue == null)
            {
                throw new Exception("TaggedValue " + name + " does not exist.");
            }
            taggedValue.Value = data;
            taggedValue.Update();
            _native.TaggedValues.Refresh();
            Update();
        }

        public static IEAElement Wrap(Element native)
        {
            return new EAElement(native);
        }

        public static IEAElement Wrap(EventProperties properties)
        {
            dynamic elementId = EAUtilities.ParseToInt32(properties.Get(EAEventPropertyKeys.ElementId).Value, -1);
            EAElement element = null;
            if (elementId > 0)
            {
                element = EARepository.Instance.GetElementByID(elementId);
            }
            return element;
        }

        public override bool Equals(object other)
        {
            if (other == null) return false;
            var element = other as EAElement;
            if (element == null) return false;
            return Equals(element);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
