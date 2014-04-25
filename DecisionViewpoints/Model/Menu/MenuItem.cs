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

namespace DecisionViewpoints.Model.Menu
{
    public class MenuItem : IMenu
    {
        public static IMenu Separator = new MenuItem("-");

        public MenuItem(string name, ClickDelegate clickDelegate = null)
        {
            Name = name;
            UpdateDelegate = self => { };
            ClickDelegate = clickDelegate ?? (() => { });
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
            return Name.Equals(name) ? this : null;
        }

        public string[] GetSubItems()
        {
            return new[] {""};
        }
    }
}
