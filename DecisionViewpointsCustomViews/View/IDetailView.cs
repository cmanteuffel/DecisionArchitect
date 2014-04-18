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

        void ShowAsDialog();
        void SetController(IDetailViewController controller);
        void AddRelatedDecision(string relationship, string name, bool isClient);
        void AddHistoryEntry(string name, string stereotype, string s, string state);
        void AddAlternativeDecision(string relationship, string name, bool isClient);//angor task 158
        void AddTrace(string name, string type);//angor task 157
        void AddRelatedRequirement(string name, string rating, string description);//angor task159
    }
}