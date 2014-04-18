using DecisionViewpoints.Logic.Reporting;
using DecisionViewpoints.Model.Menu;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Menu
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
                            if (NativeType.Element == EARepository.Instance.GetContextItemType())
                            {
                                var eaelement = EARepository.Instance.GetContextObject<EAElement>();
                                menuItem.IsEnabled = (eaelement != null && !eaelement.IsDecision() &&
                                                      !eaelement.IsTopic());
                                return;
                            }
                            menuItem.IsEnabled = false;
                        }
                };

            var createAndTraceTopic = new MenuItem(Messages.MenuTraceToNewTopic, CreateTraceMenu.CreateAndTraceTopic)
                {
                    UpdateDelegate = menuItem =>
                        {
                            if (NativeType.Element == EARepository.Instance.GetContextItemType())
                            {
                                var eaelement = EARepository.Instance.GetContextObject<EAElement>();
                                menuItem.IsEnabled = (eaelement != null && !eaelement.IsDecision() &&
                                                      !eaelement.IsTopic());
                                return;
                            }
                            menuItem.IsEnabled = false;
                        }
                };

            var generateChronologicalView = new MenuItem(Messages.MenuGenerateChronologicalVP, ChronologyMenu.Generate)
                {
                    UpdateDelegate = self =>
                        {
                            if (NativeType.Diagram == EARepository.Instance.GetContextItemType())
                            {
                                var eadiagram = EARepository.Instance.GetContextObject<EADiagram>();
                                self.IsEnabled = (eadiagram != null && eadiagram.IsChronologicalView());
                                return;
                            }
                            self.IsEnabled = false;
                        }
                };

            var reportMenu = new Model.Menu.Menu(Messages.MenuExport);
            var generateWordReport = new MenuItem(Messages.MenuExportWord)
                {
                    ClickDelegate = () => ReportMenu.GenerateReport("Report.docx", ReportType.Word),
                    UpdateDelegate = self => { }
                };

            var generateExcelAllReport = new MenuItem(Messages.MenuExportExcelForcesAll)
                {
                    ClickDelegate = () => ReportMenu.GenerateReport("AllForcesReport.xlsx", ReportType.Excel),
                    UpdateDelegate = self => { }
                };

            var generateExcelReport = new MenuItem(Messages.MenuExportExcelForces)
                {
                    ClickDelegate = () =>
                        {
                            if (NativeType.Diagram == EARepository.Instance.GetContextItemType())
                            {
                                var eadiagram = EARepository.Instance.GetContextObject<EADiagram>();
                                ReportMenu.GenerateForcesReport(eadiagram.Name + "_Report.xlsx", eadiagram);
                            }
                        },
                    UpdateDelegate = self =>
                        {
                            if (NativeType.Diagram == EARepository.Instance.GetContextItemType())
                            {
                                var eadiagram = EARepository.Instance.GetContextObject<EADiagram>();
                                self.IsEnabled = ((eadiagram != null) && eadiagram.IsForcesView());
                                return;
                            }
                            self.IsEnabled = false;
                        }
                };

            var generateSelectedDecisionsWordReport = new MenuItem(Messages.MenuExportSelectedDecisionsWord)
                {
                    ClickDelegate = () => ReportMenu.GenerateSelectedDecisionsReport("Report.docx", ReportType.Word),
                    UpdateDelegate = self => { }
                };

            var generatePowerpointReport = new MenuItem(Messages.MenuExportPowerPoint)
                {
                    ClickDelegate = () =>
                                    ReportMenu.GenerateReport("Report.pptx", ReportType.PowerPoint),
                    UpdateDelegate = self => { }
                };

            var generateSelectedDecisionsPowerpointReport = new MenuItem(Messages.MenuExportSelectedDecisionsPowerPoint)
                {
                    ClickDelegate = () =>
                                    ReportMenu.GenerateSelectedDecisionsReport("Report.pptx", ReportType.PowerPoint),
                    UpdateDelegate = self => { }
                };

            RootMenu.Add(createTraces);
            createTraces.Add(createAndTraceDecision);
            createTraces.Add(createAndTraceTopic);

            RootMenu.Add(new FollowTraceMenu());
            RootMenu.Add(MenuItem.Separator);
            RootMenu.Add(generateChronologicalView);
            RootMenu.Add(MenuItem.Separator);
            RootMenu.Add(reportMenu);
            reportMenu.Add(generateWordReport);        
            reportMenu.Add(generatePowerpointReport);
            reportMenu.Add(generateExcelAllReport);
            reportMenu.Add(MenuItem.Separator);
            reportMenu.Add(generateSelectedDecisionsWordReport);
            reportMenu.Add(generateSelectedDecisionsPowerpointReport);
            reportMenu.Add(generateExcelReport);
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