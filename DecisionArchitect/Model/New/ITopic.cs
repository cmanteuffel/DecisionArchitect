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
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Model.New
{
    public interface ITopic : IPersistableModel, INotifyPropertyChanged 
    {
        string GUID { get; }
        string Name { get; set; }
        string Description { get; set; }
    }

    public class Topic : Entity, ITopic
    {
        private string _description;
        private string _name;
        private bool _changed=false;


        private Topic()
        {
        }

        public bool Changed
        {
            get { return _changed; }
            private set { SetField(ref _changed, value, "Changed"); }
        }

        public bool SaveChanges()
        {
            IEAElement element = EAMain.Repository.GetElementByGUID(GUID);
            if (null == element || !EAMain.IsTopic(element)) throw new Exception("element null or not a topic");
            element.Name = Name;
            SaveDescription(element);
            Changed = false;
            return true;
        }

        public void DiscardChanges()
        {
            IEAElement element = EAMain.Repository.GetElementByGUID(GUID);
            LoadTopicDataFromElement(element);
        }

        public string GUID { get; private set; }

        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, "Name"); }
        }

        public string Description
        {
            get { return _description; }
            set { SetField(ref _description, value, "Description"); }
        }

        public static ITopic Load(IEAElement element)
        {
            var topic = new Topic();
            topic.LoadTopicDataFromElement(element);
            return topic;
        }

        private void LoadTopicDataFromElement(IEAElement element)
        {
            if (null == element) throw new ArgumentNullException();
            if (!EAMain.IsTopic(element)) throw new ArgumentException("not a topic");

            GUID = element.GUID;
            Name = element.Name;
            Description = LoadDescription(element);
            Changed = false;
        }

        /// <summary>
        ///     Saves Rationale field into LinkedDocument
        /// </summary>
        /// <param name="element"></param>
        public void SaveDescription(IEAElement element)
        {
            //_element.Notes = Rationale;
            using (var tempFiles = new TempFileCollection())
            {
                string fileName = tempFiles.AddExtension("rtf");
                using (var file = new StreamWriter(fileName))
                {
                    file.WriteLine(Description);
                }
                element.LoadFileIntoLinkedDocument(fileName);
            }
        }

        /// <summary>
        ///     Loads Rationale from LinkedDocument
        /// </summary>
        /// <param name="element"></param>
        private string LoadDescription(IEAElement element)
        {
            var rtf = new RichTextBox {Rtf = element.GetLinkedDocument()};
            return rtf.Text;
        }

        private void UpdateChangeFlag(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Changed")) return;
            Changed = true;
        }
    }
}