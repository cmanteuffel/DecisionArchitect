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

using System.Linq;
using DecisionArchitect.Logic;
using EA;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect
{
    //TODO: Not all events are implemented
    public partial class MainApplication
    {
        public override bool EA_OnPreNewElement(Repository repository, EventProperties properties)
        {
            EAMain.UpdateRepository(repository);
            IEAVolatileElement element = EAMain.WrapVolatileElement(properties);

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
            EAMain.UpdateRepository(repository);
            IEAElement element = EAMain.WrapElement(properties);

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
            EAMain.UpdateRepository(repository);
            IEAVolatileConnector volatileConnector = EAMain.WrapVolatileConnector(info);
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
            EAMain.UpdateRepository(repository);
            foreach (IRepositoryListener l in _listeners)
            {
                l.OnContextItemChanged(guid, EAUtilities.Translate(ot));
            }
        }

        public override bool EA_OnContextItemDoubleClicked(Repository repository, string guid, ObjectType ot)
        {
            EAMain.UpdateRepository(repository);
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
            EAMain.UpdateRepository(repository);
            foreach (IRepositoryListener l in _listeners)
            {
                l.OnNotifyContextItemModified(guid, EAUtilities.Translate(ot));
            }
        }

        public override bool EA_OnPreDeleteDiagram(Repository repository, EventProperties properties)
        {
            EAMain.UpdateRepository(repository);
            IEAVolatileDiagram diagram = EAMain.WrapVolatileDiagram(properties);
            return _listeners.All(l => l.OnPreDeleteDiagram(diagram));
        }

        public override bool EA_OnPreDeleteElement(Repository repository, EventProperties properties)
        {
            EAMain.UpdateRepository(repository);
            IEAElement element = EAMain.WrapElement(properties);

            foreach (IRepositoryListener l in _listeners)
            {
                if (!l.OnPreDeleteElement(element))
                {
                    return false;
                }
            }
            return true;
        }

        public override void EA_OnPostOpenDiagram(Repository repository, int diagramId)
        {
            EAMain.UpdateRepository(repository);
            IEADiagram diagram = EAMain.Repository.GetDiagramByID(diagramId);
            foreach (IRepositoryListener l in _listeners)
            {
                l.OnPostOpenDiagram(diagram);
            }
        }

        public override bool EA_OnPostNewDiagramObject(Repository repository, EventProperties properties)
        {
            EAMain.UpdateRepository(repository);
            foreach (IRepositoryListener l in _listeners)
            {
                if (!l.OnPostNewDiagramObject())
                {
                    return false;
                }
            }
            return true;
        }

        public override void EA_OnPostCloseDiagram(Repository repository, int diagramId)
        {
            EAMain.UpdateRepository(repository);
        }
    }
}