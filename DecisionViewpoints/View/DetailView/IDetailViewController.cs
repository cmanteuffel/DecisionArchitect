using DecisionViewpoints.View.Controller;
using DecisionViewpoints.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionViewpoints.Logic.Chronological;

namespace DecisionViewpoints.View
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
