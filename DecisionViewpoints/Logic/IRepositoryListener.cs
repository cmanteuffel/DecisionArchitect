using EAFacade.Model;


namespace DecisionViewpoints.Logic
{
    interface IRepositoryListener
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

        //cm: does not return a diagram object because of an issue within the EA API
        bool OnPostNewDiagramObject();

        bool OnPostNewPackage(IEAPackage package);

        void OnContextItemChanged(string guid, EANativeType type);

        bool OnContextItemDoubleClicked(string guid, EANativeType type);

        void OnNotifyContextItemModified(string guid, EANativeType type);

        void OnFileOpen();

        void OnFileClose();

        void OnFileNew();
    }
}