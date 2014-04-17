using System;
using System.IO;
using System.Reflection;

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
            if (!Int64.TryParse(value, out number))
            {
                number = valueOnFailure;
            }
            return number;
        }

        public static string GetResourceContents(string resource)
        {
            string technology;
            using (var stream = Assembly.GetExecutingAssembly()
                                        .GetManifestResourceStream(resource))
            {
                using (var reader = new StreamReader(stream))
                {
                    technology = reader.ReadToEnd();
                }
            }
            return technology;
        }
    }
}