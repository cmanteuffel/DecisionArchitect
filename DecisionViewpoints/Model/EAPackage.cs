using System;
using System.Collections.Generic;
using System.Xml;
using DecisionViewpoints.Model.Baselines;
using EA;

namespace DecisionViewpoints.Model
{
    public class EAPackage : IModelObject
    {
        private readonly Package _native;


        private EAPackage(Package native)
        {
            _native = native;
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
        public IList<EAElement> Elements
        {
            get { 
                var elements = new List<EAElement>(_native.Elements.Count);
                foreach (Element nativeElement in _native.Elements)
                {
                    elements.Add(EAElement.Wrap(nativeElement));
                }
                return elements;
            }
        }


        public void ShowInProjectView()
        {
            EARepository.Instance.Native.ShowInProjectView(_native);
        }

        public bool IsModelRoot()
        {
            return (this == ParentPackage);
        }

        [Obsolete("",true)]
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
            return EAPackage.Wrap(newPackage);
        }

        [Obsolete]
        public void DeletePackage(short pos, bool refresh)
        {
            _native.Packages.DeleteAt(pos, refresh);
        }

        [Obsolete]
        public Element CreateElement(string name, string stereotype, string type)
        {
            Element newElement = _native.Elements.AddNew(name, type);
            newElement.Stereotype = stereotype;
            newElement.Update();
            _native.Elements.Refresh();
            EARepository.Instance.RefreshModelView(_native.PackageID);
            return newElement;
        }

        [Obsolete]
        public Diagram CreateDiagram(IDualRepository repository, string name, string type)
        {
            Diagram d = _native.Diagrams.AddNew(name, type);
            d.Update();
            _native.Diagrams.Refresh();
            repository.RefreshModelView(_native.PackageID);
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

        public IEnumerable<Baseline> GetBaselines()
        {
            var baselines = new List<Baseline>();
            var project = EARepository.Instance.Native.GetProjectInterface();
            var baselineString = project.GetBaselines(GUID, "");
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(baselineString);

            throw new NotImplementedException("parse xml and create xml");


            return baselines;
        }

        public BaselineDiff CompareWithBaseline(Baseline baseline)
        {
            var project = EARepository.Instance.Native.GetProjectInterface();
            var baselineXmlGuid = project.GUIDtoXML(baseline.Guid);
            var diffString = project.DoBaselineCompare(GUID, baselineXmlGuid, "");
            return BaselineDiff.ParseFromXML(this, baseline, diffString);
        }

        public bool CreateBaseline(string version, string notes)
        {
            var project = EARepository.Instance.Native.GetProjectInterface();
            return project.CreateBaseline(GUID, version, notes);
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
    }
}