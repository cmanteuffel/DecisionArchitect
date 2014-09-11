using System;
using System.ComponentModel;

namespace DecisionArchitect.Model
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
        BindingList<IHistoryEntry> History { get; }
        BindingList<IForceEvaluation> Forces { get; }
        BindingList<ITraceLink> Traces { get; }
        BindingList<IDecisionRelation> Alternatives { get; }
        BindingList<IDecisionRelation> RelatedDecisions { get; }
        BindingList<IStakeholderAction> Stakeholders { get; }
        bool HasTopic();
    }
}