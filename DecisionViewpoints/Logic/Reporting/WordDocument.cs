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

        private int _diagmarCounter = 0;
        private int _topicCounter = 0;
        private int _decisionCounter = 0;

        public WordDocument(string filename)
        {
            _filename = filename;
            using (var wordDoc = WordprocessingDocument.Create(_filename, WordprocessingDocumentType.Document))
            {
                _mainPart = wordDoc.AddMainDocumentPart();
                _mainPart.Document = new Document();
                _body = _mainPart.Document.AppendChild(new Body());

                DateTime saveNow = DateTime.Now;

                Paragraph para = _body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());
                DocumentFormat.OpenXml.Wordprocessing.RunProperties runProperties = getHeading1(run);
                run.AppendChild(new Text("Decision Report [" + saveNow + "]"));
                //_body.Append(new Paragraph(new Run(new Text("Decision Report [" + saveNow + "]"))));
                _body.AppendChild(new Paragraph());
            }
        }

        public void InsertTopicTable(ITopic topic)
        {
            Paragraph para = _body.AppendChild(new Paragraph());
            Run run = para.AppendChild(new Run());
            DocumentFormat.OpenXml.Wordprocessing.RunProperties runProperties = getHeading3(run);
            run.AppendChild(new Text(_diagmarCounter + "." + (++_topicCounter) + ". " + topic.Name));
            //_body.AppendChild(new Paragraph(new Run(new Text(_diagmarCounter + "." + (++_topicCounter) + ". " + topic.Name)))); //Topic Name
            if (topic.Description != "")
            {
                _body.AppendChild(new Paragraph(new Run(new Text(topic.Description))));//Topic Desc
            }
            _body.AppendChild(new Paragraph());
        }

        public void InsertDecisionWithoutTopicMessage()
        {
            Paragraph para = _body.AppendChild(new Paragraph());
            Run run = para.AppendChild(new Run());
            DocumentFormat.OpenXml.Wordprocessing.RunProperties runProperties = getHeading2(run);
            run.AppendChild(new Text("Decisions not included in a topic:"));
            //_body.AppendChild(new Paragraph(new Run(new Text("Decisions not included in a topic:"))));
            _body.AppendChild(new Paragraph());
        }

        public void InsertDecisionDetailViewMessage()
        {
            Paragraph para = _body.AppendChild(new Paragraph());
            Run run = para.AppendChild(new Run());
            DocumentFormat.OpenXml.Wordprocessing.RunProperties runProperties = getHeading2(run);
            run.AppendChild(new Text(++_diagmarCounter + ". Decision Detail View"));
               // _body.AppendChild(new Paragraph(new Run(new Text(++_diagmarCounter + ". Decision Detail View"))));
            _body.AppendChild(new Paragraph());
        }
       

        public void InsertDecisionTable(IDecision decision)
        {
            _decisionCounter++;
            //_body.AppendChild(new Paragraph());
            //_body.AppendChild(new Paragraph(new Run(new Text("Decision " +_decisionCounter.ToString() +": " + decision.Name))));

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
                        },
                    new TableWidth
                        {
                            Width = "5000",
                            Type = TableWidthUnitValues.Pct
                        }
                   ),
                    new TableCaption
                    {
                        Val = new StringValue("My Caption Val")
                        
                    });

            table.AppendChild(props);
   
            var relatedDecisions = new StringBuilder();
            var alternativeDecisions = new StringBuilder();
            foreach (EAConnector connector in decision.GetConnectors().Where(connector => connector.IsRelationship()))
            {
                // Related Decisions
                if (!connector.Stereotype.Equals("alternative for"))
                {
                    relatedDecisions.AppendLine(connector.ClientId == decision.ID
                        ? "<<this>> " + decision.Name +" - "+ connector.Stereotype + " - " + connector.GetSupplier().Name
                        :  connector.GetClient().Name + " - " + connector.Stereotype + " - <<this>> " + decision.Name);
                }
                // Alternative Decisions
                else if (connector.Stereotype.Equals("alternative for"))
                {
                    alternativeDecisions.AppendLine(connector.ClientId == decision.ID
                        ? "<<this>> " + decision.Name + " - " + connector.Stereotype + " - " + connector.GetSupplier().Name
                        : connector.GetClient().Name + " - " + connector.Stereotype + " - <<this>> " + decision.Name);
                }
            }

            // Related Requirements
            var relatedRequirements = new StringBuilder();
            var forces = decision.GetForces();
            foreach (var rating in forces)
            {
                var req = EARepository.Instance.GetElementByGUID(rating.RequirementGUID);
                var concern = EARepository.Instance.GetElementByGUID(rating.ConcernGUID);
                relatedRequirements.AppendLine(req.Name + " - " + req.Notes);
            }

            var data = new[,]
                {
                    {"Name", decision.Name},
                    {"State", decision.State},
                    //{"Group", decision.Group},
                    {"Issue", decision.Issue},
                    {"Decision", decision.DecisionText},
                    //{"Alternatives", decision.Alternatives},
                    {"Arguments", decision.Arguments},
                    {"Alternatives", alternativeDecisions.ToString()},
                    {"Related Decision", relatedDecisions.ToString()},
                    //{"Related Requirements", decision.RelatedRequirements}
                    {"Related Requirements", relatedRequirements.ToString()}
                };

            for (var i = 0; i <= data.GetUpperBound(0); i++)
            {
                var tr = new TableRow();
                for (var j = 0; j <= data.GetUpperBound(1); j++)
                {
                    var tc = new TableCell();
                    if (j == 0)
                    {
                        //Apply the same width at column 1 (0)
                        tc.Append(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "1821" });
                        tc.Append(new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "##d3d4d6" }));
                        Paragraph para = tc.AppendChild(new Paragraph());
                        Run run = para.AppendChild(new Run());
                        DocumentFormat.OpenXml.Wordprocessing.RunProperties runProperties = getBold(run);
                        run.AppendChild(new Text(data[i, j]));
                    }
                    else
                    {
                        tc.AppendChild(new Paragraph(new Run(new Text(data[i, j]))));
                    }
                    
                    tr.AppendChild(tc);
                }
                if (data[i, 1] != "")
                    table.AppendChild(tr);
            }

            /*
            for (var i = 0; i <= data.GetUpperBound(0); i++)
            {
                var tr = new TableRow();
                for (var j = 0; j <= data.GetUpperBound(1); j++)
                {
                    var tc = new TableCell();
                    tc.AppendChild(new Paragraph(new Run(new Text(data[i, j]))));
                    
                    tr.AppendChild(tc);
                }
                if (data[i, 1] != "")
                table.AppendChild(tr);
            }*/

            _body.AppendChild(table);
            _body.AppendChild(new Paragraph());

        }

        public void InsertForcesTable(IForcesModel forces)
        {
            Paragraph para = _body.AppendChild(new Paragraph());
            Run run = para.AppendChild(new Run());
            DocumentFormat.OpenXml.Wordprocessing.RunProperties runProperties = getHeading2(run);
            run.AppendChild(new Text(++_diagmarCounter + ". Decision Forces Viewpoint: " + forces.Name));
            //_body.AppendChild(new Paragraph(new Run(new Text(++_diagmarCounter + ". Decision Forces Viewpoint"))));
            _body.AppendChild(new Paragraph(new Run(new Text())));

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

            var emptyCell = new TableCell();
            //emptyCell.Append(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "1821" });
            //emptyCell.Append(new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "##d3d4d6" })); 

            // insert an empty cell in tol left of forces table
            var decRow = new TableRow();
            decRow.AppendChild(emptyCell);
            para = emptyCell.AppendChild(new Paragraph(new Run(new Text(""))));
            //run = para.AppendChild(new Run());
            //runProperties = getBold(run);
            //run.AppendChild(new Text(""));

            // insert the concern header and the decisions names
            var concCellHeader = new TableCell(new Paragraph(new Run(new Text("Concerns"))));
            //var concCellHeader = new TableCell();
            //concCellHeader.Append(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "1821" });
            //concCellHeader.Append(new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "##d3d4d6" })); 

            decRow.AppendChild(concCellHeader);
            //para = concCellHeader.AppendChild(new Paragraph());
            //run = para.AppendChild(new Run());
            //runProperties = getBold(run);
            //run.AppendChild(new Text("Concerns"));
            foreach (
                var decCell in
                    forces.GetDecisions()
                          .Select(decision => new TableCell(new Paragraph(new Run(new Text(decision.Name))))))
            {
                //decCell.Append(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "1821" });
                //decCell.Append(new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "##d3d4d6" })); 

                decRow.AppendChild(decCell);
            }
            table.AppendChild(decRow);



            foreach (var concernsPerRequirement in forces.GetConcernsPerRequirement())
            {
                var requirement = concernsPerRequirement.Key;
                var concerns = concernsPerRequirement.Value;

                foreach (var concern in concerns)
                {
                    var reqRow = new TableRow();
                    var reqCell = new TableCell(new Paragraph(new Run(new Text(requirement.Name))));
                    reqRow.AppendChild(reqCell);
                    var concCell = new TableCell();
                    concCell.AppendChild(new Paragraph(new Run(new Text(concern.Name))));
                    reqRow.AppendChild(concCell);

                    // insert ratings
                    foreach (Rating rating in forces.GetRatings())
                    {
                        if (rating.RequirementGUID != requirement.GUID || rating.ConcernGUID != concern.GUID) continue;
                        if (forces.GetDecisions().Any(decision => rating.DecisionGUID == decision.GUID))
                        {
                            var ratCell = new TableCell();
                            ratCell.AppendChild(new Paragraph(new Run(new Text(rating.Value))));
                            reqRow.AppendChild(ratCell);
                        }
                    }
                    table.AppendChild(reqRow);
                }
            }

           
            _body.AppendChild(table);
            _body.AppendChild(new Paragraph());
        }

        public void InsertDiagramImage(EADiagram diagram)
        {
            //angor reporting  
            if (diagram.IsRelationshipView())
            {
                Paragraph para = _body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());
                DocumentFormat.OpenXml.Wordprocessing.RunProperties runProperties = getHeading2(run);
                run.AppendChild(new Text(++_diagmarCounter + ". Relationship Viewpoint: " + diagram.Name));
                //_body.AppendChild(new Paragraph(new Run(new Text(++_diagmarCounter + ". Relationship Viewpoint"))));
            }
            else if (diagram.IsStakeholderInvolvementView())
            {
                Paragraph para = _body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());
                DocumentFormat.OpenXml.Wordprocessing.RunProperties runProperties = getHeading2(run);
                run.AppendChild(new Text(++_diagmarCounter + ". Decision Stakeholder Involvement Viewpoint: " + diagram.Name));
                //_body.AppendChild(new Paragraph(new Run(new Text(++_diagmarCounter + ". Decision Stakeholder Involvement Viewpoint"))));
            }
            else if (diagram.IsChronologicalView())
            {
                Paragraph para = _body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());
                DocumentFormat.OpenXml.Wordprocessing.RunProperties runProperties = getHeading2(run);
                run.AppendChild(new Text(++_diagmarCounter + ". Decision Chronological Viewpoint: " + diagram.Name));
                //_body.AppendChild(new Paragraph(new Run(new Text(++_diagmarCounter + ". Decision Chronological Viewpoint"))));
            }
            
             _body.AppendChild(new Paragraph(new Run(new Text())));

            var imagePart = _mainPart.AddImagePart(ImagePartType.Emf);
            FileStream fs = diagram.DiagramToStream();
            imagePart.FeedData(fs);

            Image image = Image.FromFile(fs.Name);
            AddImageToBody(_mainPart.GetIdOfPart(imagePart), Utilities.GetImageSize(image));

            //cleanup:
            fs.Close();
            image.Dispose();
            File.Delete(fs.Name);
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

        public DocumentFormat.OpenXml.Wordprocessing.RunProperties getBold(Run run)
        {
            DocumentFormat.OpenXml.Wordprocessing.RunProperties runProperties = run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.RunProperties());
            Bold bold = new Bold();
            bold.Val = OnOffValue.FromBoolean(true);
            runProperties.AppendChild(bold);
            return runProperties;
        }

        public DocumentFormat.OpenXml.Wordprocessing.RunProperties getHeading1(Run run)
        {
            DocumentFormat.OpenXml.Wordprocessing.RunProperties runProperties = run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.RunProperties());
            Bold bold = new Bold();
            bold.Val = OnOffValue.FromBoolean(true);
            DocumentFormat.OpenXml.Wordprocessing.Color color = new DocumentFormat.OpenXml.Wordprocessing.Color() { Val = "365F91", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "BF" };
            FontSize size = new FontSize() { Val = new StringValue("33")};
            
            runProperties.AppendChild(bold);
            runProperties.AppendChild(color);
            runProperties.AppendChild(size);
            return runProperties;
        }

        public DocumentFormat.OpenXml.Wordprocessing.RunProperties getHeading2(Run run)
        {
            DocumentFormat.OpenXml.Wordprocessing.RunProperties runProperties = run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.RunProperties());
            Bold bold = new Bold();
            bold.Val = OnOffValue.FromBoolean(true);
            DocumentFormat.OpenXml.Wordprocessing.Color color = new DocumentFormat.OpenXml.Wordprocessing.Color() { Val = "365F91", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "BF" };
            FontSize size = new FontSize() { Val = new StringValue("29") };

            runProperties.AppendChild(bold);
            runProperties.AppendChild(color);
            runProperties.AppendChild(size);
            return runProperties;
        }

        public DocumentFormat.OpenXml.Wordprocessing.RunProperties getHeading3(Run run)
        {
            DocumentFormat.OpenXml.Wordprocessing.RunProperties runProperties = run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.RunProperties());
            Bold bold = new Bold();
            bold.Val = OnOffValue.FromBoolean(true);
            DocumentFormat.OpenXml.Wordprocessing.Color color = new DocumentFormat.OpenXml.Wordprocessing.Color() { Val = "365F91", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "BF" };
            FontSize size = new FontSize() { Val = new StringValue("25") };

            runProperties.AppendChild(bold);
            runProperties.AppendChild(color);
            runProperties.AppendChild(size);
            return runProperties;
        }
    }

   

}