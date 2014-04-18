using System.IO;
using System.Reflection;

namespace DecisionViewpoints
{
    public class Utilities
    {
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
