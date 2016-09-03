/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Marc Holterman (University of Groningen)
*/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace DecisionArchitect.View.Components.RichTextBox
{
    public class ToolStripFontComboBox : ToolStripComboBox
    {
        // With of the listbox.

        private readonly Color _selectedTextBoxColor = Color.LightBlue;
        public string DefaultFont = "Microsoft Sans Serif";
        public Boolean DrawPlainText = true;
        protected int DropWidth = 0;
        public Brush TextColor = Brushes.Black;

        // Makes the text in the scrollbar change while selecting
        private Boolean _changeSelectedTextWhileScrolling = false;
        // Makes the text appear in plain text of the Font that is describes

        public ToolStripFontComboBox()
        {
            Items.Clear();
            // Set default font
            // _fonts = new List<string>();
            // Create the list of fonts, and populate the ComboBox with that list
            PopulateFonts();
            // this.ComboBox.DataSource = _fonts;
            ComboBox.Text = DefaultFont;

            // Set the draw mode so we can take over item drawing
            ComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            AutoCompleteMode = AutoCompleteMode.Append;

            // Handle the events
            ComboBox.DropDown += DropDown;
            ComboBox.DropDownClosed += DropDownClosed;
            ComboBox.MeasureItem += MeasureItem;
            ComboBox.DrawItem += DrawItem;

            // I do this to loose the focus in the box....
            ComboBox.CausesValidation = false;
            ComboBox.SelectedText = String.Empty;
            ComboBox.SelectionStart = 0;
        }

        protected new void DropDownClosed(object sender, EventArgs e)
        {
            // Change the color of the selected text in the combobox
            // to your custom color
            ComboBox.ForeColor = Color.Black;
            ComboBox.BackColor = Color.White;
            // Console.WriteLine("DropDownClosed");
        }

        protected new void DropDown(object sender, EventArgs e)
        {
            ComboBox.DropDownWidth = DropWidth;
            //Console.WriteLine("DropDown");
        }

        protected void MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index > -1)
            {
                string szFont = Items[e.Index].ToString();
                Graphics g = ComboBox.CreateGraphics();
                SizeF size = g.MeasureString(szFont, new Font(szFont, Font.Size));

                // Set the Item's Width, and iDropWidth if the item has a greater width
                e.ItemWidth = (int) size.Width;
                if (e.ItemWidth > DropWidth)
                {
                    DropWidth = e.ItemWidth;
                }

                // If .NET gives you problems drawing fonts with different heights, set a maximum height
                e.ItemHeight = (int) size.Height;
                if (e.ItemHeight > 20)
                {
                    e.ItemHeight = 20;
                }
            }
        }

        private void DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw Background
            e.DrawBackground();
            // Highlight the row that is selected
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(_selectedTextBoxColor), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            }

            if (e.Index > -1 && e.Index < ComboBox.Items.Count)
            {
                string fontName = ComboBox.Items[e.Index].ToString();

                if (DrawPlainText)
                {
                    e.Graphics.DrawString(fontName, e.Font, TextColor, e.Bounds.Left, e.Bounds.Top);
                }
                else
                {
                    var cvt = new FontConverter();
                    var font = cvt.ConvertFromString(fontName) as Font;
                    e.Graphics.DrawString(font.Name, font, TextColor, e.Bounds.Left, e.Bounds.Top);
                }

                // Change the text in selection area whilst scrolling
                if (_changeSelectedTextWhileScrolling)
                {
                    ComboBox.Text = fontName;
                }
                //e.DrawFocusRectangle();
            }
        }

        private void PopulateFonts()
        {
            ComboBox.Items.Clear();
            foreach (FontFamily ff in FontFamily.Families)
            {
                if (!ff.IsStyleAvailable(FontStyle.Regular))
                    continue;

                ComboBox.Items.Add(ff.Name);
            }
        }
    }
}