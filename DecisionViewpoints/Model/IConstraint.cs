using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionViewpoints.Model
{
    interface IConstraint
    {
        bool Validate();
    }

}
