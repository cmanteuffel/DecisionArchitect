using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using DecisionArchitect.Model;
using DecisionArchitect.Utilities;
using DecisionArchitect.View.Forces;

namespace DecisionArchitect.View.Dialogs
{
    public partial class EditForceRatingDialog : Form
    {
        //public delegate void ForceRatingChangedHandler(object sender, ForceRatingChangedEventArgs e);
        //public event ForceRatingChangedHandler OnForceRatingChanged;

        public ITopicForceEvaluation ForceEvaluation { get; private set; }
        public DecisionEvaluation DecisionEvaluation { get; private set; }
        public int RowIndex { get; private set; }
        public int ColumnIndex { get; private set; }
        public int SelectedColor { get; private set; }
        public string Rating { get; private set; }
        public string Rationale { get; private set; }



        public EditForceRatingDialog(ITopicForceEvaluation evaluation, DecisionEvaluation decisionEvaluation, int rowIndex, int colIndex)
        {
            InitializeComponent();
            txtRating.Text = decisionEvaluation.Rating;
            txtRationale.Text = decisionEvaluation.Rationale;
            ForceEvaluation = evaluation;
            DecisionEvaluation = decisionEvaluation;
            RowIndex = rowIndex;
            ColumnIndex = colIndex;
            SelectedColor = decisionEvaluation.BackgroundColor;

            SetColorPickerBox();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Rating = txtRating.Text;
            Rationale = txtRationale.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        #region ColorPicker

        private static readonly Color[] PickableColors = new Color[] { Color.White, Color.FromArgb(84, 180, 104), Color.FromArgb(163, 190, 109), Color.FromArgb(163, 220, 109), Color.FromArgb(254, 233, 114), Color.FromArgb(220, 167, 105), Color.FromArgb(231, 129, 121), Color.FromArgb(244, 90, 104) };
        private int _customPickedColor = -1;
        private int _clickedColor = -1;
        private bool _didPickCustomColor = false;
        private float _colorBoxWidth;

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            _colorBoxWidth = ((float)pictureBox1.Width)/PickableColors.Length;
            if (_didPickCustomColor)
            {
                _colorBoxWidth = ((float) pictureBox1.Width)/(PickableColors.Length + 1);
                var brush = new SolidBrush(Color.FromArgb(_customPickedColor));
                e.Graphics.FillRectangle(brush, _colorBoxWidth * PickableColors.Length, 0, _colorBoxWidth, pictureBox1.Height);
            }

            for (var i = 0; i < PickableColors.Length; i++)
            {
                var brush = new SolidBrush(PickableColors[i]);
                e.Graphics.FillRectangle(brush, _colorBoxWidth * i, 0, _colorBoxWidth, pictureBox1.Height);
            }

            if (_clickedColor < 0) return;
            var penColor = Utils.GetDesiredForegroundColor(_clickedColor == PickableColors.Length ? Color.FromArgb(_customPickedColor) : PickableColors[_clickedColor]);
            var pen = new Pen(penColor) {Width = 1.5f};

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawLine(pen, _clickedColor * _colorBoxWidth, 0, (_clickedColor + 1) * _colorBoxWidth, pictureBox1.Height);
            e.Graphics.DrawLine(pen, _clickedColor * _colorBoxWidth, pictureBox1.Height, (_clickedColor + 1) * _colorBoxWidth, 0);

        }

        private void SetColorPickerBox()
        {
            
            var found = false;
            for (var i = 0; i < PickableColors.Length; i++)
            {
                if (!PickableColors[i].ToArgb().Equals(SelectedColor)) continue;
                _clickedColor = i;
                found = true;
                break;
            }
            if (!found)
            {
                _didPickCustomColor = true;
                _clickedColor = PickableColors.Length;
                _customPickedColor = SelectedColor;
            }
            pictureBox1.Invalidate();
        }

        #endregion

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            _clickedColor = (int) (e.Location.X/_colorBoxWidth);
            SelectedColor = _clickedColor < PickableColors.Length ? PickableColors[_clickedColor].ToArgb() : _customPickedColor;
            pictureBox1.Invalidate();
        }

        private void buttonPick_Click(object sender, EventArgs e)
        {
            var result = colorDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                _didPickCustomColor = true;
                _customPickedColor = colorDialog1.Color.ToArgb();
                _clickedColor = PickableColors.Length;
                SelectedColor = _customPickedColor;
                pictureBox1.Invalidate();
            }

        }
    }

    
}
