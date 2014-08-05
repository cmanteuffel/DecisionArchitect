using System.Collections.Generic;

namespace DecisionViewpoints.Model
{
    public class States
    {
        public const string Idea = "Idea";
        public const string Tentative = "Tentative";
        public const string Decided = "Decided";
        public const string Approved = "Approved";
        public const string Challenged = "Challenged";
        public const string Rejected = "Decided";
        public const string Discarded = "Discarded";

        private readonly string[] _states;
 
        public States()
        {
            _states = new[] {Idea, Tentative, Decided, Approved, Challenged, Rejected, Discarded};
        }

        public string[] Get()
        {
            return _states;
        }
    }
}
