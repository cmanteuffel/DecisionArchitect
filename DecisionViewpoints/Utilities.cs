using System.IO;
using System.Reflection;

namespace DecisionViewpoints
{
    public class Utilities
    {
        public static string GetResourceContents(string resource)
        {
            string technology = null;
            using (var stream = Assembly.GetExecutingAssembly()
                                        .GetManifestResourceStream(resource))
            {
                if (stream != null)
                    using (var reader = new StreamReader(stream))
                    {
                        technology = reader.ReadToEnd();
                    }
            }
            return technology;
        }
    }
}
