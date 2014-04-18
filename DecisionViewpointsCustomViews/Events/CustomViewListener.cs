using DecisionViewpointsCustomViews.View;

namespace DecisionViewpointsCustomViews.Events
{
    public interface ICustomViewListener
    {
        void Save(ICustomView view);
        void Configure(ICustomView view);
        void Update(ICustomView view);
    }
}
