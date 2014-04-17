using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Xml;
using DecisionViewpoints.Model;
using EA;

namespace DecisionViewpoints.Logic.AutoGeneration
{
    public class ChronologicalGenerator : IGenerator
    {
        private static Repository _repository;
        private static EAProjectWrapper _project;
        private static EAPackage _history;
        private static EAPackage _generateFrom;
        private static EADiagram _cvpd;
        private static Element _lastCreated;

        public ChronologicalGenerator(Repository repository, EAProjectWrapper project, EAPackage generateFrom,
                                      EAPackage history,
                                      EADiagram diagram)
        {
            _repository = repository;
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
                        elements.Add(key, _history.CreateElement(_repository, elementName, stereotype, "Action"));
                }
            }
            GenerateElements(elements);
            GenerateElements(_generateFrom.Get().Elements);
        }

        public void Update()
        {
        }

        private static void GenerateElements(IDualCollection elements)
        {
            if (elements.Count <= 0) return;
            // Add the new element in the ChronologicalGenerator View diagram
            _cvpd.AddToDiagram(_repository, elements.GetAt(0));
            // Create a connector between the last modified and the new element
            if (_lastCreated != null) _cvpd.CreateConnector(_lastCreated, elements.GetAt(0));
            for (short i = 1; i < elements.Count; i++)
            {
                var element = elements.GetAt(i) as Element;
                if (element == null) continue;
                if (!element.MetaType.Equals("Decision")) continue;
                _cvpd.AddToDiagram(_repository, elements.GetAt(i));
                _cvpd.CreateConnector(elements.GetAt((short) (i - 1)), elements.GetAt(i));
            }
        }

        private static void GenerateElements(IDictionary elementsDict)
        {
            if (elementsDict.Count <= 0) return;
            var elements = new Element[elementsDict.Values.Count];
            elementsDict.Values.CopyTo(elements, 0);
            _cvpd.AddToDiagram(_repository, elements[0]);
            for (short i = 1; i < elements.Length; i++)
            {
                _cvpd.AddToDiagram(_repository, elements[i]);
                _cvpd.CreateConnector(elements[i - 1], elements[i]);
            }
            _lastCreated = elements[elements.Length - 1];
        }
    }
}