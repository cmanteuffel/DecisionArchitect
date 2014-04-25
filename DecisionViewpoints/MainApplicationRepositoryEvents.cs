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

using System.Linq;
using DecisionViewpoints.Logic;
using EA;
using EAFacade;
using EAFacade.Model;

namespace DecisionViewpoints
{
    //TODO: Not all events are implemented
    public partial class MainApplication
    {
        public override bool EA_OnPreNewElement(Repository repository, EventProperties properties)
        {
            EAFacade.EA.UpdateRepository(repository);
            IEAVolatileElement element = EAFacade.EA.WrapVolatileElement(properties);

            foreach (IRepositoryListener l in _listeners)
            {
                if (!l.OnPreNewElement(element))
                {
                    return false;
                }
            }
            return true;
        }

        public override bool EA_OnPostNewElement(Repository repository, EventProperties properties)
        {
            EAFacade.EA.UpdateRepository(repository);
            var element = EAFacade.EA.WrapElement(properties);

            foreach (IRepositoryListener l in _listeners)
            {
                if (!l.OnPostNewElement(element))
                {
                    return false;
                }
            }
            return true;
        }

        public override bool EA_OnPreNewConnector(Repository repository, EventProperties info)
        {
            EAFacade.EA.UpdateRepository(repository);
            IEAVolatileConnector volatileConnector = EAFacade.EA.WrapVolatileConnector(info);
            foreach (IRepositoryListener l in _listeners)
            {
                if (!l.OnPreNewConnector(volatileConnector))
                {
                    return false;
                }
            }
            return true;
        }

        public override void EA_OnContextItemChanged(Repository repository, string guid, ObjectType ot)
        {
            EAFacade.EA.UpdateRepository(repository);
            foreach (IRepositoryListener l in _listeners)
            {
                l.OnContextItemChanged(guid, EAUtilities.Translate(ot));
            }
        }

        public override bool EA_OnContextItemDoubleClicked(Repository repository, string guid, ObjectType ot)
        {
            EAFacade.EA.UpdateRepository(repository);
            foreach (IRepositoryListener l in _listeners)
            {
                if (l.OnContextItemDoubleClicked(guid, EAUtilities.Translate(ot)))
                {
                    return true;
                }
            }
            return false;
        }

        public override void EA_OnNotifyContextItemModified(Repository repository, string guid, ObjectType ot)
        {
            EAFacade.EA.UpdateRepository(repository);
            foreach (IRepositoryListener l in _listeners)
            {
                l.OnNotifyContextItemModified(guid, EAUtilities.Translate(ot));
            }
        }

        public override bool EA_OnPreDeleteDiagram(Repository repository, EventProperties properties)
        {
            EAFacade.EA.UpdateRepository(repository);
            IEAVolatileDiagram diagram = EAFacade.EA.WrapVolatileDiagram(properties);
            return _listeners.All(l => l.OnPreDeleteDiagram(diagram));
        }

        public override bool EA_OnPreDeleteElement(Repository repository, EventProperties properties)
        {
            EAFacade.EA.UpdateRepository(repository);
            var element = EAFacade.EA.WrapElement(properties);

            foreach (IRepositoryListener l in _listeners)
            {
                if (!l.OnPreDeleteElement(element))
                {
                    return false;
                }
            }
            return true;
        }

        //angor moved from MainApplication
        public override void EA_OnPostOpenDiagram(Repository repository, int diagramId)
        {
            EAFacade.EA.UpdateRepository(repository);
            IEADiagram diagram = EAFacade.EA.Repository.GetDiagramByID(diagramId);
            foreach (IRepositoryListener l in _listeners)
            {
                l.OnPostOpenDiagram(diagram);
            }
        }

        //angor
        public override bool EA_OnPostNewDiagramObject(Repository repository, EventProperties properties)
        {
            EAFacade.EA.UpdateRepository(repository);
            foreach (IRepositoryListener l in _listeners)
            {
                if (!l.OnPostNewDiagramObject())
                {
                    return false;
                }
            }
            return true;
        }

        //angor task179 START
        public override void EA_OnPostCloseDiagram(Repository repository, int diagramId)
        {
            EAFacade.EA.UpdateRepository(repository);
            //System.Windows.Forms.MessageBox.Show("Event OnPostCloseDiagram"); //angor
        }

        //angor task179 END
    }
}
