using System;
using DecisionViewpointsCustomViews.Controller;
using DecisionViewpointsCustomViews.Model;

namespace DecisionViewpointsCustomViews.View
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
        void AddRelatedDecision(string relationship, string name, bool isClient, string decisionuid, string relateduid);//angor task161
        void AddStakeholderEntry(string name, string stereotype, string s, string state, string stakeholderuid);
       //void AddAlternativeDecision(string relationship, string name, bool isClient);//angor task 158
        void AddAlternativeDecision(string relationship, string name, bool isClient, string decisionuid, string alternativeuid);//angor task161
        void AddHistoryEntry(string state, DateTime dateModfied);
        //void AddTrace(string name, string type);//angor task 157
        void AddTrace(string name, string type, string uid);//angor task 161
       // void AddRelatedRequirement(string name, string rating, string description);//angor task159
        void AddRelatedRequirement(string name, string rating, string description, string uid, string concern);//angor task161
        void AddTopic(string name, string description, bool hasTopic);//angor task191
    }
}