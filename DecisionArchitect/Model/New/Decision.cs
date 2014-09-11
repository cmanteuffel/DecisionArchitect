using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
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
        private IList<IDecisionRelation> _alternatives;
        private string _author;
        private DateTime _modified;
        private string _name;
        private string _rationale;
        private IList<IDecisionRelation> _relatedDecisions;
        private string _state;

        private Decision()
        {
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
            set { SetField(ref _state, value, "State"); }
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


        public ITopic Topic { get; private set; }
        public IList<IHistoryEntry> History { get; private set; }
        public IList<ITraceLink> Traces { get; private set; }

        //!lazy loading to avoid cyclic loading of alternatives. 
        public IList<IDecisionRelation> Alternatives
        {
            get
            {
                if (_alternatives == null)
                {
                    IEAElement element = EAMain.Repository.GetElementByGUID(GUID);
                    _alternatives = LoadAlternatives(element);
                }
                return _alternatives;
            }
        }

        //!lazy loading to avoid cyclic loading of related decisions. 
        public IList<IDecisionRelation> RelatedDecisions
        {
            get
            {
                if (_relatedDecisions == null)
                {
                    IEAElement element = EAMain.Repository.GetElementByGUID(GUID);
                    _relatedDecisions = LoadRelations(element);
                }
                return _relatedDecisions;
            }
        }

        public IList<IForceEvaluation> Forces { get; private set; }
        public IList<IStakeholderAction> Stakeholders { get; private set; }

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

            if (!element.Stereotype.Equals(State))
            {
                History.Add(new HistoryEntry(this, element.Stereotype, element.Modified));
                element.UpdateTaggedValue(EATaggedValueKeys.DecisionStateModifiedDate,
                                          Modified.ToString(CultureInfo.InvariantCulture));
                element.UpdateTaggedValue(EATaggedValueKeys.DecisionState, State);
            }
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
            return true;
        }


        public void DiscardChanges()
        {
            IEAElement element = LoadElementFromRepository();
            LoadDecisionDataFromElement(element);
        }

        public static IDecision Load(IEAElement element)
        {
            var decision = new Decision();
            decision.LoadDecisionDataFromElement(element);
            return decision;
        }


        /// <summary>
        ///     Loads information from EAelement and converts them into domain model.
        /// </summary>
        /// <param name="element"></param>
        private void LoadDecisionDataFromElement(IEAElement element)
        {
            if (element == null) throw new Exception();
            GUID = element.GUID;
            ID = element.ID;
            Name = element.Name;
            State = element.Stereotype;
            Modified = element.Modified;
            Author = element.Author;
            Rationale = LoadRationale(element);
            //Topic change not yet possible.
            Topic = LoadTopic(element);
            History = LoadHistory(element);
            Forces = LoadForces(element);
            Traces = LoadTraces(element);
            Stakeholders = LoadStakeholder(element);
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

        private IList<IHistoryEntry> LoadHistory(IEAElement element)
        {
            return
                element.GetTaggedValuesByName(EATaggedValueKeys.DecisionStateChange)
                       .Select(tv => (IHistoryEntry) new HistoryEntry(this, tv))
                       .ToList();
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

        private IList<IForceEvaluation> LoadForces(IEAElement element)
        {
            return
                element.TaggedValues.Where(tv => tv.Name.StartsWith(EATaggedValueKeys.ForceEvaluation))
                       .Select(tv => (IForceEvaluation) new ForceEvaluation(this, tv))
                       .ToList();
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

        private IList<ITraceLink> LoadTraces(IEAElement element)
        {
            return element.GetTracedElements().Select(t => (ITraceLink) new TraceLink(t.GUID)).ToList();
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

        private IList<IDecisionRelation> LoadAlternatives(IEAElement element)
        {
            return
                element.FindConnectors(EAConstants.RelationMetaType, EAConstants.RelationAlternativeFor)
                       .Select(a => (IDecisionRelation) new DecisionRelation(this, a))
                       .ToList();
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

        private IList<IDecisionRelation> LoadRelations(IEAElement element)
        {
            return
                element.FindConnectors(EAConstants.RelationMetaType, EAConstants.RelationDependsOn,
                                       EAConstants.RelationExcludedBy, EAConstants.RelationCausedBy,
                                       EAConstants.RelationReplaces)
                       .Select(a => (IDecisionRelation) new DecisionRelation(this, a))
                       .ToList();
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

        private IList<IStakeholderAction> LoadStakeholder(IEAElement element)
        {
            return
                element.GetConnectors()
                       .Where(connector => connector.IsAction() && EAMain.IsStakeholder(connector.GetClient()))
                       .Select(sa => (IStakeholderAction) new StakeholderAction(this, sa))
                       .ToList();
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