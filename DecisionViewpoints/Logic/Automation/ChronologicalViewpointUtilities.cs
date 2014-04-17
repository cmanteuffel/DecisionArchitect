using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionViewpoints.Model;
using DecisionViewpoints.Model.Baselines;
using DecisionViewpoints.Properties;

namespace DecisionViewpoints.Logic.Automation
{
    class ChronologicalViewpointUtilities
    {
        public static void CreateDecisionSnapshot(EAPackage eapackage)
        {
            if (eapackage == null || eapackage.IsDecisionViewPackge())
            {
                throw new BaselineException("Package needs to be a decision viewpoint packge");
            }


            string notes = String.Format(Settings.Default.BaselineIdentifier);
            eapackage.CreateBaseline(notes);
        }
    }
}
