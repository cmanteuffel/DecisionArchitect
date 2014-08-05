using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Xml;
using DecisionViewpoints.Model;

namespace DecisionViewpoints.Logic.AutoGeneration
{
    public class ChronologicalGenerator : IGenerator
    {
        private static EAProjectWrapper _project;
        private static EAPackage _history;
        private static EAPackage _generateFrom;
        private static EADiagram _cvpd;
        private static EAElement _lastCreated;

        public ChronologicalGenerator(EAProjectWrapper project, EAPackage generateFrom,
                                      EAPackage history,
                                      EADiagram diagram)
        {
            _project = project;
            _generateFrom = generateFrom;
            _history = history;
            _cvpd = diagram;
        }

        //TODO: Name identification might be weak
        public void Generate()
        {
            var elements = new OrderedDictionary();
            foreach (var result in _project.GetComparisonResults())
            {
                foreach (XmlNode element in result.Value)
                {
                    if (element.Attributes == null) continue;
                    var elementName = element.Attributes["name"].Value;
                    var dateModified =
                        element.FirstChild.SelectSingleNode("//Property[@status='Changed' and @name='DateModified']");
                    var generate = dateModified != null;
                    if (!generate) continue;
                    if (dateModified.Attributes == null) continue;
                    var elementDateModified = dateModified.Attributes["baseline"].Value;
                    var key = String.Format("{0}::{1}", elementName, elementDateModified);
                    var stereotypeProperty =
                        element.FirstChild.SelectSingleNode("//Property[@name='Stereotype' and @status='Changed']");
                    if (stereotypeProperty == null) continue;
                    if (stereotypeProperty.Attributes == null) continue;
                    var stereotype = stereotypeProperty.Attributes["baseline"].Value;
                    if (!elements.Contains(key))
                        elements.Add(key, _history.CreateElement(elementName, stereotype, "Action"));
                }
            }
            GenerateElements(elements);
            GenerateElements(_generateFrom.Elements);
        }

        public void Update()
        {
        }

        private static void GenerateElements(IList<EAElement> elements)
        {
            if (elements.Count <= 0) return;
            // Add the new element in the ChronologicalGenerator View diagram
            _cvpd.AddToDiagram(elements[0]);
            // Create a connector between the last modified and the new element
            if (_lastCreated != null) _lastCreated.ConnectTo(elements[0]);
            for (short i = 1; i < elements.Count; i++)
            {
                var element = elements[i];
                if (element == null) continue;
                if (!element.MetaType.Equals("Decision")) continue;
                _cvpd.AddToDiagram(elements[i]);
                elements[(short) (i - 1)].ConnectTo(elements[i]);
            }
        }

        private static void GenerateElements(IDictionary elementsDict)
        {
            if (elementsDict.Count <= 0) return;
            var elements = new EAElement[elementsDict.Values.Count];
            elementsDict.Values.CopyTo(elements, 0);
            _cvpd.AddToDiagram(elements[0]);
            for (short i = 1; i < elements.Length; i++)
            {
                _cvpd.AddToDiagram(elements[i]);
                elements[i - 1].ConnectTo(elements[i]);
            }
            _lastCreated = elements[elements.Length - 1];
        }
    }
}