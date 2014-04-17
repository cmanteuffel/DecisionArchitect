using System.Collections;
using System.Collections.Generic;
using EA;

namespace DecisionViewpointsTests
{
    public class EventPropertiesHelper : EventProperties
    {
        private readonly IDictionary<string, EventProperty> _properties;

        private EventPropertiesHelper()
        {
            _properties = new Dictionary<string, EventProperty>
                    {
                        {"Type", null},
                        {"Subtype", null},
                        {"Stereotype", null},
                        {"ClientID", null},
                        {"SupplierID", null},
                        {"DiagramID", null},
                    };
        }

        public static EventPropertiesHelper Create(string type, string subtype, string stereotype, long clientid, long supplierid, long diagramid)
        {
            var eventPropertiesHelper = new EventPropertiesHelper();
            eventPropertiesHelper.Set("Type", type);
            eventPropertiesHelper.Set("Subtype", subtype);
            eventPropertiesHelper.Set("Stereotype", stereotype);
            eventPropertiesHelper.Set("ClientID", clientid);
            eventPropertiesHelper.Set("SupplierID", supplierid);
            eventPropertiesHelper.Set("DiagramID", diagramid);
            return eventPropertiesHelper;
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
