using System;
using System.Collections.Generic;

namespace EAFacade.Model
{
    public interface IEAElement : IModelObject, IEquatable<IEAElement>
    {
        string Type { get; }
        string Stereotype { get; set; }
        string MetaType { get; set; }
        IEAElement ParentElement { get; set; }
        List<IEATaggedValue> TaggedValues { get; }
        string StereotypeList { get; set; }
        IEnumerable<IEAElement> GetTracedElements();

        [Obsolete("Should be moved to topic",false)]
        IEnumerable<IEAElement> GetDecisionsForTopic();

        [Obsolete("Should be moved to appropriate domain class",false)]
        IEnumerable<IEAElement> GetConnectedConcerns();

        [Obsolete("Should be moved to appropriate domain class", false)]
        IEnumerable<IEAElement> GetConnectedRequirements();

        IEADiagram[] GetDiagrams();
        IList<IEAConnector> FindConnectors(IEAElement suppliedElement, String type, String stereotype);
        void ConnectTo(IEAElement suppliedElement, String type, String stereotype);
        bool IsDecision();
        bool IsConcern();
        bool IsRequirement();
        bool IsTopic();
        bool IsHistoryDecision();
        bool Update();
        void Refresh();
        List<IEAElement> GetElements();
        List<IEAConnector> GetConnectors();
        string GetLinkedDocument();
        void LoadLinkedDocument(string fileName);
        string GetTaggedValue(string dvDecisionviewpackage);
        void AddTaggedValue(string name, string data);
        void UpdateTaggedValue(string name, string data);
    }
}