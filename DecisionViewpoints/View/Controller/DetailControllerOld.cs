/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    Antonis Gkortzis (University of Groningen)    
*/

using System.Linq;
using DecisionViewpoints.Model;
using EAFacade.Model;


namespace DecisionViewpoints.View.Controller
{
    public class DetailController : IDetailViewController
    {
        private readonly IDecision _decision;
        private readonly IDetailView _view;

        public DetailController(IDecision decision, IDetailView view)
        {
            _view = view;
            _decision = decision;
            _view.SetController(this);
        }

        public void Update()
        {
            _view.DecisionName = _decision.Name;
            _view.DecisionState = _decision.State;
            _view.DecisionIssue = _decision.Problem;
            _view.DecisionText = _decision.Solution;
            _view.DecisionArguments = _decision.Argumentation;

            // Update Related Decisions field
            foreach (var connector in _decision.Connectors.Where(connector => connector.IsRelationship()))
            {
                if (!connector.Stereotype.Equals("alternative for"))
                {
                    if (connector.ClientId == _decision.ID)
                        _view.AddRelatedDecision(connector.Stereotype, connector.GetSupplier().Name, true,
                                                 connector.GetSupplier().GUID, connector.GetClient().GUID);
                    else
                        _view.AddRelatedDecision(connector.Stereotype, connector.GetClient().Name, false,
                                                 connector.GetClient().GUID, connector.GetSupplier().GUID);
                }
            }


            // Update Alternative Decisions field
            foreach (var connector in _decision.Connectors.Where(connector => connector.IsRelationship()))
            {
                if (connector.Stereotype.Equals("alternative for"))
                {
                    if (connector.ClientId != _decision.ID)
                        _view.AddAlternativeDecision(connector.Stereotype, connector.GetClient().Name, false,
                                                     connector.GetSupplier().GUID, connector.GetClient().GUID);
                    else
                        _view.AddAlternativeDecision(connector.Stereotype, connector.GetSupplier().Name, true,
                                                     connector.GetSupplier().GUID, connector.GetClient().GUID);
                }
            }

            // Update Traces
            var traces = from IEAConnector trace in _decision.Connectors
                         where trace.Stereotype.Equals("trace")
                         select (trace.SupplierId == _decision.ID
                                     ? trace.GetClient()
                                     : trace.GetSupplier()
                                );
            foreach (IEAElement tracedElement in traces)
            {
                _view.AddTrace(tracedElement.Name, tracedElement.Type, tracedElement.GUID);
                // MessageBox.Show("Traced element: " + tracedElement.Name + "\nuid: " + tracedElement.GUID);
            }

            // Update Related Forces
            var forces = _decision.GetForces();
            foreach (var rating in forces)
            {
                IEAElement force = EAFacade.EA.Repository.GetElementByGUID(rating.ForceGUID);
                IEAElement concern = EAFacade.EA.Repository.GetElementByGUID(rating.ConcernGUID);
                _view.AddRelatedForce(force.Name, rating.Value, force.Notes, rating.ForceGUID, concern.Name);
            }

            // Update Stakeholder field
            foreach (var connector in _decision.Connectors.Where(connector => connector.IsAction()))
            {
                if (connector.ClientId == _decision.ID) continue;
                var stakeholder = connector.GetClient();
                _view.AddStakeholderEntry(stakeholder.Name, stakeholder.Stereotype, connector.Stereotype,
                                          _decision.State, stakeholder.GUID);
            }

            // Update History field
            foreach (var entry in _decision.GetHistory())
            {
                _view.AddHistoryEntry(entry.State, entry.DateModified);
            }

            //update topic
            if (_decision.HasTopic())
            {

                var topic = _decision.Topic;
                _view.AddTopic(topic.Name, topic.Description, true);
            }
        }

        public void ShowDetailView()
        {
            Update();
            _view.ShowAsDialog();
        }

        public void Save()
        {
            _decision.Name = _view.DecisionName;
            _decision.State = _view.DecisionState;
            _decision.Problem = _view.DecisionIssue;
            _decision.Solution = _view.DecisionText ;
            _decision.Argumentation = _view.DecisionArguments;
            _decision.Save();
        }
    }
}
