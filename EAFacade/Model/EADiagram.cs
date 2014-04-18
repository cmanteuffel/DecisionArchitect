using System;
using System.Collections.Generic;
using System.Linq;
using EA;

namespace EAFacade.Model
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

        public EAPackage ParentPackage
        {
            get
            {
                EAPackage parentPkg = EARepository.Instance.GetPackageByID(_native.PackageID);
                return parentPkg;
            }
            set { _native.PackageID = value.ID; }
        }

        public void ShowInProjectView()
        {
            EARepository.Instance.Native.ShowInProjectView(_native);
        }

        [Obsolete("Do not use outside of model namespace or main app")]
        internal static EADiagram Wrap(Diagram native)
        {
            return new EADiagram(native);
        }

        public void AddToDiagram(EAElement newElement)
        {
            DiagramObject diaObj = _native.DiagramObjects.AddNew("l=10;r=110;t=-20;b=-80", "");
            diaObj.ElementID = newElement.ID;
            diaObj.Update();
            var nativeRepository = EARepository.Instance.Native;
            nativeRepository.ReloadDiagram(_native.DiagramID);
            nativeRepository.SaveDiagram(_native.DiagramID);
        }

        public void OpenAndSelectElement(EAElement element)
        {
            Repository repository = EARepository.Instance.Native;
            repository.OpenDiagram(_native.DiagramID);

            for (short i = 0; i < _native.SelectedObjects.Count; i++)
            {
                _native.SelectedObjects.Delete(i);
            }
            _native.SelectedObjects.AddNew(element.ID.ToString(), element.Type);
            repository.ActivateDiagram(_native.DiagramID);
        }

        public List<EADiagramObject> GetElements()
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
            return Metatype.Equals(DVStereotypes.DiagramMetaTypeForces);
        }

        public bool IsChronologicalView()
        {
            return Metatype.Equals(DVStereotypes.DiagramMetaTypeChronological);
        }

        public bool IsRelationshipView()
        {
            return Metatype.Equals(DVStereotypes.DiagramMetaTypeRelationship);
        }

        public bool IsStakeholderInvolvementView()
        {
            return Metatype.Equals(DVStereotypes.DiagramMetaTypeStakeholder);
        }

        public bool Contains(EAElement element)
        {
            var repository = EARepository.Instance;
            foreach (DiagramObject diagramObject in _native.DiagramObjects)
            {
                var diagramElement = repository.GetElementByID(diagramObject.ElementID);
                if (diagramElement.GUID == element.GUID)
                    return true;
            }
            return false;
        }
    }
}