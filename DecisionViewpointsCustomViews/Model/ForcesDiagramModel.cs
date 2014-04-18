using System.Collections.Generic;
using System.Linq;
using EAFacade.Model;

namespace DecisionViewpointsCustomViews.Model
{
    public class ForcesDiagramModel : ICustomViewModel
    {
        private readonly List<ICustomViewModelObserver> _observers = new List<ICustomViewModelObserver>();
        private EADiagram _diagram;
        public string Name { get; set; }

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

        public void AddObserver(ICustomViewModelObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(ICustomViewModelObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public EAElement[] GetDecisions()
        {
            var repository = EARepository.Instance;
            return (from diagramObject in _diagram.GetElements()
                    select repository.GetElementByID(diagramObject.ElementID)
                    into element where element.IsDecision() select element).ToArray();
        }

        public EAElement[] GetRequirements()
        {
            var repository = EARepository.Instance;
            return (from diagramObject in _diagram.GetElements()
                    select repository.GetElementByID(diagramObject.ElementID)
                    into element where element.IsRequirement() select element).ToArray();
        }

        public Dictionary<EAElement, List<EAElement>> GetConcerns()
        {
            var repository = EARepository.Instance;
            var requirementsConcerns = new Dictionary<EAElement, List<EAElement>>();
            foreach (var diagramObject in _diagram.GetElements())
            {
                var concern = repository.GetElementByID(diagramObject.ElementID);
                if (!concern.IsConcern()) continue;
                foreach (
                    var connectedRequirement in
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
            var repository = EARepository.Instance;
            var data = new List<Rating>();
            foreach (
                var element in
                    _diagram.GetElements()
                            .Select(diagramObject => repository.GetElementByID(diagramObject.ElementID))
                            .Where(element => element.IsDecision()))
            {
                data.AddRange(from taggedValue in element.TaggedValues
                              where taggedValue.Name.Split(':')[0].Equals("r")
                              select new Rating
                                  {
                                      DecisionGUID = element.GUID,
                                      RequirementGUID = taggedValue.Name,
                                      Value = taggedValue.Value
                                  });
            }
            return data;
        }

        public void SaveRatings(List<Rating> data)
        {
            var repository = EARepository.Instance;
            foreach (var rating in data)
            {
                var decision = repository.GetElementByGUID(rating.DecisionGUID);
                if (decision == null) continue;
                if (decision.GetTaggedValue(rating.RequirementGUID) != null)
                    decision.UpdateTaggedValue(rating.RequirementGUID, rating.Value);
                else
                    decision.AddTaggedValue(rating.RequirementGUID, rating.Value);
            }
        }
    }
}