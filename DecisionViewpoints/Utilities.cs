using System;

namespace DecisionViewpoints
{
    internal class Utilities
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

        public static long ParseToLong(string value, long valueOnFailure)
        {
            long number;
            if (!long.TryParse(value, out number))
            {
                number = valueOnFailure;
            }
            return number;
        }
    }
}