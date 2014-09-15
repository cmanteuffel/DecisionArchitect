/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
*/

using System;
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
            try
            {
                IEAElement element = EAMain.Repository.GetElementByGUID(forceGUID);
                Name = element.Name;
                ForceGUID = forceGUID;
            }
            catch (ArgumentNullException e)
            {
                throw new ForceNotInModelException("No Force with the specified GUID can be found. It has been probably deleted.", e);
            }
        }

        public string Name { get; private set; }
        public string ForceGUID { get; private set; }
    }

    public class ForceNotInModelException : Exception
    {
        public ForceNotInModelException(string message, Exception innerException) : base(message,innerException)
        {
           
        }
    }
}