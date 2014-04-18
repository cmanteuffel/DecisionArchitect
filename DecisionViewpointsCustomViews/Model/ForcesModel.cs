using System;
using System.Collections.Generic;
using System.Data;

namespace DecisionViewpointsCustomViews.Model
{
    public class ForcesModel : DataTable
    {
        public ForcesModel()
        {
            Requirements = new List<ForcesRequirement>();
        }

        public List<ForcesRequirement> Requirements { get; private set; }
    }

    public struct ForcesRequirement
    {
        public string Name { get; set; }
    }
}