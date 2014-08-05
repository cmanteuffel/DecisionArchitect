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
using EAFacade;

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
            if (!DateTime.TryParse(dateString, CultureInfo.CurrentUICulture, DateTimeStyles.AdjustToUniversal, out parsed))
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
            CustomRichTextBox box = new CustomRichTextBox();
            box.SetRichText(formattedRtf);

            return box.TextBox.Text;
        }

        private static string getLink(string rtfString, int index)
        {
            // "$inet"
          //  rtfString.Remove(index, 4);
          //  rtfString.Insert(index, "http");
            
            string link = "";
            //while (rtfString[index++] != '"'); // Walk untill first "

            while (rtfString[index] != '"')
            {
                link += rtfString[index];
                index++;
            }
            link = link.Replace("$inet", "http");
            return link;
        }

        private static string getTargetName(string rtfString)
        {
            var targetName = "";
            var index = 0;
            while (rtfString[index++] != '{') ; // walk untill first bracket

            while (rtfString[index] != '}')
            {
                targetName += rtfString[index];
                index++;
            }
            var prefix = "\fldrslt";
            targetName = targetName.Substring(prefix.Length + 1, targetName.Length - (prefix.Length + 1)).Trim(' ');
            //MessageBox.Show("TargetName: " + targetName);
            return targetName;
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
                    helperRichTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, richTextBox.Font.Size, helperRichTextBox.SelectionFont.Style);
                    lastFontChange = i;
                }
            }

            if (helperRichTextBox.TextLength == 0)
            {
                richTextBox.Font = new Font(richTextBox.Font.FontFamily, richTextBox.Font.Size, helperRichTextBox.SelectionFont.Style);
                return "";
            }

            helperRichTextBox.SelectionStart = helperRichTextBox.TextLength - 1;
            helperRichTextBox.SelectionLength = 1;
            helperRichTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, richTextBox.Font.Size, helperRichTextBox.SelectionFont.Style);

            // From here on we look for hyperlinks and restore them.
            if (rtfValue.Contains("$inet") && false)
            {
                var index = rtfValue.IndexOf("$inet");
                var link = getLink(rtfValue, index);

                var targetName = getTargetName(rtfValue.Substring(index, rtfValue.Length - index));
                //{\field{\*\fldinst HYPERLINK "$inet://www.google.nl"}{\fldrslt www.google.nl}}
                //MessageBox.Show("Has Link " + index);
                var pos = helperRichTextBox.Text.IndexOf(targetName);
               // helperRichTextBox.Re(pos, targetName.Length + link.Length + 4);
                //helperRichTextBox.Rtf.Remove()
                helperRichTextBox.InsertLink(targetName, link, pos);
                MessageBox.Show("Target: " + targetName + " Link: " + link + " Pos: " + pos);

            }


            return helperRichTextBox.Rtf;

            //var helperRichTextBox = new RichTextBox();
            //helperRichTextBox.Rtf = rtfValue;
            //helperRichTextBox.SelectionStart = 0;
            //helperRichTextBox.SelectionLength = 1;

            //Font lastFont = helperRichTextBox.SelectionFont;
            //int lastFontChange = 0;
            //for (int i = 0; i < helperRichTextBox.TextLength; ++i)
            //{
            //    helperRichTextBox.SelectionStart = i;
            //    helperRichTextBox.SelectionLength = 1;
            //    if (!helperRichTextBox.SelectionFont.Equals(lastFont))
            //    {
            //        lastFont = helperRichTextBox.SelectionFont;
            //        helperRichTextBox.SelectionStart = lastFontChange;
            //        helperRichTextBox.SelectionLength = i - lastFontChange;
            //        helperRichTextBox.SelectionFont = new Font(richTextBox.SelectionFont.FontFamily, richTextBox.SelectionFont.Size, helperRichTextBox.SelectionFont.Style);
            //        lastFontChange = i;
            //    }
            //}
            //helperRichTextBox.SelectionStart = helperRichTextBox.TextLength - 1;
            //helperRichTextBox.SelectionLength = 1;
            //helperRichTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, richTextBox.Font.Size, helperRichTextBox.SelectionFont.Style);

            //richTextBox.SelectedRtf = helperRichTextBox.Rtf;
            //return richTextBox.Rtf;
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
                        Color stateColor = ColorTranslator.FromWin32((int) win32Color);
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
