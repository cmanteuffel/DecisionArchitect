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
    Mathieu Kalksma (University of Groningen)
*/

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DecisionArchitect.Utilities;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Model
{
    public interface ITopic : IPersistableModel, INotifyPropertyChanged
    {
        string GUID { get; }
        string Name { get; set; }
        string Description { get; set; }
        int ID { get; }
        IEnumerable<IEAElement> GetDecisionsForTopic();
        BindingList<IDecision> Decisions { get; }
        BindingList<ITopicForceEvaluation> Forces { get; }
        BindingList<IStakeholder> Stakeholders { get; }
        BindingList<DAFile> Files { get; }
        IEnumerable<string> GetConcerns(IForce force);
        IEAElement Element { get; }
        DateTime Modified { get; }
        string Author { get; }
    }

    public class Topic : Entity, ITopic
    {

        private bool _changed;
        private string _description;
        private string _name;
        private DateTime _modified;
        private string _author;
        public BindingList<IDecision> Decisions { get; private set; }

        public BindingList<ITopicForceEvaluation> Forces { get; private set; }
        public BindingList<IStakeholder> Stakeholders { get; private set; }
        public BindingList<DAFile> Files { get; private set; }

        public IEAElement Element
        {
            get { return EAMain.Repository.GetElementByGUID(GUID); }
        }

        private Topic()
        {
            Decisions = new SortableBindingList<IDecision>();
            Stakeholders = new SortableBindingList<IStakeholder>();
        }

        public bool Changed
        {
            get { return _changed; }
            private set { SetField(ref _changed, value, "Changed"); }
        }

        public DateTime Modified
        {
            get { return _modified; }
            set { SetField(ref _modified, value, "Modified"); }
        }

        public string Author
        {
            get { return _author; }
            set { SetField(ref _author, value, "Author"); }
        }


        public bool SaveChanges()
        {
            var element = EAMain.Repository.GetElementByGUID(GUID);
            if (null == element || !EAMain.IsTopic(element)) throw new Exception("element null or not a topic");
            element.Name = Name;
            element.Author = Author;
            element.Modified = DateTime.Now;
            SaveDescription(element);
            SaveDecisions();
            SaveForces();
            SaveFiles(element);
            element.Update();
            EAMain.Repository.AdviseElementChanged(element.ID);
            Changed = false;
            return true;
        }

        private void SaveDecisions()
        {
            foreach (var decision in Decisions.Where(decision => decision.Changed))
                decision.SaveChanges();
        }

        private void SaveFiles(IEAElement element)
        {
            foreach (var file in Files.Where(x => x.Changed && !x.DoDelete))
                file.SaveChanges();
            for (var i = 0; i < Files.Count; i++)
            {
                if (Files[i].DoDelete)
                    element.DeleteFile(i);
            }
        }

        private void SaveForces()
        {
            foreach (var force in Forces.Where(force => force.Changed))
            {
                force.SaveChanges();
            }
        }


        public void DiscardChanges()
        {
            var element = EAMain.Repository.GetElementByGUID(GUID);
            LoadTopicDataFromElement(element);
            LoadForces(element);
            LoadDecisions();
            LoadFiles(element);
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

        public int ID { get; private set; }

        public static ITopic Load(IEAElement element)
        {
            return Load(element, true);
        }

        public static ITopic Load(IEAElement element, bool loadDecisions)
        {
            var topic = new Topic();
            topic.LoadTopicDataFromElement(element);
            if (loadDecisions)
            {
                topic.LoadDecisions();
                topic.LoadStakeholders();
            }

            topic.LoadForces(element);
            topic.LoadFiles(element);
            return topic;
        }

        private void LoadFiles(IEAElement element)
        {
            Files = new BindingList<DAFile>(element.Files.Select(x => new DAFile(x)).ToList())
            {
                RaiseListChangedEvents = true
            };
            Files.ListChanged += ListMemberChanged;
        }

        private void LoadStakeholders()
        {
            Stakeholders.Clear();
            foreach (var stakeholder in Decisions.SelectMany(decision => decision.Stakeholders).Distinct())
                Stakeholders.Add(stakeholder.Stakeholder);   
        }

        private void LoadTopicDataFromElement(IEAElement element)
        {
            if (null == element) throw new ArgumentNullException();
            if (!EAMain.IsTopic(element)) throw new ArgumentException("not a topic");

            PropertyChanged -= UpdateChangeFlag;
            GUID = element.GUID;
            ID = element.ID;
            Name = element.Name;
            Description = LoadDescription(element);
            Changed = false;
            Author = element.Author;
            Modified = element.Modified;
            PropertyChanged += UpdateChangeFlag;

        }

        private void ListMemberChanged(object sender, ListChangedEventArgs listChangedEventArgs)
        {
            Changed = true;
            
        }

        /// <summary>
        ///     Saves Rationale field into LinkedDocument
        /// </summary>
        /// <param name="element"></param>
        private void SaveDescription(IEAElement element)
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

        public IEnumerable<IEAElement> GetDecisionsForTopic()
        {
            IEAElement element = EAMain.Repository.GetElementByGUID(GUID);
            if (!EAMain.IsTopic(element))
            {
                throw new Exception("EAElementImpl is not a topic");
            }

            return from IEAElement e in element.GetElements() where EAMain.IsDecision(e) select e;
        }

        private void LoadForces(IEAElement element)
        {
            Forces = new BindingList<ITopicForceEvaluation>();
            var connectors =
                (from x in element.GetConnectors() where x.MetaType.Equals(EAConstants.ForcesConnectorType) && x.TaggedValueExists(EAConstants.ConcernUID) select x);
            foreach (var connector in connectors)
            {
                var force = new Force(connector.GetSupplier());
                var concernID = connector.GetTaggedValueByName(EAConstants.ConcernUID);
                Forces.Add(new TopicForceEvaluation(this, force, force.GetConcern(concernID), Decisions));

            }
            Forces.RaiseListChangedEvents = true;
            Forces.ListChanged += ListMemberChanged;
        }

        private void LoadDecisions()
        {
            Decisions.Clear();
            foreach (var decision in GetDecisionsForTopic())
                Decisions.Add(Decision.Load(decision, false));
            var temp = Utils.SortDecisionsByState(Decisions.ToList());
            Decisions = new BindingList<IDecision>(temp);
            Decisions.RaiseListChangedEvents = true;
            Decisions.ListChanged += ListMemberChanged;
        }

        //private const string ConcernUID = "ConcernUID";
        //private const string Weight = "Weight";

        //public void AddForce(IForce force, IConcern concern)
        //{
        //    var concernUID = force.AddConcern(this, concern);
        //    if (concernUID != null)
        //    {
        //        var element = Element;
        //        var forceElement = force.Element;
        //        var forceConnector = element.ConnectTo(forceElement, EAConstants.ForcesConnectorType, EAConstants.ForcesConnectorType);
        //        forceConnector.AddTaggedValue(ConcernUID, concernUID);
        //        forceConnector.AddTaggedValue(Weight, string.Empty);

        //        Forces.Add(new TopicForceEvaluation(this, force, concern, Decisions));
        //    }
        //}

        public IEnumerable<string> GetConcerns(IForce force)
        {
            var topicElement = EAMain.Repository.GetElementByGUID(GUID);

            return (from x in topicElement.GetConnectors()
                    where
                        x.MetaType.Equals(EAConstants.ForcesConnectorType) && x.GetSupplier().GUID.Equals(force.ForceGUID) &&
                        x.TaggedValueExists(EAConstants.ConcernUID)
                    select x.GetTaggedValueByName(EAConstants.ConcernUID));
        }        
    }
}