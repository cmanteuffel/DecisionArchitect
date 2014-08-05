namespace DecisionViewpoints.Logic.Menu.General
{
    public class CreateProjectStructure : LeafMenuItem
    {
        public CreateProjectStructure()
            : base("&Create Project Structure")
        {
        }

        public override bool Enabled()
        {
            return false;
        }
    }
}
