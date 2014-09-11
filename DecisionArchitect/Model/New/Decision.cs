using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DecisionArchitect.Utilities;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Model.New
{
    /// <summary>
    ///     Doamin class to hide access to EAMain concepts
    ///     Changes are not written to the repository until SaveChangs has been explicitly called
    ///     ! Changes to linked domain objects such as Topic or other decisions also need to be explicilty saved.
    ///     ! Changes to domain entities such as I*Relation, or I*ForceEvaluation are automatically saved when SaveChagnes is called.
    /// </summary>
    public class Decision : Entity, IDecision
    {
        private string _author;
        private bool _changed;
        private DateTime _modified;
        private string _name;
        private string _rationale;

        private string _state;

        private Decision()
        {
            History = new SortableBindingList<IHistoryEntry>();
            Alternatives = new BindingList<IDecisionRelation>();
            RelatedDecisions = new BindingList<IDecisionRelation>();
            Traces = new BindingList<ITraceLink>();
            Stakeholders = new BindingList<IStakeholderAction>();
            Forces = new BindingList<IForceEvaluation>();
        }

        public string GUID { get; private set; }
        public int ID { get; private set; }

        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, "Name"); }
        }

        public string State
        {
            get { return _state; }
            set { SetField(ref _state, value.ToLower(), "State"); }
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

        public string Rationale
        {
            get { return _rationale; }
            set { SetField(ref _rationale, value, "Rationale"); }
        }

        public bool Changed
        {
            get { return _changed; }
            private set { SetField(ref _changed, value, "Changed"); }
        }

        public ITopic Topic { get; private set; }
        public BindingList<IHistoryEntry> History { get; private set; }
        public BindingList<ITraceLink> Traces { get; private set; }
        public BindingList<IDecisionRelation> Alternatives { get; private set; }
        public BindingList<IDecisionRelation> RelatedDecisions { get; private set; }
        public BindingList<IForceEvaluation> Forces { get; private set; }
        public BindingList<IStakeholderAction> Stakeholders { get; private set; }

        public bool HasTopic()
        {
            return Topic != null;
        }


        public bool SaveChanges()
        {
            if (("").Equals(GUID) && ID == 0)
            {
                throw new Exception();
            }
            IEARepository repository = EAMain.Repository;
            IEAElement element = repository.GetElementByGUID(GUID);

            element.Name = Name;

            if (!element.TaggedValueExists(EATaggedValueKeys.DecisionState))
            {
                element.AddTaggedValue(EATaggedValueKeys.DecisionState, element.Stereotype);
                element.AddTaggedValue(EATaggedValueKeys.DecisionStateModifiedDate,
                                       element.Modified.ToString(CultureInfo.InvariantCulture));
            }

            if (!element.StereotypeList.Equals(State))
            {
                History.Add(new HistoryEntry(this, element.Stereotype, element.Modified));
                element.UpdateTaggedValue(EATaggedValueKeys.DecisionStateModifiedDate,
                                          Modified.ToString(CultureInfo.InvariantCulture));
            }
            element.UpdateTaggedValue(EATaggedValueKeys.DecisionState, State);

            element.StereotypeList = State;
            element.Modified = Modified;
            element.Author = Author;
            SaveRationale(element);
            SaveHistory(element);
            SaveForces(element);
            SaveTraces(element);
            SaveAlternatives(element);
            SaveRelations(element);
            SaveStakeholders(element);
            element.Update();
            repository.AdviseElementChanged(element.ID);
            Changed = false;
            return true;
        }


        public void DiscardChanges()
        {
            IEAElement element = LoadElementFromRepository();
            LoadDecisionDataFromElement(element);
        }

        private void UpdateListChangeFlag(object sender, ListChangedEventArgs listChangedEventArgs)
        {
            switch (listChangedEventArgs.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                case ListChangedType.ItemChanged:
                case ListChangedType.ItemDeleted:
                    Changed = true;
                    break;
            }
        }


        private void UpdateChangeFlag(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Changed")) return;
            Changed = true;
        }

        public static IDecision Load(IEAElement element)
        {
            var decision = new Decision();
            decision.LoadDecisionDataFromElement(element);
            decision.PropertyChanged += decision.UpdateChangeFlag;
            return decision;
        }


        /// <summary>
        ///     Loads information from EAelement and converts them into domain model.
        /// </summary>
        /// <param name="element"></param>
        private void LoadDecisionDataFromElement(IEAElement element)
        {
            if (element == null) throw new Exception();
            RemoveAllChangeListener();
            GUID = element.GUID;
            ID = element.ID;
            Name = element.Name;
            State = element.StereotypeList;
            Modified = element.Modified;
            Author = element.Author;
            Rationale = LoadRationale(element);
            //Topic change not yet possible.
            Topic = LoadTopic(element);
            LoadAlternatives(element);
            LoadRelations(element);
            LoadHistory(element);
            LoadForces(element);
            LoadTraces(element);
            LoadStakeholder(element);
            Changed = false;
            AddAllChangeListener();
        }

        private void AddAllChangeListener()
        {
            if (HasTopic())
            {
                Topic.PropertyChanged += UpdateChangeFlag;
            }
            Alternatives.ListChanged += UpdateListChangeFlag;
            RelatedDecisions.ListChanged += UpdateListChangeFlag;
            History.ListChanged += UpdateListChangeFlag;
            Forces.ListChanged += UpdateListChangeFlag;
            Traces.ListChanged += UpdateListChangeFlag;
            Stakeholders.ListChanged += UpdateListChangeFlag;
            PropertyChanged += UpdateChangeFlag;
        }

        private void RemoveAllChangeListener()
        {
            if (HasTopic())
            {
                Topic.PropertyChanged -= UpdateChangeFlag;
            }
            Alternatives.ListChanged -= UpdateListChangeFlag;
            RelatedDecisions.ListChanged -= UpdateListChangeFlag;
            History.ListChanged -= UpdateListChangeFlag;
            Forces.ListChanged -= UpdateListChangeFlag;
            Traces.ListChanged -= UpdateListChangeFlag;
            Stakeholders.ListChanged -= UpdateListChangeFlag;
            PropertyChanged -= UpdateChangeFlag;
        }


        private ITopic LoadTopic(IEAElement element)
        {
            if (element.ParentElement != null)
            {
                if (EAMain.IsTopic(element.ParentElement))
                {
                    return New.Topic.Load(element.ParentElement);
                }
            }
            return null;
        }


        /// <summary>
        ///     Loads the latest version of the underlying EAelement
        /// </summary>
        /// <returns></returns>
        private IEAElement LoadElementFromRepository()
        {
            if (("").Equals(GUID) && ID == 0)
            {
                throw new Exception();
            }
            return EAMain.Repository.GetElementByGUID(GUID);
        }


        /// <summary>
        ///     Loads Rationale from LinkedDocument
        /// </summary>
        /// <param name="element"></param>
        private string LoadRationale(IEAElement element)
        {
            var rtf = new RichTextBox {Rtf = element.GetLinkedDocument()};
            return rtf.Text;
        }

        /// <summary>
        ///     Saves Rationale field into LinkedDocument
        /// </summary>
        /// <param name="element"></param>
        public void SaveRationale(IEAElement element)
        {
            //_element.Notes = Rationale;
            using (var tempFiles = new TempFileCollection())
            {
                string fileName = tempFiles.AddExtension("rtf");
                using (var file = new StreamWriter(fileName))
                {
                    file.WriteLine(Rationale);
                }
                element.LoadFileIntoLinkedDocument(fileName);
            }
        }

        private void LoadHistory(IEAElement element)
        {
            History.Clear();
            IEnumerable<IHistoryEntry> entries = element.GetTaggedValuesByName(EATaggedValueKeys.DecisionStateChange)
                                                        .Select(tv => (IHistoryEntry) new HistoryEntry(this, tv));
            foreach (IHistoryEntry entry in entries)
            {
                History.Add(entry);
            }
        }

        private void SaveHistory(IEAElement element)
        {
            //first old history needs to be removed but if I do this, then I will delete existing.
            //I did not keep track of those that were deleted from the list. 
            //first need to check which one were deleted, i.e. exist in EAelem but not in this list
            IEnumerable<string> removedHistroyEntries =
                element.GetTaggedValuesByName(EATaggedValueKeys.DecisionStateChange)
                       .Select(tv => tv.GUID)
                       .Except(History.Select(h => h.TaggedValueGUID));
            foreach (string tagGUID in removedHistroyEntries)
            {
                element.RemoveTaggedValueByGUID(tagGUID);
            }

            foreach (IHistoryEntry historyEntry in History)
            {
                historyEntry.SaveChanges();
            }
        }

        private void LoadForces(IEAElement element)
        {
            Forces.Clear();
            IEnumerable<IForceEvaluation> forces =
                element.TaggedValues.Where(tv => tv.Name.StartsWith(EATaggedValueKeys.ForceEvaluation))
                       .Select(tv => (IForceEvaluation) new ForceEvaluation(this, tv));
            foreach (IForceEvaluation force in forces)
            {
                Forces.Add(force);
            }
        }

        private void SaveForces(IEAElement element)
        {
            //see saveHistroy (clone)
            IEnumerable<string> removedForceEvaluations =
                element.TaggedValues.Where(tv => tv.Name.StartsWith(EATaggedValueKeys.ForceEvaluation))
                       .Select(tv => tv.GUID)
                       .Except(Forces.Select(f => f.TaggedValueGUID));
            foreach (string tagGUID in removedForceEvaluations)
            {
                element.RemoveTaggedValueByGUID(tagGUID);
            }

            foreach (IForceEvaluation forceEvaluation in Forces)
            {
                forceEvaluation.SaveChanges();
            }
        }

        private void LoadTraces(IEAElement element)
        {
            Traces.Clear();
            IEnumerable<ITraceLink> traces =
                element.GetTracedElements().Select(t => (ITraceLink) new TraceLink(t.GUID));
            foreach (ITraceLink trace in traces)
            {
                Traces.Add(trace);
            }
        }

        private void SaveTraces(IEAElement element)
        {
            //first need to identify those tracelinks that were removed and those that were added
            // currently traces do not support update and can only be added or removed
            IEAElement[] existingTraces = element.GetTracedElements().ToArray();
            // existing.except(traces) traces that have been deleted
            IEnumerable<string> removedTraces =
                existingTraces.Select(e => e.GUID).Except(Traces.Select(t => t.TracedElementGUID));

            // traces.except(existing) traces that were added
            IEnumerable<string> addedTraces =
                Traces.Select(t => t.TracedElementGUID).Except(existingTraces.Select(e => e.GUID));

            //in order to remove tracelink i need to find the correct connection that connect this and the linked element.
            foreach (string removedTrace in removedTraces)
            {
                IEAConnector connector =
                    element.GetConnectors().FirstOrDefault(c => (c.GetSupplier().GUID.Equals(removedTrace) ||
                                                                 c.GetClient().GUID.Equals(removedTrace))
                                                                &&
                                                                c.Stereotype.Equals(EAConstants.RelationTrace) &&
                                                                c.Type.Equals(EAConstants.AbstractionMetaType));
                if (null != connector)
                {
                    element.RemoveConnector(connector);
                }
            }

            foreach (string addedTrace in addedTraces)
            {
                IEAElement suppliedElement = EAMain.Repository.GetElementByGUID(addedTrace);
                element.ConnectTo(suppliedElement, EAConstants.AbstractionMetaType, EAConstants.RelationTrace);
            }
        }

        private void LoadAlternatives(IEAElement element)
        {
            Alternatives.Clear();
            IEnumerable<IDecisionRelation> alternatives =
                element.FindConnectors(EAConstants.RelationMetaType, EAConstants.RelationAlternativeFor)
                       .Select(a => (IDecisionRelation) new DecisionRelation(this, a));

            foreach (IDecisionRelation alternative in alternatives)
            {
                Alternatives.Add(alternative);
            }
        }

        private void SaveAlternatives(IEAElement element)
        {
            IEARepository repository = EAMain.Repository;
            IEnumerable<string> deleted =
                element.FindConnectors(EAConstants.RelationMetaType, EAConstants.RelationAlternativeFor)
                       .Select(c => c.GUID)
                       .Except(Alternatives.Select(a => a.RelationGUID));

            foreach (string connector in deleted)
            {
                element.RemoveConnector(repository.GetConnectorByGUID(connector));
            }

            foreach (IDecisionRelation connector in Alternatives)
            {
                if ("".Equals(connector.RelationGUID) || null == connector.RelationGUID)
                {
                    IEAElement client = repository.GetElementByGUID(connector.Decision.GUID);
                    IEAElement supplier = repository.GetElementByGUID(connector.RelatedDecision.GUID);
                    client.ConnectTo(supplier, EAConstants.RelationMetaType, connector.Type);
                }
            }
        }

        private void LoadRelations(IEAElement element)
        {
            RelatedDecisions.Clear();
            IEnumerable<IDecisionRelation> relations = element.FindConnectors(EAConstants.RelationMetaType,
                                                                              EAConstants.RelationDependsOn,
                                                                              EAConstants.RelationExcludedBy,
                                                                              EAConstants.RelationCausedBy,
                                                                              EAConstants.RelationReplaces)
                                                              .Select(
                                                                  a => (IDecisionRelation) new DecisionRelation(this, a));
            foreach (IDecisionRelation relation in relations)
            {
                RelatedDecisions.Add(relation);
            }
        }

        private void SaveRelations(IEAElement element)
        {
            IEARepository repository = EAMain.Repository;
            IEnumerable<string> deleted =
                element.FindConnectors(EAConstants.RelationMetaType, EAConstants.RelationDependsOn,
                                       EAConstants.RelationExcludedBy, EAConstants.RelationCausedBy,
                                       EAConstants.RelationReplaces)
                       .Select(c => c.GUID)
                       .Except(RelatedDecisions.Select(a => a.RelationGUID));

            foreach (string connector in deleted)
            {
                element.RemoveConnector(repository.GetConnectorByGUID(connector));
            }

            foreach (IDecisionRelation connector in RelatedDecisions)
            {
                if ("".Equals(connector.RelationGUID) || null == connector.RelationGUID)
                {
                    IEAElement client = repository.GetElementByGUID(connector.Decision.GUID);
                    IEAElement supplier = repository.GetElementByGUID(connector.RelatedDecision.GUID);
                    client.ConnectTo(supplier, EAConstants.RelationMetaType, connector.Type);
                }
            }
        }

        private void LoadStakeholder(IEAElement element)
        {
            Stakeholders.Clear();
            IEnumerable<IStakeholderAction> actions =
                element.GetConnectors()
                       .Where(connector => connector.IsAction() && EAMain.IsStakeholder(connector.GetClient()))
                       .Select(sa => (IStakeholderAction) new StakeholderAction(this, sa));
            foreach (IStakeholderAction action in actions)
            {
                Stakeholders.Add(action);
            }
        }

        private void SaveStakeholders(IEAElement element)
        {
            IEARepository repository = EAMain.Repository;
            IEnumerable<string> deleted =
                element.GetConnectors().Where(connector => connector.IsAction() && connector.ClientId != element.ID)
                       .Select(c => c.GUID)
                       .Except(Stakeholders.Select(a => a.ConnectorGUID));

            foreach (string connector in deleted)
            {
                element.RemoveConnector(repository.GetConnectorByGUID(connector));
            }

            foreach (IStakeholderAction connector in Stakeholders)
            {
                if ("".Equals(connector.ConnectorGUID) || null == connector.ConnectorGUID)
                {
                    IEAElement client = repository.GetElementByGUID(GUID);
                    IEAElement supplier = repository.GetElementByGUID(connector.Stakeholder.GUID);
                    client.ConnectTo(supplier, EAConstants.ActionMetaType, connector.Action);
                }
            }
        }
    }
}