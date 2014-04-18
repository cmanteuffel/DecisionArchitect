using EAFacade.Model;

namespace DecisionViewpointsCustomViews.Controller
{
    public interface ICustomViewController
    {
        void UpdateTable();
        void SaveRatings();
        void Configure();
        void SetDiagramModel(EADiagram diagram);
    }
}
