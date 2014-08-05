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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionViewpoints.Model;
using DecisionViewpoints.Model.Baselines;
using DecisionViewpoints.Properties;

namespace DecisionViewpoints.Logic.Automation
{
    class ChronologicalViewpointUtilities
    {
        public static void CreateDecisionSnapshot(EAPackage eapackage)
        {
            if (eapackage == null || eapackage.IsDecisionViewPackge())
            {
                throw new BaselineException("Package needs to be a decision viewpoint packge");
            }


            string notes = String.Format(Settings.Default.BaselineIdentifier);
            eapackage.CreateBaseline(notes);
        }
    }
}
