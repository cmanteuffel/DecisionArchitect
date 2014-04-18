using DecisionViewpointsCustomViews.Model;
using DecisionViewpointsCustomViews.View;
using EAFacade.Model;

namespace DecisionViewpointsCustomViews.Controller
{
    public interface ICustomViewController
    {
        ICustomViewModel Model { get; set; }
        IForcesView View { get; set; }
        void UpdateTable();
        void SaveRatings();
        void Configure();
        void SetDiagramModel(EADiagram diagram);
        void UpdateDecision(EAElement element);
        void UpdateRequirement(EAElement element);
        void UpdateConcern(EAElement element);
        void RemoveDecision(EAElement element);
        void RemoveRequirement(EAElement element);
        void RemoveConcern(EAElement element);
    }
}
