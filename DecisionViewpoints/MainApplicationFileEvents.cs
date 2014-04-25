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

using EA;
using EAFacade.Model;

namespace DecisionViewpoints
{
    public partial class MainApplication
    {
        public override void EA_FileOpen(Repository repository)
        {
            EAFacade.EA.UpdateRepository(repository);
            foreach (var l in _listeners)
            {
                l.OnFileOpen();
            }
        }

        public override void EA_FileClose(Repository repository)
        {
            EAFacade.EA.UpdateRepository(repository);
            foreach (var l in _listeners)
            {
                l.OnFileClose();
            }
        }

        public override void EA_FileNew(Repository repository)
        {
            EAFacade.EA.UpdateRepository(repository);
            foreach (var l in _listeners)
            {
                l.OnFileNew();
            }
        }
        
    }
}
