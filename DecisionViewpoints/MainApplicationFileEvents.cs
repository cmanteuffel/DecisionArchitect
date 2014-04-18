using EA;
using EAFacade.Model;

namespace DecisionViewpoints
{
    public partial class MainApplication
    {
        public override void EA_FileOpen(Repository repository)
        {
            EARepository.UpdateRepository(repository);
            foreach (var l in _listeners)
            {
                l.OnFileOpen();
            }
        }

        public override void EA_FileClose(Repository repository)
        {
            EARepository.UpdateRepository(repository);
            foreach (var l in _listeners)
            {
                l.OnFileClose();
            }
        }

        public override void EA_FileNew(Repository repository)
        {
            EARepository.UpdateRepository(repository);
            foreach (var l in _listeners)
            {
                l.OnFileNew();
            }
        }

        public override void EA_OnPostOpenDiagram(Repository repository, int diagramId)
        {
            EARepository.UpdateRepository(repository);
            var diagram = EARepository.Instance.GetDiagramByID(diagramId);
            foreach (var l in _listeners)
            {
                l.OnPostOpenDiagram(diagram);
            }
        }
    }
}
