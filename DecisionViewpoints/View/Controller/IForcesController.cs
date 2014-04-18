using DecisionViewpoints.Model;
using EAFacade.Model;

namespace DecisionViewpoints.View.Controller
{
    public interface IForcesController : ICustomViewController
    {
        IForcesModel Model { get; set; }
        IForcesView View { get; set; }
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