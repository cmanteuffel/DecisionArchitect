/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    Marc Holterman (University of Groningen)
*/

namespace DecisionArchitect.Model
{
    public interface ITopic : ICustomViewModel
    {
        int ID { get; }
        string Name { get; set; }
        string Description { get; set; }

        void Save();
       
        void LoadLinkedDocument(string fileName);
        /*
        void AddObserver(ITopicObserver observer);
        void RemoveObserver(ITopicObserver observer);
         */
    }
}
