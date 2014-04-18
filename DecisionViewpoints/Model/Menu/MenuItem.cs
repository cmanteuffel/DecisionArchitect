namespace DecisionViewpoints.Model.Menu
{
    public class MenuItem : IMenu
    {
        public static IMenu Separator = new MenuItem("-");

        public MenuItem(string name, ClickDelegate clickDelegate = null)
        {
            Name = name;
            UpdateDelegate = self => { };
            ClickDelegate = clickDelegate ?? (() => { });
            IsEnabled = true;
            IsChecked = false;
            IsVisible = true;
        }

        public string Name { get; set; }
        public object Value { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsChecked { get; set; }
        public bool IsVisible { get; set; }
        public ClickDelegate ClickDelegate { get; set; }
        public UpdateDelegate UpdateDelegate { get; set; }

        public void Click()
        {
            ClickDelegate();
        }

        public void Update()
        {
            UpdateDelegate(this);
        }

        public IMenu FindMenuItem(string name)
        {
            return Name.Equals(name) ? this : null;
        }

        public string[] GetSubItems()
        {
            return new[] {""};
        }
    }
}