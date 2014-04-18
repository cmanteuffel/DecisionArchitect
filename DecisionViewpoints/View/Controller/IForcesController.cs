using DecisionViewpoints.Model;
using EAFacade.Model;


namespace DecisionViewpoints.View.Controller
{
    public interface IForcesController : ICustomViewController
    {
        IForcesModel Model { get; set; }
        IForcesView View { get; set; }
        void Configure();
        void SetDiagramModel(IEADiagram diagram);
        void UpdateDecision(IEAElement element);
        void UpdateRequirement(IEAElement element);
        void UpdateConcern(IEAElement element);
        void RemoveDecision(IEAElement element);
        void RemoveRequirement(IEAElement element);
        void RemoveConcern(IEAElement element);
    }
}