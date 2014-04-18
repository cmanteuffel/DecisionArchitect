using EAFacade.Model;

namespace DecisionViewpoints.Logic.Validation
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

        public bool Validate(IEAObject obj, out string message)
        {
            bool validationResult = true;
            message = "";

            var connector = obj as IEAConnector;
            if (connector != null)
            {
                validationResult = ValidateConnector(connector);
            }

            var element = obj as IEAElement;
            if (element != null)
            {
                validationResult = ValidateElement(element);
            }

            var volatileElement = obj as IEAVolatileElement;
            if (volatileElement != null)
            {
                validationResult = ValidateElement(volatileElement);
            }


            if (!validationResult)
            {
                message = ErrorMessage;
            }
            return validationResult;
        }

        public virtual bool ValidateElement(IEAVolatileElement element)
        {
            return true;
        }

        public virtual bool ValidateElement(IEAElement element)
        {
            return true;
        }

        public virtual bool ValidateConnector(IEAConnector connector)
        {
            return true;
        }

        public abstract RuleType GetRuleType();
    }
}