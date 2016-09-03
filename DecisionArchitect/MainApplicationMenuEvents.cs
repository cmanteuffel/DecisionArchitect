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

using DecisionArchitect.Logic.Menu;
using EA;
using EAFacade;

namespace DecisionArchitect
{
    public partial class MainApplication
    {
        public override object EA_GetMenuItems(Repository repository, string location, string menuName)
        {
            EAMain.UpdateRepository(repository);
            return MenuEventHandler.GetMenuItems(location, menuName);
        }

        public override void EA_GetMenuState(Repository repository, string location, string menuName,
                                             string itemName, ref bool isEnabled, ref bool isChecked)
        {
            EAMain.UpdateRepository(repository);
            MenuEventHandler.GetMenuState(location, menuName, itemName, ref isEnabled, ref isChecked);
        }

        public override void EA_MenuClick(Repository repository, string location, string menuName, string itemName)
        {
            EAMain.UpdateRepository(repository);
            MenuEventHandler.MenuClick(location, menuName, itemName);
        }
    }
}