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

using EA;

namespace EAFacade.Events
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