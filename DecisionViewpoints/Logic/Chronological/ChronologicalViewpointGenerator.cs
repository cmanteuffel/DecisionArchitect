using System;
using System.Collections.Generic;
using System.Linq;
using DecisionViewpoints.Properties;
using EAFacade.Model;
using EAFacade.Model.Baselines;

namespace DecisionViewpoints.Logic.Chronological
{
    internal class ChronologicalViewpointGenerator
    {
        //private const string BaselineIdentifier = "Decision History";

        private readonly EADiagram _chronologicalViewpoint;
        private readonly EAPackage _historyPackage;
        private readonly EAPackage _viewPackage;
        private readonly Dictionary<string, EAElement> decisions;

        public ChronologicalViewpointGenerator(EAPackage viewPackage, EAPackage historyPackage,
                                               EADiagram chronologicalViewpoint)
        {
            _viewPackage = viewPackage;
            _chronologicalViewpoint = chronologicalViewpoint;
            _historyPackage = historyPackage;
            decisions = _viewPackage.GetAllDecisions().ToDictionary(e => e.GUID, e => e);
        }


        public bool GenerateViewpoint()
        {
            IEnumerable<DecisionDiffItem> items = GetHistory();

            string itemString = "";
            foreach (DecisionDiffItem decisionDiffItem in items)
            {
                itemString += decisionDiffItem.Current.Name + " <" + decisionDiffItem.Stereotype + "> @" +
                              decisionDiffItem.Modified + "\n";
            }
            IEnumerable<EAElement> decisionElements = CreateDecisions(items);
            IList<EAElement> connectedElements = ConnectDecisions(decisionElements);
            GenerateDiagram(_chronologicalViewpoint, connectedElements);

            return true;
        }

        private IEnumerable<DecisionDiffItem> GetHistory()
        {
            IEnumerable<Baseline> baselines =
                _viewPackage.GetBaselines()
                            .Where(baseline => baseline.Notes.Equals(Settings.Default.BaselineIdentifier));

            //TODO: Identify our decisions by tagged values and not metatype and it needs to be recursive (depth search for decisions in groups etc)
            IDictionary<string, DecisionDiffItem> nomodificationFilter = new Dictionary<string, DecisionDiffItem>();
            foreach (Baseline baseline in baselines)
            {
                BaselineDiff baselineDiff = _viewPackage.CompareWithBaseline(baseline);
                DiffItem packageItem = baselineDiff.DiffItems.First(item => item.Guid.Equals(_viewPackage.GUID));

                IEnumerable<DecisionDiffItem> changedDecisions = FilterChangedDecisionsOnly(packageItem, decisions);
                foreach (DecisionDiffItem decisionItem in changedDecisions)
                {
                    string key = decisionItem.Guid + ">>" + decisionItem.Modified;
                    if (!nomodificationFilter.ContainsKey(key))
                    {
                        nomodificationFilter[key] = decisionItem;
                    }
                }
            }

            string itemString = "";
            foreach (DecisionDiffItem decisionDiffItem in nomodificationFilter.Values)
            {
                itemString += decisionDiffItem.Current.Name + " <" + decisionDiffItem.Stereotype + "> @" +
                              decisionDiffItem.Modified + "\n";
            }

            return FilterConsecutiveStereotypeChanges(decisions, nomodificationFilter.Values.ToList());
        }

        private IEnumerable<EAElement> CreateDecisions(IEnumerable<DecisionDiffItem> items)
        {
            List<DecisionDiffItem> diffItems = items.ToList();

            //create non existing and update existing (name)
            var pastDecisions = new List<EAElement>();
            foreach (DecisionDiffItem item in diffItems)
            {
                //TODO: if there is an element with the tagged value original guid and modified name than skip creating and just updating it with name and then add it to list
                string name = item.Current.Name;
                string stereotype = item.Stereotype;
                DateTime modified = item.Modified;
                string metatype = DVStereotypes.DecisionMetaType;
                string type = "Action";
                //TODO: add tagged value original guid
                //TODO: add tagged value modified
                EAElement pastDecision = _historyPackage.CreateElement(name, stereotype, type);
                pastDecision.MetaType = metatype;
                pastDecision.Modified = modified;

                ;

                pastDecisions.Add(pastDecision);
            }

            //combine decisions and created or updated elements
            return pastDecisions.Union(decisions.Values);
        }

        private IList<EAElement> ConnectDecisions(IEnumerable<EAElement> elements)
        {
            List<EAElement> sortedElements = elements.ToList();
            sortedElements.Sort(EAElement.CompareByDateModified);

            string itemString = "";
            foreach (EAElement decisionDiffItem in sortedElements)
            {
                itemString += decisionDiffItem.Name + " <" + decisionDiffItem.Stereotype + "> @" +
                              decisionDiffItem.Modified + "\n";
            }

            // connect subsequent elements
            for (int i = 1; i < sortedElements.Count(); i++)
            {
                //TODO: check if connected (remove previous followed bys
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


        private IEnumerable<DecisionDiffItem> FilterChangedDecisionsOnly(DiffItem packageItem,
                                                                         IDictionary<string, EAElement> decisions)
        {
            //filter decisions that have changes compared to current version
            IEnumerable<DecisionDiffItem> items =
                packageItem.DiffItems.Where(item => decisions.Keys.Contains(item.Guid))
                           .Where(item => item.Status == DiffStatus.Changed)
                           .Select(
                               item =>
                               new DecisionDiffItem(item, decisions[item.Guid])).ToList();
            return items;
        }


        private IEnumerable<DecisionDiffItem> FilterConsecutiveStereotypeChanges(
            IDictionary<string, EAElement> decisions, IEnumerable<DecisionDiffItem> decisionHistory)
        {
            IEnumerable<DecisionDiffItem> filteredDecisions = new List<DecisionDiffItem>();
            foreach (string guid in decisions.Keys)
            {
                List<DecisionDiffItem> items = decisionHistory.Where(d => d.Guid.Equals(guid)).ToList();
                if (!items.Any()) continue;

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