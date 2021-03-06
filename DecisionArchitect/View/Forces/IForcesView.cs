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
using System.Runtime.InteropServices;
using DecisionArchitect.Model;
using EAFacade.Model;

namespace DecisionArchitect.View.Forces
{
    [ComVisible(true)]
    [Guid("C325ED77-CD8C-4CC3-BAB1-974420531239")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IForcesView : IForcesModelObserver
    {
        IEnumerable<string> ForceGuids { get; }
        IEnumerable<string> ConcernGuids { get; }
        IEnumerable<string> DecisionGuids { get; }

        void SetController(IForcesController controller);
        void UpdateTable(IForcesModel model);
        void UpdateDecision(IEAElement element);
        void UpdateForce(IEAElement element);
        void UpdateConcern(IEAElement element);
        void RemoveDecision(IEAElement element);
        void RemoveForce(IEAElement element);
        void RemoveConcern(IEAElement element);
        string GetRating(int row, int column);
    }
}