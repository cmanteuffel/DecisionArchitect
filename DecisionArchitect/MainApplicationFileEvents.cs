/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    Marc Holterman (University of Groningen)
 */

using DecisionArchitect.Logic;
using EA;
using EAFacade;

namespace DecisionArchitect
{
    public partial class MainApplication
    {
        public override void EA_FileOpen(Repository repository)
        {
            //MessageBox.Show("EA_FileOpen ");

            EAMain.UpdateRepository(repository);
            foreach (IRepositoryListener l in _listeners)
            {
                l.OnFileOpen();
            }
        }

        public override void EA_FileClose(Repository repository)
        {
            // MessageBox.Show("EA_FileClose ");

            EAMain.UpdateRepository(repository);
            foreach (IRepositoryListener l in _listeners)
            {
                l.OnFileClose();
            }
        }

        public override void EA_FileNew(Repository repository)
        {
            //  MessageBox.Show("EA_FileNew ");

            EAMain.UpdateRepository(repository);
            foreach (IRepositoryListener l in _listeners)
            {
                l.OnFileNew();
            }
        }

        /// <summary>
        ///     This is called if the user clicks on a tab
        /// </summary>
        /// <param name="tabname">
        ///     tells the listeners which tab
        /// </param>
        public override void EA_OnTabChanged(Repository repository, string tabname, int diagramID)
        {
            //MessageBox.Show("EA_OnTabChanged " + tabname);
            EAMain.UpdateRepository(repository);
            foreach (IRepositoryListener l in _listeners)
            {
                l.OnTabChanged(tabname, diagramID);
            }
        }
    }
}