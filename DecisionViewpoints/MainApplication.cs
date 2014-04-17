﻿using DecisionViewpoints.Logic;
using DecisionViewpoints.Model.Events;
using EA;

namespace DecisionViewpoints
{
    /// <summary>
    ///     This is the main entry point of the Add-in.
    ///     All the events received in this class are delegated.
    /// </summary>
    public class MainApplication : EAEventAdapter
    {
        /// <summary>
        ///     Handled by the AddinEventHandler.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="location"></param>
        /// <param name="menuName"></param>
        /// <returns></returns>
        public override object EA_GetMenuItems(Repository repository, string location, string menuName)
        {
            return AddinEventHandler.GetMenuItems(repository, location, menuName);
        }


        /// <summary>
        ///     Handled by the AddinEventHandler.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="location"></param>
        /// <param name="menuName"></param>
        /// <param name="itemName"></param>
        /// <param name="isEnabled"></param>
        /// <param name="isChecked"></param>
        public override void EA_GetMenuState(Repository repository, string location, string menuName,
                                             string itemName, ref bool isEnabled, ref bool isChecked)
        {
            AddinEventHandler.GetMenuState(repository, location, menuName, itemName, ref isEnabled, ref isChecked);
        }

        /// <summary>
        ///     Handled by the AddinEventHandler.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="location"></param>
        /// <param name="menuName"></param>
        /// <param name="itemName"></param>
        public override void EA_MenuClick(Repository repository, string location, string menuName, string itemName)
        {
            AddinEventHandler.MenuClick(repository, location, menuName, itemName);
        }

        /// <summary>
        ///     Handled by the BroadcastEventHandler.
        /// </summary>
        /// <param name="repository">The EA repository.</param>
        /// <param name="info">Contains properties of the element to be created.</param>
        /// <returns>Returns true to permit the creation of the element, false to deny.</returns>
        public override bool EA_OnPreNewElement(Repository repository, EventProperties info)
        {
            return BroadcastEventHandler.OnPreNewElement(repository, info);
        }

        /// <summary>
        ///     Handled by the BroadcastEventHandler.
        /// </summary>
        /// <param name="repository">The EA repository.</param>
        /// <param name="info">Contains properties of the connector to be created.</param>
        /// <returns>Returns true to permit the creation of the connector, false to deny.</returns>
        public override bool EA_OnPreNewConnector(Repository repository, EventProperties info)
        {
            return BroadcastEventHandler.OnPreNewConnector(repository, info);
        }

        /// <summary>
        ///     Handled by the BroadcastEventHandler.
        /// </summary>
        /// <param name="repository">The EA repository.</param>
        /// <param name="diagramId">The ID of the diagram that has been opened.</param>
        /// <returns></returns>
        public override string EA_OnPostOpenDiagram(Repository repository, int diagramId)
        {
            return BroadcastEventHandler.OnPostOpenDiagram(repository, diagramId);
        }

        /// <summary>
        ///     Handled by the BroadcastEventHandler.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="guid"></param>
        /// <param name="ot"></param>
        public override void EA_OnNotifyContextItemModified(Repository repository, string guid, ObjectType ot)
        {
            BroadcastEventHandler.OnNotifyContextItemModified(repository, guid, ot);
        }

        /// <summary>
        ///     Handled by the BroadcastEventHandler.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="guid"></param>
        /// <param name="ot"></param>
        public override void EA_OnContextItemChanged(Repository repository, string guid, ObjectType ot)
        {
            BroadcastEventHandler.OnContextItemChanged(repository, guid, ot);
        }

        public override bool EA_OnPostNewPackage(Repository repository, EventProperties info)
        {
            return BroadcastEventHandler.OnPostNewPackage(repository, info);
        }
    }
}