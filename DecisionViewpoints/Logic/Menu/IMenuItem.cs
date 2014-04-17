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

    public class NullMenuItem : IMenuItem
    {
        public static NullMenuItem Instance()
        {
            return new NullMenuItem();
        }

        public string Name { get; set; }

        public void Click()
        {
        }

        public bool Enabled()
        {
            return true;
        }

        public bool Checked()
        {
            return false;
        }

        public bool Visible()
        {
            return true;
        }

        public IMenuItem GetMenuItem(string name)
        {
            return new NullMenuItem();
        }
    }
}
