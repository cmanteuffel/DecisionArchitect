using DecisionArchitect.Model.New;

namespace DecisionArchitect.Logic.Events
{
    public interface IDecisionObservable // : IObservable<IDecision>
    {
        // The interface which the form/view must implement so that, the event will be
        // fired when a value is changed in the model.
        void valueChanged(IDecision decision, DecisionEventArgs e);
    }
}