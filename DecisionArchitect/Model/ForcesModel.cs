/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    Antonis Gkortzis (University of Groningen)
    Mark Hoekstra (University of Groningen)
*/

using System;
using System.Collections.Generic;
using System.Linq;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Model
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

        public string Name { get; private set; }
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

        /// <summary>
        ///     Implements IForcesModel.GetDecisions()
        /// </summary>
        /// <returns></returns>
        public IEAElement[] GetDecisions()
        {
            IEARepository repository = EAMain.Repository;
            IEAElement[] topics = (from diagramObject in _diagram.GetElements()
                                   select repository.GetElementByID(diagramObject.ElementID)
                                   into element
                                   where
                                       EAMain.IsTopic(element) &&
                                       !element.TaggedValueExists(EATaggedValueKeys.IsForceElement, _diagram.GUID)
                                   select element).ToArray();


            IEnumerable<IEAElement> decisionsFromTopic =
                (from IEAElement topic in topics select topic.GetDecisionsForTopic()).SelectMany(x => x);


            IEnumerable<IEAElement> decisionsDirectlyFromDiagram = (from diagramObject in _diagram.GetElements()
                                                                    select
                                                                        repository.GetElementByID(
                                                                            diagramObject.ElementID)
                                                                    into element
                                                                    where
                                                                        element.TaggedValueExists(
                                                                            EATaggedValueKeys.IsDecisionElement,
                                                                            _diagram.GUID)
                                                                    select element);

            return decisionsFromTopic.Union(decisionsDirectlyFromDiagram).ToArray();
        }

        /// <summary>
        ///     Implements IForcesModel.GetForces()
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IEAElement> GetForces()
        {
            IEARepository repository = EAMain.Repository;
            return (from diagramObject in _diagram.GetElements()
                    select repository.GetElementByID(diagramObject.ElementID)
                    into element
                    where element.TaggedValueExists(EATaggedValueKeys.IsForceElement, _diagram.GUID)
                    select element).ToArray();
        }

        /// <summary>
        ///     Implements IForcesModel.GetConcernsPerForce()
        /// </summary>
        /// <returns></returns>
        public Dictionary<IEAElement, List<IEAElement>> GetConcernsPerForce()
        {
            var forceConcernDictionary = new Dictionary<IEAElement, List<IEAElement>>();
            foreach (IEAElement force in GetForces())
            {
                List<IEAElement> concerns =
                    force.GetConnectedConcerns(_diagram.GUID).Where(concern => _diagram.Contains(concern)).ToList();
                forceConcernDictionary.Add(force, concerns);
            }
            return forceConcernDictionary;
        }

        public IEnumerable<Rating> GetRatings()
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
                                      ForceGUID = Rating.GetForceGUIDFromTaggedValue(taggedValue.Name),
                                      ConcernGUID = Rating.GetConcernGUIDFromTaggedValue(taggedValue.Name),
                                      Value = taggedValue.Value
                                  });
            }
            return data;
        }

        public void SaveRatings(IEnumerable<Rating> data)
        {
            IEARepository repository = EAMain.Repository;
            foreach (Rating rating in data)
            {
                IEAElement decision = repository.GetElementByGUID(rating.DecisionGUID);
                if (decision == null) continue;
                string forcesTaggedValue = Rating.ConstructForcesTaggedValue(rating.ForceGUID, rating.ConcernGUID);
                if (decision.GetTaggedValueByName(forcesTaggedValue) != null)
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
    }
}