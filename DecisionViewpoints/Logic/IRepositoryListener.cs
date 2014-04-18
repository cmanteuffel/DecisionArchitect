using DecisionViewpoints.Model;
using EA;

namespace DecisionViewpoints.Logic
{
    interface IRepositoryListener
    {
        string OnPostOpenDiagram(EADiagram diagram);

        void OnPostCloseDiagram(EADiagram diagram);

        bool OnPreDeleteElement(EAElement element);

        bool OnPreDeleteConnector(EAConnectorWrapper connector);

        bool OnPreDeleteDiagram(EADiagram diagram);

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

        void OnContextItemChanged(string guid, ObjectType type);

        bool OnContextItemDoubleClicked(string guid, ObjectType type);

        void OnNotifyContextItemModified(string guid, ObjectType type);

        void OnFileOpen();

        void OnFileClose();

        void OnFileNew();
    }
}