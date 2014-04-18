using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EA;

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

        public void DeletePackage(EAPackage package)
        {
            short index = 0;
            foreach (Package p in  _native.Packages.Cast<Package>())
            {
                
                if (p.PackageGUID.Equals(package.GUID))
                {
                    _native.Packages.DeleteAt(index, true);
                    EARepository.Instance.RefreshModelView(_native.PackageID);
                    return;
                }
                index++;
            }
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

        public EADiagram GetDiagram(string name)
        {
            return EADiagram.Wrap(_native.Diagrams.GetByName(name));
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
            var decisions = new List<EAElement>();
            var elementsStack = new Stack<EAElement>();
            _native.Elements.Cast<Element>().ToList().ForEach(e => elementsStack.Push(EAElement.Wrap(e)));

            while (elementsStack.Count > 0)
            {
                var element = elementsStack.Pop(); 
                element.GetElements().ForEach(elementsStack.Push);
                if (element.IsDecision())
                {
                    decisions.Add(element);
                }
            }

            return decisions;
        }

        public IEnumerable<EAElement> GetAllTopics()
        {
            var topics = new List<EAElement>();
            var elementsStack = new Stack<EAElement>();
            _native.Elements.Cast<Element>().ToList().ForEach(e => elementsStack.Push(EAElement.Wrap(e)));

            while (elementsStack.Count > 0)
            {
                var element = elementsStack.Pop();
                element.GetElements().ForEach(elementsStack.Push);
                if (element.IsTopic())
                {
                    topics.Add(element);
                }
            }

            return topics;
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

        public IEnumerable<EADiagram> GetDiagrams()
        {
            return _native.Diagrams.Cast<Diagram>().Select(EADiagram.Wrap).ToList();
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
    }
}