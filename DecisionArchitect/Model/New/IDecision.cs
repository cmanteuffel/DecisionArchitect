using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DecisionArchitect.Model.New
{
    public interface IDecision : IPersistableModel, INotifyPropertyChanged
    {
        string GUID { get; }
        int ID { get; }
        string Name { get; set; }
        string State { get; set; }
        DateTime Modified { get; set; }
        string Author { get; set; }
        string Rationale { get; set; }
        //topic cannot (yet) be changed programatically. Feature will come in future. 
        ITopic Topic { get; }
        IList<IHistoryEntry> History { get; }
        IList<IForceEvaluation> Forces { get; }
        IList<ITraceLink> Traces { get; }
        IList<IDecisionRelation> Alternatives { get; }
        IList<IDecisionRelation> RelatedDecisions { get; }
        IList<IStakeholderAction> Stakeholders { get; }
        bool HasTopic();
    }
}