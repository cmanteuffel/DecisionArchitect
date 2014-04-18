using System.Collections.Generic;
using System.Runtime.InteropServices;
using DecisionViewpointsCustomViews.Controller;
using DecisionViewpointsCustomViews.Model;

namespace DecisionViewpointsCustomViews.View
{
    [ComVisible(true)]
    [Guid("C325ED77-CD8C-4CC3-BAB1-974420531239")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface ICustomView : ICustomViewModelObserver
    {
        List<string> RequirementGuids { get; }
        List<string> ConcernGuids { get; }
        List<string> DecisionGuids { get; }

        void SetController(ICustomViewController controller);
        void UpdateTable(ICustomViewModel model);
        string GetRating(int row, int column);
        void RemoveDecision(string guid);
        void RemoveRequirement(string guid);
        void RemoveConcern(string guid);
    }
}
