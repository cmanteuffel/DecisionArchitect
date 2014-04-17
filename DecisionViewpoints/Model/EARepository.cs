using System;
using EA;
using Microsoft.VisualBasic;

namespace DecisionViewpoints.Model
{
    public class EARepository : IEAObject
    {
        private static EARepository _instance;

        [Obsolete]
        public EARepository(Repository native)
        {
        }

        private EARepository()
        {
        }

        public static EARepository Instance
        {
            get { return _instance ?? (_instance = new EARepository()); }
        }

        private Repository Native
        {
            get
            {
                var app = Interaction.GetObject("EA.App") as App;
                if (app != null) return app.Repository;
                return null;
            }
        }

        private Package Root
        {
            get { return Native.Models.GetAt(0); }
        }

        [Obsolete]
        public Package CreateView(string name, int pos)
        {
            Package view = Root.Packages.AddNew(name, "");
            // Set the icon of the view. Info can be found in ScriptingEA page 20
            view.Flags = "VICON=0;";
            view.TreePos = pos;
            view.Update();
            Root.Packages.Refresh();
            return view;
        }

        [Obsolete]
        public Diagram CreateDiagram(Package parent, string name, string metatype)
        {
            Diagram diagram = parent.Diagrams.AddNew(name, metatype);
            diagram.Update();
            parent.Diagrams.Refresh();
            Native.RefreshModelView(parent.PackageID);
            return diagram;
        }

        public Package CreatePackage(Package parent, string name)
        {
            Package package = parent.Packages.AddNew(name, "");
            package.Update();
            package.Packages.Refresh();
            Native.RefreshModelView(parent.PackageID);
            return package;
        }

        [Obsolete]
        public Package GetPackageFromRootByName(string name)
        {
            return Root.Packages.GetByName(name);
        }

        public EAPackage GetPackageByID(int packageID)
        {
            return EAPackage.Wrap(Native.GetPackageByID(packageID));
        }

        public EAElement GetElementByID(int elementID)
        {
            return EAElement.Wrap(Native.GetElementByID(elementID));
        }
    }
}