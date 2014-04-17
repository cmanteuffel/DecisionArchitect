using System;
using System.Globalization;
using System.Linq;
using System.Text;
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
        public const string MenuTestBaselines = "&Test Baselines";
        public const string MenuGenerateChronological = "Generate CVP";

        private static double _baselineVersion = 0.0;

        private static readonly string DiagramMetaType = Settings.Default["DiagramMetaType"].ToString();

        public static object GetMenuItems(Repository repository, string location, string menuName)
        {
            switch (menuName)
            {
                case "":
                    return MenuHeader;
                case MenuHeader:
                    string[] subMenus = {MenuCreateProjectStructure, MenuTestBaselines, MenuGenerateChronological};
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
                    //TestBaselines(repository);
                    CreateBaselines(repository);
                    break;
                case MenuGenerateChronological:
                    GenerateView(repository);
                    break;
                    /*case MenuCreateDecisionGroup:
                CreateDecisionGroup(repository);
                break;*/
            }
        }

        private static void GenerateView(Repository repository)
        {
            var project = new EAProjectWrapper(repository);
            Package root = repository.Models.GetAt(0);
            var rvp = new EAPackageWrapper(root.Packages.GetByName("Relationship")); // relationship package
            var cvp = new EAPackageWrapper(root.Packages.GetByName("Chronological")); // chronological package
            try
            {
                cvp.DeletePackage(0, false);
            }
            catch (Exception)
            {
                MessageBox.Show("No previous history.");
            }
            try
            {
                cvp.DeleteDiagram(0, false);
            }
            catch (Exception)
            {
                MessageBox.Show("No previous diagram.");
                throw;
            }
            var hp = new EAPackageWrapper(cvp.CreatePackage(repository, "history")); // history package
            var cd = new EADiagramWrapper(cvp.CreateDiagram(repository, "Diagram1", "Custom")); // chronological diagram
            var baselines = project.ReadPackageBaselines(repository, rvp);
            project.ComparePackageBaselines(repository, rvp, baselines);
            var chronologicalViewGenarator = new ChronologicalGenerator(repository, project, rvp, hp, cd);
            chronologicalViewGenarator.Generate();
            //project.Get().LayoutDiagramEx(cd.Get().DiagramGUID, ConstLayoutStyles.lsLayoutDirectionRight, 3, ConstLayoutStyles.lsLayeringOptimalLinkLength, 40, true);
        }

        private static void CreateBaselines(IDualRepository repository)
        {
            var project = new EAProjectWrapper(repository);
            Package root = repository.Models.GetAt(0);
            var rvp = new EAPackageWrapper(root.Packages.GetByName("Relationship")); // relationship package
            _baselineVersion += 0.1;
            project.Get().CreateBaseline(rvp.Get().PackageGUID, _baselineVersion.ToString(CultureInfo.InvariantCulture), "");
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
                    case MenuGenerateChronological:
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
            CreateNewView(repository, "Relationship", 0);
            CreateNewView(repository, "Chronological", 1);
            CreateNewView(repository, "Stakeholder Involvement", 2);
        }

        private static void CreateNewView(IDualRepository repository, string name, int pos)
        {
            Package root = repository.Models.GetAt(0);
            Package vp = root.Packages.AddNew(name, "");
            // Set the icon of the view. Info can be found in ScriptingEA page 20
            vp.Flags = "VICON=0;";
            vp.TreePos = pos;
            vp.Update();
            root.Packages.Refresh();
            // Create new Decision Relationship model diagram
            Diagram diagram = vp.Diagrams.AddNew("Diagram1", DiagramMetaType);
            diagram.Update();
            vp.Diagrams.Refresh();
            repository.RefreshModelView(vp.PackageID);
        }
    }
}