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

using System.Runtime.InteropServices;
using DecisionViewpoints.Model;
using DecisionViewpoints.View.Controller;
using EAFacade.Model;

namespace DecisionViewpoints.View
{
    [ComVisible(true)]
    [Guid("C325ED77-CD8C-4CC3-BAB1-974420531239")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IForcesView : IForcesModelObserver, ICustomView
    {
        string[] RequirementGuids { get; }
        string[] ConcernGuids { get; }
        string[] DecisionGuids { get; }

        void SetController(IForcesController controller);
        void UpdateTable(IForcesModel model);
        void UpdateDecision(IEAElement element);
        void UpdateRequirement(IEAElement element);
        void UpdateConcern(IEAElement element);
        void RemoveDecision(IEAElement element);
        void RemoveRequirement(IEAElement element);
        void RemoveConcern(IEAElement element);
        string GetRating(int row, int column);
    }
}
