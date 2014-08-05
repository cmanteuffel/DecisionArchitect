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
using System.Drawing;
using System.Windows.Forms;
using EA;
using EAFacade.Model;
using System.Text;
using System.CodeDom.Compiler;
using System.IO;

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

        //public string Description
        //{
        //    get { return _element.Notes; }
        //    set
        //    {
        //        if (_element.Notes != value)
        //        {
        //            _element.Notes = value;
        //        }
        //    }
        //}

        public string Description { get; set; }
   
        public void Save()
        {
            var extraData = new StringBuilder();
            extraData.Append(string.Format("{0}{1}{2}", TopicDataTags.Description, Description,
                                           TopicDataTags.Description));

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

        private void Load()
        {
            Description = GetSubstring(TopicDataTags.Description);
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
    }
}
