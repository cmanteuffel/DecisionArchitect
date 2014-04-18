using EAFacade.Model;


namespace DecisionViewpoints.Logic
{
    public abstract class RepositoryAdapter : IRepositoryListener
    {
        public virtual void OnPostOpenDiagram(IEADiagram diagram)
        {
        }

        public virtual void OnPostCloseDiagram(IEADiagram diagram)
        {
        }

        public virtual bool OnPreDeleteElement(IEAElement element)
        {
            return true;
        }

        public virtual bool OnPreDeleteConnector(IEAConnector connector)
        {
            return true;
        }

        public virtual bool OnPreDeleteDiagram(IEAVolatileDiagram volatileDiagram)
        {
            return true;
        }

        public virtual bool OnPreDeletePackage(IEAPackage pacakge)
        {
            return true;
        }

        public virtual bool OnPreNewElement(IEAVolatileElement element)
        {
            return true;
        }

        public virtual bool OnPreNewConnector(IEAVolatileConnector connector)
        {
            return true;
        }

        public virtual bool OnPreNewDiagram(IEAVolatileDiagram diagram)
        {
            return true;
        }

        public bool OnPreNewDiagramObject(IEAVolatileDiagramObject diagramObject)
        {
            return true;
        }

        public virtual bool OnPreNewPackage(IEAVolatilePackage package)
        {
            return true;
        }

        public virtual bool OnPostNewElement(IEAElement element)
        {
            return true;
        }

        public virtual bool OnPostNewConnector(IEAConnector connector)
        {
            return true;
        }

        public virtual bool OnPostNewDiagramObject()
        {
            return true;
        }

        public virtual bool OnPostNewPackage(IEAPackage package)
        {
            return true;
        }

        public virtual void OnContextItemChanged(string guid, EANativeType type)
        {
        }

        public virtual bool OnContextItemDoubleClicked(string guid, EANativeType type)
        {
            return false;
        }

        public virtual void OnNotifyContextItemModified(string guid, EANativeType type)
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