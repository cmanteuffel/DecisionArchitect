using System;
using System.Windows.Forms;
using EA;

namespace DecisionViewpoints
{
    /// <summary>
    /// This class is responsible for handling all the EA events delegated
    /// from MainApplication which is the entry point.
    /// </summary>
    public static class AddinEventHandler
    {
        // define menu constants
        private const string MenuHeader = "-&DecisionVS";
        private const string MenuCreateProjectStructure = "Create Decision &Views";
        // private const string MenuCreateDecisionGroup = "Create Decision &Group";
        private const string Con = "connected";

        /// <summary>
        /// Called Before EA starts to check if Add-In Exists. Nothing is done here.
        /// This operation needs to exists for the addin to work.
        /// </summary>
        /// <returns>Returns a constant string 'connected'</returns>
        public static string Connect()
        {
            return Con;
        }

        /// <summary>
        /// 
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
        /// 
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
        /// 
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
                    CreateDecisionViews(repository);
                    break;
                /*case MenuCreateDecisionGroup:
                    CreateDecisionGroup(repository);
                    break;*/
            }
        }

        /// <summary>
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
        /// Creates the project structure with the five views and one initial diagram foreach view.
        /// </summary>
        /// <param name="repository">The EA repository.</param>
        private static void CreateDecisionViews(IDualRepository repository)
        {
            // Create new Decision Relationship View
            Package root = repository.Models.GetAt(0);
            Package view = root.Packages.AddNew("Decision Relationship View", "");
            view.Flags = "VICON=0;";
            view.Update();
            root.Packages.Refresh();
            // Create new Decision Relationship diagram
            Diagram diagram = view.Diagrams.AddNew("Decision Relationship View", "Custom");
            diagram.Update();
            view.Diagrams.Refresh();
            repository.RefreshModelView(view.PackageID);
            // TODO: Still to implement the creation of the other four views and the related diagrams.
        }

        /*private static void CreateDecisionGroup(IDualRepository repository)
        {
            // Create a new Decision Group
            Package root = repository.Models.GetAt(0);
            Package view = root.Packages.GetByName("Decision Relationship View");
            Package group = view.Packages.AddNew("Web Application", "");
            group.Update();
            group.Packages.Refresh();
            // Create a new diagram along with the new Group
            Diagram diagram = group.Diagrams.AddNew(group.Name, "Custom");
            diagram.Update();
            group.Packages.Refresh();
            repository.RefreshModelView(group.PackageID);
        }*/

        /// <summary>
        /// EA calls this operation when it exists. It is used to
        /// do some cleanup work.
        /// </summary>
        public static void Disconnect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
