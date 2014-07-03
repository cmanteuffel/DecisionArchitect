/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    Marc Holterman (University of Groningen)
*/

using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Linq;


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
            var widthEmus = (long)(widthPx / horzRezDpi * emusPerInch);
            var heightEmus = (long)(heightPx / vertRezDpi * emusPerInch);
            const long maxWidthEmus = (long)(6.5 * emusPerInch);
            decimal ratio = (heightEmus * 1.0m) / widthEmus;
            size[0] = widthEmus <= maxWidthEmus ? widthEmus : maxWidthEmus;
            size[1] = (long)(widthEmus * ratio);
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

        public static string ProgramFilesx86()
        {
            if (8 == IntPtr.Size
                || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            }

            return Environment.GetEnvironmentVariable("ProgramFiles");
        }
    }


    /**
     * This class is used to determine the Color for a Specific State.
     */
    public sealed class DecisionStateColor
    {
        private static DecisionStateColor instance = null;

        enum States
        {
            IDEA = 0,
            TENTATIVE = 1,
            DECIDED = 2,
            APPROVED = 3,
            CHALLENGED = 4,
            DISCARDED = 5,
            REJECTED = 6
        }
        // This is the xml file containing all the information
        private const string XmlFilePath = "DecisionViewpoints.xml";
        // keeps the Colors for fast access
        private readonly Color[] _stateColors;

        // Private Constructor
        private DecisionStateColor()
        {
            _stateColors = new Color[Enum.GetNames(typeof(States)).Length];

            string directoy = Utilities.ProgramFilesx86() + @"\SEARCH Group\Decision Viewpoints\MDG Technology\";
            string path = directoy + XmlFilePath;
            InitStateColors(path);
        }

        // Getter
        public static DecisionStateColor Instance
        {
            get { return instance ?? (instance = new DecisionStateColor()); }
        }

        /// <summary>
        /// Converts a state to their respective color.
        /// </summary>
        /// <param name="state">
        /// Throws Argument Exeption if state is invalid
        /// </param>
        public static Color ConvertStateToColor(string state)
        {
            return Instance._stateColors[(int)(States)Enum.Parse(typeof(States), state, true)];
        }

        // Init method
        private void InitStateColors(string xmlFileName)
        {
            // Put the intial color on DarkGray
            Color defaultColor = Color.FromKnownColor(KnownColor.DarkGray);
            string stateStr;

            try
            {
                // Load xml file
                var xml = XDocument.Load(xmlFileName);

                // Loop over all states
                foreach (States state in (States[])Enum.GetValues(typeof(States)))
                {
                    // State to string
                    stateStr = (Enum.GetName(state.GetType(), state)).ToLower();

                    // Query the data and write out a subset of colors
                    var win32Colors = from item in xml.Root.Descendants("Stereotype")
                                      where (string)item.Attribute("metatype") == "Decision" &&
                                            (string)item.Attribute("name") == stateStr
                                      select item.Attribute("bgcolor");

                    // Should not contain more then 1 entry
                    foreach (var win32Color in win32Colors)
                    {
                        Color stateColor = ColorTranslator.FromWin32((int)win32Color);
                        _stateColors[(int)state] = stateColor != null ? stateColor : defaultColor;
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.Error.WriteLine("Query resulted in more than 1 Colors in " + xmlFileName);
            }
            catch (Exception)
            {
                Console.Error.WriteLine("Couldn't find " + xmlFileName + " in current Directoy");
            }
        }
    }
}