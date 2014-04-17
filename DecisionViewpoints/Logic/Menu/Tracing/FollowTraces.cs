using System.Collections.Generic;
using DecisionViewpoints.Model;
using EA;

namespace DecisionViewpoints.Logic.Menu.Tracing
{
    public class FollowTraces : CompositeMenuItem
    {
        public FollowTraces()
            : base("-&Follow trace(s) to ...")
        {
        }

        public override bool Visible()
        {
            //TODO: Check if the the context item is an element
            /*if (ObjectType.otElement == repository.GetContextItemType())
            {
                dynamic obj = repository.GetContextObject();
                var eaelement = obj as Element;
                if (eaelement != null)
                {
                    return true;
                }
            }*/
            return false;
        }

        public override string[] GetMenuItemsAsArray()
        {
            /*TraceMenuContext.Clear();

            EAElement element = EAElement.Wrap(repository, eaelement);

            foreach (EAElement tracedElement in element.GetTracedElements())
            {
                string menuItem = tracedElement.GetProjectPath() + "/" + tracedElement.Element.Name;

                if (!"".Equals(tracedElement.Stereotype))
                {
                    menuItem += " «" + tracedElement.Stereotype + "»";
                }

                int duplicate = 1;
                string uniqueMenuItem = menuItem;
                while (TraceMenuContext.ContainsKey(uniqueMenuItem))
                {
                    // identify number of duplication
                    uniqueMenuItem = menuItem + " (" + ++duplicate + ")";
                }
                TraceMenuContext[uniqueMenuItem] = tracedElement;
            }
            List<string> menuItems = TraceMenuContext.Keys.ToList();
            menuItems.Sort();
            return menuItems.ToArray();*/
            return new string[0];
        }
    }
}