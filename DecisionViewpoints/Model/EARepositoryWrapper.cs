using EA;

namespace DecisionViewpoints.Model
{
    public class EARepositoryWrapper : IEAWrapper
    {
        private readonly Repository _repository;
        private readonly Package _root;

        public EARepositoryWrapper(Repository repository)
        {
            _repository = repository;
            _root = repository.Models.GetAt(0);
        }

        public Package CreateView(string name, int pos)
        {
            Package view = _root.Packages.AddNew(name, "");
            // Set the icon of the view. Info can be found in ScriptingEA page 20
            view.Flags = "VICON=0;";
            view.TreePos = pos;
            view.Update();
            _root.Packages.Refresh();
            return view;
        }

        public Diagram CreateDiagram(Package parent, string name, string metatype)
        {
            Diagram diagram = parent.Diagrams.AddNew(name, metatype);
            diagram.Update();
            parent.Diagrams.Refresh();
            _repository.RefreshModelView(parent.PackageID);
            return diagram;
        }

        public Package CreatePackage(Package parent, string name)
        {
            Package package = parent.Packages.AddNew(name, "");
            package.Update();
            package.Packages.Refresh();
            _repository.RefreshModelView(parent.PackageID);
            return package;
        }

        public Package GetPackageFromRootByName(string name)
        {
            return _root.Packages.GetByName(name);
        }
    }
}
