using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using DecisionViewpointsCustomViews.Model;
using Word = Microsoft.Office.Interop.Word;

namespace DecisionViewpoints.Logic.Reporting
{
    public class Report
    {
        private static Report _instance;
        // create MS-Word application 
        private readonly Word.Application _msWord = new Word.Application();
        // create Word document reference
        private Word.Document _doc;
        // Create misssing value object
        private object _objMiss = Missing.Value;
        // Create end of document object
        private object _endofdoc = "\\endofdoc";

        public static Report Instance
        {
            get { return _instance ?? (_instance = new Report()); }
        }

        public void CreateWord(IEnumerable<Decision> decisions)
        {
            try
            {
                // show ms-word application
                _msWord.Visible = true;
                // add blank documnet in word application
                _doc = _msWord.Documents.Add(ref _objMiss, ref _objMiss, ref _objMiss, ref _objMiss);
                // create decision tables
                foreach (var decision in decisions)
                {
                    CreateDecisionTable(decision);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CreateDecisionTable(Decision decision)
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
            objTable.Cell(1, 2).Range.Text = decision.Name;

            objTable.Cell(2, 1).Range.Text = "Current State";
            objTable.Cell(2, 2).Range.Text = decision.State;

            objTable.Cell(3, 1).Range.Text = "Group";
            objTable.Cell(2, 1).Range.Text = decision.Group;

            objTable.Cell(4, 1).Range.Text = "Problem/Issue";
            objTable.Cell(4, 2).Range.Text = decision.Issue;

            objTable.Cell(5, 1).Range.Text = "Decision";
            objTable.Cell(5, 2).Range.Text = decision.DecisionText;

            objTable.Cell(6, 1).Range.Text = "Alternatives";
            objTable.Cell(6, 2).Range.Text = decision.Alternatives;

            objTable.Cell(7, 1).Range.Text = "Arguments";
            objTable.Cell(7, 2).Range.Text = decision.Arguments;

            object objRangePara = _doc.Bookmarks.get_Item(ref _endofdoc).Range;
            var objParagraph = _doc.Content.Paragraphs.Add(ref objRangePara);
            objParagraph.Range.Text = Environment.NewLine;
        }

        /*public static void GenerateDoc(Decision decision)
        {
            try
            {
                MsWord.Visible = true;
                Object oTemplatePath = string.Format("{0}\\DecisionTemplate.dotx", Directory.GetCurrentDirectory());

                _doc = MsWord.Documents.Add(ref oTemplatePath, _objMiss, _objMiss, _objMiss);

                foreach (Word.Field myMergeField in _doc.Fields)
                {
                    var rngFieldCode = myMergeField.Code;
                    var fieldText = rngFieldCode.Text;

                    // ONLY GETTING THE MAILMERGE FIELDS
                    if (!fieldText.StartsWith(" MERGEFIELD")) continue;
                    // THE TEXT COMES IN THE FORMAT OF

                    // MERGEFIELD  MyFieldName  \\* MERGEFORMAT

                    // THIS HAS TO BE EDITED TO GET ONLY THE FIELDNAME "MyFieldName"

                    var endMerge = fieldText.IndexOf("\\", StringComparison.Ordinal);

                    var fieldName = fieldText.Substring(11, endMerge - 11);

                    // GIVES THE FIELDNAMES AS THE USER HAD ENTERED IN .dot FILE

                    fieldName = fieldName.Trim();

                    // **** FIELD REPLACEMENT IMPLEMENTATION GOES HERE ***#1#/

                    // THE PROGRAMMER CAN HAVE HIS OWN IMPLEMENTATIONS HERE

                    switch (fieldName)
                    {
                        case "Name":
                            myMergeField.Select();
                            MsWord.Selection.TypeText(decision.Name);
                            break;
                        case "State":
                            myMergeField.Select();
                            MsWord.Selection.TypeText(decision.State);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// This Method create first paragraph 
        /// </summary>
        public void FirstPara()
        {
            // create first paragraph with reference name
            // add paragraph with document
            var para1 = _doc.Content.Paragraphs.Add(ref _objMiss);
            // create object of heading style
            object styleHeading1 = "Heading 1";
            //add heading style with paragraph
            para1.Range.set_Style(styleHeading1);
            // Write text of paragraph
            para1.Range.Text = "Hello Arun, How are You?";
            //set font style of paragraph
            para1.Range.Font.Bold = 1;
            // set space after write format of paragraph
            para1.Format.SpaceAfter = 24;
            // selection range of after insert paragraph
            para1.Range.InsertParagraphAfter();
        }

        /// <summary>
        /// This Method Create Second Paragraph
        /// </summary>
        public void SecondPara()
        {
            // create second paragaraph  with paragraph reference name para2

            // add second paragraph with documnet
            var para2 = _doc.Content.Paragraphs.Add(ref _objMiss);
            // set paragraph heading style
            object styleHeading2 = "Heading 2";
            // add heading style with paragraph
            para2.Range.set_Style(ref styleHeading2);
            // second paragraph text 
            para2.Range.Text = "Hii This is Arun I am fine and you?";
            // set second paragraph font style
            para2.Range.Font.Bold = 1;
            // space or font size style like 24pt, 25pt etc.
            para2.Format.SpaceAfter = 24;
            // set selection range of paragraph
            para2.Range.InsertParagraphAfter();
        }

        /// <summary>
        /// This Method create table in ms-word document
        /// </summary>
        public void CreateTable(int row, int column)
        {
            // create table in word documnet in word application with table reference name tbl1
            // calculate the range of endofdocu
            var wordRange = _doc.Bookmarks.get_Item(ref _endofdoc).Range;
            // add table with document with number of row and column
            var tbl1 = _doc.Content.Tables.Add(wordRange, row, column, ref _objMiss, ref _objMiss);
            // set border visibility true by input 1 and false by input 0
            tbl1.Borders.Enable = 1;
            // set text in each cell of table
            for (var r = 1; r <= row; r++)
            {
                for (var c = 1; c <= column; c++)
                {
                    tbl1.Cell(r, c).Range.Text = "r" + r + "c" + c;
                }
            }
        }

        /// <summary>
        ///This method creates ms-word document and adding some paragraph, table and much more.
        /// </summary>
        public void CreateMsWord()
        {
            try
            {
                // show ms-word application
                MsWord.Visible = true;
                // add blank documnet in word application
                _doc = MsWord.Documents.Add(ref _objMiss, ref _objMiss, ref _objMiss, ref _objMiss);
                // create first para
                FirstPara();
                // create Second para
                SecondPara();
                // create table
                CreateTable(3, 3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }*/
    }
}
