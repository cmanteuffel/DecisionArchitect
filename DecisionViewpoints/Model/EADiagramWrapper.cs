using EA;

namespace DecisionViewpoints.Model
{
    public class EADiagramWrapper : IEAWrapper
    {
        private readonly Diagram _diagram;

        public EADiagramWrapper(Diagram diagram)
        {
            _diagram = diagram;
        }

        public Diagram Get()
        {
            return _diagram;
        }

        public void CreateConnector(IDualElement lastModified, IDualElement newElement)
        {
            Connector connector = lastModified.Connectors.AddNew("", "ControlFlow");
            connector.Stereotype = "followed by";
            connector.SupplierID = newElement.ElementID;
            connector.Update();
            lastModified.Connectors.Refresh();
            newElement.Connectors.Refresh();
        }

        public void AddToDiagram(Repository repository, IDualElement newElement)
        {
            DiagramObject diaObj = _diagram.DiagramObjects.AddNew("l=10;r=110;t=-20;b=-80", "");
            diaObj.ElementID = newElement.ElementID;
            diaObj.Update();
            repository.ReloadDiagram(_diagram.PackageID);
            repository.SaveDiagram(_diagram.DiagramID);
        }

        public void OpenAndSelectElement(Repository repository, IDualElement element)
        {
            repository.OpenDiagram(_diagram.DiagramID);

            for (short i = 0; i < _diagram.SelectedObjects.Count; i++)
            {
                _diagram.SelectedObjects.Delete(i);
            }
            _diagram.SelectedObjects.AddNew(element.ElementID.ToString(), element.Type);
            repository.ActivateDiagram(_diagram.DiagramID);
        }
    }
}