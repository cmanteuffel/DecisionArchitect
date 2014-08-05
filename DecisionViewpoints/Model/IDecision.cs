/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    Marc Holterman (University of Groningen)
*/

using System;
using System.Collections.Generic;
using DecisionViewpoints.Logic.Chronological;
using DecisionViewpoints.Logic.Events;

using EAFacade.Model;

namespace DecisionViewpoints.Model
{
    public delegate void DecisionChangedHandler<IDecision>(IDecision sender, DecisionEventArgs e);

    public interface IDecision : ICustomViewModel
    {
        string GUID { get; }
        int ID { get; }
        string Name { get; set; }
        string State { get; set; }
        DateTime Modified { get; set; }
        string Author { get; set; }
        string Rationale { get; set; }

        Topic Topic { get; set; }

        IList<DecisionStateChange> History { get; set; }

        List<IEAConnector> Connectors { get; }

        bool HasTopic();
        //bool IsRecentlyChanged();
        void Reload();
        void Save();
        void ShowDetailView();
        string DecisionSerialVersionID();

        /// <summary>
        /// Returns a enumeration of elements that were traced to this decision with the trace connector.
        /// </summary>
        /// <returns>Enumeration of elements</returns>
        IEnumerable<IEAElement> GetTraces();

        /// <summary>
        ///  Ratings are filled out in the Forces Views and stored in the tagged values of a decision.
        /// </summary>
        /// <returns>Returns a enumeration of Ratings.</returns>
        IEnumerable<Rating> GetForces();
        IEnumerable<StakeholderInvolvement> GetStakeholderInvolvements();
        IList<DecisionStateChange> GetHistory();
        void AddHistory(string newState, DateTime dateModified);
       // void DeleteHistory(string stateToBeDeleted, string dateToBeDeleted);
        bool ReplaceHistoryEntryForState(string state, DateTime oldDatemodified, DateTime newDateModified);

    }
}
