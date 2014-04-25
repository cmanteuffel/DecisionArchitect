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

using System.Collections.Generic;
using EAFacade.Model;

namespace DecisionViewpoints.Model
{
    public interface IForcesModel : ICustomViewModel
    {
        string Name { get; }
        string DiagramName { get; }
        string DiagramGUID { get; }
        IEADiagram DiagramModel { set; }

        void SaveRatings(List<Rating> data);
        IEAElement[] GetDecisions();
        IEAElement[] GetRequirements();
        Dictionary<IEAElement, List<IEAElement>> GetConcerns();
        List<Rating> GetRatings();
        Dictionary<IEAElement, List<IEAElement>> GetConcernsPerRequirement();

        void AddObserver(IForcesModelObserver observer);
        void RemoveObserver(IForcesModelObserver observer);
    }
}
