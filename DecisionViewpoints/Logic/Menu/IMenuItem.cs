namespace DecisionViewpoints.Logic.Menu
{
    public interface IMenuItem
    {
        string Name { get; set; }
        void Click();
        bool Enabled();
        bool Checked();
        bool Visible();
        IMenuItem GetMenuItem(string name);
    }
}
