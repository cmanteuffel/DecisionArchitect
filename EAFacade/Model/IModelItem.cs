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

namespace EAFacade.Model
{
    public interface IModelItem : IEAObject
    {
        string GUID { get; }
        int ID { get; }
        EANativeType EANativeType { get; }
        string Name { get; set; }
        string Notes { get; set; }
    }
}