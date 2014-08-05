using DecisionViewpointsCustomViews.Model;
using Word = Microsoft.Office.Interop.Word;

namespace DecisionViewpoints.Model.Reporting
{
    public class DecisionTable : ITable
    {
        private readonly Decision _decision;
        private readonly Word.Document _doc;
        private object _objMiss;
        private object _endofdoc;

        public DecisionTable(Decision decision, Word.Document doc, object objMiss, object endofdoc)
        {
            _decision = decision;
            _doc = doc;
            _objMiss = objMiss;
            _endofdoc = endofdoc;
        }

        public void Create()
        {
            const int rows = 8;
            const int columns = 2;
            // calculate the range of endofdocu
            var objRange = _doc.Bookmarks.get_Item(ref _endofdoc).Range;
            // add table with document with number of row and column
            var objTable = _doc.Content.Tables.Add(objRange, rows, columns, ref _objMiss, ref _objMiss);
            // set border visibility true by input 1 and false by input 0
            objTable.Borders.Enable = 1;
            // set text in each cell of table
            objTable.Cell(1, 1).Range.Text = "Name";
            objTable.Cell(1, 2).Range.Text = _decision.Name;

            objTable.Cell(2, 1).Range.Text = "Current State";
            objTable.Cell(2, 2).Range.Text = _decision.State;

            objTable.Cell(3, 1).Range.Text = "Group";
            objTable.Cell(3, 2).Range.Text = _decision.Group;

            objTable.Cell(4, 1).Range.Text = "Problem/Issue";
            objTable.Cell(4, 2).Range.Text = _decision.Issue;

            objTable.Cell(5, 1).Range.Text = "Decision";
            objTable.Cell(5, 2).Range.Text = _decision.DecisionText;

            objTable.Cell(6, 1).Range.Text = "Alternatives";
            objTable.Cell(6, 2).Range.Text = _decision.Alternatives;

            objTable.Cell(7, 1).Range.Text = "Arguments";
            objTable.Cell(7, 2).Range.Text = _decision.Arguments;
        }
    }
}
