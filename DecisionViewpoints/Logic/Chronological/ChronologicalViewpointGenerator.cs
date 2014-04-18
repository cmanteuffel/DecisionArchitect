﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Chronological
{
    internal class ChronologicalViewpointGenerator
    {
        //private const string BaselineIdentifier = "Decision History";

        private readonly EADiagram _chronologicalViewpoint;
        private readonly EAPackage _historyPackage;
        private readonly EAPackage _viewPackage;

        public ChronologicalViewpointGenerator(EAPackage viewPackage, EAPackage historyPackage,
                                               EADiagram chronologicalViewpoint)
        {
            _viewPackage = viewPackage;
            _chronologicalViewpoint = chronologicalViewpoint;
            _historyPackage = historyPackage;
            //decisions = _viewPackage.GetAllDecisions().ToDictionary(e => e.GUID, e => e);
        }


        public bool GenerateViewpoint()
        {
            
            IEnumerable < EAElement > decisionElements = GetHistory();
            IList<EAElement> connectedElements = ConnectDecisions(decisionElements);
            GenerateDiagram(_chronologicalViewpoint, connectedElements);

            return false;
        }

        private IEnumerable<EAElement> GetHistory()
        {
            IEnumerable<EAElement> allDecisionsInPackage =
                _viewPackage.GetAllDecisions();

            var history =  allDecisionsInPackage.SelectMany(DecisionStateChange.GetHistory);
        
            IEnumerable<EAElement> exisitingHistoryDecisions = _historyPackage.Elements.Where(e => e.IsDecision());

            //create non existing and update existing (name)
            var pastDecisions = new List<EAElement>();
            foreach (DecisionStateChange item in history.ToList())
            {

                string name = string.Format(Messages.ChronologyDecisionName, item.Element.Name, item.DateModified.ToShortDateString());
                string stereotype = item.State;
                DateTime modified = item.DateModified;
                var type = DVStereotypes.ActionMetaType;
                string originalGUID = item.Element.GUID;

                EAElement pastDecision = exisitingHistoryDecisions.FirstOrDefault(hd => originalGUID.Equals(hd.GetTaggedValue(DVTaggedValueKeys.OriginalDecisionGuid)) &&
                                                                                       modified.ToString(CultureInfo.InvariantCulture)
                                                                                               .Equals(hd.GetTaggedValue(DVTaggedValueKeys.DecisionStateModifiedDate)) &&
                                                                                       stereotype.Equals(hd.Stereotype));
                if (pastDecision == null)
                {
                    pastDecision = _historyPackage.CreateElement(name, stereotype, type);
                }
                pastDecision.MetaType = DVStereotypes.DecisionMetaType;
                pastDecision.Modified = modified;
                pastDecision.AddTaggedValue(DVTaggedValueKeys.DecisionStateModifiedDate, modified.ToString(CultureInfo.InvariantCulture));
                pastDecision.AddTaggedValue(DVTaggedValueKeys.DecisionState, stereotype);
                pastDecision.AddTaggedValue(DVTaggedValueKeys.IsHistoryDecision, true.ToString());
                pastDecision.AddTaggedValue(DVTaggedValueKeys.OriginalDecisionGuid, originalGUID);

                pastDecisions.Add(pastDecision);
            }

            //add topics           

            return pastDecisions.Union( _viewPackage.GetAllTopics());
        }

        private IList<EAElement> ConnectDecisions(IEnumerable<EAElement> elements)
        {
            //determine order of decisions
            List<EAElement> sortedElements = elements.ToList();
            sortedElements.Sort(EAElement.CompareByStateDateModified);

            // connect subsequent elements
            for (int i = 1; i < sortedElements.Count(); i++)
            {
                sortedElements[i - 1].ConnectTo(sortedElements[i], "ControlFlow", "followed by");
            }

            return sortedElements;
        }


        private void GenerateDiagram(EADiagram chronologicalViewpoint, IList<EAElement> elements)
        {
            foreach (EAElement element in elements)
            {
                chronologicalViewpoint.AddToDiagram(element);
            }
        }
    }
}