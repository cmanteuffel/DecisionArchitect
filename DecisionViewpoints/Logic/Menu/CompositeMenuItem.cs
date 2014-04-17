using System.Collections.Generic;
using System.Windows.Forms;

namespace DecisionViewpoints.Logic.Menu
{
    public abstract class CompositeMenuItem : IMenuItem
    {
        private readonly List<IMenuItem> _menuItems = new List<IMenuItem>();

        protected CompositeMenuItem(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public virtual void Click()
        {
        }

        public virtual bool Enabled()
        {
            return true;
        }

        public virtual bool Checked()
        {
            return false;
        }

        public virtual bool Visible()
        {
            return true;
        }

        public virtual void Add(IMenuItem i)
        {
            _menuItems.Add(i);
        }

        public virtual void Remove(IMenuItem i)
        {
            _menuItems.Remove(i);
        }

        public virtual IMenuItem GetMenuItem(string name)
        {
            var menuItem = _menuItems.Find(x => x.Name == name);
            
            if (menuItem == null)
            {
                foreach (var item in _menuItems)
                {
                    menuItem = item.GetMenuItem(name);
                }
            }
            return menuItem;
        }

        public virtual string[] GetMenuItemsAsArray()
        {
            var menuItems = new string[_menuItems.Count];
            for (var i = 0; i < _menuItems.Count; i++)
            {
                menuItems[i] = _menuItems[i].Name;
            }
            return menuItems;
        }
    }
}
