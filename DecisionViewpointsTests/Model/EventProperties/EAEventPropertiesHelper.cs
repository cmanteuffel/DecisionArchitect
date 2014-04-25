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

using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using EA;
using EAFacade.Model;

namespace DecisionViewpointsTests.Model.EventProperties
{
    public sealed class EAEventPropertiesHelper : EA.EventProperties
    {
        private readonly IDictionary<string, EventProperty> _properties;

        private EAEventPropertiesHelper()
        {
            _properties = new Dictionary<string, EventProperty>
                {
                    {EAEventPropertyKeys.Type, null},
                    {EAEventPropertyKeys.Subtype, null},
                    {EAEventPropertyKeys.Stereotype, null},
                    {EAEventPropertyKeys.ClientId, null},
                    {EAEventPropertyKeys.SupplierId, null},
                    {EAEventPropertyKeys.DiagramId, null},
                };
        }

        public static EAEventPropertiesHelper GetInstance(string type, string subtype, string stereotype, int clientid,
                                                          int supplierid, int diagramid)
        {
            var instance = new EAEventPropertiesHelper();
            instance.Set(EAEventPropertyKeys.Type, type);
            instance.Set(EAEventPropertyKeys.Subtype, subtype);
            instance.Set(EAEventPropertyKeys.Stereotype, stereotype);
            instance.Set(EAEventPropertyKeys.ClientId, clientid.ToString(CultureInfo.InvariantCulture));
            instance.Set(EAEventPropertyKeys.SupplierId, supplierid.ToString(CultureInfo.InvariantCulture));
            instance.Set(EAEventPropertyKeys.DiagramId, diagramid.ToString(CultureInfo.InvariantCulture));
            return instance;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _properties.GetEnumerator();
        }

        IEnumerator _EventProperties.GetEnumerator()
        {
            return _properties.GetEnumerator();
        }

        public EventProperty Get(object key)
        {
            return _properties[(string) key];
        }

        private void Set(string key, object value)
        {
            var eventProperty = new EAEventPropertyHelper
                {
                    Name = key,
                    Value = value,
                    Description = "",
                    ObjectType = ObjectType.otEventProperty
                };
            _properties[key] = eventProperty;
        }

        public int Count
        {
            get { return _properties.Count; }
        }

        public ObjectType ObjectType
        {
            get { return ObjectType.otEventProperties; }
        }
    }
}
