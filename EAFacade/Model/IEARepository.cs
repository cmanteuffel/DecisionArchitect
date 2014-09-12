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

using System.Collections.Generic;
using EA;

namespace EAFacade.Model
{
// ReSharper disable InconsistentNaming
    public abstract class IEARepository : IEAObject
// ReSharper restore InconsistentNaming
    {
        internal Repository Native { get; set; }
        public abstract IEnumerable<IEAPackage> GetAllRootPackages();
        public abstract IEnumerable<IEAPackage> GetAllPackages();
        public abstract IEAPackage GetPackageFromRootByName(string name);
        public abstract IEAPackage GetPackageByID(int id);
        public abstract IEAPackage GetPackageByGUID(string guid);
        public abstract IEAElement GetElementByID(int elementID);
        public abstract string GetFieldFromFormat(string format, string text);
        public abstract string GetFormatFromField(string format, string text);
        public abstract IEAConnector GetConnectorByID(int connectorId);
        public abstract IEAConnector GetConnectorByGUID(string guid);
        public abstract string Query(string sql);
        public abstract IEADiagram GetDiagramByID(int id);
        public abstract IEADiagram GetDiagramByGuid(string guid);
        public abstract IEAElement GetElementByGUID(string guid);
        public abstract IEADiagram GetCurrentDiagram();
        public abstract IEnumerable<IEAElement> GetSelectedItems();
        public abstract IEnumerable<IEAElement> GetAllElements();
        public abstract void RefreshModelView(int packageID);
        public abstract void RefreshOpenDiagrams(bool fullReload);
        public abstract void AdviseElementChanged(int elementID);
        public abstract EANativeType GetContextItemType();
        public abstract bool IsProjectOpen();
        public abstract int IsTabOpen(string tabName);
        public abstract void ActivateTab(string tabName);
        public abstract dynamic AddTab(string tabName, string controlID);
        public abstract void RemoveTab(string tabName);
        public abstract void OpenDiagram(int diagramID);
        public abstract void ReloadDiagram(int diagramID);
        public abstract void SuppressDefaultDialogs(bool flag);
        public abstract T GetContextObject<T>() where T : IModelItem;
    }
}