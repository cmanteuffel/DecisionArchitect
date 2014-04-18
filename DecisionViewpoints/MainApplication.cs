using System.Collections.Generic;
using DecisionViewpoints.Logic;
using DecisionViewpoints.Logic.Chronological;
using DecisionViewpoints.Logic.Forces;
using EA;
using EAFacade.Model;
using EAFacade.Model.Events;
using EAFacade;

namespace DecisionViewpoints
{
    public partial class MainApplication : EAEventAdapter
    {
        private readonly IList<IRepositoryListener> _listeners = new List<IRepositoryListener>();

        //init repository listener
        public MainApplication()
        {
          // _listeners.Add(new ValidationHandler());
            _listeners.Add(new ChronologicalViewpointHandler());
            _listeners.Add(new ForcesHandler());
        }

        public override object EA_OnInitializeTechnologies(Repository repository)
        {
            EARepository.UpdateRepository(repository);
            const string resource = "DecisionViewpoints." + "DecisionViewpoints.xml";
            return Utilities.GetResourceContents(resource);
        }

        public override string EA_OnRetrieveModelTemplate(Repository repository, string location)
        {
            EARepository.UpdateRepository(repository);
            var resource = "DecisionViewpoints." + location;
            return Utilities.GetResourceContents(resource);
        }
    }
}