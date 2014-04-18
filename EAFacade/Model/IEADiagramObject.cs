namespace EAFacade.Model
{
    public interface IEADiagramObject : IEAObject
    {
        int ElementID { get; }
        IEADiagram Diagram { get; }
    }
}