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

namespace EAFacade.Model.Impl
{
    internal sealed class EAVolatileDiagram : IEAVolatileDiagram
    {
        private EAVolatileDiagram()
        {
        }

        public int DiagramID { get; set; }

        public static IEAVolatileDiagram Wrap(EventProperties info)
        {
            var volatileDiagram = new EAVolatileDiagram();
            dynamic diagramID = EAUtilities.ParseToInt32(info.Get(EAEventPropertyKeys.DiagramId).Value, -1);
            if (diagramID > 0)
                volatileDiagram.DiagramID = diagramID;

            return volatileDiagram;
        }
    }
}