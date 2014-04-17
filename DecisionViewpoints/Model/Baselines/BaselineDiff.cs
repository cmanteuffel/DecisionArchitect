using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace DecisionViewpoints.Model.Baselines
{
    public class BaselineDiff
    {
        public Baseline Baseline { get; private set; }
        public EAPackage Package { get; private set; }
        public bool HasChanges { get; private set; }
        public IEnumerable<DiffItem> DiffItems { get; private set; }

        private BaselineDiff()
        {
        }

        /// <summary>
        /// Created a BaselineDiff by parsing the provided xml.
        /// 
        /// Baseline XML structure:
        /// 
        /// <EA.CompareLog>
        ///     <ComparePackage>
        ///         <CompareResults hasChanges="">
        ///             <CompareItem>
        ///                 <Properties>
        ///                     <Property></Property>
        ///                     ...
        ///                 </Properties>
        ///                 <CompareItem>
        ///                     <Properties>
        ///                         <Property></Property>
        ///                         ...
        ///                     </Properties>
        ///                     <CompareItem></CompareItem>
        ///                     ...
        ///                 </CompareItem>
        ///                 ...
        ///             </CompareItem>
        ///             ...
        ///         </CompareResults>
        ///     </ComparePackage>
        /// </EA.CompareLog>
        /// 
        /// </summary>
        /// <param name="package">The package that its baselines are used in comparison.</param>
        /// <param name="baseline">The baseline that is compared with hte current model of the package.</param>
        /// <param name="xml">The xml that is obtained when comparing baselines.</param>
        /// <returns></returns>
        public static BaselineDiff ParseFromXml(EAPackage package, Baseline baseline, string xml)
        {
            var baselineDiff = new BaselineDiff {Baseline = baseline, Package = package};
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);

            // We stop adding CompareItems in Links
            var compareResults = xmlDocument.SelectSingleNode("//CompareResults");
            var diffItems = new List<DiffItem>();
            if (compareResults != null)
            {
                if (compareResults.Attributes != null)
                    baselineDiff.HasChanges = Boolean.Parse(compareResults.Attributes["hasChanges"].Value);

                var compareItems = compareResults.SelectNodes("./CompareItem");
                if (compareItems != null)
                    foreach (XmlNode compareItem in compareItems)
                    {
                        if (compareItem.Attributes == null) continue;
                        var diffItem = GetDiffItem(compareItem);

                        GetProperties(compareItem.SelectSingleNode("./Properties"), diffItem);

                        foreach (
                            var childCompareItem in
                                compareItem.ChildNodes.Cast<XmlNode>()
                                           .Where(childCompareItem => childCompareItem.Name.Equals("CompareItem")))
                        {
                            if (childCompareItem.Attributes == null) continue;
                            var childDiffItem = GetDiffItem(childCompareItem);

                            GetProperties(childCompareItem.SelectSingleNode("./Properties"), childDiffItem);

                            diffItem.DiffItems.Add(childDiffItem);
                        }

                        diffItems.Add(diffItem);
                    }
            }
            baselineDiff.DiffItems = diffItems;

            return baselineDiff;
        }

        private static void GetProperties(XmlNode properties, DiffItem diffItem)
        {
            if (properties != null)
                foreach (XmlNode diffItemProperty in properties.ChildNodes)
                    diffItem.Properties.Add(GetDiffProperty(diffItemProperty));
        }

        private static DiffItem GetDiffItem(XmlNode compareItem)
        {
            var diffItem = new DiffItem();
            if (compareItem.Attributes != null)
            {
                diffItem.Guid = compareItem.Attributes["guid"].Value;
                diffItem.Name = compareItem.Attributes["name"].Value;
                diffItem.Status = GetStatus(compareItem.Attributes["status"].Value);
                diffItem.Type = compareItem.Attributes["type"].Value;
            }
            return diffItem;
        }

        private static DiffProperty GetDiffProperty(XmlNode property)
        {
            var diffProperty = new DiffProperty();
            if (property.Attributes != null)
            {
                diffProperty.Name = property.Attributes["name"].Value;
                diffProperty.Status = GetStatus(property.Attributes["status"].Value);
                diffProperty.BaselineValue = property.Attributes["baseline"] != null
                                                 ? property.Attributes["baseline"].Value
                                                 : "";
                diffProperty.ModelValue = property.Attributes["model"] != null
                                              ? property.Attributes["model"].Value
                                              : "";
            }
            return diffProperty;
        }

        private static DiffStatus GetStatus(string diffStatus)
        {
            switch (diffStatus)
            {
                case "Baseline only":
                    return DiffStatus.Baseline;
                case "Changed":
                    return DiffStatus.Changed;
                case "Identical":
                    return DiffStatus.Identical;
                case "Model only":
                    return DiffStatus.Model;
                default:
                    return DiffStatus.None;
            }
        }
    }
}