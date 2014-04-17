using System;
using EA;

namespace DecisionViewpoints.Model
{
    public class EAPackage : IModelObject
    {
        private readonly Package _package;

        public EAPackage(Package package)
        {
            _package = package;
        }

        public string GUID
        {
            get { return _package.PackageGUID; }
        }

        public int ID { get; private set; }
        public NativeType NativeType { get; private set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Version { get; set; }
        public EAPackage ParentPackage { get; set; }
        public IModelObject Parent { get; set; }

        [Obsolete]
        public Package Get()
        {
            return _package;
        }

        public Package CreatePackage(IDualRepository repository, string name, string stereotype = "")
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

        public static EAPackage Wrap(Package packageID)
        {
            throw new NotImplementedException();
        }
    }
}