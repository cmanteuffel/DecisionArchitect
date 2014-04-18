using System.Windows.Forms;
using DecisionViewpoints.Logic;
using DecisionViewpoints.Model;
using DecisionViewpoints.Model.Events;
using EA;

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
                l.OnContextItemChanged(guid, ot);
            }
        }

        public override bool EA_OnContextItemDoubleClicked(Repository repository, string guid, ObjectType ot)
        {
            EARepository.UpdateRepository(repository);
            foreach (IRepositoryListener l in _listeners)
            {
                if (l.OnContextItemDoubleClicked(guid, ot))
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
                l.OnNotifyContextItemModified(guid, ot);
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
    }
}