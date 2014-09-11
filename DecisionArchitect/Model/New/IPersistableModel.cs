namespace DecisionArchitect.Model.New
{
    public interface IPersistableModel
    {
        bool Changed { get; }
        bool SaveChanges();
        void DiscardChanges();
    }
}