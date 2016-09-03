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

using System.Windows.Forms;
using DecisionArchitect.View.Dialogs;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Logic.Menu
{
    internal class ChronologyMenu
    {
        public static void Generate()
        {
            if (EANativeType.Package != EAMain.Repository.GetContextItemType()) return;
            var eapackage = EAMain.Repository.GetContextObject<IEAPackage>();
            if (null == eapackage) return;

            var view = new GenerateChronologyViewDialog();
            if (DialogResult.OK == view.ShowDialog())
            {
                
                IEADiagram chronologicalView = CreateChronologyDiagram(eapackage, view.ViewName);
                IEAPackage historyPackage =
                    eapackage.GetSubpackageByName("History data for " + chronologicalView.Name);
                if (historyPackage != null)
                {
                    historyPackage.ParentPackage.DeletePackage(historyPackage);
                }
                historyPackage = eapackage.CreatePackage("History data for " + chronologicalView.Name,
                                                         EAConstants.ChronologicalStereoType);

                var generator = new ChronologicalViewpointGenerator(view.Decisions, historyPackage, chronologicalView);
                generator.GenerateViewpoint();
            }
        }

        private static IEADiagram CreateChronologyDiagram(IEAPackage package, string viewName)
        {
            return package.CreateDiagram(viewName, "generated", EAConstants.DiagramMetaTypeChronological);
        }
    }
}