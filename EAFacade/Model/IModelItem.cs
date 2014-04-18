namespace EAFacade.Model
{
    public interface IModelItem : IEAObject
    {
        string GUID { get; }
        int ID { get; }
        NativeType NativeType { get; }
        string Name { get; set; }
        string Notes { get; set; }
    }
}