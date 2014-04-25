/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
*/

using System.Collections.Generic;

namespace EAFacade.Model
{
    public interface IEARepository : IEAObject
    {
        IEnumerable<IEAPackage> GetAllDecisionViewPackages();
        IEAPackage GetPackageFromRootByName(string name);
        IEAPackage GetPackageByID(int packageID);
        IEAElement GetElementByID(int elementID);
        IEAConnector GetConnectorByID(int connectorId);
        IEAConnector GetConnectorByGUID(string guid);
        string Query(string sql);
        IEADiagram GetDiagramByID(int id);
        IEADiagram GetDiagramByGuid(string guid);
        IEAElement GetElementByGUID(string guid);
        IEADiagram GetCurrentDiagram();
        IEnumerable<IEAElement> GetSelectedItems();
        IEnumerable<IEAElement> GetAllElements();
        void RefreshModelView(int packageID);
        void RefreshOpenDiagrams(bool fullReload);
        void AdviseElementChanged(int elementID);
        EANativeType GetContextItemType();
        bool IsProjectOpen();
        int IsTabOpen(string tabName);
        void ActivateTab(string tabName);
        dynamic AddTab(string tabName, string controlID);
        void RemoveTab(string tabName);
        void OpenDiagram(int diagramID);
        void ReloadDiagram(int diagramID);
        void SuppressDefaultDialogs(bool flag);
        T GetContextObject<T>() where T : IModelItem;
    }
}
