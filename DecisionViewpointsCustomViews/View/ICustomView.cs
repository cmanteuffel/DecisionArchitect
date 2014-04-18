using System.Runtime.InteropServices;
using DecisionViewpointsCustomViews.Controller;
using DecisionViewpointsCustomViews.Events;
using DecisionViewpointsCustomViews.Model;

namespace DecisionViewpointsCustomViews.View
{
    [ComVisible(true)]
    [Guid("C325ED77-CD8C-4CC3-BAB1-974420531239")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface ICustomView
    {
        void SetController(ForcesController controller);
        void UpdateTable(ForcesModel model);
        void AddListener(ICustomViewListener listener);
        string DiagramGUID { get; set; }
    }
}
