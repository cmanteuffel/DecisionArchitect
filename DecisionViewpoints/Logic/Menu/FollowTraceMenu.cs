﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DecisionViewpoints.Model;

namespace DecisionViewpoints.Logic.Menu
{
    class FollowTraceMenu : Menu
    {
        private const string NoTracesDefinedName = "No Traces defined";
        private const string DefaultName = "-&Follow Trac(e)";

        public FollowTraceMenu()
            : base(DefaultName)
        {
            UpdateDelegate = OnNoTracesDefined;
        }

        private void OnNoTracesDefined(IMenu self)
        {
            var repository = EARepository.Instance;
            if (repository.GetContextItemType() == NativeType.Element)
            {
                var element = repository.GetContextObject<EAElement>();
                if (element != null)
                {
                    if (!element.GetTracedElements().Any())
                    {
                        Name = NoTracesDefinedName;
                        IsEnabled = false;
                        return;
                    }
                    Name = DefaultName;
                    IsEnabled = true;
                }
            }

        }

        public override string[] GetSubItems()
        {
            Clear();
            
            var repository = EARepository.Instance;
            if (repository.GetContextItemType() == NativeType.Element)
            {
                var element = repository.GetContextObject<EAElement>();
                if (element != null)
                {
                    var menuItemNames = new List<string>();
                    foreach (EAElement tracedElement in element.GetTracedElements())
                    {

                        string name = tracedElement.GetProjectPath() + "/" + tracedElement.Name;
                        if (!"".Equals(tracedElement.Stereotype))
                        {
                            name += " «" + tracedElement.Stereotype + "»";
                        }

                        var uniqueName = GetUniqueName(name, menuItemNames);
                        var menuItem = CreateTraceMenuItem(uniqueName, tracedElement);

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

        private MenuItem CreateTraceMenuItem(string uniqueName, EAElement tracedElement)
        {
            var menuItem = new MenuItem(uniqueName);
            menuItem.Value = tracedElement;
            menuItem.ClickDelegate = delegate
                {
                    EADiagram[] diagrams = tracedElement.GetDiagrams();
                    if (diagrams.Count() == 1)
                    {
                        var diagram = diagrams[0];
                        diagram.OpenAndSelectElement(tracedElement);
                    }
                    else if (diagrams.Count() >= 2)
                    {
                        var selectForm = new SelectDiagram(diagrams);
                        if (selectForm.ShowDialog() == DialogResult.OK)
                        {
                            EADiagram diagram = selectForm.GetSelectedDiagram();
                            diagram.OpenAndSelectElement(tracedElement);
                        }
                    }
                    tracedElement.ShowInProjectView();
                };
            return menuItem;
        }
    }
}
