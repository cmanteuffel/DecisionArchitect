using DecisionArchitect.Model;

namespace DecisionArchitect.Logic.Events
{
    // The interface which the form/view must implement so that, the event will be
    // fired when a value is changed in the model.
    public interface IDecisionObserver
    {
        void valueChanged(IDecision model, DecisionEventArgs e);
    }
}