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
using System.Linq;
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
        // internal Repository Native { get; private set; }

        private Package Root
        {
            get { return Native.Models.GetAt(0); }
        }

        public override IEnumerable<IEAPackage> GetAllPackages()
        {
            return Native.Models.Cast<Package>().SelectMany(
                root => root.Packages.Cast<Package>()
                            .Select(EAPackage.Wrap)).ToList();
        }

        public override IEnumerable<IEAPackage> GetAllRootPackages()
        {
            return Native.Models.Cast<Package>().Select(EAPackage.Wrap).ToList();
        }

        public override IEAPackage GetPackageFromRootByName(string name)
        {
            return EAPackage.Wrap(Root.Packages.GetByName(name));
        }

        public override IEAPackage GetPackageByID(int id)
        {
            return EAPackage.Wrap(Native.GetPackageByID(id));
        }

        public override IEAPackage GetPackageByGUID(string guid)
        {
            return EAPackage.Wrap(Native.GetPackageByGuid(guid));
        }

        public override string GetFieldFromFormat(string format, string text)
        {
            return Native.GetFieldFromFormat(format, text);
        }

        public override string GetFormatFromField(string format, string text)
        {
            return Native.GetFormatFromField(format, text);
        }

        public override IEAElement GetElementByID(int elementID)
        {
            return EAElement.Wrap(Native.GetElementByID(elementID));
        }

        public override IEAConnector GetConnectorByID(int connectorId)
        {
            return EAConnector.Wrap(Native.GetConnectorByID(connectorId));
        }

        public override IEAConnector GetConnectorByGUID(string guid)
        {
            return EAConnector.Wrap(Native.GetConnectorByGuid(guid));
        }

        public override string Query(string sql)
        {
            return Native.SQLQuery(sql);
        }

        public override IEADiagram GetDiagramByID(int id)
        {
            return EADiagram.Wrap(Native.GetDiagramByID(id));
        }

        public override IEADiagram GetDiagramByGuid(string guid)
        {
            return EADiagram.Wrap(Native.GetDiagramByGuid(guid));
        }

        public override IEAElement GetElementByGUID(string guid)
        {
            return EAElement.Wrap(Native.GetElementByGuid(guid));
        }

        public override IEADiagram GetCurrentDiagram()
        {
            return EADiagram.Wrap(Native.GetCurrentDiagram());
        }

        public override IEnumerable<IEAElement> GetSelectedItems()
        {
            Collection elements = Native.GetTreeSelectedElements();
            return (from object element in elements select EAElement.Wrap((Element) element)).ToList();
        }

        public override IEnumerable<IEAElement> GetAllElements()
        {
            Collection elements = Native.GetElementSet(null, 0);
            return (from object element in elements select EAElement.Wrap((Element) element)).ToList();
        }

        public override void RefreshModelView(int packageID)
        {
            Native.RefreshModelView(packageID);
        }

        public override void RefreshOpenDiagrams(bool fullReload)
        {
            Native.RefreshOpenDiagrams(fullReload);
        }

        public override void AdviseElementChanged(int elementID)
        {
            Native.AdviseElementChange(elementID);
        }

        public override EANativeType GetContextItemType()
        {
            ObjectType nativeOt = Native.GetContextItemType();
            return EAUtilities.Translate(nativeOt);
        }

        public override bool IsProjectOpen()
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

        public override int IsTabOpen(string tabName)
        {
            return Native.IsTabOpen(tabName);
        }

        public override void ActivateTab(string tabName)
        {
            Native.ActivateTab(tabName);
        }

        public override dynamic AddTab(string tabName, string controlID)
        {
            return Native.AddTab(tabName, controlID);
        }

        public override void RemoveTab(string tabName)
        {
            Native.RemoveTab(tabName);
        }

        public override void OpenDiagram(int diagramID)
        {
            Native.OpenDiagram(diagramID);
        }

        public override void ReloadDiagram(int diagramID)
        {
            Native.ReloadDiagram(diagramID);
        }

        public override void SuppressDefaultDialogs(bool flag)
        {
            Native.SuppressEADialogs = flag;
        }

        public override T GetContextObject<T>()
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

        public static void UpdateRepository(Repository r)
        {
            Instance.Native = r;
        }
    }
}