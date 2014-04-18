using EAFacade.Model;

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

        public virtual bool OnPreDeleteConnector(EAConnector connector)
        {
            return true;
        }

        public virtual bool OnPreDeleteDiagram(EAVolatileDiagram volatileDiagram)
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

        public virtual bool OnPreNewConnector(EAVolatileConnector connector)
        {
            return true;
        }

        public virtual bool OnPreNewDiagram(EAVolatileDiagram diagram)
        {
            return true;
        }

        public bool OnPreNewDiagramObject(EAVolatileDiagramObject diagramObject)
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

        public virtual bool OnPostNewConnector(EAConnector connector)
        {
            return true;
        }

        public bool OnPostNewDiagramObject(EADiagramObject diagramObject)
        {
            return true;
        }

        public virtual bool OnPostNewPackage(EAPackage package)
        {
            return true;
        }

        public virtual void OnContextItemChanged(string guid, NativeType type)
        {
        }

        public virtual bool OnContextItemDoubleClicked(string guid, NativeType type)
        {
            return false;
        }

        public virtual void OnNotifyContextItemModified(string guid, NativeType type)
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