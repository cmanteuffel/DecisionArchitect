using System.Linq;
using DecisionViewpoints.Logic;
using EA;
using EAFacade;
using EAFacade.Model;

namespace DecisionViewpoints
{
    //TODO: Not all events are implemented
    public partial class MainApplication
    {
        public override bool EA_OnPreNewElement(Repository repository, EventProperties info)
        {
            EARepository.UpdateRepository(repository);
            EAVolatileElement element = EAVolatileElement.Wrap(info);

            foreach (IRepositoryListener l in _listeners)
            {
                if (!l.OnPreNewElement(element))
                {
                    return false;
                }
            }
            return true;
        }

        public override bool EA_OnPreNewConnector(Repository repository, EventProperties info)
        {
            EARepository.UpdateRepository(repository);
            EAConnectorWrapper connectorWrapper = EAConnectorWrapper.Wrap(info);
            foreach (IRepositoryListener l in _listeners)
            {
                if (!l.OnPreNewConnector(connectorWrapper))
                {
                    return false;
                }
            }
            return true;
        }

        public override void EA_OnContextItemChanged(Repository repository, string guid, ObjectType ot)
        {
            EARepository.UpdateRepository(repository);
            foreach (IRepositoryListener l in _listeners)
            {
                l.OnContextItemChanged(guid, Utilities.Translate(ot));
            }
        }

        public override bool EA_OnContextItemDoubleClicked(Repository repository, string guid, ObjectType ot)
        {
            EARepository.UpdateRepository(repository);
            foreach (IRepositoryListener l in _listeners)
            {
                if (l.OnContextItemDoubleClicked(guid, Utilities.Translate(ot)))
                {
                    return true;
                }
            }
            return false;
        }

        public override void EA_OnNotifyContextItemModified(Repository repository, string guid, ObjectType ot)
        {
            EARepository.UpdateRepository(repository);
            foreach (IRepositoryListener l in _listeners)
            {
                l.OnNotifyContextItemModified(guid, Utilities.Translate(ot));
            }
        }


        public override void EA_FileOpen(Repository repository)
        {
            EARepository.UpdateRepository(repository);
            foreach (IRepositoryListener l in _listeners)
            {
                l.OnFileOpen();
            }
        }

        public override void EA_FileClose(Repository repository)
        {
            EARepository.UpdateRepository(repository);
            foreach (IRepositoryListener l in _listeners)
            {
                l.OnFileClose();
            }
        }

        public override void EA_FileNew(Repository repository)
        {
            EARepository.UpdateRepository(repository);
            foreach (IRepositoryListener l in _listeners)
            {
                l.OnFileNew();
            }
        }

        public override bool EA_OnPreDeleteDiagram(Repository repository, EventProperties properties)
        {
            EARepository.UpdateRepository(repository);
            var diagramWrapper = EAVolatileDiagram.Wrap(properties);
            return _listeners.All(l => l.OnPreDeleteDiagram(diagramWrapper));
        }
    }
}