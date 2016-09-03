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
*/

namespace DecisionArchitect.Model
{
    public interface ICustomViewModelObserver
    {
    }

    public interface IForcesModelObserver : ICustomViewModelObserver
    {
        void Update(IForcesModel model);
    }

    /*
    public interface ITopicObserver : ICustomViewModelObserver
    {
        void Update(ITopic model);
    }
     */
}