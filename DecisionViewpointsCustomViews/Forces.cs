using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DecisionViewpointsCustomViews
{
    [ComVisible(true)]
    [Guid("D65970AD-12A7-402A-9F88-ED50D8C1DD82")]
    [ProgId("DecisionViewpointsCustomViews.Forces")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(ICustomView))]
    public class Forces : UserControl, ICustomView
    {
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        
        public Forces()
        {
            InitializeComponent();
        }

        public string GetText()
        {
            return "This is a Forces View!";
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "This will be the forces view!";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 74);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(264, 31);
            this.textBox1.TabIndex = 2;
            // 
            // Forces
            // 
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Forces";
            this.Size = new System.Drawing.Size(362, 216);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
