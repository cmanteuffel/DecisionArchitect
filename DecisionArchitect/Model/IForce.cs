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
using System.Linq;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Model
{
    public interface IForce
    {
        string Name { get; }
        string ForceGUID { get; }
        string AddConcern(ITopic topic, IConcern concern);
        IEAElement Element { get; }
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
                throw new ForceNotInModelException(
                    "No Force with the specified GUID can be found. It has been probably deleted.", e);
            }
        }

        public Force(IEAElement forceElement)
        {
            Name = forceElement.Name;
            ForceGUID = forceElement.GUID;
        }


        private bool HasConcern(ITopic topic, IConcern concern)
        {
            var topicConcerns = topic.GetConcerns(this);
            var concernUIDs = concern.GetUIDs(this);
            return topicConcerns.Any(topicConcern => concernUIDs.Contains(topicConcern));
        }

        /// <summary>
        /// Add a new concern for this force
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="concern"></param>
        /// <returns>The newly created concernUID or null if already exists</returns>
        public string AddConcern(ITopic topic, IConcern concern)
        {
            if (HasConcern(topic, concern))
                return null;
            return Guid.NewGuid().ToString();

            //var element = Element;
            //var concernElement = EAMain.Repository.GetElementByGUID(concern.ConcernGUID);
            //var connector = element.ConnectTo(concernElement, EAConstants.ConcernMetaType, EAConstants.ConcernMetaType);
            //var uid = Guid.NewGuid().ToString();
            //connector.AddTaggedValue(EAConstants.ConcernUID, uid);

            //return uid;
        }

        public IConcern GetConcern(string uid)
        {
            return (from x in Element.GetConnectors()
                where
                    x.MetaType.Equals(EAConstants.ConcernMetaType) && x.TaggedValueExists(EAConstants.ConcernUID) &&
                    x.GetTaggedValueByName(EAConstants.ConcernUID).Equals(uid)
                select new Concern(x.GetSupplier(), uid)).FirstOrDefault();
        }

        public IEAElement Element {
            get { return EAMain.Repository.GetElementByGUID(ForceGUID); }
        }
        public string Name { get; private set; }
        public string ForceGUID { get; private set; }
    }

    public class ForceNotInModelException : Exception
    {
        public ForceNotInModelException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}