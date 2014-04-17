using System;
using System.Collections.Generic;
using System.Linq;
using DecisionViewpoints.Model;
using DecisionViewpoints.Model.Baselines;

namespace DecisionViewpoints.Logic.Automation
{
    internal class ChronologicalViewpointGenerator
    {
        private const string BaselineIdentifier = "Decision History";

        private readonly EADiagram _chronologicalViewpoint;
        private readonly EAPackage _viewPackage;

        public ChronologicalViewpointGenerator(EAPackage viewPackage, EADiagram chronologicalViewpoint)
        {
            _viewPackage = viewPackage;
            _chronologicalViewpoint = chronologicalViewpoint;
        }


        public bool GenerateViewpoint()
        {
            //make sure diagram and data package exists, if not create those
            IEnumerable<DecisionDiffItem> items = GetHistory(_viewPackage);
            IEnumerable<EAElement> decisions = CreateDecisions(items);
            IList<EAElement> connectedDecisions = ConnectDecisions(decisions);

            GenerateDiagram(_chronologicalViewpoint, connectedDecisions);

            return true;
        }

        private IEnumerable<DecisionDiffItem> GetHistory(EAPackage viewPackage)
        {
            IEnumerable<Baseline> baselines =
                viewPackage.GetBaselines().Where(baseline => baseline.Notes.Equals(BaselineIdentifier));
            IEnumerable<DecisionDiffItem> decisionsItems = new List<DecisionDiffItem>();
            Dictionary<string, EAElement> decisions = viewPackage.GetAllDecisions().ToDictionary(e => e.GUID, e => e);

            foreach (Baseline baseline in baselines)
            {
                BaselineDiff baselineDiff = viewPackage.CompareWithBaseline(baseline);
                DiffItem packageItem = baselineDiff.DiffItems.First(item => item.Guid.Equals(viewPackage.GUID));

                decisionsItems = FilterChangedDecisionsOnly(packageItem, decisions);
                decisionsItems = FilterNoModificationsInBetweenBaselines(decisionsItems);
            }

            decisionsItems = FilterConsecutiveStereotypeChanges(decisions, decisionsItems);
            return decisionsItems;
        }

        private IEnumerable<EAElement> CreateDecisions(IEnumerable<DecisionDiffItem> items)
        {
            //check if current element exists if not create in data package
            throw new NotImplementedException();
        }

        private IList<EAElement> ConnectDecisions(IEnumerable<EAElement> decisions)
        {
            throw new NotImplementedException();
        }


        private void GenerateDiagram(EADiagram chronologicalViewpoint, IList<EAElement> connectedDecisions)
        {
            throw new NotImplementedException();
        }



        private IEnumerable<DecisionDiffItem> FilterChangedDecisionsOnly(DiffItem packageItem,
                                                                       IDictionary<string, EAElement> decisions)
        {
            //filter decisions that have changes compared to current version
            IEnumerable<DecisionDiffItem> items = packageItem.DiffItems.Where(item => decisions.Keys.Contains(item.Guid))
                                                             .Where(item => item.Status == DiffStatus.Changed)
                                                             .Select(
                                                                 item =>
                                                                 new DecisionDiffItem(item, decisions[item.Guid]));
            return items;
        }

        private IEnumerable<DecisionDiffItem> FilterNoModificationsInBetweenBaselines(
            IEnumerable<DecisionDiffItem> decisionsItems)
        {
            //filter decisions that are unchanged inbetween baselines
            IDictionary<string, DecisionDiffItem> nomodificationFilter = new Dictionary<string, DecisionDiffItem>();
            foreach (DecisionDiffItem decisionItem in decisionsItems)
            {
                string key = decisionItem.Guid + ">>" + decisionItem.Modified;
                if (!nomodificationFilter.ContainsKey(key))
                {
                    nomodificationFilter[key] = decisionItem;
                }
            }

            return nomodificationFilter.Values;
        }

        private IEnumerable<DecisionDiffItem> FilterConsecutiveStereotypeChanges(
            IDictionary<string, EAElement> decisions, IEnumerable<DecisionDiffItem> decisionsItems)
        {
            IEnumerable<DecisionDiffItem> filteredDecisions = new List<DecisionDiffItem>();
            foreach (string guid in decisions.Keys)
            {
                List<DecisionDiffItem> items = decisionsItems.Where(d => d.Guid.Equals(guid)).ToList();
                items.Sort(DecisionDiffItem.CompareByDateModified);

                var consecutiveChanges = new List<DecisionDiffItem>();
                foreach (DecisionDiffItem item in items)
                {
                    if (!consecutiveChanges.Any())
                    {
                        consecutiveChanges.Add(item);
                    }
                    else
                    {
                        DecisionDiffItem last = consecutiveChanges.Last();
                        if (!last.Stereotype.Equals(item.Stereotype))
                        {
                            consecutiveChanges.Add(item);
                        }
                    }
                }

                DecisionDiffItem lastItem = consecutiveChanges.Last();
                if (lastItem != null && lastItem.Stereotype.Equals(lastItem.Current.Stereotype))
                {
                    consecutiveChanges.Remove(lastItem);
                }
                filteredDecisions = filteredDecisions.Concat(consecutiveChanges);
            }
            return filteredDecisions;
        }
    }
}