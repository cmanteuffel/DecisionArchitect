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
    internal sealed class EAVolatileElement : IEAVolatileElement
    {
        private EAVolatileElement()
        {
        }

        public IEADiagram Diagram { get; private set; }
        public string Stereotype { get; private set; }
        public string Type { get; private set; }
        public IEAElement ParentElement { get; private set; }

        public static IEAVolatileElement Wrap(EventProperties info)
        {
            var volatileElement = new EAVolatileElement
                {
                    Type = info.Get(EAEventPropertyKeys.Type).Value,
                    Stereotype = info.Get(EAEventPropertyKeys.Stereotype).Value
                };

            if (volatileElement.Type.Equals(EAConstants.EventPropertyTypeElement))
            {
                dynamic parentElementID = EAUtilities.ParseToInt32(info.Get(EAEventPropertyKeys.ParentId).Value, -1);
                if (parentElementID > 0)
                {
                    volatileElement.ParentElement = EARepository.Instance.GetElementByID(parentElementID);
                }
            }

            dynamic diagramID = EAUtilities.ParseToInt32(info.Get(EAEventPropertyKeys.DiagramId).Value, -1);
            if (diagramID > 0)
            {
                volatileElement.Diagram = EARepository.Instance.GetDiagramByID(diagramID);
            }

            return volatileElement;
        }
    }
}