namespace DecisionViewpoints.Logic.Menu
{
    public abstract class LeafMenuItem : IMenuItem
    {
        protected LeafMenuItem(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public virtual void Click()
        {
        }

        public virtual bool Enabled()
        {
            return true;
        }

        public virtual bool Checked()
        {
            return false;
        }

        public virtual bool Visible()
        {
            return true;
        }

        public virtual IMenuItem GetMenuItem(string name)
        {
            return null;
        }
    }
}
