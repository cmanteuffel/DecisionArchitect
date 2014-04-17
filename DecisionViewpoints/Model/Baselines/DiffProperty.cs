namespace DecisionViewpoints.Model.Baselines
{
    public class DiffProperty
    {
        public DiffStatus Status { get; set; }
        public string Name { get; set; }
        public string BaselineValue { get; set; }
        public string ModelValue { get; set; }
    }
}