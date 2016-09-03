namespace DecisionArchitect.View.Components.RichTextBox
{
    partial class CustomRichTextBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomRichTextBox));
            this.pnlRationale = new System.Windows.Forms.Panel();
            this.plnBackground = new System.Windows.Forms.Panel();
            this.TextBox = new RichTextBoxEx();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBold = new System.Windows.Forms.ToolStripButton();
            this.btnItalics = new System.Windows.Forms.ToolStripButton();
            this.btnUnderline = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBulletList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnInsertHyperlink = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.pnlRationale.SuspendLayout();
            this.plnBackground.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRationale
            // 
            this.pnlRationale.BackColor = System.Drawing.Color.Transparent;
            this.pnlRationale.Controls.Add(this.plnBackground);
            this.pnlRationale.Controls.Add(this.toolStrip1);
            this.pnlRationale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRationale.Location = new System.Drawing.Point(0, 0);
            this.pnlRationale.Name = "pnlRationale";
            this.pnlRationale.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.pnlRationale.Size = new System.Drawing.Size(676, 356);
            this.pnlRationale.TabIndex = 99;
            // 
            // plnBackground
            // 
            this.plnBackground.BackColor = System.Drawing.SystemColors.Window;
            this.plnBackground.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plnBackground.Controls.Add(this.TextBox);
            this.plnBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plnBackground.Location = new System.Drawing.Point(5, 25);
            this.plnBackground.Name = "plnBackground";
            this.plnBackground.Padding = new System.Windows.Forms.Padding(8);
            this.plnBackground.Size = new System.Drawing.Size(666, 326);
            this.plnBackground.TabIndex = 55;
            // 
            // TextBox
            // 
            this.TextBox.AcceptsTab = true;
            this.TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox.BulletIndent = 2;
            this.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox.Location = new System.Drawing.Point(8, 8);
            this.TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(646, 306);
            this.TextBox.TabIndex = 53;
            this.TextBox.Text = "";
            this.TextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtRationale_LinkClicked);
            this.TextBox.SelectionChanged += new System.EventHandler(this.txtRationale_SelectionChanged);
            this.TextBox.CursorChanged += new System.EventHandler(this.txtRationale_CursorChanged);
            this.TextBox.TextChanged += new System.EventHandler(this.txtRationale_TextChanged);
            this.TextBox.Leave += new System.EventHandler(this.txtRationale_Leave);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.btnBold,
            this.btnItalics,
            this.btnUnderline,
            this.toolStripSeparator1,
            this.btnBulletList,
            this.toolStripSeparator3,
            this.btnInsertHyperlink,
            this.toolStripSeparator4});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(5, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(666, 25);
            this.toolStrip1.TabIndex = 54;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.TextChanged += new System.EventHandler(this.txtRationale_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnBold
            // 
            this.btnBold.AutoToolTip = false;
            this.btnBold.BackColor = System.Drawing.SystemColors.Control;
            this.btnBold.CheckOnClick = true;
            this.btnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnBold.Image = ((System.Drawing.Image)(resources.GetObject("btnBold.Image")));
            this.btnBold.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(23, 22);
            this.btnBold.Text = "B";
            this.btnBold.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnBold.ToolTipText = "Make the selected text bold.";
            this.btnBold.Click += new System.EventHandler(this.buttonBold_Click);
            // 
            // btnItalics
            // 
            this.btnItalics.AutoToolTip = false;
            this.btnItalics.BackColor = System.Drawing.SystemColors.Control;
            this.btnItalics.CheckOnClick = true;
            this.btnItalics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnItalics.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.btnItalics.Image = ((System.Drawing.Image)(resources.GetObject("btnItalics.Image")));
            this.btnItalics.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnItalics.Name = "btnItalics";
            this.btnItalics.Size = new System.Drawing.Size(23, 22);
            this.btnItalics.Text = "I";
            this.btnItalics.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnItalics.ToolTipText = "Italicize the selected text.";
            this.btnItalics.Click += new System.EventHandler(this.buttonItalics_Click);
            // 
            // btnUnderline
            // 
            this.btnUnderline.AutoToolTip = false;
            this.btnUnderline.BackColor = System.Drawing.SystemColors.Control;
            this.btnUnderline.CheckOnClick = true;
            this.btnUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUnderline.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline);
            this.btnUnderline.Image = ((System.Drawing.Image)(resources.GetObject("btnUnderline.Image")));
            this.btnUnderline.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUnderline.Name = "btnUnderline";
            this.btnUnderline.Size = new System.Drawing.Size(23, 22);
            this.btnUnderline.Text = "U";
            this.btnUnderline.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnUnderline.ToolTipText = "Underline the selected text.";
            this.btnUnderline.Click += new System.EventHandler(this.buttonUnderline_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnBulletList
            // 
            this.btnBulletList.CheckOnClick = true;
            this.btnBulletList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBulletList.Image = ((System.Drawing.Image)(resources.GetObject("btnBulletList.Image")));
            this.btnBulletList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBulletList.Name = "btnBulletList";
            this.btnBulletList.Size = new System.Drawing.Size(23, 22);
            this.btnBulletList.Text = "btnBulletList";
            this.btnBulletList.ToolTipText = "Start a bulletlist.";
            this.btnBulletList.Click += new System.EventHandler(this.buttonBulletList_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnInsertHyperlink
            // 
            this.btnInsertHyperlink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInsertHyperlink.Image = ((System.Drawing.Image)(resources.GetObject("btnInsertHyperlink.Image")));
            this.btnInsertHyperlink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInsertHyperlink.Name = "btnInsertHyperlink";
            this.btnInsertHyperlink.Size = new System.Drawing.Size(23, 22);
            this.btnInsertHyperlink.Text = "btnInsertHyperlink";
            this.btnInsertHyperlink.ToolTipText = "Create a link to a webpage or to a file.";
            this.btnInsertHyperlink.Click += new System.EventHandler(this.buttonHyperlink_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // RichTextPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlRationale);
            this.Name = "RichTextPanel";
            this.Size = new System.Drawing.Size(676, 356);
            this.pnlRationale.ResumeLayout(false);
            this.pnlRationale.PerformLayout();
            this.plnBackground.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRationale;
        private System.Windows.Forms.Panel plnBackground;
        public RichTextBoxEx TextBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnBold;
        private System.Windows.Forms.ToolStripButton btnItalics;
        private System.Windows.Forms.ToolStripButton btnUnderline;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnBulletList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnInsertHyperlink;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;


    }
}
