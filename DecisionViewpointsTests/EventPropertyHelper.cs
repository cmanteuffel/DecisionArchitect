using EA;

namespace DecisionViewpointsTests
{
    public class EventPropertyHelper : EventProperty
    {
        public object Value { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ObjectType ObjectType { get; set; }
    }
}
