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

namespace EAFacade.Model
{
    public interface IModelObject : IModelItem
    {
        DateTime Created { get; set; }
        DateTime Modified { get; set; }
        String Version { get; set; }
        IEAPackage ParentPackage { get; set; }

        void ShowInProjectView();

        string GetProjectPath();

    }
}
