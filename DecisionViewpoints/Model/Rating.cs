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

using System;
using System.Windows.Forms;
using EAFacade.Model;

namespace DecisionViewpoints.Model
{
    public class Rating
    {
        private string _value;

        public string DecisionGUID { get; set; }
        public string ConcernGUID { get; set; }
        public string RequirementGUID { get; set; }

        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                if (_value.Length <= 255) return;
                var repository = EAFacade.EA.Repository;
                var decision = repository.GetElementByGUID(DecisionGUID);
                var requirement = repository.GetElementByGUID(RequirementGUID);
                var concern = repository.GetElementByGUID(ConcernGUID);
                MessageBox.Show(
                    String.Format(
                        "The length of rating '{0}' that belongs to decision '{1}' and requirement '{2}' classified by '{3}' is too large. It must be less than 256 characters.",
                        _value, decision.Name, requirement.Name, concern.Name));
                _value = "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string ConstructForcesTaggedValue(string requirementGUID, string concernGUID)
        {
            return String.Format("DV.Forces:{0}:{1}", requirementGUID, concernGUID);
        }

        /// <summary>
        /// Returns just the GUID from the requirement GUID tagged value.
        /// The format of the requirement GUID tagged value is r:{GUID}.
        /// </summary>
        /// <param name="value">The taggged value name.</param>
        /// <returns></returns>
        //private static string GetReqGUIDFromTaggedValue(string value)//original
        public static string GetReqGUIDFromTaggedValue(string value)
        {
            return value.Split(':')[1];
        }

        public static string GetConcernGUIDFromTaggedValue(string value)
        {
            return value.Split(':')[2];
        }

        /// <summary>
        /// Checks if the tagged value of the 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        //private static bool IsForcesTaggedValue(string value)//original
        public static bool IsForcesTaggedValue(string value)
        {
            return value.Split(':')[0].Equals("DV.Forces");
        }
    }
}
