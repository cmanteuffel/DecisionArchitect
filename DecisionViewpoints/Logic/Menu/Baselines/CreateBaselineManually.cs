namespace DecisionViewpoints.Logic.Menu.Baselines
{
    public class CreateBaselineManually : LeafMenuItem
    {
        public CreateBaselineManually()
            : base("&CreateBaselineManually")
        {
        }

        public override bool Enabled()
        {
            return false;
        }
    }
}
