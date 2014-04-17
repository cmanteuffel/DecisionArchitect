using System.Collections.Generic;
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
        private static EAPackageWrapper _history;
        private static EAPackageWrapper _generateFrom;
        private static EADiagramWrapper _cvpd;
        private static Element _lastCreated;

        public ChronologicalGenerator(Repository repository, EAProjectWrapper project, EAPackageWrapper generateFrom,
                                      EAPackageWrapper history,
                                      EADiagramWrapper diagram)
        {
            _repository = repository;
            _project = project;
            _generateFrom = generateFrom;
            _history = history;
            _cvpd = diagram;
        }

        public void Generate()
        {
            var elements = new List<Element>();
            foreach (var result in _project.GetComparisonResults())
            {
                foreach (XmlNode element in result.Value)
                {
                    if (element.Attributes == null) continue;
                    var elementName = element.Attributes["name"].Value;
                    var generate =
                        element.FirstChild.SelectSingleNode("//Property[@status='Changed' and @name='DateModified']") !=
                        null;
                    if (!generate) continue;
                    var stereotypeProperty =
                        element.FirstChild.SelectSingleNode("//Property[@name='Stereotype' and @status='Changed']");
                    if (stereotypeProperty == null) continue;
                    if (stereotypeProperty.Attributes == null) continue;
                    var stereotype = stereotypeProperty.Attributes["baseline"].Value;
                    elements.Add(_history.CreateElement(_repository, elementName, stereotype, "Action"));
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

        private static void GenerateElements(IReadOnlyList<Element> elements)
        {
            if (elements.Count <= 0) return;
            _cvpd.AddToDiagram(_repository, elements[0]);
            for (short i = 1; i < elements.Count; i++)
            {
                _cvpd.AddToDiagram(_repository, elements[i]);
                _cvpd.CreateConnector(elements[i - 1], elements[i]);
            }
            _lastCreated = elements[elements.Count - 1];
        }
    }
}