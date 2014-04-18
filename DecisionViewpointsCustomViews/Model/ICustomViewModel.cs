using System.Collections.Generic;
using EAFacade.Model;

namespace DecisionViewpointsCustomViews.Model
{
    public interface ICustomViewModel
    {
        string Name { get; }
        string DiagramGUID { get; }
        EADiagram DiagramModel { set; }

        void AddObserver(ICustomViewModelObserver observer);
        void RemoveObserver(ICustomViewModelObserver observer);
        void SaveRatings(Dictionary<string, Dictionary<string, string>> data);
        List<EAElement> GetDecisions();
        List<EAElement> GetRequirements();
        Dictionary<EAElement, List<EAElement>> GetConcerns();
        Dictionary<string, Dictionary<string, string>> GetRatings();
    }
}
