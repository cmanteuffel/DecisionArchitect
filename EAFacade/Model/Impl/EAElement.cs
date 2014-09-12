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
    Marc Holterman (University of Groningen)
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using EA;
using EAFacade.Forms;

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

        public string Author
        {
            get { return _native.Author; }
            set { _native.Author = value; }
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
            if (!EAMain.IsTopic(this))
            {
                throw new Exception("EAElementImpl is not a topic");
            }

            return from EAElement e in GetElements() where EAMain.IsDecision(e) select e;
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

        [Obsolete("Should be moved to appropriate domain class", false)]
        public IEnumerable<IEAElement> GetConnectedConcerns(string diagramGuid)
        {
            if (_native == null) return new EAElement[0];

            // Get the connectors with the native element as a client
            IList<IEAConnector> connectors =
                (from Connector c in _native.Connectors select EAConnector.Wrap(c)).Where(
                    c => c.GetClient().GUID.Equals(GUID)).ToList();

            // Get the SuppliedElement for each connector in connectors in the current diagram
            IEnumerable<IEAElement> suppliers = from IEAConnector connector in connectors
                                                where
                                                    connector.Stereotype.Equals(EAConstants.RelationClassifiedBy) &&
                                                    inDiagram(connector, diagramGuid)
                                                select (connector.GetSupplier());

            // Get the elements from connectedConcerns which are Concerns
            return suppliers.Where(x => x.TaggedValueExists(EATaggedValueKeys.IsConcernElement, diagramGuid));
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

            return (from XmlNode diagramId in diagramIDs
                    select EAUtilities.ParseToInt32(diagramId.InnerText, -1)
                    into id
                    where id > 0
                    select repository.GetDiagramByID(id)).ToArray();
        }

        public IList<IEAConnector> FindConnectors(string metatype, params string[] stereotypes)
        {
            IEnumerable<IEAConnector> filteredConnectors = GetConnectors()
                .Where(c => stereotypes.Contains(c.Stereotype));
            if (null != metatype && !"".Equals(metatype))
            {
                filteredConnectors = filteredConnectors.Where(c => c.MetaType.Equals(metatype));
            }
            return filteredConnectors.ToList();
        }

        public IList<IEAConnector> FindConnectors(IEAElement connectedElement, string stereotype, string type = null,
                                                  EAConnectorDirection direction = EAConnectorDirection.ClientToSupplier)
        {
            IList<IEAConnector> filteredConnectors = FindConnectors(type, stereotype);

            switch (direction)
            {
                case EAConnectorDirection.ClientToSupplier:
                    filteredConnectors = filteredConnectors.Where(c => c.ClientId == connectedElement.ID).ToList();
                    break;
                case EAConnectorDirection.SupplierToClient:
                    filteredConnectors = filteredConnectors.Where(c => c.SupplierId == connectedElement.ID).ToList();
                    break;

                default:
                    filteredConnectors =
                        filteredConnectors.Where(
                            c => c.SupplierId == connectedElement.ID || c.ClientId == connectedElement.ID).ToList();
                    break;
            }

            return filteredConnectors;
        }

        public IEAConnector ConnectTo(IEAElement suppliedElement, String type, String stereotype)
        {
            //check if two elements are already connected with this connector
            IList<IEAConnector> connectors = FindConnectors(suppliedElement, stereotype, type);
            if (connectors.Count > 0) return connectors.FirstOrDefault();

            Connector connector = _native.Connectors.AddNew("", type);
            connector.Stereotype = stereotype;
            connector.SupplierID = suppliedElement.ID;
            connector.Update();

            _native.Connectors.Refresh();
            _native.Update();
            ((EAElement) suppliedElement)._native.Connectors.Refresh();
            suppliedElement.Update();

            return EAConnector.Wrap(connector);
        }

        /// <summary>
        ///     Implements IEAElement.RemoveConnector(IEAConnector connector)
        /// </summary>
        /// <param name="connector"></param>
        public void RemoveConnector(IEAConnector connector)
        {
            for (short i = 0; i < _native.Connectors.Count; i++)
            {
                EAConnector con = EAConnector.Wrap(_native.Connectors.GetAt(i));

                if (!con.GUID.Equals(connector.GUID)) continue;
                _native.Connectors.Delete(i);
                _native.Connectors.Refresh();
                _native.Update();
                return;
            }
            
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

        public void LoadFileIntoLinkedDocument(string fileName)
        {
            _native.LoadLinkedDocument(fileName);
        }

        /// <summary>
        ///     Implements IEAElement.TaggedValueExists(string name)
        /// </summary>
        /// <returns></returns>
        public bool TaggedValueExists(string name)
        {
            return _native.TaggedValues.Cast<TaggedValue>().Any(tv => tv.Name.Equals(name));
        }

        /// <summary>
        ///     Implements IEAElement.TaggedValueExists(string name, string data)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool TaggedValueExists(string name, string data)
        {
            return _native.TaggedValues.Cast<TaggedValue>().Any(tv => tv.Name.Equals(name) && tv.Value.Equals(data));
        }

        public IEATaggedValue GetTaggedValueByGUID(string guid)
        {
            return
                _native.TaggedValues.Cast<TaggedValue>()
                       .Where(tv => tv.PropertyGUID.Equals(guid))
                       .Select(EATaggedValue.Wrap)
                       .FirstOrDefault();
        }

        public IList<IEATaggedValue> GetTaggedValuesByName(string name)
        {
            return
                _native.TaggedValues.Cast<TaggedValue>()
                       .Where(tv => tv.Name.Equals(name))
                       .Select(EATaggedValue.Wrap)
                       .ToList();
        }

        public string GetTaggedValueByName(string name)
        {
            TaggedValue value;

            try
            {
                // GetByName raises an exception if the collection contains items but not with this name
                value = _native.TaggedValues.GetByName(name);
            }
            catch (Exception)
            {
                return null;
            }

            return value == null ? null : value.Value;
        }

        /// <summary>
        ///     Implements IEAElement.AddTaggedValue(string name, string data)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public void AddTaggedValue(string name, string data)
        {
            TaggedValue taggedValue = _native.TaggedValues.AddNew(name, "");
            taggedValue.Value = data;
            taggedValue.Update();
            _native.TaggedValues.Refresh();
        }

        public bool UpdateTaggedValue(string guid, string name, string data)
        {
            TaggedValue taggedValue =
                _native.TaggedValues.Cast<TaggedValue>().FirstOrDefault(tv => tv.PropertyGUID.Equals(guid));
            if (taggedValue == null) return false;
            taggedValue.Name = name;
            taggedValue.Value = data;
            taggedValue.Update();
            _native.TaggedValues.Refresh();
            Update();
            return true;
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

        /// <summary>
        ///     Removes a tagged value from Tagged values
        /// </summary>
        /// <param name="name">name of the TaggedValue</param>
        /// <param name="data">data to be deleted</param>
        /// <returns>A bool indication whether the action was a success</returns>
        public bool DeleteTaggedValue(string name, string data)
        {
            short index = 0;
            short targetIndex = -1;

            // Find the entry which needs to be deleted
            foreach (TaggedValue taggedValue in _native.TaggedValues)
            {
                if (taggedValue.Name.StartsWith(name) && taggedValue.Value == data)
                {
                    targetIndex = index;
                }
                index++;
            }

            // Delete it
            if (targetIndex > 0 && targetIndex < _native.TaggedValues.Count - 1)
            {
                _native.TaggedValues.DeleteAt(targetIndex, true);
                Update();
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Implements IEAElement.RemoveTaggedValue(string name, string data)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public void RemoveTaggedValue(string name, string data)
        {
            for (short i = 0; i < TaggedValues.Count; i++)
            {
                IEATaggedValue tv = TaggedValues[i];

                if (tv.Name.Equals(name) && tv.Value.Equals(data))
                {
                    _native.TaggedValues.Delete(i);
                    _native.TaggedValues.Refresh();
                    return; // Only delete one TaggedValue
                }
            }
        }

        public void RemoveTaggedValueByGUID(string tagGUID)
        {
            for (short i = 0; i < TaggedValues.Count; i++)
            {
                IEATaggedValue tv = TaggedValues[i];
                if (tv.GUID.Equals(tagGUID))
                {
                    _native.TaggedValues.Delete(i);
                    _native.TaggedValues.Refresh();
                    return; // Only delete one TaggedValue
                }
            }
        }


        public void AdviseElementChanged()
        {
            EAMain.Repository.AdviseElementChanged(ID);
        }

        public void ShowInDiagrams()
        {
            IEADiagram[] diagrams = GetDiagrams();
            if (diagrams.Length == 1)
            {
                IEADiagram diagram = diagrams[0];
                diagram.OpenAndSelectElement(this);
            }
            else if (diagrams.Length >= 2)
            {
                var selectForm = new SelectDiagram(diagrams);
                if (selectForm.ShowDialog() == DialogResult.OK)
                {
                    IEADiagram diagram = selectForm.GetSelectedDiagram();
                    diagram.OpenAndSelectElement(this);
                }
            }
            ShowInProjectView();
        }


        public int RemoveAllWithName(string name)
        {
            int count = 0;
            const short one = 1;
            for (var idx = (short) (_native.TaggedValues.Count - one); idx >= 0; idx--)
            {
                TaggedValue tv = _native.TaggedValues.GetAt(idx);
                if (tv.Name.StartsWith(name))
                {
                    _native.TaggedValues.DeleteAt(idx, true);
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        ///     Checks if the connector is meant to be a connector in the diagram with GUID diagramGUID
        /// </summary>
        /// <param name="connector"></param>
        /// <param name="diagramGuid"></param>
        /// <returns></returns>
        private bool inDiagram(IEAConnector connector, string diagramGuid)
        {
            return
                connector.TaggedValues.Any(
                    x => x.Name.Equals(EATaggedValueKeys.IsForceConnector) && x.Value.Equals(diagramGuid));
        }

        public static IEAElement Wrap(Element native)
        {
            if (null == native)
            {
                throw new ArgumentNullException(
                    "native");
            }
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
            return element != null && Equals(element);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}