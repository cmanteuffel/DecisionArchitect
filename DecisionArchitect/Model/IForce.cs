/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
*/

using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Model
{
    public interface IForce
    {
        string Name { get; }
        string ForceGUID { get; }
    }

    public class Force : IForce
    {
        public Force(string forceGUID)
        {
            IEAElement element = EAMain.Repository.GetElementByGUID(forceGUID);
            Name = element.Name;
            ForceGUID = forceGUID;
        }

        public string Name { get; private set; }
        public string ForceGUID { get; private set; }
    }
}