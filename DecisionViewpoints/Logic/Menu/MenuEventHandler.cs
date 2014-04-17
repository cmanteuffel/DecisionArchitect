using DecisionViewpoints.Logic.Menu.Baselines;
using DecisionViewpoints.Logic.Menu.General;
using DecisionViewpoints.Logic.Menu.Generate;
using DecisionViewpoints.Logic.Menu.Tracing;

namespace DecisionViewpoints.Logic.Menu
{
    public static class MenuEventHandler
    {
        private static readonly Header Header = new Header();

        static MenuEventHandler()
        {
            // Add general menu items
            Header.Add(new CreateProjectStructure());
            Header.Add(new Separator());
            // Add tracing menu items
            Header.Add(new FollowTraces());
            var createTraces = new CreateTraces();
            createTraces.Add(new TracingNewDecision());
            createTraces.Add(new TracingExistingDecision());
            Header.Add(createTraces);
            Header.Add(new Separator());
            // Add baseline menu items
            var baselinesOptions = new BaselineOptions();
            baselinesOptions.Add(new CreateBaselineManually());
            baselinesOptions.Add(new CreateBaselineOnFileClose());
            baselinesOptions.Add(new CreateBaselineOnModification());
            Header.Add(baselinesOptions);
            Header.Add(new CreateBaseline());
            Header.Add(new Separator());
            // Add generation menu items
            Header.Add(new GenerateChronological());
        }

        public static object GetMenuItems(string location, string menuName)
        {
            if (menuName.Equals(""))
                return Header.Name;
            if (menuName.Equals(Header.Name))
                return Header.GetMenuItemsAsArray();
            var menuItem = Header.GetMenuItem(menuName) as CompositeMenuItem;
            if (menuItem != null)
                return menuItem.Visible() ? menuItem.GetMenuItemsAsArray() : new string[0];
            return "";
        }

        public static void GetMenuState(string location, string menuName, string itemName,
                                        ref bool isEnabled,
                                        ref bool isChecked)
        {
            isEnabled = Header.GetMenuItem(itemName).Enabled();
            isChecked = Header.GetMenuItem(itemName).Checked();
        }

        public static void MenuClick(string location, string menuName, string itemName)
        {
        }
    }
}