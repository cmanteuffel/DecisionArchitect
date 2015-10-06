/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
*/

using System.ComponentModel;
using EAFacade.Model;

namespace DecisionArchitect.Model
{
    public interface IStakeholderAction: INotifyPropertyChanged
    {
        string Action { get; }
        IStakeholder Stakeholder { get; }
        string ConnectorGUID { get; }
        IDecision Decision { get; }
        bool DoDelete { get; set; }
    }

    public class StakeholderAction : Entity, IStakeholderAction
    {
        private bool _doDelete;
        public bool DoDelete
        {
            get { return _doDelete; }
            set { SetField(ref _doDelete, value, "DoDelete"); }
        }

        public StakeholderAction(IDecision decision, IEAConnector connector)
        {
            Stakeholder = Model.Stakeholder.Load(connector.GetClient());
            Action = connector.Stereotype;
            ConnectorGUID = connector.GUID;
            Decision = decision;
            PropertyChanged += OnPropertyChanged;

        }

        public StakeholderAction(IDecision decision, string action, IStakeholder stakeholder)
        {
            Stakeholder = stakeholder;
            Decision = decision;
            Action = action;
            PropertyChanged += OnPropertyChanged;

        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Changed")) return;
            Changed = true;

        }

        public string Action { get; private set; }
        public IStakeholder Stakeholder { get; private set; }
        public string ConnectorGUID { get; private set; }
        public IDecision Decision { get; private set; }
        public bool Changed { get; private set; }
    }
}