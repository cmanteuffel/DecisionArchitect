using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using EA;
using EAFacade.Model;

namespace EAFacade
{
    public class Utilities
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

        public static NativeType Translate(ObjectType nativeOt)
        {
            switch (nativeOt)
            {
                case ObjectType.otElement:
                    return NativeType.Element;
                case ObjectType.otConnector:
                    return NativeType.Connector;
                case ObjectType.otDiagram:
                    return NativeType.Diagram;
                case ObjectType.otPackage:
                    return NativeType.Package;
                case ObjectType.otNone:
                    //FIX: model returns for some reason otNone, translated to otModel. Might cause problems. 
                    return NativeType.Model;
                default:
                    MessageBox.Show("" + nativeOt);
                    return NativeType.Unspecified;
            }
        }

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