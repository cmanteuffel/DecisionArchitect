using System.Runtime.InteropServices;
using DecisionViewpointsCustomViews.Model;
using EAFacade.Model;

namespace DecisionViewpointsCustomViews.View
{
    [ComVisible(true)]
    [Guid("C325ED77-CD8C-4CC3-BAB1-974420531239")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IForcesView : ICustomViewModelObserver, ICustomView
    {
        string[] RequirementGuids { get; }
        string[] ConcernGuids { get; }
        string[] DecisionGuids { get; }
        
        void UpdateTable(ICustomViewModel model);
        void UpdateDecision(EAElement element);
        void UpdateRequirement(EAElement element);
        void UpdateConcern(EAElement element);
        void RemoveDecision(EAElement element);
        void RemoveRequirement(EAElement element);
        void RemoveConcern(EAElement element);
        string GetRating(int row, int column);
    }
}