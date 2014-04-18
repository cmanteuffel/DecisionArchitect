namespace EAFacade.Model
{
    public interface IEAVolatileElement : IEAObject
    {
        IEADiagram Diagram { get; }
        string Stereotype { get; }
        string Type { get; }
        IEAElement ParentElement { get; }
    }
}