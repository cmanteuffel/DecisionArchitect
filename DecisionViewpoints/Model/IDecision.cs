using System;
using System.Collections.Generic;
using DecisionViewpoints.Logic.Chronological;
using EAFacade.Model;

namespace DecisionViewpoints.Model
{
    public interface IDecision : ICustomViewModel
    {
        int ID { get; }
        string Name { get; set; }
        string State { get; set; }
        string Problem { get; set; }
        string Solution { get; set; }
        string Argumentation { get; set; }
        Topic Topic { get; set; }
        List<IEAConnector> Connectors { get; }

        bool HasTopic();
        
        void Reload();
        void Save();
        

        
        

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
    }
}