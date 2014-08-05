using System;
using System.Windows.Forms;
using DecisionViewpoints.Logic.Automation;
using DecisionViewpoints.Logic.Rules;
using DecisionViewpoints.Model;
using DecisionViewpoints.Properties;
using EA;

namespace DecisionViewpoints.Model
{
}

namespace DecisionViewpoints.Logic
{
    public class BroadcastEventHandler : RepositoryAdapter
    {
        // These values need to be consistent with the ones defined in the DecisionVP MDG file.
        private const string RelStereotype = "Relationship";
        private static string lastGUID = string.Empty;
        private static DateTime lastChange = DateTime.MinValue;
        private static bool _preventConnectorModifiedEvent;
        private static bool _modified;


        public override bool OnPreNewElement(EAVolatileElement element)
        {
            MessageBox.Show("On pre new element");
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

        public override bool OnPreNewConnector(EAConnectorWrapper connector)
        {
            MessageBox.Show("On pre new connecotr");
            string message;
            if (!RuleManager.Instance.ValidateConnector(connector, out message))
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



        public override void OnNotifyContextItemModified(string guid, ObjectType ot)
        {
            string message;
            switch (ot)
            {
                case ObjectType.otElement:


                    var element = EARepository.Instance.GetElementByGUID(guid);

                    //dirty hack to prevent that the event is fired twice when an decision is modified
                    if (lastGUID.Equals(guid) && lastChange.Equals(element.Modified))
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
                    lastChange = element.Modified;

                    // An element hass been modified
                    if ((bool)Settings.Default["BaselineOptionOnFileClose"])
                        if (element.MetaType.Equals("Decision"))
                        {
                            _modified = true;
                        }

                    // Create a baseline upon a modification of a decision
                    if ((bool)Settings.Default["BaselineOptionOnModification"])
                        if (element.MetaType.Equals("Decision"))
                        {
                            var rep =  EARepository.Instance;
                            var dvp = rep.GetPackageFromRootByName("Decision Views");
                            ChronologicalViewpointUtilities.CreateDecisionSnapshot(dvp);
                        }
                    break;
                case ObjectType.otConnector:
                    var connectorWrapper = EAConnectorWrapper.Wrap(guid);

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


        public override void OnFileClose()
        {
            if (!(bool)Settings.Default["BaselineOptionOnFileClose"]) return;
            if (!_modified) return;

            throw new Exception("needs to be performed for ALL decision view packages");
            
            var rep =  EARepository.Instance;
            
            var dvp = rep.GetPackageFromRootByName("Decision Views");
            ChronologicalViewpointUtilities.CreateDecisionSnapshot(dvp);
        }
    }
}