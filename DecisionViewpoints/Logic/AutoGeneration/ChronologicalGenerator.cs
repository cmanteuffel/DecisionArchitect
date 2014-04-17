using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DecisionViewpoints.Model;
using EA;

namespace DecisionViewpoints.Logic.AutoGeneration
{
    public class ChronologicalGenerator : IAutoGenerator
    {
        private static Repository _repository;
        private static Package _cvp;
        private static Diagram _cvpd;

        public ChronologicalGenerator(Repository repository)
        {
            _repository = repository;
            _cvp = repository.Models.GetAt(0).Packages.GetByName("Decision Chronological View");
            _cvpd = _cvp.Diagrams.GetAt(0);
        }

        public void Generate()
        {
            throw new System.NotImplementedException();
        }

        public void Update(EAElementWrapper element)
        {
            // Find all same elements in the chronological view
            var sameElements = SameElements(element);
            // Find the last same element that has been modified to check later if there is a state change
            Element lastSameModified = null;
            if (sameElements.Count > 0)
                lastSameModified = LastSameModified(sameElements);
            if (lastSameModified == null)
            {
                // A new element has been added
                HandleElementChange(element);
            }
            else
            {
                // An existing element changed, check if there is state change.
                // Only then create a new version of this element in the chronological view
                if (element.Stereotype.Equals(lastSameModified.Stereotype)) return;
                HandleElementChange(element);
            }
        }

        private static void HandleElementChange(EAElementWrapper element)
        {
            // Find last modified element
            var lastModified = LastModified();
            // Create new element
            var newElement = CreateElement(element);
            // Add the new element in the ChronologicalGenerator View diagram
            AddToDiagram(newElement);
            // Create a connector between the last modified and the new element
            if (lastModified == null) return;
            CreateConnector(lastModified, newElement);
        }

        private static void CreateConnector(IDualElement lastModified, IDualElement newElement)
        {
            Connector connector = lastModified.Connectors.AddNew("", "ControlFlow");
            connector.Stereotype = "followed by";
            connector.SupplierID = newElement.ElementID;
            connector.Update();
            lastModified.Connectors.Refresh();
            newElement.Connectors.Refresh();
        }

        private static void AddToDiagram(IDualElement newElement)
        {
            DiagramObject diaObj = _cvpd.DiagramObjects.AddNew("l=10;r=110;t=-20;b=-80", "");
            diaObj.ElementID = newElement.ElementID;
            diaObj.Update();
            _repository.ReloadDiagram(_cvpd.PackageID);
            _repository.SaveDiagram(_cvpd.DiagramID);
        }

        private static Element CreateElement(EAElementWrapper element)
        {
            Element newElement = _cvp.Elements.AddNew(element.Element.Name, element.Type);
            newElement.Stereotype = element.Stereotype;
            newElement.Update();
            _cvp.Elements.Refresh();
            return newElement;
        }

        private static Element LastModified()
        {
            Element lastModified = null;
            if (_cvp.Elements.Count > 0)
            {
                lastModified = _cvp.Elements.GetAt(0);
                foreach (
                    var e in from Element e in _cvp.Elements where e.Modified > lastModified.Modified select e)
                {
                    lastModified = e;
                }
            }
            return lastModified;
        }

        private static Element LastSameModified(IReadOnlyList<Element> sameElements)
        {
            Element lastSameModified = null;
            if (sameElements.Count > 0)
            {
                lastSameModified = sameElements[0];
                foreach (var e in sameElements.Where(e => e.Modified > lastSameModified.Modified))
                {
                    lastSameModified = e;
                }
            }
            return lastSameModified;
        }

        private static List<Element> SameElements(EAElementWrapper element)
        {
            var sameElements = new List<Element>();
            if (_cvp.Elements.Count > 0)
            {
                sameElements.AddRange(from Element e in _cvp.Elements where e.Name.Equals(element.Element.Name) select e);
            }
            return sameElements;
        }
    }
}