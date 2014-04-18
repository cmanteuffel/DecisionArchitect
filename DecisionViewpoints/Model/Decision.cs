using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        private readonly IEAElement _element;

        public Decision(IEAElement element)
        {
            _element = element;
            Load();
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

        public string Problem { get; set; }
        public string Solution { get; set; }
        public string Argumentation { get; set; }


        public Topic Topic
        {
            get
            {
                if (_element.ParentElement == null || !_element.ParentElement.IsTopic()) return null;
                return new Topic(_element.ParentElement);
            }
            set { _element.ParentElement = value.GetElement(); }
        }

        public List<IEAConnector> Connectors
        {
            get { return _element.GetConnectors(); }
        }

        public void Save()
        {
            var extraData = new StringBuilder();
            extraData.Append(string.Format("{0}{1}{2}", DecisionDataTags.Issue, Problem,
                                           DecisionDataTags.Issue));
            extraData.Append(string.Format("{0}{1}{2}", DecisionDataTags.DecisionText, Solution,
                                           DecisionDataTags.DecisionText));
            extraData.Append(string.Format("{0}{1}{2}", DecisionDataTags.Alternatives, "",
                                           DecisionDataTags.Alternatives));
            extraData.Append(string.Format("{0}{1}{2}", DecisionDataTags.Arguments, Argumentation,
                                           DecisionDataTags.Arguments));
            extraData.Append(string.Format("{0}{1}{2}", DecisionDataTags.RelatedRequirements,
                                           "", DecisionDataTags.RelatedRequirements));
            using (var tempFiles = new TempFileCollection())
            {
                string fileName = tempFiles.AddExtension("rtf");
                using (var file = new StreamWriter(fileName))
                {
                    file.WriteLine(extraData.ToString());
                }
                LoadLinkedDocument(fileName);
            }

            _element.Update();
            IEARepository repository = EAFacade.EA.Repository;
            repository.AdviseElementChanged(_element.ID);
        }

        public void Reload()
        {
            Load();
        }

        public bool HasTopic()
        {
            if (_element.ParentElement == null) return false;
            return _element.ParentElement.IsTopic();
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
            foreach (IEAConnector connector in _element.GetConnectors().Where(connector => connector.IsAction()))
            {
                if (connector.ClientId == _element.ID) continue;
                IEAElement stakeholder = connector.GetClient();

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

        public IEnumerable<IEAElement> GetTraces()
        {
            return _element.GetTracedElements();
        }

        private void Load()
        {
            Problem = GetSubstring(DecisionDataTags.Issue);
            Solution = GetSubstring(DecisionDataTags.DecisionText);
            Argumentation = GetSubstring(DecisionDataTags.Arguments);
        }

        private void LoadLinkedDocument(string fileName)
        {
            _element.LoadLinkedDocument(fileName);
        }

        public IEAElement GetElement()
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
            return name.StartsWith(EATaggedValueKeys.DecisionStateChange);
        }

        private string GetSubstring(string tag)
        {
            var rtf = new RichTextBox {Rtf = _element.GetLinkedDocument()};
            /*var first = _element.Notes.IndexOf(tag, StringComparison.Ordinal) + tag.Length;
            var last = _element.Notes.LastIndexOf(tag, StringComparison.Ordinal);*/
            int first = rtf.Text.IndexOf(tag, StringComparison.Ordinal) + tag.Length;
            int last = rtf.Text.LastIndexOf(tag, StringComparison.Ordinal);
            return last > first ? rtf.Text.Substring(first, last - first) : "";
        }
    }
}