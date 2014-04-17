using DecisionViewpoints.Model;

namespace DecisionViewpoints.Logic.Rules
{
    public abstract class AbstractRule
    {
        private readonly string _errorMessage;

        protected AbstractRule(string errorMessage)
        {
            _errorMessage = errorMessage;
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
        }

        public bool Validate(IEAWrapper obj, out string message)
        {
            bool validationResult = true;
            message = "";

            var connector = obj as EAConnectorWrapper;
            if (connector != null)
            {
                validationResult = ValidateConnector(connector);
            }

            var element = obj as EAElementWrapper;
            if (element != null)
            {
                validationResult = ValidateElement(element);
            }


            if (!validationResult)
            {
                message = ErrorMessage;
            }
            return validationResult;
        }

        public virtual bool ValidateElement(EAElementWrapper element)
        {
            return true;
        }

        public virtual bool ValidateConnector(EAConnectorWrapper connector)
        {
            return true;
        }

        public abstract RuleType GetRuleType();
    }
}