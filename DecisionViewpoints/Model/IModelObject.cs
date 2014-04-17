using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionViewpoints.Model
{
    public interface IModelObject : IModelItem
    {
        DateTime Created { get; set; }
        DateTime Modified { get; set; }
        String Version { get; set; }
        EAPackage ParentPackage { get; set; }

        void ShowInProjectView();
    }
}
