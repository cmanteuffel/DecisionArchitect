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
*/

namespace EAFacade
{
    public static class EATaggedValueKeys
    {
        public const string DecisionViewPackage = "DV.DecisionViewPackage";
        public const string DecisionStateModifiedDate = "DV.StateModifiedDate";
        public const string DecisionState = "DV.DecisionState";
        public const string DecisionHistoryState = "DV.DecisionHistoryState";
        public const string IsHistoryDecision = "DV.IsHistory";
        public const string IsForceElement = "DV.IsForce";
        public const string IsDecisionElement = "DV.IsDecision";
        public const string IsConcernElement = "DV.IsConcern";
        public const string IsForceConnector = "DC.IsForceConnector";
        public const string DecisionStateChange = "DV.StateChange";
        public const string OriginalDecisionGuid = "DV.OriginalDecisionGuid";

        public const string DecisionSerialVersionID = "DV.SerialVersionID";
        public const string ForceEvaluation = "DV.Forces";
    }
}
