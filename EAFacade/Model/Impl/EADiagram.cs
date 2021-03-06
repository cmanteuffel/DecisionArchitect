/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    Mark Hoekstra (University of Groningen)
*/

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

        /// <summary>
        ///     Implements IEADiagram.AddElement(IEAElement element)
        /// </summary>
        /// <param name="element"></param>
        public void AddElement(IEAElement element)
        {
            //check if element already exists on diagram
            if (null != GetElements().FirstOrDefault(dobj => dobj.ElementID.Equals(element.ID)))
            {
                return;
            }

            DiagramObject diaObj = _native.DiagramObjects.AddNew("l=10;r=110;t=-20;b=-80", "");
            diaObj.ElementID = element.ID;
            diaObj.Update();
            _native.DiagramObjects.Refresh();
            _native.Update();
            Repository nativeRepository = EARepository.Instance.Native;
            nativeRepository.ReloadDiagram(_native.DiagramID);
            nativeRepository.SaveDiagram(_native.DiagramID);
        }

        /// <summary>
        ///     Implements IEADiagram.RemoveElement(IEAElement element)
        /// </summary>
        /// <param name="element"></param>
        public void RemoveElement(IEAElement element)
        {
            for (short i = 0; i < _native.DiagramObjects.Count; i++)
            {
                DiagramObject obj = _native.DiagramObjects.GetAt(i);
                if (obj.ElementID.Equals(element.ID))
                {
                    _native.DiagramObjects.Delete(i);
                    _native.DiagramObjects.Refresh();

                    Repository nativeRepository = EARepository.Instance.Native;
                    nativeRepository.ReloadDiagram(_native.DiagramID);
                    nativeRepository.SaveDiagram(_native.DiagramID);
                    break;
                }
            }
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

        public void HideConnectors(IEnumerable<string> stereotypes)
        {
            EARepository repository = EARepository.Instance;
            foreach (DiagramLink diagramLink in from DiagramLink diagramLink in _native.DiagramLinks
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
            EARepository repository = EARepository.Instance;
            return
                (from DiagramObject diagramObject in _native.DiagramObjects
                 select repository.GetElementByID(diagramObject.ElementID)).Any(
                     diagramElement => diagramElement.GUID == element.GUID);
        }

        public FileStream DiagramToStream()
        {
            Project project = EARepository.Instance.Native.GetProjectInterface();
            string path = Path.GetTempPath();
            string fileName = Guid.NewGuid().ToString() + ".emf";
            string filename = Path.Combine(path, fileName);

            EARepository.Instance.OpenDiagram(ID);
            project.SaveDiagramImageToFile(filename);
            return new FileStream(filename, FileMode.Open);
        }

        internal static IEADiagram Wrap(Diagram native)
        {
            if (null == native)
            {
                throw new ArgumentNullException("native");
            }
            return new EADiagram(native);
        }
    }
}