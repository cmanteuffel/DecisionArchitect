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

using EAFacade.Model;

namespace DecisionArchitect.Logic
{
    internal interface IRepositoryListener
    {
        void OnPostOpenDiagram(IEADiagram diagram);

        void OnPostCloseDiagram(IEADiagram diagram);

        bool OnPreDeleteElement(IEAElement element);

        bool OnPreDeleteConnector(IEAConnector connector);

        bool OnPreDeleteDiagram(IEAVolatileDiagram volatileDiagram);

        bool OnPreDeletePackage(IEAPackage pacakge);

        bool OnPreNewElement(IEAVolatileElement element);

        bool OnPreNewConnector(IEAVolatileConnector connector);

        bool OnPreNewDiagram(IEAVolatileDiagram diagram);

        bool OnPreNewDiagramObject(IEAVolatileDiagramObject diagramObject);

        bool OnPreNewPackage(IEAVolatilePackage package);

        bool OnPostNewElement(IEAElement element);

        bool OnPostNewConnector(IEAConnector connector);

        //cm: does not return a diagram object because of an issue within the EAMain API
        bool OnPostNewDiagramObject();

        bool OnPostNewPackage(IEAPackage package);

        void OnContextItemChanged(string guid, EANativeType type);

        bool OnContextItemDoubleClicked(string guid, EANativeType type);

        void OnNotifyContextItemModified(string guid, EANativeType type);

        void OnFileOpen();

        void OnFileClose();

        void OnFileNew();

        //marc: This is a callback that is not only triggered by the tabchange, also by opening of tabs etc.
        void OnTabChanged(string tabname, int diagramId);
    }
}