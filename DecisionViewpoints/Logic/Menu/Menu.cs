﻿using System.Collections.Generic;
using System.Windows.Forms;

namespace DecisionViewpoints.Logic.Menu
{
    public class Menu : IMenu
    {
        private readonly List<IMenu> _subitems = new List<IMenu>();

        public Menu(string name)
        {
            Name = name;
            UpdateDelegate = self => { };
            ClickDelegate = () => { };
            IsEnabled = true;
            IsChecked = false;
            IsVisible = true;
        }

        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsChecked { get; set; }
        public bool IsVisible { get; set; }

        public ClickDelegate ClickDelegate { get; set; }
        public UpdateDelegate UpdateDelegate { get; set; }

        public void Click()
        {
            ClickDelegate();
        }

        public void Update()
        {
            UpdateDelegate(this);
        }

        public IMenu FindMenuItem(string name)
        {           
            if (Name.Equals(name))
            {
                return this;
            }

            IMenu result = null;
            foreach (IMenu subitem in _subitems)
            {
                result = subitem.FindMenuItem(name);
                if (result != null)
                {
                    return result;
                }
            }
            return result;
        }


        public void Add(IMenu i)
        {
            _subitems.Add(i);
        }

        public void Remove(IMenu i)
        {
            _subitems.Remove(i);
        }

        public virtual string[] GetSubItems()
        {
            Update();
            if (!IsVisible)
            {
                return new string[0];
            }
                
            var menuItems = new string[_subitems.Count];
            for (int i = 0; i < _subitems.Count; i++)
            {
                _subitems[i].Update();
                menuItems[i] = _subitems[i].Name;
            }
            return menuItems;
        }
    }
}