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
    public interface IEAConnector : IModelItem
    {
        string Type { get; set; }
        string Stereotype { get; set; }
        int SupplierId { get; }
        int ClientId { get; }
        string MetaType { get; set; }
        IEAElement GetSupplier();
        IEAElement GetClient();
        IEADiagram GetDiagram();
        bool IsRelationship();
        bool IsAction();
    }
}
