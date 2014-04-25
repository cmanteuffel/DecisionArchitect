/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
*/

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
