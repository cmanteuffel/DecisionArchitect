using DecisionViewpoints.Properties;
using EA;

namespace DecisionViewpoints.Logic
{
    /// <summary>
    ///     This class is responsible for handling all the EA events delegated
    ///     from MainApplication which is the entry point.
    /// </summary>
    public static class AddinEventHandler
    {
        public const string MenuHeader = "-&Decision Viewpoints";
        public const string MenuCreateProjectStructure = "&Create Project Structure";

        private static readonly string DiagramMetaType = Settings.Default["DiagramMetaType"].ToString();

        /// <summary>
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="location"></param>
        /// <param name="menuName"></param>
        /// <returns></returns>
        public static object GetMenuItems(Repository repository, string location, string menuName)
        {
            switch (menuName)
            {
                case "":
                    return MenuHeader;
                case MenuHeader:
                    string[] subMenus = {MenuCreateProjectStructure};
                    return subMenus;
            }
            return "";
        }

        /// <summary>
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="location"></param>
        /// <param name="menuName"></param>
        /// <param name="itemName"></param>
        /// <param name="isEnabled"></param>
        /// <param name="isChecked"></param>
        public static void GetMenuState(Repository repository, string location, string menuName,
                                        string itemName, ref bool isEnabled, ref bool isChecked)
        {
            if (IsProjectOpen(repository))
            {
                switch (itemName)
                {
                    case MenuCreateProjectStructure:
                        isEnabled = true;
                        break;
                        /*case MenuCreateDecisionGroup:
                        isEnabled = true;
                        break;*/
                    default:
                        isEnabled = false;
                        break;
                }
            }
            else
            {
                // If no open project, disable all menu options
                isEnabled = false;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="location"></param>
        /// <param name="menuName"></param>
        /// <param name="itemName"></param>
        public static void MenuClick(Repository repository, string location, string menuName, string itemName)
        {
            switch (itemName)
            {
                case MenuCreateProjectStructure:
                    CreateProjectStructure(repository);
                    break;
                    /*case MenuCreateDecisionGroup:
                    CreateDecisionGroup(repository);
                    break;*/
            }
        }

        /// <summary>
        ///     Sets the state of the menu depending if there is
        ///     an active project or not
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
        private static void CreateProjectStructure(IDualRepository repository)
        {
            // Create new Decision Relationship View
            Package root = repository.Models.GetAt(0);
            Package view = root.Packages.AddNew("Decision Relationship View", "");
            // Set the icon of the view. Info can be found in ScriptingEA page 20
            view.Flags = "VICON=0;";
            view.Update();
            root.Packages.Refresh();
            // Create new Decision Relationship model diagram
            Diagram diagram = view.Diagrams.AddNew("Diagram1", DiagramMetaType);
            diagram.Update();
            view.Diagrams.Refresh();
            repository.RefreshModelView(view.PackageID);
            // TODO: Still to implement the creation of the other four views and the related diagrams.
        }
    }
}