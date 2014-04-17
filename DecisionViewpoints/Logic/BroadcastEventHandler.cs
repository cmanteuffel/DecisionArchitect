﻿using System;
using System.Windows.Forms;
using DecisionViewpoints.Logic.Rules;
using DecisionViewpoints.Model;
using DecisionViewpoints.Properties;
using EA;

namespace DecisionViewpoints.Logic
{
    public static class BroadcastEventHandler
    {
        // These values need to be consistent with the ones defined in the DecisionVS MDG file.
        private const string RelStereotype = "Relationship";
        private static readonly string DecisionStereotype = Settings.Default["DecisionStereotype"].ToString();
        private static readonly string DiagramMetaType = Settings.Default["DiagramMetaType"].ToString();
        private static readonly string ToolboxName = Settings.Default["ToolboxName"].ToString();
        private static string lastGUID = string.Empty;
        private static DateTime lastChange = DateTime.MinValue;


        public static bool OnPreNewElement(Repository repository, EventProperties info)
        {
            EAElementWrapper element = EAElementWrapper.Wrap(repository, info);
            string message;
            if (!RuleManager.Instance.ValidateElement(element, out message))
            {
                DialogResult answer =
                    MessageBox.Show(
                        message + Environment.NewLine + Environment.NewLine + Messages.ConfirmCreateRelation,
                        Messages.WarningCreateRelation,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1);

                if (answer == DialogResult.No)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool OnPreNewConnector(Repository repository, EventProperties info)
        {
            EAConnectorWrapper connectorWrapper = EAConnectorWrapper.Wrap(repository, info);
            string message;
            if (!RuleManager.Instance.ValidateConnector(connectorWrapper, out message))
            {
                DialogResult answer =
                    MessageBox.Show(
                        message + Environment.NewLine + Environment.NewLine + Messages.ConfirmCreateRelation,
                        Messages.WarningCreateRelation,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1);

                if (answer == DialogResult.No)
                {
                    return false;
                }
            }
            return true;
        }


        public static string OnPostOpenDiagram(Repository repository, int diagramId)
        {
            Diagram diagram = repository.GetDiagramByID(diagramId);
            if (!diagram.MetaType.Equals(DiagramMetaType)) return "";
            return repository.ActivateToolbox(ToolboxName, 0) ? ToolboxName : "";
        }

        public static void OnNotifyContextItemModified(Repository repository, string guid, ObjectType ot)
        {
            string message;
            switch (ot)
            {
                case ObjectType.otElement:


                    EAElementWrapper element = EAElementWrapper.Wrap(repository, guid);
                    //dirty hack to prevent that the event is fired twice
                    if (lastGUID.Equals(guid) && lastChange.Equals(element.Element.Modified))
                    {
                        return;
                    }
                    if (!RuleManager.Instance.ValidateElement(element, out message))
                    {
                        MessageBox.Show(
                            message,
                            Messages.WarningCreateRelation,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
                    }
                    lastGUID = guid;
                    lastChange = element.Element.Modified;
                    break;
                case ObjectType.otConnector:
                    EAConnectorWrapper connectorWrapper = EAConnectorWrapper.Wrap(repository, guid);
                    if (!RuleManager.Instance.ValidateConnector(connectorWrapper, out message))
                    {
                        MessageBox.Show(
                            message,
                            Messages.WarningCreateRelation,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
                    }
                    break;
            }
        }


        public static void OnContextItemChanged(Repository repository, string guid, ObjectType type)
        {
        }
    }
}