using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
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
                case ObjectType.otRepository:
                    return NativeType.Repository;
                case ObjectType.otNone:
                    //FIX: model returns for some reason otNone, translated to otModel. Might cause problems. 
                    return NativeType.Model;
                default:
                    //MessageBox.Show("" + nativeOt);
                    return NativeType.Unspecified;
            }
        }

        public static string GetResourceContents(string resource)
        {
            string technology = null;
            using (Stream stream = Assembly.GetExecutingAssembly()
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


        public static long[] GetImageSize(Image img)
        {
            var size = new long[2];
            int widthPx = img.Width;
            int heightPx = img.Height;
            float horzRezDpi = img.HorizontalResolution;
            float vertRezDpi = img.VerticalResolution;
            const int emusPerInch = 914400;
            var widthEmus = (long) (widthPx/horzRezDpi*emusPerInch);
            var heightEmus = (long) (heightPx/vertRezDpi*emusPerInch);
            const long maxWidthEmus = (long) (6.5*emusPerInch);
            decimal ratio = (heightEmus*1.0m)/widthEmus;
            size[0] = widthEmus <= maxWidthEmus ? widthEmus : maxWidthEmus;
            size[1] = (long) (widthEmus*ratio);
            return size;
        }

        public static string GetDocumentsDirectory()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //String.Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
            // (Environment.OSVersion.Platform == PlatformID.Unix ||
            //        Environment.OSVersion.Platform == PlatformID.MacOSX)
            //           ? Environment.GetEnvironmentVariable("HOME")
            //           :
        }
    }
}