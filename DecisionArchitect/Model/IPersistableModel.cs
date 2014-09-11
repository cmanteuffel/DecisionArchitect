namespace DecisionArchitect.Model
{
    public interface IPersistableModel
    {
        bool Changed { get; }
        bool SaveChanges();
        void DiscardChanges();
    }
}