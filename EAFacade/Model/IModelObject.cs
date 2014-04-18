using System;

namespace EAFacade.Model
{
    public interface IModelObject : IModelItem
    {
        DateTime Created { get; set; }
        DateTime Modified { get; set; }
        String Version { get; set; }
        IEAPackage ParentPackage { get; set; }

        void ShowInProjectView();

        string GetProjectPath();

    }
}
