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

using System.Collections.Generic;
using System.Linq;
using DecisionArchitect.Model.Menu;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Logic.Menu
{
    public static class MenuEventHandler
    {
        private static readonly Model.Menu.Menu RootMenu = new Model.Menu.Menu(Messages.MenuAddIn);

        static MenuEventHandler()
        {
            var createTraces = new Model.Menu.Menu(Messages.MenuCreateTraces);
            var createAndTraceDecision = new MenuItem(Messages.MenuTraceToNewDecision,
                                                      CreateTraceMenu.CreateAndTraceDecision)
                {
                    UpdateDelegate = menuItem =>
                        {
                            if (EANativeType.Element == EAMain.Repository.GetContextItemType())
                            {
                                var eaelement = EAMain.Repository.GetContextObject<IEAElement>();
                                menuItem.IsEnabled = (eaelement != null && !EAMain.IsDecision(eaelement) &&
                                                      !EAMain.IsTopic(eaelement));
                                return;
                            }
                            menuItem.IsEnabled = false;
                        }
                };

            var createAndTraceTopic = new MenuItem(Messages.MenuTraceToNewTopic, CreateTraceMenu.CreateAndTraceTopic)
                {
                    UpdateDelegate = menuItem =>
                        {
                            if (EANativeType.Element == EAMain.Repository.GetContextItemType())
                            {
                                var eaelement = EAMain.Repository.GetContextObject<IEAElement>();
                                menuItem.IsEnabled = (eaelement != null && !EAMain.IsDecision(eaelement) &&
                                                      !EAMain.IsTopic(eaelement));
                                return;
                            }
                            menuItem.IsEnabled = false;
                        }
                };

            var generateChronologicalView = new MenuItem(Messages.MenuGenerateChronologicalVP, ChronologyMenu.Generate)
                {
                    UpdateDelegate = self =>
                        {
                            if (EANativeType.Package == EAMain.Repository.GetContextItemType())
                            {
                                var eapackage = EAMain.Repository.GetContextObject<IEAPackage>();
                                self.IsEnabled = (eapackage != null);
                                return;
                            }
                            self.IsEnabled = false;
                        }
                };

            /*var reportMenu = new Model.Menu.Menu(Messages.MenuExport);
            var generateWordReport = new MenuItem(Messages.MenuExportWord)
                {
                    ClickDelegate = () => ReportMenu.GenerateReport(SelectedDecisionViewPackage(),"Report.docx", ReportType.Word),
                    UpdateDelegate = self =>
                        {
                            self.IsEnabled = ContextItemIsDecisionViewPackage();
                        }
            };

            var generateExcelAllReport = new MenuItem(Messages.MenuExportExcelForcesAll)
                {
                    ClickDelegate = () => ReportMenu.GenerateReport(SelectedDecisionViewPackage(),"AllForcesReport.xlsx", ReportType.Excel),
                    UpdateDelegate = self =>
                        {
                            self.IsEnabled = ContextItemIsDecisionViewPackage();
                        }
                };

            var generateExcelReport = new MenuItem(Messages.MenuExportExcelForces)
                {
                    ClickDelegate = () =>
                        {
                            if (EANativeType.Diagram == EAFacade.EAMain.Repository.GetContextItemType())
                            {
                                var eadiagram = EAFacade.EAMain.Repository.GetContextObject<IEADiagram>();
                                ReportMenu.GenerateForcesReport(eadiagram.Name + "_Report.xlsx", eadiagram);
                            }
                        },
                    UpdateDelegate = self =>
                        {
                            if (EANativeType.Diagram == EAFacade.EAMain.Repository.GetContextItemType())
                            {
                                var eadiagram = EAFacade.EAMain.Repository.GetContextObject<IEADiagram>();
                                self.IsEnabled = ((eadiagram != null) && eadiagram.IsForcesView());
                                return;
                            }
                            self.IsEnabled = false;
                        }
                };

            var generateSelectedDecisionsWordReport = new MenuItem(Messages.MenuExportSelectedDecisionsWord)
                {
                    ClickDelegate = () => ReportMenu.GenerateSelectedDecisionsReport("Report.docx", ReportType.Word),
                    UpdateDelegate = self => { self.IsEnabled = ContextItemAreDecisions(); }
                };

            var generatePowerpointReport = new MenuItem(Messages.MenuExportPowerPoint)
                {
                    ClickDelegate = () =>
                                    ReportMenu.GenerateReport(SelectedDecisionViewPackage(),"Report.pptx", ReportType.PowerPoint),
                    UpdateDelegate = self =>
                        {
                            self.IsEnabled = ContextItemIsDecisionViewPackage();
                        }
                };

            var generateSelectedDecisionsPowerpointReport = new MenuItem(Messages.MenuExportSelectedDecisionsPowerPoint)
                {
                    ClickDelegate = () =>
                                    ReportMenu.GenerateSelectedDecisionsReport("Report.pptx", ReportType.PowerPoint),
                    UpdateDelegate = self => { self.IsEnabled = ContextItemAreDecisions();  }
                };
             * */

            RootMenu.Add(createTraces);
            createTraces.Add(createAndTraceDecision);
            createTraces.Add(createAndTraceTopic);

            RootMenu.Add(new FollowTraceMenu());
            RootMenu.Add(MenuItem.Separator);
            RootMenu.Add(generateChronologicalView);
            RootMenu.Add(MenuItem.Separator);
            /* RootMenu.Add(reportMenu);
            reportMenu.Add(generateWordReport);        
            reportMenu.Add(generatePowerpointReport);
            reportMenu.Add(generateExcelAllReport);
            reportMenu.Add(MenuItem.Separator);
            reportMenu.Add(generateSelectedDecisionsWordReport);
            reportMenu.Add(generateSelectedDecisionsPowerpointReport);
            reportMenu.Add(generateExcelReport);*/
        }


        private static bool ContextItemAreDecisions()
        {
            IEnumerable<IEAElement> selectedTopicsAndDecisions =
                (from IEAElement element in EAMain.Repository.GetSelectedItems()
                 where (EAMain.IsDecision(element) || EAMain.IsTopic(element)) && !EAMain.IsHistoryDecision(element)
                 select element);
            return selectedTopicsAndDecisions.Any();
        }

        public static object GetMenuItems(string location, string menuName)
        {
            if (menuName.Equals(""))
                return RootMenu.Name;

            IMenu menuItem = RootMenu.FindMenuItem(menuName);
            if (menuItem != null)
            {
                return menuItem.GetSubItems();
            }
            return "";
        }

        public static void GetMenuState(string location, string menuName, string itemName,
                                        ref bool isEnabled,
                                        ref bool isChecked)
        {
            IMenu menuItem = RootMenu.FindMenuItem(itemName);
            if (menuItem != null)
            {
                isChecked = menuItem.IsChecked;
                isEnabled = menuItem.IsEnabled;
            }
        }

        public static void MenuClick(string location, string menuName, string itemName)
        {
            IMenu menuItem = RootMenu.FindMenuItem(itemName);
            if (menuItem != null)
            {
                menuItem.Click();
            }
        }
    }
}