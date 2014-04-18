using DecisionViewpointsCustomViews.Model;
using DecisionViewpointsCustomViews.View;
using EAFacade.Model;

namespace DecisionViewpointsCustomViews.Controller
{
    public interface ICustomViewController
    {
        void SetModel(ICustomViewModel model);
        void SetView(ICustomView view);
        void UpdateTable();
        void SaveRatings();
        void Configure();
        void SetDiagramModel(EADiagram diagram);
        void RemoveDecision(EAElement element);
        void RemoveRequirement(EAElement element);
    }
}
