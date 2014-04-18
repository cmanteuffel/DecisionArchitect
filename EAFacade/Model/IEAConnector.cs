namespace EAFacade.Model
{
    public interface IEAConnector : IModelItem
    {
        string Type { get; set; }
        string Stereotype { get; set; }
        int SupplierId { get; }
        int ClientId { get; }
        string MetaType { get; set; }
        IEAElement GetSupplier();
        IEAElement GetClient();
        IEADiagram GetDiagram();
        bool IsRelationship();
        bool IsAction();
    }
}