/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using DecisionViewpoints.Model;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using EAFacade;
using EAFacade.Model;

using BlipFill = DocumentFormat.OpenXml.Drawing.Pictures.BlipFill;
using BottomBorder = DocumentFormat.OpenXml.Wordprocessing.BottomBorder;
using Break = DocumentFormat.OpenXml.Wordprocessing.Break;
using Color = DocumentFormat.OpenXml.Wordprocessing.Color;
using InsideHorizontalBorder = DocumentFormat.OpenXml.Wordprocessing.InsideHorizontalBorder;
using InsideVerticalBorder = DocumentFormat.OpenXml.Wordprocessing.InsideVerticalBorder;
using LeftBorder = DocumentFormat.OpenXml.Wordprocessing.LeftBorder;
using NonVisualDrawingProperties = DocumentFormat.OpenXml.Drawing.Pictures.NonVisualDrawingProperties;
using NonVisualGraphicFrameDrawingProperties =
    DocumentFormat.OpenXml.Drawing.Wordprocessing.NonVisualGraphicFrameDrawingProperties;
using NonVisualPictureDrawingProperties = DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureDrawingProperties;
using NonVisualPictureProperties = DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureProperties;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
using Path = System.IO.Path;
using Picture = DocumentFormat.OpenXml.Drawing.Pictures.Picture;
using RightBorder = DocumentFormat.OpenXml.Wordprocessing.RightBorder;
using Run = DocumentFormat.OpenXml.Wordprocessing.Run;
using RunProperties = DocumentFormat.OpenXml.Wordprocessing.RunProperties;
using ShapeProperties = DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties;
using Table = DocumentFormat.OpenXml.Wordprocessing.Table;
using TableCell = DocumentFormat.OpenXml.Wordprocessing.TableCell;
using TableCellProperties = DocumentFormat.OpenXml.Wordprocessing.TableCellProperties;
using TableProperties = DocumentFormat.OpenXml.Wordprocessing.TableProperties;
using TableRow = DocumentFormat.OpenXml.Wordprocessing.TableRow;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;
using TopBorder = DocumentFormat.OpenXml.Wordprocessing.TopBorder;

namespace DecisionViewpoints.Logic.Reporting
{
    public class WordDocument : IReportDocument
    {
        private readonly string _filename;
        private Body _body;
        private int _decisionCounter;

        private int _diagmarCounter;
        private MainDocumentPart _mainPart;
        private int _topicCounter;
        private WordprocessingDocument _wordDoc;

        public WordDocument(string filename)
        {
            _filename = filename;
            using (
                WordprocessingDocument wordDoc = WordprocessingDocument.Create(_filename,
                                                                               WordprocessingDocumentType.Document))
            {
                _mainPart = wordDoc.AddMainDocumentPart();
                _mainPart.Document = new Document();
                _body = _mainPart.Document.AppendChild(new Body());

                DateTime saveNow = DateTime.Now;

                Paragraph para = _body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());
                RunProperties runProperties = getHeading1(run);
                run.AppendChild(new Text("Decision Report [" + saveNow + "]"));
                //_body.Append(new Paragraph(new Run(new Text("Decision Report [" + saveNow + "]"))));
                _body.AppendChild(new Paragraph());
            }
        }

        public void InsertDecisionWithoutTopicMessage()
        {
            Paragraph para = _body.AppendChild(new Paragraph());
            Run run = para.AppendChild(new Run());
            RunProperties runProperties = getHeading2(run);
            run.AppendChild(new Text(++_diagmarCounter + ". Decisions without topic"));
            //_body.AppendChild(new Paragraph(new Run(new Text("Decisions not included in a topic:"))));
            _body.AppendChild(new Paragraph());
        }

        public void InsertDecisionDetailViewMessage()
        {
            Paragraph para = _body.AppendChild(new Paragraph());
            Run run = para.AppendChild(new Run());
            RunProperties runProperties = getHeading2(run);
            run.AppendChild(new Text(++_diagmarCounter + ". Decision Detail View"));
            // _body.AppendChild(new Paragraph(new Run(new Text(++_diagmarCounter + ". Decision Detail View"))));
            _body.AppendChild(new Paragraph());
        }


        public void InsertDiagramImage(IEADiagram diagram)
        {
            if (diagram.IsRelationshipView())
            {
                Paragraph para = _body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());
                RunProperties runProperties = getHeading2(run);
                run.AppendChild(new Text(++_diagmarCounter + ". Relationship View: " + diagram.Name));
                //_body.AppendChild(new Paragraph(new Run(new Text(++_diagmarCounter + ". Relationship Viewpoint"))));
            }
            else if (diagram.IsStakeholderInvolvementView())
            {
                Paragraph para = _body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());
                RunProperties runProperties = getHeading2(run);
                run.AppendChild(
                    new Text(++_diagmarCounter + ". Decision Stakeholder Involvement View: " + diagram.Name));
                //_body.AppendChild(new Paragraph(new Run(new Text(++_diagmarCounter + ". Decision Stakeholder Involvement Viewpoint"))));
            }
            else if (diagram.IsChronologicalView())
            {
                Paragraph para = _body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());
                RunProperties runProperties = getHeading2(run);
                run.AppendChild(new Text(++_diagmarCounter + ". Decision Chronological View: " + diagram.Name));
                //_body.AppendChild(new Paragraph(new Run(new Text(++_diagmarCounter + ". Decision Chronological Viewpoint"))));
            }
            else
            {
                return;
            }

            _body.AppendChild(new Paragraph(new Run(new Text())));

            ImagePart imagePart = _mainPart.AddImagePart(ImagePartType.Emf);
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
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), _filename);
            _wordDoc = WordprocessingDocument.Open(filepath, true);
            _mainPart = _wordDoc.MainDocumentPart;
            _body = _mainPart.Document.Body;
        }

        public void Close()
        {
            _wordDoc.Close();
        }

        public void InsertTopicTable(ITopic topic)
        {
            Paragraph para = _body.AppendChild(new Paragraph());
            Run run = para.AppendChild(new Run());
            RunProperties runProperties = getHeading3(run);
            run.AppendChild(new Text(_diagmarCounter + "." + (++_topicCounter) + ". " + topic.Name));
            //_body.AppendChild(new Paragraph(new Run(new Text(_diagmarCounter + "." + (++_topicCounter) + ". " + topic.Name)))); //Topic Name
            if (topic.Description != "")
            {
                _body.AppendChild(new Paragraph(new Run(new Text(topic.Description)))); //Topic Desc
            }
            _body.AppendChild(new Paragraph());
        }

        public void InsertDecisionTable(IDecision decision)
        {
            var dataDict = new Dictionary<String, IList<String>>();
            dataDict.Add("Name", new List<string>());
            dataDict.Add("State", new List<string>());
            dataDict.Add("Problem", new List<string>());
            dataDict.Add("Decision", new List<string>());
            dataDict.Add("Argumentation", new List<string>());
            dataDict.Add("Alternatives", new List<string>());
            dataDict.Add("Related Decisions", new List<string>());
            dataDict.Add("Requirements", new List<string>());
            dataDict.Add("Traces", new List<string>());
            dataDict.Add("Stakeholder Involvement", new List<string>());
            dataDict.Add("History", new List<string>());


            dataDict["Name"].Add(decision.Name);
            dataDict["State"].Add(decision.State);
            dataDict["Problem"].Add(decision.Problem);
            dataDict["Decision"].Add(decision.Solution);
            dataDict["Argumentation"].Add(decision.Argumentation);

            _decisionCounter++;
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
                        Val = new StringValue("My Caption Val") // Does not work..
                    });

            table.AppendChild(props);

            foreach (IEAConnector connector in decision.Connectors.Where(connector => connector.IsRelationship()))
            {
                // Related Decisions
                if (!connector.Stereotype.Equals("alternative for"))
                {
                    dataDict["Alternatives"].Add(connector.ClientId == decision.ID
                                                     ? "<<this>> " + decision.Name + " - " + connector.Stereotype +
                                                       " - " +
                                                       connector.GetSupplier().Name
                                                     : connector.GetClient().Name + " - " + connector.Stereotype +
                                                       " - <<this>> " + decision.Name + "\r\n");
                }
                    // Alternative Decisions
                else if (connector.Stereotype.Equals("alternative for"))
                {
                    dataDict["Related Decisions"].Add(connector.ClientId == decision.ID
                                                          ? "<<this>> " + decision.Name + " - " + connector.Stereotype +
                                                            " - " + connector.GetSupplier().Name
                                                          : connector.GetClient().Name + " - " + connector.Stereotype +
                                                            " - <<this>> " + decision.Name + "\r\n");
                }
            }

            // Related Requirements

            IEnumerable<Rating> forces = decision.GetForces();
            foreach (Rating rating in forces)
            {
                IEAElement req = EAFacade.EA.Repository.GetElementByGUID(rating.RequirementGUID);
                IEAElement concern = EAFacade.EA.Repository.GetElementByGUID(rating.ConcernGUID);
                dataDict["Requirements"].Add(req.Name + " - " + req.Notes);
            }


            foreach (IEAElement trace in decision.GetTraces())
            {
                dataDict["Traces"].Add(trace.GetProjectPath() + "/" + trace.Name);
            }


            foreach (var entry in decision.GetHistory())
            {
                dataDict["History"].Add(entry.State + " " + entry.DateModified.ToShortDateString());
            }

            foreach (Model.StakeholderInvolvement stakeholderInvolvment in decision.GetStakeholderInvolvements())
            {
                string line = string.Format(Messages.ReportingStakeholderInvolvmentLine,
                                            stakeholderInvolvment.StakeholderType, stakeholderInvolvment.StakeholderName,
                                            stakeholderInvolvment.Action);
                dataDict["Stakeholder Involvement"].Add(line);
            }


            foreach (var entry in dataDict)
            {
                if (entry.Value.Count == 0) continue;
                if ("".Equals(entry.Value[0])) continue;

                var tableRow = new TableRow();

                var rowHeader = new TableCell();
                rowHeader.Append(new TableCellWidth {Type = TableWidthUnitValues.Dxa, Width = "1821"});
                rowHeader.Append(
                    new TableCellProperties(new Shading
                        {
                            Val = ShadingPatternValues.Clear,
                            Color = "auto",
                            Fill = "##d3d4d6"
                        }));
                Paragraph para = rowHeader.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());
                getBold(run);
                run.AppendChild(new Text(entry.Key));

                var rowValue = new TableCell();
                Paragraph rowValuePara = rowValue.AppendChild(new Paragraph());
                Run rowValueRun = rowValuePara.AppendChild(new Run());
                int lineCount = 0;
                foreach (string line in entry.Value)
                {
                    rowValueRun.AppendChild(new Text(line));
                    if (++lineCount != entry.Value.Count)
                    {
                        rowValueRun.AppendChild(new Break());
                    }
                }

                tableRow.AppendChild(rowHeader);
                tableRow.AppendChild(rowValue);
                table.AppendChild(tableRow);
            }

            /*  for (int i = 0; i <= data.GetUpperBound(0); i++)
            {
                var tr = new TableRow();
                for (int j = 0; j <= data.GetUpperBound(1); j++)
                {
                    var tc = new TableCell();
                    if (j == 0)
                    {
                        //Apply the same width at column 1 (0)
                        tc.Append(new TableCellWidth {Type = TableWidthUnitValues.Dxa, Width = "1821"});
                        tc.Append(new TableCellProperties(new Shading{Val = ShadingPatternValues.Clear,Color = "auto",Fill = "##d3d4d6"}));
                        Paragraph para = tc.AppendChild(new Paragraph());
                        Run run = para.AppendChild(new Run());
                        RunProperties runProperties = getBold(run);
                        run.AppendChild(new Text(dataDict.));
                    }
                    else
                    {
                        tc.AppendChild(new Paragraph(new Run(new Text(data[i, j]))));
                    }

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
            RunProperties runProperties = getHeading2(run);
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

            // insert an empty cell in tol left of forces table
            var decRow = new TableRow();
            decRow.AppendChild(emptyCell);
            para = emptyCell.AppendChild(new Paragraph(new Run(new Text(""))));

            // insert the concern header and the decisions names
            var concCellHeader = new TableCell(new Paragraph(new Run(new Text("Concerns"))));

            decRow.AppendChild(concCellHeader);
            foreach (
                TableCell decCell in
                    forces.GetDecisions()
                          .Select(decision => new TableCell(new Paragraph(new Run(new Text(decision.Name))))))
            {
                decRow.AppendChild(decCell);
            }
            table.AppendChild(decRow);


            foreach (var concernsPerRequirement in forces.GetConcernsPerRequirement())
            {
                IEAElement requirement = concernsPerRequirement.Key;
                List<IEAElement> concerns = concernsPerRequirement.Value;

                foreach (IEAElement concern in concerns)
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
                                new Picture(
                                    new NonVisualPictureProperties(
                                        new NonVisualDrawingProperties
                                            {
                                                Id = (UInt32Value) 0U,
                                                Name = "New Bitmap Image.jpg"
                                            },
                                        new NonVisualPictureDrawingProperties()),
                                    new BlipFill(
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
                                    new ShapeProperties(
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

        // Add the bold style at a Run object used by a Paragraph in order to insert text in a Document.
        public RunProperties getBold(Run run)
        {
            RunProperties runProperties = run.AppendChild(new RunProperties());
            var bold = new Bold();
            bold.Val = OnOffValue.FromBoolean(true);
            runProperties.AppendChild(bold);
            return runProperties;
        }

        // Add properties with a stykle similar to Heading 1 style at a Run object used by a Paragraph in order to insert text in a Document.
        public RunProperties getHeading1(Run run)
        {
            RunProperties runProperties = run.AppendChild(new RunProperties());
            var bold = new Bold();
            bold.Val = OnOffValue.FromBoolean(true);
            var color = new Color {Val = "365F91", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "BF"};
            var size = new FontSize {Val = new StringValue("33")};

            runProperties.AppendChild(bold);
            runProperties.AppendChild(color);
            runProperties.AppendChild(size);
            return runProperties;
        }

        // Add properties with a stykle similar to Heading 2 style at a Run object used by a Paragraph in order to insert text in a Document.
        public RunProperties getHeading2(Run run)
        {
            RunProperties runProperties = run.AppendChild(new RunProperties());
            var bold = new Bold();
            bold.Val = OnOffValue.FromBoolean(true);
            var color = new Color {Val = "365F91", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "BF"};
            var size = new FontSize {Val = new StringValue("29")};

            runProperties.AppendChild(bold);
            runProperties.AppendChild(color);
            runProperties.AppendChild(size);
            return runProperties;
        }

        // Add properties with a stykle similar to Heading 3 style at a Run object used by a Paragraph in order to insert text in a Document.
        public RunProperties getHeading3(Run run)
        {
            RunProperties runProperties = run.AppendChild(new RunProperties());
            var bold = new Bold();
            bold.Val = OnOffValue.FromBoolean(true);
            var color = new Color {Val = "365F91", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "BF"};
            var size = new FontSize {Val = new StringValue("25")};

            runProperties.AppendChild(bold);
            runProperties.AppendChild(color);
            runProperties.AppendChild(size);
            return runProperties;
        }
    }
}
