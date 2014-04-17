using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using EA;

namespace DecisionViewpoints.Model
{
    public class EAElement : IModelObject
    {
        public string GUID { get; private set; }
        public int ID { get; private set; }
        public NativeType NativeType { get; private set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Version { get; set; }
        public EAPackage ParentPackage { get; set; }

        public EAElement ParentElement { get; set; }

        private readonly Element _element;
        private readonly int _parentID;
        private readonly Repository _repository;
        private readonly string _stereotype;
        private readonly string _type;

        private EAElement(Repository repository, int parentId, string stereotype, string type,
                                 Element element = null)
        {
            _repository = repository;
            _parentID = parentId;
            _stereotype = stereotype;
            _type = type;
            _element = element;
        }

        public Repository Repository
        {
            get { return _repository; }
        }

        public string Type
        {
            get { return _type; }
        }

        public int ParentID
        {
            get { return _parentID; }
        }

        public string Stereotype
        {
            get { return _stereotype; }
        }

        [Obsolete]
        public Element Element
        {
            get { return _element; }
        }

        public static EAElement Wrap(Element native)
        {
            throw new NotImplementedException();
        }

        public static EAElement Wrap(Repository repository, EventProperties properties)
        {
            dynamic type = properties.Get(EAEventPropertyKeys.Type).Value;
            dynamic stereotype = properties.Get(EAEventPropertyKeys.Stereotype).Value;
            dynamic parentId = Utilities.ParseToInt32(properties.Get(EAEventPropertyKeys.ParentId).Value, -1);
            return new EAElement(repository, parentId, stereotype, type);
        }

        public static EAElement Wrap(Repository repository, Element element)
        {
            return new EAElement(repository, element.ParentID, element.Stereotype, element.Type, element);
        }

        public static EAElement Wrap(Repository repository, string guid)
        {
            Element element = repository.GetElementByGuid(guid);
            return Wrap(repository, element);
        }

        public static EAElement Wrap(Repository repository, int id)
        {
            Element element = repository.GetElementByID(id);
            return Wrap(repository, element);
        }

        public Element GetParent()
        {
            return _repository.GetElementByID(_parentID);
        }

        public EAElement[] GetTracedElements()
        {
            if (_element == null)
            {
                return new EAElement[0];
            }

            IList<EAConnectorWrapper> connectors = new List<EAConnectorWrapper>();
            foreach (Connector c in _element.Connectors)
            {
                connectors.Add(EAConnectorWrapper.Wrap(_repository, c.ConnectorGUID));
            }

            IEnumerable<EAElement> traces = from EAConnectorWrapper trace in connectors
                                                   where trace.Stereotype.Equals("trace")
                                                   select (trace.SupplierId == _element.ElementID
                                                               ? Wrap(_repository, trace.GetClient())
                                                               : Wrap(_repository, trace.GetSupplier())
                                                          );
            return traces.ToArray();
        }

        public string GetProjectPath()
        {
            
            
            Package current = Repository.GetPackageByID(_element.PackageID);;
            string path = current.Name;
            if (current.ParentID != 0)
            {
                current = Repository.GetPackageByID(current.ParentID);
                path = current.Name + "/" + path;
            }
            path = "//" + path;
            return path;
        }

        public Diagram[] GetDiagrams()
        {
            string sql =
                "Select t_diagramobjects.Diagram_ID FROM t_diagramobjects WHERE t_diagramobjects.Object_ID = " +
                Element.ElementID + ";";

            var document = new XmlDocument();
            document.LoadXml(_repository.SQLQuery(sql));
            XmlNodeList diagramIDs = document.GetElementsByTagName(@"Diagram_ID");

            var diagrams = new List<Diagram>();
            foreach (XmlNode diagramID in diagramIDs)
            {
                int id = Utilities.ParseToInt32(diagramID.InnerText, -1);
                if (id != -1)
                {
                    diagrams.Add(_repository.GetDiagramByID(id));
                }
            }

            return diagrams.ToArray();
        }
    }
}