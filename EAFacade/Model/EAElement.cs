using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using EA;

namespace EAFacade.Model
{
    public class EAElement : IModelObject, IEquatable<EAElement>
    {
        private readonly Element _native;

        private EAElement(Element native)
        {
            _native = native;
        }

        public static int CompareByDateModified(EAElement x, EAElement y)
        {
            return DateTime.Compare(x.Modified, y.Modified);
        }

        public static int CompareByStateDateModified(EAElement x, EAElement y)
        {
            var xModified = DateTime.Parse(x.GetTaggedValue(DVTaggedValueKeys.DecisionStateModifiedDate));
            var yModified = DateTime.Parse(y.GetTaggedValue(DVTaggedValueKeys.DecisionStateModifiedDate));
            return DateTime.Compare(xModified, yModified);
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

        public EAElement ParentElement
        {
            get
            {
                EAElement parentElmt = null;
                if (_native.ParentID != 0)
                {
                    parentElmt = EARepository.Instance.GetElementByID(_native.ParentID);
                }
                return parentElmt;
            }
            set { _native.ParentID = value.ID; }
        }

        public string GUID
        {
            get { return _native.ElementGUID; }
        }

        public int ID
        {
            get { return _native.ElementID; }
        }

        public NativeType NativeType
        {
            get { return NativeType.Element; }
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

        public List<EATaggedValue> TaggedValues
        {
            get
            {
                return _native.TaggedValues.Cast<TaggedValue>()
                              .Select(EATaggedValue.Wrap).ToList();
            }
        }

        public EAPackage ParentPackage
        {
            get
            {
                EAPackage parentPkg = EARepository.Instance.GetPackageByID(_native.PackageID);
                return parentPkg;
            }
            set { _native.PackageID = value.ID; }
        }

        // To modify the stereotype we need to modify the list and not the stereotype directly
        public string StereotypeList
        {
            get { return _native.StereotypeEx; }
            set { _native.StereotypeEx = value; }
        }

        public void ShowInProjectView()
        {
            EARepository.Instance.Native.ShowInProjectView(_native);
        }

        public static EAElement Wrap(Element native)
        {
            return new EAElement(native);
        }

        public static EAElement Wrap(EventProperties properties)
        {
            var elementId = Utilities.ParseToInt32(properties.Get(EAEventPropertyKeys.ElementId).Value, -1);
            EAElement element = null;
            if (elementId > 0)
            {
                element = EARepository.Instance.GetElementByID(elementId);
            }
            return element;
        }

        public IEnumerable<EAElement> GetTracedElements()
        {
            if (_native == null)
            {
                return new EAElement[0];
            }
            IList<EAConnector> connectors = (from Connector c in _native.Connectors select EAConnector.Wrap(c)).ToList();

            var traces = from EAConnector trace in connectors
                         where trace.Stereotype.Equals("trace")
                         select (trace.SupplierId == ID
                                     ? trace.GetClient()
                                     : trace.GetSupplier()
                                );
            return traces;
        }

        public IEnumerable<EAElement> GetConnectedRequirements()
        {
            if (_native == null)
            {
                return new EAElement[0];
            }
            IList<EAConnector> connectors = (from Connector c in _native.Connectors select EAConnector.Wrap(c)).ToList();

            var connectedRequirements = from EAConnector connector in connectors
                                        where connector.Stereotype.Equals("classified by")
                                        select (connector.GetClient());

            return connectedRequirements;
        }

        public string GetProjectPath()
        {
            EAPackage current = ParentPackage;
            string path = current.Name;

            while (!current.IsModelRoot())
            {
                current = current.ParentPackage;
                path = current.Name + "/" + path;
            }
            path = "//" + path;
            return path;
        }

        public EADiagram[] GetDiagrams()
        {
            var sql =
                @"Select t_diagramobjects.Diagram_ID FROM t_diagramobjects WHERE t_diagramobjects.Object_ID = " + ID +
                ";";
            var repository = EARepository.Instance;
            var document = new XmlDocument();
            document.LoadXml(repository.Query(sql));
            var diagramIDs = document.GetElementsByTagName(@"Diagram_ID");

            var diagrams = new List<EADiagram>();
            foreach (XmlNode diagramID in diagramIDs)
            {
                var id = Utilities.ParseToInt32(diagramID.InnerText, -1);
                if (id > 0)
                {
                    diagrams.Add(repository.GetDiagramByID(id));
                }
            }

            return diagrams.ToArray();
        }

        [Obsolete]
        public void ConnectTo(EAElement suppliedElement)
        {
            ConnectTo(suppliedElement, "ControlFlow", "followed by");
        }

        public void ConnectTo(EAElement suppliedElement, String type, String stereotype)
        {
            Connector connector = _native.Connectors.AddNew("", type);
            connector.Stereotype = stereotype;
            connector.SupplierID = suppliedElement.ID;
            connector.Update();
            _native.Connectors.Refresh();
            suppliedElement._native.Connectors.Refresh();
        }

        public bool IsDecision()
        {
            return DVStereotypes.DecisionMetaType.Equals(MetaType);
        }

        public bool IsConcern()
        {
            return DVStereotypes.ConcernMetaType.Equals(MetaType);
        }

        public bool IsRequirement()
        {
            return DVStereotypes.RequirementMetaType.Equals(MetaType);
        }

        public bool IsHistoryDecision()
        {
            return GetTaggedValue(DVTaggedValueKeys.IsHistoryDecision).Equals(true.ToString());
        }

        public bool Update()
        {
            return _native.Update();
        }

        public void Refresh()
        {
            _native.Refresh();
        }

        public List<EAConnector> GetConnectors()
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
            try
            {
                TaggedValue value = _native.TaggedValues.GetByName(dvDecisionviewpackage);
                return value.Value;
            }
            catch (Exception)
            {
                return null;
            }
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

        public bool Equals(EAElement element)
        {
            if (element == null) return false;
            return _native.ElementGUID == element.GUID;
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