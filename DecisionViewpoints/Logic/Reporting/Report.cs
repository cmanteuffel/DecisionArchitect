using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using DecisionViewpointsCustomViews.Model;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using EAFacade.Model;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;

namespace DecisionViewpoints.Logic.Reporting
{
    public class Report
    {
        private readonly WordprocessingDocument _wordDoc;
        private readonly MainDocumentPart _mainPart;
        private readonly Body _body;

        public Report(string filename)
        {
            _wordDoc = WordprocessingDocument.Create(filename, WordprocessingDocumentType.Document);
            _mainPart = _wordDoc.AddMainDocumentPart();
            _mainPart.Document = new Document();
            _body = _mainPart.Document.AppendChild(new Body());
        }

        public void AddDecisionTable(IDecision decision)
        {
            var table = new Table();

            var props = new TableProperties(
                new TableBorders(
                    new TopBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 11
                        },
                    new BottomBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 11
                        },
                    new LeftBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 11
                        },
                    new RightBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 11
                        },
                    new InsideHorizontalBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 11
                        },
                    new InsideVerticalBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 11
                        }));

            table.AppendChild(props);

            var data = new[,]
                {
                    {"Name", decision.Name},
                    {"State", decision.State},
                    {"Group", decision.Group},
                    {"Issue", decision.Issue},
                    {"Decision", decision.DecisionText},
                    {"Alternatives", decision.Alternatives},
                    {"Arguments", decision.Arguments}
                };

            for (var i = 0; i <= data.GetUpperBound(0); i++)
            {
                var tr = new TableRow();
                for (var j = 0; j <= data.GetUpperBound(1); j++)
                {
                    var tc = new TableCell();
                    tc.AppendChild(new Paragraph(new Run(new Text(data[i, j]))));

                    // Assume you want columns that are automatically sized.
                    /*tc.AppendChild(new TableCellProperties(
                                  new TableCellWidth {Type = TableWidthUnitValues.Auto}));*/

                    tr.AppendChild(tc);
                }
                table.AppendChild(tr);
            }
            _body.AppendChild(table);
            _body.AppendChild(new Paragraph());
        }

        public void AddDiagramImage(EADiagram diagram)
        {
            diagram.CopyToClipboard();

            var imagePart = _mainPart.AddImagePart(ImagePartType.Jpeg);

            Image image = null;
            if (Clipboard.ContainsImage())
            {
                image = Clipboard.GetImage();
            }
            imagePart.FeedData(ToStream(image, ImageFormat.Jpeg));

            AddImageToBody(_mainPart.GetIdOfPart(imagePart), GetImageSize(image));
        }

        public void Close()
        {
            _wordDoc.Close();
        }

        private static Stream ToStream(Image image, ImageFormat format)
        {
            var stream = new MemoryStream();
            image.Save(stream, format);
            stream.Position = 0;
            return stream;
        }

        private void AddImageToBody(string relationshipId, IList<long> size)
        {
            // Define the reference of the image.
            var element =
                new Drawing(
                    new DW.Inline(
                        new DW.Extent {Cx = size[0], Cy = size[1]},
                        new DW.EffectExtent
                            {
                                LeftEdge = 0L,
                                TopEdge = 0L,
                                RightEdge = 0L,
                                BottomEdge = 0L
                            },
                        new DW.DocProperties
                            {
                                Id = (UInt32Value) 1U,
                                Name = "Picture 1"
                            },
                        new DW.NonVisualGraphicFrameDrawingProperties(
                            new A.GraphicFrameLocks {NoChangeAspect = true}),
                        new A.Graphic(
                            new A.GraphicData(
                                new PIC.Picture(
                                    new PIC.NonVisualPictureProperties(
                                        new PIC.NonVisualDrawingProperties
                                            {
                                                Id = (UInt32Value) 0U,
                                                Name = "New Bitmap Image.jpg"
                                            },
                                        new PIC.NonVisualPictureDrawingProperties()),
                                    new PIC.BlipFill(
                                        new A.Blip(
                                            new A.BlipExtensionList(
                                                new A.BlipExtension
                                                    {
                                                        Uri = Guid.NewGuid().ToString()
                                                    })
                                            )
                                            {
                                                Embed = relationshipId,
                                                CompressionState =
                                                    A.BlipCompressionValues.Print
                                            },
                                        new A.Stretch(
                                            new A.FillRectangle())),
                                    new PIC.ShapeProperties(
                                        new A.Transform2D(
                                            new A.Offset {X = 0L, Y = 0L},
                                            new A.Extents {Cx = size[0], Cy = size[1]}),
                                        new A.PresetGeometry(
                                            new A.AdjustValueList()
                                            ) {Preset = A.ShapeTypeValues.Rectangle}))
                                ) {Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture"})
                        )
                        {
                            DistanceFromTop = (UInt32Value) 0U,
                            DistanceFromBottom = (UInt32Value) 0U,
                            DistanceFromLeft = (UInt32Value) 0U,
                            DistanceFromRight = (UInt32Value) 0U,
                        });

            // Append the reference to body, the element should be in a Run.
            _body.AppendChild(new Paragraph(new Run(element)));
            _body.AppendChild(new Paragraph());
        }

        private static long[] GetImageSize(Image img)
        {
            var size = new long[2];
            var widthPx = img.Width;
            var heightPx = img.Height;
            var horzRezDpi = img.HorizontalResolution;
            var vertRezDpi = img.VerticalResolution;
            const int emusPerInch = 914400;
            var widthEmus = (long) (widthPx/horzRezDpi*emusPerInch);
            var heightEmus = (long) (heightPx/vertRezDpi*emusPerInch);
            const long maxWidthEmus = (long) (6.5*emusPerInch);
            var ratio = (heightEmus*1.0m)/widthEmus;
            size[0] = widthEmus <= maxWidthEmus ? widthEmus : maxWidthEmus;
            size[1] = (long) (widthEmus*ratio);
            return size;
        }

        // THIS CODE USE THE WORD API WHICH, KINDLY SPEAKING, SUCKS

        /*// Create MS-Word application 
        private readonly Word.Application _msWord = new Word.Application();
        // Create Word document reference
        private Word.Document _doc;
        // Create misssing value object
        private object _objMiss = Missing.Value;
        // Create end of document object
        private object _endofdoc = "\\endofdoc";*/

        // Create a document by supplying the filepath. 
        /*using (WordprocessingDocument wordDocument =
                WordprocessingDocument.Create("Report.docx", WordprocessingDocumentType.Document))
            {
                // Add a main document part. 
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                // Create the document structure and add some text.
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());
                Paragraph para = body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());
                run.AppendChild(new Text("Create text in body - CreateWordprocessingDocument - Copy"));
            }*/

        /*public void CreateWord(IEnumerable<Decision> decisions)
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
                    ITable decisionTable = new DecisionTable(decision, _doc, _objMiss, _endofdoc);
                    decisionTable.Create();
                    ChangeParagraph();
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ChangeParagraph()
        {
            object objRangePara = _doc.Bookmarks.get_Item(ref _endofdoc).Range;
            var objParagraph = _doc.Content.Paragraphs.Add(ref objRangePara);
            objParagraph.Range.Text = Environment.NewLine;
        }*/

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