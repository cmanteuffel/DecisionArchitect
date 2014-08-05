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

using DecisionViewpoints.Model;
namespace DecisionViewpoints.View.Controller
{
    public interface IDetailViewControllerOld : ICustomViewController
    {
        //void ShowDetailView();

        IDetailView View { get; set; }
        IDecision Decision { get; set; }

        void Update();
        void Initialize();

        void InvokeViewChange(string guid);
    }
}
