/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
*/

using System;
using System.Collections.Generic;
using System.Linq;
using EAFacade.Model;

namespace DecisionViewpoints.Model
{
    public class ForcesModel : IForcesModel
    {
        private readonly List<IForcesModelObserver> _observers = new List<IForcesModelObserver>();
        private IEADiagram _diagram;

        public ForcesModel(IEADiagram diagramModel)
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

        public IEADiagram DiagramModel
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
        public IEAElement[] GetDecisions()
        {
            IEARepository repository = EAFacade.EA.Repository;
            IEAElement[] topics = (from diagramObject in _diagram.GetElements()
                                  select repository.GetElementByID(diagramObject.ElementID)
                                  into element
                                  where element.IsTopic()
                                  select element).ToArray();


            IEnumerable<IEAElement> decisionsFromTopic =
                (from IEAElement topic in topics select topic.GetDecisionsForTopic()).SelectMany(x => x);


            IEnumerable<IEAElement> decisionsDirectlyFromDiagram = (from diagramObject in _diagram.GetElements()
                                                                   select
                                                                       repository.GetElementByID(diagramObject.ElementID)
                                                                   into element where element.IsDecision()
                                                                   select element);

            return decisionsFromTopic.Union(decisionsDirectlyFromDiagram).ToArray();
        }

        public IEAElement[] GetRequirements()
        {
            IEARepository repository = EAFacade.EA.Repository;
            return (from diagramObject in _diagram.GetElements()
                    select repository.GetElementByID(diagramObject.ElementID)
                    into element where element.IsRequirement() select element).ToArray();
        }

        public Dictionary<IEAElement, List<IEAElement>> GetConcernsPerRequirement()
        {
            var requirementConcernDictionary = new Dictionary<IEAElement, List<IEAElement>>();
            foreach (IEAElement requirement in GetRequirements())
            {
                List<IEAElement> concerns =
                    requirement.GetConnectedConcerns().Where(concern => _diagram.Contains(concern)).ToList();
                requirementConcernDictionary.Add(requirement, concerns);
            }
            return requirementConcernDictionary;
        }

        [Obsolete("use reqPerConc", true)]
        public Dictionary<IEAElement, List<IEAElement>> GetConcerns()
        {
            IEARepository repository = EAFacade.EA.Repository;
            var requirementsConcerns = new Dictionary<IEAElement, List<IEAElement>>();
            foreach (IEADiagramObject diagramObject in _diagram.GetElements())
            {
                IEAElement concern = repository.GetElementByID(diagramObject.ElementID);
                if (!concern.IsConcern()) continue;
                foreach (IEAElement connectedRequirement in 
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
                            requirementsConcerns.Add(connectedRequirement, new List<IEAElement> {concern});
                    }
                }
            }
            return requirementsConcerns;
        }

        public List<Rating> GetRatings()
        {
            var data = new List<Rating>();
            foreach (
                IEAElement element in
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
            IEARepository repository = EAFacade.EA.Repository;
            foreach (Rating rating in data)
            {
                IEAElement decision = repository.GetElementByGUID(rating.DecisionGUID);
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
            var obj =EAFacade.EA.Repository.GetElementByGUID(key);
            MessageBox.Show("Value: " + key + 
                "\nWhat is it? (Type): " + obj.Type
                +"\nMetatype: " +obj.MetaType
                +"\nName: " + obj.Name);
        }
        //angor END task159
         */
    }
}
