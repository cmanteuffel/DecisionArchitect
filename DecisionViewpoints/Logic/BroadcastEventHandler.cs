using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DecisionViewpoints.Logic.AutoGeneration;
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
        private static string lastGUID = string.Empty;
        private static DateTime lastChange = DateTime.MinValue;
        private static bool _preventConnectorModifiedEvent = false;


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
                _preventConnectorModifiedEvent = true;
            }

            return true;
        }

        public static string OnPostOpenDiagram(Repository repository, int diagramId)
        {
            /*var diagram = repository.GetDiagramByID(diagramId);
            if (!diagram.MetaType.Equals(DiagramMetaType)) return "";
            return repository.ActivateToolbox(ToolboxName, 0) ? ToolboxName : "";*/
            return "";
        }

        public static void OnNotifyContextItemModified(Repository repository, string guid, ObjectType ot)
        {
            string message;
            switch (ot)
            {
                case ObjectType.otElement:


                    var element = EAElementWrapper.Wrap(repository, guid);

                    //dirty hack to prevent that the event is fired twice when an decision is modified
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

                    // Update the ChronologicalGenerator View to reflect changes
                    /*if (element.Element.MetaType.Equals(DecisionMetaType))
                    {
                        var package = repository.Models.GetAt(0).Packages.GetByName("Decision Chronological View");
                        var packageWrapper = new EAPackageWrapper(package);
                        var diagramWrapper = new EADiagramWrapper(package.Diagrams.GetAt(0));
                        var chronologicalGenerator = new ChronologicalGenerator(repository, packageWrapper,
                                                                                diagramWrapper);
                        chronologicalGenerator.Update(element);
                    }*/
                    break;
                case ObjectType.otConnector:
                    var connectorWrapper = EAConnectorWrapper.Wrap(repository, guid);

                    //dirty hack that prevents that an modified event is fired after a connector has been created
                    if (_preventConnectorModifiedEvent)
                    {
                        _preventConnectorModifiedEvent = false;
                    }
                    else
                    {
                        if (!RuleManager.Instance.ValidateConnector(connectorWrapper, out message))
                        {
                            MessageBox.Show(
                                message,
                                Messages.WarningCreateRelation,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                        }
                    }
                    break;
            }
        }

        public static void OnContextItemChanged(Repository repository, string guid, ObjectType type)
        {
        }
    }
}