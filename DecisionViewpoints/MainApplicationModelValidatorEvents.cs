using DecisionViewpoints.Logic.Validation;
using EA;
using EAFacade.Model;


namespace DecisionViewpoints
{
    public partial class MainApplication
    {
        private ModelValidator _modelValidator;

        public override void EA_OnInitializeUserRules(Repository repository)
        {
            EAFacade.EA.UpdateRepository(repository);
            _modelValidator = ModelValidator.Initialize(repository);
        }

        public override void EA_OnStartValidation(Repository repository, params object[] args)
        {
            EAFacade.EA.UpdateRepository(repository);
            _modelValidator.OnStart(repository, args);
        }

        public override void EA_OnRunConnectorRule(Repository repository, string ruleId, int connectorId)
        {
            EAFacade.EA.UpdateRepository(repository);
            var connector = EAFacade.EA.Repository.GetConnectorByID(connectorId);
            _modelValidator.ValidateConectorUsingRuleID(repository, ruleId, connector);
        }

        public override void EA_OnRunElementRule(Repository repository, string ruleId, Element element)
        {
            EAFacade.EA.UpdateRepository(repository);
            var wrappedElement = EAFacade.EA.WrapElement(element);
            _modelValidator.ValidateElementUsingRuleID(repository, ruleId, wrappedElement);
        }
    }
}