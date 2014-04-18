namespace EAFacade.Model
{
    public interface IEAVolatileConnector : IEAObject
    {
        string Type { get; }
        string Subtype { get; }
        string Stereotype { get; }
        IEAElement Supplier { get; }
        IEAElement Client { get; }
        IEADiagram Diagram { get; }
    }
}