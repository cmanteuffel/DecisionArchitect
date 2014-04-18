using DecisionViewpoints.Logic.Validation;
using EA;
using EAWrapper.Model;

namespace DecisionViewpoints
{
    public partial class MainApplication
    {
        private ModelValidator _modelValidator;

        public override void EA_OnInitializeUserRules(Repository repository)
        {
            EARepository.UpdateRepository(repository);
            _modelValidator = ModelValidator.Initialize(repository);
        }

        public override void EA_OnStartValidation(Repository repository, params object[] args)
        {
            EARepository.UpdateRepository(repository);
            _modelValidator.OnStart(repository, args);
        }

        public override void EA_OnRunConnectorRule(Repository repository, string ruleId, int connectorId)
        {
            EARepository.UpdateRepository(repository);
            EAConnectorWrapper connector = EAConnectorWrapper.Wrap(connectorId);
            _modelValidator.ValidateConectorUsingRuleID(repository, ruleId, connector);
        }

        public override void EA_OnRunElementRule(Repository repository, string ruleId, Element element)
        {
            EARepository.UpdateRepository(repository);
            EAElement wrappedElement = EAElement.Wrap(element);
            _modelValidator.ValidateElementUsingRuleID(repository, ruleId, wrappedElement);
        }
    }
}