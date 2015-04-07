﻿/*
 * Reference for this code.
   http://www.codeproject.com/Articles/9196/Links-with-arbitrary-text-in-a-RichTextBox

 Contributors:
    Marc Holterman (University of Groningen)
*/

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace DecisionArchitect.View.Components.RichTextBox
{
    public class RichTextBoxEx : System.Windows.Forms.RichTextBox
    {
        #region Interop-Defines


#pragma warning disable 169
        private const int WM_USER = 0x0400;
        private const int EM_GETCHARFORMAT = WM_USER + 58;
        private const int EM_SETCHARFORMAT = WM_USER + 68;

        private const int SCF_SELECTION = 0x0001;
        private const int SCF_WORD = 0x0002;

        private const int SCF_ALL = 0x0004;

        #region CHARFORMAT2 Flags

        private const UInt32 CFE_BOLD = 0x0001;
        private const UInt32 CFE_ITALIC = 0x0002;
        private const UInt32 CFE_UNDERLINE = 0x0004;
        private const UInt32 CFE_STRIKEOUT = 0x0008;
        private const UInt32 CFE_PROTECTED = 0x0010;
        private const UInt32 CFE_LINK = 0x0020;
        private const UInt32 CFE_AUTOCOLOR = 0x40000000;
        private const UInt32 CFE_SUBSCRIPT = 0x00010000; /* Superscript and subscript are */
        private const UInt32 CFE_SUPERSCRIPT = 0x00020000; /*  mutually exclusive       */

        private const int CFM_SMALLCAPS = 0x0040; /* (*)  */
        private const int CFM_ALLCAPS = 0x0080; /* Displayed by 3.0  */
        private const int CFM_HIDDEN = 0x0100; /* Hidden by 3.0 */
        private const int CFM_OUTLINE = 0x0200; /* (*)  */
        private const int CFM_SHADOW = 0x0400; /* (*)  */
        private const int CFM_EMBOSS = 0x0800; /* (*)  */
        private const int CFM_IMPRINT = 0x1000; /* (*)  */
        private const int CFM_DISABLED = 0x2000;
        private const int CFM_REVISED = 0x4000;

        private const int CFM_BACKCOLOR = 0x04000000;
        private const int CFM_LCID = 0x02000000;
        private const int CFM_UNDERLINETYPE = 0x00800000; /* Many displayed by 3.0 */
        private const int CFM_WEIGHT = 0x00400000;
        private const int CFM_SPACING = 0x00200000; /* Displayed by 3.0  */
        private const int CFM_KERNING = 0x00100000; /* (*)  */
        private const int CFM_STYLE = 0x00080000; /* (*)  */
        private const int CFM_ANIMATION = 0x00040000; /* (*)  */
        private const int CFM_REVAUTHOR = 0x00008000;


        private const UInt32 CFM_BOLD = 0x00000001;
        private const UInt32 CFM_ITALIC = 0x00000002;
        private const UInt32 CFM_UNDERLINE = 0x00000004;
        private const UInt32 CFM_STRIKEOUT = 0x00000008;
        private const UInt32 CFM_PROTECTED = 0x00000010;
        private const UInt32 CFM_LINK = 0x00000020;
        private const UInt32 CFM_SIZE = 0x80000000;
        private const UInt32 CFM_COLOR = 0x40000000;
        private const UInt32 CFM_FACE = 0x20000000;
        private const UInt32 CFM_OFFSET = 0x10000000;
        private const UInt32 CFM_CHARSET = 0x08000000;
        private const UInt32 CFM_SUBSCRIPT = CFE_SUBSCRIPT | CFE_SUPERSCRIPT;
        private const UInt32 CFM_SUPERSCRIPT = CFM_SUBSCRIPT;

        private const byte CFU_UNDERLINENONE = 0x00000000;
        private const byte CFU_UNDERLINE = 0x00000001;
        private const byte CFU_UNDERLINEWORD = 0x00000002; /* (*) displayed as ordinary underline  */
        private const byte CFU_UNDERLINEDOUBLE = 0x00000003; /* (*) displayed as ordinary underline  */
        private const byte CFU_UNDERLINEDOTTED = 0x00000004;
        private const byte CFU_UNDERLINEDASH = 0x00000005;
        private const byte CFU_UNDERLINEDASHDOT = 0x00000006;
        private const byte CFU_UNDERLINEDASHDOTDOT = 0x00000007;
        private const byte CFU_UNDERLINEWAVE = 0x00000008;
        private const byte CFU_UNDERLINETHICK = 0x00000009;
        private const byte CFU_UNDERLINEHAIRLINE = 0x0000000A; /* (*) displayed as ordinary underline  */
#pragma warning restore 169

        #endregion

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        private struct CHARFORMAT2_STRUCT
        {
            public UInt32 cbSize;
            public UInt32 dwMask;
            public UInt32 dwEffects;
            private readonly Int32 yHeight;
            private readonly Int32 yOffset;
            private readonly Int32 crTextColor;
            private readonly byte bCharSet;
            private readonly byte bPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] public char[] szFaceName;
            private readonly UInt16 wWeight;
            private readonly UInt16 sSpacing;
            private readonly int crBackColor; // Color.ToArgb() -> int
            private readonly int lcid;
            private readonly int dwReserved;
            private readonly Int16 sStyle;
            private readonly Int16 wKerning;
            private readonly byte bUnderlineType;
            private readonly byte bAnimation;
            private readonly byte bRevAuthor;
            private readonly byte bReserved1;
        }

        #endregion

        public RichTextBoxEx()
        {
            // Otherwise, non-standard links get lost when user starts typing
            // next to a non-standard link
            DetectUrls = false;
        }

        [DefaultValue(false)]
        public new bool DetectUrls
        {
            get { return base.DetectUrls; }
            set { base.DetectUrls = value; }
        }

        /// <summary>
        ///     Insert a given text as a link into the RichTextBox at the current insert position.
        /// </summary>
        /// <param name="text">Text to be inserted</param>
        public void InsertLink(string text)
        {
            InsertLink(text, SelectionStart);
        }

        /// <summary>
        ///     Insert a given text at a given position as a link.
        /// </summary>
        /// <param name="text">Text to be inserted</param>
        /// <param name="position">Insert position</param>
        public void InsertLink(string text, int position)
        {
            if (position < 0 || position > Text.Length)
                throw new ArgumentOutOfRangeException("position");

            SelectionStart = position;
            SelectedText = text;
            Select(position, text.Length);
            SetSelectionLink(true);
            Select(position + text.Length, 0);
        }

        /// <summary>
        ///     Insert a given text at at the current input position as a link.
        ///     The link text is followed by a hash (#) and the given hyperlink text, both of
        ///     them invisible.
        ///     When clicked on, the whole link text and hyperlink string are given in the
        ///     LinkClickedEventArgs.
        /// </summary>
        /// <param name="text">Text to be inserted</param>
        /// <param name="hyperlink">Invisible hyperlink string to be inserted</param>
        public void InsertLink(string text, string hyperlink)
        {
            InsertLink(text, hyperlink, SelectionStart);
        }

        /// <summary>
        ///     Insert a given text at a given position as a link. The link text is followed by
        ///     a hash (#) and the given hyperlink text, both of them invisible.
        ///     When clicked on, the whole link text and hyperlink string are given in the
        ///     LinkClickedEventArgs.
        /// </summary>
        /// <param name="text">Text to be inserted</param>
        /// <param name="hyperlink">Invisible hyperlink string to be inserted</param>
        /// <param name="position">Insert position</param>
        public void InsertLink(string text, string hyperlink, int position)
        {
            if (position < 0 || position > Text.Length)
                throw new ArgumentOutOfRangeException("position");

            SelectionStart = position;
            SelectedRtf = @"{\rtf1\ansi " + text + @"\v #" + hyperlink + @"\v0}";
            Select(position, text.Length + hyperlink.Length + 1);
            SetSelectionLink(true);
            Select(position + text.Length + hyperlink.Length + 1, 0);
        }

        /// <summary>
        ///     Set the current selection's link style
        /// </summary>
        /// <param name="link">true: set link style, false: clear link style</param>
        public void SetSelectionLink(bool link)
        {
            SetSelectionStyle(CFM_LINK, link ? CFE_LINK : 0);
        }

        /// <summary>
        ///     Get the link style for the current selection
        /// </summary>
        /// <returns>0: link style not set, 1: link style set, -1: mixed</returns>
        public int GetSelectionLink()
        {
            return GetSelectionStyle(CFM_LINK, CFE_LINK);
        }

        private void SetSelectionStyle(UInt32 mask, UInt32 effect)
        {
            var cf = new CHARFORMAT2_STRUCT();
            cf.cbSize = (UInt32) Marshal.SizeOf(cf);
            cf.dwMask = mask;
            cf.dwEffects = effect;

            var wpar = new IntPtr(SCF_SELECTION);
            IntPtr lpar = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
            Marshal.StructureToPtr(cf, lpar, false);

            SendMessage(Handle, EM_SETCHARFORMAT, wpar, lpar);

            Marshal.FreeCoTaskMem(lpar);
        }

        private int GetSelectionStyle(UInt32 mask, UInt32 effect)
        {
            var cf = new CHARFORMAT2_STRUCT();
            cf.cbSize = (UInt32) Marshal.SizeOf(cf);
            cf.szFaceName = new char[32];

            var wpar = new IntPtr(SCF_SELECTION);
            IntPtr lpar = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
            Marshal.StructureToPtr(cf, lpar, false);

            SendMessage(Handle, EM_GETCHARFORMAT, wpar, lpar);

            cf = (CHARFORMAT2_STRUCT) Marshal.PtrToStructure(lpar, typeof (CHARFORMAT2_STRUCT));

            int state;
            // dwMask holds the information which properties are consistent throughout the selection:
            if ((cf.dwMask & mask) == mask)
            {
                if ((cf.dwEffects & effect) == effect)
                    state = 1;
                else
                    state = 0;
            }
            else
            {
                state = -1;
            }

            Marshal.FreeCoTaskMem(lpar);
            return state;
        }

        /// <summary>
        ///     This additional code block checks the locations of links
        ///     and desc. it via a string which contains informations of how many links are there
        ///     .Split('&')-1 and the select information .Select(.Split('&')[i].Split('-')[0],.Split('&')[i].Split('-')[1])
        ///     After we select the links we can SetSelectionLink(true) to get our links back.
        /// </summary>
        public string GetLinkPositions()
        {
            string pos = "";
            for (int i = 0; i < TextLength; i++)
            {
                Select(i, 1);
                int isLink = GetSelectionLink();
                if (isLink == 1)
                {
                    //the selected first character is a part of link, now find its last character
                    for (int j = i + 1; j <= TextLength; j++)
                    {
                        Select(j, 1);
                        isLink = GetSelectionLink();
                        if (isLink != 1 || j == TextLength)
                        {
                            //we found the last character's +1 so end char is (j-1), start char is (i)
                            pos += (i) + "-" + ((j - 1) - (i - 1)) + "&";
                            //j-1 to i but i inserted -1 one more so we can determine the right pos
                            i = j; //cont. from j+1
                            break; //exit second for cont. from i = j+1 (i will increase on new i value)
                        }
                    }
                }
            }
            DeselectAll();
            return pos;
        }

        /// <summary>
        ///     This method generates the links back only created via InsertLink(string text)
        ///     and overloaded InsertLink(string text,int position)
        /// </summary>
        /// <param name="pos">the pos string from getLinkPositions</param>
        public void SetLinkPositions(string pos)
        {
            string[] positions = pos.Split('&');
            for (int i = 0; i < positions.Length - 1; i++)
            {
                string[] xy = positions[i].Split('-');
                Select(Int32.Parse(xy[0]), Int32.Parse(xy[1]));
                SetSelectionLink(true);
                Select(Int32.Parse(xy[0]) + Int32.Parse(xy[1]), 0);
            }
            DeselectAll();
        }
    }
}
// ReSharper restore InconsistentNaming