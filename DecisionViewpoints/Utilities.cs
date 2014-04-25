/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
*/

using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DecisionViewpoints
{
    public static class Utilities
    {
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

        public static DateTime TryParseDateTime(string dateString, DateTime fallback)
        {
            DateTime parsed;
            if (!DateTime.TryParse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out parsed))
            {
                MessageBox.Show(dateString + " not parsed");
                parsed = fallback;
            }
            return parsed;
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
