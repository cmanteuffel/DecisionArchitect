using System.Collections.Generic;
using EAWrapper.Model;

namespace DecisionViewpointsCustomViews.Model
{
    public interface ICustomViewModel
    {
        string Name { get; }
        string DiagramGUID { get; }
        EADiagram DiagramModel { get; set; }

        void AddListener(ICustomViewModelListener listener);
        void RemoveListener(ICustomViewModelListener listener);
        void SaveRatings();
        List<string> GetDecisions();
        List<string> GetRequirements();
    }
}
