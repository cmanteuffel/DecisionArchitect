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
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;
using DecisionArchitect.Model;
using DecisionArchitect.View.Components.RichTextBox;
using EAFacade;

namespace DecisionArchitect.Utilities
{
    public static class Utils
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

        public static Color GetDesiredForegroundColor(Color backgroundColor)
        {
            //http://stackoverflow.com/questions/2241447/make-foregroundcolor-black-or-white-depending-on-background
            var backColor = (int)Math.Sqrt(
                backgroundColor.R * backgroundColor.R * .299 +
                backgroundColor.G * backgroundColor.G * .587 +
                backgroundColor.B * backgroundColor.B * .114);
            return backColor > 130 ? Color.Black : Color.White;
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
            return TryParseDateTime(dateString, fallback, CultureInfo.CurrentUICulture);
        }

        public static DateTime TryParseDateTime(string dateString, DateTime fallback, CultureInfo culture)
        {
            DateTime parsed;
            if (!DateTime.TryParse(dateString, culture, DateTimeStyles.AdjustToUniversal, out parsed))
            {
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


        internal static string AntonymRelation(string relation)
        {
            int index = 0;
            foreach (string r in EAConstants.Relationships)
            {
                if (r == relation)
                    return EAConstants.InverseRelationships.ElementAt(index);

                index++;
            }
            return EAConstants.InverseRelationships.ElementAt(0);
        }

        /**
         * Tranfors unformatted text to RTF.
         * This method is usable with the format buttons of the DetailView (current hidden)
         */

        public static string PlaintextToRtf(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return "";

            string escapedPlainText = plainText.Replace(@"\", @"\\").Replace("{", @"\{").Replace("}", @"\}");
            string rtf = @"{\rtf1\ansi\ansicpg1253\deff0\deflang1032{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}
                            {\f1\fnil\fcharset161 Microsoft Sans Serif;}}\viewkind4\uc1\pard\lang1033\f0\fs17 ";
            rtf += escapedPlainText.Replace(Environment.NewLine, "\\lang1032\\f1\\par");
            rtf += " }";
            return rtf;
        }

        public static string FormattedRtfToPlainText(string formattedRtf)
        {
            var box = new CustomRichTextBox();
            box.RichText = formattedRtf;

            return box.TextBox.Text;
        }

        public static string ChangeRtfToCurrentCulture(RichTextBoxEx richTextBox, string rtfValue)
        {
            //var textBox = new TextBox();
            var helperRichTextBox = new RichTextBoxEx();

            helperRichTextBox.Rtf = rtfValue;

            // select 1 char
            helperRichTextBox.SelectionStart = 0;
            helperRichTextBox.SelectionLength = 1;

            // set font on the first font
            Font lastFont = helperRichTextBox.SelectionFont;
            int lastFontChange = 0;
            // run over the text
            for (int i = 0; i < helperRichTextBox.TextLength; ++i)
            {
                helperRichTextBox.SelectionStart = i;
                helperRichTextBox.SelectionLength = 1;
                if (!helperRichTextBox.SelectionFont.Equals(lastFont))
                {
                    lastFont = helperRichTextBox.SelectionFont;
                    helperRichTextBox.SelectionStart = lastFontChange;
                    helperRichTextBox.SelectionLength = i - lastFontChange;
                    helperRichTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, richTextBox.Font.Size,
                                                               helperRichTextBox.SelectionFont.Style);
                    lastFontChange = i;
                }
            }

            if (helperRichTextBox.TextLength == 0)
            {
                richTextBox.Font = new Font(richTextBox.Font.FontFamily, richTextBox.Font.Size,
                                            helperRichTextBox.SelectionFont.Style);
                return "";
            }

            helperRichTextBox.SelectionStart = helperRichTextBox.TextLength - 1;
            helperRichTextBox.SelectionLength = 1;
            helperRichTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, richTextBox.Font.Size,
                                                       helperRichTextBox.SelectionFont.Style);


            return helperRichTextBox.Rtf;
        }

        public static List<IDecision> SortDecisionsByState(List<IDecision> input)
        {
            input.Sort((a, b) => GetSortValueForState(a.State).CompareTo(GetSortValueForState(b.State)));
            return input;
        }

        private static int GetSortValueForState(string state)
        {
            switch (state.ToLower())
            {
                case "approved":
                    return 1;
                case "decided":
                    return 2;
                case "tentative":
                    return 3;
                case "idea":
                    return 4;
                case "challenged":
                    return 5;
                case "discarded":
                    return 6;
                default:
                    return 7;

            }
        }
    }

    /**
     * This class is used to determine the Color for a Specific State.
     */

    public sealed class DecisionStateColor
    {
        private static DecisionStateColor _instance;

        // keeps the Colors for fast access
        private readonly Color[] _stateColors;

        // Private Constructor
        private DecisionStateColor()
        {
            _stateColors = new Color[Enum.GetNames(typeof (States)).Length];
            InitStateColors();
        }

        // Getter
        private static DecisionStateColor Instance
        {
            get { return _instance ?? (_instance = new DecisionStateColor()); }
        }

        /// <summary>
        ///     Converts a state to their respective color.
        /// </summary>
        /// <param name="state">
        ///     Throws Argument Exeption if state is invalid
        /// </param>
        public static Color ConvertStateToColor(string state)
        {
            return Instance._stateColors[(int) (States) Enum.Parse(typeof (States), state, true)];
        }

        // Init method
        private void InitStateColors()
        {
            // Put the intial color on DarkGray
            Color defaultColor = Color.FromKnownColor(KnownColor.DarkGray);

            try
            {
                // Load xml file
                XDocument xml = XDocument.Load(Assembly.GetExecutingAssembly()
                                                       .GetManifestResourceStream("DecisionArchitect." +
                                                                                  "DecisionArchitectMDG.xml"));

                // Loop over all states
                foreach (States state in (States[]) Enum.GetValues(typeof (States)))
                {
                    // State to string
                    string name = Enum.GetName(state.GetType(), state);
                    if (name != null)
                    {
                        string stateStr = name.ToLower();

                        // Query the data and write out a subset of colors
                        IEnumerable<XAttribute> win32Colors = from item in xml.Root.Descendants("Stereotype")
                                                              where
                                                                  (string) item.Attribute("metatype") ==
                                                                  EAConstants.DecisionMetaType &&
                                                                  (string) item.Attribute("name") == stateStr
                                                              select item.Attribute("bgcolor");

                        // Should not contain more then 1 entry
                        foreach (XAttribute win32Color in win32Colors)
                        {
                            _stateColors[(int) state] = ColorTranslator.FromWin32((int) win32Color);
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.Error.WriteLine("Query resulted in more than 1 Color");
            }
            catch (Exception)
            {
                Console.Error.WriteLine("Couldn't find DecisionArchitectMDG.xml");
            }
        }

        private enum States
        {
            Idea = 0,
            Tentative = 1,
            Decided = 2,
            Approved = 3,
            Challenged = 4,
            Discarded = 5,
            Rejected = 6
        }

    }
}