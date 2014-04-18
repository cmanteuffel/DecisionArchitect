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

            var generateExcelAllReport = new MenuItem(Messages.MenuExportExcelForcesAll)
                {
                    ClickDelegate = () => GenerateReport("AllForcesReport.xlsx", ReportType.Excel),
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

            var generateSelectedDecisionsWordReport = new MenuItem(Messages.MenuExportSelectedDecisionsWord)
                {
                    ClickDelegate = () => GenerateSelectedDecisionsReport("Report.docx", ReportType.Word),
                    UpdateDelegate = self => { }
                };

            var generatePowerpointReport = new MenuItem(Messages.MenuExportPowerPoint)
            {
                    ClickDelegate = () =>
                                    GenerateReport("Report.pptx", ReportType.PowerPoint),
                    UpdateDelegate = self => { }
                };

            var generateSelectedDecisionsPowerpointReport = new MenuItem(Messages.MenuExportSelectedDecisionsPowerPoint)
            {
                ClickDelegate = () =>
                                GenerateSelectedDecisionsReport("Report.pptx", ReportType.PowerPoint),
                UpdateDelegate = self => { }
            };

            RootMenu.Add(createTraces);
            createTraces.Add(createAndTraceDecision);
            createTraces.Add(createAndTraceTopic);

            RootMenu.Add(new FollowTraceMenu());
            RootMenu.Add(MenuItem.Separator);
            RootMenu.Add(MenuItem.Separator);
            RootMenu.Add(generateChronologicalView);
            RootMenu.Add(MenuItem.Separator);
            RootMenu.Add(reportMenu);
            reportMenu.Add(generateWordReport);
            reportMenu.Add(generateSelectedDecisionsWordReport);
            reportMenu.Add(MenuItem.Separator);
            reportMenu.Add(generatePowerpointReport);
            reportMenu.Add(generateSelectedDecisionsPowerpointReport);
            reportMenu.Add(MenuItem.Separator);
            reportMenu.Add(generateExcelReport);
            reportMenu.Add(generateExcelAllReport);
            
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
                var filenameExtension = filename.Substring(filename.IndexOf('.'));
                var saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
                saveFileDialog1.Title = Messages.SaveReportAs;
                saveFileDialog1.Filter = "Microsoft " + reportType.ToString() + " (*" + filenameExtension + ")|*" + filenameExtension;
                saveFileDialog1.FilterIndex = 0;

                if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                saveFileDialog1.CheckFileExists = true;
                saveFileDialog1.CheckPathExists = true;
                var reportFilename = saveFileDialog1.FileName;
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


                //Insert Decision Relationship Viewpoint
                foreach (EADiagram diagram in diagrams.Where(diagram => diagram.IsRelationshipView()))
                {
                    report.InsertDiagramImage(diagram);
                }

                //Retrieve Topics
                List<Topic> topics = (from EAElement element in repository.GetAllElements()
                                      where element.IsTopic()
                                      select new Topic(element)).ToList();

                report.InsertDecisionDetailViewMessage();

                // Insert Decisions that have a Topic
                foreach (Topic topic in topics)
                {
                    report.InsertTopicTable(topic);
                    //Insert Decisions with parent element the current Topic
                    foreach (Decision decision in decisions)
                    {
                        var parent = EARepository.Instance.GetElementByID(decision.ID).ParentElement;
                        if (parent != null && parent.IsTopic())
                        {
                            if (parent.ID.Equals(topic.ID))
                                report.InsertDecisionTable(decision);
                        }
                    }
                }

                // Insert an appropriate message before the decisions that are not included in a topic
                report.InsertDecisionWithoutTopicMessage();

                // Insert decisions without a Topic
                foreach (Decision decision in decisions)
                {
                    var parent = EARepository.Instance.GetElementByID(decision.ID).ParentElement;
                    if (parent == null || !parent.IsTopic())
                    {
                        parent = EARepository.Instance.GetElementByID(decision.ID).ParentElement;
                        report.InsertDecisionTable(decision);
                }
                }

                foreach (EADiagram diagram in diagrams.Where(diagram => !diagram.IsForcesView() && !diagram.IsRelationshipView()))
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

        private static void GenerateSelectedDecisionsReport(string filename, ReportType reportType)
        {
            //EARepository.Instance.GetSelectedItems();

            EARepository repository = EARepository.Instance;

            var selectedDecisionsRepository = EARepository.Instance.GetSelectedItems();

            /*
            List<Decision> decisions =
                (from EAElement element in repository.GetAllElements()
                 where element.IsDecision()
                 where !element.IsHistoryDecision()
                 select new Decision(element)).ToList();
            */
            List<Decision> selectedDecisions =
                (from EAElement element in selectedDecisionsRepository
                 where element.IsDecision()
                 where !element.IsHistoryDecision()
                 select new Decision(element)).ToList();

            
            //ensure that all decisions from a selected topic are include in the list of decisions
            HashSet<EADiagram> setSelectedDiagrams = new HashSet<EADiagram>();


            foreach (EAElement d in selectedDecisionsRepository.ToList())
            {

                //TODO: replace isDecisionGroup with isTopic, as groups are gone
                if (d.IsTopic())
                {
                    //TODO: this does not consider yet elements which are groups themselves - this needs to be treated separately

                    //TODO: also add the diagrams for the topic, as there can be topics with no underlying alternative
                    List<EAElement> e = d.GetElements().ToList();
                    foreach (var i in e)
                    {
                        if (i.IsDecision())
                        {
                            selectedDecisions.Add(new Decision(i));

                            setSelectedDiagrams.UnionWith(i.GetDiagrams());

                        }
                    }
                }
            }


            


            
            
            List<EADiagram> diagrams =
                (from EAPackage package in repository.GetAllDecisionViewPackages()
                 from EADiagram diagram in package.GetDiagrams()
                 select diagram).ToList();

            List<EADiagram> tryDiagrams = 
                (from EADiagram diagram in diagrams
                 from Decision dec in selectedDecisions
                 where diagram.Contains(dec.GetElement())
                 select diagram).Distinct().ToList();


            //discard diagrams which don't include decisions?
            IReportDocument report = null;

            //get the diagrams which contain selectedDecisions, and discard diagrams which don't
            List<EADiagram> selectedDiagrams = new List<EADiagram>();
            foreach (var eaDiagram in diagrams)
            {
                foreach (var selDec in selectedDecisions)
                {
                    if (eaDiagram.Contains(selDec.GetElement()))
                    {
                        selectedDiagrams.Add(eaDiagram);
                        break;
                    }

                }
            }

            //this is the actual set of diagrams to be used in the reports
            var finalSetOfDiagrams = selectedDiagrams;
            

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

                //Insert Decision Relationship Viewpoint
                foreach (EADiagram diagram in finalSetOfDiagrams.Where(diagram => diagram.IsRelationshipView()))
                {
                    report.InsertDiagramImage(diagram);
                }

                //Retrieve Topics
                List<Topic> topics = (from EAElement element in selectedDecisionsRepository
                                      where element.IsTopic()
                                      select new Topic(element)).ToList();

                report.InsertDecisionDetailViewMessage();

                // Insert Decisions that have a Topic
                foreach (Topic topic in topics)
                {
                    report.InsertTopicTable(topic);
                    //Insert Decisions with parent element the current Topic
                    foreach (Decision decision in selectedDecisions)
                    {
                        var parent = EARepository.Instance.GetElementByID(decision.ID).ParentElement;
                        if (parent != null && parent.IsTopic())
                        {
                            if (parent.ID.Equals(topic.ID))
                                report.InsertDecisionTable(decision);
                        }
                    }
                }

                // Insert an appropriate message before the decisions that are not included in a topic
                report.InsertDecisionWithoutTopicMessage();

                // Insert decisions without a Topic
                foreach (Decision decision in selectedDecisions)
                {
                    var parent = EARepository.Instance.GetElementByID(decision.ID).ParentElement;
                    if (parent == null || !parent.IsTopic())
                    {
                        parent = EARepository.Instance.GetElementByID(decision.ID).ParentElement;
                        report.InsertDecisionTable(decision);
                    }
                }

                foreach (EADiagram diagram in finalSetOfDiagrams.Where(diagram => !diagram.IsForcesView() && !diagram.IsRelationshipView()))
                {
                    report.InsertDiagramImage(diagram);
                }
                foreach (EADiagram diagram in finalSetOfDiagrams.Where(diagram => diagram.IsForcesView()))
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
    }
}