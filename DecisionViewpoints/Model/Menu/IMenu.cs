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
    public delegate void ClickDelegate();
    public delegate void UpdateDelegate(IMenu self);

    public interface IMenu
    {
        string Name { get; set; }
        object Value { get; set; }
        bool IsEnabled { get; set; }
        bool IsChecked { get; set;  }
        bool IsVisible { get; set; }

        ClickDelegate ClickDelegate { get; set; }
        UpdateDelegate UpdateDelegate { get; set; }

        void Click();
        void Update();

        IMenu FindMenuItem(string name);
        string[] GetSubItems();
    }
}
