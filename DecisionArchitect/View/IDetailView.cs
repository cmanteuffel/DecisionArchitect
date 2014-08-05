/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    Antonis Gkortzis (University of Groningen)  
    Marc Holterman (University of Groningen)  
*/

using System;
using DecisionArchitect.Model;

namespace DecisionArchitect.View
{
//    public delegate void ViewHandler<IDetailView>(IDetailView sender, DetailViewEventArgs e);

    public interface IDetailView //: //ICustomViewController
    {
        /**
         * Public Accessors 
         */
        //int DecisionId { get; set; }
        string DecisionName { get; set; }
        string DecisionState { get; set; }
        string DecisionRationale { get; set; }
        string TopicName { get; set; }
        string TopicDescription { get; set; }
       // DateTime Created { get; set; }
       // DateTime Modified { get; set; }
        DateTime Decided { get; set; }
        string Author { get; set; }

        // Set appropriate controller  
       // event ViewHandler<IDetailView> changed;
       // void SetController(IDetailViewController controller);

        /**
         * Add topic information
         */ 
        void AddTopic(int id, string name, string description, bool hasTopic);
        void AddTopic(ITopic topic, bool hasTopic);

        /**
         * Public Accessors additional information
         */
        void AddAlternativeDecision(string guid, string alternativeId, string alternativeName, string alternativeState, string alternativeRationale);
        void AddRelatedDecision(string guid, string relation, string relatedName, string relatedState);
        void AddRelatedForce(string guid, string forceName, string forceRating, string forceConcern, string description);
        void AddTrace(string guid, string traceName, string traceType);
        void AddStakeholder(string guid, string stakeholderName, string stereotype, string s, string state);
        void AddHistoryEntry(string historyState, DateTime dateModfied);
    }
}
