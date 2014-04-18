using System.Collections.Generic;
using DecisionViewpoints.Logic;
using DecisionViewpoints.Logic.Chronological;
using DecisionViewpoints.Logic.Forces;
using DecisionViewpoints.Logic.Validation;
using DecisionViewpoints.Model;
using DecisionViewpoints.Model.Events;
using DecisionViewpointsCustomViews;
using EA;

namespace DecisionViewpoints
{
    public partial class MainApplication : EAEventAdapter
    {
        private readonly IList<IRepositoryListener> _listener = new List<IRepositoryListener>();

        //init repository listener
        public MainApplication()
        {
            _listener.Add(new ValidationHandler());
            _listener.Add(new ChronologicalViewpointHandler());
            _listener.Add(new ForcesHandler());
        }

        public override object EA_OnInitializeTechnologies(Repository repository)
        {
            EARepository.UpdateRepository(repository);
            string resource = "DecisionViewpoints." + "DecisionViewpoints.xml";
            return Utilities.GetResourceContents(resource);
        }

        public override string EA_OnRetrieveModelTemplate(Repository repository, string location)
        {
            EARepository.UpdateRepository(repository);
            string resource = "DecisionViewpoints." + location;
            return Utilities.GetResourceContents(resource);
        }
    }
}