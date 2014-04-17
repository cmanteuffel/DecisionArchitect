﻿using System;
using System.Linq;
using EA;
using System.Windows.Forms;

namespace DecisionViewpoints
{
    /// <summary>
    /// This class is responsible for handling all the EA events delegated
    /// from MainApplication which is the entry point.
    /// </summary>
    public class EventHandler
    {
        private const string Con = "connected";
        // These values need to be consistent with the ones defined in the DecisionVS MDG file.
        private const string RelStereotype = "Relationship";
        private const string DecisionStereotype = "ArchitectureDecision";
        private const string DiagramMetaType = "DecisionVS::RelationshipView";
        private const string ToolboxName = "DecisionVS";

        private static string _preModifyDecisionName ;

        /// <summary>
        /// Called Before EA starts to check Add-In Exists. Nothing is done here.
        /// This operation needs to exists for the addin to work.
        /// </summary>
        /// <returns>Returns a constant string 'connected'</returns>
        public string Connect()
        {
            return Con;
        }

        /// <summary>
        /// Called before a new element is created. It can be used to deny the creation
        /// of the new element.
        /// </summary>
        /// <param name="repository">The EA repository.</param>
        /// <param name="info">Contains properties of the element to be created.</param>
        /// <returns>Returns true to permit the creation of the element, false to deny.</returns>
        public bool OnPreNewElement(Repository repository, EventProperties info)
        {
            return true;
        }

        /// <summary>
        /// Called before a new connector is created. It can be used to deny the creation
        /// of the new connector.
        /// </summary>
        /// <param name="repository">The EA repository.</param>
        /// <param name="info">Contains properties of the connector to be created.</param>
        /// <returns>Returns true to permit the creation of the connector, false to deny.</returns>
        public bool OnPreNewConnector(Repository repository, EventProperties info)
        {
            var rel = new Relationship(repository, info);
            // If the stereotype is different than 'Relationship' then permit the creation
            if (!rel.CheckStereotype(RelStereotype)) return false;
            
            // Check if the Relationship is connected to different Decisions
            if (rel.CheckIfDifferentDecisions())
            {
                MessageBox.Show("A Relationship can exist between different decisions.", "Invalid Relationship");
                return false;
            }
            
            // Check if one of the Decisions that the new Relationship is connected is in the state 'Idea'.
            if (rel.CheckIfPossible()) return true;
            MessageBox.Show("Decision has state Idea. Relationship is not permitted.",
                "Invalid Relationship");
            return false;
        }

        /// <summary>
        /// Called after a diagram has been opended for the first time.
        /// </summary>
        /// <param name="repository">The EA repository.</param>
        /// <param name="diagramId">The ID of the diagram that has been opened.</param>
        public void OnPostOpenDiagram(Repository repository, int diagramId)
        {
            var diagram = repository.GetDiagramByID(diagramId);
            if (diagram.MetaType.Equals(DiagramMetaType))
            {
                repository.ActivateToolbox(ToolboxName, 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="guid"></param>
        /// <param name="ot"></param>
        public void OnNotifyContextItemModified(Repository repository, string guid, ObjectType ot)
        {
            // Check if the Decision name already exists. If it exists print message and change
            // the name to the pre modify one.
            if (!ot.ToString().Equals("otElement")) return;
            var element = repository.GetElementByGuid(guid);
            if (!element.Stereotype.Equals(DecisionStereotype)) return;
            foreach (var e in from Element e in repository.GetElementSet(null, 0) 
                              where e.Stereotype.Equals(DecisionStereotype) 
                              where !e.ElementGUID.Equals(guid) 
                              where element.Name.Equals(e.Name) select e)
            {
                MessageBox.Show(String.Format("The name {0} already exists. Please pick a different name.", e.Name), 
                                "Invalid Decision name");
                element.Name = _preModifyDecisionName;
                element.Update();
                element.Refresh();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="guid"></param>
        /// <param name="ot"></param>
        public void OnContextItemChanged(Repository repository, string guid, ObjectType ot)
        {
            // Save the name of the selected element, which is going to be used in OnNotifyContextItemModified.
            // If the user changes the name of the selected element and the decision name already
            // exists, we will replace it with this pre modify name.
            if (!ot.ToString().Equals("otElement")) return;
            var element = repository.GetElementByGuid(guid);
            if (!element.Stereotype.Equals(DecisionStereotype)) return;
            _preModifyDecisionName = element.Name;
        }

        /// <summary>
        /// EA calls this operation when it exists. It is used to
        /// do some cleanup work.
        /// </summary>
        public void Disconnect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
