using System.Runtime.InteropServices;
using DecisionViewpoints.Model;
using DecisionViewpoints.View.Controller;
using EAFacade.Model;

namespace DecisionViewpoints.View
{
    [ComVisible(true)]
    [Guid("C325ED77-CD8C-4CC3-BAB1-974420531239")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IForcesView : IForcesModelObserver, ICustomView
    {
        string[] RequirementGuids { get; }
        string[] ConcernGuids { get; }
        string[] DecisionGuids { get; }

        void SetController(IForcesController controller);
        void UpdateTable(IForcesModel model);
        void UpdateDecision(EAElement element);
        void UpdateRequirement(EAElement element);
        void UpdateConcern(EAElement element);
        void RemoveDecision(EAElement element);
        void RemoveRequirement(EAElement element);
        void RemoveConcern(EAElement element);
        string GetRating(int row, int column);
    }
}