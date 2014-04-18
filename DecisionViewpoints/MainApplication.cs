using System.Collections.Generic;
using DecisionViewpoints.Logic;
using DecisionViewpoints.Logic.Chronological;
using DecisionViewpoints.Logic.Detail;
using DecisionViewpoints.Logic.Forces;
using DecisionViewpoints.Logic.StakeholderInvolvement;
using DecisionViewpoints.Logic.Validation;
using EA;
using EAFacade;
using EAFacade.Events;

namespace DecisionViewpoints
{
    public partial class MainApplication : EAEventAdapter
    {
        private readonly IList<IRepositoryListener> _listeners = new List<IRepositoryListener>();

        //init repository listener
        public MainApplication()
        {
            _listeners.Add(new ValidationHandler());
            _listeners.Add(new ChronologicalViewpointHandler());
            _listeners.Add(new ForcesHandler());
            _listeners.Add(new ModifedDateHandler());
            _listeners.Add(new StakeholderInvolvementHandler());
            _listeners.Add(new DetailHandler());
        }

        public override object EA_OnInitializeTechnologies(Repository repository)
        {
            EAFacade.EA.UpdateRepository(repository);
            const string resource = "DecisionViewpoints." + "DecisionViewpoints.xml";
            return Utilities.GetResourceContents(resource);
        }

        public override string EA_OnRetrieveModelTemplate(Repository repository, string location)
        {
            EAFacade.EA.UpdateRepository(repository);
            string resource = "DecisionViewpoints.Templates." + location;
            return Utilities.GetResourceContents(resource);
        }
    }
}