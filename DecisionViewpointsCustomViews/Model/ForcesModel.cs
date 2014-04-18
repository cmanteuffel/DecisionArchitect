using System.Collections.Generic;
using System.Linq;
using EAFacade.Model;

namespace DecisionViewpointsCustomViews.Model
{
    public class ForcesModel : ICustomViewModel
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
                              where IsReqGUIDTaggedValue(taggedValue.Name)
                              select new Rating
                                  {
                                      DecisionGUID = element.GUID,
                                      RequirementGUID = GetReqGUIDFromTaggedValue(taggedValue.Name),
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
                var reqTaggedValue = ConstructReqGUIDTaggedValue(rating.RequirementGUID);
                if (decision.GetTaggedValue(reqTaggedValue) != null)
                    decision.UpdateTaggedValue(reqTaggedValue, rating.Value);
                else
                    decision.AddTaggedValue(reqTaggedValue, rating.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string ConstructReqGUIDTaggedValue(string value)
        {
            return string.Format("r:{0}", value);
        }

        /// <summary>
        /// Returns just the GUID from the requirement GUID tagged value.
        /// The format of the requirement GUID tagged value is r:{GUID}.
        /// </summary>
        /// <param name="value">The taggged value name.</param>
        /// <returns></returns>
        private static string GetReqGUIDFromTaggedValue(string value)
        {
            return value.Split(':')[1];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsReqGUIDTaggedValue(string value)
        {
            return value.Split(':')[0].Equals("r");
        }
    }
}