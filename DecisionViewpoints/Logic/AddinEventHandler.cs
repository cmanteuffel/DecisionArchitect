using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using DecisionViewpoints.Logic.AutoGeneration;
using DecisionViewpoints.Model;
using EA;
using DecisionViewpoints.Properties;

namespace DecisionViewpoints.Logic
{
    public static class AddinEventHandler
    {
        public const string MenuHeader = "-&Decision Viewpoints";
        public const string MenuCreateProjectStructure = "&Create Project Structure";
        public const string MenuCreateBaseline = "Create &Baseline";
        public const string MenuGenerateChronological = "Generate CVP";
        public const string Separator = "-";
        public const string MenuTracingFollowTraces = "-&Follow trace(s) to ...";
        public const string MenuTracingCreateTraces = "-&Create Trace to ...";

        public const string MenuTracingNewDecision = "&New Decision";
        public const string MenuTracingExistingDecision = "&Existing Element";

        public const string MenuBaselineOptions = "-Baseline Options";
        public const string MenuOnFileClose = "File Close";
        public const string MenuManually = "Manually";
        public const string MenuOnModification = "On Modification";

        private static readonly string RelationshipDiagramMetaType =
            Settings.Default["RelationshipDiagramMetaType"].ToString();

        private static readonly string ChronologicalDiagramMetaType =
            Settings.Default["ChronologicalDiagramMetaType"].ToString();

        private static readonly string StakeholderInvolvementDiagramMetaType =
            Settings.Default["StakeholderInvolvementDiagramMetaType"].ToString();

        private static readonly Dictionary<string, EAElement> TraceMenuContext =
            new Dictionary<string, EAElement>();

        public static object GetMenuItems(Repository repository, string location, string menuName)
        {
            switch (menuName)
            {
                case "":
                    return MenuHeader;
                case MenuHeader:
                    return new[]
                        {
                            MenuCreateProjectStructure, MenuGenerateChronological, Separator,
                            MenuTracingFollowTraces, MenuTracingCreateTraces, Separator, MenuBaselineOptions,
                            MenuCreateBaseline
                        };
                case MenuTracingCreateTraces:
                    if (ObjectType.otElement == repository.GetContextItemType())
                    {
                        dynamic obj = repository.GetContextObject();
                        var eaelement = obj as Element;
                        if (eaelement != null && !DVStereotypes.IsDecision(eaelement))
                        {
                            return new[] {MenuTracingNewDecision, MenuTracingExistingDecision};
                        }
                    }
                    return new string[0];
                case MenuTracingFollowTraces:
                    return CreateTraceSubmenu(repository);
                case MenuBaselineOptions:
                    return new[]
                        {
                            MenuOnFileClose, MenuOnModification, MenuManually
                        };
            }
            return "";
        }

        public static void GetMenuState(Repository repository, string location, string menuName, string itemName,
                                        ref bool isEnabled,
                                        ref bool isChecked)
        {
            if (IsProjectOpen(repository))
            {
                switch (itemName)
                {
                    case MenuCreateProjectStructure:
                    case MenuGenerateChronological:
                    case MenuTracingNewDecision:
                        isEnabled = true;
                        break;
                    case MenuCreateBaseline:
                        isEnabled = (bool) Settings.Default["BaselineOptionManually"];
                        break;
                    case MenuOnFileClose:
                        isChecked = (bool) Settings.Default["BaselineOptionOnFileClose"];
                        break;
                    case MenuOnModification:
                        isChecked = (bool) Settings.Default["BaselineOptionOnModification"];
                        break;
                    case MenuManually:
                        isChecked = (bool) Settings.Default["BaselineOptionManually"];
                        break;
                    default:
                        isEnabled = menuName.Equals(MenuTracingFollowTraces);
                        break;
                }
            }
            else
            {
                // If no open project, disable all menu options
                isEnabled = false;
            }
        }

        public static void MenuClick(Repository repository, string location, string menuName, string itemName)
        {
            switch (itemName)
            {
                case MenuCreateProjectStructure:
                    CreateProjectStructure(repository);
                    break;
                case MenuCreateBaseline:
                    CreateBaselines(repository);
                    break;
                case MenuGenerateChronological:
                    GenerateView(repository);
                    break;
                case MenuTracingNewDecision:
                    CreateAndTraceDecision(repository);
                    break;
                case MenuOnFileClose:
                    Settings.Default["BaselineOptionOnFileClose"] =
                        !(bool) Settings.Default["BaselineOptionOnFileClose"];
                    Settings.Default.Save();
                    break;
                case MenuOnModification:
                    Settings.Default["BaselineOptionOnModification"] =
                        !(bool) Settings.Default["BaselineOptionOnModification"];
                    Settings.Default.Save();
                    break;
                case MenuManually:
                    Settings.Default["BaselineOptionManually"] =
                        !(bool) Settings.Default["BaselineOptionManually"];
                    Settings.Default.Save();
                    break;
                default:
                    if (menuName.Equals(MenuTracingFollowTraces))
                    {
                        EAElement element = TraceMenuContext[itemName];
                        Diagram[] diagrams = element.GetDiagrams();
                        if (diagrams.Count() == 1)
                        {
                            Diagram d = diagrams[0];
                            var diagram = EADiagram.Wrap(d);
                            diagram.OpenAndSelectElement(repository, element.Element);
                        }
                        else if (diagrams.Count() >= 2)
                        {
                            var selectForm = new SelectDiagram(diagrams);
                            if (selectForm.ShowDialog() == DialogResult.OK)
                            {
                                Diagram d = selectForm.GetSelectedDiagram();
                                var diagram = EADiagram.Wrap(d);
                                diagram.OpenAndSelectElement(repository, element.Element);
                            }
                        }
                        repository.ShowInProjectView(element.Element);
                    }
                    break;
            }
        }

        private static void CreateAndTraceDecision(Repository repository)
        {
            if (ObjectType.otElement == repository.GetContextItemType())
            {
                dynamic obj = repository.GetContextObject();
                var eaelement = obj as Element;
                if (eaelement != null && !DVStereotypes.IsDecision(eaelement))
                {
                    var createDecisionView = new CreateDecision(eaelement.Name + " Decision");
                    if (createDecisionView.ShowDialog() == DialogResult.OK)
                    {
                        Package root = repository.Models.GetAt(0);
                        Package package = root.Packages.GetByName("Decision Views");
                        Element decision = package.Elements.AddNew(createDecisionView.GetName(), "Action");
                        decision.Stereotype = createDecisionView.GetState();
                        Connector trace = eaelement.Connectors.AddNew("", "Abstraction");
                        trace.Stereotype = "trace";
                        trace.SupplierID = decision.ElementID;
                        trace.Update();
                        eaelement.Connectors.Refresh();
                        decision.Connectors.Refresh();
                        decision.Update();
                        package.Elements.Refresh();
                        repository.RefreshModelView(package.PackageID);
                    }
                }
            }
        }


        private static string[] CreateTraceSubmenu(Repository repository)
        {
            TraceMenuContext.Clear();
            if (ObjectType.otElement == repository.GetContextItemType())
            {
                dynamic obj = repository.GetContextObject();
                var eaelement = obj as Element;
                if (eaelement != null)
                {
                    EAElement element = EAElement.Wrap(repository, eaelement);

                    foreach (EAElement tracedElement in element.GetTracedElements())
                    {
                        string menuItem = tracedElement.GetProjectPath() + "/" + tracedElement.Element.Name;

                        if (! "".Equals(tracedElement.Stereotype))
                        {
                            menuItem += " «" + tracedElement.Stereotype + "»";
                        }

                        int duplicate = 1;
                        string uniqueMenuItem = menuItem;
                        while (TraceMenuContext.ContainsKey(uniqueMenuItem))
                        {
                            // identify number of duplication
                            uniqueMenuItem = menuItem + " (" + ++duplicate + ")";
                        }
                        TraceMenuContext[uniqueMenuItem] = tracedElement;
                    }
                    List<string> menuItems = TraceMenuContext.Keys.ToList();
                    menuItems.Sort();
                    return menuItems.ToArray();
                }
            }
            return new string[0];
        }


        private static void GenerateView(Repository repository)
        {
            var project = new EAProjectWrapper(repository);
            Package root = repository.Models.GetAt(0);
            var dv = new EAPackage(root.Packages.GetByName("Decision Views"));
            Package pack = dv.CreatePackage(repository, "Data", "generated");
            var hp = new EAPackage(pack);
            var cd = EADiagram.Wrap(dv.GetDiagram("Chronological"));
            XmlNodeList baselines = project.ReadPackageBaselines(repository, dv);
            project.ComparePackageBaselines(repository, dv, baselines);
            var chronologicalViewGenarator = new ChronologicalGenerator(repository, project, dv, hp, cd);
            // BatchAppend makes it more efficient to add many elements together
            repository.BatchAppend = true;
            chronologicalViewGenarator.Generate();
            repository.BatchAppend = false;
            //project.Get().LayoutDiagramEx(cd.Get().DiagramGUID, ConstLayoutStyles.lsLayoutDirectionRight, 4, 20, 20, true);
        }

        private static void CreateBaselines(Repository repository)
        {
            var project = new EAProjectWrapper(repository);
            var rep = new EARepository(repository);
            string notes = String.Format("Baseline Time: {0}", DateTime.Now);
            var dvp = new EAPackage(rep.GetPackageFromRootByName("Decision Views"));
            string bv = project.GetBaselineLatestVesrion(repository, dvp);
            project.CreateBaseline(dvp.Get().PackageGUID, bv, notes);
        }


        /// <summary>
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="location"></param>
        /// <param name="menuName"></param>
        /// <param name="itemName"></param>
        /// <param name="isEnabled"></param>
        /// <param name="isChecked"></param>
        /// Sets the state of the menu depending if there is
        /// an active project or not
        /// </summary>
        /// <param name="repository">The EA repository.</param>
        /// <returns>True if there is an active project, false otherwise.</returns>
        private static bool IsProjectOpen(IDualRepository repository)
        {
            try
            {
                return null != repository.Models;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Creates the project structure with the five views and one initial diagram for each view.
        /// </summary>
        /// <param name="repository">The EA repository.</param>
        private static void CreateProjectStructure(Repository repository)
        {
            var rep = new EARepository(repository);
            Package decisionViewpoints = rep.CreateView("Decision Views", 0);
            rep.CreateDiagram(decisionViewpoints, "Relationship", RelationshipDiagramMetaType);
            rep.CreateDiagram(decisionViewpoints, "Chronological", ChronologicalDiagramMetaType);
            rep.CreateDiagram(decisionViewpoints, "Stakeholder Involvement", StakeholderInvolvementDiagramMetaType);
        }
    }
}