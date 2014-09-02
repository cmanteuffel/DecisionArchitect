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
using EA;

namespace EAFacade.Model
{
// ReSharper disable InconsistentNaming
    public abstract class IEARepository : IEAObject
// ReSharper restore InconsistentNaming
    {
        internal Repository Native { get; set; }
        abstract public IEnumerable<IEAPackage> GetAllRootPackages();
        public abstract IEnumerable<IEAPackage> GetAllPackages();
        abstract public IEAPackage GetPackageFromRootByName(string name);
        abstract public IEAPackage GetPackageByID(int id);
        abstract public IEAPackage GetPackageByGUID(string guid);
        abstract public IEAElement GetElementByID(int elementID);
        abstract public string GetFieldFromFormat(string format, string text);
        abstract public string GetFormatFromField(string format, string text);
        abstract public IEAConnector GetConnectorByID(int connectorId);
        abstract public IEAConnector GetConnectorByGUID(string guid);
        abstract public string Query(string sql);
        abstract public IEADiagram GetDiagramByID(int id);
        abstract public IEADiagram GetDiagramByGuid(string guid);
        abstract public IEAElement GetElementByGUID(string guid);
        abstract public IEADiagram GetCurrentDiagram();
        abstract public IEnumerable<IEAElement> GetSelectedItems();
        abstract public IEnumerable<IEAElement> GetAllElements();
        abstract public void RefreshModelView(int packageID);
        abstract public void RefreshOpenDiagrams(bool fullReload);
        abstract public void AdviseElementChanged(int elementID);
        abstract public EANativeType GetContextItemType();
        abstract public bool IsProjectOpen();
        abstract public int IsTabOpen(string tabName);
        abstract public void ActivateTab(string tabName);
        abstract public dynamic AddTab(string tabName, string controlID);
        abstract public void RemoveTab(string tabName);
        abstract public void OpenDiagram(int diagramID);
        abstract public void ReloadDiagram(int diagramID);
        abstract public void SuppressDefaultDialogs(bool flag);
        public abstract T GetContextObject<T>() where T : IModelItem;

        
    }
}
