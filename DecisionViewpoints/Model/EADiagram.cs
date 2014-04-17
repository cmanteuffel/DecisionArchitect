using System;
using EA;

namespace DecisionViewpoints.Model
{
    public class EADiagram : IModelObject
    {
        private readonly Diagram _native;

        private EADiagram(Diagram native)
        {
            _native = native;
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
            get { return _native.DiagramGUID; }
        }

        public int ID
        {
            get { return _native.DiagramID; }
        }

        public NativeType NativeType
        {
            get { return NativeType.Diagram; }
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
            get { return _native.CreatedDate; }
            set { _native.CreatedDate = value; }
        }

        public DateTime Modified
        {
            get { return _native.ModifiedDate; }
            set { _native.ModifiedDate = value; }
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

        //TODO: Change to package private
        public static EADiagram Wrap(Diagram native)
        {
            var diagram = new EADiagram(native);
            return diagram;
        }

        [Obsolete]
        public Diagram Get()
        {
            return _native;
        }

        [Obsolete]
        public void CreateConnector(IDualElement lastModified, IDualElement newElement)
        {
            Connector connector = lastModified.Connectors.AddNew("", "ControlFlow");
            connector.Stereotype = "followed by";
            connector.SupplierID = newElement.ElementID;
            connector.Update();
            lastModified.Connectors.Refresh();
            newElement.Connectors.Refresh();
        }

        [Obsolete]
        public void AddToDiagram(Repository repository, IDualElement newElement)
        {
            DiagramObject diaObj = _native.DiagramObjects.AddNew("l=10;r=110;t=-20;b=-80", "");
            diaObj.ElementID = newElement.ElementID;
            diaObj.Update();
            repository.ReloadDiagram(_native.PackageID);
            repository.SaveDiagram(_native.DiagramID);
        }

        [Obsolete]
        public void OpenAndSelectElement(Repository repository, IDualElement element)
        {
            repository.OpenDiagram(_native.DiagramID);

            for (short i = 0; i < _native.SelectedObjects.Count; i++)
            {
                _native.SelectedObjects.Delete(i);
            }
            _native.SelectedObjects.AddNew(element.ElementID.ToString(), element.Type);
            repository.ActivateDiagram(_native.DiagramID);
        }
    }
}