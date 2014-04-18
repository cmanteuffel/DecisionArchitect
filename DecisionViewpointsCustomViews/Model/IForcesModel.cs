using System.Collections.Generic;
using EAFacade.Model;

namespace DecisionViewpointsCustomViews.Model
{
    public interface IForcesModel : ICustomViewModel
    {
        string Name { get; }
        string DiagramName { get; }
        string DiagramGUID { get; }
        EADiagram DiagramModel { set; }

        void SaveRatings(List<Rating> data);
        EAElement[] GetDecisions();
        EAElement[] GetRequirements();
        Dictionary<EAElement, List<EAElement>> GetConcerns();
        List<Rating> GetRatings();
        Dictionary<EAElement, List<EAElement>> GetConcernsPerRequirement();

        void AddObserver(IForcesModelObserver observer);
        void RemoveObserver(IForcesModelObserver observer);
    }
}