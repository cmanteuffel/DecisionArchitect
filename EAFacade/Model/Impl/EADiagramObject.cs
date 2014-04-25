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
    internal sealed class EADiagramObject : IEADiagramObject
    {
        private readonly DiagramObject _native;

        private EADiagramObject(DiagramObject native)
        {
            _native = native;
        }

        public static IEADiagramObject Wrap(DiagramObject native)
        {
            return new EADiagramObject(native);
        }

        
        public int ElementID
        {
            get { return _native.ElementID; }
        }

        public IEADiagram Diagram
        {
            get
            {
                return EARepository.Instance.GetDiagramByID(_native.DiagramID);
            }
        }
    }
}
