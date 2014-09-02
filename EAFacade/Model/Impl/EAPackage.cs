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
    K. Eric Harper (ABB Corporate Research)
*/

using System;
using System.Collections.Generic;
using System.Linq;
using EA;

namespace EAFacade.Model.Impl
{
     sealed class EAPackage : IEAPackage
    {
        private readonly Package _native;

        private EAPackage(Package native)
        {
            _native = native;
        }

        public IList<IEAElement> Elements
        {
            get
            {
                var elements = new List<IEAElement>(_native.Elements.Count);
                foreach (Element nativeElement in _native.Elements)
                {
                    elements.Add(EAElement.Wrap(nativeElement));
                }
                return elements;
            }
        }

        public IList<IEAPackage> Packages
        {
            get
            {
                IEAPackage package = EARepository.Instance.GetPackageByID(ID);
                return ((EAPackage)package)._native.Packages.Cast<Package>().Select(Wrap).ToList();
            }
        }

        public string Stereotype
        {
            get { return _native.StereotypeEx; }
            set { _native.StereotypeEx = value; }
        }

        public string GUID
        {
            get { return _native.PackageGUID; }
        }

        public int ID
        {
            get { return _native.PackageID; }
        }

        public EANativeType EANativeType
        {
            get { return EANativeType.Package; }
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

        public IEAPackage ParentPackage
        {
            get
            {
                //package is model root, returns itself
                if (_native.ParentID == 0)
                {
                    return this;
                }
                IEAPackage parentPkg = EARepository.Instance.GetPackageByID(_native.ParentID);
                return parentPkg;
            }
            set { _native.ParentID = value.ID; }
        }

        //TODO: Transparent ILIST that wraps the strange EA Collection


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

        public bool IsModelRoot()
        {
            return (this == ParentPackage);
        }

        public IEAPackage CreatePackage(string name, string stereotype = "")
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

        public void DeletePackage(IEAPackage package)
        {
            short index = 0;
            foreach (Package p in _native.Packages.Cast<Package>())
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

        public void DeleteElement(short index, bool refresh)
        {
            _native.Elements.Delete(index);
            if (refresh)
            {
                RefreshElements();
            }
        }


        public IEAElement CreateElement(string name, string stereotype, string type)
        {
            Element newElement = _native.Elements.AddNew(name, type);
            newElement.Stereotype = stereotype;
            newElement.Update();
            _native.Elements.Refresh();
            EARepository.Instance.RefreshModelView(_native.PackageID);
            return EAElement.Wrap(newElement);
        }

         public IEADiagram CreateDiagram(string name, string stereotype, string type)
         {
             Diagram newDiagram = _native.Diagrams.AddNew(name, type);
             newDiagram.Stereotype = stereotype;
             newDiagram.Update();
             _native.Diagrams.Refresh();
             EARepository.Instance.RefreshModelView(_native.PackageID);
             return EADiagram.Wrap(newDiagram);
         }

         public IEADiagram GetDiagram(string name)
        {
            return EADiagram.Wrap(_native.Diagrams.GetByName(name));
        }

        public static IEAPackage Wrap(Package native)
        {
            if (null == native)
            {
                throw new ArgumentNullException(
                    "native");
            }
            return new EAPackage(native);
        }

        public void RefreshElements()
        {
            _native.Elements.Refresh();
        }

        public IEAElement AddElement(string name, string type)
        {
            return EAElement.Wrap(_native.Elements.AddNew(name, type));
        }

        public IEnumerable<IEAElement> GetAllElementsOfSubTree()
        {
            var elements = new List<IEAElement>();
            var packagesStack = new Stack<IEAPackage>();
            var elementsStack = new Stack<IEAElement>();
            packagesStack.Push(this);
            while (packagesStack.Count > 0)
            {
                IEAPackage package = packagesStack.Pop();
                package.Elements.ToList().ForEach(elementsStack.Push);
                package.Packages.ToList().ForEach(packagesStack.Push);
            }
            while (elementsStack.Count > 0)
            {
                IEAElement element = elementsStack.Pop();
                element.GetElements().ForEach(elementsStack.Push);
                elements.Add(element);
            }
            return elements;
        }

        public IEnumerable<IEAElement> GetAllDecisions()
        {
            return GetAllElementsOfSubTree().Where(e => e.IsDecision() && !e.IsHistoryDecision());
        }

        public IEnumerable<IEAElement> GetAllTopics()
        {
            return GetAllElementsOfSubTree().Where(e => e.IsTopic());
        }

        public IEnumerable<IEADiagram> GetAllDiagrams()
        {
            var diagrams = new List<IEADiagram>();
            var packagesStack = new Stack<IEAPackage>();
            packagesStack.Push(this);
            while (packagesStack.Count > 0)
            {
                IEAPackage package = packagesStack.Pop();
                package.GetDiagrams().ToList().ForEach(diagrams.Add);
                package.Packages.ToList().ForEach(packagesStack.Push);
            }
            return diagrams;
        }


        public IEAPackage GetSubpackageByName(string data)
        {
            var packages = Packages;
            if (packages.Any())
            {
                var foundPackage = packages.FirstOrDefault(e => e.Name.Equals(data));
                if (foundPackage != null)
                {
                    return foundPackage;
                }
            }
            return null;
        }

        public bool IsDecisionViewPackage()
        {
            var underlyingElement = EAElement.Wrap(_native.Element);
            string value = underlyingElement.GetTaggedValue(EATaggedValueKeys.DecisionViewPackage);
            return (value != null && value.Equals("true"));
        }

         [Obsolete("dep", true)]
        public IEAPackage FindDecisionViewPackage()
        {
            IEAPackage package = this;
            if (package == null) throw new Exception("package is null");
            while (!(package.IsModelRoot() || package.IsDecisionViewPackage()))
            {
                package = package.ParentPackage;
            }
            return package;
        }

        public IEnumerable<IEADiagram> GetDiagrams()
        {
            return _native.Diagrams.Cast<Diagram>().Select(EADiagram.Wrap).ToList();
        }
    }
}
