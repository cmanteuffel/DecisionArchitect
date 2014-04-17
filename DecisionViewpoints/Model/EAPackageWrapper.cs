using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EA;

namespace DecisionViewpoints.Model
{
    public class EAPackageWrapper : IEAWrapper
    {
        private readonly Package _package;

        public EAPackageWrapper(Package package)
        {
            _package = package;
        }

        public string GUID()
        {
            return _package.PackageGUID;
        }

        public Package Get()
        {
            return _package;
        }

        public Package CreatePackage(IDualRepository repository, string name)
        {
            Package newPackage = _package.Packages.AddNew(name, "");
            newPackage.Update();
            newPackage.Packages.Refresh();
            repository.RefreshModelView(_package.PackageID);
            return newPackage;
        }

        public void DeletePackage(short pos, bool refresh)
        {
            _package.Packages.DeleteAt(pos, refresh);
        }

        public Element CreateElement(IDualRepository repository, string name, string stereotype, string type)
        {
            Element newElement = _package.Elements.AddNew(name, type);
            newElement.Stereotype = stereotype;
            newElement.Update();
            _package.Elements.Refresh();
            repository.RefreshModelView(_package.PackageID);
            return newElement;
        }

        public Diagram CreateDiagram(IDualRepository repository, string name, string type)
        {
            Diagram d = _package.Diagrams.AddNew(name, type);
            d.Update();
            _package.Diagrams.Refresh();
            repository.RefreshModelView(_package.PackageID);
            return d;
        }

        public void DeleteDiagram(short pos, bool refresh)
        {
            _package.Diagrams.DeleteAt(pos, refresh);
        }

        public Element LastModifiedElement()
        {
            Element[] lastModified = {null};
            if (_package.Elements.Count > 0)
            {
                lastModified[0] = _package.Elements.GetAt(0);
                foreach (
                    var e in from Element e in _package.Elements where e.Modified > lastModified[0].Modified select e)
                {
                    lastModified[0] = e;
                }
            }
            return lastModified[0];
        }

        public Element LastCreated()
        {
            Element lastCreated = null;
            if (_package.Elements.Count > 0)
            {
                lastCreated = _package.Elements.GetAt(0);
                for (short i = 1; i < _package.Elements.Count; i++)
                {
                    Element e = _package.Elements.GetAt(i);
                    if (e.Created > lastCreated.Created)
                    {
                        lastCreated = e;
                    }
                }
            }
            return lastCreated;
        }

        public Element LastModifiedElement(IReadOnlyList<Element> sameElements)
        {
            Element[] lastSameModified = {null};
            if (sameElements.Count > 0)
            {
                lastSameModified[0] = sameElements[0];
                foreach (var e in sameElements.Where(e => e.Modified > lastSameModified[0].Modified))
                {
                    lastSameModified[0] = e;
                }
            }
            return lastSameModified[0];
        }

        public List<Element> SameElements(EAElementWrapper element)
        {
            var sameElements = new List<Element>();
            if (_package.Elements.Count > 0)
            {
                sameElements.AddRange(from Element e in _package.Elements
                                      where e.Name.Equals(element.Element.Name)
                                      select e);
            }
            return sameElements;
        }
    }
}