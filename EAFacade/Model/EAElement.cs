using System;
using System.Collections.Generic;
using System.Globalization;
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

        public List<EATaggedValue> TaggedValues
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

        public bool Equals(EAElement element)
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

        public void ShowInProjectView()
        {
            EARepository.Instance.Native.ShowInProjectView(_native);
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

        public static int CompareByDateModified(EAElement x, EAElement y)
        {
            return DateTime.Compare(x.Modified, y.Modified);
        }

        public static int CompareByStateDateModified(EAElement x, EAElement y)
        {
            var oldestDateString =DateTime.MinValue.ToString(CultureInfo.InvariantCulture);
            var xDateString = x.GetTaggedValue(DVTaggedValueKeys.DecisionStateModifiedDate) ?? oldestDateString;
            var yDateString = y.GetTaggedValue(DVTaggedValueKeys.DecisionStateModifiedDate) ?? oldestDateString;

            DateTime xModified = DateTime.Parse(xDateString);
            DateTime yModified = DateTime.Parse(yDateString);
            return DateTime.Compare(xModified, yModified);
        }

        public static EAElement Wrap(Element native)
        {
            return new EAElement(native);
        }

        public static EAElement Wrap(EventProperties properties)
        {
            dynamic elementId = Utilities.ParseToInt32(properties.Get(EAEventPropertyKeys.ElementId).Value, -1);
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

            IEnumerable<EAElement> traces = from EAConnector trace in connectors
                                            where trace.Stereotype.Equals("trace")
                                            select (trace.SupplierId == ID
                                                        ? trace.GetClient()
                                                        : trace.GetSupplier()
                                                   );
            return traces;
        }

        public IEnumerable<EAElement> GetDecisionsForTopic()
        {
            if (!IsTopic())
            {
                throw new Exception("EAElement is not a topic");
            }

            return from EAElement e in GetElements() where e.IsDecision() select e;
        }

        public IEnumerable<EAElement> GetConnectedConcerns()
        {
            if (_native == null)
            {
                return new EAElement[0];
            }
            IList<EAConnector> connectors = (from Connector c in _native.Connectors select EAConnector.Wrap(c)).ToList();

            IEnumerable<EAElement> connectedConcerns = from EAConnector connector in connectors
                                                       where connector.Stereotype.Equals("classified by")
                                                       select (connector.GetSupplier());

            return connectedConcerns;
        }

        public IEnumerable<EAElement> GetConnectedRequirements()
        {
            if (_native == null)
            {
                return new EAElement[0];
            }
            IList<EAConnector> connectors = (from Connector c in _native.Connectors select EAConnector.Wrap(c)).ToList();

            IEnumerable<EAElement> connectedRequirements = from EAConnector connector in connectors
                                                           where connector.Stereotype.Equals("classified by")
                                                           select (connector.GetClient());

            return connectedRequirements;
        }

        public EADiagram[] GetDiagrams()
        {
            string sql =
                @"Select t_diagramobjects.Diagram_ID FROM t_diagramobjects WHERE t_diagramobjects.Object_ID = " + ID +
                ";";
            EARepository repository = EARepository.Instance;
            var document = new XmlDocument();
            document.LoadXml(repository.Query(sql));
            XmlNodeList diagramIDs = document.GetElementsByTagName(@"Diagram_ID");

            var diagrams = new List<EADiagram>();
            foreach (XmlNode diagramID in diagramIDs)
            {
                int id = Utilities.ParseToInt32(diagramID.InnerText, -1);
                if (id > 0)
                {
                    diagrams.Add(repository.GetDiagramByID(id));
                }
            }

            return diagrams.ToArray();
        }

        public IList<EAConnector> FindConnectors(EAElement suppliedElement, String type, String stereotype)
        {
            return GetConnectors().Where(c =>
                {
                    return c.GetSupplier().GUID.Equals(suppliedElement.GUID) &&
                           c.Stereotype.Equals(stereotype) &&
                           c.Type.Equals(type);
                }).ToList();
        }

        public void ConnectTo(EAElement suppliedElement, String type, String stereotype)
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
            suppliedElement._native.Connectors.Refresh();
        }


        public bool IsDecision()
        {
            return DVStereotypes.DecisionMetaType.Equals(MetaType.Trim());
            //return DVStereotypes.DecisionMetaType.Equals(MetaType);
        }

        //angor task191 START
        public bool HasTopic()
        {
            if (ParentElement == null) return false;
            return ParentElement.IsTopic();
        }

        //angor task191 END

        public EAElement GetTopic()
        {
            if (ParentElement == null || !ParentElement.IsTopic()) return null;

            return ParentElement;
        }

        public bool IsConcern()
        {
            return DVStereotypes.ConcernMetaType.Equals(MetaType);
        }

        public bool IsRequirement()
        {
            return DVStereotypes.RequirementMetaType.Equals(MetaType);
        }

        public bool IsTopic()
        {
            return DVStereotypes.TopicMetaType.Equals(MetaType);
        }

        public bool IsHistoryDecision()
        {
            return true.ToString().Equals(GetTaggedValue(DVTaggedValueKeys.IsHistoryDecision));
        }

        public bool Update()
        {
            return _native.Update();
        }

        public void Refresh()
        {
            _native.Refresh();
        }

        public List<EAElement> GetElements()
        {
            return _native.Elements.Cast<Element>().Select(Wrap).ToList();
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