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
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DecisionViewpoints.Logic.Chronological;
using DecisionViewpoints.Logic.Detail;
using DecisionViewpoints.View;
using EAFacade;
using EAFacade.Model;

namespace DecisionViewpoints.Model
{
    public static class DecisionDataTags
    {
        public const string Issue = "{issue}";
        public const string DecisionText = "{decision}";
        public const string Arguments = "{arguments}";
    }

    public class Decision : IDecision
    {
        private const int SerialVersionID = 1;
        private readonly IEAElement _element;

       // private bool _decisionDataChanged;

        public Decision(IEAElement element)
        {
            _element = element;
            Load();
        }

        public string GUID
        {
            get { return _element.GUID; }
        }

        public int ID
        {
            get { return _element.ID; }
        }

        public string Name
        {
            get { return _element.Name; }
            set
            {
                if(_element.Name != value)
                {
                    _element.Name = value;
                 }
            }
        }

        public string State
        {
            get { return _element.StereotypeList; }
            set
            {
                if (_element.StereotypeList != value)
                {
                    _element.StereotypeList = value;
                    //setChanged();
                }
            }
        }

        public string Rationale
        {
            get;
            set;
        }

        public DateTime Modified 
        {
            get { return _element.Modified; }
            set { _element.Modified = value; } 
        }

        public string Author
        {
            get { return _element.Author; }
            set 
            {
                if (_element.Author != value)
                {
                    _element.Author = value;
                   // setChanged();
                }
            }
        }

        public Topic Topic
        {
            get
            {
                if (_element.ParentElement == null || !_element.ParentElement.IsTopic()) return null;
                return new Topic(_element.ParentElement);
            }
            set
            {
                if (!_element.ParentElement.Equals(value.GetElement()))
                {
                    _element.ParentElement = value.GetElement();
                }
        }
        }

        public List<IEAConnector> Connectors
        {
            get { return _element.GetConnectors(); }
        }

        public bool HasTopic()
        {
            if (_element.ParentElement == null) return false;
            return _element.ParentElement.IsTopic();
        }

        public IList<DecisionStateChange> History
        {
            get { return GetHistory(); }
            set { SetHistory(value);  }
        }

        public IEnumerable<Rating> GetForces()
        {
            IEnumerable<Rating> forces = from taggedValue in _element.TaggedValues
                                         where Rating.IsForcesTaggedValue(taggedValue.Name)
                                         select new Rating
                                             {
                                                 DecisionGUID = _element.GUID,
                                             ForceGUID = Rating.GetForceGUIDFromTaggedValue(taggedValue.Name),
                                                 ConcernGUID = Rating.GetConcernGUIDFromTaggedValue(taggedValue.Name),
                                                 Value = taggedValue.Value
                                             };
            return forces;
        }

        public IList<DecisionStateChange> GetHistory()
        {
            var history = new List<DecisionStateChange>();
            IEnumerable<string> values = _element.TaggedValues.Where(tv => IsHistoryTag(tv.Name)).Select(tv => tv.Value);
            foreach (string value in values)
            {
                history.Add(new DecisionStateChange
                    {
                        DateModified = GetDateModifiedFromTaggedValue(value),
                        Element = GetElement(),
                        State = GetStateFromTaggedValue(value)
                    });
            }
            return history;
        }

        public void SetHistory(IList<DecisionStateChange> history)
        {
            // Remove the old history
            _element.RemoveAllWithName(EATaggedValueKeys.DecisionStateChange);
            
            // Add the new History Data
            foreach (DecisionStateChange dsc in history)
            {
                var data = String.Format("{0}|{1}", dsc.State,
                                                dsc.DateModified.ToString(CultureInfo.InvariantCulture));
                var name = EATaggedValueKeys.DecisionStateChange;
                _element.AddTaggedValue(name, data);
            }
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

        public void Reload()
        {
            Load();
        }

        public void Save()
        {
            var extraData = new StringBuilder();
            extraData.Append(String.Format("{0}{1}{2}", DecisionDataTags.DecisionText, Rationale,
                                           DecisionDataTags.DecisionText));

            //_element.Notes = Rationale;
            using (var tempFiles = new TempFileCollection())
            {
                string fileName = tempFiles.AddExtension("rtf");
                using (var file = new StreamWriter(fileName))
                {
                    file.WriteLine(extraData.ToString());
                }
                _element.LoadLinkedDocument(fileName);
            }


            string version = GetElement().GetTaggedValue(EATaggedValueKeys.DecisionSerialVersionID);
            if (version == null)
            {
                GetElement()
                    .AddTaggedValue(EATaggedValueKeys.DecisionSerialVersionID,
                                    SerialVersionID.ToString(CultureInfo.InvariantCulture));
            }
            else
            {
                GetElement()
                    .UpdateTaggedValue(EATaggedValueKeys.DecisionSerialVersionID,
                                       SerialVersionID.ToString(CultureInfo.InvariantCulture));
            }
            //MessageBox.Show("Decision Save " + Name);

            _element.Update();
            IEARepository repository = EAFacade.EA.Repository;
            repository.AdviseElementChanged(_element.ID);
        }

        public void ShowDetailView()
        {
            IEARepository repository = EAFacade.EA.Repository;
            if (repository.IsTabOpen(Name) > 0)
            {
                FocusTab();
            } else {
                OpenNewDecisionTab();
            }
           
        }

        private void OpenNewDecisionTab()
        {
            IDetailViewController detailViewController = EAFacade.EA.Repository.AddTab(Name,
                                                    "DecisionViewpoints.DetailViewController");
            detailViewController.SetDecision(this);
            if (_element.ParentElement != null)
            {
                detailViewController.SetTopic(new Topic(_element.ParentElement));
            }
            SynchronizationManager.Instance.Subscribe(_element.GUID, detailViewController, Name);
        }

        public void FocusTab()
        {
            EAFacade.EA.Repository.ActivateTab(Name);
            SynchronizationManager.Instance.Update(_element.GUID);
        }



        public IEAElement GetElement()
        {
            return _element;
        }

        //public bool IsRecentlyChanged()
        //{
        //    return _decisionDataChanged;
        //}

        private void Load()
        {
            Rationale = GetSubstring(DecisionDataTags.DecisionText);
        }


        private static String GetStateFromTaggedValue(string value)
        {
            return value.Split('|')[0];
        }

        private static DateTime GetDateModifiedFromTaggedValue(string value)
        {
            var dateString = value.Split('|')[1];
            return Utilities.TryParseDateTime(dateString, DateTime.MinValue);
        }

        private static bool IsHistoryTag(string name)
        {
            return name.StartsWith(EATaggedValueKeys.DecisionStateChange);
        }

        private string GetSubstring(string tag)
        {
            var rtf = new RichTextBox { Rtf = _element.GetLinkedDocument()};
            /*var first = _element.Notes.IndexOf(tag, StringComparison.Ordinal) + tag.Length;
            var last = _element.Notes.LastIndexOf(tag, StringComparison.Ordinal);*/
            int first = rtf.Text.IndexOf(tag, StringComparison.Ordinal) + tag.Length;
            int last = rtf.Text.LastIndexOf(tag, StringComparison.Ordinal);
            return last > first ? rtf.Text.Substring(first, last - first) : "";
        }

        private int GetSerialVersionID()
        {
            string serialVersionString = GetElement().GetTaggedValue(EATaggedValueKeys.DecisionSerialVersionID) ?? "0";
            return EAUtilities.ParseToInt32(serialVersionString, -1);
        }

        public string DecisionSerialVersionID()
        {
            return GetElement().GetTaggedValue(EATaggedValueKeys.DecisionSerialVersionID) ?? "0";
        }

        public void AddHistory(string newState, DateTime dateModified)
        {
            GetElement().AddTaggedValue(EATaggedValueKeys.DecisionStateChange,
                                   String.Format("{0}|{1}", newState,
                                                 dateModified.ToString(CultureInfo.InvariantCulture)));
        }

        public bool ReplaceHistoryEntryForState(string state, DateTime oldDatemodified, DateTime newDateModified)
        {

            string removeData = String.Format("{0}|{1}", state, oldDatemodified.ToString(CultureInfo.InvariantCulture));
            _element.UpdateTaggedValue(EATaggedValueKeys.DecisionStateChange, removeData);

            if (GetElement().DeleteTaggedValue(EATaggedValueKeys.DecisionStateChange, removeData))
            {
                AddHistory(state, newDateModified);
                return true;
            }
            return false;
        }
    }
}
