using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using DecisionArchitect.Model;
using DecisionArchitect.Utilities;
using DecisionArchitect.View.Dialogs;

namespace DecisionArchitect.View.Stakeholders
{
    public partial class StakeholdersView : UserControl
    {
        private IList<IStakeholderAction> _stakeHolders;
        private IList<IDecision> _decisions;
        private const string StakeHolderIdentifier = "DA::StakeholderAction::";
        private const int NameRowHeight = 25;
        private ITopic _topic;
        private TopicViewController _topicView;

        private enum SortState
        {
            Stakeholder,
            Decision,
            Action
        };
        private SortState _currentSortState = SortState.Stakeholder;
        private readonly Color _defaultMenuColor;


        public StakeholdersView()
        {
            InitializeComponent();
            _defaultMenuColor = stakeholderToolStripMenuItem.BackColor;
        }

        public void Show(TopicViewController topicView, IList<IDecision> decisions)
        {
            _topic = topicView.Topic;
            _topicView = topicView;
            _decisions = decisions;
            ReloadData();
            RefreshData();
        }

        private void ReloadData()
        {
            var query = _decisions.SelectMany(x => x.Stakeholders);
            switch (_currentSortState)
            {
                case SortState.Stakeholder:
                    _stakeHolders = query.OrderBy(g => g.Stakeholder.Name).ToList();
                    break;
                case SortState.Decision:
                    _stakeHolders = query.OrderBy(g => g.Decision.Name).ToList();
                    break;
                case SortState.Action:
                    _stakeHolders = query.OrderBy(g => g.Action).ToList();
                    break;
            }
            
            _stakeHolders = (from x in _stakeHolders where !x.DoDelete select x).ToList();
        }

        private void RefreshData()
        {
            dataGridView1.Rows.Clear();

            var lastAddedRow = string.Empty;

            foreach (var stakeholderAction in _stakeHolders)
            {
                var rowIdentifier = GetRowIdentifier(stakeholderAction);
                var rowName = GetRowName(stakeholderAction);

                if (lastAddedRow != rowIdentifier)
                {
                    var index = dataGridView1.Rows.Add(rowName);
                    dataGridView1.Rows[index].Height = NameRowHeight;
                    dataGridView1.Rows[index].Cells[0].Style.BackColor = Color.Gainsboro;
                    dataGridView1.Rows[index].Cells[0].Style.SelectionBackColor = Color.Gainsboro;
                    lastAddedRow = rowIdentifier;
                }
                dataGridView1.Rows.Add(StakeHolderIdentifier);
            }
        }

        private string GetRowIdentifier(IStakeholderAction stakeholderAction)
        {
            switch (_currentSortState)
            {
                case SortState.Stakeholder:
                    return stakeholderAction.Stakeholder.GUID;
                    case SortState.Decision:
                    return stakeholderAction.Decision.GUID;
                default:
                    return stakeholderAction.Action;
            }
        }

        private string GetRowName(IStakeholderAction stakeholderAction)
        {
            switch (_currentSortState)
            {
                case SortState.Stakeholder:
                    return stakeholderAction.Stakeholder.Name;
                case SortState.Decision:
                    return stakeholderAction.Decision.Name;
                default:
                    return stakeholderAction.Action;
            }
        }

        private bool IsNameRow(int row)
        {
            return !dataGridView1.Rows[row].Cells[0].Value.Equals(StakeHolderIdentifier);
            //if (row == 0) return true;
            //return !_stakeHolders[row].Stakeholder.GUID.Equals(_stakeHolders[row - 1].Stakeholder.GUID);
        }

        private IStakeholderAction GetStakeholderActionForRow(int row)
        {
            var index = row;
            for (var i = 0; i < row; i++)
            {
                if (IsNameRow(i))
                    index--;
            }
            return _stakeHolders[index];
        }

        //private IStakeholderAction GetStakeholderActionForRow(int row)
        //{
        //    var tempGuid = string.Empty;
        //    var stakeholderIndex = row;
        //    for (var i = 0; i < row && i < _stakeHolders.Count; i++)
        //    {
        //        var rowId = GetRowIdentifier(_stakeHolders[i]);
        //        if (!rowId.Equals(tempGuid))
        //        {
        //            tempGuid = rowId;
        //            stakeholderIndex--; 
        //        }
        //    }
        //    return _stakeHolders[stakeholderIndex];
        //}


        private string GetActionButtonText(IStakeholderAction action)
        {
            switch (_currentSortState)
            {
                case SortState.Stakeholder:
                    return action.Action;
                    case SortState.Decision:
                    return action.Stakeholder.Name;
                default:
                    return action.Decision.Name;
            }
        }

        private string GetReceiverButtonText(IStakeholderAction action)
        {
            switch (_currentSortState)
            {
                case SortState.Stakeholder:
                    return action.Decision.Name;
                case SortState.Decision:
                    return action.Action;
                default:
                    return action.Stakeholder.Name;
            }
        }


        #region MouseEvents
        private void decisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentSortState == SortState.Decision)
                return;
            _stakeHolders = _stakeHolders.OrderBy(x => x.Decision.Name).ThenBy(x => x.Action).ToList();
            UpdateMenu(sender);
            SortActions(SortState.Decision);
        }

        private void stakeholderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentSortState == SortState.Stakeholder)
                return;
            _stakeHolders = _stakeHolders.OrderBy(x => x.Stakeholder.Name).ThenBy(x => x.Action).ToList();
            UpdateMenu(sender);
            SortActions(SortState.Stakeholder);

        }

        private void actionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentSortState == SortState.Action)
                return;
            _stakeHolders = _stakeHolders.OrderBy(x => x.Action).ToList();
            UpdateMenu(sender);
            SortActions(SortState.Action);
        }

        private void UpdateMenu(object clickedMenu)
        {
            var menuItem = clickedMenu as ToolStripMenuItem;
            actionToolStripMenuItem.BackColor = _defaultMenuColor;
            decisionToolStripMenuItem.BackColor = _defaultMenuColor;
            stakeholderToolStripMenuItem.BackColor = _defaultMenuColor;

            if (menuItem != null) menuItem.BackColor = ColorTranslator.FromHtml("#C2E0FF");
        }

        private void newStakeholderInvolvementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new CreateStakeholderActionDialog(_topic.Decisions);
            dialog.StartPosition = FormStartPosition.CenterScreen;
            var result = dialog.ShowDialog(this);
            if (result != DialogResult.OK) return;

            var d = dialog.Decision;
            var exists = (from actions in d.Stakeholders
                          where actions.Stakeholder.GUID.Equals(dialog.Stakeholder.GUID)
                          && actions.Action.Equals(dialog.Action)
                          select actions).Any();
            if (!exists)
            {
                d.Stakeholders.Add(new StakeholderAction(d, dialog.Action, dialog.Stakeholder));
                ReloadData();
                RefreshData();
                _topicView.UpdateStakeholdersDgv();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            menuCreate.Show(Cursor.Position);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            menuDelete.Tag = GetStakeholderActionForRow(e.RowIndex);
            menuDelete.Show(Cursor.Position);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedAction = (IStakeholderAction)menuDelete.Tag;
            selectedAction.DoDelete = true;
            _topicView.UpdateStakeholdersDgv();
            ReloadData();
            RefreshData();
        }


        #endregion

        private void SortActions(SortState state)
        {
            _currentSortState = state;
            RefreshData();
        }


        #region rendering

        private const int RectangleWidth = 200;
        private const int ActionWidth = 200;
        private const int ArrowWidth = 50;
        private const int ArrowMargin = 5;
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (IsNameRow(e.RowIndex))
                return;

            e.Graphics.FillRectangle(Brushes.White, e.CellBounds); //background
            e.Graphics.DrawLine(Pens.Black, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1); //border

            var action = GetStakeholderActionForRow(e.RowIndex);


            //var horizontalRectMargin = (e.CellBounds.Width - RectangleWidth)/2;
            var horizontalRectMargin = (e.CellBounds.Width - RectangleWidth - ActionWidth - ArrowWidth) / 2;
            var verticalRectMargin = 5;

            var actionColor = DecisionStateColor.ConvertStateToColor(action.Decision.State);
            if (_currentSortState == SortState.Stakeholder)
                actionColor = GetColorForAction(action.Action);


            //draw action button
            var actionRectangle = new Rectangle(
                e.CellBounds.X + horizontalRectMargin,
                e.CellBounds.Y + verticalRectMargin,
                ActionWidth,
                dataGridView1.RowTemplate.Height - 2 * verticalRectMargin);
            var actionPath = RoundedRectangle.Create(actionRectangle);
            e.Graphics.FillPath(new SolidBrush(actionColor), actionPath);

            var text = GetActionButtonText(action);
            DrawText(e.Graphics, text, actionRectangle);

            //draw arrow between
            var arrowPen = new Pen(Color.Black, 5f);
            arrowPen.StartCap = LineCap.Flat;
            arrowPen.EndCap = LineCap.ArrowAnchor;
            e.Graphics.DrawLine(arrowPen,
                e.CellBounds.X + horizontalRectMargin + ActionWidth + ArrowMargin,
                e.CellBounds.Y + (e.CellBounds.Height / 2),
                e.CellBounds.X + horizontalRectMargin + ActionWidth + ArrowWidth - ArrowMargin,
                e.CellBounds.Y + (e.CellBounds.Height / 2)
                );

            var color = DecisionStateColor.ConvertStateToColor(action.Decision.State);
            if (_currentSortState == SortState.Decision)
                color = GetColorForAction(action.Action);
            var decisionRectangle = new Rectangle(
                e.CellBounds.X + horizontalRectMargin + ActionWidth + ArrowWidth,
                e.CellBounds.Y + verticalRectMargin,
                RectangleWidth,
                dataGridView1.RowTemplate.Height - 2 * verticalRectMargin);


            text = GetReceiverButtonText(action);
            var path = RoundedRectangle.Create(decisionRectangle);
            e.Graphics.FillPath(new SolidBrush(color), path);
            DrawText(e.Graphics, text, decisionRectangle);

            //var text = ActionToSentence(action.Action, action.Decision);
            //var stringSize = e.Graphics.MeasureString(text, DefaultFont);
            //var horizontalMargin = (rectangle.Width - stringSize.Width) / 2;
            //var verticalMargin = (rectangle.Height - stringSize.Height) / 2;



            //textRectangle = new RectangleF(rectangle.X + horizontalMargin, rectangle.Y + verticalMargin, stringSize.Width, stringSize.Height);
            //e.Graphics.DrawString(text, DefaultFont, Brushes.Black, textRectangle);
            e.Handled = true;

        }

        private void DrawText(Graphics g, string text, Rectangle container)
        {
            var stringSize = g.MeasureString(text, DefaultFont);
            var horizontalTextMargin = (container.Width - stringSize.Width) / 2;
            var verticalTextMargin = (container.Height - stringSize.Height) / 2;
            var textRectangle = new RectangleF(container.X + horizontalTextMargin, container.Y + verticalTextMargin, stringSize.Width, stringSize.Height);
            g.DrawString(text, DefaultFont, Brushes.Black, textRectangle);
        }

        private Color GetColorForAction(string action)
        {
            switch (action.ToLower())
            {
                case "propose":
                    return DecisionStateColor.ConvertStateToColor("Idea");
                case "reject":
                    return DecisionStateColor.ConvertStateToColor("Rejected");
                case "confirm":
                    return DecisionStateColor.ConvertStateToColor("Approved");
                case "challenge":
                    return DecisionStateColor.ConvertStateToColor("Challenged");
                case "discard":
                    return DecisionStateColor.ConvertStateToColor("Discarded");
            }
            return DecisionStateColor.ConvertStateToColor("Approved");
        }


        #endregion

        public void OnDecisionDeleted(IDecision decision)
        {
            _decisions = _decisions.Where(d => !d.DoDelete).ToList();
            ReloadData();
            RefreshData();
        }

        public void OnDecisionChanged()
        {
            ReloadData();
            RefreshData();
        }
    }
}
