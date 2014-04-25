/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
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
        string DecisionRelatedRequirements { get; set; }
        //string DecisionGroup { get; set; }//angor task191

        //string DecisionIssuePlainText { get; }//angor

        void ShowAsDialog();
        void SetController(IDetailViewController controller);
        //void AddRelatedDecision(string relationship, string name, bool isClient);//original
        void AddRelatedDecision(string relationship, string name, bool isClient, string decisionuid, string relateduid);
        //angor task161
        void AddStakeholderEntry(string name, string stereotype, string s, string state, string stakeholderuid);
        //void AddAlternativeDecision(string relationship, string name, bool isClient);//angor task 158
        void AddAlternativeDecision(string relationship, string name, bool isClient, string decisionuid,
                                    string alternativeuid);

        //angor task161
        void AddHistoryEntry(string state, DateTime dateModfied);
        //void AddTrace(string name, string type);//angor task 157
        void AddTrace(string name, string type, string uid); //angor task 161
        // void AddRelatedRequirement(string name, string rating, string description);//angor task159
        void AddRelatedRequirement(string name, string rating, string description, string uid, string concern);
        //angor task161
        void AddTopic(string name, string description, bool hasTopic); //angor task191
    }
}
