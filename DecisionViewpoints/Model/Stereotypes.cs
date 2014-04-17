using System.Collections.Generic;

namespace DecisionViewpoints.Model
{
    internal class Stereotypes
    {
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

        public static readonly HashSet<string> Relationships = new HashSet<string>
            {
                RelationAlternativeFor,
                RelationCausedBy,
                RelationDependsOn,
                RelationExcludedBy,
                RelationReplaces
            };
    }
}