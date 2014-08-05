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
using EAFacade.Model;

namespace DecisionArchitect.Logic.Chronological
{
    public class DecisionStateChange
    {
        public IEAElement Element { get; set; }
        public DateTime DateModified { get; set; }
        public String State { get; set; }

        public static int CompareByDateModified(DecisionStateChange x, DecisionStateChange y)
        {
            return DateTime.Compare(x.DateModified, y.DateModified);
        }
    }
}
