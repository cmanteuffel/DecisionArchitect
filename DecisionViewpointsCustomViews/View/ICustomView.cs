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
        void SetController(ICustomViewController controller);
        void UpdateTable(ICustomViewModel model);
        void RemoveDecision(string name);
        void RemoveRequirement(string name);
    }
}
