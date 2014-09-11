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
using System.Linq;
using System.Windows.Forms;
using DecisionArchitect.Model.Menu;
using DecisionArchitect.View;
using EAFacade;
using EAFacade.Model;
using MenuItem = DecisionArchitect.Model.Menu.MenuItem;

namespace DecisionArchitect.Logic.Menu
{
    internal class FollowTraceMenu : Model.Menu.Menu
    {
        public FollowTraceMenu()
            : base(Messages.MenuFollowTraceDefault)
        {
            UpdateDelegate = OnNoTracesDefined;
        }

        private void OnNoTracesDefined(IMenu self)
        {
            IEARepository repository = EAMain.Repository;
            if (repository.GetContextItemType() == EANativeType.Element)
            {
                var element = repository.GetContextObject<IEAElement>();
                if (element != null)
                {
                    if (!element.GetTracedElements().Any())
                    {
                        Name = Messages.MenuFollowTraceNoTraces;
                        IsEnabled = false;
                        return;
                    }
                    Name = Messages.MenuFollowTraceDefault;
                    IsEnabled = true;
                }
            }
        }

        public override string[] GetSubItems()
        {
            Clear();

            IEARepository repository = EAMain.Repository;
            if (repository.GetContextItemType() == EANativeType.Element)
            {
                var element = repository.GetContextObject<IEAElement>();
                if (element != null)
                {
                    var menuItemNames = new List<string>();
                    foreach (IEAElement tracedElement in element.GetTracedElements())
                    {
                        string name = tracedElement.GetProjectPath() + "/" + tracedElement.Name;
                        if (!"".Equals(tracedElement.Stereotype))
                        {
                            name += " �" + tracedElement.Stereotype + "�";
                        }

                        string uniqueName = GetUniqueName(name, menuItemNames);
                        MenuItem menuItem = CreateTraceMenuItem(uniqueName, tracedElement);

                        menuItemNames.Add(uniqueName);
                        Add(menuItem);
                    }
                    menuItemNames.Sort();
                    return menuItemNames.ToArray();
                }
            }
            return new string[0];
        }

        private static string GetUniqueName(string name, ICollection<string> menuItemNames)
        {
            int duplicate = 1;
            string uniqueName = name;
            // identify number of duplicates
            while (menuItemNames.Contains(uniqueName))
            {
                uniqueName = name + " (" + ++duplicate + ")";
            }
            return uniqueName;
        }

        private static MenuItem CreateTraceMenuItem(string uniqueName, IEAElement tracedElement)
        {
            var menuItem = new MenuItem(uniqueName);
            menuItem.Value = tracedElement;
            menuItem.ClickDelegate = delegate
                {
                    IEADiagram[] diagrams = tracedElement.GetDiagrams();
                    if (diagrams.Count() == 1)
                    {
                        IEADiagram diagram = diagrams[0];
                        diagram.OpenAndSelectElement(tracedElement);
                    }
                    else if (diagrams.Count() >= 2)
                    {
                        var selectForm = new SelectDiagram(diagrams);
                        if (selectForm.ShowDialog() == DialogResult.OK)
                        {
                            IEADiagram diagram = selectForm.GetSelectedDiagram();
                            diagram.OpenAndSelectElement(tracedElement);
                        }
                    }
                    tracedElement.ShowInProjectView();
                };
            return menuItem;
        }
    }
}