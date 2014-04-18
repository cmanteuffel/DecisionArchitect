﻿using System;
using System.Linq;
using System.Windows.Forms;
using DecisionViewpoints.Logic.Chronological;
using DecisionViewpoints.Logic.Reporting;
using DecisionViewpointsCustomViews.Model;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using EAFacade.Model;
using Settings = DecisionViewpoints.Properties.Settings;

namespace DecisionViewpoints.Logic.Menu
{
    public static class MenuEventHandler
    {
        private static readonly Menu RootMenu = new Menu(Messages.MenuAddIn);

        static MenuEventHandler()
        {
            var createTraces = new Menu(Messages.MenuCreateTraces);
            var createAndTraceDecision = new MenuItem(Messages.MenuTraceToNewDecision, CreateAndTraceDecision);
            createAndTraceDecision.UpdateDelegate = menuItem =>
                {
                    if (NativeType.Element == EARepository.Instance.GetContextItemType())
                    {
                        var eaelement = EARepository.Instance.GetContextObject<EAElement>();
                        menuItem.IsEnabled = (eaelement != null && !eaelement.IsDecision());
                        return;
                    }
                    menuItem.IsEnabled = false;
                };


            var baselinesOptions = new Menu(Messages.MenuBaselineOptions);
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

            var generateReport = new MenuItem("Generate Report", GenerateReport);

            RootMenu.Add(createTraces);
            createTraces.Add(createAndTraceDecision);
            createTraces.Add(new MenuItem(Messages.MenuTraceToExistingElement,
                                          (delegate { MessageBox.Show("To be implemented"); })));
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
            RootMenu.Add(generateReport);
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
                EARepository repository = EARepository.Instance;
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
                EAPackage historyPackage = viewPackage.GetSubpackageByName("History data for " + chronologicalView.Name);
                if (historyPackage == null)
                {
                    historyPackage = viewPackage.CreatePackage("History data for " + chronologicalView.Name, "generated");
                }

                var generator = new ChronologicalViewpointGenerator(viewPackage, historyPackage,
                                                                    chronologicalView);
                generator.GenerateViewpoint();
            }
        }

        private static void GenerateReport()
        {
            var repository = EARepository.Instance;
            var decisions =
                (from EAElement element in repository.GetAllElements()
                 where element.IsDecision()
                 where !element.IsHistoryDecision()
                 select new Decision(element)).ToList();
            var diagrams =
                (from EAPackage package in repository.GetAllDecisionViewPackages()
                 from EADiagram diagram in package.GetDiagrams()
                 where !diagram.IsForcesView()
                 select diagram).ToList();
            var report = new Report("Report.docx");
            foreach (var decision in decisions)
            {
                report.AddDecisionTable(decision);
            }
            foreach (var diagram in diagrams)
            {
                report.AddDiagramImage(diagram);
            }
            report.Close();
        }
    }
}