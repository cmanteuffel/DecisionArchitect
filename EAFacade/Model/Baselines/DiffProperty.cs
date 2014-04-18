using System;

namespace EAFacade.Model.Baselines
{
    public class DiffProperty
    {
        public DiffStatus Status { get; set; }
        public string Name { get; set; }
        public string BaselineValue { get; set; }
        public string ModelValue { get; set; }

        public override string ToString()
        {
            return String.Format("name: {0}, status: {1}, baseline: {2}, model: {3}", Name, Status,
                                 BaselineValue, ModelValue);
        }
    }
}