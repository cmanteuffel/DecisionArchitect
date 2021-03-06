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
    public static class EAEventPropertyKeys
    {
        public const string SupplierId = "supplierID";
        public const string ClientId = "clientID";
        public const string DiagramId = "diagramID";
        public const string Stereotype = "stereotype";
        public const string Type = "type";
        public const string Subtype = "subtype";
        public const string ParentId = "ParentID";
        public const string ElementId = "ElementID";
        public const string ConnectorID = "ConnectorID";

        public const string DiagramObjectId = "ID";
        //According to documentation this key is called ObjectID, however in practice it is just called ID
    }
}