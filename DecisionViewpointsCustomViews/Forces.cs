using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DecisionViewpointsCustomViews
{
    [ComVisible(true)]
    [Guid("D65970AD-12A7-402A-9F88-ED50D8C1DD82")]
    [ProgId("DecisionViewpointsCustomViews.Forces")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(IForces))]
    public class Forces : UserControl, IForces
    {
        private Label label1;
    
        [ComVisible(true)]
        public string GetText()
        {
            return "This is a Forces View!";
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "This will be the forces view!";
            // 
            // Forces
            // 
            this.Controls.Add(this.label1);
            this.Name = "Forces";
            this.Size = new System.Drawing.Size(372, 233);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
