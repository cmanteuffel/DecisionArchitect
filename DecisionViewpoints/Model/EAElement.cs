using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using EA;

namespace DecisionViewpoints.Model
{
    public class EAElement : IModelObject
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

        public EAPackage ParentPackage
        {
            get
            {
                EAPackage parentPkg = EARepository.Instance.GetPackageByID(_native.PackageID);
                return parentPkg;
            }
            set { _native.PackageID = value.ID; }
        }

        public void ShowInProjectView()
        {
            EARepository.Instance.Native.ShowInProjectView(_native);
        }

        [Obsolete("Do not use outside of model namespace or main app")]
        internal static EAElement Wrap(Element native)
        {
            return new EAElement(native);
        }

        public IEnumerable<EAElement> GetTracedElements()
        {
            if (_native == null)
            {
                return new EAElement[0];
            }
            IList<EAConnectorWrapper> connectors = new List<EAConnectorWrapper>();
            foreach (Connector c in _native.Connectors)
            {
                connectors.Add(EAConnectorWrapper.Wrap(c));
            }

            IEnumerable<EAElement> traces = from EAConnectorWrapper trace in connectors
                                            where trace.Stereotype.Equals("trace")
                                            select (trace.SupplierId == ID
                                                        ? trace.GetClient()
                                                        : trace.GetSupplier()
                                                   );
            return traces;
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
                if (id != -1)
                {
                    diagrams.Add(repository.GetDiagramByID(id));
                }
            }

            return diagrams.ToArray();
        }

        [Obsolete]
        public void ConnectTo(EAElement suppliedElement)
        {
            ConnectTo(suppliedElement,"ControlFlow", "followed by");
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

        public  bool IsDecision()
        {
            return (DVStereotypes.DecisionMetaType.Equals(MetaType));
        }

        public bool Update()
        {
            return _native.Update();
        }

        public string GetTaggedValue(string dvDecisionviewpackage)
        {
            TaggedValue value = _native.TaggedValues.GetByName(dvDecisionviewpackage);
            if (value == null)
            {
                return null;
            }
            return value.Value;
        }
    }
}