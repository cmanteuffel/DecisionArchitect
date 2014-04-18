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
        void SaveRatings();
        List<string> GetDecisions();
        List<string> GetRequirements();
    }
}
