using System.Collections.Generic;

namespace DecisionViewpoints
{
    public class BaselineOptions
    {
        public enum Option
        {
            OnFileClose, OnModification, Manually
        }

        private readonly Dictionary<Option, bool> _baselinesOptions = new Dictionary<Option, bool>()
            {
                {Option.OnFileClose, false},
                {Option.OnModification, false},
                {Option.Manually, true}
            };

        public bool GetOption(Option o)
        {
            return _baselinesOptions[o];
        }

        public void SetOption(Option o, bool state)
        {
            _baselinesOptions[o] = state;
        }
    }
}
