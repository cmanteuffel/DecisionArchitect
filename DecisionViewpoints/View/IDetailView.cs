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
*/

using System;
using DecisionViewpoints.Model;
using DecisionViewpoints.View.Controller;

namespace DecisionViewpoints.View
{
    public interface IDetailView : IDecisionObserver, ICustomView
    {
        string DecisionName { get; set; }
        string DecisionState { get; set; }
        string DecisionIssue { get; set; }
        string DecisionText { get; set; }
        string DecisionAlternatives { get; set; }
        string DecisionArguments { get; set; }
        string DecisionRelatedForces { get; set; }
        //string DecisionGroup { get; set; }

        //string DecisionIssuePlainText { get; }

        void ShowAsDialog();
        void SetController(IDetailViewController controller);
        //void AddRelatedDecision(string relationship, string name, bool isClient);//original
        void AddRelatedDecision(string relationship, string name, bool isClient, string decisionuid, string relateduid);
        void AddStakeholderEntry(string name, string stereotype, string s, string state, string stakeholderuid);
        //void AddAlternativeDecision(string relationship, string name, bool isClient);
        void AddAlternativeDecision(string relationship, string name, bool isClient, string decisionuid,
                                    string alternativeuid);

        void AddHistoryEntry(string state, DateTime dateModfied);
        //void AddTrace(string name, string type);
        void AddTrace(string name, string type, string uid);
        // void AddRelatedRequirement(string name, string rating, string description);
        void AddRelatedForce(string name, string rating, string description, string uid, string concern);
        void AddTopic(string name, string description, bool hasTopic);
    }
}
