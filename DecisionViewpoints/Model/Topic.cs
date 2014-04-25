/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
*/

using System;
using System.Windows.Forms;
using EAFacade.Model;

namespace DecisionViewpoints.Model
{
    public static class TopicDataTags
    {
        public const string Name = "{topic}";
        public const string Description = "{description}";
    }

    public class Topic : ITopic
    {
        private readonly IEAElement _element;

        public Topic(IEAElement element)
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

        public string Description
        {
            get { return GetSubstring(TopicDataTags.Description); }
        }

        public void Save(string extraData)
        {
            _element.Update();
            IEARepository repository = EAFacade.EA.Repository;
            repository.AdviseElementChanged(_element.ID);
        }

        public void LoadLinkedDocument(string fileName)
        {
            _element.LoadLinkedDocument(fileName);
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

        public IEAElement GetElement()
        {
            return _element;
        }

        /*
        public void AddObserver(ITopicObserver observer)
        {
            throw new NotImplementedException();
        }

        public void RemoveObserver(ITopicObserver observer)
        {

            throw new NotImplementedException();
        }
         */
    }
}
