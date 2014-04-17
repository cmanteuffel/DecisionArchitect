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

        public Package CreatePackage(IDualRepository repository, string name, string stereotype="")
        {
            Package newPackage = _package.Packages.AddNew(name, "");
            newPackage.Update();
            if (!stereotype.Equals(""))
            {
                newPackage.Element.Stereotype = stereotype;
                newPackage.Update();
            }
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

        public Diagram GetDiagram(string name)
        {
            return _package.Diagrams.GetByName(name);
        }
    }
}