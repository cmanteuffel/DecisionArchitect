using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionViewpoints.Model.Events;
using EA;

namespace DecisionViewpoints.Logic
{
    interface IAddInEventHandler
    {
        string Connect(Repository repository);
        void Disconnect();
        object GetMenuItems(Repository repository, string location, string menuName);
        void MenuClick(Repository repository, string location, string menuName, string itemName);

        void GetMenuState(Repository repository, string location, string menuName,
                             string itemName, ref bool isEnabled, ref bool isChecked);
        void ShowHelp(Repository repository, string location, string menuName, string itemName);
        void OnOutputItemClicked(Repository repository, string tabName, string lineText, long id);
        void OnOutputItemDoubleClicked(Repository repository, string tabName, string lineText, long id);
    }
}
