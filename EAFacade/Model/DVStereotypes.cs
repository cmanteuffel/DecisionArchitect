using System.Collections.Generic;

namespace EAFacade.Model
{
    public static class DVStereotypes
    {
        public const string DecisionMetaType = "Decision";
        public const string DiagramMetaType = "Decision Viewpoints::Forces";

        public const string StateIdea = "idea";
        public const string StateTentative = "tentative";
        public const string StateDecided = "decided";
        public const string StateApproved = "approved";
        public const string StateChallenged = "challenged";
        public const string StateDiscarded = "discarded";
        public const string StateRejected = "rejected";

        public const string RelationDependsOn = "depends on";
        public const string RelationCausedBy = "caused by";
        public const string RelationAlternativeFor = "alternative for";
        public const string RelationExcludedBy = "excluded by";
        public const string RelationReplaces = "replaces";
        public const string RelationClassifiedBy = "classified by";

        public static readonly HashSet<string> Relationships = new HashSet<string>
            {
                RelationAlternativeFor,
                RelationCausedBy,
                RelationDependsOn,
                RelationExcludedBy,
                RelationReplaces
            };

        public static readonly HashSet<string> States = new HashSet<string>
            {
                StateApproved,
                StateChallenged,
                StateDecided,
                StateDiscarded,
                StateIdea,
                StateRejected,
                StateTentative
            };
    }
}