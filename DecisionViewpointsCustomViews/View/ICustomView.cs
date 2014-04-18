using DecisionViewpointsCustomViews.Controller;

namespace DecisionViewpointsCustomViews.View
{
    public interface ICustomView
    {
        void SetController(ICustomViewController controller);
    }
}
