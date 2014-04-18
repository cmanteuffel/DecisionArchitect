using System.Collections.Generic;
using EAWrapper.Model;

namespace DecisionViewpointsCustomViews.Model
{
    public interface ICustomViewModel
    {
        string Name { get; }
        string GUID { get; }
        EADiagram DiagramModel { get; set; }
        
        void SaveRatings();
        List<string> GetDecisions();
        List<string> GetRequirements();
    }
}
