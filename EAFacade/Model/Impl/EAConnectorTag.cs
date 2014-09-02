/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Mark Hoekstra (University of Groningen)
*/

using System;
using EA;

namespace EAFacade.Model.Impl
{
    internal sealed class EAConnectorTag : IEAConnectorTag
    {

        private readonly ConnectorTag _native;

        private EAConnectorTag(ConnectorTag native)
        {
            _native = native;
        }

        public string GUID
        {
            get { return _native.TagGUID; }
        }

        public int ID
        {
            get { return _native.TagID; }
        }

        public EANativeType EANativeType
        {
            get { return EANativeType.Property; }
        }

        public string Name
        {
            get { return _native.Name; }
            set { _native.Name = value; }
        }

        public string Notes
        {
            get { return _native.Notes; }
            set { _native.Notes = value; }
        }

        public string Value
        {
            get { return _native.Value; }
            set { _native.Value = value; }
        }

        public static IEAConnectorTag Wrap(ConnectorTag native)
        {
            if (null == native)
            {
                throw new ArgumentNullException("native");
            }
            return new EAConnectorTag(native);
        }
    }
}
