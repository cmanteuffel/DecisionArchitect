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

using DecisionArchitect.Model;
using EAFacade.Model;

namespace DecisionArchitect.View.Forces
{
    public interface IForcesController
    {
        IForcesModel Model { get; set; }
        IForcesView View { get; set; }
        void Configure();
        void SetDiagramModel(IEADiagram diagram);
        void UpdateDecision(IEAElement element);
        void UpdateForce(IEAElement element);
        void UpdateConcern(IEAElement element);
        void RemoveDecision(IEAElement element);
        void RemoveForce(IEAElement element);
        void RemoveConcern(IEAElement element);
        void Update();
        void Save();
    }
}