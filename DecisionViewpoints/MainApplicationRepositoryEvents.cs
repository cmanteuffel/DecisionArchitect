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
        public override bool EA_OnPreNewElement(Repository repository, EventProperties properties)
        {
            EARepository.UpdateRepository(repository);
            var element = EAVolatileElement.Wrap(properties);

            foreach (IRepositoryListener l in _listeners)
            {
                if (!l.OnPreNewElement(element))
                {
                    return false;
                }
            }
            return true;
        }

        public override bool EA_OnPostNewElement(Repository repository, EventProperties properties)
        {
            EARepository.UpdateRepository(repository);
            var element = EAElement.Wrap(properties);

            foreach (IRepositoryListener l in _listeners)
            {
                if (!l.OnPostNewElement(element))
                {
                    return false;
                }
            }
            return true;
        }

        public override bool EA_OnPreNewConnector(Repository repository, EventProperties info)
        {
            EARepository.UpdateRepository(repository);
            var volatileConnector = EAVolatileConnector.Wrap(info);
            foreach (var l in _listeners)
            {
                if (!l.OnPreNewConnector(volatileConnector))
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
                l.OnContextItemChanged(guid, EAUtilities.Translate(ot));
            }
        }

        public override bool EA_OnContextItemDoubleClicked(Repository repository, string guid, ObjectType ot)
        {
            EARepository.UpdateRepository(repository);
            foreach (IRepositoryListener l in _listeners)
            {
                if (l.OnContextItemDoubleClicked(guid, EAUtilities.Translate(ot)))
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
                l.OnNotifyContextItemModified(guid, EAUtilities.Translate(ot));
            }
        }

        public override bool EA_OnPreDeleteDiagram(Repository repository, EventProperties properties)
        {
            EARepository.UpdateRepository(repository);
            var diagram = EAVolatileDiagram.Wrap(properties);
            return _listeners.All(l => l.OnPreDeleteDiagram(diagram));
        }

        public override bool EA_OnPreDeleteElement(Repository repository, EventProperties properties)
        {
            EARepository.UpdateRepository(repository);
            var element = EAElement.Wrap(properties);

            foreach (IRepositoryListener l in _listeners)
            {
                if (!l.OnPreDeleteElement(element))
                {
                    return false;
                }
            }
            return true;
        }

        //angor moved from MainApplication
        public override void EA_OnPostOpenDiagram(Repository repository, int diagramId)
        {
            EARepository.UpdateRepository(repository);
            var diagram = EARepository.Instance.GetDiagramByID(diagramId);
            foreach (var l in _listeners)
            {
                l.OnPostOpenDiagram(diagram);
            }
        }

        //angor
        public override bool EA_OnPostNewDiagramObject(Repository repository, EventProperties properties)
        {
            EARepository.UpdateRepository(repository);
            foreach (var l in _listeners)
            {
                if (!l.OnPostNewDiagramObject())
                {
                    return false;
                }

            }
            return true;

        }

        //angor task179 START
        public override void EA_OnPostCloseDiagram(Repository repository, int diagramId)
        {
            EARepository.UpdateRepository(repository);
            //System.Windows.Forms.MessageBox.Show("Event OnPostCloseDiagram"); //angor
        }
        //angor task179 END
    }
}