using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using DecisionViewpoints.Model;
using EA;

namespace DecisionViewpoints.Logic.AutoGeneration
{
    public class ChronologicalGenerator : IAutoGenerator
    {
        private static Repository _repository;
        private static EAPackageWrapper _hp;
        private static EADiagramWrapper _cvpd;

        public ChronologicalGenerator(Repository repository, EAPackageWrapper package, EADiagramWrapper diagram)
        {
            _repository = repository;
            _hp = package;
            _cvpd = diagram;
        }

        public void GenerateHistory(IDualRepository repository, Dictionary<string, XmlNodeList> comparisonResults)
        {
            var elements = new List<Element>();
            foreach (var result in comparisonResults)
            {
                foreach (XmlNode element in result.Value)
                {
                    if (element.Attributes == null) continue;
                    var elementName = element.Attributes["name"].Value;
                    var generate = element.FirstChild.SelectSingleNode("//Property[@status='Changed' and @name='DateModified']") != null;
                    if (!generate) continue;
                    var stereotypeProperty = element.FirstChild.SelectSingleNode("//Property[@name='Stereotype' and @status='Changed']");
                    if (stereotypeProperty == null) continue;
                    if (stereotypeProperty.Attributes == null) continue;
                    var stereotype = stereotypeProperty.Attributes["baseline"].Value;
                    elements.Add(_hp.CreateElement(_repository, elementName, stereotype, "Action"));
                }
            }
            GenerateElements(elements);
        }

        public void AddCurrent(EAPackageWrapper package)
        {
            GenerateElements(package.Get().Elements);
        }

        private static void GenerateElements(IDualCollection elements)
        {
            // Find last modified element
            var lastCreated = _hp.LastCreated();
            // Add the new element in the ChronologicalGenerator View diagram
            _cvpd.AddToDiagram(_repository, elements.GetAt(0));
            // Create a connector between the last modified and the new element
            if (lastCreated == null) return;
            //MessageBox.Show(string.Format("{0}, {1}", lastCreated.Name, lastCreated.Created));
            _cvpd.CreateConnector(lastCreated, elements.GetAt(0));
            for (short i = 1; i < elements.Count; i++)
            {
                _cvpd.AddToDiagram(_repository, elements.GetAt(i));
                _cvpd.CreateConnector(elements.GetAt((short)(i - 1)), elements.GetAt(i));
            }
        }

        private static void GenerateElements(IReadOnlyList<Element> elements)
        {
            _cvpd.AddToDiagram(_repository, elements[0]);
            for (short i = 1; i < elements.Count; i++)
            {
                _cvpd.AddToDiagram(_repository, elements[i]);
                _cvpd.CreateConnector(elements[i - 1], elements[i]);
            }
        }
    }
}