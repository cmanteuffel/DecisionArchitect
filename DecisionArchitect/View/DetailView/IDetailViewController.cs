using DecisionArchitect.Model.New;
using DecisionArchitect.View.Controller;

namespace DecisionArchitect.View.DetailView
{
    internal interface IDetailViewController : ICustomViewController
    {
        IDecision Decision { get; set; }
    }
}