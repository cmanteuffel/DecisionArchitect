/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Mathieu Kalksma (University of Groningen)
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DecisionArchitect.Model;
using DecisionArchitect.Utilities;
using DecisionArchitect.View.Dialogs;

namespace DecisionArchitect.View.Forces
{
    public partial class TopicForceView : DecisionArchitectControl
    {
        private ITopic Topic { get; set; }
        private int _rowIndex;
        private const int FirstDecisionColumnindex = 3;
        private const int ForceWeightColumn = 2;
        private const int ForceColumn = 1;
        private const int ConcernColumn = 0;
        private const int FirstColumnWidth = 30;
        private const int DefaultRowHeight = 30;
        private const string RequirementHeaderText = "Force";

        private bool _isInitizalized;
        private List<ITopicForceEvaluation> Forces { get; set; } 

        public TopicForceView()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.RowTemplate.MinimumHeight = 30;
            dataGridView1.RowTemplate.Height = 30;
        }

        public void Init(ITopic topic)
        {
            Topic = topic;

            Forces = Topic.Forces.OrderBy(f => f.Concern.Name).ToList();
            if (!_isInitizalized)
            {
                AddDecisions();
                foreach (var evaluation in Forces)
                    AddRow(evaluation);
            }
            else
            {
                Reset();
            }
            _isInitizalized = true;
        }


        #region events
        public void OnDecisionChanged(int index, IDecision decision)
        {
           //TODO dit werkt denk ik niet met deletes
            //var column = dataGridView1.Columns[FirstDecisionColumnindex + index];
            //column.HeaderCell.Value = decision.Name;

            //ColorCellAccordingToState(column.HeaderCell, decision.State);   
            OnRevertedChanges(Topic);
        }

        public void OnDecisionAdded(IDecision decision)
        {
            var columnIndex = dataGridView1.Columns.Add(decision.GUID, decision.Name);
            dataGridView1.Columns[columnIndex].ReadOnly = true;
            dataGridView1.Columns[columnIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
            ColorCellAccordingToState(dataGridView1.Columns[columnIndex].HeaderCell, decision.State);

            foreach (var f in Forces) //avoid NPE by creating a new decisionevaluation for this decision
                f.DecisionEvaluations.Add(new DecisionEvaluation(decision, f.Concern, f.Force));
        }

        public void OnDecisionDeleted()
        {
            //just redo everything is the safest way all data will still be stored in the topic
            OnRevertedChanges(Topic);
        }

        public void OnForceAdded()
        {
            Forces = Topic.Forces.OrderBy(f => f.Concern.Name).ToList();
            Reset();
        }

        public void OnRevertedChanges(ITopic topic)
        {
            DeleteAllDecisionColumns();
            _isInitizalized = false;
            _rowIndex = 0;
            dataGridView1.Rows.Clear();
            Init(topic);
        }

        #endregion

        private void DeleteAllDecisionColumns()
        {
            for (var i = dataGridView1.ColumnCount -1; i >= FirstDecisionColumnindex; i--)
            {
                var column = dataGridView1.Columns[i];
                dataGridView1.Columns.Remove(column);
            }
        }

        private void Reset()
        {
            _rowIndex = 0;
            dataGridView1.Rows.Clear();
            foreach (var evaluation in Forces)
                AddRow(evaluation);
        }

        private static DecisionEvaluation GetDecisionEvaluation(ITopicForceEvaluation row, int columnIndex)
        {
            columnIndex -= FirstDecisionColumnindex - 1;

            foreach (var evaluation in row.DecisionEvaluations)
            {
                if (!evaluation.Decision.DoDelete)
                    columnIndex--;

                if (columnIndex == 0)
                    return evaluation;
            }
            throw new Exception("Failure");
        }

        private DataGridViewCell GetCellForDecision(int row, int decisionIndex)
        {
            return dataGridView1.Rows[row].Cells[decisionIndex + FirstDecisionColumnindex];
        }

        #region Verified
        private void AddDecisions()
        {
            foreach (var decision in Topic.Decisions.Where(d => !d.DoDelete))
            {
                var columnIndex = dataGridView1.Columns.Add(decision.GUID, decision.Name);
                dataGridView1.Columns[columnIndex].ReadOnly = true;
                dataGridView1.Columns[columnIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
                ColorCellAccordingToState(dataGridView1.Columns[columnIndex].HeaderCell, decision.State);
            }
        }

        private static string GetConcernNameVertical(string name)
        {
            return string.Join("\n", name.ToCharArray());
        }
        #endregion



        private void AddRow(ITopicForceEvaluation row)
        {
            dataGridView1.Rows.Add(GetConcernNameVertical(row.Concern.Name), row.Force.Name);
            dataGridView1.Rows[_rowIndex].Cells[ForceWeightColumn].Value = row.Weight;

            var index = 0;
            foreach (var evaluation in row.DecisionEvaluations)
            {
                if (evaluation.Decision.DoDelete)
                    continue;

                var cell = GetCellForDecision(_rowIndex, index);
                cell.Value = evaluation.Rating;
                cell.Style.BackColor = Color.FromArgb(evaluation.BackgroundColor);
                cell.Style.ForeColor = Utils.GetDesiredForegroundColor(cell.Style.BackColor);
                index++;
            }
            _rowIndex++;
        }

        

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex >= 0 && e.ColumnIndex >= FirstDecisionColumnindex))
                return;
            var evaluation = Forces[e.RowIndex];

            var decision = GetDecisionEvaluation(evaluation, e.ColumnIndex);
            var dialog = new EditForceRatingDialog(evaluation, decision, e.RowIndex, e.ColumnIndex);
            var dialogResult = dialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                var color = Color.FromArgb(dialog.SelectedColor);
                decision.Rating = dialog.Rating;
                decision.Rationale = dialog.Rationale;
                decision.BackgroundColor = dialog.SelectedColor;
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = decision.Rating;
                cell.Style.BackColor = color;
                cell.Style.ForeColor = Utils.GetDesiredForegroundColor(color);
            }
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < FirstDecisionColumnindex || e.RowIndex < 0)
                return;
            var evaluation = GetDecisionEvaluation(Forces[e.RowIndex], e.ColumnIndex);
            timerShowRationale.Tag = evaluation.Rationale;
            timerShowRationale.Start();
            
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            timerShowRationale.Stop();
            timerShowRationale.Tag = null;
            tooltipRationale.Hide(this);
        }

        private void timerShowRationale_Tick(object sender, EventArgs e)
        {
            var position = PointToClient(Cursor.Position);
            tooltipRationale.Show(timerShowRationale.Tag.ToString(), this, position);
            timerShowRationale.Stop();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != ForceWeightColumn)
                return;
            OnChangedWeight(e);
        }

        private void OnChangedWeight(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= Forces.Count)
                return;

            var objValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            var newValue = objValue != null ? objValue.ToString() : string.Empty;
            float result;
            if (!string.IsNullOrEmpty(newValue) && (!float.TryParse(newValue, out result) || result < 0 || result > 1))
            {
                MessageBox.Show(Messages.WeightShouldBeNumeric);
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Empty;

            }
            else
            {
                var evaluation = Forces[e.RowIndex];
                evaluation.Weight = newValue;
            }
            
        }


        #region Rendering
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (e.ColumnIndex == 0)
                DrawConcernCells(e);
        }


        private void DrawConcernCells(DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= Forces.Count)
                return;

            var firstRowForConcern = e.RowIndex == 0 ||
                                     !Forces[e.RowIndex].Concern.ConcernGUID.Equals(Forces[e.RowIndex - 1].Concern.ConcernGUID);
            if (!firstRowForConcern)
            {
                dataGridView1.Rows[e.RowIndex].Height = DefaultRowHeight;
                dataGridView1.Rows[e.RowIndex].MinimumHeight = DefaultRowHeight;
                e.Handled = true;
                return;
            }

            var concern = Forces[e.RowIndex].Concern.Name;
            var height = GetTotalHeightForConcern(concern, e.RowIndex);

            var textSize = TextRenderer.MeasureText(concern, DefaultFont);
            if (textSize.Width > height)
            {
                //for now only increase the first row as it is easier :)
                //for better visuals probably divide the required height over each row of this concern...
                dataGridView1.Rows[e.RowIndex].Height = textSize.Width - height + DefaultRowHeight;
                dataGridView1.Rows[e.RowIndex].MinimumHeight = textSize.Width - height + DefaultRowHeight;
                height = dataGridView1.Rows[e.RowIndex].Height;
            }
            var rectangle = new RectangleF(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, height - 1);
            var borderRectangle = new RectangleF(rectangle.Left, rectangle.Top, rectangle.Width + 1,
                rectangle.Height + 1);

            var topMargin = (height - textSize.Width) / 2; //to center vertical the text
            var leftMargin = (FirstColumnWidth - textSize.Height) / 2; //to horizontal center the text

            e.Graphics.FillRectangle(Brushes.Black, borderRectangle);
            e.Graphics.FillRectangle(Brushes.White, rectangle);
            e.Graphics.TranslateTransform(0, textSize.Width);
            e.Graphics.RotateTransform(-90.0F);

            e.Graphics.DrawString(concern, DefaultFont, Brushes.Black, new PointF(rectangle.Height - rectangle.Bottom - topMargin, rectangle.Left + leftMargin));


            e.Graphics.RotateTransform(90.0F);
            e.Graphics.TranslateTransform(0, -textSize.Width);


            e.Handled = true;
        }

        private int GetTotalHeightForConcern(string concern, int startIndex)
        {
            var forceIndex = startIndex;
            var totalHeight = 0;
            while (forceIndex < Forces.Count &&
                   Forces[forceIndex].Concern.Name.Equals(concern))
            {
                totalHeight += dataGridView1.Rows[forceIndex].Height;
                forceIndex++;
            }
            return totalHeight;
        }

        /// <summary>
        /// Merges the first two column headers to make it look like 1 cell
        /// </summary>
        /// <param name="e"></param>
        private static void DrawRequirementsHeaderCell(DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;

            var mergedRectangle = new RectangleF(e.CellBounds.Left - FirstColumnWidth, e.CellBounds.Top,
                e.CellBounds.Width + FirstColumnWidth - 1, e.CellBounds.Height - 1);
            var border = new RectangleF(mergedRectangle.Left, mergedRectangle.Top, mergedRectangle.Width + 1,
                mergedRectangle.Height + 1);

            var textSize = TextRenderer.MeasureText(RequirementHeaderText, e.CellStyle.Font);
            var topMargin = (mergedRectangle.Height - textSize.Height) / 2;
            var leftMargin = (mergedRectangle.Width - textSize.Width) / 2;
            var textRectangle = new RectangleF(leftMargin, topMargin, mergedRectangle.Width,
                mergedRectangle.Height);

            e.Graphics.FillRectangle(SystemBrushes.WindowText, border);
            e.Graphics.FillRectangle(SystemBrushes.Control, mergedRectangle);
            e.Graphics.DrawString(RequirementHeaderText, DefaultFont, SystemBrushes.WindowText, textRectangle);
            e.Handled = true;

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex != -1)
                return;
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
                e.FormattingApplied = true;
        }
        #endregion

        #region MouseEvents
        private void addNewForceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new SelectForceDialog(Forces);
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Topic.Forces.Add(new TopicForceEvaluation(Topic, dialog.Force, dialog.Concern, Topic.Decisions));
                //Init(Topic);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedRowIndex == -1) return;
            var evaluation = Forces[_selectedRowIndex];

            evaluation.Delete();
            Forces.RemoveAt(_selectedRowIndex);
            Reset();

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip2.Show(Cursor.Position);
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //dataGridView1.Rows.RemoveAt(_selectedRowIndex);
        }

        private int _selectedRowIndex = -1;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            for (var i = 0; i < dataGridView1.RowCount; i++)
                dataGridView1.Rows[i].Selected = false;

            if (e.RowIndex == -1)
                contextMenuStrip2.Show(Cursor.Position);
            else
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                _selectedRowIndex = e.RowIndex;
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            switch (e.ColumnIndex)
            {
                case ForceColumn:
                    SortForces(_forceComparer, true);
                    break;
                case ForceWeightColumn:
                    SortForces(_weightComparer, true);
                    break;
                case ConcernColumn:
                    SortByConcerns();
                    break;
            }
        }
        #endregion

        #region Sorting
        private void SortForces(ForceComparer comparer, bool switchOrder)
        {
            if (Forces.Count == 0)
                return;
            _currentComparer = comparer;
            if (switchOrder)
                comparer.SortState = comparer.SortState == SortState.Ascending ? SortState.Descending : SortState.Ascending;
            var forceIndex = 0;
            while (forceIndex < Forces.Count)
            {
                var currentConcern = Forces[forceIndex].Concern.ConcernGUID;
                var concernCount = GetForcesCountForConcern(currentConcern, forceIndex);
                Forces.Sort(forceIndex, concernCount, comparer);
                forceIndex += concernCount;
            }
            Reset();
        }

        private void SortByConcerns()
        {
            Forces = Forces.OrderBy(f => f.Concern.Name).ToList();
            if (_concernSortState == SortState.Ascending)
            {
                _concernSortState = SortState.Descending;
                Forces.Reverse();
            }
            else
            {
                _concernSortState = SortState.Ascending;
            }
            if (_currentComparer != null)
                SortForces(_currentComparer, false);
            Reset();
        }

        private SortState _concernSortState = SortState.Ascending;



        private class ForceComparer : IComparer<ITopicForceEvaluation>
        {
            public ForceComparer(int column)
            {
                _column = column;
            }

            public SortState SortState = SortState.None;
            private readonly int _column;

            public int Compare(ITopicForceEvaluation x, ITopicForceEvaluation y)
            {
                var multiplier = SortState == SortState.Descending ? -1 : 1;
                switch (_column)
                {
                    case ForceColumn:
                        return CompareForce(x, y, multiplier);
                    case ForceWeightColumn:
                        return CompareWeight(x, y, multiplier);
                }
                return 0;
            }

            private static int CompareForce(ITopicForceEvaluation x, ITopicForceEvaluation y, int multiplier)
            {
                // ReSharper disable once StringCompareToIsCultureSpecific
                return x.Force.Name.CompareTo(y.Force.Name) * multiplier;
            }

            private static int CompareWeight(ITopicForceEvaluation x, ITopicForceEvaluation y, int multiplier)
            {
                float weightX;
                float weightY;
                float.TryParse(x.Weight, out weightX);
                float.TryParse(y.Weight, out weightY);
                return weightX.CompareTo(weightY) * multiplier;
            }
        }

        private enum SortState
        {
            None,
            Ascending,
            Descending
        };

        private readonly ForceComparer _forceComparer = new ForceComparer(ForceColumn);
        private readonly ForceComparer _weightComparer = new ForceComparer(ForceWeightColumn);
        private ForceComparer _currentComparer;

        private int GetForcesCountForConcern(string concernGUID, int forceIndex)
        {
            var count = 0;
            while (forceIndex < Forces.Count && Forces[forceIndex].Concern.ConcernGUID.Equals(concernGUID))
            {
                count++;
                forceIndex++;
            }
            return count;

        }

        #endregion

        

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var row = e.RowIndex + e.RowCount;
            if (e.RowIndex + e.RowCount < Forces.Count) return;
            if (row >= dataGridView1.RowCount) return;
            dataGridView1.Rows[row].Cells[1].ReadOnly = false;
            dataGridView1.Rows[row].Cells[0].ReadOnly = false;
        }

        
        
    }
}
