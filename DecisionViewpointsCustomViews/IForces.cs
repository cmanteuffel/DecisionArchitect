using System.Runtime.InteropServices;

namespace DecisionViewpointsCustomViews
{
    [ComVisible(true)]
    [Guid("C325ED77-CD8C-4CC3-BAB1-974420531239")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IForces
    {
        [ComVisible(true)]
        string GetText();
    }
}
