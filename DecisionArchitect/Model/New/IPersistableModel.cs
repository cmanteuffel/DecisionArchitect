namespace DecisionArchitect.Model.New
{
    public interface IPersistableModel
    {
        bool SaveChanges();
        void DiscardChanges();
    }
}