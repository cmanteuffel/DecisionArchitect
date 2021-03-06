/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    Mark Hoekstra (University of Groningen)
*/

using System.Collections.Generic;
using EAFacade.Model;

namespace DecisionArchitect.Model
{
    public interface IForcesModel : ICustomViewModel
    {
        string Name { get; }
        string DiagramName { get; }
        string DiagramGUID { get; }
        IEADiagram DiagramModel { set; }

        void SaveRatings(IEnumerable<Rating> data);

        /// <summary>
        ///     Get Decisions from Diagram and Topics that are on the diagram
        /// </summary>
        /// <returns></returns>
        IEAElement[] GetDecisions();

        /// <summary>
        ///     Get all elements which are a force in this model
        /// </summary>
        /// <returns></returns>
        IEnumerable<IEAElement> GetForces();

        /// <summary>
        ///     Get all forces and concerns connected to each other
        /// </summary>
        /// <returns></returns>
        Dictionary<IEAElement, List<IEAElement>> GetConcernsPerForce();

        IEnumerable<Rating> GetRatings();

        void AddObserver(IForcesModelObserver observer);
        void RemoveObserver(IForcesModelObserver observer);
    }
}