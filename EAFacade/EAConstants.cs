using System.Collections.Generic;

namespace EAFacade
{
    public static class EAConstants
    {
        public const string DecisionMetaType = "Decision";
        public const string TopicMetaType = "Topic";
        public const string ConcernMetaType = "Concern";
        public const string RequirementMetaType = "Requirement";
        public const string DiagramMetaTypeForces = "Decision Viewpoints::Forces";
        public const string DiagramMetaTypeChronological = "Decision Viewpoints::Chronological";
        public const string DiagramMetaTypeRelationship = "Decision Viewpoints::Relationship";
        public const string DiagramMetaTypeStakeholder = "Decision Viewpoints::Stakeholder Involvement";

        public const string EventPropertyTypeElement = "Element";


        public const string TopicStereoType = "Topic";

        public const string StateIdea = "idea";
        public const string StateTentative = "tentative";
        public const string StateDecided = "decided";
        public const string StateApproved = "approved";
        public const string StateChallenged = "challenged";
        public const string StateDiscarded = "discarded";
        public const string StateRejected = "rejected";

        public const string RelationMetaType = "Relationship";
        public const string RelationDependsOn = "depends on";
        public const string RelationCausedBy = "caused by";
        public const string RelationAlternativeFor = "alternative for";
        public const string RelationExcludedBy = "excluded by";
        public const string RelationReplaces = "replaces";
        public const string RelationClassifiedBy = "classified by";
        public const string RelationFollowedBy = "followed by";
        public const string RelationTrace = "trace";

        public const string ActionMetaType = "Action";
        public const string ActivityMetaType = "Activity";
        public const string AbstractionMetaType = "Abstraction";
        

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