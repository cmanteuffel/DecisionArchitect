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

using System;
using System.Globalization;
using EAFacade;
using EAFacade.Model;

namespace DecisionViewpoints.Model
{
    public class DataComparator
    {
        public static int CompareByStateDateModified(IEAElement x, IEAElement y)
        {
            string oldestDateString = DateTime.MinValue.ToString(CultureInfo.InvariantCulture);
            string xDateString = x.GetTaggedValue(EATaggedValueKeys.DecisionStateModifiedDate) ?? oldestDateString;
            string yDateString = y.GetTaggedValue(EATaggedValueKeys.DecisionStateModifiedDate) ?? oldestDateString;

            DateTime xModified = Utilities.TryParseDateTime(xDateString, DateTime.MinValue);
            DateTime yModified = Utilities.TryParseDateTime(yDateString, DateTime.MinValue);
            return DateTime.Compare(xModified, yModified);
        }
    }
}
