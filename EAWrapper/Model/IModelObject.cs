using System;

namespace EAWrapper.Model
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
