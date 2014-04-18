namespace DecisionViewpointsCustomViews.Model
{
    public interface ICustomViewModelObserver
    {
        
    }

    public interface IForcesModelObserver : ICustomViewModelObserver
    {
        void Update(IForcesModel model);
    }

    public interface IDecisionObserver : ICustomViewModelObserver
    {
        void Update(IDecision model);
    }
}