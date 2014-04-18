using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionViewpoints.Logic.Chronological;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Menu
{
    class ChronologyMenu
    {
        public static void Generate()
        {
            var eadiagram = EAFacade.EA.Repository.GetContextObject<IEADiagram>();
            if (eadiagram != null && eadiagram.IsChronologicalView())
            {
                IEADiagram chronologicalView = eadiagram;
                IEAPackage parentPackage = chronologicalView.ParentPackage;
                IEAPackage decisionViewPackage = parentPackage.FindDecisionViewPackage();
                if (decisionViewPackage == null || !decisionViewPackage.IsDecisionViewPackage())
                {
                    return;
                }

                IEAPackage historyPackage =
                    parentPackage.GetSubpackageByName("History data for " + chronologicalView.Name);
                if (historyPackage != null)
                {
                    historyPackage.ParentPackage.DeletePackage(historyPackage);
                }
                historyPackage = parentPackage.CreatePackage("History data for " + chronologicalView.Name, "generated");

                var generator = new ChronologicalViewpointGenerator(decisionViewPackage, historyPackage,
                                                                    chronologicalView);
                generator.GenerateViewpoint();
            }
        }
    }
}
