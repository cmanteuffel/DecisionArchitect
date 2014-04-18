using System;
using System.Collections.Generic;
using EAFacade.Model;

namespace DecisionViewpointsCustomViews.Model
{
    public static class DecisionDataTags
    {
        public const string Issue = "issue:";
        public const string DecisionText = "decision:";
        public const string Alternatives = "alternatives:";
        public const string Arguments = "arguments:";
        public const string End = "end";
    }

    public class Decision
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
            get { return _element.Stereotype; }
            set { _element.Stereotype = value; }
        }

        public string Issue
        {
            get { return GetSubstring(DecisionDataTags.Issue, DecisionDataTags.DecisionText); }
        }

        public string DecisionText
        {
            get { return GetSubstring(DecisionDataTags.DecisionText, DecisionDataTags.Alternatives); }
        }

        public string Alternatives
        {
            get { return GetSubstring(DecisionDataTags.Alternatives, DecisionDataTags.Arguments); }
        }

        public string Arguments
        {
            get { return GetSubstring(DecisionDataTags.Arguments, DecisionDataTags.End); }
        }

        public void Save(string extraData)
        {
            _element.Notes = extraData;
            _element.Update();
            //element.Refresh();
            //repository.AdviseElementChanged(element.ID);
            //element.ParentPackage.RefreshElements();
            //repository.RefreshModelView(element.ParentPackage.ID);
            /*repository.RefreshOpenDiagrams(false);*/
            /*foreach (var diagram in element.GetDiagrams())
            {
                repository.ReloadDiagram(diagram.ID);
            }*/
        }

        public List<EAConnector> GetConnectors()
        {
            return _element.GetConnectors();
        }

        private string GetSubstring(string first, string last)
        {
            var index1 = _element.Notes.IndexOf(first, StringComparison.Ordinal) + first.Length;
            var index2 = _element.Notes.LastIndexOf(last, StringComparison.Ordinal);
            return index2 > index1 ? _element.Notes.Substring(index1, index2 - index1) : "";
        }
    }
}
