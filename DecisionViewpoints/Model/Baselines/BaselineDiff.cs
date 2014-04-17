using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
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
        /// We stop adding CompareItems and navigating further bottom to the tree,
        /// when we encounter those of type=Link.
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

            var compareResults = xmlDocument.SelectSingleNode("//CompareResults");
            var baselineDiffItems = new List<DiffItem>();
            if (compareResults != null)
            {
                if (compareResults.Attributes != null)
                    baselineDiff.HasChanges = Boolean.Parse(compareResults.Attributes["hasChanges"].Value);

                var compareItems = compareResults.SelectNodes("./CompareItem");
                if (compareItems != null)
                    baselineDiffItems.AddRange(from XmlNode compareItem in compareItems select Parse(compareItem));
            }
            baselineDiff.DiffItems = baselineDiffItems;

            return baselineDiff;
        }

        private static DiffItem Parse(XmlNode node)
        {
            var diffItem = GetDiffItem(node);
            var properties = node.SelectSingleNode("./Properties");
            if (properties != null)
                diffItem.Properties = GetProperties(properties);
            var compareItems = node.SelectNodes("./CompareItem");
            if (compareItems != null)
                foreach (var childDiffItem in from XmlNode compareItem in compareItems select Parse(compareItem))
                {
                    diffItem.DiffItems.Add(childDiffItem);
                }
            return diffItem;
        }

        private static ICollection<DiffProperty> GetProperties(XmlNode propertiesNode)
        {
            var properties = new Collection<DiffProperty>();
            if (propertiesNode != null)
                foreach (XmlNode diffItemProperty in propertiesNode.ChildNodes)
                    properties.Add(GetDiffProperty(diffItemProperty));
            return properties;
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