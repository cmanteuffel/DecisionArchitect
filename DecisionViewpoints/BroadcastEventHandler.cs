﻿using System;
using System.Linq;
using System.Windows.Forms;
using DecisionViewpoints.Model;
using DecisionViewpoints.Model.Rules;
using EA;

namespace DecisionViewpoints
{
    public static class BroadcastEventHandler
    {
        // These values need to be consistent with the ones defined in the DecisionVS MDG file.
        private const string RelStereotype = "Relationship";
        private static readonly string DecisionStereotype = Properties.Settings.Default["DecisionStereotype"].ToString();
        private static readonly string DiagramMetaType = Properties.Settings.Default["DiagramMetaType"].ToString();
        private static readonly string ToolboxName = Properties.Settings.Default["ToolboxName"].ToString();

        // TODO: it is recommended not to hold state information, to be discussed (name uniqueness)
        private static string _preModifyDecisionName;

        /// <summary>
        /// Called before a new element is created. It can be used to deny the creation
        /// of the new element.
        /// </summary>
        /// <param name="repository">The EA repository.</param>
        /// <param name="info">Contains properties of the element to be created.</param>
        /// <returns>Returns true to permit the creation of the element, false to deny.</returns>
        public static bool OnPreNewElement(Repository repository, EventProperties info)
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
        public static bool OnPreNewConnector(Repository repository, EventProperties info)
        {
            PreConnector connector = PreConnector.Wrap(repository, info);

            if (!Stereotypes.Relationships.Contains(connector.Stereotype))
            {
                return true;
            }

            string message;
            if (!Validator.Instance.ValidateConnector(connector, out message))
            {
                MessageBox.Show(message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Called after a diagram has been opended for the first time.
        /// </summary>
        /// <param name="repository">The EA repository.</param>
        /// <param name="diagramId">The ID of the diagram that has been opened.</param>
        /// <returns>The name of the our Decision Viewpoints toolbox which was activated or an empty string.</returns>
        public static string OnPostOpenDiagram(Repository repository, int diagramId)
        {
            // Activate the Decision toolbox when user opens for the first time a Relationship View diagram.
            var diagram = repository.GetDiagramByID(diagramId);
            if (!diagram.MetaType.Equals(DiagramMetaType)) return "";
            return repository.ActivateToolbox(ToolboxName, 0) ? ToolboxName : "";
        }

        /// <summary>
        /// Called when the user modifies the context of any element in the EA user interface.
        /// </summary>
        /// <param name="repository">The EA repository.</param>
        /// <param name="guid">The guid of the element whose context modified.</param>
        /// <param name="ot">The object type of the element whose context modified.</param>
        public static void OnNotifyContextItemModified(Repository repository, string guid, ObjectType ot)
        {
            switch (ot)
            {
                case ObjectType.otElement:
                    var element = repository.GetElementByGuid(guid);
                    if (element.Stereotype.Equals(DecisionStereotype))
                    {
                        // TODO: it is recommended not to hold state information, to be discussed (name uniqueness)
                        // Check if the Decision name already exists. If it exists print message and change
                        // the name to the pre modify one.
                        // DecisionContextChanged(repository, element);
                    }
                    break;
                case ObjectType.otConnector:
                    var connector = repository.GetConnectorByGuid(guid);
                    switch (connector.Stereotype)
                    {
                        case RelStereotype:
                            // RelContextChanged(repository, connector);
                            break;
                    }
                    break;
            }
        }

        /// <summary>
        /// Called when user selects a new element anywhere in the EA user interface.
        /// </summary>
        /// <param name="repository">The EA repostiory.</param>
        /// <param name="guid">The guid of the selected element.</param>
        /// <param name="ot">The object type of the selected element.</param>
        public static void OnContextItemChanged(Repository repository, string guid, ObjectType ot)
        {
            // TODO: it is recommended not to hold state information, to be discussed (name uniqueness)
            // Save the name of the selected element, which is going to be used in OnNotifyContextItemModified.
            // If the user changes the name of the selected element and the decision name already
            // exists, we will replace it with this pre modify name.
            switch (ot)
            {
                case ObjectType.otElement:
                    var element = repository.GetElementByGuid(guid);
                    if (!element.Stereotype.Equals(DecisionStereotype)) return;
                    _preModifyDecisionName = element.Name;
                    break;
            }
        }

        private static void DecisionContextChanged(IDualRepository repository, IDualElement element)
        {
            foreach (var e in from Element e in repository.GetElementSet(null, 0)
                              where e.Stereotype.Equals(DecisionStereotype)
                              where !e.ElementGUID.Equals(element.ElementGUID)
                              where element.Name.Equals(e.Name)
                              select e)
            {
                MessageBox.Show(String.Format("The name {0} already exists. Please pick a different name.", e.Name),
                                "Invalid decision name");
                element.Name = _preModifyDecisionName;
                element.Update();
                element.Refresh();
            }
        }

        private static void RelContextChanged(Repository repository, Connector connector)
        {
            // var rel = new Relationship(connector);
            // TaggedValue taggedValue = connector.TaggedValues.GetByName("type");
            // MessageBox.Show(taggedValue.Name);
        }

        public static bool OnPostNewPackage(Repository repository, EventProperties info)
        {
            // Here we can create a Decision Group directly into the diagram of the newly created
            // Decision Group Package. It is an action that the users will most often repeat.
            return false;
        }
    }
}