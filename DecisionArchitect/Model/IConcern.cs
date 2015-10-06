/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Mathieu Kalksma (University of Groningen)
*/


using System.Collections.Generic;
using System.Linq;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Model
{
    public interface IConcern
    {
        string Name { get; }
        string ConcernGUID { get; }
        string UID { get; set; }
        IEAElement Element { get; }
        IEnumerable<string> GetUIDs(IForce force);
    }


    public class Concern : IConcern
    {
        public Concern(string concernGUID)
        {
            IEAElement element = EAMain.Repository.GetElementByGUID(concernGUID);
            Name = element.Name;
            ConcernGUID = concernGUID;
        }

        public Concern(IEAElement concernElement)
        {
            Name = concernElement.Name;
            ConcernGUID = concernElement.GUID;
        }
        public Concern(IEAElement concernElement, string uid)
        {
            Name = concernElement.Name;
            ConcernGUID = concernElement.GUID;
            UID = uid;
        }

        public string Name { get; private set; }
        public string ConcernGUID { get; private set; }
        public string UID { get;  set; }
        public IEAElement Element { get { return EAMain.Repository.GetElementByGUID(ConcernGUID); }}

        public IEnumerable<string> GetUIDs(IForce force)
        {
            var element = EAMain.Repository.GetElementByGUID(force.ForceGUID);

            return (from x in element.GetConnectors()
                where
                    x.MetaType.Equals(EAConstants.ConcernMetaType) && x.GetSupplier().GUID.Equals(ConcernGUID) &&
                    x.TaggedValueExists(EAConstants.ConcernUID)
                select x.GetTaggedValueByName(EAConstants.ConcernUID));
        }
    }
}