namespace EAFacade.Model
{
    public interface IModelItem : IEAObject
    {
        string GUID { get; }
        int ID { get; }
        EANativeType EANativeType { get; }
        string Name { get; set; }
        string Notes { get; set; }
    }
}