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

using System;
using System.Windows.Forms;
using EAFacade.Model;

namespace DecisionArchitect.Logic.Validation
{
    public class ValidationHandler : RepositoryAdapter
    {
        // These values need to be consistent with the ones defined in the DecisionVP MDG file.
        private static string lastGUID = string.Empty;
        private static DateTime lastChange = DateTime.MinValue;
        private static bool _preventConnectorModifiedEvent;


        public override bool OnPreNewElement(IEAVolatileElement element)
        {
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

        public override bool OnPreNewConnector(IEAVolatileConnector connector)
        {
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


        public override void OnNotifyContextItemModified(string guid, EANativeType ot)
        {
            string message;
            switch (ot)
            {
                case EANativeType.Element:

                    IEAElement element = EAFacade.EA.Repository.GetElementByGUID(guid);

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

                    break;
                case EANativeType.Connector:
                    var connector = EAFacade.EA.Repository.GetConnectorByGUID(guid);

                    //dirty hack that prevents that an modified event is fired after a connector has been created
                    if (_preventConnectorModifiedEvent)
                    {
                        _preventConnectorModifiedEvent = false;
                    }
                    else
                    {
                        if (!RuleManager.Instance.ValidateConnector(connector, out message))
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
    }
}
