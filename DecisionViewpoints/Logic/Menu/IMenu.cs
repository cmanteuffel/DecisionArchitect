namespace DecisionViewpoints.Logic.Menu
{
    public delegate void ClickDelegate();
    public delegate void UpdateDelegate(IMenu self);

    public interface IMenu
    {
        string Name { get; set; }

        bool IsEnabled { get; set; }
        bool IsChecked { get; set;  }
        bool IsVisible { get; set; }

        ClickDelegate ClickDelegate { get; set; }
        UpdateDelegate UpdateDelegate { get; set; }

        void Click();
        void Update();

        IMenu FindMenuItem(string name);
        string[] GetSubItems();
    }
}
