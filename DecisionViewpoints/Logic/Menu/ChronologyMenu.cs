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
                EAPackage package = chronologicalView.ParentPackage;
                if (package == null) throw new Exception("package is null");
                while (!(package.IsModelRoot() || package.IsDecisionViewPackage()))
                {
                    package = package.ParentPackage;
                }
                if (package == null || !package.IsDecisionViewPackage())
                {
                    return;
                }

                EAPackage viewPackage = package;
                EAPackage historyPackage =
                    viewPackage.GetSubpackageByName("History data for " + chronologicalView.Name);
                if (historyPackage != null)
                {
                    historyPackage.ParentPackage.DeletePackage(historyPackage);
                }
                historyPackage = viewPackage.CreatePackage("History data for " + chronologicalView.Name, "generated");

                var generator = new ChronologicalViewpointGenerator(viewPackage, historyPackage,
                                                                    chronologicalView);
                generator.GenerateViewpoint();
            }
        }
    }
}
