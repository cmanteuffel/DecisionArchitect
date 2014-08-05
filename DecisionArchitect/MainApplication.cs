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

using System.Collections.Generic;
using DecisionArchitect.Logic;
using DecisionArchitect.Logic.Chronological;
using DecisionArchitect.Logic.Detail;
using DecisionArchitect.Logic.Forces;
using DecisionArchitect.Logic.StakeholderInvolvement;
using DecisionArchitect.Logic.Validation;
using EA;
using EAFacade.Events;

namespace DecisionArchitect
{

    public partial class MainApplication : EAEventAdapter
    {
        private readonly IList<IRepositoryListener> _listeners = new List<IRepositoryListener>();

        //init repository listener
        public MainApplication()
        {
            _listeners.Add(new ValidationHandler());
            _listeners.Add(new ChronologicalViewpointHandler());
            _listeners.Add(new ForcesHandler());
            _listeners.Add(new StakeholderInvolvementHandler());
            _listeners.Add(DetailHandler.Instance);
        }

        public override object EA_OnInitializeTechnologies(Repository repository)
        {
            EAFacade.EA.UpdateRepository(repository);
            const string resource = "DecisionArchitect." + "DecisionArchitectMDG.xml";
            return Utilities.GetResourceContents(resource);
        }

        public override string EA_OnRetrieveModelTemplate(Repository repository, string location)
        {
            EAFacade.EA.UpdateRepository(repository);
            string resource = "DecisionArchitect.Templates." + location;
            return Utilities.GetResourceContents(resource);
        }
    }
}
