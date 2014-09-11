/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    Mark Hoekstra (University of Groningen)
    Marc Holterman (University of Groningen)
*/

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EAFacade
{
    public static class EAConstants
    {
        public const string DecisionMetaType = "DADecision";
        public const string TopicMetaType = "DATopic";
        public const string ConcernMetaType = "Concern";
        public const string RequirementMetaType = "Requirement";
        public const string StakeholderMetaType = "Actor";

        public const string DiagramMetaTypeForces = "Decision Architect::Forces";
        public const string DiagramMetaTypeChronological = "Decision Architect::Chronological";
        public const string DiagramMetaTypeRelationship = "Decision Architect::Relationship";
        public const string DiagramMetaTypeStakeholder = "Decision Architect::Stakeholder Involvement";

        public const string EventPropertyTypeElement = "Element";


        public const string TopicStereoType = "Topic";
        public const string ChronologicalStereoType = "generated";

        public const string StateIdea = "idea";
        public const string StateTentative = "tentative";
        public const string StateDecided = "decided";
        public const string StateApproved = "approved";
        public const string StateChallenged = "challenged";
        public const string StateDiscarded = "discarded";
        public const string StateRejected = "rejected";

        public const string ForcesConnectorType = "Dependency";

        public const string RelationMetaType = "Relationship";
        public const string RelationDependsOn = "depends on";
        public const string InverseDependsOn = "is dependent of";
        public const string RelationCausedBy = "caused by";
        public const string InverseCausedBy = "causes";
        public const string RelationAlternativeFor = "alternative for";
        public const string InverseAlternativeFor = "alternative for";
        public const string RelationExcludedBy = "excluded by";
        public const string InverseExcludedBy = "excludes";
        public const string RelationReplaces = "replaces";
        public const string InverseReplaces = "replaced by";
        public const string RelationClassifiedBy = "classified by";
        public const string InverseClassifiedBy = "classifies";
        public const string RelationFollowedBy = "followed by";
        public const string InverseFollowedBy = "follows";
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

        public static readonly HashSet<string> InverseRelationships = new HashSet<string>
            {
                InverseAlternativeFor,
                InverseCausedBy,
                InverseDependsOn,
                InverseExcludedBy,
                InverseReplaces
            };

        public static readonly IDictionary<string, string> ConvertInverse =
            new ReadOnlyDictionary<string, string>(new Dictionary<string, string>
                {
                    {RelationAlternativeFor, InverseAlternativeFor},
                    {RelationCausedBy, InverseCausedBy},
                    {RelationDependsOn, InverseDependsOn},
                    {RelationExcludedBy, InverseExcludedBy},
                    {RelationReplaces, InverseReplaces}
                });

        public static readonly IDictionary<string, string> ConvertToRelationship =
            new ReadOnlyDictionary<string, string>(new Dictionary<string, string>
                {
                    {InverseAlternativeFor, RelationAlternativeFor},
                    {InverseCausedBy, RelationCausedBy},
                    {InverseDependsOn, RelationDependsOn},
                    {InverseExcludedBy, RelationExcludedBy},
                    {InverseReplaces, RelationReplaces}
                });
        


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
