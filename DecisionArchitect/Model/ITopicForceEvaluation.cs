/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Mathieu Kalksma (University of Groningen)
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DecisionArchitect.View.Forces;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Model
{
    public interface ITopicForceEvaluation: IPersistableModel, INotifyPropertyChanged
    {
        IForce Force { get; }
        IConcern Concern { get; }
        BindingList<DecisionEvaluation> DecisionEvaluations { get; }
        string Weight { get; set; }
        void Delete();
        bool DoDelete { get; }
    }


    public class TopicForceEvaluation : Entity, ITopicForceEvaluation
    {
        private string _weight;

        public IForce Force { get; private set; }
        public IConcern Concern { get; private set; }
        public ITopic Topic { get; private set; }
        public BindingList<DecisionEvaluation> DecisionEvaluations { get; set; }


        public string Weight
        {
            get { return _weight; }
            set { SetField(ref _weight, value, "Weight"); }
        }

        private bool _changed;
        public bool Changed
        {
            get { return _changed; }
            private set { SetField(ref _changed, value, "Changed"); }
        }

        private bool _doDelete;

        public bool DoDelete
        {
            get { return _doDelete; }
            set { SetField(ref _doDelete, value, "DoDelete"); }
        }

        public TopicForceEvaluation(ITopic topic, IForce force, IConcern concern, IEnumerable<IDecision> decisions)
        {
            Force = force;
            Concern = concern;
            DecisionEvaluations = new BindingList<DecisionEvaluation>();
            Topic = topic;
            
            var connector = GetTopicForceConnector(Topic.Element);
            if (connector == null)
                Changed = true; //new force so must be saved
            Weight = connector == null ? string.Empty : connector.GetTaggedValueByName(EAConstants.ForceWeight);

            foreach (var decision in decisions)
                DecisionEvaluations.Add(new DecisionEvaluation(decision, Concern, Force));
            PropertyChanged += OnPropertyChanged;
            DecisionEvaluations.RaiseListChangedEvents = true;
            DecisionEvaluations.ListChanged += DecisionEvaluationsOnListChanged;
            
        }

        private void DecisionEvaluationsOnListChanged(object sender, ListChangedEventArgs listChangedEventArgs)
        {
            Changed = true;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Changed")) return;
            Changed = true;
        }

        private IEAConnector GetTopicForceConnector(IEAElement topicElement)
        {
            return (from x in topicElement.GetConnectors()
                    where x.GetSupplier().GUID.Equals(Force.ForceGUID) && x.TaggedValueExists(EAConstants.ConcernUID) && x.GetTaggedValueByName(EAConstants.ConcernUID).Equals(Concern.UID)
                    select x).FirstOrDefault();
        }

        private IEAConnector GetForceConcernConnector(IEAElement forceElement)
        {
            return (from x in forceElement.GetConnectors()
                where
                    x.GetSupplier().GUID.Equals(Concern.ConcernGUID) && x.TaggedValueExists(EAConstants.ConcernUID) &&
                    x.GetTaggedValueByName(EAConstants.ConcernUID).Equals(Concern.UID)
                select x).FirstOrDefault();
        }

        public void Delete()
        {
            DoDelete = true;
        }

        public bool SaveChanges()
        {
            var topicElement = Topic.Element;
            var forceElement = Force.Element;
            if (Concern.UID == null)
                Concern.UID = Guid.NewGuid().ToString();
            var connector = GetTopicForceConnector(topicElement);
            var concernConnector = GetForceConcernConnector(forceElement);
            if (concernConnector == null)
            {
                var concernElement = EAMain.Repository.GetElementByGUID(Concern.ConcernGUID);
                concernConnector = forceElement.ConnectTo(concernElement, EAConstants.ConcernMetaType, EAConstants.ConcernMetaType);
                concernConnector.AddTaggedValue(EAConstants.ConcernUID, Concern.UID);
            }
            if (connector == null)
            {
                connector = topicElement.ConnectTo(forceElement, EAConstants.ForcesConnectorType,
                    EAConstants.ForcesConnectorType);
                connector.AddTaggedValue(EAConstants.ConcernUID, Concern.UID);
                connector.AddTaggedValue(EAConstants.ForceWeight, Weight);
            }
            else
            {
                connector.UpdateTaggedValue(EAConstants.ForceWeight, Weight);
            }

            if (DoDelete)
                return DeleteForce(topicElement, connector);
             
            foreach (var decisionEvaluation in DecisionEvaluations.Where(decisionEvaluation => decisionEvaluation.Changed))
                decisionEvaluation.SaveChanges();
            
            return true;
        }

        private bool DeleteForce(IEAElement topicElement, IEAConnector connector)
        {
            //first remove the connection between topic-> force
            topicElement.RemoveConnector(connector);
            var forceElement = Force.Element;

            //now all connectionsb etween force->decision
            foreach (var decisionEvaluation in DecisionEvaluations)
                decisionEvaluation.Delete(forceElement);

            //finally between force->concern
            var concernConnector = (from x in forceElement.GetConnectors()
                where
                    x.GetSupplier().GUID.Equals(Concern.ConcernGUID) && x.TaggedValueExists(EAConstants.ConcernUID) &&
                    x.GetTaggedValueByName(EAConstants.ConcernUID).Equals(Concern.UID)
                select x).FirstOrDefault();
            forceElement.RemoveConnector(concernConnector);

            return true;
        }

        public void DiscardChanges()
        {
            
        }

        
    }
}