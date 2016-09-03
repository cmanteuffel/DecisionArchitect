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

using System;
using EA;

namespace EAFacade.Model.Impl
{
    internal sealed class EATaggedValue : IEATaggedValue
    {
        private readonly TaggedValue _native;

        private EATaggedValue(TaggedValue native)
        {
            _native = native;
        }

        public string GUID
        {
            get { return _native.PropertyGUID; }
            set { throw new InvalidOperationException("Read-only property"); }
        }

        public int ID
        {
            get { return _native.PropertyID; }
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

        public static IEATaggedValue Wrap(TaggedValue native)
        {
            if (null == native)
            {
                throw new ArgumentNullException("native");
            }
            return new EATaggedValue(native);
        }
    }
}