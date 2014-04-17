using System.Collections.Generic;

namespace DecisionViewpoints.Model.Baselines
{
    public class DiffItem
    {
        public DiffItem()
        {
        }

        public string Guid { get; set; }
        public string Name { get; set; }
        public DiffStatus Status { get; set; }
        public string Type { get; set; }
        public ICollection<DiffProperty> Properties { get; set; }
        public ICollection<DiffItem> DiffItems { get; set; } 
    }
}