using DecisionViewpoints.Logic.Menu;
using DecisionViewpoints.Model;
using DecisionViewpoints.Model.Events;
using EA;

namespace DecisionViewpoints
{
    public partial class MainApplication : EAEventAdapter
    {
        

        public override object EA_GetMenuItems(Repository repository, string location, string menuName)
        {
            EARepository.UpdateRepository(repository);
            return MenuEventHandler.GetMenuItems(location, menuName);
        }

        public override void EA_GetMenuState(Repository repository, string location, string menuName,
                                             string itemName, ref bool isEnabled, ref bool isChecked)
        {
            EARepository.UpdateRepository(repository);
            MenuEventHandler.GetMenuState(location, menuName, itemName, ref isEnabled, ref isChecked);
        }

        public override void EA_MenuClick(Repository repository, string location, string menuName, string itemName)
        {
            EARepository.UpdateRepository(repository);
            MenuEventHandler.MenuClick(location, menuName, itemName);
        }
    }
}