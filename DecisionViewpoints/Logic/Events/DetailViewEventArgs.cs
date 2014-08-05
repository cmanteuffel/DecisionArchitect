using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionViewpoints.Logic.Events
{
    // The event arguments class that will be used while firing the events
    // for this program, we have only one value which the user changed.
    public class DetailViewEventArgs : EventArgs
    {
        public DetailViewEventArgs()
        {
        }
    }

}
