using System;
using System.Collections.Generic;
using DecisionArchitect.Logic.Chronological;
using DecisionArchitect.Model;
using DecisionArchitect.View.Controller;

namespace DecisionArchitect.View.DetailView
{
    interface IDetailViewController : ICustomViewController
    {
        string DecisionName { get; set; }
        string DecisionState { get; set; }
        DateTime Modified { get; set; }
        string DecisionAuthor { get; set; }
        string DecisionRationale { get; set; }
        string TopicName { get; set; }
        string TopicDescription { get; set; }

        void SetDecision(IDecision decision);
        void SetTopic(ITopic topic);

        IList<DecisionStateChange> History { get; set; }

    }
}
