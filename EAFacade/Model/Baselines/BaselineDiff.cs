using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml;

namespace EAFacade.Model.Baselines
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
                    baselineDiffItems.AddRange(from XmlNode node in compareItems select ParseNode(node));
            }
            baselineDiff.DiffItems = baselineDiffItems;

            return baselineDiff;
        }

        private static DiffItem ParseNode(XmlNode node)
        {
            var diffItem = GetDiffItem(node);
            var properties = node.SelectSingleNode("./Properties");
            if (properties != null)
                diffItem.Properties = GetDiffProperties(properties);
            var compareItems = node.SelectNodes("./CompareItem");
            if (compareItems != null)
                foreach (var childDiffItem in from XmlNode compareItem in compareItems select ParseNode(compareItem))
                    diffItem.DiffItems.Add(childDiffItem);
            return diffItem;
        }

        private static ICollection<DiffProperty> GetDiffProperties(XmlNode propertiesNode)
        {
            var properties = new Collection<DiffProperty>();
            if (propertiesNode != null)
                foreach (XmlNode diffItemProperty in propertiesNode.ChildNodes)
                    properties.Add(GetDiffProperty(diffItemProperty));
            return properties;
        }

        private static DiffItem GetDiffItem(XmlNode node)
        {
            var diffItem = new DiffItem();
            if (node.Attributes != null)
            {
                diffItem.Guid = GetAttributeValue(node.Attributes["guid"]);
                diffItem.Name = GetAttributeValue(node.Attributes["name"]);
                diffItem.Status = GetStatus(GetAttributeValue(node.Attributes["status"]));
                diffItem.Type = GetAttributeValue(node.Attributes["type"]);
            }
            return diffItem;
        }

        private static DiffProperty GetDiffProperty(XmlNode property)
        {
            var diffProperty = new DiffProperty();
            if (property.Attributes != null)
            {
                diffProperty.Name = GetAttributeValue(property.Attributes["name"]);
                diffProperty.Status = GetStatus(GetAttributeValue(property.Attributes["status"]));
                diffProperty.BaselineValue = GetAttributeValue(property.Attributes["baseline"]);
                diffProperty.ModelValue = GetAttributeValue(property.Attributes["model"]);
            }
            return diffProperty;
        }

        private static string GetAttributeValue(XmlNode attribute)
        {
            return attribute != null ? attribute.Value : "";
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