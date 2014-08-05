using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionViewpoints.Model;


namespace DecisionViewpoints.Logic.Events
{
    // The interface which the form/view must implement so that, the event will be
    // fired when a value is changed in the model.
    public interface IDecisionObserver
    {
        void valueChanged(IDecision model, DecisionEventArgs e);
    }
}
