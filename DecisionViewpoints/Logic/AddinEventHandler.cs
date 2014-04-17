using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using DecisionViewpoints.Logic.AutoGeneration;
using DecisionViewpoints.Model;
using DecisionViewpoints.Properties;
using EA;

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

        private static readonly Dictionary<string, EAElementWrapper> TraceMenuContext =
            new Dictionary<string, EAElementWrapper>();

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
                            MenuTracingFollowTraces, Separator, MenuBaselineOptions, MenuCreateBaseline
                        };
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
                                        ref bool isChecked, BaselineOptions bo)
        {
            if (IsProjectOpen(repository))
            {
                switch (itemName)
                {
                    case MenuCreateProjectStructure:
                    case MenuGenerateChronological:
                        isEnabled = true;
                        break;
                    case MenuCreateBaseline:
                        isEnabled = bo.GetOption(BaselineOptions.Option.Manually);
                        break;
                    case MenuOnFileClose:
                        isEnabled = !bo.GetOption(BaselineOptions.Option.OnFileClose);
                        break;
                    case MenuOnModification:
                        isEnabled = !bo.GetOption(BaselineOptions.Option.OnModification);
                        break;
                    case MenuManually:
                        isEnabled = !bo.GetOption(BaselineOptions.Option.Manually);
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

        public static void MenuClick(Repository repository, string location, string menuName, string itemName,
                                     BaselineOptions bo)
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
                case MenuOnFileClose:
                    bo.SetOption(BaselineOptions.Option.OnFileClose, true);
                    bo.SetOption(BaselineOptions.Option.OnModification, false);
                    bo.SetOption(BaselineOptions.Option.Manually, false);
                    break;
                case MenuOnModification:
                    bo.SetOption(BaselineOptions.Option.OnFileClose, false);
                    bo.SetOption(BaselineOptions.Option.OnModification, true);
                    bo.SetOption(BaselineOptions.Option.Manually, false);
                    break;
                case MenuManually:
                    bo.SetOption(BaselineOptions.Option.OnFileClose, false);
                    bo.SetOption(BaselineOptions.Option.OnModification, false);
                    bo.SetOption(BaselineOptions.Option.Manually, true);
                    break;
                default:
                    if (menuName.Equals(MenuTracingFollowTraces))
                    {
                        EAElementWrapper element = TraceMenuContext[itemName];
                        Diagram[] diagrams = element.GetDiagrams();
                        if (diagrams.Count() == 1)
                        {
                            Diagram d = diagrams[0];
                            var diagram = new EADiagramWrapper(d);
                            diagram.OpenAndSelectElement(repository, element.Element);
                        }
                        else if (diagrams.Count() >= 2)
                        {
                            var selectForm = new SelectDiagram(diagrams);
                            if (selectForm.ShowDialog() == DialogResult.OK)
                            {
                                Diagram d = selectForm.GetSelectedDiagram();
                                var diagram = new EADiagramWrapper(d);
                                diagram.OpenAndSelectElement(repository, element.Element);
                            }
                        }
                        repository.ShowInProjectView(element.Element);
                    }
                    break;
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
                    EAElementWrapper element = EAElementWrapper.Wrap(repository, eaelement);

                    foreach (EAElementWrapper tracedElement in element.GetTracedElements())
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
            var dv = new EAPackageWrapper(root.Packages.GetByName("Decision Views"));
            var pack = dv.CreatePackage(repository, "Data", "generated");
            var hp = new EAPackageWrapper(pack);
            var cd = new EADiagramWrapper(dv.GetDiagram("Chronological"));
            var baselines = project.ReadPackageBaselines(repository, dv);
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
            var rep = new EARepositoryWrapper(repository);
            var notes = String.Format("Baseline Time: {0}", DateTime.Now);
            var dvp = new EAPackageWrapper(rep.GetPackageFromRootByName("Decision Views"));
            var bv = project.GetBaselineLatestVesrion(repository, dvp);
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
            var rep = new EARepositoryWrapper(repository);
            var decisionViewpoints = rep.CreateView("Decision Views", 0);
            rep.CreateDiagram(decisionViewpoints, "Relationship", RelationshipDiagramMetaType);
            rep.CreateDiagram(decisionViewpoints, "Chronological", ChronologicalDiagramMetaType);
            rep.CreateDiagram(decisionViewpoints, "Stakeholder Involvement", StakeholderInvolvementDiagramMetaType);
        }
    }
}