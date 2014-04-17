using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionViewpoints
{
    public class BaselineOptions
    {
        public enum BaselineOption
        {
            OnFileClose, OnModification, Manually
        }

        private readonly Dictionary<BaselineOption, bool> _baselinesOptions = new Dictionary<BaselineOption, bool>()
            {
                {BaselineOption.OnFileClose, false},
                {BaselineOption.OnModification, false},
                {BaselineOption.Manually, true}
            };

        public bool GetOption(BaselineOption o)
        {
            return _baselinesOptions[o];
        }

        public void SetOption(BaselineOption o, bool state)
        {
            _baselinesOptions[o] = state;
        }
    }
}
