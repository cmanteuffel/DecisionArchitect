using System;
using System.Collections.Generic;
using System.Xml;

namespace DecisionViewpoints.Model.Baselines
{
    public class BaselineDiff
    {

        private BaselineDiff() {}

        public static BaselineDiff ParseFromXML(EAPackage package, Baseline baseline, string xml)
        {
            throw new NotImplementedException();
        }

        public Baseline Baseline { get; private set; }
        public EAPackage Package { get; private set; }
        public bool HasChanges { get; private set; }
        public IEnumerable<DiffItem> DiffItems { get; private set; }

    }
}