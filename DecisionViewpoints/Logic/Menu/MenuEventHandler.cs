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
            var createAndTraceDecision = new MenuItem(Messages.MenuTraceToNewDecision, CreateAndTraceDecision)
         
            {
                    UpdateDelegate = menuItem =>
                        {
                            if (NativeType.Element == EARepository.Instance.GetContextItemType())
                            {
                                var eaelement = EARepository.Instance.GetContextObject<EAElement>();
                                menuItem.IsEnabled = (eaelement != null && !eaelement.IsDecision());
                                return;
                            }
                            menuItem.IsEnabled = false;
                        }
                };


            var baselinesOptions = new Model.Menu.Menu(Messages.MenuBaselineOptions);
            var baselineManually = new MenuItem(Messages.MenuBaselineManually)
                {
                    ClickDelegate = () =>
                        {
                            Settings.Default.BaselineOptionManually =
                                !Settings.Default.BaselineOptionManually;
                            Settings.Default.Save();
                        },
                    UpdateDelegate = self => { self.IsChecked = Settings.Default.BaselineOptionManually; }
                };

            var baselineOnFileClose = new MenuItem(Messages.MenuBaselineOnClose)
                {
                    ClickDelegate = () =>
                        {
                            Settings.Default.BaselineOptionOnFileClose =
                                !Settings.Default.BaselineOptionOnFileClose;
                            Settings.Default.Save();
                        },
                    UpdateDelegate = self => { self.IsChecked = Settings.Default.BaselineOptionOnFileClose; }
                };

            var baselineOnModification = new MenuItem(Messages.MenuBaselineOnModify)
                {
                    ClickDelegate = () =>
                        {
                            Settings.Default.BaselineOptionOnModification =
                                ! Settings.Default.BaselineOptionOnModification;
                            Settings.Default.Save();
                        },
                    UpdateDelegate =
                        self => { self.IsChecked = Settings.Default.BaselineOptionOnModification; }
                };


            var createBaseline = new MenuItem(Messages.MenuCreateBaseline, ManualDecisionSnapshot)
                {
                    UpdateDelegate = self =>
                        {
                            if (NativeType.Package == EARepository.Instance.GetContextItemType() &&
                                Settings.Default.BaselineOptionManually)
                            {
                                var eapackage = EARepository.Instance.GetContextObject<EAPackage>();
                                self.IsEnabled = (eapackage != null && eapackage.IsDecisionViewPackage());
                                return;
                            }
                            self.IsEnabled = false;
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
                    ClickDelegate = () => GenerateReport("Report.docx",ReportType.Word),
                    
                    UpdateDelegate = self => {}
                    
                };

            var generateExecelAllReport = new MenuItem(Messages.MenuExportExcelForcesAll)
            {
                //ClickDelegate = () => GenerateReport("AllForcesReport.docx", ReportType.Excel),//original
                ClickDelegate = () => GenerateReport("AllForcesReport.xlsx", ReportType.Excel),//angor
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
            createTraces.Add(new MenuItem(Messages.MenuTraceToExistingElement,
                                          (() => MessageBox.Show("To be implemented"))));
            RootMenu.Add(new FollowTraceMenu());
            RootMenu.Add(MenuItem.Separator);
            RootMenu.Add(baselinesOptions);
            baselinesOptions.Add(baselineManually);
            baselinesOptions.Add(baselineOnFileClose);
            baselinesOptions.Add(baselineOnModification);
            RootMenu.Add(createBaseline);
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

        private static void CreateAndTraceDecision()
        {
            EARepository repository = EARepository.Instance;
            if (repository.GetContextItemType() == NativeType.Element)
            {
                var eaelement = EARepository.Instance.GetContextObject<EAElement>();
                if (eaelement != null && !eaelement.IsDecision())
                {
                    var createDecisionView = new CreateDecision(eaelement.Name + " Decision");
                    if (createDecisionView.ShowDialog() == DialogResult.OK)
                    {
                        EAPackage dvPackage = repository.GetPackageFromRootByName("Decision Views");

                        EAElement decision = dvPackage.AddElement(createDecisionView.GetName(), "Action");
                        decision.Stereotype = createDecisionView.GetState();
                        decision.MetaType = DVStereotypes.DecisionMetaType;


                        eaelement.ConnectTo(decision, "Abstraction", "trace");
                        decision.Update();

                        dvPackage.RefreshElements();
                        repository.RefreshModelView(dvPackage.ID);
                        decision.ShowInProjectView();
                    }
                }
                else
                {
                    MessageBox.Show("Here I am"); //angor
                }
            }
        }

        private static void ManualDecisionSnapshot()
        {
            if (NativeType.Package == EARepository.Instance.GetContextItemType() &&
                Settings.Default.BaselineOptionManually)
            {
                var eapackage = EARepository.Instance.GetContextObject<EAPackage>();
                ChronologicalViewpointHandler.CreateDecisionSnapshot(eapackage);
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
                    viewPackage.GetSubpackageByName("History data for " + chronologicalView.Name) ??
                    viewPackage.CreatePackage("History data for " + chronologicalView.Name, "generated");

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
                //angor START
                var filenameExtension = filename.Substring(filename.IndexOf('.'));
                //MessageBox.Show("filename ext: "+filenameExtension); //DEBUG
                var saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
                saveFileDialog1.Title = Messages.SaveReportAs;
                saveFileDialog1.Filter = "Microsoft " + reportType.ToString() + " (*"+ filenameExtension + ")|*" + filenameExtension;
                saveFileDialog1.FilterIndex = 0;
                
                if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                saveFileDialog1.CheckFileExists = true;
                saveFileDialog1.CheckPathExists = true;
                var reportFilename = saveFileDialog1.FileName;// + filenameExtension;
                //MessageBox.Show("report filename: "+reportFilename + "\nOriginal filename: " + filename); //DEBUG
                //angor END

                //report = ReportFactory.Create(reportType,filename);// original
                report = ReportFactory.Create(reportType, reportFilename); // angor
                report.Open();
                foreach (Decision decision in decisions)
                {
                    report.InsertDecisionTable(decision);
                }
                foreach (EADiagram diagram in diagrams.Where(diagram => !diagram.IsForcesView()))
                {
                    report.InsertDiagramImage(diagram);
                }
                foreach (EADiagram diagram in diagrams.Where(diagram => diagram.IsForcesView()))
                {
                    report.InsertForcesTable(new ForcesModel(diagram));
                }
                //angor START
                //MessageBox.Show(reportType.ToString() + " " + Messages.SuccesfulReportCreation); //DEBUG //angor
                var customMessage = new ExportReportsCustomMessageBox(reportType.ToString(), reportFilename);
                customMessage.Show();
                //angor END
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
                //angor START
                var filenameExtension = filename.Substring(filename.IndexOf('.'));
                //MessageBox.Show("filename ext: "+filenameExtension); //DEBUG
                var saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
                saveFileDialog1.Title = "Save report as..";
                saveFileDialog1.Filter = "Microsoft Excel (*" + filenameExtension + ")|*" + filenameExtension;
                saveFileDialog1.FilterIndex = 0;

                if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                saveFileDialog1.CheckFileExists = true;
                saveFileDialog1.CheckPathExists = true;
                var reportFilename = saveFileDialog1.FileName;// + filenameExtension;
                //MessageBox.Show("report filename: "+reportFilename + "\nOriginal filename: " + filename); //DEBUG
                //angor END

                //report = ReportFactory.Create(ReportType.Excel, filename); //original
                report = ReportFactory.Create(ReportType.Excel, reportFilename); //angor
                report.Open();
                if (diagram.IsForcesView())
                {
                    report.InsertForcesTable(new ForcesModel(diagram));
                }
                //angor START
                //MessageBox.Show(ReportType.Excel.ToString() + " " + Messages.SuccesfulForcesReportCreation);   //angor DEBUG
                var customMessage = new ExportReportsCustomMessageBox("Excel", reportFilename);
                customMessage.Show();
                //angor END
            }
            finally
            {
                if (report != null)
                    report.Close();
            }
        }
    }
}