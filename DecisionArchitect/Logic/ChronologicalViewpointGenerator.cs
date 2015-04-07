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
using System.Globalization;
using System.Linq;
using DecisionArchitect.Model;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Logic
{
    internal class ChronologicalViewpointGenerator
    {
        //private const string BaselineIdentifier = "Decision History";

        private readonly IEADiagram _chronologicalViewpoint;
        private readonly List<IEAElement> _decisions;
        private readonly IEAPackage _historyPackage;

        public ChronologicalViewpointGenerator(List<IEAElement> decisions, IEAPackage historyPackage,
                                               IEADiagram chronologicalViewpoint)
        {
            _chronologicalViewpoint = chronologicalViewpoint;
            _historyPackage = historyPackage;
            _decisions = decisions;
        }


        public bool GenerateViewpoint()
        {
            IEnumerable<IEAElement> decisionElements = GetHistory();
            IEnumerable<IEAElement> connectedElements = ConnectDecisions(decisionElements);
            GenerateDiagram(_chronologicalViewpoint, connectedElements);

            return false;
        }

        private IEnumerable<IEAElement> GetHistory()
        {
            IEnumerable<IEAElement> allDecisionsInPackage = _decisions;

            IEnumerable<IHistoryEntry> history = allDecisionsInPackage.SelectMany(d => Decision.Load(d).History);

            IEnumerable<IEAElement> exisitingHistoryDecisions = _historyPackage.Elements.Where(e => EAMain.IsDecision(e));

            //create non existing and update existing (name)
            var pastDecisions = new List<IEAElement>();
            foreach (IHistoryEntry item in history.ToList())
            {
                string name = string.Format(Messages.ChronologyDecisionName, item.Decision.Name,
                                            item.Modified.ToShortDateString());
                string stereotype = item.State;
                DateTime modified = item.Modified;
                const string type = EAConstants.ActionMetaType;
                string originalGUID = item.Decision.GUID;

                IEAElement pastDecision =
                    exisitingHistoryDecisions.FirstOrDefault(
                        hd => originalGUID.Equals(hd.GetTaggedValueByName(EATaggedValueKeys.OriginalDecisionGuid)) &&
                              modified.ToString(CultureInfo.InvariantCulture)
                                      .Equals(hd.GetTaggedValueByName(EATaggedValueKeys.DecisionStateModifiedDate)) &&
                              stereotype.Equals(hd.Stereotype));
                if (pastDecision == null)
                {
                    pastDecision = _historyPackage.CreateElement(name, stereotype, type);
                }
                pastDecision.MetaType = EAConstants.DecisionMetaType;
                pastDecision.Modified = modified;
                pastDecision.AddTaggedValue(EATaggedValueKeys.DecisionStateModifiedDate,
                                            modified.ToString(CultureInfo.InvariantCulture));
                pastDecision.AddTaggedValue(EATaggedValueKeys.DecisionState, stereotype);
                pastDecision.AddTaggedValue(EATaggedValueKeys.IsHistoryDecision, true.ToString());
                pastDecision.AddTaggedValue(EATaggedValueKeys.OriginalDecisionGuid, originalGUID);

                pastDecisions.Add(pastDecision);
            }


            //add topics  and original decisions         

            return
                pastDecisions.Union(
                    _decisions.Select(d => Decision.Load(d))
                              .Where(d => d.HasTopic())
                              .Select(d => EAMain.Repository.GetElementByGUID(d.Topic.GUID))).Union(_decisions);
        }

        private IEnumerable<IEAElement> ConnectDecisions(IEnumerable<IEAElement> elements)
        {
            //determine order of decisions
            List<IEAElement> sortedElements = elements.ToList();
            sortedElements.Sort(DataComparator.CompareByStateDateModified);

            // connect subsequent elements
            for (int i = 1; i < sortedElements.Count(); i++)
            {
                sortedElements[i - 1].ConnectTo(sortedElements[i], "ControlFlow", "followed by");
            }

            return sortedElements;
        }


        private void GenerateDiagram(IEADiagram chronologicalViewpoint, IEnumerable<IEAElement> elements)
        {
            foreach (IEAElement element in elements)
            {
                chronologicalViewpoint.AddElement(element);
            }
        }
    }
}