using DecisionViewpoints.View.Controller;
using EAFacade.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecisionViewpoints.Logic.Detail
{
    class SynchronizationManager
    {
        private static SynchronizationManager _instance;

        private Dictionary<string, ICustomViewController> _tabs;

        private ICustomViewController _activeTab;
        private string _activeTabGuid;
        private string _activeTabName;

        private SynchronizationManager() 
        {
            _tabs = new Dictionary<string, ICustomViewController>();
        }

        public static SynchronizationManager Instance
        {
            get { return _instance ?? (_instance = new SynchronizationManager()); }
        }

        public void Subscribe(string GUID, ICustomViewController vc, string tabName)
        {
            //MessageBox.Show("Subscribed " + EAFacade.EA.Repository.GetElementByGUID(GUID).Name);
            _tabs.Add(GUID, vc);
            SetActiveTab(GUID, vc, tabName);
        }

        public void UnSubscribe(string GUID)
        {
            if (_tabs.ContainsKey(GUID))
            {
               // MessageBox.Show("UnSubscribe " + EAFacade.EA.Repository.GetElementByGUID(GUID).Name);
                
                var removed = _tabs[GUID];
                _tabs.Remove(GUID);
                if (removed == _activeTab)
                {
                    _activeTab = null;
                }
            }
        }

        public void SetActiveTab(string tabname)
        {
            // This is the old activeTab
            if (_activeTab != null)
            {
                _activeTab.Save();
            }

            //if (_activeTabName != GetNameForGUID(_activeTabGuid) && EAFacade.EA.Repository.IsTabOpen(_activeTabName) > 0)
            //{
            //    DialogResult dialogResult = MessageBox.Show(
            //        Messages.DialogOpenNameChange,
            //        Messages.DialogOpenNameChangeTitle,
            //        MessageBoxButtons.YesNo,
            //        MessageBoxIcon.Information
            //        );

            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        EAFacade.EA.Repository.RemoveTab(_activeTabName);
            //        UnSubscribe(_activeTabGuid);
            //    }
            //}
            

            foreach (var element in _tabs)
            {
                if (GetNameForGUID(element.Key).Equals(tabname))
                {
                    SetActiveTab(element.Key, element.Value, tabname);
                    _activeTab.Update();
                }
            }
            RemoveClosedViewControllers();
        }

        private void SetActiveTab(string GUID, ICustomViewController cvc, string tabName)
        {
            _activeTab = cvc;
            _activeTabGuid = GUID;
            _activeTabName = tabName;
        }

        public void Update(string GUID)
        {
            ICustomViewController vc = _tabs[GUID];
            if (vc != null)
            {
                vc.Update();
            }
        }

        private void RemoveClosedViewControllers()
        {
            List<string> removals = new List<string>();

            foreach (var element in _tabs)
            {
                if (isClosedTab(element.Key))
                {
                    removals.Add(element.Key);
                }
            }

            // Remove them
            foreach (string key in removals)
            {
                UnSubscribe(key);
            }
        }

        private string GetNameForGUID(string GUID)
        {
            return GUID != null ? EAFacade.EA.Repository.GetElementByGUID(GUID).Name : null;
        }

        private bool isActiveTab(string GUID)
        {
            return EAFacade.EA.Repository.IsTabOpen(GetNameForGUID(GUID)) == 2;
        }

        private bool isClosedTab(string GUID)
        {
            return !isOpenTab(GUID);
        }

        private bool isOpenTab(string GUID)
        {
            return GUID != null ? EAFacade.EA.Repository.IsTabOpen(GetNameForGUID(GUID)) > 0 : false;
        }

        public int OpenTabs()
        {
            return _tabs.Count;
        }
    }
}
