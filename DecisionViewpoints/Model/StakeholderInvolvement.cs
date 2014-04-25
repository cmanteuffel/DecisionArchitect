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

namespace DecisionViewpoints.Model
{
    public class StakeholderInvolvement
    {
        public String StakeholderName { get; set; }
        public String StakeholderType { get; set; }
        public String Action { get; set; }
        public String StakeholderGUID { get; set; }
        public String ConnectorGUID { get; set; }
    }
}
