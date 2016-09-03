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
using DecisionArchitect.Logic.EventHandler;
using DecisionArchitect.Model;
using DecisionArchitect.Utilities;

namespace DecisionArchitect.View.Chronology
{
    public partial class ChronologyView : UserControl
    {
        public ChronologyView()
        {
            InitializeComponent();

            _defaultMenuColor = noneToolStripMenuItem.BackColor;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.RowTemplate.MinimumHeight = dataGridView1.RowTemplate.Height;
        
        }

        private class HistoryRow: IComparable
        {
            public DateTime Date { get; set; }
            public IList<IHistoryEntry> HistoryEntries { get; set; }
            public int CompareTo(object obj)
            {
                return Date.CompareTo(((HistoryRow) obj).Date);
            }
        }


        private IList<IDecision> Decisions { get; set; }
        private IList<HistoryRow> _histories;
        

        private enum ZoomState
        {
            None,
            Hour,
            Day,
            Week,
            Month
        };

        private const int FirstDecisionColumn = 1;
        private const string HourFormat = "dd-MM-yyyy HH:mm";
        private const string NoneFormat = "dd-MM-yyyy HH:mm:ss";
        private const string DayFormat = "dd-MM-yyyy";
        private const string WeekFormat = "dd-MM-yyyy";
        private const string MonthFormat = "MM-yyyy";
        private ZoomState _zoomState;
        private readonly Color _defaultMenuColor;

        public void Refresh(IList<IDecision> decisions)
        {
            
            Decisions = decisions;
            //FixHistories();
            _zoomState = ZoomState.None;
            LoadHistoryEntries();
            if (dataGridView1.ColumnCount - FirstDecisionColumn < decisions.Count)
                AddDecisions();
            ShowEntries();
            noneToolStripMenuItem_Click(noneToolStripMenuItem, null);
        }

        public void OnDecisionDeleted()
        {
            RefreshAll(Decisions);
        }

        public void RefreshAll(IList<IDecision> decisions )
        {
            for (var i = dataGridView1.ColumnCount - 1; i >= FirstDecisionColumn; i--)
            {
                var column = dataGridView1.Columns[i];
                dataGridView1.Columns.Remove(column);
            }
            dataGridView1.Rows.Clear();
            Refresh(decisions);            
        }

        private void ShowEntries()
        {
            dataGridView1.Rows.Clear();
            AddEntries();
        }

        private IDecision GetDecision(int columnIndex)
        {
            var decisions = Decisions.Where(x => !x.DoDelete).ToList();
            return decisions[columnIndex - 1];
        }

        private void AddDecisions()
        {
            foreach (var columnIndex in Decisions.Where(d => !d.DoDelete).Select(decision => dataGridView1.Columns.Add(decision.GUID, decision.Name)))
            {
                dataGridView1.Columns[columnIndex].ReadOnly = true;
            }
        }

        private void AddEntries()
        {
            foreach (var historyRow in _histories)
            {
                dataGridView1.Rows.Add(historyRow.Date);
            }      
        }

        private void LoadHistoryEntries()
        {
            _histories = new List<HistoryRow>();
            foreach (var history in Decisions.Where(d => !d.DoDelete).SelectMany(decision => decision.History))
            {
                _histories.Add(new HistoryRow
                {
                    Date = history.Modified,
                    HistoryEntries = new[] {history}.ToList()
                });
            }
            _histories = _histories.OrderByDescending(x => x.Date).ToList();
        }


        private void Zoom(TimeSpan span)
        {
            _histories = new List<HistoryRow>();
            foreach (var history in Decisions.SelectMany(decision => decision.History))
            {
                DateTime roundedTime;
                if (span == TimeSpan.Zero) //month hack as you cannot show month in ticks
                    roundedTime = new DateTime(history.Modified.Year, history.Modified.Month, 1);
                else
                    roundedTime = new DateTime((history.Modified.Ticks / span.Ticks) * span.Ticks);

                var existingRow = (from x in _histories where x.Date.Equals(roundedTime) select x).FirstOrDefault();

                if (existingRow == null)
                {
                    _histories.Add(new HistoryRow
                    {
                        Date = roundedTime,
                        HistoryEntries = new[] {history}.ToList()
                    });
                }
                else
                {
                    existingRow.HistoryEntries.Add(history);
                }
            }
            _histories = _histories.OrderByDescending(x => x.Date).ToList();
            
        }

        private void Zoom(ZoomState zoom)
        {
            if (_zoomState == zoom)
                return;
            _zoomState = zoom;

            switch (zoom)
            {
                case ZoomState.None:
                    LoadHistoryEntries();
                    break;
                case ZoomState.Hour:
                    Zoom(new TimeSpan(0, 1, 0, 0));
                    break;
                case ZoomState.Day:
                    Zoom(new TimeSpan(1, 0, 0, 0));
                    break;
                case ZoomState.Week:
                    Zoom(new TimeSpan(7, 0,0,0));
                    break;
                case ZoomState.Month:
                    Zoom(TimeSpan.Zero); //months dont work with a timespan
                    break;
            }
            ShowEntries();
            FormatDates();
        }

        private void FormatDates()
        {
            var format = NoneFormat;
            switch (_zoomState)
            {
                case ZoomState.Hour:
                    format = HourFormat;
                    break;
                case ZoomState.Day:
                    format = DayFormat;
                    break;
                case ZoomState.Week:
                    format = WeekFormat;
                    for (var i = 0; i < _histories.Count; i++)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = 
                            _histories[i].Date.ToString(format) + " - " +
                            _histories[i].Date.AddDays(7).ToString(format);
                    }

                    return;
                    case ZoomState.Month:
                    format = MonthFormat;
                    break;
            }

            for (var i = 0; i < _histories.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = _histories[i].Date.ToString(format);
            }
        }

        private const int RectangleMargin = 5;
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < FirstDecisionColumn)
            {
                ResizeRow(e.RowIndex);
                return;
            }

            var historyRow = _histories[e.RowIndex];
            if (e.ColumnIndex - FirstDecisionColumn >= Decisions.Count)
                return;
            var decision = GetDecision(e.ColumnIndex);
            //var decision = Decisions[e.ColumnIndex - FirstDecisionColumn];
            //TODO this wont work with new decisions.. or might as a new one doesnt have any :P
            var entries =
                (from x in historyRow.HistoryEntries where x.Decision.GUID.Equals(decision.GUID) select x).ToList();

            e.Graphics.FillRectangle(Brushes.White, e.CellBounds);

            if (!entries.Any())
            {
                e.Graphics.DrawLine(Pens.Black, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                e.Handled = true;
                return;
            }
            e.Graphics.FillRectangle(Brushes.White, e.CellBounds);
            for (var i =entries.Count() -1; i >= 0; i--)
            {
                DrawEntry(entries[i], e, i);
            }
            e.Graphics.DrawLine(Pens.Black, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
            e.Handled = true;
        }

        private void DrawEntry(IHistoryEntry entry, DataGridViewCellPaintingEventArgs e, int i)
        {
            
            var color = DecisionStateColor.ConvertStateToColor(entry.State);

            var rectangle = new Rectangle(
                e.CellBounds.X + RectangleMargin, 
                e.CellBounds.Y + (i * dataGridView1.RowTemplate.Height) + RectangleMargin, 
                e.CellBounds.Width - (2 * RectangleMargin), 
                dataGridView1.RowTemplate.Height - 2 * RectangleMargin);
            

            var path = RoundedRectangle.Create(rectangle);
            e.Graphics.FillPath(new SolidBrush(color), path);

            //e.Graphics.FillRectangle(new SolidBrush(color), rectangle);

            var text = entry.Decision.Name;
            var temp = text;
            var stringSize = e.Graphics.MeasureString(text, DefaultFont);
            while (stringSize.Width > rectangle.Width)
            {
                if (text.Length < 2) break;
                text = text.Substring(0, text.Length - 2);
                temp = text + "..";
                stringSize = e.Graphics.MeasureString(temp, DefaultFont);
            }
            var horizontalMargin = (rectangle.Width - stringSize.Width) / 2;
            var verticalMargin = (rectangle.Height - stringSize.Height) / 2;



            var textRectangle = new RectangleF(rectangle.X + horizontalMargin, rectangle.Y + verticalMargin, stringSize.Width, stringSize.Height);
            e.Graphics.DrawString(temp, DefaultFont, Brushes.Black, textRectangle);
            
        }

        private void ResizeRow(int rowIndex)
        {
            var row = _histories[rowIndex];
            var max = row.HistoryEntries.GroupBy(x => x.Decision.GUID).Max(g => g.Count());
            var requiredHeight = dataGridView1.RowTemplate.Height * max;
            if (dataGridView1.Rows[rowIndex].Height != requiredHeight)
            {
                dataGridView1.Rows[rowIndex].Height = dataGridView1.RowTemplate.Height*max;
                dataGridView1.Rows[rowIndex].MinimumHeight = dataGridView1.RowTemplate.Height*max;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) return;
            var decision = Decisions[e.ColumnIndex - FirstDecisionColumn];
            DetailViewHandler.Instance.OpenDecisionDetailView(decision);   
        }

        private void timerShowState_Tick(object sender, EventArgs e)
        {
            timerShowState.Stop();
            var position = dataGridView1.PointToClient(Cursor.Position);
            var entry = (HistoryEntry) timerShowState.Tag;
            var text = entry.Decision.Name + " " + entry.State;
            toolTip1.Show(text, this, position);
        }

       

        #region menu
        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom(ZoomState.None);
            UpdateMenu(sender);
        }

        private void UpdateMenu(object clickedMenu)
        {
            var menuItem = clickedMenu as ToolStripMenuItem;
            noneToolStripMenuItem.BackColor = _defaultMenuColor;
            hourToolStripMenuItem.BackColor = _defaultMenuColor;
            dayToolStripMenuItem.BackColor = _defaultMenuColor;
            weekToolStripMenuItem.BackColor = _defaultMenuColor;
            monthToolStripMenuItem.BackColor = _defaultMenuColor;

            if (menuItem != null) menuItem.BackColor = ColorTranslator.FromHtml("#C2E0FF");
        }

        private void hourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom(ZoomState.Hour);
            UpdateMenu(sender);
        }

        private void dayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom(ZoomState.Day);
            UpdateMenu(sender);
        }

        private void weekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom(ZoomState.Week);
            UpdateMenu(sender);
        }

        private void monthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom(ZoomState.Month);
            UpdateMenu(sender);
        }

        #endregion

        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < FirstDecisionColumn || e.RowIndex < 0)
            {
                timerShowState.Stop();
                toolTip1.Hide(this);
                return;
            }

            var decision = GetDecision(e.ColumnIndex);

            var yOffset = e.Y;
            var historyIndex = (yOffset / dataGridView1.RowTemplate.Height);


            var temp =
                (from x in _histories[e.RowIndex].HistoryEntries where x.Decision.GUID.Equals(decision.GUID) select x)
                    .ToList();
            if (!temp.Any() || historyIndex >= temp.Count)
            {
                timerShowState.Stop();
                toolTip1.Hide(this);
                return;
            }

            //if (historyIndex >= temp.Count)
            //    historyIndex = temp.Count - 1;
            //if (historyIndex < 0)
            //    return;
            var historyEntry = temp[historyIndex];
            var timerEntry = (HistoryEntry) timerShowState.Tag;
            if (timerEntry != null && historyEntry.TaggedValueGUID.Equals(timerEntry.TaggedValueGUID) && historyEntry.Decision.GUID.Equals(timerEntry.Decision.GUID))
                return;
            toolTip1.Hide(this);
            timerShowState.Tag = historyEntry;
            timerShowState.Start();

        }

        private void dataGridView1_MouseLeave(object sender, EventArgs e)
        {
            timerShowState.Stop();
            toolTip1.Hide(this);
        }


    }
}
