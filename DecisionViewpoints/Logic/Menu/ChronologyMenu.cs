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
            var eadiagram = EARepository.Instance.GetContextObject<EADiagram>();
            if (eadiagram != null && eadiagram.IsChronologicalView())
            {
                EADiagram chronologicalView = eadiagram;
                EAPackage parentPackage = chronologicalView.ParentPackage;
                EAPackage decisionViewPackage = parentPackage.FindDecisionViewPackage();
                if (decisionViewPackage == null || !decisionViewPackage.IsDecisionViewPackage())
                {
                    return;
                }

                EAPackage historyPackage =
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
