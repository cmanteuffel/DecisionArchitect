using DecisionViewpoints.Model;
using EA;

namespace DecisionViewpoints.Logic
{
    public abstract class RepositoryAdapter : IRepositoryListener
    {
        public virtual string OnPostOpenDiagram(EADiagram diagram)
        {
            return "";
        }

        public virtual void OnPostCloseDiagram(EADiagram diagram)
        {
        }

        public virtual bool OnPreDeleteElement(EAElement element)
        {
            return true;
        }

        public virtual bool OnPreDeleteConnector(EAConnectorWrapper connector)
        {
            return true;
        }

        public virtual bool OnPreDeleteDiagram(EADiagram diagram)
        {
            return true;
        }

        public virtual bool OnPreDeletePackage(EAPackage pacakge)
        {
            return true;
        }

        public virtual bool OnPreNewElement(EAVolatileElement element)
        {
            return true;
        }

        public virtual bool OnPreNewConnector(EAConnectorWrapper connector)
        {
            return true;
        }

        public virtual bool OnPreNewDiagram(EAVolatileDiagram diagram)
        {
            return true;
        }

        public virtual bool OnPreNewPackage(EAVolatilePackage package)
        {
            return true;
        }

        public virtual bool OnPostNewElement(EAElement element)
        {
            return true;
        }

        public virtual bool OnPostNewConnector(EAConnectorWrapper connector)
        {
            return true;
        }

        public virtual bool OnPostNewPackage(EAPackage package)
        {
            return true;
        }

        public virtual void OnContextItemChanged(string guid, ObjectType type)
        {
        }

        public virtual void OnContextItemDoubleClicked(string guid, ObjectType type)
        {
        }

        public virtual void OnNotifyContextItemModified(string guid, ObjectType type)
        {
        }

        public virtual void OnFileOpen()
        {
        }

        public virtual void OnFileClose()
        {
        }

        public virtual void OnFileNew()
        {
        }
    }
}