using System.Collections.Generic;
using EAFacade.Model;

namespace DecisionViewpoints.Model
{
    public interface IForcesModel : ICustomViewModel
    {
        string Name { get; }
        string DiagramName { get; }
        string DiagramGUID { get; }
        IEADiagram DiagramModel { set; }

        void SaveRatings(List<Rating> data);
        IEAElement[] GetDecisions();
        IEAElement[] GetRequirements();
        Dictionary<IEAElement, List<IEAElement>> GetConcerns();
        List<Rating> GetRatings();
        Dictionary<IEAElement, List<IEAElement>> GetConcernsPerRequirement();

        void AddObserver(IForcesModelObserver observer);
        void RemoveObserver(IForcesModelObserver observer);
    }
}