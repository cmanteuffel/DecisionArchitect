using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DecisionViewpoints.Properties;
using EA;

namespace DecisionViewpoints.Logic
{
    public static class AddinEventHandler
    {
        public const string MenuHeader = "-&Decision Viewpoints";
        public const string MenuCreateProjectStructure = "&Create Project Structure";
        public const string MenuTestBaselines = "&Test Baselines";

        private static readonly string DiagramMetaType = Settings.Default["DiagramMetaType"].ToString();


        public static object GetMenuItems(Repository repository, string location, string menuName)
        {
            switch (menuName)
            {
                case "":
                    return MenuHeader;
                case MenuHeader:
                    string[] subMenus = {MenuCreateProjectStructure, MenuTestBaselines};
                    return subMenus;
            }
            return "";
        }

        public static void MenuClick(Repository repository, string location, string menuName, string itemName)
        {
            switch (itemName)
            {
                case MenuCreateProjectStructure:
                    CreateProjectStructure(repository);
                    break;
                case MenuTestBaselines:
                    TestBaselines(repository);
                    break;
                    /*case MenuCreateDecisionGroup:
                CreateDecisionGroup(repository);
                break;*/
            }
        }

        private static void TestBaselines(Repository repository)
        {
            Project project = repository.GetProjectInterface();
            foreach (Package m in repository.Models)
            {
                string xmlGuid = project.GUIDtoXML(m.PackageGUID);
                string xmlBaselines = project.GetBaselines(xmlGuid, "");
                var xml = new XmlDocument();
                xml.LoadXml(xmlBaselines);

                XmlNodeList baselines = xml.SelectNodes("//@guid");
                foreach (XmlNode baseline in baselines)
                {
                    string xmlCompare = project.DoBaselineCompare(xmlGuid, baseline.Value, "");


                    var compare = new XmlDocument();
                    compare.LoadXml(xmlCompare);
                    MessageBox.Show(xmlCompare);

                    foreach (XmlNode compareItem in compare.SelectNodes("//CompareItem[@status='Changed']"))
                    {
                        var builder = new StringBuilder(compareItem.Attributes["name"].Value);
                        builder.Append(Environment.NewLine);
                        builder.Append(compareItem.Attributes["guid"].Value);
                        builder.Append(Environment.NewLine);
                        builder.Append(compareItem.ChildNodes.Count);
                        builder.Append(Environment.NewLine);

                        foreach (XmlNode property in compareItem.FirstChild.ChildNodes)
                        {
                            if (property.Attributes["status"].Value == "Changed")
                            {
                                foreach (XmlAttribute attribute in property.Attributes)
                                {
                                    builder.Append(attribute.Name);
                                    builder.Append(" ");
                                    builder.Append(attribute.Value);
                                    builder.Append(Environment.NewLine);
                                }
                                builder.Append(Environment.NewLine);
                            }
                        }

                        MessageBox.Show(builder.ToString());
                    }
                }
            }
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