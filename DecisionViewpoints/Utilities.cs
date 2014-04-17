using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionViewpoints
{
    class Utilities
    {
        public static int ParseToInt32(string value, int valueOnFailure)
        {
            int number;
            if (!Int32.TryParse(value, out number))
            {
                number = valueOnFailure;
            }
            return number;
        }
    }
}
