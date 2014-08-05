using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DecisionViewpoints.Model.Baselines
{
    public class DiffItem
    {
        public DiffItem()
        {
            Properties = new Collection<DiffProperty>();
            DiffItems = new Collection<DiffItem>();
        }

        public string Guid { get; set; }
        public string Name { get; set; }
        public DiffStatus Status { get; set; }
        public string Type { get; set; }
        public ICollection<DiffProperty> Properties { get; set; }
        public ICollection<DiffItem> DiffItems { get; set; }

        public override string ToString()
        {
            return String.Format("guid: {0}, name: {1}, status: {2}, type: {3}", Guid, Name,
                                 Status, Type);
        }
    }
}