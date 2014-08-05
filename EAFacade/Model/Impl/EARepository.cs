/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    Marc Holterman (University of Groningen)

*/

using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.CompilerServices;
using EA;

namespace EAFacade.Model.Impl
{
    internal sealed class EARepository : IEARepository
    {
        private static EARepository _instance;

        private EARepository()
        {
        }

        public static EARepository Instance
        {
            get { return _instance ?? (_instance = new EARepository()); }
        }

        //Exception from pattern, native of repos is allowed to be exposed. Should be only used within the Model namespace
        //maybe we consider to move the model to an own assembly
        internal Repository Native { get; private set; }

        private Package Root
        {
            get { return Native.Models.GetAt(0); }
        }

        public static void UpdateRepository(Repository r)
        {
            Instance.Native = r;
        }

        public IEnumerable<IEAPackage> GetAllDecisionViewPackages()
        {
            return Native.Models.Cast<Package>().SelectMany(
                root => root.Packages.Cast<Package>()
                            .Select(EAPackage.Wrap)
                            .Where(eapackage => eapackage.IsDecisionViewPackage())).ToList();
        }

        public IEAPackage GetPackageFromRootByName(string name)
        {
            return EAPackage.Wrap(Root.Packages.GetByName(name));
        }

        public IEAPackage GetPackageByID(int id)
        {
            return EAPackage.Wrap(Native.GetPackageByID(id));
        }

        public IEAPackage GetPackageByGUID(string guid)
        {
            return EAPackage.Wrap(Native.GetPackageByGuid(guid));
        }

        public string GetFieldFromFormat(string format, string text)
        {
            return Native.GetFieldFromFormat(format, text);
        }

        public string GetFormatFromField(string format, string text)
        {
            return Native.GetFormatFromField(format, text);
        }


        /*
        public List<IEAPackage> GetAllPackages()
        {
            return IEAPackage.Wrap(Root.Packages);
        }
         */

        public IEAElement GetElementByID(int elementID)
        {
            return EAElement.Wrap(Native.GetElementByID(elementID));
        }

        public IEAConnector GetConnectorByID(int connectorId)
        {
            return EAConnector.Wrap(Native.GetConnectorByID(connectorId));
        }

        public IEAConnector GetConnectorByGUID(string guid)
        {
            return EAConnector.Wrap(Native.GetConnectorByGuid(guid));
        }

        public string Query(string sql)
        {
            return Native.SQLQuery(sql);
        }

        public IEADiagram GetDiagramByID(int id)
        {
            return EADiagram.Wrap(Native.GetDiagramByID(id));
        }

        public IEADiagram GetDiagramByGuid(string guid)
        {
            return EADiagram.Wrap(Native.GetDiagramByGuid(guid));
        }

        public IEAElement GetElementByGUID(string guid)
        {
            return EAElement.Wrap(Native.GetElementByGuid(guid));
        }

        public IEADiagram GetCurrentDiagram()
        {
            return EADiagram.Wrap(Native.GetCurrentDiagram());
        }

        public IEnumerable<IEAElement> GetSelectedItems()
        {
            Collection elements = Native.GetTreeSelectedElements();
            return (from object element in elements select EAElement.Wrap((Element)element)).ToList();
        }

        public IEnumerable<IEAElement> GetAllElements()
        {
            Collection elements = Native.GetElementSet(null, 0);
            return (from object element in elements select EAElement.Wrap((Element) element)).ToList();
        }

        public void RefreshModelView(int packageID)
        {
            Native.RefreshModelView(packageID);
        }

        public void RefreshOpenDiagrams(bool fullReload)
        {
            Native.RefreshOpenDiagrams(fullReload);
        }

        public void AdviseElementChanged(int elementID)
        {
            Native.AdviseElementChange(elementID);
        }

        public EANativeType GetContextItemType()
        {
            ObjectType nativeOt = Native.GetContextItemType();
            return EAUtilities.Translate(nativeOt);
        }

        public bool IsProjectOpen()
        {
            try
            {
                return null != Native.Models;
            }
            catch
            {
                return false;
            }
        }

        public int IsTabOpen(string tabName)
        {
            return Native.IsTabOpen(tabName);
        }

        public void ActivateTab(string tabName)
        {
            Native.ActivateTab(tabName);
        }
        
        public dynamic AddTab(string tabName, string controlID)
        {
            return Native.AddTab(tabName, controlID);
        }

        public void RemoveTab(string tabName)
        {
            Native.RemoveTab(tabName);
        }

        public void OpenDiagram(int diagramID)
        {
            Native.OpenDiagram(diagramID);
        }

        public void ReloadDiagram(int diagramID)
        {
            Native.ReloadDiagram(diagramID);
        }

        public void SuppressDefaultDialogs(bool flag)
        {
            Native.SuppressEADialogs = flag;
        }

        public T GetContextObject<T>() where T : IModelItem
        {
            dynamic obj = Native.GetContextObject();
            Type typeT = typeof (T);
            if (typeT == typeof (IEAElement))
            {
                var nativeElement = obj as Element;
                if (nativeElement != null)
                {
                    dynamic element = EAElement.Wrap(nativeElement);
                    return element;
                }
                return default(T);
            }
            if (typeT == typeof (IEAPackage))
            {
                var nativePackage = obj as Package;
                if (nativePackage != null)
                {
                    dynamic element = EAPackage.Wrap(nativePackage);
                    return element;
                }
                return default(T);
            }
            if (typeT == typeof (IEADiagram))
            {
                var nativeDiagram = obj as Diagram;
                if (nativeDiagram != null)
                {
                    dynamic element = EADiagram.Wrap(nativeDiagram);
                    return element;
                }
                return default(T);
            }

            throw new NotSupportedException("Type (" + typeT.Name + ") not supported by GetContextObject()");
        }
    }
}
