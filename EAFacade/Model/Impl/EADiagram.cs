using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using EA;

namespace EAFacade.Model.Impl
{
    internal sealed class EADiagram : IEADiagram
    {
        private readonly Diagram _native;

        private EADiagram(Diagram native)
        {
            _native = native;
        }

        public IEAElement ParentElement
        {
            get
            {
                IEAElement parentElmt = null;
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

        public EANativeType EANativeType
        {
            get { return EANativeType.Diagram; }
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

        public string Metatype
        {
            get { return _native.MetaType; }
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

        public IEAPackage ParentPackage
        {
            get
            {
                IEAPackage parentPkg = EARepository.Instance.GetPackageByID(_native.PackageID);
                return parentPkg;
            }
            set { _native.PackageID = value.ID; }
        }

        public void ShowInProjectView()
        {
            EARepository.Instance.Native.ShowInProjectView(_native);
        }

        public string GetProjectPath()
        {
            IEAPackage current = ParentPackage;
            string path = current.Name;

            while (!current.IsModelRoot())
            {
                current = current.ParentPackage;
                path = current.Name + "/" + path;
            }
            path = "//" + path;
            return path;
        }

        internal static IEADiagram Wrap(Diagram native)
        {
            return new EADiagram(native);
        }

        public void AddToDiagram(IEAElement newElement)
        {
            //check if element already exists on diagram
            if (null != GetElements().FirstOrDefault(dobj => dobj.ElementID.Equals(newElement.ID)))
            {
                return;
            }

            DiagramObject diaObj = _native.DiagramObjects.AddNew("l=10;r=110;t=-20;b=-80", "");
            diaObj.ElementID = newElement.ID;
            diaObj.Update();
            var nativeRepository = EARepository.Instance.Native;
            nativeRepository.ReloadDiagram(_native.DiagramID);
            nativeRepository.SaveDiagram(_native.DiagramID);
        }

        public void OpenAndSelectElement(IEAElement element)
        {
            Repository repository = EARepository.Instance.Native;
            repository.OpenDiagram(_native.DiagramID);

            for (short i = 0; i < _native.SelectedObjects.Count; i++)
            {
                _native.SelectedObjects.Delete(i);
            }
            _native.SelectedObjects.AddNew(element.ID.ToString(CultureInfo.InvariantCulture), element.Type);
            repository.ActivateDiagram(_native.DiagramID);
        }

        public List<IEADiagramObject> GetElements()
        {
            return
                (from DiagramObject diagramObject in _native.DiagramObjects select EADiagramObject.Wrap(diagramObject))
                    .ToList();
        }

        public void HideConnectors(string[] stereotypes)
        {
            var repository = EARepository.Instance;
            foreach (var diagramLink in from DiagramLink diagramLink in _native.DiagramLinks
                                        let connector = repository.GetConnectorByID(diagramLink.ConnectorID)
                                        where stereotypes.Contains(connector.Stereotype)
                                        select diagramLink)
            {
                diagramLink.IsHidden = true;
                diagramLink.Update();
            }
            _native.DiagramLinks.Refresh();
            repository.ReloadDiagram(_native.DiagramID);
        }

        public bool IsForcesView()
        {
          return Metatype.Equals(EAConstants.DiagramMetaTypeForces);
        }

        public bool IsChronologicalView()
        {
            return Metatype.Equals(EAConstants.DiagramMetaTypeChronological);
        }

        public bool IsRelationshipView()
        {
            return Metatype.Equals(EAConstants.DiagramMetaTypeRelationship);
        }

        public bool IsStakeholderInvolvementView()
        {
            return Metatype.Equals(EAConstants.DiagramMetaTypeStakeholder);
        }

        public bool Contains(IEAElement element)
        {
            var repository = EARepository.Instance;
            return
                (from DiagramObject diagramObject in _native.DiagramObjects
                 select repository.GetElementByID(diagramObject.ElementID)).Any(
                     diagramElement => diagramElement.GUID == element.GUID);
        }

        public FileStream DiagramToStream()
        {
            var project = EARepository.Instance.Native.GetProjectInterface();
            var path = Path.GetTempPath();
            var fileName = Guid.NewGuid().ToString() + ".emf";
            string filename = Path.Combine(path, fileName);

            EARepository.Instance.OpenDiagram(ID);
            project.SaveDiagramImageToFile(filename);
            return new FileStream(filename, FileMode.Open);
        }

        
    }
}