using System;
using System.Collections.Generic;
using System.Globalization;
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
        // These values need to be consistent with the ones defined in the DecisionVP MDG file.
        private const string RelStereotype = "Relationship";
        private static string lastGUID = string.Empty;
        private static DateTime lastChange = DateTime.MinValue;
        private static bool _preventConnectorModifiedEvent;
        private static bool _modified;

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

        public static void OnNotifyContextItemModified(Repository repository, string guid, ObjectType ot, BaselineOptions bo)
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

                    // An element hass been modified
                    if (bo.GetOption(BaselineOptions.Option.OnFileClose))
                        if (element.Element.MetaType.Equals("Decision"))
                        {
                            _modified = true;
                        }

                    // Create a baseline upon a modification of a decision
                    if (bo.GetOption(BaselineOptions.Option.OnModification))
                        if (element.Element.MetaType.Equals("Decision"))
                        {
                            var project = new EAProjectWrapper(repository);
                            var rep = new EARepositoryWrapper(repository);
                            var notes = String.Format("Baseline Time: {0}", DateTime.Now);
                            var dvp = new EAPackageWrapper(rep.GetPackageFromRootByName("Decision Views"));
                            var bv = project.GetBaselineLatestVesrion(repository, dvp);
                            project.CreateBaseline(dvp.Get().PackageGUID, bv, notes);
                        }
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

        public static void FileClose(Repository repository, BaselineOptions bo)
        {
            if (!bo.GetOption(BaselineOptions.Option.OnFileClose)) return;
            if (!_modified) return;
            var project = new EAProjectWrapper(repository);
            var rep = new EARepositoryWrapper(repository);
            var notes = String.Format("Baseline Time: {0}", DateTime.Now);
            var dvp = new EAPackageWrapper(rep.GetPackageFromRootByName("Decision Views"));
            var bv = project.GetBaselineLatestVesrion(repository, dvp);
            project.CreateBaseline(dvp.Get().PackageGUID, bv, notes);
        }
    }
}