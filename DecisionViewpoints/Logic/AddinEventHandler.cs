using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using DecisionViewpoints.Logic.AutoGeneration;
using DecisionViewpoints.Model;
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
        public const string MenuManually = "CreateBaselineManually";
        public const string MenuOnModification = "On Modification";

        private static readonly string RelationshipDiagramMetaType =
            Settings.Default["RelationshipDiagramMetaType"].ToString();

        private static readonly string ChronologicalDiagramMetaType =
            Settings.Default["ChronologicalDiagramMetaType"].ToString();

        private static readonly string StakeholderInvolvementDiagramMetaType =
            Settings.Default["StakeholderInvolvementDiagramMetaType"].ToString();

        private static readonly Dictionary<string, EAElement> TraceMenuContext =
            new Dictionary<string, EAElement>();

        public static object GetMenuItems(string location, string menuName)
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
                    if (NativeType.Element == EARepository.Instance.GetContextItemType())
                    {
                        var eaelement = EARepository.Instance.GetContextObject<EAElement>();
                     
                        if (eaelement != null && !eaelement.IsDecision())
                        {
                            return new[] {MenuTracingNewDecision, MenuTracingExistingDecision};
                        }
                    }
                    return new string[0];
                case MenuTracingFollowTraces:
                    return CreateTraceSubmenu();
                case MenuBaselineOptions:
                    return new[]
                        {
                            MenuOnFileClose, MenuOnModification, MenuManually
                        };
            }
            return "";
        }

        public static void GetMenuState(string location, string menuName, string itemName,
                                        ref bool isEnabled,
                                        ref bool isChecked)
        {
            if (!EARepository.Instance.IsProjectOpen())
             {
                // If no open project, disable all menu options
                isEnabled = false;
                 return;
             }

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

        public static void MenuClick(string location, string menuName, string itemName)
        {
            switch (itemName)
            {
                case MenuCreateProjectStructure:
                   // CreateProjectStructure();
                    break;
                case MenuCreateBaseline:
                    CreateBaselines();
                    break;
                case MenuGenerateChronological:
                    GenerateView();
                    break;
                case MenuTracingNewDecision:
                  //  CreateAndTraceDecision();
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
                        EADiagram[] diagrams = element.GetDiagrams();
                        if (diagrams.Count() == 1)
                        {
                            var diagram = diagrams[0];
                            diagram.OpenAndSelectElement(element);
                        }
                        else if (diagrams.Count() >= 2)
                        {
                            var selectForm = new SelectDiagram(diagrams);
                            if (selectForm.ShowDialog() == DialogResult.OK)
                            {
                                EADiagram diagram = selectForm.GetSelectedDiagram();
                                diagram.OpenAndSelectElement(element);
                            }
                        }
                        element.ShowInProjectView();
                    }
                    break;
            }
        }




        private static string[] CreateTraceSubmenu()
        {
            TraceMenuContext.Clear();
            var repository = EARepository.Instance;
            if (repository.GetContextItemType() == NativeType.Element)
            {
                var element = EARepository.Instance.GetContextObject<EAElement>();
                if (element != null)
                {
                    foreach (EAElement tracedElement in element.GetTracedElements())
                    {
                 
                        string menuItem = tracedElement.GetProjectPath() + "/" + tracedElement.Name;
                 
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


        private static void GenerateView()
        {
            var project = EARepository.Instance.GetProject();
            var dv = EARepository.Instance.GetPackageFromRootByName("Decision Views");
            var hp = dv.CreatePackage("Data", "generated");
            var cd = dv.GetDiagram("Chronological");
          /*  XmlNodeList baselines = project.ReadPackageBaselines(repository, dv);
            project.ComparePackageBaselines(repository, dv, baselines);
            var chronologicalViewGenarator = new ChronologicalGenerator(repository, project, dv, hp, cd);
            // BatchAppend makes it more efficient to add many elements together
            repository.BatchAppend = true;
            chronologicalViewGenarator.Generate();
            repository.BatchAppend = false;
            //project.Get().LayoutDiagramEx(cd.Get().DiagramGUID, ConstLayoutStyles.lsLayoutDirectionRight, 4, 20, 20, true);
           * */
        }

        private static void CreateBaselines()
        {
            /*
            var project = EARepository.Instance.GetProject();
            var rep = EARepository.Instance;
            string notes = String.Format("Baseline Time: {0}", DateTime.Now);
            var dvp = rep.GetPackageFromRootByName("Decision Views");
            string bv = project.GetBaselineLatestVesrion(repository, dvp);
            project.CreateBaseline(dvp.GUID, bv, notes);*/
        }

    }
}