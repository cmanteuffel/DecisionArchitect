using EAFacade.Model;

namespace DecisionViewpoints.Logic
{
    interface IRepositoryListener
    {
        string OnPostOpenDiagram(EADiagram diagram);

        void OnPostCloseDiagram(EADiagram diagram);

        bool OnPreDeleteElement(EAElement element);

        bool OnPreDeleteConnector(EAConnector connector);

        bool OnPreDeleteDiagram(EAVolatileDiagram volatileDiagram);

        bool OnPreDeletePackage(EAPackage pacakge);

        bool OnPreNewElement(EAVolatileElement element);

        bool OnPreNewConnector(EAVolatileConnector connector);

        bool OnPreNewDiagram(EAVolatileDiagram diagram);

        bool OnPreNewDiagramObject(EAVolatileDiagramObject diagramObject);

        bool OnPreNewPackage(EAVolatilePackage package);

        bool OnPostNewElement(EAElement element);

        bool OnPostNewConnector(EAConnector connector);

        bool OnPostNewDiagramObject(EADiagramObject diagramObject);

        bool OnPostNewPackage(EAPackage package);

        void OnContextItemChanged(string guid, NativeType type);

        bool OnContextItemDoubleClicked(string guid, NativeType type);

        void OnNotifyContextItemModified(string guid, NativeType type);

        void OnFileOpen();

        void OnFileClose();

        void OnFileNew();
    }
}