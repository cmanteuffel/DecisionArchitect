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
using DecisionArchitect.Logic.EventHandler;
using DecisionArchitect.Logic.StakeholderInvolvement;
using DecisionArchitect.Logic.Validation;
using DecisionArchitect.Utilities;
using EA;
using EAFacade;
using EAFacade.Events;

namespace DecisionArchitect
{
    public partial class MainApplication : EAEventAdapter
    {
        private readonly IList<IRepositoryListener> _listeners = new List<IRepositoryListener>();

        //init repository listener
        public MainApplication()
        {
            _listeners.Add(new DecisionStateChangeEventHandler());
            _listeners.Add(DetailViewHandler.Instance);
            _listeners.Add(new ValidationHandler());
            _listeners.Add(new ChronologicalViewpointHandler());
            _listeners.Add(new ForcesHandler());
            _listeners.Add(new StakeholderInvolvementHandler());
        }

        public override object EA_OnInitializeTechnologies(Repository repository)
        {
            EAMain.UpdateRepository(repository);
            const string resource = "DecisionArchitect." + "DecisionArchitectMDG.xml";
            return Utils.GetResourceContents(resource);
        }

        public override string EA_OnRetrieveModelTemplate(Repository repository, string location)
        {
            EAMain.UpdateRepository(repository);
            string resource = "DecisionArchitect.Templates." + location;
            return Utils.GetResourceContents(resource);
        }
    }
}