using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using EA;
using EAFacade.Model.Baselines;

namespace EAFacade.Model
{
    public class EAPackage : IModelObject
    {
        private readonly Package _native;


        private EAPackage(Package native)
        {
            _native = native;
        }

        public IList<EAElement> Elements
        {
            get
            {
                var elements = new List<EAElement>(_native.Elements.Count);
                foreach (Element nativeElement in _native.Elements)
                {
                    elements.Add(EAElement.Wrap(nativeElement));
                }
                return elements;
            }
        }


        public string GUID
        {
            get { return _native.PackageGUID; }
        }

        public int ID
        {
            get { return _native.PackageID; }
        }

        public NativeType NativeType
        {
            get { return NativeType.Package; }
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
                //package is model root, returns itself
                if (_native.ParentID == 0)
                {
                    return this;
                }
                EAPackage parentPkg = EARepository.Instance.GetPackageByID(_native.ParentID);
                return parentPkg;
            }
            set { _native.ParentID = value.ID; }
        }

        //TODO: Transparent ILIST that wraps the strange EA Collection


        public void ShowInProjectView()
        {
            EARepository.Instance.Native.ShowInProjectView(_native);
        }

        public bool IsModelRoot()
        {
            return (this == ParentPackage);
        }

        [Obsolete("", true)]
        public Package Get()
        {
            return _native;
        }

        [Obsolete]
        public EAPackage CreatePackage(string name, string stereotype = "")
        {
            Package newPackage = _native.Packages.AddNew(name, "");
            newPackage.Update();
            if (!stereotype.Equals(""))
            {
                newPackage.Element.Stereotype = stereotype;
                newPackage.Update();
            }
            newPackage.Packages.Refresh();
            EARepository.Instance.RefreshModelView(_native.PackageID);
            return Wrap(newPackage);
        }

        public EAElement CreateElement(string name, string stereotype, string type)
        {
            Element newElement = _native.Elements.AddNew(name, type);
            newElement.Stereotype = stereotype;
            newElement.Update();
            _native.Elements.Refresh();
            EARepository.Instance.RefreshModelView(_native.PackageID);
            return EAElement.Wrap(newElement);
        }

        [Obsolete]
        public Diagram CreateDiagram(string name, string type)
        {
            EARepository repository = EARepository.Instance;
            Diagram d = _native.Diagrams.AddNew(name, type);

            d.Update();
            _native.Diagrams.Refresh();
            repository.Native.RefreshModelView(_native.PackageID);
            return d;
        }

        [Obsolete]
        public void DeleteDiagram(short pos, bool refresh)
        {
            _native.Diagrams.DeleteAt(pos, refresh);
        }

        [Obsolete]
        public EADiagram GetDiagram(string name)
        {
            return EADiagram.Wrap(_native.Diagrams.GetByName(name));
        }

        public IList<Baseline> GetBaselines()
        {
            Project project = EARepository.Instance.Native.GetProjectInterface();
            string baselineString = project.GetBaselines(GUID, "");
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(baselineString);

            return (from XmlNode baselineNode in xmlDocument.FirstChild.ChildNodes
                    where baselineNode.Attributes != null
                    let version = baselineNode.Attributes["version"].Value
                    let notes = baselineNode.Attributes["notes"].Value
                    let guid = baselineNode.Attributes["guid"].Value
                    select new Baseline(guid, version, notes)).ToList();
        }

        public void CreateBaseline(string notes, bool excludeSubPackages = false)
        {
            int flags = 0;
            if (excludeSubPackages)
            {
                flags = 1;
            }
            string version = DateTime.Now.ToString("yyyyMMddHHmmssffff");

            Project project = EARepository.Instance.Native.GetProjectInterface();
            if (!project.CreateBaselineEx(GUID, version, notes, flags))
            {
                throw new BaselineException("Baseline could not be created");
            }

        }

        public BaselineDiff CompareWithBaseline(Baseline baseline)
        {
            Project project = EARepository.Instance.Native.GetProjectInterface();
            string baselineXmlGuid = project.GUIDtoXML(baseline.Guid);
            string diffString = project.DoBaselineCompare(GUID, baselineXmlGuid, "");
            return BaselineDiff.ParseFromXml(this, baseline, diffString);
        }

        public static EAPackage Wrap(Package packageID)
        {
            return new EAPackage(packageID);
        }

        public void RefreshElements()
        {
            _native.Elements.Refresh();
        }

        public EAElement AddElement(string name, string type)
        {
            return EAElement.Wrap(_native.Elements.AddNew(name, type));
        }

        public IEnumerable<EAElement> GetAllDecisions()
        {
            return
                _native.Elements.Cast<Element>()
                       .Where(e => e.MetaType.Equals(DVStereotypes.DecisionMetaType))
                       .Select(e => EAElement.Wrap(e));
        }

        public EAPackage GetSubpackageByName(string data)
        {
            IEnumerable<Package> packages = _native.Packages.Cast<Package>();
            if (packages.Any())
            {
                Package foundPackage = packages.FirstOrDefault(e => e.Name.Equals(data));
                if (foundPackage != null)
                {
                    return Wrap(foundPackage);
                }
            }
            return null;
        }

        public bool IsDecisionViewPackage()
        {
            EAElement underlyingElement = EAElement.Wrap(_native.Element);
            string value = underlyingElement.GetTaggedValue(DVTaggedValueKeys.DecisionViewPackage);
            return (value != null && value.Equals("true"));
        }
    }
}