/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
*/

using System.Collections.Generic;

namespace DecisionViewpoints.Model.Menu
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
        public object Value { get; set; }
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

            foreach (IMenu subitem in _subitems)
            {
                IMenu result = subitem.FindMenuItem(name);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }


        public void Add(IMenu i)
        {
            _subitems.Add(i);
        }

        public void Remove(IMenu i)
        {
            _subitems.Remove(i);
        }

        public void Clear()
        {
            _subitems.Clear();
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
