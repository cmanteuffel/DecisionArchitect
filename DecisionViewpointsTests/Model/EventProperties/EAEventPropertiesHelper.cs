using System.Collections;
using System.Collections.Generic;
using EA;
using DecisionViewpoints.Model;

namespace DecisionViewpointsTests.Model.EventProperties
{
    public class EAEventPropertiesHelper : EA.EventProperties
    {
        private readonly IDictionary<string, EventProperty> _properties;

        public EAEventPropertiesHelper()
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
            return _properties[(string)key];
        }

        public void Set(string key, object value)
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
