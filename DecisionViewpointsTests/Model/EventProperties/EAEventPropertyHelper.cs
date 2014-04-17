using EA;

namespace DecisionViewpointsTests.Model.EventProperties
{
    public class EAEventPropertyHelper : EventProperty
    {
        public object Value { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ObjectType ObjectType { get; set; }
    }
}
