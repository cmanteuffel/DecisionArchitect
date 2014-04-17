using System.Windows.Forms;
using DecisionViewpoints.Model;
using DecisionViewpoints.Properties;

namespace DecisionViewpoints.Logic.Menu
{
    public static class MenuEventHandler
    {
        private static readonly Menu Header = new Menu("-&Decision Viewpoints");

        private static readonly string RelationshipDiagramMetaType =
            Settings.Default["RelationshipDiagramMetaType"].ToString();

        private static readonly string ChronologicalDiagramMetaType =
            Settings.Default["ChronologicalDiagramMetaType"].ToString();

        private static readonly string StakeholderInvolvementDiagramMetaType =
            Settings.Default["StakeholderInvolvementDiagramMetaType"].ToString();

        static MenuEventHandler()
        {
            // Add general menu items

            // Add tracing menu items
            //Header.Add(new FollowTraces());

            var createTraces = new Menu("-&Create Traces");
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


            var baselinesOptions = new Menu("-&Baseline Options");
            var baselineManually = new MenuItem("Manually")
                {
                    ClickDelegate = () =>
                        {
                            Settings.Default["BaselineOptionManually"] =
                                !(bool) Settings.Default["BaselineOptionManually"];
                            Settings.Default.Save();
                        },
                    UpdateDelegate = self => { self.IsChecked = (bool) Settings.Default["BaselineOptionManually"]; }
                };
            var baselineOnFileClose = new MenuItem("On File Close")
                {
                    ClickDelegate = () =>
                        {
                            Settings.Default["BaselineOptionOnFileClose"] =
                                !(bool) Settings.Default["BaselineOptionOnFileClose"];
                            Settings.Default.Save();
                        },
                    UpdateDelegate = self => { self.IsChecked = (bool) Settings.Default["BaselineOptionOnFileClose"]; }
                };
            var baselineOnModification = new MenuItem("On Modification")
                {
                    ClickDelegate = () =>
                        {
                            Settings.Default["BaselineOptionOnModification"] =
                                !(bool) Settings.Default["BaselineOptionOnModification"];
                            Settings.Default.Save();
                        },
                    UpdateDelegate =
                        self => { self.IsChecked = (bool) Settings.Default["BaselineOptionOnModification"]; }
                };

            var createBaseline = new MenuItem("Create Baseline", CreateBaseline)
                {
                    UpdateDelegate = self => { self.IsEnabled = (bool) Settings.Default["BaselineOptionManually"]; }
                };


            Header.Add(new MenuItem("&Create Project Structure", CreateProjectStructure));
            Header.Add(MenuItem.Separator);
            Header.Add(createTraces);
            createTraces.Add(new MenuItem("&New Decision", CreateAndTraceDecision));
            Header.Add(new FollowTraceMenu("-&Follow Trace"));
            Header.Add(MenuItem.Separator);
            Header.Add(baselinesOptions);
            baselinesOptions.Add(baselineManually);
            baselinesOptions.Add(baselineOnFileClose);
            baselinesOptions.Add(baselineOnModification);
            Header.Add(createBaseline);
            Header.Add(MenuItem.Separator);
            Header.Add(new MenuItem("Generate CVP", Generate));

            /*
            createTraces.Add();
            createTraces.Add(new TracingExistingDecision());
            Header.Add(createTraces);
            Header.Add(MenuItem.Separator);
            // Add baseline menu items
          
            Header.Add(new CreateBaseline());
            Header.Add(MenuItem.Separator);
            // Add generation menu items
            Header.Add(new GenerateChronological());
            */
        }

        public static object GetMenuItems(string location, string menuName)
        {
            if (menuName.Equals(""))
                return Header.Name;

            IMenu menuItem = Header.FindMenuItem(menuName);
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
            IMenu menuItem = Header.FindMenuItem(itemName);
            if (menuItem != null)
            {
                isChecked = menuItem.IsChecked;
                isEnabled = menuItem.IsEnabled;
            }
        }

        public static void MenuClick(string location, string menuName, string itemName)
        {
            IMenu menuItem = Header.FindMenuItem(itemName);
            if (menuItem != null)
            {
                menuItem.Click();
            }
        }


        private static void CreateProjectStructure()
        {
            var rep = EARepository.Instance;
            EAPackage decisionViewpoints = rep.CreateView("Decision Views", 0);
            rep.CreateDiagram(decisionViewpoints, "Relationship", RelationshipDiagramMetaType);
            rep.CreateDiagram(decisionViewpoints, "Chronological", ChronologicalDiagramMetaType);
            rep.CreateDiagram(decisionViewpoints, "Stakeholder Involvement", StakeholderInvolvementDiagramMetaType);
        }


        private static void CreateAndTraceDecision()
        {
            MessageBox.Show("Create and trace");
            /*
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
                    }
                }
            }*/
        }

        private static void CreateBaseline()
        {

        }

        private static void Generate()
        {
            
        }
    }
}