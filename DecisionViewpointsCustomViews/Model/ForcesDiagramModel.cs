﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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

        public List<EAElement> GetDecisions()
        {
            var repository = EARepository.Instance;
            return (from diagramObject in _diagram.GetElements()
                    select repository.GetElementByID(diagramObject.ElementID)
                    into element where element.IsDecision() select element).ToList();
        }

        public List<EAElement> GetRequirements()
        {
            var repository = EARepository.Instance;
            return (from diagramObject in _diagram.GetElements()
                    select repository.GetElementByID(diagramObject.ElementID)
                    into element where element.IsRequirement() select element).ToList();
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

        public Dictionary<string, Dictionary<string, string>> GetRatings()
        {
            var repository = EARepository.Instance;
            var data = new Dictionary<string, Dictionary<string, string>>();
            foreach (var diagramObject in _diagram.GetElements())
            {
                var element = repository.GetElementByID(diagramObject.ElementID);
                var reqConcRating = new Dictionary<string, string>();
                foreach (var taggedValue in element.TaggedValues)
                {
                    if (!taggedValue.Name.Split(':')[0].Equals("r")) continue;
                    reqConcRating.Add(taggedValue.Name, taggedValue.Value);
                }
                data.Add(element.GUID, reqConcRating);
            }
            return data;
        }

        public void SaveRatings(Dictionary<string, Dictionary<string, string>> data)
        {
            // validate the ratings (++, +, blank, -, --, X, ?) ???
            var repository = EARepository.Instance;
            foreach (var decision in data)
            {
                var element = repository.GetElementByGUID(decision.Key);
                foreach (var reqConcRating in decision.Value)
                {
                    if (element.GetTaggedValue(reqConcRating.Key) != null)
                        element.UpdateTaggedValue(reqConcRating.Key, reqConcRating.Value);
                    else
                        element.AddTaggedValue(reqConcRating.Key, reqConcRating.Value);
                }
            }
        }
    }
}