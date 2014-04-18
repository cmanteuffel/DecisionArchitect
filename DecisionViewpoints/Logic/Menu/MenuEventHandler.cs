using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DecisionViewpoints.Logic.Chronological;
using DecisionViewpoints.Logic.Reporting;
using DecisionViewpoints.Model.Menu;
using DecisionViewpoints.Properties;
using DecisionViewpointsCustomViews.Model;
using EAFacade.Model;
using MenuItem = DecisionViewpoints.Model.Menu.MenuItem;

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


            var generateChronologicalView = new MenuItem(Messages.MenuGenerateChronologicalVP, Generate)
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
                    ClickDelegate = () => GenerateReport("Report.docx", ReportType.Word),
                    UpdateDelegate = self => { }
                };

            var generateExecelAllReport = new MenuItem(Messages.MenuExportExcelForcesAll)
                {
                    //ClickDelegate = () => GenerateReport("AllForcesReport.docx", ReportType.Excel),//original
                    ClickDelegate = () => GenerateReport("AllForcesReport.xlsx", ReportType.Excel), //angor
                    UpdateDelegate = self => { }
                };

            var generateExcelReport = new MenuItem(Messages.MenuExportExcelForces)
                {
                    ClickDelegate = () =>
                        {
                            if (NativeType.Diagram == EARepository.Instance.GetContextItemType())
                            {
                                var eadiagram = EARepository.Instance.GetContextObject<EADiagram>();
                                GenerateForcesReport(eadiagram.Name + "_Report.xlsx", eadiagram);
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
/* Original
            var generatePowerpointReport = new MenuItem(Messages.MenuExportPowerPoint)
            {
                ClickDelegate = () => GenerateReport("Report.pptx", ReportType.PowerPoint),
                UpdateDelegate = self => { }
            };
*/
            //angor 17/9/2013
            var generatePowerpointReport = new MenuItem(Messages.MenuExportPowerPoint)
                {
                    ClickDelegate = () =>
                                    GenerateReport("Report.pptx", ReportType.PowerPoint),
                    UpdateDelegate = self => { }
                };

            RootMenu.Add(createTraces);
            createTraces.Add(createAndTraceDecision);
            createTraces.Add(createAndTraceTopic);
            /*
            createTraces.Add(new MenuItem(Messages.MenuTraceToExistingElement,
                                          (() => MessageBox.Show("To be implemented"))));
             */ //angor 
            RootMenu.Add(new FollowTraceMenu());
            RootMenu.Add(MenuItem.Separator);
            RootMenu.Add(MenuItem.Separator);
            RootMenu.Add(generateChronologicalView);
            RootMenu.Add(MenuItem.Separator);
            RootMenu.Add(reportMenu);
            reportMenu.Add(generateWordReport);
            reportMenu.Add(generateExcelReport);
            reportMenu.Add(generateExecelAllReport);
            reportMenu.Add(generatePowerpointReport);
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

        private static void Generate()
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
                historyPackage =  viewPackage.CreatePackage("History data for " + chronologicalView.Name, "generated");
                
                var generator = new ChronologicalViewpointGenerator(viewPackage, historyPackage,
                                                                    chronologicalView);
                generator.GenerateViewpoint();
            }
        }

        private static void GenerateReport(string filename, ReportType reportType)
        {
            //EARepository.Instance.GetSelectedItems();

            EARepository repository = EARepository.Instance;
            List<Decision> decisions =
                (from EAElement element in repository.GetAllElements()
                 where element.IsDecision()
                 where !element.IsHistoryDecision()
                 select new Decision(element)).ToList();
            List<EADiagram> diagrams =
                (from EAPackage package in repository.GetAllDecisionViewPackages()
                 from EADiagram diagram in package.GetDiagrams()
                 select diagram).ToList();
            IReportDocument report = null;
            try
            {
                string filenameExtension = filename.Substring(filename.IndexOf('.'));
                var saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Title = Messages.SaveReportAs;
                saveFileDialog1.Filter = "Microsoft " + reportType.ToString() + " (*" + filenameExtension + ")|*" +
                                         filenameExtension;
                saveFileDialog1.FilterIndex = 0;

                if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                saveFileDialog1.CheckFileExists = true;
                saveFileDialog1.CheckPathExists = true;
                string reportFilename = saveFileDialog1.FileName;
                report = ReportFactory.Create(reportType, reportFilename);
                //if the report cannot be created because is already used by another program a message will appear
                if (report == null)
                {
                    MessageBox.Show("Check if another program is using this file.",
                                    "Fail to create report",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
                report.Open();

                var decisionsWithoutTopic = new List<Decision>();
                //angor START
                List<Topic> topics = (from EAElement element in repository.GetAllElements()
                                      where element.IsTopic()
                                      select new Topic(element)).ToList();

                // Insert Decisions that have a Topic
                foreach (Topic topic in topics)
                {
                    //var topicparent = EARepository.Instance.GetElementByID(topic.ID).ParentPackage;
                    //MessageBox.Show("Topic parent package: " + topicparent.Name);
                    report.InsertTopicTable(topic);
                    foreach (Decision decision in decisions)
                    {
                        EAElement parent = EARepository.Instance.GetElementByID(decision.ID).ParentElement;
                        if (parent != null && parent.IsTopic())
                        {
                            if (parent.ID.Equals(topic.ID))
                                report.InsertDecisionTable(decision);
                        }
                        else if (parent == null || !parent.IsTopic())
                        {
                            decisionsWithoutTopic.Add(decision);
                        }
                    }
                }

                // Insert an appropriate message before the decisions that are not included in a topic
                report.InsertDecisionWithoutTopicMessage();

                // Insert decisions without a Topic
                foreach (Decision decision in decisionsWithoutTopic)
                {
                    EAElement parent = EARepository.Instance.GetElementByID(decision.ID).ParentElement;
                    if (parent == null || !parent.IsTopic())
                        report.InsertDecisionTable(decision);
                }
                //angor END

                foreach (EADiagram diagram in diagrams.Where(diagram => !diagram.IsForcesView()))
                {
                    report.InsertDiagramImage(diagram);
                }
                foreach (EADiagram diagram in diagrams.Where(diagram => diagram.IsForcesView()))
                {
                    report.InsertForcesTable(new ForcesModel(diagram));
                }
                var customMessage = new ExportReportsCustomMessageBox(reportType.ToString(), reportFilename);
                customMessage.Show();
            }
            finally
            {
                if (report != null)
                    report.Close();
            }
        }

        private static void GenerateForcesReport(string filename, EADiagram diagram)
        {
            IReportDocument report = null;
            try
            {
                string filenameExtension = filename.Substring(filename.IndexOf('.'));
                var saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Title = "Save report as..";
                saveFileDialog1.Filter = "Microsoft Excel (*" + filenameExtension + ")|*" + filenameExtension;
                saveFileDialog1.FilterIndex = 0;

                if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                saveFileDialog1.CheckFileExists = true;
                saveFileDialog1.CheckPathExists = true;
                string reportFilename = saveFileDialog1.FileName;
                report = ReportFactory.Create(ReportType.Excel, reportFilename);
                report.Open();
                if (diagram.IsForcesView())
                {
                    report.InsertForcesTable(new ForcesModel(diagram));
                }
                var customMessage = new ExportReportsCustomMessageBox("Excel", reportFilename);
                customMessage.Show();
            }
            finally
            {
                if (report != null)
                    report.Close();
            }
        }
    }
}