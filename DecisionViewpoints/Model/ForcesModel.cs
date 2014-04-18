using System;
using System.Collections.Generic;
using System.Linq;
using EAFacade.Model;

namespace DecisionViewpoints.Model
{
    public class ForcesModel : IForcesModel
    {
        private readonly List<IForcesModelObserver> _observers = new List<IForcesModelObserver>();
        private EADiagram _diagram;

        public ForcesModel(EADiagram diagramModel)
        {
            DiagramModel = diagramModel;
            Name = CreateForcesTabName(diagramModel.Name);
            DiagramName = diagramModel.Name;
        }

        public string Name { get; set; }
        public string DiagramName { get; private set; }

        public string DiagramGUID
        {
            get { return _diagram.GUID; }
        }

        public EADiagram DiagramModel
        {
            set
            {
                _diagram = value;
                Notify();
            }
        }

        public void AddObserver(IForcesModelObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IForcesModelObserver observer)
        {
            _observers.Remove(observer);
        }

        // Get Decision from Diagram and Topics that are on the diagram
        public EAElement[] GetDecisions()
        {
            EARepository repository = EARepository.Instance;
            EAElement[] topics = (from diagramObject in _diagram.GetElements()
                                  select repository.GetElementByID(diagramObject.ElementID)
                                  into element
                                  where element.IsTopic()
                                  select element).ToArray();


            IEnumerable<EAElement> decisionsFromTopic =
                (from EAElement topic in topics select topic.GetDecisionsForTopic()).SelectMany(x => x);


            IEnumerable<EAElement> decisionsDirectlyFromDiagram = (from diagramObject in _diagram.GetElements()
                                                                   select
                                                                       repository.GetElementByID(diagramObject.ElementID)
                                                                   into element where element.IsDecision()
                                                                   select element);

            return decisionsFromTopic.Union(decisionsDirectlyFromDiagram).ToArray();
        }

        public EAElement[] GetRequirements()
        {
            EARepository repository = EARepository.Instance;
            return (from diagramObject in _diagram.GetElements()
                    select repository.GetElementByID(diagramObject.ElementID)
                    into element where element.IsRequirement() select element).ToArray();
        }

        public Dictionary<EAElement, List<EAElement>> GetConcernsPerRequirement()
        {
            var requirementConcernDictionary = new Dictionary<EAElement, List<EAElement>>();
            foreach (EAElement requirement in GetRequirements())
            {
                List<EAElement> concerns =
                    requirement.GetConnectedConcerns().Where(concern => _diagram.Contains(concern)).ToList();
                requirementConcernDictionary.Add(requirement, concerns);
            }
            return requirementConcernDictionary;
        }

        [Obsolete("use reqPerConc", true)]
        public Dictionary<EAElement, List<EAElement>> GetConcerns()
        {
            EARepository repository = EARepository.Instance;
            var requirementsConcerns = new Dictionary<EAElement, List<EAElement>>();
            foreach (EADiagramObject diagramObject in _diagram.GetElements())
            {
                EAElement concern = repository.GetElementByID(diagramObject.ElementID);
                if (!concern.IsConcern()) continue;
                foreach (EAElement connectedRequirement in 
                    concern.GetConnectedRequirements()
                           .Where(connectedRequirement => _diagram.Contains(connectedRequirement)))
                {
                    if (requirementsConcerns.ContainsKey(connectedRequirement))
                    {
                        requirementsConcerns[connectedRequirement].Add(concern);
                    }
                    else
                    {
                        if (connectedRequirement.IsRequirement())
                            requirementsConcerns.Add(connectedRequirement, new List<EAElement> {concern});
                    }
                }
            }
            return requirementsConcerns;
        }

        public List<Rating> GetRatings()
        {
            var data = new List<Rating>();
            foreach (
                EAElement element in
                    GetDecisions())
            {
                data.AddRange(from taggedValue in element.TaggedValues
                              where Rating.IsForcesTaggedValue(taggedValue.Name)
                              select new Rating
                                  {
                                      DecisionGUID = element.GUID,
                                      RequirementGUID = Rating.GetReqGUIDFromTaggedValue(taggedValue.Name),
                                      ConcernGUID = Rating.GetConcernGUIDFromTaggedValue(taggedValue.Name),
                                      Value = taggedValue.Value
                                  });
            }
            return data;
        }

        public void SaveRatings(List<Rating> data)
        {
            EARepository repository = EARepository.Instance;
            foreach (Rating rating in data)
            {
                EAElement decision = repository.GetElementByGUID(rating.DecisionGUID);
                if (decision == null) continue;
                string forcesTaggedValue = Rating.ConstructForcesTaggedValue(rating.RequirementGUID, rating.ConcernGUID);
                if (decision.GetTaggedValue(forcesTaggedValue) != null)
                    decision.UpdateTaggedValue(forcesTaggedValue, rating.Value);
                else
                    decision.AddTaggedValue(forcesTaggedValue, rating.Value);
            }
        }

        private void Notify()
        {
            foreach (IForcesModelObserver observer in _observers)
            {
                observer.Update(this);
            }
        }

        public static string CreateForcesTabName(string diagramName)
        {
            return String.Format("{0} (Forces)", diagramName);
        }

        /*
        //angor START task159
        public static void PrintRequirementInfo(String value)
        {
            var key = value.Split(':')[2];
            var obj =EARepository.Instance.GetElementByGUID(key);
            MessageBox.Show("Value: " + key + 
                "\nWhat is it? (Type): " + obj.Type
                +"\nMetatype: " +obj.MetaType
                +"\nName: " + obj.Name);
        }
        //angor END task159
         */
    }
}