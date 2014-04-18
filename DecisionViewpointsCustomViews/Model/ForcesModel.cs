using System;
using System.Collections.Generic;

namespace DecisionViewpointsCustomViews.Model
{
    [Serializable]
    public class ForcesModel
    {
        public ForcesModel()
        {
            Requirements = new List<ForcesRequirement>();
            Decisions = new List<ForcesDecision>();
        }

        public List<ForcesRequirement> Requirements { get; private set; }

        public List<ForcesDecision> Decisions { get; private set; }
    }

    public class ForcesRequirement
    {
        public string Name { get; set; }
    }

    public class ForcesDecision
    {
        public string Name { get; set; }
    }
}