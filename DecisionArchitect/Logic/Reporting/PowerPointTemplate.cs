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
using System.IO;
using System.Xml;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Office2010.Drawing;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.VariantTypes;
using ApplicationNonVisualDrawingProperties = DocumentFormat.OpenXml.Presentation.ApplicationNonVisualDrawingProperties;
using BlipFill = DocumentFormat.OpenXml.Drawing.BlipFill;
using ColorMap = DocumentFormat.OpenXml.Presentation.ColorMap;
using GraphicFrame = DocumentFormat.OpenXml.Presentation.GraphicFrame;
using NonVisualDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualDrawingProperties;
using NonVisualGraphicFrameDrawingProperties =
    DocumentFormat.OpenXml.Presentation.NonVisualGraphicFrameDrawingProperties;
using NonVisualGraphicFrameProperties = DocumentFormat.OpenXml.Presentation.NonVisualGraphicFrameProperties;
using NonVisualGroupShapeDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualGroupShapeDrawingProperties;
using NonVisualGroupShapeProperties = DocumentFormat.OpenXml.Presentation.NonVisualGroupShapeProperties;
using NonVisualPictureDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualPictureDrawingProperties;
using NonVisualPictureProperties = DocumentFormat.OpenXml.Presentation.NonVisualPictureProperties;
using NonVisualShapeDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualShapeDrawingProperties;
using NonVisualShapeProperties = DocumentFormat.OpenXml.Presentation.NonVisualShapeProperties;
using Picture = DocumentFormat.OpenXml.Presentation.Picture;
using Shape = DocumentFormat.OpenXml.Presentation.Shape;
using ShapeProperties = DocumentFormat.OpenXml.Presentation.ShapeProperties;
using ShapeStyle = DocumentFormat.OpenXml.Drawing.ShapeStyle;
using Template = DocumentFormat.OpenXml.ExtendedProperties.Template;
using Text = DocumentFormat.OpenXml.Drawing.Text;
using TextBody = DocumentFormat.OpenXml.Presentation.TextBody;
using Transform2D = DocumentFormat.OpenXml.Drawing.Transform2D;


// ReSharper disable InconsistentNaming
namespace DecisionArchitect.Logic.Reporting
{
    public class PowerPointTemplate
    {
        // Creates a PresentationDocument.
        public void CreatePackage(string filePath)
        {
            using (
                PresentationDocument package = PresentationDocument.Create(filePath,
                                                                           PresentationDocumentType.Presentation))
            {
                CreateParts(package);
            }
        }

        // Adds child parts and generates content of the specified part.
        public void CreateParts(PresentationDocument document)
        {
            var extendedFilePropertiesPart1 = document.AddNewPart<ExtendedFilePropertiesPart>("rId4");
            GenerateExtendedFilePropertiesPart1Content(extendedFilePropertiesPart1);

            PresentationPart presentationPart1 = document.AddPresentationPart();
            GeneratePresentationPart1Content(presentationPart1);

            var slidePart1 = presentationPart1.AddNewPart<SlidePart>("rId3");
            GenerateSlidePart1Content(slidePart1);

            var slideLayoutPart1 = slidePart1.AddNewPart<SlideLayoutPart>("rId1");
            GenerateSlideLayoutPart1Content(slideLayoutPart1);

            var slideMasterPart1 = slideLayoutPart1.AddNewPart<SlideMasterPart>("rId1");
            GenerateSlideMasterPart1Content(slideMasterPart1);

            var slideLayoutPart2 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId11");
            GenerateSlideLayoutPart2Content(slideLayoutPart2);

            slideLayoutPart2.AddPart(slideMasterPart1, "rId1");

            var slideLayoutPart3 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId12");
            GenerateSlideLayoutPart3Content(slideLayoutPart3);

            slideLayoutPart3.AddPart(slideMasterPart1, "rId1");

            slideMasterPart1.AddPart(slideLayoutPart1, "rId13");

            var themePart1 = slideMasterPart1.AddNewPart<ThemePart>("rId14");
            GenerateThemePart1Content(themePart1);

            var imagePart1 = themePart1.AddNewPart<ImagePart>("image/jpeg", "rId1");
            GenerateImagePart1Content(imagePart1);

            var slideLayoutPart4 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId1");
            GenerateSlideLayoutPart4Content(slideLayoutPart4);

            slideLayoutPart4.AddPart(slideMasterPart1, "rId1");

            var slideLayoutPart5 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId2");
            GenerateSlideLayoutPart5Content(slideLayoutPart5);

            slideLayoutPart5.AddPart(slideMasterPart1, "rId1");

            var slideLayoutPart6 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId3");
            GenerateSlideLayoutPart6Content(slideLayoutPart6);

            slideLayoutPart6.AddPart(slideMasterPart1, "rId1");

            var slideLayoutPart7 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId4");
            GenerateSlideLayoutPart7Content(slideLayoutPart7);

            slideLayoutPart7.AddPart(slideMasterPart1, "rId1");

            var slideLayoutPart8 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId5");
            GenerateSlideLayoutPart8Content(slideLayoutPart8);

            slideLayoutPart8.AddPart(slideMasterPart1, "rId1");

            var slideLayoutPart9 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId6");
            GenerateSlideLayoutPart9Content(slideLayoutPart9);

            slideLayoutPart9.AddPart(slideMasterPart1, "rId1");

            var slideLayoutPart10 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId7");
            GenerateSlideLayoutPart10Content(slideLayoutPart10);

            slideLayoutPart10.AddPart(slideMasterPart1, "rId1");

            var slideLayoutPart11 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId8");
            GenerateSlideLayoutPart11Content(slideLayoutPart11);

            slideLayoutPart11.AddPart(slideMasterPart1, "rId1");

            var slideLayoutPart12 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId9");
            GenerateSlideLayoutPart12Content(slideLayoutPart12);

            slideLayoutPart12.AddPart(slideMasterPart1, "rId1");

            var slideLayoutPart13 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId10");
            GenerateSlideLayoutPart13Content(slideLayoutPart13);

            slideLayoutPart13.AddPart(slideMasterPart1, "rId1");

            var slidePart2 = presentationPart1.AddNewPart<SlidePart>("rId4");
            GenerateSlidePart2Content(slidePart2);

            slidePart2.AddPart(slideLayoutPart5, "rId1");

            var imagePart2 = slidePart2.AddNewPart<ImagePart>("image/jpeg", "rId2");
            GenerateImagePart2Content(imagePart2);

            var slidePart3 = presentationPart1.AddNewPart<SlidePart>("rId5");
            GenerateSlidePart3Content(slidePart3);

            slidePart3.AddPart(slideLayoutPart5, "rId1");

            ExtendedPart extendedPart1 =
                presentationPart1.AddExtendedPart(
                    "http://schemas.openxmlformats.org/officeDocument/2006/relationships/printerSettings",
                    "application/vnd.openxmlformats-officedocument.presentationml.printerSettings", "bin", "rId6");
            GenerateExtendedPart1Content(extendedPart1);

            var presentationPropertiesPart1 = presentationPart1.AddNewPart<PresentationPropertiesPart>("rId7");
            GeneratePresentationPropertiesPart1Content(presentationPropertiesPart1);

            var viewPropertiesPart1 = presentationPart1.AddNewPart<ViewPropertiesPart>("rId8");
            GenerateViewPropertiesPart1Content(viewPropertiesPart1);

            presentationPart1.AddPart(themePart1, "rId9");

            var tableStylesPart1 = presentationPart1.AddNewPart<TableStylesPart>("rId10");
            GenerateTableStylesPart1Content(tableStylesPart1);

            presentationPart1.AddPart(slideMasterPart1, "rId1");

            var slidePart4 = presentationPart1.AddNewPart<SlidePart>("rId2");
            GenerateSlidePart4Content(slidePart4);

            slidePart4.AddPart(slideLayoutPart1, "rId1");

            var thumbnailPart1 = document.AddNewPart<ThumbnailPart>("image/jpeg", "rId2");
            GenerateThumbnailPart1Content(thumbnailPart1);

            SetPackageProperties(document);
        }

        // Generates content of extendedFilePropertiesPart1.
        private void GenerateExtendedFilePropertiesPart1Content(ExtendedFilePropertiesPart extendedFilePropertiesPart1)
        {
            var properties1 = new DocumentFormat.OpenXml.ExtendedProperties.Properties();
            properties1.AddNamespaceDeclaration("vt",
                                                "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");
            var template1 = new Template();
            template1.Text = "Breeze.thmx";
            var totalTime1 = new TotalTime();
            totalTime1.Text = "42";
            var words1 = new Words();
            words1.Text = "57";
            var application1 = new Application();
            application1.Text = "Microsoft Macintosh PowerPoint";
            var presentationFormat1 = new PresentationFormat();
            presentationFormat1.Text = "On-screen Show (4:3)";
            var paragraphs1 = new Paragraphs();
            paragraphs1.Text = "24";
            var slides1 = new Slides();
            slides1.Text = "4";
            var notes1 = new Notes();
            notes1.Text = "0";
            var hiddenSlides1 = new HiddenSlides();
            hiddenSlides1.Text = "0";
            var multimediaClips1 = new MultimediaClips();
            multimediaClips1.Text = "0";
            var scaleCrop1 = new ScaleCrop();
            scaleCrop1.Text = "false";

            var headingPairs1 = new HeadingPairs();

            var vTVector1 = new VTVector {BaseType = VectorBaseValues.Variant, Size = 4U};

            var variant1 = new Variant();
            var vTLPSTR1 = new VTLPSTR();
            vTLPSTR1.Text = "Theme";

            variant1.Append(vTLPSTR1);

            var variant2 = new Variant();
            var vTInt321 = new VTInt32();
            vTInt321.Text = "1";

            variant2.Append(vTInt321);

            var variant3 = new Variant();
            var vTLPSTR2 = new VTLPSTR();
            vTLPSTR2.Text = "Slide Titles";

            variant3.Append(vTLPSTR2);

            var variant4 = new Variant();
            var vTInt322 = new VTInt32();
            vTInt322.Text = "4";

            variant4.Append(vTInt322);

            vTVector1.Append(variant1);
            vTVector1.Append(variant2);
            vTVector1.Append(variant3);
            vTVector1.Append(variant4);

            headingPairs1.Append(vTVector1);

            var titlesOfParts1 = new TitlesOfParts();

            var vTVector2 = new VTVector {BaseType = VectorBaseValues.Lpstr, Size = 5U};
            var vTLPSTR3 = new VTLPSTR();
            vTLPSTR3.Text = "Breeze";
            var vTLPSTR4 = new VTLPSTR();
            vTLPSTR4.Text = "PowerPoint Presentation";
            var vTLPSTR5 = new VTLPSTR();
            vTLPSTR5.Text = "PowerPoint Presentation";
            var vTLPSTR6 = new VTLPSTR();
            vTLPSTR6.Text = "PowerPoint Presentation";
            var vTLPSTR7 = new VTLPSTR();
            vTLPSTR7.Text = "PowerPoint Presentation";

            vTVector2.Append(vTLPSTR3);
            vTVector2.Append(vTLPSTR4);
            vTVector2.Append(vTLPSTR5);
            vTVector2.Append(vTLPSTR6);
            vTVector2.Append(vTLPSTR7);

            titlesOfParts1.Append(vTVector2);
            var linksUpToDate1 = new LinksUpToDate();
            linksUpToDate1.Text = "false";
            var sharedDocument1 = new SharedDocument();
            sharedDocument1.Text = "false";
            var hyperlinksChanged1 = new HyperlinksChanged();
            hyperlinksChanged1.Text = "false";
            var applicationVersion1 = new ApplicationVersion();
            applicationVersion1.Text = "14.0000";

            properties1.Append(template1);
            properties1.Append(totalTime1);
            properties1.Append(words1);
            properties1.Append(application1);
            properties1.Append(presentationFormat1);
            properties1.Append(paragraphs1);
            properties1.Append(slides1);
            properties1.Append(notes1);
            properties1.Append(hiddenSlides1);
            properties1.Append(multimediaClips1);
            properties1.Append(scaleCrop1);
            properties1.Append(headingPairs1);
            properties1.Append(titlesOfParts1);
            properties1.Append(linksUpToDate1);
            properties1.Append(sharedDocument1);
            properties1.Append(hyperlinksChanged1);
            properties1.Append(applicationVersion1);

            extendedFilePropertiesPart1.Properties = properties1;
        }

        // Generates content of presentationPart1.
        private void GeneratePresentationPart1Content(PresentationPart presentationPart1)
        {
            var presentation1 = new Presentation {SaveSubsetFonts = true};
            presentation1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            presentation1.AddNamespaceDeclaration("r",
                                                  "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            presentation1.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            var slideMasterIdList1 = new SlideMasterIdList();
            var slideMasterId1 = new SlideMasterId {Id = 2147484277U, RelationshipId = "rId1"};

            slideMasterIdList1.Append(slideMasterId1);

            var slideIdList1 = new SlideIdList();
            var slideId1 = new SlideId {Id = 256U, RelationshipId = "rId2"};
            var slideId2 = new SlideId {Id = 260U, RelationshipId = "rId3"};
            var slideId3 = new SlideId {Id = 258U, RelationshipId = "rId4"};
            var slideId4 = new SlideId {Id = 259U, RelationshipId = "rId5"};

            slideIdList1.Append(slideId1);
            slideIdList1.Append(slideId2);
            slideIdList1.Append(slideId3);
            slideIdList1.Append(slideId4);
            var slideSize1 = new SlideSize {Cx = 9144000, Cy = 6858000, Type = SlideSizeValues.Screen4x3};
            var notesSize1 = new NotesSize {Cx = 6858000L, Cy = 9144000L};

            var defaultTextStyle1 = new DefaultTextStyle();

            var defaultParagraphProperties1 = new DefaultParagraphProperties();
            var defaultRunProperties1 = new DefaultRunProperties {Language = "en-US"};

            defaultParagraphProperties1.Append(defaultRunProperties1);

            var level1ParagraphProperties1 = new Level1ParagraphProperties
                {
                    LeftMargin = 0,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var defaultRunProperties2 = new DefaultRunProperties {FontSize = 1800, Kerning = 1200};

            var solidFill1 = new SolidFill();
            var schemeColor1 = new SchemeColor {Val = SchemeColorValues.Text1};

            solidFill1.Append(schemeColor1);
            var latinFont1 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont1 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont1 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties2.Append(solidFill1);
            defaultRunProperties2.Append(latinFont1);
            defaultRunProperties2.Append(eastAsianFont1);
            defaultRunProperties2.Append(complexScriptFont1);

            level1ParagraphProperties1.Append(defaultRunProperties2);

            var level2ParagraphProperties1 = new Level2ParagraphProperties
                {
                    LeftMargin = 457200,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var defaultRunProperties3 = new DefaultRunProperties {FontSize = 1800, Kerning = 1200};

            var solidFill2 = new SolidFill();
            var schemeColor2 = new SchemeColor {Val = SchemeColorValues.Text1};

            solidFill2.Append(schemeColor2);
            var latinFont2 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont2 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont2 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties3.Append(solidFill2);
            defaultRunProperties3.Append(latinFont2);
            defaultRunProperties3.Append(eastAsianFont2);
            defaultRunProperties3.Append(complexScriptFont2);

            level2ParagraphProperties1.Append(defaultRunProperties3);

            var level3ParagraphProperties1 = new Level3ParagraphProperties
                {
                    LeftMargin = 914400,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var defaultRunProperties4 = new DefaultRunProperties {FontSize = 1800, Kerning = 1200};

            var solidFill3 = new SolidFill();
            var schemeColor3 = new SchemeColor {Val = SchemeColorValues.Text1};

            solidFill3.Append(schemeColor3);
            var latinFont3 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont3 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont3 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties4.Append(solidFill3);
            defaultRunProperties4.Append(latinFont3);
            defaultRunProperties4.Append(eastAsianFont3);
            defaultRunProperties4.Append(complexScriptFont3);

            level3ParagraphProperties1.Append(defaultRunProperties4);

            var level4ParagraphProperties1 = new Level4ParagraphProperties
                {
                    LeftMargin = 1371600,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var defaultRunProperties5 = new DefaultRunProperties {FontSize = 1800, Kerning = 1200};

            var solidFill4 = new SolidFill();
            var schemeColor4 = new SchemeColor {Val = SchemeColorValues.Text1};

            solidFill4.Append(schemeColor4);
            var latinFont4 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont4 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont4 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties5.Append(solidFill4);
            defaultRunProperties5.Append(latinFont4);
            defaultRunProperties5.Append(eastAsianFont4);
            defaultRunProperties5.Append(complexScriptFont4);

            level4ParagraphProperties1.Append(defaultRunProperties5);

            var level5ParagraphProperties1 = new Level5ParagraphProperties
                {
                    LeftMargin = 1828800,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var defaultRunProperties6 = new DefaultRunProperties {FontSize = 1800, Kerning = 1200};

            var solidFill5 = new SolidFill();
            var schemeColor5 = new SchemeColor {Val = SchemeColorValues.Text1};

            solidFill5.Append(schemeColor5);
            var latinFont5 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont5 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont5 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties6.Append(solidFill5);
            defaultRunProperties6.Append(latinFont5);
            defaultRunProperties6.Append(eastAsianFont5);
            defaultRunProperties6.Append(complexScriptFont5);

            level5ParagraphProperties1.Append(defaultRunProperties6);

            var level6ParagraphProperties1 = new Level6ParagraphProperties
                {
                    LeftMargin = 2286000,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var defaultRunProperties7 = new DefaultRunProperties {FontSize = 1800, Kerning = 1200};

            var solidFill6 = new SolidFill();
            var schemeColor6 = new SchemeColor {Val = SchemeColorValues.Text1};

            solidFill6.Append(schemeColor6);
            var latinFont6 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont6 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont6 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties7.Append(solidFill6);
            defaultRunProperties7.Append(latinFont6);
            defaultRunProperties7.Append(eastAsianFont6);
            defaultRunProperties7.Append(complexScriptFont6);

            level6ParagraphProperties1.Append(defaultRunProperties7);

            var level7ParagraphProperties1 = new Level7ParagraphProperties
                {
                    LeftMargin = 2743200,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var defaultRunProperties8 = new DefaultRunProperties {FontSize = 1800, Kerning = 1200};

            var solidFill7 = new SolidFill();
            var schemeColor7 = new SchemeColor {Val = SchemeColorValues.Text1};

            solidFill7.Append(schemeColor7);
            var latinFont7 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont7 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont7 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties8.Append(solidFill7);
            defaultRunProperties8.Append(latinFont7);
            defaultRunProperties8.Append(eastAsianFont7);
            defaultRunProperties8.Append(complexScriptFont7);

            level7ParagraphProperties1.Append(defaultRunProperties8);

            var level8ParagraphProperties1 = new Level8ParagraphProperties
                {
                    LeftMargin = 3200400,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var defaultRunProperties9 = new DefaultRunProperties {FontSize = 1800, Kerning = 1200};

            var solidFill8 = new SolidFill();
            var schemeColor8 = new SchemeColor {Val = SchemeColorValues.Text1};

            solidFill8.Append(schemeColor8);
            var latinFont8 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont8 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont8 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties9.Append(solidFill8);
            defaultRunProperties9.Append(latinFont8);
            defaultRunProperties9.Append(eastAsianFont8);
            defaultRunProperties9.Append(complexScriptFont8);

            level8ParagraphProperties1.Append(defaultRunProperties9);

            var level9ParagraphProperties1 = new Level9ParagraphProperties
                {
                    LeftMargin = 3657600,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var defaultRunProperties10 = new DefaultRunProperties {FontSize = 1800, Kerning = 1200};

            var solidFill9 = new SolidFill();
            var schemeColor9 = new SchemeColor {Val = SchemeColorValues.Text1};

            solidFill9.Append(schemeColor9);
            var latinFont9 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont9 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont9 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties10.Append(solidFill9);
            defaultRunProperties10.Append(latinFont9);
            defaultRunProperties10.Append(eastAsianFont9);
            defaultRunProperties10.Append(complexScriptFont9);

            level9ParagraphProperties1.Append(defaultRunProperties10);

            defaultTextStyle1.Append(defaultParagraphProperties1);
            defaultTextStyle1.Append(level1ParagraphProperties1);
            defaultTextStyle1.Append(level2ParagraphProperties1);
            defaultTextStyle1.Append(level3ParagraphProperties1);
            defaultTextStyle1.Append(level4ParagraphProperties1);
            defaultTextStyle1.Append(level5ParagraphProperties1);
            defaultTextStyle1.Append(level6ParagraphProperties1);
            defaultTextStyle1.Append(level7ParagraphProperties1);
            defaultTextStyle1.Append(level8ParagraphProperties1);
            defaultTextStyle1.Append(level9ParagraphProperties1);

            presentation1.Append(slideMasterIdList1);
            presentation1.Append(slideIdList1);
            presentation1.Append(slideSize1);
            presentation1.Append(notesSize1);
            presentation1.Append(defaultTextStyle1);

            presentationPart1.Presentation = presentation1;
        }

        // Generates content of slidePart1.
        private void GenerateSlidePart1Content(SlidePart slidePart1)
        {
            var slide1 = new Slide();
            slide1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slide1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slide1.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            var commonSlideData1 = new CommonSlideData();

            var shapeTree1 = new ShapeTree();

            var nonVisualGroupShapeProperties1 = new NonVisualGroupShapeProperties();
            var nonVisualDrawingProperties1 = new NonVisualDrawingProperties {Id = 1U, Name = ""};
            var nonVisualGroupShapeDrawingProperties1 = new NonVisualGroupShapeDrawingProperties();
            var applicationNonVisualDrawingProperties1 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties1.Append(nonVisualDrawingProperties1);
            nonVisualGroupShapeProperties1.Append(nonVisualGroupShapeDrawingProperties1);
            nonVisualGroupShapeProperties1.Append(applicationNonVisualDrawingProperties1);

            var groupShapeProperties1 = new GroupShapeProperties();

            var transformGroup1 = new TransformGroup();
            var offset1 = new Offset {X = 0L, Y = 0L};
            var extents1 = new Extents {Cx = 0L, Cy = 0L};
            var childOffset1 = new ChildOffset {X = 0L, Y = 0L};
            var childExtents1 = new ChildExtents {Cx = 0L, Cy = 0L};

            transformGroup1.Append(offset1);
            transformGroup1.Append(extents1);
            transformGroup1.Append(childOffset1);
            transformGroup1.Append(childExtents1);

            groupShapeProperties1.Append(transformGroup1);

            var shape1 = new Shape();

            var nonVisualShapeProperties1 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties2 = new NonVisualDrawingProperties {Id = 3U, Name = "Title 2"};

            var nonVisualShapeDrawingProperties1 = new NonVisualShapeDrawingProperties {TextBox = true};
            var shapeLocks1 = new ShapeLocks();

            nonVisualShapeDrawingProperties1.Append(shapeLocks1);
            var applicationNonVisualDrawingProperties2 = new ApplicationNonVisualDrawingProperties();

            nonVisualShapeProperties1.Append(nonVisualDrawingProperties2);
            nonVisualShapeProperties1.Append(nonVisualShapeDrawingProperties1);
            nonVisualShapeProperties1.Append(applicationNonVisualDrawingProperties2);

            var shapeProperties1 = new ShapeProperties();

            var transform2D1 = new Transform2D();
            var offset2 = new Offset {X = 533400L, Y = 381000L};
            var extents2 = new Extents {Cx = 8042276L, Cy = 1447800L};

            transform2D1.Append(offset2);
            transform2D1.Append(extents2);

            var presetGeometry1 = new PresetGeometry {Preset = ShapeTypeValues.Rectangle};
            var adjustValueList1 = new AdjustValueList();

            presetGeometry1.Append(adjustValueList1);

            shapeProperties1.Append(transform2D1);
            shapeProperties1.Append(presetGeometry1);

            var textBody1 = new TextBody();

            var bodyProperties1 = new BodyProperties
                {
                    Vertical = TextVerticalValues.Horizontal,
                    LeftInset = 91440,
                    TopInset = 45720,
                    RightInset = 91440,
                    BottomInset = 45720,
                    RightToLeftColumns = false,
                    Anchor = TextAnchoringTypeValues.Bottom,
                    AnchorCenter = false
                };
            var noAutoFit1 = new NoAutoFit();

            bodyProperties1.Append(noAutoFit1);

            var listStyle1 = new ListStyle();

            var level1ParagraphProperties2 = new Level1ParagraphProperties
                {
                    Alignment = TextAlignmentTypeValues.Center,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var spaceBefore1 = new SpaceBefore();
            var spacingPercent1 = new SpacingPercent {Val = 0};

            spaceBefore1.Append(spacingPercent1);
            var noBullet1 = new NoBullet();

            var defaultRunProperties11 = new DefaultRunProperties {FontSize = 4600, Kerning = 1200};

            var solidFill10 = new SolidFill();
            var schemeColor10 = new SchemeColor {Val = SchemeColorValues.Accent1};

            solidFill10.Append(schemeColor10);
            var latinFont10 = new LatinFont {Typeface = "+mj-lt"};
            var eastAsianFont10 = new EastAsianFont {Typeface = "+mj-ea"};
            var complexScriptFont10 = new ComplexScriptFont {Typeface = "+mj-cs"};

            defaultRunProperties11.Append(solidFill10);
            defaultRunProperties11.Append(latinFont10);
            defaultRunProperties11.Append(eastAsianFont10);
            defaultRunProperties11.Append(complexScriptFont10);

            level1ParagraphProperties2.Append(spaceBefore1);
            level1ParagraphProperties2.Append(noBullet1);
            level1ParagraphProperties2.Append(defaultRunProperties11);

            listStyle1.Append(level1ParagraphProperties2);

            var paragraph1 = new Paragraph();

            var run1 = new Run();

            var runProperties1 = new RunProperties {Language = "en-US", FontSize = 2200, Dirty = false};
            runProperties1.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text1 = new Text();
            text1.Text = "{topic}";

            run1.Append(runProperties1);
            run1.Append(text1);
            var endParagraphRunProperties1 = new EndParagraphRunProperties
                {
                    Language = "en-US",
                    FontSize = 2200,
                    Dirty = false
                };

            paragraph1.Append(run1);
            paragraph1.Append(endParagraphRunProperties1);

            textBody1.Append(bodyProperties1);
            textBody1.Append(listStyle1);
            textBody1.Append(paragraph1);

            shape1.Append(nonVisualShapeProperties1);
            shape1.Append(shapeProperties1);
            shape1.Append(textBody1);

            var shape2 = new Shape();

            var nonVisualShapeProperties2 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties3 = new NonVisualDrawingProperties {Id = 2U, Name = "TextBox 1"};
            var nonVisualShapeDrawingProperties2 = new NonVisualShapeDrawingProperties {TextBox = true};
            var applicationNonVisualDrawingProperties3 = new ApplicationNonVisualDrawingProperties();

            nonVisualShapeProperties2.Append(nonVisualDrawingProperties3);
            nonVisualShapeProperties2.Append(nonVisualShapeDrawingProperties2);
            nonVisualShapeProperties2.Append(applicationNonVisualDrawingProperties3);

            var shapeProperties2 = new ShapeProperties();

            var transform2D2 = new Transform2D();
            var offset3 = new Offset {X = 1495778L, Y = 2111514L};
            var extents3 = new Extents {Cx = 6505222L, Cy = 369332L};

            transform2D2.Append(offset3);
            transform2D2.Append(extents3);

            var presetGeometry2 = new PresetGeometry {Preset = ShapeTypeValues.Rectangle};
            var adjustValueList2 = new AdjustValueList();

            presetGeometry2.Append(adjustValueList2);
            var noFill1 = new NoFill();

            shapeProperties2.Append(transform2D2);
            shapeProperties2.Append(presetGeometry2);
            shapeProperties2.Append(noFill1);

            var textBody2 = new TextBody();

            var bodyProperties2 = new BodyProperties {Wrap = TextWrappingValues.Square, RightToLeftColumns = false};
            var shapeAutoFit1 = new ShapeAutoFit();

            bodyProperties2.Append(shapeAutoFit1);
            var listStyle2 = new ListStyle();

            var paragraph2 = new Paragraph();
            var paragraphProperties1 = new ParagraphProperties {Alignment = TextAlignmentTypeValues.Justified};

            var run2 = new Run();

            var runProperties2 = new RunProperties {Language = "en-US"};
            runProperties2.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text2 = new Text();
            text2.Text = "{description}";

            run2.Append(runProperties2);
            run2.Append(text2);
            var endParagraphRunProperties2 = new EndParagraphRunProperties {Language = "en-US", Dirty = false};

            paragraph2.Append(paragraphProperties1);
            paragraph2.Append(run2);
            paragraph2.Append(endParagraphRunProperties2);

            textBody2.Append(bodyProperties2);
            textBody2.Append(listStyle2);
            textBody2.Append(paragraph2);

            shape2.Append(nonVisualShapeProperties2);
            shape2.Append(shapeProperties2);
            shape2.Append(textBody2);

            shapeTree1.Append(nonVisualGroupShapeProperties1);
            shapeTree1.Append(groupShapeProperties1);
            shapeTree1.Append(shape1);
            shapeTree1.Append(shape2);

            var commonSlideDataExtensionList1 = new CommonSlideDataExtensionList();

            var commonSlideDataExtension1 = new CommonSlideDataExtension
                {
                    Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}"
                };

            var creationId1 = new CreationId {Val = 130268486U};
            creationId1.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension1.Append(creationId1);

            commonSlideDataExtensionList1.Append(commonSlideDataExtension1);

            commonSlideData1.Append(shapeTree1);
            commonSlideData1.Append(commonSlideDataExtensionList1);

            var colorMapOverride1 = new ColorMapOverride();
            var masterColorMapping1 = new MasterColorMapping();

            colorMapOverride1.Append(masterColorMapping1);

            slide1.Append(commonSlideData1);
            slide1.Append(colorMapOverride1);

            slidePart1.Slide = slide1;
        }

        // Generates content of slideLayoutPart1.
        private void GenerateSlideLayoutPart1Content(SlideLayoutPart slideLayoutPart1)
        {
            var slideLayout1 = new SlideLayout {UserDrawn = true};
            slideLayout1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout1.AddNamespaceDeclaration("r",
                                                 "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout1.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            var commonSlideData2 = new CommonSlideData {Name = "1_Title Slide"};

            var shapeTree2 = new ShapeTree();

            var nonVisualGroupShapeProperties2 = new NonVisualGroupShapeProperties();
            var nonVisualDrawingProperties4 = new NonVisualDrawingProperties {Id = 1U, Name = ""};
            var nonVisualGroupShapeDrawingProperties2 = new NonVisualGroupShapeDrawingProperties();
            var applicationNonVisualDrawingProperties4 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties2.Append(nonVisualDrawingProperties4);
            nonVisualGroupShapeProperties2.Append(nonVisualGroupShapeDrawingProperties2);
            nonVisualGroupShapeProperties2.Append(applicationNonVisualDrawingProperties4);

            var groupShapeProperties2 = new GroupShapeProperties();

            var transformGroup2 = new TransformGroup();
            var offset4 = new Offset {X = 0L, Y = 0L};
            var extents4 = new Extents {Cx = 0L, Cy = 0L};
            var childOffset2 = new ChildOffset {X = 0L, Y = 0L};
            var childExtents2 = new ChildExtents {Cx = 0L, Cy = 0L};

            transformGroup2.Append(offset4);
            transformGroup2.Append(extents4);
            transformGroup2.Append(childOffset2);
            transformGroup2.Append(childExtents2);

            groupShapeProperties2.Append(transformGroup2);

            var shape3 = new Shape();

            var nonVisualShapeProperties3 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties5 = new NonVisualDrawingProperties {Id = 2U, Name = "Title 1"};

            var nonVisualShapeDrawingProperties3 = new NonVisualShapeDrawingProperties();
            var shapeLocks2 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties3.Append(shapeLocks2);

            var applicationNonVisualDrawingProperties5 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape1 = new PlaceholderShape {Type = PlaceholderValues.CenteredTitle};

            applicationNonVisualDrawingProperties5.Append(placeholderShape1);

            nonVisualShapeProperties3.Append(nonVisualDrawingProperties5);
            nonVisualShapeProperties3.Append(nonVisualShapeDrawingProperties3);
            nonVisualShapeProperties3.Append(applicationNonVisualDrawingProperties5);

            var shapeProperties3 = new ShapeProperties();

            var transform2D3 = new Transform2D();
            var offset5 = new Offset {X = 685800L, Y = 2130425L};
            var extents5 = new Extents {Cx = 7772400L, Cy = 1470025L};

            transform2D3.Append(offset5);
            transform2D3.Append(extents5);

            shapeProperties3.Append(transform2D3);

            var textBody3 = new TextBody();
            var bodyProperties3 = new BodyProperties();
            var listStyle3 = new ListStyle();

            var paragraph3 = new Paragraph();

            var run3 = new Run();

            var runProperties3 = new RunProperties {Language = "en-US"};
            runProperties3.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text3 = new Text();
            text3.Text = "Click to edit Master title style";

            run3.Append(runProperties3);
            run3.Append(text3);
            var endParagraphRunProperties3 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph3.Append(run3);
            paragraph3.Append(endParagraphRunProperties3);

            textBody3.Append(bodyProperties3);
            textBody3.Append(listStyle3);
            textBody3.Append(paragraph3);

            shape3.Append(nonVisualShapeProperties3);
            shape3.Append(shapeProperties3);
            shape3.Append(textBody3);

            var shape4 = new Shape();

            var nonVisualShapeProperties4 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties6 = new NonVisualDrawingProperties {Id = 3U, Name = "Subtitle 2"};

            var nonVisualShapeDrawingProperties4 = new NonVisualShapeDrawingProperties();
            var shapeLocks3 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties4.Append(shapeLocks3);

            var applicationNonVisualDrawingProperties6 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape2 = new PlaceholderShape {Type = PlaceholderValues.SubTitle, Index = 1U};

            applicationNonVisualDrawingProperties6.Append(placeholderShape2);

            nonVisualShapeProperties4.Append(nonVisualDrawingProperties6);
            nonVisualShapeProperties4.Append(nonVisualShapeDrawingProperties4);
            nonVisualShapeProperties4.Append(applicationNonVisualDrawingProperties6);

            var shapeProperties4 = new ShapeProperties();

            var transform2D4 = new Transform2D();
            var offset6 = new Offset {X = 1371600L, Y = 3886200L};
            var extents6 = new Extents {Cx = 6400800L, Cy = 1752600L};

            transform2D4.Append(offset6);
            transform2D4.Append(extents6);

            shapeProperties4.Append(transform2D4);

            var textBody4 = new TextBody();
            var bodyProperties4 = new BodyProperties();

            var listStyle4 = new ListStyle();

            var level1ParagraphProperties3 = new Level1ParagraphProperties
                {
                    LeftMargin = 0,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet2 = new NoBullet();

            var defaultRunProperties12 = new DefaultRunProperties();

            var solidFill11 = new SolidFill();

            var schemeColor11 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint1 = new Tint {Val = 75000};

            schemeColor11.Append(tint1);

            solidFill11.Append(schemeColor11);

            defaultRunProperties12.Append(solidFill11);

            level1ParagraphProperties3.Append(noBullet2);
            level1ParagraphProperties3.Append(defaultRunProperties12);

            var level2ParagraphProperties2 = new Level2ParagraphProperties
                {
                    LeftMargin = 457200,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet3 = new NoBullet();

            var defaultRunProperties13 = new DefaultRunProperties();

            var solidFill12 = new SolidFill();

            var schemeColor12 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint2 = new Tint {Val = 75000};

            schemeColor12.Append(tint2);

            solidFill12.Append(schemeColor12);

            defaultRunProperties13.Append(solidFill12);

            level2ParagraphProperties2.Append(noBullet3);
            level2ParagraphProperties2.Append(defaultRunProperties13);

            var level3ParagraphProperties2 = new Level3ParagraphProperties
                {
                    LeftMargin = 914400,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet4 = new NoBullet();

            var defaultRunProperties14 = new DefaultRunProperties();

            var solidFill13 = new SolidFill();

            var schemeColor13 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint3 = new Tint {Val = 75000};

            schemeColor13.Append(tint3);

            solidFill13.Append(schemeColor13);

            defaultRunProperties14.Append(solidFill13);

            level3ParagraphProperties2.Append(noBullet4);
            level3ParagraphProperties2.Append(defaultRunProperties14);

            var level4ParagraphProperties2 = new Level4ParagraphProperties
                {
                    LeftMargin = 1371600,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet5 = new NoBullet();

            var defaultRunProperties15 = new DefaultRunProperties();

            var solidFill14 = new SolidFill();

            var schemeColor14 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint4 = new Tint {Val = 75000};

            schemeColor14.Append(tint4);

            solidFill14.Append(schemeColor14);

            defaultRunProperties15.Append(solidFill14);

            level4ParagraphProperties2.Append(noBullet5);
            level4ParagraphProperties2.Append(defaultRunProperties15);

            var level5ParagraphProperties2 = new Level5ParagraphProperties
                {
                    LeftMargin = 1828800,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet6 = new NoBullet();

            var defaultRunProperties16 = new DefaultRunProperties();

            var solidFill15 = new SolidFill();

            var schemeColor15 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint5 = new Tint {Val = 75000};

            schemeColor15.Append(tint5);

            solidFill15.Append(schemeColor15);

            defaultRunProperties16.Append(solidFill15);

            level5ParagraphProperties2.Append(noBullet6);
            level5ParagraphProperties2.Append(defaultRunProperties16);

            var level6ParagraphProperties2 = new Level6ParagraphProperties
                {
                    LeftMargin = 2286000,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet7 = new NoBullet();

            var defaultRunProperties17 = new DefaultRunProperties();

            var solidFill16 = new SolidFill();

            var schemeColor16 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint6 = new Tint {Val = 75000};

            schemeColor16.Append(tint6);

            solidFill16.Append(schemeColor16);

            defaultRunProperties17.Append(solidFill16);

            level6ParagraphProperties2.Append(noBullet7);
            level6ParagraphProperties2.Append(defaultRunProperties17);

            var level7ParagraphProperties2 = new Level7ParagraphProperties
                {
                    LeftMargin = 2743200,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet8 = new NoBullet();

            var defaultRunProperties18 = new DefaultRunProperties();

            var solidFill17 = new SolidFill();

            var schemeColor17 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint7 = new Tint {Val = 75000};

            schemeColor17.Append(tint7);

            solidFill17.Append(schemeColor17);

            defaultRunProperties18.Append(solidFill17);

            level7ParagraphProperties2.Append(noBullet8);
            level7ParagraphProperties2.Append(defaultRunProperties18);

            var level8ParagraphProperties2 = new Level8ParagraphProperties
                {
                    LeftMargin = 3200400,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet9 = new NoBullet();

            var defaultRunProperties19 = new DefaultRunProperties();

            var solidFill18 = new SolidFill();

            var schemeColor18 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint8 = new Tint {Val = 75000};

            schemeColor18.Append(tint8);

            solidFill18.Append(schemeColor18);

            defaultRunProperties19.Append(solidFill18);

            level8ParagraphProperties2.Append(noBullet9);
            level8ParagraphProperties2.Append(defaultRunProperties19);

            var level9ParagraphProperties2 = new Level9ParagraphProperties
                {
                    LeftMargin = 3657600,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet10 = new NoBullet();

            var defaultRunProperties20 = new DefaultRunProperties();

            var solidFill19 = new SolidFill();

            var schemeColor19 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint9 = new Tint {Val = 75000};

            schemeColor19.Append(tint9);

            solidFill19.Append(schemeColor19);

            defaultRunProperties20.Append(solidFill19);

            level9ParagraphProperties2.Append(noBullet10);
            level9ParagraphProperties2.Append(defaultRunProperties20);

            listStyle4.Append(level1ParagraphProperties3);
            listStyle4.Append(level2ParagraphProperties2);
            listStyle4.Append(level3ParagraphProperties2);
            listStyle4.Append(level4ParagraphProperties2);
            listStyle4.Append(level5ParagraphProperties2);
            listStyle4.Append(level6ParagraphProperties2);
            listStyle4.Append(level7ParagraphProperties2);
            listStyle4.Append(level8ParagraphProperties2);
            listStyle4.Append(level9ParagraphProperties2);

            var paragraph4 = new Paragraph();

            var run4 = new Run();

            var runProperties4 = new RunProperties {Language = "en-US"};
            runProperties4.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text4 = new Text();
            text4.Text = "Click to edit Master subtitle style";

            run4.Append(runProperties4);
            run4.Append(text4);
            var endParagraphRunProperties4 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph4.Append(run4);
            paragraph4.Append(endParagraphRunProperties4);

            textBody4.Append(bodyProperties4);
            textBody4.Append(listStyle4);
            textBody4.Append(paragraph4);

            shape4.Append(nonVisualShapeProperties4);
            shape4.Append(shapeProperties4);
            shape4.Append(textBody4);

            var shape5 = new Shape();

            var nonVisualShapeProperties5 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties7 = new NonVisualDrawingProperties {Id = 4U, Name = "Date Placeholder 3"};

            var nonVisualShapeDrawingProperties5 = new NonVisualShapeDrawingProperties();
            var shapeLocks4 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties5.Append(shapeLocks4);

            var applicationNonVisualDrawingProperties7 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape3 = new PlaceholderShape
                {
                    Type = PlaceholderValues.DateAndTime,
                    Size = PlaceholderSizeValues.Half,
                    Index = 10U
                };

            applicationNonVisualDrawingProperties7.Append(placeholderShape3);

            nonVisualShapeProperties5.Append(nonVisualDrawingProperties7);
            nonVisualShapeProperties5.Append(nonVisualShapeDrawingProperties5);
            nonVisualShapeProperties5.Append(applicationNonVisualDrawingProperties7);
            var shapeProperties5 = new ShapeProperties();

            var textBody5 = new TextBody();
            var bodyProperties5 = new BodyProperties();
            var listStyle5 = new ListStyle();

            var paragraph5 = new Paragraph();

            var field1 = new Field {Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut"};

            var runProperties5 = new RunProperties {Language = "en-US"};
            runProperties5.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties2 = new ParagraphProperties();
            var text5 = new Text();
            text5.Text = "29/11/13";

            field1.Append(runProperties5);
            field1.Append(paragraphProperties2);
            field1.Append(text5);
            var endParagraphRunProperties5 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph5.Append(field1);
            paragraph5.Append(endParagraphRunProperties5);

            textBody5.Append(bodyProperties5);
            textBody5.Append(listStyle5);
            textBody5.Append(paragraph5);

            shape5.Append(nonVisualShapeProperties5);
            shape5.Append(shapeProperties5);
            shape5.Append(textBody5);

            var shape6 = new Shape();

            var nonVisualShapeProperties6 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties8 = new NonVisualDrawingProperties {Id = 5U, Name = "Footer Placeholder 4"};

            var nonVisualShapeDrawingProperties6 = new NonVisualShapeDrawingProperties();
            var shapeLocks5 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties6.Append(shapeLocks5);

            var applicationNonVisualDrawingProperties8 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape4 = new PlaceholderShape
                {
                    Type = PlaceholderValues.Footer,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 11U
                };

            applicationNonVisualDrawingProperties8.Append(placeholderShape4);

            nonVisualShapeProperties6.Append(nonVisualDrawingProperties8);
            nonVisualShapeProperties6.Append(nonVisualShapeDrawingProperties6);
            nonVisualShapeProperties6.Append(applicationNonVisualDrawingProperties8);
            var shapeProperties6 = new ShapeProperties();

            var textBody6 = new TextBody();
            var bodyProperties6 = new BodyProperties();
            var listStyle6 = new ListStyle();

            var paragraph6 = new Paragraph();
            var endParagraphRunProperties6 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph6.Append(endParagraphRunProperties6);

            textBody6.Append(bodyProperties6);
            textBody6.Append(listStyle6);
            textBody6.Append(paragraph6);

            shape6.Append(nonVisualShapeProperties6);
            shape6.Append(shapeProperties6);
            shape6.Append(textBody6);

            var shape7 = new Shape();

            var nonVisualShapeProperties7 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties9 = new NonVisualDrawingProperties
                {
                    Id = 6U,
                    Name = "Slide Number Placeholder 5"
                };

            var nonVisualShapeDrawingProperties7 = new NonVisualShapeDrawingProperties();
            var shapeLocks6 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties7.Append(shapeLocks6);

            var applicationNonVisualDrawingProperties9 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape5 = new PlaceholderShape
                {
                    Type = PlaceholderValues.SlideNumber,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 12U
                };

            applicationNonVisualDrawingProperties9.Append(placeholderShape5);

            nonVisualShapeProperties7.Append(nonVisualDrawingProperties9);
            nonVisualShapeProperties7.Append(nonVisualShapeDrawingProperties7);
            nonVisualShapeProperties7.Append(applicationNonVisualDrawingProperties9);
            var shapeProperties7 = new ShapeProperties();

            var textBody7 = new TextBody();
            var bodyProperties7 = new BodyProperties();
            var listStyle7 = new ListStyle();

            var paragraph7 = new Paragraph();

            var field2 = new Field {Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum"};

            var runProperties6 = new RunProperties {Language = "en-US"};
            runProperties6.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties3 = new ParagraphProperties();
            var text6 = new Text();
            text6.Text = "‹#›";

            field2.Append(runProperties6);
            field2.Append(paragraphProperties3);
            field2.Append(text6);
            var endParagraphRunProperties7 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph7.Append(field2);
            paragraph7.Append(endParagraphRunProperties7);

            textBody7.Append(bodyProperties7);
            textBody7.Append(listStyle7);
            textBody7.Append(paragraph7);

            shape7.Append(nonVisualShapeProperties7);
            shape7.Append(shapeProperties7);
            shape7.Append(textBody7);

            var shape8 = new Shape();

            var nonVisualShapeProperties8 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties10 = new NonVisualDrawingProperties {Id = 9U, Name = "Text Placeholder 7"};

            var nonVisualShapeDrawingProperties8 = new NonVisualShapeDrawingProperties();
            var shapeLocks7 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties8.Append(shapeLocks7);

            var applicationNonVisualDrawingProperties10 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape6 = new PlaceholderShape
                {
                    Type = PlaceholderValues.Body,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 13U
                };

            applicationNonVisualDrawingProperties10.Append(placeholderShape6);

            nonVisualShapeProperties8.Append(nonVisualDrawingProperties10);
            nonVisualShapeProperties8.Append(nonVisualShapeDrawingProperties8);
            nonVisualShapeProperties8.Append(applicationNonVisualDrawingProperties10);

            var shapeProperties8 = new ShapeProperties();

            var transform2D5 = new Transform2D();
            var offset7 = new Offset {X = 1828800L, Y = 838200L};
            var extents7 = new Extents {Cx = 2895600L, Cy = 609600L};

            transform2D5.Append(offset7);
            transform2D5.Append(extents7);

            shapeProperties8.Append(transform2D5);

            var textBody8 = new TextBody();
            var bodyProperties8 = new BodyProperties();

            var listStyle8 = new ListStyle();

            var level1ParagraphProperties4 = new Level1ParagraphProperties {LeftMargin = 0, Indent = 0};
            var noBullet11 = new NoBullet();
            var defaultRunProperties21 = new DefaultRunProperties();

            level1ParagraphProperties4.Append(noBullet11);
            level1ParagraphProperties4.Append(defaultRunProperties21);

            listStyle8.Append(level1ParagraphProperties4);

            var paragraph8 = new Paragraph();
            var paragraphProperties4 = new ParagraphProperties {Level = 0};
            var endParagraphRunProperties8 = new EndParagraphRunProperties {Language = "en-US", Dirty = false};

            paragraph8.Append(paragraphProperties4);
            paragraph8.Append(endParagraphRunProperties8);

            textBody8.Append(bodyProperties8);
            textBody8.Append(listStyle8);
            textBody8.Append(paragraph8);

            shape8.Append(nonVisualShapeProperties8);
            shape8.Append(shapeProperties8);
            shape8.Append(textBody8);

            shapeTree2.Append(nonVisualGroupShapeProperties2);
            shapeTree2.Append(groupShapeProperties2);
            shapeTree2.Append(shape3);
            shapeTree2.Append(shape4);
            shapeTree2.Append(shape5);
            shapeTree2.Append(shape6);
            shapeTree2.Append(shape7);
            shapeTree2.Append(shape8);

            var commonSlideDataExtensionList2 = new CommonSlideDataExtensionList();

            var commonSlideDataExtension2 = new CommonSlideDataExtension
                {
                    Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}"
                };

            var creationId2 = new CreationId {Val = 3875837434U};
            creationId2.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension2.Append(creationId2);

            commonSlideDataExtensionList2.Append(commonSlideDataExtension2);

            commonSlideData2.Append(shapeTree2);
            commonSlideData2.Append(commonSlideDataExtensionList2);

            var colorMapOverride2 = new ColorMapOverride();
            var masterColorMapping2 = new MasterColorMapping();

            colorMapOverride2.Append(masterColorMapping2);

            slideLayout1.Append(commonSlideData2);
            slideLayout1.Append(colorMapOverride2);

            slideLayoutPart1.SlideLayout = slideLayout1;
        }

        // Generates content of slideMasterPart1.
        private void GenerateSlideMasterPart1Content(SlideMasterPart slideMasterPart1)
        {
            var slideMaster1 = new SlideMaster();
            slideMaster1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideMaster1.AddNamespaceDeclaration("r",
                                                 "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideMaster1.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            var commonSlideData3 = new CommonSlideData();

            var background1 = new Background();

            var backgroundStyleReference1 = new BackgroundStyleReference {Index = 1003U};
            var schemeColor20 = new SchemeColor {Val = SchemeColorValues.Background2};

            backgroundStyleReference1.Append(schemeColor20);

            background1.Append(backgroundStyleReference1);

            var shapeTree3 = new ShapeTree();

            var nonVisualGroupShapeProperties3 = new NonVisualGroupShapeProperties();
            var nonVisualDrawingProperties11 = new NonVisualDrawingProperties {Id = 1U, Name = ""};
            var nonVisualGroupShapeDrawingProperties3 = new NonVisualGroupShapeDrawingProperties();
            var applicationNonVisualDrawingProperties11 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties3.Append(nonVisualDrawingProperties11);
            nonVisualGroupShapeProperties3.Append(nonVisualGroupShapeDrawingProperties3);
            nonVisualGroupShapeProperties3.Append(applicationNonVisualDrawingProperties11);

            var groupShapeProperties3 = new GroupShapeProperties();

            var transformGroup3 = new TransformGroup();
            var offset8 = new Offset {X = 0L, Y = 0L};
            var extents8 = new Extents {Cx = 0L, Cy = 0L};
            var childOffset3 = new ChildOffset {X = 0L, Y = 0L};
            var childExtents3 = new ChildExtents {Cx = 0L, Cy = 0L};

            transformGroup3.Append(offset8);
            transformGroup3.Append(extents8);
            transformGroup3.Append(childOffset3);
            transformGroup3.Append(childExtents3);

            groupShapeProperties3.Append(transformGroup3);

            var shape9 = new Shape();

            var nonVisualShapeProperties9 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties12 = new NonVisualDrawingProperties {Id = 2U, Name = "Title Placeholder 1"};

            var nonVisualShapeDrawingProperties9 = new NonVisualShapeDrawingProperties();
            var shapeLocks8 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties9.Append(shapeLocks8);

            var applicationNonVisualDrawingProperties12 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape7 = new PlaceholderShape {Type = PlaceholderValues.Title};

            applicationNonVisualDrawingProperties12.Append(placeholderShape7);

            nonVisualShapeProperties9.Append(nonVisualDrawingProperties12);
            nonVisualShapeProperties9.Append(nonVisualShapeDrawingProperties9);
            nonVisualShapeProperties9.Append(applicationNonVisualDrawingProperties12);

            var shapeProperties9 = new ShapeProperties();

            var transform2D6 = new Transform2D();
            var offset9 = new Offset {X = 549275L, Y = 107576L};
            var extents9 = new Extents {Cx = 8042276L, Cy = 1336956L};

            transform2D6.Append(offset9);
            transform2D6.Append(extents9);

            var presetGeometry3 = new PresetGeometry {Preset = ShapeTypeValues.Rectangle};
            var adjustValueList3 = new AdjustValueList();

            presetGeometry3.Append(adjustValueList3);

            shapeProperties9.Append(transform2D6);
            shapeProperties9.Append(presetGeometry3);

            var textBody9 = new TextBody();

            var bodyProperties9 = new BodyProperties
                {
                    Vertical = TextVerticalValues.Horizontal,
                    LeftInset = 91440,
                    TopInset = 45720,
                    RightInset = 91440,
                    BottomInset = 45720,
                    RightToLeftColumns = false,
                    Anchor = TextAnchoringTypeValues.Bottom,
                    AnchorCenter = false
                };
            var noAutoFit2 = new NoAutoFit();

            bodyProperties9.Append(noAutoFit2);
            var listStyle9 = new ListStyle();

            var paragraph9 = new Paragraph();

            var run5 = new Run();

            var runProperties7 = new RunProperties {Language = "en-US"};
            runProperties7.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text7 = new Text();
            text7.Text = "Click to edit Master title style";

            run5.Append(runProperties7);
            run5.Append(text7);
            var endParagraphRunProperties9 = new EndParagraphRunProperties();

            paragraph9.Append(run5);
            paragraph9.Append(endParagraphRunProperties9);

            textBody9.Append(bodyProperties9);
            textBody9.Append(listStyle9);
            textBody9.Append(paragraph9);

            shape9.Append(nonVisualShapeProperties9);
            shape9.Append(shapeProperties9);
            shape9.Append(textBody9);

            var shape10 = new Shape();

            var nonVisualShapeProperties10 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties13 = new NonVisualDrawingProperties {Id = 3U, Name = "Text Placeholder 2"};

            var nonVisualShapeDrawingProperties10 = new NonVisualShapeDrawingProperties();
            var shapeLocks9 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties10.Append(shapeLocks9);

            var applicationNonVisualDrawingProperties13 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape8 = new PlaceholderShape {Type = PlaceholderValues.Body, Index = 1U};

            applicationNonVisualDrawingProperties13.Append(placeholderShape8);

            nonVisualShapeProperties10.Append(nonVisualDrawingProperties13);
            nonVisualShapeProperties10.Append(nonVisualShapeDrawingProperties10);
            nonVisualShapeProperties10.Append(applicationNonVisualDrawingProperties13);

            var shapeProperties10 = new ShapeProperties();

            var transform2D7 = new Transform2D();
            var offset10 = new Offset {X = 549275L, Y = 1600201L};
            var extents10 = new Extents {Cx = 8042276L, Cy = 4343400L};

            transform2D7.Append(offset10);
            transform2D7.Append(extents10);

            var presetGeometry4 = new PresetGeometry {Preset = ShapeTypeValues.Rectangle};
            var adjustValueList4 = new AdjustValueList();

            presetGeometry4.Append(adjustValueList4);

            shapeProperties10.Append(transform2D7);
            shapeProperties10.Append(presetGeometry4);

            var textBody10 = new TextBody();

            var bodyProperties10 = new BodyProperties
                {
                    Vertical = TextVerticalValues.Horizontal,
                    LeftInset = 91440,
                    TopInset = 45720,
                    RightInset = 91440,
                    BottomInset = 45720,
                    RightToLeftColumns = false
                };
            var normalAutoFit1 = new NormalAutoFit();

            bodyProperties10.Append(normalAutoFit1);
            var listStyle10 = new ListStyle();

            var paragraph10 = new Paragraph();
            var paragraphProperties5 = new ParagraphProperties {Level = 0};

            var run6 = new Run();

            var runProperties8 = new RunProperties {Language = "en-US"};
            runProperties8.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text8 = new Text();
            text8.Text = "Click to edit Master text styles";

            run6.Append(runProperties8);
            run6.Append(text8);

            paragraph10.Append(paragraphProperties5);
            paragraph10.Append(run6);

            var paragraph11 = new Paragraph();
            var paragraphProperties6 = new ParagraphProperties {Level = 1};

            var run7 = new Run();

            var runProperties9 = new RunProperties {Language = "en-US"};
            runProperties9.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text9 = new Text();
            text9.Text = "Second level";

            run7.Append(runProperties9);
            run7.Append(text9);

            paragraph11.Append(paragraphProperties6);
            paragraph11.Append(run7);

            var paragraph12 = new Paragraph();
            var paragraphProperties7 = new ParagraphProperties {Level = 2};

            var run8 = new Run();

            var runProperties10 = new RunProperties {Language = "en-US"};
            runProperties10.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text10 = new Text();
            text10.Text = "Third level";

            run8.Append(runProperties10);
            run8.Append(text10);

            paragraph12.Append(paragraphProperties7);
            paragraph12.Append(run8);

            var paragraph13 = new Paragraph();
            var paragraphProperties8 = new ParagraphProperties {Level = 3};

            var run9 = new Run();

            var runProperties11 = new RunProperties {Language = "en-US"};
            runProperties11.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text11 = new Text();
            text11.Text = "Fourth level";

            run9.Append(runProperties11);
            run9.Append(text11);

            paragraph13.Append(paragraphProperties8);
            paragraph13.Append(run9);

            var paragraph14 = new Paragraph();
            var paragraphProperties9 = new ParagraphProperties {Level = 4};

            var run10 = new Run();

            var runProperties12 = new RunProperties {Language = "en-US"};
            runProperties12.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text12 = new Text();
            text12.Text = "Fifth level";

            run10.Append(runProperties12);
            run10.Append(text12);
            var endParagraphRunProperties10 = new EndParagraphRunProperties {Dirty = false};

            paragraph14.Append(paragraphProperties9);
            paragraph14.Append(run10);
            paragraph14.Append(endParagraphRunProperties10);

            textBody10.Append(bodyProperties10);
            textBody10.Append(listStyle10);
            textBody10.Append(paragraph10);
            textBody10.Append(paragraph11);
            textBody10.Append(paragraph12);
            textBody10.Append(paragraph13);
            textBody10.Append(paragraph14);

            shape10.Append(nonVisualShapeProperties10);
            shape10.Append(shapeProperties10);
            shape10.Append(textBody10);

            var shape11 = new Shape();

            var nonVisualShapeProperties11 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties14 = new NonVisualDrawingProperties {Id = 4U, Name = "Date Placeholder 3"};

            var nonVisualShapeDrawingProperties11 = new NonVisualShapeDrawingProperties();
            var shapeLocks10 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties11.Append(shapeLocks10);

            var applicationNonVisualDrawingProperties14 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape9 = new PlaceholderShape
                {
                    Type = PlaceholderValues.DateAndTime,
                    Size = PlaceholderSizeValues.Half,
                    Index = 2U
                };

            applicationNonVisualDrawingProperties14.Append(placeholderShape9);

            nonVisualShapeProperties11.Append(nonVisualDrawingProperties14);
            nonVisualShapeProperties11.Append(nonVisualShapeDrawingProperties11);
            nonVisualShapeProperties11.Append(applicationNonVisualDrawingProperties14);

            var shapeProperties11 = new ShapeProperties();

            var transform2D8 = new Transform2D();
            var offset11 = new Offset {X = 5629835L, Y = 6275668L};
            var extents11 = new Extents {Cx = 2133600L, Cy = 365125L};

            transform2D8.Append(offset11);
            transform2D8.Append(extents11);

            var presetGeometry5 = new PresetGeometry {Preset = ShapeTypeValues.Rectangle};
            var adjustValueList5 = new AdjustValueList();

            presetGeometry5.Append(adjustValueList5);

            shapeProperties11.Append(transform2D8);
            shapeProperties11.Append(presetGeometry5);

            var textBody11 = new TextBody();
            var bodyProperties11 = new BodyProperties
                {
                    Vertical = TextVerticalValues.Horizontal,
                    LeftInset = 91440,
                    TopInset = 45720,
                    RightInset = 91440,
                    BottomInset = 45720,
                    RightToLeftColumns = false,
                    Anchor = TextAnchoringTypeValues.Center
                };

            var listStyle11 = new ListStyle();

            var level1ParagraphProperties5 = new Level1ParagraphProperties {Alignment = TextAlignmentTypeValues.Right};

            var defaultRunProperties22 = new DefaultRunProperties {FontSize = 1200};

            var solidFill20 = new SolidFill();
            var schemeColor21 = new SchemeColor {Val = SchemeColorValues.Background1};

            solidFill20.Append(schemeColor21);

            defaultRunProperties22.Append(solidFill20);

            level1ParagraphProperties5.Append(defaultRunProperties22);

            listStyle11.Append(level1ParagraphProperties5);

            var paragraph15 = new Paragraph();

            var field3 = new Field {Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut"};

            var runProperties13 = new RunProperties {Language = "en-US"};
            runProperties13.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties10 = new ParagraphProperties();
            var text13 = new Text();
            text13.Text = "29/11/13";

            field3.Append(runProperties13);
            field3.Append(paragraphProperties10);
            field3.Append(text13);
            var endParagraphRunProperties11 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph15.Append(field3);
            paragraph15.Append(endParagraphRunProperties11);

            textBody11.Append(bodyProperties11);
            textBody11.Append(listStyle11);
            textBody11.Append(paragraph15);

            shape11.Append(nonVisualShapeProperties11);
            shape11.Append(shapeProperties11);
            shape11.Append(textBody11);

            var shape12 = new Shape();

            var nonVisualShapeProperties12 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties15 = new NonVisualDrawingProperties {Id = 5U, Name = "Footer Placeholder 4"};

            var nonVisualShapeDrawingProperties12 = new NonVisualShapeDrawingProperties();
            var shapeLocks11 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties12.Append(shapeLocks11);

            var applicationNonVisualDrawingProperties15 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape10 = new PlaceholderShape
                {
                    Type = PlaceholderValues.Footer,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 3U
                };

            applicationNonVisualDrawingProperties15.Append(placeholderShape10);

            nonVisualShapeProperties12.Append(nonVisualDrawingProperties15);
            nonVisualShapeProperties12.Append(nonVisualShapeDrawingProperties12);
            nonVisualShapeProperties12.Append(applicationNonVisualDrawingProperties15);

            var shapeProperties12 = new ShapeProperties();

            var transform2D9 = new Transform2D();
            var offset12 = new Offset {X = 264458L, Y = 6275668L};
            var extents12 = new Extents {Cx = 4840941L, Cy = 365125L};

            transform2D9.Append(offset12);
            transform2D9.Append(extents12);

            var presetGeometry6 = new PresetGeometry {Preset = ShapeTypeValues.Rectangle};
            var adjustValueList6 = new AdjustValueList();

            presetGeometry6.Append(adjustValueList6);

            shapeProperties12.Append(transform2D9);
            shapeProperties12.Append(presetGeometry6);

            var textBody12 = new TextBody();
            var bodyProperties12 = new BodyProperties
                {
                    Vertical = TextVerticalValues.Horizontal,
                    LeftInset = 91440,
                    TopInset = 45720,
                    RightInset = 91440,
                    BottomInset = 45720,
                    RightToLeftColumns = false,
                    Anchor = TextAnchoringTypeValues.Center
                };

            var listStyle12 = new ListStyle();

            var level1ParagraphProperties6 = new Level1ParagraphProperties {Alignment = TextAlignmentTypeValues.Left};

            var defaultRunProperties23 = new DefaultRunProperties {FontSize = 1200};

            var solidFill21 = new SolidFill();
            var schemeColor22 = new SchemeColor {Val = SchemeColorValues.Background1};

            solidFill21.Append(schemeColor22);

            defaultRunProperties23.Append(solidFill21);

            level1ParagraphProperties6.Append(defaultRunProperties23);

            listStyle12.Append(level1ParagraphProperties6);

            var paragraph16 = new Paragraph();
            var endParagraphRunProperties12 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph16.Append(endParagraphRunProperties12);

            textBody12.Append(bodyProperties12);
            textBody12.Append(listStyle12);
            textBody12.Append(paragraph16);

            shape12.Append(nonVisualShapeProperties12);
            shape12.Append(shapeProperties12);
            shape12.Append(textBody12);

            var shape13 = new Shape();

            var nonVisualShapeProperties13 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties16 = new NonVisualDrawingProperties
                {
                    Id = 6U,
                    Name = "Slide Number Placeholder 5"
                };

            var nonVisualShapeDrawingProperties13 = new NonVisualShapeDrawingProperties();
            var shapeLocks12 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties13.Append(shapeLocks12);

            var applicationNonVisualDrawingProperties16 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape11 = new PlaceholderShape
                {
                    Type = PlaceholderValues.SlideNumber,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 4U
                };

            applicationNonVisualDrawingProperties16.Append(placeholderShape11);

            nonVisualShapeProperties13.Append(nonVisualDrawingProperties16);
            nonVisualShapeProperties13.Append(nonVisualShapeDrawingProperties13);
            nonVisualShapeProperties13.Append(applicationNonVisualDrawingProperties16);

            var shapeProperties13 = new ShapeProperties();

            var transform2D10 = new Transform2D();
            var offset13 = new Offset {X = 7897906L, Y = 6275668L};
            var extents13 = new Extents {Cx = 990600L, Cy = 365125L};

            transform2D10.Append(offset13);
            transform2D10.Append(extents13);

            var presetGeometry7 = new PresetGeometry {Preset = ShapeTypeValues.Rectangle};
            var adjustValueList7 = new AdjustValueList();

            presetGeometry7.Append(adjustValueList7);

            shapeProperties13.Append(transform2D10);
            shapeProperties13.Append(presetGeometry7);

            var textBody13 = new TextBody();
            var bodyProperties13 = new BodyProperties
                {
                    Vertical = TextVerticalValues.Horizontal,
                    LeftInset = 91440,
                    TopInset = 45720,
                    RightInset = 91440,
                    BottomInset = 45720,
                    RightToLeftColumns = false,
                    Anchor = TextAnchoringTypeValues.Center
                };

            var listStyle13 = new ListStyle();

            var level1ParagraphProperties7 = new Level1ParagraphProperties {Alignment = TextAlignmentTypeValues.Right};

            var defaultRunProperties24 = new DefaultRunProperties {FontSize = 3600};

            var solidFill22 = new SolidFill();
            var schemeColor23 = new SchemeColor {Val = SchemeColorValues.Background1};

            solidFill22.Append(schemeColor23);

            defaultRunProperties24.Append(solidFill22);

            level1ParagraphProperties7.Append(defaultRunProperties24);

            listStyle13.Append(level1ParagraphProperties7);

            var paragraph17 = new Paragraph();

            var field4 = new Field {Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum"};

            var runProperties14 = new RunProperties {Language = "en-US"};
            runProperties14.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties11 = new ParagraphProperties();
            var text14 = new Text();
            text14.Text = "‹#›";

            field4.Append(runProperties14);
            field4.Append(paragraphProperties11);
            field4.Append(text14);
            var endParagraphRunProperties13 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph17.Append(field4);
            paragraph17.Append(endParagraphRunProperties13);

            textBody13.Append(bodyProperties13);
            textBody13.Append(listStyle13);
            textBody13.Append(paragraph17);

            shape13.Append(nonVisualShapeProperties13);
            shape13.Append(shapeProperties13);
            shape13.Append(textBody13);

            shapeTree3.Append(nonVisualGroupShapeProperties3);
            shapeTree3.Append(groupShapeProperties3);
            shapeTree3.Append(shape9);
            shapeTree3.Append(shape10);
            shapeTree3.Append(shape11);
            shapeTree3.Append(shape12);
            shapeTree3.Append(shape13);

            commonSlideData3.Append(background1);
            commonSlideData3.Append(shapeTree3);
            var colorMap1 = new ColorMap
                {
                    Background1 = ColorSchemeIndexValues.Light1,
                    Text1 = ColorSchemeIndexValues.Dark1,
                    Background2 = ColorSchemeIndexValues.Light2,
                    Text2 = ColorSchemeIndexValues.Dark2,
                    Accent1 = ColorSchemeIndexValues.Accent1,
                    Accent2 = ColorSchemeIndexValues.Accent2,
                    Accent3 = ColorSchemeIndexValues.Accent3,
                    Accent4 = ColorSchemeIndexValues.Accent4,
                    Accent5 = ColorSchemeIndexValues.Accent5,
                    Accent6 = ColorSchemeIndexValues.Accent6,
                    Hyperlink = ColorSchemeIndexValues.Hyperlink,
                    FollowedHyperlink = ColorSchemeIndexValues.FollowedHyperlink
                };

            var slideLayoutIdList1 = new SlideLayoutIdList();
            var slideLayoutId1 = new SlideLayoutId {Id = 2147484278U, RelationshipId = "rId1"};
            var slideLayoutId2 = new SlideLayoutId {Id = 2147484279U, RelationshipId = "rId2"};
            var slideLayoutId3 = new SlideLayoutId {Id = 2147484280U, RelationshipId = "rId3"};
            var slideLayoutId4 = new SlideLayoutId {Id = 2147484281U, RelationshipId = "rId4"};
            var slideLayoutId5 = new SlideLayoutId {Id = 2147484282U, RelationshipId = "rId5"};
            var slideLayoutId6 = new SlideLayoutId {Id = 2147484283U, RelationshipId = "rId6"};
            var slideLayoutId7 = new SlideLayoutId {Id = 2147484284U, RelationshipId = "rId7"};
            var slideLayoutId8 = new SlideLayoutId {Id = 2147484285U, RelationshipId = "rId8"};
            var slideLayoutId9 = new SlideLayoutId {Id = 2147484286U, RelationshipId = "rId9"};
            var slideLayoutId10 = new SlideLayoutId {Id = 2147484287U, RelationshipId = "rId10"};
            var slideLayoutId11 = new SlideLayoutId {Id = 2147484288U, RelationshipId = "rId11"};
            var slideLayoutId12 = new SlideLayoutId {Id = 2147484289U, RelationshipId = "rId12"};
            var slideLayoutId13 = new SlideLayoutId {Id = 2147484290U, RelationshipId = "rId13"};

            slideLayoutIdList1.Append(slideLayoutId1);
            slideLayoutIdList1.Append(slideLayoutId2);
            slideLayoutIdList1.Append(slideLayoutId3);
            slideLayoutIdList1.Append(slideLayoutId4);
            slideLayoutIdList1.Append(slideLayoutId5);
            slideLayoutIdList1.Append(slideLayoutId6);
            slideLayoutIdList1.Append(slideLayoutId7);
            slideLayoutIdList1.Append(slideLayoutId8);
            slideLayoutIdList1.Append(slideLayoutId9);
            slideLayoutIdList1.Append(slideLayoutId10);
            slideLayoutIdList1.Append(slideLayoutId11);
            slideLayoutIdList1.Append(slideLayoutId12);
            slideLayoutIdList1.Append(slideLayoutId13);

            var textStyles1 = new TextStyles();

            var titleStyle1 = new TitleStyle();

            var level1ParagraphProperties8 = new Level1ParagraphProperties
                {
                    Alignment = TextAlignmentTypeValues.Center,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var spaceBefore2 = new SpaceBefore();
            var spacingPercent2 = new SpacingPercent {Val = 0};

            spaceBefore2.Append(spacingPercent2);
            var noBullet12 = new NoBullet();

            var defaultRunProperties25 = new DefaultRunProperties {FontSize = 4600, Kerning = 1200};

            var solidFill23 = new SolidFill();
            var schemeColor24 = new SchemeColor {Val = SchemeColorValues.Accent1};

            solidFill23.Append(schemeColor24);
            var latinFont11 = new LatinFont {Typeface = "+mj-lt"};
            var eastAsianFont11 = new EastAsianFont {Typeface = "+mj-ea"};
            var complexScriptFont11 = new ComplexScriptFont {Typeface = "+mj-cs"};

            defaultRunProperties25.Append(solidFill23);
            defaultRunProperties25.Append(latinFont11);
            defaultRunProperties25.Append(eastAsianFont11);
            defaultRunProperties25.Append(complexScriptFont11);

            level1ParagraphProperties8.Append(spaceBefore2);
            level1ParagraphProperties8.Append(noBullet12);
            level1ParagraphProperties8.Append(defaultRunProperties25);

            titleStyle1.Append(level1ParagraphProperties8);

            var bodyStyle1 = new BodyStyle();

            var level1ParagraphProperties9 = new Level1ParagraphProperties
                {
                    LeftMargin = 349250,
                    Indent = -349250,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var spaceBefore3 = new SpaceBefore();
            var spacingPoints1 = new SpacingPoints {Val = 2000};

            spaceBefore3.Append(spacingPoints1);

            var bulletColor1 = new BulletColor();

            var schemeColor25 = new SchemeColor {Val = SchemeColorValues.Accent1};
            var luminanceModulation1 = new LuminanceModulation {Val = 60000};
            var luminanceOffset1 = new LuminanceOffset {Val = 40000};

            schemeColor25.Append(luminanceModulation1);
            schemeColor25.Append(luminanceOffset1);

            bulletColor1.Append(schemeColor25);
            var bulletSizePercentage1 = new BulletSizePercentage {Val = 110000};
            var bulletFont1 = new BulletFont {Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2};
            var characterBullet1 = new CharacterBullet {Char = ""};

            var defaultRunProperties26 = new DefaultRunProperties {FontSize = 2400, Kerning = 1200};

            var solidFill24 = new SolidFill();

            var schemeColor26 = new SchemeColor {Val = SchemeColorValues.Text1};
            var luminanceModulation2 = new LuminanceModulation {Val = 65000};
            var luminanceOffset2 = new LuminanceOffset {Val = 35000};

            schemeColor26.Append(luminanceModulation2);
            schemeColor26.Append(luminanceOffset2);

            solidFill24.Append(schemeColor26);
            var latinFont12 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont12 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont12 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties26.Append(solidFill24);
            defaultRunProperties26.Append(latinFont12);
            defaultRunProperties26.Append(eastAsianFont12);
            defaultRunProperties26.Append(complexScriptFont12);

            level1ParagraphProperties9.Append(spaceBefore3);
            level1ParagraphProperties9.Append(bulletColor1);
            level1ParagraphProperties9.Append(bulletSizePercentage1);
            level1ParagraphProperties9.Append(bulletFont1);
            level1ParagraphProperties9.Append(characterBullet1);
            level1ParagraphProperties9.Append(defaultRunProperties26);

            var level2ParagraphProperties3 = new Level2ParagraphProperties
                {
                    LeftMargin = 685800,
                    Indent = -336550,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var spaceBefore4 = new SpaceBefore();
            var spacingPoints2 = new SpacingPoints {Val = 600};

            spaceBefore4.Append(spacingPoints2);

            var bulletColor2 = new BulletColor();

            var schemeColor27 = new SchemeColor {Val = SchemeColorValues.Accent1};
            var luminanceModulation3 = new LuminanceModulation {Val = 75000};

            schemeColor27.Append(luminanceModulation3);

            bulletColor2.Append(schemeColor27);
            var bulletSizePercentage2 = new BulletSizePercentage {Val = 110000};
            var bulletFont2 = new BulletFont {Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2};
            var characterBullet2 = new CharacterBullet {Char = ""};

            var defaultRunProperties27 = new DefaultRunProperties {FontSize = 2200, Kerning = 1200};

            var solidFill25 = new SolidFill();

            var schemeColor28 = new SchemeColor {Val = SchemeColorValues.Text1};
            var luminanceModulation4 = new LuminanceModulation {Val = 65000};
            var luminanceOffset3 = new LuminanceOffset {Val = 35000};

            schemeColor28.Append(luminanceModulation4);
            schemeColor28.Append(luminanceOffset3);

            solidFill25.Append(schemeColor28);
            var latinFont13 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont13 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont13 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties27.Append(solidFill25);
            defaultRunProperties27.Append(latinFont13);
            defaultRunProperties27.Append(eastAsianFont13);
            defaultRunProperties27.Append(complexScriptFont13);

            level2ParagraphProperties3.Append(spaceBefore4);
            level2ParagraphProperties3.Append(bulletColor2);
            level2ParagraphProperties3.Append(bulletSizePercentage2);
            level2ParagraphProperties3.Append(bulletFont2);
            level2ParagraphProperties3.Append(characterBullet2);
            level2ParagraphProperties3.Append(defaultRunProperties27);

            var level3ParagraphProperties3 = new Level3ParagraphProperties
                {
                    LeftMargin = 968375,
                    Indent = -282575,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var spaceBefore5 = new SpaceBefore();
            var spacingPoints3 = new SpacingPoints {Val = 600};

            spaceBefore5.Append(spacingPoints3);

            var bulletColor3 = new BulletColor();

            var schemeColor29 = new SchemeColor {Val = SchemeColorValues.Accent1};
            var luminanceModulation5 = new LuminanceModulation {Val = 60000};
            var luminanceOffset4 = new LuminanceOffset {Val = 40000};

            schemeColor29.Append(luminanceModulation5);
            schemeColor29.Append(luminanceOffset4);

            bulletColor3.Append(schemeColor29);
            var bulletSizePercentage3 = new BulletSizePercentage {Val = 110000};
            var bulletFont3 = new BulletFont {Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2};
            var characterBullet3 = new CharacterBullet {Char = ""};

            var defaultRunProperties28 = new DefaultRunProperties {FontSize = 2000, Kerning = 1200};

            var solidFill26 = new SolidFill();

            var schemeColor30 = new SchemeColor {Val = SchemeColorValues.Text1};
            var luminanceModulation6 = new LuminanceModulation {Val = 65000};
            var luminanceOffset5 = new LuminanceOffset {Val = 35000};

            schemeColor30.Append(luminanceModulation6);
            schemeColor30.Append(luminanceOffset5);

            solidFill26.Append(schemeColor30);
            var latinFont14 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont14 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont14 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties28.Append(solidFill26);
            defaultRunProperties28.Append(latinFont14);
            defaultRunProperties28.Append(eastAsianFont14);
            defaultRunProperties28.Append(complexScriptFont14);

            level3ParagraphProperties3.Append(spaceBefore5);
            level3ParagraphProperties3.Append(bulletColor3);
            level3ParagraphProperties3.Append(bulletSizePercentage3);
            level3ParagraphProperties3.Append(bulletFont3);
            level3ParagraphProperties3.Append(characterBullet3);
            level3ParagraphProperties3.Append(defaultRunProperties28);

            var level4ParagraphProperties3 = new Level4ParagraphProperties
                {
                    LeftMargin = 1263650,
                    Indent = -295275,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var spaceBefore6 = new SpaceBefore();
            var spacingPoints4 = new SpacingPoints {Val = 600};

            spaceBefore6.Append(spacingPoints4);

            var bulletColor4 = new BulletColor();

            var schemeColor31 = new SchemeColor {Val = SchemeColorValues.Accent1};
            var luminanceModulation7 = new LuminanceModulation {Val = 75000};

            schemeColor31.Append(luminanceModulation7);

            bulletColor4.Append(schemeColor31);
            var bulletSizePercentage4 = new BulletSizePercentage {Val = 110000};
            var bulletFont4 = new BulletFont {Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2};
            var characterBullet4 = new CharacterBullet {Char = ""};

            var defaultRunProperties29 = new DefaultRunProperties {FontSize = 1800, Kerning = 1200};

            var solidFill27 = new SolidFill();

            var schemeColor32 = new SchemeColor {Val = SchemeColorValues.Text1};
            var luminanceModulation8 = new LuminanceModulation {Val = 65000};
            var luminanceOffset6 = new LuminanceOffset {Val = 35000};

            schemeColor32.Append(luminanceModulation8);
            schemeColor32.Append(luminanceOffset6);

            solidFill27.Append(schemeColor32);
            var latinFont15 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont15 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont15 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties29.Append(solidFill27);
            defaultRunProperties29.Append(latinFont15);
            defaultRunProperties29.Append(eastAsianFont15);
            defaultRunProperties29.Append(complexScriptFont15);

            level4ParagraphProperties3.Append(spaceBefore6);
            level4ParagraphProperties3.Append(bulletColor4);
            level4ParagraphProperties3.Append(bulletSizePercentage4);
            level4ParagraphProperties3.Append(bulletFont4);
            level4ParagraphProperties3.Append(characterBullet4);
            level4ParagraphProperties3.Append(defaultRunProperties29);

            var level5ParagraphProperties3 = new Level5ParagraphProperties
                {
                    LeftMargin = 1546225,
                    Indent = -282575,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var spaceBefore7 = new SpaceBefore();
            var spacingPoints5 = new SpacingPoints {Val = 600};

            spaceBefore7.Append(spacingPoints5);

            var bulletColor5 = new BulletColor();

            var schemeColor33 = new SchemeColor {Val = SchemeColorValues.Accent1};
            var luminanceModulation9 = new LuminanceModulation {Val = 60000};
            var luminanceOffset7 = new LuminanceOffset {Val = 40000};

            schemeColor33.Append(luminanceModulation9);
            schemeColor33.Append(luminanceOffset7);

            bulletColor5.Append(schemeColor33);
            var bulletSizePercentage5 = new BulletSizePercentage {Val = 110000};
            var bulletFont5 = new BulletFont {Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2};
            var characterBullet5 = new CharacterBullet {Char = ""};

            var defaultRunProperties30 = new DefaultRunProperties {FontSize = 1800, Kerning = 1200};

            var solidFill28 = new SolidFill();

            var schemeColor34 = new SchemeColor {Val = SchemeColorValues.Text1};
            var luminanceModulation10 = new LuminanceModulation {Val = 65000};
            var luminanceOffset8 = new LuminanceOffset {Val = 35000};

            schemeColor34.Append(luminanceModulation10);
            schemeColor34.Append(luminanceOffset8);

            solidFill28.Append(schemeColor34);
            var latinFont16 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont16 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont16 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties30.Append(solidFill28);
            defaultRunProperties30.Append(latinFont16);
            defaultRunProperties30.Append(eastAsianFont16);
            defaultRunProperties30.Append(complexScriptFont16);

            level5ParagraphProperties3.Append(spaceBefore7);
            level5ParagraphProperties3.Append(bulletColor5);
            level5ParagraphProperties3.Append(bulletSizePercentage5);
            level5ParagraphProperties3.Append(bulletFont5);
            level5ParagraphProperties3.Append(characterBullet5);
            level5ParagraphProperties3.Append(defaultRunProperties30);

            var level6ParagraphProperties3 = new Level6ParagraphProperties
                {
                    LeftMargin = 1828800,
                    Indent = -282575,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var spaceBefore8 = new SpaceBefore();
            var spacingPercent3 = new SpacingPercent {Val = 20000};

            spaceBefore8.Append(spacingPercent3);

            var bulletColor6 = new BulletColor();
            var schemeColor35 = new SchemeColor {Val = SchemeColorValues.Accent2};

            bulletColor6.Append(schemeColor35);
            var bulletSizePercentage6 = new BulletSizePercentage {Val = 110000};
            var bulletFont6 = new BulletFont {Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2};
            var characterBullet6 = new CharacterBullet {Char = "—"};

            var defaultRunProperties31 = new DefaultRunProperties
                {
                    Language = "en-US",
                    FontSize = 1800,
                    Kerning = 1200,
                    Dirty = false
                };
            defaultRunProperties31.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));

            var solidFill29 = new SolidFill();

            var schemeColor36 = new SchemeColor {Val = SchemeColorValues.Text1};
            var luminanceModulation11 = new LuminanceModulation {Val = 65000};
            var luminanceOffset9 = new LuminanceOffset {Val = 35000};

            schemeColor36.Append(luminanceModulation11);
            schemeColor36.Append(luminanceOffset9);

            solidFill29.Append(schemeColor36);
            var latinFont17 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont17 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont17 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties31.Append(solidFill29);
            defaultRunProperties31.Append(latinFont17);
            defaultRunProperties31.Append(eastAsianFont17);
            defaultRunProperties31.Append(complexScriptFont17);

            level6ParagraphProperties3.Append(spaceBefore8);
            level6ParagraphProperties3.Append(bulletColor6);
            level6ParagraphProperties3.Append(bulletSizePercentage6);
            level6ParagraphProperties3.Append(bulletFont6);
            level6ParagraphProperties3.Append(characterBullet6);
            level6ParagraphProperties3.Append(defaultRunProperties31);

            var level7ParagraphProperties3 = new Level7ParagraphProperties
                {
                    LeftMargin = 2117725,
                    Indent = -282575,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var spaceBefore9 = new SpaceBefore();
            var spacingPercent4 = new SpacingPercent {Val = 20000};

            spaceBefore9.Append(spacingPercent4);

            var bulletColor7 = new BulletColor();

            var schemeColor37 = new SchemeColor {Val = SchemeColorValues.Accent1};
            var luminanceModulation12 = new LuminanceModulation {Val = 60000};
            var luminanceOffset10 = new LuminanceOffset {Val = 40000};

            schemeColor37.Append(luminanceModulation12);
            schemeColor37.Append(luminanceOffset10);

            bulletColor7.Append(schemeColor37);
            var bulletSizePercentage7 = new BulletSizePercentage {Val = 110000};
            var bulletFont7 = new BulletFont {Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2};
            var characterBullet7 = new CharacterBullet {Char = "—"};

            var defaultRunProperties32 = new DefaultRunProperties
                {
                    Language = "en-US",
                    FontSize = 1800,
                    Kerning = 1200,
                    Dirty = false
                };
            defaultRunProperties32.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));

            var solidFill30 = new SolidFill();

            var schemeColor38 = new SchemeColor {Val = SchemeColorValues.Text1};
            var luminanceModulation13 = new LuminanceModulation {Val = 65000};
            var luminanceOffset11 = new LuminanceOffset {Val = 35000};

            schemeColor38.Append(luminanceModulation13);
            schemeColor38.Append(luminanceOffset11);

            solidFill30.Append(schemeColor38);
            var latinFont18 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont18 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont18 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties32.Append(solidFill30);
            defaultRunProperties32.Append(latinFont18);
            defaultRunProperties32.Append(eastAsianFont18);
            defaultRunProperties32.Append(complexScriptFont18);

            level7ParagraphProperties3.Append(spaceBefore9);
            level7ParagraphProperties3.Append(bulletColor7);
            level7ParagraphProperties3.Append(bulletSizePercentage7);
            level7ParagraphProperties3.Append(bulletFont7);
            level7ParagraphProperties3.Append(characterBullet7);
            level7ParagraphProperties3.Append(defaultRunProperties32);

            var level8ParagraphProperties3 = new Level8ParagraphProperties
                {
                    LeftMargin = 2398713,
                    Indent = -282575,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var spaceBefore10 = new SpaceBefore();
            var spacingPercent5 = new SpacingPercent {Val = 20000};

            spaceBefore10.Append(spacingPercent5);

            var bulletColor8 = new BulletColor();
            var schemeColor39 = new SchemeColor {Val = SchemeColorValues.Accent2};

            bulletColor8.Append(schemeColor39);
            var bulletSizePercentage8 = new BulletSizePercentage {Val = 110000};
            var bulletFont8 = new BulletFont {Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2};
            var characterBullet8 = new CharacterBullet {Char = "—"};

            var defaultRunProperties33 = new DefaultRunProperties
                {
                    Language = "en-US",
                    FontSize = 1800,
                    Kerning = 1200,
                    Dirty = false
                };
            defaultRunProperties33.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));

            var solidFill31 = new SolidFill();

            var schemeColor40 = new SchemeColor {Val = SchemeColorValues.Text1};
            var luminanceModulation14 = new LuminanceModulation {Val = 65000};
            var luminanceOffset12 = new LuminanceOffset {Val = 35000};

            schemeColor40.Append(luminanceModulation14);
            schemeColor40.Append(luminanceOffset12);

            solidFill31.Append(schemeColor40);
            var latinFont19 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont19 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont19 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties33.Append(solidFill31);
            defaultRunProperties33.Append(latinFont19);
            defaultRunProperties33.Append(eastAsianFont19);
            defaultRunProperties33.Append(complexScriptFont19);

            level8ParagraphProperties3.Append(spaceBefore10);
            level8ParagraphProperties3.Append(bulletColor8);
            level8ParagraphProperties3.Append(bulletSizePercentage8);
            level8ParagraphProperties3.Append(bulletFont8);
            level8ParagraphProperties3.Append(characterBullet8);
            level8ParagraphProperties3.Append(defaultRunProperties33);

            var level9ParagraphProperties3 = new Level9ParagraphProperties
                {
                    LeftMargin = 2689225,
                    Indent = -282575,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var spaceBefore11 = new SpaceBefore();
            var spacingPercent6 = new SpacingPercent {Val = 20000};

            spaceBefore11.Append(spacingPercent6);

            var bulletColor9 = new BulletColor();

            var schemeColor41 = new SchemeColor {Val = SchemeColorValues.Accent1};
            var luminanceModulation15 = new LuminanceModulation {Val = 60000};
            var luminanceOffset13 = new LuminanceOffset {Val = 40000};

            schemeColor41.Append(luminanceModulation15);
            schemeColor41.Append(luminanceOffset13);

            bulletColor9.Append(schemeColor41);
            var bulletSizePercentage9 = new BulletSizePercentage {Val = 110000};
            var bulletFont9 = new BulletFont {Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2};
            var characterBullet9 = new CharacterBullet {Char = "—"};

            var defaultRunProperties34 = new DefaultRunProperties
                {
                    Language = "en-US",
                    FontSize = 1800,
                    Kerning = 1200,
                    Dirty = false
                };

            var solidFill32 = new SolidFill();

            var schemeColor42 = new SchemeColor {Val = SchemeColorValues.Text1};
            var luminanceModulation16 = new LuminanceModulation {Val = 65000};
            var luminanceOffset14 = new LuminanceOffset {Val = 35000};

            schemeColor42.Append(luminanceModulation16);
            schemeColor42.Append(luminanceOffset14);

            solidFill32.Append(schemeColor42);
            var latinFont20 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont20 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont20 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties34.Append(solidFill32);
            defaultRunProperties34.Append(latinFont20);
            defaultRunProperties34.Append(eastAsianFont20);
            defaultRunProperties34.Append(complexScriptFont20);

            level9ParagraphProperties3.Append(spaceBefore11);
            level9ParagraphProperties3.Append(bulletColor9);
            level9ParagraphProperties3.Append(bulletSizePercentage9);
            level9ParagraphProperties3.Append(bulletFont9);
            level9ParagraphProperties3.Append(characterBullet9);
            level9ParagraphProperties3.Append(defaultRunProperties34);

            bodyStyle1.Append(level1ParagraphProperties9);
            bodyStyle1.Append(level2ParagraphProperties3);
            bodyStyle1.Append(level3ParagraphProperties3);
            bodyStyle1.Append(level4ParagraphProperties3);
            bodyStyle1.Append(level5ParagraphProperties3);
            bodyStyle1.Append(level6ParagraphProperties3);
            bodyStyle1.Append(level7ParagraphProperties3);
            bodyStyle1.Append(level8ParagraphProperties3);
            bodyStyle1.Append(level9ParagraphProperties3);

            var otherStyle1 = new OtherStyle();

            var defaultParagraphProperties2 = new DefaultParagraphProperties();
            var defaultRunProperties35 = new DefaultRunProperties();

            defaultParagraphProperties2.Append(defaultRunProperties35);

            var level1ParagraphProperties10 = new Level1ParagraphProperties
                {
                    LeftMargin = 0,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var defaultRunProperties36 = new DefaultRunProperties {FontSize = 1800, Kerning = 1200};

            var solidFill33 = new SolidFill();
            var schemeColor43 = new SchemeColor {Val = SchemeColorValues.Text1};

            solidFill33.Append(schemeColor43);
            var latinFont21 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont21 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont21 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties36.Append(solidFill33);
            defaultRunProperties36.Append(latinFont21);
            defaultRunProperties36.Append(eastAsianFont21);
            defaultRunProperties36.Append(complexScriptFont21);

            level1ParagraphProperties10.Append(defaultRunProperties36);

            var level2ParagraphProperties4 = new Level2ParagraphProperties
                {
                    LeftMargin = 457200,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var defaultRunProperties37 = new DefaultRunProperties {FontSize = 1800, Kerning = 1200};

            var solidFill34 = new SolidFill();
            var schemeColor44 = new SchemeColor {Val = SchemeColorValues.Text1};

            solidFill34.Append(schemeColor44);
            var latinFont22 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont22 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont22 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties37.Append(solidFill34);
            defaultRunProperties37.Append(latinFont22);
            defaultRunProperties37.Append(eastAsianFont22);
            defaultRunProperties37.Append(complexScriptFont22);

            level2ParagraphProperties4.Append(defaultRunProperties37);

            var level3ParagraphProperties4 = new Level3ParagraphProperties
                {
                    LeftMargin = 914400,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var defaultRunProperties38 = new DefaultRunProperties {FontSize = 1800, Kerning = 1200};

            var solidFill35 = new SolidFill();
            var schemeColor45 = new SchemeColor {Val = SchemeColorValues.Text1};

            solidFill35.Append(schemeColor45);
            var latinFont23 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont23 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont23 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties38.Append(solidFill35);
            defaultRunProperties38.Append(latinFont23);
            defaultRunProperties38.Append(eastAsianFont23);
            defaultRunProperties38.Append(complexScriptFont23);

            level3ParagraphProperties4.Append(defaultRunProperties38);

            var level4ParagraphProperties4 = new Level4ParagraphProperties
                {
                    LeftMargin = 1371600,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var defaultRunProperties39 = new DefaultRunProperties {FontSize = 1800, Kerning = 1200};

            var solidFill36 = new SolidFill();
            var schemeColor46 = new SchemeColor {Val = SchemeColorValues.Text1};

            solidFill36.Append(schemeColor46);
            var latinFont24 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont24 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont24 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties39.Append(solidFill36);
            defaultRunProperties39.Append(latinFont24);
            defaultRunProperties39.Append(eastAsianFont24);
            defaultRunProperties39.Append(complexScriptFont24);

            level4ParagraphProperties4.Append(defaultRunProperties39);

            var level5ParagraphProperties4 = new Level5ParagraphProperties
                {
                    LeftMargin = 1828800,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var defaultRunProperties40 = new DefaultRunProperties {FontSize = 1800, Kerning = 1200};

            var solidFill37 = new SolidFill();
            var schemeColor47 = new SchemeColor {Val = SchemeColorValues.Text1};

            solidFill37.Append(schemeColor47);
            var latinFont25 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont25 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont25 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties40.Append(solidFill37);
            defaultRunProperties40.Append(latinFont25);
            defaultRunProperties40.Append(eastAsianFont25);
            defaultRunProperties40.Append(complexScriptFont25);

            level5ParagraphProperties4.Append(defaultRunProperties40);

            var level6ParagraphProperties4 = new Level6ParagraphProperties
                {
                    LeftMargin = 2286000,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var defaultRunProperties41 = new DefaultRunProperties {FontSize = 1800, Kerning = 1200};

            var solidFill38 = new SolidFill();
            var schemeColor48 = new SchemeColor {Val = SchemeColorValues.Text1};

            solidFill38.Append(schemeColor48);
            var latinFont26 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont26 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont26 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties41.Append(solidFill38);
            defaultRunProperties41.Append(latinFont26);
            defaultRunProperties41.Append(eastAsianFont26);
            defaultRunProperties41.Append(complexScriptFont26);

            level6ParagraphProperties4.Append(defaultRunProperties41);

            var level7ParagraphProperties4 = new Level7ParagraphProperties
                {
                    LeftMargin = 2743200,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var defaultRunProperties42 = new DefaultRunProperties {FontSize = 1800, Kerning = 1200};

            var solidFill39 = new SolidFill();
            var schemeColor49 = new SchemeColor {Val = SchemeColorValues.Text1};

            solidFill39.Append(schemeColor49);
            var latinFont27 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont27 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont27 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties42.Append(solidFill39);
            defaultRunProperties42.Append(latinFont27);
            defaultRunProperties42.Append(eastAsianFont27);
            defaultRunProperties42.Append(complexScriptFont27);

            level7ParagraphProperties4.Append(defaultRunProperties42);

            var level8ParagraphProperties4 = new Level8ParagraphProperties
                {
                    LeftMargin = 3200400,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var defaultRunProperties43 = new DefaultRunProperties {FontSize = 1800, Kerning = 1200};

            var solidFill40 = new SolidFill();
            var schemeColor50 = new SchemeColor {Val = SchemeColorValues.Text1};

            solidFill40.Append(schemeColor50);
            var latinFont28 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont28 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont28 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties43.Append(solidFill40);
            defaultRunProperties43.Append(latinFont28);
            defaultRunProperties43.Append(eastAsianFont28);
            defaultRunProperties43.Append(complexScriptFont28);

            level8ParagraphProperties4.Append(defaultRunProperties43);

            var level9ParagraphProperties4 = new Level9ParagraphProperties
                {
                    LeftMargin = 3657600,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var defaultRunProperties44 = new DefaultRunProperties {FontSize = 1800, Kerning = 1200};

            var solidFill41 = new SolidFill();
            var schemeColor51 = new SchemeColor {Val = SchemeColorValues.Text1};

            solidFill41.Append(schemeColor51);
            var latinFont29 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont29 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont29 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties44.Append(solidFill41);
            defaultRunProperties44.Append(latinFont29);
            defaultRunProperties44.Append(eastAsianFont29);
            defaultRunProperties44.Append(complexScriptFont29);

            level9ParagraphProperties4.Append(defaultRunProperties44);

            otherStyle1.Append(defaultParagraphProperties2);
            otherStyle1.Append(level1ParagraphProperties10);
            otherStyle1.Append(level2ParagraphProperties4);
            otherStyle1.Append(level3ParagraphProperties4);
            otherStyle1.Append(level4ParagraphProperties4);
            otherStyle1.Append(level5ParagraphProperties4);
            otherStyle1.Append(level6ParagraphProperties4);
            otherStyle1.Append(level7ParagraphProperties4);
            otherStyle1.Append(level8ParagraphProperties4);
            otherStyle1.Append(level9ParagraphProperties4);

            textStyles1.Append(titleStyle1);
            textStyles1.Append(bodyStyle1);
            textStyles1.Append(otherStyle1);

            slideMaster1.Append(commonSlideData3);
            slideMaster1.Append(colorMap1);
            slideMaster1.Append(slideLayoutIdList1);
            slideMaster1.Append(textStyles1);

            slideMasterPart1.SlideMaster = slideMaster1;
        }

        // Generates content of slideLayoutPart2.
        private void GenerateSlideLayoutPart2Content(SlideLayoutPart slideLayoutPart2)
        {
            var slideLayout2 = new SlideLayout {Type = SlideLayoutValues.VerticalText, Preserve = true};
            slideLayout2.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout2.AddNamespaceDeclaration("r",
                                                 "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout2.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            var commonSlideData4 = new CommonSlideData {Name = "Title and Vertical Text"};

            var shapeTree4 = new ShapeTree();

            var nonVisualGroupShapeProperties4 = new NonVisualGroupShapeProperties();
            var nonVisualDrawingProperties17 = new NonVisualDrawingProperties {Id = 1U, Name = ""};
            var nonVisualGroupShapeDrawingProperties4 = new NonVisualGroupShapeDrawingProperties();
            var applicationNonVisualDrawingProperties17 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties4.Append(nonVisualDrawingProperties17);
            nonVisualGroupShapeProperties4.Append(nonVisualGroupShapeDrawingProperties4);
            nonVisualGroupShapeProperties4.Append(applicationNonVisualDrawingProperties17);

            var groupShapeProperties4 = new GroupShapeProperties();

            var transformGroup4 = new TransformGroup();
            var offset14 = new Offset {X = 0L, Y = 0L};
            var extents14 = new Extents {Cx = 0L, Cy = 0L};
            var childOffset4 = new ChildOffset {X = 0L, Y = 0L};
            var childExtents4 = new ChildExtents {Cx = 0L, Cy = 0L};

            transformGroup4.Append(offset14);
            transformGroup4.Append(extents14);
            transformGroup4.Append(childOffset4);
            transformGroup4.Append(childExtents4);

            groupShapeProperties4.Append(transformGroup4);

            var shape14 = new Shape();

            var nonVisualShapeProperties14 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties18 = new NonVisualDrawingProperties {Id = 2U, Name = "Title 1"};

            var nonVisualShapeDrawingProperties14 = new NonVisualShapeDrawingProperties();
            var shapeLocks13 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties14.Append(shapeLocks13);

            var applicationNonVisualDrawingProperties18 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape12 = new PlaceholderShape {Type = PlaceholderValues.Title};

            applicationNonVisualDrawingProperties18.Append(placeholderShape12);

            nonVisualShapeProperties14.Append(nonVisualDrawingProperties18);
            nonVisualShapeProperties14.Append(nonVisualShapeDrawingProperties14);
            nonVisualShapeProperties14.Append(applicationNonVisualDrawingProperties18);
            var shapeProperties14 = new ShapeProperties();

            var textBody14 = new TextBody();
            var bodyProperties14 = new BodyProperties();
            var listStyle14 = new ListStyle();

            var paragraph18 = new Paragraph();

            var run11 = new Run();

            var runProperties15 = new RunProperties {Language = "en-US"};
            runProperties15.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text15 = new Text();
            text15.Text = "Click to edit Master title style";

            run11.Append(runProperties15);
            run11.Append(text15);
            var endParagraphRunProperties14 = new EndParagraphRunProperties();

            paragraph18.Append(run11);
            paragraph18.Append(endParagraphRunProperties14);

            textBody14.Append(bodyProperties14);
            textBody14.Append(listStyle14);
            textBody14.Append(paragraph18);

            shape14.Append(nonVisualShapeProperties14);
            shape14.Append(shapeProperties14);
            shape14.Append(textBody14);

            var shape15 = new Shape();

            var nonVisualShapeProperties15 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties19 = new NonVisualDrawingProperties
                {
                    Id = 3U,
                    Name = "Vertical Text Placeholder 2"
                };

            var nonVisualShapeDrawingProperties15 = new NonVisualShapeDrawingProperties();
            var shapeLocks14 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties15.Append(shapeLocks14);

            var applicationNonVisualDrawingProperties19 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape13 = new PlaceholderShape
                {
                    Type = PlaceholderValues.Body,
                    Orientation = DirectionValues.Vertical,
                    Index = 1U
                };

            applicationNonVisualDrawingProperties19.Append(placeholderShape13);

            nonVisualShapeProperties15.Append(nonVisualDrawingProperties19);
            nonVisualShapeProperties15.Append(nonVisualShapeDrawingProperties15);
            nonVisualShapeProperties15.Append(applicationNonVisualDrawingProperties19);
            var shapeProperties15 = new ShapeProperties();

            var textBody15 = new TextBody();
            var bodyProperties15 = new BodyProperties {Vertical = TextVerticalValues.EastAsianVetical};

            var listStyle15 = new ListStyle();

            var level5ParagraphProperties5 = new Level5ParagraphProperties();
            var defaultRunProperties45 = new DefaultRunProperties();

            level5ParagraphProperties5.Append(defaultRunProperties45);

            listStyle15.Append(level5ParagraphProperties5);

            var paragraph19 = new Paragraph();
            var paragraphProperties12 = new ParagraphProperties {Level = 0};

            var run12 = new Run();

            var runProperties16 = new RunProperties {Language = "en-US"};
            runProperties16.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text16 = new Text();
            text16.Text = "Click to edit Master text styles";

            run12.Append(runProperties16);
            run12.Append(text16);

            paragraph19.Append(paragraphProperties12);
            paragraph19.Append(run12);

            var paragraph20 = new Paragraph();
            var paragraphProperties13 = new ParagraphProperties {Level = 1};

            var run13 = new Run();

            var runProperties17 = new RunProperties {Language = "en-US"};
            runProperties17.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text17 = new Text();
            text17.Text = "Second level";

            run13.Append(runProperties17);
            run13.Append(text17);

            paragraph20.Append(paragraphProperties13);
            paragraph20.Append(run13);

            var paragraph21 = new Paragraph();
            var paragraphProperties14 = new ParagraphProperties {Level = 2};

            var run14 = new Run();

            var runProperties18 = new RunProperties {Language = "en-US"};
            runProperties18.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text18 = new Text();
            text18.Text = "Third level";

            run14.Append(runProperties18);
            run14.Append(text18);

            paragraph21.Append(paragraphProperties14);
            paragraph21.Append(run14);

            var paragraph22 = new Paragraph();
            var paragraphProperties15 = new ParagraphProperties {Level = 3};

            var run15 = new Run();

            var runProperties19 = new RunProperties {Language = "en-US"};
            runProperties19.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text19 = new Text();
            text19.Text = "Fourth level";

            run15.Append(runProperties19);
            run15.Append(text19);

            paragraph22.Append(paragraphProperties15);
            paragraph22.Append(run15);

            var paragraph23 = new Paragraph();
            var paragraphProperties16 = new ParagraphProperties {Level = 4};

            var run16 = new Run();

            var runProperties20 = new RunProperties {Language = "en-US"};
            runProperties20.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text20 = new Text();
            text20.Text = "Fifth level";

            run16.Append(runProperties20);
            run16.Append(text20);
            var endParagraphRunProperties15 = new EndParagraphRunProperties {Dirty = false};

            paragraph23.Append(paragraphProperties16);
            paragraph23.Append(run16);
            paragraph23.Append(endParagraphRunProperties15);

            textBody15.Append(bodyProperties15);
            textBody15.Append(listStyle15);
            textBody15.Append(paragraph19);
            textBody15.Append(paragraph20);
            textBody15.Append(paragraph21);
            textBody15.Append(paragraph22);
            textBody15.Append(paragraph23);

            shape15.Append(nonVisualShapeProperties15);
            shape15.Append(shapeProperties15);
            shape15.Append(textBody15);

            var shape16 = new Shape();

            var nonVisualShapeProperties16 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties20 = new NonVisualDrawingProperties {Id = 4U, Name = "Date Placeholder 3"};

            var nonVisualShapeDrawingProperties16 = new NonVisualShapeDrawingProperties();
            var shapeLocks15 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties16.Append(shapeLocks15);

            var applicationNonVisualDrawingProperties20 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape14 = new PlaceholderShape
                {
                    Type = PlaceholderValues.DateAndTime,
                    Size = PlaceholderSizeValues.Half,
                    Index = 10U
                };

            applicationNonVisualDrawingProperties20.Append(placeholderShape14);

            nonVisualShapeProperties16.Append(nonVisualDrawingProperties20);
            nonVisualShapeProperties16.Append(nonVisualShapeDrawingProperties16);
            nonVisualShapeProperties16.Append(applicationNonVisualDrawingProperties20);
            var shapeProperties16 = new ShapeProperties();

            var textBody16 = new TextBody();
            var bodyProperties16 = new BodyProperties();
            var listStyle16 = new ListStyle();

            var paragraph24 = new Paragraph();

            var field5 = new Field {Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut"};

            var runProperties21 = new RunProperties {Language = "en-US"};
            runProperties21.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties17 = new ParagraphProperties();
            var text21 = new Text();
            text21.Text = "29/11/13";

            field5.Append(runProperties21);
            field5.Append(paragraphProperties17);
            field5.Append(text21);
            var endParagraphRunProperties16 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph24.Append(field5);
            paragraph24.Append(endParagraphRunProperties16);

            textBody16.Append(bodyProperties16);
            textBody16.Append(listStyle16);
            textBody16.Append(paragraph24);

            shape16.Append(nonVisualShapeProperties16);
            shape16.Append(shapeProperties16);
            shape16.Append(textBody16);

            var shape17 = new Shape();

            var nonVisualShapeProperties17 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties21 = new NonVisualDrawingProperties {Id = 5U, Name = "Footer Placeholder 4"};

            var nonVisualShapeDrawingProperties17 = new NonVisualShapeDrawingProperties();
            var shapeLocks16 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties17.Append(shapeLocks16);

            var applicationNonVisualDrawingProperties21 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape15 = new PlaceholderShape
                {
                    Type = PlaceholderValues.Footer,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 11U
                };

            applicationNonVisualDrawingProperties21.Append(placeholderShape15);

            nonVisualShapeProperties17.Append(nonVisualDrawingProperties21);
            nonVisualShapeProperties17.Append(nonVisualShapeDrawingProperties17);
            nonVisualShapeProperties17.Append(applicationNonVisualDrawingProperties21);
            var shapeProperties17 = new ShapeProperties();

            var textBody17 = new TextBody();
            var bodyProperties17 = new BodyProperties();
            var listStyle17 = new ListStyle();

            var paragraph25 = new Paragraph();
            var endParagraphRunProperties17 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph25.Append(endParagraphRunProperties17);

            textBody17.Append(bodyProperties17);
            textBody17.Append(listStyle17);
            textBody17.Append(paragraph25);

            shape17.Append(nonVisualShapeProperties17);
            shape17.Append(shapeProperties17);
            shape17.Append(textBody17);

            var shape18 = new Shape();

            var nonVisualShapeProperties18 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties22 = new NonVisualDrawingProperties
                {
                    Id = 6U,
                    Name = "Slide Number Placeholder 5"
                };

            var nonVisualShapeDrawingProperties18 = new NonVisualShapeDrawingProperties();
            var shapeLocks17 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties18.Append(shapeLocks17);

            var applicationNonVisualDrawingProperties22 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape16 = new PlaceholderShape
                {
                    Type = PlaceholderValues.SlideNumber,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 12U
                };

            applicationNonVisualDrawingProperties22.Append(placeholderShape16);

            nonVisualShapeProperties18.Append(nonVisualDrawingProperties22);
            nonVisualShapeProperties18.Append(nonVisualShapeDrawingProperties18);
            nonVisualShapeProperties18.Append(applicationNonVisualDrawingProperties22);
            var shapeProperties18 = new ShapeProperties();

            var textBody18 = new TextBody();
            var bodyProperties18 = new BodyProperties();
            var listStyle18 = new ListStyle();

            var paragraph26 = new Paragraph();

            var field6 = new Field {Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum"};

            var runProperties22 = new RunProperties {Language = "en-US"};
            runProperties22.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties18 = new ParagraphProperties();
            var text22 = new Text();
            text22.Text = "‹#›";

            field6.Append(runProperties22);
            field6.Append(paragraphProperties18);
            field6.Append(text22);
            var endParagraphRunProperties18 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph26.Append(field6);
            paragraph26.Append(endParagraphRunProperties18);

            textBody18.Append(bodyProperties18);
            textBody18.Append(listStyle18);
            textBody18.Append(paragraph26);

            shape18.Append(nonVisualShapeProperties18);
            shape18.Append(shapeProperties18);
            shape18.Append(textBody18);

            shapeTree4.Append(nonVisualGroupShapeProperties4);
            shapeTree4.Append(groupShapeProperties4);
            shapeTree4.Append(shape14);
            shapeTree4.Append(shape15);
            shapeTree4.Append(shape16);
            shapeTree4.Append(shape17);
            shapeTree4.Append(shape18);

            commonSlideData4.Append(shapeTree4);

            var colorMapOverride3 = new ColorMapOverride();
            var masterColorMapping3 = new MasterColorMapping();

            colorMapOverride3.Append(masterColorMapping3);

            slideLayout2.Append(commonSlideData4);
            slideLayout2.Append(colorMapOverride3);

            slideLayoutPart2.SlideLayout = slideLayout2;
        }

        // Generates content of slideLayoutPart3.
        private void GenerateSlideLayoutPart3Content(SlideLayoutPart slideLayoutPart3)
        {
            var slideLayout3 = new SlideLayout {Type = SlideLayoutValues.VerticalTitleAndText, Preserve = true};
            slideLayout3.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout3.AddNamespaceDeclaration("r",
                                                 "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout3.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            var commonSlideData5 = new CommonSlideData {Name = "Vertical Title and Text"};

            var shapeTree5 = new ShapeTree();

            var nonVisualGroupShapeProperties5 = new NonVisualGroupShapeProperties();
            var nonVisualDrawingProperties23 = new NonVisualDrawingProperties {Id = 1U, Name = ""};
            var nonVisualGroupShapeDrawingProperties5 = new NonVisualGroupShapeDrawingProperties();
            var applicationNonVisualDrawingProperties23 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties5.Append(nonVisualDrawingProperties23);
            nonVisualGroupShapeProperties5.Append(nonVisualGroupShapeDrawingProperties5);
            nonVisualGroupShapeProperties5.Append(applicationNonVisualDrawingProperties23);

            var groupShapeProperties5 = new GroupShapeProperties();

            var transformGroup5 = new TransformGroup();
            var offset15 = new Offset {X = 0L, Y = 0L};
            var extents15 = new Extents {Cx = 0L, Cy = 0L};
            var childOffset5 = new ChildOffset {X = 0L, Y = 0L};
            var childExtents5 = new ChildExtents {Cx = 0L, Cy = 0L};

            transformGroup5.Append(offset15);
            transformGroup5.Append(extents15);
            transformGroup5.Append(childOffset5);
            transformGroup5.Append(childExtents5);

            groupShapeProperties5.Append(transformGroup5);

            var shape19 = new Shape();

            var nonVisualShapeProperties19 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties24 = new NonVisualDrawingProperties {Id = 2U, Name = "Vertical Title 1"};

            var nonVisualShapeDrawingProperties19 = new NonVisualShapeDrawingProperties();
            var shapeLocks18 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties19.Append(shapeLocks18);

            var applicationNonVisualDrawingProperties24 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape17 = new PlaceholderShape
                {
                    Type = PlaceholderValues.Title,
                    Orientation = DirectionValues.Vertical
                };

            applicationNonVisualDrawingProperties24.Append(placeholderShape17);

            nonVisualShapeProperties19.Append(nonVisualDrawingProperties24);
            nonVisualShapeProperties19.Append(nonVisualShapeDrawingProperties19);
            nonVisualShapeProperties19.Append(applicationNonVisualDrawingProperties24);

            var shapeProperties19 = new ShapeProperties();

            var transform2D11 = new Transform2D();
            var offset16 = new Offset {X = 7369792L, Y = 368301L};
            var extents16 = new Extents {Cx = 1524000L, Cy = 5575300L};

            transform2D11.Append(offset16);
            transform2D11.Append(extents16);

            shapeProperties19.Append(transform2D11);

            var textBody19 = new TextBody();
            var bodyProperties19 = new BodyProperties {Vertical = TextVerticalValues.EastAsianVetical};
            var listStyle19 = new ListStyle();

            var paragraph27 = new Paragraph();

            var run17 = new Run();

            var runProperties23 = new RunProperties {Language = "en-US"};
            runProperties23.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text23 = new Text();
            text23.Text = "Click to edit Master title style";

            run17.Append(runProperties23);
            run17.Append(text23);
            var endParagraphRunProperties19 = new EndParagraphRunProperties();

            paragraph27.Append(run17);
            paragraph27.Append(endParagraphRunProperties19);

            textBody19.Append(bodyProperties19);
            textBody19.Append(listStyle19);
            textBody19.Append(paragraph27);

            shape19.Append(nonVisualShapeProperties19);
            shape19.Append(shapeProperties19);
            shape19.Append(textBody19);

            var shape20 = new Shape();

            var nonVisualShapeProperties20 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties25 = new NonVisualDrawingProperties
                {
                    Id = 3U,
                    Name = "Vertical Text Placeholder 2"
                };

            var nonVisualShapeDrawingProperties20 = new NonVisualShapeDrawingProperties();
            var shapeLocks19 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties20.Append(shapeLocks19);

            var applicationNonVisualDrawingProperties25 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape18 = new PlaceholderShape
                {
                    Type = PlaceholderValues.Body,
                    Orientation = DirectionValues.Vertical,
                    Index = 1U
                };

            applicationNonVisualDrawingProperties25.Append(placeholderShape18);

            nonVisualShapeProperties20.Append(nonVisualDrawingProperties25);
            nonVisualShapeProperties20.Append(nonVisualShapeDrawingProperties20);
            nonVisualShapeProperties20.Append(applicationNonVisualDrawingProperties25);

            var shapeProperties20 = new ShapeProperties();

            var transform2D12 = new Transform2D();
            var offset17 = new Offset {X = 549274L, Y = 368301L};
            var extents17 = new Extents {Cx = 6689726L, Cy = 5575300L};

            transform2D12.Append(offset17);
            transform2D12.Append(extents17);

            shapeProperties20.Append(transform2D12);

            var textBody20 = new TextBody();
            var bodyProperties20 = new BodyProperties {Vertical = TextVerticalValues.EastAsianVetical};

            var listStyle20 = new ListStyle();

            var level5ParagraphProperties6 = new Level5ParagraphProperties();
            var defaultRunProperties46 = new DefaultRunProperties();

            level5ParagraphProperties6.Append(defaultRunProperties46);

            listStyle20.Append(level5ParagraphProperties6);

            var paragraph28 = new Paragraph();
            var paragraphProperties19 = new ParagraphProperties {Level = 0};

            var run18 = new Run();

            var runProperties24 = new RunProperties {Language = "en-US"};
            runProperties24.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text24 = new Text();
            text24.Text = "Click to edit Master text styles";

            run18.Append(runProperties24);
            run18.Append(text24);

            paragraph28.Append(paragraphProperties19);
            paragraph28.Append(run18);

            var paragraph29 = new Paragraph();
            var paragraphProperties20 = new ParagraphProperties {Level = 1};

            var run19 = new Run();

            var runProperties25 = new RunProperties {Language = "en-US"};
            runProperties25.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text25 = new Text();
            text25.Text = "Second level";

            run19.Append(runProperties25);
            run19.Append(text25);

            paragraph29.Append(paragraphProperties20);
            paragraph29.Append(run19);

            var paragraph30 = new Paragraph();
            var paragraphProperties21 = new ParagraphProperties {Level = 2};

            var run20 = new Run();

            var runProperties26 = new RunProperties {Language = "en-US"};
            runProperties26.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text26 = new Text();
            text26.Text = "Third level";

            run20.Append(runProperties26);
            run20.Append(text26);

            paragraph30.Append(paragraphProperties21);
            paragraph30.Append(run20);

            var paragraph31 = new Paragraph();
            var paragraphProperties22 = new ParagraphProperties {Level = 3};

            var run21 = new Run();

            var runProperties27 = new RunProperties {Language = "en-US"};
            runProperties27.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text27 = new Text();
            text27.Text = "Fourth level";

            run21.Append(runProperties27);
            run21.Append(text27);

            paragraph31.Append(paragraphProperties22);
            paragraph31.Append(run21);

            var paragraph32 = new Paragraph();
            var paragraphProperties23 = new ParagraphProperties {Level = 4};

            var run22 = new Run();

            var runProperties28 = new RunProperties {Language = "en-US"};
            runProperties28.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text28 = new Text();
            text28.Text = "Fifth level";

            run22.Append(runProperties28);
            run22.Append(text28);
            var endParagraphRunProperties20 = new EndParagraphRunProperties {Dirty = false};

            paragraph32.Append(paragraphProperties23);
            paragraph32.Append(run22);
            paragraph32.Append(endParagraphRunProperties20);

            textBody20.Append(bodyProperties20);
            textBody20.Append(listStyle20);
            textBody20.Append(paragraph28);
            textBody20.Append(paragraph29);
            textBody20.Append(paragraph30);
            textBody20.Append(paragraph31);
            textBody20.Append(paragraph32);

            shape20.Append(nonVisualShapeProperties20);
            shape20.Append(shapeProperties20);
            shape20.Append(textBody20);

            var shape21 = new Shape();

            var nonVisualShapeProperties21 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties26 = new NonVisualDrawingProperties {Id = 4U, Name = "Date Placeholder 3"};

            var nonVisualShapeDrawingProperties21 = new NonVisualShapeDrawingProperties();
            var shapeLocks20 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties21.Append(shapeLocks20);

            var applicationNonVisualDrawingProperties26 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape19 = new PlaceholderShape
                {
                    Type = PlaceholderValues.DateAndTime,
                    Size = PlaceholderSizeValues.Half,
                    Index = 10U
                };

            applicationNonVisualDrawingProperties26.Append(placeholderShape19);

            nonVisualShapeProperties21.Append(nonVisualDrawingProperties26);
            nonVisualShapeProperties21.Append(nonVisualShapeDrawingProperties21);
            nonVisualShapeProperties21.Append(applicationNonVisualDrawingProperties26);
            var shapeProperties21 = new ShapeProperties();

            var textBody21 = new TextBody();
            var bodyProperties21 = new BodyProperties();
            var listStyle21 = new ListStyle();

            var paragraph33 = new Paragraph();

            var field7 = new Field {Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut"};

            var runProperties29 = new RunProperties {Language = "en-US"};
            runProperties29.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties24 = new ParagraphProperties();
            var text29 = new Text();
            text29.Text = "29/11/13";

            field7.Append(runProperties29);
            field7.Append(paragraphProperties24);
            field7.Append(text29);
            var endParagraphRunProperties21 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph33.Append(field7);
            paragraph33.Append(endParagraphRunProperties21);

            textBody21.Append(bodyProperties21);
            textBody21.Append(listStyle21);
            textBody21.Append(paragraph33);

            shape21.Append(nonVisualShapeProperties21);
            shape21.Append(shapeProperties21);
            shape21.Append(textBody21);

            var shape22 = new Shape();

            var nonVisualShapeProperties22 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties27 = new NonVisualDrawingProperties {Id = 5U, Name = "Footer Placeholder 4"};

            var nonVisualShapeDrawingProperties22 = new NonVisualShapeDrawingProperties();
            var shapeLocks21 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties22.Append(shapeLocks21);

            var applicationNonVisualDrawingProperties27 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape20 = new PlaceholderShape
                {
                    Type = PlaceholderValues.Footer,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 11U
                };

            applicationNonVisualDrawingProperties27.Append(placeholderShape20);

            nonVisualShapeProperties22.Append(nonVisualDrawingProperties27);
            nonVisualShapeProperties22.Append(nonVisualShapeDrawingProperties22);
            nonVisualShapeProperties22.Append(applicationNonVisualDrawingProperties27);
            var shapeProperties22 = new ShapeProperties();

            var textBody22 = new TextBody();
            var bodyProperties22 = new BodyProperties();
            var listStyle22 = new ListStyle();

            var paragraph34 = new Paragraph();
            var endParagraphRunProperties22 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph34.Append(endParagraphRunProperties22);

            textBody22.Append(bodyProperties22);
            textBody22.Append(listStyle22);
            textBody22.Append(paragraph34);

            shape22.Append(nonVisualShapeProperties22);
            shape22.Append(shapeProperties22);
            shape22.Append(textBody22);

            var shape23 = new Shape();

            var nonVisualShapeProperties23 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties28 = new NonVisualDrawingProperties
                {
                    Id = 6U,
                    Name = "Slide Number Placeholder 5"
                };

            var nonVisualShapeDrawingProperties23 = new NonVisualShapeDrawingProperties();
            var shapeLocks22 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties23.Append(shapeLocks22);

            var applicationNonVisualDrawingProperties28 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape21 = new PlaceholderShape
                {
                    Type = PlaceholderValues.SlideNumber,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 12U
                };

            applicationNonVisualDrawingProperties28.Append(placeholderShape21);

            nonVisualShapeProperties23.Append(nonVisualDrawingProperties28);
            nonVisualShapeProperties23.Append(nonVisualShapeDrawingProperties23);
            nonVisualShapeProperties23.Append(applicationNonVisualDrawingProperties28);
            var shapeProperties23 = new ShapeProperties();

            var textBody23 = new TextBody();
            var bodyProperties23 = new BodyProperties();
            var listStyle23 = new ListStyle();

            var paragraph35 = new Paragraph();

            var field8 = new Field {Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum"};

            var runProperties30 = new RunProperties {Language = "en-US"};
            runProperties30.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties25 = new ParagraphProperties();
            var text30 = new Text();
            text30.Text = "‹#›";

            field8.Append(runProperties30);
            field8.Append(paragraphProperties25);
            field8.Append(text30);
            var endParagraphRunProperties23 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph35.Append(field8);
            paragraph35.Append(endParagraphRunProperties23);

            textBody23.Append(bodyProperties23);
            textBody23.Append(listStyle23);
            textBody23.Append(paragraph35);

            shape23.Append(nonVisualShapeProperties23);
            shape23.Append(shapeProperties23);
            shape23.Append(textBody23);

            shapeTree5.Append(nonVisualGroupShapeProperties5);
            shapeTree5.Append(groupShapeProperties5);
            shapeTree5.Append(shape19);
            shapeTree5.Append(shape20);
            shapeTree5.Append(shape21);
            shapeTree5.Append(shape22);
            shapeTree5.Append(shape23);

            commonSlideData5.Append(shapeTree5);

            var colorMapOverride4 = new ColorMapOverride();
            var masterColorMapping4 = new MasterColorMapping();

            colorMapOverride4.Append(masterColorMapping4);

            slideLayout3.Append(commonSlideData5);
            slideLayout3.Append(colorMapOverride4);

            slideLayoutPart3.SlideLayout = slideLayout3;
        }

        // Generates content of themePart1.
        private void GenerateThemePart1Content(ThemePart themePart1)
        {
            var theme1 = new Theme {Name = "Breeze"};
            theme1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            var themeElements1 = new ThemeElements();

            var colorScheme1 = new ColorScheme {Name = "Breeze"};

            var dark1Color1 = new Dark1Color();
            var systemColor1 = new SystemColor {Val = SystemColorValues.WindowText, LastColor = "000000"};

            dark1Color1.Append(systemColor1);

            var light1Color1 = new Light1Color();
            var systemColor2 = new SystemColor {Val = SystemColorValues.Window, LastColor = "FFFFFF"};

            light1Color1.Append(systemColor2);

            var dark2Color1 = new Dark2Color();
            var rgbColorModelHex1 = new RgbColorModelHex {Val = "09213B"};

            dark2Color1.Append(rgbColorModelHex1);

            var light2Color1 = new Light2Color();
            var rgbColorModelHex2 = new RgbColorModelHex {Val = "D5EDF4"};

            light2Color1.Append(rgbColorModelHex2);

            var accent1Color1 = new Accent1Color();
            var rgbColorModelHex3 = new RgbColorModelHex {Val = "2C7C9F"};

            accent1Color1.Append(rgbColorModelHex3);

            var accent2Color1 = new Accent2Color();
            var rgbColorModelHex4 = new RgbColorModelHex {Val = "244A58"};

            accent2Color1.Append(rgbColorModelHex4);

            var accent3Color1 = new Accent3Color();
            var rgbColorModelHex5 = new RgbColorModelHex {Val = "E2751D"};

            accent3Color1.Append(rgbColorModelHex5);

            var accent4Color1 = new Accent4Color();
            var rgbColorModelHex6 = new RgbColorModelHex {Val = "FFB400"};

            accent4Color1.Append(rgbColorModelHex6);

            var accent5Color1 = new Accent5Color();
            var rgbColorModelHex7 = new RgbColorModelHex {Val = "7EB606"};

            accent5Color1.Append(rgbColorModelHex7);

            var accent6Color1 = new Accent6Color();
            var rgbColorModelHex8 = new RgbColorModelHex {Val = "C00000"};

            accent6Color1.Append(rgbColorModelHex8);

            var hyperlink1 = new Hyperlink();
            var rgbColorModelHex9 = new RgbColorModelHex {Val = "7030A0"};

            hyperlink1.Append(rgbColorModelHex9);

            var followedHyperlinkColor1 = new FollowedHyperlinkColor();
            var rgbColorModelHex10 = new RgbColorModelHex {Val = "00B0F0"};

            followedHyperlinkColor1.Append(rgbColorModelHex10);

            colorScheme1.Append(dark1Color1);
            colorScheme1.Append(light1Color1);
            colorScheme1.Append(dark2Color1);
            colorScheme1.Append(light2Color1);
            colorScheme1.Append(accent1Color1);
            colorScheme1.Append(accent2Color1);
            colorScheme1.Append(accent3Color1);
            colorScheme1.Append(accent4Color1);
            colorScheme1.Append(accent5Color1);
            colorScheme1.Append(accent6Color1);
            colorScheme1.Append(hyperlink1);
            colorScheme1.Append(followedHyperlinkColor1);

            var fontScheme1 = new FontScheme {Name = "Breeze"};

            var majorFont1 = new MajorFont();
            var latinFont30 = new LatinFont {Typeface = "News Gothic MT"};
            var eastAsianFont30 = new EastAsianFont {Typeface = ""};
            var complexScriptFont30 = new ComplexScriptFont {Typeface = ""};
            var supplementalFont1 = new SupplementalFont {Script = "Jpan", Typeface = "ＭＳ Ｐゴシック"};
            var supplementalFont2 = new SupplementalFont {Script = "Hans", Typeface = "宋体"};
            var supplementalFont3 = new SupplementalFont {Script = "Hant", Typeface = "新細明體"};

            majorFont1.Append(latinFont30);
            majorFont1.Append(eastAsianFont30);
            majorFont1.Append(complexScriptFont30);
            majorFont1.Append(supplementalFont1);
            majorFont1.Append(supplementalFont2);
            majorFont1.Append(supplementalFont3);

            var minorFont1 = new MinorFont();
            var latinFont31 = new LatinFont {Typeface = "News Gothic MT"};
            var eastAsianFont31 = new EastAsianFont {Typeface = ""};
            var complexScriptFont31 = new ComplexScriptFont {Typeface = ""};
            var supplementalFont4 = new SupplementalFont {Script = "Jpan", Typeface = "ＭＳ Ｐゴシック"};
            var supplementalFont5 = new SupplementalFont {Script = "Hans", Typeface = "宋体"};
            var supplementalFont6 = new SupplementalFont {Script = "Hant", Typeface = "新細明體"};

            minorFont1.Append(latinFont31);
            minorFont1.Append(eastAsianFont31);
            minorFont1.Append(complexScriptFont31);
            minorFont1.Append(supplementalFont4);
            minorFont1.Append(supplementalFont5);
            minorFont1.Append(supplementalFont6);

            fontScheme1.Append(majorFont1);
            fontScheme1.Append(minorFont1);

            var formatScheme1 = new FormatScheme {Name = "Breeze"};

            var fillStyleList1 = new FillStyleList();

            var solidFill42 = new SolidFill();
            var schemeColor52 = new SchemeColor {Val = SchemeColorValues.PhColor};

            solidFill42.Append(schemeColor52);

            var gradientFill1 = new GradientFill {RotateWithShape = true};

            var gradientStopList1 = new GradientStopList();

            var gradientStop1 = new GradientStop {Position = 31000};

            var schemeColor53 = new SchemeColor {Val = SchemeColorValues.PhColor};
            var tint10 = new Tint {Val = 100000};
            var shade1 = new Shade {Val = 100000};
            var saturationModulation1 = new SaturationModulation {Val = 120000};

            schemeColor53.Append(tint10);
            schemeColor53.Append(shade1);
            schemeColor53.Append(saturationModulation1);

            gradientStop1.Append(schemeColor53);

            var gradientStop2 = new GradientStop {Position = 100000};

            var schemeColor54 = new SchemeColor {Val = SchemeColorValues.PhColor};
            var tint11 = new Tint {Val = 50000};
            var saturationModulation2 = new SaturationModulation {Val = 150000};

            schemeColor54.Append(tint11);
            schemeColor54.Append(saturationModulation2);

            gradientStop2.Append(schemeColor54);

            gradientStopList1.Append(gradientStop1);
            gradientStopList1.Append(gradientStop2);
            var linearGradientFill1 = new LinearGradientFill {Angle = 5400000, Scaled = true};

            gradientFill1.Append(gradientStopList1);
            gradientFill1.Append(linearGradientFill1);

            var gradientFill2 = new GradientFill {RotateWithShape = true};

            var gradientStopList2 = new GradientStopList();

            var gradientStop3 = new GradientStop {Position = 0};

            var schemeColor55 = new SchemeColor {Val = SchemeColorValues.PhColor};
            var shade2 = new Shade {Val = 100000};
            var saturationModulation3 = new SaturationModulation {Val = 120000};

            schemeColor55.Append(shade2);
            schemeColor55.Append(saturationModulation3);

            gradientStop3.Append(schemeColor55);

            var gradientStop4 = new GradientStop {Position = 69000};

            var schemeColor56 = new SchemeColor {Val = SchemeColorValues.PhColor};
            var tint12 = new Tint {Val = 80000};
            var shade3 = new Shade {Val = 100000};
            var saturationModulation4 = new SaturationModulation {Val = 150000};

            schemeColor56.Append(tint12);
            schemeColor56.Append(shade3);
            schemeColor56.Append(saturationModulation4);

            gradientStop4.Append(schemeColor56);

            var gradientStop5 = new GradientStop {Position = 100000};

            var schemeColor57 = new SchemeColor {Val = SchemeColorValues.PhColor};
            var tint13 = new Tint {Val = 50000};
            var shade4 = new Shade {Val = 100000};
            var saturationModulation5 = new SaturationModulation {Val = 150000};

            schemeColor57.Append(tint13);
            schemeColor57.Append(shade4);
            schemeColor57.Append(saturationModulation5);

            gradientStop5.Append(schemeColor57);

            gradientStopList2.Append(gradientStop3);
            gradientStopList2.Append(gradientStop4);
            gradientStopList2.Append(gradientStop5);

            var pathGradientFill1 = new PathGradientFill {Path = PathShadeValues.Circle};
            var fillToRectangle1 = new FillToRectangle {Left = 100000, Top = 100000, Right = 100000, Bottom = 100000};

            pathGradientFill1.Append(fillToRectangle1);

            gradientFill2.Append(gradientStopList2);
            gradientFill2.Append(pathGradientFill1);

            fillStyleList1.Append(solidFill42);
            fillStyleList1.Append(gradientFill1);
            fillStyleList1.Append(gradientFill2);

            var lineStyleList1 = new LineStyleList();

            var outline1 = new Outline
                {
                    Width = 12700,
                    CapType = LineCapValues.Flat,
                    CompoundLineType = CompoundLineValues.Single,
                    Alignment = PenAlignmentValues.Center
                };

            var solidFill43 = new SolidFill();

            var schemeColor58 = new SchemeColor {Val = SchemeColorValues.PhColor};
            var shade5 = new Shade {Val = 95000};
            var saturationModulation6 = new SaturationModulation {Val = 105000};

            schemeColor58.Append(shade5);
            schemeColor58.Append(saturationModulation6);

            solidFill43.Append(schemeColor58);
            var presetDash1 = new PresetDash {Val = PresetLineDashValues.Solid};

            outline1.Append(solidFill43);
            outline1.Append(presetDash1);

            var outline2 = new Outline
                {
                    Width = 25400,
                    CapType = LineCapValues.Flat,
                    CompoundLineType = CompoundLineValues.Double,
                    Alignment = PenAlignmentValues.Center
                };

            var solidFill44 = new SolidFill();
            var schemeColor59 = new SchemeColor {Val = SchemeColorValues.PhColor};

            solidFill44.Append(schemeColor59);
            var presetDash2 = new PresetDash {Val = PresetLineDashValues.Solid};

            outline2.Append(solidFill44);
            outline2.Append(presetDash2);

            var outline3 = new Outline
                {
                    Width = 31750,
                    CapType = LineCapValues.Flat,
                    CompoundLineType = CompoundLineValues.Double,
                    Alignment = PenAlignmentValues.Center
                };

            var solidFill45 = new SolidFill();
            var schemeColor60 = new SchemeColor {Val = SchemeColorValues.PhColor};

            solidFill45.Append(schemeColor60);
            var presetDash3 = new PresetDash {Val = PresetLineDashValues.Solid};

            outline3.Append(solidFill45);
            outline3.Append(presetDash3);

            lineStyleList1.Append(outline1);
            lineStyleList1.Append(outline2);
            lineStyleList1.Append(outline3);

            var effectStyleList1 = new EffectStyleList();

            var effectStyle1 = new EffectStyle();
            var effectList1 = new EffectList();

            effectStyle1.Append(effectList1);

            var effectStyle2 = new EffectStyle();

            var effectList2 = new EffectList();

            var outerShadow1 = new OuterShadow
                {
                    BlurRadius = 63500L,
                    Distance = 25400L,
                    Direction = 5400000,
                    HorizontalRatio = 101000,
                    VerticalRatio = 101000,
                    RotateWithShape = false
                };

            var rgbColorModelHex11 = new RgbColorModelHex {Val = "000000"};
            var alpha1 = new Alpha {Val = 40000};

            rgbColorModelHex11.Append(alpha1);

            outerShadow1.Append(rgbColorModelHex11);

            effectList2.Append(outerShadow1);

            effectStyle2.Append(effectList2);

            var effectStyle3 = new EffectStyle();

            var effectList3 = new EffectList();

            var innerShadow1 = new InnerShadow {BlurRadius = 127000L, Distance = 25400L, Direction = 13500000};

            var rgbColorModelHex12 = new RgbColorModelHex {Val = "C0C0C0"};
            var alpha2 = new Alpha {Val = 75000};

            rgbColorModelHex12.Append(alpha2);

            innerShadow1.Append(rgbColorModelHex12);

            var outerShadow2 = new OuterShadow
                {
                    BlurRadius = 88900L,
                    Distance = 25400L,
                    Direction = 5400000,
                    HorizontalRatio = 102000,
                    VerticalRatio = 102000,
                    Alignment = RectangleAlignmentValues.Center,
                    RotateWithShape = false
                };

            var rgbColorModelHex13 = new RgbColorModelHex {Val = "C0C0C0"};
            var alpha3 = new Alpha {Val = 40000};

            rgbColorModelHex13.Append(alpha3);

            outerShadow2.Append(rgbColorModelHex13);

            effectList3.Append(innerShadow1);
            effectList3.Append(outerShadow2);

            var scene3DType1 = new Scene3DType();
            var camera1 = new Camera {Preset = PresetCameraValues.PerspectiveLeft, FieldOfView = 300000};

            var lightRig1 = new LightRig {Rig = LightRigValues.Soft, Direction = LightRigDirectionValues.Left};
            var rotation1 = new Rotation {Latitude = 0, Longitude = 0, Revolution = 4200000};

            lightRig1.Append(rotation1);

            scene3DType1.Append(camera1);
            scene3DType1.Append(lightRig1);

            var shape3DType1 = new Shape3DType
                {
                    ExtrusionHeight = 38100L,
                    PresetMaterial = PresetMaterialTypeValues.Powder
                };
            var bevelTop1 = new BevelTop {Width = 50800L, Height = 88900L, Preset = BevelPresetValues.Convex};

            shape3DType1.Append(bevelTop1);

            effectStyle3.Append(effectList3);
            effectStyle3.Append(scene3DType1);
            effectStyle3.Append(shape3DType1);

            effectStyleList1.Append(effectStyle1);
            effectStyleList1.Append(effectStyle2);
            effectStyleList1.Append(effectStyle3);

            var backgroundFillStyleList1 = new BackgroundFillStyleList();

            var solidFill46 = new SolidFill();
            var schemeColor61 = new SchemeColor {Val = SchemeColorValues.PhColor};

            solidFill46.Append(schemeColor61);

            var gradientFill3 = new GradientFill {RotateWithShape = true};

            var gradientStopList3 = new GradientStopList();

            var gradientStop6 = new GradientStop {Position = 0};

            var schemeColor62 = new SchemeColor {Val = SchemeColorValues.PhColor};
            var tint14 = new Tint {Val = 40000};
            var saturationModulation7 = new SaturationModulation {Val = 350000};

            schemeColor62.Append(tint14);
            schemeColor62.Append(saturationModulation7);

            gradientStop6.Append(schemeColor62);

            var gradientStop7 = new GradientStop {Position = 40000};

            var schemeColor63 = new SchemeColor {Val = SchemeColorValues.PhColor};
            var tint15 = new Tint {Val = 45000};
            var shade6 = new Shade {Val = 99000};
            var saturationModulation8 = new SaturationModulation {Val = 350000};

            schemeColor63.Append(tint15);
            schemeColor63.Append(shade6);
            schemeColor63.Append(saturationModulation8);

            gradientStop7.Append(schemeColor63);

            var gradientStop8 = new GradientStop {Position = 100000};

            var schemeColor64 = new SchemeColor {Val = SchemeColorValues.PhColor};
            var shade7 = new Shade {Val = 20000};
            var saturationModulation9 = new SaturationModulation {Val = 255000};

            schemeColor64.Append(shade7);
            schemeColor64.Append(saturationModulation9);

            gradientStop8.Append(schemeColor64);

            gradientStopList3.Append(gradientStop6);
            gradientStopList3.Append(gradientStop7);
            gradientStopList3.Append(gradientStop8);

            var pathGradientFill2 = new PathGradientFill {Path = PathShadeValues.Circle};
            var fillToRectangle2 = new FillToRectangle {Left = 50000, Top = -80000, Right = 50000, Bottom = 180000};

            pathGradientFill2.Append(fillToRectangle2);

            gradientFill3.Append(gradientStopList3);
            gradientFill3.Append(pathGradientFill2);

            var blipFill1 = new BlipFill {RotateWithShape = true};

            var blip1 = new Blip {Embed = "rId1"};
            blip1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");

            var duotone1 = new Duotone();

            var schemeColor65 = new SchemeColor {Val = SchemeColorValues.PhColor};
            var shade8 = new Shade {Val = 40000};
            var saturationModulation10 = new SaturationModulation {Val = 400000};

            schemeColor65.Append(shade8);
            schemeColor65.Append(saturationModulation10);

            var schemeColor66 = new SchemeColor {Val = SchemeColorValues.PhColor};
            var tint16 = new Tint {Val = 10000};
            var saturationModulation11 = new SaturationModulation {Val = 200000};

            schemeColor66.Append(tint16);
            schemeColor66.Append(saturationModulation11);

            duotone1.Append(schemeColor65);
            duotone1.Append(schemeColor66);

            blip1.Append(duotone1);
            var stretch1 = new Stretch();

            blipFill1.Append(blip1);
            blipFill1.Append(stretch1);

            backgroundFillStyleList1.Append(solidFill46);
            backgroundFillStyleList1.Append(gradientFill3);
            backgroundFillStyleList1.Append(blipFill1);

            formatScheme1.Append(fillStyleList1);
            formatScheme1.Append(lineStyleList1);
            formatScheme1.Append(effectStyleList1);
            formatScheme1.Append(backgroundFillStyleList1);

            themeElements1.Append(colorScheme1);
            themeElements1.Append(fontScheme1);
            themeElements1.Append(formatScheme1);

            var objectDefaults1 = new ObjectDefaults();

            var shapeDefault1 = new ShapeDefault();
            var shapeProperties24 = new DocumentFormat.OpenXml.Drawing.ShapeProperties();
            var bodyProperties24 = new BodyProperties
                {
                    RightToLeftColumns = false,
                    Anchor = TextAnchoringTypeValues.Center
                };

            var listStyle24 = new ListStyle();

            var defaultParagraphProperties3 = new DefaultParagraphProperties
                {
                    Alignment = TextAlignmentTypeValues.Center
                };
            var defaultRunProperties47 = new DefaultRunProperties();

            defaultParagraphProperties3.Append(defaultRunProperties47);

            listStyle24.Append(defaultParagraphProperties3);

            var shapeStyle1 = new ShapeStyle();

            var lineReference1 = new LineReference {Index = 1U};
            var schemeColor67 = new SchemeColor {Val = SchemeColorValues.Accent1};

            lineReference1.Append(schemeColor67);

            var fillReference1 = new FillReference {Index = 3U};
            var schemeColor68 = new SchemeColor {Val = SchemeColorValues.Accent1};

            fillReference1.Append(schemeColor68);

            var effectReference1 = new EffectReference {Index = 2U};
            var schemeColor69 = new SchemeColor {Val = SchemeColorValues.Accent1};

            effectReference1.Append(schemeColor69);

            var fontReference1 = new FontReference {Index = FontCollectionIndexValues.Minor};
            var schemeColor70 = new SchemeColor {Val = SchemeColorValues.Light1};

            fontReference1.Append(schemeColor70);

            shapeStyle1.Append(lineReference1);
            shapeStyle1.Append(fillReference1);
            shapeStyle1.Append(effectReference1);
            shapeStyle1.Append(fontReference1);

            shapeDefault1.Append(shapeProperties24);
            shapeDefault1.Append(bodyProperties24);
            shapeDefault1.Append(listStyle24);
            shapeDefault1.Append(shapeStyle1);

            var lineDefault1 = new LineDefault();
            var shapeProperties25 = new DocumentFormat.OpenXml.Drawing.ShapeProperties();
            var bodyProperties25 = new BodyProperties();
            var listStyle25 = new ListStyle();

            var shapeStyle2 = new ShapeStyle();

            var lineReference2 = new LineReference {Index = 2U};
            var schemeColor71 = new SchemeColor {Val = SchemeColorValues.Accent1};

            lineReference2.Append(schemeColor71);

            var fillReference2 = new FillReference {Index = 0U};
            var schemeColor72 = new SchemeColor {Val = SchemeColorValues.Accent1};

            fillReference2.Append(schemeColor72);

            var effectReference2 = new EffectReference {Index = 1U};
            var schemeColor73 = new SchemeColor {Val = SchemeColorValues.Accent1};

            effectReference2.Append(schemeColor73);

            var fontReference2 = new FontReference {Index = FontCollectionIndexValues.Minor};
            var schemeColor74 = new SchemeColor {Val = SchemeColorValues.Text1};

            fontReference2.Append(schemeColor74);

            shapeStyle2.Append(lineReference2);
            shapeStyle2.Append(fillReference2);
            shapeStyle2.Append(effectReference2);
            shapeStyle2.Append(fontReference2);

            lineDefault1.Append(shapeProperties25);
            lineDefault1.Append(bodyProperties25);
            lineDefault1.Append(listStyle25);
            lineDefault1.Append(shapeStyle2);

            objectDefaults1.Append(shapeDefault1);
            objectDefaults1.Append(lineDefault1);
            var extraColorSchemeList1 = new ExtraColorSchemeList();

            theme1.Append(themeElements1);
            theme1.Append(objectDefaults1);
            theme1.Append(extraColorSchemeList1);

            themePart1.Theme = theme1;
        }

        // Generates content of imagePart1.
        private void GenerateImagePart1Content(ImagePart imagePart1)
        {
            Stream data = GetBinaryDataStream(imagePart1Data);
            imagePart1.FeedData(data);
            data.Close();
        }

        // Generates content of slideLayoutPart4.
        private void GenerateSlideLayoutPart4Content(SlideLayoutPart slideLayoutPart4)
        {
            var slideLayout4 = new SlideLayout {Type = SlideLayoutValues.Title, Preserve = true};
            slideLayout4.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout4.AddNamespaceDeclaration("r",
                                                 "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout4.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            var commonSlideData6 = new CommonSlideData {Name = "Title Slide"};

            var shapeTree6 = new ShapeTree();

            var nonVisualGroupShapeProperties6 = new NonVisualGroupShapeProperties();
            var nonVisualDrawingProperties29 = new NonVisualDrawingProperties {Id = 1U, Name = ""};
            var nonVisualGroupShapeDrawingProperties6 = new NonVisualGroupShapeDrawingProperties();
            var applicationNonVisualDrawingProperties29 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties6.Append(nonVisualDrawingProperties29);
            nonVisualGroupShapeProperties6.Append(nonVisualGroupShapeDrawingProperties6);
            nonVisualGroupShapeProperties6.Append(applicationNonVisualDrawingProperties29);

            var groupShapeProperties6 = new GroupShapeProperties();

            var transformGroup6 = new TransformGroup();
            var offset18 = new Offset {X = 0L, Y = 0L};
            var extents18 = new Extents {Cx = 0L, Cy = 0L};
            var childOffset6 = new ChildOffset {X = 0L, Y = 0L};
            var childExtents6 = new ChildExtents {Cx = 0L, Cy = 0L};

            transformGroup6.Append(offset18);
            transformGroup6.Append(extents18);
            transformGroup6.Append(childOffset6);
            transformGroup6.Append(childExtents6);

            groupShapeProperties6.Append(transformGroup6);

            var shape24 = new Shape();

            var nonVisualShapeProperties24 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties30 = new NonVisualDrawingProperties {Id = 7U, Name = "Rectangle 6"};
            var nonVisualShapeDrawingProperties24 = new NonVisualShapeDrawingProperties();
            var applicationNonVisualDrawingProperties30 = new ApplicationNonVisualDrawingProperties();

            nonVisualShapeProperties24.Append(nonVisualDrawingProperties30);
            nonVisualShapeProperties24.Append(nonVisualShapeDrawingProperties24);
            nonVisualShapeProperties24.Append(applicationNonVisualDrawingProperties30);

            var shapeProperties26 = new ShapeProperties();

            var transform2D13 = new Transform2D();
            var offset19 = new Offset {X = 1328166L, Y = 1295400L};
            var extents19 = new Extents {Cx = 6487668L, Cy = 3152887L};

            transform2D13.Append(offset19);
            transform2D13.Append(extents19);

            var presetGeometry8 = new PresetGeometry {Preset = ShapeTypeValues.Rectangle};
            var adjustValueList8 = new AdjustValueList();

            presetGeometry8.Append(adjustValueList8);

            var outline4 = new Outline {Width = 3175};

            var solidFill47 = new SolidFill();
            var schemeColor75 = new SchemeColor {Val = SchemeColorValues.Background1};

            solidFill47.Append(schemeColor75);

            outline4.Append(solidFill47);

            var effectList4 = new EffectList();

            var outerShadow3 = new OuterShadow
                {
                    BlurRadius = 63500L,
                    HorizontalRatio = 100500,
                    VerticalRatio = 100500,
                    Alignment = RectangleAlignmentValues.Center,
                    RotateWithShape = false
                };

            var presetColor1 = new PresetColor {Val = PresetColorValues.Black};
            var alpha4 = new Alpha {Val = 50000};

            presetColor1.Append(alpha4);

            outerShadow3.Append(presetColor1);

            effectList4.Append(outerShadow3);

            shapeProperties26.Append(transform2D13);
            shapeProperties26.Append(presetGeometry8);
            shapeProperties26.Append(outline4);
            shapeProperties26.Append(effectList4);

            var textBody24 = new TextBody();

            var bodyProperties26 = new BodyProperties
                {
                    Vertical = TextVerticalValues.Horizontal,
                    LeftInset = 91440,
                    TopInset = 45720,
                    RightInset = 91440,
                    BottomInset = 45720,
                    RightToLeftColumns = false
                };
            var normalAutoFit2 = new NormalAutoFit();

            bodyProperties26.Append(normalAutoFit2);
            var listStyle26 = new ListStyle();

            var paragraph36 = new Paragraph();

            var paragraphProperties26 = new ParagraphProperties
                {
                    LeftMargin = 0,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var spaceBefore12 = new SpaceBefore();
            var spacingPoints6 = new SpacingPoints {Val = 2000};

            spaceBefore12.Append(spacingPoints6);

            var bulletColor10 = new BulletColor();

            var schemeColor76 = new SchemeColor {Val = SchemeColorValues.Accent1};
            var luminanceModulation17 = new LuminanceModulation {Val = 60000};
            var luminanceOffset15 = new LuminanceOffset {Val = 40000};

            schemeColor76.Append(luminanceModulation17);
            schemeColor76.Append(luminanceOffset15);

            bulletColor10.Append(schemeColor76);
            var bulletSizePercentage10 = new BulletSizePercentage {Val = 110000};
            var bulletFont10 = new BulletFont {Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2};
            var noBullet13 = new NoBullet();

            paragraphProperties26.Append(spaceBefore12);
            paragraphProperties26.Append(bulletColor10);
            paragraphProperties26.Append(bulletSizePercentage10);
            paragraphProperties26.Append(bulletFont10);
            paragraphProperties26.Append(noBullet13);

            var endParagraphRunProperties24 = new EndParagraphRunProperties {FontSize = 3200, Kerning = 1200};

            var solidFill48 = new SolidFill();

            var schemeColor77 = new SchemeColor {Val = SchemeColorValues.Text1};
            var luminanceModulation18 = new LuminanceModulation {Val = 65000};
            var luminanceOffset16 = new LuminanceOffset {Val = 35000};

            schemeColor77.Append(luminanceModulation18);
            schemeColor77.Append(luminanceOffset16);

            solidFill48.Append(schemeColor77);
            var latinFont32 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont32 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont32 = new ComplexScriptFont {Typeface = "+mn-cs"};

            endParagraphRunProperties24.Append(solidFill48);
            endParagraphRunProperties24.Append(latinFont32);
            endParagraphRunProperties24.Append(eastAsianFont32);
            endParagraphRunProperties24.Append(complexScriptFont32);

            paragraph36.Append(paragraphProperties26);
            paragraph36.Append(endParagraphRunProperties24);

            textBody24.Append(bodyProperties26);
            textBody24.Append(listStyle26);
            textBody24.Append(paragraph36);

            shape24.Append(nonVisualShapeProperties24);
            shape24.Append(shapeProperties26);
            shape24.Append(textBody24);

            var shape25 = new Shape();

            var nonVisualShapeProperties25 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties31 = new NonVisualDrawingProperties {Id = 2U, Name = "Title 1"};

            var nonVisualShapeDrawingProperties25 = new NonVisualShapeDrawingProperties();
            var shapeLocks23 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties25.Append(shapeLocks23);

            var applicationNonVisualDrawingProperties31 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape22 = new PlaceholderShape {Type = PlaceholderValues.CenteredTitle};

            applicationNonVisualDrawingProperties31.Append(placeholderShape22);

            nonVisualShapeProperties25.Append(nonVisualDrawingProperties31);
            nonVisualShapeProperties25.Append(nonVisualShapeDrawingProperties25);
            nonVisualShapeProperties25.Append(applicationNonVisualDrawingProperties31);

            var shapeProperties27 = new ShapeProperties();

            var transform2D14 = new Transform2D();
            var offset20 = new Offset {X = 1322921L, Y = 1523999L};
            var extents20 = new Extents {Cx = 6498158L, Cy = 1724867L};

            transform2D14.Append(offset20);
            transform2D14.Append(extents20);

            shapeProperties27.Append(transform2D14);

            var textBody25 = new TextBody();

            var bodyProperties27 = new BodyProperties
                {
                    Vertical = TextVerticalValues.Horizontal,
                    LeftInset = 91440,
                    TopInset = 45720,
                    RightInset = 91440,
                    BottomInset = 45720,
                    RightToLeftColumns = false,
                    Anchor = TextAnchoringTypeValues.Bottom,
                    AnchorCenter = false
                };
            var noAutoFit3 = new NoAutoFit();

            bodyProperties27.Append(noAutoFit3);

            var listStyle27 = new ListStyle();

            var level1ParagraphProperties11 = new Level1ParagraphProperties
                {
                    LeftMargin = 0,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var spaceBefore13 = new SpaceBefore();
            var spacingPercent7 = new SpacingPercent {Val = 0};

            spaceBefore13.Append(spacingPercent7);

            var bulletColor11 = new BulletColor();

            var schemeColor78 = new SchemeColor {Val = SchemeColorValues.Accent1};
            var luminanceModulation19 = new LuminanceModulation {Val = 60000};
            var luminanceOffset17 = new LuminanceOffset {Val = 40000};

            schemeColor78.Append(luminanceModulation19);
            schemeColor78.Append(luminanceOffset17);

            bulletColor11.Append(schemeColor78);
            var bulletSizePercentage11 = new BulletSizePercentage {Val = 110000};
            var bulletFont11 = new BulletFont {Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2};
            var noBullet14 = new NoBullet();

            var defaultRunProperties48 = new DefaultRunProperties {FontSize = 4600, Kerning = 1200};

            var solidFill49 = new SolidFill();
            var schemeColor79 = new SchemeColor {Val = SchemeColorValues.Accent1};

            solidFill49.Append(schemeColor79);
            var latinFont33 = new LatinFont {Typeface = "+mj-lt"};
            var eastAsianFont33 = new EastAsianFont {Typeface = "+mj-ea"};
            var complexScriptFont33 = new ComplexScriptFont {Typeface = "+mj-cs"};

            defaultRunProperties48.Append(solidFill49);
            defaultRunProperties48.Append(latinFont33);
            defaultRunProperties48.Append(eastAsianFont33);
            defaultRunProperties48.Append(complexScriptFont33);

            level1ParagraphProperties11.Append(spaceBefore13);
            level1ParagraphProperties11.Append(bulletColor11);
            level1ParagraphProperties11.Append(bulletSizePercentage11);
            level1ParagraphProperties11.Append(bulletFont11);
            level1ParagraphProperties11.Append(noBullet14);
            level1ParagraphProperties11.Append(defaultRunProperties48);

            listStyle27.Append(level1ParagraphProperties11);

            var paragraph37 = new Paragraph();

            var run23 = new Run();

            var runProperties31 = new RunProperties {Language = "en-US"};
            runProperties31.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text31 = new Text();
            text31.Text = "Click to edit Master title style";

            run23.Append(runProperties31);
            run23.Append(text31);
            var endParagraphRunProperties25 = new EndParagraphRunProperties();

            paragraph37.Append(run23);
            paragraph37.Append(endParagraphRunProperties25);

            textBody25.Append(bodyProperties27);
            textBody25.Append(listStyle27);
            textBody25.Append(paragraph37);

            shape25.Append(nonVisualShapeProperties25);
            shape25.Append(shapeProperties27);
            shape25.Append(textBody25);

            var shape26 = new Shape();

            var nonVisualShapeProperties26 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties32 = new NonVisualDrawingProperties {Id = 3U, Name = "Subtitle 2"};

            var nonVisualShapeDrawingProperties26 = new NonVisualShapeDrawingProperties();
            var shapeLocks24 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties26.Append(shapeLocks24);

            var applicationNonVisualDrawingProperties32 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape23 = new PlaceholderShape {Type = PlaceholderValues.SubTitle, Index = 1U};

            applicationNonVisualDrawingProperties32.Append(placeholderShape23);

            nonVisualShapeProperties26.Append(nonVisualDrawingProperties32);
            nonVisualShapeProperties26.Append(nonVisualShapeDrawingProperties26);
            nonVisualShapeProperties26.Append(applicationNonVisualDrawingProperties32);

            var shapeProperties28 = new ShapeProperties();

            var transform2D15 = new Transform2D();
            var offset21 = new Offset {X = 1322921L, Y = 3299012L};
            var extents21 = new Extents {Cx = 6498159L, Cy = 916641L};

            transform2D15.Append(offset21);
            transform2D15.Append(extents21);

            shapeProperties28.Append(transform2D15);

            var textBody26 = new TextBody();

            var bodyProperties28 = new BodyProperties
                {
                    Vertical = TextVerticalValues.Horizontal,
                    LeftInset = 91440,
                    TopInset = 45720,
                    RightInset = 91440,
                    BottomInset = 45720,
                    RightToLeftColumns = false
                };
            var normalAutoFit3 = new NormalAutoFit();

            bodyProperties28.Append(normalAutoFit3);

            var listStyle28 = new ListStyle();

            var level1ParagraphProperties12 = new Level1ParagraphProperties
                {
                    LeftMargin = 0,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var spaceBefore14 = new SpaceBefore();
            var spacingPoints7 = new SpacingPoints {Val = 300};

            spaceBefore14.Append(spacingPoints7);

            var bulletColor12 = new BulletColor();

            var schemeColor80 = new SchemeColor {Val = SchemeColorValues.Accent1};
            var luminanceModulation20 = new LuminanceModulation {Val = 60000};
            var luminanceOffset18 = new LuminanceOffset {Val = 40000};

            schemeColor80.Append(luminanceModulation20);
            schemeColor80.Append(luminanceOffset18);

            bulletColor12.Append(schemeColor80);
            var bulletSizePercentage12 = new BulletSizePercentage {Val = 110000};
            var bulletFont12 = new BulletFont {Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2};
            var noBullet15 = new NoBullet();

            var defaultRunProperties49 = new DefaultRunProperties {FontSize = 1800, Kerning = 1200};

            var solidFill50 = new SolidFill();

            var schemeColor81 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint17 = new Tint {Val = 75000};

            schemeColor81.Append(tint17);

            solidFill50.Append(schemeColor81);
            var latinFont34 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont34 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont34 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties49.Append(solidFill50);
            defaultRunProperties49.Append(latinFont34);
            defaultRunProperties49.Append(eastAsianFont34);
            defaultRunProperties49.Append(complexScriptFont34);

            level1ParagraphProperties12.Append(spaceBefore14);
            level1ParagraphProperties12.Append(bulletColor12);
            level1ParagraphProperties12.Append(bulletSizePercentage12);
            level1ParagraphProperties12.Append(bulletFont12);
            level1ParagraphProperties12.Append(noBullet15);
            level1ParagraphProperties12.Append(defaultRunProperties49);

            var level2ParagraphProperties5 = new Level2ParagraphProperties
                {
                    LeftMargin = 457200,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet16 = new NoBullet();

            var defaultRunProperties50 = new DefaultRunProperties();

            var solidFill51 = new SolidFill();

            var schemeColor82 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint18 = new Tint {Val = 75000};

            schemeColor82.Append(tint18);

            solidFill51.Append(schemeColor82);

            defaultRunProperties50.Append(solidFill51);

            level2ParagraphProperties5.Append(noBullet16);
            level2ParagraphProperties5.Append(defaultRunProperties50);

            var level3ParagraphProperties5 = new Level3ParagraphProperties
                {
                    LeftMargin = 914400,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet17 = new NoBullet();

            var defaultRunProperties51 = new DefaultRunProperties();

            var solidFill52 = new SolidFill();

            var schemeColor83 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint19 = new Tint {Val = 75000};

            schemeColor83.Append(tint19);

            solidFill52.Append(schemeColor83);

            defaultRunProperties51.Append(solidFill52);

            level3ParagraphProperties5.Append(noBullet17);
            level3ParagraphProperties5.Append(defaultRunProperties51);

            var level4ParagraphProperties5 = new Level4ParagraphProperties
                {
                    LeftMargin = 1371600,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet18 = new NoBullet();

            var defaultRunProperties52 = new DefaultRunProperties();

            var solidFill53 = new SolidFill();

            var schemeColor84 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint20 = new Tint {Val = 75000};

            schemeColor84.Append(tint20);

            solidFill53.Append(schemeColor84);

            defaultRunProperties52.Append(solidFill53);

            level4ParagraphProperties5.Append(noBullet18);
            level4ParagraphProperties5.Append(defaultRunProperties52);

            var level5ParagraphProperties7 = new Level5ParagraphProperties
                {
                    LeftMargin = 1828800,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet19 = new NoBullet();

            var defaultRunProperties53 = new DefaultRunProperties();

            var solidFill54 = new SolidFill();

            var schemeColor85 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint21 = new Tint {Val = 75000};

            schemeColor85.Append(tint21);

            solidFill54.Append(schemeColor85);

            defaultRunProperties53.Append(solidFill54);

            level5ParagraphProperties7.Append(noBullet19);
            level5ParagraphProperties7.Append(defaultRunProperties53);

            var level6ParagraphProperties5 = new Level6ParagraphProperties
                {
                    LeftMargin = 2286000,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet20 = new NoBullet();

            var defaultRunProperties54 = new DefaultRunProperties();

            var solidFill55 = new SolidFill();

            var schemeColor86 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint22 = new Tint {Val = 75000};

            schemeColor86.Append(tint22);

            solidFill55.Append(schemeColor86);

            defaultRunProperties54.Append(solidFill55);

            level6ParagraphProperties5.Append(noBullet20);
            level6ParagraphProperties5.Append(defaultRunProperties54);

            var level7ParagraphProperties5 = new Level7ParagraphProperties
                {
                    LeftMargin = 2743200,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet21 = new NoBullet();

            var defaultRunProperties55 = new DefaultRunProperties();

            var solidFill56 = new SolidFill();

            var schemeColor87 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint23 = new Tint {Val = 75000};

            schemeColor87.Append(tint23);

            solidFill56.Append(schemeColor87);

            defaultRunProperties55.Append(solidFill56);

            level7ParagraphProperties5.Append(noBullet21);
            level7ParagraphProperties5.Append(defaultRunProperties55);

            var level8ParagraphProperties5 = new Level8ParagraphProperties
                {
                    LeftMargin = 3200400,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet22 = new NoBullet();

            var defaultRunProperties56 = new DefaultRunProperties();

            var solidFill57 = new SolidFill();

            var schemeColor88 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint24 = new Tint {Val = 75000};

            schemeColor88.Append(tint24);

            solidFill57.Append(schemeColor88);

            defaultRunProperties56.Append(solidFill57);

            level8ParagraphProperties5.Append(noBullet22);
            level8ParagraphProperties5.Append(defaultRunProperties56);

            var level9ParagraphProperties5 = new Level9ParagraphProperties
                {
                    LeftMargin = 3657600,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet23 = new NoBullet();

            var defaultRunProperties57 = new DefaultRunProperties();

            var solidFill58 = new SolidFill();

            var schemeColor89 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint25 = new Tint {Val = 75000};

            schemeColor89.Append(tint25);

            solidFill58.Append(schemeColor89);

            defaultRunProperties57.Append(solidFill58);

            level9ParagraphProperties5.Append(noBullet23);
            level9ParagraphProperties5.Append(defaultRunProperties57);

            listStyle28.Append(level1ParagraphProperties12);
            listStyle28.Append(level2ParagraphProperties5);
            listStyle28.Append(level3ParagraphProperties5);
            listStyle28.Append(level4ParagraphProperties5);
            listStyle28.Append(level5ParagraphProperties7);
            listStyle28.Append(level6ParagraphProperties5);
            listStyle28.Append(level7ParagraphProperties5);
            listStyle28.Append(level8ParagraphProperties5);
            listStyle28.Append(level9ParagraphProperties5);

            var paragraph38 = new Paragraph();

            var run24 = new Run();

            var runProperties32 = new RunProperties {Language = "en-US"};
            runProperties32.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text32 = new Text();
            text32.Text = "Click to edit Master subtitle style";

            run24.Append(runProperties32);
            run24.Append(text32);
            var endParagraphRunProperties26 = new EndParagraphRunProperties {Dirty = false};

            paragraph38.Append(run24);
            paragraph38.Append(endParagraphRunProperties26);

            textBody26.Append(bodyProperties28);
            textBody26.Append(listStyle28);
            textBody26.Append(paragraph38);

            shape26.Append(nonVisualShapeProperties26);
            shape26.Append(shapeProperties28);
            shape26.Append(textBody26);

            var shape27 = new Shape();

            var nonVisualShapeProperties27 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties33 = new NonVisualDrawingProperties {Id = 4U, Name = "Date Placeholder 3"};

            var nonVisualShapeDrawingProperties27 = new NonVisualShapeDrawingProperties();
            var shapeLocks25 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties27.Append(shapeLocks25);

            var applicationNonVisualDrawingProperties33 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape24 = new PlaceholderShape
                {
                    Type = PlaceholderValues.DateAndTime,
                    Size = PlaceholderSizeValues.Half,
                    Index = 10U
                };

            applicationNonVisualDrawingProperties33.Append(placeholderShape24);

            nonVisualShapeProperties27.Append(nonVisualDrawingProperties33);
            nonVisualShapeProperties27.Append(nonVisualShapeDrawingProperties27);
            nonVisualShapeProperties27.Append(applicationNonVisualDrawingProperties33);
            var shapeProperties29 = new ShapeProperties();

            var textBody27 = new TextBody();
            var bodyProperties29 = new BodyProperties();
            var listStyle29 = new ListStyle();

            var paragraph39 = new Paragraph();

            var field9 = new Field {Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut"};

            var runProperties33 = new RunProperties {Language = "en-US"};
            runProperties33.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties27 = new ParagraphProperties();
            var text33 = new Text();
            text33.Text = "29/11/13";

            field9.Append(runProperties33);
            field9.Append(paragraphProperties27);
            field9.Append(text33);
            var endParagraphRunProperties27 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph39.Append(field9);
            paragraph39.Append(endParagraphRunProperties27);

            textBody27.Append(bodyProperties29);
            textBody27.Append(listStyle29);
            textBody27.Append(paragraph39);

            shape27.Append(nonVisualShapeProperties27);
            shape27.Append(shapeProperties29);
            shape27.Append(textBody27);

            var shape28 = new Shape();

            var nonVisualShapeProperties28 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties34 = new NonVisualDrawingProperties {Id = 5U, Name = "Footer Placeholder 4"};

            var nonVisualShapeDrawingProperties28 = new NonVisualShapeDrawingProperties();
            var shapeLocks26 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties28.Append(shapeLocks26);

            var applicationNonVisualDrawingProperties34 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape25 = new PlaceholderShape
                {
                    Type = PlaceholderValues.Footer,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 11U
                };

            applicationNonVisualDrawingProperties34.Append(placeholderShape25);

            nonVisualShapeProperties28.Append(nonVisualDrawingProperties34);
            nonVisualShapeProperties28.Append(nonVisualShapeDrawingProperties28);
            nonVisualShapeProperties28.Append(applicationNonVisualDrawingProperties34);
            var shapeProperties30 = new ShapeProperties();

            var textBody28 = new TextBody();
            var bodyProperties30 = new BodyProperties();
            var listStyle30 = new ListStyle();

            var paragraph40 = new Paragraph();
            var endParagraphRunProperties28 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph40.Append(endParagraphRunProperties28);

            textBody28.Append(bodyProperties30);
            textBody28.Append(listStyle30);
            textBody28.Append(paragraph40);

            shape28.Append(nonVisualShapeProperties28);
            shape28.Append(shapeProperties30);
            shape28.Append(textBody28);

            var shape29 = new Shape();

            var nonVisualShapeProperties29 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties35 = new NonVisualDrawingProperties
                {
                    Id = 6U,
                    Name = "Slide Number Placeholder 5"
                };

            var nonVisualShapeDrawingProperties29 = new NonVisualShapeDrawingProperties();
            var shapeLocks27 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties29.Append(shapeLocks27);

            var applicationNonVisualDrawingProperties35 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape26 = new PlaceholderShape
                {
                    Type = PlaceholderValues.SlideNumber,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 12U
                };

            applicationNonVisualDrawingProperties35.Append(placeholderShape26);

            nonVisualShapeProperties29.Append(nonVisualDrawingProperties35);
            nonVisualShapeProperties29.Append(nonVisualShapeDrawingProperties29);
            nonVisualShapeProperties29.Append(applicationNonVisualDrawingProperties35);
            var shapeProperties31 = new ShapeProperties();

            var textBody29 = new TextBody();
            var bodyProperties31 = new BodyProperties();
            var listStyle31 = new ListStyle();

            var paragraph41 = new Paragraph();

            var field10 = new Field {Id = "{7F5CE407-6216-4202-80E4-A30DC2F709B2}", Type = "slidenum"};

            var runProperties34 = new RunProperties {Language = "en-US"};
            runProperties34.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text34 = new Text();
            text34.Text = "‹#›";

            field10.Append(runProperties34);
            field10.Append(text34);
            var endParagraphRunProperties29 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph41.Append(field10);
            paragraph41.Append(endParagraphRunProperties29);

            textBody29.Append(bodyProperties31);
            textBody29.Append(listStyle31);
            textBody29.Append(paragraph41);

            shape29.Append(nonVisualShapeProperties29);
            shape29.Append(shapeProperties31);
            shape29.Append(textBody29);

            shapeTree6.Append(nonVisualGroupShapeProperties6);
            shapeTree6.Append(groupShapeProperties6);
            shapeTree6.Append(shape24);
            shapeTree6.Append(shape25);
            shapeTree6.Append(shape26);
            shapeTree6.Append(shape27);
            shapeTree6.Append(shape28);
            shapeTree6.Append(shape29);

            commonSlideData6.Append(shapeTree6);

            var colorMapOverride5 = new ColorMapOverride();
            var masterColorMapping5 = new MasterColorMapping();

            colorMapOverride5.Append(masterColorMapping5);

            slideLayout4.Append(commonSlideData6);
            slideLayout4.Append(colorMapOverride5);

            slideLayoutPart4.SlideLayout = slideLayout4;
        }

        // Generates content of slideLayoutPart5.
        private void GenerateSlideLayoutPart5Content(SlideLayoutPart slideLayoutPart5)
        {
            var slideLayout5 = new SlideLayout {Type = SlideLayoutValues.Object, Preserve = true};
            slideLayout5.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout5.AddNamespaceDeclaration("r",
                                                 "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout5.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            var commonSlideData7 = new CommonSlideData {Name = "Title and Content"};

            var shapeTree7 = new ShapeTree();

            var nonVisualGroupShapeProperties7 = new NonVisualGroupShapeProperties();
            var nonVisualDrawingProperties36 = new NonVisualDrawingProperties {Id = 1U, Name = ""};
            var nonVisualGroupShapeDrawingProperties7 = new NonVisualGroupShapeDrawingProperties();
            var applicationNonVisualDrawingProperties36 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties7.Append(nonVisualDrawingProperties36);
            nonVisualGroupShapeProperties7.Append(nonVisualGroupShapeDrawingProperties7);
            nonVisualGroupShapeProperties7.Append(applicationNonVisualDrawingProperties36);

            var groupShapeProperties7 = new GroupShapeProperties();

            var transformGroup7 = new TransformGroup();
            var offset22 = new Offset {X = 0L, Y = 0L};
            var extents22 = new Extents {Cx = 0L, Cy = 0L};
            var childOffset7 = new ChildOffset {X = 0L, Y = 0L};
            var childExtents7 = new ChildExtents {Cx = 0L, Cy = 0L};

            transformGroup7.Append(offset22);
            transformGroup7.Append(extents22);
            transformGroup7.Append(childOffset7);
            transformGroup7.Append(childExtents7);

            groupShapeProperties7.Append(transformGroup7);

            var shape30 = new Shape();

            var nonVisualShapeProperties30 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties37 = new NonVisualDrawingProperties {Id = 2U, Name = "Title 1"};

            var nonVisualShapeDrawingProperties30 = new NonVisualShapeDrawingProperties();
            var shapeLocks28 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties30.Append(shapeLocks28);

            var applicationNonVisualDrawingProperties37 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape27 = new PlaceholderShape {Type = PlaceholderValues.Title};

            applicationNonVisualDrawingProperties37.Append(placeholderShape27);

            nonVisualShapeProperties30.Append(nonVisualDrawingProperties37);
            nonVisualShapeProperties30.Append(nonVisualShapeDrawingProperties30);
            nonVisualShapeProperties30.Append(applicationNonVisualDrawingProperties37);
            var shapeProperties32 = new ShapeProperties();

            var textBody30 = new TextBody();
            var bodyProperties32 = new BodyProperties();
            var listStyle32 = new ListStyle();

            var paragraph42 = new Paragraph();

            var run25 = new Run();

            var runProperties35 = new RunProperties {Language = "en-US"};
            runProperties35.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text35 = new Text();
            text35.Text = "Click to edit Master title style";

            run25.Append(runProperties35);
            run25.Append(text35);
            var endParagraphRunProperties30 = new EndParagraphRunProperties();

            paragraph42.Append(run25);
            paragraph42.Append(endParagraphRunProperties30);

            textBody30.Append(bodyProperties32);
            textBody30.Append(listStyle32);
            textBody30.Append(paragraph42);

            shape30.Append(nonVisualShapeProperties30);
            shape30.Append(shapeProperties32);
            shape30.Append(textBody30);

            var shape31 = new Shape();

            var nonVisualShapeProperties31 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties38 = new NonVisualDrawingProperties {Id = 3U, Name = "Content Placeholder 2"};

            var nonVisualShapeDrawingProperties31 = new NonVisualShapeDrawingProperties();
            var shapeLocks29 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties31.Append(shapeLocks29);

            var applicationNonVisualDrawingProperties38 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape28 = new PlaceholderShape {Index = 1U};

            applicationNonVisualDrawingProperties38.Append(placeholderShape28);

            nonVisualShapeProperties31.Append(nonVisualDrawingProperties38);
            nonVisualShapeProperties31.Append(nonVisualShapeDrawingProperties31);
            nonVisualShapeProperties31.Append(applicationNonVisualDrawingProperties38);
            var shapeProperties33 = new ShapeProperties();

            var textBody31 = new TextBody();
            var bodyProperties33 = new BodyProperties();

            var listStyle33 = new ListStyle();

            var level5ParagraphProperties8 = new Level5ParagraphProperties();
            var defaultRunProperties58 = new DefaultRunProperties();

            level5ParagraphProperties8.Append(defaultRunProperties58);

            listStyle33.Append(level5ParagraphProperties8);

            var paragraph43 = new Paragraph();
            var paragraphProperties28 = new ParagraphProperties {Level = 0};

            var run26 = new Run();

            var runProperties36 = new RunProperties {Language = "en-US"};
            runProperties36.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text36 = new Text();
            text36.Text = "Click to edit Master text styles";

            run26.Append(runProperties36);
            run26.Append(text36);

            paragraph43.Append(paragraphProperties28);
            paragraph43.Append(run26);

            var paragraph44 = new Paragraph();
            var paragraphProperties29 = new ParagraphProperties {Level = 1};

            var run27 = new Run();

            var runProperties37 = new RunProperties {Language = "en-US"};
            runProperties37.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text37 = new Text();
            text37.Text = "Second level";

            run27.Append(runProperties37);
            run27.Append(text37);

            paragraph44.Append(paragraphProperties29);
            paragraph44.Append(run27);

            var paragraph45 = new Paragraph();
            var paragraphProperties30 = new ParagraphProperties {Level = 2};

            var run28 = new Run();

            var runProperties38 = new RunProperties {Language = "en-US"};
            runProperties38.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text38 = new Text();
            text38.Text = "Third level";

            run28.Append(runProperties38);
            run28.Append(text38);

            paragraph45.Append(paragraphProperties30);
            paragraph45.Append(run28);

            var paragraph46 = new Paragraph();
            var paragraphProperties31 = new ParagraphProperties {Level = 3};

            var run29 = new Run();

            var runProperties39 = new RunProperties {Language = "en-US"};
            runProperties39.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text39 = new Text();
            text39.Text = "Fourth level";

            run29.Append(runProperties39);
            run29.Append(text39);

            paragraph46.Append(paragraphProperties31);
            paragraph46.Append(run29);

            var paragraph47 = new Paragraph();
            var paragraphProperties32 = new ParagraphProperties {Level = 4};

            var run30 = new Run();

            var runProperties40 = new RunProperties {Language = "en-US"};
            runProperties40.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text40 = new Text();
            text40.Text = "Fifth level";

            run30.Append(runProperties40);
            run30.Append(text40);
            var endParagraphRunProperties31 = new EndParagraphRunProperties {Dirty = false};

            paragraph47.Append(paragraphProperties32);
            paragraph47.Append(run30);
            paragraph47.Append(endParagraphRunProperties31);

            textBody31.Append(bodyProperties33);
            textBody31.Append(listStyle33);
            textBody31.Append(paragraph43);
            textBody31.Append(paragraph44);
            textBody31.Append(paragraph45);
            textBody31.Append(paragraph46);
            textBody31.Append(paragraph47);

            shape31.Append(nonVisualShapeProperties31);
            shape31.Append(shapeProperties33);
            shape31.Append(textBody31);

            var shape32 = new Shape();

            var nonVisualShapeProperties32 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties39 = new NonVisualDrawingProperties {Id = 4U, Name = "Date Placeholder 3"};

            var nonVisualShapeDrawingProperties32 = new NonVisualShapeDrawingProperties();
            var shapeLocks30 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties32.Append(shapeLocks30);

            var applicationNonVisualDrawingProperties39 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape29 = new PlaceholderShape
                {
                    Type = PlaceholderValues.DateAndTime,
                    Size = PlaceholderSizeValues.Half,
                    Index = 10U
                };

            applicationNonVisualDrawingProperties39.Append(placeholderShape29);

            nonVisualShapeProperties32.Append(nonVisualDrawingProperties39);
            nonVisualShapeProperties32.Append(nonVisualShapeDrawingProperties32);
            nonVisualShapeProperties32.Append(applicationNonVisualDrawingProperties39);
            var shapeProperties34 = new ShapeProperties();

            var textBody32 = new TextBody();
            var bodyProperties34 = new BodyProperties();
            var listStyle34 = new ListStyle();

            var paragraph48 = new Paragraph();

            var field11 = new Field {Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut"};

            var runProperties41 = new RunProperties {Language = "en-US"};
            runProperties41.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties33 = new ParagraphProperties();
            var text41 = new Text();
            text41.Text = "29/11/13";

            field11.Append(runProperties41);
            field11.Append(paragraphProperties33);
            field11.Append(text41);
            var endParagraphRunProperties32 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph48.Append(field11);
            paragraph48.Append(endParagraphRunProperties32);

            textBody32.Append(bodyProperties34);
            textBody32.Append(listStyle34);
            textBody32.Append(paragraph48);

            shape32.Append(nonVisualShapeProperties32);
            shape32.Append(shapeProperties34);
            shape32.Append(textBody32);

            var shape33 = new Shape();

            var nonVisualShapeProperties33 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties40 = new NonVisualDrawingProperties {Id = 5U, Name = "Footer Placeholder 4"};

            var nonVisualShapeDrawingProperties33 = new NonVisualShapeDrawingProperties();
            var shapeLocks31 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties33.Append(shapeLocks31);

            var applicationNonVisualDrawingProperties40 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape30 = new PlaceholderShape
                {
                    Type = PlaceholderValues.Footer,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 11U
                };

            applicationNonVisualDrawingProperties40.Append(placeholderShape30);

            nonVisualShapeProperties33.Append(nonVisualDrawingProperties40);
            nonVisualShapeProperties33.Append(nonVisualShapeDrawingProperties33);
            nonVisualShapeProperties33.Append(applicationNonVisualDrawingProperties40);
            var shapeProperties35 = new ShapeProperties();

            var textBody33 = new TextBody();
            var bodyProperties35 = new BodyProperties();
            var listStyle35 = new ListStyle();

            var paragraph49 = new Paragraph();
            var endParagraphRunProperties33 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph49.Append(endParagraphRunProperties33);

            textBody33.Append(bodyProperties35);
            textBody33.Append(listStyle35);
            textBody33.Append(paragraph49);

            shape33.Append(nonVisualShapeProperties33);
            shape33.Append(shapeProperties35);
            shape33.Append(textBody33);

            var shape34 = new Shape();

            var nonVisualShapeProperties34 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties41 = new NonVisualDrawingProperties
                {
                    Id = 6U,
                    Name = "Slide Number Placeholder 5"
                };

            var nonVisualShapeDrawingProperties34 = new NonVisualShapeDrawingProperties();
            var shapeLocks32 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties34.Append(shapeLocks32);

            var applicationNonVisualDrawingProperties41 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape31 = new PlaceholderShape
                {
                    Type = PlaceholderValues.SlideNumber,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 12U
                };

            applicationNonVisualDrawingProperties41.Append(placeholderShape31);

            nonVisualShapeProperties34.Append(nonVisualDrawingProperties41);
            nonVisualShapeProperties34.Append(nonVisualShapeDrawingProperties34);
            nonVisualShapeProperties34.Append(applicationNonVisualDrawingProperties41);
            var shapeProperties36 = new ShapeProperties();

            var textBody34 = new TextBody();
            var bodyProperties36 = new BodyProperties();
            var listStyle36 = new ListStyle();

            var paragraph50 = new Paragraph();

            var field12 = new Field {Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum"};

            var runProperties42 = new RunProperties {Language = "en-US"};
            runProperties42.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties34 = new ParagraphProperties();
            var text42 = new Text();
            text42.Text = "‹#›";

            field12.Append(runProperties42);
            field12.Append(paragraphProperties34);
            field12.Append(text42);
            var endParagraphRunProperties34 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph50.Append(field12);
            paragraph50.Append(endParagraphRunProperties34);

            textBody34.Append(bodyProperties36);
            textBody34.Append(listStyle36);
            textBody34.Append(paragraph50);

            shape34.Append(nonVisualShapeProperties34);
            shape34.Append(shapeProperties36);
            shape34.Append(textBody34);

            shapeTree7.Append(nonVisualGroupShapeProperties7);
            shapeTree7.Append(groupShapeProperties7);
            shapeTree7.Append(shape30);
            shapeTree7.Append(shape31);
            shapeTree7.Append(shape32);
            shapeTree7.Append(shape33);
            shapeTree7.Append(shape34);

            commonSlideData7.Append(shapeTree7);

            var colorMapOverride6 = new ColorMapOverride();
            var masterColorMapping6 = new MasterColorMapping();

            colorMapOverride6.Append(masterColorMapping6);

            slideLayout5.Append(commonSlideData7);
            slideLayout5.Append(colorMapOverride6);

            slideLayoutPart5.SlideLayout = slideLayout5;
        }

        // Generates content of slideLayoutPart6.
        private void GenerateSlideLayoutPart6Content(SlideLayoutPart slideLayoutPart6)
        {
            var slideLayout6 = new SlideLayout {Preserve = true};
            slideLayout6.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout6.AddNamespaceDeclaration("r",
                                                 "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout6.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            var commonSlideData8 = new CommonSlideData {Name = "Title Slide with Picture"};

            var shapeTree8 = new ShapeTree();

            var nonVisualGroupShapeProperties8 = new NonVisualGroupShapeProperties();
            var nonVisualDrawingProperties42 = new NonVisualDrawingProperties {Id = 1U, Name = ""};
            var nonVisualGroupShapeDrawingProperties8 = new NonVisualGroupShapeDrawingProperties();
            var applicationNonVisualDrawingProperties42 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties8.Append(nonVisualDrawingProperties42);
            nonVisualGroupShapeProperties8.Append(nonVisualGroupShapeDrawingProperties8);
            nonVisualGroupShapeProperties8.Append(applicationNonVisualDrawingProperties42);

            var groupShapeProperties8 = new GroupShapeProperties();

            var transformGroup8 = new TransformGroup();
            var offset23 = new Offset {X = 0L, Y = 0L};
            var extents23 = new Extents {Cx = 0L, Cy = 0L};
            var childOffset8 = new ChildOffset {X = 0L, Y = 0L};
            var childExtents8 = new ChildExtents {Cx = 0L, Cy = 0L};

            transformGroup8.Append(offset23);
            transformGroup8.Append(extents23);
            transformGroup8.Append(childOffset8);
            transformGroup8.Append(childExtents8);

            groupShapeProperties8.Append(transformGroup8);

            var shape35 = new Shape();

            var nonVisualShapeProperties35 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties43 = new NonVisualDrawingProperties {Id = 2U, Name = "Title 1"};

            var nonVisualShapeDrawingProperties35 = new NonVisualShapeDrawingProperties();
            var shapeLocks33 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties35.Append(shapeLocks33);

            var applicationNonVisualDrawingProperties43 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape32 = new PlaceholderShape {Type = PlaceholderValues.CenteredTitle};

            applicationNonVisualDrawingProperties43.Append(placeholderShape32);

            nonVisualShapeProperties35.Append(nonVisualDrawingProperties43);
            nonVisualShapeProperties35.Append(nonVisualShapeDrawingProperties35);
            nonVisualShapeProperties35.Append(applicationNonVisualDrawingProperties43);

            var shapeProperties37 = new ShapeProperties();

            var transform2D16 = new Transform2D();
            var offset24 = new Offset {X = 363538L, Y = 3352801L};
            var extents24 = new Extents {Cx = 8416925L, Cy = 1470025L};

            transform2D16.Append(offset24);
            transform2D16.Append(extents24);

            shapeProperties37.Append(transform2D16);

            var textBody35 = new TextBody();
            var bodyProperties37 = new BodyProperties();
            var listStyle37 = new ListStyle();

            var paragraph51 = new Paragraph();

            var run31 = new Run();

            var runProperties43 = new RunProperties {Language = "en-US"};
            runProperties43.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text43 = new Text();
            text43.Text = "Click to edit Master title style";

            run31.Append(runProperties43);
            run31.Append(text43);
            var endParagraphRunProperties35 = new EndParagraphRunProperties {Dirty = false};

            paragraph51.Append(run31);
            paragraph51.Append(endParagraphRunProperties35);

            textBody35.Append(bodyProperties37);
            textBody35.Append(listStyle37);
            textBody35.Append(paragraph51);

            shape35.Append(nonVisualShapeProperties35);
            shape35.Append(shapeProperties37);
            shape35.Append(textBody35);

            var shape36 = new Shape();

            var nonVisualShapeProperties36 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties44 = new NonVisualDrawingProperties {Id = 3U, Name = "Subtitle 2"};

            var nonVisualShapeDrawingProperties36 = new NonVisualShapeDrawingProperties();
            var shapeLocks34 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties36.Append(shapeLocks34);

            var applicationNonVisualDrawingProperties44 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape33 = new PlaceholderShape {Type = PlaceholderValues.SubTitle, Index = 1U};

            applicationNonVisualDrawingProperties44.Append(placeholderShape33);

            nonVisualShapeProperties36.Append(nonVisualDrawingProperties44);
            nonVisualShapeProperties36.Append(nonVisualShapeDrawingProperties36);
            nonVisualShapeProperties36.Append(applicationNonVisualDrawingProperties44);

            var shapeProperties38 = new ShapeProperties();

            var transform2D17 = new Transform2D();
            var offset25 = new Offset {X = 363538L, Y = 4771029L};
            var extents25 = new Extents {Cx = 8416925L, Cy = 972671L};

            transform2D17.Append(offset25);
            transform2D17.Append(extents25);

            shapeProperties38.Append(transform2D17);

            var textBody36 = new TextBody();

            var bodyProperties38 = new BodyProperties();
            var normalAutoFit4 = new NormalAutoFit();

            bodyProperties38.Append(normalAutoFit4);

            var listStyle38 = new ListStyle();

            var level1ParagraphProperties13 = new Level1ParagraphProperties
                {
                    LeftMargin = 0,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };

            var spaceBefore15 = new SpaceBefore();
            var spacingPoints8 = new SpacingPoints {Val = 300};

            spaceBefore15.Append(spacingPoints8);
            var noBullet24 = new NoBullet();

            var defaultRunProperties59 = new DefaultRunProperties {FontSize = 1800};

            var solidFill59 = new SolidFill();

            var schemeColor90 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint26 = new Tint {Val = 75000};

            schemeColor90.Append(tint26);

            solidFill59.Append(schemeColor90);

            defaultRunProperties59.Append(solidFill59);

            level1ParagraphProperties13.Append(spaceBefore15);
            level1ParagraphProperties13.Append(noBullet24);
            level1ParagraphProperties13.Append(defaultRunProperties59);

            var level2ParagraphProperties6 = new Level2ParagraphProperties
                {
                    LeftMargin = 457200,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet25 = new NoBullet();

            var defaultRunProperties60 = new DefaultRunProperties();

            var solidFill60 = new SolidFill();

            var schemeColor91 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint27 = new Tint {Val = 75000};

            schemeColor91.Append(tint27);

            solidFill60.Append(schemeColor91);

            defaultRunProperties60.Append(solidFill60);

            level2ParagraphProperties6.Append(noBullet25);
            level2ParagraphProperties6.Append(defaultRunProperties60);

            var level3ParagraphProperties6 = new Level3ParagraphProperties
                {
                    LeftMargin = 914400,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet26 = new NoBullet();

            var defaultRunProperties61 = new DefaultRunProperties();

            var solidFill61 = new SolidFill();

            var schemeColor92 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint28 = new Tint {Val = 75000};

            schemeColor92.Append(tint28);

            solidFill61.Append(schemeColor92);

            defaultRunProperties61.Append(solidFill61);

            level3ParagraphProperties6.Append(noBullet26);
            level3ParagraphProperties6.Append(defaultRunProperties61);

            var level4ParagraphProperties6 = new Level4ParagraphProperties
                {
                    LeftMargin = 1371600,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet27 = new NoBullet();

            var defaultRunProperties62 = new DefaultRunProperties();

            var solidFill62 = new SolidFill();

            var schemeColor93 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint29 = new Tint {Val = 75000};

            schemeColor93.Append(tint29);

            solidFill62.Append(schemeColor93);

            defaultRunProperties62.Append(solidFill62);

            level4ParagraphProperties6.Append(noBullet27);
            level4ParagraphProperties6.Append(defaultRunProperties62);

            var level5ParagraphProperties9 = new Level5ParagraphProperties
                {
                    LeftMargin = 1828800,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet28 = new NoBullet();

            var defaultRunProperties63 = new DefaultRunProperties();

            var solidFill63 = new SolidFill();

            var schemeColor94 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint30 = new Tint {Val = 75000};

            schemeColor94.Append(tint30);

            solidFill63.Append(schemeColor94);

            defaultRunProperties63.Append(solidFill63);

            level5ParagraphProperties9.Append(noBullet28);
            level5ParagraphProperties9.Append(defaultRunProperties63);

            var level6ParagraphProperties6 = new Level6ParagraphProperties
                {
                    LeftMargin = 2286000,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet29 = new NoBullet();

            var defaultRunProperties64 = new DefaultRunProperties();

            var solidFill64 = new SolidFill();

            var schemeColor95 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint31 = new Tint {Val = 75000};

            schemeColor95.Append(tint31);

            solidFill64.Append(schemeColor95);

            defaultRunProperties64.Append(solidFill64);

            level6ParagraphProperties6.Append(noBullet29);
            level6ParagraphProperties6.Append(defaultRunProperties64);

            var level7ParagraphProperties6 = new Level7ParagraphProperties
                {
                    LeftMargin = 2743200,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet30 = new NoBullet();

            var defaultRunProperties65 = new DefaultRunProperties();

            var solidFill65 = new SolidFill();

            var schemeColor96 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint32 = new Tint {Val = 75000};

            schemeColor96.Append(tint32);

            solidFill65.Append(schemeColor96);

            defaultRunProperties65.Append(solidFill65);

            level7ParagraphProperties6.Append(noBullet30);
            level7ParagraphProperties6.Append(defaultRunProperties65);

            var level8ParagraphProperties6 = new Level8ParagraphProperties
                {
                    LeftMargin = 3200400,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet31 = new NoBullet();

            var defaultRunProperties66 = new DefaultRunProperties();

            var solidFill66 = new SolidFill();

            var schemeColor97 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint33 = new Tint {Val = 75000};

            schemeColor97.Append(tint33);

            solidFill66.Append(schemeColor97);

            defaultRunProperties66.Append(solidFill66);

            level8ParagraphProperties6.Append(noBullet31);
            level8ParagraphProperties6.Append(defaultRunProperties66);

            var level9ParagraphProperties6 = new Level9ParagraphProperties
                {
                    LeftMargin = 3657600,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };
            var noBullet32 = new NoBullet();

            var defaultRunProperties67 = new DefaultRunProperties();

            var solidFill67 = new SolidFill();

            var schemeColor98 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint34 = new Tint {Val = 75000};

            schemeColor98.Append(tint34);

            solidFill67.Append(schemeColor98);

            defaultRunProperties67.Append(solidFill67);

            level9ParagraphProperties6.Append(noBullet32);
            level9ParagraphProperties6.Append(defaultRunProperties67);

            listStyle38.Append(level1ParagraphProperties13);
            listStyle38.Append(level2ParagraphProperties6);
            listStyle38.Append(level3ParagraphProperties6);
            listStyle38.Append(level4ParagraphProperties6);
            listStyle38.Append(level5ParagraphProperties9);
            listStyle38.Append(level6ParagraphProperties6);
            listStyle38.Append(level7ParagraphProperties6);
            listStyle38.Append(level8ParagraphProperties6);
            listStyle38.Append(level9ParagraphProperties6);

            var paragraph52 = new Paragraph();

            var run32 = new Run();

            var runProperties44 = new RunProperties {Language = "en-US"};
            runProperties44.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text44 = new Text();
            text44.Text = "Click to edit Master subtitle style";

            run32.Append(runProperties44);
            run32.Append(text44);
            var endParagraphRunProperties36 = new EndParagraphRunProperties {Dirty = false};

            paragraph52.Append(run32);
            paragraph52.Append(endParagraphRunProperties36);

            textBody36.Append(bodyProperties38);
            textBody36.Append(listStyle38);
            textBody36.Append(paragraph52);

            shape36.Append(nonVisualShapeProperties36);
            shape36.Append(shapeProperties38);
            shape36.Append(textBody36);

            var shape37 = new Shape();

            var nonVisualShapeProperties37 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties45 = new NonVisualDrawingProperties {Id = 4U, Name = "Date Placeholder 3"};

            var nonVisualShapeDrawingProperties37 = new NonVisualShapeDrawingProperties();
            var shapeLocks35 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties37.Append(shapeLocks35);

            var applicationNonVisualDrawingProperties45 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape34 = new PlaceholderShape
                {
                    Type = PlaceholderValues.DateAndTime,
                    Size = PlaceholderSizeValues.Half,
                    Index = 10U
                };

            applicationNonVisualDrawingProperties45.Append(placeholderShape34);

            nonVisualShapeProperties37.Append(nonVisualDrawingProperties45);
            nonVisualShapeProperties37.Append(nonVisualShapeDrawingProperties37);
            nonVisualShapeProperties37.Append(applicationNonVisualDrawingProperties45);
            var shapeProperties39 = new ShapeProperties();

            var textBody37 = new TextBody();
            var bodyProperties39 = new BodyProperties();
            var listStyle39 = new ListStyle();

            var paragraph53 = new Paragraph();

            var field13 = new Field {Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut"};

            var runProperties45 = new RunProperties {Language = "en-US"};
            runProperties45.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties35 = new ParagraphProperties();
            var text45 = new Text();
            text45.Text = "29/11/13";

            field13.Append(runProperties45);
            field13.Append(paragraphProperties35);
            field13.Append(text45);
            var endParagraphRunProperties37 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph53.Append(field13);
            paragraph53.Append(endParagraphRunProperties37);

            textBody37.Append(bodyProperties39);
            textBody37.Append(listStyle39);
            textBody37.Append(paragraph53);

            shape37.Append(nonVisualShapeProperties37);
            shape37.Append(shapeProperties39);
            shape37.Append(textBody37);

            var shape38 = new Shape();

            var nonVisualShapeProperties38 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties46 = new NonVisualDrawingProperties {Id = 5U, Name = "Footer Placeholder 4"};

            var nonVisualShapeDrawingProperties38 = new NonVisualShapeDrawingProperties();
            var shapeLocks36 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties38.Append(shapeLocks36);

            var applicationNonVisualDrawingProperties46 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape35 = new PlaceholderShape
                {
                    Type = PlaceholderValues.Footer,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 11U
                };

            applicationNonVisualDrawingProperties46.Append(placeholderShape35);

            nonVisualShapeProperties38.Append(nonVisualDrawingProperties46);
            nonVisualShapeProperties38.Append(nonVisualShapeDrawingProperties38);
            nonVisualShapeProperties38.Append(applicationNonVisualDrawingProperties46);
            var shapeProperties40 = new ShapeProperties();

            var textBody38 = new TextBody();
            var bodyProperties40 = new BodyProperties();
            var listStyle40 = new ListStyle();

            var paragraph54 = new Paragraph();
            var endParagraphRunProperties38 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph54.Append(endParagraphRunProperties38);

            textBody38.Append(bodyProperties40);
            textBody38.Append(listStyle40);
            textBody38.Append(paragraph54);

            shape38.Append(nonVisualShapeProperties38);
            shape38.Append(shapeProperties40);
            shape38.Append(textBody38);

            var shape39 = new Shape();

            var nonVisualShapeProperties39 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties47 = new NonVisualDrawingProperties
                {
                    Id = 6U,
                    Name = "Slide Number Placeholder 5"
                };

            var nonVisualShapeDrawingProperties39 = new NonVisualShapeDrawingProperties();
            var shapeLocks37 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties39.Append(shapeLocks37);

            var applicationNonVisualDrawingProperties47 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape36 = new PlaceholderShape
                {
                    Type = PlaceholderValues.SlideNumber,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 12U
                };

            applicationNonVisualDrawingProperties47.Append(placeholderShape36);

            nonVisualShapeProperties39.Append(nonVisualDrawingProperties47);
            nonVisualShapeProperties39.Append(nonVisualShapeDrawingProperties39);
            nonVisualShapeProperties39.Append(applicationNonVisualDrawingProperties47);
            var shapeProperties41 = new ShapeProperties();

            var textBody39 = new TextBody();
            var bodyProperties41 = new BodyProperties();
            var listStyle41 = new ListStyle();

            var paragraph55 = new Paragraph();

            var field14 = new Field {Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum"};

            var runProperties46 = new RunProperties {Language = "en-US"};
            runProperties46.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties36 = new ParagraphProperties();
            var text46 = new Text();
            text46.Text = "‹#›";

            field14.Append(runProperties46);
            field14.Append(paragraphProperties36);
            field14.Append(text46);
            var endParagraphRunProperties39 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph55.Append(field14);
            paragraph55.Append(endParagraphRunProperties39);

            textBody39.Append(bodyProperties41);
            textBody39.Append(listStyle41);
            textBody39.Append(paragraph55);

            shape39.Append(nonVisualShapeProperties39);
            shape39.Append(shapeProperties41);
            shape39.Append(textBody39);

            var shape40 = new Shape();

            var nonVisualShapeProperties40 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties48 = new NonVisualDrawingProperties {Id = 9U, Name = "Picture Placeholder 2"};

            var nonVisualShapeDrawingProperties40 = new NonVisualShapeDrawingProperties();
            var shapeLocks38 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties40.Append(shapeLocks38);

            var applicationNonVisualDrawingProperties48 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape37 = new PlaceholderShape {Type = PlaceholderValues.Picture, Index = 13U};

            applicationNonVisualDrawingProperties48.Append(placeholderShape37);

            nonVisualShapeProperties40.Append(nonVisualDrawingProperties48);
            nonVisualShapeProperties40.Append(nonVisualShapeDrawingProperties40);
            nonVisualShapeProperties40.Append(applicationNonVisualDrawingProperties48);

            var shapeProperties42 = new ShapeProperties();

            var transform2D18 = new Transform2D();
            var offset26 = new Offset {X = 370980L, Y = 363538L};
            var extents26 = new Extents {Cx = 8402040L, Cy = 2836862L};

            transform2D18.Append(offset26);
            transform2D18.Append(extents26);

            var outline5 = new Outline {Width = 3175};

            var solidFill68 = new SolidFill();
            var schemeColor99 = new SchemeColor {Val = SchemeColorValues.Background1};

            solidFill68.Append(schemeColor99);

            outline5.Append(solidFill68);

            var effectList5 = new EffectList();

            var outerShadow4 = new OuterShadow
                {
                    BlurRadius = 63500L,
                    HorizontalRatio = 100500,
                    VerticalRatio = 100500,
                    Alignment = RectangleAlignmentValues.Center,
                    RotateWithShape = false
                };

            var presetColor2 = new PresetColor {Val = PresetColorValues.Black};
            var alpha5 = new Alpha {Val = 50000};

            presetColor2.Append(alpha5);

            outerShadow4.Append(presetColor2);

            effectList5.Append(outerShadow4);

            shapeProperties42.Append(transform2D18);
            shapeProperties42.Append(outline5);
            shapeProperties42.Append(effectList5);

            var textBody40 = new TextBody();
            var bodyProperties42 = new BodyProperties();

            var listStyle42 = new ListStyle();

            var level1ParagraphProperties14 = new Level1ParagraphProperties {LeftMargin = 0, Indent = 0};
            var noBullet33 = new NoBullet();
            var defaultRunProperties68 = new DefaultRunProperties {FontSize = 3200};

            level1ParagraphProperties14.Append(noBullet33);
            level1ParagraphProperties14.Append(defaultRunProperties68);

            var level2ParagraphProperties7 = new Level2ParagraphProperties {LeftMargin = 457200, Indent = 0};
            var noBullet34 = new NoBullet();
            var defaultRunProperties69 = new DefaultRunProperties {FontSize = 2800};

            level2ParagraphProperties7.Append(noBullet34);
            level2ParagraphProperties7.Append(defaultRunProperties69);

            var level3ParagraphProperties7 = new Level3ParagraphProperties {LeftMargin = 914400, Indent = 0};
            var noBullet35 = new NoBullet();
            var defaultRunProperties70 = new DefaultRunProperties {FontSize = 2400};

            level3ParagraphProperties7.Append(noBullet35);
            level3ParagraphProperties7.Append(defaultRunProperties70);

            var level4ParagraphProperties7 = new Level4ParagraphProperties {LeftMargin = 1371600, Indent = 0};
            var noBullet36 = new NoBullet();
            var defaultRunProperties71 = new DefaultRunProperties {FontSize = 2000};

            level4ParagraphProperties7.Append(noBullet36);
            level4ParagraphProperties7.Append(defaultRunProperties71);

            var level5ParagraphProperties10 = new Level5ParagraphProperties {LeftMargin = 1828800, Indent = 0};
            var noBullet37 = new NoBullet();
            var defaultRunProperties72 = new DefaultRunProperties {FontSize = 2000};

            level5ParagraphProperties10.Append(noBullet37);
            level5ParagraphProperties10.Append(defaultRunProperties72);

            var level6ParagraphProperties7 = new Level6ParagraphProperties {LeftMargin = 2286000, Indent = 0};
            var noBullet38 = new NoBullet();
            var defaultRunProperties73 = new DefaultRunProperties {FontSize = 2000};

            level6ParagraphProperties7.Append(noBullet38);
            level6ParagraphProperties7.Append(defaultRunProperties73);

            var level7ParagraphProperties7 = new Level7ParagraphProperties {LeftMargin = 2743200, Indent = 0};
            var noBullet39 = new NoBullet();
            var defaultRunProperties74 = new DefaultRunProperties {FontSize = 2000};

            level7ParagraphProperties7.Append(noBullet39);
            level7ParagraphProperties7.Append(defaultRunProperties74);

            var level8ParagraphProperties7 = new Level8ParagraphProperties {LeftMargin = 3200400, Indent = 0};
            var noBullet40 = new NoBullet();
            var defaultRunProperties75 = new DefaultRunProperties {FontSize = 2000};

            level8ParagraphProperties7.Append(noBullet40);
            level8ParagraphProperties7.Append(defaultRunProperties75);

            var level9ParagraphProperties7 = new Level9ParagraphProperties {LeftMargin = 3657600, Indent = 0};
            var noBullet41 = new NoBullet();
            var defaultRunProperties76 = new DefaultRunProperties {FontSize = 2000};

            level9ParagraphProperties7.Append(noBullet41);
            level9ParagraphProperties7.Append(defaultRunProperties76);

            listStyle42.Append(level1ParagraphProperties14);
            listStyle42.Append(level2ParagraphProperties7);
            listStyle42.Append(level3ParagraphProperties7);
            listStyle42.Append(level4ParagraphProperties7);
            listStyle42.Append(level5ParagraphProperties10);
            listStyle42.Append(level6ParagraphProperties7);
            listStyle42.Append(level7ParagraphProperties7);
            listStyle42.Append(level8ParagraphProperties7);
            listStyle42.Append(level9ParagraphProperties7);

            var paragraph56 = new Paragraph();

            var run33 = new Run();

            var runProperties47 = new RunProperties {Language = "en-US"};
            runProperties47.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text47 = new Text();
            text47.Text = "Drag picture to placeholder or click icon to add";

            run33.Append(runProperties47);
            run33.Append(text47);
            var endParagraphRunProperties40 = new EndParagraphRunProperties();

            paragraph56.Append(run33);
            paragraph56.Append(endParagraphRunProperties40);

            textBody40.Append(bodyProperties42);
            textBody40.Append(listStyle42);
            textBody40.Append(paragraph56);

            shape40.Append(nonVisualShapeProperties40);
            shape40.Append(shapeProperties42);
            shape40.Append(textBody40);

            shapeTree8.Append(nonVisualGroupShapeProperties8);
            shapeTree8.Append(groupShapeProperties8);
            shapeTree8.Append(shape35);
            shapeTree8.Append(shape36);
            shapeTree8.Append(shape37);
            shapeTree8.Append(shape38);
            shapeTree8.Append(shape39);
            shapeTree8.Append(shape40);

            commonSlideData8.Append(shapeTree8);

            var colorMapOverride7 = new ColorMapOverride();
            var masterColorMapping7 = new MasterColorMapping();

            colorMapOverride7.Append(masterColorMapping7);

            slideLayout6.Append(commonSlideData8);
            slideLayout6.Append(colorMapOverride7);

            slideLayoutPart6.SlideLayout = slideLayout6;
        }

        // Generates content of slideLayoutPart7.
        private void GenerateSlideLayoutPart7Content(SlideLayoutPart slideLayoutPart7)
        {
            var slideLayout7 = new SlideLayout {Type = SlideLayoutValues.SectionHeader, Preserve = true};
            slideLayout7.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout7.AddNamespaceDeclaration("r",
                                                 "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout7.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            var commonSlideData9 = new CommonSlideData {Name = "Section Header"};

            var shapeTree9 = new ShapeTree();

            var nonVisualGroupShapeProperties9 = new NonVisualGroupShapeProperties();
            var nonVisualDrawingProperties49 = new NonVisualDrawingProperties {Id = 1U, Name = ""};
            var nonVisualGroupShapeDrawingProperties9 = new NonVisualGroupShapeDrawingProperties();
            var applicationNonVisualDrawingProperties49 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties9.Append(nonVisualDrawingProperties49);
            nonVisualGroupShapeProperties9.Append(nonVisualGroupShapeDrawingProperties9);
            nonVisualGroupShapeProperties9.Append(applicationNonVisualDrawingProperties49);

            var groupShapeProperties9 = new GroupShapeProperties();

            var transformGroup9 = new TransformGroup();
            var offset27 = new Offset {X = 0L, Y = 0L};
            var extents27 = new Extents {Cx = 0L, Cy = 0L};
            var childOffset9 = new ChildOffset {X = 0L, Y = 0L};
            var childExtents9 = new ChildExtents {Cx = 0L, Cy = 0L};

            transformGroup9.Append(offset27);
            transformGroup9.Append(extents27);
            transformGroup9.Append(childOffset9);
            transformGroup9.Append(childExtents9);

            groupShapeProperties9.Append(transformGroup9);

            var shape41 = new Shape();

            var nonVisualShapeProperties41 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties50 = new NonVisualDrawingProperties {Id = 2U, Name = "Title 1"};

            var nonVisualShapeDrawingProperties41 = new NonVisualShapeDrawingProperties();
            var shapeLocks39 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties41.Append(shapeLocks39);

            var applicationNonVisualDrawingProperties50 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape38 = new PlaceholderShape {Type = PlaceholderValues.Title};

            applicationNonVisualDrawingProperties50.Append(placeholderShape38);

            nonVisualShapeProperties41.Append(nonVisualDrawingProperties50);
            nonVisualShapeProperties41.Append(nonVisualShapeDrawingProperties41);
            nonVisualShapeProperties41.Append(applicationNonVisualDrawingProperties50);

            var shapeProperties43 = new ShapeProperties();

            var transform2D19 = new Transform2D();
            var offset28 = new Offset {X = 549275L, Y = 2403144L};
            var extents28 = new Extents {Cx = 8056563L, Cy = 1362075L};

            transform2D19.Append(offset28);
            transform2D19.Append(extents28);

            shapeProperties43.Append(transform2D19);

            var textBody41 = new TextBody();
            var bodyProperties43 = new BodyProperties {Anchor = TextAnchoringTypeValues.Bottom, AnchorCenter = false};

            var listStyle43 = new ListStyle();

            var level1ParagraphProperties15 = new Level1ParagraphProperties {Alignment = TextAlignmentTypeValues.Center};
            var defaultRunProperties77 = new DefaultRunProperties
                {
                    FontSize = 4600,
                    Bold = false,
                    Capital = TextCapsValues.None,
                    Baseline = 0
                };

            level1ParagraphProperties15.Append(defaultRunProperties77);

            listStyle43.Append(level1ParagraphProperties15);

            var paragraph57 = new Paragraph();

            var run34 = new Run();

            var runProperties48 = new RunProperties {Language = "en-US"};
            runProperties48.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text48 = new Text();
            text48.Text = "Click to edit Master title style";

            run34.Append(runProperties48);
            run34.Append(text48);
            var endParagraphRunProperties41 = new EndParagraphRunProperties();

            paragraph57.Append(run34);
            paragraph57.Append(endParagraphRunProperties41);

            textBody41.Append(bodyProperties43);
            textBody41.Append(listStyle43);
            textBody41.Append(paragraph57);

            shape41.Append(nonVisualShapeProperties41);
            shape41.Append(shapeProperties43);
            shape41.Append(textBody41);

            var shape42 = new Shape();

            var nonVisualShapeProperties42 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties51 = new NonVisualDrawingProperties {Id = 3U, Name = "Text Placeholder 2"};

            var nonVisualShapeDrawingProperties42 = new NonVisualShapeDrawingProperties();
            var shapeLocks40 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties42.Append(shapeLocks40);

            var applicationNonVisualDrawingProperties51 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape39 = new PlaceholderShape {Type = PlaceholderValues.Body, Index = 1U};

            applicationNonVisualDrawingProperties51.Append(placeholderShape39);

            nonVisualShapeProperties42.Append(nonVisualDrawingProperties51);
            nonVisualShapeProperties42.Append(nonVisualShapeDrawingProperties42);
            nonVisualShapeProperties42.Append(applicationNonVisualDrawingProperties51);

            var shapeProperties44 = new ShapeProperties();

            var transform2D20 = new Transform2D();
            var offset29 = new Offset {X = 549275L, Y = 3736005L};
            var extents29 = new Extents {Cx = 8056563L, Cy = 1500187L};

            transform2D20.Append(offset29);
            transform2D20.Append(extents29);

            shapeProperties44.Append(transform2D20);

            var textBody42 = new TextBody();

            var bodyProperties44 = new BodyProperties {Anchor = TextAnchoringTypeValues.Top, AnchorCenter = false};
            var normalAutoFit5 = new NormalAutoFit();

            bodyProperties44.Append(normalAutoFit5);

            var listStyle44 = new ListStyle();

            var level1ParagraphProperties16 = new Level1ParagraphProperties
                {
                    LeftMargin = 0,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };

            var spaceBefore16 = new SpaceBefore();
            var spacingPoints9 = new SpacingPoints {Val = 300};

            spaceBefore16.Append(spacingPoints9);
            var noBullet42 = new NoBullet();

            var defaultRunProperties78 = new DefaultRunProperties {FontSize = 1800};

            var solidFill69 = new SolidFill();

            var schemeColor100 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint35 = new Tint {Val = 75000};

            schemeColor100.Append(tint35);

            solidFill69.Append(schemeColor100);

            defaultRunProperties78.Append(solidFill69);

            level1ParagraphProperties16.Append(spaceBefore16);
            level1ParagraphProperties16.Append(noBullet42);
            level1ParagraphProperties16.Append(defaultRunProperties78);

            var level2ParagraphProperties8 = new Level2ParagraphProperties {LeftMargin = 457200, Indent = 0};
            var noBullet43 = new NoBullet();

            var defaultRunProperties79 = new DefaultRunProperties {FontSize = 1800};

            var solidFill70 = new SolidFill();

            var schemeColor101 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint36 = new Tint {Val = 75000};

            schemeColor101.Append(tint36);

            solidFill70.Append(schemeColor101);

            defaultRunProperties79.Append(solidFill70);

            level2ParagraphProperties8.Append(noBullet43);
            level2ParagraphProperties8.Append(defaultRunProperties79);

            var level3ParagraphProperties8 = new Level3ParagraphProperties {LeftMargin = 914400, Indent = 0};
            var noBullet44 = new NoBullet();

            var defaultRunProperties80 = new DefaultRunProperties {FontSize = 1600};

            var solidFill71 = new SolidFill();

            var schemeColor102 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint37 = new Tint {Val = 75000};

            schemeColor102.Append(tint37);

            solidFill71.Append(schemeColor102);

            defaultRunProperties80.Append(solidFill71);

            level3ParagraphProperties8.Append(noBullet44);
            level3ParagraphProperties8.Append(defaultRunProperties80);

            var level4ParagraphProperties8 = new Level4ParagraphProperties {LeftMargin = 1371600, Indent = 0};
            var noBullet45 = new NoBullet();

            var defaultRunProperties81 = new DefaultRunProperties {FontSize = 1400};

            var solidFill72 = new SolidFill();

            var schemeColor103 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint38 = new Tint {Val = 75000};

            schemeColor103.Append(tint38);

            solidFill72.Append(schemeColor103);

            defaultRunProperties81.Append(solidFill72);

            level4ParagraphProperties8.Append(noBullet45);
            level4ParagraphProperties8.Append(defaultRunProperties81);

            var level5ParagraphProperties11 = new Level5ParagraphProperties {LeftMargin = 1828800, Indent = 0};
            var noBullet46 = new NoBullet();

            var defaultRunProperties82 = new DefaultRunProperties {FontSize = 1400};

            var solidFill73 = new SolidFill();

            var schemeColor104 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint39 = new Tint {Val = 75000};

            schemeColor104.Append(tint39);

            solidFill73.Append(schemeColor104);

            defaultRunProperties82.Append(solidFill73);

            level5ParagraphProperties11.Append(noBullet46);
            level5ParagraphProperties11.Append(defaultRunProperties82);

            var level6ParagraphProperties8 = new Level6ParagraphProperties {LeftMargin = 2286000, Indent = 0};
            var noBullet47 = new NoBullet();

            var defaultRunProperties83 = new DefaultRunProperties {FontSize = 1400};

            var solidFill74 = new SolidFill();

            var schemeColor105 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint40 = new Tint {Val = 75000};

            schemeColor105.Append(tint40);

            solidFill74.Append(schemeColor105);

            defaultRunProperties83.Append(solidFill74);

            level6ParagraphProperties8.Append(noBullet47);
            level6ParagraphProperties8.Append(defaultRunProperties83);

            var level7ParagraphProperties8 = new Level7ParagraphProperties {LeftMargin = 2743200, Indent = 0};
            var noBullet48 = new NoBullet();

            var defaultRunProperties84 = new DefaultRunProperties {FontSize = 1400};

            var solidFill75 = new SolidFill();

            var schemeColor106 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint41 = new Tint {Val = 75000};

            schemeColor106.Append(tint41);

            solidFill75.Append(schemeColor106);

            defaultRunProperties84.Append(solidFill75);

            level7ParagraphProperties8.Append(noBullet48);
            level7ParagraphProperties8.Append(defaultRunProperties84);

            var level8ParagraphProperties8 = new Level8ParagraphProperties {LeftMargin = 3200400, Indent = 0};
            var noBullet49 = new NoBullet();

            var defaultRunProperties85 = new DefaultRunProperties {FontSize = 1400};

            var solidFill76 = new SolidFill();

            var schemeColor107 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint42 = new Tint {Val = 75000};

            schemeColor107.Append(tint42);

            solidFill76.Append(schemeColor107);

            defaultRunProperties85.Append(solidFill76);

            level8ParagraphProperties8.Append(noBullet49);
            level8ParagraphProperties8.Append(defaultRunProperties85);

            var level9ParagraphProperties8 = new Level9ParagraphProperties {LeftMargin = 3657600, Indent = 0};
            var noBullet50 = new NoBullet();

            var defaultRunProperties86 = new DefaultRunProperties {FontSize = 1400};

            var solidFill77 = new SolidFill();

            var schemeColor108 = new SchemeColor {Val = SchemeColorValues.Text1};
            var tint43 = new Tint {Val = 75000};

            schemeColor108.Append(tint43);

            solidFill77.Append(schemeColor108);

            defaultRunProperties86.Append(solidFill77);

            level9ParagraphProperties8.Append(noBullet50);
            level9ParagraphProperties8.Append(defaultRunProperties86);

            listStyle44.Append(level1ParagraphProperties16);
            listStyle44.Append(level2ParagraphProperties8);
            listStyle44.Append(level3ParagraphProperties8);
            listStyle44.Append(level4ParagraphProperties8);
            listStyle44.Append(level5ParagraphProperties11);
            listStyle44.Append(level6ParagraphProperties8);
            listStyle44.Append(level7ParagraphProperties8);
            listStyle44.Append(level8ParagraphProperties8);
            listStyle44.Append(level9ParagraphProperties8);

            var paragraph58 = new Paragraph();
            var paragraphProperties37 = new ParagraphProperties {Level = 0};

            var run35 = new Run();

            var runProperties49 = new RunProperties {Language = "en-US"};
            runProperties49.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text49 = new Text();
            text49.Text = "Click to edit Master text styles";

            run35.Append(runProperties49);
            run35.Append(text49);

            paragraph58.Append(paragraphProperties37);
            paragraph58.Append(run35);

            textBody42.Append(bodyProperties44);
            textBody42.Append(listStyle44);
            textBody42.Append(paragraph58);

            shape42.Append(nonVisualShapeProperties42);
            shape42.Append(shapeProperties44);
            shape42.Append(textBody42);

            var shape43 = new Shape();

            var nonVisualShapeProperties43 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties52 = new NonVisualDrawingProperties {Id = 4U, Name = "Date Placeholder 3"};

            var nonVisualShapeDrawingProperties43 = new NonVisualShapeDrawingProperties();
            var shapeLocks41 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties43.Append(shapeLocks41);

            var applicationNonVisualDrawingProperties52 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape40 = new PlaceholderShape
                {
                    Type = PlaceholderValues.DateAndTime,
                    Size = PlaceholderSizeValues.Half,
                    Index = 10U
                };

            applicationNonVisualDrawingProperties52.Append(placeholderShape40);

            nonVisualShapeProperties43.Append(nonVisualDrawingProperties52);
            nonVisualShapeProperties43.Append(nonVisualShapeDrawingProperties43);
            nonVisualShapeProperties43.Append(applicationNonVisualDrawingProperties52);
            var shapeProperties45 = new ShapeProperties();

            var textBody43 = new TextBody();
            var bodyProperties45 = new BodyProperties();
            var listStyle45 = new ListStyle();

            var paragraph59 = new Paragraph();

            var field15 = new Field {Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut"};

            var runProperties50 = new RunProperties {Language = "en-US"};
            runProperties50.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties38 = new ParagraphProperties();
            var text50 = new Text();
            text50.Text = "29/11/13";

            field15.Append(runProperties50);
            field15.Append(paragraphProperties38);
            field15.Append(text50);
            var endParagraphRunProperties42 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph59.Append(field15);
            paragraph59.Append(endParagraphRunProperties42);

            textBody43.Append(bodyProperties45);
            textBody43.Append(listStyle45);
            textBody43.Append(paragraph59);

            shape43.Append(nonVisualShapeProperties43);
            shape43.Append(shapeProperties45);
            shape43.Append(textBody43);

            var shape44 = new Shape();

            var nonVisualShapeProperties44 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties53 = new NonVisualDrawingProperties {Id = 5U, Name = "Footer Placeholder 4"};

            var nonVisualShapeDrawingProperties44 = new NonVisualShapeDrawingProperties();
            var shapeLocks42 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties44.Append(shapeLocks42);

            var applicationNonVisualDrawingProperties53 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape41 = new PlaceholderShape
                {
                    Type = PlaceholderValues.Footer,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 11U
                };

            applicationNonVisualDrawingProperties53.Append(placeholderShape41);

            nonVisualShapeProperties44.Append(nonVisualDrawingProperties53);
            nonVisualShapeProperties44.Append(nonVisualShapeDrawingProperties44);
            nonVisualShapeProperties44.Append(applicationNonVisualDrawingProperties53);
            var shapeProperties46 = new ShapeProperties();

            var textBody44 = new TextBody();
            var bodyProperties46 = new BodyProperties();
            var listStyle46 = new ListStyle();

            var paragraph60 = new Paragraph();
            var endParagraphRunProperties43 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph60.Append(endParagraphRunProperties43);

            textBody44.Append(bodyProperties46);
            textBody44.Append(listStyle46);
            textBody44.Append(paragraph60);

            shape44.Append(nonVisualShapeProperties44);
            shape44.Append(shapeProperties46);
            shape44.Append(textBody44);

            var shape45 = new Shape();

            var nonVisualShapeProperties45 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties54 = new NonVisualDrawingProperties
                {
                    Id = 6U,
                    Name = "Slide Number Placeholder 5"
                };

            var nonVisualShapeDrawingProperties45 = new NonVisualShapeDrawingProperties();
            var shapeLocks43 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties45.Append(shapeLocks43);

            var applicationNonVisualDrawingProperties54 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape42 = new PlaceholderShape
                {
                    Type = PlaceholderValues.SlideNumber,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 12U
                };

            applicationNonVisualDrawingProperties54.Append(placeholderShape42);

            nonVisualShapeProperties45.Append(nonVisualDrawingProperties54);
            nonVisualShapeProperties45.Append(nonVisualShapeDrawingProperties45);
            nonVisualShapeProperties45.Append(applicationNonVisualDrawingProperties54);
            var shapeProperties47 = new ShapeProperties();

            var textBody45 = new TextBody();
            var bodyProperties47 = new BodyProperties();
            var listStyle47 = new ListStyle();

            var paragraph61 = new Paragraph();

            var field16 = new Field {Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum"};

            var runProperties51 = new RunProperties {Language = "en-US"};
            runProperties51.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties39 = new ParagraphProperties();
            var text51 = new Text();
            text51.Text = "‹#›";

            field16.Append(runProperties51);
            field16.Append(paragraphProperties39);
            field16.Append(text51);
            var endParagraphRunProperties44 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph61.Append(field16);
            paragraph61.Append(endParagraphRunProperties44);

            textBody45.Append(bodyProperties47);
            textBody45.Append(listStyle47);
            textBody45.Append(paragraph61);

            shape45.Append(nonVisualShapeProperties45);
            shape45.Append(shapeProperties47);
            shape45.Append(textBody45);

            shapeTree9.Append(nonVisualGroupShapeProperties9);
            shapeTree9.Append(groupShapeProperties9);
            shapeTree9.Append(shape41);
            shapeTree9.Append(shape42);
            shapeTree9.Append(shape43);
            shapeTree9.Append(shape44);
            shapeTree9.Append(shape45);

            commonSlideData9.Append(shapeTree9);

            var colorMapOverride8 = new ColorMapOverride();
            var masterColorMapping8 = new MasterColorMapping();

            colorMapOverride8.Append(masterColorMapping8);

            slideLayout7.Append(commonSlideData9);
            slideLayout7.Append(colorMapOverride8);

            slideLayoutPart7.SlideLayout = slideLayout7;
        }

        // Generates content of slideLayoutPart8.
        private void GenerateSlideLayoutPart8Content(SlideLayoutPart slideLayoutPart8)
        {
            var slideLayout8 = new SlideLayout {Type = SlideLayoutValues.TwoObjects, Preserve = true};
            slideLayout8.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout8.AddNamespaceDeclaration("r",
                                                 "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout8.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            var commonSlideData10 = new CommonSlideData {Name = "Two Content"};

            var shapeTree10 = new ShapeTree();

            var nonVisualGroupShapeProperties10 = new NonVisualGroupShapeProperties();
            var nonVisualDrawingProperties55 = new NonVisualDrawingProperties {Id = 1U, Name = ""};
            var nonVisualGroupShapeDrawingProperties10 = new NonVisualGroupShapeDrawingProperties();
            var applicationNonVisualDrawingProperties55 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties10.Append(nonVisualDrawingProperties55);
            nonVisualGroupShapeProperties10.Append(nonVisualGroupShapeDrawingProperties10);
            nonVisualGroupShapeProperties10.Append(applicationNonVisualDrawingProperties55);

            var groupShapeProperties10 = new GroupShapeProperties();

            var transformGroup10 = new TransformGroup();
            var offset30 = new Offset {X = 0L, Y = 0L};
            var extents30 = new Extents {Cx = 0L, Cy = 0L};
            var childOffset10 = new ChildOffset {X = 0L, Y = 0L};
            var childExtents10 = new ChildExtents {Cx = 0L, Cy = 0L};

            transformGroup10.Append(offset30);
            transformGroup10.Append(extents30);
            transformGroup10.Append(childOffset10);
            transformGroup10.Append(childExtents10);

            groupShapeProperties10.Append(transformGroup10);

            var shape46 = new Shape();

            var nonVisualShapeProperties46 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties56 = new NonVisualDrawingProperties {Id = 2U, Name = "Title 1"};

            var nonVisualShapeDrawingProperties46 = new NonVisualShapeDrawingProperties();
            var shapeLocks44 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties46.Append(shapeLocks44);

            var applicationNonVisualDrawingProperties56 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape43 = new PlaceholderShape {Type = PlaceholderValues.Title};

            applicationNonVisualDrawingProperties56.Append(placeholderShape43);

            nonVisualShapeProperties46.Append(nonVisualDrawingProperties56);
            nonVisualShapeProperties46.Append(nonVisualShapeDrawingProperties46);
            nonVisualShapeProperties46.Append(applicationNonVisualDrawingProperties56);

            var shapeProperties48 = new ShapeProperties();

            var transform2D21 = new Transform2D();
            var offset31 = new Offset {X = 549275L, Y = 107576L};
            var extents31 = new Extents {Cx = 8042276L, Cy = 1336956L};

            transform2D21.Append(offset31);
            transform2D21.Append(extents31);

            shapeProperties48.Append(transform2D21);

            var textBody46 = new TextBody();
            var bodyProperties48 = new BodyProperties();
            var listStyle48 = new ListStyle();

            var paragraph62 = new Paragraph();

            var run36 = new Run();

            var runProperties52 = new RunProperties {Language = "en-US"};
            runProperties52.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text52 = new Text();
            text52.Text = "Click to edit Master title style";

            run36.Append(runProperties52);
            run36.Append(text52);
            var endParagraphRunProperties45 = new EndParagraphRunProperties();

            paragraph62.Append(run36);
            paragraph62.Append(endParagraphRunProperties45);

            textBody46.Append(bodyProperties48);
            textBody46.Append(listStyle48);
            textBody46.Append(paragraph62);

            shape46.Append(nonVisualShapeProperties46);
            shape46.Append(shapeProperties48);
            shape46.Append(textBody46);

            var shape47 = new Shape();

            var nonVisualShapeProperties47 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties57 = new NonVisualDrawingProperties {Id = 3U, Name = "Content Placeholder 2"};

            var nonVisualShapeDrawingProperties47 = new NonVisualShapeDrawingProperties();
            var shapeLocks45 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties47.Append(shapeLocks45);

            var applicationNonVisualDrawingProperties57 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape44 = new PlaceholderShape {Size = PlaceholderSizeValues.Half, Index = 1U};

            applicationNonVisualDrawingProperties57.Append(placeholderShape44);

            nonVisualShapeProperties47.Append(nonVisualDrawingProperties57);
            nonVisualShapeProperties47.Append(nonVisualShapeDrawingProperties47);
            nonVisualShapeProperties47.Append(applicationNonVisualDrawingProperties57);

            var shapeProperties49 = new ShapeProperties();

            var transform2D22 = new Transform2D();
            var offset32 = new Offset {X = 549275L, Y = 1600201L};
            var extents32 = new Extents {Cx = 3840480L, Cy = 4343400L};

            transform2D22.Append(offset32);
            transform2D22.Append(extents32);

            shapeProperties49.Append(transform2D22);

            var textBody47 = new TextBody();

            var bodyProperties49 = new BodyProperties();
            var normalAutoFit6 = new NormalAutoFit();

            bodyProperties49.Append(normalAutoFit6);

            var listStyle49 = new ListStyle();

            var level1ParagraphProperties17 = new Level1ParagraphProperties();

            var spaceBefore17 = new SpaceBefore();
            var spacingPoints10 = new SpacingPoints {Val = 1600};

            spaceBefore17.Append(spacingPoints10);
            var defaultRunProperties87 = new DefaultRunProperties {FontSize = 2000};

            level1ParagraphProperties17.Append(spaceBefore17);
            level1ParagraphProperties17.Append(defaultRunProperties87);

            var level2ParagraphProperties9 = new Level2ParagraphProperties();
            var defaultRunProperties88 = new DefaultRunProperties {FontSize = 1800};

            level2ParagraphProperties9.Append(defaultRunProperties88);

            var level3ParagraphProperties9 = new Level3ParagraphProperties();
            var defaultRunProperties89 = new DefaultRunProperties {FontSize = 1800};

            level3ParagraphProperties9.Append(defaultRunProperties89);

            var level4ParagraphProperties9 = new Level4ParagraphProperties();
            var defaultRunProperties90 = new DefaultRunProperties {FontSize = 1800};

            level4ParagraphProperties9.Append(defaultRunProperties90);

            var level5ParagraphProperties12 = new Level5ParagraphProperties();
            var defaultRunProperties91 = new DefaultRunProperties {FontSize = 1800};

            level5ParagraphProperties12.Append(defaultRunProperties91);

            var level6ParagraphProperties9 = new Level6ParagraphProperties();
            var defaultRunProperties92 = new DefaultRunProperties {FontSize = 1800};

            level6ParagraphProperties9.Append(defaultRunProperties92);

            var level7ParagraphProperties9 = new Level7ParagraphProperties();
            var defaultRunProperties93 = new DefaultRunProperties {FontSize = 1800};

            level7ParagraphProperties9.Append(defaultRunProperties93);

            var level8ParagraphProperties9 = new Level8ParagraphProperties();
            var defaultRunProperties94 = new DefaultRunProperties {FontSize = 1800};

            level8ParagraphProperties9.Append(defaultRunProperties94);

            var level9ParagraphProperties9 = new Level9ParagraphProperties();
            var defaultRunProperties95 = new DefaultRunProperties {FontSize = 1800};

            level9ParagraphProperties9.Append(defaultRunProperties95);

            listStyle49.Append(level1ParagraphProperties17);
            listStyle49.Append(level2ParagraphProperties9);
            listStyle49.Append(level3ParagraphProperties9);
            listStyle49.Append(level4ParagraphProperties9);
            listStyle49.Append(level5ParagraphProperties12);
            listStyle49.Append(level6ParagraphProperties9);
            listStyle49.Append(level7ParagraphProperties9);
            listStyle49.Append(level8ParagraphProperties9);
            listStyle49.Append(level9ParagraphProperties9);

            var paragraph63 = new Paragraph();
            var paragraphProperties40 = new ParagraphProperties {Level = 0};

            var run37 = new Run();

            var runProperties53 = new RunProperties {Language = "en-US"};
            runProperties53.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text53 = new Text();
            text53.Text = "Click to edit Master text styles";

            run37.Append(runProperties53);
            run37.Append(text53);

            paragraph63.Append(paragraphProperties40);
            paragraph63.Append(run37);

            var paragraph64 = new Paragraph();
            var paragraphProperties41 = new ParagraphProperties {Level = 1};

            var run38 = new Run();

            var runProperties54 = new RunProperties {Language = "en-US"};
            runProperties54.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text54 = new Text();
            text54.Text = "Second level";

            run38.Append(runProperties54);
            run38.Append(text54);

            paragraph64.Append(paragraphProperties41);
            paragraph64.Append(run38);

            var paragraph65 = new Paragraph();
            var paragraphProperties42 = new ParagraphProperties {Level = 2};

            var run39 = new Run();

            var runProperties55 = new RunProperties {Language = "en-US"};
            runProperties55.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text55 = new Text();
            text55.Text = "Third level";

            run39.Append(runProperties55);
            run39.Append(text55);

            paragraph65.Append(paragraphProperties42);
            paragraph65.Append(run39);

            var paragraph66 = new Paragraph();
            var paragraphProperties43 = new ParagraphProperties {Level = 3};

            var run40 = new Run();

            var runProperties56 = new RunProperties {Language = "en-US"};
            runProperties56.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text56 = new Text();
            text56.Text = "Fourth level";

            run40.Append(runProperties56);
            run40.Append(text56);

            paragraph66.Append(paragraphProperties43);
            paragraph66.Append(run40);

            var paragraph67 = new Paragraph();
            var paragraphProperties44 = new ParagraphProperties {Level = 4};

            var run41 = new Run();

            var runProperties57 = new RunProperties {Language = "en-US"};
            runProperties57.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text57 = new Text();
            text57.Text = "Fifth level";

            run41.Append(runProperties57);
            run41.Append(text57);
            var endParagraphRunProperties46 = new EndParagraphRunProperties {Dirty = false};

            paragraph67.Append(paragraphProperties44);
            paragraph67.Append(run41);
            paragraph67.Append(endParagraphRunProperties46);

            textBody47.Append(bodyProperties49);
            textBody47.Append(listStyle49);
            textBody47.Append(paragraph63);
            textBody47.Append(paragraph64);
            textBody47.Append(paragraph65);
            textBody47.Append(paragraph66);
            textBody47.Append(paragraph67);

            shape47.Append(nonVisualShapeProperties47);
            shape47.Append(shapeProperties49);
            shape47.Append(textBody47);

            var shape48 = new Shape();

            var nonVisualShapeProperties48 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties58 = new NonVisualDrawingProperties {Id = 4U, Name = "Content Placeholder 3"};

            var nonVisualShapeDrawingProperties48 = new NonVisualShapeDrawingProperties();
            var shapeLocks46 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties48.Append(shapeLocks46);

            var applicationNonVisualDrawingProperties58 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape45 = new PlaceholderShape {Size = PlaceholderSizeValues.Half, Index = 2U};

            applicationNonVisualDrawingProperties58.Append(placeholderShape45);

            nonVisualShapeProperties48.Append(nonVisualDrawingProperties58);
            nonVisualShapeProperties48.Append(nonVisualShapeDrawingProperties48);
            nonVisualShapeProperties48.Append(applicationNonVisualDrawingProperties58);

            var shapeProperties50 = new ShapeProperties();

            var transform2D23 = new Transform2D();
            var offset33 = new Offset {X = 4751071L, Y = 1600201L};
            var extents33 = new Extents {Cx = 3840480L, Cy = 4343400L};

            transform2D23.Append(offset33);
            transform2D23.Append(extents33);

            shapeProperties50.Append(transform2D23);

            var textBody48 = new TextBody();

            var bodyProperties50 = new BodyProperties();
            var normalAutoFit7 = new NormalAutoFit();

            bodyProperties50.Append(normalAutoFit7);

            var listStyle50 = new ListStyle();

            var level1ParagraphProperties18 = new Level1ParagraphProperties();

            var spaceBefore18 = new SpaceBefore();
            var spacingPoints11 = new SpacingPoints {Val = 1600};

            spaceBefore18.Append(spacingPoints11);
            var defaultRunProperties96 = new DefaultRunProperties {FontSize = 2000};

            level1ParagraphProperties18.Append(spaceBefore18);
            level1ParagraphProperties18.Append(defaultRunProperties96);

            var level2ParagraphProperties10 = new Level2ParagraphProperties();
            var defaultRunProperties97 = new DefaultRunProperties {FontSize = 1800};

            level2ParagraphProperties10.Append(defaultRunProperties97);

            var level3ParagraphProperties10 = new Level3ParagraphProperties();
            var defaultRunProperties98 = new DefaultRunProperties {FontSize = 1800};

            level3ParagraphProperties10.Append(defaultRunProperties98);

            var level4ParagraphProperties10 = new Level4ParagraphProperties();
            var defaultRunProperties99 = new DefaultRunProperties {FontSize = 1800};

            level4ParagraphProperties10.Append(defaultRunProperties99);

            var level5ParagraphProperties13 = new Level5ParagraphProperties();
            var defaultRunProperties100 = new DefaultRunProperties {FontSize = 1800};

            level5ParagraphProperties13.Append(defaultRunProperties100);

            var level6ParagraphProperties10 = new Level6ParagraphProperties();
            var defaultRunProperties101 = new DefaultRunProperties {FontSize = 1800};

            level6ParagraphProperties10.Append(defaultRunProperties101);

            var level7ParagraphProperties10 = new Level7ParagraphProperties();
            var defaultRunProperties102 = new DefaultRunProperties {FontSize = 1800};

            level7ParagraphProperties10.Append(defaultRunProperties102);

            var level8ParagraphProperties10 = new Level8ParagraphProperties();
            var defaultRunProperties103 = new DefaultRunProperties {FontSize = 1800};

            level8ParagraphProperties10.Append(defaultRunProperties103);

            var level9ParagraphProperties10 = new Level9ParagraphProperties();
            var defaultRunProperties104 = new DefaultRunProperties {FontSize = 1800};

            level9ParagraphProperties10.Append(defaultRunProperties104);

            listStyle50.Append(level1ParagraphProperties18);
            listStyle50.Append(level2ParagraphProperties10);
            listStyle50.Append(level3ParagraphProperties10);
            listStyle50.Append(level4ParagraphProperties10);
            listStyle50.Append(level5ParagraphProperties13);
            listStyle50.Append(level6ParagraphProperties10);
            listStyle50.Append(level7ParagraphProperties10);
            listStyle50.Append(level8ParagraphProperties10);
            listStyle50.Append(level9ParagraphProperties10);

            var paragraph68 = new Paragraph();
            var paragraphProperties45 = new ParagraphProperties {Level = 0};

            var run42 = new Run();

            var runProperties58 = new RunProperties {Language = "en-US"};
            runProperties58.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text58 = new Text();
            text58.Text = "Click to edit Master text styles";

            run42.Append(runProperties58);
            run42.Append(text58);

            paragraph68.Append(paragraphProperties45);
            paragraph68.Append(run42);

            var paragraph69 = new Paragraph();
            var paragraphProperties46 = new ParagraphProperties {Level = 1};

            var run43 = new Run();

            var runProperties59 = new RunProperties {Language = "en-US"};
            runProperties59.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text59 = new Text();
            text59.Text = "Second level";

            run43.Append(runProperties59);
            run43.Append(text59);

            paragraph69.Append(paragraphProperties46);
            paragraph69.Append(run43);

            var paragraph70 = new Paragraph();
            var paragraphProperties47 = new ParagraphProperties {Level = 2};

            var run44 = new Run();

            var runProperties60 = new RunProperties {Language = "en-US"};
            runProperties60.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text60 = new Text();
            text60.Text = "Third level";

            run44.Append(runProperties60);
            run44.Append(text60);

            paragraph70.Append(paragraphProperties47);
            paragraph70.Append(run44);

            var paragraph71 = new Paragraph();
            var paragraphProperties48 = new ParagraphProperties {Level = 3};

            var run45 = new Run();

            var runProperties61 = new RunProperties {Language = "en-US"};
            runProperties61.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text61 = new Text();
            text61.Text = "Fourth level";

            run45.Append(runProperties61);
            run45.Append(text61);

            paragraph71.Append(paragraphProperties48);
            paragraph71.Append(run45);

            var paragraph72 = new Paragraph();
            var paragraphProperties49 = new ParagraphProperties {Level = 4};

            var run46 = new Run();

            var runProperties62 = new RunProperties {Language = "en-US"};
            runProperties62.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text62 = new Text();
            text62.Text = "Fifth level";

            run46.Append(runProperties62);
            run46.Append(text62);
            var endParagraphRunProperties47 = new EndParagraphRunProperties {Dirty = false};

            paragraph72.Append(paragraphProperties49);
            paragraph72.Append(run46);
            paragraph72.Append(endParagraphRunProperties47);

            textBody48.Append(bodyProperties50);
            textBody48.Append(listStyle50);
            textBody48.Append(paragraph68);
            textBody48.Append(paragraph69);
            textBody48.Append(paragraph70);
            textBody48.Append(paragraph71);
            textBody48.Append(paragraph72);

            shape48.Append(nonVisualShapeProperties48);
            shape48.Append(shapeProperties50);
            shape48.Append(textBody48);

            var shape49 = new Shape();

            var nonVisualShapeProperties49 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties59 = new NonVisualDrawingProperties {Id = 5U, Name = "Date Placeholder 4"};

            var nonVisualShapeDrawingProperties49 = new NonVisualShapeDrawingProperties();
            var shapeLocks47 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties49.Append(shapeLocks47);

            var applicationNonVisualDrawingProperties59 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape46 = new PlaceholderShape
                {
                    Type = PlaceholderValues.DateAndTime,
                    Size = PlaceholderSizeValues.Half,
                    Index = 10U
                };

            applicationNonVisualDrawingProperties59.Append(placeholderShape46);

            nonVisualShapeProperties49.Append(nonVisualDrawingProperties59);
            nonVisualShapeProperties49.Append(nonVisualShapeDrawingProperties49);
            nonVisualShapeProperties49.Append(applicationNonVisualDrawingProperties59);
            var shapeProperties51 = new ShapeProperties();

            var textBody49 = new TextBody();
            var bodyProperties51 = new BodyProperties();
            var listStyle51 = new ListStyle();

            var paragraph73 = new Paragraph();

            var field17 = new Field {Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut"};

            var runProperties63 = new RunProperties {Language = "en-US"};
            runProperties63.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties50 = new ParagraphProperties();
            var text63 = new Text();
            text63.Text = "29/11/13";

            field17.Append(runProperties63);
            field17.Append(paragraphProperties50);
            field17.Append(text63);
            var endParagraphRunProperties48 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph73.Append(field17);
            paragraph73.Append(endParagraphRunProperties48);

            textBody49.Append(bodyProperties51);
            textBody49.Append(listStyle51);
            textBody49.Append(paragraph73);

            shape49.Append(nonVisualShapeProperties49);
            shape49.Append(shapeProperties51);
            shape49.Append(textBody49);

            var shape50 = new Shape();

            var nonVisualShapeProperties50 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties60 = new NonVisualDrawingProperties {Id = 6U, Name = "Footer Placeholder 5"};

            var nonVisualShapeDrawingProperties50 = new NonVisualShapeDrawingProperties();
            var shapeLocks48 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties50.Append(shapeLocks48);

            var applicationNonVisualDrawingProperties60 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape47 = new PlaceholderShape
                {
                    Type = PlaceholderValues.Footer,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 11U
                };

            applicationNonVisualDrawingProperties60.Append(placeholderShape47);

            nonVisualShapeProperties50.Append(nonVisualDrawingProperties60);
            nonVisualShapeProperties50.Append(nonVisualShapeDrawingProperties50);
            nonVisualShapeProperties50.Append(applicationNonVisualDrawingProperties60);
            var shapeProperties52 = new ShapeProperties();

            var textBody50 = new TextBody();
            var bodyProperties52 = new BodyProperties();
            var listStyle52 = new ListStyle();

            var paragraph74 = new Paragraph();
            var endParagraphRunProperties49 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph74.Append(endParagraphRunProperties49);

            textBody50.Append(bodyProperties52);
            textBody50.Append(listStyle52);
            textBody50.Append(paragraph74);

            shape50.Append(nonVisualShapeProperties50);
            shape50.Append(shapeProperties52);
            shape50.Append(textBody50);

            var shape51 = new Shape();

            var nonVisualShapeProperties51 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties61 = new NonVisualDrawingProperties
                {
                    Id = 7U,
                    Name = "Slide Number Placeholder 6"
                };

            var nonVisualShapeDrawingProperties51 = new NonVisualShapeDrawingProperties();
            var shapeLocks49 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties51.Append(shapeLocks49);

            var applicationNonVisualDrawingProperties61 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape48 = new PlaceholderShape
                {
                    Type = PlaceholderValues.SlideNumber,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 12U
                };

            applicationNonVisualDrawingProperties61.Append(placeholderShape48);

            nonVisualShapeProperties51.Append(nonVisualDrawingProperties61);
            nonVisualShapeProperties51.Append(nonVisualShapeDrawingProperties51);
            nonVisualShapeProperties51.Append(applicationNonVisualDrawingProperties61);
            var shapeProperties53 = new ShapeProperties();

            var textBody51 = new TextBody();
            var bodyProperties53 = new BodyProperties();
            var listStyle53 = new ListStyle();

            var paragraph75 = new Paragraph();

            var field18 = new Field {Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum"};

            var runProperties64 = new RunProperties {Language = "en-US"};
            runProperties64.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties51 = new ParagraphProperties();
            var text64 = new Text();
            text64.Text = "‹#›";

            field18.Append(runProperties64);
            field18.Append(paragraphProperties51);
            field18.Append(text64);
            var endParagraphRunProperties50 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph75.Append(field18);
            paragraph75.Append(endParagraphRunProperties50);

            textBody51.Append(bodyProperties53);
            textBody51.Append(listStyle53);
            textBody51.Append(paragraph75);

            shape51.Append(nonVisualShapeProperties51);
            shape51.Append(shapeProperties53);
            shape51.Append(textBody51);

            shapeTree10.Append(nonVisualGroupShapeProperties10);
            shapeTree10.Append(groupShapeProperties10);
            shapeTree10.Append(shape46);
            shapeTree10.Append(shape47);
            shapeTree10.Append(shape48);
            shapeTree10.Append(shape49);
            shapeTree10.Append(shape50);
            shapeTree10.Append(shape51);

            commonSlideData10.Append(shapeTree10);

            var colorMapOverride9 = new ColorMapOverride();
            var masterColorMapping9 = new MasterColorMapping();

            colorMapOverride9.Append(masterColorMapping9);

            slideLayout8.Append(commonSlideData10);
            slideLayout8.Append(colorMapOverride9);

            slideLayoutPart8.SlideLayout = slideLayout8;
        }

        // Generates content of slideLayoutPart9.
        private void GenerateSlideLayoutPart9Content(SlideLayoutPart slideLayoutPart9)
        {
            var slideLayout9 = new SlideLayout {Type = SlideLayoutValues.TwoTextAndTwoObjects, Preserve = true};
            slideLayout9.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout9.AddNamespaceDeclaration("r",
                                                 "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout9.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            var commonSlideData11 = new CommonSlideData {Name = "Comparison"};

            var shapeTree11 = new ShapeTree();

            var nonVisualGroupShapeProperties11 = new NonVisualGroupShapeProperties();
            var nonVisualDrawingProperties62 = new NonVisualDrawingProperties {Id = 1U, Name = ""};
            var nonVisualGroupShapeDrawingProperties11 = new NonVisualGroupShapeDrawingProperties();
            var applicationNonVisualDrawingProperties62 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties11.Append(nonVisualDrawingProperties62);
            nonVisualGroupShapeProperties11.Append(nonVisualGroupShapeDrawingProperties11);
            nonVisualGroupShapeProperties11.Append(applicationNonVisualDrawingProperties62);

            var groupShapeProperties11 = new GroupShapeProperties();

            var transformGroup11 = new TransformGroup();
            var offset34 = new Offset {X = 0L, Y = 0L};
            var extents34 = new Extents {Cx = 0L, Cy = 0L};
            var childOffset11 = new ChildOffset {X = 0L, Y = 0L};
            var childExtents11 = new ChildExtents {Cx = 0L, Cy = 0L};

            transformGroup11.Append(offset34);
            transformGroup11.Append(extents34);
            transformGroup11.Append(childOffset11);
            transformGroup11.Append(childExtents11);

            groupShapeProperties11.Append(transformGroup11);

            var shape52 = new Shape();

            var nonVisualShapeProperties52 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties63 = new NonVisualDrawingProperties {Id = 2U, Name = "Title 1"};

            var nonVisualShapeDrawingProperties52 = new NonVisualShapeDrawingProperties();
            var shapeLocks50 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties52.Append(shapeLocks50);

            var applicationNonVisualDrawingProperties63 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape49 = new PlaceholderShape {Type = PlaceholderValues.Title};

            applicationNonVisualDrawingProperties63.Append(placeholderShape49);

            nonVisualShapeProperties52.Append(nonVisualDrawingProperties63);
            nonVisualShapeProperties52.Append(nonVisualShapeDrawingProperties52);
            nonVisualShapeProperties52.Append(applicationNonVisualDrawingProperties63);

            var shapeProperties54 = new ShapeProperties();

            var transform2D24 = new Transform2D();
            var offset35 = new Offset {X = 549274L, Y = 107576L};
            var extents35 = new Extents {Cx = 8042276L, Cy = 1336956L};

            transform2D24.Append(offset35);
            transform2D24.Append(extents35);

            shapeProperties54.Append(transform2D24);

            var textBody52 = new TextBody();
            var bodyProperties54 = new BodyProperties();

            var listStyle54 = new ListStyle();

            var level1ParagraphProperties19 = new Level1ParagraphProperties();
            var defaultRunProperties105 = new DefaultRunProperties();

            level1ParagraphProperties19.Append(defaultRunProperties105);

            listStyle54.Append(level1ParagraphProperties19);

            var paragraph76 = new Paragraph();

            var run47 = new Run();

            var runProperties65 = new RunProperties {Language = "en-US"};
            runProperties65.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text65 = new Text();
            text65.Text = "Click to edit Master title style";

            run47.Append(runProperties65);
            run47.Append(text65);
            var endParagraphRunProperties51 = new EndParagraphRunProperties();

            paragraph76.Append(run47);
            paragraph76.Append(endParagraphRunProperties51);

            textBody52.Append(bodyProperties54);
            textBody52.Append(listStyle54);
            textBody52.Append(paragraph76);

            shape52.Append(nonVisualShapeProperties52);
            shape52.Append(shapeProperties54);
            shape52.Append(textBody52);

            var shape53 = new Shape();

            var nonVisualShapeProperties53 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties64 = new NonVisualDrawingProperties {Id = 3U, Name = "Text Placeholder 2"};

            var nonVisualShapeDrawingProperties53 = new NonVisualShapeDrawingProperties();
            var shapeLocks51 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties53.Append(shapeLocks51);

            var applicationNonVisualDrawingProperties64 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape50 = new PlaceholderShape {Type = PlaceholderValues.Body, Index = 1U};

            applicationNonVisualDrawingProperties64.Append(placeholderShape50);

            nonVisualShapeProperties53.Append(nonVisualDrawingProperties64);
            nonVisualShapeProperties53.Append(nonVisualShapeDrawingProperties53);
            nonVisualShapeProperties53.Append(applicationNonVisualDrawingProperties64);

            var shapeProperties55 = new ShapeProperties();

            var transform2D25 = new Transform2D();
            var offset36 = new Offset {X = 549274L, Y = 1453224L};
            var extents36 = new Extents {Cx = 3840480L, Cy = 750887L};

            transform2D25.Append(offset36);
            transform2D25.Append(extents36);

            shapeProperties55.Append(transform2D25);

            var textBody53 = new TextBody();

            var bodyProperties55 = new BodyProperties {Anchor = TextAnchoringTypeValues.Bottom};
            var noAutoFit4 = new NoAutoFit();

            bodyProperties55.Append(noAutoFit4);

            var listStyle55 = new ListStyle();

            var level1ParagraphProperties20 = new Level1ParagraphProperties
                {
                    LeftMargin = 0,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };

            var spaceBefore19 = new SpaceBefore();
            var spacingPoints12 = new SpacingPoints {Val = 0};

            spaceBefore19.Append(spacingPoints12);
            var noBullet51 = new NoBullet();

            var defaultRunProperties106 = new DefaultRunProperties {FontSize = 2400, Bold = false};

            var solidFill78 = new SolidFill();

            var schemeColor109 = new SchemeColor {Val = SchemeColorValues.Accent1};
            var luminanceModulation21 = new LuminanceModulation {Val = 60000};
            var luminanceOffset19 = new LuminanceOffset {Val = 40000};

            schemeColor109.Append(luminanceModulation21);
            schemeColor109.Append(luminanceOffset19);

            solidFill78.Append(schemeColor109);

            defaultRunProperties106.Append(solidFill78);

            level1ParagraphProperties20.Append(spaceBefore19);
            level1ParagraphProperties20.Append(noBullet51);
            level1ParagraphProperties20.Append(defaultRunProperties106);

            var level2ParagraphProperties11 = new Level2ParagraphProperties {LeftMargin = 457200, Indent = 0};
            var noBullet52 = new NoBullet();
            var defaultRunProperties107 = new DefaultRunProperties {FontSize = 2000, Bold = true};

            level2ParagraphProperties11.Append(noBullet52);
            level2ParagraphProperties11.Append(defaultRunProperties107);

            var level3ParagraphProperties11 = new Level3ParagraphProperties {LeftMargin = 914400, Indent = 0};
            var noBullet53 = new NoBullet();
            var defaultRunProperties108 = new DefaultRunProperties {FontSize = 1800, Bold = true};

            level3ParagraphProperties11.Append(noBullet53);
            level3ParagraphProperties11.Append(defaultRunProperties108);

            var level4ParagraphProperties11 = new Level4ParagraphProperties {LeftMargin = 1371600, Indent = 0};
            var noBullet54 = new NoBullet();
            var defaultRunProperties109 = new DefaultRunProperties {FontSize = 1600, Bold = true};

            level4ParagraphProperties11.Append(noBullet54);
            level4ParagraphProperties11.Append(defaultRunProperties109);

            var level5ParagraphProperties14 = new Level5ParagraphProperties {LeftMargin = 1828800, Indent = 0};
            var noBullet55 = new NoBullet();
            var defaultRunProperties110 = new DefaultRunProperties {FontSize = 1600, Bold = true};

            level5ParagraphProperties14.Append(noBullet55);
            level5ParagraphProperties14.Append(defaultRunProperties110);

            var level6ParagraphProperties11 = new Level6ParagraphProperties {LeftMargin = 2286000, Indent = 0};
            var noBullet56 = new NoBullet();
            var defaultRunProperties111 = new DefaultRunProperties {FontSize = 1600, Bold = true};

            level6ParagraphProperties11.Append(noBullet56);
            level6ParagraphProperties11.Append(defaultRunProperties111);

            var level7ParagraphProperties11 = new Level7ParagraphProperties {LeftMargin = 2743200, Indent = 0};
            var noBullet57 = new NoBullet();
            var defaultRunProperties112 = new DefaultRunProperties {FontSize = 1600, Bold = true};

            level7ParagraphProperties11.Append(noBullet57);
            level7ParagraphProperties11.Append(defaultRunProperties112);

            var level8ParagraphProperties11 = new Level8ParagraphProperties {LeftMargin = 3200400, Indent = 0};
            var noBullet58 = new NoBullet();
            var defaultRunProperties113 = new DefaultRunProperties {FontSize = 1600, Bold = true};

            level8ParagraphProperties11.Append(noBullet58);
            level8ParagraphProperties11.Append(defaultRunProperties113);

            var level9ParagraphProperties11 = new Level9ParagraphProperties {LeftMargin = 3657600, Indent = 0};
            var noBullet59 = new NoBullet();
            var defaultRunProperties114 = new DefaultRunProperties {FontSize = 1600, Bold = true};

            level9ParagraphProperties11.Append(noBullet59);
            level9ParagraphProperties11.Append(defaultRunProperties114);

            listStyle55.Append(level1ParagraphProperties20);
            listStyle55.Append(level2ParagraphProperties11);
            listStyle55.Append(level3ParagraphProperties11);
            listStyle55.Append(level4ParagraphProperties11);
            listStyle55.Append(level5ParagraphProperties14);
            listStyle55.Append(level6ParagraphProperties11);
            listStyle55.Append(level7ParagraphProperties11);
            listStyle55.Append(level8ParagraphProperties11);
            listStyle55.Append(level9ParagraphProperties11);

            var paragraph77 = new Paragraph();
            var paragraphProperties52 = new ParagraphProperties {Level = 0};

            var run48 = new Run();

            var runProperties66 = new RunProperties {Language = "en-US"};
            runProperties66.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text66 = new Text();
            text66.Text = "Click to edit Master text styles";

            run48.Append(runProperties66);
            run48.Append(text66);

            paragraph77.Append(paragraphProperties52);
            paragraph77.Append(run48);

            textBody53.Append(bodyProperties55);
            textBody53.Append(listStyle55);
            textBody53.Append(paragraph77);

            shape53.Append(nonVisualShapeProperties53);
            shape53.Append(shapeProperties55);
            shape53.Append(textBody53);

            var shape54 = new Shape();

            var nonVisualShapeProperties54 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties65 = new NonVisualDrawingProperties {Id = 4U, Name = "Content Placeholder 3"};

            var nonVisualShapeDrawingProperties54 = new NonVisualShapeDrawingProperties();
            var shapeLocks52 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties54.Append(shapeLocks52);

            var applicationNonVisualDrawingProperties65 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape51 = new PlaceholderShape {Size = PlaceholderSizeValues.Half, Index = 2U};

            applicationNonVisualDrawingProperties65.Append(placeholderShape51);

            nonVisualShapeProperties54.Append(nonVisualDrawingProperties65);
            nonVisualShapeProperties54.Append(nonVisualShapeDrawingProperties54);
            nonVisualShapeProperties54.Append(applicationNonVisualDrawingProperties65);

            var shapeProperties56 = new ShapeProperties();

            var transform2D26 = new Transform2D();
            var offset37 = new Offset {X = 549274L, Y = 2347415L};
            var extents37 = new Extents {Cx = 3840480L, Cy = 3596185L};

            transform2D26.Append(offset37);
            transform2D26.Append(extents37);

            shapeProperties56.Append(transform2D26);

            var textBody54 = new TextBody();

            var bodyProperties56 = new BodyProperties();
            var normalAutoFit8 = new NormalAutoFit();

            bodyProperties56.Append(normalAutoFit8);

            var listStyle56 = new ListStyle();

            var level1ParagraphProperties21 = new Level1ParagraphProperties();

            var spaceBefore20 = new SpaceBefore();
            var spacingPoints13 = new SpacingPoints {Val = 1600};

            spaceBefore20.Append(spacingPoints13);
            var defaultRunProperties115 = new DefaultRunProperties {FontSize = 2000};

            level1ParagraphProperties21.Append(spaceBefore20);
            level1ParagraphProperties21.Append(defaultRunProperties115);

            var level2ParagraphProperties12 = new Level2ParagraphProperties();
            var defaultRunProperties116 = new DefaultRunProperties {FontSize = 1800};

            level2ParagraphProperties12.Append(defaultRunProperties116);

            var level3ParagraphProperties12 = new Level3ParagraphProperties();
            var defaultRunProperties117 = new DefaultRunProperties {FontSize = 1800};

            level3ParagraphProperties12.Append(defaultRunProperties117);

            var level4ParagraphProperties12 = new Level4ParagraphProperties();
            var defaultRunProperties118 = new DefaultRunProperties {FontSize = 1800};

            level4ParagraphProperties12.Append(defaultRunProperties118);

            var level5ParagraphProperties15 = new Level5ParagraphProperties();
            var defaultRunProperties119 = new DefaultRunProperties {FontSize = 1800};

            level5ParagraphProperties15.Append(defaultRunProperties119);

            var level6ParagraphProperties12 = new Level6ParagraphProperties();
            var defaultRunProperties120 = new DefaultRunProperties {FontSize = 1600};

            level6ParagraphProperties12.Append(defaultRunProperties120);

            var level7ParagraphProperties12 = new Level7ParagraphProperties();
            var defaultRunProperties121 = new DefaultRunProperties {FontSize = 1600};

            level7ParagraphProperties12.Append(defaultRunProperties121);

            var level8ParagraphProperties12 = new Level8ParagraphProperties();
            var defaultRunProperties122 = new DefaultRunProperties {FontSize = 1600};

            level8ParagraphProperties12.Append(defaultRunProperties122);

            var level9ParagraphProperties12 = new Level9ParagraphProperties();
            var defaultRunProperties123 = new DefaultRunProperties {FontSize = 1600};

            level9ParagraphProperties12.Append(defaultRunProperties123);

            listStyle56.Append(level1ParagraphProperties21);
            listStyle56.Append(level2ParagraphProperties12);
            listStyle56.Append(level3ParagraphProperties12);
            listStyle56.Append(level4ParagraphProperties12);
            listStyle56.Append(level5ParagraphProperties15);
            listStyle56.Append(level6ParagraphProperties12);
            listStyle56.Append(level7ParagraphProperties12);
            listStyle56.Append(level8ParagraphProperties12);
            listStyle56.Append(level9ParagraphProperties12);

            var paragraph78 = new Paragraph();
            var paragraphProperties53 = new ParagraphProperties {Level = 0};

            var run49 = new Run();

            var runProperties67 = new RunProperties {Language = "en-US"};
            runProperties67.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text67 = new Text();
            text67.Text = "Click to edit Master text styles";

            run49.Append(runProperties67);
            run49.Append(text67);

            paragraph78.Append(paragraphProperties53);
            paragraph78.Append(run49);

            var paragraph79 = new Paragraph();
            var paragraphProperties54 = new ParagraphProperties {Level = 1};

            var run50 = new Run();

            var runProperties68 = new RunProperties {Language = "en-US"};
            runProperties68.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text68 = new Text();
            text68.Text = "Second level";

            run50.Append(runProperties68);
            run50.Append(text68);

            paragraph79.Append(paragraphProperties54);
            paragraph79.Append(run50);

            var paragraph80 = new Paragraph();
            var paragraphProperties55 = new ParagraphProperties {Level = 2};

            var run51 = new Run();

            var runProperties69 = new RunProperties {Language = "en-US"};
            runProperties69.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text69 = new Text();
            text69.Text = "Third level";

            run51.Append(runProperties69);
            run51.Append(text69);

            paragraph80.Append(paragraphProperties55);
            paragraph80.Append(run51);

            var paragraph81 = new Paragraph();
            var paragraphProperties56 = new ParagraphProperties {Level = 3};

            var run52 = new Run();

            var runProperties70 = new RunProperties {Language = "en-US"};
            runProperties70.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text70 = new Text();
            text70.Text = "Fourth level";

            run52.Append(runProperties70);
            run52.Append(text70);

            paragraph81.Append(paragraphProperties56);
            paragraph81.Append(run52);

            var paragraph82 = new Paragraph();
            var paragraphProperties57 = new ParagraphProperties {Level = 4};

            var run53 = new Run();

            var runProperties71 = new RunProperties {Language = "en-US"};
            runProperties71.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text71 = new Text();
            text71.Text = "Fifth level";

            run53.Append(runProperties71);
            run53.Append(text71);
            var endParagraphRunProperties52 = new EndParagraphRunProperties {Dirty = false};

            paragraph82.Append(paragraphProperties57);
            paragraph82.Append(run53);
            paragraph82.Append(endParagraphRunProperties52);

            textBody54.Append(bodyProperties56);
            textBody54.Append(listStyle56);
            textBody54.Append(paragraph78);
            textBody54.Append(paragraph79);
            textBody54.Append(paragraph80);
            textBody54.Append(paragraph81);
            textBody54.Append(paragraph82);

            shape54.Append(nonVisualShapeProperties54);
            shape54.Append(shapeProperties56);
            shape54.Append(textBody54);

            var shape55 = new Shape();

            var nonVisualShapeProperties55 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties66 = new NonVisualDrawingProperties {Id = 5U, Name = "Text Placeholder 4"};

            var nonVisualShapeDrawingProperties55 = new NonVisualShapeDrawingProperties();
            var shapeLocks53 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties55.Append(shapeLocks53);

            var applicationNonVisualDrawingProperties66 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape52 = new PlaceholderShape
                {
                    Type = PlaceholderValues.Body,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 3U
                };

            applicationNonVisualDrawingProperties66.Append(placeholderShape52);

            nonVisualShapeProperties55.Append(nonVisualDrawingProperties66);
            nonVisualShapeProperties55.Append(nonVisualShapeDrawingProperties55);
            nonVisualShapeProperties55.Append(applicationNonVisualDrawingProperties66);

            var shapeProperties57 = new ShapeProperties();

            var transform2D27 = new Transform2D();
            var offset38 = new Offset {X = 4751070L, Y = 1453224L};
            var extents38 = new Extents {Cx = 3840480L, Cy = 750887L};

            transform2D27.Append(offset38);
            transform2D27.Append(extents38);

            shapeProperties57.Append(transform2D27);

            var textBody55 = new TextBody();

            var bodyProperties57 = new BodyProperties {Anchor = TextAnchoringTypeValues.Bottom};
            var noAutoFit5 = new NoAutoFit();

            bodyProperties57.Append(noAutoFit5);

            var listStyle57 = new ListStyle();

            var level1ParagraphProperties22 = new Level1ParagraphProperties
                {
                    LeftMargin = 0,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };

            var spaceBefore21 = new SpaceBefore();
            var spacingPoints14 = new SpacingPoints {Val = 0};

            spaceBefore21.Append(spacingPoints14);
            var noBullet60 = new NoBullet();

            var defaultRunProperties124 = new DefaultRunProperties {FontSize = 2400, Bold = false};

            var solidFill79 = new SolidFill();

            var schemeColor110 = new SchemeColor {Val = SchemeColorValues.Accent1};
            var luminanceModulation22 = new LuminanceModulation {Val = 60000};
            var luminanceOffset20 = new LuminanceOffset {Val = 40000};

            schemeColor110.Append(luminanceModulation22);
            schemeColor110.Append(luminanceOffset20);

            solidFill79.Append(schemeColor110);

            defaultRunProperties124.Append(solidFill79);

            level1ParagraphProperties22.Append(spaceBefore21);
            level1ParagraphProperties22.Append(noBullet60);
            level1ParagraphProperties22.Append(defaultRunProperties124);

            var level2ParagraphProperties13 = new Level2ParagraphProperties {LeftMargin = 457200, Indent = 0};
            var noBullet61 = new NoBullet();
            var defaultRunProperties125 = new DefaultRunProperties {FontSize = 2000, Bold = true};

            level2ParagraphProperties13.Append(noBullet61);
            level2ParagraphProperties13.Append(defaultRunProperties125);

            var level3ParagraphProperties13 = new Level3ParagraphProperties {LeftMargin = 914400, Indent = 0};
            var noBullet62 = new NoBullet();
            var defaultRunProperties126 = new DefaultRunProperties {FontSize = 1800, Bold = true};

            level3ParagraphProperties13.Append(noBullet62);
            level3ParagraphProperties13.Append(defaultRunProperties126);

            var level4ParagraphProperties13 = new Level4ParagraphProperties {LeftMargin = 1371600, Indent = 0};
            var noBullet63 = new NoBullet();
            var defaultRunProperties127 = new DefaultRunProperties {FontSize = 1600, Bold = true};

            level4ParagraphProperties13.Append(noBullet63);
            level4ParagraphProperties13.Append(defaultRunProperties127);

            var level5ParagraphProperties16 = new Level5ParagraphProperties {LeftMargin = 1828800, Indent = 0};
            var noBullet64 = new NoBullet();
            var defaultRunProperties128 = new DefaultRunProperties {FontSize = 1600, Bold = true};

            level5ParagraphProperties16.Append(noBullet64);
            level5ParagraphProperties16.Append(defaultRunProperties128);

            var level6ParagraphProperties13 = new Level6ParagraphProperties {LeftMargin = 2286000, Indent = 0};
            var noBullet65 = new NoBullet();
            var defaultRunProperties129 = new DefaultRunProperties {FontSize = 1600, Bold = true};

            level6ParagraphProperties13.Append(noBullet65);
            level6ParagraphProperties13.Append(defaultRunProperties129);

            var level7ParagraphProperties13 = new Level7ParagraphProperties {LeftMargin = 2743200, Indent = 0};
            var noBullet66 = new NoBullet();
            var defaultRunProperties130 = new DefaultRunProperties {FontSize = 1600, Bold = true};

            level7ParagraphProperties13.Append(noBullet66);
            level7ParagraphProperties13.Append(defaultRunProperties130);

            var level8ParagraphProperties13 = new Level8ParagraphProperties {LeftMargin = 3200400, Indent = 0};
            var noBullet67 = new NoBullet();
            var defaultRunProperties131 = new DefaultRunProperties {FontSize = 1600, Bold = true};

            level8ParagraphProperties13.Append(noBullet67);
            level8ParagraphProperties13.Append(defaultRunProperties131);

            var level9ParagraphProperties13 = new Level9ParagraphProperties {LeftMargin = 3657600, Indent = 0};
            var noBullet68 = new NoBullet();
            var defaultRunProperties132 = new DefaultRunProperties {FontSize = 1600, Bold = true};

            level9ParagraphProperties13.Append(noBullet68);
            level9ParagraphProperties13.Append(defaultRunProperties132);

            listStyle57.Append(level1ParagraphProperties22);
            listStyle57.Append(level2ParagraphProperties13);
            listStyle57.Append(level3ParagraphProperties13);
            listStyle57.Append(level4ParagraphProperties13);
            listStyle57.Append(level5ParagraphProperties16);
            listStyle57.Append(level6ParagraphProperties13);
            listStyle57.Append(level7ParagraphProperties13);
            listStyle57.Append(level8ParagraphProperties13);
            listStyle57.Append(level9ParagraphProperties13);

            var paragraph83 = new Paragraph();
            var paragraphProperties58 = new ParagraphProperties {Level = 0};

            var run54 = new Run();

            var runProperties72 = new RunProperties {Language = "en-US"};
            runProperties72.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text72 = new Text();
            text72.Text = "Click to edit Master text styles";

            run54.Append(runProperties72);
            run54.Append(text72);

            paragraph83.Append(paragraphProperties58);
            paragraph83.Append(run54);

            textBody55.Append(bodyProperties57);
            textBody55.Append(listStyle57);
            textBody55.Append(paragraph83);

            shape55.Append(nonVisualShapeProperties55);
            shape55.Append(shapeProperties57);
            shape55.Append(textBody55);

            var shape56 = new Shape();

            var nonVisualShapeProperties56 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties67 = new NonVisualDrawingProperties {Id = 6U, Name = "Content Placeholder 5"};

            var nonVisualShapeDrawingProperties56 = new NonVisualShapeDrawingProperties();
            var shapeLocks54 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties56.Append(shapeLocks54);

            var applicationNonVisualDrawingProperties67 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape53 = new PlaceholderShape {Size = PlaceholderSizeValues.Quarter, Index = 4U};

            applicationNonVisualDrawingProperties67.Append(placeholderShape53);

            nonVisualShapeProperties56.Append(nonVisualDrawingProperties67);
            nonVisualShapeProperties56.Append(nonVisualShapeDrawingProperties56);
            nonVisualShapeProperties56.Append(applicationNonVisualDrawingProperties67);

            var shapeProperties58 = new ShapeProperties();

            var transform2D28 = new Transform2D();
            var offset39 = new Offset {X = 4751070L, Y = 2347415L};
            var extents39 = new Extents {Cx = 3840480L, Cy = 3596185L};

            transform2D28.Append(offset39);
            transform2D28.Append(extents39);

            shapeProperties58.Append(transform2D28);

            var textBody56 = new TextBody();

            var bodyProperties58 = new BodyProperties();
            var normalAutoFit9 = new NormalAutoFit();

            bodyProperties58.Append(normalAutoFit9);

            var listStyle58 = new ListStyle();

            var level1ParagraphProperties23 = new Level1ParagraphProperties();

            var spaceBefore22 = new SpaceBefore();
            var spacingPoints15 = new SpacingPoints {Val = 1600};

            spaceBefore22.Append(spacingPoints15);
            var defaultRunProperties133 = new DefaultRunProperties {FontSize = 2000};

            level1ParagraphProperties23.Append(spaceBefore22);
            level1ParagraphProperties23.Append(defaultRunProperties133);

            var level2ParagraphProperties14 = new Level2ParagraphProperties();
            var defaultRunProperties134 = new DefaultRunProperties {FontSize = 1800};

            level2ParagraphProperties14.Append(defaultRunProperties134);

            var level3ParagraphProperties14 = new Level3ParagraphProperties();
            var defaultRunProperties135 = new DefaultRunProperties {FontSize = 1800};

            level3ParagraphProperties14.Append(defaultRunProperties135);

            var level4ParagraphProperties14 = new Level4ParagraphProperties();
            var defaultRunProperties136 = new DefaultRunProperties {FontSize = 1800};

            level4ParagraphProperties14.Append(defaultRunProperties136);

            var level5ParagraphProperties17 = new Level5ParagraphProperties();
            var defaultRunProperties137 = new DefaultRunProperties {FontSize = 1800};

            level5ParagraphProperties17.Append(defaultRunProperties137);

            var level6ParagraphProperties14 = new Level6ParagraphProperties();
            var defaultRunProperties138 = new DefaultRunProperties {FontSize = 1600};

            level6ParagraphProperties14.Append(defaultRunProperties138);

            var level7ParagraphProperties14 = new Level7ParagraphProperties();
            var defaultRunProperties139 = new DefaultRunProperties {FontSize = 1600};

            level7ParagraphProperties14.Append(defaultRunProperties139);

            var level8ParagraphProperties14 = new Level8ParagraphProperties();
            var defaultRunProperties140 = new DefaultRunProperties {FontSize = 1600};

            level8ParagraphProperties14.Append(defaultRunProperties140);

            var level9ParagraphProperties14 = new Level9ParagraphProperties();
            var defaultRunProperties141 = new DefaultRunProperties {FontSize = 1600};

            level9ParagraphProperties14.Append(defaultRunProperties141);

            listStyle58.Append(level1ParagraphProperties23);
            listStyle58.Append(level2ParagraphProperties14);
            listStyle58.Append(level3ParagraphProperties14);
            listStyle58.Append(level4ParagraphProperties14);
            listStyle58.Append(level5ParagraphProperties17);
            listStyle58.Append(level6ParagraphProperties14);
            listStyle58.Append(level7ParagraphProperties14);
            listStyle58.Append(level8ParagraphProperties14);
            listStyle58.Append(level9ParagraphProperties14);

            var paragraph84 = new Paragraph();
            var paragraphProperties59 = new ParagraphProperties {Level = 0};

            var run55 = new Run();

            var runProperties73 = new RunProperties {Language = "en-US"};
            runProperties73.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text73 = new Text();
            text73.Text = "Click to edit Master text styles";

            run55.Append(runProperties73);
            run55.Append(text73);

            paragraph84.Append(paragraphProperties59);
            paragraph84.Append(run55);

            var paragraph85 = new Paragraph();
            var paragraphProperties60 = new ParagraphProperties {Level = 1};

            var run56 = new Run();

            var runProperties74 = new RunProperties {Language = "en-US"};
            runProperties74.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text74 = new Text();
            text74.Text = "Second level";

            run56.Append(runProperties74);
            run56.Append(text74);

            paragraph85.Append(paragraphProperties60);
            paragraph85.Append(run56);

            var paragraph86 = new Paragraph();
            var paragraphProperties61 = new ParagraphProperties {Level = 2};

            var run57 = new Run();

            var runProperties75 = new RunProperties {Language = "en-US"};
            runProperties75.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text75 = new Text();
            text75.Text = "Third level";

            run57.Append(runProperties75);
            run57.Append(text75);

            paragraph86.Append(paragraphProperties61);
            paragraph86.Append(run57);

            var paragraph87 = new Paragraph();
            var paragraphProperties62 = new ParagraphProperties {Level = 3};

            var run58 = new Run();

            var runProperties76 = new RunProperties {Language = "en-US"};
            runProperties76.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text76 = new Text();
            text76.Text = "Fourth level";

            run58.Append(runProperties76);
            run58.Append(text76);

            paragraph87.Append(paragraphProperties62);
            paragraph87.Append(run58);

            var paragraph88 = new Paragraph();
            var paragraphProperties63 = new ParagraphProperties {Level = 4};

            var run59 = new Run();

            var runProperties77 = new RunProperties {Language = "en-US"};
            runProperties77.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text77 = new Text();
            text77.Text = "Fifth level";

            run59.Append(runProperties77);
            run59.Append(text77);
            var endParagraphRunProperties53 = new EndParagraphRunProperties {Dirty = false};

            paragraph88.Append(paragraphProperties63);
            paragraph88.Append(run59);
            paragraph88.Append(endParagraphRunProperties53);

            textBody56.Append(bodyProperties58);
            textBody56.Append(listStyle58);
            textBody56.Append(paragraph84);
            textBody56.Append(paragraph85);
            textBody56.Append(paragraph86);
            textBody56.Append(paragraph87);
            textBody56.Append(paragraph88);

            shape56.Append(nonVisualShapeProperties56);
            shape56.Append(shapeProperties58);
            shape56.Append(textBody56);

            var shape57 = new Shape();

            var nonVisualShapeProperties57 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties68 = new NonVisualDrawingProperties {Id = 7U, Name = "Date Placeholder 6"};

            var nonVisualShapeDrawingProperties57 = new NonVisualShapeDrawingProperties();
            var shapeLocks55 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties57.Append(shapeLocks55);

            var applicationNonVisualDrawingProperties68 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape54 = new PlaceholderShape
                {
                    Type = PlaceholderValues.DateAndTime,
                    Size = PlaceholderSizeValues.Half,
                    Index = 10U
                };

            applicationNonVisualDrawingProperties68.Append(placeholderShape54);

            nonVisualShapeProperties57.Append(nonVisualDrawingProperties68);
            nonVisualShapeProperties57.Append(nonVisualShapeDrawingProperties57);
            nonVisualShapeProperties57.Append(applicationNonVisualDrawingProperties68);
            var shapeProperties59 = new ShapeProperties();

            var textBody57 = new TextBody();
            var bodyProperties59 = new BodyProperties();
            var listStyle59 = new ListStyle();

            var paragraph89 = new Paragraph();

            var field19 = new Field {Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut"};

            var runProperties78 = new RunProperties {Language = "en-US"};
            runProperties78.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties64 = new ParagraphProperties();
            var text78 = new Text();
            text78.Text = "29/11/13";

            field19.Append(runProperties78);
            field19.Append(paragraphProperties64);
            field19.Append(text78);
            var endParagraphRunProperties54 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph89.Append(field19);
            paragraph89.Append(endParagraphRunProperties54);

            textBody57.Append(bodyProperties59);
            textBody57.Append(listStyle59);
            textBody57.Append(paragraph89);

            shape57.Append(nonVisualShapeProperties57);
            shape57.Append(shapeProperties59);
            shape57.Append(textBody57);

            var shape58 = new Shape();

            var nonVisualShapeProperties58 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties69 = new NonVisualDrawingProperties {Id = 8U, Name = "Footer Placeholder 7"};

            var nonVisualShapeDrawingProperties58 = new NonVisualShapeDrawingProperties();
            var shapeLocks56 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties58.Append(shapeLocks56);

            var applicationNonVisualDrawingProperties69 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape55 = new PlaceholderShape
                {
                    Type = PlaceholderValues.Footer,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 11U
                };

            applicationNonVisualDrawingProperties69.Append(placeholderShape55);

            nonVisualShapeProperties58.Append(nonVisualDrawingProperties69);
            nonVisualShapeProperties58.Append(nonVisualShapeDrawingProperties58);
            nonVisualShapeProperties58.Append(applicationNonVisualDrawingProperties69);
            var shapeProperties60 = new ShapeProperties();

            var textBody58 = new TextBody();
            var bodyProperties60 = new BodyProperties();
            var listStyle60 = new ListStyle();

            var paragraph90 = new Paragraph();
            var endParagraphRunProperties55 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph90.Append(endParagraphRunProperties55);

            textBody58.Append(bodyProperties60);
            textBody58.Append(listStyle60);
            textBody58.Append(paragraph90);

            shape58.Append(nonVisualShapeProperties58);
            shape58.Append(shapeProperties60);
            shape58.Append(textBody58);

            var shape59 = new Shape();

            var nonVisualShapeProperties59 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties70 = new NonVisualDrawingProperties
                {
                    Id = 9U,
                    Name = "Slide Number Placeholder 8"
                };

            var nonVisualShapeDrawingProperties59 = new NonVisualShapeDrawingProperties();
            var shapeLocks57 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties59.Append(shapeLocks57);

            var applicationNonVisualDrawingProperties70 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape56 = new PlaceholderShape
                {
                    Type = PlaceholderValues.SlideNumber,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 12U
                };

            applicationNonVisualDrawingProperties70.Append(placeholderShape56);

            nonVisualShapeProperties59.Append(nonVisualDrawingProperties70);
            nonVisualShapeProperties59.Append(nonVisualShapeDrawingProperties59);
            nonVisualShapeProperties59.Append(applicationNonVisualDrawingProperties70);
            var shapeProperties61 = new ShapeProperties();

            var textBody59 = new TextBody();
            var bodyProperties61 = new BodyProperties();
            var listStyle61 = new ListStyle();

            var paragraph91 = new Paragraph();

            var field20 = new Field {Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum"};

            var runProperties79 = new RunProperties {Language = "en-US"};
            runProperties79.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties65 = new ParagraphProperties();
            var text79 = new Text();
            text79.Text = "‹#›";

            field20.Append(runProperties79);
            field20.Append(paragraphProperties65);
            field20.Append(text79);
            var endParagraphRunProperties56 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph91.Append(field20);
            paragraph91.Append(endParagraphRunProperties56);

            textBody59.Append(bodyProperties61);
            textBody59.Append(listStyle61);
            textBody59.Append(paragraph91);

            shape59.Append(nonVisualShapeProperties59);
            shape59.Append(shapeProperties61);
            shape59.Append(textBody59);

            shapeTree11.Append(nonVisualGroupShapeProperties11);
            shapeTree11.Append(groupShapeProperties11);
            shapeTree11.Append(shape52);
            shapeTree11.Append(shape53);
            shapeTree11.Append(shape54);
            shapeTree11.Append(shape55);
            shapeTree11.Append(shape56);
            shapeTree11.Append(shape57);
            shapeTree11.Append(shape58);
            shapeTree11.Append(shape59);

            commonSlideData11.Append(shapeTree11);

            var colorMapOverride10 = new ColorMapOverride();
            var masterColorMapping10 = new MasterColorMapping();

            colorMapOverride10.Append(masterColorMapping10);

            slideLayout9.Append(commonSlideData11);
            slideLayout9.Append(colorMapOverride10);

            slideLayoutPart9.SlideLayout = slideLayout9;
        }

        // Generates content of slideLayoutPart10.
        private void GenerateSlideLayoutPart10Content(SlideLayoutPart slideLayoutPart10)
        {
            var slideLayout10 = new SlideLayout {Type = SlideLayoutValues.TitleOnly, Preserve = true};
            slideLayout10.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout10.AddNamespaceDeclaration("r",
                                                  "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout10.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            var commonSlideData12 = new CommonSlideData {Name = "Title Only"};

            var shapeTree12 = new ShapeTree();

            var nonVisualGroupShapeProperties12 = new NonVisualGroupShapeProperties();
            var nonVisualDrawingProperties71 = new NonVisualDrawingProperties {Id = 1U, Name = ""};
            var nonVisualGroupShapeDrawingProperties12 = new NonVisualGroupShapeDrawingProperties();
            var applicationNonVisualDrawingProperties71 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties12.Append(nonVisualDrawingProperties71);
            nonVisualGroupShapeProperties12.Append(nonVisualGroupShapeDrawingProperties12);
            nonVisualGroupShapeProperties12.Append(applicationNonVisualDrawingProperties71);

            var groupShapeProperties12 = new GroupShapeProperties();

            var transformGroup12 = new TransformGroup();
            var offset40 = new Offset {X = 0L, Y = 0L};
            var extents40 = new Extents {Cx = 0L, Cy = 0L};
            var childOffset12 = new ChildOffset {X = 0L, Y = 0L};
            var childExtents12 = new ChildExtents {Cx = 0L, Cy = 0L};

            transformGroup12.Append(offset40);
            transformGroup12.Append(extents40);
            transformGroup12.Append(childOffset12);
            transformGroup12.Append(childExtents12);

            groupShapeProperties12.Append(transformGroup12);

            var shape60 = new Shape();

            var nonVisualShapeProperties60 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties72 = new NonVisualDrawingProperties {Id = 2U, Name = "Title 1"};

            var nonVisualShapeDrawingProperties60 = new NonVisualShapeDrawingProperties();
            var shapeLocks58 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties60.Append(shapeLocks58);

            var applicationNonVisualDrawingProperties72 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape57 = new PlaceholderShape {Type = PlaceholderValues.Title};

            applicationNonVisualDrawingProperties72.Append(placeholderShape57);

            nonVisualShapeProperties60.Append(nonVisualDrawingProperties72);
            nonVisualShapeProperties60.Append(nonVisualShapeDrawingProperties60);
            nonVisualShapeProperties60.Append(applicationNonVisualDrawingProperties72);
            var shapeProperties62 = new ShapeProperties();

            var textBody60 = new TextBody();
            var bodyProperties62 = new BodyProperties();
            var listStyle62 = new ListStyle();

            var paragraph92 = new Paragraph();

            var run60 = new Run();

            var runProperties80 = new RunProperties {Language = "en-US"};
            runProperties80.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text80 = new Text();
            text80.Text = "Click to edit Master title style";

            run60.Append(runProperties80);
            run60.Append(text80);
            var endParagraphRunProperties57 = new EndParagraphRunProperties();

            paragraph92.Append(run60);
            paragraph92.Append(endParagraphRunProperties57);

            textBody60.Append(bodyProperties62);
            textBody60.Append(listStyle62);
            textBody60.Append(paragraph92);

            shape60.Append(nonVisualShapeProperties60);
            shape60.Append(shapeProperties62);
            shape60.Append(textBody60);

            var shape61 = new Shape();

            var nonVisualShapeProperties61 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties73 = new NonVisualDrawingProperties {Id = 3U, Name = "Date Placeholder 2"};

            var nonVisualShapeDrawingProperties61 = new NonVisualShapeDrawingProperties();
            var shapeLocks59 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties61.Append(shapeLocks59);

            var applicationNonVisualDrawingProperties73 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape58 = new PlaceholderShape
                {
                    Type = PlaceholderValues.DateAndTime,
                    Size = PlaceholderSizeValues.Half,
                    Index = 10U
                };

            applicationNonVisualDrawingProperties73.Append(placeholderShape58);

            nonVisualShapeProperties61.Append(nonVisualDrawingProperties73);
            nonVisualShapeProperties61.Append(nonVisualShapeDrawingProperties61);
            nonVisualShapeProperties61.Append(applicationNonVisualDrawingProperties73);
            var shapeProperties63 = new ShapeProperties();

            var textBody61 = new TextBody();
            var bodyProperties63 = new BodyProperties();
            var listStyle63 = new ListStyle();

            var paragraph93 = new Paragraph();

            var field21 = new Field {Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut"};

            var runProperties81 = new RunProperties {Language = "en-US"};
            runProperties81.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties66 = new ParagraphProperties();
            var text81 = new Text();
            text81.Text = "29/11/13";

            field21.Append(runProperties81);
            field21.Append(paragraphProperties66);
            field21.Append(text81);
            var endParagraphRunProperties58 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph93.Append(field21);
            paragraph93.Append(endParagraphRunProperties58);

            textBody61.Append(bodyProperties63);
            textBody61.Append(listStyle63);
            textBody61.Append(paragraph93);

            shape61.Append(nonVisualShapeProperties61);
            shape61.Append(shapeProperties63);
            shape61.Append(textBody61);

            var shape62 = new Shape();

            var nonVisualShapeProperties62 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties74 = new NonVisualDrawingProperties {Id = 4U, Name = "Footer Placeholder 3"};

            var nonVisualShapeDrawingProperties62 = new NonVisualShapeDrawingProperties();
            var shapeLocks60 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties62.Append(shapeLocks60);

            var applicationNonVisualDrawingProperties74 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape59 = new PlaceholderShape
                {
                    Type = PlaceholderValues.Footer,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 11U
                };

            applicationNonVisualDrawingProperties74.Append(placeholderShape59);

            nonVisualShapeProperties62.Append(nonVisualDrawingProperties74);
            nonVisualShapeProperties62.Append(nonVisualShapeDrawingProperties62);
            nonVisualShapeProperties62.Append(applicationNonVisualDrawingProperties74);
            var shapeProperties64 = new ShapeProperties();

            var textBody62 = new TextBody();
            var bodyProperties64 = new BodyProperties();
            var listStyle64 = new ListStyle();

            var paragraph94 = new Paragraph();
            var endParagraphRunProperties59 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph94.Append(endParagraphRunProperties59);

            textBody62.Append(bodyProperties64);
            textBody62.Append(listStyle64);
            textBody62.Append(paragraph94);

            shape62.Append(nonVisualShapeProperties62);
            shape62.Append(shapeProperties64);
            shape62.Append(textBody62);

            var shape63 = new Shape();

            var nonVisualShapeProperties63 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties75 = new NonVisualDrawingProperties
                {
                    Id = 5U,
                    Name = "Slide Number Placeholder 4"
                };

            var nonVisualShapeDrawingProperties63 = new NonVisualShapeDrawingProperties();
            var shapeLocks61 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties63.Append(shapeLocks61);

            var applicationNonVisualDrawingProperties75 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape60 = new PlaceholderShape
                {
                    Type = PlaceholderValues.SlideNumber,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 12U
                };

            applicationNonVisualDrawingProperties75.Append(placeholderShape60);

            nonVisualShapeProperties63.Append(nonVisualDrawingProperties75);
            nonVisualShapeProperties63.Append(nonVisualShapeDrawingProperties63);
            nonVisualShapeProperties63.Append(applicationNonVisualDrawingProperties75);
            var shapeProperties65 = new ShapeProperties();

            var textBody63 = new TextBody();
            var bodyProperties65 = new BodyProperties();
            var listStyle65 = new ListStyle();

            var paragraph95 = new Paragraph();

            var field22 = new Field {Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum"};

            var runProperties82 = new RunProperties {Language = "en-US"};
            runProperties82.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties67 = new ParagraphProperties();
            var text82 = new Text();
            text82.Text = "‹#›";

            field22.Append(runProperties82);
            field22.Append(paragraphProperties67);
            field22.Append(text82);
            var endParagraphRunProperties60 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph95.Append(field22);
            paragraph95.Append(endParagraphRunProperties60);

            textBody63.Append(bodyProperties65);
            textBody63.Append(listStyle65);
            textBody63.Append(paragraph95);

            shape63.Append(nonVisualShapeProperties63);
            shape63.Append(shapeProperties65);
            shape63.Append(textBody63);

            shapeTree12.Append(nonVisualGroupShapeProperties12);
            shapeTree12.Append(groupShapeProperties12);
            shapeTree12.Append(shape60);
            shapeTree12.Append(shape61);
            shapeTree12.Append(shape62);
            shapeTree12.Append(shape63);

            commonSlideData12.Append(shapeTree12);

            var colorMapOverride11 = new ColorMapOverride();
            var masterColorMapping11 = new MasterColorMapping();

            colorMapOverride11.Append(masterColorMapping11);

            slideLayout10.Append(commonSlideData12);
            slideLayout10.Append(colorMapOverride11);

            slideLayoutPart10.SlideLayout = slideLayout10;
        }

        // Generates content of slideLayoutPart11.
        private void GenerateSlideLayoutPart11Content(SlideLayoutPart slideLayoutPart11)
        {
            var slideLayout11 = new SlideLayout {Type = SlideLayoutValues.Blank, Preserve = true};
            slideLayout11.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout11.AddNamespaceDeclaration("r",
                                                  "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout11.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            var commonSlideData13 = new CommonSlideData {Name = "Blank"};

            var shapeTree13 = new ShapeTree();

            var nonVisualGroupShapeProperties13 = new NonVisualGroupShapeProperties();
            var nonVisualDrawingProperties76 = new NonVisualDrawingProperties {Id = 1U, Name = ""};
            var nonVisualGroupShapeDrawingProperties13 = new NonVisualGroupShapeDrawingProperties();
            var applicationNonVisualDrawingProperties76 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties13.Append(nonVisualDrawingProperties76);
            nonVisualGroupShapeProperties13.Append(nonVisualGroupShapeDrawingProperties13);
            nonVisualGroupShapeProperties13.Append(applicationNonVisualDrawingProperties76);

            var groupShapeProperties13 = new GroupShapeProperties();

            var transformGroup13 = new TransformGroup();
            var offset41 = new Offset {X = 0L, Y = 0L};
            var extents41 = new Extents {Cx = 0L, Cy = 0L};
            var childOffset13 = new ChildOffset {X = 0L, Y = 0L};
            var childExtents13 = new ChildExtents {Cx = 0L, Cy = 0L};

            transformGroup13.Append(offset41);
            transformGroup13.Append(extents41);
            transformGroup13.Append(childOffset13);
            transformGroup13.Append(childExtents13);

            groupShapeProperties13.Append(transformGroup13);

            var shape64 = new Shape();

            var nonVisualShapeProperties64 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties77 = new NonVisualDrawingProperties {Id = 2U, Name = "Date Placeholder 1"};

            var nonVisualShapeDrawingProperties64 = new NonVisualShapeDrawingProperties();
            var shapeLocks62 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties64.Append(shapeLocks62);

            var applicationNonVisualDrawingProperties77 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape61 = new PlaceholderShape
                {
                    Type = PlaceholderValues.DateAndTime,
                    Size = PlaceholderSizeValues.Half,
                    Index = 10U
                };

            applicationNonVisualDrawingProperties77.Append(placeholderShape61);

            nonVisualShapeProperties64.Append(nonVisualDrawingProperties77);
            nonVisualShapeProperties64.Append(nonVisualShapeDrawingProperties64);
            nonVisualShapeProperties64.Append(applicationNonVisualDrawingProperties77);
            var shapeProperties66 = new ShapeProperties();

            var textBody64 = new TextBody();
            var bodyProperties66 = new BodyProperties();
            var listStyle66 = new ListStyle();

            var paragraph96 = new Paragraph();

            var field23 = new Field {Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut"};

            var runProperties83 = new RunProperties {Language = "en-US"};
            runProperties83.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties68 = new ParagraphProperties();
            var text83 = new Text();
            text83.Text = "29/11/13";

            field23.Append(runProperties83);
            field23.Append(paragraphProperties68);
            field23.Append(text83);
            var endParagraphRunProperties61 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph96.Append(field23);
            paragraph96.Append(endParagraphRunProperties61);

            textBody64.Append(bodyProperties66);
            textBody64.Append(listStyle66);
            textBody64.Append(paragraph96);

            shape64.Append(nonVisualShapeProperties64);
            shape64.Append(shapeProperties66);
            shape64.Append(textBody64);

            var shape65 = new Shape();

            var nonVisualShapeProperties65 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties78 = new NonVisualDrawingProperties {Id = 3U, Name = "Footer Placeholder 2"};

            var nonVisualShapeDrawingProperties65 = new NonVisualShapeDrawingProperties();
            var shapeLocks63 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties65.Append(shapeLocks63);

            var applicationNonVisualDrawingProperties78 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape62 = new PlaceholderShape
                {
                    Type = PlaceholderValues.Footer,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 11U
                };

            applicationNonVisualDrawingProperties78.Append(placeholderShape62);

            nonVisualShapeProperties65.Append(nonVisualDrawingProperties78);
            nonVisualShapeProperties65.Append(nonVisualShapeDrawingProperties65);
            nonVisualShapeProperties65.Append(applicationNonVisualDrawingProperties78);
            var shapeProperties67 = new ShapeProperties();

            var textBody65 = new TextBody();
            var bodyProperties67 = new BodyProperties();
            var listStyle67 = new ListStyle();

            var paragraph97 = new Paragraph();
            var endParagraphRunProperties62 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph97.Append(endParagraphRunProperties62);

            textBody65.Append(bodyProperties67);
            textBody65.Append(listStyle67);
            textBody65.Append(paragraph97);

            shape65.Append(nonVisualShapeProperties65);
            shape65.Append(shapeProperties67);
            shape65.Append(textBody65);

            var shape66 = new Shape();

            var nonVisualShapeProperties66 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties79 = new NonVisualDrawingProperties
                {
                    Id = 4U,
                    Name = "Slide Number Placeholder 3"
                };

            var nonVisualShapeDrawingProperties66 = new NonVisualShapeDrawingProperties();
            var shapeLocks64 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties66.Append(shapeLocks64);

            var applicationNonVisualDrawingProperties79 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape63 = new PlaceholderShape
                {
                    Type = PlaceholderValues.SlideNumber,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 12U
                };

            applicationNonVisualDrawingProperties79.Append(placeholderShape63);

            nonVisualShapeProperties66.Append(nonVisualDrawingProperties79);
            nonVisualShapeProperties66.Append(nonVisualShapeDrawingProperties66);
            nonVisualShapeProperties66.Append(applicationNonVisualDrawingProperties79);
            var shapeProperties68 = new ShapeProperties();

            var textBody66 = new TextBody();
            var bodyProperties68 = new BodyProperties();
            var listStyle68 = new ListStyle();

            var paragraph98 = new Paragraph();

            var field24 = new Field {Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum"};

            var runProperties84 = new RunProperties {Language = "en-US"};
            runProperties84.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties69 = new ParagraphProperties();
            var text84 = new Text();
            text84.Text = "‹#›";

            field24.Append(runProperties84);
            field24.Append(paragraphProperties69);
            field24.Append(text84);
            var endParagraphRunProperties63 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph98.Append(field24);
            paragraph98.Append(endParagraphRunProperties63);

            textBody66.Append(bodyProperties68);
            textBody66.Append(listStyle68);
            textBody66.Append(paragraph98);

            shape66.Append(nonVisualShapeProperties66);
            shape66.Append(shapeProperties68);
            shape66.Append(textBody66);

            shapeTree13.Append(nonVisualGroupShapeProperties13);
            shapeTree13.Append(groupShapeProperties13);
            shapeTree13.Append(shape64);
            shapeTree13.Append(shape65);
            shapeTree13.Append(shape66);

            commonSlideData13.Append(shapeTree13);

            var colorMapOverride12 = new ColorMapOverride();
            var masterColorMapping12 = new MasterColorMapping();

            colorMapOverride12.Append(masterColorMapping12);

            slideLayout11.Append(commonSlideData13);
            slideLayout11.Append(colorMapOverride12);

            slideLayoutPart11.SlideLayout = slideLayout11;
        }

        // Generates content of slideLayoutPart12.
        private void GenerateSlideLayoutPart12Content(SlideLayoutPart slideLayoutPart12)
        {
            var slideLayout12 = new SlideLayout {Type = SlideLayoutValues.ObjectText, Preserve = true};
            slideLayout12.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout12.AddNamespaceDeclaration("r",
                                                  "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout12.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            var commonSlideData14 = new CommonSlideData {Name = "Content with Caption"};

            var shapeTree14 = new ShapeTree();

            var nonVisualGroupShapeProperties14 = new NonVisualGroupShapeProperties();
            var nonVisualDrawingProperties80 = new NonVisualDrawingProperties {Id = 1U, Name = ""};
            var nonVisualGroupShapeDrawingProperties14 = new NonVisualGroupShapeDrawingProperties();
            var applicationNonVisualDrawingProperties80 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties14.Append(nonVisualDrawingProperties80);
            nonVisualGroupShapeProperties14.Append(nonVisualGroupShapeDrawingProperties14);
            nonVisualGroupShapeProperties14.Append(applicationNonVisualDrawingProperties80);

            var groupShapeProperties14 = new GroupShapeProperties();

            var transformGroup14 = new TransformGroup();
            var offset42 = new Offset {X = 0L, Y = 0L};
            var extents42 = new Extents {Cx = 0L, Cy = 0L};
            var childOffset14 = new ChildOffset {X = 0L, Y = 0L};
            var childExtents14 = new ChildExtents {Cx = 0L, Cy = 0L};

            transformGroup14.Append(offset42);
            transformGroup14.Append(extents42);
            transformGroup14.Append(childOffset14);
            transformGroup14.Append(childExtents14);

            groupShapeProperties14.Append(transformGroup14);

            var shape67 = new Shape();

            var nonVisualShapeProperties67 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties81 = new NonVisualDrawingProperties {Id = 2U, Name = "Title 1"};

            var nonVisualShapeDrawingProperties67 = new NonVisualShapeDrawingProperties();
            var shapeLocks65 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties67.Append(shapeLocks65);

            var applicationNonVisualDrawingProperties81 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape64 = new PlaceholderShape {Type = PlaceholderValues.Title};

            applicationNonVisualDrawingProperties81.Append(placeholderShape64);

            nonVisualShapeProperties67.Append(nonVisualDrawingProperties81);
            nonVisualShapeProperties67.Append(nonVisualShapeDrawingProperties67);
            nonVisualShapeProperties67.Append(applicationNonVisualDrawingProperties81);

            var shapeProperties69 = new ShapeProperties();

            var transform2D29 = new Transform2D();
            var offset43 = new Offset {X = 533399L, Y = 611872L};
            var extents43 = new Extents {Cx = 3840480L, Cy = 1162050L};

            transform2D29.Append(offset43);
            transform2D29.Append(extents43);

            shapeProperties69.Append(transform2D29);

            var textBody67 = new TextBody();
            var bodyProperties69 = new BodyProperties {Anchor = TextAnchoringTypeValues.Bottom};

            var listStyle69 = new ListStyle();

            var level1ParagraphProperties24 = new Level1ParagraphProperties {Alignment = TextAlignmentTypeValues.Center};
            var defaultRunProperties142 = new DefaultRunProperties {FontSize = 3600, Bold = false};

            level1ParagraphProperties24.Append(defaultRunProperties142);

            listStyle69.Append(level1ParagraphProperties24);

            var paragraph99 = new Paragraph();

            var run61 = new Run();

            var runProperties85 = new RunProperties {Language = "en-US"};
            runProperties85.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text85 = new Text();
            text85.Text = "Click to edit Master title style";

            run61.Append(runProperties85);
            run61.Append(text85);
            var endParagraphRunProperties64 = new EndParagraphRunProperties();

            paragraph99.Append(run61);
            paragraph99.Append(endParagraphRunProperties64);

            textBody67.Append(bodyProperties69);
            textBody67.Append(listStyle69);
            textBody67.Append(paragraph99);

            shape67.Append(nonVisualShapeProperties67);
            shape67.Append(shapeProperties69);
            shape67.Append(textBody67);

            var shape68 = new Shape();

            var nonVisualShapeProperties68 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties82 = new NonVisualDrawingProperties {Id = 3U, Name = "Content Placeholder 2"};

            var nonVisualShapeDrawingProperties68 = new NonVisualShapeDrawingProperties();
            var shapeLocks66 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties68.Append(shapeLocks66);

            var applicationNonVisualDrawingProperties82 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape65 = new PlaceholderShape {Index = 1U};

            applicationNonVisualDrawingProperties82.Append(placeholderShape65);

            nonVisualShapeProperties68.Append(nonVisualDrawingProperties82);
            nonVisualShapeProperties68.Append(nonVisualShapeDrawingProperties68);
            nonVisualShapeProperties68.Append(applicationNonVisualDrawingProperties82);

            var shapeProperties70 = new ShapeProperties();

            var transform2D30 = new Transform2D();
            var offset44 = new Offset {X = 4742824L, Y = 368300L};
            var extents44 = new Extents {Cx = 3840480L, Cy = 5575300L};

            transform2D30.Append(offset44);
            transform2D30.Append(extents44);

            shapeProperties70.Append(transform2D30);

            var textBody68 = new TextBody();

            var bodyProperties70 = new BodyProperties();
            var normalAutoFit10 = new NormalAutoFit();

            bodyProperties70.Append(normalAutoFit10);

            var listStyle70 = new ListStyle();

            var level1ParagraphProperties25 = new Level1ParagraphProperties();

            var spaceBefore23 = new SpaceBefore();
            var spacingPoints16 = new SpacingPoints {Val = 2000};

            spaceBefore23.Append(spacingPoints16);
            var defaultRunProperties143 = new DefaultRunProperties {FontSize = 2200};

            level1ParagraphProperties25.Append(spaceBefore23);
            level1ParagraphProperties25.Append(defaultRunProperties143);

            var level2ParagraphProperties15 = new Level2ParagraphProperties();
            var defaultRunProperties144 = new DefaultRunProperties {FontSize = 2000};

            level2ParagraphProperties15.Append(defaultRunProperties144);

            var level3ParagraphProperties15 = new Level3ParagraphProperties();
            var defaultRunProperties145 = new DefaultRunProperties {FontSize = 1800};

            level3ParagraphProperties15.Append(defaultRunProperties145);

            var level4ParagraphProperties15 = new Level4ParagraphProperties();
            var defaultRunProperties146 = new DefaultRunProperties {FontSize = 1800};

            level4ParagraphProperties15.Append(defaultRunProperties146);

            var level5ParagraphProperties18 = new Level5ParagraphProperties();
            var defaultRunProperties147 = new DefaultRunProperties {FontSize = 1800};

            level5ParagraphProperties18.Append(defaultRunProperties147);

            var level6ParagraphProperties15 = new Level6ParagraphProperties();
            var defaultRunProperties148 = new DefaultRunProperties {FontSize = 2000};

            level6ParagraphProperties15.Append(defaultRunProperties148);

            var level7ParagraphProperties15 = new Level7ParagraphProperties();
            var defaultRunProperties149 = new DefaultRunProperties {FontSize = 2000};

            level7ParagraphProperties15.Append(defaultRunProperties149);

            var level8ParagraphProperties15 = new Level8ParagraphProperties();
            var defaultRunProperties150 = new DefaultRunProperties {FontSize = 2000};

            level8ParagraphProperties15.Append(defaultRunProperties150);

            var level9ParagraphProperties15 = new Level9ParagraphProperties();
            var defaultRunProperties151 = new DefaultRunProperties {FontSize = 2000};

            level9ParagraphProperties15.Append(defaultRunProperties151);

            listStyle70.Append(level1ParagraphProperties25);
            listStyle70.Append(level2ParagraphProperties15);
            listStyle70.Append(level3ParagraphProperties15);
            listStyle70.Append(level4ParagraphProperties15);
            listStyle70.Append(level5ParagraphProperties18);
            listStyle70.Append(level6ParagraphProperties15);
            listStyle70.Append(level7ParagraphProperties15);
            listStyle70.Append(level8ParagraphProperties15);
            listStyle70.Append(level9ParagraphProperties15);

            var paragraph100 = new Paragraph();
            var paragraphProperties70 = new ParagraphProperties {Level = 0};

            var run62 = new Run();

            var runProperties86 = new RunProperties {Language = "en-US"};
            runProperties86.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text86 = new Text();
            text86.Text = "Click to edit Master text styles";

            run62.Append(runProperties86);
            run62.Append(text86);

            paragraph100.Append(paragraphProperties70);
            paragraph100.Append(run62);

            var paragraph101 = new Paragraph();
            var paragraphProperties71 = new ParagraphProperties {Level = 1};

            var run63 = new Run();

            var runProperties87 = new RunProperties {Language = "en-US"};
            runProperties87.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text87 = new Text();
            text87.Text = "Second level";

            run63.Append(runProperties87);
            run63.Append(text87);

            paragraph101.Append(paragraphProperties71);
            paragraph101.Append(run63);

            var paragraph102 = new Paragraph();
            var paragraphProperties72 = new ParagraphProperties {Level = 2};

            var run64 = new Run();

            var runProperties88 = new RunProperties {Language = "en-US"};
            runProperties88.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text88 = new Text();
            text88.Text = "Third level";

            run64.Append(runProperties88);
            run64.Append(text88);

            paragraph102.Append(paragraphProperties72);
            paragraph102.Append(run64);

            var paragraph103 = new Paragraph();
            var paragraphProperties73 = new ParagraphProperties {Level = 3};

            var run65 = new Run();

            var runProperties89 = new RunProperties {Language = "en-US"};
            runProperties89.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text89 = new Text();
            text89.Text = "Fourth level";

            run65.Append(runProperties89);
            run65.Append(text89);

            paragraph103.Append(paragraphProperties73);
            paragraph103.Append(run65);

            var paragraph104 = new Paragraph();
            var paragraphProperties74 = new ParagraphProperties {Level = 4};

            var run66 = new Run();

            var runProperties90 = new RunProperties {Language = "en-US"};
            runProperties90.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text90 = new Text();
            text90.Text = "Fifth level";

            run66.Append(runProperties90);
            run66.Append(text90);
            var endParagraphRunProperties65 = new EndParagraphRunProperties {Dirty = false};

            paragraph104.Append(paragraphProperties74);
            paragraph104.Append(run66);
            paragraph104.Append(endParagraphRunProperties65);

            textBody68.Append(bodyProperties70);
            textBody68.Append(listStyle70);
            textBody68.Append(paragraph100);
            textBody68.Append(paragraph101);
            textBody68.Append(paragraph102);
            textBody68.Append(paragraph103);
            textBody68.Append(paragraph104);

            shape68.Append(nonVisualShapeProperties68);
            shape68.Append(shapeProperties70);
            shape68.Append(textBody68);

            var shape69 = new Shape();

            var nonVisualShapeProperties69 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties83 = new NonVisualDrawingProperties {Id = 4U, Name = "Text Placeholder 3"};

            var nonVisualShapeDrawingProperties69 = new NonVisualShapeDrawingProperties();
            var shapeLocks67 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties69.Append(shapeLocks67);

            var applicationNonVisualDrawingProperties83 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape66 = new PlaceholderShape
                {
                    Type = PlaceholderValues.Body,
                    Size = PlaceholderSizeValues.Half,
                    Index = 2U
                };

            applicationNonVisualDrawingProperties83.Append(placeholderShape66);

            nonVisualShapeProperties69.Append(nonVisualDrawingProperties83);
            nonVisualShapeProperties69.Append(nonVisualShapeDrawingProperties69);
            nonVisualShapeProperties69.Append(applicationNonVisualDrawingProperties83);

            var shapeProperties71 = new ShapeProperties();

            var transform2D31 = new Transform2D();
            var offset45 = new Offset {X = 533399L, Y = 1787856L};
            var extents45 = new Extents {Cx = 3840480L, Cy = 3720152L};

            transform2D31.Append(offset45);
            transform2D31.Append(extents45);

            shapeProperties71.Append(transform2D31);

            var textBody69 = new TextBody();

            var bodyProperties71 = new BodyProperties();
            var normalAutoFit11 = new NormalAutoFit();

            bodyProperties71.Append(normalAutoFit11);

            var listStyle71 = new ListStyle();

            var level1ParagraphProperties26 = new Level1ParagraphProperties
                {
                    LeftMargin = 0,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };

            var spaceBefore24 = new SpaceBefore();
            var spacingPoints17 = new SpacingPoints {Val = 600};

            spaceBefore24.Append(spacingPoints17);
            var noBullet69 = new NoBullet();
            var defaultRunProperties152 = new DefaultRunProperties {FontSize = 1800};

            level1ParagraphProperties26.Append(spaceBefore24);
            level1ParagraphProperties26.Append(noBullet69);
            level1ParagraphProperties26.Append(defaultRunProperties152);

            var level2ParagraphProperties16 = new Level2ParagraphProperties {LeftMargin = 457200, Indent = 0};
            var noBullet70 = new NoBullet();
            var defaultRunProperties153 = new DefaultRunProperties {FontSize = 1200};

            level2ParagraphProperties16.Append(noBullet70);
            level2ParagraphProperties16.Append(defaultRunProperties153);

            var level3ParagraphProperties16 = new Level3ParagraphProperties {LeftMargin = 914400, Indent = 0};
            var noBullet71 = new NoBullet();
            var defaultRunProperties154 = new DefaultRunProperties {FontSize = 1000};

            level3ParagraphProperties16.Append(noBullet71);
            level3ParagraphProperties16.Append(defaultRunProperties154);

            var level4ParagraphProperties16 = new Level4ParagraphProperties {LeftMargin = 1371600, Indent = 0};
            var noBullet72 = new NoBullet();
            var defaultRunProperties155 = new DefaultRunProperties {FontSize = 900};

            level4ParagraphProperties16.Append(noBullet72);
            level4ParagraphProperties16.Append(defaultRunProperties155);

            var level5ParagraphProperties19 = new Level5ParagraphProperties {LeftMargin = 1828800, Indent = 0};
            var noBullet73 = new NoBullet();
            var defaultRunProperties156 = new DefaultRunProperties {FontSize = 900};

            level5ParagraphProperties19.Append(noBullet73);
            level5ParagraphProperties19.Append(defaultRunProperties156);

            var level6ParagraphProperties16 = new Level6ParagraphProperties {LeftMargin = 2286000, Indent = 0};
            var noBullet74 = new NoBullet();
            var defaultRunProperties157 = new DefaultRunProperties {FontSize = 900};

            level6ParagraphProperties16.Append(noBullet74);
            level6ParagraphProperties16.Append(defaultRunProperties157);

            var level7ParagraphProperties16 = new Level7ParagraphProperties {LeftMargin = 2743200, Indent = 0};
            var noBullet75 = new NoBullet();
            var defaultRunProperties158 = new DefaultRunProperties {FontSize = 900};

            level7ParagraphProperties16.Append(noBullet75);
            level7ParagraphProperties16.Append(defaultRunProperties158);

            var level8ParagraphProperties16 = new Level8ParagraphProperties {LeftMargin = 3200400, Indent = 0};
            var noBullet76 = new NoBullet();
            var defaultRunProperties159 = new DefaultRunProperties {FontSize = 900};

            level8ParagraphProperties16.Append(noBullet76);
            level8ParagraphProperties16.Append(defaultRunProperties159);

            var level9ParagraphProperties16 = new Level9ParagraphProperties {LeftMargin = 3657600, Indent = 0};
            var noBullet77 = new NoBullet();
            var defaultRunProperties160 = new DefaultRunProperties {FontSize = 900};

            level9ParagraphProperties16.Append(noBullet77);
            level9ParagraphProperties16.Append(defaultRunProperties160);

            listStyle71.Append(level1ParagraphProperties26);
            listStyle71.Append(level2ParagraphProperties16);
            listStyle71.Append(level3ParagraphProperties16);
            listStyle71.Append(level4ParagraphProperties16);
            listStyle71.Append(level5ParagraphProperties19);
            listStyle71.Append(level6ParagraphProperties16);
            listStyle71.Append(level7ParagraphProperties16);
            listStyle71.Append(level8ParagraphProperties16);
            listStyle71.Append(level9ParagraphProperties16);

            var paragraph105 = new Paragraph();
            var paragraphProperties75 = new ParagraphProperties {Level = 0};

            var run67 = new Run();

            var runProperties91 = new RunProperties {Language = "en-US"};
            runProperties91.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text91 = new Text();
            text91.Text = "Click to edit Master text styles";

            run67.Append(runProperties91);
            run67.Append(text91);

            paragraph105.Append(paragraphProperties75);
            paragraph105.Append(run67);

            textBody69.Append(bodyProperties71);
            textBody69.Append(listStyle71);
            textBody69.Append(paragraph105);

            shape69.Append(nonVisualShapeProperties69);
            shape69.Append(shapeProperties71);
            shape69.Append(textBody69);

            var shape70 = new Shape();

            var nonVisualShapeProperties70 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties84 = new NonVisualDrawingProperties {Id = 5U, Name = "Date Placeholder 4"};

            var nonVisualShapeDrawingProperties70 = new NonVisualShapeDrawingProperties();
            var shapeLocks68 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties70.Append(shapeLocks68);

            var applicationNonVisualDrawingProperties84 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape67 = new PlaceholderShape
                {
                    Type = PlaceholderValues.DateAndTime,
                    Size = PlaceholderSizeValues.Half,
                    Index = 10U
                };

            applicationNonVisualDrawingProperties84.Append(placeholderShape67);

            nonVisualShapeProperties70.Append(nonVisualDrawingProperties84);
            nonVisualShapeProperties70.Append(nonVisualShapeDrawingProperties70);
            nonVisualShapeProperties70.Append(applicationNonVisualDrawingProperties84);
            var shapeProperties72 = new ShapeProperties();

            var textBody70 = new TextBody();
            var bodyProperties72 = new BodyProperties();
            var listStyle72 = new ListStyle();

            var paragraph106 = new Paragraph();

            var field25 = new Field {Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut"};

            var runProperties92 = new RunProperties {Language = "en-US"};
            runProperties92.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties76 = new ParagraphProperties();
            var text92 = new Text();
            text92.Text = "29/11/13";

            field25.Append(runProperties92);
            field25.Append(paragraphProperties76);
            field25.Append(text92);
            var endParagraphRunProperties66 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph106.Append(field25);
            paragraph106.Append(endParagraphRunProperties66);

            textBody70.Append(bodyProperties72);
            textBody70.Append(listStyle72);
            textBody70.Append(paragraph106);

            shape70.Append(nonVisualShapeProperties70);
            shape70.Append(shapeProperties72);
            shape70.Append(textBody70);

            var shape71 = new Shape();

            var nonVisualShapeProperties71 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties85 = new NonVisualDrawingProperties {Id = 6U, Name = "Footer Placeholder 5"};

            var nonVisualShapeDrawingProperties71 = new NonVisualShapeDrawingProperties();
            var shapeLocks69 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties71.Append(shapeLocks69);

            var applicationNonVisualDrawingProperties85 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape68 = new PlaceholderShape
                {
                    Type = PlaceholderValues.Footer,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 11U
                };

            applicationNonVisualDrawingProperties85.Append(placeholderShape68);

            nonVisualShapeProperties71.Append(nonVisualDrawingProperties85);
            nonVisualShapeProperties71.Append(nonVisualShapeDrawingProperties71);
            nonVisualShapeProperties71.Append(applicationNonVisualDrawingProperties85);
            var shapeProperties73 = new ShapeProperties();

            var textBody71 = new TextBody();
            var bodyProperties73 = new BodyProperties();
            var listStyle73 = new ListStyle();

            var paragraph107 = new Paragraph();
            var endParagraphRunProperties67 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph107.Append(endParagraphRunProperties67);

            textBody71.Append(bodyProperties73);
            textBody71.Append(listStyle73);
            textBody71.Append(paragraph107);

            shape71.Append(nonVisualShapeProperties71);
            shape71.Append(shapeProperties73);
            shape71.Append(textBody71);

            var shape72 = new Shape();

            var nonVisualShapeProperties72 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties86 = new NonVisualDrawingProperties
                {
                    Id = 7U,
                    Name = "Slide Number Placeholder 6"
                };

            var nonVisualShapeDrawingProperties72 = new NonVisualShapeDrawingProperties();
            var shapeLocks70 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties72.Append(shapeLocks70);

            var applicationNonVisualDrawingProperties86 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape69 = new PlaceholderShape
                {
                    Type = PlaceholderValues.SlideNumber,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 12U
                };

            applicationNonVisualDrawingProperties86.Append(placeholderShape69);

            nonVisualShapeProperties72.Append(nonVisualDrawingProperties86);
            nonVisualShapeProperties72.Append(nonVisualShapeDrawingProperties72);
            nonVisualShapeProperties72.Append(applicationNonVisualDrawingProperties86);
            var shapeProperties74 = new ShapeProperties();

            var textBody72 = new TextBody();
            var bodyProperties74 = new BodyProperties();
            var listStyle74 = new ListStyle();

            var paragraph108 = new Paragraph();

            var field26 = new Field {Id = "{7F5CE407-6216-4202-80E4-A30DC2F709B2}", Type = "slidenum"};

            var runProperties93 = new RunProperties {Language = "en-US"};
            runProperties93.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text93 = new Text();
            text93.Text = "‹#›";

            field26.Append(runProperties93);
            field26.Append(text93);
            var endParagraphRunProperties68 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph108.Append(field26);
            paragraph108.Append(endParagraphRunProperties68);

            textBody72.Append(bodyProperties74);
            textBody72.Append(listStyle74);
            textBody72.Append(paragraph108);

            shape72.Append(nonVisualShapeProperties72);
            shape72.Append(shapeProperties74);
            shape72.Append(textBody72);

            shapeTree14.Append(nonVisualGroupShapeProperties14);
            shapeTree14.Append(groupShapeProperties14);
            shapeTree14.Append(shape67);
            shapeTree14.Append(shape68);
            shapeTree14.Append(shape69);
            shapeTree14.Append(shape70);
            shapeTree14.Append(shape71);
            shapeTree14.Append(shape72);

            commonSlideData14.Append(shapeTree14);

            var colorMapOverride13 = new ColorMapOverride();
            var masterColorMapping13 = new MasterColorMapping();

            colorMapOverride13.Append(masterColorMapping13);

            slideLayout12.Append(commonSlideData14);
            slideLayout12.Append(colorMapOverride13);

            slideLayoutPart12.SlideLayout = slideLayout12;
        }

        // Generates content of slideLayoutPart13.
        private void GenerateSlideLayoutPart13Content(SlideLayoutPart slideLayoutPart13)
        {
            var slideLayout13 = new SlideLayout {Preserve = true};
            slideLayout13.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout13.AddNamespaceDeclaration("r",
                                                  "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout13.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            var commonSlideData15 = new CommonSlideData {Name = "Picture with Caption"};

            var shapeTree15 = new ShapeTree();

            var nonVisualGroupShapeProperties15 = new NonVisualGroupShapeProperties();
            var nonVisualDrawingProperties87 = new NonVisualDrawingProperties {Id = 1U, Name = ""};
            var nonVisualGroupShapeDrawingProperties15 = new NonVisualGroupShapeDrawingProperties();
            var applicationNonVisualDrawingProperties87 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties15.Append(nonVisualDrawingProperties87);
            nonVisualGroupShapeProperties15.Append(nonVisualGroupShapeDrawingProperties15);
            nonVisualGroupShapeProperties15.Append(applicationNonVisualDrawingProperties87);

            var groupShapeProperties15 = new GroupShapeProperties();

            var transformGroup15 = new TransformGroup();
            var offset46 = new Offset {X = 0L, Y = 0L};
            var extents46 = new Extents {Cx = 0L, Cy = 0L};
            var childOffset15 = new ChildOffset {X = 0L, Y = 0L};
            var childExtents15 = new ChildExtents {Cx = 0L, Cy = 0L};

            transformGroup15.Append(offset46);
            transformGroup15.Append(extents46);
            transformGroup15.Append(childOffset15);
            transformGroup15.Append(childExtents15);

            groupShapeProperties15.Append(transformGroup15);

            var shape73 = new Shape();

            var nonVisualShapeProperties73 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties88 = new NonVisualDrawingProperties {Id = 2U, Name = "Title 1"};

            var nonVisualShapeDrawingProperties73 = new NonVisualShapeDrawingProperties();
            var shapeLocks71 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties73.Append(shapeLocks71);

            var applicationNonVisualDrawingProperties88 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape70 = new PlaceholderShape {Type = PlaceholderValues.Title};

            applicationNonVisualDrawingProperties88.Append(placeholderShape70);

            nonVisualShapeProperties73.Append(nonVisualDrawingProperties88);
            nonVisualShapeProperties73.Append(nonVisualShapeDrawingProperties73);
            nonVisualShapeProperties73.Append(applicationNonVisualDrawingProperties88);

            var shapeProperties75 = new ShapeProperties();

            var transform2D32 = new Transform2D();
            var offset47 = new Offset {X = 533398L, Y = 611872L};
            var extents47 = new Extents {Cx = 4079545L, Cy = 1162050L};

            transform2D32.Append(offset47);
            transform2D32.Append(extents47);

            shapeProperties75.Append(transform2D32);

            var textBody73 = new TextBody();
            var bodyProperties75 = new BodyProperties {Anchor = TextAnchoringTypeValues.Bottom};

            var listStyle75 = new ListStyle();

            var level1ParagraphProperties27 = new Level1ParagraphProperties {Alignment = TextAlignmentTypeValues.Center};
            var defaultRunProperties161 = new DefaultRunProperties {FontSize = 3600, Bold = false};

            level1ParagraphProperties27.Append(defaultRunProperties161);

            listStyle75.Append(level1ParagraphProperties27);

            var paragraph109 = new Paragraph();

            var run68 = new Run();

            var runProperties94 = new RunProperties {Language = "en-US"};
            runProperties94.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text94 = new Text();
            text94.Text = "Click to edit Master title style";

            run68.Append(runProperties94);
            run68.Append(text94);
            var endParagraphRunProperties69 = new EndParagraphRunProperties();

            paragraph109.Append(run68);
            paragraph109.Append(endParagraphRunProperties69);

            textBody73.Append(bodyProperties75);
            textBody73.Append(listStyle75);
            textBody73.Append(paragraph109);

            shape73.Append(nonVisualShapeProperties73);
            shape73.Append(shapeProperties75);
            shape73.Append(textBody73);

            var shape74 = new Shape();

            var nonVisualShapeProperties74 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties89 = new NonVisualDrawingProperties {Id = 4U, Name = "Text Placeholder 3"};

            var nonVisualShapeDrawingProperties74 = new NonVisualShapeDrawingProperties();
            var shapeLocks72 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties74.Append(shapeLocks72);

            var applicationNonVisualDrawingProperties89 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape71 = new PlaceholderShape
                {
                    Type = PlaceholderValues.Body,
                    Size = PlaceholderSizeValues.Half,
                    Index = 2U
                };

            applicationNonVisualDrawingProperties89.Append(placeholderShape71);

            nonVisualShapeProperties74.Append(nonVisualDrawingProperties89);
            nonVisualShapeProperties74.Append(nonVisualShapeDrawingProperties74);
            nonVisualShapeProperties74.Append(applicationNonVisualDrawingProperties89);

            var shapeProperties76 = new ShapeProperties();

            var transform2D33 = new Transform2D();
            var offset48 = new Offset {X = 533398L, Y = 1787856L};
            var extents48 = new Extents {Cx = 4079545L, Cy = 3720152L};

            transform2D33.Append(offset48);
            transform2D33.Append(extents48);

            shapeProperties76.Append(transform2D33);

            var textBody74 = new TextBody();

            var bodyProperties76 = new BodyProperties();
            var normalAutoFit12 = new NormalAutoFit();

            bodyProperties76.Append(normalAutoFit12);

            var listStyle76 = new ListStyle();

            var level1ParagraphProperties28 = new Level1ParagraphProperties
                {
                    LeftMargin = 0,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Center
                };

            var spaceBefore25 = new SpaceBefore();
            var spacingPoints18 = new SpacingPoints {Val = 600};

            spaceBefore25.Append(spacingPoints18);
            var noBullet78 = new NoBullet();
            var defaultRunProperties162 = new DefaultRunProperties {FontSize = 1800};

            level1ParagraphProperties28.Append(spaceBefore25);
            level1ParagraphProperties28.Append(noBullet78);
            level1ParagraphProperties28.Append(defaultRunProperties162);

            var level2ParagraphProperties17 = new Level2ParagraphProperties {LeftMargin = 457200, Indent = 0};
            var noBullet79 = new NoBullet();
            var defaultRunProperties163 = new DefaultRunProperties {FontSize = 1200};

            level2ParagraphProperties17.Append(noBullet79);
            level2ParagraphProperties17.Append(defaultRunProperties163);

            var level3ParagraphProperties17 = new Level3ParagraphProperties {LeftMargin = 914400, Indent = 0};
            var noBullet80 = new NoBullet();
            var defaultRunProperties164 = new DefaultRunProperties {FontSize = 1000};

            level3ParagraphProperties17.Append(noBullet80);
            level3ParagraphProperties17.Append(defaultRunProperties164);

            var level4ParagraphProperties17 = new Level4ParagraphProperties {LeftMargin = 1371600, Indent = 0};
            var noBullet81 = new NoBullet();
            var defaultRunProperties165 = new DefaultRunProperties {FontSize = 900};

            level4ParagraphProperties17.Append(noBullet81);
            level4ParagraphProperties17.Append(defaultRunProperties165);

            var level5ParagraphProperties20 = new Level5ParagraphProperties {LeftMargin = 1828800, Indent = 0};
            var noBullet82 = new NoBullet();
            var defaultRunProperties166 = new DefaultRunProperties {FontSize = 900};

            level5ParagraphProperties20.Append(noBullet82);
            level5ParagraphProperties20.Append(defaultRunProperties166);

            var level6ParagraphProperties17 = new Level6ParagraphProperties {LeftMargin = 2286000, Indent = 0};
            var noBullet83 = new NoBullet();
            var defaultRunProperties167 = new DefaultRunProperties {FontSize = 900};

            level6ParagraphProperties17.Append(noBullet83);
            level6ParagraphProperties17.Append(defaultRunProperties167);

            var level7ParagraphProperties17 = new Level7ParagraphProperties {LeftMargin = 2743200, Indent = 0};
            var noBullet84 = new NoBullet();
            var defaultRunProperties168 = new DefaultRunProperties {FontSize = 900};

            level7ParagraphProperties17.Append(noBullet84);
            level7ParagraphProperties17.Append(defaultRunProperties168);

            var level8ParagraphProperties17 = new Level8ParagraphProperties {LeftMargin = 3200400, Indent = 0};
            var noBullet85 = new NoBullet();
            var defaultRunProperties169 = new DefaultRunProperties {FontSize = 900};

            level8ParagraphProperties17.Append(noBullet85);
            level8ParagraphProperties17.Append(defaultRunProperties169);

            var level9ParagraphProperties17 = new Level9ParagraphProperties {LeftMargin = 3657600, Indent = 0};
            var noBullet86 = new NoBullet();
            var defaultRunProperties170 = new DefaultRunProperties {FontSize = 900};

            level9ParagraphProperties17.Append(noBullet86);
            level9ParagraphProperties17.Append(defaultRunProperties170);

            listStyle76.Append(level1ParagraphProperties28);
            listStyle76.Append(level2ParagraphProperties17);
            listStyle76.Append(level3ParagraphProperties17);
            listStyle76.Append(level4ParagraphProperties17);
            listStyle76.Append(level5ParagraphProperties20);
            listStyle76.Append(level6ParagraphProperties17);
            listStyle76.Append(level7ParagraphProperties17);
            listStyle76.Append(level8ParagraphProperties17);
            listStyle76.Append(level9ParagraphProperties17);

            var paragraph110 = new Paragraph();
            var paragraphProperties77 = new ParagraphProperties {Level = 0};

            var run69 = new Run();

            var runProperties95 = new RunProperties {Language = "en-US"};
            runProperties95.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text95 = new Text();
            text95.Text = "Click to edit Master text styles";

            run69.Append(runProperties95);
            run69.Append(text95);

            paragraph110.Append(paragraphProperties77);
            paragraph110.Append(run69);

            textBody74.Append(bodyProperties76);
            textBody74.Append(listStyle76);
            textBody74.Append(paragraph110);

            shape74.Append(nonVisualShapeProperties74);
            shape74.Append(shapeProperties76);
            shape74.Append(textBody74);

            var shape75 = new Shape();

            var nonVisualShapeProperties75 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties90 = new NonVisualDrawingProperties {Id = 5U, Name = "Date Placeholder 4"};

            var nonVisualShapeDrawingProperties75 = new NonVisualShapeDrawingProperties();
            var shapeLocks73 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties75.Append(shapeLocks73);

            var applicationNonVisualDrawingProperties90 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape72 = new PlaceholderShape
                {
                    Type = PlaceholderValues.DateAndTime,
                    Size = PlaceholderSizeValues.Half,
                    Index = 10U
                };

            applicationNonVisualDrawingProperties90.Append(placeholderShape72);

            nonVisualShapeProperties75.Append(nonVisualDrawingProperties90);
            nonVisualShapeProperties75.Append(nonVisualShapeDrawingProperties75);
            nonVisualShapeProperties75.Append(applicationNonVisualDrawingProperties90);
            var shapeProperties77 = new ShapeProperties();

            var textBody75 = new TextBody();
            var bodyProperties77 = new BodyProperties();
            var listStyle77 = new ListStyle();

            var paragraph111 = new Paragraph();

            var field27 = new Field {Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut"};

            var runProperties96 = new RunProperties {Language = "en-US"};
            runProperties96.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties78 = new ParagraphProperties();
            var text96 = new Text();
            text96.Text = "29/11/13";

            field27.Append(runProperties96);
            field27.Append(paragraphProperties78);
            field27.Append(text96);
            var endParagraphRunProperties70 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph111.Append(field27);
            paragraph111.Append(endParagraphRunProperties70);

            textBody75.Append(bodyProperties77);
            textBody75.Append(listStyle77);
            textBody75.Append(paragraph111);

            shape75.Append(nonVisualShapeProperties75);
            shape75.Append(shapeProperties77);
            shape75.Append(textBody75);

            var shape76 = new Shape();

            var nonVisualShapeProperties76 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties91 = new NonVisualDrawingProperties {Id = 6U, Name = "Footer Placeholder 5"};

            var nonVisualShapeDrawingProperties76 = new NonVisualShapeDrawingProperties();
            var shapeLocks74 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties76.Append(shapeLocks74);

            var applicationNonVisualDrawingProperties91 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape73 = new PlaceholderShape
                {
                    Type = PlaceholderValues.Footer,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 11U
                };

            applicationNonVisualDrawingProperties91.Append(placeholderShape73);

            nonVisualShapeProperties76.Append(nonVisualDrawingProperties91);
            nonVisualShapeProperties76.Append(nonVisualShapeDrawingProperties76);
            nonVisualShapeProperties76.Append(applicationNonVisualDrawingProperties91);
            var shapeProperties78 = new ShapeProperties();

            var textBody76 = new TextBody();
            var bodyProperties78 = new BodyProperties();
            var listStyle78 = new ListStyle();

            var paragraph112 = new Paragraph();
            var endParagraphRunProperties71 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph112.Append(endParagraphRunProperties71);

            textBody76.Append(bodyProperties78);
            textBody76.Append(listStyle78);
            textBody76.Append(paragraph112);

            shape76.Append(nonVisualShapeProperties76);
            shape76.Append(shapeProperties78);
            shape76.Append(textBody76);

            var shape77 = new Shape();

            var nonVisualShapeProperties77 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties92 = new NonVisualDrawingProperties
                {
                    Id = 7U,
                    Name = "Slide Number Placeholder 6"
                };

            var nonVisualShapeDrawingProperties77 = new NonVisualShapeDrawingProperties();
            var shapeLocks75 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties77.Append(shapeLocks75);

            var applicationNonVisualDrawingProperties92 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape74 = new PlaceholderShape
                {
                    Type = PlaceholderValues.SlideNumber,
                    Size = PlaceholderSizeValues.Quarter,
                    Index = 12U
                };

            applicationNonVisualDrawingProperties92.Append(placeholderShape74);

            nonVisualShapeProperties77.Append(nonVisualDrawingProperties92);
            nonVisualShapeProperties77.Append(nonVisualShapeDrawingProperties77);
            nonVisualShapeProperties77.Append(applicationNonVisualDrawingProperties92);
            var shapeProperties79 = new ShapeProperties();

            var textBody77 = new TextBody();
            var bodyProperties79 = new BodyProperties();
            var listStyle79 = new ListStyle();

            var paragraph113 = new Paragraph();

            var field28 = new Field {Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum"};

            var runProperties97 = new RunProperties {Language = "en-US"};
            runProperties97.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var paragraphProperties79 = new ParagraphProperties();
            var text97 = new Text();
            text97.Text = "‹#›";

            field28.Append(runProperties97);
            field28.Append(paragraphProperties79);
            field28.Append(text97);
            var endParagraphRunProperties72 = new EndParagraphRunProperties {Language = "en-US"};

            paragraph113.Append(field28);
            paragraph113.Append(endParagraphRunProperties72);

            textBody77.Append(bodyProperties79);
            textBody77.Append(listStyle79);
            textBody77.Append(paragraph113);

            shape77.Append(nonVisualShapeProperties77);
            shape77.Append(shapeProperties79);
            shape77.Append(textBody77);

            var shape78 = new Shape();

            var nonVisualShapeProperties78 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties93 = new NonVisualDrawingProperties {Id = 8U, Name = "Picture Placeholder 2"};

            var nonVisualShapeDrawingProperties78 = new NonVisualShapeDrawingProperties();
            var shapeLocks76 = new ShapeLocks {NoGrouping = true};

            nonVisualShapeDrawingProperties78.Append(shapeLocks76);

            var applicationNonVisualDrawingProperties93 = new ApplicationNonVisualDrawingProperties();
            var placeholderShape75 = new PlaceholderShape {Type = PlaceholderValues.Picture, Index = 1U};

            applicationNonVisualDrawingProperties93.Append(placeholderShape75);

            nonVisualShapeProperties78.Append(nonVisualDrawingProperties93);
            nonVisualShapeProperties78.Append(nonVisualShapeDrawingProperties78);
            nonVisualShapeProperties78.Append(applicationNonVisualDrawingProperties93);

            var shapeProperties80 = new ShapeProperties();

            var transform2D34 = new Transform2D();
            var offset49 = new Offset {X = 5090617L, Y = 359392L};
            var extents49 = new Extents {Cx = 3657600L, Cy = 5318077L};

            transform2D34.Append(offset49);
            transform2D34.Append(extents49);

            var outline6 = new Outline {Width = 3175};

            var solidFill80 = new SolidFill();
            var schemeColor111 = new SchemeColor {Val = SchemeColorValues.Background1};

            solidFill80.Append(schemeColor111);

            outline6.Append(solidFill80);

            var effectList6 = new EffectList();

            var outerShadow5 = new OuterShadow
                {
                    BlurRadius = 63500L,
                    HorizontalRatio = 100500,
                    VerticalRatio = 100500,
                    Alignment = RectangleAlignmentValues.Center,
                    RotateWithShape = false
                };

            var presetColor3 = new PresetColor {Val = PresetColorValues.Black};
            var alpha6 = new Alpha {Val = 50000};

            presetColor3.Append(alpha6);

            outerShadow5.Append(presetColor3);

            effectList6.Append(outerShadow5);

            shapeProperties80.Append(transform2D34);
            shapeProperties80.Append(outline6);
            shapeProperties80.Append(effectList6);

            var textBody78 = new TextBody();

            var bodyProperties80 = new BodyProperties
                {
                    Vertical = TextVerticalValues.Horizontal,
                    LeftInset = 91440,
                    TopInset = 45720,
                    RightInset = 91440,
                    BottomInset = 45720,
                    RightToLeftColumns = false
                };
            var normalAutoFit13 = new NormalAutoFit();

            bodyProperties80.Append(normalAutoFit13);

            var listStyle80 = new ListStyle();

            var level1ParagraphProperties29 = new Level1ParagraphProperties
                {
                    LeftMargin = 0,
                    Indent = 0,
                    Alignment = TextAlignmentTypeValues.Left,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var spaceBefore26 = new SpaceBefore();
            var spacingPoints19 = new SpacingPoints {Val = 2000};

            spaceBefore26.Append(spacingPoints19);

            var bulletColor13 = new BulletColor();

            var schemeColor112 = new SchemeColor {Val = SchemeColorValues.Accent1};
            var luminanceModulation23 = new LuminanceModulation {Val = 60000};
            var luminanceOffset21 = new LuminanceOffset {Val = 40000};

            schemeColor112.Append(luminanceModulation23);
            schemeColor112.Append(luminanceOffset21);

            bulletColor13.Append(schemeColor112);
            var bulletSizePercentage13 = new BulletSizePercentage {Val = 110000};
            var bulletFont13 = new BulletFont {Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2};
            var noBullet87 = new NoBullet();

            var defaultRunProperties171 = new DefaultRunProperties {FontSize = 3200, Kerning = 1200};

            var solidFill81 = new SolidFill();

            var schemeColor113 = new SchemeColor {Val = SchemeColorValues.Text1};
            var luminanceModulation24 = new LuminanceModulation {Val = 65000};
            var luminanceOffset22 = new LuminanceOffset {Val = 35000};

            schemeColor113.Append(luminanceModulation24);
            schemeColor113.Append(luminanceOffset22);

            solidFill81.Append(schemeColor113);
            var latinFont35 = new LatinFont {Typeface = "+mn-lt"};
            var eastAsianFont35 = new EastAsianFont {Typeface = "+mn-ea"};
            var complexScriptFont35 = new ComplexScriptFont {Typeface = "+mn-cs"};

            defaultRunProperties171.Append(solidFill81);
            defaultRunProperties171.Append(latinFont35);
            defaultRunProperties171.Append(eastAsianFont35);
            defaultRunProperties171.Append(complexScriptFont35);

            level1ParagraphProperties29.Append(spaceBefore26);
            level1ParagraphProperties29.Append(bulletColor13);
            level1ParagraphProperties29.Append(bulletSizePercentage13);
            level1ParagraphProperties29.Append(bulletFont13);
            level1ParagraphProperties29.Append(noBullet87);
            level1ParagraphProperties29.Append(defaultRunProperties171);

            var level2ParagraphProperties18 = new Level2ParagraphProperties {LeftMargin = 457200, Indent = 0};
            var noBullet88 = new NoBullet();
            var defaultRunProperties172 = new DefaultRunProperties {FontSize = 2800};

            level2ParagraphProperties18.Append(noBullet88);
            level2ParagraphProperties18.Append(defaultRunProperties172);

            var level3ParagraphProperties18 = new Level3ParagraphProperties {LeftMargin = 914400, Indent = 0};
            var noBullet89 = new NoBullet();
            var defaultRunProperties173 = new DefaultRunProperties {FontSize = 2400};

            level3ParagraphProperties18.Append(noBullet89);
            level3ParagraphProperties18.Append(defaultRunProperties173);

            var level4ParagraphProperties18 = new Level4ParagraphProperties {LeftMargin = 1371600, Indent = 0};
            var noBullet90 = new NoBullet();
            var defaultRunProperties174 = new DefaultRunProperties {FontSize = 2000};

            level4ParagraphProperties18.Append(noBullet90);
            level4ParagraphProperties18.Append(defaultRunProperties174);

            var level5ParagraphProperties21 = new Level5ParagraphProperties {LeftMargin = 1828800, Indent = 0};
            var noBullet91 = new NoBullet();
            var defaultRunProperties175 = new DefaultRunProperties {FontSize = 2000};

            level5ParagraphProperties21.Append(noBullet91);
            level5ParagraphProperties21.Append(defaultRunProperties175);

            var level6ParagraphProperties18 = new Level6ParagraphProperties {LeftMargin = 2286000, Indent = 0};
            var noBullet92 = new NoBullet();
            var defaultRunProperties176 = new DefaultRunProperties {FontSize = 2000};

            level6ParagraphProperties18.Append(noBullet92);
            level6ParagraphProperties18.Append(defaultRunProperties176);

            var level7ParagraphProperties18 = new Level7ParagraphProperties {LeftMargin = 2743200, Indent = 0};
            var noBullet93 = new NoBullet();
            var defaultRunProperties177 = new DefaultRunProperties {FontSize = 2000};

            level7ParagraphProperties18.Append(noBullet93);
            level7ParagraphProperties18.Append(defaultRunProperties177);

            var level8ParagraphProperties18 = new Level8ParagraphProperties {LeftMargin = 3200400, Indent = 0};
            var noBullet94 = new NoBullet();
            var defaultRunProperties178 = new DefaultRunProperties {FontSize = 2000};

            level8ParagraphProperties18.Append(noBullet94);
            level8ParagraphProperties18.Append(defaultRunProperties178);

            var level9ParagraphProperties18 = new Level9ParagraphProperties {LeftMargin = 3657600, Indent = 0};
            var noBullet95 = new NoBullet();
            var defaultRunProperties179 = new DefaultRunProperties {FontSize = 2000};

            level9ParagraphProperties18.Append(noBullet95);
            level9ParagraphProperties18.Append(defaultRunProperties179);

            listStyle80.Append(level1ParagraphProperties29);
            listStyle80.Append(level2ParagraphProperties18);
            listStyle80.Append(level3ParagraphProperties18);
            listStyle80.Append(level4ParagraphProperties18);
            listStyle80.Append(level5ParagraphProperties21);
            listStyle80.Append(level6ParagraphProperties18);
            listStyle80.Append(level7ParagraphProperties18);
            listStyle80.Append(level8ParagraphProperties18);
            listStyle80.Append(level9ParagraphProperties18);

            var paragraph114 = new Paragraph();

            var run70 = new Run();

            var runProperties98 = new RunProperties {Language = "en-US"};
            runProperties98.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text98 = new Text();
            text98.Text = "Drag picture to placeholder or click icon to add";

            run70.Append(runProperties98);
            run70.Append(text98);
            var endParagraphRunProperties73 = new EndParagraphRunProperties();

            paragraph114.Append(run70);
            paragraph114.Append(endParagraphRunProperties73);

            textBody78.Append(bodyProperties80);
            textBody78.Append(listStyle80);
            textBody78.Append(paragraph114);

            shape78.Append(nonVisualShapeProperties78);
            shape78.Append(shapeProperties80);
            shape78.Append(textBody78);

            shapeTree15.Append(nonVisualGroupShapeProperties15);
            shapeTree15.Append(groupShapeProperties15);
            shapeTree15.Append(shape73);
            shapeTree15.Append(shape74);
            shapeTree15.Append(shape75);
            shapeTree15.Append(shape76);
            shapeTree15.Append(shape77);
            shapeTree15.Append(shape78);

            commonSlideData15.Append(shapeTree15);

            var colorMapOverride14 = new ColorMapOverride();
            var masterColorMapping14 = new MasterColorMapping();

            colorMapOverride14.Append(masterColorMapping14);

            slideLayout13.Append(commonSlideData15);
            slideLayout13.Append(colorMapOverride14);

            slideLayoutPart13.SlideLayout = slideLayout13;
        }

        // Generates content of slidePart2.
        private void GenerateSlidePart2Content(SlidePart slidePart2)
        {
            var slide2 = new Slide();
            slide2.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slide2.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slide2.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            var commonSlideData16 = new CommonSlideData();

            var shapeTree16 = new ShapeTree();

            var nonVisualGroupShapeProperties16 = new NonVisualGroupShapeProperties();
            var nonVisualDrawingProperties94 = new NonVisualDrawingProperties {Id = 1U, Name = ""};
            var nonVisualGroupShapeDrawingProperties16 = new NonVisualGroupShapeDrawingProperties();
            var applicationNonVisualDrawingProperties94 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties16.Append(nonVisualDrawingProperties94);
            nonVisualGroupShapeProperties16.Append(nonVisualGroupShapeDrawingProperties16);
            nonVisualGroupShapeProperties16.Append(applicationNonVisualDrawingProperties94);

            var groupShapeProperties16 = new GroupShapeProperties();

            var transformGroup16 = new TransformGroup();
            var offset50 = new Offset {X = 0L, Y = 0L};
            var extents50 = new Extents {Cx = 0L, Cy = 0L};
            var childOffset16 = new ChildOffset {X = 0L, Y = 0L};
            var childExtents16 = new ChildExtents {Cx = 0L, Cy = 0L};

            transformGroup16.Append(offset50);
            transformGroup16.Append(extents50);
            transformGroup16.Append(childOffset16);
            transformGroup16.Append(childExtents16);

            groupShapeProperties16.Append(transformGroup16);

            var picture1 = new Picture();

            var nonVisualPictureProperties1 = new NonVisualPictureProperties();
            var nonVisualDrawingProperties95 = new NonVisualDrawingProperties {Id = 1026U, Name = "Picture 2"};

            var nonVisualPictureDrawingProperties1 = new NonVisualPictureDrawingProperties();
            var pictureLocks1 = new PictureLocks {NoChangeAspect = true, NoChangeArrowheads = true};

            nonVisualPictureDrawingProperties1.Append(pictureLocks1);
            var applicationNonVisualDrawingProperties95 = new ApplicationNonVisualDrawingProperties();

            nonVisualPictureProperties1.Append(nonVisualDrawingProperties95);
            nonVisualPictureProperties1.Append(nonVisualPictureDrawingProperties1);
            nonVisualPictureProperties1.Append(applicationNonVisualDrawingProperties95);

            var blipFill2 = new DocumentFormat.OpenXml.Presentation.BlipFill();

            var blip2 = new Blip {Embed = "rId2", CompressionState = BlipCompressionValues.Print};

            var blipExtensionList1 = new BlipExtensionList();

            var blipExtension1 = new BlipExtension {Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}"};

            var useLocalDpi1 = new UseLocalDpi {Val = false};
            useLocalDpi1.AddNamespaceDeclaration("a14", "http://schemas.microsoft.com/office/drawing/2010/main");

            blipExtension1.Append(useLocalDpi1);

            blipExtensionList1.Append(blipExtension1);

            blip2.Append(blipExtensionList1);
            var sourceRectangle1 = new SourceRectangle();

            var stretch2 = new Stretch();
            var fillRectangle1 = new FillRectangle();

            stretch2.Append(fillRectangle1);

            blipFill2.Append(blip2);
            blipFill2.Append(sourceRectangle1);
            blipFill2.Append(stretch2);

            var shapeProperties81 = new ShapeProperties {BlackWhiteMode = BlackWhiteModeValues.Auto};

            var transform2D35 = new Transform2D();
            var offset51 = new Offset {X = 457200L, Y = 1219200L};
            var extents51 = new Extents {Cx = 8305800L, Cy = 5354794L};

            transform2D35.Append(offset51);
            transform2D35.Append(extents51);

            var presetGeometry9 = new PresetGeometry {Preset = ShapeTypeValues.Rectangle};
            var adjustValueList9 = new AdjustValueList();

            presetGeometry9.Append(adjustValueList9);

            var outline7 = new Outline();
            var noFill2 = new NoFill();

            outline7.Append(noFill2);

            var effectList7 = new EffectList();

            var outerShadow6 = new OuterShadow
                {
                    BlurRadius = 292100L,
                    Distance = 139700L,
                    Direction = 2700000,
                    Alignment = RectangleAlignmentValues.TopLeft,
                    RotateWithShape = false
                };

            var rgbColorModelHex14 = new RgbColorModelHex {Val = "333333"};
            var alpha7 = new Alpha {Val = 65000};

            rgbColorModelHex14.Append(alpha7);

            outerShadow6.Append(rgbColorModelHex14);

            effectList7.Append(outerShadow6);

            var shapePropertiesExtensionList1 = new ShapePropertiesExtensionList();

            var shapePropertiesExtension1 = new ShapePropertiesExtension
                {
                    Uri = "{909E8E84-426E-40dd-AFC4-6F175D3DCCD1}"
                };

            var hiddenFillProperties1 = new HiddenFillProperties();
            hiddenFillProperties1.AddNamespaceDeclaration("a14", "http://schemas.microsoft.com/office/drawing/2010/main");

            var solidFill82 = new SolidFill();
            var schemeColor114 = new SchemeColor {Val = SchemeColorValues.Accent1};

            solidFill82.Append(schemeColor114);

            hiddenFillProperties1.Append(solidFill82);

            shapePropertiesExtension1.Append(hiddenFillProperties1);

            var shapePropertiesExtension2 = new ShapePropertiesExtension
                {
                    Uri = "{91240B29-F687-4f45-9708-019B960494DF}"
                };

            var hiddenLineProperties1 = new HiddenLineProperties {Width = 9525};
            hiddenLineProperties1.AddNamespaceDeclaration("a14", "http://schemas.microsoft.com/office/drawing/2010/main");

            var solidFill83 = new SolidFill();
            var schemeColor115 = new SchemeColor {Val = SchemeColorValues.Text1};

            solidFill83.Append(schemeColor115);
            var miter1 = new Miter {Limit = 800000};
            var headEnd1 = new HeadEnd();
            var tailEnd1 = new TailEnd();

            hiddenLineProperties1.Append(solidFill83);
            hiddenLineProperties1.Append(miter1);
            hiddenLineProperties1.Append(headEnd1);
            hiddenLineProperties1.Append(tailEnd1);

            shapePropertiesExtension2.Append(hiddenLineProperties1);

            shapePropertiesExtensionList1.Append(shapePropertiesExtension1);
            shapePropertiesExtensionList1.Append(shapePropertiesExtension2);

            shapeProperties81.Append(transform2D35);
            shapeProperties81.Append(presetGeometry9);
            shapeProperties81.Append(outline7);
            shapeProperties81.Append(effectList7);
            shapeProperties81.Append(shapePropertiesExtensionList1);

            picture1.Append(nonVisualPictureProperties1);
            picture1.Append(blipFill2);
            picture1.Append(shapeProperties81);

            var shape79 = new Shape();

            var nonVisualShapeProperties79 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties96 = new NonVisualDrawingProperties {Id = 5U, Name = "Title 2"};

            var nonVisualShapeDrawingProperties79 = new NonVisualShapeDrawingProperties {TextBox = true};
            var shapeLocks77 = new ShapeLocks();

            nonVisualShapeDrawingProperties79.Append(shapeLocks77);
            var applicationNonVisualDrawingProperties96 = new ApplicationNonVisualDrawingProperties();

            nonVisualShapeProperties79.Append(nonVisualDrawingProperties96);
            nonVisualShapeProperties79.Append(nonVisualShapeDrawingProperties79);
            nonVisualShapeProperties79.Append(applicationNonVisualDrawingProperties96);

            var shapeProperties82 = new ShapeProperties();

            var transform2D36 = new Transform2D();
            var offset52 = new Offset {X = 533400L, Y = 152400L};
            var extents52 = new Extents {Cx = 8042276L, Cy = 758732L};

            transform2D36.Append(offset52);
            transform2D36.Append(extents52);

            var presetGeometry10 = new PresetGeometry {Preset = ShapeTypeValues.Rectangle};
            var adjustValueList10 = new AdjustValueList();

            presetGeometry10.Append(adjustValueList10);

            shapeProperties82.Append(transform2D36);
            shapeProperties82.Append(presetGeometry10);

            var textBody79 = new TextBody();

            var bodyProperties81 = new BodyProperties
                {
                    Vertical = TextVerticalValues.Horizontal,
                    LeftInset = 91440,
                    TopInset = 45720,
                    RightInset = 91440,
                    BottomInset = 45720,
                    RightToLeftColumns = false,
                    Anchor = TextAnchoringTypeValues.Bottom,
                    AnchorCenter = false
                };
            var noAutoFit6 = new NoAutoFit();

            bodyProperties81.Append(noAutoFit6);

            var listStyle81 = new ListStyle();

            var level1ParagraphProperties30 = new Level1ParagraphProperties
                {
                    Alignment = TextAlignmentTypeValues.Center,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var spaceBefore27 = new SpaceBefore();
            var spacingPercent8 = new SpacingPercent {Val = 0};

            spaceBefore27.Append(spacingPercent8);
            var noBullet96 = new NoBullet();

            var defaultRunProperties180 = new DefaultRunProperties {FontSize = 4600, Kerning = 1200};

            var solidFill84 = new SolidFill();
            var schemeColor116 = new SchemeColor {Val = SchemeColorValues.Accent1};

            solidFill84.Append(schemeColor116);
            var latinFont36 = new LatinFont {Typeface = "+mj-lt"};
            var eastAsianFont36 = new EastAsianFont {Typeface = "+mj-ea"};
            var complexScriptFont36 = new ComplexScriptFont {Typeface = "+mj-cs"};

            defaultRunProperties180.Append(solidFill84);
            defaultRunProperties180.Append(latinFont36);
            defaultRunProperties180.Append(eastAsianFont36);
            defaultRunProperties180.Append(complexScriptFont36);

            level1ParagraphProperties30.Append(spaceBefore27);
            level1ParagraphProperties30.Append(noBullet96);
            level1ParagraphProperties30.Append(defaultRunProperties180);

            listStyle81.Append(level1ParagraphProperties30);

            var paragraph115 = new Paragraph();

            var run71 = new Run();

            var runProperties99 = new RunProperties {Language = "en-US", FontSize = 2200, Dirty = false};
            runProperties99.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text99 = new Text();
            text99.Text = "{title}";

            run71.Append(runProperties99);
            run71.Append(text99);
            var endParagraphRunProperties74 = new EndParagraphRunProperties
                {
                    Language = "en-US",
                    FontSize = 2200,
                    Dirty = false
                };

            paragraph115.Append(run71);
            paragraph115.Append(endParagraphRunProperties74);

            textBody79.Append(bodyProperties81);
            textBody79.Append(listStyle81);
            textBody79.Append(paragraph115);

            shape79.Append(nonVisualShapeProperties79);
            shape79.Append(shapeProperties82);
            shape79.Append(textBody79);

            shapeTree16.Append(nonVisualGroupShapeProperties16);
            shapeTree16.Append(groupShapeProperties16);
            shapeTree16.Append(picture1);
            shapeTree16.Append(shape79);

            var commonSlideDataExtensionList3 = new CommonSlideDataExtensionList();

            var commonSlideDataExtension3 = new CommonSlideDataExtension
                {
                    Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}"
                };

            var creationId3 = new CreationId {Val = 3486677695U};
            creationId3.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension3.Append(creationId3);

            commonSlideDataExtensionList3.Append(commonSlideDataExtension3);

            commonSlideData16.Append(shapeTree16);
            commonSlideData16.Append(commonSlideDataExtensionList3);

            var colorMapOverride15 = new ColorMapOverride();
            var masterColorMapping15 = new MasterColorMapping();

            colorMapOverride15.Append(masterColorMapping15);

            var alternateContent1 = new AlternateContent();
            alternateContent1.AddNamespaceDeclaration("mc",
                                                      "http://schemas.openxmlformats.org/markup-compatibility/2006");
            alternateContent1.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            var alternateContentChoice1 = new AlternateContentChoice {Requires = "p14"};
            var transition1 = new Transition {Speed = TransitionSpeedValues.Slow, Duration = "2000"};

            alternateContentChoice1.Append(transition1);

            var alternateContentFallback1 = new AlternateContentFallback();

            var transition2 = new Transition {Speed = TransitionSpeedValues.Slow};
            transition2.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            alternateContentFallback1.Append(transition2);

            alternateContent1.Append(alternateContentChoice1);
            alternateContent1.Append(alternateContentFallback1);

            slide2.Append(commonSlideData16);
            slide2.Append(colorMapOverride15);
            slide2.Append(alternateContent1);

            slidePart2.Slide = slide2;
        }

        // Generates content of imagePart2.
        private void GenerateImagePart2Content(ImagePart imagePart2)
        {
            Stream data = GetBinaryDataStream(imagePart2Data);
            imagePart2.FeedData(data);
            data.Close();
        }

        // Generates content of slidePart3.
        private void GenerateSlidePart3Content(SlidePart slidePart3)
        {
            var slide3 = new Slide();
            slide3.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slide3.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slide3.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            var commonSlideData17 = new CommonSlideData();

            var shapeTree17 = new ShapeTree();

            var nonVisualGroupShapeProperties17 = new NonVisualGroupShapeProperties();
            var nonVisualDrawingProperties97 = new NonVisualDrawingProperties {Id = 1U, Name = ""};
            var nonVisualGroupShapeDrawingProperties17 = new NonVisualGroupShapeDrawingProperties();
            var applicationNonVisualDrawingProperties97 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties17.Append(nonVisualDrawingProperties97);
            nonVisualGroupShapeProperties17.Append(nonVisualGroupShapeDrawingProperties17);
            nonVisualGroupShapeProperties17.Append(applicationNonVisualDrawingProperties97);

            var groupShapeProperties17 = new GroupShapeProperties();

            var transformGroup17 = new TransformGroup();
            var offset53 = new Offset {X = 0L, Y = 0L};
            var extents53 = new Extents {Cx = 0L, Cy = 0L};
            var childOffset17 = new ChildOffset {X = 0L, Y = 0L};
            var childExtents17 = new ChildExtents {Cx = 0L, Cy = 0L};

            transformGroup17.Append(offset53);
            transformGroup17.Append(extents53);
            transformGroup17.Append(childOffset17);
            transformGroup17.Append(childExtents17);

            groupShapeProperties17.Append(transformGroup17);

            var graphicFrame1 = new GraphicFrame();

            var nonVisualGraphicFrameProperties1 = new NonVisualGraphicFrameProperties();
            var nonVisualDrawingProperties98 = new NonVisualDrawingProperties {Id = 4U, Name = "Table 3"};

            var nonVisualGraphicFrameDrawingProperties1 = new NonVisualGraphicFrameDrawingProperties();
            var graphicFrameLocks1 = new GraphicFrameLocks {NoGrouping = true};

            nonVisualGraphicFrameDrawingProperties1.Append(graphicFrameLocks1);

            var applicationNonVisualDrawingProperties98 = new ApplicationNonVisualDrawingProperties();

            var applicationNonVisualDrawingPropertiesExtensionList1 =
                new ApplicationNonVisualDrawingPropertiesExtensionList();

            var applicationNonVisualDrawingPropertiesExtension1 = new ApplicationNonVisualDrawingPropertiesExtension
                {
                    Uri = "{D42A27DB-BD31-4B8C-83A1-F6EECF244321}"
                };

            var modificationId1 = new ModificationId {Val = 2159725999U};
            modificationId1.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            applicationNonVisualDrawingPropertiesExtension1.Append(modificationId1);

            applicationNonVisualDrawingPropertiesExtensionList1.Append(applicationNonVisualDrawingPropertiesExtension1);

            applicationNonVisualDrawingProperties98.Append(applicationNonVisualDrawingPropertiesExtensionList1);

            nonVisualGraphicFrameProperties1.Append(nonVisualDrawingProperties98);
            nonVisualGraphicFrameProperties1.Append(nonVisualGraphicFrameDrawingProperties1);
            nonVisualGraphicFrameProperties1.Append(applicationNonVisualDrawingProperties98);

            var transform1 = new Transform();
            var offset54 = new Offset {X = 228600L, Y = 1295400L};
            var extents54 = new Extents {Cx = 2819400L, Cy = 274320L};

            transform1.Append(offset54);
            transform1.Append(extents54);

            var graphic1 = new Graphic();

            var graphicData1 = new GraphicData {Uri = "http://schemas.openxmlformats.org/drawingml/2006/table"};

            var table1 = new Table();

            var tableProperties1 = new TableProperties {FirstRow = true, FirstColumn = true, BandRow = true};
            var tableStyleId1 = new TableStyleId();
            tableStyleId1.Text = "{5C22544A-7EE6-4342-B048-85BDC9FD1C3A}";

            tableProperties1.Append(tableStyleId1);

            var tableGrid1 = new TableGrid();
            var gridColumn1 = new GridColumn {Width = 1828800L};
            var gridColumn2 = new GridColumn {Width = 990600L};

            tableGrid1.Append(gridColumn1);
            tableGrid1.Append(gridColumn2);

            var tableRow1 = new TableRow {Height = 228600L};

            var tableCell1 = new TableCell();

            var textBody80 = new DocumentFormat.OpenXml.Drawing.TextBody();
            var bodyProperties82 = new BodyProperties();
            var listStyle82 = new ListStyle();

            var paragraph116 = new Paragraph();
            var endParagraphRunProperties75 = new EndParagraphRunProperties
                {
                    Language = "en-US",
                    FontSize = 1200,
                    Dirty = false
                };

            paragraph116.Append(endParagraphRunProperties75);

            textBody80.Append(bodyProperties82);
            textBody80.Append(listStyle82);
            textBody80.Append(paragraph116);
            var tableCellProperties1 = new TableCellProperties();

            tableCell1.Append(textBody80);
            tableCell1.Append(tableCellProperties1);

            var tableCell2 = new TableCell();

            var textBody81 = new DocumentFormat.OpenXml.Drawing.TextBody();
            var bodyProperties83 = new BodyProperties();
            var listStyle83 = new ListStyle();

            var paragraph117 = new Paragraph();

            var run72 = new Run();

            var runProperties100 = new RunProperties {Language = "en-US", FontSize = 1200, Dirty = false};
            runProperties100.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text100 = new Text();
            text100.Text = "Concerns";

            run72.Append(runProperties100);
            run72.Append(text100);
            var endParagraphRunProperties76 = new EndParagraphRunProperties
                {
                    Language = "en-US",
                    FontSize = 1200,
                    Dirty = false
                };

            paragraph117.Append(run72);
            paragraph117.Append(endParagraphRunProperties76);

            textBody81.Append(bodyProperties83);
            textBody81.Append(listStyle83);
            textBody81.Append(paragraph117);
            var tableCellProperties2 = new TableCellProperties();

            tableCell2.Append(textBody81);
            tableCell2.Append(tableCellProperties2);

            tableRow1.Append(tableCell1);
            tableRow1.Append(tableCell2);

            table1.Append(tableProperties1);
            table1.Append(tableGrid1);
            table1.Append(tableRow1);

            graphicData1.Append(table1);

            graphic1.Append(graphicData1);

            graphicFrame1.Append(nonVisualGraphicFrameProperties1);
            graphicFrame1.Append(transform1);
            graphicFrame1.Append(graphic1);

            var shape80 = new Shape();

            var nonVisualShapeProperties80 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties99 = new NonVisualDrawingProperties {Id = 5U, Name = "Title 2"};

            var nonVisualShapeDrawingProperties80 = new NonVisualShapeDrawingProperties {TextBox = true};
            var shapeLocks78 = new ShapeLocks();

            nonVisualShapeDrawingProperties80.Append(shapeLocks78);
            var applicationNonVisualDrawingProperties99 = new ApplicationNonVisualDrawingProperties();

            nonVisualShapeProperties80.Append(nonVisualDrawingProperties99);
            nonVisualShapeProperties80.Append(nonVisualShapeDrawingProperties80);
            nonVisualShapeProperties80.Append(applicationNonVisualDrawingProperties99);

            var shapeProperties83 = new ShapeProperties();

            var transform2D37 = new Transform2D();
            var offset55 = new Offset {X = 533400L, Y = 152400L};
            var extents55 = new Extents {Cx = 8042276L, Cy = 758732L};

            transform2D37.Append(offset55);
            transform2D37.Append(extents55);

            var presetGeometry11 = new PresetGeometry {Preset = ShapeTypeValues.Rectangle};
            var adjustValueList11 = new AdjustValueList();

            presetGeometry11.Append(adjustValueList11);

            shapeProperties83.Append(transform2D37);
            shapeProperties83.Append(presetGeometry11);

            var textBody82 = new TextBody();

            var bodyProperties84 = new BodyProperties
                {
                    Vertical = TextVerticalValues.Horizontal,
                    LeftInset = 91440,
                    TopInset = 45720,
                    RightInset = 91440,
                    BottomInset = 45720,
                    RightToLeftColumns = false,
                    Anchor = TextAnchoringTypeValues.Bottom,
                    AnchorCenter = false
                };
            var noAutoFit7 = new NoAutoFit();

            bodyProperties84.Append(noAutoFit7);

            var listStyle84 = new ListStyle();

            var level1ParagraphProperties31 = new Level1ParagraphProperties
                {
                    Alignment = TextAlignmentTypeValues.Center,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var spaceBefore28 = new SpaceBefore();
            var spacingPercent9 = new SpacingPercent {Val = 0};

            spaceBefore28.Append(spacingPercent9);
            var noBullet97 = new NoBullet();

            var defaultRunProperties181 = new DefaultRunProperties {FontSize = 4600, Kerning = 1200};

            var solidFill85 = new SolidFill();
            var schemeColor117 = new SchemeColor {Val = SchemeColorValues.Accent1};

            solidFill85.Append(schemeColor117);
            var latinFont37 = new LatinFont {Typeface = "+mj-lt"};
            var eastAsianFont37 = new EastAsianFont {Typeface = "+mj-ea"};
            var complexScriptFont37 = new ComplexScriptFont {Typeface = "+mj-cs"};

            defaultRunProperties181.Append(solidFill85);
            defaultRunProperties181.Append(latinFont37);
            defaultRunProperties181.Append(eastAsianFont37);
            defaultRunProperties181.Append(complexScriptFont37);

            level1ParagraphProperties31.Append(spaceBefore28);
            level1ParagraphProperties31.Append(noBullet97);
            level1ParagraphProperties31.Append(defaultRunProperties181);

            listStyle84.Append(level1ParagraphProperties31);

            var paragraph118 = new Paragraph();

            var run73 = new Run();

            var runProperties101 = new RunProperties {Language = "en-US", Dirty = false};
            runProperties101.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text101 = new Text();
            text101.Text = "{title}";

            run73.Append(runProperties101);
            run73.Append(text101);
            var endParagraphRunProperties77 = new EndParagraphRunProperties {Language = "en-US", Dirty = false};

            paragraph118.Append(run73);
            paragraph118.Append(endParagraphRunProperties77);

            textBody82.Append(bodyProperties84);
            textBody82.Append(listStyle84);
            textBody82.Append(paragraph118);

            shape80.Append(nonVisualShapeProperties80);
            shape80.Append(shapeProperties83);
            shape80.Append(textBody82);

            shapeTree17.Append(nonVisualGroupShapeProperties17);
            shapeTree17.Append(groupShapeProperties17);
            shapeTree17.Append(graphicFrame1);
            shapeTree17.Append(shape80);

            var commonSlideDataExtensionList4 = new CommonSlideDataExtensionList();

            var commonSlideDataExtension4 = new CommonSlideDataExtension
                {
                    Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}"
                };

            var creationId4 = new CreationId {Val = 1849363573U};
            creationId4.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension4.Append(creationId4);

            commonSlideDataExtensionList4.Append(commonSlideDataExtension4);

            commonSlideData17.Append(shapeTree17);
            commonSlideData17.Append(commonSlideDataExtensionList4);

            var colorMapOverride16 = new ColorMapOverride();
            var masterColorMapping16 = new MasterColorMapping();

            colorMapOverride16.Append(masterColorMapping16);

            var alternateContent2 = new AlternateContent();
            alternateContent2.AddNamespaceDeclaration("mc",
                                                      "http://schemas.openxmlformats.org/markup-compatibility/2006");
            alternateContent2.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            var alternateContentChoice2 = new AlternateContentChoice {Requires = "p14"};
            var transition3 = new Transition {Speed = TransitionSpeedValues.Slow, Duration = "2000"};

            alternateContentChoice2.Append(transition3);

            var alternateContentFallback2 = new AlternateContentFallback();

            var transition4 = new Transition {Speed = TransitionSpeedValues.Slow};
            transition4.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            alternateContentFallback2.Append(transition4);

            alternateContent2.Append(alternateContentChoice2);
            alternateContent2.Append(alternateContentFallback2);

            slide3.Append(commonSlideData17);
            slide3.Append(colorMapOverride16);
            slide3.Append(alternateContent2);

            slidePart3.Slide = slide3;
        }

        // Generates content of extendedPart1.
        private void GenerateExtendedPart1Content(ExtendedPart extendedPart1)
        {
            Stream data = GetBinaryDataStream(extendedPart1Data);
            extendedPart1.FeedData(data);
            data.Close();
        }

        // Generates content of presentationPropertiesPart1.
        private void GeneratePresentationPropertiesPart1Content(PresentationPropertiesPart presentationPropertiesPart1)
        {
            var presentationProperties1 = new PresentationProperties();
            presentationProperties1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            presentationProperties1.AddNamespaceDeclaration("r",
                                                            "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            presentationProperties1.AddNamespaceDeclaration("p",
                                                            "http://schemas.openxmlformats.org/presentationml/2006/main");

            var presentationPropertiesExtensionList1 = new PresentationPropertiesExtensionList();

            var presentationPropertiesExtension1 = new PresentationPropertiesExtension
                {
                    Uri = "{E76CE94A-603C-4142-B9EB-6D1370010A27}"
                };

            var discardImageEditData1 = new DiscardImageEditData {Val = false};
            discardImageEditData1.AddNamespaceDeclaration("p14",
                                                          "http://schemas.microsoft.com/office/powerpoint/2010/main");

            presentationPropertiesExtension1.Append(discardImageEditData1);

            var presentationPropertiesExtension2 = new PresentationPropertiesExtension
                {
                    Uri = "{D31A062A-798A-4329-ABDD-BBA856620510}"
                };

            var defaultImageDpi1 = new DefaultImageDpi {Val = 220U};
            defaultImageDpi1.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            presentationPropertiesExtension2.Append(defaultImageDpi1);

            presentationPropertiesExtensionList1.Append(presentationPropertiesExtension1);
            presentationPropertiesExtensionList1.Append(presentationPropertiesExtension2);

            presentationProperties1.Append(presentationPropertiesExtensionList1);

            presentationPropertiesPart1.PresentationProperties = presentationProperties1;
        }

        // Generates content of viewPropertiesPart1.
        private void GenerateViewPropertiesPart1Content(ViewPropertiesPart viewPropertiesPart1)
        {
            var viewProperties1 = new ViewProperties();
            viewProperties1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            viewProperties1.AddNamespaceDeclaration("r",
                                                    "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            viewProperties1.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            var normalViewProperties1 = new NormalViewProperties();
            var restoredLeft1 = new RestoredLeft {Size = 15620};
            var restoredTop1 = new RestoredTop {Size = 94660};

            normalViewProperties1.Append(restoredLeft1);
            normalViewProperties1.Append(restoredTop1);

            var slideViewProperties1 = new SlideViewProperties();

            var commonSlideViewProperties1 = new CommonSlideViewProperties();

            var commonViewProperties1 = new CommonViewProperties {VariableScale = true};

            var scaleFactor1 = new ScaleFactor();
            var scaleX1 = new ScaleX {Numerator = 90, Denominator = 100};
            var scaleY1 = new ScaleY {Numerator = 90, Denominator = 100};

            scaleFactor1.Append(scaleX1);
            scaleFactor1.Append(scaleY1);
            var origin1 = new Origin {X = -1560L, Y = -96L};

            commonViewProperties1.Append(scaleFactor1);
            commonViewProperties1.Append(origin1);

            var guideList1 = new GuideList();
            var guide1 = new Guide {Orientation = DirectionValues.Horizontal, Position = 2160};
            var guide2 = new Guide {Position = 2880};

            guideList1.Append(guide1);
            guideList1.Append(guide2);

            commonSlideViewProperties1.Append(commonViewProperties1);
            commonSlideViewProperties1.Append(guideList1);

            slideViewProperties1.Append(commonSlideViewProperties1);

            var notesTextViewProperties1 = new NotesTextViewProperties();

            var commonViewProperties2 = new CommonViewProperties();

            var scaleFactor2 = new ScaleFactor();
            var scaleX2 = new ScaleX {Numerator = 1, Denominator = 1};
            var scaleY2 = new ScaleY {Numerator = 1, Denominator = 1};

            scaleFactor2.Append(scaleX2);
            scaleFactor2.Append(scaleY2);
            var origin2 = new Origin {X = 0L, Y = 0L};

            commonViewProperties2.Append(scaleFactor2);
            commonViewProperties2.Append(origin2);

            notesTextViewProperties1.Append(commonViewProperties2);
            var gridSpacing1 = new GridSpacing {Cx = 76200L, Cy = 76200L};

            viewProperties1.Append(normalViewProperties1);
            viewProperties1.Append(slideViewProperties1);
            viewProperties1.Append(notesTextViewProperties1);
            viewProperties1.Append(gridSpacing1);

            viewPropertiesPart1.ViewProperties = viewProperties1;
        }

        // Generates content of tableStylesPart1.
        private void GenerateTableStylesPart1Content(TableStylesPart tableStylesPart1)
        {
            var tableStyleList1 = new TableStyleList {Default = "{5C22544A-7EE6-4342-B048-85BDC9FD1C3A}"};
            tableStyleList1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            var tableStyleEntry1 = new TableStyleEntry
                {
                    StyleId = "{5C22544A-7EE6-4342-B048-85BDC9FD1C3A}",
                    StyleName = "Medium Style 2 - Accent 1"
                };

            var wholeTable1 = new WholeTable();

            var tableCellTextStyle1 = new TableCellTextStyle();

            var fontReference3 = new FontReference {Index = FontCollectionIndexValues.Minor};
            var presetColor4 = new PresetColor {Val = PresetColorValues.Black};

            fontReference3.Append(presetColor4);
            var schemeColor118 = new SchemeColor {Val = SchemeColorValues.Dark1};

            tableCellTextStyle1.Append(fontReference3);
            tableCellTextStyle1.Append(schemeColor118);

            var tableCellStyle1 = new TableCellStyle();

            var tableCellBorders1 = new TableCellBorders();

            var leftBorder1 = new LeftBorder();

            var outline8 = new Outline {Width = 12700, CompoundLineType = CompoundLineValues.Single};

            var solidFill86 = new SolidFill();
            var schemeColor119 = new SchemeColor {Val = SchemeColorValues.Light1};

            solidFill86.Append(schemeColor119);

            outline8.Append(solidFill86);

            leftBorder1.Append(outline8);

            var rightBorder1 = new RightBorder();

            var outline9 = new Outline {Width = 12700, CompoundLineType = CompoundLineValues.Single};

            var solidFill87 = new SolidFill();
            var schemeColor120 = new SchemeColor {Val = SchemeColorValues.Light1};

            solidFill87.Append(schemeColor120);

            outline9.Append(solidFill87);

            rightBorder1.Append(outline9);

            var topBorder1 = new TopBorder();

            var outline10 = new Outline {Width = 12700, CompoundLineType = CompoundLineValues.Single};

            var solidFill88 = new SolidFill();
            var schemeColor121 = new SchemeColor {Val = SchemeColorValues.Light1};

            solidFill88.Append(schemeColor121);

            outline10.Append(solidFill88);

            topBorder1.Append(outline10);

            var bottomBorder1 = new BottomBorder();

            var outline11 = new Outline {Width = 12700, CompoundLineType = CompoundLineValues.Single};

            var solidFill89 = new SolidFill();
            var schemeColor122 = new SchemeColor {Val = SchemeColorValues.Light1};

            solidFill89.Append(schemeColor122);

            outline11.Append(solidFill89);

            bottomBorder1.Append(outline11);

            var insideHorizontalBorder1 = new InsideHorizontalBorder();

            var outline12 = new Outline {Width = 12700, CompoundLineType = CompoundLineValues.Single};

            var solidFill90 = new SolidFill();
            var schemeColor123 = new SchemeColor {Val = SchemeColorValues.Light1};

            solidFill90.Append(schemeColor123);

            outline12.Append(solidFill90);

            insideHorizontalBorder1.Append(outline12);

            var insideVerticalBorder1 = new InsideVerticalBorder();

            var outline13 = new Outline {Width = 12700, CompoundLineType = CompoundLineValues.Single};

            var solidFill91 = new SolidFill();
            var schemeColor124 = new SchemeColor {Val = SchemeColorValues.Light1};

            solidFill91.Append(schemeColor124);

            outline13.Append(solidFill91);

            insideVerticalBorder1.Append(outline13);

            tableCellBorders1.Append(leftBorder1);
            tableCellBorders1.Append(rightBorder1);
            tableCellBorders1.Append(topBorder1);
            tableCellBorders1.Append(bottomBorder1);
            tableCellBorders1.Append(insideHorizontalBorder1);
            tableCellBorders1.Append(insideVerticalBorder1);

            var fillProperties1 = new FillProperties();

            var solidFill92 = new SolidFill();

            var schemeColor125 = new SchemeColor {Val = SchemeColorValues.Accent1};
            var tint44 = new Tint {Val = 20000};

            schemeColor125.Append(tint44);

            solidFill92.Append(schemeColor125);

            fillProperties1.Append(solidFill92);

            tableCellStyle1.Append(tableCellBorders1);
            tableCellStyle1.Append(fillProperties1);

            wholeTable1.Append(tableCellTextStyle1);
            wholeTable1.Append(tableCellStyle1);

            var band1Horizontal1 = new Band1Horizontal();

            var tableCellStyle2 = new TableCellStyle();
            var tableCellBorders2 = new TableCellBorders();

            var fillProperties2 = new FillProperties();

            var solidFill93 = new SolidFill();

            var schemeColor126 = new SchemeColor {Val = SchemeColorValues.Accent1};
            var tint45 = new Tint {Val = 40000};

            schemeColor126.Append(tint45);

            solidFill93.Append(schemeColor126);

            fillProperties2.Append(solidFill93);

            tableCellStyle2.Append(tableCellBorders2);
            tableCellStyle2.Append(fillProperties2);

            band1Horizontal1.Append(tableCellStyle2);

            var band2Horizontal1 = new Band2Horizontal();

            var tableCellStyle3 = new TableCellStyle();
            var tableCellBorders3 = new TableCellBorders();

            tableCellStyle3.Append(tableCellBorders3);

            band2Horizontal1.Append(tableCellStyle3);

            var band1Vertical1 = new Band1Vertical();

            var tableCellStyle4 = new TableCellStyle();
            var tableCellBorders4 = new TableCellBorders();

            var fillProperties3 = new FillProperties();

            var solidFill94 = new SolidFill();

            var schemeColor127 = new SchemeColor {Val = SchemeColorValues.Accent1};
            var tint46 = new Tint {Val = 40000};

            schemeColor127.Append(tint46);

            solidFill94.Append(schemeColor127);

            fillProperties3.Append(solidFill94);

            tableCellStyle4.Append(tableCellBorders4);
            tableCellStyle4.Append(fillProperties3);

            band1Vertical1.Append(tableCellStyle4);

            var band2Vertical1 = new Band2Vertical();

            var tableCellStyle5 = new TableCellStyle();
            var tableCellBorders5 = new TableCellBorders();

            tableCellStyle5.Append(tableCellBorders5);

            band2Vertical1.Append(tableCellStyle5);

            var lastColumn1 = new LastColumn();

            var tableCellTextStyle2 = new TableCellTextStyle {Bold = BooleanStyleValues.On};

            var fontReference4 = new FontReference {Index = FontCollectionIndexValues.Minor};
            var presetColor5 = new PresetColor {Val = PresetColorValues.Black};

            fontReference4.Append(presetColor5);
            var schemeColor128 = new SchemeColor {Val = SchemeColorValues.Light1};

            tableCellTextStyle2.Append(fontReference4);
            tableCellTextStyle2.Append(schemeColor128);

            var tableCellStyle6 = new TableCellStyle();
            var tableCellBorders6 = new TableCellBorders();

            var fillProperties4 = new FillProperties();

            var solidFill95 = new SolidFill();
            var schemeColor129 = new SchemeColor {Val = SchemeColorValues.Accent1};

            solidFill95.Append(schemeColor129);

            fillProperties4.Append(solidFill95);

            tableCellStyle6.Append(tableCellBorders6);
            tableCellStyle6.Append(fillProperties4);

            lastColumn1.Append(tableCellTextStyle2);
            lastColumn1.Append(tableCellStyle6);

            var firstColumn1 = new FirstColumn();

            var tableCellTextStyle3 = new TableCellTextStyle {Bold = BooleanStyleValues.On};

            var fontReference5 = new FontReference {Index = FontCollectionIndexValues.Minor};
            var presetColor6 = new PresetColor {Val = PresetColorValues.Black};

            fontReference5.Append(presetColor6);
            var schemeColor130 = new SchemeColor {Val = SchemeColorValues.Light1};

            tableCellTextStyle3.Append(fontReference5);
            tableCellTextStyle3.Append(schemeColor130);

            var tableCellStyle7 = new TableCellStyle();
            var tableCellBorders7 = new TableCellBorders();

            var fillProperties5 = new FillProperties();

            var solidFill96 = new SolidFill();
            var schemeColor131 = new SchemeColor {Val = SchemeColorValues.Accent1};

            solidFill96.Append(schemeColor131);

            fillProperties5.Append(solidFill96);

            tableCellStyle7.Append(tableCellBorders7);
            tableCellStyle7.Append(fillProperties5);

            firstColumn1.Append(tableCellTextStyle3);
            firstColumn1.Append(tableCellStyle7);

            var lastRow1 = new LastRow();

            var tableCellTextStyle4 = new TableCellTextStyle {Bold = BooleanStyleValues.On};

            var fontReference6 = new FontReference {Index = FontCollectionIndexValues.Minor};
            var presetColor7 = new PresetColor {Val = PresetColorValues.Black};

            fontReference6.Append(presetColor7);
            var schemeColor132 = new SchemeColor {Val = SchemeColorValues.Light1};

            tableCellTextStyle4.Append(fontReference6);
            tableCellTextStyle4.Append(schemeColor132);

            var tableCellStyle8 = new TableCellStyle();

            var tableCellBorders8 = new TableCellBorders();

            var topBorder2 = new TopBorder();

            var outline14 = new Outline {Width = 38100, CompoundLineType = CompoundLineValues.Single};

            var solidFill97 = new SolidFill();
            var schemeColor133 = new SchemeColor {Val = SchemeColorValues.Light1};

            solidFill97.Append(schemeColor133);

            outline14.Append(solidFill97);

            topBorder2.Append(outline14);

            tableCellBorders8.Append(topBorder2);

            var fillProperties6 = new FillProperties();

            var solidFill98 = new SolidFill();
            var schemeColor134 = new SchemeColor {Val = SchemeColorValues.Accent1};

            solidFill98.Append(schemeColor134);

            fillProperties6.Append(solidFill98);

            tableCellStyle8.Append(tableCellBorders8);
            tableCellStyle8.Append(fillProperties6);

            lastRow1.Append(tableCellTextStyle4);
            lastRow1.Append(tableCellStyle8);

            var firstRow1 = new FirstRow();

            var tableCellTextStyle5 = new TableCellTextStyle {Bold = BooleanStyleValues.On};

            var fontReference7 = new FontReference {Index = FontCollectionIndexValues.Minor};
            var presetColor8 = new PresetColor {Val = PresetColorValues.Black};

            fontReference7.Append(presetColor8);
            var schemeColor135 = new SchemeColor {Val = SchemeColorValues.Light1};

            tableCellTextStyle5.Append(fontReference7);
            tableCellTextStyle5.Append(schemeColor135);

            var tableCellStyle9 = new TableCellStyle();

            var tableCellBorders9 = new TableCellBorders();

            var bottomBorder2 = new BottomBorder();

            var outline15 = new Outline {Width = 38100, CompoundLineType = CompoundLineValues.Single};

            var solidFill99 = new SolidFill();
            var schemeColor136 = new SchemeColor {Val = SchemeColorValues.Light1};

            solidFill99.Append(schemeColor136);

            outline15.Append(solidFill99);

            bottomBorder2.Append(outline15);

            tableCellBorders9.Append(bottomBorder2);

            var fillProperties7 = new FillProperties();

            var solidFill100 = new SolidFill();
            var schemeColor137 = new SchemeColor {Val = SchemeColorValues.Accent1};

            solidFill100.Append(schemeColor137);

            fillProperties7.Append(solidFill100);

            tableCellStyle9.Append(tableCellBorders9);
            tableCellStyle9.Append(fillProperties7);

            firstRow1.Append(tableCellTextStyle5);
            firstRow1.Append(tableCellStyle9);

            tableStyleEntry1.Append(wholeTable1);
            tableStyleEntry1.Append(band1Horizontal1);
            tableStyleEntry1.Append(band2Horizontal1);
            tableStyleEntry1.Append(band1Vertical1);
            tableStyleEntry1.Append(band2Vertical1);
            tableStyleEntry1.Append(lastColumn1);
            tableStyleEntry1.Append(firstColumn1);
            tableStyleEntry1.Append(lastRow1);
            tableStyleEntry1.Append(firstRow1);

            tableStyleList1.Append(tableStyleEntry1);

            tableStylesPart1.TableStyleList = tableStyleList1;
        }

        // Generates content of slidePart4.
        private void GenerateSlidePart4Content(SlidePart slidePart4)
        {
            var slide4 = new Slide();
            slide4.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slide4.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slide4.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            var commonSlideData18 = new CommonSlideData();

            var shapeTree18 = new ShapeTree();

            var nonVisualGroupShapeProperties18 = new NonVisualGroupShapeProperties();
            var nonVisualDrawingProperties100 = new NonVisualDrawingProperties {Id = 1U, Name = ""};
            var nonVisualGroupShapeDrawingProperties18 = new NonVisualGroupShapeDrawingProperties();
            var applicationNonVisualDrawingProperties100 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties18.Append(nonVisualDrawingProperties100);
            nonVisualGroupShapeProperties18.Append(nonVisualGroupShapeDrawingProperties18);
            nonVisualGroupShapeProperties18.Append(applicationNonVisualDrawingProperties100);

            var groupShapeProperties18 = new GroupShapeProperties();

            var transformGroup18 = new TransformGroup();
            var offset56 = new Offset {X = 0L, Y = 0L};
            var extents56 = new Extents {Cx = 0L, Cy = 0L};
            var childOffset18 = new ChildOffset {X = 0L, Y = 0L};
            var childExtents18 = new ChildExtents {Cx = 0L, Cy = 0L};

            transformGroup18.Append(offset56);
            transformGroup18.Append(extents56);
            transformGroup18.Append(childOffset18);
            transformGroup18.Append(childExtents18);

            groupShapeProperties18.Append(transformGroup18);

            var graphicFrame2 = new GraphicFrame();

            var nonVisualGraphicFrameProperties2 = new NonVisualGraphicFrameProperties();
            var nonVisualDrawingProperties101 = new NonVisualDrawingProperties {Id = 4U, Name = "Table 3"};

            var nonVisualGraphicFrameDrawingProperties2 = new NonVisualGraphicFrameDrawingProperties();
            var graphicFrameLocks2 = new GraphicFrameLocks {NoGrouping = true};

            nonVisualGraphicFrameDrawingProperties2.Append(graphicFrameLocks2);

            var applicationNonVisualDrawingProperties101 = new ApplicationNonVisualDrawingProperties();

            var applicationNonVisualDrawingPropertiesExtensionList2 =
                new ApplicationNonVisualDrawingPropertiesExtensionList();

            var applicationNonVisualDrawingPropertiesExtension2 = new ApplicationNonVisualDrawingPropertiesExtension
                {
                    Uri = "{D42A27DB-BD31-4B8C-83A1-F6EECF244321}"
                };

            var modificationId2 = new ModificationId {Val = 268369441U};
            modificationId2.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            applicationNonVisualDrawingPropertiesExtension2.Append(modificationId2);

            applicationNonVisualDrawingPropertiesExtensionList2.Append(applicationNonVisualDrawingPropertiesExtension2);

            applicationNonVisualDrawingProperties101.Append(applicationNonVisualDrawingPropertiesExtensionList2);

            nonVisualGraphicFrameProperties2.Append(nonVisualDrawingProperties101);
            nonVisualGraphicFrameProperties2.Append(nonVisualGraphicFrameDrawingProperties2);
            nonVisualGraphicFrameProperties2.Append(applicationNonVisualDrawingProperties101);

            var transform2 = new Transform();
            var offset57 = new Offset {X = 228600L, Y = 1219200L};
            var extents57 = new Extents {Cx = 8610600L, Cy = 2926080L};

            transform2.Append(offset57);
            transform2.Append(extents57);

            var graphic2 = new Graphic();

            var graphicData2 = new GraphicData {Uri = "http://schemas.openxmlformats.org/drawingml/2006/table"};

            var table2 = new Table();

            var tableProperties2 = new TableProperties {FirstColumn = true, BandRow = true};
            var tableStyleId2 = new TableStyleId();
            tableStyleId2.Text = "{5C22544A-7EE6-4342-B048-85BDC9FD1C3A}";

            tableProperties2.Append(tableStyleId2);

            var tableGrid2 = new TableGrid();
            var gridColumn3 = new GridColumn {Width = 1295399L};
            var gridColumn4 = new GridColumn {Width = 7315201L};

            tableGrid2.Append(gridColumn3);
            tableGrid2.Append(gridColumn4);

            var tableRow2 = new TableRow {Height = 304800L};

            var tableCell3 = new TableCell();

            var textBody83 = new DocumentFormat.OpenXml.Drawing.TextBody();
            var bodyProperties85 = new BodyProperties();
            var listStyle85 = new ListStyle();

            var paragraph119 = new Paragraph();

            var run74 = new Run();

            var runProperties102 = new RunProperties {Language = "en-US", FontSize = 1000, Dirty = false};
            runProperties102.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text102 = new Text();
            text102.Text = "State";

            run74.Append(runProperties102);
            run74.Append(text102);
            var endParagraphRunProperties78 = new EndParagraphRunProperties
                {
                    Language = "en-US",
                    FontSize = 1000,
                    Dirty = false
                };

            paragraph119.Append(run74);
            paragraph119.Append(endParagraphRunProperties78);

            textBody83.Append(bodyProperties85);
            textBody83.Append(listStyle85);
            textBody83.Append(paragraph119);
            var tableCellProperties3 = new TableCellProperties();

            tableCell3.Append(textBody83);
            tableCell3.Append(tableCellProperties3);

            var tableCell4 = new TableCell();

            var textBody84 = new DocumentFormat.OpenXml.Drawing.TextBody();
            var bodyProperties86 = new BodyProperties();
            var listStyle86 = new ListStyle();

            var paragraph120 = new Paragraph();

            var run75 = new Run();

            var runProperties103 = new RunProperties {Language = "en-US", FontSize = 1000, Dirty = false};
            runProperties103.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text103 = new Text();
            text103.Text = "{state}";

            run75.Append(runProperties103);
            run75.Append(text103);
            var endParagraphRunProperties79 = new EndParagraphRunProperties
                {
                    Language = "en-US",
                    FontSize = 1000,
                    Dirty = false
                };

            paragraph120.Append(run75);
            paragraph120.Append(endParagraphRunProperties79);

            textBody84.Append(bodyProperties86);
            textBody84.Append(listStyle86);
            textBody84.Append(paragraph120);
            var tableCellProperties4 = new TableCellProperties();

            tableCell4.Append(textBody84);
            tableCell4.Append(tableCellProperties4);

            tableRow2.Append(tableCell3);
            tableRow2.Append(tableCell4);

            var tableRow3 = new TableRow {Height = 304800L};

            var tableCell5 = new TableCell();

            var textBody85 = new DocumentFormat.OpenXml.Drawing.TextBody();
            var bodyProperties87 = new BodyProperties();
            var listStyle87 = new ListStyle();

            var paragraph121 = new Paragraph();

            var run76 = new Run();

            var runProperties104 = new RunProperties {Language = "en-US", FontSize = 1000, Dirty = false};
            runProperties104.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text104 = new Text();
            text104.Text = "Topic";

            run76.Append(runProperties104);
            run76.Append(text104);
            var endParagraphRunProperties80 = new EndParagraphRunProperties
                {
                    Language = "en-US",
                    FontSize = 1000,
                    Dirty = false
                };

            paragraph121.Append(run76);
            paragraph121.Append(endParagraphRunProperties80);

            textBody85.Append(bodyProperties87);
            textBody85.Append(listStyle87);
            textBody85.Append(paragraph121);
            var tableCellProperties5 = new TableCellProperties();

            tableCell5.Append(textBody85);
            tableCell5.Append(tableCellProperties5);

            var tableCell6 = new TableCell();

            var textBody86 = new DocumentFormat.OpenXml.Drawing.TextBody();
            var bodyProperties88 = new BodyProperties();
            var listStyle88 = new ListStyle();

            var paragraph122 = new Paragraph();

            var run77 = new Run();

            var runProperties105 = new RunProperties {Language = "en-US", FontSize = 1000, Dirty = false};
            runProperties105.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text105 = new Text();
            text105.Text = "{topic}";

            run77.Append(runProperties105);
            run77.Append(text105);
            var endParagraphRunProperties81 = new EndParagraphRunProperties
                {
                    Language = "en-US",
                    FontSize = 1000,
                    Dirty = false
                };

            paragraph122.Append(run77);
            paragraph122.Append(endParagraphRunProperties81);

            textBody86.Append(bodyProperties88);
            textBody86.Append(listStyle88);
            textBody86.Append(paragraph122);
            var tableCellProperties6 = new TableCellProperties();

            tableCell6.Append(textBody86);
            tableCell6.Append(tableCellProperties6);

            tableRow3.Append(tableCell5);
            tableRow3.Append(tableCell6);

            var tableRow4 = new TableRow {Height = 304800L};

            var tableCell7 = new TableCell();

            var textBody87 = new DocumentFormat.OpenXml.Drawing.TextBody();
            var bodyProperties89 = new BodyProperties();
            var listStyle89 = new ListStyle();

            var paragraph123 = new Paragraph();

            var run78 = new Run();

            var runProperties106 = new RunProperties {Language = "en-US", FontSize = 1000, Dirty = false};
            runProperties106.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text106 = new Text();
            text106.Text = "Problem/Problem";

            run78.Append(runProperties106);
            run78.Append(text106);
            var endParagraphRunProperties82 = new EndParagraphRunProperties
                {
                    Language = "en-US",
                    FontSize = 1000,
                    Dirty = false
                };

            paragraph123.Append(run78);
            paragraph123.Append(endParagraphRunProperties82);

            textBody87.Append(bodyProperties89);
            textBody87.Append(listStyle89);
            textBody87.Append(paragraph123);
            var tableCellProperties7 = new TableCellProperties();

            tableCell7.Append(textBody87);
            tableCell7.Append(tableCellProperties7);

            var tableCell8 = new TableCell();

            var textBody88 = new DocumentFormat.OpenXml.Drawing.TextBody();
            var bodyProperties90 = new BodyProperties();
            var listStyle90 = new ListStyle();

            var paragraph124 = new Paragraph();

            var run79 = new Run();

            var runProperties107 = new RunProperties {Language = "en-US", FontSize = 1000, Dirty = false};
            runProperties107.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text107 = new Text();
            text107.Text = "{issue}";

            run79.Append(runProperties107);
            run79.Append(text107);
            var endParagraphRunProperties83 = new EndParagraphRunProperties
                {
                    Language = "en-US",
                    FontSize = 1000,
                    Dirty = false
                };

            paragraph124.Append(run79);
            paragraph124.Append(endParagraphRunProperties83);

            textBody88.Append(bodyProperties90);
            textBody88.Append(listStyle90);
            textBody88.Append(paragraph124);
            var tableCellProperties8 = new TableCellProperties();

            tableCell8.Append(textBody88);
            tableCell8.Append(tableCellProperties8);

            tableRow4.Append(tableCell7);
            tableRow4.Append(tableCell8);

            var tableRow5 = new TableRow {Height = 304800L};

            var tableCell9 = new TableCell();

            var textBody89 = new DocumentFormat.OpenXml.Drawing.TextBody();
            var bodyProperties91 = new BodyProperties();
            var listStyle91 = new ListStyle();

            var paragraph125 = new Paragraph();

            var run80 = new Run();

            var runProperties108 = new RunProperties {Language = "en-US", FontSize = 1000, Dirty = false};
            runProperties108.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text108 = new Text();
            text108.Text = "Decision";

            run80.Append(runProperties108);
            run80.Append(text108);
            var endParagraphRunProperties84 = new EndParagraphRunProperties
                {
                    Language = "en-US",
                    FontSize = 1000,
                    Dirty = false
                };

            paragraph125.Append(run80);
            paragraph125.Append(endParagraphRunProperties84);

            textBody89.Append(bodyProperties91);
            textBody89.Append(listStyle91);
            textBody89.Append(paragraph125);
            var tableCellProperties9 = new TableCellProperties();

            tableCell9.Append(textBody89);
            tableCell9.Append(tableCellProperties9);

            var tableCell10 = new TableCell();

            var textBody90 = new DocumentFormat.OpenXml.Drawing.TextBody();
            var bodyProperties92 = new BodyProperties();
            var listStyle92 = new ListStyle();

            var paragraph126 = new Paragraph();

            var run81 = new Run();

            var runProperties109 = new RunProperties {Language = "en-US", FontSize = 1000, Dirty = false};
            runProperties109.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text109 = new Text();
            text109.Text = "{decision}";

            run81.Append(runProperties109);
            run81.Append(text109);
            var endParagraphRunProperties85 = new EndParagraphRunProperties
                {
                    Language = "en-US",
                    FontSize = 1000,
                    Dirty = false
                };

            paragraph126.Append(run81);
            paragraph126.Append(endParagraphRunProperties85);

            textBody90.Append(bodyProperties92);
            textBody90.Append(listStyle92);
            textBody90.Append(paragraph126);
            var tableCellProperties10 = new TableCellProperties();

            tableCell10.Append(textBody90);
            tableCell10.Append(tableCellProperties10);

            tableRow5.Append(tableCell9);
            tableRow5.Append(tableCell10);

            var tableRow6 = new TableRow {Height = 304800L};

            var tableCell11 = new TableCell();

            var textBody91 = new DocumentFormat.OpenXml.Drawing.TextBody();
            var bodyProperties93 = new BodyProperties();
            var listStyle93 = new ListStyle();

            var paragraph127 = new Paragraph();

            var run82 = new Run();

            var runProperties110 = new RunProperties {Language = "en-US", FontSize = 1000, Dirty = false};
            runProperties110.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text110 = new Text();
            text110.Text = "Alternatives";

            run82.Append(runProperties110);
            run82.Append(text110);
            var endParagraphRunProperties86 = new EndParagraphRunProperties
                {
                    Language = "en-US",
                    FontSize = 1000,
                    Dirty = false
                };

            paragraph127.Append(run82);
            paragraph127.Append(endParagraphRunProperties86);

            textBody91.Append(bodyProperties93);
            textBody91.Append(listStyle93);
            textBody91.Append(paragraph127);
            var tableCellProperties11 = new TableCellProperties();

            tableCell11.Append(textBody91);
            tableCell11.Append(tableCellProperties11);

            var tableCell12 = new TableCell();

            var textBody92 = new DocumentFormat.OpenXml.Drawing.TextBody();
            var bodyProperties94 = new BodyProperties();
            var listStyle94 = new ListStyle();

            var paragraph128 = new Paragraph();

            var run83 = new Run();

            var runProperties111 = new RunProperties {Language = "en-US", FontSize = 1000, Dirty = false};
            runProperties111.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text111 = new Text();
            text111.Text = "{alternatives}";

            run83.Append(runProperties111);
            run83.Append(text111);
            var endParagraphRunProperties87 = new EndParagraphRunProperties
                {
                    Language = "en-US",
                    FontSize = 1000,
                    Dirty = false
                };

            paragraph128.Append(run83);
            paragraph128.Append(endParagraphRunProperties87);

            textBody92.Append(bodyProperties94);
            textBody92.Append(listStyle94);
            textBody92.Append(paragraph128);
            var tableCellProperties12 = new TableCellProperties();

            tableCell12.Append(textBody92);
            tableCell12.Append(tableCellProperties12);

            tableRow6.Append(tableCell11);
            tableRow6.Append(tableCell12);

            var tableRow7 = new TableRow {Height = 304800L};

            var tableCell13 = new TableCell();

            var textBody93 = new DocumentFormat.OpenXml.Drawing.TextBody();
            var bodyProperties95 = new BodyProperties();
            var listStyle95 = new ListStyle();

            var paragraph129 = new Paragraph();

            var run84 = new Run();

            var runProperties112 = new RunProperties {Language = "en-US", FontSize = 1000, Dirty = false};
            runProperties112.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text112 = new Text();
            text112.Text = "Argumentation";

            run84.Append(runProperties112);
            run84.Append(text112);
            var endParagraphRunProperties88 = new EndParagraphRunProperties
                {
                    Language = "en-US",
                    FontSize = 1000,
                    Dirty = false
                };

            paragraph129.Append(run84);
            paragraph129.Append(endParagraphRunProperties88);

            textBody93.Append(bodyProperties95);
            textBody93.Append(listStyle95);
            textBody93.Append(paragraph129);
            var tableCellProperties13 = new TableCellProperties();

            tableCell13.Append(textBody93);
            tableCell13.Append(tableCellProperties13);

            var tableCell14 = new TableCell();

            var textBody94 = new DocumentFormat.OpenXml.Drawing.TextBody();
            var bodyProperties96 = new BodyProperties();
            var listStyle96 = new ListStyle();

            var paragraph130 = new Paragraph();

            var run85 = new Run();

            var runProperties113 = new RunProperties {Language = "en-US", FontSize = 1000, Dirty = false};
            runProperties113.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text113 = new Text();
            text113.Text = "{arguments}";

            run85.Append(runProperties113);
            run85.Append(text113);
            var endParagraphRunProperties89 = new EndParagraphRunProperties
                {
                    Language = "en-US",
                    FontSize = 1000,
                    Dirty = false
                };

            paragraph130.Append(run85);
            paragraph130.Append(endParagraphRunProperties89);

            textBody94.Append(bodyProperties96);
            textBody94.Append(listStyle96);
            textBody94.Append(paragraph130);
            var tableCellProperties14 = new TableCellProperties();

            tableCell14.Append(textBody94);
            tableCell14.Append(tableCellProperties14);

            tableRow7.Append(tableCell13);
            tableRow7.Append(tableCell14);

            var tableRow8 = new TableRow {Height = 304800L};

            var tableCell15 = new TableCell();

            var textBody95 = new DocumentFormat.OpenXml.Drawing.TextBody();
            var bodyProperties97 = new BodyProperties();
            var listStyle97 = new ListStyle();

            var paragraph131 = new Paragraph();

            var run86 = new Run();

            var runProperties114 = new RunProperties {Language = "en-US", FontSize = 1000, Dirty = false};
            runProperties114.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text114 = new Text();
            text114.Text = "Related Decision";

            run86.Append(runProperties114);
            run86.Append(text114);
            var endParagraphRunProperties90 = new EndParagraphRunProperties
                {
                    Language = "en-US",
                    FontSize = 1000,
                    Dirty = false
                };

            paragraph131.Append(run86);
            paragraph131.Append(endParagraphRunProperties90);

            textBody95.Append(bodyProperties97);
            textBody95.Append(listStyle97);
            textBody95.Append(paragraph131);
            var tableCellProperties15 = new TableCellProperties();

            tableCell15.Append(textBody95);
            tableCell15.Append(tableCellProperties15);

            var tableCell16 = new TableCell();

            var textBody96 = new DocumentFormat.OpenXml.Drawing.TextBody();
            var bodyProperties98 = new BodyProperties();
            var listStyle98 = new ListStyle();

            var paragraph132 = new Paragraph();

            var run87 = new Run();

            var runProperties115 = new RunProperties {Language = "en-US", FontSize = 1000, Dirty = false};
            runProperties115.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text115 = new Text();
            text115.Text = "{decisions}";

            run87.Append(runProperties115);
            run87.Append(text115);
            var endParagraphRunProperties91 = new EndParagraphRunProperties
                {
                    Language = "en-US",
                    FontSize = 1000,
                    Dirty = false
                };

            paragraph132.Append(run87);
            paragraph132.Append(endParagraphRunProperties91);

            textBody96.Append(bodyProperties98);
            textBody96.Append(listStyle98);
            textBody96.Append(paragraph132);
            var tableCellProperties16 = new TableCellProperties();

            tableCell16.Append(textBody96);
            tableCell16.Append(tableCellProperties16);

            tableRow8.Append(tableCell15);
            tableRow8.Append(tableCell16);

            var tableRow9 = new TableRow {Height = 304800L};

            var tableCell17 = new TableCell();

            var textBody97 = new DocumentFormat.OpenXml.Drawing.TextBody();
            var bodyProperties99 = new BodyProperties();
            var listStyle99 = new ListStyle();

            var paragraph133 = new Paragraph();

            var run88 = new Run();

            var runProperties116 = new RunProperties {Language = "en-US", FontSize = 1000, Dirty = false};
            runProperties116.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text116 = new Text();
            text116.Text = "Related Forces";

            run88.Append(runProperties116);
            run88.Append(text116);
            var endParagraphRunProperties92 = new EndParagraphRunProperties
                {
                    Language = "en-US",
                    FontSize = 1000,
                    Dirty = false
                };

            paragraph133.Append(run88);
            paragraph133.Append(endParagraphRunProperties92);

            textBody97.Append(bodyProperties99);
            textBody97.Append(listStyle99);
            textBody97.Append(paragraph133);
            var tableCellProperties17 = new TableCellProperties();

            tableCell17.Append(textBody97);
            tableCell17.Append(tableCellProperties17);

            var tableCell18 = new TableCell();

            var textBody98 = new DocumentFormat.OpenXml.Drawing.TextBody();
            var bodyProperties100 = new BodyProperties();
            var listStyle100 = new ListStyle();

            var paragraph134 = new Paragraph();

            var run89 = new Run();

            var runProperties117 = new RunProperties {Language = "en-US", FontSize = 1000, Dirty = false};
            runProperties117.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text117 = new Text();
            text117.Text = "{forces}";

            run89.Append(runProperties117);
            run89.Append(text117);
            var endParagraphRunProperties93 = new EndParagraphRunProperties
                {
                    Language = "en-US",
                    FontSize = 1000,
                    Dirty = false
                };

            paragraph134.Append(run89);
            paragraph134.Append(endParagraphRunProperties93);

            textBody98.Append(bodyProperties100);
            textBody98.Append(listStyle100);
            textBody98.Append(paragraph134);
            var tableCellProperties18 = new TableCellProperties();

            tableCell18.Append(textBody98);
            tableCell18.Append(tableCellProperties18);

            tableRow9.Append(tableCell17);
            tableRow9.Append(tableCell18);

            var tableRow10 = new TableRow {Height = 304800L};

            var tableCell19 = new TableCell();

            var textBody99 = new DocumentFormat.OpenXml.Drawing.TextBody();
            var bodyProperties101 = new BodyProperties();
            var listStyle101 = new ListStyle();

            var paragraph135 = new Paragraph();

            var run90 = new Run();

            var runProperties118 = new RunProperties {Language = "en-US", FontSize = 1000, Dirty = false};
            runProperties118.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text118 = new Text();
            text118.Text = "Related Components";

            run90.Append(runProperties118);
            run90.Append(text118);
            var endParagraphRunProperties94 = new EndParagraphRunProperties
                {
                    Language = "en-US",
                    FontSize = 1000,
                    Dirty = false
                };

            paragraph135.Append(run90);
            paragraph135.Append(endParagraphRunProperties94);

            textBody99.Append(bodyProperties101);
            textBody99.Append(listStyle101);
            textBody99.Append(paragraph135);
            var tableCellProperties19 = new TableCellProperties();

            tableCell19.Append(textBody99);
            tableCell19.Append(tableCellProperties19);

            var tableCell20 = new TableCell();

            var textBody100 = new DocumentFormat.OpenXml.Drawing.TextBody();
            var bodyProperties102 = new BodyProperties();
            var listStyle102 = new ListStyle();

            var paragraph136 = new Paragraph();

            var run91 = new Run();

            var runProperties119 = new RunProperties {Language = "en-US", FontSize = 1000, Dirty = false};
            runProperties119.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text119 = new Text();
            text119.Text = "{traces}";

            run91.Append(runProperties119);
            run91.Append(text119);
            var endParagraphRunProperties95 = new EndParagraphRunProperties
                {
                    Language = "en-US",
                    FontSize = 1000,
                    Dirty = false
                };

            paragraph136.Append(run91);
            paragraph136.Append(endParagraphRunProperties95);

            textBody100.Append(bodyProperties102);
            textBody100.Append(listStyle102);
            textBody100.Append(paragraph136);
            var tableCellProperties20 = new TableCellProperties();

            tableCell20.Append(textBody100);
            tableCell20.Append(tableCellProperties20);

            tableRow10.Append(tableCell19);
            tableRow10.Append(tableCell20);

            table2.Append(tableProperties2);
            table2.Append(tableGrid2);
            table2.Append(tableRow2);
            table2.Append(tableRow3);
            table2.Append(tableRow4);
            table2.Append(tableRow5);
            table2.Append(tableRow6);
            table2.Append(tableRow7);
            table2.Append(tableRow8);
            table2.Append(tableRow9);
            table2.Append(tableRow10);

            graphicData2.Append(table2);

            graphic2.Append(graphicData2);

            graphicFrame2.Append(nonVisualGraphicFrameProperties2);
            graphicFrame2.Append(transform2);
            graphicFrame2.Append(graphic2);

            var shape81 = new Shape();

            var nonVisualShapeProperties81 = new NonVisualShapeProperties();
            var nonVisualDrawingProperties102 = new NonVisualDrawingProperties {Id = 3U, Name = "Title 2"};

            var nonVisualShapeDrawingProperties81 = new NonVisualShapeDrawingProperties {TextBox = true};
            var shapeLocks79 = new ShapeLocks();

            nonVisualShapeDrawingProperties81.Append(shapeLocks79);
            var applicationNonVisualDrawingProperties102 = new ApplicationNonVisualDrawingProperties();

            nonVisualShapeProperties81.Append(nonVisualDrawingProperties102);
            nonVisualShapeProperties81.Append(nonVisualShapeDrawingProperties81);
            nonVisualShapeProperties81.Append(applicationNonVisualDrawingProperties102);

            var shapeProperties84 = new ShapeProperties();

            var transform2D38 = new Transform2D();
            var offset58 = new Offset {X = 533400L, Y = 152400L};
            var extents58 = new Extents {Cx = 8042276L, Cy = 758732L};

            transform2D38.Append(offset58);
            transform2D38.Append(extents58);

            var presetGeometry12 = new PresetGeometry {Preset = ShapeTypeValues.Rectangle};
            var adjustValueList12 = new AdjustValueList();

            presetGeometry12.Append(adjustValueList12);

            shapeProperties84.Append(transform2D38);
            shapeProperties84.Append(presetGeometry12);

            var textBody101 = new TextBody();

            var bodyProperties103 = new BodyProperties
                {
                    Vertical = TextVerticalValues.Horizontal,
                    LeftInset = 91440,
                    TopInset = 45720,
                    RightInset = 91440,
                    BottomInset = 45720,
                    RightToLeftColumns = false,
                    Anchor = TextAnchoringTypeValues.Bottom,
                    AnchorCenter = false
                };
            var noAutoFit8 = new NoAutoFit();

            bodyProperties103.Append(noAutoFit8);

            var listStyle103 = new ListStyle();

            var level1ParagraphProperties32 = new Level1ParagraphProperties
                {
                    Alignment = TextAlignmentTypeValues.Center,
                    DefaultTabSize = 914400,
                    RightToLeft = false,
                    EastAsianLineBreak = true,
                    LatinLineBreak = false,
                    Height = true
                };

            var spaceBefore29 = new SpaceBefore();
            var spacingPercent10 = new SpacingPercent {Val = 0};

            spaceBefore29.Append(spacingPercent10);
            var noBullet98 = new NoBullet();

            var defaultRunProperties182 = new DefaultRunProperties {FontSize = 4600, Kerning = 1200};

            var solidFill101 = new SolidFill();
            var schemeColor138 = new SchemeColor {Val = SchemeColorValues.Accent1};

            solidFill101.Append(schemeColor138);
            var latinFont38 = new LatinFont {Typeface = "+mj-lt"};
            var eastAsianFont38 = new EastAsianFont {Typeface = "+mj-ea"};
            var complexScriptFont38 = new ComplexScriptFont {Typeface = "+mj-cs"};

            defaultRunProperties182.Append(solidFill101);
            defaultRunProperties182.Append(latinFont38);
            defaultRunProperties182.Append(eastAsianFont38);
            defaultRunProperties182.Append(complexScriptFont38);

            level1ParagraphProperties32.Append(spaceBefore29);
            level1ParagraphProperties32.Append(noBullet98);
            level1ParagraphProperties32.Append(defaultRunProperties182);

            listStyle103.Append(level1ParagraphProperties32);

            var paragraph137 = new Paragraph();

            var run92 = new Run();

            var runProperties120 = new RunProperties {Language = "en-US", FontSize = 2200, Dirty = false};
            runProperties120.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            var text120 = new Text();
            text120.Text = "{name}";

            run92.Append(runProperties120);
            run92.Append(text120);
            var endParagraphRunProperties96 = new EndParagraphRunProperties
                {
                    Language = "en-US",
                    FontSize = 2200,
                    Dirty = false
                };

            paragraph137.Append(run92);
            paragraph137.Append(endParagraphRunProperties96);

            textBody101.Append(bodyProperties103);
            textBody101.Append(listStyle103);
            textBody101.Append(paragraph137);

            shape81.Append(nonVisualShapeProperties81);
            shape81.Append(shapeProperties84);
            shape81.Append(textBody101);

            shapeTree18.Append(nonVisualGroupShapeProperties18);
            shapeTree18.Append(groupShapeProperties18);
            shapeTree18.Append(graphicFrame2);
            shapeTree18.Append(shape81);

            var commonSlideDataExtensionList5 = new CommonSlideDataExtensionList();

            var commonSlideDataExtension5 = new CommonSlideDataExtension
                {
                    Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}"
                };

            var creationId5 = new CreationId {Val = 331602207U};
            creationId5.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension5.Append(creationId5);

            commonSlideDataExtensionList5.Append(commonSlideDataExtension5);

            commonSlideData18.Append(shapeTree18);
            commonSlideData18.Append(commonSlideDataExtensionList5);

            var colorMapOverride17 = new ColorMapOverride();
            var masterColorMapping17 = new MasterColorMapping();

            colorMapOverride17.Append(masterColorMapping17);

            slide4.Append(commonSlideData18);
            slide4.Append(colorMapOverride17);

            slidePart4.Slide = slide4;
        }

        // Generates content of thumbnailPart1.
        private void GenerateThumbnailPart1Content(ThumbnailPart thumbnailPart1)
        {
            Stream data = GetBinaryDataStream(thumbnailPart1Data);
            thumbnailPart1.FeedData(data);
            data.Close();
        }

        private void SetPackageProperties(OpenXmlPackage document)
        {
            document.PackageProperties.Creator = "Spyros";
            document.PackageProperties.Title = "PowerPoint Presentation";
            document.PackageProperties.Revision = "46";
            document.PackageProperties.Created = XmlConvert.ToDateTime("2013-07-27T17:27:29Z",
                                                                       XmlDateTimeSerializationMode.RoundtripKind);
            document.PackageProperties.Modified = XmlConvert.ToDateTime("2013-11-29T17:01:33Z",
                                                                        XmlDateTimeSerializationMode.RoundtripKind);
            document.PackageProperties.LastModifiedBy = "Christian Manteuffel";
        }

        #region Binary Data

        private string extendedPart1Data =
            "AgAAAAEAAACVGQAAPD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz4KPCFET0NUWVBFIHBsaXN0IFBVQkxJQyAiLS8vQXBwbGUvL0RURCBQTElTVCAxLjAvL0VOIiAiaHR0cDovL3d3dy5hcHBsZS5jb20vRFREcy9Qcm9wZXJ0eUxpc3QtMS4wLmR0ZCI+CjxwbGlzdCB2ZXJzaW9uPSIxLjAiPgo8ZGljdD4KCTxrZXk+Y29tLmFwcGxlLnByaW50LlBhZ2VGb3JtYXQuUE1Ib3Jpem9udGFsUmVzPC9rZXk+Cgk8ZGljdD4KCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuY3JlYXRvcjwva2V5PgoJCTxzdHJpbmc+Y29tLmFwcGxlLmpvYnRpY2tldDwvc3RyaW5nPgoJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5pdGVtQXJyYXk8L2tleT4KCQk8YXJyYXk+CgkJCTxkaWN0PgoJCQkJPGtleT5jb20uYXBwbGUucHJpbnQuUGFnZUZvcm1hdC5QTUhvcml6b250YWxSZXM8L2tleT4KCQkJCTxyZWFsPjcyPC9yZWFsPgoJCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LnN0YXRlRmxhZzwva2V5PgoJCQkJPGludGVnZXI+MDwvaW50ZWdlcj4KCQkJPC9kaWN0PgoJCTwvYXJyYXk+Cgk8L2RpY3Q+Cgk8a2V5PmNvbS5hcHBsZS5wcmludC5QYWdlRm9ybWF0LlBNT3JpZW50YXRpb248L2tleT4KCTxkaWN0PgoJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5jcmVhdG9yPC9rZXk+CgkJPHN0cmluZz5jb20uYXBwbGUuam9idGlja2V0PC9zdHJpbmc+CgkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0Lml0ZW1BcnJheTwva2V5PgoJCTxhcnJheT4KCQkJPGRpY3Q+CgkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC5QYWdlRm9ybWF0LlBNT3JpZW50YXRpb248L2tleT4KCQkJCTxpbnRlZ2VyPjE8L2ludGVnZXI+CgkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuc3RhdGVGbGFnPC9rZXk+CgkJCQk8aW50ZWdlcj4wPC9pbnRlZ2VyPgoJCQk8L2RpY3Q+CgkJPC9hcnJheT4KCTwvZGljdD4KCTxrZXk+Y29tLmFwcGxlLnByaW50LlBhZ2VGb3JtYXQuUE1TY2FsaW5nPC9rZXk+Cgk8ZGljdD4KCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuY3JlYXRvcjwva2V5PgoJCTxzdHJpbmc+Y29tLmFwcGxlLmpvYnRpY2tldDwvc3RyaW5nPgoJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5pdGVtQXJyYXk8L2tleT4KCQk8YXJyYXk+CgkJCTxkaWN0PgoJCQkJPGtleT5jb20uYXBwbGUucHJpbnQuUGFnZUZvcm1hdC5QTVNjYWxpbmc8L2tleT4KCQkJCTxyZWFsPjE8L3JlYWw+CgkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuc3RhdGVGbGFnPC9rZXk+CgkJCQk8aW50ZWdlcj4wPC9pbnRlZ2VyPgoJCQk8L2RpY3Q+CgkJPC9hcnJheT4KCTwvZGljdD4KCTxrZXk+Y29tLmFwcGxlLnByaW50LlBhZ2VGb3JtYXQuUE1WZXJ0aWNhbFJlczwva2V5PgoJPGRpY3Q+CgkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LmNyZWF0b3I8L2tleT4KCQk8c3RyaW5nPmNvbS5hcHBsZS5qb2J0aWNrZXQ8L3N0cmluZz4KCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuaXRlbUFycmF5PC9rZXk+CgkJPGFycmF5PgoJCQk8ZGljdD4KCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LlBhZ2VGb3JtYXQuUE1WZXJ0aWNhbFJlczwva2V5PgoJCQkJPHJlYWw+NzI8L3JlYWw+CgkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuc3RhdGVGbGFnPC9rZXk+CgkJCQk8aW50ZWdlcj4wPC9pbnRlZ2VyPgoJCQk8L2RpY3Q+CgkJPC9hcnJheT4KCTwvZGljdD4KCTxrZXk+Y29tLmFwcGxlLnByaW50LlBhZ2VGb3JtYXQuUE1WZXJ0aWNhbFNjYWxpbmc8L2tleT4KCTxkaWN0PgoJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5jcmVhdG9yPC9rZXk+CgkJPHN0cmluZz5jb20uYXBwbGUuam9idGlja2V0PC9zdHJpbmc+CgkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0Lml0ZW1BcnJheTwva2V5PgoJCTxhcnJheT4KCQkJPGRpY3Q+CgkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC5QYWdlRm9ybWF0LlBNVmVydGljYWxTY2FsaW5nPC9rZXk+CgkJCQk8cmVhbD4xPC9yZWFsPgoJCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LnN0YXRlRmxhZzwva2V5PgoJCQkJPGludGVnZXI+MDwvaW50ZWdlcj4KCQkJPC9kaWN0PgoJCTwvYXJyYXk+Cgk8L2RpY3Q+Cgk8a2V5PmNvbS5hcHBsZS5wcmludC5zdWJUaWNrZXQucGFwZXJfaW5mb190aWNrZXQ8L2tleT4KCTxkaWN0PgoJCTxrZXk+UE1QUERQYXBlckNvZGVOYW1lPC9rZXk+CgkJPGRpY3Q+CgkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5jcmVhdG9yPC9rZXk+CgkJCTxzdHJpbmc+Y29tLmFwcGxlLmpvYnRpY2tldDwvc3RyaW5nPgoJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuaXRlbUFycmF5PC9rZXk+CgkJCTxhcnJheT4KCQkJCTxkaWN0PgoJCQkJCTxrZXk+UE1QUERQYXBlckNvZGVOYW1lPC9rZXk+CgkJCQkJPHN0cmluZz5BNDwvc3RyaW5nPgoJCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5zdGF0ZUZsYWc8L2tleT4KCQkJCQk8aW50ZWdlcj4wPC9pbnRlZ2VyPgoJCQkJPC9kaWN0PgoJCQk8L2FycmF5PgoJCTwvZGljdD4KCQk8a2V5PlBNUFBEVHJhbnNsYXRpb25TdHJpbmdQYXBlck5hbWU8L2tleT4KCQk8ZGljdD4KCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LmNyZWF0b3I8L2tleT4KCQkJPHN0cmluZz5jb20uYXBwbGUuam9idGlja2V0PC9zdHJpbmc+CgkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5pdGVtQXJyYXk8L2tleT4KCQkJPGFycmF5PgoJCQkJPGRpY3Q+CgkJCQkJPGtleT5QTVBQRFRyYW5zbGF0aW9uU3RyaW5nUGFwZXJOYW1lPC9rZXk+CgkJCQkJPHN0cmluZz5BNDwvc3RyaW5nPgoJCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5zdGF0ZUZsYWc8L2tleT4KCQkJCQk8aW50ZWdlcj4wPC9pbnRlZ2VyPgoJCQkJPC9kaWN0PgoJCQk8L2FycmF5PgoJCTwvZGljdD4KCQk8a2V5PlBNVGlvZ2FQYXBlck5hbWU8L2tleT4KCQk8ZGljdD4KCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LmNyZWF0b3I8L2tleT4KCQkJPHN0cmluZz5jb20uYXBwbGUuam9idGlja2V0PC9zdHJpbmc+CgkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5pdGVtQXJyYXk8L2tleT4KCQkJPGFycmF5PgoJCQkJPGRpY3Q+CgkJCQkJPGtleT5QTVRpb2dhUGFwZXJOYW1lPC9rZXk+CgkJCQkJPHN0cmluZz5pc28tYTQ8L3N0cmluZz4KCQkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuc3RhdGVGbGFnPC9rZXk+CgkJCQkJPGludGVnZXI+MDwvaW50ZWdlcj4KCQkJCTwvZGljdD4KCQkJPC9hcnJheT4KCQk8L2RpY3Q+CgkJPGtleT5jb20uYXBwbGUucHJpbnQuUGFnZUZvcm1hdC5QTUFkanVzdGVkUGFnZVJlY3Q8L2tleT4KCQk8ZGljdD4KCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LmNyZWF0b3I8L2tleT4KCQkJPHN0cmluZz5jb20uYXBwbGUuam9idGlja2V0PC9zdHJpbmc+CgkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5pdGVtQXJyYXk8L2tleT4KCQkJPGFycmF5PgoJCQkJPGRpY3Q+CgkJCQkJPGtleT5jb20uYXBwbGUucHJpbnQuUGFnZUZvcm1hdC5QTUFkanVzdGVkUGFnZVJlY3Q8L2tleT4KCQkJCQk8YXJyYXk+CgkJCQkJCTxpbnRlZ2VyPjA8L2ludGVnZXI+CgkJCQkJCTxpbnRlZ2VyPjA8L2ludGVnZXI+CgkJCQkJCTxyZWFsPjc4MzwvcmVhbD4KCQkJCQkJPHJlYWw+NTU5PC9yZWFsPgoJCQkJCTwvYXJyYXk+CgkJCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LnN0YXRlRmxhZzwva2V5PgoJCQkJCTxpbnRlZ2VyPjA8L2ludGVnZXI+CgkJCQk8L2RpY3Q+CgkJCTwvYXJyYXk+CgkJPC9kaWN0PgoJCTxrZXk+Y29tLmFwcGxlLnByaW50LlBhZ2VGb3JtYXQuUE1BZGp1c3RlZFBhcGVyUmVjdDwva2V5PgoJCTxkaWN0PgoJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuY3JlYXRvcjwva2V5PgoJCQk8c3RyaW5nPmNvbS5hcHBsZS5qb2J0aWNrZXQ8L3N0cmluZz4KCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0Lml0ZW1BcnJheTwva2V5PgoJCQk8YXJyYXk+CgkJCQk8ZGljdD4KCQkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC5QYWdlRm9ybWF0LlBNQWRqdXN0ZWRQYXBlclJlY3Q8L2tleT4KCQkJCQk8YXJyYXk+CgkJCQkJCTxyZWFsPi0xODwvcmVhbD4KCQkJCQkJPHJlYWw+LTE4PC9yZWFsPgoJCQkJCQk8cmVhbD44MjQ8L3JlYWw+CgkJCQkJCTxyZWFsPjU3NzwvcmVhbD4KCQkJCQk8L2FycmF5PgoJCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5zdGF0ZUZsYWc8L2tleT4KCQkJCQk8aW50ZWdlcj4wPC9pbnRlZ2VyPgoJCQkJPC9kaWN0PgoJCQk8L2FycmF5PgoJCTwvZGljdD4KCQk8a2V5PmNvbS5hcHBsZS5wcmludC5QYXBlckluZm8uUE1QYXBlck5hbWU8L2tleT4KCQk8ZGljdD4KCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LmNyZWF0b3I8L2tleT4KCQkJPHN0cmluZz5jb20uYXBwbGUuam9idGlja2V0PC9zdHJpbmc+CgkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5pdGVtQXJyYXk8L2tleT4KCQkJPGFycmF5PgoJCQkJPGRpY3Q+CgkJCQkJPGtleT5jb20uYXBwbGUucHJpbnQuUGFwZXJJbmZvLlBNUGFwZXJOYW1lPC9rZXk+CgkJCQkJPHN0cmluZz5pc28tYTQ8L3N0cmluZz4KCQkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuc3RhdGVGbGFnPC9rZXk+CgkJCQkJPGludGVnZXI+MDwvaW50ZWdlcj4KCQkJCTwvZGljdD4KCQkJPC9hcnJheT4KCQk8L2RpY3Q+CgkJPGtleT5jb20uYXBwbGUucHJpbnQuUGFwZXJJbmZvLlBNVW5hZGp1c3RlZFBhZ2VSZWN0PC9rZXk+CgkJPGRpY3Q+CgkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5jcmVhdG9yPC9rZXk+CgkJCTxzdHJpbmc+Y29tLmFwcGxlLmpvYnRpY2tldDwvc3RyaW5nPgoJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuaXRlbUFycmF5PC9rZXk+CgkJCTxhcnJheT4KCQkJCTxkaWN0PgoJCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LlBhcGVySW5mby5QTVVuYWRqdXN0ZWRQYWdlUmVjdDwva2V5PgoJCQkJCTxhcnJheT4KCQkJCQkJPGludGVnZXI+MDwvaW50ZWdlcj4KCQkJCQkJPGludGVnZXI+MDwvaW50ZWdlcj4KCQkJCQkJPHJlYWw+NzgzPC9yZWFsPgoJCQkJCQk8cmVhbD41NTk8L3JlYWw+CgkJCQkJPC9hcnJheT4KCQkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuc3RhdGVGbGFnPC9rZXk+CgkJCQkJPGludGVnZXI+MDwvaW50ZWdlcj4KCQkJCTwvZGljdD4KCQkJPC9hcnJheT4KCQk8L2RpY3Q+CgkJPGtleT5jb20uYXBwbGUucHJpbnQuUGFwZXJJbmZvLlBNVW5hZGp1c3RlZFBhcGVyUmVjdDwva2V5PgoJCTxkaWN0PgoJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuY3JlYXRvcjwva2V5PgoJCQk8c3RyaW5nPmNvbS5hcHBsZS5qb2J0aWNrZXQ8L3N0cmluZz4KCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0Lml0ZW1BcnJheTwva2V5PgoJCQk8YXJyYXk+CgkJCQk8ZGljdD4KCQkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC5QYXBlckluZm8uUE1VbmFkanVzdGVkUGFwZXJSZWN0PC9rZXk+CgkJCQkJPGFycmF5PgoJCQkJCQk8cmVhbD4tMTg8L3JlYWw+CgkJCQkJCTxyZWFsPi0xODwvcmVhbD4KCQkJCQkJPHJlYWw+ODI0PC9yZWFsPgoJCQkJCQk8cmVhbD41Nzc8L3JlYWw+CgkJCQkJPC9hcnJheT4KCQkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuc3RhdGVGbGFnPC9rZXk+CgkJCQkJPGludGVnZXI+MDwvaW50ZWdlcj4KCQkJCTwvZGljdD4KCQkJPC9hcnJheT4KCQk8L2RpY3Q+CgkJPGtleT5jb20uYXBwbGUucHJpbnQuUGFwZXJJbmZvLnBwZC5QTVBhcGVyTmFtZTwva2V5PgoJCTxkaWN0PgoJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuY3JlYXRvcjwva2V5PgoJCQk8c3RyaW5nPmNvbS5hcHBsZS5qb2J0aWNrZXQ8L3N0cmluZz4KCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0Lml0ZW1BcnJheTwva2V5PgoJCQk8YXJyYXk+CgkJCQk8ZGljdD4KCQkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC5QYXBlckluZm8ucHBkLlBNUGFwZXJOYW1lPC9rZXk+CgkJCQkJPHN0cmluZz5BNDwvc3RyaW5nPgoJCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5zdGF0ZUZsYWc8L2tleT4KCQkJCQk8aW50ZWdlcj4wPC9pbnRlZ2VyPgoJCQkJPC9kaWN0PgoJCQk8L2FycmF5PgoJCTwvZGljdD4KCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuQVBJVmVyc2lvbjwva2V5PgoJCTxzdHJpbmc+MDAuMjA8L3N0cmluZz4KCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQudHlwZTwva2V5PgoJCTxzdHJpbmc+Y29tLmFwcGxlLnByaW50LlBhcGVySW5mb1RpY2tldDwvc3RyaW5nPgoJPC9kaWN0PgoJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LkFQSVZlcnNpb248L2tleT4KCTxzdHJpbmc+MDAuMjA8L3N0cmluZz4KCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC50eXBlPC9rZXk+Cgk8c3RyaW5nPmNvbS5hcHBsZS5wcmludC5QYWdlRm9ybWF0VGlja2V0PC9zdHJpbmc+CjwvZGljdD4KPC9wbGlzdD4KAgAAAPUKAAA8P3htbCB2ZXJzaW9uPSIxLjAiIGVuY29kaW5nPSJVVEYtOCI/Pgo8IURPQ1RZUEUgcGxpc3QgUFVCTElDICItLy9BcHBsZS8vRFREIFBMSVNUIDEuMC8vRU4iICJodHRwOi8vd3d3LmFwcGxlLmNvbS9EVERzL1Byb3BlcnR5TGlzdC0xLjAuZHRkIj4KPHBsaXN0IHZlcnNpb249IjEuMCI+CjxkaWN0PgoJPGtleT5jb20uYXBwbGUucHJpbnQuRG9jdW1lbnRUaWNrZXQuUE1TcG9vbEZvcm1hdDwva2V5PgoJPGRpY3Q+CgkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LmNyZWF0b3I8L2tleT4KCQk8c3RyaW5nPmNvbS5hcHBsZS5qb2J0aWNrZXQ8L3N0cmluZz4KCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuaXRlbUFycmF5PC9rZXk+CgkJPGFycmF5PgoJCQk8ZGljdD4KCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LkRvY3VtZW50VGlja2V0LlBNU3Bvb2xGb3JtYXQ8L2tleT4KCQkJCTxzdHJpbmc+YXBwbGljYXRpb24vcGRmPC9zdHJpbmc+CgkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuc3RhdGVGbGFnPC9rZXk+CgkJCQk8aW50ZWdlcj4wPC9pbnRlZ2VyPgoJCQk8L2RpY3Q+CgkJPC9hcnJheT4KCTwvZGljdD4KCTxrZXk+Y29tLmFwcGxlLnByaW50LlByaW50U2V0dGluZ3MuUE1Db3BpZXM8L2tleT4KCTxkaWN0PgoJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5jcmVhdG9yPC9rZXk+CgkJPHN0cmluZz5jb20uYXBwbGUuam9idGlja2V0PC9zdHJpbmc+CgkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0Lml0ZW1BcnJheTwva2V5PgoJCTxhcnJheT4KCQkJPGRpY3Q+CgkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC5QcmludFNldHRpbmdzLlBNQ29waWVzPC9rZXk+CgkJCQk8aW50ZWdlcj4xPC9pbnRlZ2VyPgoJCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LnN0YXRlRmxhZzwva2V5PgoJCQkJPGludGVnZXI+MDwvaW50ZWdlcj4KCQkJPC9kaWN0PgoJCTwvYXJyYXk+Cgk8L2RpY3Q+Cgk8a2V5PmNvbS5hcHBsZS5wcmludC5QcmludFNldHRpbmdzLlBNQ29weUNvbGxhdGU8L2tleT4KCTxkaWN0PgoJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5jcmVhdG9yPC9rZXk+CgkJPHN0cmluZz5jb20uYXBwbGUuam9idGlja2V0PC9zdHJpbmc+CgkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0Lml0ZW1BcnJheTwva2V5PgoJCTxhcnJheT4KCQkJPGRpY3Q+CgkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC5QcmludFNldHRpbmdzLlBNQ29weUNvbGxhdGU8L2tleT4KCQkJCTx0cnVlLz4KCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5zdGF0ZUZsYWc8L2tleT4KCQkJCTxpbnRlZ2VyPjA8L2ludGVnZXI+CgkJCTwvZGljdD4KCQk8L2FycmF5PgoJPC9kaWN0PgoJPGtleT5jb20uYXBwbGUucHJpbnQuUHJpbnRTZXR0aW5ncy5QTUZpcnN0UGFnZTwva2V5PgoJPGRpY3Q+CgkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LmNyZWF0b3I8L2tleT4KCQk8c3RyaW5nPmNvbS5hcHBsZS5qb2J0aWNrZXQ8L3N0cmluZz4KCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuaXRlbUFycmF5PC9rZXk+CgkJPGFycmF5PgoJCQk8ZGljdD4KCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LlByaW50U2V0dGluZ3MuUE1GaXJzdFBhZ2U8L2tleT4KCQkJCTxpbnRlZ2VyPjE8L2ludGVnZXI+CgkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuc3RhdGVGbGFnPC9rZXk+CgkJCQk8aW50ZWdlcj4wPC9pbnRlZ2VyPgoJCQk8L2RpY3Q+CgkJPC9hcnJheT4KCTwvZGljdD4KCTxrZXk+Y29tLmFwcGxlLnByaW50LlByaW50U2V0dGluZ3MuUE1MYXN0UGFnZTwva2V5PgoJPGRpY3Q+CgkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LmNyZWF0b3I8L2tleT4KCQk8c3RyaW5nPmNvbS5hcHBsZS5qb2J0aWNrZXQ8L3N0cmluZz4KCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuaXRlbUFycmF5PC9rZXk+CgkJPGFycmF5PgoJCQk8ZGljdD4KCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LlByaW50U2V0dGluZ3MuUE1MYXN0UGFnZTwva2V5PgoJCQkJPGludGVnZXI+MjE0NzQ4MzY0NzwvaW50ZWdlcj4KCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5zdGF0ZUZsYWc8L2tleT4KCQkJCTxpbnRlZ2VyPjA8L2ludGVnZXI+CgkJCTwvZGljdD4KCQk8L2FycmF5PgoJPC9kaWN0PgoJPGtleT5jb20uYXBwbGUucHJpbnQuUHJpbnRTZXR0aW5ncy5QTVBhZ2VSYW5nZTwva2V5PgoJPGRpY3Q+CgkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LmNyZWF0b3I8L2tleT4KCQk8c3RyaW5nPmNvbS5hcHBsZS5qb2J0aWNrZXQ8L3N0cmluZz4KCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuaXRlbUFycmF5PC9rZXk+CgkJPGFycmF5PgoJCQk8ZGljdD4KCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LlByaW50U2V0dGluZ3MuUE1QYWdlUmFuZ2U8L2tleT4KCQkJCTxhcnJheT4KCQkJCQk8aW50ZWdlcj4xPC9pbnRlZ2VyPgoJCQkJCTxpbnRlZ2VyPjIxNDc0ODM2NDc8L2ludGVnZXI+CgkJCQk8L2FycmF5PgoJCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LnN0YXRlRmxhZzwva2V5PgoJCQkJPGludGVnZXI+MDwvaW50ZWdlcj4KCQkJPC9kaWN0PgoJCTwvYXJyYXk+Cgk8L2RpY3Q+Cgk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuQVBJVmVyc2lvbjwva2V5PgoJPHN0cmluZz4wMC4yMDwvc3RyaW5nPgoJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LnR5cGU8L2tleT4KCTxzdHJpbmc+Y29tLmFwcGxlLnByaW50LlByaW50U2V0dGluZ3NUaWNrZXQ8L3N0cmluZz4KPC9kaWN0Pgo8L3BsaXN0Pgo=";

        private string imagePart1Data =
            "/9j/4AAQSkZJRgABAgAAZABkAAD/7AARRHVja3kAAQAEAAAAPAAA/+4ADkFkb2JlAGTAAAAAAf/bAEMABgQEBAUEBgUFBgkGBQYJCwgGBggLDAoKCwoKDBAMDAwMDAwQDA4PEA8ODBMTFBQTExwbGxscHx8fHx8fHx8fH//bAEMBBwcHDQwNGBAQGBoVERUaHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fH//AABEIAwAEAAMBEQACEQEDEQH/xAAfAAABBQEBAQEBAQAAAAAAAAAAAQIDBAUGBwgJCgv/xAC1EAACAQMDAgQDBQUEBAAAAX0BAgMABBEFEiExQQYTUWEHInEUMoGRoQgjQrHBFVLR8CQzYnKCCQoWFxgZGiUmJygpKjQ1Njc4OTpDREVGR0hJSlNUVVZXWFlaY2RlZmdoaWpzdHV2d3h5eoOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4eLj5OXm5+jp6vHy8/T19vf4+fr/xAAfAQADAQEBAQEBAQEBAAAAAAAAAQIDBAUGBwgJCgv/xAC1EQACAQIEBAMEBwUEBAABAncAAQIDEQQFITEGEkFRB2FxEyIygQgUQpGhscEJIzNS8BVictEKFiQ04SXxFxgZGiYnKCkqNTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqCg4SFhoeIiYqSk5SVlpeYmZqio6Slpqeoqaqys7S1tre4ubrCw8TFxsfIycrS09TV1tfY2dri4+Tl5ufo6ery8/T19vf4+fr/2gAMAwEAAhEDEQA/APqGgAoAWgAoAWgAoAWgAoAKACgAoAKAFFABQAUAFABQAuKADFABigBaACgAoAKACgAoAKACgAoAKACgAoAKACgAFAC0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABigBMUAGKADFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUAFACUAFABQAUAFACUAFABQAUAFABQAlABQAUAJQAUAJQAUAJQAtAC0AFAC0AFABQAtABQAUAFABQAuKAFoAMUAGKACgBaACgAoAKACgAoAKACgAoAKACgAoAKAFxQAUAGKADFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAYoATFABigAxQAYoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKADFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAJQAUAJQAUAFABigBKACgAoAKACgBKACgAoAKAENACUAFACUALQAooAKAFoAKAFoAKACgAxQAuKAFoAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAMUAGKAExQAYoAMUAFABQAUAFABQAYoAXFABQAUAFACUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUAFABQAlABQAUAJQAUAFABQAUAJQAUAFACUABoASgAoAKAFoAWgAoAKAFxQAuKACgAoAWgAoAWgAoAKACgAoAKACgAoAKACgAoAKACgBcUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAlABQAUAFABQAUAFABQAUAFABQAUAFABQAUAJQAUAFACUAFABQAlABQAUAFABQAlABQAlABQAlABQAtAC0AGKAFoAWgAoAKACgAoAWgAoAWgAoAKACgAoAKACgAoAKACgAoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBDQAUAFABQAUAFABQAUAFABQAUAFABQAhoAKACgBKACgAoAKAEoAKACgAoASgAoAKAEoAKAEoAdigBaACgAoAWgAoAKACgBaACgBaACgAoAKACgAoAKACgAoAKACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAEoAKACgAoAKACgAoAKACgAoAKACgBKACgBKACgAoADQAlABQAUAFABQAlABQAUAJQAlAD6ACgAoAWgAoAKACgBaACgAoAWgAoAKACgAoAKACgAoAKACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAMUAJQAUAFABQAUAFABQAUAFABQAUAJQAUAJQAUAFABQAlABQAUAFACUAFABQAUAIaAHUAFABQAtABQAUAFACigBaACgAoAKACgAoAKACgAoAMUALigAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgAoAKACgAoAKACgAoAKAEoAKACgBKACgAoASgAoAKACgAoASgAoAKAEoAdQAUALQAUAFABQAtABQAtABQAUAFABQAYoAXFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAGKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAExQAUAFABQAUAFABQAUAFACUAFABQAlABQAUAJQAUAFABQAlABQAlABQA6gAoAWgAoAKAFoABQAtABQAUAFABQAtABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFAC0AFACUALQAlABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAJigAoAKACgAoAKACgAoAQ0AJQAUAFABQAlABQAUAFACGgAoAKAEoAdQAUALQAUALigAoAWgAoAKACgAoAAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAWgBKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAFoAMUAFABQAUAFABQAUAFABQAlAC0AJQAtACUAFABQAtABQAlABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAJigAoAKACgAoAKACgBDQAlABQAUAFACUAFABQAlABQAUAJQA/FABQAtABQAtABQAUAFABQAUAGKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBaAEoAWgAoASgAoAWgAoAKACgAoAKACgBKAFoAKACgBKAFoAKAEoAWgAoAKACgAoAKACgAoAKACgAoAMUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUALQAUAJQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACYoAKACgAoAKAEoAKAEoAKACgBKACgAoAKAEoAKAEoAfQAUALQAUALQAUAFABQAUAFAC0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUALQAlABQAtABQAlAC0AFACUALQAUAFABQAUAFABQAUAFABigAoAKACgAoASgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoASgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoASgAoAKACgBKACgBKACgAoASgAoAKACgBKACgAoAdQAUALQAtABQAUAFABQAUAFAC0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFAC0AFABQAlAC0AFABQAUAFABQAUAJQAtABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAlABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAYoATFABQAUAJQAlABQAUAFACGgAoAKACgBKACgAoAdQAUALQAtABQAUAFABQAUAAoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAWgAoASgBaACgAoASgBaAEoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoATFABigBKACgBKACgBKACgAoAKAEoAKAEoAfQAtABQAtABQAUAFABQAUALQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAtABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAlAC0AJQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUAFABQAmKAEoAKAEoAKACgBKACgBKAH0ALQAUAFAC0AFABQAUAKKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAEoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgAoAKACgBMUAJigBKAA0AJQAUAJQBJQAUAFAC0AFABQAUAFAC0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUALQAYoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAxQAUAFABQAUAJQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAJQAUAFABQAUAFACUAJQAlABigBKAEoAkoAKACgBaACgAoAKACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgAoAKACgAoASgAoASgBKACgBOKAH0AFABQAtABQAUAFABQAtABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFAC0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAGKADFABQAUAJQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUAFABQAUAFABQAUAJQAlABQAlACGgB9ABQACgBaACgAoAKACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgAoAKACgAoAKAEoASgAoAKAEIoAWgBaACgBaACgAoAKAAUALQAUAFABQAUAFABQAUAFABQAUAFABQAUALQAlAC0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAJQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAlABQAUAFABQAUAIaAEoAKACgAoASgB1ABQAUALQAUAFABQACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgAoAKACgAoASgBKACgAoAKAEoAWgBaACgBaACgAoAKADNAC0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAtABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAlABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACGgAoAKACgAoAKAEoASgAoAKAEoAKAFoAWgAoAWgAoAKACgAoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKAFoAKACgBKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBDQAUAFABQAUAFACUAJQAUABoASgAoAWgBaACgBaACgAoAKACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoADQAUAFABQAUAFABQAUAJQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAIaACgAoAKACgAoASgBKACgBKACgAoAWgBaAAUALQAUAFABQAUALQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACigAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKAFoASgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAENABQAUAFABQAUAJQAlABQAlABQAUALQAtAAKAFoAKACgAoABQAtABQAUAFABQAUAFABQAUAFABQAUAFABQAUALQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUAFAC0AJQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUABoASgAoAKACgAoASgAoASgAoASgAoAKAFoAKAFoAKAFoAKACgAoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoASgAoAKAFoASgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAEoAKACgAoAKACgBKAEoAKAA0AJQAUAFAC0AFAC0ALQAUAFABQAUAAoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAXNABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUALQAUAFABQAlABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAlABQAUAFABQAUAJQAlABQAGgBKACgAoAWgAoAWgAzQAtABQAUAFABQAooAKACgAoAKACgAoAKACgAoAKACgAoAKACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAEoAWgBKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAQ0AFABQAUAFABQAlABQAlABQAUAJQAUAJQA6gAoAKAFoAWgAoAKACgAoABQAtABQAUAFABQAUAFABQAUAFABQAUAFAC0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAZoAKACgAoAKACgAoASgBaACgBKAFoAKAEoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgAoAKACgAoAQ0AJQAUAFACUAFABQAlADqACgAoAWgBaACgAoAKACgAoAWgAoAKACgAoAKACgAoAKACgAoAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKADNACUALQAUAJQAUAFAC0AFACUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAlABQAUAFABQAlACUAFABQAUAJQAUAIaACgBaAFoAKACgBaAFoAKACgAoAKACgBaACgAoAKACgAoAKACgAoAKACgAoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgBaAEoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAEoAKACgAoAKAEoAKAEoAKACgBKACgANACUAFAC0AFAC0AFAC0ALQAUAFABQAUAFAC0AFABQAUAFABQAUAFABQAUAFABQAUAFAC5oAKACgAoAKADNABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABmgAoAKACgAoAKACgAoAKACgAoASgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgAoAKACgAoAQ0AJQAUAFAAaAEoAKACgBKAEoAdQAUALQAUAFAC0ALQAUAFABQAUAFAAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBaACgBKACgBaAEoAWgAzQAUAFABQAUAFABQAUAJQAUALQAlABQAUAFABQAUAFABQAUAFABQAUALQAlABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUAFABQAUAFABQAUAJQAlABQAUAJQAUAFACUAFACUAOoAKACgBaACgBaACgBaACgAoAKACgAoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoASgAoAKACgAoAKAEoAKAEoAKAA0AJQAUAFACUAFACUALQACgBaAFoAKACgBaAFoAKACgAoAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBM0AFABQAUAFABQAlACUAFAAaAEoAKACgBKACgBDQAlADqACgBaACgAoAWgAoAUUALQAUAFABQAtABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUAFABQAUAFABQAUAJQAlABQAUABoASgAoAKAEoASgAoASgB1ABQAtABQAUAKKACgBQKAFoAKACgAoAKACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAEoAKACgAoAKACgAoASgAoASgAoAKACgBKACgANACUAIaAEoAKAHUAFABQAtABQAtAC0AFAC0AFABQAUAFABQAUALQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAlABQAUAFABQAUAFACUAFABQAlABQAUAFACUAFABQAlABQAlACUAFAC5oAKAFoAUCgBaACgAoAWgAFAC0AFABQAUAFABQAUALQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUAFABQAUAFABQAUAJQAlABQAUAFAAaAEoAKACgBKACgBKAEoADQAlAC0AOAoAXigAoAWgAoAKACgBaACgBaACgAoAKACgAoAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAzQAmaACgAoAKACgAoAKAENACUAFABQAUAFABQAlABQAGgBKACgBDQAlACUAFAD6ACgAoAWgAoAWgAoAKACgBaAFoAKACgAoAKACgAoAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoATNABQAUAFABQAUAFABQAUAFABQAUAIaAEoAKACgAoAKAEoAKACgBDQAUAFACGgBDQAlABQA6gAoAWgAoAWgAoAWgAoAKAFoAKAFoAKACgAoAKACgAoAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAEoAKACgAoAKACgAoAKACgAoAKACgAoAKAEoAM0AFACUAFABQAUAFACUAFABQAlABQAlACUAJQAUAJQA6gBaAFoAKAFoAKACgAoAWgAoAWgAoAWgAoAKACgAoAKACgAoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAM0AGaADNABmgAzQAlABQAuaAEzQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAIaAEoAKACgAoADQAUAJQAUAFACUAFACUAJQAGgBKAEJoAKAHUAFAC0ALQAUALQAUAFAC0AFABQAtABmgAoAWgAoAKACgAoAKACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAzQAmaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAEoAKAEoAKACgAoAKAEoAKACgBDQAUAJQAUAJQAGgBDQAlACZoAfQAUALQAUALQAtABQAUAFAC0AFABQAUAFAC0AAoAWgAoAKACgAoAKACgBaADNABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAZoAM0AGaAEzQAZoAM0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUAFABQAlAAaAEoAKACgAoAKAA0AJQAUAIaAEoADQAlACUAIaAEoAfQAtABQAUALQAtAC0AFABQAUALQAUAFABQAUALQAZoAWgAoAKACgAoAKACgAoAKAFzQAUAFABQAUAFABQAUAFABQAUAFABQAZoAKACgAoAM0AFABQAUAGaADNABmgAzQAZoAM0AGaADNABmgBM0AGaADNABmgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoASgAoAKACgBKACgANACUAFABQAUAFACGgAoAKAENACUAJQAUAJQAlACUAPoAKAFoAKAFoAWgAoAWgAoAKACgBc0AFABQAUAFABQAooAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgBKACgAoAKAEoAKACgAoAKACgBKACgBM0AJQAUAJQAlACUAFACUAOoAWgAoAWgAoAUGgBaACgAzQAtABQAUAKKACgAoAKACgAoAWgAoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoATNABQAUAJQAUAFABQAUAFACUAFABQAUAFACUAFACGgBKACgANADc0AFACUAJmgBM0AOoAWgBaACgBc0AFACigBaACgBRQAUAFABQAZoAXNABQAUAFABQAooAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBDQAUAJQAUAFABQAUAFABQAlABQAUAFABQAlABQAUAIaAEoADQAhoASgBDQAlACGgAoAdQACgBaAFoAKAFzQAtAC0AFAAKAFzQAUAFABQAUALQAUAFABQAUAFABQAtABmgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAQ0AJQAtACUAFABQAUAHNACUAFABQAUAFACUAFABQAhNACUAFACUAJQAUAJQAhoASgAoAXNABQAtAC0AGaAFoAUUALQAUALQAUAGaAFoAKACgAoAKAFFABQAUAFABQAUALQAUAFAC0AFABQAlAC0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUAFABQAUAFAC0AFABQAUAFACUAFAC0AFABQAUAJQAtACUALQAlAC0AJmgAoAWgAoAKACgAoAKACgAoAKACgAoASgBaACgAoAKACgAoAKACgBKACgAoASgAoAKACgAoAKAEoAKACgAoATNABQAUAFACUAJQAUAFACUAJQAhoASgBKACgBKAFoAWgAoAWgBaAFoABQAtABQAtAC0AFABQAtABQAUAFABQAUALQAUAFABQAUAFAC0AFABQAUAFABQAUALQAUAJQAtACUALQAlABQAtABQAlAC0AFABQAlAC0AJmgAoAKAA0AFABQAUAFABQAUAFABmgAoAKACgAoAKACgAoAKACgAoAKACgAzQAUAFABQAUAFABQAUAFABQAUAFABQAUAGaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAEoAKACgAoAKACgBKACgAoAKAENABQAUAFABQAlACUABoASgBDQAUAIaAEoASgBKAEoAXNAC0AKKACgBaAFzQAtABQAtABQAooAWgAoAKACgBaACgAoAKACgBc0AGaACgAoAKACgAoAKAFoASgBaACgAoAKACgAoAKADNABQAZoAKACgAoAM0AFABQAZoAKAEoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoASgAoAKACgAoAKAEoAKACgAoAKAEoASgANACE0AJQAlACUAJQAGgBKAENABQAooAWgBc0AFAC0ALQAtABQAtABQAuaAFoAKACgAoAWgAoAKACgAoAKACgBc0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAJQAUAFABQAUAFACUAFABQAUAJQAUAJQAUAJQAhoAKAEoASgBKAENACUAJQAZoAUGgBc0ALQAooAKAFoAWgBRQAooAKACgAoAXNAC0AFABQAZoAXNABQAUAFABQAUAFABQAtABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAGaACgAoAKACgAoAM0AFABQAUAAoAKACgAoAKACgAoAKACgAoAM0AFABmgAoAKACgAoAM0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAJQAUAFABQAUAFABQAmaAA0AFABQAhoAM0AJQAUAFACUAJQAGgBKAEoASgBM0AFADSaAEzQAmaAFBoAcDQAoNABmgBQaAFzQAuaADNAC5oAXNABmgBc0AGaAFzQAZoAM0AGaAFoABQAtABQAUAFABQAUAGaADNAC0AFABQAZoAM0AGaAEoAXNABmgAoAM0AGaADNABQAUAGaADNABmgAoASgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAXNABQAUAJQAUAFABQAUAGaACgAoAKAFzQAlABQAUAGaAFzQAmaAFoAM0AJQAUALmgAzQAmaACgAoAM0AGaAFzQAZoATNAC5oATNABQAUAFABQAUAFABQAZoAM0AITQAZoATNABmgAzQAmaADNABmgBM0AJmgAJoAQmgBM0AITQAZoAQmgBM0ANJoAQmgBM0AJmgBd1ACg0ALmgB2aACgBRQA4UAFABQAoNAC0AAoAWgBRQAUAFABQAtABQAtABQAUAFABQAUAFAC0AFABQAUAFABQAUAJmgBaACgAoAKACgAoAKACgAoAKACgAoAKACgBKAFoAKAEoAKACgAoAKADNABQAUAFABmgAoAKAFzQAmaACgAzQAUAGaADNABmgAzQAZoAKADNABmgAoAM0AGaACgAzQAZoAM0AGaACgAoAM0AGaACgAoAKACgAzQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACGgBKACgAoADQAlABQAZoASgBM0AJQAGgBKAEoATNACZoATNACEigBpNACZoATNABmgBwNACg0AKKAFoAUUAOBoAKAFzQAuaAFzQAZoAXNABmgBc0AGaAFzQAUAKKACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAM0AGaACgAoAKACgAzQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABmgAoAKACgAoAKAEoAKAFoAKACgBKACgBaACgAoAKACgAzQAUAFABQAUAJQAtACUALQAlABmgAzQAZoAM0AGaAEoAM0ABNACZoATNABmgAJoATNABmgBM0AITQAmaAEoASgBKAEzQAlADSaAEzQAmaAG5oAWgBc0AOBoAXNAC5oAcDQAoPFAC5oAUGgAzQAoIoAXIoAM0ALmgAzQAtAC5oAM0AFAC5oAM0AFABQAUAFAC5oAM0AGaADNABmgAoAM0AGaADNABmgAzQAZoAM0AGaADNABmgAzQAZoAKACgAoASgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAWgAoASgAoAWgBKACgAoAKACgAoAKADNABmgAzQAZoATNABQAUAIaACgBKADNACZoAM0AJmgBM0AJmgAzQA0mgBM0AJmgBM0ANJoAQmgBuaAEJoAZuFAChqAHBqAFDUAO3UAOzQAoNAC5oAUGgBQaAFzQAoNABmgBc0ALmgBaACgBQaADNAADQAuaADNABk0AGaADNACg0ALmgAzQAZoAM0AGaADNABmgAzQAZoAM0AGaADNABmgAzQAZoAM0AGaADNABmgAzQAZoAM0AGaADNABmgAzQAZoAM0AGaADNABmgAzQAZoAM0AGaADNABmgBM0ALmgAzQAZoAM0AGaADNABmgAzQAZoAM0AGaADNABmgAzQAZoAM0AGaADNABmgAzQAZoAM0AGaADNABmgAzQAZoAM0AGaADNABmgAzQAZoAM0AGaADNABmgAzQAmaADNACZoAM0AGaADNABmgAzQAmaAEoAKAEoAM0AJQAUANzQAhNABmgBpNACZoATNADSaAEJoAbmgBCaAELUARbqAFBoAeDQAuaAHA0AOzQAoNACg0AOBoAUGgBc0ALmgAzQAuaAFzQAuaADNACg0ALmgAzQAuaADNABmgBaACgAoAWgAoAKADNABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABmgAoAKACgAoAKADNABQAUAFABQAUAFABmgAoAKACgAoAKACgAoAM0AFABQAUAFABQAUAFABmgAoAM0AGaACgAoAM0AFABQAUAFABQAUAFABQAZoASgAoAKAEzQAZoAM0AITQAZoATNABk0AJQAZoATNACZoATNACZoAM0AITQA0mgBM0ANzQAhNADSaAG5oAQtQA0mgCPdQAoagBwIoAcGoAcGoAcGoAXNADs0AKDQAoagB2aADNAC0AGaAHZoAXNABmgBQaAFzQAA0ALmgAzQAuaACgAoAWgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBM0ALQAUAFABQAUAFACUAGaAFoAKACgBKAFoAKACgAoAKACgAoASgAoAWgAoAKACgAoAKACgAoAKACgAoAKACgBDQAlABQAZoATdQAZoAM0AJmgBCaADNACZoAMmgBuaADNACUAJmgBCaAE3UANJoATNACE0ANLUAMLUAIWoAYWoATdQBGDQA4NQA4NxQAoagBwagBwagB26gB2eKADdQA7dQA4GgBQaAFzQAZoAXNACg0ALmgBQaADNACg0ALmgABoAWgBc0AGaADNAC5oAM0AGaADNAC5oAM0AGaAEzQAZoAXNABmgAzQAZoATNAC5oAKADNABmgBM0AGaADNAC5oAM0AGaAEzQAuaADNACZoAXNACUALmgBM0AGaADNABQAZoAXNACUALmgAoAM0AJmgAoAM0ALmgBKAFzQAmaADNABmgAzQAZoAM0AGaADNABmgAoAM0ALQAmaADNABmgAzQAZoAM0AGaA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";

        private string imagePart2Data =
            "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kbweCDQBHDOk8AlhIKHqfWpscccIeq+tc5JFcaNdebBmSyY8r6VvQXEd1Y+dEwIPX2oAmoo7UUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAN427Vp38WM0cjPFQTTRWto0src0ANurmO2tDJIQgXv61hW9tPqmoC8uQUtQfljNLBBPq16Lq6yLNT+7T+9XSKFVAFPH0oAAAqgAYFLRRQAUUUUAFFFFAHn3iz/kYof+vYf+hNRR4s/wCRih/69h/6E1FAHaab/wAi7Yf9eyf+girtUtN/5F2w/wCvZP8A0EVdoAKKKKACiiigBGRWhKOMg/ernJoJ9JvDc2uWsSfnSukz82e1NcKylSAwP8JoAitLmG5t/MjIYY+76VPk5wfvHpXNXFvcaXd/arLL22fnX0rbtbqK7txNGf8AeHpQBaooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKAE5LZNBIL0pJIqKedIIC7kDFACTzR21s0srYhHQVz8Ucmr3puJ8pZqflX+9SpHNrF/wCY5K2SHgf3q6FI0RAQu1FHCjtQA5VVUCqAFA4Ap1FFABRRRQAUUUUAFFFFAHn3iz/kYof+vYf+hNRR4s/5GKH/AK9h/wChNRQB2mm/8i7Yf9eyf+girtUtN/5F2w/69k/9BFXaACiiigAooooAKKKKAE2gqw4/2hXN3NrLp14b2yBMOfnQV0h+71w386TqMkA+qmgCpaXcd7AJIj9U9Ku4GMDmudvLOawuRe2JPq6CtayvoryANEfn/jFAFyiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiimu6ohZiAAM8mgBs0iRRMzsFVRnJrnF83Wr3cQUsUPT+/Q3m61e7ASlih6/366SGNIolVFCqo6CgBY41hjCqAFA4FO3Z70rck0nQUAFFFFABRRRQAUUUUAFFFFAHn3iz/AJGKH/r2H/oTUUeLP+Rih/69h/6E1FAHaab/AMi7Yf8AXsn/AKCKu1S03/kXbD/r2T/0EVdoAKKKKACiiigAooooAKKKKAGnGSpGVPWufu7OW0uDe2GQepUV0e75cryppuAAV7GgCjY30V5bq3SXuncVfb7455/nXP3tjLb3Bv7HIkH309avWN9HeQZBxN/GD1FAGlRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUU1mCoWYgADnNACSSIiEswUj+I9q5yR5tY1AwoGW0Q/Mf71JLLJq959lgLJbKfnf1robaGO3t1jiXCKMZ9aAFghSCAIoAwKlAJFAGXpOS2BQAtFFFABRRRQAUUUUAFFFFABRRRQB594s/wCRih/69h/6E1FHiz/kYof+vYf+hNRQB2mm/wDIu2H/AF7J/wCgirtUtN/5F2w/69k/9BFXaACiiigAooooAKKKKACiiigAooooACCTkdPSsG90+RZzf2Hyzjkgd63eCeDz3peCvBx60AZthfJeQkH5bhfvIe1aQO6LIPzDqfWsO/05hObuyJjuF5YD+KrOn6il3EUf93cLwyGgDTooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiikJAUsSAB3oAQsqIWk5T0rnJ7ibVbw2dtn7Mp+eT1ouLi41LUjaWpK23/LST0rctrWK2tBFGu1R+tACwQR2lusMKjpyasewOBR3IHSgBTGf71ABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFAHn3iz/kYof8Ar2H/AKE1FHiz/kYof+vYf+hNRQB2mm/8i7Yf9eyf+girtUtN/wCRdsP+vZP/AEEVdoAKKKKACiiigAooooAKKKKACiiigAooooACflyvUViahpxMv26y+W5HUDvW4evHBpD/AKzPT1oAyNO1FbpTFKPIuhwQe9a2GzgD6nNU2sbdrz7T5f7/AL4OKuBcY7J3FAC0UUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAIWXbnf06k1zt3cy6hffYrRikAPzMK6CaNZ4SjjKHriq8Ftb2qlIV2IerdaAFtbaGzsxHGPqfWrOR5igUHdjAWkyAP9qgB1FFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFAHn3iz/AJGKH/r2H/oTUUeLP+Rih/69h/6E1FAHaab/AMi7Yf8AXsn/AKCKu1S03/kXbD/r2T/0EVdoAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooA8+8Wf8AIxQ/9ew/9CaijxZ/yMUP/XsP/QmooA7TTf8AkXbD/r2T/wBBFXapab/yLth/17J/6CKu0AFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAefeLP+Rih/69h/6E1FHiz/AJGKH/r2H/oTUUAdppv/ACLth/17J/6CKu1S03/kXbD/AK9k/wDQRV2gAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigBjMsYLyOqJ6k4piTwMwRJ4pH7BWFcN8RSyfDm6ZHZH4wQcd68j+HE87/ABHs0knllTncCxPavjM24u+p5rSwPs78/Lre1rt9LHi4zOPY4uGH5L3trfu7dj6booor7M9oKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKAPPvFn/IxQ/9ew/9CaijxZ/yMUP/AF7D/wBCaigDtNN/5F2w/wCvZP8A0EVdqlpv/Iu2H/Xsn/oIq7QAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQB578Sv+SZ3f4fzryD4bf8lOs/x/lXsHxL/wCSZ3n4fzrx/wCG3/JTrP8AH+VfjPFX/JV4T/t38z4nNv8AkbUfl+bPp2RhHFJJ1RVJx68V5PbfFO2bxCbO7077NAjEed5mc/hXqtwf9AnAO4CNvl/Cvji7Xd4iljZiAZ8Y+pr3+PeIMdljoPDStdu6snfbTU9LiDMK+F9k6T3vf8D26++K9rDdstlp7XSD+IN1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MbAT0rtb+wttQ0uSzuow0Tj7x7V9Bjsvq57kvs68PZzetuzT0+TPRrYapj8Fy1I8sn+DR4F8OvFcGk3UtjfNsgbG0ntXu0mr6eNFkvPtURttufvDJryHVfhVKLzzdOu9yMSSm3GPxrPj+GGslkEl7KkfZMkivk8lxfEWVUPqjwnOl8L/AOD2PHwVXMcJT9jKjzW21OD8RXsF948uLq3bzIZHHNfQmmWA1L4PRWudqvGcd681f4V6kl0BHceainJO2vbdDspNO8L2tnK20xj0pcGZJj443ESxlLlU079nd6pFZJga6r1XWhbmX6nyptufD/jPLxtHPDJ1PcZr6Y0DxTpmtabEyXKR3IUB1Y4qt4l8Gad4ihMjgQXX/PUDrXmUvwv1a3vHFveP5XYrxU4HLM64exM1hqftaUn31/4DIw+Fx2W1n7KHNFns1/4g0nTIDJd3kafQ5q7YajZ6ppS3llIJYD/FXhsPwt1W4vkS5vpER/4yc16x4Y8PN4d0P7I9yb0DpxivsMmzXOMTin7fDezp273d/wBV8j2sDjMZWq/vafLH11ucL8WiTpNiRwOcVg/CbC6zeZOc4zXoHjjw5deIrG3jtnI8vPGPWs7wP4PvPDt9cy3Mmd+McV83i8nxsuK44qNN+zVtemx5lXA13m6q8vu9/keo0UUV+pn1YUUUUAFFFFABRRRQAUUUUAefeLP+Rih/69h/6E1FHiz/AJGKH/r2H/oTUUAdppv/ACLth/17J/6CKu1S03/kXbD/AK9k/wDQRV2gAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACjtiiigAooooAKKKKADvRRRQAUUUUAFFFFABRRRQAUUUUAHeiiigAooooAKKKKACiiigAooooAKKKKACiiigA70UUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAefeLP+Rih/69h/6E1FHiz/AJGKH/r2H/oTUUAdppv/ACLth/17J/6CKu1S03/kXbD/AK9k/wDQRV2gAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigDz7xZ/yMUP8A17D/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m/8AIu2H/Xsn/oIq7VLTf+RdsP8Ar2T/ANBFXaACiiigAI+QKtBwGHejp0qhe3y2dsWbl+woAL69Wzti7HMh+6g61Q0+zkmmN/fcyn7qn+GmWNlLcXn26+yzH7q/3a6BcBto6dhQAvaiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKAK88KTQGOVcxNWAHm0a92OGksWPFdP/ABktyvpUcsSzwlZEDDtQARyJJCJVbch6VIQCo3VjWVpc2WpsobfaHpmtnJBIPLdhQAUUUUAefeLP+Rih/wCvYf8AoTUUeLP+Rih/69h/6E1FAHaab/yLth/17J/6CKu1S03/AJF2w/69k/8AQRV2gAooooATnBPp92sWLT5ptYa8vG3YPyr2rbABHH3expOdvXLUALgAYHSiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigDz7xZ/wAjFD/17D/0JqKPFn/IxQ/9ew/9CaigDtNN/wCRdsP+vZP/AEEVdqlpv/Iu2H/Xsn/oIq7QAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQB594s/5GKH/r2H/oTUUeLP8AkYof+vYf+hNRQBDb+J7+CwghSGzKxxqoJRs4Ax/eqb/hLNR/542X/fDf/FUUUAH/AAlmo/8APGy/74b/AOKo/wCEs1H/AJ42X/fDf/FUUUAH/CWaj/zxsv8Avhv/AIqj/hLNR/542X/fDf8AxVFFAB/wlmo/88bL/vhv/iqP+Es1H/njZf8AfDf/ABVFFAB/wlmo/wDPGy/74b/4qj/hLNR/542X/fDf/FUUUAH/AAlmo/8APGy/74b/AOKo/wCEs1H/AJ42X/fDf/FUUUAH/CWaj/zxsv8Avhv/AIqj/hLNR/542X/fDf8AxVFFAB/wlmo/88bL/vhv/iqP+Es1H/njZf8AfDf/ABVFFAB/wlmo/wDPGy/74b/4qj/hLNR/542X/fDf/FUUUAH/AAlmo/8APGy/74b/AOKo/wCEs1H/AJ42X/fDf/FUUUAH/CWaj/zxsv8Avhv/AIqj/hLNR/542X/fDf8AxVFFAB/wlmo/88bL/vhv/iqP+Es1H/njZf8AfDf/ABVFFAB/wlmo/wDPGy/74b/4qj/hLNR/542X/fDf/FUUUAH/AAlmo/8APGy/74b/AOKo/wCEs1H/AJ42X/fDf/FUUUAH/CWaj/zxsv8Avhv/AIqj/hLNR/542X/fDf8AxVFFAB/wlmo/88bL/vhv/iqP+Es1H/njZf8AfDf/ABVFFAB/wlmo/wDPGy/74b/4qj/hLNR/542X/fDf/FUUUAH/AAlmo/8APGy/74b/AOKo/wCEs1H/AJ42X/fDf/FUUUAH/CWaj/zxsv8Avhv/AIqj/hLNR/542X/fDf8AxVFFAB/wlmo/88bL/vhv/iqP+Es1H/njZf8AfDf/ABVFFAB/wlmo/wDPGy/74b/4qj/hLNR/542X/fDf/FUUUAH/AAlmo/8APGy/74b/AOKo/wCEs1H/AJ42X/fDf/FUUUAH/CWaj/zxsv8Avhv/AIqj/hLNR/542X/fDf8AxVFFAB/wlmo/88bL/vhv/iqP+Es1H/njZf8AfDf/ABVFFAB/wlmo/wDPGy/74b/4qj/hLNR/542X/fDf/FUUUAH/AAlmo/8APGy/74b/AOKo/wCEs1H/AJ42X/fDf/FUUUAH/CWaj/zxsv8Avhv/AIqj/hLNR/542X/fDf8AxVFFAB/wlmo/88bL/vhv/iqP+Es1H/njZf8AfDf/ABVFFAB/wlmo/wDPGy/74b/4qj/hLNR/542X/fDf/FUUUAH/AAlmo/8APGy/74b/AOKo/wCEs1H/AJ42X/fDf/FUUUAH/CWaj/zxsv8Avhv/AIqj/hLNR/542X/fDf8AxVFFAGFqep3GoX6TTJCrLGFAQEDGSe5PrRRRQB//2Q==";

        private string thumbnailPart1Data =
            "/9j/4AAQSkZJRgABAQEASABIAAD/4ge4SUNDX1BST0ZJTEUAAQEAAAeoYXBwbAIgAABtbnRyUkdCIFhZWiAH2QACABkACwAaAAthY3NwQVBQTAAAAABhcHBsAAAAAAAAAAAAAAAAAAAAAAAA9tYAAQAAAADTLWFwcGwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAtkZXNjAAABCAAAAG9kc2NtAAABeAAABWxjcHJ0AAAG5AAAADh3dHB0AAAHHAAAABRyWFlaAAAHMAAAABRnWFlaAAAHRAAAABRiWFlaAAAHWAAAABRyVFJDAAAHbAAAAA5jaGFkAAAHfAAAACxiVFJDAAAHbAAAAA5nVFJDAAAHbAAAAA5kZXNjAAAAAAAAABRHZW5lcmljIFJHQiBQcm9maWxlAAAAAAAAAAAAAAAUR2VuZXJpYyBSR0IgUHJvZmlsZQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAbWx1YwAAAAAAAAAeAAAADHNrU0sAAAAoAAABeGhySFIAAAAoAAABoGNhRVMAAAAkAAAByHB0QlIAAAAmAAAB7HVrVUEAAAAqAAACEmZyRlUAAAAoAAACPHpoVFcAAAAWAAACZGl0SVQAAAAoAAACem5iTk8AAAAmAAAComtvS1IAAAAWAAACyGNzQ1oAAAAiAAAC3mhlSUwAAAAeAAADAGRlREUAAAAsAAADHmh1SFUAAAAoAAADSnN2U0UAAAAmAAAConpoQ04AAAAWAAADcmphSlAAAAAaAAADiHJvUk8AAAAkAAADomVsR1IAAAAiAAADxnB0UE8AAAAmAAAD6G5sTkwAAAAoAAAEDmVzRVMAAAAmAAAD6HRoVEgAAAAkAAAENnRyVFIAAAAiAAAEWmZpRkkAAAAoAAAEfHBsUEwAAAAsAAAEpHJ1UlUAAAAiAAAE0GFyRUcAAAAmAAAE8mVuVVMAAAAmAAAFGGRhREsAAAAuAAAFPgBWAWEAZQBvAGIAZQBjAG4A/QAgAFIARwBCACAAcAByAG8AZgBpAGwARwBlAG4AZQByAGkBDQBrAGkAIABSAEcAQgAgAHAAcgBvAGYAaQBsAFAAZQByAGYAaQBsACAAUgBHAEIAIABnAGUAbgDoAHIAaQBjAFAAZQByAGYAaQBsACAAUgBHAEIAIABHAGUAbgDpAHIAaQBjAG8EFwQwBDMEMAQ7BEwEPQQ4BDkAIAQ/BEAEPgREBDAEOQQ7ACAAUgBHAEIAUAByAG8AZgBpAGwAIABnAOkAbgDpAHIAaQBxAHUAZQAgAFIAVgBCkBp1KAAgAFIARwBCACCCcl9pY8+P8ABQAHIAbwBmAGkAbABvACAAUgBHAEIAIABnAGUAbgBlAHIAaQBjAG8ARwBlAG4AZQByAGkAcwBrACAAUgBHAEIALQBwAHIAbwBmAGkAbMd8vBgAIABSAEcAQgAg1QS4XNMMx3wATwBiAGUAYwBuAP0AIABSAEcAQgAgAHAAcgBvAGYAaQBsBeQF6AXVBeQF2QXcACAAUgBHAEIAIAXbBdwF3AXZAEEAbABsAGcAZQBtAGUAaQBuAGUAcwAgAFIARwBCAC0AUAByAG8AZgBpAGwAwQBsAHQAYQBsAOEAbgBvAHMAIABSAEcAQgAgAHAAcgBvAGYAaQBsZm6QGgAgAFIARwBCACBjz4/wZYdO9k4AgiwAIABSAEcAQgAgMNcw7TDVMKEwpDDrAFAAcgBvAGYAaQBsACAAUgBHAEIAIABnAGUAbgBlAHIAaQBjA5MDtQO9A7kDugPMACADwAPBA78DxgOvA7sAIABSAEcAQgBQAGUAcgBmAGkAbAAgAFIARwBCACAAZwBlAG4A6QByAGkAYwBvAEEAbABnAGUAbQBlAGUAbgAgAFIARwBCAC0AcAByAG8AZgBpAGUAbA5CDhsOIw5EDh8OJQ5MACAAUgBHAEIAIA4XDjEOSA4nDkQOGwBHAGUAbgBlAGwAIABSAEcAQgAgAFAAcgBvAGYAaQBsAGkAWQBsAGUAaQBuAGUAbgAgAFIARwBCAC0AcAByAG8AZgBpAGkAbABpAFUAbgBpAHcAZQByAHMAYQBsAG4AeQAgAHAAcgBvAGYAaQBsACAAUgBHAEIEHgQxBEkEOAQ5ACAEPwRABD4ERAQ4BDsETAAgAFIARwBCBkUGRAZBACAGKgY5BjEGSgZBACAAUgBHAEIAIAYnBkQGOQYnBkUARwBlAG4AZQByAGkAYwAgAFIARwBCACAAUAByAG8AZgBpAGwAZQBHAGUAbgBlAHIAZQBsACAAUgBHAEIALQBiAGUAcwBrAHIAaQB2AGUAbABz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I/L7wdfXp91/y0G/2pjBLAg9h/jv/wA459zklcXtvNfcxv8AawHJbp3yOvP+0f8APPej2b8vx/yD261vJfc/XXX5iHVV9QT345/H5u3/ANbNHs35ff8A8Aft7bS791tv177h/a6AHLDjofQ/99d/zo9nLy+//gC9utXza9d+vd8239ajDrC8/OvXv37Z69vx70/ZS306de+wfWEuvp066/a7/l3KkutoAcP17D/I6898Z9KpUW9/6+f49zKWJXf1vpfrv3et9ShLro5GTjnnPrnIxuPHbHBq1Qe9m/LX9F/VzKWLj/N31vzPs938tvxM99aPILLx0yd35c9/p6/hqqPVLv2X9fqYyxfn93z7W/q76mZPrgHPm+vTpjnr3GeP6DOatUb76v53/D/gmE8X9/8AWr3d38jDu9eVVIL9dw6nP+PPPHBzx3reNHtH7+/ov60OSpi31l3/AK6u2vVo4jVvGVtbbk8zzZskCNW4U5z87cjAOPlGW6g7Sd1ddPCylq721v0/pvffz16+bXzCnTvG/NLstturTb/HfQ8e1/4gFWffL50gJ2xIW8qLn+Mg4znqv3zjDODyfVoYHqlyrq38T72/zsr9mfOYvN9XeXPJbR+zG/ezs3829Hd6a/OGmePFikBWW4t3z1DZHbPzLtbB7/IQfevdqYS6aajJeen+f47Hx1HNOV3UpQd0rp3Xq7NPproep6P8R42Cq80UvT5lcRSHB/uPhTjggBATj7x5NedVwFr2ur62fvRt6/g/e7M9zD50mlzSjPpdNqXrby/w38+/pmneNLWYLsuQjMANkrBGwfQsdhJ7Yckjr3rz6mEkrtwdtdY63t3X47b+p7dHM6crWnZ9m7b9um/zs35nY2vifKj9526nIzz1ByR64HeuWeH1a036/fp99ttPmelTx17av+n+f59XqzetvEykDMnB9yOeB/eOCTWEsO+z36a6d7efp8zphjV36+nX+u+u5tw6+hxiQn1+YHj8y2PoPf3rJ0Wr67d/+HW/9anSsSn17dn+P5t/f1NBNePH7wZHXdj8cnOOee/0qHRfZW9GjaOJd9JpPzfz7lldebON68/7YHPOTj6jGDnnrnIqXR6uK8t/v1777mixUv5k/mvnurk411snkdORkj8x/k1Psf7vptp6FLFT7p/Na9dUuxJ/brH+Ig8/xHB59xx0J9emOvC9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";

        private Stream GetBinaryDataStream(string base64String)
        {
            return new MemoryStream(Convert.FromBase64String(base64String));
        }

        #endregion
    }
}
// ReSharper restore InconsistentNaming