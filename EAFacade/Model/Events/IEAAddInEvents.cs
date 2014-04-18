using EA;

namespace EAFacade.Model.Events
{
    internal interface IEAAddInEvents
    {
        string EA_Connect(Repository repository);
        void EA_Disconnect();
        object EA_GetMenuItems(Repository repository, string location, string menuName);
        void EA_MenuClick(Repository repository, string location, string menuName, string itemName);

        void EA_GetMenuState(Repository repository, string location, string menuName,
                             string itemName, ref bool isEnabled, ref bool isChecked);
        void EA_ShowHelp(Repository repository, string location, string menuName, string itemName);
        void EA_OnOutputItemClicked(Repository repository, string tabName, string lineText, long id);
        void EA_OnOutputItemDoubleClicked(Repository repository, string tabName, string lineText, long id);
    }
}