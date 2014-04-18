using DecisionViewpointsCustomViews.Model;
using DecisionViewpointsCustomViews.View;
using EAFacade.Model;

namespace DecisionViewpointsCustomViews.Controller
{
    public interface ICustomViewController
    {
        ICustomViewModel Model { get; set; }
        ICustomView View { get; set; }
        void UpdateTable();
        void SaveRatings();
        void Configure();
        void SetDiagramModel(EADiagram diagram);
        void RemoveDecision(EAElement element);
        void RemoveRequirement(EAElement element);
        void RemoveConcern(EAElement element);
    }
}
