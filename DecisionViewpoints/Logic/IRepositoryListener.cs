﻿using EAFacade.Model;

namespace DecisionViewpoints.Logic
{
    interface IRepositoryListener
    {
        string OnPostOpenDiagram(EADiagram diagram);

        void OnPostCloseDiagram(EADiagram diagram);

        bool OnPreDeleteElement(EAElement element);

        bool OnPreDeleteConnector(EAConnectorWrapper connector);

        bool OnPreDeleteDiagram(EAVolatileDiagram volatileDiagram);

        bool OnPreDeletePackage(EAPackage pacakge);

        bool OnPreNewElement(EAVolatileElement element);

        bool OnPreNewConnector(EAConnectorWrapper connector);

        bool OnPreNewDiagram(EAVolatileDiagram diagram);

        //bool OnPreNewDiagramObject(EventProperties properties);

        bool OnPreNewPackage(EAVolatilePackage package);

        bool OnPostNewElement(EAElement element);

        bool OnPostNewConnector(EAConnectorWrapper connector);

        //bool OnPostNewDiagramObject(EventProperties properties);

        bool OnPostNewPackage(EAPackage package);

        void OnContextItemChanged(string guid, NativeType type);

        bool OnContextItemDoubleClicked(string guid, NativeType type);

        void OnNotifyContextItemModified(string guid, NativeType type);

        void OnFileOpen();

        void OnFileClose();

        void OnFileNew();
    }
}