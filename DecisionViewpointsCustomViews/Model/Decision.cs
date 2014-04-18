using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EAFacade.Model;

namespace DecisionViewpointsCustomViews.Model
{
    public static class DecisionDataTags
    {
        public const string Issue = "{issue}";
        public const string DecisionText = "{decision}";
        public const string Alternatives = "{alternatives}";
        public const string Arguments = "{arguments}";
        public const string RelatedRequirements = "{requirements}";
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
            var repository = EARepository.Instance;
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

        private string GetSubstring(string tag)
        {
            var rtf = new RichTextBox { Rtf = _element.GetLinkedDocument() };
            /*var first = _element.Notes.IndexOf(tag, StringComparison.Ordinal) + tag.Length;
            var last = _element.Notes.LastIndexOf(tag, StringComparison.Ordinal);*/
            var first = rtf.Text.IndexOf(tag, StringComparison.Ordinal) + tag.Length;
            var last = rtf.Text.LastIndexOf(tag, StringComparison.Ordinal);
            return last > first ? rtf.Text.Substring(first, last - first) : "";
        }
    }
}