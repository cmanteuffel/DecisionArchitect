/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Mathieu Kalksma (University of Groningen)
*/

using System;
using EA;

namespace EAFacade.Model.Impl
{
    public sealed class EAFile : IEAFile
    {
        private readonly IFile _native;

        private EAFile(IFile native)
        {
            _native = native;   
        }

        public string FileDate
        {
            get { return _native.FileDate; }
            set { _native.FileDate = value; }
        }

        public string FullPath
        {
            get { return _native.Name;  }
            set { _native.Name = value; }
        }

        public string Notes
        {
            get { return _native.Notes; }
            set { _native.Notes = value; }
        }

        public string Size
        {
            get { return _native.Size; }
            set { _native.Size = value; }
        }

        public string Type
        {
            get { return _native.Size; }
            set { _native.Size = value; }
        }

        public static IEAFile Wrap(IFile native)
        {
            if (null == native)
            {
                throw new ArgumentNullException("native");
            }
            return new EAFile(native);
        }

        
    }
}