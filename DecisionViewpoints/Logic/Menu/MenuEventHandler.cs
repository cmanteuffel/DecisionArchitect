using System.Windows.Forms;
using DecisionViewpoints.Model;
using DecisionViewpoints.Properties;

namespace DecisionViewpoints.Logic.Menu
{
    public static class MenuEventHandler
    {
        private static readonly Menu RootMenu = new Menu(Messages.MenuAddIn);

        static MenuEventHandler()
        {
            var createTraces = new Menu(Messages.MenuCreateTraces);
            createTraces.UpdateDelegate = menuItem =>
                {
                    if (NativeType.Element == EARepository.Instance.GetContextItemType())
                    {
                        var eaelement = EARepository.Instance.GetContextObject<EAElement>();
                        menuItem.IsVisible = (eaelement != null && !eaelement.IsDecision());
                        return;
                    }
                    menuItem.IsVisible = false;
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
                            Settings.Default.BaselineOptionOnModification=
                                ! Settings.Default.BaselineOptionOnModification;
                            Settings.Default.Save();
                        },
                    UpdateDelegate =
                        self => { self.IsChecked = Settings.Default.BaselineOptionOnModification; }
                };

            var createBaseline = new MenuItem(Messages.MenuCreateBaseline, CreateBaseline)
                {
                    UpdateDelegate = self => { self.IsEnabled = Settings.Default.BaselineOptionManually; }
                };


            RootMenu.Add(new MenuItem(Messages.MenuCreateProjectStructure, CreateProjectStructure));
            RootMenu.Add(MenuItem.Separator);
            RootMenu.Add(createTraces);
            createTraces.Add(new MenuItem(Messages.MenuTraceToNewDecision, CreateAndTraceDecision));
            createTraces.Add(new MenuItem(Messages.MenuTraceToExistingElement, (delegate { MessageBox.Show("To be implemented"); })));
            RootMenu.Add(new FollowTraceMenu());
            RootMenu.Add(MenuItem.Separator);
            RootMenu.Add(baselinesOptions);
            baselinesOptions.Add(baselineManually);
            baselinesOptions.Add(baselineOnFileClose);
            baselinesOptions.Add(baselineOnModification);
            RootMenu.Add(createBaseline);
            RootMenu.Add(MenuItem.Separator);
            RootMenu.Add(new MenuItem(Messages.MenuGenerateChronologicalVP, Generate));
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


        private static void CreateProjectStructure()
        {
            var rep = EARepository.Instance;
            EAPackage decisionViewpoints = rep.CreateView("Decision Views", 0);
            rep.CreateDiagram(decisionViewpoints, "Relationship", Settings.Default.RelationshipDiagramMetaType);
            rep.CreateDiagram(decisionViewpoints, "Chronological", Settings.Default.ChronologicalDiagramMetaType);
            rep.CreateDiagram(decisionViewpoints, "Stakeholder Involvement", Settings.Default.StakeholderInvolvementDiagramMetaType);
        }


        private static void CreateAndTraceDecision()
        {
            var repository = EARepository.Instance;
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

        private static void CreateBaseline()
        {

        }

        private static void Generate()
        {
            
        }
    }
}