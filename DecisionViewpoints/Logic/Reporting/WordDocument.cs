using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DecisionViewpoints.Logic.Reporting;
using DecisionViewpointsCustomViews.Model;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using EAFacade;
using EAFacade.Model;
using BottomBorder = DocumentFormat.OpenXml.Wordprocessing.BottomBorder;
using InsideHorizontalBorder = DocumentFormat.OpenXml.Wordprocessing.InsideHorizontalBorder;
using InsideVerticalBorder = DocumentFormat.OpenXml.Wordprocessing.InsideVerticalBorder;
using LeftBorder = DocumentFormat.OpenXml.Wordprocessing.LeftBorder;
using NonVisualGraphicFrameDrawingProperties = DocumentFormat.OpenXml.Drawing.Wordprocessing.NonVisualGraphicFrameDrawingProperties;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
using Path = System.IO.Path;
using RightBorder = DocumentFormat.OpenXml.Wordprocessing.RightBorder;
using Run = DocumentFormat.OpenXml.Wordprocessing.Run;
using Table = DocumentFormat.OpenXml.Wordprocessing.Table;
using TableCell = DocumentFormat.OpenXml.Wordprocessing.TableCell;
using TableProperties = DocumentFormat.OpenXml.Wordprocessing.TableProperties;
using TableRow = DocumentFormat.OpenXml.Wordprocessing.TableRow;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;
using TopBorder = DocumentFormat.OpenXml.Wordprocessing.TopBorder;

namespace DecisionViewpoints.Model.Reporting
{
    public class WordDocument : IReportDocument
    {
        private WordprocessingDocument _wordDoc;
        private MainDocumentPart _mainPart;
        private Body _body;
        private readonly string _filename;

        public WordDocument(string filename)
        {
            //_filename = String.Format("{0}\\{1}", Utilities.GetDocumentsDirectory(), filename);// original
            _filename = filename; //angor
            //MessageBox.Show("Document filename: " + filename); //DEBUG
            using (var wordDoc = WordprocessingDocument.Create(_filename, WordprocessingDocumentType.Document))
            {
                _mainPart = wordDoc.AddMainDocumentPart();
                _mainPart.Document = new Document();
                _body = _mainPart.Document.AppendChild(new Body());
            }
        }

        public void InsertDecisionTable(IDecision decision)
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

            var relatedDecisions = new StringBuilder();
            foreach (EAConnector connector in decision.GetConnectors().Where(connector => connector.IsRelationship()))
            {
                relatedDecisions.AppendLine(connector.ClientId == decision.ID
                                                      ? string.Format("This <<{1}>> {0}", connector.GetSupplier().Name,
                                                                      connector.Stereotype)
                                                      : string.Format("{0} <<{1}>> This", connector.GetClient().Name,
                                                                      connector.Stereotype));
            }

            var data = new[,]
                {
                    {"Name", decision.Name},
                    {"State", decision.State},
                    {"Group", decision.Group},
                    {"Issue", decision.Issue},
                    {"Decision", decision.DecisionText},
                    {"Alternatives", decision.Alternatives},
                    {"Arguments", decision.Arguments},
                    {"Related Decision", relatedDecisions.ToString()},
                    {"Related Requirements", decision.RelatedRequirements}
                };

            for (var i = 0; i <= data.GetUpperBound(0); i++)
            {
                var tr = new TableRow();
                for (var j = 0; j <= data.GetUpperBound(1); j++)
                {
                    var tc = new TableCell();
                    tc.AppendChild(new Paragraph(new Run(new Text(data[i, j]))));

                    tr.AppendChild(tc);
                }
                table.AppendChild(tr);
            }

            _body.AppendChild(table);
            _body.AppendChild(new Paragraph());
        }

        public void InsertForcesTable(IForcesModel forces)
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

            var emptyCell = new TableCell(new Paragraph(new Run(new Text(""))));

            // insert an empty cell in tol left of forces table
            var decRow = new TableRow();
            decRow.AppendChild(emptyCell);

            // insert the concern header and the decisions names
            var concCellHeader = new TableCell(new Paragraph(new Run(new Text("Concerns"))));
            decRow.AppendChild(concCellHeader);
            foreach (
                var decCell in
                    forces.GetDecisions()
                          .Select(decision => new TableCell(new Paragraph(new Run(new Text(decision.Name))))))
            {
                decRow.AppendChild(decCell);
            }
            table.AppendChild(decRow);

            // insert the requirement name, concern(s), and ratings
            foreach (var requirement in forces.GetRequirements())
            {
                var reqRow = new TableRow();
                var reqCell = new TableCell(new Paragraph(new Run(new Text(requirement.Name))));
                reqRow.AppendChild(reqCell);
                // insert concern(s)
                var concCell = new TableCell();
                var concCellText = new StringBuilder();
                foreach (var concern in forces.GetConcerns())
                {
                    if (concern.Key.GUID != requirement.GUID) continue;
                    var concernIndex = 0;
                    foreach (var concernText in concern.Value)
                    {
                        if (concernIndex++ > 0)
                        {
                            concCellText.Append(", ");
                        }
                        concCellText.Append(concernText.Name);
                    }
                    break;
                }
                concCell.AppendChild(new Paragraph(new Run(new Text(concCellText.ToString()))));
                reqRow.AppendChild(concCell);
                // insert ratings
                foreach (var rating in forces.GetRatings())
                {
                    if (rating.RequirementGUID != requirement.GUID) continue;
                    var ratCell = new TableCell();
                    if (forces.GetDecisions().Any(decision => rating.DecisionGUID == decision.GUID))
                    {
                        ratCell.AppendChild(new Paragraph(new Run(new Text(rating.Value))));
                    }
                    reqRow.AppendChild(ratCell);
                }
                table.AppendChild(reqRow);
            }

            _body.AppendChild(table);
            _body.AppendChild(new Paragraph());
        }

        public void InsertDiagramImage(EADiagram diagram)
        {
            diagram.CopyToClipboard();

            var imagePart = _mainPart.AddImagePart(ImagePartType.Jpeg);

            Image image = null;
            if (Clipboard.ContainsImage())
            {
                image = Clipboard.GetImage();
            }
            imagePart.FeedData(Utilities.ImageToStream(image, ImageFormat.Jpeg));

            AddImageToBody(_mainPart.GetIdOfPart(imagePart), Utilities.GetImageSize(image));
        }

        public void Open()
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), _filename);
            _wordDoc = WordprocessingDocument.Open(filepath, true);
            _mainPart = _wordDoc.MainDocumentPart;
            _body = _mainPart.Document.Body;
        }

        public void Close()
        {
            _wordDoc.Close();
        }

        private void AddImageToBody(string relationshipId, IList<long> size)
        {
            // Define the reference of the image.
            var element =
                new Drawing(
                    new Inline(
                        new Extent {Cx = size[0], Cy = size[1]},
                        new EffectExtent
                            {
                                LeftEdge = 0L,
                                TopEdge = 0L,
                                RightEdge = 0L,
                                BottomEdge = 0L
                            },
                        new DocProperties
                            {
                                Id = (UInt32Value) 1U,
                                Name = "Picture 1"
                            },
                        new NonVisualGraphicFrameDrawingProperties(
                            new GraphicFrameLocks {NoChangeAspect = true}),
                        new Graphic(
                            new GraphicData(
                                new DocumentFormat.OpenXml.Drawing.Pictures.Picture(
                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureProperties(
                                        new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualDrawingProperties
                                            {
                                                Id = (UInt32Value) 0U,
                                                Name = "New Bitmap Image.jpg"
                                            },
                                        new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureDrawingProperties()),
                                    new DocumentFormat.OpenXml.Drawing.Pictures.BlipFill(
                                        new Blip(
                                            new BlipExtensionList(
                                                new BlipExtension
                                                    {
                                                        Uri = Guid.NewGuid().ToString()
                                                    })
                                            )
                                            {
                                                Embed = relationshipId,
                                                CompressionState =
                                                    BlipCompressionValues.Print
                                            },
                                        new Stretch(
                                            new FillRectangle())),
                                    new DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties(
                                        new Transform2D(
                                            new Offset {X = 0L, Y = 0L},
                                            new Extents {Cx = size[0], Cy = size[1]}),
                                        new PresetGeometry(
                                            new AdjustValueList()
                                            ) {Preset = ShapeTypeValues.Rectangle}))
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
    }
}