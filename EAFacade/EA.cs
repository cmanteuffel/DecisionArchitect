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
using EAFacade.Model.Impl;

namespace EAFacade
{
    public sealed class EA
    {
        public static IEARepository Repository
        {
            get { return EARepository.Instance; }
        }

        public static void UpdateRepository(Repository repository)
        {
            EARepository.UpdateRepository(repository);
        }

        public static IEAElement WrapElement(EventProperties eventProperties)
        {
            return EAElement.Wrap(eventProperties);
        }

        public static IEAElement WrapElement(Element element)
        {
            return EAElement.Wrap(element);
        }

        public static IEAConnector WrapConnector(Connector connector)
        {
            return EAConnector.Wrap(connector);
        }

        public static IEAVolatileConnector WrapVolatileConnector(EventProperties eventProperties)
        {
            return EAVolatileConnector.Wrap(eventProperties);
        }

        public static IEAVolatileDiagram WrapVolatileDiagram(EventProperties properties)
        {
            return EAVolatileDiagram.Wrap(properties);
        }

        public static IEAVolatileElement WrapVolatileElement(EventProperties properties)
        {
            return EAVolatileElement.Wrap(properties);
        }
    }
}
