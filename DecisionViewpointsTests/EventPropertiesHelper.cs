using System.Collections;
using System.Collections.Generic;
using EA;
using DecisionViewpoints.Model;

namespace DecisionViewpointsTests
{
    public class EventPropertiesHelper : EventProperties
    {
        private readonly IDictionary<string, EventProperty> _properties;

        public EventPropertiesHelper()
        {
            _properties = new Dictionary<string, EventProperty>
                    {
                        {EventPropertyKeys.Type, null},
                        {EventPropertyKeys.Subtype, null},
                        {EventPropertyKeys.Stereotype, null},
                        {EventPropertyKeys.ClientId, null},
                        {EventPropertyKeys.SupplierId, null},
                        {EventPropertyKeys.DiagramId, null},
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
            var eventProperty = new EventPropertyHelper
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
