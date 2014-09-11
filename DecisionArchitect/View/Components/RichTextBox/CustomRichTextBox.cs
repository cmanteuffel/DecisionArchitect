using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace DecisionArchitect.View.RichTextBox
{
    public partial class CustomRichTextBox : UserControl
    {
        public CustomRichTextBox()
        {
            InitializeComponent();
        }

        /*
         * These are the Ratiuonale RichtextField implementation Functions
         */

        private void buttonBold_Click(object sender, EventArgs e)
        {
            TextBox.SelectionFont = new Font(TextBox.Font,
                                             TextBox.SelectionFont.Style ^ FontStyle.Bold);
        }

        private void buttonItalics_Click(object sender, EventArgs e)
        {
            TextBox.SelectionFont = new Font(TextBox.Font,
                                             TextBox.SelectionFont.Style ^ FontStyle.Italic);
        }

        private void buttonUnderline_Click(object sender, EventArgs e)
        {
            TextBox.SelectionFont = new Font(TextBox.Font,
                                             TextBox.SelectionFont.Style ^ FontStyle.Underline);
        }

        private void buttonBulletList_Click(object sender, EventArgs e)
        {
            TextBox.SelectionBullet = !TextBox.SelectionBullet;
        }

        private void buttonHyperlink_Click(object sender, EventArgs e)
        {
            //txtRationale.HideSelection = false;
            var hyperLinkWindow = new HyperLinkWindow(TextBox.SelectedText);
            // Show the HyperlinkForm form and insert if OK
            if (hyperLinkWindow.ShowDialog() == DialogResult.OK && hyperLinkWindow.Address.Length > 0)
            {
                string url = hyperLinkWindow.Address;
                // prefix http:// is neccesary
                //if (!url.match(/^https?:\/\//i.test(url))) {
                //    url = 'http://' + url;
                //}
                url = (!url.Contains("://")) ? "http://" + url : url;
                // Check if the url is valid
                string targetName;
                if (hyperLinkWindow.TargetName.Length > 0)
                {
                    targetName = hyperLinkWindow.TargetName;
                }
                else
                {
                    targetName = hyperLinkWindow.Address;
                }
                TextBox.InsertLink(targetName, url);
                TextBox.AppendText(" ");
                // System.Diagnostics.Debug.WriteLine("targetName: " + targetName + " url " + url);
                //MessageBox.Show(url);
            }
            //txtRationale.HideSelection = true;
        }

        public void SetEnabled(bool value)
        {
            Enabled = value;
            pnlRationale.Enabled = value;

            if (value)
            {
                plnBackground.BackColor = SystemColors.Window;
            }
            else
            {
                plnBackground.BackColor = SystemColors.Control;
            }
        }

        private void cmboxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Console.WriteLine("He was clsoed by Jim!");

            //if (this.cmboxFont.SelectedIndex > -1 && this.cmboxFont.SelectedIndex < this.cmboxFont.Items.Count)
            //{
            //   string fontName = this.cmboxFont.SelectedItem as string;
            //   txtRationale.SelectionFont = new System.Drawing.Font(new Font(fontName, txtRationale.SelectionFont.Size), txtRationale.SelectionFont.Style);
            //this.cmboxFont.Text = ff.Name.ToString();
            // this.cmboxFont.Text = txtRationale.SelectionFont.Name;
            // Console.WriteLine("Selected Font = " + this.cmboxFont.Text);
            //}
        }

        private void txtRationale_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            string input = e.LinkText;
            int index = input.IndexOf("#");
            if (index > 0)
            {
                // MessageBox.Show("Ja: " + index + " " + e.LinkText.Length + " | " + e.LinkText + " sub: " + input.Substring(index + 1, e.LinkText.Length - (index + 1)));
                input = input.Substring(index + 1, input.Length - (index + 1));
            }
            else
            {
                // Hidden string 
                // @"{\rtf1\ansi " + text + @"\v #" + hyperlink + @"\v0}";
                // first use prefixText to find the link
                string prefixLinkText = e.LinkText + @"\v #";
                // cut of all the text untill that so now we are here
                int preFixIndex = TextBox.Rtf.IndexOf(prefixLinkText);

                string linkText = TextBox.Rtf.Substring(preFixIndex + prefixLinkText.Length);

                // use the postFix @"\v0" indexOf.
                string postFix = @"\v0";
                int postIndex = linkText.IndexOf(postFix);

                // THat is the endpos of the url the link is inbetween 0 and postIndex.
                string link = linkText.Substring(0, postIndex);

                if (link.IndexOf(@"\") > 0 && link.IndexOf(@"\") < linkText.Length)
                {
                    link = linkText.Substring(0, link.IndexOf(@"\"));
                }

                input = link;
            }

            try
            {
                Uri myUri;
                Uri.TryCreate(input, UriKind.Absolute, out myUri);
                var request = WebRequest.Create(myUri) as HttpWebRequest;
                var response = request.GetResponse() as HttpWebResponse;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    // DateTime endTime2; p1.CloseMainWindow(); //endTime2 = p1.ExitTime; p1.Close()
                    Process.Start(input);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open " + input + ". Cannot locate the Internet server or proxy server.\n" +
                                ex.Data);
            }
        }

        /*
         * Detail richttextbox related functions
         */

        private void txtRationale_CursorChanged(object sender, EventArgs e)
        {
            // MessageBox.Show("Cursos Changed");
        }

        private void txtRationale_SelectionChanged(object sender, EventArgs e)
        {
            HandleSelectionChange();
        }

        private void HandleSelectionChange()
        {
            if (TextBox.SelectionFont != null)
            {
                btnBold.Checked = TextBox.SelectionFont.Bold;
                btnItalics.Checked = TextBox.SelectionFont.Italic;
                btnUnderline.Checked = TextBox.SelectionFont.Underline;
            }
            btnBulletList.Checked = TextBox.SelectionBullet;
        }

        /********************************************************************************************
         ** TextChanged Events    
         ********************************************************************************************/

        private void txtRationale_Leave(object sender, EventArgs e)
        {
        }

        private void txtRationale_TextChanged(object sender, EventArgs e)
        {
        }

        public string RichText {
            get
            {
                var extraData = new StringBuilder();
                extraData.Append(String.Format("{0}{1}{2}", DataTags.RtfData, TextBox.Rtf.Trim(' '),
                                               DataTags.RtfData));
                extraData.Append(String.Format("{0}{1}{2}", DataTags.LinkPositions, TextBox.GetLinkPositions(),
                                               DataTags.LinkPositions));
                return extraData.ToString();
            }
            set
            {
                 TextBox.Rtf = GetSubstring(DataTags.RtfData, value);
                 TextBox.SetLinkPositions(GetSubstring(DataTags.LinkPositions, value));
            }
        }



        public static string GetSubstring(string tag, string rtfString)
        {
            int first = rtfString.IndexOf(tag, StringComparison.Ordinal) + tag.Length;
            int last = rtfString.LastIndexOf(tag, StringComparison.Ordinal);
            return last > first ? rtfString.Substring(first, last - first) : "";
        }

        public static class DataTags
        {
            public const string RtfData = "{rtfData}";
            public const string LinkPositions = "{linkPositions}";
        }
    }
}