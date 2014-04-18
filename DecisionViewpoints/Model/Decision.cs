﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EAFacade.Model;

namespace DecisionViewpoints.Model
{
    public static class DecisionDataTags
    {
        public const string Name = "{name}";
        public const string State = "{state}";
        public const string Topic = "{topic}";
        public const string Issue = "{issue}";
        public const string DecisionText = "{decision}";
        public const string Alternatives = "{alternatives}";
        public const string Arguments = "{arguments}";
        public const string RelatedDecisions = "{decisions}";
        public const string RelatedRequirements = "{requirements}";
        public const string Traces = "{traces}";
    }

    public class Decision : IDecision
    {
        private readonly EAElement _element;

        public Decision(EAElement element)
        {
            _element = element;
        }

        public int ID
        {
            get { return _element.ID; }
        }

        public string Name
        {
            get { return _element.Name; }
            set { _element.Name = value; }
        }

        public string State
        {
            get { return _element.StereotypeList; }
            set { _element.StereotypeList = value; }
        }

        public string Group { get; set; }

        public string Issue
        {
            get { return GetSubstring(DecisionDataTags.Issue); }
        }

        public string DecisionText
        {
            get { return GetSubstring(DecisionDataTags.DecisionText); }
        }

        public string Alternatives
        {
            get { return GetSubstring(DecisionDataTags.Alternatives); }
        }

        public string Arguments
        {
            get { return GetSubstring(DecisionDataTags.Arguments); }
        }

        public string RelatedRequirements
        {
            get { return GetSubstring(DecisionDataTags.RelatedRequirements); }
        }

        public void Save(string extraData)
        {
            _element.Update();
            EARepository repository = EARepository.Instance;
            repository.AdviseElementChanged(_element.ID);
        }

        public List<EAConnector> GetConnectors()
        {
            return _element.GetConnectors();
        }

        public void LoadLinkedDocument(string fileName)
        {
            _element.LoadLinkedDocument(fileName);
        }

        public void AddObserver(IDecisionObserver observer)
        {
            throw new NotImplementedException();
        }

        public void RemoveObserver(IDecisionObserver observer)
        {
            throw new NotImplementedException();
        }

        public bool HasTopic()
        {
            return _element.HasTopic();
        }

        public EAElement GetTopic()
        {
            return _element.GetTopic();
        }

        
        public IEnumerable<Rating> GetForces()
        {
            IEnumerable<Rating> forces = from taggedValue in _element.TaggedValues
                                         where Rating.IsForcesTaggedValue(taggedValue.Name)
                                         select new Rating
                                             {
                                                 DecisionGUID = _element.GUID,
                                                 RequirementGUID = Rating.GetReqGUIDFromTaggedValue(taggedValue.Name),
                                                 ConcernGUID = Rating.GetConcernGUIDFromTaggedValue(taggedValue.Name),
                                                 Value = taggedValue.Value
                                             };
            return forces;
        }

        public IDictionary<string, DateTime> GetHistory()
        {
            var history = new Dictionary<string, DateTime>();
            IEnumerable<string> values = _element.TaggedValues.Where(tv => IsHistoryTag(tv.Name)).Select(tv => tv.Value);
            foreach (string value in values)
            {
                history.Add(GetStateFromTaggedValue(value), GetDateModifiedFromTaggedValue(value));
            }

            return history;
        }

        public IEnumerable<StakeholderInvolvement> GetStakeholderInvolvements()
        {
            var stakeholders = new List<StakeholderInvolvement>();
            foreach (var connector in _element.GetConnectors().Where(connector => connector.IsAction()))
            {
                if (connector.ClientId == _element.ID) continue;
                var stakeholder = connector.GetClient();

                stakeholders.Add(new StakeholderInvolvement
                    {
                        StakeholderName = stakeholder.Name,
                        StakeholderType = stakeholder.Stereotype,
                        StakeholderGUID = stakeholder.GUID,
                        ConnectorGUID = connector.GUID,
                        Action = connector.Stereotype
                    });
            }
            return stakeholders;
        }

        public IEnumerable<EAElement> GetTraces()
        {
            return _element.GetTracedElements();
        }

       

        public EAElement GetElement()
        {
            return _element;
        }

        private static String GetStateFromTaggedValue(string value)
        {
            return value.Split('|')[0];
        }

        private static DateTime GetDateModifiedFromTaggedValue(string value)
        {
            return DateTime.Parse(value.Split('|')[1]);
        }

        private static bool IsHistoryTag(string name)
        {
            return name.StartsWith(DVTaggedValueKeys.DecisionStateChange);
        }

        private string GetSubstring(string tag)
        {
            var rtf = new RichTextBox { Rtf = _element.GetLinkedDocument() };
            /*var first = _element.Notes.IndexOf(tag, StringComparison.Ordinal) + tag.Length;
            var last = _element.Notes.LastIndexOf(tag, StringComparison.Ordinal);*/
            int first = rtf.Text.IndexOf(tag, StringComparison.Ordinal) + tag.Length;
            int last = rtf.Text.LastIndexOf(tag, StringComparison.Ordinal);
            return last > first ? rtf.Text.Substring(first, last - first) : "";
        }
    }
}