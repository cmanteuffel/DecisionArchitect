using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
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
        public const string MenuTestBaselines = "Test &Baselines";
        public const string MenuGenerateChronological = "Generate CVP";
        public const string Separator = "-";
        public const string MenuTracingFollowTraces = "-&Follow trace(s) to ...";

        private static double _baselineVersion;

        private static readonly string RelationshipDiagramMetaType =
            Settings.Default["RelationshipDiagramMetaType"].ToString();

        private static readonly string ChronologicalDiagramMetaType =
            Settings.Default["ChronologicalDiagramMetaType"].ToString();

        private static readonly string StakeholderInvolvementDiagramMetaType =
            Settings.Default["StakeholderInvolvementDiagramMetaType"].ToString();


        private static readonly Regex traceMenuRegex = new Regex(@"[1-9][0-9]*:");

        private static readonly Dictionary<string, EAElementWrapper> _traceMenuContext =
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
                            MenuCreateProjectStructure, MenuTestBaselines, MenuGenerateChronological, Separator,
                            MenuTracingFollowTraces
                        };
                case MenuTracingFollowTraces:
                    return CreateTraceSubmenu(repository);
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
                    case MenuTestBaselines:
                    case MenuGenerateChronological:
                        isEnabled = true;
                        break;
                    default:
                        isEnabled = (traceMenuRegex.IsMatch(itemName));
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
                case MenuTestBaselines:
                    CreateBaselines(repository);
                    break;
                case MenuGenerateChronological:
                    GenerateView(repository);
                    break;
                default:
                    if (menuName.Equals(MenuTracingFollowTraces) && traceMenuRegex.IsMatch(itemName))
                    {
                        EAElementWrapper element = _traceMenuContext[itemName];
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
                                diagram.OpenAndSelectElement(repository,element.Element);
                            }
                        }
                        repository.ShowInProjectView(element.Element);
                        
                    }
                    break;
            }
        }


        private static string[] CreateTraceSubmenu(Repository repository)
        {
            _traceMenuContext.Clear();
            if (ObjectType.otElement == repository.GetContextItemType())
            {
                dynamic obj = repository.GetContextObject();
                var eaelement = obj as Element;
                if (eaelement != null)
                {
                    EAElementWrapper element = EAElementWrapper.Wrap(repository, eaelement);

                    int i = 0;
                    foreach (EAElementWrapper tracedElement in element.GetTracedElements())
                    {
                        string menuItem = ++i + ": " + tracedElement.Element.Name;
                        _traceMenuContext[menuItem] = tracedElement;
                    }
                    return _traceMenuContext.Keys.ToArray();
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
            //MessageBox.Show(pack.Element.Stereotype);
            var hp = new EAPackageWrapper(pack);
            var cd = new EADiagramWrapper(dv.GetDiagram("Chronological"));
            var baselines = project.ReadPackageBaselines(repository, dv);
            project.ComparePackageBaselines(repository, dv, baselines);
            var chronologicalViewGenarator = new ChronologicalGenerator(repository, project, dv, hp, cd);
            repository.BatchAppend = true;
            chronologicalViewGenarator.Generate();
            repository.BatchAppend = false;
            //project.Get().LayoutDiagramEx(cd.Get().DiagramGUID, ConstLayoutStyles.lsLayoutDirectionRight, 4, 20, 20, true);
        }

        private static void CreateBaselines(Repository repository)
        {
            var project = new EAProjectWrapper(repository);
            var rep = new EARepositoryWrapper(repository);
            _baselineVersion += 0.1;
            dynamic item;
            var ot = repository.GetContextItem(out item);
            switch (ot)
            {
                case ObjectType.otDiagram:
                    var diagram = item as Diagram;
                    if (diagram != null) MessageBox.Show(diagram.MetaType);
                    break;
            }
            project.CreateBaseline(rep.GetPackageFromRootByName("Relationship").PackageGUID,
                                   _baselineVersion.ToString(CultureInfo.InvariantCulture), "");
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