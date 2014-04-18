using System;
using System.Collections.Generic;
using EAFacade.Model;

namespace DecisionViewpointsCustomViews.Model
{
    public interface IDecision : ICustomViewModel
    {
        int ID { get; }
        string Name { get; set; }
        string State { get; set; }
        string Group { get; set; }
        string Issue { get; }
        string DecisionText { get; }
        string Alternatives { get; }
        string Arguments { get; }
        string RelatedRequirements { get; }

        void Save(string extraData);
        List<EAConnector> GetConnectors();
        void LoadLinkedDocument(string fileName);
        void AddObserver(IDecisionObserver observer);
        void RemoveObserver(IDecisionObserver observer);
        bool HasTopic();
        EAElement GetTopic();
        IEnumerable<EAElement> GetTraces();
        IEnumerable<Rating> GetForces();
        IDictionary<string, DateTime> GetHistory();
    }
}