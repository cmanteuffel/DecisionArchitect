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

using DocumentFormat.OpenXml.Packaging;
using Ap = DocumentFormat.OpenXml.ExtendedProperties;
using Vt = DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Presentation;
using A = DocumentFormat.OpenXml.Drawing;
using P14 = DocumentFormat.OpenXml.Office2010.PowerPoint;
using A14 = DocumentFormat.OpenXml.Office2010.Drawing;

namespace DecisionViewpoints.Logic.Reporting
{
    public class PowerPointTemplate
    {
        // Creates a PresentationDocument.
        public void CreatePackage(string filePath)
        {
            using (PresentationDocument package = PresentationDocument.Create(filePath, PresentationDocumentType.Presentation))
            {
                CreateParts(package);
            }
        }

        // Adds child parts and generates content of the specified part.
        public void CreateParts(PresentationDocument document)
        {
            ExtendedFilePropertiesPart extendedFilePropertiesPart1 = document.AddNewPart<ExtendedFilePropertiesPart>("rId4");
            GenerateExtendedFilePropertiesPart1Content(extendedFilePropertiesPart1);

            PresentationPart presentationPart1 = document.AddPresentationPart();
            GeneratePresentationPart1Content(presentationPart1);

            SlidePart slidePart1 = presentationPart1.AddNewPart<SlidePart>("rId3");
            GenerateSlidePart1Content(slidePart1);

            SlideLayoutPart slideLayoutPart1 = slidePart1.AddNewPart<SlideLayoutPart>("rId1");
            GenerateSlideLayoutPart1Content(slideLayoutPart1);

            SlideMasterPart slideMasterPart1 = slideLayoutPart1.AddNewPart<SlideMasterPart>("rId1");
            GenerateSlideMasterPart1Content(slideMasterPart1);

            SlideLayoutPart slideLayoutPart2 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId11");
            GenerateSlideLayoutPart2Content(slideLayoutPart2);

            slideLayoutPart2.AddPart(slideMasterPart1, "rId1");

            SlideLayoutPart slideLayoutPart3 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId12");
            GenerateSlideLayoutPart3Content(slideLayoutPart3);

            slideLayoutPart3.AddPart(slideMasterPart1, "rId1");

            slideMasterPart1.AddPart(slideLayoutPart1, "rId13");

            ThemePart themePart1 = slideMasterPart1.AddNewPart<ThemePart>("rId14");
            GenerateThemePart1Content(themePart1);

            ImagePart imagePart1 = themePart1.AddNewPart<ImagePart>("image/jpeg", "rId1");
            GenerateImagePart1Content(imagePart1);

            SlideLayoutPart slideLayoutPart4 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId1");
            GenerateSlideLayoutPart4Content(slideLayoutPart4);

            slideLayoutPart4.AddPart(slideMasterPart1, "rId1");

            SlideLayoutPart slideLayoutPart5 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId2");
            GenerateSlideLayoutPart5Content(slideLayoutPart5);

            slideLayoutPart5.AddPart(slideMasterPart1, "rId1");

            SlideLayoutPart slideLayoutPart6 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId3");
            GenerateSlideLayoutPart6Content(slideLayoutPart6);

            slideLayoutPart6.AddPart(slideMasterPart1, "rId1");

            SlideLayoutPart slideLayoutPart7 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId4");
            GenerateSlideLayoutPart7Content(slideLayoutPart7);

            slideLayoutPart7.AddPart(slideMasterPart1, "rId1");

            SlideLayoutPart slideLayoutPart8 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId5");
            GenerateSlideLayoutPart8Content(slideLayoutPart8);

            slideLayoutPart8.AddPart(slideMasterPart1, "rId1");

            SlideLayoutPart slideLayoutPart9 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId6");
            GenerateSlideLayoutPart9Content(slideLayoutPart9);

            slideLayoutPart9.AddPart(slideMasterPart1, "rId1");

            SlideLayoutPart slideLayoutPart10 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId7");
            GenerateSlideLayoutPart10Content(slideLayoutPart10);

            slideLayoutPart10.AddPart(slideMasterPart1, "rId1");

            SlideLayoutPart slideLayoutPart11 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId8");
            GenerateSlideLayoutPart11Content(slideLayoutPart11);

            slideLayoutPart11.AddPart(slideMasterPart1, "rId1");

            SlideLayoutPart slideLayoutPart12 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId9");
            GenerateSlideLayoutPart12Content(slideLayoutPart12);

            slideLayoutPart12.AddPart(slideMasterPart1, "rId1");

            SlideLayoutPart slideLayoutPart13 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId10");
            GenerateSlideLayoutPart13Content(slideLayoutPart13);

            slideLayoutPart13.AddPart(slideMasterPart1, "rId1");

            SlidePart slidePart2 = presentationPart1.AddNewPart<SlidePart>("rId4");
            GenerateSlidePart2Content(slidePart2);

            slidePart2.AddPart(slideLayoutPart5, "rId1");

            ImagePart imagePart2 = slidePart2.AddNewPart<ImagePart>("image/jpeg", "rId2");
            GenerateImagePart2Content(imagePart2);

            SlidePart slidePart3 = presentationPart1.AddNewPart<SlidePart>("rId5");
            GenerateSlidePart3Content(slidePart3);

            slidePart3.AddPart(slideLayoutPart5, "rId1");

            ExtendedPart extendedPart1 = presentationPart1.AddExtendedPart("http://schemas.openxmlformats.org/officeDocument/2006/relationships/printerSettings", "application/vnd.openxmlformats-officedocument.presentationml.printerSettings", "bin", "rId6");
            GenerateExtendedPart1Content(extendedPart1);

            PresentationPropertiesPart presentationPropertiesPart1 = presentationPart1.AddNewPart<PresentationPropertiesPart>("rId7");
            GeneratePresentationPropertiesPart1Content(presentationPropertiesPart1);

            ViewPropertiesPart viewPropertiesPart1 = presentationPart1.AddNewPart<ViewPropertiesPart>("rId8");
            GenerateViewPropertiesPart1Content(viewPropertiesPart1);

            presentationPart1.AddPart(themePart1, "rId9");

            TableStylesPart tableStylesPart1 = presentationPart1.AddNewPart<TableStylesPart>("rId10");
            GenerateTableStylesPart1Content(tableStylesPart1);

            presentationPart1.AddPart(slideMasterPart1, "rId1");

            SlidePart slidePart4 = presentationPart1.AddNewPart<SlidePart>("rId2");
            GenerateSlidePart4Content(slidePart4);

            slidePart4.AddPart(slideLayoutPart1, "rId1");

            ThumbnailPart thumbnailPart1 = document.AddNewPart<ThumbnailPart>("image/jpeg", "rId2");
            GenerateThumbnailPart1Content(thumbnailPart1);

            SetPackageProperties(document);
        }

        // Generates content of extendedFilePropertiesPart1.
        private void GenerateExtendedFilePropertiesPart1Content(ExtendedFilePropertiesPart extendedFilePropertiesPart1)
        {
            Ap.Properties properties1 = new Ap.Properties();
            properties1.AddNamespaceDeclaration("vt", "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");
            Ap.Template template1 = new Ap.Template();
            template1.Text = "Breeze.thmx";
            Ap.TotalTime totalTime1 = new Ap.TotalTime();
            totalTime1.Text = "42";
            Ap.Words words1 = new Ap.Words();
            words1.Text = "57";
            Ap.Application application1 = new Ap.Application();
            application1.Text = "Microsoft Macintosh PowerPoint";
            Ap.PresentationFormat presentationFormat1 = new Ap.PresentationFormat();
            presentationFormat1.Text = "On-screen Show (4:3)";
            Ap.Paragraphs paragraphs1 = new Ap.Paragraphs();
            paragraphs1.Text = "24";
            Ap.Slides slides1 = new Ap.Slides();
            slides1.Text = "4";
            Ap.Notes notes1 = new Ap.Notes();
            notes1.Text = "0";
            Ap.HiddenSlides hiddenSlides1 = new Ap.HiddenSlides();
            hiddenSlides1.Text = "0";
            Ap.MultimediaClips multimediaClips1 = new Ap.MultimediaClips();
            multimediaClips1.Text = "0";
            Ap.ScaleCrop scaleCrop1 = new Ap.ScaleCrop();
            scaleCrop1.Text = "false";

            Ap.HeadingPairs headingPairs1 = new Ap.HeadingPairs();

            Vt.VTVector vTVector1 = new Vt.VTVector() { BaseType = Vt.VectorBaseValues.Variant, Size = (UInt32Value)4U };

            Vt.Variant variant1 = new Vt.Variant();
            Vt.VTLPSTR vTLPSTR1 = new Vt.VTLPSTR();
            vTLPSTR1.Text = "Theme";

            variant1.Append(vTLPSTR1);

            Vt.Variant variant2 = new Vt.Variant();
            Vt.VTInt32 vTInt321 = new Vt.VTInt32();
            vTInt321.Text = "1";

            variant2.Append(vTInt321);

            Vt.Variant variant3 = new Vt.Variant();
            Vt.VTLPSTR vTLPSTR2 = new Vt.VTLPSTR();
            vTLPSTR2.Text = "Slide Titles";

            variant3.Append(vTLPSTR2);

            Vt.Variant variant4 = new Vt.Variant();
            Vt.VTInt32 vTInt322 = new Vt.VTInt32();
            vTInt322.Text = "4";

            variant4.Append(vTInt322);

            vTVector1.Append(variant1);
            vTVector1.Append(variant2);
            vTVector1.Append(variant3);
            vTVector1.Append(variant4);

            headingPairs1.Append(vTVector1);

            Ap.TitlesOfParts titlesOfParts1 = new Ap.TitlesOfParts();

            Vt.VTVector vTVector2 = new Vt.VTVector() { BaseType = Vt.VectorBaseValues.Lpstr, Size = (UInt32Value)5U };
            Vt.VTLPSTR vTLPSTR3 = new Vt.VTLPSTR();
            vTLPSTR3.Text = "Breeze";
            Vt.VTLPSTR vTLPSTR4 = new Vt.VTLPSTR();
            vTLPSTR4.Text = "PowerPoint Presentation";
            Vt.VTLPSTR vTLPSTR5 = new Vt.VTLPSTR();
            vTLPSTR5.Text = "PowerPoint Presentation";
            Vt.VTLPSTR vTLPSTR6 = new Vt.VTLPSTR();
            vTLPSTR6.Text = "PowerPoint Presentation";
            Vt.VTLPSTR vTLPSTR7 = new Vt.VTLPSTR();
            vTLPSTR7.Text = "PowerPoint Presentation";

            vTVector2.Append(vTLPSTR3);
            vTVector2.Append(vTLPSTR4);
            vTVector2.Append(vTLPSTR5);
            vTVector2.Append(vTLPSTR6);
            vTVector2.Append(vTLPSTR7);

            titlesOfParts1.Append(vTVector2);
            Ap.LinksUpToDate linksUpToDate1 = new Ap.LinksUpToDate();
            linksUpToDate1.Text = "false";
            Ap.SharedDocument sharedDocument1 = new Ap.SharedDocument();
            sharedDocument1.Text = "false";
            Ap.HyperlinksChanged hyperlinksChanged1 = new Ap.HyperlinksChanged();
            hyperlinksChanged1.Text = "false";
            Ap.ApplicationVersion applicationVersion1 = new Ap.ApplicationVersion();
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
            Presentation presentation1 = new Presentation() { SaveSubsetFonts = true };
            presentation1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            presentation1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            presentation1.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            SlideMasterIdList slideMasterIdList1 = new SlideMasterIdList();
            SlideMasterId slideMasterId1 = new SlideMasterId() { Id = (UInt32Value)2147484277U, RelationshipId = "rId1" };

            slideMasterIdList1.Append(slideMasterId1);

            SlideIdList slideIdList1 = new SlideIdList();
            SlideId slideId1 = new SlideId() { Id = (UInt32Value)256U, RelationshipId = "rId2" };
            SlideId slideId2 = new SlideId() { Id = (UInt32Value)260U, RelationshipId = "rId3" };
            SlideId slideId3 = new SlideId() { Id = (UInt32Value)258U, RelationshipId = "rId4" };
            SlideId slideId4 = new SlideId() { Id = (UInt32Value)259U, RelationshipId = "rId5" };

            slideIdList1.Append(slideId1);
            slideIdList1.Append(slideId2);
            slideIdList1.Append(slideId3);
            slideIdList1.Append(slideId4);
            SlideSize slideSize1 = new SlideSize() { Cx = 9144000, Cy = 6858000, Type = SlideSizeValues.Screen4x3 };
            NotesSize notesSize1 = new NotesSize() { Cx = 6858000L, Cy = 9144000L };

            DefaultTextStyle defaultTextStyle1 = new DefaultTextStyle();

            A.DefaultParagraphProperties defaultParagraphProperties1 = new A.DefaultParagraphProperties();
            A.DefaultRunProperties defaultRunProperties1 = new A.DefaultRunProperties() { Language = "en-US" };

            defaultParagraphProperties1.Append(defaultRunProperties1);

            A.Level1ParagraphProperties level1ParagraphProperties1 = new A.Level1ParagraphProperties() { LeftMargin = 0, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties2 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill1 = new A.SolidFill();
            A.SchemeColor schemeColor1 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill1.Append(schemeColor1);
            A.LatinFont latinFont1 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont1 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont1 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties2.Append(solidFill1);
            defaultRunProperties2.Append(latinFont1);
            defaultRunProperties2.Append(eastAsianFont1);
            defaultRunProperties2.Append(complexScriptFont1);

            level1ParagraphProperties1.Append(defaultRunProperties2);

            A.Level2ParagraphProperties level2ParagraphProperties1 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties3 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill2 = new A.SolidFill();
            A.SchemeColor schemeColor2 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill2.Append(schemeColor2);
            A.LatinFont latinFont2 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont2 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont2 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties3.Append(solidFill2);
            defaultRunProperties3.Append(latinFont2);
            defaultRunProperties3.Append(eastAsianFont2);
            defaultRunProperties3.Append(complexScriptFont2);

            level2ParagraphProperties1.Append(defaultRunProperties3);

            A.Level3ParagraphProperties level3ParagraphProperties1 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties4 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill3 = new A.SolidFill();
            A.SchemeColor schemeColor3 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill3.Append(schemeColor3);
            A.LatinFont latinFont3 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont3 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont3 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties4.Append(solidFill3);
            defaultRunProperties4.Append(latinFont3);
            defaultRunProperties4.Append(eastAsianFont3);
            defaultRunProperties4.Append(complexScriptFont3);

            level3ParagraphProperties1.Append(defaultRunProperties4);

            A.Level4ParagraphProperties level4ParagraphProperties1 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties5 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill4 = new A.SolidFill();
            A.SchemeColor schemeColor4 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill4.Append(schemeColor4);
            A.LatinFont latinFont4 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont4 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont4 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties5.Append(solidFill4);
            defaultRunProperties5.Append(latinFont4);
            defaultRunProperties5.Append(eastAsianFont4);
            defaultRunProperties5.Append(complexScriptFont4);

            level4ParagraphProperties1.Append(defaultRunProperties5);

            A.Level5ParagraphProperties level5ParagraphProperties1 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties6 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill5 = new A.SolidFill();
            A.SchemeColor schemeColor5 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill5.Append(schemeColor5);
            A.LatinFont latinFont5 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont5 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont5 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties6.Append(solidFill5);
            defaultRunProperties6.Append(latinFont5);
            defaultRunProperties6.Append(eastAsianFont5);
            defaultRunProperties6.Append(complexScriptFont5);

            level5ParagraphProperties1.Append(defaultRunProperties6);

            A.Level6ParagraphProperties level6ParagraphProperties1 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties7 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill6 = new A.SolidFill();
            A.SchemeColor schemeColor6 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill6.Append(schemeColor6);
            A.LatinFont latinFont6 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont6 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont6 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties7.Append(solidFill6);
            defaultRunProperties7.Append(latinFont6);
            defaultRunProperties7.Append(eastAsianFont6);
            defaultRunProperties7.Append(complexScriptFont6);

            level6ParagraphProperties1.Append(defaultRunProperties7);

            A.Level7ParagraphProperties level7ParagraphProperties1 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties8 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill7 = new A.SolidFill();
            A.SchemeColor schemeColor7 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill7.Append(schemeColor7);
            A.LatinFont latinFont7 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont7 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont7 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties8.Append(solidFill7);
            defaultRunProperties8.Append(latinFont7);
            defaultRunProperties8.Append(eastAsianFont7);
            defaultRunProperties8.Append(complexScriptFont7);

            level7ParagraphProperties1.Append(defaultRunProperties8);

            A.Level8ParagraphProperties level8ParagraphProperties1 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties9 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill8 = new A.SolidFill();
            A.SchemeColor schemeColor8 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill8.Append(schemeColor8);
            A.LatinFont latinFont8 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont8 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont8 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties9.Append(solidFill8);
            defaultRunProperties9.Append(latinFont8);
            defaultRunProperties9.Append(eastAsianFont8);
            defaultRunProperties9.Append(complexScriptFont8);

            level8ParagraphProperties1.Append(defaultRunProperties9);

            A.Level9ParagraphProperties level9ParagraphProperties1 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties10 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill9 = new A.SolidFill();
            A.SchemeColor schemeColor9 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill9.Append(schemeColor9);
            A.LatinFont latinFont9 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont9 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont9 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

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
            Slide slide1 = new Slide();
            slide1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slide1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slide1.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData1 = new CommonSlideData();

            ShapeTree shapeTree1 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties1 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties1 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties1 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties1 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties1.Append(nonVisualDrawingProperties1);
            nonVisualGroupShapeProperties1.Append(nonVisualGroupShapeDrawingProperties1);
            nonVisualGroupShapeProperties1.Append(applicationNonVisualDrawingProperties1);

            GroupShapeProperties groupShapeProperties1 = new GroupShapeProperties();

            A.TransformGroup transformGroup1 = new A.TransformGroup();
            A.Offset offset1 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents1 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset1 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents1 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup1.Append(offset1);
            transformGroup1.Append(extents1);
            transformGroup1.Append(childOffset1);
            transformGroup1.Append(childExtents1);

            groupShapeProperties1.Append(transformGroup1);

            Shape shape1 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties1 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties2 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Title 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties1 = new NonVisualShapeDrawingProperties() { TextBox = true };
            A.ShapeLocks shapeLocks1 = new A.ShapeLocks();

            nonVisualShapeDrawingProperties1.Append(shapeLocks1);
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties2 = new ApplicationNonVisualDrawingProperties();

            nonVisualShapeProperties1.Append(nonVisualDrawingProperties2);
            nonVisualShapeProperties1.Append(nonVisualShapeDrawingProperties1);
            nonVisualShapeProperties1.Append(applicationNonVisualDrawingProperties2);

            ShapeProperties shapeProperties1 = new ShapeProperties();

            A.Transform2D transform2D1 = new A.Transform2D();
            A.Offset offset2 = new A.Offset() { X = 533400L, Y = 381000L };
            A.Extents extents2 = new A.Extents() { Cx = 8042276L, Cy = 1447800L };

            transform2D1.Append(offset2);
            transform2D1.Append(extents2);

            A.PresetGeometry presetGeometry1 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList1 = new A.AdjustValueList();

            presetGeometry1.Append(adjustValueList1);

            shapeProperties1.Append(transform2D1);
            shapeProperties1.Append(presetGeometry1);

            TextBody textBody1 = new TextBody();

            A.BodyProperties bodyProperties1 = new A.BodyProperties() { Vertical = A.TextVerticalValues.Horizontal, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, RightToLeftColumns = false, Anchor = A.TextAnchoringTypeValues.Bottom, AnchorCenter = false };
            A.NoAutoFit noAutoFit1 = new A.NoAutoFit();

            bodyProperties1.Append(noAutoFit1);

            A.ListStyle listStyle1 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties2 = new A.Level1ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Center, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore1 = new A.SpaceBefore();
            A.SpacingPercent spacingPercent1 = new A.SpacingPercent() { Val = 0 };

            spaceBefore1.Append(spacingPercent1);
            A.NoBullet noBullet1 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties11 = new A.DefaultRunProperties() { FontSize = 4600, Kerning = 1200 };

            A.SolidFill solidFill10 = new A.SolidFill();
            A.SchemeColor schemeColor10 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            solidFill10.Append(schemeColor10);
            A.LatinFont latinFont10 = new A.LatinFont() { Typeface = "+mj-lt" };
            A.EastAsianFont eastAsianFont10 = new A.EastAsianFont() { Typeface = "+mj-ea" };
            A.ComplexScriptFont complexScriptFont10 = new A.ComplexScriptFont() { Typeface = "+mj-cs" };

            defaultRunProperties11.Append(solidFill10);
            defaultRunProperties11.Append(latinFont10);
            defaultRunProperties11.Append(eastAsianFont10);
            defaultRunProperties11.Append(complexScriptFont10);

            level1ParagraphProperties2.Append(spaceBefore1);
            level1ParagraphProperties2.Append(noBullet1);
            level1ParagraphProperties2.Append(defaultRunProperties11);

            listStyle1.Append(level1ParagraphProperties2);

            A.Paragraph paragraph1 = new A.Paragraph();

            A.Run run1 = new A.Run();

            A.RunProperties runProperties1 = new A.RunProperties() { Language = "en-US", FontSize = 2200, Dirty = false };
            runProperties1.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text1 = new A.Text();
            text1.Text = "{topic}";

            run1.Append(runProperties1);
            run1.Append(text1);
            A.EndParagraphRunProperties endParagraphRunProperties1 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 2200, Dirty = false };

            paragraph1.Append(run1);
            paragraph1.Append(endParagraphRunProperties1);

            textBody1.Append(bodyProperties1);
            textBody1.Append(listStyle1);
            textBody1.Append(paragraph1);

            shape1.Append(nonVisualShapeProperties1);
            shape1.Append(shapeProperties1);
            shape1.Append(textBody1);

            Shape shape2 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties2 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties3 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "TextBox 1" };
            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties2 = new NonVisualShapeDrawingProperties() { TextBox = true };
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties3 = new ApplicationNonVisualDrawingProperties();

            nonVisualShapeProperties2.Append(nonVisualDrawingProperties3);
            nonVisualShapeProperties2.Append(nonVisualShapeDrawingProperties2);
            nonVisualShapeProperties2.Append(applicationNonVisualDrawingProperties3);

            ShapeProperties shapeProperties2 = new ShapeProperties();

            A.Transform2D transform2D2 = new A.Transform2D();
            A.Offset offset3 = new A.Offset() { X = 1495778L, Y = 2111514L };
            A.Extents extents3 = new A.Extents() { Cx = 6505222L, Cy = 369332L };

            transform2D2.Append(offset3);
            transform2D2.Append(extents3);

            A.PresetGeometry presetGeometry2 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList2 = new A.AdjustValueList();

            presetGeometry2.Append(adjustValueList2);
            A.NoFill noFill1 = new A.NoFill();

            shapeProperties2.Append(transform2D2);
            shapeProperties2.Append(presetGeometry2);
            shapeProperties2.Append(noFill1);

            TextBody textBody2 = new TextBody();

            A.BodyProperties bodyProperties2 = new A.BodyProperties() { Wrap = A.TextWrappingValues.Square, RightToLeftColumns = false };
            A.ShapeAutoFit shapeAutoFit1 = new A.ShapeAutoFit();

            bodyProperties2.Append(shapeAutoFit1);
            A.ListStyle listStyle2 = new A.ListStyle();

            A.Paragraph paragraph2 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties1 = new A.ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Justified };

            A.Run run2 = new A.Run();

            A.RunProperties runProperties2 = new A.RunProperties() { Language = "en-US" };
            runProperties2.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text2 = new A.Text();
            text2.Text = "{description}";

            run2.Append(runProperties2);
            run2.Append(text2);
            A.EndParagraphRunProperties endParagraphRunProperties2 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

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

            CommonSlideDataExtensionList commonSlideDataExtensionList1 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension1 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId1 = new P14.CreationId() { Val = (UInt32Value)130268486U };
            creationId1.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension1.Append(creationId1);

            commonSlideDataExtensionList1.Append(commonSlideDataExtension1);

            commonSlideData1.Append(shapeTree1);
            commonSlideData1.Append(commonSlideDataExtensionList1);

            ColorMapOverride colorMapOverride1 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping1 = new A.MasterColorMapping();

            colorMapOverride1.Append(masterColorMapping1);

            slide1.Append(commonSlideData1);
            slide1.Append(colorMapOverride1);

            slidePart1.Slide = slide1;
        }

        // Generates content of slideLayoutPart1.
        private void GenerateSlideLayoutPart1Content(SlideLayoutPart slideLayoutPart1)
        {
            SlideLayout slideLayout1 = new SlideLayout() { UserDrawn = true };
            slideLayout1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout1.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData2 = new CommonSlideData() { Name = "1_Title Slide" };

            ShapeTree shapeTree2 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties2 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties4 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties2 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties4 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties2.Append(nonVisualDrawingProperties4);
            nonVisualGroupShapeProperties2.Append(nonVisualGroupShapeDrawingProperties2);
            nonVisualGroupShapeProperties2.Append(applicationNonVisualDrawingProperties4);

            GroupShapeProperties groupShapeProperties2 = new GroupShapeProperties();

            A.TransformGroup transformGroup2 = new A.TransformGroup();
            A.Offset offset4 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents4 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset2 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents2 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup2.Append(offset4);
            transformGroup2.Append(extents4);
            transformGroup2.Append(childOffset2);
            transformGroup2.Append(childExtents2);

            groupShapeProperties2.Append(transformGroup2);

            Shape shape3 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties3 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties5 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties3 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks2 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties3.Append(shapeLocks2);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties5 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape1 = new PlaceholderShape() { Type = PlaceholderValues.CenteredTitle };

            applicationNonVisualDrawingProperties5.Append(placeholderShape1);

            nonVisualShapeProperties3.Append(nonVisualDrawingProperties5);
            nonVisualShapeProperties3.Append(nonVisualShapeDrawingProperties3);
            nonVisualShapeProperties3.Append(applicationNonVisualDrawingProperties5);

            ShapeProperties shapeProperties3 = new ShapeProperties();

            A.Transform2D transform2D3 = new A.Transform2D();
            A.Offset offset5 = new A.Offset() { X = 685800L, Y = 2130425L };
            A.Extents extents5 = new A.Extents() { Cx = 7772400L, Cy = 1470025L };

            transform2D3.Append(offset5);
            transform2D3.Append(extents5);

            shapeProperties3.Append(transform2D3);

            TextBody textBody3 = new TextBody();
            A.BodyProperties bodyProperties3 = new A.BodyProperties();
            A.ListStyle listStyle3 = new A.ListStyle();

            A.Paragraph paragraph3 = new A.Paragraph();

            A.Run run3 = new A.Run();

            A.RunProperties runProperties3 = new A.RunProperties() { Language = "en-US" };
            runProperties3.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text3 = new A.Text();
            text3.Text = "Click to edit Master title style";

            run3.Append(runProperties3);
            run3.Append(text3);
            A.EndParagraphRunProperties endParagraphRunProperties3 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph3.Append(run3);
            paragraph3.Append(endParagraphRunProperties3);

            textBody3.Append(bodyProperties3);
            textBody3.Append(listStyle3);
            textBody3.Append(paragraph3);

            shape3.Append(nonVisualShapeProperties3);
            shape3.Append(shapeProperties3);
            shape3.Append(textBody3);

            Shape shape4 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties4 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties6 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Subtitle 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties4 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks3 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties4.Append(shapeLocks3);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties6 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape2 = new PlaceholderShape() { Type = PlaceholderValues.SubTitle, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties6.Append(placeholderShape2);

            nonVisualShapeProperties4.Append(nonVisualDrawingProperties6);
            nonVisualShapeProperties4.Append(nonVisualShapeDrawingProperties4);
            nonVisualShapeProperties4.Append(applicationNonVisualDrawingProperties6);

            ShapeProperties shapeProperties4 = new ShapeProperties();

            A.Transform2D transform2D4 = new A.Transform2D();
            A.Offset offset6 = new A.Offset() { X = 1371600L, Y = 3886200L };
            A.Extents extents6 = new A.Extents() { Cx = 6400800L, Cy = 1752600L };

            transform2D4.Append(offset6);
            transform2D4.Append(extents6);

            shapeProperties4.Append(transform2D4);

            TextBody textBody4 = new TextBody();
            A.BodyProperties bodyProperties4 = new A.BodyProperties();

            A.ListStyle listStyle4 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties3 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet2 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties12 = new A.DefaultRunProperties();

            A.SolidFill solidFill11 = new A.SolidFill();

            A.SchemeColor schemeColor11 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint1 = new A.Tint() { Val = 75000 };

            schemeColor11.Append(tint1);

            solidFill11.Append(schemeColor11);

            defaultRunProperties12.Append(solidFill11);

            level1ParagraphProperties3.Append(noBullet2);
            level1ParagraphProperties3.Append(defaultRunProperties12);

            A.Level2ParagraphProperties level2ParagraphProperties2 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet3 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties13 = new A.DefaultRunProperties();

            A.SolidFill solidFill12 = new A.SolidFill();

            A.SchemeColor schemeColor12 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint2 = new A.Tint() { Val = 75000 };

            schemeColor12.Append(tint2);

            solidFill12.Append(schemeColor12);

            defaultRunProperties13.Append(solidFill12);

            level2ParagraphProperties2.Append(noBullet3);
            level2ParagraphProperties2.Append(defaultRunProperties13);

            A.Level3ParagraphProperties level3ParagraphProperties2 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet4 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties14 = new A.DefaultRunProperties();

            A.SolidFill solidFill13 = new A.SolidFill();

            A.SchemeColor schemeColor13 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint3 = new A.Tint() { Val = 75000 };

            schemeColor13.Append(tint3);

            solidFill13.Append(schemeColor13);

            defaultRunProperties14.Append(solidFill13);

            level3ParagraphProperties2.Append(noBullet4);
            level3ParagraphProperties2.Append(defaultRunProperties14);

            A.Level4ParagraphProperties level4ParagraphProperties2 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet5 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties15 = new A.DefaultRunProperties();

            A.SolidFill solidFill14 = new A.SolidFill();

            A.SchemeColor schemeColor14 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint4 = new A.Tint() { Val = 75000 };

            schemeColor14.Append(tint4);

            solidFill14.Append(schemeColor14);

            defaultRunProperties15.Append(solidFill14);

            level4ParagraphProperties2.Append(noBullet5);
            level4ParagraphProperties2.Append(defaultRunProperties15);

            A.Level5ParagraphProperties level5ParagraphProperties2 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet6 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties16 = new A.DefaultRunProperties();

            A.SolidFill solidFill15 = new A.SolidFill();

            A.SchemeColor schemeColor15 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint5 = new A.Tint() { Val = 75000 };

            schemeColor15.Append(tint5);

            solidFill15.Append(schemeColor15);

            defaultRunProperties16.Append(solidFill15);

            level5ParagraphProperties2.Append(noBullet6);
            level5ParagraphProperties2.Append(defaultRunProperties16);

            A.Level6ParagraphProperties level6ParagraphProperties2 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet7 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties17 = new A.DefaultRunProperties();

            A.SolidFill solidFill16 = new A.SolidFill();

            A.SchemeColor schemeColor16 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint6 = new A.Tint() { Val = 75000 };

            schemeColor16.Append(tint6);

            solidFill16.Append(schemeColor16);

            defaultRunProperties17.Append(solidFill16);

            level6ParagraphProperties2.Append(noBullet7);
            level6ParagraphProperties2.Append(defaultRunProperties17);

            A.Level7ParagraphProperties level7ParagraphProperties2 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet8 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties18 = new A.DefaultRunProperties();

            A.SolidFill solidFill17 = new A.SolidFill();

            A.SchemeColor schemeColor17 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint7 = new A.Tint() { Val = 75000 };

            schemeColor17.Append(tint7);

            solidFill17.Append(schemeColor17);

            defaultRunProperties18.Append(solidFill17);

            level7ParagraphProperties2.Append(noBullet8);
            level7ParagraphProperties2.Append(defaultRunProperties18);

            A.Level8ParagraphProperties level8ParagraphProperties2 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet9 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties19 = new A.DefaultRunProperties();

            A.SolidFill solidFill18 = new A.SolidFill();

            A.SchemeColor schemeColor18 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint8 = new A.Tint() { Val = 75000 };

            schemeColor18.Append(tint8);

            solidFill18.Append(schemeColor18);

            defaultRunProperties19.Append(solidFill18);

            level8ParagraphProperties2.Append(noBullet9);
            level8ParagraphProperties2.Append(defaultRunProperties19);

            A.Level9ParagraphProperties level9ParagraphProperties2 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet10 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties20 = new A.DefaultRunProperties();

            A.SolidFill solidFill19 = new A.SolidFill();

            A.SchemeColor schemeColor19 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint9 = new A.Tint() { Val = 75000 };

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

            A.Paragraph paragraph4 = new A.Paragraph();

            A.Run run4 = new A.Run();

            A.RunProperties runProperties4 = new A.RunProperties() { Language = "en-US" };
            runProperties4.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text4 = new A.Text();
            text4.Text = "Click to edit Master subtitle style";

            run4.Append(runProperties4);
            run4.Append(text4);
            A.EndParagraphRunProperties endParagraphRunProperties4 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph4.Append(run4);
            paragraph4.Append(endParagraphRunProperties4);

            textBody4.Append(bodyProperties4);
            textBody4.Append(listStyle4);
            textBody4.Append(paragraph4);

            shape4.Append(nonVisualShapeProperties4);
            shape4.Append(shapeProperties4);
            shape4.Append(textBody4);

            Shape shape5 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties5 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties7 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Date Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties5 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks4 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties5.Append(shapeLocks4);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties7 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape3 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties7.Append(placeholderShape3);

            nonVisualShapeProperties5.Append(nonVisualDrawingProperties7);
            nonVisualShapeProperties5.Append(nonVisualShapeDrawingProperties5);
            nonVisualShapeProperties5.Append(applicationNonVisualDrawingProperties7);
            ShapeProperties shapeProperties5 = new ShapeProperties();

            TextBody textBody5 = new TextBody();
            A.BodyProperties bodyProperties5 = new A.BodyProperties();
            A.ListStyle listStyle5 = new A.ListStyle();

            A.Paragraph paragraph5 = new A.Paragraph();

            A.Field field1 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties5 = new A.RunProperties() { Language = "en-US" };
            runProperties5.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties2 = new A.ParagraphProperties();
            A.Text text5 = new A.Text();
            text5.Text = "29/11/13";

            field1.Append(runProperties5);
            field1.Append(paragraphProperties2);
            field1.Append(text5);
            A.EndParagraphRunProperties endParagraphRunProperties5 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph5.Append(field1);
            paragraph5.Append(endParagraphRunProperties5);

            textBody5.Append(bodyProperties5);
            textBody5.Append(listStyle5);
            textBody5.Append(paragraph5);

            shape5.Append(nonVisualShapeProperties5);
            shape5.Append(shapeProperties5);
            shape5.Append(textBody5);

            Shape shape6 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties6 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties8 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Footer Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties6 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks5 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties6.Append(shapeLocks5);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties8 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape4 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties8.Append(placeholderShape4);

            nonVisualShapeProperties6.Append(nonVisualDrawingProperties8);
            nonVisualShapeProperties6.Append(nonVisualShapeDrawingProperties6);
            nonVisualShapeProperties6.Append(applicationNonVisualDrawingProperties8);
            ShapeProperties shapeProperties6 = new ShapeProperties();

            TextBody textBody6 = new TextBody();
            A.BodyProperties bodyProperties6 = new A.BodyProperties();
            A.ListStyle listStyle6 = new A.ListStyle();

            A.Paragraph paragraph6 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties6 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph6.Append(endParagraphRunProperties6);

            textBody6.Append(bodyProperties6);
            textBody6.Append(listStyle6);
            textBody6.Append(paragraph6);

            shape6.Append(nonVisualShapeProperties6);
            shape6.Append(shapeProperties6);
            shape6.Append(textBody6);

            Shape shape7 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties7 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties9 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Slide Number Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties7 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks6 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties7.Append(shapeLocks6);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties9 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape5 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties9.Append(placeholderShape5);

            nonVisualShapeProperties7.Append(nonVisualDrawingProperties9);
            nonVisualShapeProperties7.Append(nonVisualShapeDrawingProperties7);
            nonVisualShapeProperties7.Append(applicationNonVisualDrawingProperties9);
            ShapeProperties shapeProperties7 = new ShapeProperties();

            TextBody textBody7 = new TextBody();
            A.BodyProperties bodyProperties7 = new A.BodyProperties();
            A.ListStyle listStyle7 = new A.ListStyle();

            A.Paragraph paragraph7 = new A.Paragraph();

            A.Field field2 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties6 = new A.RunProperties() { Language = "en-US" };
            runProperties6.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties3 = new A.ParagraphProperties();
            A.Text text6 = new A.Text();
            text6.Text = "‹#›";

            field2.Append(runProperties6);
            field2.Append(paragraphProperties3);
            field2.Append(text6);
            A.EndParagraphRunProperties endParagraphRunProperties7 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph7.Append(field2);
            paragraph7.Append(endParagraphRunProperties7);

            textBody7.Append(bodyProperties7);
            textBody7.Append(listStyle7);
            textBody7.Append(paragraph7);

            shape7.Append(nonVisualShapeProperties7);
            shape7.Append(shapeProperties7);
            shape7.Append(textBody7);

            Shape shape8 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties8 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties10 = new NonVisualDrawingProperties() { Id = (UInt32Value)9U, Name = "Text Placeholder 7" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties8 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks7 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties8.Append(shapeLocks7);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties10 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape6 = new PlaceholderShape() { Type = PlaceholderValues.Body, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)13U };

            applicationNonVisualDrawingProperties10.Append(placeholderShape6);

            nonVisualShapeProperties8.Append(nonVisualDrawingProperties10);
            nonVisualShapeProperties8.Append(nonVisualShapeDrawingProperties8);
            nonVisualShapeProperties8.Append(applicationNonVisualDrawingProperties10);

            ShapeProperties shapeProperties8 = new ShapeProperties();

            A.Transform2D transform2D5 = new A.Transform2D();
            A.Offset offset7 = new A.Offset() { X = 1828800L, Y = 838200L };
            A.Extents extents7 = new A.Extents() { Cx = 2895600L, Cy = 609600L };

            transform2D5.Append(offset7);
            transform2D5.Append(extents7);

            shapeProperties8.Append(transform2D5);

            TextBody textBody8 = new TextBody();
            A.BodyProperties bodyProperties8 = new A.BodyProperties();

            A.ListStyle listStyle8 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties4 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0 };
            A.NoBullet noBullet11 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties21 = new A.DefaultRunProperties();

            level1ParagraphProperties4.Append(noBullet11);
            level1ParagraphProperties4.Append(defaultRunProperties21);

            listStyle8.Append(level1ParagraphProperties4);

            A.Paragraph paragraph8 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties4 = new A.ParagraphProperties() { Level = 0 };
            A.EndParagraphRunProperties endParagraphRunProperties8 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

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

            CommonSlideDataExtensionList commonSlideDataExtensionList2 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension2 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId2 = new P14.CreationId() { Val = (UInt32Value)3875837434U };
            creationId2.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension2.Append(creationId2);

            commonSlideDataExtensionList2.Append(commonSlideDataExtension2);

            commonSlideData2.Append(shapeTree2);
            commonSlideData2.Append(commonSlideDataExtensionList2);

            ColorMapOverride colorMapOverride2 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping2 = new A.MasterColorMapping();

            colorMapOverride2.Append(masterColorMapping2);

            slideLayout1.Append(commonSlideData2);
            slideLayout1.Append(colorMapOverride2);

            slideLayoutPart1.SlideLayout = slideLayout1;
        }

        // Generates content of slideMasterPart1.
        private void GenerateSlideMasterPart1Content(SlideMasterPart slideMasterPart1)
        {
            SlideMaster slideMaster1 = new SlideMaster();
            slideMaster1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideMaster1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideMaster1.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData3 = new CommonSlideData();

            Background background1 = new Background();

            BackgroundStyleReference backgroundStyleReference1 = new BackgroundStyleReference() { Index = (UInt32Value)1003U };
            A.SchemeColor schemeColor20 = new A.SchemeColor() { Val = A.SchemeColorValues.Background2 };

            backgroundStyleReference1.Append(schemeColor20);

            background1.Append(backgroundStyleReference1);

            ShapeTree shapeTree3 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties3 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties11 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties3 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties11 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties3.Append(nonVisualDrawingProperties11);
            nonVisualGroupShapeProperties3.Append(nonVisualGroupShapeDrawingProperties3);
            nonVisualGroupShapeProperties3.Append(applicationNonVisualDrawingProperties11);

            GroupShapeProperties groupShapeProperties3 = new GroupShapeProperties();

            A.TransformGroup transformGroup3 = new A.TransformGroup();
            A.Offset offset8 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents8 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset3 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents3 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup3.Append(offset8);
            transformGroup3.Append(extents8);
            transformGroup3.Append(childOffset3);
            transformGroup3.Append(childExtents3);

            groupShapeProperties3.Append(transformGroup3);

            Shape shape9 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties9 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties12 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title Placeholder 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties9 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks8 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties9.Append(shapeLocks8);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties12 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape7 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties12.Append(placeholderShape7);

            nonVisualShapeProperties9.Append(nonVisualDrawingProperties12);
            nonVisualShapeProperties9.Append(nonVisualShapeDrawingProperties9);
            nonVisualShapeProperties9.Append(applicationNonVisualDrawingProperties12);

            ShapeProperties shapeProperties9 = new ShapeProperties();

            A.Transform2D transform2D6 = new A.Transform2D();
            A.Offset offset9 = new A.Offset() { X = 549275L, Y = 107576L };
            A.Extents extents9 = new A.Extents() { Cx = 8042276L, Cy = 1336956L };

            transform2D6.Append(offset9);
            transform2D6.Append(extents9);

            A.PresetGeometry presetGeometry3 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList3 = new A.AdjustValueList();

            presetGeometry3.Append(adjustValueList3);

            shapeProperties9.Append(transform2D6);
            shapeProperties9.Append(presetGeometry3);

            TextBody textBody9 = new TextBody();

            A.BodyProperties bodyProperties9 = new A.BodyProperties() { Vertical = A.TextVerticalValues.Horizontal, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, RightToLeftColumns = false, Anchor = A.TextAnchoringTypeValues.Bottom, AnchorCenter = false };
            A.NoAutoFit noAutoFit2 = new A.NoAutoFit();

            bodyProperties9.Append(noAutoFit2);
            A.ListStyle listStyle9 = new A.ListStyle();

            A.Paragraph paragraph9 = new A.Paragraph();

            A.Run run5 = new A.Run();

            A.RunProperties runProperties7 = new A.RunProperties() { Language = "en-US" };
            runProperties7.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text7 = new A.Text();
            text7.Text = "Click to edit Master title style";

            run5.Append(runProperties7);
            run5.Append(text7);
            A.EndParagraphRunProperties endParagraphRunProperties9 = new A.EndParagraphRunProperties();

            paragraph9.Append(run5);
            paragraph9.Append(endParagraphRunProperties9);

            textBody9.Append(bodyProperties9);
            textBody9.Append(listStyle9);
            textBody9.Append(paragraph9);

            shape9.Append(nonVisualShapeProperties9);
            shape9.Append(shapeProperties9);
            shape9.Append(textBody9);

            Shape shape10 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties10 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties13 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Text Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties10 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks9 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties10.Append(shapeLocks9);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties13 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape8 = new PlaceholderShape() { Type = PlaceholderValues.Body, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties13.Append(placeholderShape8);

            nonVisualShapeProperties10.Append(nonVisualDrawingProperties13);
            nonVisualShapeProperties10.Append(nonVisualShapeDrawingProperties10);
            nonVisualShapeProperties10.Append(applicationNonVisualDrawingProperties13);

            ShapeProperties shapeProperties10 = new ShapeProperties();

            A.Transform2D transform2D7 = new A.Transform2D();
            A.Offset offset10 = new A.Offset() { X = 549275L, Y = 1600201L };
            A.Extents extents10 = new A.Extents() { Cx = 8042276L, Cy = 4343400L };

            transform2D7.Append(offset10);
            transform2D7.Append(extents10);

            A.PresetGeometry presetGeometry4 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList4 = new A.AdjustValueList();

            presetGeometry4.Append(adjustValueList4);

            shapeProperties10.Append(transform2D7);
            shapeProperties10.Append(presetGeometry4);

            TextBody textBody10 = new TextBody();

            A.BodyProperties bodyProperties10 = new A.BodyProperties() { Vertical = A.TextVerticalValues.Horizontal, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, RightToLeftColumns = false };
            A.NormalAutoFit normalAutoFit1 = new A.NormalAutoFit();

            bodyProperties10.Append(normalAutoFit1);
            A.ListStyle listStyle10 = new A.ListStyle();

            A.Paragraph paragraph10 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties5 = new A.ParagraphProperties() { Level = 0 };

            A.Run run6 = new A.Run();

            A.RunProperties runProperties8 = new A.RunProperties() { Language = "en-US" };
            runProperties8.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text8 = new A.Text();
            text8.Text = "Click to edit Master text styles";

            run6.Append(runProperties8);
            run6.Append(text8);

            paragraph10.Append(paragraphProperties5);
            paragraph10.Append(run6);

            A.Paragraph paragraph11 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties6 = new A.ParagraphProperties() { Level = 1 };

            A.Run run7 = new A.Run();

            A.RunProperties runProperties9 = new A.RunProperties() { Language = "en-US" };
            runProperties9.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text9 = new A.Text();
            text9.Text = "Second level";

            run7.Append(runProperties9);
            run7.Append(text9);

            paragraph11.Append(paragraphProperties6);
            paragraph11.Append(run7);

            A.Paragraph paragraph12 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties7 = new A.ParagraphProperties() { Level = 2 };

            A.Run run8 = new A.Run();

            A.RunProperties runProperties10 = new A.RunProperties() { Language = "en-US" };
            runProperties10.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text10 = new A.Text();
            text10.Text = "Third level";

            run8.Append(runProperties10);
            run8.Append(text10);

            paragraph12.Append(paragraphProperties7);
            paragraph12.Append(run8);

            A.Paragraph paragraph13 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties8 = new A.ParagraphProperties() { Level = 3 };

            A.Run run9 = new A.Run();

            A.RunProperties runProperties11 = new A.RunProperties() { Language = "en-US" };
            runProperties11.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text11 = new A.Text();
            text11.Text = "Fourth level";

            run9.Append(runProperties11);
            run9.Append(text11);

            paragraph13.Append(paragraphProperties8);
            paragraph13.Append(run9);

            A.Paragraph paragraph14 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties9 = new A.ParagraphProperties() { Level = 4 };

            A.Run run10 = new A.Run();

            A.RunProperties runProperties12 = new A.RunProperties() { Language = "en-US" };
            runProperties12.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text12 = new A.Text();
            text12.Text = "Fifth level";

            run10.Append(runProperties12);
            run10.Append(text12);
            A.EndParagraphRunProperties endParagraphRunProperties10 = new A.EndParagraphRunProperties() { Dirty = false };

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

            Shape shape11 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties11 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties14 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Date Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties11 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks10 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties11.Append(shapeLocks10);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties14 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape9 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)2U };

            applicationNonVisualDrawingProperties14.Append(placeholderShape9);

            nonVisualShapeProperties11.Append(nonVisualDrawingProperties14);
            nonVisualShapeProperties11.Append(nonVisualShapeDrawingProperties11);
            nonVisualShapeProperties11.Append(applicationNonVisualDrawingProperties14);

            ShapeProperties shapeProperties11 = new ShapeProperties();

            A.Transform2D transform2D8 = new A.Transform2D();
            A.Offset offset11 = new A.Offset() { X = 5629835L, Y = 6275668L };
            A.Extents extents11 = new A.Extents() { Cx = 2133600L, Cy = 365125L };

            transform2D8.Append(offset11);
            transform2D8.Append(extents11);

            A.PresetGeometry presetGeometry5 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList5 = new A.AdjustValueList();

            presetGeometry5.Append(adjustValueList5);

            shapeProperties11.Append(transform2D8);
            shapeProperties11.Append(presetGeometry5);

            TextBody textBody11 = new TextBody();
            A.BodyProperties bodyProperties11 = new A.BodyProperties() { Vertical = A.TextVerticalValues.Horizontal, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, RightToLeftColumns = false, Anchor = A.TextAnchoringTypeValues.Center };

            A.ListStyle listStyle11 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties5 = new A.Level1ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Right };

            A.DefaultRunProperties defaultRunProperties22 = new A.DefaultRunProperties() { FontSize = 1200 };

            A.SolidFill solidFill20 = new A.SolidFill();
            A.SchemeColor schemeColor21 = new A.SchemeColor() { Val = A.SchemeColorValues.Background1 };

            solidFill20.Append(schemeColor21);

            defaultRunProperties22.Append(solidFill20);

            level1ParagraphProperties5.Append(defaultRunProperties22);

            listStyle11.Append(level1ParagraphProperties5);

            A.Paragraph paragraph15 = new A.Paragraph();

            A.Field field3 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties13 = new A.RunProperties() { Language = "en-US" };
            runProperties13.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties10 = new A.ParagraphProperties();
            A.Text text13 = new A.Text();
            text13.Text = "29/11/13";

            field3.Append(runProperties13);
            field3.Append(paragraphProperties10);
            field3.Append(text13);
            A.EndParagraphRunProperties endParagraphRunProperties11 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph15.Append(field3);
            paragraph15.Append(endParagraphRunProperties11);

            textBody11.Append(bodyProperties11);
            textBody11.Append(listStyle11);
            textBody11.Append(paragraph15);

            shape11.Append(nonVisualShapeProperties11);
            shape11.Append(shapeProperties11);
            shape11.Append(textBody11);

            Shape shape12 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties12 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties15 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Footer Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties12 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks11 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties12.Append(shapeLocks11);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties15 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape10 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)3U };

            applicationNonVisualDrawingProperties15.Append(placeholderShape10);

            nonVisualShapeProperties12.Append(nonVisualDrawingProperties15);
            nonVisualShapeProperties12.Append(nonVisualShapeDrawingProperties12);
            nonVisualShapeProperties12.Append(applicationNonVisualDrawingProperties15);

            ShapeProperties shapeProperties12 = new ShapeProperties();

            A.Transform2D transform2D9 = new A.Transform2D();
            A.Offset offset12 = new A.Offset() { X = 264458L, Y = 6275668L };
            A.Extents extents12 = new A.Extents() { Cx = 4840941L, Cy = 365125L };

            transform2D9.Append(offset12);
            transform2D9.Append(extents12);

            A.PresetGeometry presetGeometry6 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList6 = new A.AdjustValueList();

            presetGeometry6.Append(adjustValueList6);

            shapeProperties12.Append(transform2D9);
            shapeProperties12.Append(presetGeometry6);

            TextBody textBody12 = new TextBody();
            A.BodyProperties bodyProperties12 = new A.BodyProperties() { Vertical = A.TextVerticalValues.Horizontal, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, RightToLeftColumns = false, Anchor = A.TextAnchoringTypeValues.Center };

            A.ListStyle listStyle12 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties6 = new A.Level1ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Left };

            A.DefaultRunProperties defaultRunProperties23 = new A.DefaultRunProperties() { FontSize = 1200 };

            A.SolidFill solidFill21 = new A.SolidFill();
            A.SchemeColor schemeColor22 = new A.SchemeColor() { Val = A.SchemeColorValues.Background1 };

            solidFill21.Append(schemeColor22);

            defaultRunProperties23.Append(solidFill21);

            level1ParagraphProperties6.Append(defaultRunProperties23);

            listStyle12.Append(level1ParagraphProperties6);

            A.Paragraph paragraph16 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties12 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph16.Append(endParagraphRunProperties12);

            textBody12.Append(bodyProperties12);
            textBody12.Append(listStyle12);
            textBody12.Append(paragraph16);

            shape12.Append(nonVisualShapeProperties12);
            shape12.Append(shapeProperties12);
            shape12.Append(textBody12);

            Shape shape13 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties13 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties16 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Slide Number Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties13 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks12 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties13.Append(shapeLocks12);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties16 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape11 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)4U };

            applicationNonVisualDrawingProperties16.Append(placeholderShape11);

            nonVisualShapeProperties13.Append(nonVisualDrawingProperties16);
            nonVisualShapeProperties13.Append(nonVisualShapeDrawingProperties13);
            nonVisualShapeProperties13.Append(applicationNonVisualDrawingProperties16);

            ShapeProperties shapeProperties13 = new ShapeProperties();

            A.Transform2D transform2D10 = new A.Transform2D();
            A.Offset offset13 = new A.Offset() { X = 7897906L, Y = 6275668L };
            A.Extents extents13 = new A.Extents() { Cx = 990600L, Cy = 365125L };

            transform2D10.Append(offset13);
            transform2D10.Append(extents13);

            A.PresetGeometry presetGeometry7 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList7 = new A.AdjustValueList();

            presetGeometry7.Append(adjustValueList7);

            shapeProperties13.Append(transform2D10);
            shapeProperties13.Append(presetGeometry7);

            TextBody textBody13 = new TextBody();
            A.BodyProperties bodyProperties13 = new A.BodyProperties() { Vertical = A.TextVerticalValues.Horizontal, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, RightToLeftColumns = false, Anchor = A.TextAnchoringTypeValues.Center };

            A.ListStyle listStyle13 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties7 = new A.Level1ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Right };

            A.DefaultRunProperties defaultRunProperties24 = new A.DefaultRunProperties() { FontSize = 3600 };

            A.SolidFill solidFill22 = new A.SolidFill();
            A.SchemeColor schemeColor23 = new A.SchemeColor() { Val = A.SchemeColorValues.Background1 };

            solidFill22.Append(schemeColor23);

            defaultRunProperties24.Append(solidFill22);

            level1ParagraphProperties7.Append(defaultRunProperties24);

            listStyle13.Append(level1ParagraphProperties7);

            A.Paragraph paragraph17 = new A.Paragraph();

            A.Field field4 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties14 = new A.RunProperties() { Language = "en-US" };
            runProperties14.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties11 = new A.ParagraphProperties();
            A.Text text14 = new A.Text();
            text14.Text = "‹#›";

            field4.Append(runProperties14);
            field4.Append(paragraphProperties11);
            field4.Append(text14);
            A.EndParagraphRunProperties endParagraphRunProperties13 = new A.EndParagraphRunProperties() { Language = "en-US" };

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
            ColorMap colorMap1 = new ColorMap() { Background1 = A.ColorSchemeIndexValues.Light1, Text1 = A.ColorSchemeIndexValues.Dark1, Background2 = A.ColorSchemeIndexValues.Light2, Text2 = A.ColorSchemeIndexValues.Dark2, Accent1 = A.ColorSchemeIndexValues.Accent1, Accent2 = A.ColorSchemeIndexValues.Accent2, Accent3 = A.ColorSchemeIndexValues.Accent3, Accent4 = A.ColorSchemeIndexValues.Accent4, Accent5 = A.ColorSchemeIndexValues.Accent5, Accent6 = A.ColorSchemeIndexValues.Accent6, Hyperlink = A.ColorSchemeIndexValues.Hyperlink, FollowedHyperlink = A.ColorSchemeIndexValues.FollowedHyperlink };

            SlideLayoutIdList slideLayoutIdList1 = new SlideLayoutIdList();
            SlideLayoutId slideLayoutId1 = new SlideLayoutId() { Id = (UInt32Value)2147484278U, RelationshipId = "rId1" };
            SlideLayoutId slideLayoutId2 = new SlideLayoutId() { Id = (UInt32Value)2147484279U, RelationshipId = "rId2" };
            SlideLayoutId slideLayoutId3 = new SlideLayoutId() { Id = (UInt32Value)2147484280U, RelationshipId = "rId3" };
            SlideLayoutId slideLayoutId4 = new SlideLayoutId() { Id = (UInt32Value)2147484281U, RelationshipId = "rId4" };
            SlideLayoutId slideLayoutId5 = new SlideLayoutId() { Id = (UInt32Value)2147484282U, RelationshipId = "rId5" };
            SlideLayoutId slideLayoutId6 = new SlideLayoutId() { Id = (UInt32Value)2147484283U, RelationshipId = "rId6" };
            SlideLayoutId slideLayoutId7 = new SlideLayoutId() { Id = (UInt32Value)2147484284U, RelationshipId = "rId7" };
            SlideLayoutId slideLayoutId8 = new SlideLayoutId() { Id = (UInt32Value)2147484285U, RelationshipId = "rId8" };
            SlideLayoutId slideLayoutId9 = new SlideLayoutId() { Id = (UInt32Value)2147484286U, RelationshipId = "rId9" };
            SlideLayoutId slideLayoutId10 = new SlideLayoutId() { Id = (UInt32Value)2147484287U, RelationshipId = "rId10" };
            SlideLayoutId slideLayoutId11 = new SlideLayoutId() { Id = (UInt32Value)2147484288U, RelationshipId = "rId11" };
            SlideLayoutId slideLayoutId12 = new SlideLayoutId() { Id = (UInt32Value)2147484289U, RelationshipId = "rId12" };
            SlideLayoutId slideLayoutId13 = new SlideLayoutId() { Id = (UInt32Value)2147484290U, RelationshipId = "rId13" };

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

            TextStyles textStyles1 = new TextStyles();

            TitleStyle titleStyle1 = new TitleStyle();

            A.Level1ParagraphProperties level1ParagraphProperties8 = new A.Level1ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Center, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore2 = new A.SpaceBefore();
            A.SpacingPercent spacingPercent2 = new A.SpacingPercent() { Val = 0 };

            spaceBefore2.Append(spacingPercent2);
            A.NoBullet noBullet12 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties25 = new A.DefaultRunProperties() { FontSize = 4600, Kerning = 1200 };

            A.SolidFill solidFill23 = new A.SolidFill();
            A.SchemeColor schemeColor24 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            solidFill23.Append(schemeColor24);
            A.LatinFont latinFont11 = new A.LatinFont() { Typeface = "+mj-lt" };
            A.EastAsianFont eastAsianFont11 = new A.EastAsianFont() { Typeface = "+mj-ea" };
            A.ComplexScriptFont complexScriptFont11 = new A.ComplexScriptFont() { Typeface = "+mj-cs" };

            defaultRunProperties25.Append(solidFill23);
            defaultRunProperties25.Append(latinFont11);
            defaultRunProperties25.Append(eastAsianFont11);
            defaultRunProperties25.Append(complexScriptFont11);

            level1ParagraphProperties8.Append(spaceBefore2);
            level1ParagraphProperties8.Append(noBullet12);
            level1ParagraphProperties8.Append(defaultRunProperties25);

            titleStyle1.Append(level1ParagraphProperties8);

            BodyStyle bodyStyle1 = new BodyStyle();

            A.Level1ParagraphProperties level1ParagraphProperties9 = new A.Level1ParagraphProperties() { LeftMargin = 349250, Indent = -349250, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore3 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints1 = new A.SpacingPoints() { Val = 2000 };

            spaceBefore3.Append(spacingPoints1);

            A.BulletColor bulletColor1 = new A.BulletColor();

            A.SchemeColor schemeColor25 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };
            A.LuminanceModulation luminanceModulation1 = new A.LuminanceModulation() { Val = 60000 };
            A.LuminanceOffset luminanceOffset1 = new A.LuminanceOffset() { Val = 40000 };

            schemeColor25.Append(luminanceModulation1);
            schemeColor25.Append(luminanceOffset1);

            bulletColor1.Append(schemeColor25);
            A.BulletSizePercentage bulletSizePercentage1 = new A.BulletSizePercentage() { Val = 110000 };
            A.BulletFont bulletFont1 = new A.BulletFont() { Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2 };
            A.CharacterBullet characterBullet1 = new A.CharacterBullet() { Char = "" };

            A.DefaultRunProperties defaultRunProperties26 = new A.DefaultRunProperties() { FontSize = 2400, Kerning = 1200 };

            A.SolidFill solidFill24 = new A.SolidFill();

            A.SchemeColor schemeColor26 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.LuminanceModulation luminanceModulation2 = new A.LuminanceModulation() { Val = 65000 };
            A.LuminanceOffset luminanceOffset2 = new A.LuminanceOffset() { Val = 35000 };

            schemeColor26.Append(luminanceModulation2);
            schemeColor26.Append(luminanceOffset2);

            solidFill24.Append(schemeColor26);
            A.LatinFont latinFont12 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont12 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont12 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

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

            A.Level2ParagraphProperties level2ParagraphProperties3 = new A.Level2ParagraphProperties() { LeftMargin = 685800, Indent = -336550, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore4 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints2 = new A.SpacingPoints() { Val = 600 };

            spaceBefore4.Append(spacingPoints2);

            A.BulletColor bulletColor2 = new A.BulletColor();

            A.SchemeColor schemeColor27 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };
            A.LuminanceModulation luminanceModulation3 = new A.LuminanceModulation() { Val = 75000 };

            schemeColor27.Append(luminanceModulation3);

            bulletColor2.Append(schemeColor27);
            A.BulletSizePercentage bulletSizePercentage2 = new A.BulletSizePercentage() { Val = 110000 };
            A.BulletFont bulletFont2 = new A.BulletFont() { Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2 };
            A.CharacterBullet characterBullet2 = new A.CharacterBullet() { Char = "" };

            A.DefaultRunProperties defaultRunProperties27 = new A.DefaultRunProperties() { FontSize = 2200, Kerning = 1200 };

            A.SolidFill solidFill25 = new A.SolidFill();

            A.SchemeColor schemeColor28 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.LuminanceModulation luminanceModulation4 = new A.LuminanceModulation() { Val = 65000 };
            A.LuminanceOffset luminanceOffset3 = new A.LuminanceOffset() { Val = 35000 };

            schemeColor28.Append(luminanceModulation4);
            schemeColor28.Append(luminanceOffset3);

            solidFill25.Append(schemeColor28);
            A.LatinFont latinFont13 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont13 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont13 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

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

            A.Level3ParagraphProperties level3ParagraphProperties3 = new A.Level3ParagraphProperties() { LeftMargin = 968375, Indent = -282575, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore5 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints3 = new A.SpacingPoints() { Val = 600 };

            spaceBefore5.Append(spacingPoints3);

            A.BulletColor bulletColor3 = new A.BulletColor();

            A.SchemeColor schemeColor29 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };
            A.LuminanceModulation luminanceModulation5 = new A.LuminanceModulation() { Val = 60000 };
            A.LuminanceOffset luminanceOffset4 = new A.LuminanceOffset() { Val = 40000 };

            schemeColor29.Append(luminanceModulation5);
            schemeColor29.Append(luminanceOffset4);

            bulletColor3.Append(schemeColor29);
            A.BulletSizePercentage bulletSizePercentage3 = new A.BulletSizePercentage() { Val = 110000 };
            A.BulletFont bulletFont3 = new A.BulletFont() { Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2 };
            A.CharacterBullet characterBullet3 = new A.CharacterBullet() { Char = "" };

            A.DefaultRunProperties defaultRunProperties28 = new A.DefaultRunProperties() { FontSize = 2000, Kerning = 1200 };

            A.SolidFill solidFill26 = new A.SolidFill();

            A.SchemeColor schemeColor30 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.LuminanceModulation luminanceModulation6 = new A.LuminanceModulation() { Val = 65000 };
            A.LuminanceOffset luminanceOffset5 = new A.LuminanceOffset() { Val = 35000 };

            schemeColor30.Append(luminanceModulation6);
            schemeColor30.Append(luminanceOffset5);

            solidFill26.Append(schemeColor30);
            A.LatinFont latinFont14 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont14 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont14 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

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

            A.Level4ParagraphProperties level4ParagraphProperties3 = new A.Level4ParagraphProperties() { LeftMargin = 1263650, Indent = -295275, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore6 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints4 = new A.SpacingPoints() { Val = 600 };

            spaceBefore6.Append(spacingPoints4);

            A.BulletColor bulletColor4 = new A.BulletColor();

            A.SchemeColor schemeColor31 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };
            A.LuminanceModulation luminanceModulation7 = new A.LuminanceModulation() { Val = 75000 };

            schemeColor31.Append(luminanceModulation7);

            bulletColor4.Append(schemeColor31);
            A.BulletSizePercentage bulletSizePercentage4 = new A.BulletSizePercentage() { Val = 110000 };
            A.BulletFont bulletFont4 = new A.BulletFont() { Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2 };
            A.CharacterBullet characterBullet4 = new A.CharacterBullet() { Char = "" };

            A.DefaultRunProperties defaultRunProperties29 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill27 = new A.SolidFill();

            A.SchemeColor schemeColor32 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.LuminanceModulation luminanceModulation8 = new A.LuminanceModulation() { Val = 65000 };
            A.LuminanceOffset luminanceOffset6 = new A.LuminanceOffset() { Val = 35000 };

            schemeColor32.Append(luminanceModulation8);
            schemeColor32.Append(luminanceOffset6);

            solidFill27.Append(schemeColor32);
            A.LatinFont latinFont15 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont15 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont15 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

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

            A.Level5ParagraphProperties level5ParagraphProperties3 = new A.Level5ParagraphProperties() { LeftMargin = 1546225, Indent = -282575, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore7 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints5 = new A.SpacingPoints() { Val = 600 };

            spaceBefore7.Append(spacingPoints5);

            A.BulletColor bulletColor5 = new A.BulletColor();

            A.SchemeColor schemeColor33 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };
            A.LuminanceModulation luminanceModulation9 = new A.LuminanceModulation() { Val = 60000 };
            A.LuminanceOffset luminanceOffset7 = new A.LuminanceOffset() { Val = 40000 };

            schemeColor33.Append(luminanceModulation9);
            schemeColor33.Append(luminanceOffset7);

            bulletColor5.Append(schemeColor33);
            A.BulletSizePercentage bulletSizePercentage5 = new A.BulletSizePercentage() { Val = 110000 };
            A.BulletFont bulletFont5 = new A.BulletFont() { Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2 };
            A.CharacterBullet characterBullet5 = new A.CharacterBullet() { Char = "" };

            A.DefaultRunProperties defaultRunProperties30 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill28 = new A.SolidFill();

            A.SchemeColor schemeColor34 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.LuminanceModulation luminanceModulation10 = new A.LuminanceModulation() { Val = 65000 };
            A.LuminanceOffset luminanceOffset8 = new A.LuminanceOffset() { Val = 35000 };

            schemeColor34.Append(luminanceModulation10);
            schemeColor34.Append(luminanceOffset8);

            solidFill28.Append(schemeColor34);
            A.LatinFont latinFont16 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont16 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont16 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

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

            A.Level6ParagraphProperties level6ParagraphProperties3 = new A.Level6ParagraphProperties() { LeftMargin = 1828800, Indent = -282575, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore8 = new A.SpaceBefore();
            A.SpacingPercent spacingPercent3 = new A.SpacingPercent() { Val = 20000 };

            spaceBefore8.Append(spacingPercent3);

            A.BulletColor bulletColor6 = new A.BulletColor();
            A.SchemeColor schemeColor35 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent2 };

            bulletColor6.Append(schemeColor35);
            A.BulletSizePercentage bulletSizePercentage6 = new A.BulletSizePercentage() { Val = 110000 };
            A.BulletFont bulletFont6 = new A.BulletFont() { Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2 };
            A.CharacterBullet characterBullet6 = new A.CharacterBullet() { Char = "—" };

            A.DefaultRunProperties defaultRunProperties31 = new A.DefaultRunProperties() { Language = "en-US", FontSize = 1800, Kerning = 1200, Dirty = false };
            defaultRunProperties31.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));

            A.SolidFill solidFill29 = new A.SolidFill();

            A.SchemeColor schemeColor36 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.LuminanceModulation luminanceModulation11 = new A.LuminanceModulation() { Val = 65000 };
            A.LuminanceOffset luminanceOffset9 = new A.LuminanceOffset() { Val = 35000 };

            schemeColor36.Append(luminanceModulation11);
            schemeColor36.Append(luminanceOffset9);

            solidFill29.Append(schemeColor36);
            A.LatinFont latinFont17 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont17 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont17 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

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

            A.Level7ParagraphProperties level7ParagraphProperties3 = new A.Level7ParagraphProperties() { LeftMargin = 2117725, Indent = -282575, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore9 = new A.SpaceBefore();
            A.SpacingPercent spacingPercent4 = new A.SpacingPercent() { Val = 20000 };

            spaceBefore9.Append(spacingPercent4);

            A.BulletColor bulletColor7 = new A.BulletColor();

            A.SchemeColor schemeColor37 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };
            A.LuminanceModulation luminanceModulation12 = new A.LuminanceModulation() { Val = 60000 };
            A.LuminanceOffset luminanceOffset10 = new A.LuminanceOffset() { Val = 40000 };

            schemeColor37.Append(luminanceModulation12);
            schemeColor37.Append(luminanceOffset10);

            bulletColor7.Append(schemeColor37);
            A.BulletSizePercentage bulletSizePercentage7 = new A.BulletSizePercentage() { Val = 110000 };
            A.BulletFont bulletFont7 = new A.BulletFont() { Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2 };
            A.CharacterBullet characterBullet7 = new A.CharacterBullet() { Char = "—" };

            A.DefaultRunProperties defaultRunProperties32 = new A.DefaultRunProperties() { Language = "en-US", FontSize = 1800, Kerning = 1200, Dirty = false };
            defaultRunProperties32.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));

            A.SolidFill solidFill30 = new A.SolidFill();

            A.SchemeColor schemeColor38 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.LuminanceModulation luminanceModulation13 = new A.LuminanceModulation() { Val = 65000 };
            A.LuminanceOffset luminanceOffset11 = new A.LuminanceOffset() { Val = 35000 };

            schemeColor38.Append(luminanceModulation13);
            schemeColor38.Append(luminanceOffset11);

            solidFill30.Append(schemeColor38);
            A.LatinFont latinFont18 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont18 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont18 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

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

            A.Level8ParagraphProperties level8ParagraphProperties3 = new A.Level8ParagraphProperties() { LeftMargin = 2398713, Indent = -282575, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore10 = new A.SpaceBefore();
            A.SpacingPercent spacingPercent5 = new A.SpacingPercent() { Val = 20000 };

            spaceBefore10.Append(spacingPercent5);

            A.BulletColor bulletColor8 = new A.BulletColor();
            A.SchemeColor schemeColor39 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent2 };

            bulletColor8.Append(schemeColor39);
            A.BulletSizePercentage bulletSizePercentage8 = new A.BulletSizePercentage() { Val = 110000 };
            A.BulletFont bulletFont8 = new A.BulletFont() { Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2 };
            A.CharacterBullet characterBullet8 = new A.CharacterBullet() { Char = "—" };

            A.DefaultRunProperties defaultRunProperties33 = new A.DefaultRunProperties() { Language = "en-US", FontSize = 1800, Kerning = 1200, Dirty = false };
            defaultRunProperties33.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));

            A.SolidFill solidFill31 = new A.SolidFill();

            A.SchemeColor schemeColor40 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.LuminanceModulation luminanceModulation14 = new A.LuminanceModulation() { Val = 65000 };
            A.LuminanceOffset luminanceOffset12 = new A.LuminanceOffset() { Val = 35000 };

            schemeColor40.Append(luminanceModulation14);
            schemeColor40.Append(luminanceOffset12);

            solidFill31.Append(schemeColor40);
            A.LatinFont latinFont19 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont19 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont19 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

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

            A.Level9ParagraphProperties level9ParagraphProperties3 = new A.Level9ParagraphProperties() { LeftMargin = 2689225, Indent = -282575, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore11 = new A.SpaceBefore();
            A.SpacingPercent spacingPercent6 = new A.SpacingPercent() { Val = 20000 };

            spaceBefore11.Append(spacingPercent6);

            A.BulletColor bulletColor9 = new A.BulletColor();

            A.SchemeColor schemeColor41 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };
            A.LuminanceModulation luminanceModulation15 = new A.LuminanceModulation() { Val = 60000 };
            A.LuminanceOffset luminanceOffset13 = new A.LuminanceOffset() { Val = 40000 };

            schemeColor41.Append(luminanceModulation15);
            schemeColor41.Append(luminanceOffset13);

            bulletColor9.Append(schemeColor41);
            A.BulletSizePercentage bulletSizePercentage9 = new A.BulletSizePercentage() { Val = 110000 };
            A.BulletFont bulletFont9 = new A.BulletFont() { Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2 };
            A.CharacterBullet characterBullet9 = new A.CharacterBullet() { Char = "—" };

            A.DefaultRunProperties defaultRunProperties34 = new A.DefaultRunProperties() { Language = "en-US", FontSize = 1800, Kerning = 1200, Dirty = false };

            A.SolidFill solidFill32 = new A.SolidFill();

            A.SchemeColor schemeColor42 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.LuminanceModulation luminanceModulation16 = new A.LuminanceModulation() { Val = 65000 };
            A.LuminanceOffset luminanceOffset14 = new A.LuminanceOffset() { Val = 35000 };

            schemeColor42.Append(luminanceModulation16);
            schemeColor42.Append(luminanceOffset14);

            solidFill32.Append(schemeColor42);
            A.LatinFont latinFont20 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont20 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont20 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

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

            OtherStyle otherStyle1 = new OtherStyle();

            A.DefaultParagraphProperties defaultParagraphProperties2 = new A.DefaultParagraphProperties();
            A.DefaultRunProperties defaultRunProperties35 = new A.DefaultRunProperties();

            defaultParagraphProperties2.Append(defaultRunProperties35);

            A.Level1ParagraphProperties level1ParagraphProperties10 = new A.Level1ParagraphProperties() { LeftMargin = 0, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties36 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill33 = new A.SolidFill();
            A.SchemeColor schemeColor43 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill33.Append(schemeColor43);
            A.LatinFont latinFont21 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont21 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont21 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties36.Append(solidFill33);
            defaultRunProperties36.Append(latinFont21);
            defaultRunProperties36.Append(eastAsianFont21);
            defaultRunProperties36.Append(complexScriptFont21);

            level1ParagraphProperties10.Append(defaultRunProperties36);

            A.Level2ParagraphProperties level2ParagraphProperties4 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties37 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill34 = new A.SolidFill();
            A.SchemeColor schemeColor44 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill34.Append(schemeColor44);
            A.LatinFont latinFont22 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont22 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont22 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties37.Append(solidFill34);
            defaultRunProperties37.Append(latinFont22);
            defaultRunProperties37.Append(eastAsianFont22);
            defaultRunProperties37.Append(complexScriptFont22);

            level2ParagraphProperties4.Append(defaultRunProperties37);

            A.Level3ParagraphProperties level3ParagraphProperties4 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties38 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill35 = new A.SolidFill();
            A.SchemeColor schemeColor45 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill35.Append(schemeColor45);
            A.LatinFont latinFont23 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont23 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont23 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties38.Append(solidFill35);
            defaultRunProperties38.Append(latinFont23);
            defaultRunProperties38.Append(eastAsianFont23);
            defaultRunProperties38.Append(complexScriptFont23);

            level3ParagraphProperties4.Append(defaultRunProperties38);

            A.Level4ParagraphProperties level4ParagraphProperties4 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties39 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill36 = new A.SolidFill();
            A.SchemeColor schemeColor46 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill36.Append(schemeColor46);
            A.LatinFont latinFont24 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont24 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont24 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties39.Append(solidFill36);
            defaultRunProperties39.Append(latinFont24);
            defaultRunProperties39.Append(eastAsianFont24);
            defaultRunProperties39.Append(complexScriptFont24);

            level4ParagraphProperties4.Append(defaultRunProperties39);

            A.Level5ParagraphProperties level5ParagraphProperties4 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties40 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill37 = new A.SolidFill();
            A.SchemeColor schemeColor47 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill37.Append(schemeColor47);
            A.LatinFont latinFont25 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont25 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont25 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties40.Append(solidFill37);
            defaultRunProperties40.Append(latinFont25);
            defaultRunProperties40.Append(eastAsianFont25);
            defaultRunProperties40.Append(complexScriptFont25);

            level5ParagraphProperties4.Append(defaultRunProperties40);

            A.Level6ParagraphProperties level6ParagraphProperties4 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties41 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill38 = new A.SolidFill();
            A.SchemeColor schemeColor48 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill38.Append(schemeColor48);
            A.LatinFont latinFont26 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont26 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont26 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties41.Append(solidFill38);
            defaultRunProperties41.Append(latinFont26);
            defaultRunProperties41.Append(eastAsianFont26);
            defaultRunProperties41.Append(complexScriptFont26);

            level6ParagraphProperties4.Append(defaultRunProperties41);

            A.Level7ParagraphProperties level7ParagraphProperties4 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties42 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill39 = new A.SolidFill();
            A.SchemeColor schemeColor49 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill39.Append(schemeColor49);
            A.LatinFont latinFont27 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont27 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont27 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties42.Append(solidFill39);
            defaultRunProperties42.Append(latinFont27);
            defaultRunProperties42.Append(eastAsianFont27);
            defaultRunProperties42.Append(complexScriptFont27);

            level7ParagraphProperties4.Append(defaultRunProperties42);

            A.Level8ParagraphProperties level8ParagraphProperties4 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties43 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill40 = new A.SolidFill();
            A.SchemeColor schemeColor50 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill40.Append(schemeColor50);
            A.LatinFont latinFont28 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont28 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont28 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties43.Append(solidFill40);
            defaultRunProperties43.Append(latinFont28);
            defaultRunProperties43.Append(eastAsianFont28);
            defaultRunProperties43.Append(complexScriptFont28);

            level8ParagraphProperties4.Append(defaultRunProperties43);

            A.Level9ParagraphProperties level9ParagraphProperties4 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties44 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill41 = new A.SolidFill();
            A.SchemeColor schemeColor51 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill41.Append(schemeColor51);
            A.LatinFont latinFont29 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont29 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont29 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

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
            SlideLayout slideLayout2 = new SlideLayout() { Type = SlideLayoutValues.VerticalText, Preserve = true };
            slideLayout2.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout2.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout2.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData4 = new CommonSlideData() { Name = "Title and Vertical Text" };

            ShapeTree shapeTree4 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties4 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties17 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties4 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties17 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties4.Append(nonVisualDrawingProperties17);
            nonVisualGroupShapeProperties4.Append(nonVisualGroupShapeDrawingProperties4);
            nonVisualGroupShapeProperties4.Append(applicationNonVisualDrawingProperties17);

            GroupShapeProperties groupShapeProperties4 = new GroupShapeProperties();

            A.TransformGroup transformGroup4 = new A.TransformGroup();
            A.Offset offset14 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents14 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset4 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents4 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup4.Append(offset14);
            transformGroup4.Append(extents14);
            transformGroup4.Append(childOffset4);
            transformGroup4.Append(childExtents4);

            groupShapeProperties4.Append(transformGroup4);

            Shape shape14 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties14 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties18 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties14 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks13 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties14.Append(shapeLocks13);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties18 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape12 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties18.Append(placeholderShape12);

            nonVisualShapeProperties14.Append(nonVisualDrawingProperties18);
            nonVisualShapeProperties14.Append(nonVisualShapeDrawingProperties14);
            nonVisualShapeProperties14.Append(applicationNonVisualDrawingProperties18);
            ShapeProperties shapeProperties14 = new ShapeProperties();

            TextBody textBody14 = new TextBody();
            A.BodyProperties bodyProperties14 = new A.BodyProperties();
            A.ListStyle listStyle14 = new A.ListStyle();

            A.Paragraph paragraph18 = new A.Paragraph();

            A.Run run11 = new A.Run();

            A.RunProperties runProperties15 = new A.RunProperties() { Language = "en-US" };
            runProperties15.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text15 = new A.Text();
            text15.Text = "Click to edit Master title style";

            run11.Append(runProperties15);
            run11.Append(text15);
            A.EndParagraphRunProperties endParagraphRunProperties14 = new A.EndParagraphRunProperties();

            paragraph18.Append(run11);
            paragraph18.Append(endParagraphRunProperties14);

            textBody14.Append(bodyProperties14);
            textBody14.Append(listStyle14);
            textBody14.Append(paragraph18);

            shape14.Append(nonVisualShapeProperties14);
            shape14.Append(shapeProperties14);
            shape14.Append(textBody14);

            Shape shape15 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties15 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties19 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Vertical Text Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties15 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks14 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties15.Append(shapeLocks14);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties19 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape13 = new PlaceholderShape() { Type = PlaceholderValues.Body, Orientation = DirectionValues.Vertical, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties19.Append(placeholderShape13);

            nonVisualShapeProperties15.Append(nonVisualDrawingProperties19);
            nonVisualShapeProperties15.Append(nonVisualShapeDrawingProperties15);
            nonVisualShapeProperties15.Append(applicationNonVisualDrawingProperties19);
            ShapeProperties shapeProperties15 = new ShapeProperties();

            TextBody textBody15 = new TextBody();
            A.BodyProperties bodyProperties15 = new A.BodyProperties() { Vertical = A.TextVerticalValues.EastAsianVetical };

            A.ListStyle listStyle15 = new A.ListStyle();

            A.Level5ParagraphProperties level5ParagraphProperties5 = new A.Level5ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties45 = new A.DefaultRunProperties();

            level5ParagraphProperties5.Append(defaultRunProperties45);

            listStyle15.Append(level5ParagraphProperties5);

            A.Paragraph paragraph19 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties12 = new A.ParagraphProperties() { Level = 0 };

            A.Run run12 = new A.Run();

            A.RunProperties runProperties16 = new A.RunProperties() { Language = "en-US" };
            runProperties16.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text16 = new A.Text();
            text16.Text = "Click to edit Master text styles";

            run12.Append(runProperties16);
            run12.Append(text16);

            paragraph19.Append(paragraphProperties12);
            paragraph19.Append(run12);

            A.Paragraph paragraph20 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties13 = new A.ParagraphProperties() { Level = 1 };

            A.Run run13 = new A.Run();

            A.RunProperties runProperties17 = new A.RunProperties() { Language = "en-US" };
            runProperties17.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text17 = new A.Text();
            text17.Text = "Second level";

            run13.Append(runProperties17);
            run13.Append(text17);

            paragraph20.Append(paragraphProperties13);
            paragraph20.Append(run13);

            A.Paragraph paragraph21 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties14 = new A.ParagraphProperties() { Level = 2 };

            A.Run run14 = new A.Run();

            A.RunProperties runProperties18 = new A.RunProperties() { Language = "en-US" };
            runProperties18.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text18 = new A.Text();
            text18.Text = "Third level";

            run14.Append(runProperties18);
            run14.Append(text18);

            paragraph21.Append(paragraphProperties14);
            paragraph21.Append(run14);

            A.Paragraph paragraph22 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties15 = new A.ParagraphProperties() { Level = 3 };

            A.Run run15 = new A.Run();

            A.RunProperties runProperties19 = new A.RunProperties() { Language = "en-US" };
            runProperties19.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text19 = new A.Text();
            text19.Text = "Fourth level";

            run15.Append(runProperties19);
            run15.Append(text19);

            paragraph22.Append(paragraphProperties15);
            paragraph22.Append(run15);

            A.Paragraph paragraph23 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties16 = new A.ParagraphProperties() { Level = 4 };

            A.Run run16 = new A.Run();

            A.RunProperties runProperties20 = new A.RunProperties() { Language = "en-US" };
            runProperties20.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text20 = new A.Text();
            text20.Text = "Fifth level";

            run16.Append(runProperties20);
            run16.Append(text20);
            A.EndParagraphRunProperties endParagraphRunProperties15 = new A.EndParagraphRunProperties() { Dirty = false };

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

            Shape shape16 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties16 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties20 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Date Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties16 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks15 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties16.Append(shapeLocks15);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties20 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape14 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties20.Append(placeholderShape14);

            nonVisualShapeProperties16.Append(nonVisualDrawingProperties20);
            nonVisualShapeProperties16.Append(nonVisualShapeDrawingProperties16);
            nonVisualShapeProperties16.Append(applicationNonVisualDrawingProperties20);
            ShapeProperties shapeProperties16 = new ShapeProperties();

            TextBody textBody16 = new TextBody();
            A.BodyProperties bodyProperties16 = new A.BodyProperties();
            A.ListStyle listStyle16 = new A.ListStyle();

            A.Paragraph paragraph24 = new A.Paragraph();

            A.Field field5 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties21 = new A.RunProperties() { Language = "en-US" };
            runProperties21.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties17 = new A.ParagraphProperties();
            A.Text text21 = new A.Text();
            text21.Text = "29/11/13";

            field5.Append(runProperties21);
            field5.Append(paragraphProperties17);
            field5.Append(text21);
            A.EndParagraphRunProperties endParagraphRunProperties16 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph24.Append(field5);
            paragraph24.Append(endParagraphRunProperties16);

            textBody16.Append(bodyProperties16);
            textBody16.Append(listStyle16);
            textBody16.Append(paragraph24);

            shape16.Append(nonVisualShapeProperties16);
            shape16.Append(shapeProperties16);
            shape16.Append(textBody16);

            Shape shape17 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties17 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties21 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Footer Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties17 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks16 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties17.Append(shapeLocks16);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties21 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape15 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties21.Append(placeholderShape15);

            nonVisualShapeProperties17.Append(nonVisualDrawingProperties21);
            nonVisualShapeProperties17.Append(nonVisualShapeDrawingProperties17);
            nonVisualShapeProperties17.Append(applicationNonVisualDrawingProperties21);
            ShapeProperties shapeProperties17 = new ShapeProperties();

            TextBody textBody17 = new TextBody();
            A.BodyProperties bodyProperties17 = new A.BodyProperties();
            A.ListStyle listStyle17 = new A.ListStyle();

            A.Paragraph paragraph25 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties17 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph25.Append(endParagraphRunProperties17);

            textBody17.Append(bodyProperties17);
            textBody17.Append(listStyle17);
            textBody17.Append(paragraph25);

            shape17.Append(nonVisualShapeProperties17);
            shape17.Append(shapeProperties17);
            shape17.Append(textBody17);

            Shape shape18 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties18 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties22 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Slide Number Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties18 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks17 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties18.Append(shapeLocks17);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties22 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape16 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties22.Append(placeholderShape16);

            nonVisualShapeProperties18.Append(nonVisualDrawingProperties22);
            nonVisualShapeProperties18.Append(nonVisualShapeDrawingProperties18);
            nonVisualShapeProperties18.Append(applicationNonVisualDrawingProperties22);
            ShapeProperties shapeProperties18 = new ShapeProperties();

            TextBody textBody18 = new TextBody();
            A.BodyProperties bodyProperties18 = new A.BodyProperties();
            A.ListStyle listStyle18 = new A.ListStyle();

            A.Paragraph paragraph26 = new A.Paragraph();

            A.Field field6 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties22 = new A.RunProperties() { Language = "en-US" };
            runProperties22.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties18 = new A.ParagraphProperties();
            A.Text text22 = new A.Text();
            text22.Text = "‹#›";

            field6.Append(runProperties22);
            field6.Append(paragraphProperties18);
            field6.Append(text22);
            A.EndParagraphRunProperties endParagraphRunProperties18 = new A.EndParagraphRunProperties() { Language = "en-US" };

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

            ColorMapOverride colorMapOverride3 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping3 = new A.MasterColorMapping();

            colorMapOverride3.Append(masterColorMapping3);

            slideLayout2.Append(commonSlideData4);
            slideLayout2.Append(colorMapOverride3);

            slideLayoutPart2.SlideLayout = slideLayout2;
        }

        // Generates content of slideLayoutPart3.
        private void GenerateSlideLayoutPart3Content(SlideLayoutPart slideLayoutPart3)
        {
            SlideLayout slideLayout3 = new SlideLayout() { Type = SlideLayoutValues.VerticalTitleAndText, Preserve = true };
            slideLayout3.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout3.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout3.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData5 = new CommonSlideData() { Name = "Vertical Title and Text" };

            ShapeTree shapeTree5 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties5 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties23 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties5 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties23 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties5.Append(nonVisualDrawingProperties23);
            nonVisualGroupShapeProperties5.Append(nonVisualGroupShapeDrawingProperties5);
            nonVisualGroupShapeProperties5.Append(applicationNonVisualDrawingProperties23);

            GroupShapeProperties groupShapeProperties5 = new GroupShapeProperties();

            A.TransformGroup transformGroup5 = new A.TransformGroup();
            A.Offset offset15 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents15 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset5 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents5 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup5.Append(offset15);
            transformGroup5.Append(extents15);
            transformGroup5.Append(childOffset5);
            transformGroup5.Append(childExtents5);

            groupShapeProperties5.Append(transformGroup5);

            Shape shape19 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties19 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties24 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Vertical Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties19 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks18 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties19.Append(shapeLocks18);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties24 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape17 = new PlaceholderShape() { Type = PlaceholderValues.Title, Orientation = DirectionValues.Vertical };

            applicationNonVisualDrawingProperties24.Append(placeholderShape17);

            nonVisualShapeProperties19.Append(nonVisualDrawingProperties24);
            nonVisualShapeProperties19.Append(nonVisualShapeDrawingProperties19);
            nonVisualShapeProperties19.Append(applicationNonVisualDrawingProperties24);

            ShapeProperties shapeProperties19 = new ShapeProperties();

            A.Transform2D transform2D11 = new A.Transform2D();
            A.Offset offset16 = new A.Offset() { X = 7369792L, Y = 368301L };
            A.Extents extents16 = new A.Extents() { Cx = 1524000L, Cy = 5575300L };

            transform2D11.Append(offset16);
            transform2D11.Append(extents16);

            shapeProperties19.Append(transform2D11);

            TextBody textBody19 = new TextBody();
            A.BodyProperties bodyProperties19 = new A.BodyProperties() { Vertical = A.TextVerticalValues.EastAsianVetical };
            A.ListStyle listStyle19 = new A.ListStyle();

            A.Paragraph paragraph27 = new A.Paragraph();

            A.Run run17 = new A.Run();

            A.RunProperties runProperties23 = new A.RunProperties() { Language = "en-US" };
            runProperties23.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text23 = new A.Text();
            text23.Text = "Click to edit Master title style";

            run17.Append(runProperties23);
            run17.Append(text23);
            A.EndParagraphRunProperties endParagraphRunProperties19 = new A.EndParagraphRunProperties();

            paragraph27.Append(run17);
            paragraph27.Append(endParagraphRunProperties19);

            textBody19.Append(bodyProperties19);
            textBody19.Append(listStyle19);
            textBody19.Append(paragraph27);

            shape19.Append(nonVisualShapeProperties19);
            shape19.Append(shapeProperties19);
            shape19.Append(textBody19);

            Shape shape20 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties20 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties25 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Vertical Text Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties20 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks19 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties20.Append(shapeLocks19);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties25 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape18 = new PlaceholderShape() { Type = PlaceholderValues.Body, Orientation = DirectionValues.Vertical, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties25.Append(placeholderShape18);

            nonVisualShapeProperties20.Append(nonVisualDrawingProperties25);
            nonVisualShapeProperties20.Append(nonVisualShapeDrawingProperties20);
            nonVisualShapeProperties20.Append(applicationNonVisualDrawingProperties25);

            ShapeProperties shapeProperties20 = new ShapeProperties();

            A.Transform2D transform2D12 = new A.Transform2D();
            A.Offset offset17 = new A.Offset() { X = 549274L, Y = 368301L };
            A.Extents extents17 = new A.Extents() { Cx = 6689726L, Cy = 5575300L };

            transform2D12.Append(offset17);
            transform2D12.Append(extents17);

            shapeProperties20.Append(transform2D12);

            TextBody textBody20 = new TextBody();
            A.BodyProperties bodyProperties20 = new A.BodyProperties() { Vertical = A.TextVerticalValues.EastAsianVetical };

            A.ListStyle listStyle20 = new A.ListStyle();

            A.Level5ParagraphProperties level5ParagraphProperties6 = new A.Level5ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties46 = new A.DefaultRunProperties();

            level5ParagraphProperties6.Append(defaultRunProperties46);

            listStyle20.Append(level5ParagraphProperties6);

            A.Paragraph paragraph28 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties19 = new A.ParagraphProperties() { Level = 0 };

            A.Run run18 = new A.Run();

            A.RunProperties runProperties24 = new A.RunProperties() { Language = "en-US" };
            runProperties24.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text24 = new A.Text();
            text24.Text = "Click to edit Master text styles";

            run18.Append(runProperties24);
            run18.Append(text24);

            paragraph28.Append(paragraphProperties19);
            paragraph28.Append(run18);

            A.Paragraph paragraph29 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties20 = new A.ParagraphProperties() { Level = 1 };

            A.Run run19 = new A.Run();

            A.RunProperties runProperties25 = new A.RunProperties() { Language = "en-US" };
            runProperties25.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text25 = new A.Text();
            text25.Text = "Second level";

            run19.Append(runProperties25);
            run19.Append(text25);

            paragraph29.Append(paragraphProperties20);
            paragraph29.Append(run19);

            A.Paragraph paragraph30 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties21 = new A.ParagraphProperties() { Level = 2 };

            A.Run run20 = new A.Run();

            A.RunProperties runProperties26 = new A.RunProperties() { Language = "en-US" };
            runProperties26.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text26 = new A.Text();
            text26.Text = "Third level";

            run20.Append(runProperties26);
            run20.Append(text26);

            paragraph30.Append(paragraphProperties21);
            paragraph30.Append(run20);

            A.Paragraph paragraph31 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties22 = new A.ParagraphProperties() { Level = 3 };

            A.Run run21 = new A.Run();

            A.RunProperties runProperties27 = new A.RunProperties() { Language = "en-US" };
            runProperties27.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text27 = new A.Text();
            text27.Text = "Fourth level";

            run21.Append(runProperties27);
            run21.Append(text27);

            paragraph31.Append(paragraphProperties22);
            paragraph31.Append(run21);

            A.Paragraph paragraph32 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties23 = new A.ParagraphProperties() { Level = 4 };

            A.Run run22 = new A.Run();

            A.RunProperties runProperties28 = new A.RunProperties() { Language = "en-US" };
            runProperties28.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text28 = new A.Text();
            text28.Text = "Fifth level";

            run22.Append(runProperties28);
            run22.Append(text28);
            A.EndParagraphRunProperties endParagraphRunProperties20 = new A.EndParagraphRunProperties() { Dirty = false };

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

            Shape shape21 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties21 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties26 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Date Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties21 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks20 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties21.Append(shapeLocks20);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties26 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape19 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties26.Append(placeholderShape19);

            nonVisualShapeProperties21.Append(nonVisualDrawingProperties26);
            nonVisualShapeProperties21.Append(nonVisualShapeDrawingProperties21);
            nonVisualShapeProperties21.Append(applicationNonVisualDrawingProperties26);
            ShapeProperties shapeProperties21 = new ShapeProperties();

            TextBody textBody21 = new TextBody();
            A.BodyProperties bodyProperties21 = new A.BodyProperties();
            A.ListStyle listStyle21 = new A.ListStyle();

            A.Paragraph paragraph33 = new A.Paragraph();

            A.Field field7 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties29 = new A.RunProperties() { Language = "en-US" };
            runProperties29.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties24 = new A.ParagraphProperties();
            A.Text text29 = new A.Text();
            text29.Text = "29/11/13";

            field7.Append(runProperties29);
            field7.Append(paragraphProperties24);
            field7.Append(text29);
            A.EndParagraphRunProperties endParagraphRunProperties21 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph33.Append(field7);
            paragraph33.Append(endParagraphRunProperties21);

            textBody21.Append(bodyProperties21);
            textBody21.Append(listStyle21);
            textBody21.Append(paragraph33);

            shape21.Append(nonVisualShapeProperties21);
            shape21.Append(shapeProperties21);
            shape21.Append(textBody21);

            Shape shape22 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties22 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties27 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Footer Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties22 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks21 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties22.Append(shapeLocks21);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties27 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape20 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties27.Append(placeholderShape20);

            nonVisualShapeProperties22.Append(nonVisualDrawingProperties27);
            nonVisualShapeProperties22.Append(nonVisualShapeDrawingProperties22);
            nonVisualShapeProperties22.Append(applicationNonVisualDrawingProperties27);
            ShapeProperties shapeProperties22 = new ShapeProperties();

            TextBody textBody22 = new TextBody();
            A.BodyProperties bodyProperties22 = new A.BodyProperties();
            A.ListStyle listStyle22 = new A.ListStyle();

            A.Paragraph paragraph34 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties22 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph34.Append(endParagraphRunProperties22);

            textBody22.Append(bodyProperties22);
            textBody22.Append(listStyle22);
            textBody22.Append(paragraph34);

            shape22.Append(nonVisualShapeProperties22);
            shape22.Append(shapeProperties22);
            shape22.Append(textBody22);

            Shape shape23 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties23 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties28 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Slide Number Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties23 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks22 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties23.Append(shapeLocks22);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties28 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape21 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties28.Append(placeholderShape21);

            nonVisualShapeProperties23.Append(nonVisualDrawingProperties28);
            nonVisualShapeProperties23.Append(nonVisualShapeDrawingProperties23);
            nonVisualShapeProperties23.Append(applicationNonVisualDrawingProperties28);
            ShapeProperties shapeProperties23 = new ShapeProperties();

            TextBody textBody23 = new TextBody();
            A.BodyProperties bodyProperties23 = new A.BodyProperties();
            A.ListStyle listStyle23 = new A.ListStyle();

            A.Paragraph paragraph35 = new A.Paragraph();

            A.Field field8 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties30 = new A.RunProperties() { Language = "en-US" };
            runProperties30.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties25 = new A.ParagraphProperties();
            A.Text text30 = new A.Text();
            text30.Text = "‹#›";

            field8.Append(runProperties30);
            field8.Append(paragraphProperties25);
            field8.Append(text30);
            A.EndParagraphRunProperties endParagraphRunProperties23 = new A.EndParagraphRunProperties() { Language = "en-US" };

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

            ColorMapOverride colorMapOverride4 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping4 = new A.MasterColorMapping();

            colorMapOverride4.Append(masterColorMapping4);

            slideLayout3.Append(commonSlideData5);
            slideLayout3.Append(colorMapOverride4);

            slideLayoutPart3.SlideLayout = slideLayout3;
        }

        // Generates content of themePart1.
        private void GenerateThemePart1Content(ThemePart themePart1)
        {
            A.Theme theme1 = new A.Theme() { Name = "Breeze" };
            theme1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            A.ThemeElements themeElements1 = new A.ThemeElements();

            A.ColorScheme colorScheme1 = new A.ColorScheme() { Name = "Breeze" };

            A.Dark1Color dark1Color1 = new A.Dark1Color();
            A.SystemColor systemColor1 = new A.SystemColor() { Val = A.SystemColorValues.WindowText, LastColor = "000000" };

            dark1Color1.Append(systemColor1);

            A.Light1Color light1Color1 = new A.Light1Color();
            A.SystemColor systemColor2 = new A.SystemColor() { Val = A.SystemColorValues.Window, LastColor = "FFFFFF" };

            light1Color1.Append(systemColor2);

            A.Dark2Color dark2Color1 = new A.Dark2Color();
            A.RgbColorModelHex rgbColorModelHex1 = new A.RgbColorModelHex() { Val = "09213B" };

            dark2Color1.Append(rgbColorModelHex1);

            A.Light2Color light2Color1 = new A.Light2Color();
            A.RgbColorModelHex rgbColorModelHex2 = new A.RgbColorModelHex() { Val = "D5EDF4" };

            light2Color1.Append(rgbColorModelHex2);

            A.Accent1Color accent1Color1 = new A.Accent1Color();
            A.RgbColorModelHex rgbColorModelHex3 = new A.RgbColorModelHex() { Val = "2C7C9F" };

            accent1Color1.Append(rgbColorModelHex3);

            A.Accent2Color accent2Color1 = new A.Accent2Color();
            A.RgbColorModelHex rgbColorModelHex4 = new A.RgbColorModelHex() { Val = "244A58" };

            accent2Color1.Append(rgbColorModelHex4);

            A.Accent3Color accent3Color1 = new A.Accent3Color();
            A.RgbColorModelHex rgbColorModelHex5 = new A.RgbColorModelHex() { Val = "E2751D" };

            accent3Color1.Append(rgbColorModelHex5);

            A.Accent4Color accent4Color1 = new A.Accent4Color();
            A.RgbColorModelHex rgbColorModelHex6 = new A.RgbColorModelHex() { Val = "FFB400" };

            accent4Color1.Append(rgbColorModelHex6);

            A.Accent5Color accent5Color1 = new A.Accent5Color();
            A.RgbColorModelHex rgbColorModelHex7 = new A.RgbColorModelHex() { Val = "7EB606" };

            accent5Color1.Append(rgbColorModelHex7);

            A.Accent6Color accent6Color1 = new A.Accent6Color();
            A.RgbColorModelHex rgbColorModelHex8 = new A.RgbColorModelHex() { Val = "C00000" };

            accent6Color1.Append(rgbColorModelHex8);

            A.Hyperlink hyperlink1 = new A.Hyperlink();
            A.RgbColorModelHex rgbColorModelHex9 = new A.RgbColorModelHex() { Val = "7030A0" };

            hyperlink1.Append(rgbColorModelHex9);

            A.FollowedHyperlinkColor followedHyperlinkColor1 = new A.FollowedHyperlinkColor();
            A.RgbColorModelHex rgbColorModelHex10 = new A.RgbColorModelHex() { Val = "00B0F0" };

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

            A.FontScheme fontScheme1 = new A.FontScheme() { Name = "Breeze" };

            A.MajorFont majorFont1 = new A.MajorFont();
            A.LatinFont latinFont30 = new A.LatinFont() { Typeface = "News Gothic MT" };
            A.EastAsianFont eastAsianFont30 = new A.EastAsianFont() { Typeface = "" };
            A.ComplexScriptFont complexScriptFont30 = new A.ComplexScriptFont() { Typeface = "" };
            A.SupplementalFont supplementalFont1 = new A.SupplementalFont() { Script = "Jpan", Typeface = "ＭＳ Ｐゴシック" };
            A.SupplementalFont supplementalFont2 = new A.SupplementalFont() { Script = "Hans", Typeface = "宋体" };
            A.SupplementalFont supplementalFont3 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };

            majorFont1.Append(latinFont30);
            majorFont1.Append(eastAsianFont30);
            majorFont1.Append(complexScriptFont30);
            majorFont1.Append(supplementalFont1);
            majorFont1.Append(supplementalFont2);
            majorFont1.Append(supplementalFont3);

            A.MinorFont minorFont1 = new A.MinorFont();
            A.LatinFont latinFont31 = new A.LatinFont() { Typeface = "News Gothic MT" };
            A.EastAsianFont eastAsianFont31 = new A.EastAsianFont() { Typeface = "" };
            A.ComplexScriptFont complexScriptFont31 = new A.ComplexScriptFont() { Typeface = "" };
            A.SupplementalFont supplementalFont4 = new A.SupplementalFont() { Script = "Jpan", Typeface = "ＭＳ Ｐゴシック" };
            A.SupplementalFont supplementalFont5 = new A.SupplementalFont() { Script = "Hans", Typeface = "宋体" };
            A.SupplementalFont supplementalFont6 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };

            minorFont1.Append(latinFont31);
            minorFont1.Append(eastAsianFont31);
            minorFont1.Append(complexScriptFont31);
            minorFont1.Append(supplementalFont4);
            minorFont1.Append(supplementalFont5);
            minorFont1.Append(supplementalFont6);

            fontScheme1.Append(majorFont1);
            fontScheme1.Append(minorFont1);

            A.FormatScheme formatScheme1 = new A.FormatScheme() { Name = "Breeze" };

            A.FillStyleList fillStyleList1 = new A.FillStyleList();

            A.SolidFill solidFill42 = new A.SolidFill();
            A.SchemeColor schemeColor52 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill42.Append(schemeColor52);

            A.GradientFill gradientFill1 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList1 = new A.GradientStopList();

            A.GradientStop gradientStop1 = new A.GradientStop() { Position = 31000 };

            A.SchemeColor schemeColor53 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint10 = new A.Tint() { Val = 100000 };
            A.Shade shade1 = new A.Shade() { Val = 100000 };
            A.SaturationModulation saturationModulation1 = new A.SaturationModulation() { Val = 120000 };

            schemeColor53.Append(tint10);
            schemeColor53.Append(shade1);
            schemeColor53.Append(saturationModulation1);

            gradientStop1.Append(schemeColor53);

            A.GradientStop gradientStop2 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor54 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint11 = new A.Tint() { Val = 50000 };
            A.SaturationModulation saturationModulation2 = new A.SaturationModulation() { Val = 150000 };

            schemeColor54.Append(tint11);
            schemeColor54.Append(saturationModulation2);

            gradientStop2.Append(schemeColor54);

            gradientStopList1.Append(gradientStop1);
            gradientStopList1.Append(gradientStop2);
            A.LinearGradientFill linearGradientFill1 = new A.LinearGradientFill() { Angle = 5400000, Scaled = true };

            gradientFill1.Append(gradientStopList1);
            gradientFill1.Append(linearGradientFill1);

            A.GradientFill gradientFill2 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList2 = new A.GradientStopList();

            A.GradientStop gradientStop3 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor55 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade2 = new A.Shade() { Val = 100000 };
            A.SaturationModulation saturationModulation3 = new A.SaturationModulation() { Val = 120000 };

            schemeColor55.Append(shade2);
            schemeColor55.Append(saturationModulation3);

            gradientStop3.Append(schemeColor55);

            A.GradientStop gradientStop4 = new A.GradientStop() { Position = 69000 };

            A.SchemeColor schemeColor56 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint12 = new A.Tint() { Val = 80000 };
            A.Shade shade3 = new A.Shade() { Val = 100000 };
            A.SaturationModulation saturationModulation4 = new A.SaturationModulation() { Val = 150000 };

            schemeColor56.Append(tint12);
            schemeColor56.Append(shade3);
            schemeColor56.Append(saturationModulation4);

            gradientStop4.Append(schemeColor56);

            A.GradientStop gradientStop5 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor57 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint13 = new A.Tint() { Val = 50000 };
            A.Shade shade4 = new A.Shade() { Val = 100000 };
            A.SaturationModulation saturationModulation5 = new A.SaturationModulation() { Val = 150000 };

            schemeColor57.Append(tint13);
            schemeColor57.Append(shade4);
            schemeColor57.Append(saturationModulation5);

            gradientStop5.Append(schemeColor57);

            gradientStopList2.Append(gradientStop3);
            gradientStopList2.Append(gradientStop4);
            gradientStopList2.Append(gradientStop5);

            A.PathGradientFill pathGradientFill1 = new A.PathGradientFill() { Path = A.PathShadeValues.Circle };
            A.FillToRectangle fillToRectangle1 = new A.FillToRectangle() { Left = 100000, Top = 100000, Right = 100000, Bottom = 100000 };

            pathGradientFill1.Append(fillToRectangle1);

            gradientFill2.Append(gradientStopList2);
            gradientFill2.Append(pathGradientFill1);

            fillStyleList1.Append(solidFill42);
            fillStyleList1.Append(gradientFill1);
            fillStyleList1.Append(gradientFill2);

            A.LineStyleList lineStyleList1 = new A.LineStyleList();

            A.Outline outline1 = new A.Outline() { Width = 12700, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill43 = new A.SolidFill();

            A.SchemeColor schemeColor58 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade5 = new A.Shade() { Val = 95000 };
            A.SaturationModulation saturationModulation6 = new A.SaturationModulation() { Val = 105000 };

            schemeColor58.Append(shade5);
            schemeColor58.Append(saturationModulation6);

            solidFill43.Append(schemeColor58);
            A.PresetDash presetDash1 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

            outline1.Append(solidFill43);
            outline1.Append(presetDash1);

            A.Outline outline2 = new A.Outline() { Width = 25400, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Double, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill44 = new A.SolidFill();
            A.SchemeColor schemeColor59 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill44.Append(schemeColor59);
            A.PresetDash presetDash2 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

            outline2.Append(solidFill44);
            outline2.Append(presetDash2);

            A.Outline outline3 = new A.Outline() { Width = 31750, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Double, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill45 = new A.SolidFill();
            A.SchemeColor schemeColor60 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill45.Append(schemeColor60);
            A.PresetDash presetDash3 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

            outline3.Append(solidFill45);
            outline3.Append(presetDash3);

            lineStyleList1.Append(outline1);
            lineStyleList1.Append(outline2);
            lineStyleList1.Append(outline3);

            A.EffectStyleList effectStyleList1 = new A.EffectStyleList();

            A.EffectStyle effectStyle1 = new A.EffectStyle();
            A.EffectList effectList1 = new A.EffectList();

            effectStyle1.Append(effectList1);

            A.EffectStyle effectStyle2 = new A.EffectStyle();

            A.EffectList effectList2 = new A.EffectList();

            A.OuterShadow outerShadow1 = new A.OuterShadow() { BlurRadius = 63500L, Distance = 25400L, Direction = 5400000, HorizontalRatio = 101000, VerticalRatio = 101000, RotateWithShape = false };

            A.RgbColorModelHex rgbColorModelHex11 = new A.RgbColorModelHex() { Val = "000000" };
            A.Alpha alpha1 = new A.Alpha() { Val = 40000 };

            rgbColorModelHex11.Append(alpha1);

            outerShadow1.Append(rgbColorModelHex11);

            effectList2.Append(outerShadow1);

            effectStyle2.Append(effectList2);

            A.EffectStyle effectStyle3 = new A.EffectStyle();

            A.EffectList effectList3 = new A.EffectList();

            A.InnerShadow innerShadow1 = new A.InnerShadow() { BlurRadius = 127000L, Distance = 25400L, Direction = 13500000 };

            A.RgbColorModelHex rgbColorModelHex12 = new A.RgbColorModelHex() { Val = "C0C0C0" };
            A.Alpha alpha2 = new A.Alpha() { Val = 75000 };

            rgbColorModelHex12.Append(alpha2);

            innerShadow1.Append(rgbColorModelHex12);

            A.OuterShadow outerShadow2 = new A.OuterShadow() { BlurRadius = 88900L, Distance = 25400L, Direction = 5400000, HorizontalRatio = 102000, VerticalRatio = 102000, Alignment = A.RectangleAlignmentValues.Center, RotateWithShape = false };

            A.RgbColorModelHex rgbColorModelHex13 = new A.RgbColorModelHex() { Val = "C0C0C0" };
            A.Alpha alpha3 = new A.Alpha() { Val = 40000 };

            rgbColorModelHex13.Append(alpha3);

            outerShadow2.Append(rgbColorModelHex13);

            effectList3.Append(innerShadow1);
            effectList3.Append(outerShadow2);

            A.Scene3DType scene3DType1 = new A.Scene3DType();
            A.Camera camera1 = new A.Camera() { Preset = A.PresetCameraValues.PerspectiveLeft, FieldOfView = 300000 };

            A.LightRig lightRig1 = new A.LightRig() { Rig = A.LightRigValues.Soft, Direction = A.LightRigDirectionValues.Left };
            A.Rotation rotation1 = new A.Rotation() { Latitude = 0, Longitude = 0, Revolution = 4200000 };

            lightRig1.Append(rotation1);

            scene3DType1.Append(camera1);
            scene3DType1.Append(lightRig1);

            A.Shape3DType shape3DType1 = new A.Shape3DType() { ExtrusionHeight = 38100L, PresetMaterial = A.PresetMaterialTypeValues.Powder };
            A.BevelTop bevelTop1 = new A.BevelTop() { Width = 50800L, Height = 88900L, Preset = A.BevelPresetValues.Convex };

            shape3DType1.Append(bevelTop1);

            effectStyle3.Append(effectList3);
            effectStyle3.Append(scene3DType1);
            effectStyle3.Append(shape3DType1);

            effectStyleList1.Append(effectStyle1);
            effectStyleList1.Append(effectStyle2);
            effectStyleList1.Append(effectStyle3);

            A.BackgroundFillStyleList backgroundFillStyleList1 = new A.BackgroundFillStyleList();

            A.SolidFill solidFill46 = new A.SolidFill();
            A.SchemeColor schemeColor61 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill46.Append(schemeColor61);

            A.GradientFill gradientFill3 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList3 = new A.GradientStopList();

            A.GradientStop gradientStop6 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor62 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint14 = new A.Tint() { Val = 40000 };
            A.SaturationModulation saturationModulation7 = new A.SaturationModulation() { Val = 350000 };

            schemeColor62.Append(tint14);
            schemeColor62.Append(saturationModulation7);

            gradientStop6.Append(schemeColor62);

            A.GradientStop gradientStop7 = new A.GradientStop() { Position = 40000 };

            A.SchemeColor schemeColor63 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint15 = new A.Tint() { Val = 45000 };
            A.Shade shade6 = new A.Shade() { Val = 99000 };
            A.SaturationModulation saturationModulation8 = new A.SaturationModulation() { Val = 350000 };

            schemeColor63.Append(tint15);
            schemeColor63.Append(shade6);
            schemeColor63.Append(saturationModulation8);

            gradientStop7.Append(schemeColor63);

            A.GradientStop gradientStop8 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor64 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade7 = new A.Shade() { Val = 20000 };
            A.SaturationModulation saturationModulation9 = new A.SaturationModulation() { Val = 255000 };

            schemeColor64.Append(shade7);
            schemeColor64.Append(saturationModulation9);

            gradientStop8.Append(schemeColor64);

            gradientStopList3.Append(gradientStop6);
            gradientStopList3.Append(gradientStop7);
            gradientStopList3.Append(gradientStop8);

            A.PathGradientFill pathGradientFill2 = new A.PathGradientFill() { Path = A.PathShadeValues.Circle };
            A.FillToRectangle fillToRectangle2 = new A.FillToRectangle() { Left = 50000, Top = -80000, Right = 50000, Bottom = 180000 };

            pathGradientFill2.Append(fillToRectangle2);

            gradientFill3.Append(gradientStopList3);
            gradientFill3.Append(pathGradientFill2);

            A.BlipFill blipFill1 = new A.BlipFill() { RotateWithShape = true };

            A.Blip blip1 = new A.Blip() { Embed = "rId1" };
            blip1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");

            A.Duotone duotone1 = new A.Duotone();

            A.SchemeColor schemeColor65 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade8 = new A.Shade() { Val = 40000 };
            A.SaturationModulation saturationModulation10 = new A.SaturationModulation() { Val = 400000 };

            schemeColor65.Append(shade8);
            schemeColor65.Append(saturationModulation10);

            A.SchemeColor schemeColor66 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint16 = new A.Tint() { Val = 10000 };
            A.SaturationModulation saturationModulation11 = new A.SaturationModulation() { Val = 200000 };

            schemeColor66.Append(tint16);
            schemeColor66.Append(saturationModulation11);

            duotone1.Append(schemeColor65);
            duotone1.Append(schemeColor66);

            blip1.Append(duotone1);
            A.Stretch stretch1 = new A.Stretch();

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

            A.ObjectDefaults objectDefaults1 = new A.ObjectDefaults();

            A.ShapeDefault shapeDefault1 = new A.ShapeDefault();
            A.ShapeProperties shapeProperties24 = new A.ShapeProperties();
            A.BodyProperties bodyProperties24 = new A.BodyProperties() { RightToLeftColumns = false, Anchor = A.TextAnchoringTypeValues.Center };

            A.ListStyle listStyle24 = new A.ListStyle();

            A.DefaultParagraphProperties defaultParagraphProperties3 = new A.DefaultParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Center };
            A.DefaultRunProperties defaultRunProperties47 = new A.DefaultRunProperties();

            defaultParagraphProperties3.Append(defaultRunProperties47);

            listStyle24.Append(defaultParagraphProperties3);

            A.ShapeStyle shapeStyle1 = new A.ShapeStyle();

            A.LineReference lineReference1 = new A.LineReference() { Index = (UInt32Value)1U };
            A.SchemeColor schemeColor67 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            lineReference1.Append(schemeColor67);

            A.FillReference fillReference1 = new A.FillReference() { Index = (UInt32Value)3U };
            A.SchemeColor schemeColor68 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            fillReference1.Append(schemeColor68);

            A.EffectReference effectReference1 = new A.EffectReference() { Index = (UInt32Value)2U };
            A.SchemeColor schemeColor69 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            effectReference1.Append(schemeColor69);

            A.FontReference fontReference1 = new A.FontReference() { Index = A.FontCollectionIndexValues.Minor };
            A.SchemeColor schemeColor70 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            fontReference1.Append(schemeColor70);

            shapeStyle1.Append(lineReference1);
            shapeStyle1.Append(fillReference1);
            shapeStyle1.Append(effectReference1);
            shapeStyle1.Append(fontReference1);

            shapeDefault1.Append(shapeProperties24);
            shapeDefault1.Append(bodyProperties24);
            shapeDefault1.Append(listStyle24);
            shapeDefault1.Append(shapeStyle1);

            A.LineDefault lineDefault1 = new A.LineDefault();
            A.ShapeProperties shapeProperties25 = new A.ShapeProperties();
            A.BodyProperties bodyProperties25 = new A.BodyProperties();
            A.ListStyle listStyle25 = new A.ListStyle();

            A.ShapeStyle shapeStyle2 = new A.ShapeStyle();

            A.LineReference lineReference2 = new A.LineReference() { Index = (UInt32Value)2U };
            A.SchemeColor schemeColor71 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            lineReference2.Append(schemeColor71);

            A.FillReference fillReference2 = new A.FillReference() { Index = (UInt32Value)0U };
            A.SchemeColor schemeColor72 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            fillReference2.Append(schemeColor72);

            A.EffectReference effectReference2 = new A.EffectReference() { Index = (UInt32Value)1U };
            A.SchemeColor schemeColor73 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            effectReference2.Append(schemeColor73);

            A.FontReference fontReference2 = new A.FontReference() { Index = A.FontCollectionIndexValues.Minor };
            A.SchemeColor schemeColor74 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

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
            A.ExtraColorSchemeList extraColorSchemeList1 = new A.ExtraColorSchemeList();

            theme1.Append(themeElements1);
            theme1.Append(objectDefaults1);
            theme1.Append(extraColorSchemeList1);

            themePart1.Theme = theme1;
        }

        // Generates content of imagePart1.
        private void GenerateImagePart1Content(ImagePart imagePart1)
        {
            System.IO.Stream data = GetBinaryDataStream(imagePart1Data);
            imagePart1.FeedData(data);
            data.Close();
        }

        // Generates content of slideLayoutPart4.
        private void GenerateSlideLayoutPart4Content(SlideLayoutPart slideLayoutPart4)
        {
            SlideLayout slideLayout4 = new SlideLayout() { Type = SlideLayoutValues.Title, Preserve = true };
            slideLayout4.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout4.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout4.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData6 = new CommonSlideData() { Name = "Title Slide" };

            ShapeTree shapeTree6 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties6 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties29 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties6 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties29 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties6.Append(nonVisualDrawingProperties29);
            nonVisualGroupShapeProperties6.Append(nonVisualGroupShapeDrawingProperties6);
            nonVisualGroupShapeProperties6.Append(applicationNonVisualDrawingProperties29);

            GroupShapeProperties groupShapeProperties6 = new GroupShapeProperties();

            A.TransformGroup transformGroup6 = new A.TransformGroup();
            A.Offset offset18 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents18 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset6 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents6 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup6.Append(offset18);
            transformGroup6.Append(extents18);
            transformGroup6.Append(childOffset6);
            transformGroup6.Append(childExtents6);

            groupShapeProperties6.Append(transformGroup6);

            Shape shape24 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties24 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties30 = new NonVisualDrawingProperties() { Id = (UInt32Value)7U, Name = "Rectangle 6" };
            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties24 = new NonVisualShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties30 = new ApplicationNonVisualDrawingProperties();

            nonVisualShapeProperties24.Append(nonVisualDrawingProperties30);
            nonVisualShapeProperties24.Append(nonVisualShapeDrawingProperties24);
            nonVisualShapeProperties24.Append(applicationNonVisualDrawingProperties30);

            ShapeProperties shapeProperties26 = new ShapeProperties();

            A.Transform2D transform2D13 = new A.Transform2D();
            A.Offset offset19 = new A.Offset() { X = 1328166L, Y = 1295400L };
            A.Extents extents19 = new A.Extents() { Cx = 6487668L, Cy = 3152887L };

            transform2D13.Append(offset19);
            transform2D13.Append(extents19);

            A.PresetGeometry presetGeometry8 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList8 = new A.AdjustValueList();

            presetGeometry8.Append(adjustValueList8);

            A.Outline outline4 = new A.Outline() { Width = 3175 };

            A.SolidFill solidFill47 = new A.SolidFill();
            A.SchemeColor schemeColor75 = new A.SchemeColor() { Val = A.SchemeColorValues.Background1 };

            solidFill47.Append(schemeColor75);

            outline4.Append(solidFill47);

            A.EffectList effectList4 = new A.EffectList();

            A.OuterShadow outerShadow3 = new A.OuterShadow() { BlurRadius = 63500L, HorizontalRatio = 100500, VerticalRatio = 100500, Alignment = A.RectangleAlignmentValues.Center, RotateWithShape = false };

            A.PresetColor presetColor1 = new A.PresetColor() { Val = A.PresetColorValues.Black };
            A.Alpha alpha4 = new A.Alpha() { Val = 50000 };

            presetColor1.Append(alpha4);

            outerShadow3.Append(presetColor1);

            effectList4.Append(outerShadow3);

            shapeProperties26.Append(transform2D13);
            shapeProperties26.Append(presetGeometry8);
            shapeProperties26.Append(outline4);
            shapeProperties26.Append(effectList4);

            TextBody textBody24 = new TextBody();

            A.BodyProperties bodyProperties26 = new A.BodyProperties() { Vertical = A.TextVerticalValues.Horizontal, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, RightToLeftColumns = false };
            A.NormalAutoFit normalAutoFit2 = new A.NormalAutoFit();

            bodyProperties26.Append(normalAutoFit2);
            A.ListStyle listStyle26 = new A.ListStyle();

            A.Paragraph paragraph36 = new A.Paragraph();

            A.ParagraphProperties paragraphProperties26 = new A.ParagraphProperties() { LeftMargin = 0, Indent = 0, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore12 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints6 = new A.SpacingPoints() { Val = 2000 };

            spaceBefore12.Append(spacingPoints6);

            A.BulletColor bulletColor10 = new A.BulletColor();

            A.SchemeColor schemeColor76 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };
            A.LuminanceModulation luminanceModulation17 = new A.LuminanceModulation() { Val = 60000 };
            A.LuminanceOffset luminanceOffset15 = new A.LuminanceOffset() { Val = 40000 };

            schemeColor76.Append(luminanceModulation17);
            schemeColor76.Append(luminanceOffset15);

            bulletColor10.Append(schemeColor76);
            A.BulletSizePercentage bulletSizePercentage10 = new A.BulletSizePercentage() { Val = 110000 };
            A.BulletFont bulletFont10 = new A.BulletFont() { Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2 };
            A.NoBullet noBullet13 = new A.NoBullet();

            paragraphProperties26.Append(spaceBefore12);
            paragraphProperties26.Append(bulletColor10);
            paragraphProperties26.Append(bulletSizePercentage10);
            paragraphProperties26.Append(bulletFont10);
            paragraphProperties26.Append(noBullet13);

            A.EndParagraphRunProperties endParagraphRunProperties24 = new A.EndParagraphRunProperties() { FontSize = 3200, Kerning = 1200 };

            A.SolidFill solidFill48 = new A.SolidFill();

            A.SchemeColor schemeColor77 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.LuminanceModulation luminanceModulation18 = new A.LuminanceModulation() { Val = 65000 };
            A.LuminanceOffset luminanceOffset16 = new A.LuminanceOffset() { Val = 35000 };

            schemeColor77.Append(luminanceModulation18);
            schemeColor77.Append(luminanceOffset16);

            solidFill48.Append(schemeColor77);
            A.LatinFont latinFont32 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont32 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont32 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

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

            Shape shape25 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties25 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties31 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties25 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks23 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties25.Append(shapeLocks23);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties31 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape22 = new PlaceholderShape() { Type = PlaceholderValues.CenteredTitle };

            applicationNonVisualDrawingProperties31.Append(placeholderShape22);

            nonVisualShapeProperties25.Append(nonVisualDrawingProperties31);
            nonVisualShapeProperties25.Append(nonVisualShapeDrawingProperties25);
            nonVisualShapeProperties25.Append(applicationNonVisualDrawingProperties31);

            ShapeProperties shapeProperties27 = new ShapeProperties();

            A.Transform2D transform2D14 = new A.Transform2D();
            A.Offset offset20 = new A.Offset() { X = 1322921L, Y = 1523999L };
            A.Extents extents20 = new A.Extents() { Cx = 6498158L, Cy = 1724867L };

            transform2D14.Append(offset20);
            transform2D14.Append(extents20);

            shapeProperties27.Append(transform2D14);

            TextBody textBody25 = new TextBody();

            A.BodyProperties bodyProperties27 = new A.BodyProperties() { Vertical = A.TextVerticalValues.Horizontal, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, RightToLeftColumns = false, Anchor = A.TextAnchoringTypeValues.Bottom, AnchorCenter = false };
            A.NoAutoFit noAutoFit3 = new A.NoAutoFit();

            bodyProperties27.Append(noAutoFit3);

            A.ListStyle listStyle27 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties11 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore13 = new A.SpaceBefore();
            A.SpacingPercent spacingPercent7 = new A.SpacingPercent() { Val = 0 };

            spaceBefore13.Append(spacingPercent7);

            A.BulletColor bulletColor11 = new A.BulletColor();

            A.SchemeColor schemeColor78 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };
            A.LuminanceModulation luminanceModulation19 = new A.LuminanceModulation() { Val = 60000 };
            A.LuminanceOffset luminanceOffset17 = new A.LuminanceOffset() { Val = 40000 };

            schemeColor78.Append(luminanceModulation19);
            schemeColor78.Append(luminanceOffset17);

            bulletColor11.Append(schemeColor78);
            A.BulletSizePercentage bulletSizePercentage11 = new A.BulletSizePercentage() { Val = 110000 };
            A.BulletFont bulletFont11 = new A.BulletFont() { Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2 };
            A.NoBullet noBullet14 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties48 = new A.DefaultRunProperties() { FontSize = 4600, Kerning = 1200 };

            A.SolidFill solidFill49 = new A.SolidFill();
            A.SchemeColor schemeColor79 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            solidFill49.Append(schemeColor79);
            A.LatinFont latinFont33 = new A.LatinFont() { Typeface = "+mj-lt" };
            A.EastAsianFont eastAsianFont33 = new A.EastAsianFont() { Typeface = "+mj-ea" };
            A.ComplexScriptFont complexScriptFont33 = new A.ComplexScriptFont() { Typeface = "+mj-cs" };

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

            A.Paragraph paragraph37 = new A.Paragraph();

            A.Run run23 = new A.Run();

            A.RunProperties runProperties31 = new A.RunProperties() { Language = "en-US" };
            runProperties31.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text31 = new A.Text();
            text31.Text = "Click to edit Master title style";

            run23.Append(runProperties31);
            run23.Append(text31);
            A.EndParagraphRunProperties endParagraphRunProperties25 = new A.EndParagraphRunProperties();

            paragraph37.Append(run23);
            paragraph37.Append(endParagraphRunProperties25);

            textBody25.Append(bodyProperties27);
            textBody25.Append(listStyle27);
            textBody25.Append(paragraph37);

            shape25.Append(nonVisualShapeProperties25);
            shape25.Append(shapeProperties27);
            shape25.Append(textBody25);

            Shape shape26 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties26 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties32 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Subtitle 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties26 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks24 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties26.Append(shapeLocks24);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties32 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape23 = new PlaceholderShape() { Type = PlaceholderValues.SubTitle, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties32.Append(placeholderShape23);

            nonVisualShapeProperties26.Append(nonVisualDrawingProperties32);
            nonVisualShapeProperties26.Append(nonVisualShapeDrawingProperties26);
            nonVisualShapeProperties26.Append(applicationNonVisualDrawingProperties32);

            ShapeProperties shapeProperties28 = new ShapeProperties();

            A.Transform2D transform2D15 = new A.Transform2D();
            A.Offset offset21 = new A.Offset() { X = 1322921L, Y = 3299012L };
            A.Extents extents21 = new A.Extents() { Cx = 6498159L, Cy = 916641L };

            transform2D15.Append(offset21);
            transform2D15.Append(extents21);

            shapeProperties28.Append(transform2D15);

            TextBody textBody26 = new TextBody();

            A.BodyProperties bodyProperties28 = new A.BodyProperties() { Vertical = A.TextVerticalValues.Horizontal, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, RightToLeftColumns = false };
            A.NormalAutoFit normalAutoFit3 = new A.NormalAutoFit();

            bodyProperties28.Append(normalAutoFit3);

            A.ListStyle listStyle28 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties12 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore14 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints7 = new A.SpacingPoints() { Val = 300 };

            spaceBefore14.Append(spacingPoints7);

            A.BulletColor bulletColor12 = new A.BulletColor();

            A.SchemeColor schemeColor80 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };
            A.LuminanceModulation luminanceModulation20 = new A.LuminanceModulation() { Val = 60000 };
            A.LuminanceOffset luminanceOffset18 = new A.LuminanceOffset() { Val = 40000 };

            schemeColor80.Append(luminanceModulation20);
            schemeColor80.Append(luminanceOffset18);

            bulletColor12.Append(schemeColor80);
            A.BulletSizePercentage bulletSizePercentage12 = new A.BulletSizePercentage() { Val = 110000 };
            A.BulletFont bulletFont12 = new A.BulletFont() { Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2 };
            A.NoBullet noBullet15 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties49 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill50 = new A.SolidFill();

            A.SchemeColor schemeColor81 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint17 = new A.Tint() { Val = 75000 };

            schemeColor81.Append(tint17);

            solidFill50.Append(schemeColor81);
            A.LatinFont latinFont34 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont34 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont34 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

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

            A.Level2ParagraphProperties level2ParagraphProperties5 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet16 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties50 = new A.DefaultRunProperties();

            A.SolidFill solidFill51 = new A.SolidFill();

            A.SchemeColor schemeColor82 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint18 = new A.Tint() { Val = 75000 };

            schemeColor82.Append(tint18);

            solidFill51.Append(schemeColor82);

            defaultRunProperties50.Append(solidFill51);

            level2ParagraphProperties5.Append(noBullet16);
            level2ParagraphProperties5.Append(defaultRunProperties50);

            A.Level3ParagraphProperties level3ParagraphProperties5 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet17 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties51 = new A.DefaultRunProperties();

            A.SolidFill solidFill52 = new A.SolidFill();

            A.SchemeColor schemeColor83 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint19 = new A.Tint() { Val = 75000 };

            schemeColor83.Append(tint19);

            solidFill52.Append(schemeColor83);

            defaultRunProperties51.Append(solidFill52);

            level3ParagraphProperties5.Append(noBullet17);
            level3ParagraphProperties5.Append(defaultRunProperties51);

            A.Level4ParagraphProperties level4ParagraphProperties5 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet18 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties52 = new A.DefaultRunProperties();

            A.SolidFill solidFill53 = new A.SolidFill();

            A.SchemeColor schemeColor84 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint20 = new A.Tint() { Val = 75000 };

            schemeColor84.Append(tint20);

            solidFill53.Append(schemeColor84);

            defaultRunProperties52.Append(solidFill53);

            level4ParagraphProperties5.Append(noBullet18);
            level4ParagraphProperties5.Append(defaultRunProperties52);

            A.Level5ParagraphProperties level5ParagraphProperties7 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet19 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties53 = new A.DefaultRunProperties();

            A.SolidFill solidFill54 = new A.SolidFill();

            A.SchemeColor schemeColor85 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint21 = new A.Tint() { Val = 75000 };

            schemeColor85.Append(tint21);

            solidFill54.Append(schemeColor85);

            defaultRunProperties53.Append(solidFill54);

            level5ParagraphProperties7.Append(noBullet19);
            level5ParagraphProperties7.Append(defaultRunProperties53);

            A.Level6ParagraphProperties level6ParagraphProperties5 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet20 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties54 = new A.DefaultRunProperties();

            A.SolidFill solidFill55 = new A.SolidFill();

            A.SchemeColor schemeColor86 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint22 = new A.Tint() { Val = 75000 };

            schemeColor86.Append(tint22);

            solidFill55.Append(schemeColor86);

            defaultRunProperties54.Append(solidFill55);

            level6ParagraphProperties5.Append(noBullet20);
            level6ParagraphProperties5.Append(defaultRunProperties54);

            A.Level7ParagraphProperties level7ParagraphProperties5 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet21 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties55 = new A.DefaultRunProperties();

            A.SolidFill solidFill56 = new A.SolidFill();

            A.SchemeColor schemeColor87 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint23 = new A.Tint() { Val = 75000 };

            schemeColor87.Append(tint23);

            solidFill56.Append(schemeColor87);

            defaultRunProperties55.Append(solidFill56);

            level7ParagraphProperties5.Append(noBullet21);
            level7ParagraphProperties5.Append(defaultRunProperties55);

            A.Level8ParagraphProperties level8ParagraphProperties5 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet22 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties56 = new A.DefaultRunProperties();

            A.SolidFill solidFill57 = new A.SolidFill();

            A.SchemeColor schemeColor88 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint24 = new A.Tint() { Val = 75000 };

            schemeColor88.Append(tint24);

            solidFill57.Append(schemeColor88);

            defaultRunProperties56.Append(solidFill57);

            level8ParagraphProperties5.Append(noBullet22);
            level8ParagraphProperties5.Append(defaultRunProperties56);

            A.Level9ParagraphProperties level9ParagraphProperties5 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet23 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties57 = new A.DefaultRunProperties();

            A.SolidFill solidFill58 = new A.SolidFill();

            A.SchemeColor schemeColor89 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint25 = new A.Tint() { Val = 75000 };

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

            A.Paragraph paragraph38 = new A.Paragraph();

            A.Run run24 = new A.Run();

            A.RunProperties runProperties32 = new A.RunProperties() { Language = "en-US" };
            runProperties32.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text32 = new A.Text();
            text32.Text = "Click to edit Master subtitle style";

            run24.Append(runProperties32);
            run24.Append(text32);
            A.EndParagraphRunProperties endParagraphRunProperties26 = new A.EndParagraphRunProperties() { Dirty = false };

            paragraph38.Append(run24);
            paragraph38.Append(endParagraphRunProperties26);

            textBody26.Append(bodyProperties28);
            textBody26.Append(listStyle28);
            textBody26.Append(paragraph38);

            shape26.Append(nonVisualShapeProperties26);
            shape26.Append(shapeProperties28);
            shape26.Append(textBody26);

            Shape shape27 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties27 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties33 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Date Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties27 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks25 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties27.Append(shapeLocks25);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties33 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape24 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties33.Append(placeholderShape24);

            nonVisualShapeProperties27.Append(nonVisualDrawingProperties33);
            nonVisualShapeProperties27.Append(nonVisualShapeDrawingProperties27);
            nonVisualShapeProperties27.Append(applicationNonVisualDrawingProperties33);
            ShapeProperties shapeProperties29 = new ShapeProperties();

            TextBody textBody27 = new TextBody();
            A.BodyProperties bodyProperties29 = new A.BodyProperties();
            A.ListStyle listStyle29 = new A.ListStyle();

            A.Paragraph paragraph39 = new A.Paragraph();

            A.Field field9 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties33 = new A.RunProperties() { Language = "en-US" };
            runProperties33.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties27 = new A.ParagraphProperties();
            A.Text text33 = new A.Text();
            text33.Text = "29/11/13";

            field9.Append(runProperties33);
            field9.Append(paragraphProperties27);
            field9.Append(text33);
            A.EndParagraphRunProperties endParagraphRunProperties27 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph39.Append(field9);
            paragraph39.Append(endParagraphRunProperties27);

            textBody27.Append(bodyProperties29);
            textBody27.Append(listStyle29);
            textBody27.Append(paragraph39);

            shape27.Append(nonVisualShapeProperties27);
            shape27.Append(shapeProperties29);
            shape27.Append(textBody27);

            Shape shape28 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties28 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties34 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Footer Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties28 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks26 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties28.Append(shapeLocks26);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties34 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape25 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties34.Append(placeholderShape25);

            nonVisualShapeProperties28.Append(nonVisualDrawingProperties34);
            nonVisualShapeProperties28.Append(nonVisualShapeDrawingProperties28);
            nonVisualShapeProperties28.Append(applicationNonVisualDrawingProperties34);
            ShapeProperties shapeProperties30 = new ShapeProperties();

            TextBody textBody28 = new TextBody();
            A.BodyProperties bodyProperties30 = new A.BodyProperties();
            A.ListStyle listStyle30 = new A.ListStyle();

            A.Paragraph paragraph40 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties28 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph40.Append(endParagraphRunProperties28);

            textBody28.Append(bodyProperties30);
            textBody28.Append(listStyle30);
            textBody28.Append(paragraph40);

            shape28.Append(nonVisualShapeProperties28);
            shape28.Append(shapeProperties30);
            shape28.Append(textBody28);

            Shape shape29 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties29 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties35 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Slide Number Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties29 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks27 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties29.Append(shapeLocks27);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties35 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape26 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties35.Append(placeholderShape26);

            nonVisualShapeProperties29.Append(nonVisualDrawingProperties35);
            nonVisualShapeProperties29.Append(nonVisualShapeDrawingProperties29);
            nonVisualShapeProperties29.Append(applicationNonVisualDrawingProperties35);
            ShapeProperties shapeProperties31 = new ShapeProperties();

            TextBody textBody29 = new TextBody();
            A.BodyProperties bodyProperties31 = new A.BodyProperties();
            A.ListStyle listStyle31 = new A.ListStyle();

            A.Paragraph paragraph41 = new A.Paragraph();

            A.Field field10 = new A.Field() { Id = "{7F5CE407-6216-4202-80E4-A30DC2F709B2}", Type = "slidenum" };

            A.RunProperties runProperties34 = new A.RunProperties() { Language = "en-US" };
            runProperties34.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text34 = new A.Text();
            text34.Text = "‹#›";

            field10.Append(runProperties34);
            field10.Append(text34);
            A.EndParagraphRunProperties endParagraphRunProperties29 = new A.EndParagraphRunProperties() { Language = "en-US" };

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

            ColorMapOverride colorMapOverride5 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping5 = new A.MasterColorMapping();

            colorMapOverride5.Append(masterColorMapping5);

            slideLayout4.Append(commonSlideData6);
            slideLayout4.Append(colorMapOverride5);

            slideLayoutPart4.SlideLayout = slideLayout4;
        }

        // Generates content of slideLayoutPart5.
        private void GenerateSlideLayoutPart5Content(SlideLayoutPart slideLayoutPart5)
        {
            SlideLayout slideLayout5 = new SlideLayout() { Type = SlideLayoutValues.Object, Preserve = true };
            slideLayout5.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout5.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout5.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData7 = new CommonSlideData() { Name = "Title and Content" };

            ShapeTree shapeTree7 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties7 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties36 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties7 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties36 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties7.Append(nonVisualDrawingProperties36);
            nonVisualGroupShapeProperties7.Append(nonVisualGroupShapeDrawingProperties7);
            nonVisualGroupShapeProperties7.Append(applicationNonVisualDrawingProperties36);

            GroupShapeProperties groupShapeProperties7 = new GroupShapeProperties();

            A.TransformGroup transformGroup7 = new A.TransformGroup();
            A.Offset offset22 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents22 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset7 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents7 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup7.Append(offset22);
            transformGroup7.Append(extents22);
            transformGroup7.Append(childOffset7);
            transformGroup7.Append(childExtents7);

            groupShapeProperties7.Append(transformGroup7);

            Shape shape30 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties30 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties37 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties30 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks28 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties30.Append(shapeLocks28);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties37 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape27 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties37.Append(placeholderShape27);

            nonVisualShapeProperties30.Append(nonVisualDrawingProperties37);
            nonVisualShapeProperties30.Append(nonVisualShapeDrawingProperties30);
            nonVisualShapeProperties30.Append(applicationNonVisualDrawingProperties37);
            ShapeProperties shapeProperties32 = new ShapeProperties();

            TextBody textBody30 = new TextBody();
            A.BodyProperties bodyProperties32 = new A.BodyProperties();
            A.ListStyle listStyle32 = new A.ListStyle();

            A.Paragraph paragraph42 = new A.Paragraph();

            A.Run run25 = new A.Run();

            A.RunProperties runProperties35 = new A.RunProperties() { Language = "en-US" };
            runProperties35.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text35 = new A.Text();
            text35.Text = "Click to edit Master title style";

            run25.Append(runProperties35);
            run25.Append(text35);
            A.EndParagraphRunProperties endParagraphRunProperties30 = new A.EndParagraphRunProperties();

            paragraph42.Append(run25);
            paragraph42.Append(endParagraphRunProperties30);

            textBody30.Append(bodyProperties32);
            textBody30.Append(listStyle32);
            textBody30.Append(paragraph42);

            shape30.Append(nonVisualShapeProperties30);
            shape30.Append(shapeProperties32);
            shape30.Append(textBody30);

            Shape shape31 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties31 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties38 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Content Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties31 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks29 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties31.Append(shapeLocks29);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties38 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape28 = new PlaceholderShape() { Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties38.Append(placeholderShape28);

            nonVisualShapeProperties31.Append(nonVisualDrawingProperties38);
            nonVisualShapeProperties31.Append(nonVisualShapeDrawingProperties31);
            nonVisualShapeProperties31.Append(applicationNonVisualDrawingProperties38);
            ShapeProperties shapeProperties33 = new ShapeProperties();

            TextBody textBody31 = new TextBody();
            A.BodyProperties bodyProperties33 = new A.BodyProperties();

            A.ListStyle listStyle33 = new A.ListStyle();

            A.Level5ParagraphProperties level5ParagraphProperties8 = new A.Level5ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties58 = new A.DefaultRunProperties();

            level5ParagraphProperties8.Append(defaultRunProperties58);

            listStyle33.Append(level5ParagraphProperties8);

            A.Paragraph paragraph43 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties28 = new A.ParagraphProperties() { Level = 0 };

            A.Run run26 = new A.Run();

            A.RunProperties runProperties36 = new A.RunProperties() { Language = "en-US" };
            runProperties36.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text36 = new A.Text();
            text36.Text = "Click to edit Master text styles";

            run26.Append(runProperties36);
            run26.Append(text36);

            paragraph43.Append(paragraphProperties28);
            paragraph43.Append(run26);

            A.Paragraph paragraph44 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties29 = new A.ParagraphProperties() { Level = 1 };

            A.Run run27 = new A.Run();

            A.RunProperties runProperties37 = new A.RunProperties() { Language = "en-US" };
            runProperties37.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text37 = new A.Text();
            text37.Text = "Second level";

            run27.Append(runProperties37);
            run27.Append(text37);

            paragraph44.Append(paragraphProperties29);
            paragraph44.Append(run27);

            A.Paragraph paragraph45 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties30 = new A.ParagraphProperties() { Level = 2 };

            A.Run run28 = new A.Run();

            A.RunProperties runProperties38 = new A.RunProperties() { Language = "en-US" };
            runProperties38.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text38 = new A.Text();
            text38.Text = "Third level";

            run28.Append(runProperties38);
            run28.Append(text38);

            paragraph45.Append(paragraphProperties30);
            paragraph45.Append(run28);

            A.Paragraph paragraph46 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties31 = new A.ParagraphProperties() { Level = 3 };

            A.Run run29 = new A.Run();

            A.RunProperties runProperties39 = new A.RunProperties() { Language = "en-US" };
            runProperties39.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text39 = new A.Text();
            text39.Text = "Fourth level";

            run29.Append(runProperties39);
            run29.Append(text39);

            paragraph46.Append(paragraphProperties31);
            paragraph46.Append(run29);

            A.Paragraph paragraph47 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties32 = new A.ParagraphProperties() { Level = 4 };

            A.Run run30 = new A.Run();

            A.RunProperties runProperties40 = new A.RunProperties() { Language = "en-US" };
            runProperties40.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text40 = new A.Text();
            text40.Text = "Fifth level";

            run30.Append(runProperties40);
            run30.Append(text40);
            A.EndParagraphRunProperties endParagraphRunProperties31 = new A.EndParagraphRunProperties() { Dirty = false };

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

            Shape shape32 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties32 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties39 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Date Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties32 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks30 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties32.Append(shapeLocks30);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties39 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape29 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties39.Append(placeholderShape29);

            nonVisualShapeProperties32.Append(nonVisualDrawingProperties39);
            nonVisualShapeProperties32.Append(nonVisualShapeDrawingProperties32);
            nonVisualShapeProperties32.Append(applicationNonVisualDrawingProperties39);
            ShapeProperties shapeProperties34 = new ShapeProperties();

            TextBody textBody32 = new TextBody();
            A.BodyProperties bodyProperties34 = new A.BodyProperties();
            A.ListStyle listStyle34 = new A.ListStyle();

            A.Paragraph paragraph48 = new A.Paragraph();

            A.Field field11 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties41 = new A.RunProperties() { Language = "en-US" };
            runProperties41.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties33 = new A.ParagraphProperties();
            A.Text text41 = new A.Text();
            text41.Text = "29/11/13";

            field11.Append(runProperties41);
            field11.Append(paragraphProperties33);
            field11.Append(text41);
            A.EndParagraphRunProperties endParagraphRunProperties32 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph48.Append(field11);
            paragraph48.Append(endParagraphRunProperties32);

            textBody32.Append(bodyProperties34);
            textBody32.Append(listStyle34);
            textBody32.Append(paragraph48);

            shape32.Append(nonVisualShapeProperties32);
            shape32.Append(shapeProperties34);
            shape32.Append(textBody32);

            Shape shape33 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties33 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties40 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Footer Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties33 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks31 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties33.Append(shapeLocks31);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties40 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape30 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties40.Append(placeholderShape30);

            nonVisualShapeProperties33.Append(nonVisualDrawingProperties40);
            nonVisualShapeProperties33.Append(nonVisualShapeDrawingProperties33);
            nonVisualShapeProperties33.Append(applicationNonVisualDrawingProperties40);
            ShapeProperties shapeProperties35 = new ShapeProperties();

            TextBody textBody33 = new TextBody();
            A.BodyProperties bodyProperties35 = new A.BodyProperties();
            A.ListStyle listStyle35 = new A.ListStyle();

            A.Paragraph paragraph49 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties33 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph49.Append(endParagraphRunProperties33);

            textBody33.Append(bodyProperties35);
            textBody33.Append(listStyle35);
            textBody33.Append(paragraph49);

            shape33.Append(nonVisualShapeProperties33);
            shape33.Append(shapeProperties35);
            shape33.Append(textBody33);

            Shape shape34 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties34 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties41 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Slide Number Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties34 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks32 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties34.Append(shapeLocks32);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties41 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape31 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties41.Append(placeholderShape31);

            nonVisualShapeProperties34.Append(nonVisualDrawingProperties41);
            nonVisualShapeProperties34.Append(nonVisualShapeDrawingProperties34);
            nonVisualShapeProperties34.Append(applicationNonVisualDrawingProperties41);
            ShapeProperties shapeProperties36 = new ShapeProperties();

            TextBody textBody34 = new TextBody();
            A.BodyProperties bodyProperties36 = new A.BodyProperties();
            A.ListStyle listStyle36 = new A.ListStyle();

            A.Paragraph paragraph50 = new A.Paragraph();

            A.Field field12 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties42 = new A.RunProperties() { Language = "en-US" };
            runProperties42.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties34 = new A.ParagraphProperties();
            A.Text text42 = new A.Text();
            text42.Text = "‹#›";

            field12.Append(runProperties42);
            field12.Append(paragraphProperties34);
            field12.Append(text42);
            A.EndParagraphRunProperties endParagraphRunProperties34 = new A.EndParagraphRunProperties() { Language = "en-US" };

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

            ColorMapOverride colorMapOverride6 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping6 = new A.MasterColorMapping();

            colorMapOverride6.Append(masterColorMapping6);

            slideLayout5.Append(commonSlideData7);
            slideLayout5.Append(colorMapOverride6);

            slideLayoutPart5.SlideLayout = slideLayout5;
        }

        // Generates content of slideLayoutPart6.
        private void GenerateSlideLayoutPart6Content(SlideLayoutPart slideLayoutPart6)
        {
            SlideLayout slideLayout6 = new SlideLayout() { Preserve = true };
            slideLayout6.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout6.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout6.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData8 = new CommonSlideData() { Name = "Title Slide with Picture" };

            ShapeTree shapeTree8 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties8 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties42 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties8 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties42 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties8.Append(nonVisualDrawingProperties42);
            nonVisualGroupShapeProperties8.Append(nonVisualGroupShapeDrawingProperties8);
            nonVisualGroupShapeProperties8.Append(applicationNonVisualDrawingProperties42);

            GroupShapeProperties groupShapeProperties8 = new GroupShapeProperties();

            A.TransformGroup transformGroup8 = new A.TransformGroup();
            A.Offset offset23 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents23 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset8 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents8 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup8.Append(offset23);
            transformGroup8.Append(extents23);
            transformGroup8.Append(childOffset8);
            transformGroup8.Append(childExtents8);

            groupShapeProperties8.Append(transformGroup8);

            Shape shape35 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties35 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties43 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties35 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks33 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties35.Append(shapeLocks33);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties43 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape32 = new PlaceholderShape() { Type = PlaceholderValues.CenteredTitle };

            applicationNonVisualDrawingProperties43.Append(placeholderShape32);

            nonVisualShapeProperties35.Append(nonVisualDrawingProperties43);
            nonVisualShapeProperties35.Append(nonVisualShapeDrawingProperties35);
            nonVisualShapeProperties35.Append(applicationNonVisualDrawingProperties43);

            ShapeProperties shapeProperties37 = new ShapeProperties();

            A.Transform2D transform2D16 = new A.Transform2D();
            A.Offset offset24 = new A.Offset() { X = 363538L, Y = 3352801L };
            A.Extents extents24 = new A.Extents() { Cx = 8416925L, Cy = 1470025L };

            transform2D16.Append(offset24);
            transform2D16.Append(extents24);

            shapeProperties37.Append(transform2D16);

            TextBody textBody35 = new TextBody();
            A.BodyProperties bodyProperties37 = new A.BodyProperties();
            A.ListStyle listStyle37 = new A.ListStyle();

            A.Paragraph paragraph51 = new A.Paragraph();

            A.Run run31 = new A.Run();

            A.RunProperties runProperties43 = new A.RunProperties() { Language = "en-US" };
            runProperties43.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text43 = new A.Text();
            text43.Text = "Click to edit Master title style";

            run31.Append(runProperties43);
            run31.Append(text43);
            A.EndParagraphRunProperties endParagraphRunProperties35 = new A.EndParagraphRunProperties() { Dirty = false };

            paragraph51.Append(run31);
            paragraph51.Append(endParagraphRunProperties35);

            textBody35.Append(bodyProperties37);
            textBody35.Append(listStyle37);
            textBody35.Append(paragraph51);

            shape35.Append(nonVisualShapeProperties35);
            shape35.Append(shapeProperties37);
            shape35.Append(textBody35);

            Shape shape36 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties36 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties44 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Subtitle 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties36 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks34 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties36.Append(shapeLocks34);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties44 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape33 = new PlaceholderShape() { Type = PlaceholderValues.SubTitle, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties44.Append(placeholderShape33);

            nonVisualShapeProperties36.Append(nonVisualDrawingProperties44);
            nonVisualShapeProperties36.Append(nonVisualShapeDrawingProperties36);
            nonVisualShapeProperties36.Append(applicationNonVisualDrawingProperties44);

            ShapeProperties shapeProperties38 = new ShapeProperties();

            A.Transform2D transform2D17 = new A.Transform2D();
            A.Offset offset25 = new A.Offset() { X = 363538L, Y = 4771029L };
            A.Extents extents25 = new A.Extents() { Cx = 8416925L, Cy = 972671L };

            transform2D17.Append(offset25);
            transform2D17.Append(extents25);

            shapeProperties38.Append(transform2D17);

            TextBody textBody36 = new TextBody();

            A.BodyProperties bodyProperties38 = new A.BodyProperties();
            A.NormalAutoFit normalAutoFit4 = new A.NormalAutoFit();

            bodyProperties38.Append(normalAutoFit4);

            A.ListStyle listStyle38 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties13 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };

            A.SpaceBefore spaceBefore15 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints8 = new A.SpacingPoints() { Val = 300 };

            spaceBefore15.Append(spacingPoints8);
            A.NoBullet noBullet24 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties59 = new A.DefaultRunProperties() { FontSize = 1800 };

            A.SolidFill solidFill59 = new A.SolidFill();

            A.SchemeColor schemeColor90 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint26 = new A.Tint() { Val = 75000 };

            schemeColor90.Append(tint26);

            solidFill59.Append(schemeColor90);

            defaultRunProperties59.Append(solidFill59);

            level1ParagraphProperties13.Append(spaceBefore15);
            level1ParagraphProperties13.Append(noBullet24);
            level1ParagraphProperties13.Append(defaultRunProperties59);

            A.Level2ParagraphProperties level2ParagraphProperties6 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet25 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties60 = new A.DefaultRunProperties();

            A.SolidFill solidFill60 = new A.SolidFill();

            A.SchemeColor schemeColor91 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint27 = new A.Tint() { Val = 75000 };

            schemeColor91.Append(tint27);

            solidFill60.Append(schemeColor91);

            defaultRunProperties60.Append(solidFill60);

            level2ParagraphProperties6.Append(noBullet25);
            level2ParagraphProperties6.Append(defaultRunProperties60);

            A.Level3ParagraphProperties level3ParagraphProperties6 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet26 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties61 = new A.DefaultRunProperties();

            A.SolidFill solidFill61 = new A.SolidFill();

            A.SchemeColor schemeColor92 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint28 = new A.Tint() { Val = 75000 };

            schemeColor92.Append(tint28);

            solidFill61.Append(schemeColor92);

            defaultRunProperties61.Append(solidFill61);

            level3ParagraphProperties6.Append(noBullet26);
            level3ParagraphProperties6.Append(defaultRunProperties61);

            A.Level4ParagraphProperties level4ParagraphProperties6 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet27 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties62 = new A.DefaultRunProperties();

            A.SolidFill solidFill62 = new A.SolidFill();

            A.SchemeColor schemeColor93 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint29 = new A.Tint() { Val = 75000 };

            schemeColor93.Append(tint29);

            solidFill62.Append(schemeColor93);

            defaultRunProperties62.Append(solidFill62);

            level4ParagraphProperties6.Append(noBullet27);
            level4ParagraphProperties6.Append(defaultRunProperties62);

            A.Level5ParagraphProperties level5ParagraphProperties9 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet28 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties63 = new A.DefaultRunProperties();

            A.SolidFill solidFill63 = new A.SolidFill();

            A.SchemeColor schemeColor94 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint30 = new A.Tint() { Val = 75000 };

            schemeColor94.Append(tint30);

            solidFill63.Append(schemeColor94);

            defaultRunProperties63.Append(solidFill63);

            level5ParagraphProperties9.Append(noBullet28);
            level5ParagraphProperties9.Append(defaultRunProperties63);

            A.Level6ParagraphProperties level6ParagraphProperties6 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet29 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties64 = new A.DefaultRunProperties();

            A.SolidFill solidFill64 = new A.SolidFill();

            A.SchemeColor schemeColor95 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint31 = new A.Tint() { Val = 75000 };

            schemeColor95.Append(tint31);

            solidFill64.Append(schemeColor95);

            defaultRunProperties64.Append(solidFill64);

            level6ParagraphProperties6.Append(noBullet29);
            level6ParagraphProperties6.Append(defaultRunProperties64);

            A.Level7ParagraphProperties level7ParagraphProperties6 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet30 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties65 = new A.DefaultRunProperties();

            A.SolidFill solidFill65 = new A.SolidFill();

            A.SchemeColor schemeColor96 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint32 = new A.Tint() { Val = 75000 };

            schemeColor96.Append(tint32);

            solidFill65.Append(schemeColor96);

            defaultRunProperties65.Append(solidFill65);

            level7ParagraphProperties6.Append(noBullet30);
            level7ParagraphProperties6.Append(defaultRunProperties65);

            A.Level8ParagraphProperties level8ParagraphProperties6 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet31 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties66 = new A.DefaultRunProperties();

            A.SolidFill solidFill66 = new A.SolidFill();

            A.SchemeColor schemeColor97 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint33 = new A.Tint() { Val = 75000 };

            schemeColor97.Append(tint33);

            solidFill66.Append(schemeColor97);

            defaultRunProperties66.Append(solidFill66);

            level8ParagraphProperties6.Append(noBullet31);
            level8ParagraphProperties6.Append(defaultRunProperties66);

            A.Level9ParagraphProperties level9ParagraphProperties6 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet32 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties67 = new A.DefaultRunProperties();

            A.SolidFill solidFill67 = new A.SolidFill();

            A.SchemeColor schemeColor98 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint34 = new A.Tint() { Val = 75000 };

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

            A.Paragraph paragraph52 = new A.Paragraph();

            A.Run run32 = new A.Run();

            A.RunProperties runProperties44 = new A.RunProperties() { Language = "en-US" };
            runProperties44.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text44 = new A.Text();
            text44.Text = "Click to edit Master subtitle style";

            run32.Append(runProperties44);
            run32.Append(text44);
            A.EndParagraphRunProperties endParagraphRunProperties36 = new A.EndParagraphRunProperties() { Dirty = false };

            paragraph52.Append(run32);
            paragraph52.Append(endParagraphRunProperties36);

            textBody36.Append(bodyProperties38);
            textBody36.Append(listStyle38);
            textBody36.Append(paragraph52);

            shape36.Append(nonVisualShapeProperties36);
            shape36.Append(shapeProperties38);
            shape36.Append(textBody36);

            Shape shape37 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties37 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties45 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Date Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties37 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks35 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties37.Append(shapeLocks35);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties45 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape34 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties45.Append(placeholderShape34);

            nonVisualShapeProperties37.Append(nonVisualDrawingProperties45);
            nonVisualShapeProperties37.Append(nonVisualShapeDrawingProperties37);
            nonVisualShapeProperties37.Append(applicationNonVisualDrawingProperties45);
            ShapeProperties shapeProperties39 = new ShapeProperties();

            TextBody textBody37 = new TextBody();
            A.BodyProperties bodyProperties39 = new A.BodyProperties();
            A.ListStyle listStyle39 = new A.ListStyle();

            A.Paragraph paragraph53 = new A.Paragraph();

            A.Field field13 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties45 = new A.RunProperties() { Language = "en-US" };
            runProperties45.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties35 = new A.ParagraphProperties();
            A.Text text45 = new A.Text();
            text45.Text = "29/11/13";

            field13.Append(runProperties45);
            field13.Append(paragraphProperties35);
            field13.Append(text45);
            A.EndParagraphRunProperties endParagraphRunProperties37 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph53.Append(field13);
            paragraph53.Append(endParagraphRunProperties37);

            textBody37.Append(bodyProperties39);
            textBody37.Append(listStyle39);
            textBody37.Append(paragraph53);

            shape37.Append(nonVisualShapeProperties37);
            shape37.Append(shapeProperties39);
            shape37.Append(textBody37);

            Shape shape38 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties38 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties46 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Footer Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties38 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks36 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties38.Append(shapeLocks36);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties46 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape35 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties46.Append(placeholderShape35);

            nonVisualShapeProperties38.Append(nonVisualDrawingProperties46);
            nonVisualShapeProperties38.Append(nonVisualShapeDrawingProperties38);
            nonVisualShapeProperties38.Append(applicationNonVisualDrawingProperties46);
            ShapeProperties shapeProperties40 = new ShapeProperties();

            TextBody textBody38 = new TextBody();
            A.BodyProperties bodyProperties40 = new A.BodyProperties();
            A.ListStyle listStyle40 = new A.ListStyle();

            A.Paragraph paragraph54 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties38 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph54.Append(endParagraphRunProperties38);

            textBody38.Append(bodyProperties40);
            textBody38.Append(listStyle40);
            textBody38.Append(paragraph54);

            shape38.Append(nonVisualShapeProperties38);
            shape38.Append(shapeProperties40);
            shape38.Append(textBody38);

            Shape shape39 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties39 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties47 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Slide Number Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties39 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks37 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties39.Append(shapeLocks37);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties47 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape36 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties47.Append(placeholderShape36);

            nonVisualShapeProperties39.Append(nonVisualDrawingProperties47);
            nonVisualShapeProperties39.Append(nonVisualShapeDrawingProperties39);
            nonVisualShapeProperties39.Append(applicationNonVisualDrawingProperties47);
            ShapeProperties shapeProperties41 = new ShapeProperties();

            TextBody textBody39 = new TextBody();
            A.BodyProperties bodyProperties41 = new A.BodyProperties();
            A.ListStyle listStyle41 = new A.ListStyle();

            A.Paragraph paragraph55 = new A.Paragraph();

            A.Field field14 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties46 = new A.RunProperties() { Language = "en-US" };
            runProperties46.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties36 = new A.ParagraphProperties();
            A.Text text46 = new A.Text();
            text46.Text = "‹#›";

            field14.Append(runProperties46);
            field14.Append(paragraphProperties36);
            field14.Append(text46);
            A.EndParagraphRunProperties endParagraphRunProperties39 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph55.Append(field14);
            paragraph55.Append(endParagraphRunProperties39);

            textBody39.Append(bodyProperties41);
            textBody39.Append(listStyle41);
            textBody39.Append(paragraph55);

            shape39.Append(nonVisualShapeProperties39);
            shape39.Append(shapeProperties41);
            shape39.Append(textBody39);

            Shape shape40 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties40 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties48 = new NonVisualDrawingProperties() { Id = (UInt32Value)9U, Name = "Picture Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties40 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks38 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties40.Append(shapeLocks38);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties48 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape37 = new PlaceholderShape() { Type = PlaceholderValues.Picture, Index = (UInt32Value)13U };

            applicationNonVisualDrawingProperties48.Append(placeholderShape37);

            nonVisualShapeProperties40.Append(nonVisualDrawingProperties48);
            nonVisualShapeProperties40.Append(nonVisualShapeDrawingProperties40);
            nonVisualShapeProperties40.Append(applicationNonVisualDrawingProperties48);

            ShapeProperties shapeProperties42 = new ShapeProperties();

            A.Transform2D transform2D18 = new A.Transform2D();
            A.Offset offset26 = new A.Offset() { X = 370980L, Y = 363538L };
            A.Extents extents26 = new A.Extents() { Cx = 8402040L, Cy = 2836862L };

            transform2D18.Append(offset26);
            transform2D18.Append(extents26);

            A.Outline outline5 = new A.Outline() { Width = 3175 };

            A.SolidFill solidFill68 = new A.SolidFill();
            A.SchemeColor schemeColor99 = new A.SchemeColor() { Val = A.SchemeColorValues.Background1 };

            solidFill68.Append(schemeColor99);

            outline5.Append(solidFill68);

            A.EffectList effectList5 = new A.EffectList();

            A.OuterShadow outerShadow4 = new A.OuterShadow() { BlurRadius = 63500L, HorizontalRatio = 100500, VerticalRatio = 100500, Alignment = A.RectangleAlignmentValues.Center, RotateWithShape = false };

            A.PresetColor presetColor2 = new A.PresetColor() { Val = A.PresetColorValues.Black };
            A.Alpha alpha5 = new A.Alpha() { Val = 50000 };

            presetColor2.Append(alpha5);

            outerShadow4.Append(presetColor2);

            effectList5.Append(outerShadow4);

            shapeProperties42.Append(transform2D18);
            shapeProperties42.Append(outline5);
            shapeProperties42.Append(effectList5);

            TextBody textBody40 = new TextBody();
            A.BodyProperties bodyProperties42 = new A.BodyProperties();

            A.ListStyle listStyle42 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties14 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0 };
            A.NoBullet noBullet33 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties68 = new A.DefaultRunProperties() { FontSize = 3200 };

            level1ParagraphProperties14.Append(noBullet33);
            level1ParagraphProperties14.Append(defaultRunProperties68);

            A.Level2ParagraphProperties level2ParagraphProperties7 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0 };
            A.NoBullet noBullet34 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties69 = new A.DefaultRunProperties() { FontSize = 2800 };

            level2ParagraphProperties7.Append(noBullet34);
            level2ParagraphProperties7.Append(defaultRunProperties69);

            A.Level3ParagraphProperties level3ParagraphProperties7 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0 };
            A.NoBullet noBullet35 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties70 = new A.DefaultRunProperties() { FontSize = 2400 };

            level3ParagraphProperties7.Append(noBullet35);
            level3ParagraphProperties7.Append(defaultRunProperties70);

            A.Level4ParagraphProperties level4ParagraphProperties7 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0 };
            A.NoBullet noBullet36 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties71 = new A.DefaultRunProperties() { FontSize = 2000 };

            level4ParagraphProperties7.Append(noBullet36);
            level4ParagraphProperties7.Append(defaultRunProperties71);

            A.Level5ParagraphProperties level5ParagraphProperties10 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0 };
            A.NoBullet noBullet37 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties72 = new A.DefaultRunProperties() { FontSize = 2000 };

            level5ParagraphProperties10.Append(noBullet37);
            level5ParagraphProperties10.Append(defaultRunProperties72);

            A.Level6ParagraphProperties level6ParagraphProperties7 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0 };
            A.NoBullet noBullet38 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties73 = new A.DefaultRunProperties() { FontSize = 2000 };

            level6ParagraphProperties7.Append(noBullet38);
            level6ParagraphProperties7.Append(defaultRunProperties73);

            A.Level7ParagraphProperties level7ParagraphProperties7 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0 };
            A.NoBullet noBullet39 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties74 = new A.DefaultRunProperties() { FontSize = 2000 };

            level7ParagraphProperties7.Append(noBullet39);
            level7ParagraphProperties7.Append(defaultRunProperties74);

            A.Level8ParagraphProperties level8ParagraphProperties7 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0 };
            A.NoBullet noBullet40 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties75 = new A.DefaultRunProperties() { FontSize = 2000 };

            level8ParagraphProperties7.Append(noBullet40);
            level8ParagraphProperties7.Append(defaultRunProperties75);

            A.Level9ParagraphProperties level9ParagraphProperties7 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0 };
            A.NoBullet noBullet41 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties76 = new A.DefaultRunProperties() { FontSize = 2000 };

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

            A.Paragraph paragraph56 = new A.Paragraph();

            A.Run run33 = new A.Run();

            A.RunProperties runProperties47 = new A.RunProperties() { Language = "en-US" };
            runProperties47.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text47 = new A.Text();
            text47.Text = "Drag picture to placeholder or click icon to add";

            run33.Append(runProperties47);
            run33.Append(text47);
            A.EndParagraphRunProperties endParagraphRunProperties40 = new A.EndParagraphRunProperties();

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

            ColorMapOverride colorMapOverride7 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping7 = new A.MasterColorMapping();

            colorMapOverride7.Append(masterColorMapping7);

            slideLayout6.Append(commonSlideData8);
            slideLayout6.Append(colorMapOverride7);

            slideLayoutPart6.SlideLayout = slideLayout6;
        }

        // Generates content of slideLayoutPart7.
        private void GenerateSlideLayoutPart7Content(SlideLayoutPart slideLayoutPart7)
        {
            SlideLayout slideLayout7 = new SlideLayout() { Type = SlideLayoutValues.SectionHeader, Preserve = true };
            slideLayout7.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout7.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout7.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData9 = new CommonSlideData() { Name = "Section Header" };

            ShapeTree shapeTree9 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties9 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties49 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties9 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties49 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties9.Append(nonVisualDrawingProperties49);
            nonVisualGroupShapeProperties9.Append(nonVisualGroupShapeDrawingProperties9);
            nonVisualGroupShapeProperties9.Append(applicationNonVisualDrawingProperties49);

            GroupShapeProperties groupShapeProperties9 = new GroupShapeProperties();

            A.TransformGroup transformGroup9 = new A.TransformGroup();
            A.Offset offset27 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents27 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset9 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents9 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup9.Append(offset27);
            transformGroup9.Append(extents27);
            transformGroup9.Append(childOffset9);
            transformGroup9.Append(childExtents9);

            groupShapeProperties9.Append(transformGroup9);

            Shape shape41 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties41 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties50 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties41 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks39 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties41.Append(shapeLocks39);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties50 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape38 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties50.Append(placeholderShape38);

            nonVisualShapeProperties41.Append(nonVisualDrawingProperties50);
            nonVisualShapeProperties41.Append(nonVisualShapeDrawingProperties41);
            nonVisualShapeProperties41.Append(applicationNonVisualDrawingProperties50);

            ShapeProperties shapeProperties43 = new ShapeProperties();

            A.Transform2D transform2D19 = new A.Transform2D();
            A.Offset offset28 = new A.Offset() { X = 549275L, Y = 2403144L };
            A.Extents extents28 = new A.Extents() { Cx = 8056563L, Cy = 1362075L };

            transform2D19.Append(offset28);
            transform2D19.Append(extents28);

            shapeProperties43.Append(transform2D19);

            TextBody textBody41 = new TextBody();
            A.BodyProperties bodyProperties43 = new A.BodyProperties() { Anchor = A.TextAnchoringTypeValues.Bottom, AnchorCenter = false };

            A.ListStyle listStyle43 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties15 = new A.Level1ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Center };
            A.DefaultRunProperties defaultRunProperties77 = new A.DefaultRunProperties() { FontSize = 4600, Bold = false, Capital = A.TextCapsValues.None, Baseline = 0 };

            level1ParagraphProperties15.Append(defaultRunProperties77);

            listStyle43.Append(level1ParagraphProperties15);

            A.Paragraph paragraph57 = new A.Paragraph();

            A.Run run34 = new A.Run();

            A.RunProperties runProperties48 = new A.RunProperties() { Language = "en-US" };
            runProperties48.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text48 = new A.Text();
            text48.Text = "Click to edit Master title style";

            run34.Append(runProperties48);
            run34.Append(text48);
            A.EndParagraphRunProperties endParagraphRunProperties41 = new A.EndParagraphRunProperties();

            paragraph57.Append(run34);
            paragraph57.Append(endParagraphRunProperties41);

            textBody41.Append(bodyProperties43);
            textBody41.Append(listStyle43);
            textBody41.Append(paragraph57);

            shape41.Append(nonVisualShapeProperties41);
            shape41.Append(shapeProperties43);
            shape41.Append(textBody41);

            Shape shape42 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties42 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties51 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Text Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties42 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks40 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties42.Append(shapeLocks40);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties51 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape39 = new PlaceholderShape() { Type = PlaceholderValues.Body, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties51.Append(placeholderShape39);

            nonVisualShapeProperties42.Append(nonVisualDrawingProperties51);
            nonVisualShapeProperties42.Append(nonVisualShapeDrawingProperties42);
            nonVisualShapeProperties42.Append(applicationNonVisualDrawingProperties51);

            ShapeProperties shapeProperties44 = new ShapeProperties();

            A.Transform2D transform2D20 = new A.Transform2D();
            A.Offset offset29 = new A.Offset() { X = 549275L, Y = 3736005L };
            A.Extents extents29 = new A.Extents() { Cx = 8056563L, Cy = 1500187L };

            transform2D20.Append(offset29);
            transform2D20.Append(extents29);

            shapeProperties44.Append(transform2D20);

            TextBody textBody42 = new TextBody();

            A.BodyProperties bodyProperties44 = new A.BodyProperties() { Anchor = A.TextAnchoringTypeValues.Top, AnchorCenter = false };
            A.NormalAutoFit normalAutoFit5 = new A.NormalAutoFit();

            bodyProperties44.Append(normalAutoFit5);

            A.ListStyle listStyle44 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties16 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };

            A.SpaceBefore spaceBefore16 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints9 = new A.SpacingPoints() { Val = 300 };

            spaceBefore16.Append(spacingPoints9);
            A.NoBullet noBullet42 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties78 = new A.DefaultRunProperties() { FontSize = 1800 };

            A.SolidFill solidFill69 = new A.SolidFill();

            A.SchemeColor schemeColor100 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint35 = new A.Tint() { Val = 75000 };

            schemeColor100.Append(tint35);

            solidFill69.Append(schemeColor100);

            defaultRunProperties78.Append(solidFill69);

            level1ParagraphProperties16.Append(spaceBefore16);
            level1ParagraphProperties16.Append(noBullet42);
            level1ParagraphProperties16.Append(defaultRunProperties78);

            A.Level2ParagraphProperties level2ParagraphProperties8 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0 };
            A.NoBullet noBullet43 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties79 = new A.DefaultRunProperties() { FontSize = 1800 };

            A.SolidFill solidFill70 = new A.SolidFill();

            A.SchemeColor schemeColor101 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint36 = new A.Tint() { Val = 75000 };

            schemeColor101.Append(tint36);

            solidFill70.Append(schemeColor101);

            defaultRunProperties79.Append(solidFill70);

            level2ParagraphProperties8.Append(noBullet43);
            level2ParagraphProperties8.Append(defaultRunProperties79);

            A.Level3ParagraphProperties level3ParagraphProperties8 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0 };
            A.NoBullet noBullet44 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties80 = new A.DefaultRunProperties() { FontSize = 1600 };

            A.SolidFill solidFill71 = new A.SolidFill();

            A.SchemeColor schemeColor102 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint37 = new A.Tint() { Val = 75000 };

            schemeColor102.Append(tint37);

            solidFill71.Append(schemeColor102);

            defaultRunProperties80.Append(solidFill71);

            level3ParagraphProperties8.Append(noBullet44);
            level3ParagraphProperties8.Append(defaultRunProperties80);

            A.Level4ParagraphProperties level4ParagraphProperties8 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0 };
            A.NoBullet noBullet45 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties81 = new A.DefaultRunProperties() { FontSize = 1400 };

            A.SolidFill solidFill72 = new A.SolidFill();

            A.SchemeColor schemeColor103 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint38 = new A.Tint() { Val = 75000 };

            schemeColor103.Append(tint38);

            solidFill72.Append(schemeColor103);

            defaultRunProperties81.Append(solidFill72);

            level4ParagraphProperties8.Append(noBullet45);
            level4ParagraphProperties8.Append(defaultRunProperties81);

            A.Level5ParagraphProperties level5ParagraphProperties11 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0 };
            A.NoBullet noBullet46 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties82 = new A.DefaultRunProperties() { FontSize = 1400 };

            A.SolidFill solidFill73 = new A.SolidFill();

            A.SchemeColor schemeColor104 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint39 = new A.Tint() { Val = 75000 };

            schemeColor104.Append(tint39);

            solidFill73.Append(schemeColor104);

            defaultRunProperties82.Append(solidFill73);

            level5ParagraphProperties11.Append(noBullet46);
            level5ParagraphProperties11.Append(defaultRunProperties82);

            A.Level6ParagraphProperties level6ParagraphProperties8 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0 };
            A.NoBullet noBullet47 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties83 = new A.DefaultRunProperties() { FontSize = 1400 };

            A.SolidFill solidFill74 = new A.SolidFill();

            A.SchemeColor schemeColor105 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint40 = new A.Tint() { Val = 75000 };

            schemeColor105.Append(tint40);

            solidFill74.Append(schemeColor105);

            defaultRunProperties83.Append(solidFill74);

            level6ParagraphProperties8.Append(noBullet47);
            level6ParagraphProperties8.Append(defaultRunProperties83);

            A.Level7ParagraphProperties level7ParagraphProperties8 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0 };
            A.NoBullet noBullet48 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties84 = new A.DefaultRunProperties() { FontSize = 1400 };

            A.SolidFill solidFill75 = new A.SolidFill();

            A.SchemeColor schemeColor106 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint41 = new A.Tint() { Val = 75000 };

            schemeColor106.Append(tint41);

            solidFill75.Append(schemeColor106);

            defaultRunProperties84.Append(solidFill75);

            level7ParagraphProperties8.Append(noBullet48);
            level7ParagraphProperties8.Append(defaultRunProperties84);

            A.Level8ParagraphProperties level8ParagraphProperties8 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0 };
            A.NoBullet noBullet49 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties85 = new A.DefaultRunProperties() { FontSize = 1400 };

            A.SolidFill solidFill76 = new A.SolidFill();

            A.SchemeColor schemeColor107 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint42 = new A.Tint() { Val = 75000 };

            schemeColor107.Append(tint42);

            solidFill76.Append(schemeColor107);

            defaultRunProperties85.Append(solidFill76);

            level8ParagraphProperties8.Append(noBullet49);
            level8ParagraphProperties8.Append(defaultRunProperties85);

            A.Level9ParagraphProperties level9ParagraphProperties8 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0 };
            A.NoBullet noBullet50 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties86 = new A.DefaultRunProperties() { FontSize = 1400 };

            A.SolidFill solidFill77 = new A.SolidFill();

            A.SchemeColor schemeColor108 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint43 = new A.Tint() { Val = 75000 };

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

            A.Paragraph paragraph58 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties37 = new A.ParagraphProperties() { Level = 0 };

            A.Run run35 = new A.Run();

            A.RunProperties runProperties49 = new A.RunProperties() { Language = "en-US" };
            runProperties49.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text49 = new A.Text();
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

            Shape shape43 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties43 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties52 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Date Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties43 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks41 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties43.Append(shapeLocks41);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties52 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape40 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties52.Append(placeholderShape40);

            nonVisualShapeProperties43.Append(nonVisualDrawingProperties52);
            nonVisualShapeProperties43.Append(nonVisualShapeDrawingProperties43);
            nonVisualShapeProperties43.Append(applicationNonVisualDrawingProperties52);
            ShapeProperties shapeProperties45 = new ShapeProperties();

            TextBody textBody43 = new TextBody();
            A.BodyProperties bodyProperties45 = new A.BodyProperties();
            A.ListStyle listStyle45 = new A.ListStyle();

            A.Paragraph paragraph59 = new A.Paragraph();

            A.Field field15 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties50 = new A.RunProperties() { Language = "en-US" };
            runProperties50.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties38 = new A.ParagraphProperties();
            A.Text text50 = new A.Text();
            text50.Text = "29/11/13";

            field15.Append(runProperties50);
            field15.Append(paragraphProperties38);
            field15.Append(text50);
            A.EndParagraphRunProperties endParagraphRunProperties42 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph59.Append(field15);
            paragraph59.Append(endParagraphRunProperties42);

            textBody43.Append(bodyProperties45);
            textBody43.Append(listStyle45);
            textBody43.Append(paragraph59);

            shape43.Append(nonVisualShapeProperties43);
            shape43.Append(shapeProperties45);
            shape43.Append(textBody43);

            Shape shape44 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties44 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties53 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Footer Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties44 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks42 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties44.Append(shapeLocks42);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties53 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape41 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties53.Append(placeholderShape41);

            nonVisualShapeProperties44.Append(nonVisualDrawingProperties53);
            nonVisualShapeProperties44.Append(nonVisualShapeDrawingProperties44);
            nonVisualShapeProperties44.Append(applicationNonVisualDrawingProperties53);
            ShapeProperties shapeProperties46 = new ShapeProperties();

            TextBody textBody44 = new TextBody();
            A.BodyProperties bodyProperties46 = new A.BodyProperties();
            A.ListStyle listStyle46 = new A.ListStyle();

            A.Paragraph paragraph60 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties43 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph60.Append(endParagraphRunProperties43);

            textBody44.Append(bodyProperties46);
            textBody44.Append(listStyle46);
            textBody44.Append(paragraph60);

            shape44.Append(nonVisualShapeProperties44);
            shape44.Append(shapeProperties46);
            shape44.Append(textBody44);

            Shape shape45 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties45 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties54 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Slide Number Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties45 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks43 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties45.Append(shapeLocks43);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties54 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape42 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties54.Append(placeholderShape42);

            nonVisualShapeProperties45.Append(nonVisualDrawingProperties54);
            nonVisualShapeProperties45.Append(nonVisualShapeDrawingProperties45);
            nonVisualShapeProperties45.Append(applicationNonVisualDrawingProperties54);
            ShapeProperties shapeProperties47 = new ShapeProperties();

            TextBody textBody45 = new TextBody();
            A.BodyProperties bodyProperties47 = new A.BodyProperties();
            A.ListStyle listStyle47 = new A.ListStyle();

            A.Paragraph paragraph61 = new A.Paragraph();

            A.Field field16 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties51 = new A.RunProperties() { Language = "en-US" };
            runProperties51.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties39 = new A.ParagraphProperties();
            A.Text text51 = new A.Text();
            text51.Text = "‹#›";

            field16.Append(runProperties51);
            field16.Append(paragraphProperties39);
            field16.Append(text51);
            A.EndParagraphRunProperties endParagraphRunProperties44 = new A.EndParagraphRunProperties() { Language = "en-US" };

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

            ColorMapOverride colorMapOverride8 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping8 = new A.MasterColorMapping();

            colorMapOverride8.Append(masterColorMapping8);

            slideLayout7.Append(commonSlideData9);
            slideLayout7.Append(colorMapOverride8);

            slideLayoutPart7.SlideLayout = slideLayout7;
        }

        // Generates content of slideLayoutPart8.
        private void GenerateSlideLayoutPart8Content(SlideLayoutPart slideLayoutPart8)
        {
            SlideLayout slideLayout8 = new SlideLayout() { Type = SlideLayoutValues.TwoObjects, Preserve = true };
            slideLayout8.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout8.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout8.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData10 = new CommonSlideData() { Name = "Two Content" };

            ShapeTree shapeTree10 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties10 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties55 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties10 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties55 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties10.Append(nonVisualDrawingProperties55);
            nonVisualGroupShapeProperties10.Append(nonVisualGroupShapeDrawingProperties10);
            nonVisualGroupShapeProperties10.Append(applicationNonVisualDrawingProperties55);

            GroupShapeProperties groupShapeProperties10 = new GroupShapeProperties();

            A.TransformGroup transformGroup10 = new A.TransformGroup();
            A.Offset offset30 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents30 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset10 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents10 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup10.Append(offset30);
            transformGroup10.Append(extents30);
            transformGroup10.Append(childOffset10);
            transformGroup10.Append(childExtents10);

            groupShapeProperties10.Append(transformGroup10);

            Shape shape46 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties46 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties56 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties46 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks44 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties46.Append(shapeLocks44);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties56 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape43 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties56.Append(placeholderShape43);

            nonVisualShapeProperties46.Append(nonVisualDrawingProperties56);
            nonVisualShapeProperties46.Append(nonVisualShapeDrawingProperties46);
            nonVisualShapeProperties46.Append(applicationNonVisualDrawingProperties56);

            ShapeProperties shapeProperties48 = new ShapeProperties();

            A.Transform2D transform2D21 = new A.Transform2D();
            A.Offset offset31 = new A.Offset() { X = 549275L, Y = 107576L };
            A.Extents extents31 = new A.Extents() { Cx = 8042276L, Cy = 1336956L };

            transform2D21.Append(offset31);
            transform2D21.Append(extents31);

            shapeProperties48.Append(transform2D21);

            TextBody textBody46 = new TextBody();
            A.BodyProperties bodyProperties48 = new A.BodyProperties();
            A.ListStyle listStyle48 = new A.ListStyle();

            A.Paragraph paragraph62 = new A.Paragraph();

            A.Run run36 = new A.Run();

            A.RunProperties runProperties52 = new A.RunProperties() { Language = "en-US" };
            runProperties52.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text52 = new A.Text();
            text52.Text = "Click to edit Master title style";

            run36.Append(runProperties52);
            run36.Append(text52);
            A.EndParagraphRunProperties endParagraphRunProperties45 = new A.EndParagraphRunProperties();

            paragraph62.Append(run36);
            paragraph62.Append(endParagraphRunProperties45);

            textBody46.Append(bodyProperties48);
            textBody46.Append(listStyle48);
            textBody46.Append(paragraph62);

            shape46.Append(nonVisualShapeProperties46);
            shape46.Append(shapeProperties48);
            shape46.Append(textBody46);

            Shape shape47 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties47 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties57 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Content Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties47 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks45 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties47.Append(shapeLocks45);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties57 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape44 = new PlaceholderShape() { Size = PlaceholderSizeValues.Half, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties57.Append(placeholderShape44);

            nonVisualShapeProperties47.Append(nonVisualDrawingProperties57);
            nonVisualShapeProperties47.Append(nonVisualShapeDrawingProperties47);
            nonVisualShapeProperties47.Append(applicationNonVisualDrawingProperties57);

            ShapeProperties shapeProperties49 = new ShapeProperties();

            A.Transform2D transform2D22 = new A.Transform2D();
            A.Offset offset32 = new A.Offset() { X = 549275L, Y = 1600201L };
            A.Extents extents32 = new A.Extents() { Cx = 3840480L, Cy = 4343400L };

            transform2D22.Append(offset32);
            transform2D22.Append(extents32);

            shapeProperties49.Append(transform2D22);

            TextBody textBody47 = new TextBody();

            A.BodyProperties bodyProperties49 = new A.BodyProperties();
            A.NormalAutoFit normalAutoFit6 = new A.NormalAutoFit();

            bodyProperties49.Append(normalAutoFit6);

            A.ListStyle listStyle49 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties17 = new A.Level1ParagraphProperties();

            A.SpaceBefore spaceBefore17 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints10 = new A.SpacingPoints() { Val = 1600 };

            spaceBefore17.Append(spacingPoints10);
            A.DefaultRunProperties defaultRunProperties87 = new A.DefaultRunProperties() { FontSize = 2000 };

            level1ParagraphProperties17.Append(spaceBefore17);
            level1ParagraphProperties17.Append(defaultRunProperties87);

            A.Level2ParagraphProperties level2ParagraphProperties9 = new A.Level2ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties88 = new A.DefaultRunProperties() { FontSize = 1800 };

            level2ParagraphProperties9.Append(defaultRunProperties88);

            A.Level3ParagraphProperties level3ParagraphProperties9 = new A.Level3ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties89 = new A.DefaultRunProperties() { FontSize = 1800 };

            level3ParagraphProperties9.Append(defaultRunProperties89);

            A.Level4ParagraphProperties level4ParagraphProperties9 = new A.Level4ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties90 = new A.DefaultRunProperties() { FontSize = 1800 };

            level4ParagraphProperties9.Append(defaultRunProperties90);

            A.Level5ParagraphProperties level5ParagraphProperties12 = new A.Level5ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties91 = new A.DefaultRunProperties() { FontSize = 1800 };

            level5ParagraphProperties12.Append(defaultRunProperties91);

            A.Level6ParagraphProperties level6ParagraphProperties9 = new A.Level6ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties92 = new A.DefaultRunProperties() { FontSize = 1800 };

            level6ParagraphProperties9.Append(defaultRunProperties92);

            A.Level7ParagraphProperties level7ParagraphProperties9 = new A.Level7ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties93 = new A.DefaultRunProperties() { FontSize = 1800 };

            level7ParagraphProperties9.Append(defaultRunProperties93);

            A.Level8ParagraphProperties level8ParagraphProperties9 = new A.Level8ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties94 = new A.DefaultRunProperties() { FontSize = 1800 };

            level8ParagraphProperties9.Append(defaultRunProperties94);

            A.Level9ParagraphProperties level9ParagraphProperties9 = new A.Level9ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties95 = new A.DefaultRunProperties() { FontSize = 1800 };

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

            A.Paragraph paragraph63 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties40 = new A.ParagraphProperties() { Level = 0 };

            A.Run run37 = new A.Run();

            A.RunProperties runProperties53 = new A.RunProperties() { Language = "en-US" };
            runProperties53.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text53 = new A.Text();
            text53.Text = "Click to edit Master text styles";

            run37.Append(runProperties53);
            run37.Append(text53);

            paragraph63.Append(paragraphProperties40);
            paragraph63.Append(run37);

            A.Paragraph paragraph64 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties41 = new A.ParagraphProperties() { Level = 1 };

            A.Run run38 = new A.Run();

            A.RunProperties runProperties54 = new A.RunProperties() { Language = "en-US" };
            runProperties54.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text54 = new A.Text();
            text54.Text = "Second level";

            run38.Append(runProperties54);
            run38.Append(text54);

            paragraph64.Append(paragraphProperties41);
            paragraph64.Append(run38);

            A.Paragraph paragraph65 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties42 = new A.ParagraphProperties() { Level = 2 };

            A.Run run39 = new A.Run();

            A.RunProperties runProperties55 = new A.RunProperties() { Language = "en-US" };
            runProperties55.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text55 = new A.Text();
            text55.Text = "Third level";

            run39.Append(runProperties55);
            run39.Append(text55);

            paragraph65.Append(paragraphProperties42);
            paragraph65.Append(run39);

            A.Paragraph paragraph66 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties43 = new A.ParagraphProperties() { Level = 3 };

            A.Run run40 = new A.Run();

            A.RunProperties runProperties56 = new A.RunProperties() { Language = "en-US" };
            runProperties56.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text56 = new A.Text();
            text56.Text = "Fourth level";

            run40.Append(runProperties56);
            run40.Append(text56);

            paragraph66.Append(paragraphProperties43);
            paragraph66.Append(run40);

            A.Paragraph paragraph67 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties44 = new A.ParagraphProperties() { Level = 4 };

            A.Run run41 = new A.Run();

            A.RunProperties runProperties57 = new A.RunProperties() { Language = "en-US" };
            runProperties57.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text57 = new A.Text();
            text57.Text = "Fifth level";

            run41.Append(runProperties57);
            run41.Append(text57);
            A.EndParagraphRunProperties endParagraphRunProperties46 = new A.EndParagraphRunProperties() { Dirty = false };

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

            Shape shape48 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties48 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties58 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Content Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties48 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks46 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties48.Append(shapeLocks46);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties58 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape45 = new PlaceholderShape() { Size = PlaceholderSizeValues.Half, Index = (UInt32Value)2U };

            applicationNonVisualDrawingProperties58.Append(placeholderShape45);

            nonVisualShapeProperties48.Append(nonVisualDrawingProperties58);
            nonVisualShapeProperties48.Append(nonVisualShapeDrawingProperties48);
            nonVisualShapeProperties48.Append(applicationNonVisualDrawingProperties58);

            ShapeProperties shapeProperties50 = new ShapeProperties();

            A.Transform2D transform2D23 = new A.Transform2D();
            A.Offset offset33 = new A.Offset() { X = 4751071L, Y = 1600201L };
            A.Extents extents33 = new A.Extents() { Cx = 3840480L, Cy = 4343400L };

            transform2D23.Append(offset33);
            transform2D23.Append(extents33);

            shapeProperties50.Append(transform2D23);

            TextBody textBody48 = new TextBody();

            A.BodyProperties bodyProperties50 = new A.BodyProperties();
            A.NormalAutoFit normalAutoFit7 = new A.NormalAutoFit();

            bodyProperties50.Append(normalAutoFit7);

            A.ListStyle listStyle50 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties18 = new A.Level1ParagraphProperties();

            A.SpaceBefore spaceBefore18 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints11 = new A.SpacingPoints() { Val = 1600 };

            spaceBefore18.Append(spacingPoints11);
            A.DefaultRunProperties defaultRunProperties96 = new A.DefaultRunProperties() { FontSize = 2000 };

            level1ParagraphProperties18.Append(spaceBefore18);
            level1ParagraphProperties18.Append(defaultRunProperties96);

            A.Level2ParagraphProperties level2ParagraphProperties10 = new A.Level2ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties97 = new A.DefaultRunProperties() { FontSize = 1800 };

            level2ParagraphProperties10.Append(defaultRunProperties97);

            A.Level3ParagraphProperties level3ParagraphProperties10 = new A.Level3ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties98 = new A.DefaultRunProperties() { FontSize = 1800 };

            level3ParagraphProperties10.Append(defaultRunProperties98);

            A.Level4ParagraphProperties level4ParagraphProperties10 = new A.Level4ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties99 = new A.DefaultRunProperties() { FontSize = 1800 };

            level4ParagraphProperties10.Append(defaultRunProperties99);

            A.Level5ParagraphProperties level5ParagraphProperties13 = new A.Level5ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties100 = new A.DefaultRunProperties() { FontSize = 1800 };

            level5ParagraphProperties13.Append(defaultRunProperties100);

            A.Level6ParagraphProperties level6ParagraphProperties10 = new A.Level6ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties101 = new A.DefaultRunProperties() { FontSize = 1800 };

            level6ParagraphProperties10.Append(defaultRunProperties101);

            A.Level7ParagraphProperties level7ParagraphProperties10 = new A.Level7ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties102 = new A.DefaultRunProperties() { FontSize = 1800 };

            level7ParagraphProperties10.Append(defaultRunProperties102);

            A.Level8ParagraphProperties level8ParagraphProperties10 = new A.Level8ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties103 = new A.DefaultRunProperties() { FontSize = 1800 };

            level8ParagraphProperties10.Append(defaultRunProperties103);

            A.Level9ParagraphProperties level9ParagraphProperties10 = new A.Level9ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties104 = new A.DefaultRunProperties() { FontSize = 1800 };

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

            A.Paragraph paragraph68 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties45 = new A.ParagraphProperties() { Level = 0 };

            A.Run run42 = new A.Run();

            A.RunProperties runProperties58 = new A.RunProperties() { Language = "en-US" };
            runProperties58.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text58 = new A.Text();
            text58.Text = "Click to edit Master text styles";

            run42.Append(runProperties58);
            run42.Append(text58);

            paragraph68.Append(paragraphProperties45);
            paragraph68.Append(run42);

            A.Paragraph paragraph69 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties46 = new A.ParagraphProperties() { Level = 1 };

            A.Run run43 = new A.Run();

            A.RunProperties runProperties59 = new A.RunProperties() { Language = "en-US" };
            runProperties59.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text59 = new A.Text();
            text59.Text = "Second level";

            run43.Append(runProperties59);
            run43.Append(text59);

            paragraph69.Append(paragraphProperties46);
            paragraph69.Append(run43);

            A.Paragraph paragraph70 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties47 = new A.ParagraphProperties() { Level = 2 };

            A.Run run44 = new A.Run();

            A.RunProperties runProperties60 = new A.RunProperties() { Language = "en-US" };
            runProperties60.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text60 = new A.Text();
            text60.Text = "Third level";

            run44.Append(runProperties60);
            run44.Append(text60);

            paragraph70.Append(paragraphProperties47);
            paragraph70.Append(run44);

            A.Paragraph paragraph71 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties48 = new A.ParagraphProperties() { Level = 3 };

            A.Run run45 = new A.Run();

            A.RunProperties runProperties61 = new A.RunProperties() { Language = "en-US" };
            runProperties61.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text61 = new A.Text();
            text61.Text = "Fourth level";

            run45.Append(runProperties61);
            run45.Append(text61);

            paragraph71.Append(paragraphProperties48);
            paragraph71.Append(run45);

            A.Paragraph paragraph72 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties49 = new A.ParagraphProperties() { Level = 4 };

            A.Run run46 = new A.Run();

            A.RunProperties runProperties62 = new A.RunProperties() { Language = "en-US" };
            runProperties62.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text62 = new A.Text();
            text62.Text = "Fifth level";

            run46.Append(runProperties62);
            run46.Append(text62);
            A.EndParagraphRunProperties endParagraphRunProperties47 = new A.EndParagraphRunProperties() { Dirty = false };

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

            Shape shape49 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties49 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties59 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Date Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties49 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks47 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties49.Append(shapeLocks47);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties59 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape46 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties59.Append(placeholderShape46);

            nonVisualShapeProperties49.Append(nonVisualDrawingProperties59);
            nonVisualShapeProperties49.Append(nonVisualShapeDrawingProperties49);
            nonVisualShapeProperties49.Append(applicationNonVisualDrawingProperties59);
            ShapeProperties shapeProperties51 = new ShapeProperties();

            TextBody textBody49 = new TextBody();
            A.BodyProperties bodyProperties51 = new A.BodyProperties();
            A.ListStyle listStyle51 = new A.ListStyle();

            A.Paragraph paragraph73 = new A.Paragraph();

            A.Field field17 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties63 = new A.RunProperties() { Language = "en-US" };
            runProperties63.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties50 = new A.ParagraphProperties();
            A.Text text63 = new A.Text();
            text63.Text = "29/11/13";

            field17.Append(runProperties63);
            field17.Append(paragraphProperties50);
            field17.Append(text63);
            A.EndParagraphRunProperties endParagraphRunProperties48 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph73.Append(field17);
            paragraph73.Append(endParagraphRunProperties48);

            textBody49.Append(bodyProperties51);
            textBody49.Append(listStyle51);
            textBody49.Append(paragraph73);

            shape49.Append(nonVisualShapeProperties49);
            shape49.Append(shapeProperties51);
            shape49.Append(textBody49);

            Shape shape50 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties50 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties60 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Footer Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties50 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks48 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties50.Append(shapeLocks48);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties60 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape47 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties60.Append(placeholderShape47);

            nonVisualShapeProperties50.Append(nonVisualDrawingProperties60);
            nonVisualShapeProperties50.Append(nonVisualShapeDrawingProperties50);
            nonVisualShapeProperties50.Append(applicationNonVisualDrawingProperties60);
            ShapeProperties shapeProperties52 = new ShapeProperties();

            TextBody textBody50 = new TextBody();
            A.BodyProperties bodyProperties52 = new A.BodyProperties();
            A.ListStyle listStyle52 = new A.ListStyle();

            A.Paragraph paragraph74 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties49 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph74.Append(endParagraphRunProperties49);

            textBody50.Append(bodyProperties52);
            textBody50.Append(listStyle52);
            textBody50.Append(paragraph74);

            shape50.Append(nonVisualShapeProperties50);
            shape50.Append(shapeProperties52);
            shape50.Append(textBody50);

            Shape shape51 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties51 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties61 = new NonVisualDrawingProperties() { Id = (UInt32Value)7U, Name = "Slide Number Placeholder 6" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties51 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks49 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties51.Append(shapeLocks49);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties61 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape48 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties61.Append(placeholderShape48);

            nonVisualShapeProperties51.Append(nonVisualDrawingProperties61);
            nonVisualShapeProperties51.Append(nonVisualShapeDrawingProperties51);
            nonVisualShapeProperties51.Append(applicationNonVisualDrawingProperties61);
            ShapeProperties shapeProperties53 = new ShapeProperties();

            TextBody textBody51 = new TextBody();
            A.BodyProperties bodyProperties53 = new A.BodyProperties();
            A.ListStyle listStyle53 = new A.ListStyle();

            A.Paragraph paragraph75 = new A.Paragraph();

            A.Field field18 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties64 = new A.RunProperties() { Language = "en-US" };
            runProperties64.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties51 = new A.ParagraphProperties();
            A.Text text64 = new A.Text();
            text64.Text = "‹#›";

            field18.Append(runProperties64);
            field18.Append(paragraphProperties51);
            field18.Append(text64);
            A.EndParagraphRunProperties endParagraphRunProperties50 = new A.EndParagraphRunProperties() { Language = "en-US" };

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

            ColorMapOverride colorMapOverride9 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping9 = new A.MasterColorMapping();

            colorMapOverride9.Append(masterColorMapping9);

            slideLayout8.Append(commonSlideData10);
            slideLayout8.Append(colorMapOverride9);

            slideLayoutPart8.SlideLayout = slideLayout8;
        }

        // Generates content of slideLayoutPart9.
        private void GenerateSlideLayoutPart9Content(SlideLayoutPart slideLayoutPart9)
        {
            SlideLayout slideLayout9 = new SlideLayout() { Type = SlideLayoutValues.TwoTextAndTwoObjects, Preserve = true };
            slideLayout9.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout9.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout9.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData11 = new CommonSlideData() { Name = "Comparison" };

            ShapeTree shapeTree11 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties11 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties62 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties11 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties62 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties11.Append(nonVisualDrawingProperties62);
            nonVisualGroupShapeProperties11.Append(nonVisualGroupShapeDrawingProperties11);
            nonVisualGroupShapeProperties11.Append(applicationNonVisualDrawingProperties62);

            GroupShapeProperties groupShapeProperties11 = new GroupShapeProperties();

            A.TransformGroup transformGroup11 = new A.TransformGroup();
            A.Offset offset34 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents34 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset11 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents11 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup11.Append(offset34);
            transformGroup11.Append(extents34);
            transformGroup11.Append(childOffset11);
            transformGroup11.Append(childExtents11);

            groupShapeProperties11.Append(transformGroup11);

            Shape shape52 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties52 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties63 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties52 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks50 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties52.Append(shapeLocks50);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties63 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape49 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties63.Append(placeholderShape49);

            nonVisualShapeProperties52.Append(nonVisualDrawingProperties63);
            nonVisualShapeProperties52.Append(nonVisualShapeDrawingProperties52);
            nonVisualShapeProperties52.Append(applicationNonVisualDrawingProperties63);

            ShapeProperties shapeProperties54 = new ShapeProperties();

            A.Transform2D transform2D24 = new A.Transform2D();
            A.Offset offset35 = new A.Offset() { X = 549274L, Y = 107576L };
            A.Extents extents35 = new A.Extents() { Cx = 8042276L, Cy = 1336956L };

            transform2D24.Append(offset35);
            transform2D24.Append(extents35);

            shapeProperties54.Append(transform2D24);

            TextBody textBody52 = new TextBody();
            A.BodyProperties bodyProperties54 = new A.BodyProperties();

            A.ListStyle listStyle54 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties19 = new A.Level1ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties105 = new A.DefaultRunProperties();

            level1ParagraphProperties19.Append(defaultRunProperties105);

            listStyle54.Append(level1ParagraphProperties19);

            A.Paragraph paragraph76 = new A.Paragraph();

            A.Run run47 = new A.Run();

            A.RunProperties runProperties65 = new A.RunProperties() { Language = "en-US" };
            runProperties65.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text65 = new A.Text();
            text65.Text = "Click to edit Master title style";

            run47.Append(runProperties65);
            run47.Append(text65);
            A.EndParagraphRunProperties endParagraphRunProperties51 = new A.EndParagraphRunProperties();

            paragraph76.Append(run47);
            paragraph76.Append(endParagraphRunProperties51);

            textBody52.Append(bodyProperties54);
            textBody52.Append(listStyle54);
            textBody52.Append(paragraph76);

            shape52.Append(nonVisualShapeProperties52);
            shape52.Append(shapeProperties54);
            shape52.Append(textBody52);

            Shape shape53 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties53 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties64 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Text Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties53 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks51 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties53.Append(shapeLocks51);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties64 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape50 = new PlaceholderShape() { Type = PlaceholderValues.Body, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties64.Append(placeholderShape50);

            nonVisualShapeProperties53.Append(nonVisualDrawingProperties64);
            nonVisualShapeProperties53.Append(nonVisualShapeDrawingProperties53);
            nonVisualShapeProperties53.Append(applicationNonVisualDrawingProperties64);

            ShapeProperties shapeProperties55 = new ShapeProperties();

            A.Transform2D transform2D25 = new A.Transform2D();
            A.Offset offset36 = new A.Offset() { X = 549274L, Y = 1453224L };
            A.Extents extents36 = new A.Extents() { Cx = 3840480L, Cy = 750887L };

            transform2D25.Append(offset36);
            transform2D25.Append(extents36);

            shapeProperties55.Append(transform2D25);

            TextBody textBody53 = new TextBody();

            A.BodyProperties bodyProperties55 = new A.BodyProperties() { Anchor = A.TextAnchoringTypeValues.Bottom };
            A.NoAutoFit noAutoFit4 = new A.NoAutoFit();

            bodyProperties55.Append(noAutoFit4);

            A.ListStyle listStyle55 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties20 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };

            A.SpaceBefore spaceBefore19 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints12 = new A.SpacingPoints() { Val = 0 };

            spaceBefore19.Append(spacingPoints12);
            A.NoBullet noBullet51 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties106 = new A.DefaultRunProperties() { FontSize = 2400, Bold = false };

            A.SolidFill solidFill78 = new A.SolidFill();

            A.SchemeColor schemeColor109 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };
            A.LuminanceModulation luminanceModulation21 = new A.LuminanceModulation() { Val = 60000 };
            A.LuminanceOffset luminanceOffset19 = new A.LuminanceOffset() { Val = 40000 };

            schemeColor109.Append(luminanceModulation21);
            schemeColor109.Append(luminanceOffset19);

            solidFill78.Append(schemeColor109);

            defaultRunProperties106.Append(solidFill78);

            level1ParagraphProperties20.Append(spaceBefore19);
            level1ParagraphProperties20.Append(noBullet51);
            level1ParagraphProperties20.Append(defaultRunProperties106);

            A.Level2ParagraphProperties level2ParagraphProperties11 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0 };
            A.NoBullet noBullet52 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties107 = new A.DefaultRunProperties() { FontSize = 2000, Bold = true };

            level2ParagraphProperties11.Append(noBullet52);
            level2ParagraphProperties11.Append(defaultRunProperties107);

            A.Level3ParagraphProperties level3ParagraphProperties11 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0 };
            A.NoBullet noBullet53 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties108 = new A.DefaultRunProperties() { FontSize = 1800, Bold = true };

            level3ParagraphProperties11.Append(noBullet53);
            level3ParagraphProperties11.Append(defaultRunProperties108);

            A.Level4ParagraphProperties level4ParagraphProperties11 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0 };
            A.NoBullet noBullet54 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties109 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level4ParagraphProperties11.Append(noBullet54);
            level4ParagraphProperties11.Append(defaultRunProperties109);

            A.Level5ParagraphProperties level5ParagraphProperties14 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0 };
            A.NoBullet noBullet55 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties110 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level5ParagraphProperties14.Append(noBullet55);
            level5ParagraphProperties14.Append(defaultRunProperties110);

            A.Level6ParagraphProperties level6ParagraphProperties11 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0 };
            A.NoBullet noBullet56 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties111 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level6ParagraphProperties11.Append(noBullet56);
            level6ParagraphProperties11.Append(defaultRunProperties111);

            A.Level7ParagraphProperties level7ParagraphProperties11 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0 };
            A.NoBullet noBullet57 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties112 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level7ParagraphProperties11.Append(noBullet57);
            level7ParagraphProperties11.Append(defaultRunProperties112);

            A.Level8ParagraphProperties level8ParagraphProperties11 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0 };
            A.NoBullet noBullet58 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties113 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level8ParagraphProperties11.Append(noBullet58);
            level8ParagraphProperties11.Append(defaultRunProperties113);

            A.Level9ParagraphProperties level9ParagraphProperties11 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0 };
            A.NoBullet noBullet59 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties114 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

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

            A.Paragraph paragraph77 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties52 = new A.ParagraphProperties() { Level = 0 };

            A.Run run48 = new A.Run();

            A.RunProperties runProperties66 = new A.RunProperties() { Language = "en-US" };
            runProperties66.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text66 = new A.Text();
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

            Shape shape54 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties54 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties65 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Content Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties54 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks52 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties54.Append(shapeLocks52);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties65 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape51 = new PlaceholderShape() { Size = PlaceholderSizeValues.Half, Index = (UInt32Value)2U };

            applicationNonVisualDrawingProperties65.Append(placeholderShape51);

            nonVisualShapeProperties54.Append(nonVisualDrawingProperties65);
            nonVisualShapeProperties54.Append(nonVisualShapeDrawingProperties54);
            nonVisualShapeProperties54.Append(applicationNonVisualDrawingProperties65);

            ShapeProperties shapeProperties56 = new ShapeProperties();

            A.Transform2D transform2D26 = new A.Transform2D();
            A.Offset offset37 = new A.Offset() { X = 549274L, Y = 2347415L };
            A.Extents extents37 = new A.Extents() { Cx = 3840480L, Cy = 3596185L };

            transform2D26.Append(offset37);
            transform2D26.Append(extents37);

            shapeProperties56.Append(transform2D26);

            TextBody textBody54 = new TextBody();

            A.BodyProperties bodyProperties56 = new A.BodyProperties();
            A.NormalAutoFit normalAutoFit8 = new A.NormalAutoFit();

            bodyProperties56.Append(normalAutoFit8);

            A.ListStyle listStyle56 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties21 = new A.Level1ParagraphProperties();

            A.SpaceBefore spaceBefore20 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints13 = new A.SpacingPoints() { Val = 1600 };

            spaceBefore20.Append(spacingPoints13);
            A.DefaultRunProperties defaultRunProperties115 = new A.DefaultRunProperties() { FontSize = 2000 };

            level1ParagraphProperties21.Append(spaceBefore20);
            level1ParagraphProperties21.Append(defaultRunProperties115);

            A.Level2ParagraphProperties level2ParagraphProperties12 = new A.Level2ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties116 = new A.DefaultRunProperties() { FontSize = 1800 };

            level2ParagraphProperties12.Append(defaultRunProperties116);

            A.Level3ParagraphProperties level3ParagraphProperties12 = new A.Level3ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties117 = new A.DefaultRunProperties() { FontSize = 1800 };

            level3ParagraphProperties12.Append(defaultRunProperties117);

            A.Level4ParagraphProperties level4ParagraphProperties12 = new A.Level4ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties118 = new A.DefaultRunProperties() { FontSize = 1800 };

            level4ParagraphProperties12.Append(defaultRunProperties118);

            A.Level5ParagraphProperties level5ParagraphProperties15 = new A.Level5ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties119 = new A.DefaultRunProperties() { FontSize = 1800 };

            level5ParagraphProperties15.Append(defaultRunProperties119);

            A.Level6ParagraphProperties level6ParagraphProperties12 = new A.Level6ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties120 = new A.DefaultRunProperties() { FontSize = 1600 };

            level6ParagraphProperties12.Append(defaultRunProperties120);

            A.Level7ParagraphProperties level7ParagraphProperties12 = new A.Level7ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties121 = new A.DefaultRunProperties() { FontSize = 1600 };

            level7ParagraphProperties12.Append(defaultRunProperties121);

            A.Level8ParagraphProperties level8ParagraphProperties12 = new A.Level8ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties122 = new A.DefaultRunProperties() { FontSize = 1600 };

            level8ParagraphProperties12.Append(defaultRunProperties122);

            A.Level9ParagraphProperties level9ParagraphProperties12 = new A.Level9ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties123 = new A.DefaultRunProperties() { FontSize = 1600 };

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

            A.Paragraph paragraph78 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties53 = new A.ParagraphProperties() { Level = 0 };

            A.Run run49 = new A.Run();

            A.RunProperties runProperties67 = new A.RunProperties() { Language = "en-US" };
            runProperties67.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text67 = new A.Text();
            text67.Text = "Click to edit Master text styles";

            run49.Append(runProperties67);
            run49.Append(text67);

            paragraph78.Append(paragraphProperties53);
            paragraph78.Append(run49);

            A.Paragraph paragraph79 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties54 = new A.ParagraphProperties() { Level = 1 };

            A.Run run50 = new A.Run();

            A.RunProperties runProperties68 = new A.RunProperties() { Language = "en-US" };
            runProperties68.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text68 = new A.Text();
            text68.Text = "Second level";

            run50.Append(runProperties68);
            run50.Append(text68);

            paragraph79.Append(paragraphProperties54);
            paragraph79.Append(run50);

            A.Paragraph paragraph80 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties55 = new A.ParagraphProperties() { Level = 2 };

            A.Run run51 = new A.Run();

            A.RunProperties runProperties69 = new A.RunProperties() { Language = "en-US" };
            runProperties69.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text69 = new A.Text();
            text69.Text = "Third level";

            run51.Append(runProperties69);
            run51.Append(text69);

            paragraph80.Append(paragraphProperties55);
            paragraph80.Append(run51);

            A.Paragraph paragraph81 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties56 = new A.ParagraphProperties() { Level = 3 };

            A.Run run52 = new A.Run();

            A.RunProperties runProperties70 = new A.RunProperties() { Language = "en-US" };
            runProperties70.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text70 = new A.Text();
            text70.Text = "Fourth level";

            run52.Append(runProperties70);
            run52.Append(text70);

            paragraph81.Append(paragraphProperties56);
            paragraph81.Append(run52);

            A.Paragraph paragraph82 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties57 = new A.ParagraphProperties() { Level = 4 };

            A.Run run53 = new A.Run();

            A.RunProperties runProperties71 = new A.RunProperties() { Language = "en-US" };
            runProperties71.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text71 = new A.Text();
            text71.Text = "Fifth level";

            run53.Append(runProperties71);
            run53.Append(text71);
            A.EndParagraphRunProperties endParagraphRunProperties52 = new A.EndParagraphRunProperties() { Dirty = false };

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

            Shape shape55 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties55 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties66 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Text Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties55 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks53 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties55.Append(shapeLocks53);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties66 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape52 = new PlaceholderShape() { Type = PlaceholderValues.Body, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)3U };

            applicationNonVisualDrawingProperties66.Append(placeholderShape52);

            nonVisualShapeProperties55.Append(nonVisualDrawingProperties66);
            nonVisualShapeProperties55.Append(nonVisualShapeDrawingProperties55);
            nonVisualShapeProperties55.Append(applicationNonVisualDrawingProperties66);

            ShapeProperties shapeProperties57 = new ShapeProperties();

            A.Transform2D transform2D27 = new A.Transform2D();
            A.Offset offset38 = new A.Offset() { X = 4751070L, Y = 1453224L };
            A.Extents extents38 = new A.Extents() { Cx = 3840480L, Cy = 750887L };

            transform2D27.Append(offset38);
            transform2D27.Append(extents38);

            shapeProperties57.Append(transform2D27);

            TextBody textBody55 = new TextBody();

            A.BodyProperties bodyProperties57 = new A.BodyProperties() { Anchor = A.TextAnchoringTypeValues.Bottom };
            A.NoAutoFit noAutoFit5 = new A.NoAutoFit();

            bodyProperties57.Append(noAutoFit5);

            A.ListStyle listStyle57 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties22 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };

            A.SpaceBefore spaceBefore21 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints14 = new A.SpacingPoints() { Val = 0 };

            spaceBefore21.Append(spacingPoints14);
            A.NoBullet noBullet60 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties124 = new A.DefaultRunProperties() { FontSize = 2400, Bold = false };

            A.SolidFill solidFill79 = new A.SolidFill();

            A.SchemeColor schemeColor110 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };
            A.LuminanceModulation luminanceModulation22 = new A.LuminanceModulation() { Val = 60000 };
            A.LuminanceOffset luminanceOffset20 = new A.LuminanceOffset() { Val = 40000 };

            schemeColor110.Append(luminanceModulation22);
            schemeColor110.Append(luminanceOffset20);

            solidFill79.Append(schemeColor110);

            defaultRunProperties124.Append(solidFill79);

            level1ParagraphProperties22.Append(spaceBefore21);
            level1ParagraphProperties22.Append(noBullet60);
            level1ParagraphProperties22.Append(defaultRunProperties124);

            A.Level2ParagraphProperties level2ParagraphProperties13 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0 };
            A.NoBullet noBullet61 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties125 = new A.DefaultRunProperties() { FontSize = 2000, Bold = true };

            level2ParagraphProperties13.Append(noBullet61);
            level2ParagraphProperties13.Append(defaultRunProperties125);

            A.Level3ParagraphProperties level3ParagraphProperties13 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0 };
            A.NoBullet noBullet62 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties126 = new A.DefaultRunProperties() { FontSize = 1800, Bold = true };

            level3ParagraphProperties13.Append(noBullet62);
            level3ParagraphProperties13.Append(defaultRunProperties126);

            A.Level4ParagraphProperties level4ParagraphProperties13 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0 };
            A.NoBullet noBullet63 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties127 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level4ParagraphProperties13.Append(noBullet63);
            level4ParagraphProperties13.Append(defaultRunProperties127);

            A.Level5ParagraphProperties level5ParagraphProperties16 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0 };
            A.NoBullet noBullet64 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties128 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level5ParagraphProperties16.Append(noBullet64);
            level5ParagraphProperties16.Append(defaultRunProperties128);

            A.Level6ParagraphProperties level6ParagraphProperties13 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0 };
            A.NoBullet noBullet65 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties129 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level6ParagraphProperties13.Append(noBullet65);
            level6ParagraphProperties13.Append(defaultRunProperties129);

            A.Level7ParagraphProperties level7ParagraphProperties13 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0 };
            A.NoBullet noBullet66 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties130 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level7ParagraphProperties13.Append(noBullet66);
            level7ParagraphProperties13.Append(defaultRunProperties130);

            A.Level8ParagraphProperties level8ParagraphProperties13 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0 };
            A.NoBullet noBullet67 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties131 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level8ParagraphProperties13.Append(noBullet67);
            level8ParagraphProperties13.Append(defaultRunProperties131);

            A.Level9ParagraphProperties level9ParagraphProperties13 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0 };
            A.NoBullet noBullet68 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties132 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

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

            A.Paragraph paragraph83 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties58 = new A.ParagraphProperties() { Level = 0 };

            A.Run run54 = new A.Run();

            A.RunProperties runProperties72 = new A.RunProperties() { Language = "en-US" };
            runProperties72.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text72 = new A.Text();
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

            Shape shape56 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties56 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties67 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Content Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties56 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks54 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties56.Append(shapeLocks54);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties67 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape53 = new PlaceholderShape() { Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)4U };

            applicationNonVisualDrawingProperties67.Append(placeholderShape53);

            nonVisualShapeProperties56.Append(nonVisualDrawingProperties67);
            nonVisualShapeProperties56.Append(nonVisualShapeDrawingProperties56);
            nonVisualShapeProperties56.Append(applicationNonVisualDrawingProperties67);

            ShapeProperties shapeProperties58 = new ShapeProperties();

            A.Transform2D transform2D28 = new A.Transform2D();
            A.Offset offset39 = new A.Offset() { X = 4751070L, Y = 2347415L };
            A.Extents extents39 = new A.Extents() { Cx = 3840480L, Cy = 3596185L };

            transform2D28.Append(offset39);
            transform2D28.Append(extents39);

            shapeProperties58.Append(transform2D28);

            TextBody textBody56 = new TextBody();

            A.BodyProperties bodyProperties58 = new A.BodyProperties();
            A.NormalAutoFit normalAutoFit9 = new A.NormalAutoFit();

            bodyProperties58.Append(normalAutoFit9);

            A.ListStyle listStyle58 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties23 = new A.Level1ParagraphProperties();

            A.SpaceBefore spaceBefore22 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints15 = new A.SpacingPoints() { Val = 1600 };

            spaceBefore22.Append(spacingPoints15);
            A.DefaultRunProperties defaultRunProperties133 = new A.DefaultRunProperties() { FontSize = 2000 };

            level1ParagraphProperties23.Append(spaceBefore22);
            level1ParagraphProperties23.Append(defaultRunProperties133);

            A.Level2ParagraphProperties level2ParagraphProperties14 = new A.Level2ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties134 = new A.DefaultRunProperties() { FontSize = 1800 };

            level2ParagraphProperties14.Append(defaultRunProperties134);

            A.Level3ParagraphProperties level3ParagraphProperties14 = new A.Level3ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties135 = new A.DefaultRunProperties() { FontSize = 1800 };

            level3ParagraphProperties14.Append(defaultRunProperties135);

            A.Level4ParagraphProperties level4ParagraphProperties14 = new A.Level4ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties136 = new A.DefaultRunProperties() { FontSize = 1800 };

            level4ParagraphProperties14.Append(defaultRunProperties136);

            A.Level5ParagraphProperties level5ParagraphProperties17 = new A.Level5ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties137 = new A.DefaultRunProperties() { FontSize = 1800 };

            level5ParagraphProperties17.Append(defaultRunProperties137);

            A.Level6ParagraphProperties level6ParagraphProperties14 = new A.Level6ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties138 = new A.DefaultRunProperties() { FontSize = 1600 };

            level6ParagraphProperties14.Append(defaultRunProperties138);

            A.Level7ParagraphProperties level7ParagraphProperties14 = new A.Level7ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties139 = new A.DefaultRunProperties() { FontSize = 1600 };

            level7ParagraphProperties14.Append(defaultRunProperties139);

            A.Level8ParagraphProperties level8ParagraphProperties14 = new A.Level8ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties140 = new A.DefaultRunProperties() { FontSize = 1600 };

            level8ParagraphProperties14.Append(defaultRunProperties140);

            A.Level9ParagraphProperties level9ParagraphProperties14 = new A.Level9ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties141 = new A.DefaultRunProperties() { FontSize = 1600 };

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

            A.Paragraph paragraph84 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties59 = new A.ParagraphProperties() { Level = 0 };

            A.Run run55 = new A.Run();

            A.RunProperties runProperties73 = new A.RunProperties() { Language = "en-US" };
            runProperties73.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text73 = new A.Text();
            text73.Text = "Click to edit Master text styles";

            run55.Append(runProperties73);
            run55.Append(text73);

            paragraph84.Append(paragraphProperties59);
            paragraph84.Append(run55);

            A.Paragraph paragraph85 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties60 = new A.ParagraphProperties() { Level = 1 };

            A.Run run56 = new A.Run();

            A.RunProperties runProperties74 = new A.RunProperties() { Language = "en-US" };
            runProperties74.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text74 = new A.Text();
            text74.Text = "Second level";

            run56.Append(runProperties74);
            run56.Append(text74);

            paragraph85.Append(paragraphProperties60);
            paragraph85.Append(run56);

            A.Paragraph paragraph86 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties61 = new A.ParagraphProperties() { Level = 2 };

            A.Run run57 = new A.Run();

            A.RunProperties runProperties75 = new A.RunProperties() { Language = "en-US" };
            runProperties75.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text75 = new A.Text();
            text75.Text = "Third level";

            run57.Append(runProperties75);
            run57.Append(text75);

            paragraph86.Append(paragraphProperties61);
            paragraph86.Append(run57);

            A.Paragraph paragraph87 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties62 = new A.ParagraphProperties() { Level = 3 };

            A.Run run58 = new A.Run();

            A.RunProperties runProperties76 = new A.RunProperties() { Language = "en-US" };
            runProperties76.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text76 = new A.Text();
            text76.Text = "Fourth level";

            run58.Append(runProperties76);
            run58.Append(text76);

            paragraph87.Append(paragraphProperties62);
            paragraph87.Append(run58);

            A.Paragraph paragraph88 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties63 = new A.ParagraphProperties() { Level = 4 };

            A.Run run59 = new A.Run();

            A.RunProperties runProperties77 = new A.RunProperties() { Language = "en-US" };
            runProperties77.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text77 = new A.Text();
            text77.Text = "Fifth level";

            run59.Append(runProperties77);
            run59.Append(text77);
            A.EndParagraphRunProperties endParagraphRunProperties53 = new A.EndParagraphRunProperties() { Dirty = false };

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

            Shape shape57 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties57 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties68 = new NonVisualDrawingProperties() { Id = (UInt32Value)7U, Name = "Date Placeholder 6" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties57 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks55 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties57.Append(shapeLocks55);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties68 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape54 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties68.Append(placeholderShape54);

            nonVisualShapeProperties57.Append(nonVisualDrawingProperties68);
            nonVisualShapeProperties57.Append(nonVisualShapeDrawingProperties57);
            nonVisualShapeProperties57.Append(applicationNonVisualDrawingProperties68);
            ShapeProperties shapeProperties59 = new ShapeProperties();

            TextBody textBody57 = new TextBody();
            A.BodyProperties bodyProperties59 = new A.BodyProperties();
            A.ListStyle listStyle59 = new A.ListStyle();

            A.Paragraph paragraph89 = new A.Paragraph();

            A.Field field19 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties78 = new A.RunProperties() { Language = "en-US" };
            runProperties78.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties64 = new A.ParagraphProperties();
            A.Text text78 = new A.Text();
            text78.Text = "29/11/13";

            field19.Append(runProperties78);
            field19.Append(paragraphProperties64);
            field19.Append(text78);
            A.EndParagraphRunProperties endParagraphRunProperties54 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph89.Append(field19);
            paragraph89.Append(endParagraphRunProperties54);

            textBody57.Append(bodyProperties59);
            textBody57.Append(listStyle59);
            textBody57.Append(paragraph89);

            shape57.Append(nonVisualShapeProperties57);
            shape57.Append(shapeProperties59);
            shape57.Append(textBody57);

            Shape shape58 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties58 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties69 = new NonVisualDrawingProperties() { Id = (UInt32Value)8U, Name = "Footer Placeholder 7" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties58 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks56 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties58.Append(shapeLocks56);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties69 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape55 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties69.Append(placeholderShape55);

            nonVisualShapeProperties58.Append(nonVisualDrawingProperties69);
            nonVisualShapeProperties58.Append(nonVisualShapeDrawingProperties58);
            nonVisualShapeProperties58.Append(applicationNonVisualDrawingProperties69);
            ShapeProperties shapeProperties60 = new ShapeProperties();

            TextBody textBody58 = new TextBody();
            A.BodyProperties bodyProperties60 = new A.BodyProperties();
            A.ListStyle listStyle60 = new A.ListStyle();

            A.Paragraph paragraph90 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties55 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph90.Append(endParagraphRunProperties55);

            textBody58.Append(bodyProperties60);
            textBody58.Append(listStyle60);
            textBody58.Append(paragraph90);

            shape58.Append(nonVisualShapeProperties58);
            shape58.Append(shapeProperties60);
            shape58.Append(textBody58);

            Shape shape59 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties59 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties70 = new NonVisualDrawingProperties() { Id = (UInt32Value)9U, Name = "Slide Number Placeholder 8" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties59 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks57 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties59.Append(shapeLocks57);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties70 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape56 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties70.Append(placeholderShape56);

            nonVisualShapeProperties59.Append(nonVisualDrawingProperties70);
            nonVisualShapeProperties59.Append(nonVisualShapeDrawingProperties59);
            nonVisualShapeProperties59.Append(applicationNonVisualDrawingProperties70);
            ShapeProperties shapeProperties61 = new ShapeProperties();

            TextBody textBody59 = new TextBody();
            A.BodyProperties bodyProperties61 = new A.BodyProperties();
            A.ListStyle listStyle61 = new A.ListStyle();

            A.Paragraph paragraph91 = new A.Paragraph();

            A.Field field20 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties79 = new A.RunProperties() { Language = "en-US" };
            runProperties79.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties65 = new A.ParagraphProperties();
            A.Text text79 = new A.Text();
            text79.Text = "‹#›";

            field20.Append(runProperties79);
            field20.Append(paragraphProperties65);
            field20.Append(text79);
            A.EndParagraphRunProperties endParagraphRunProperties56 = new A.EndParagraphRunProperties() { Language = "en-US" };

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

            ColorMapOverride colorMapOverride10 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping10 = new A.MasterColorMapping();

            colorMapOverride10.Append(masterColorMapping10);

            slideLayout9.Append(commonSlideData11);
            slideLayout9.Append(colorMapOverride10);

            slideLayoutPart9.SlideLayout = slideLayout9;
        }

        // Generates content of slideLayoutPart10.
        private void GenerateSlideLayoutPart10Content(SlideLayoutPart slideLayoutPart10)
        {
            SlideLayout slideLayout10 = new SlideLayout() { Type = SlideLayoutValues.TitleOnly, Preserve = true };
            slideLayout10.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout10.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout10.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData12 = new CommonSlideData() { Name = "Title Only" };

            ShapeTree shapeTree12 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties12 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties71 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties12 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties71 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties12.Append(nonVisualDrawingProperties71);
            nonVisualGroupShapeProperties12.Append(nonVisualGroupShapeDrawingProperties12);
            nonVisualGroupShapeProperties12.Append(applicationNonVisualDrawingProperties71);

            GroupShapeProperties groupShapeProperties12 = new GroupShapeProperties();

            A.TransformGroup transformGroup12 = new A.TransformGroup();
            A.Offset offset40 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents40 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset12 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents12 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup12.Append(offset40);
            transformGroup12.Append(extents40);
            transformGroup12.Append(childOffset12);
            transformGroup12.Append(childExtents12);

            groupShapeProperties12.Append(transformGroup12);

            Shape shape60 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties60 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties72 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties60 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks58 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties60.Append(shapeLocks58);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties72 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape57 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties72.Append(placeholderShape57);

            nonVisualShapeProperties60.Append(nonVisualDrawingProperties72);
            nonVisualShapeProperties60.Append(nonVisualShapeDrawingProperties60);
            nonVisualShapeProperties60.Append(applicationNonVisualDrawingProperties72);
            ShapeProperties shapeProperties62 = new ShapeProperties();

            TextBody textBody60 = new TextBody();
            A.BodyProperties bodyProperties62 = new A.BodyProperties();
            A.ListStyle listStyle62 = new A.ListStyle();

            A.Paragraph paragraph92 = new A.Paragraph();

            A.Run run60 = new A.Run();

            A.RunProperties runProperties80 = new A.RunProperties() { Language = "en-US" };
            runProperties80.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text80 = new A.Text();
            text80.Text = "Click to edit Master title style";

            run60.Append(runProperties80);
            run60.Append(text80);
            A.EndParagraphRunProperties endParagraphRunProperties57 = new A.EndParagraphRunProperties();

            paragraph92.Append(run60);
            paragraph92.Append(endParagraphRunProperties57);

            textBody60.Append(bodyProperties62);
            textBody60.Append(listStyle62);
            textBody60.Append(paragraph92);

            shape60.Append(nonVisualShapeProperties60);
            shape60.Append(shapeProperties62);
            shape60.Append(textBody60);

            Shape shape61 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties61 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties73 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Date Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties61 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks59 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties61.Append(shapeLocks59);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties73 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape58 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties73.Append(placeholderShape58);

            nonVisualShapeProperties61.Append(nonVisualDrawingProperties73);
            nonVisualShapeProperties61.Append(nonVisualShapeDrawingProperties61);
            nonVisualShapeProperties61.Append(applicationNonVisualDrawingProperties73);
            ShapeProperties shapeProperties63 = new ShapeProperties();

            TextBody textBody61 = new TextBody();
            A.BodyProperties bodyProperties63 = new A.BodyProperties();
            A.ListStyle listStyle63 = new A.ListStyle();

            A.Paragraph paragraph93 = new A.Paragraph();

            A.Field field21 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties81 = new A.RunProperties() { Language = "en-US" };
            runProperties81.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties66 = new A.ParagraphProperties();
            A.Text text81 = new A.Text();
            text81.Text = "29/11/13";

            field21.Append(runProperties81);
            field21.Append(paragraphProperties66);
            field21.Append(text81);
            A.EndParagraphRunProperties endParagraphRunProperties58 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph93.Append(field21);
            paragraph93.Append(endParagraphRunProperties58);

            textBody61.Append(bodyProperties63);
            textBody61.Append(listStyle63);
            textBody61.Append(paragraph93);

            shape61.Append(nonVisualShapeProperties61);
            shape61.Append(shapeProperties63);
            shape61.Append(textBody61);

            Shape shape62 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties62 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties74 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Footer Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties62 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks60 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties62.Append(shapeLocks60);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties74 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape59 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties74.Append(placeholderShape59);

            nonVisualShapeProperties62.Append(nonVisualDrawingProperties74);
            nonVisualShapeProperties62.Append(nonVisualShapeDrawingProperties62);
            nonVisualShapeProperties62.Append(applicationNonVisualDrawingProperties74);
            ShapeProperties shapeProperties64 = new ShapeProperties();

            TextBody textBody62 = new TextBody();
            A.BodyProperties bodyProperties64 = new A.BodyProperties();
            A.ListStyle listStyle64 = new A.ListStyle();

            A.Paragraph paragraph94 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties59 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph94.Append(endParagraphRunProperties59);

            textBody62.Append(bodyProperties64);
            textBody62.Append(listStyle64);
            textBody62.Append(paragraph94);

            shape62.Append(nonVisualShapeProperties62);
            shape62.Append(shapeProperties64);
            shape62.Append(textBody62);

            Shape shape63 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties63 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties75 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Slide Number Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties63 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks61 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties63.Append(shapeLocks61);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties75 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape60 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties75.Append(placeholderShape60);

            nonVisualShapeProperties63.Append(nonVisualDrawingProperties75);
            nonVisualShapeProperties63.Append(nonVisualShapeDrawingProperties63);
            nonVisualShapeProperties63.Append(applicationNonVisualDrawingProperties75);
            ShapeProperties shapeProperties65 = new ShapeProperties();

            TextBody textBody63 = new TextBody();
            A.BodyProperties bodyProperties65 = new A.BodyProperties();
            A.ListStyle listStyle65 = new A.ListStyle();

            A.Paragraph paragraph95 = new A.Paragraph();

            A.Field field22 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties82 = new A.RunProperties() { Language = "en-US" };
            runProperties82.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties67 = new A.ParagraphProperties();
            A.Text text82 = new A.Text();
            text82.Text = "‹#›";

            field22.Append(runProperties82);
            field22.Append(paragraphProperties67);
            field22.Append(text82);
            A.EndParagraphRunProperties endParagraphRunProperties60 = new A.EndParagraphRunProperties() { Language = "en-US" };

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

            ColorMapOverride colorMapOverride11 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping11 = new A.MasterColorMapping();

            colorMapOverride11.Append(masterColorMapping11);

            slideLayout10.Append(commonSlideData12);
            slideLayout10.Append(colorMapOverride11);

            slideLayoutPart10.SlideLayout = slideLayout10;
        }

        // Generates content of slideLayoutPart11.
        private void GenerateSlideLayoutPart11Content(SlideLayoutPart slideLayoutPart11)
        {
            SlideLayout slideLayout11 = new SlideLayout() { Type = SlideLayoutValues.Blank, Preserve = true };
            slideLayout11.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout11.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout11.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData13 = new CommonSlideData() { Name = "Blank" };

            ShapeTree shapeTree13 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties13 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties76 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties13 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties76 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties13.Append(nonVisualDrawingProperties76);
            nonVisualGroupShapeProperties13.Append(nonVisualGroupShapeDrawingProperties13);
            nonVisualGroupShapeProperties13.Append(applicationNonVisualDrawingProperties76);

            GroupShapeProperties groupShapeProperties13 = new GroupShapeProperties();

            A.TransformGroup transformGroup13 = new A.TransformGroup();
            A.Offset offset41 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents41 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset13 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents13 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup13.Append(offset41);
            transformGroup13.Append(extents41);
            transformGroup13.Append(childOffset13);
            transformGroup13.Append(childExtents13);

            groupShapeProperties13.Append(transformGroup13);

            Shape shape64 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties64 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties77 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Date Placeholder 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties64 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks62 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties64.Append(shapeLocks62);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties77 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape61 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties77.Append(placeholderShape61);

            nonVisualShapeProperties64.Append(nonVisualDrawingProperties77);
            nonVisualShapeProperties64.Append(nonVisualShapeDrawingProperties64);
            nonVisualShapeProperties64.Append(applicationNonVisualDrawingProperties77);
            ShapeProperties shapeProperties66 = new ShapeProperties();

            TextBody textBody64 = new TextBody();
            A.BodyProperties bodyProperties66 = new A.BodyProperties();
            A.ListStyle listStyle66 = new A.ListStyle();

            A.Paragraph paragraph96 = new A.Paragraph();

            A.Field field23 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties83 = new A.RunProperties() { Language = "en-US" };
            runProperties83.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties68 = new A.ParagraphProperties();
            A.Text text83 = new A.Text();
            text83.Text = "29/11/13";

            field23.Append(runProperties83);
            field23.Append(paragraphProperties68);
            field23.Append(text83);
            A.EndParagraphRunProperties endParagraphRunProperties61 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph96.Append(field23);
            paragraph96.Append(endParagraphRunProperties61);

            textBody64.Append(bodyProperties66);
            textBody64.Append(listStyle66);
            textBody64.Append(paragraph96);

            shape64.Append(nonVisualShapeProperties64);
            shape64.Append(shapeProperties66);
            shape64.Append(textBody64);

            Shape shape65 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties65 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties78 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Footer Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties65 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks63 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties65.Append(shapeLocks63);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties78 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape62 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties78.Append(placeholderShape62);

            nonVisualShapeProperties65.Append(nonVisualDrawingProperties78);
            nonVisualShapeProperties65.Append(nonVisualShapeDrawingProperties65);
            nonVisualShapeProperties65.Append(applicationNonVisualDrawingProperties78);
            ShapeProperties shapeProperties67 = new ShapeProperties();

            TextBody textBody65 = new TextBody();
            A.BodyProperties bodyProperties67 = new A.BodyProperties();
            A.ListStyle listStyle67 = new A.ListStyle();

            A.Paragraph paragraph97 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties62 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph97.Append(endParagraphRunProperties62);

            textBody65.Append(bodyProperties67);
            textBody65.Append(listStyle67);
            textBody65.Append(paragraph97);

            shape65.Append(nonVisualShapeProperties65);
            shape65.Append(shapeProperties67);
            shape65.Append(textBody65);

            Shape shape66 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties66 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties79 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Slide Number Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties66 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks64 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties66.Append(shapeLocks64);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties79 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape63 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties79.Append(placeholderShape63);

            nonVisualShapeProperties66.Append(nonVisualDrawingProperties79);
            nonVisualShapeProperties66.Append(nonVisualShapeDrawingProperties66);
            nonVisualShapeProperties66.Append(applicationNonVisualDrawingProperties79);
            ShapeProperties shapeProperties68 = new ShapeProperties();

            TextBody textBody66 = new TextBody();
            A.BodyProperties bodyProperties68 = new A.BodyProperties();
            A.ListStyle listStyle68 = new A.ListStyle();

            A.Paragraph paragraph98 = new A.Paragraph();

            A.Field field24 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties84 = new A.RunProperties() { Language = "en-US" };
            runProperties84.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties69 = new A.ParagraphProperties();
            A.Text text84 = new A.Text();
            text84.Text = "‹#›";

            field24.Append(runProperties84);
            field24.Append(paragraphProperties69);
            field24.Append(text84);
            A.EndParagraphRunProperties endParagraphRunProperties63 = new A.EndParagraphRunProperties() { Language = "en-US" };

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

            ColorMapOverride colorMapOverride12 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping12 = new A.MasterColorMapping();

            colorMapOverride12.Append(masterColorMapping12);

            slideLayout11.Append(commonSlideData13);
            slideLayout11.Append(colorMapOverride12);

            slideLayoutPart11.SlideLayout = slideLayout11;
        }

        // Generates content of slideLayoutPart12.
        private void GenerateSlideLayoutPart12Content(SlideLayoutPart slideLayoutPart12)
        {
            SlideLayout slideLayout12 = new SlideLayout() { Type = SlideLayoutValues.ObjectText, Preserve = true };
            slideLayout12.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout12.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout12.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData14 = new CommonSlideData() { Name = "Content with Caption" };

            ShapeTree shapeTree14 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties14 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties80 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties14 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties80 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties14.Append(nonVisualDrawingProperties80);
            nonVisualGroupShapeProperties14.Append(nonVisualGroupShapeDrawingProperties14);
            nonVisualGroupShapeProperties14.Append(applicationNonVisualDrawingProperties80);

            GroupShapeProperties groupShapeProperties14 = new GroupShapeProperties();

            A.TransformGroup transformGroup14 = new A.TransformGroup();
            A.Offset offset42 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents42 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset14 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents14 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup14.Append(offset42);
            transformGroup14.Append(extents42);
            transformGroup14.Append(childOffset14);
            transformGroup14.Append(childExtents14);

            groupShapeProperties14.Append(transformGroup14);

            Shape shape67 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties67 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties81 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties67 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks65 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties67.Append(shapeLocks65);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties81 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape64 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties81.Append(placeholderShape64);

            nonVisualShapeProperties67.Append(nonVisualDrawingProperties81);
            nonVisualShapeProperties67.Append(nonVisualShapeDrawingProperties67);
            nonVisualShapeProperties67.Append(applicationNonVisualDrawingProperties81);

            ShapeProperties shapeProperties69 = new ShapeProperties();

            A.Transform2D transform2D29 = new A.Transform2D();
            A.Offset offset43 = new A.Offset() { X = 533399L, Y = 611872L };
            A.Extents extents43 = new A.Extents() { Cx = 3840480L, Cy = 1162050L };

            transform2D29.Append(offset43);
            transform2D29.Append(extents43);

            shapeProperties69.Append(transform2D29);

            TextBody textBody67 = new TextBody();
            A.BodyProperties bodyProperties69 = new A.BodyProperties() { Anchor = A.TextAnchoringTypeValues.Bottom };

            A.ListStyle listStyle69 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties24 = new A.Level1ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Center };
            A.DefaultRunProperties defaultRunProperties142 = new A.DefaultRunProperties() { FontSize = 3600, Bold = false };

            level1ParagraphProperties24.Append(defaultRunProperties142);

            listStyle69.Append(level1ParagraphProperties24);

            A.Paragraph paragraph99 = new A.Paragraph();

            A.Run run61 = new A.Run();

            A.RunProperties runProperties85 = new A.RunProperties() { Language = "en-US" };
            runProperties85.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text85 = new A.Text();
            text85.Text = "Click to edit Master title style";

            run61.Append(runProperties85);
            run61.Append(text85);
            A.EndParagraphRunProperties endParagraphRunProperties64 = new A.EndParagraphRunProperties();

            paragraph99.Append(run61);
            paragraph99.Append(endParagraphRunProperties64);

            textBody67.Append(bodyProperties69);
            textBody67.Append(listStyle69);
            textBody67.Append(paragraph99);

            shape67.Append(nonVisualShapeProperties67);
            shape67.Append(shapeProperties69);
            shape67.Append(textBody67);

            Shape shape68 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties68 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties82 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Content Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties68 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks66 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties68.Append(shapeLocks66);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties82 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape65 = new PlaceholderShape() { Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties82.Append(placeholderShape65);

            nonVisualShapeProperties68.Append(nonVisualDrawingProperties82);
            nonVisualShapeProperties68.Append(nonVisualShapeDrawingProperties68);
            nonVisualShapeProperties68.Append(applicationNonVisualDrawingProperties82);

            ShapeProperties shapeProperties70 = new ShapeProperties();

            A.Transform2D transform2D30 = new A.Transform2D();
            A.Offset offset44 = new A.Offset() { X = 4742824L, Y = 368300L };
            A.Extents extents44 = new A.Extents() { Cx = 3840480L, Cy = 5575300L };

            transform2D30.Append(offset44);
            transform2D30.Append(extents44);

            shapeProperties70.Append(transform2D30);

            TextBody textBody68 = new TextBody();

            A.BodyProperties bodyProperties70 = new A.BodyProperties();
            A.NormalAutoFit normalAutoFit10 = new A.NormalAutoFit();

            bodyProperties70.Append(normalAutoFit10);

            A.ListStyle listStyle70 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties25 = new A.Level1ParagraphProperties();

            A.SpaceBefore spaceBefore23 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints16 = new A.SpacingPoints() { Val = 2000 };

            spaceBefore23.Append(spacingPoints16);
            A.DefaultRunProperties defaultRunProperties143 = new A.DefaultRunProperties() { FontSize = 2200 };

            level1ParagraphProperties25.Append(spaceBefore23);
            level1ParagraphProperties25.Append(defaultRunProperties143);

            A.Level2ParagraphProperties level2ParagraphProperties15 = new A.Level2ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties144 = new A.DefaultRunProperties() { FontSize = 2000 };

            level2ParagraphProperties15.Append(defaultRunProperties144);

            A.Level3ParagraphProperties level3ParagraphProperties15 = new A.Level3ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties145 = new A.DefaultRunProperties() { FontSize = 1800 };

            level3ParagraphProperties15.Append(defaultRunProperties145);

            A.Level4ParagraphProperties level4ParagraphProperties15 = new A.Level4ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties146 = new A.DefaultRunProperties() { FontSize = 1800 };

            level4ParagraphProperties15.Append(defaultRunProperties146);

            A.Level5ParagraphProperties level5ParagraphProperties18 = new A.Level5ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties147 = new A.DefaultRunProperties() { FontSize = 1800 };

            level5ParagraphProperties18.Append(defaultRunProperties147);

            A.Level6ParagraphProperties level6ParagraphProperties15 = new A.Level6ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties148 = new A.DefaultRunProperties() { FontSize = 2000 };

            level6ParagraphProperties15.Append(defaultRunProperties148);

            A.Level7ParagraphProperties level7ParagraphProperties15 = new A.Level7ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties149 = new A.DefaultRunProperties() { FontSize = 2000 };

            level7ParagraphProperties15.Append(defaultRunProperties149);

            A.Level8ParagraphProperties level8ParagraphProperties15 = new A.Level8ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties150 = new A.DefaultRunProperties() { FontSize = 2000 };

            level8ParagraphProperties15.Append(defaultRunProperties150);

            A.Level9ParagraphProperties level9ParagraphProperties15 = new A.Level9ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties151 = new A.DefaultRunProperties() { FontSize = 2000 };

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

            A.Paragraph paragraph100 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties70 = new A.ParagraphProperties() { Level = 0 };

            A.Run run62 = new A.Run();

            A.RunProperties runProperties86 = new A.RunProperties() { Language = "en-US" };
            runProperties86.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text86 = new A.Text();
            text86.Text = "Click to edit Master text styles";

            run62.Append(runProperties86);
            run62.Append(text86);

            paragraph100.Append(paragraphProperties70);
            paragraph100.Append(run62);

            A.Paragraph paragraph101 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties71 = new A.ParagraphProperties() { Level = 1 };

            A.Run run63 = new A.Run();

            A.RunProperties runProperties87 = new A.RunProperties() { Language = "en-US" };
            runProperties87.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text87 = new A.Text();
            text87.Text = "Second level";

            run63.Append(runProperties87);
            run63.Append(text87);

            paragraph101.Append(paragraphProperties71);
            paragraph101.Append(run63);

            A.Paragraph paragraph102 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties72 = new A.ParagraphProperties() { Level = 2 };

            A.Run run64 = new A.Run();

            A.RunProperties runProperties88 = new A.RunProperties() { Language = "en-US" };
            runProperties88.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text88 = new A.Text();
            text88.Text = "Third level";

            run64.Append(runProperties88);
            run64.Append(text88);

            paragraph102.Append(paragraphProperties72);
            paragraph102.Append(run64);

            A.Paragraph paragraph103 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties73 = new A.ParagraphProperties() { Level = 3 };

            A.Run run65 = new A.Run();

            A.RunProperties runProperties89 = new A.RunProperties() { Language = "en-US" };
            runProperties89.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text89 = new A.Text();
            text89.Text = "Fourth level";

            run65.Append(runProperties89);
            run65.Append(text89);

            paragraph103.Append(paragraphProperties73);
            paragraph103.Append(run65);

            A.Paragraph paragraph104 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties74 = new A.ParagraphProperties() { Level = 4 };

            A.Run run66 = new A.Run();

            A.RunProperties runProperties90 = new A.RunProperties() { Language = "en-US" };
            runProperties90.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text90 = new A.Text();
            text90.Text = "Fifth level";

            run66.Append(runProperties90);
            run66.Append(text90);
            A.EndParagraphRunProperties endParagraphRunProperties65 = new A.EndParagraphRunProperties() { Dirty = false };

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

            Shape shape69 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties69 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties83 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Text Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties69 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks67 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties69.Append(shapeLocks67);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties83 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape66 = new PlaceholderShape() { Type = PlaceholderValues.Body, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)2U };

            applicationNonVisualDrawingProperties83.Append(placeholderShape66);

            nonVisualShapeProperties69.Append(nonVisualDrawingProperties83);
            nonVisualShapeProperties69.Append(nonVisualShapeDrawingProperties69);
            nonVisualShapeProperties69.Append(applicationNonVisualDrawingProperties83);

            ShapeProperties shapeProperties71 = new ShapeProperties();

            A.Transform2D transform2D31 = new A.Transform2D();
            A.Offset offset45 = new A.Offset() { X = 533399L, Y = 1787856L };
            A.Extents extents45 = new A.Extents() { Cx = 3840480L, Cy = 3720152L };

            transform2D31.Append(offset45);
            transform2D31.Append(extents45);

            shapeProperties71.Append(transform2D31);

            TextBody textBody69 = new TextBody();

            A.BodyProperties bodyProperties71 = new A.BodyProperties();
            A.NormalAutoFit normalAutoFit11 = new A.NormalAutoFit();

            bodyProperties71.Append(normalAutoFit11);

            A.ListStyle listStyle71 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties26 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };

            A.SpaceBefore spaceBefore24 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints17 = new A.SpacingPoints() { Val = 600 };

            spaceBefore24.Append(spacingPoints17);
            A.NoBullet noBullet69 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties152 = new A.DefaultRunProperties() { FontSize = 1800 };

            level1ParagraphProperties26.Append(spaceBefore24);
            level1ParagraphProperties26.Append(noBullet69);
            level1ParagraphProperties26.Append(defaultRunProperties152);

            A.Level2ParagraphProperties level2ParagraphProperties16 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0 };
            A.NoBullet noBullet70 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties153 = new A.DefaultRunProperties() { FontSize = 1200 };

            level2ParagraphProperties16.Append(noBullet70);
            level2ParagraphProperties16.Append(defaultRunProperties153);

            A.Level3ParagraphProperties level3ParagraphProperties16 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0 };
            A.NoBullet noBullet71 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties154 = new A.DefaultRunProperties() { FontSize = 1000 };

            level3ParagraphProperties16.Append(noBullet71);
            level3ParagraphProperties16.Append(defaultRunProperties154);

            A.Level4ParagraphProperties level4ParagraphProperties16 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0 };
            A.NoBullet noBullet72 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties155 = new A.DefaultRunProperties() { FontSize = 900 };

            level4ParagraphProperties16.Append(noBullet72);
            level4ParagraphProperties16.Append(defaultRunProperties155);

            A.Level5ParagraphProperties level5ParagraphProperties19 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0 };
            A.NoBullet noBullet73 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties156 = new A.DefaultRunProperties() { FontSize = 900 };

            level5ParagraphProperties19.Append(noBullet73);
            level5ParagraphProperties19.Append(defaultRunProperties156);

            A.Level6ParagraphProperties level6ParagraphProperties16 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0 };
            A.NoBullet noBullet74 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties157 = new A.DefaultRunProperties() { FontSize = 900 };

            level6ParagraphProperties16.Append(noBullet74);
            level6ParagraphProperties16.Append(defaultRunProperties157);

            A.Level7ParagraphProperties level7ParagraphProperties16 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0 };
            A.NoBullet noBullet75 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties158 = new A.DefaultRunProperties() { FontSize = 900 };

            level7ParagraphProperties16.Append(noBullet75);
            level7ParagraphProperties16.Append(defaultRunProperties158);

            A.Level8ParagraphProperties level8ParagraphProperties16 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0 };
            A.NoBullet noBullet76 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties159 = new A.DefaultRunProperties() { FontSize = 900 };

            level8ParagraphProperties16.Append(noBullet76);
            level8ParagraphProperties16.Append(defaultRunProperties159);

            A.Level9ParagraphProperties level9ParagraphProperties16 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0 };
            A.NoBullet noBullet77 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties160 = new A.DefaultRunProperties() { FontSize = 900 };

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

            A.Paragraph paragraph105 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties75 = new A.ParagraphProperties() { Level = 0 };

            A.Run run67 = new A.Run();

            A.RunProperties runProperties91 = new A.RunProperties() { Language = "en-US" };
            runProperties91.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text91 = new A.Text();
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

            Shape shape70 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties70 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties84 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Date Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties70 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks68 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties70.Append(shapeLocks68);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties84 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape67 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties84.Append(placeholderShape67);

            nonVisualShapeProperties70.Append(nonVisualDrawingProperties84);
            nonVisualShapeProperties70.Append(nonVisualShapeDrawingProperties70);
            nonVisualShapeProperties70.Append(applicationNonVisualDrawingProperties84);
            ShapeProperties shapeProperties72 = new ShapeProperties();

            TextBody textBody70 = new TextBody();
            A.BodyProperties bodyProperties72 = new A.BodyProperties();
            A.ListStyle listStyle72 = new A.ListStyle();

            A.Paragraph paragraph106 = new A.Paragraph();

            A.Field field25 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties92 = new A.RunProperties() { Language = "en-US" };
            runProperties92.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties76 = new A.ParagraphProperties();
            A.Text text92 = new A.Text();
            text92.Text = "29/11/13";

            field25.Append(runProperties92);
            field25.Append(paragraphProperties76);
            field25.Append(text92);
            A.EndParagraphRunProperties endParagraphRunProperties66 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph106.Append(field25);
            paragraph106.Append(endParagraphRunProperties66);

            textBody70.Append(bodyProperties72);
            textBody70.Append(listStyle72);
            textBody70.Append(paragraph106);

            shape70.Append(nonVisualShapeProperties70);
            shape70.Append(shapeProperties72);
            shape70.Append(textBody70);

            Shape shape71 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties71 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties85 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Footer Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties71 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks69 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties71.Append(shapeLocks69);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties85 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape68 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties85.Append(placeholderShape68);

            nonVisualShapeProperties71.Append(nonVisualDrawingProperties85);
            nonVisualShapeProperties71.Append(nonVisualShapeDrawingProperties71);
            nonVisualShapeProperties71.Append(applicationNonVisualDrawingProperties85);
            ShapeProperties shapeProperties73 = new ShapeProperties();

            TextBody textBody71 = new TextBody();
            A.BodyProperties bodyProperties73 = new A.BodyProperties();
            A.ListStyle listStyle73 = new A.ListStyle();

            A.Paragraph paragraph107 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties67 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph107.Append(endParagraphRunProperties67);

            textBody71.Append(bodyProperties73);
            textBody71.Append(listStyle73);
            textBody71.Append(paragraph107);

            shape71.Append(nonVisualShapeProperties71);
            shape71.Append(shapeProperties73);
            shape71.Append(textBody71);

            Shape shape72 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties72 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties86 = new NonVisualDrawingProperties() { Id = (UInt32Value)7U, Name = "Slide Number Placeholder 6" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties72 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks70 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties72.Append(shapeLocks70);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties86 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape69 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties86.Append(placeholderShape69);

            nonVisualShapeProperties72.Append(nonVisualDrawingProperties86);
            nonVisualShapeProperties72.Append(nonVisualShapeDrawingProperties72);
            nonVisualShapeProperties72.Append(applicationNonVisualDrawingProperties86);
            ShapeProperties shapeProperties74 = new ShapeProperties();

            TextBody textBody72 = new TextBody();
            A.BodyProperties bodyProperties74 = new A.BodyProperties();
            A.ListStyle listStyle74 = new A.ListStyle();

            A.Paragraph paragraph108 = new A.Paragraph();

            A.Field field26 = new A.Field() { Id = "{7F5CE407-6216-4202-80E4-A30DC2F709B2}", Type = "slidenum" };

            A.RunProperties runProperties93 = new A.RunProperties() { Language = "en-US" };
            runProperties93.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text93 = new A.Text();
            text93.Text = "‹#›";

            field26.Append(runProperties93);
            field26.Append(text93);
            A.EndParagraphRunProperties endParagraphRunProperties68 = new A.EndParagraphRunProperties() { Language = "en-US" };

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

            ColorMapOverride colorMapOverride13 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping13 = new A.MasterColorMapping();

            colorMapOverride13.Append(masterColorMapping13);

            slideLayout12.Append(commonSlideData14);
            slideLayout12.Append(colorMapOverride13);

            slideLayoutPart12.SlideLayout = slideLayout12;
        }

        // Generates content of slideLayoutPart13.
        private void GenerateSlideLayoutPart13Content(SlideLayoutPart slideLayoutPart13)
        {
            SlideLayout slideLayout13 = new SlideLayout() { Preserve = true };
            slideLayout13.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout13.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout13.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData15 = new CommonSlideData() { Name = "Picture with Caption" };

            ShapeTree shapeTree15 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties15 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties87 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties15 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties87 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties15.Append(nonVisualDrawingProperties87);
            nonVisualGroupShapeProperties15.Append(nonVisualGroupShapeDrawingProperties15);
            nonVisualGroupShapeProperties15.Append(applicationNonVisualDrawingProperties87);

            GroupShapeProperties groupShapeProperties15 = new GroupShapeProperties();

            A.TransformGroup transformGroup15 = new A.TransformGroup();
            A.Offset offset46 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents46 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset15 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents15 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup15.Append(offset46);
            transformGroup15.Append(extents46);
            transformGroup15.Append(childOffset15);
            transformGroup15.Append(childExtents15);

            groupShapeProperties15.Append(transformGroup15);

            Shape shape73 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties73 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties88 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties73 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks71 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties73.Append(shapeLocks71);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties88 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape70 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties88.Append(placeholderShape70);

            nonVisualShapeProperties73.Append(nonVisualDrawingProperties88);
            nonVisualShapeProperties73.Append(nonVisualShapeDrawingProperties73);
            nonVisualShapeProperties73.Append(applicationNonVisualDrawingProperties88);

            ShapeProperties shapeProperties75 = new ShapeProperties();

            A.Transform2D transform2D32 = new A.Transform2D();
            A.Offset offset47 = new A.Offset() { X = 533398L, Y = 611872L };
            A.Extents extents47 = new A.Extents() { Cx = 4079545L, Cy = 1162050L };

            transform2D32.Append(offset47);
            transform2D32.Append(extents47);

            shapeProperties75.Append(transform2D32);

            TextBody textBody73 = new TextBody();
            A.BodyProperties bodyProperties75 = new A.BodyProperties() { Anchor = A.TextAnchoringTypeValues.Bottom };

            A.ListStyle listStyle75 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties27 = new A.Level1ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Center };
            A.DefaultRunProperties defaultRunProperties161 = new A.DefaultRunProperties() { FontSize = 3600, Bold = false };

            level1ParagraphProperties27.Append(defaultRunProperties161);

            listStyle75.Append(level1ParagraphProperties27);

            A.Paragraph paragraph109 = new A.Paragraph();

            A.Run run68 = new A.Run();

            A.RunProperties runProperties94 = new A.RunProperties() { Language = "en-US" };
            runProperties94.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text94 = new A.Text();
            text94.Text = "Click to edit Master title style";

            run68.Append(runProperties94);
            run68.Append(text94);
            A.EndParagraphRunProperties endParagraphRunProperties69 = new A.EndParagraphRunProperties();

            paragraph109.Append(run68);
            paragraph109.Append(endParagraphRunProperties69);

            textBody73.Append(bodyProperties75);
            textBody73.Append(listStyle75);
            textBody73.Append(paragraph109);

            shape73.Append(nonVisualShapeProperties73);
            shape73.Append(shapeProperties75);
            shape73.Append(textBody73);

            Shape shape74 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties74 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties89 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Text Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties74 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks72 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties74.Append(shapeLocks72);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties89 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape71 = new PlaceholderShape() { Type = PlaceholderValues.Body, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)2U };

            applicationNonVisualDrawingProperties89.Append(placeholderShape71);

            nonVisualShapeProperties74.Append(nonVisualDrawingProperties89);
            nonVisualShapeProperties74.Append(nonVisualShapeDrawingProperties74);
            nonVisualShapeProperties74.Append(applicationNonVisualDrawingProperties89);

            ShapeProperties shapeProperties76 = new ShapeProperties();

            A.Transform2D transform2D33 = new A.Transform2D();
            A.Offset offset48 = new A.Offset() { X = 533398L, Y = 1787856L };
            A.Extents extents48 = new A.Extents() { Cx = 4079545L, Cy = 3720152L };

            transform2D33.Append(offset48);
            transform2D33.Append(extents48);

            shapeProperties76.Append(transform2D33);

            TextBody textBody74 = new TextBody();

            A.BodyProperties bodyProperties76 = new A.BodyProperties();
            A.NormalAutoFit normalAutoFit12 = new A.NormalAutoFit();

            bodyProperties76.Append(normalAutoFit12);

            A.ListStyle listStyle76 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties28 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };

            A.SpaceBefore spaceBefore25 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints18 = new A.SpacingPoints() { Val = 600 };

            spaceBefore25.Append(spacingPoints18);
            A.NoBullet noBullet78 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties162 = new A.DefaultRunProperties() { FontSize = 1800 };

            level1ParagraphProperties28.Append(spaceBefore25);
            level1ParagraphProperties28.Append(noBullet78);
            level1ParagraphProperties28.Append(defaultRunProperties162);

            A.Level2ParagraphProperties level2ParagraphProperties17 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0 };
            A.NoBullet noBullet79 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties163 = new A.DefaultRunProperties() { FontSize = 1200 };

            level2ParagraphProperties17.Append(noBullet79);
            level2ParagraphProperties17.Append(defaultRunProperties163);

            A.Level3ParagraphProperties level3ParagraphProperties17 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0 };
            A.NoBullet noBullet80 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties164 = new A.DefaultRunProperties() { FontSize = 1000 };

            level3ParagraphProperties17.Append(noBullet80);
            level3ParagraphProperties17.Append(defaultRunProperties164);

            A.Level4ParagraphProperties level4ParagraphProperties17 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0 };
            A.NoBullet noBullet81 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties165 = new A.DefaultRunProperties() { FontSize = 900 };

            level4ParagraphProperties17.Append(noBullet81);
            level4ParagraphProperties17.Append(defaultRunProperties165);

            A.Level5ParagraphProperties level5ParagraphProperties20 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0 };
            A.NoBullet noBullet82 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties166 = new A.DefaultRunProperties() { FontSize = 900 };

            level5ParagraphProperties20.Append(noBullet82);
            level5ParagraphProperties20.Append(defaultRunProperties166);

            A.Level6ParagraphProperties level6ParagraphProperties17 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0 };
            A.NoBullet noBullet83 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties167 = new A.DefaultRunProperties() { FontSize = 900 };

            level6ParagraphProperties17.Append(noBullet83);
            level6ParagraphProperties17.Append(defaultRunProperties167);

            A.Level7ParagraphProperties level7ParagraphProperties17 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0 };
            A.NoBullet noBullet84 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties168 = new A.DefaultRunProperties() { FontSize = 900 };

            level7ParagraphProperties17.Append(noBullet84);
            level7ParagraphProperties17.Append(defaultRunProperties168);

            A.Level8ParagraphProperties level8ParagraphProperties17 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0 };
            A.NoBullet noBullet85 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties169 = new A.DefaultRunProperties() { FontSize = 900 };

            level8ParagraphProperties17.Append(noBullet85);
            level8ParagraphProperties17.Append(defaultRunProperties169);

            A.Level9ParagraphProperties level9ParagraphProperties17 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0 };
            A.NoBullet noBullet86 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties170 = new A.DefaultRunProperties() { FontSize = 900 };

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

            A.Paragraph paragraph110 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties77 = new A.ParagraphProperties() { Level = 0 };

            A.Run run69 = new A.Run();

            A.RunProperties runProperties95 = new A.RunProperties() { Language = "en-US" };
            runProperties95.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text95 = new A.Text();
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

            Shape shape75 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties75 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties90 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Date Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties75 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks73 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties75.Append(shapeLocks73);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties90 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape72 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties90.Append(placeholderShape72);

            nonVisualShapeProperties75.Append(nonVisualDrawingProperties90);
            nonVisualShapeProperties75.Append(nonVisualShapeDrawingProperties75);
            nonVisualShapeProperties75.Append(applicationNonVisualDrawingProperties90);
            ShapeProperties shapeProperties77 = new ShapeProperties();

            TextBody textBody75 = new TextBody();
            A.BodyProperties bodyProperties77 = new A.BodyProperties();
            A.ListStyle listStyle77 = new A.ListStyle();

            A.Paragraph paragraph111 = new A.Paragraph();

            A.Field field27 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties96 = new A.RunProperties() { Language = "en-US" };
            runProperties96.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties78 = new A.ParagraphProperties();
            A.Text text96 = new A.Text();
            text96.Text = "29/11/13";

            field27.Append(runProperties96);
            field27.Append(paragraphProperties78);
            field27.Append(text96);
            A.EndParagraphRunProperties endParagraphRunProperties70 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph111.Append(field27);
            paragraph111.Append(endParagraphRunProperties70);

            textBody75.Append(bodyProperties77);
            textBody75.Append(listStyle77);
            textBody75.Append(paragraph111);

            shape75.Append(nonVisualShapeProperties75);
            shape75.Append(shapeProperties77);
            shape75.Append(textBody75);

            Shape shape76 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties76 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties91 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Footer Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties76 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks74 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties76.Append(shapeLocks74);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties91 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape73 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties91.Append(placeholderShape73);

            nonVisualShapeProperties76.Append(nonVisualDrawingProperties91);
            nonVisualShapeProperties76.Append(nonVisualShapeDrawingProperties76);
            nonVisualShapeProperties76.Append(applicationNonVisualDrawingProperties91);
            ShapeProperties shapeProperties78 = new ShapeProperties();

            TextBody textBody76 = new TextBody();
            A.BodyProperties bodyProperties78 = new A.BodyProperties();
            A.ListStyle listStyle78 = new A.ListStyle();

            A.Paragraph paragraph112 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties71 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph112.Append(endParagraphRunProperties71);

            textBody76.Append(bodyProperties78);
            textBody76.Append(listStyle78);
            textBody76.Append(paragraph112);

            shape76.Append(nonVisualShapeProperties76);
            shape76.Append(shapeProperties78);
            shape76.Append(textBody76);

            Shape shape77 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties77 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties92 = new NonVisualDrawingProperties() { Id = (UInt32Value)7U, Name = "Slide Number Placeholder 6" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties77 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks75 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties77.Append(shapeLocks75);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties92 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape74 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties92.Append(placeholderShape74);

            nonVisualShapeProperties77.Append(nonVisualDrawingProperties92);
            nonVisualShapeProperties77.Append(nonVisualShapeDrawingProperties77);
            nonVisualShapeProperties77.Append(applicationNonVisualDrawingProperties92);
            ShapeProperties shapeProperties79 = new ShapeProperties();

            TextBody textBody77 = new TextBody();
            A.BodyProperties bodyProperties79 = new A.BodyProperties();
            A.ListStyle listStyle79 = new A.ListStyle();

            A.Paragraph paragraph113 = new A.Paragraph();

            A.Field field28 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties97 = new A.RunProperties() { Language = "en-US" };
            runProperties97.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.ParagraphProperties paragraphProperties79 = new A.ParagraphProperties();
            A.Text text97 = new A.Text();
            text97.Text = "‹#›";

            field28.Append(runProperties97);
            field28.Append(paragraphProperties79);
            field28.Append(text97);
            A.EndParagraphRunProperties endParagraphRunProperties72 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph113.Append(field28);
            paragraph113.Append(endParagraphRunProperties72);

            textBody77.Append(bodyProperties79);
            textBody77.Append(listStyle79);
            textBody77.Append(paragraph113);

            shape77.Append(nonVisualShapeProperties77);
            shape77.Append(shapeProperties79);
            shape77.Append(textBody77);

            Shape shape78 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties78 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties93 = new NonVisualDrawingProperties() { Id = (UInt32Value)8U, Name = "Picture Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties78 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks76 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties78.Append(shapeLocks76);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties93 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape75 = new PlaceholderShape() { Type = PlaceholderValues.Picture, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties93.Append(placeholderShape75);

            nonVisualShapeProperties78.Append(nonVisualDrawingProperties93);
            nonVisualShapeProperties78.Append(nonVisualShapeDrawingProperties78);
            nonVisualShapeProperties78.Append(applicationNonVisualDrawingProperties93);

            ShapeProperties shapeProperties80 = new ShapeProperties();

            A.Transform2D transform2D34 = new A.Transform2D();
            A.Offset offset49 = new A.Offset() { X = 5090617L, Y = 359392L };
            A.Extents extents49 = new A.Extents() { Cx = 3657600L, Cy = 5318077L };

            transform2D34.Append(offset49);
            transform2D34.Append(extents49);

            A.Outline outline6 = new A.Outline() { Width = 3175 };

            A.SolidFill solidFill80 = new A.SolidFill();
            A.SchemeColor schemeColor111 = new A.SchemeColor() { Val = A.SchemeColorValues.Background1 };

            solidFill80.Append(schemeColor111);

            outline6.Append(solidFill80);

            A.EffectList effectList6 = new A.EffectList();

            A.OuterShadow outerShadow5 = new A.OuterShadow() { BlurRadius = 63500L, HorizontalRatio = 100500, VerticalRatio = 100500, Alignment = A.RectangleAlignmentValues.Center, RotateWithShape = false };

            A.PresetColor presetColor3 = new A.PresetColor() { Val = A.PresetColorValues.Black };
            A.Alpha alpha6 = new A.Alpha() { Val = 50000 };

            presetColor3.Append(alpha6);

            outerShadow5.Append(presetColor3);

            effectList6.Append(outerShadow5);

            shapeProperties80.Append(transform2D34);
            shapeProperties80.Append(outline6);
            shapeProperties80.Append(effectList6);

            TextBody textBody78 = new TextBody();

            A.BodyProperties bodyProperties80 = new A.BodyProperties() { Vertical = A.TextVerticalValues.Horizontal, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, RightToLeftColumns = false };
            A.NormalAutoFit normalAutoFit13 = new A.NormalAutoFit();

            bodyProperties80.Append(normalAutoFit13);

            A.ListStyle listStyle80 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties29 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore26 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints19 = new A.SpacingPoints() { Val = 2000 };

            spaceBefore26.Append(spacingPoints19);

            A.BulletColor bulletColor13 = new A.BulletColor();

            A.SchemeColor schemeColor112 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };
            A.LuminanceModulation luminanceModulation23 = new A.LuminanceModulation() { Val = 60000 };
            A.LuminanceOffset luminanceOffset21 = new A.LuminanceOffset() { Val = 40000 };

            schemeColor112.Append(luminanceModulation23);
            schemeColor112.Append(luminanceOffset21);

            bulletColor13.Append(schemeColor112);
            A.BulletSizePercentage bulletSizePercentage13 = new A.BulletSizePercentage() { Val = 110000 };
            A.BulletFont bulletFont13 = new A.BulletFont() { Typeface = "Wingdings 2", PitchFamily = 18, CharacterSet = 2 };
            A.NoBullet noBullet87 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties171 = new A.DefaultRunProperties() { FontSize = 3200, Kerning = 1200 };

            A.SolidFill solidFill81 = new A.SolidFill();

            A.SchemeColor schemeColor113 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.LuminanceModulation luminanceModulation24 = new A.LuminanceModulation() { Val = 65000 };
            A.LuminanceOffset luminanceOffset22 = new A.LuminanceOffset() { Val = 35000 };

            schemeColor113.Append(luminanceModulation24);
            schemeColor113.Append(luminanceOffset22);

            solidFill81.Append(schemeColor113);
            A.LatinFont latinFont35 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont35 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont35 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

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

            A.Level2ParagraphProperties level2ParagraphProperties18 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0 };
            A.NoBullet noBullet88 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties172 = new A.DefaultRunProperties() { FontSize = 2800 };

            level2ParagraphProperties18.Append(noBullet88);
            level2ParagraphProperties18.Append(defaultRunProperties172);

            A.Level3ParagraphProperties level3ParagraphProperties18 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0 };
            A.NoBullet noBullet89 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties173 = new A.DefaultRunProperties() { FontSize = 2400 };

            level3ParagraphProperties18.Append(noBullet89);
            level3ParagraphProperties18.Append(defaultRunProperties173);

            A.Level4ParagraphProperties level4ParagraphProperties18 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0 };
            A.NoBullet noBullet90 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties174 = new A.DefaultRunProperties() { FontSize = 2000 };

            level4ParagraphProperties18.Append(noBullet90);
            level4ParagraphProperties18.Append(defaultRunProperties174);

            A.Level5ParagraphProperties level5ParagraphProperties21 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0 };
            A.NoBullet noBullet91 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties175 = new A.DefaultRunProperties() { FontSize = 2000 };

            level5ParagraphProperties21.Append(noBullet91);
            level5ParagraphProperties21.Append(defaultRunProperties175);

            A.Level6ParagraphProperties level6ParagraphProperties18 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0 };
            A.NoBullet noBullet92 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties176 = new A.DefaultRunProperties() { FontSize = 2000 };

            level6ParagraphProperties18.Append(noBullet92);
            level6ParagraphProperties18.Append(defaultRunProperties176);

            A.Level7ParagraphProperties level7ParagraphProperties18 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0 };
            A.NoBullet noBullet93 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties177 = new A.DefaultRunProperties() { FontSize = 2000 };

            level7ParagraphProperties18.Append(noBullet93);
            level7ParagraphProperties18.Append(defaultRunProperties177);

            A.Level8ParagraphProperties level8ParagraphProperties18 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0 };
            A.NoBullet noBullet94 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties178 = new A.DefaultRunProperties() { FontSize = 2000 };

            level8ParagraphProperties18.Append(noBullet94);
            level8ParagraphProperties18.Append(defaultRunProperties178);

            A.Level9ParagraphProperties level9ParagraphProperties18 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0 };
            A.NoBullet noBullet95 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties179 = new A.DefaultRunProperties() { FontSize = 2000 };

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

            A.Paragraph paragraph114 = new A.Paragraph();

            A.Run run70 = new A.Run();

            A.RunProperties runProperties98 = new A.RunProperties() { Language = "en-US" };
            runProperties98.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text98 = new A.Text();
            text98.Text = "Drag picture to placeholder or click icon to add";

            run70.Append(runProperties98);
            run70.Append(text98);
            A.EndParagraphRunProperties endParagraphRunProperties73 = new A.EndParagraphRunProperties();

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

            ColorMapOverride colorMapOverride14 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping14 = new A.MasterColorMapping();

            colorMapOverride14.Append(masterColorMapping14);

            slideLayout13.Append(commonSlideData15);
            slideLayout13.Append(colorMapOverride14);

            slideLayoutPart13.SlideLayout = slideLayout13;
        }

        // Generates content of slidePart2.
        private void GenerateSlidePart2Content(SlidePart slidePart2)
        {
            Slide slide2 = new Slide();
            slide2.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slide2.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slide2.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData16 = new CommonSlideData();

            ShapeTree shapeTree16 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties16 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties94 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties16 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties94 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties16.Append(nonVisualDrawingProperties94);
            nonVisualGroupShapeProperties16.Append(nonVisualGroupShapeDrawingProperties16);
            nonVisualGroupShapeProperties16.Append(applicationNonVisualDrawingProperties94);

            GroupShapeProperties groupShapeProperties16 = new GroupShapeProperties();

            A.TransformGroup transformGroup16 = new A.TransformGroup();
            A.Offset offset50 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents50 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset16 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents16 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup16.Append(offset50);
            transformGroup16.Append(extents50);
            transformGroup16.Append(childOffset16);
            transformGroup16.Append(childExtents16);

            groupShapeProperties16.Append(transformGroup16);

            Picture picture1 = new Picture();

            NonVisualPictureProperties nonVisualPictureProperties1 = new NonVisualPictureProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties95 = new NonVisualDrawingProperties() { Id = (UInt32Value)1026U, Name = "Picture 2" };

            NonVisualPictureDrawingProperties nonVisualPictureDrawingProperties1 = new NonVisualPictureDrawingProperties();
            A.PictureLocks pictureLocks1 = new A.PictureLocks() { NoChangeAspect = true, NoChangeArrowheads = true };

            nonVisualPictureDrawingProperties1.Append(pictureLocks1);
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties95 = new ApplicationNonVisualDrawingProperties();

            nonVisualPictureProperties1.Append(nonVisualDrawingProperties95);
            nonVisualPictureProperties1.Append(nonVisualPictureDrawingProperties1);
            nonVisualPictureProperties1.Append(applicationNonVisualDrawingProperties95);

            BlipFill blipFill2 = new BlipFill();

            A.Blip blip2 = new A.Blip() { Embed = "rId2", CompressionState = A.BlipCompressionValues.Print };

            A.BlipExtensionList blipExtensionList1 = new A.BlipExtensionList();

            A.BlipExtension blipExtension1 = new A.BlipExtension() { Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}" };

            A14.UseLocalDpi useLocalDpi1 = new A14.UseLocalDpi() { Val = false };
            useLocalDpi1.AddNamespaceDeclaration("a14", "http://schemas.microsoft.com/office/drawing/2010/main");

            blipExtension1.Append(useLocalDpi1);

            blipExtensionList1.Append(blipExtension1);

            blip2.Append(blipExtensionList1);
            A.SourceRectangle sourceRectangle1 = new A.SourceRectangle();

            A.Stretch stretch2 = new A.Stretch();
            A.FillRectangle fillRectangle1 = new A.FillRectangle();

            stretch2.Append(fillRectangle1);

            blipFill2.Append(blip2);
            blipFill2.Append(sourceRectangle1);
            blipFill2.Append(stretch2);

            ShapeProperties shapeProperties81 = new ShapeProperties() { BlackWhiteMode = A.BlackWhiteModeValues.Auto };

            A.Transform2D transform2D35 = new A.Transform2D();
            A.Offset offset51 = new A.Offset() { X = 457200L, Y = 1219200L };
            A.Extents extents51 = new A.Extents() { Cx = 8305800L, Cy = 5354794L };

            transform2D35.Append(offset51);
            transform2D35.Append(extents51);

            A.PresetGeometry presetGeometry9 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList9 = new A.AdjustValueList();

            presetGeometry9.Append(adjustValueList9);

            A.Outline outline7 = new A.Outline();
            A.NoFill noFill2 = new A.NoFill();

            outline7.Append(noFill2);

            A.EffectList effectList7 = new A.EffectList();

            A.OuterShadow outerShadow6 = new A.OuterShadow() { BlurRadius = 292100L, Distance = 139700L, Direction = 2700000, Alignment = A.RectangleAlignmentValues.TopLeft, RotateWithShape = false };

            A.RgbColorModelHex rgbColorModelHex14 = new A.RgbColorModelHex() { Val = "333333" };
            A.Alpha alpha7 = new A.Alpha() { Val = 65000 };

            rgbColorModelHex14.Append(alpha7);

            outerShadow6.Append(rgbColorModelHex14);

            effectList7.Append(outerShadow6);

            A.ShapePropertiesExtensionList shapePropertiesExtensionList1 = new A.ShapePropertiesExtensionList();

            A.ShapePropertiesExtension shapePropertiesExtension1 = new A.ShapePropertiesExtension() { Uri = "{909E8E84-426E-40dd-AFC4-6F175D3DCCD1}" };

            A14.HiddenFillProperties hiddenFillProperties1 = new A14.HiddenFillProperties();
            hiddenFillProperties1.AddNamespaceDeclaration("a14", "http://schemas.microsoft.com/office/drawing/2010/main");

            A.SolidFill solidFill82 = new A.SolidFill();
            A.SchemeColor schemeColor114 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            solidFill82.Append(schemeColor114);

            hiddenFillProperties1.Append(solidFill82);

            shapePropertiesExtension1.Append(hiddenFillProperties1);

            A.ShapePropertiesExtension shapePropertiesExtension2 = new A.ShapePropertiesExtension() { Uri = "{91240B29-F687-4f45-9708-019B960494DF}" };

            A14.HiddenLineProperties hiddenLineProperties1 = new A14.HiddenLineProperties() { Width = 9525 };
            hiddenLineProperties1.AddNamespaceDeclaration("a14", "http://schemas.microsoft.com/office/drawing/2010/main");

            A.SolidFill solidFill83 = new A.SolidFill();
            A.SchemeColor schemeColor115 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill83.Append(schemeColor115);
            A.Miter miter1 = new A.Miter() { Limit = 800000 };
            A.HeadEnd headEnd1 = new A.HeadEnd();
            A.TailEnd tailEnd1 = new A.TailEnd();

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

            Shape shape79 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties79 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties96 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Title 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties79 = new NonVisualShapeDrawingProperties() { TextBox = true };
            A.ShapeLocks shapeLocks77 = new A.ShapeLocks();

            nonVisualShapeDrawingProperties79.Append(shapeLocks77);
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties96 = new ApplicationNonVisualDrawingProperties();

            nonVisualShapeProperties79.Append(nonVisualDrawingProperties96);
            nonVisualShapeProperties79.Append(nonVisualShapeDrawingProperties79);
            nonVisualShapeProperties79.Append(applicationNonVisualDrawingProperties96);

            ShapeProperties shapeProperties82 = new ShapeProperties();

            A.Transform2D transform2D36 = new A.Transform2D();
            A.Offset offset52 = new A.Offset() { X = 533400L, Y = 152400L };
            A.Extents extents52 = new A.Extents() { Cx = 8042276L, Cy = 758732L };

            transform2D36.Append(offset52);
            transform2D36.Append(extents52);

            A.PresetGeometry presetGeometry10 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList10 = new A.AdjustValueList();

            presetGeometry10.Append(adjustValueList10);

            shapeProperties82.Append(transform2D36);
            shapeProperties82.Append(presetGeometry10);

            TextBody textBody79 = new TextBody();

            A.BodyProperties bodyProperties81 = new A.BodyProperties() { Vertical = A.TextVerticalValues.Horizontal, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, RightToLeftColumns = false, Anchor = A.TextAnchoringTypeValues.Bottom, AnchorCenter = false };
            A.NoAutoFit noAutoFit6 = new A.NoAutoFit();

            bodyProperties81.Append(noAutoFit6);

            A.ListStyle listStyle81 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties30 = new A.Level1ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Center, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore27 = new A.SpaceBefore();
            A.SpacingPercent spacingPercent8 = new A.SpacingPercent() { Val = 0 };

            spaceBefore27.Append(spacingPercent8);
            A.NoBullet noBullet96 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties180 = new A.DefaultRunProperties() { FontSize = 4600, Kerning = 1200 };

            A.SolidFill solidFill84 = new A.SolidFill();
            A.SchemeColor schemeColor116 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            solidFill84.Append(schemeColor116);
            A.LatinFont latinFont36 = new A.LatinFont() { Typeface = "+mj-lt" };
            A.EastAsianFont eastAsianFont36 = new A.EastAsianFont() { Typeface = "+mj-ea" };
            A.ComplexScriptFont complexScriptFont36 = new A.ComplexScriptFont() { Typeface = "+mj-cs" };

            defaultRunProperties180.Append(solidFill84);
            defaultRunProperties180.Append(latinFont36);
            defaultRunProperties180.Append(eastAsianFont36);
            defaultRunProperties180.Append(complexScriptFont36);

            level1ParagraphProperties30.Append(spaceBefore27);
            level1ParagraphProperties30.Append(noBullet96);
            level1ParagraphProperties30.Append(defaultRunProperties180);

            listStyle81.Append(level1ParagraphProperties30);

            A.Paragraph paragraph115 = new A.Paragraph();

            A.Run run71 = new A.Run();

            A.RunProperties runProperties99 = new A.RunProperties() { Language = "en-US", FontSize = 2200, Dirty = false };
            runProperties99.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text99 = new A.Text();
            text99.Text = "{title}";

            run71.Append(runProperties99);
            run71.Append(text99);
            A.EndParagraphRunProperties endParagraphRunProperties74 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 2200, Dirty = false };

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

            CommonSlideDataExtensionList commonSlideDataExtensionList3 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension3 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId3 = new P14.CreationId() { Val = (UInt32Value)3486677695U };
            creationId3.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension3.Append(creationId3);

            commonSlideDataExtensionList3.Append(commonSlideDataExtension3);

            commonSlideData16.Append(shapeTree16);
            commonSlideData16.Append(commonSlideDataExtensionList3);

            ColorMapOverride colorMapOverride15 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping15 = new A.MasterColorMapping();

            colorMapOverride15.Append(masterColorMapping15);

            AlternateContent alternateContent1 = new AlternateContent();
            alternateContent1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            alternateContent1.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            AlternateContentChoice alternateContentChoice1 = new AlternateContentChoice() { Requires = "p14" };
            Transition transition1 = new Transition() { Speed = TransitionSpeedValues.Slow, Duration = "2000" };

            alternateContentChoice1.Append(transition1);

            AlternateContentFallback alternateContentFallback1 = new AlternateContentFallback();

            Transition transition2 = new Transition() { Speed = TransitionSpeedValues.Slow };
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
            System.IO.Stream data = GetBinaryDataStream(imagePart2Data);
            imagePart2.FeedData(data);
            data.Close();
        }

        // Generates content of slidePart3.
        private void GenerateSlidePart3Content(SlidePart slidePart3)
        {
            Slide slide3 = new Slide();
            slide3.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slide3.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slide3.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData17 = new CommonSlideData();

            ShapeTree shapeTree17 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties17 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties97 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties17 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties97 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties17.Append(nonVisualDrawingProperties97);
            nonVisualGroupShapeProperties17.Append(nonVisualGroupShapeDrawingProperties17);
            nonVisualGroupShapeProperties17.Append(applicationNonVisualDrawingProperties97);

            GroupShapeProperties groupShapeProperties17 = new GroupShapeProperties();

            A.TransformGroup transformGroup17 = new A.TransformGroup();
            A.Offset offset53 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents53 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset17 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents17 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup17.Append(offset53);
            transformGroup17.Append(extents53);
            transformGroup17.Append(childOffset17);
            transformGroup17.Append(childExtents17);

            groupShapeProperties17.Append(transformGroup17);

            GraphicFrame graphicFrame1 = new GraphicFrame();

            NonVisualGraphicFrameProperties nonVisualGraphicFrameProperties1 = new NonVisualGraphicFrameProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties98 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Table 3" };

            NonVisualGraphicFrameDrawingProperties nonVisualGraphicFrameDrawingProperties1 = new NonVisualGraphicFrameDrawingProperties();
            A.GraphicFrameLocks graphicFrameLocks1 = new A.GraphicFrameLocks() { NoGrouping = true };

            nonVisualGraphicFrameDrawingProperties1.Append(graphicFrameLocks1);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties98 = new ApplicationNonVisualDrawingProperties();

            ApplicationNonVisualDrawingPropertiesExtensionList applicationNonVisualDrawingPropertiesExtensionList1 = new ApplicationNonVisualDrawingPropertiesExtensionList();

            ApplicationNonVisualDrawingPropertiesExtension applicationNonVisualDrawingPropertiesExtension1 = new ApplicationNonVisualDrawingPropertiesExtension() { Uri = "{D42A27DB-BD31-4B8C-83A1-F6EECF244321}" };

            P14.ModificationId modificationId1 = new P14.ModificationId() { Val = (UInt32Value)2159725999U };
            modificationId1.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            applicationNonVisualDrawingPropertiesExtension1.Append(modificationId1);

            applicationNonVisualDrawingPropertiesExtensionList1.Append(applicationNonVisualDrawingPropertiesExtension1);

            applicationNonVisualDrawingProperties98.Append(applicationNonVisualDrawingPropertiesExtensionList1);

            nonVisualGraphicFrameProperties1.Append(nonVisualDrawingProperties98);
            nonVisualGraphicFrameProperties1.Append(nonVisualGraphicFrameDrawingProperties1);
            nonVisualGraphicFrameProperties1.Append(applicationNonVisualDrawingProperties98);

            Transform transform1 = new Transform();
            A.Offset offset54 = new A.Offset() { X = 228600L, Y = 1295400L };
            A.Extents extents54 = new A.Extents() { Cx = 2819400L, Cy = 274320L };

            transform1.Append(offset54);
            transform1.Append(extents54);

            A.Graphic graphic1 = new A.Graphic();

            A.GraphicData graphicData1 = new A.GraphicData() { Uri = "http://schemas.openxmlformats.org/drawingml/2006/table" };

            A.Table table1 = new A.Table();

            A.TableProperties tableProperties1 = new A.TableProperties() { FirstRow = true, FirstColumn = true, BandRow = true };
            A.TableStyleId tableStyleId1 = new A.TableStyleId();
            tableStyleId1.Text = "{5C22544A-7EE6-4342-B048-85BDC9FD1C3A}";

            tableProperties1.Append(tableStyleId1);

            A.TableGrid tableGrid1 = new A.TableGrid();
            A.GridColumn gridColumn1 = new A.GridColumn() { Width = 1828800L };
            A.GridColumn gridColumn2 = new A.GridColumn() { Width = 990600L };

            tableGrid1.Append(gridColumn1);
            tableGrid1.Append(gridColumn2);

            A.TableRow tableRow1 = new A.TableRow() { Height = 228600L };

            A.TableCell tableCell1 = new A.TableCell();

            A.TextBody textBody80 = new A.TextBody();
            A.BodyProperties bodyProperties82 = new A.BodyProperties();
            A.ListStyle listStyle82 = new A.ListStyle();

            A.Paragraph paragraph116 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties75 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph116.Append(endParagraphRunProperties75);

            textBody80.Append(bodyProperties82);
            textBody80.Append(listStyle82);
            textBody80.Append(paragraph116);
            A.TableCellProperties tableCellProperties1 = new A.TableCellProperties();

            tableCell1.Append(textBody80);
            tableCell1.Append(tableCellProperties1);

            A.TableCell tableCell2 = new A.TableCell();

            A.TextBody textBody81 = new A.TextBody();
            A.BodyProperties bodyProperties83 = new A.BodyProperties();
            A.ListStyle listStyle83 = new A.ListStyle();

            A.Paragraph paragraph117 = new A.Paragraph();

            A.Run run72 = new A.Run();

            A.RunProperties runProperties100 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties100.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text100 = new A.Text();
            text100.Text = "Concerns";

            run72.Append(runProperties100);
            run72.Append(text100);
            A.EndParagraphRunProperties endParagraphRunProperties76 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph117.Append(run72);
            paragraph117.Append(endParagraphRunProperties76);

            textBody81.Append(bodyProperties83);
            textBody81.Append(listStyle83);
            textBody81.Append(paragraph117);
            A.TableCellProperties tableCellProperties2 = new A.TableCellProperties();

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

            Shape shape80 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties80 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties99 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Title 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties80 = new NonVisualShapeDrawingProperties() { TextBox = true };
            A.ShapeLocks shapeLocks78 = new A.ShapeLocks();

            nonVisualShapeDrawingProperties80.Append(shapeLocks78);
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties99 = new ApplicationNonVisualDrawingProperties();

            nonVisualShapeProperties80.Append(nonVisualDrawingProperties99);
            nonVisualShapeProperties80.Append(nonVisualShapeDrawingProperties80);
            nonVisualShapeProperties80.Append(applicationNonVisualDrawingProperties99);

            ShapeProperties shapeProperties83 = new ShapeProperties();

            A.Transform2D transform2D37 = new A.Transform2D();
            A.Offset offset55 = new A.Offset() { X = 533400L, Y = 152400L };
            A.Extents extents55 = new A.Extents() { Cx = 8042276L, Cy = 758732L };

            transform2D37.Append(offset55);
            transform2D37.Append(extents55);

            A.PresetGeometry presetGeometry11 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList11 = new A.AdjustValueList();

            presetGeometry11.Append(adjustValueList11);

            shapeProperties83.Append(transform2D37);
            shapeProperties83.Append(presetGeometry11);

            TextBody textBody82 = new TextBody();

            A.BodyProperties bodyProperties84 = new A.BodyProperties() { Vertical = A.TextVerticalValues.Horizontal, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, RightToLeftColumns = false, Anchor = A.TextAnchoringTypeValues.Bottom, AnchorCenter = false };
            A.NoAutoFit noAutoFit7 = new A.NoAutoFit();

            bodyProperties84.Append(noAutoFit7);

            A.ListStyle listStyle84 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties31 = new A.Level1ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Center, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore28 = new A.SpaceBefore();
            A.SpacingPercent spacingPercent9 = new A.SpacingPercent() { Val = 0 };

            spaceBefore28.Append(spacingPercent9);
            A.NoBullet noBullet97 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties181 = new A.DefaultRunProperties() { FontSize = 4600, Kerning = 1200 };

            A.SolidFill solidFill85 = new A.SolidFill();
            A.SchemeColor schemeColor117 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            solidFill85.Append(schemeColor117);
            A.LatinFont latinFont37 = new A.LatinFont() { Typeface = "+mj-lt" };
            A.EastAsianFont eastAsianFont37 = new A.EastAsianFont() { Typeface = "+mj-ea" };
            A.ComplexScriptFont complexScriptFont37 = new A.ComplexScriptFont() { Typeface = "+mj-cs" };

            defaultRunProperties181.Append(solidFill85);
            defaultRunProperties181.Append(latinFont37);
            defaultRunProperties181.Append(eastAsianFont37);
            defaultRunProperties181.Append(complexScriptFont37);

            level1ParagraphProperties31.Append(spaceBefore28);
            level1ParagraphProperties31.Append(noBullet97);
            level1ParagraphProperties31.Append(defaultRunProperties181);

            listStyle84.Append(level1ParagraphProperties31);

            A.Paragraph paragraph118 = new A.Paragraph();

            A.Run run73 = new A.Run();

            A.RunProperties runProperties101 = new A.RunProperties() { Language = "en-US", Dirty = false };
            runProperties101.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text101 = new A.Text();
            text101.Text = "{title}";

            run73.Append(runProperties101);
            run73.Append(text101);
            A.EndParagraphRunProperties endParagraphRunProperties77 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

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

            CommonSlideDataExtensionList commonSlideDataExtensionList4 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension4 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId4 = new P14.CreationId() { Val = (UInt32Value)1849363573U };
            creationId4.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension4.Append(creationId4);

            commonSlideDataExtensionList4.Append(commonSlideDataExtension4);

            commonSlideData17.Append(shapeTree17);
            commonSlideData17.Append(commonSlideDataExtensionList4);

            ColorMapOverride colorMapOverride16 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping16 = new A.MasterColorMapping();

            colorMapOverride16.Append(masterColorMapping16);

            AlternateContent alternateContent2 = new AlternateContent();
            alternateContent2.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            alternateContent2.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            AlternateContentChoice alternateContentChoice2 = new AlternateContentChoice() { Requires = "p14" };
            Transition transition3 = new Transition() { Speed = TransitionSpeedValues.Slow, Duration = "2000" };

            alternateContentChoice2.Append(transition3);

            AlternateContentFallback alternateContentFallback2 = new AlternateContentFallback();

            Transition transition4 = new Transition() { Speed = TransitionSpeedValues.Slow };
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
            System.IO.Stream data = GetBinaryDataStream(extendedPart1Data);
            extendedPart1.FeedData(data);
            data.Close();
        }

        // Generates content of presentationPropertiesPart1.
        private void GeneratePresentationPropertiesPart1Content(PresentationPropertiesPart presentationPropertiesPart1)
        {
            PresentationProperties presentationProperties1 = new PresentationProperties();
            presentationProperties1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            presentationProperties1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            presentationProperties1.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            PresentationPropertiesExtensionList presentationPropertiesExtensionList1 = new PresentationPropertiesExtensionList();

            PresentationPropertiesExtension presentationPropertiesExtension1 = new PresentationPropertiesExtension() { Uri = "{E76CE94A-603C-4142-B9EB-6D1370010A27}" };

            P14.DiscardImageEditData discardImageEditData1 = new P14.DiscardImageEditData() { Val = false };
            discardImageEditData1.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            presentationPropertiesExtension1.Append(discardImageEditData1);

            PresentationPropertiesExtension presentationPropertiesExtension2 = new PresentationPropertiesExtension() { Uri = "{D31A062A-798A-4329-ABDD-BBA856620510}" };

            P14.DefaultImageDpi defaultImageDpi1 = new P14.DefaultImageDpi() { Val = (UInt32Value)220U };
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
            ViewProperties viewProperties1 = new ViewProperties();
            viewProperties1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            viewProperties1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            viewProperties1.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            NormalViewProperties normalViewProperties1 = new NormalViewProperties();
            RestoredLeft restoredLeft1 = new RestoredLeft() { Size = 15620 };
            RestoredTop restoredTop1 = new RestoredTop() { Size = 94660 };

            normalViewProperties1.Append(restoredLeft1);
            normalViewProperties1.Append(restoredTop1);

            SlideViewProperties slideViewProperties1 = new SlideViewProperties();

            CommonSlideViewProperties commonSlideViewProperties1 = new CommonSlideViewProperties();

            CommonViewProperties commonViewProperties1 = new CommonViewProperties() { VariableScale = true };

            ScaleFactor scaleFactor1 = new ScaleFactor();
            A.ScaleX scaleX1 = new A.ScaleX() { Numerator = 90, Denominator = 100 };
            A.ScaleY scaleY1 = new A.ScaleY() { Numerator = 90, Denominator = 100 };

            scaleFactor1.Append(scaleX1);
            scaleFactor1.Append(scaleY1);
            Origin origin1 = new Origin() { X = -1560L, Y = -96L };

            commonViewProperties1.Append(scaleFactor1);
            commonViewProperties1.Append(origin1);

            GuideList guideList1 = new GuideList();
            Guide guide1 = new Guide() { Orientation = DirectionValues.Horizontal, Position = 2160 };
            Guide guide2 = new Guide() { Position = 2880 };

            guideList1.Append(guide1);
            guideList1.Append(guide2);

            commonSlideViewProperties1.Append(commonViewProperties1);
            commonSlideViewProperties1.Append(guideList1);

            slideViewProperties1.Append(commonSlideViewProperties1);

            NotesTextViewProperties notesTextViewProperties1 = new NotesTextViewProperties();

            CommonViewProperties commonViewProperties2 = new CommonViewProperties();

            ScaleFactor scaleFactor2 = new ScaleFactor();
            A.ScaleX scaleX2 = new A.ScaleX() { Numerator = 1, Denominator = 1 };
            A.ScaleY scaleY2 = new A.ScaleY() { Numerator = 1, Denominator = 1 };

            scaleFactor2.Append(scaleX2);
            scaleFactor2.Append(scaleY2);
            Origin origin2 = new Origin() { X = 0L, Y = 0L };

            commonViewProperties2.Append(scaleFactor2);
            commonViewProperties2.Append(origin2);

            notesTextViewProperties1.Append(commonViewProperties2);
            GridSpacing gridSpacing1 = new GridSpacing() { Cx = 76200L, Cy = 76200L };

            viewProperties1.Append(normalViewProperties1);
            viewProperties1.Append(slideViewProperties1);
            viewProperties1.Append(notesTextViewProperties1);
            viewProperties1.Append(gridSpacing1);

            viewPropertiesPart1.ViewProperties = viewProperties1;
        }

        // Generates content of tableStylesPart1.
        private void GenerateTableStylesPart1Content(TableStylesPart tableStylesPart1)
        {
            A.TableStyleList tableStyleList1 = new A.TableStyleList() { Default = "{5C22544A-7EE6-4342-B048-85BDC9FD1C3A}" };
            tableStyleList1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            A.TableStyleEntry tableStyleEntry1 = new A.TableStyleEntry() { StyleId = "{5C22544A-7EE6-4342-B048-85BDC9FD1C3A}", StyleName = "Medium Style 2 - Accent 1" };

            A.WholeTable wholeTable1 = new A.WholeTable();

            A.TableCellTextStyle tableCellTextStyle1 = new A.TableCellTextStyle();

            A.FontReference fontReference3 = new A.FontReference() { Index = A.FontCollectionIndexValues.Minor };
            A.PresetColor presetColor4 = new A.PresetColor() { Val = A.PresetColorValues.Black };

            fontReference3.Append(presetColor4);
            A.SchemeColor schemeColor118 = new A.SchemeColor() { Val = A.SchemeColorValues.Dark1 };

            tableCellTextStyle1.Append(fontReference3);
            tableCellTextStyle1.Append(schemeColor118);

            A.TableCellStyle tableCellStyle1 = new A.TableCellStyle();

            A.TableCellBorders tableCellBorders1 = new A.TableCellBorders();

            A.LeftBorder leftBorder1 = new A.LeftBorder();

            A.Outline outline8 = new A.Outline() { Width = 12700, CompoundLineType = A.CompoundLineValues.Single };

            A.SolidFill solidFill86 = new A.SolidFill();
            A.SchemeColor schemeColor119 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            solidFill86.Append(schemeColor119);

            outline8.Append(solidFill86);

            leftBorder1.Append(outline8);

            A.RightBorder rightBorder1 = new A.RightBorder();

            A.Outline outline9 = new A.Outline() { Width = 12700, CompoundLineType = A.CompoundLineValues.Single };

            A.SolidFill solidFill87 = new A.SolidFill();
            A.SchemeColor schemeColor120 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            solidFill87.Append(schemeColor120);

            outline9.Append(solidFill87);

            rightBorder1.Append(outline9);

            A.TopBorder topBorder1 = new A.TopBorder();

            A.Outline outline10 = new A.Outline() { Width = 12700, CompoundLineType = A.CompoundLineValues.Single };

            A.SolidFill solidFill88 = new A.SolidFill();
            A.SchemeColor schemeColor121 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            solidFill88.Append(schemeColor121);

            outline10.Append(solidFill88);

            topBorder1.Append(outline10);

            A.BottomBorder bottomBorder1 = new A.BottomBorder();

            A.Outline outline11 = new A.Outline() { Width = 12700, CompoundLineType = A.CompoundLineValues.Single };

            A.SolidFill solidFill89 = new A.SolidFill();
            A.SchemeColor schemeColor122 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            solidFill89.Append(schemeColor122);

            outline11.Append(solidFill89);

            bottomBorder1.Append(outline11);

            A.InsideHorizontalBorder insideHorizontalBorder1 = new A.InsideHorizontalBorder();

            A.Outline outline12 = new A.Outline() { Width = 12700, CompoundLineType = A.CompoundLineValues.Single };

            A.SolidFill solidFill90 = new A.SolidFill();
            A.SchemeColor schemeColor123 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            solidFill90.Append(schemeColor123);

            outline12.Append(solidFill90);

            insideHorizontalBorder1.Append(outline12);

            A.InsideVerticalBorder insideVerticalBorder1 = new A.InsideVerticalBorder();

            A.Outline outline13 = new A.Outline() { Width = 12700, CompoundLineType = A.CompoundLineValues.Single };

            A.SolidFill solidFill91 = new A.SolidFill();
            A.SchemeColor schemeColor124 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            solidFill91.Append(schemeColor124);

            outline13.Append(solidFill91);

            insideVerticalBorder1.Append(outline13);

            tableCellBorders1.Append(leftBorder1);
            tableCellBorders1.Append(rightBorder1);
            tableCellBorders1.Append(topBorder1);
            tableCellBorders1.Append(bottomBorder1);
            tableCellBorders1.Append(insideHorizontalBorder1);
            tableCellBorders1.Append(insideVerticalBorder1);

            A.FillProperties fillProperties1 = new A.FillProperties();

            A.SolidFill solidFill92 = new A.SolidFill();

            A.SchemeColor schemeColor125 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };
            A.Tint tint44 = new A.Tint() { Val = 20000 };

            schemeColor125.Append(tint44);

            solidFill92.Append(schemeColor125);

            fillProperties1.Append(solidFill92);

            tableCellStyle1.Append(tableCellBorders1);
            tableCellStyle1.Append(fillProperties1);

            wholeTable1.Append(tableCellTextStyle1);
            wholeTable1.Append(tableCellStyle1);

            A.Band1Horizontal band1Horizontal1 = new A.Band1Horizontal();

            A.TableCellStyle tableCellStyle2 = new A.TableCellStyle();
            A.TableCellBorders tableCellBorders2 = new A.TableCellBorders();

            A.FillProperties fillProperties2 = new A.FillProperties();

            A.SolidFill solidFill93 = new A.SolidFill();

            A.SchemeColor schemeColor126 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };
            A.Tint tint45 = new A.Tint() { Val = 40000 };

            schemeColor126.Append(tint45);

            solidFill93.Append(schemeColor126);

            fillProperties2.Append(solidFill93);

            tableCellStyle2.Append(tableCellBorders2);
            tableCellStyle2.Append(fillProperties2);

            band1Horizontal1.Append(tableCellStyle2);

            A.Band2Horizontal band2Horizontal1 = new A.Band2Horizontal();

            A.TableCellStyle tableCellStyle3 = new A.TableCellStyle();
            A.TableCellBorders tableCellBorders3 = new A.TableCellBorders();

            tableCellStyle3.Append(tableCellBorders3);

            band2Horizontal1.Append(tableCellStyle3);

            A.Band1Vertical band1Vertical1 = new A.Band1Vertical();

            A.TableCellStyle tableCellStyle4 = new A.TableCellStyle();
            A.TableCellBorders tableCellBorders4 = new A.TableCellBorders();

            A.FillProperties fillProperties3 = new A.FillProperties();

            A.SolidFill solidFill94 = new A.SolidFill();

            A.SchemeColor schemeColor127 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };
            A.Tint tint46 = new A.Tint() { Val = 40000 };

            schemeColor127.Append(tint46);

            solidFill94.Append(schemeColor127);

            fillProperties3.Append(solidFill94);

            tableCellStyle4.Append(tableCellBorders4);
            tableCellStyle4.Append(fillProperties3);

            band1Vertical1.Append(tableCellStyle4);

            A.Band2Vertical band2Vertical1 = new A.Band2Vertical();

            A.TableCellStyle tableCellStyle5 = new A.TableCellStyle();
            A.TableCellBorders tableCellBorders5 = new A.TableCellBorders();

            tableCellStyle5.Append(tableCellBorders5);

            band2Vertical1.Append(tableCellStyle5);

            A.LastColumn lastColumn1 = new A.LastColumn();

            A.TableCellTextStyle tableCellTextStyle2 = new A.TableCellTextStyle() { Bold = A.BooleanStyleValues.On };

            A.FontReference fontReference4 = new A.FontReference() { Index = A.FontCollectionIndexValues.Minor };
            A.PresetColor presetColor5 = new A.PresetColor() { Val = A.PresetColorValues.Black };

            fontReference4.Append(presetColor5);
            A.SchemeColor schemeColor128 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            tableCellTextStyle2.Append(fontReference4);
            tableCellTextStyle2.Append(schemeColor128);

            A.TableCellStyle tableCellStyle6 = new A.TableCellStyle();
            A.TableCellBorders tableCellBorders6 = new A.TableCellBorders();

            A.FillProperties fillProperties4 = new A.FillProperties();

            A.SolidFill solidFill95 = new A.SolidFill();
            A.SchemeColor schemeColor129 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            solidFill95.Append(schemeColor129);

            fillProperties4.Append(solidFill95);

            tableCellStyle6.Append(tableCellBorders6);
            tableCellStyle6.Append(fillProperties4);

            lastColumn1.Append(tableCellTextStyle2);
            lastColumn1.Append(tableCellStyle6);

            A.FirstColumn firstColumn1 = new A.FirstColumn();

            A.TableCellTextStyle tableCellTextStyle3 = new A.TableCellTextStyle() { Bold = A.BooleanStyleValues.On };

            A.FontReference fontReference5 = new A.FontReference() { Index = A.FontCollectionIndexValues.Minor };
            A.PresetColor presetColor6 = new A.PresetColor() { Val = A.PresetColorValues.Black };

            fontReference5.Append(presetColor6);
            A.SchemeColor schemeColor130 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            tableCellTextStyle3.Append(fontReference5);
            tableCellTextStyle3.Append(schemeColor130);

            A.TableCellStyle tableCellStyle7 = new A.TableCellStyle();
            A.TableCellBorders tableCellBorders7 = new A.TableCellBorders();

            A.FillProperties fillProperties5 = new A.FillProperties();

            A.SolidFill solidFill96 = new A.SolidFill();
            A.SchemeColor schemeColor131 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            solidFill96.Append(schemeColor131);

            fillProperties5.Append(solidFill96);

            tableCellStyle7.Append(tableCellBorders7);
            tableCellStyle7.Append(fillProperties5);

            firstColumn1.Append(tableCellTextStyle3);
            firstColumn1.Append(tableCellStyle7);

            A.LastRow lastRow1 = new A.LastRow();

            A.TableCellTextStyle tableCellTextStyle4 = new A.TableCellTextStyle() { Bold = A.BooleanStyleValues.On };

            A.FontReference fontReference6 = new A.FontReference() { Index = A.FontCollectionIndexValues.Minor };
            A.PresetColor presetColor7 = new A.PresetColor() { Val = A.PresetColorValues.Black };

            fontReference6.Append(presetColor7);
            A.SchemeColor schemeColor132 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            tableCellTextStyle4.Append(fontReference6);
            tableCellTextStyle4.Append(schemeColor132);

            A.TableCellStyle tableCellStyle8 = new A.TableCellStyle();

            A.TableCellBorders tableCellBorders8 = new A.TableCellBorders();

            A.TopBorder topBorder2 = new A.TopBorder();

            A.Outline outline14 = new A.Outline() { Width = 38100, CompoundLineType = A.CompoundLineValues.Single };

            A.SolidFill solidFill97 = new A.SolidFill();
            A.SchemeColor schemeColor133 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            solidFill97.Append(schemeColor133);

            outline14.Append(solidFill97);

            topBorder2.Append(outline14);

            tableCellBorders8.Append(topBorder2);

            A.FillProperties fillProperties6 = new A.FillProperties();

            A.SolidFill solidFill98 = new A.SolidFill();
            A.SchemeColor schemeColor134 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            solidFill98.Append(schemeColor134);

            fillProperties6.Append(solidFill98);

            tableCellStyle8.Append(tableCellBorders8);
            tableCellStyle8.Append(fillProperties6);

            lastRow1.Append(tableCellTextStyle4);
            lastRow1.Append(tableCellStyle8);

            A.FirstRow firstRow1 = new A.FirstRow();

            A.TableCellTextStyle tableCellTextStyle5 = new A.TableCellTextStyle() { Bold = A.BooleanStyleValues.On };

            A.FontReference fontReference7 = new A.FontReference() { Index = A.FontCollectionIndexValues.Minor };
            A.PresetColor presetColor8 = new A.PresetColor() { Val = A.PresetColorValues.Black };

            fontReference7.Append(presetColor8);
            A.SchemeColor schemeColor135 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            tableCellTextStyle5.Append(fontReference7);
            tableCellTextStyle5.Append(schemeColor135);

            A.TableCellStyle tableCellStyle9 = new A.TableCellStyle();

            A.TableCellBorders tableCellBorders9 = new A.TableCellBorders();

            A.BottomBorder bottomBorder2 = new A.BottomBorder();

            A.Outline outline15 = new A.Outline() { Width = 38100, CompoundLineType = A.CompoundLineValues.Single };

            A.SolidFill solidFill99 = new A.SolidFill();
            A.SchemeColor schemeColor136 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            solidFill99.Append(schemeColor136);

            outline15.Append(solidFill99);

            bottomBorder2.Append(outline15);

            tableCellBorders9.Append(bottomBorder2);

            A.FillProperties fillProperties7 = new A.FillProperties();

            A.SolidFill solidFill100 = new A.SolidFill();
            A.SchemeColor schemeColor137 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

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
            Slide slide4 = new Slide();
            slide4.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slide4.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slide4.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData18 = new CommonSlideData();

            ShapeTree shapeTree18 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties18 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties100 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties18 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties100 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties18.Append(nonVisualDrawingProperties100);
            nonVisualGroupShapeProperties18.Append(nonVisualGroupShapeDrawingProperties18);
            nonVisualGroupShapeProperties18.Append(applicationNonVisualDrawingProperties100);

            GroupShapeProperties groupShapeProperties18 = new GroupShapeProperties();

            A.TransformGroup transformGroup18 = new A.TransformGroup();
            A.Offset offset56 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents56 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset18 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents18 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup18.Append(offset56);
            transformGroup18.Append(extents56);
            transformGroup18.Append(childOffset18);
            transformGroup18.Append(childExtents18);

            groupShapeProperties18.Append(transformGroup18);

            GraphicFrame graphicFrame2 = new GraphicFrame();

            NonVisualGraphicFrameProperties nonVisualGraphicFrameProperties2 = new NonVisualGraphicFrameProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties101 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Table 3" };

            NonVisualGraphicFrameDrawingProperties nonVisualGraphicFrameDrawingProperties2 = new NonVisualGraphicFrameDrawingProperties();
            A.GraphicFrameLocks graphicFrameLocks2 = new A.GraphicFrameLocks() { NoGrouping = true };

            nonVisualGraphicFrameDrawingProperties2.Append(graphicFrameLocks2);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties101 = new ApplicationNonVisualDrawingProperties();

            ApplicationNonVisualDrawingPropertiesExtensionList applicationNonVisualDrawingPropertiesExtensionList2 = new ApplicationNonVisualDrawingPropertiesExtensionList();

            ApplicationNonVisualDrawingPropertiesExtension applicationNonVisualDrawingPropertiesExtension2 = new ApplicationNonVisualDrawingPropertiesExtension() { Uri = "{D42A27DB-BD31-4B8C-83A1-F6EECF244321}" };

            P14.ModificationId modificationId2 = new P14.ModificationId() { Val = (UInt32Value)268369441U };
            modificationId2.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            applicationNonVisualDrawingPropertiesExtension2.Append(modificationId2);

            applicationNonVisualDrawingPropertiesExtensionList2.Append(applicationNonVisualDrawingPropertiesExtension2);

            applicationNonVisualDrawingProperties101.Append(applicationNonVisualDrawingPropertiesExtensionList2);

            nonVisualGraphicFrameProperties2.Append(nonVisualDrawingProperties101);
            nonVisualGraphicFrameProperties2.Append(nonVisualGraphicFrameDrawingProperties2);
            nonVisualGraphicFrameProperties2.Append(applicationNonVisualDrawingProperties101);

            Transform transform2 = new Transform();
            A.Offset offset57 = new A.Offset() { X = 228600L, Y = 1219200L };
            A.Extents extents57 = new A.Extents() { Cx = 8610600L, Cy = 2926080L };

            transform2.Append(offset57);
            transform2.Append(extents57);

            A.Graphic graphic2 = new A.Graphic();

            A.GraphicData graphicData2 = new A.GraphicData() { Uri = "http://schemas.openxmlformats.org/drawingml/2006/table" };

            A.Table table2 = new A.Table();

            A.TableProperties tableProperties2 = new A.TableProperties() { FirstColumn = true, BandRow = true };
            A.TableStyleId tableStyleId2 = new A.TableStyleId();
            tableStyleId2.Text = "{5C22544A-7EE6-4342-B048-85BDC9FD1C3A}";

            tableProperties2.Append(tableStyleId2);

            A.TableGrid tableGrid2 = new A.TableGrid();
            A.GridColumn gridColumn3 = new A.GridColumn() { Width = 1295399L };
            A.GridColumn gridColumn4 = new A.GridColumn() { Width = 7315201L };

            tableGrid2.Append(gridColumn3);
            tableGrid2.Append(gridColumn4);

            A.TableRow tableRow2 = new A.TableRow() { Height = 304800L };

            A.TableCell tableCell3 = new A.TableCell();

            A.TextBody textBody83 = new A.TextBody();
            A.BodyProperties bodyProperties85 = new A.BodyProperties();
            A.ListStyle listStyle85 = new A.ListStyle();

            A.Paragraph paragraph119 = new A.Paragraph();

            A.Run run74 = new A.Run();

            A.RunProperties runProperties102 = new A.RunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };
            runProperties102.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text102 = new A.Text();
            text102.Text = "State";

            run74.Append(runProperties102);
            run74.Append(text102);
            A.EndParagraphRunProperties endParagraphRunProperties78 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };

            paragraph119.Append(run74);
            paragraph119.Append(endParagraphRunProperties78);

            textBody83.Append(bodyProperties85);
            textBody83.Append(listStyle85);
            textBody83.Append(paragraph119);
            A.TableCellProperties tableCellProperties3 = new A.TableCellProperties();

            tableCell3.Append(textBody83);
            tableCell3.Append(tableCellProperties3);

            A.TableCell tableCell4 = new A.TableCell();

            A.TextBody textBody84 = new A.TextBody();
            A.BodyProperties bodyProperties86 = new A.BodyProperties();
            A.ListStyle listStyle86 = new A.ListStyle();

            A.Paragraph paragraph120 = new A.Paragraph();

            A.Run run75 = new A.Run();

            A.RunProperties runProperties103 = new A.RunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };
            runProperties103.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text103 = new A.Text();
            text103.Text = "{state}";

            run75.Append(runProperties103);
            run75.Append(text103);
            A.EndParagraphRunProperties endParagraphRunProperties79 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };

            paragraph120.Append(run75);
            paragraph120.Append(endParagraphRunProperties79);

            textBody84.Append(bodyProperties86);
            textBody84.Append(listStyle86);
            textBody84.Append(paragraph120);
            A.TableCellProperties tableCellProperties4 = new A.TableCellProperties();

            tableCell4.Append(textBody84);
            tableCell4.Append(tableCellProperties4);

            tableRow2.Append(tableCell3);
            tableRow2.Append(tableCell4);

            A.TableRow tableRow3 = new A.TableRow() { Height = 304800L };

            A.TableCell tableCell5 = new A.TableCell();

            A.TextBody textBody85 = new A.TextBody();
            A.BodyProperties bodyProperties87 = new A.BodyProperties();
            A.ListStyle listStyle87 = new A.ListStyle();

            A.Paragraph paragraph121 = new A.Paragraph();

            A.Run run76 = new A.Run();

            A.RunProperties runProperties104 = new A.RunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };
            runProperties104.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text104 = new A.Text();
            text104.Text = "Topic";

            run76.Append(runProperties104);
            run76.Append(text104);
            A.EndParagraphRunProperties endParagraphRunProperties80 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };

            paragraph121.Append(run76);
            paragraph121.Append(endParagraphRunProperties80);

            textBody85.Append(bodyProperties87);
            textBody85.Append(listStyle87);
            textBody85.Append(paragraph121);
            A.TableCellProperties tableCellProperties5 = new A.TableCellProperties();

            tableCell5.Append(textBody85);
            tableCell5.Append(tableCellProperties5);

            A.TableCell tableCell6 = new A.TableCell();

            A.TextBody textBody86 = new A.TextBody();
            A.BodyProperties bodyProperties88 = new A.BodyProperties();
            A.ListStyle listStyle88 = new A.ListStyle();

            A.Paragraph paragraph122 = new A.Paragraph();

            A.Run run77 = new A.Run();

            A.RunProperties runProperties105 = new A.RunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };
            runProperties105.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text105 = new A.Text();
            text105.Text = "{topic}";

            run77.Append(runProperties105);
            run77.Append(text105);
            A.EndParagraphRunProperties endParagraphRunProperties81 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };

            paragraph122.Append(run77);
            paragraph122.Append(endParagraphRunProperties81);

            textBody86.Append(bodyProperties88);
            textBody86.Append(listStyle88);
            textBody86.Append(paragraph122);
            A.TableCellProperties tableCellProperties6 = new A.TableCellProperties();

            tableCell6.Append(textBody86);
            tableCell6.Append(tableCellProperties6);

            tableRow3.Append(tableCell5);
            tableRow3.Append(tableCell6);

            A.TableRow tableRow4 = new A.TableRow() { Height = 304800L };

            A.TableCell tableCell7 = new A.TableCell();

            A.TextBody textBody87 = new A.TextBody();
            A.BodyProperties bodyProperties89 = new A.BodyProperties();
            A.ListStyle listStyle89 = new A.ListStyle();

            A.Paragraph paragraph123 = new A.Paragraph();

            A.Run run78 = new A.Run();

            A.RunProperties runProperties106 = new A.RunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };
            runProperties106.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text106 = new A.Text();
            text106.Text = "Problem/Problem";

            run78.Append(runProperties106);
            run78.Append(text106);
            A.EndParagraphRunProperties endParagraphRunProperties82 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };

            paragraph123.Append(run78);
            paragraph123.Append(endParagraphRunProperties82);

            textBody87.Append(bodyProperties89);
            textBody87.Append(listStyle89);
            textBody87.Append(paragraph123);
            A.TableCellProperties tableCellProperties7 = new A.TableCellProperties();

            tableCell7.Append(textBody87);
            tableCell7.Append(tableCellProperties7);

            A.TableCell tableCell8 = new A.TableCell();

            A.TextBody textBody88 = new A.TextBody();
            A.BodyProperties bodyProperties90 = new A.BodyProperties();
            A.ListStyle listStyle90 = new A.ListStyle();

            A.Paragraph paragraph124 = new A.Paragraph();

            A.Run run79 = new A.Run();

            A.RunProperties runProperties107 = new A.RunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };
            runProperties107.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text107 = new A.Text();
            text107.Text = "{issue}";

            run79.Append(runProperties107);
            run79.Append(text107);
            A.EndParagraphRunProperties endParagraphRunProperties83 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };

            paragraph124.Append(run79);
            paragraph124.Append(endParagraphRunProperties83);

            textBody88.Append(bodyProperties90);
            textBody88.Append(listStyle90);
            textBody88.Append(paragraph124);
            A.TableCellProperties tableCellProperties8 = new A.TableCellProperties();

            tableCell8.Append(textBody88);
            tableCell8.Append(tableCellProperties8);

            tableRow4.Append(tableCell7);
            tableRow4.Append(tableCell8);

            A.TableRow tableRow5 = new A.TableRow() { Height = 304800L };

            A.TableCell tableCell9 = new A.TableCell();

            A.TextBody textBody89 = new A.TextBody();
            A.BodyProperties bodyProperties91 = new A.BodyProperties();
            A.ListStyle listStyle91 = new A.ListStyle();

            A.Paragraph paragraph125 = new A.Paragraph();

            A.Run run80 = new A.Run();

            A.RunProperties runProperties108 = new A.RunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };
            runProperties108.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text108 = new A.Text();
            text108.Text = "Decision";

            run80.Append(runProperties108);
            run80.Append(text108);
            A.EndParagraphRunProperties endParagraphRunProperties84 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };

            paragraph125.Append(run80);
            paragraph125.Append(endParagraphRunProperties84);

            textBody89.Append(bodyProperties91);
            textBody89.Append(listStyle91);
            textBody89.Append(paragraph125);
            A.TableCellProperties tableCellProperties9 = new A.TableCellProperties();

            tableCell9.Append(textBody89);
            tableCell9.Append(tableCellProperties9);

            A.TableCell tableCell10 = new A.TableCell();

            A.TextBody textBody90 = new A.TextBody();
            A.BodyProperties bodyProperties92 = new A.BodyProperties();
            A.ListStyle listStyle92 = new A.ListStyle();

            A.Paragraph paragraph126 = new A.Paragraph();

            A.Run run81 = new A.Run();

            A.RunProperties runProperties109 = new A.RunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };
            runProperties109.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text109 = new A.Text();
            text109.Text = "{decision}";

            run81.Append(runProperties109);
            run81.Append(text109);
            A.EndParagraphRunProperties endParagraphRunProperties85 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };

            paragraph126.Append(run81);
            paragraph126.Append(endParagraphRunProperties85);

            textBody90.Append(bodyProperties92);
            textBody90.Append(listStyle92);
            textBody90.Append(paragraph126);
            A.TableCellProperties tableCellProperties10 = new A.TableCellProperties();

            tableCell10.Append(textBody90);
            tableCell10.Append(tableCellProperties10);

            tableRow5.Append(tableCell9);
            tableRow5.Append(tableCell10);

            A.TableRow tableRow6 = new A.TableRow() { Height = 304800L };

            A.TableCell tableCell11 = new A.TableCell();

            A.TextBody textBody91 = new A.TextBody();
            A.BodyProperties bodyProperties93 = new A.BodyProperties();
            A.ListStyle listStyle93 = new A.ListStyle();

            A.Paragraph paragraph127 = new A.Paragraph();

            A.Run run82 = new A.Run();

            A.RunProperties runProperties110 = new A.RunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };
            runProperties110.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text110 = new A.Text();
            text110.Text = "Alternatives";

            run82.Append(runProperties110);
            run82.Append(text110);
            A.EndParagraphRunProperties endParagraphRunProperties86 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };

            paragraph127.Append(run82);
            paragraph127.Append(endParagraphRunProperties86);

            textBody91.Append(bodyProperties93);
            textBody91.Append(listStyle93);
            textBody91.Append(paragraph127);
            A.TableCellProperties tableCellProperties11 = new A.TableCellProperties();

            tableCell11.Append(textBody91);
            tableCell11.Append(tableCellProperties11);

            A.TableCell tableCell12 = new A.TableCell();

            A.TextBody textBody92 = new A.TextBody();
            A.BodyProperties bodyProperties94 = new A.BodyProperties();
            A.ListStyle listStyle94 = new A.ListStyle();

            A.Paragraph paragraph128 = new A.Paragraph();

            A.Run run83 = new A.Run();

            A.RunProperties runProperties111 = new A.RunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };
            runProperties111.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text111 = new A.Text();
            text111.Text = "{alternatives}";

            run83.Append(runProperties111);
            run83.Append(text111);
            A.EndParagraphRunProperties endParagraphRunProperties87 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };

            paragraph128.Append(run83);
            paragraph128.Append(endParagraphRunProperties87);

            textBody92.Append(bodyProperties94);
            textBody92.Append(listStyle94);
            textBody92.Append(paragraph128);
            A.TableCellProperties tableCellProperties12 = new A.TableCellProperties();

            tableCell12.Append(textBody92);
            tableCell12.Append(tableCellProperties12);

            tableRow6.Append(tableCell11);
            tableRow6.Append(tableCell12);

            A.TableRow tableRow7 = new A.TableRow() { Height = 304800L };

            A.TableCell tableCell13 = new A.TableCell();

            A.TextBody textBody93 = new A.TextBody();
            A.BodyProperties bodyProperties95 = new A.BodyProperties();
            A.ListStyle listStyle95 = new A.ListStyle();

            A.Paragraph paragraph129 = new A.Paragraph();

            A.Run run84 = new A.Run();

            A.RunProperties runProperties112 = new A.RunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };
            runProperties112.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text112 = new A.Text();
            text112.Text = "Argumentation";

            run84.Append(runProperties112);
            run84.Append(text112);
            A.EndParagraphRunProperties endParagraphRunProperties88 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };

            paragraph129.Append(run84);
            paragraph129.Append(endParagraphRunProperties88);

            textBody93.Append(bodyProperties95);
            textBody93.Append(listStyle95);
            textBody93.Append(paragraph129);
            A.TableCellProperties tableCellProperties13 = new A.TableCellProperties();

            tableCell13.Append(textBody93);
            tableCell13.Append(tableCellProperties13);

            A.TableCell tableCell14 = new A.TableCell();

            A.TextBody textBody94 = new A.TextBody();
            A.BodyProperties bodyProperties96 = new A.BodyProperties();
            A.ListStyle listStyle96 = new A.ListStyle();

            A.Paragraph paragraph130 = new A.Paragraph();

            A.Run run85 = new A.Run();

            A.RunProperties runProperties113 = new A.RunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };
            runProperties113.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text113 = new A.Text();
            text113.Text = "{arguments}";

            run85.Append(runProperties113);
            run85.Append(text113);
            A.EndParagraphRunProperties endParagraphRunProperties89 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };

            paragraph130.Append(run85);
            paragraph130.Append(endParagraphRunProperties89);

            textBody94.Append(bodyProperties96);
            textBody94.Append(listStyle96);
            textBody94.Append(paragraph130);
            A.TableCellProperties tableCellProperties14 = new A.TableCellProperties();

            tableCell14.Append(textBody94);
            tableCell14.Append(tableCellProperties14);

            tableRow7.Append(tableCell13);
            tableRow7.Append(tableCell14);

            A.TableRow tableRow8 = new A.TableRow() { Height = 304800L };

            A.TableCell tableCell15 = new A.TableCell();

            A.TextBody textBody95 = new A.TextBody();
            A.BodyProperties bodyProperties97 = new A.BodyProperties();
            A.ListStyle listStyle97 = new A.ListStyle();

            A.Paragraph paragraph131 = new A.Paragraph();

            A.Run run86 = new A.Run();

            A.RunProperties runProperties114 = new A.RunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };
            runProperties114.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text114 = new A.Text();
            text114.Text = "Related Decision";

            run86.Append(runProperties114);
            run86.Append(text114);
            A.EndParagraphRunProperties endParagraphRunProperties90 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };

            paragraph131.Append(run86);
            paragraph131.Append(endParagraphRunProperties90);

            textBody95.Append(bodyProperties97);
            textBody95.Append(listStyle97);
            textBody95.Append(paragraph131);
            A.TableCellProperties tableCellProperties15 = new A.TableCellProperties();

            tableCell15.Append(textBody95);
            tableCell15.Append(tableCellProperties15);

            A.TableCell tableCell16 = new A.TableCell();

            A.TextBody textBody96 = new A.TextBody();
            A.BodyProperties bodyProperties98 = new A.BodyProperties();
            A.ListStyle listStyle98 = new A.ListStyle();

            A.Paragraph paragraph132 = new A.Paragraph();

            A.Run run87 = new A.Run();

            A.RunProperties runProperties115 = new A.RunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };
            runProperties115.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text115 = new A.Text();
            text115.Text = "{decisions}";

            run87.Append(runProperties115);
            run87.Append(text115);
            A.EndParagraphRunProperties endParagraphRunProperties91 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };

            paragraph132.Append(run87);
            paragraph132.Append(endParagraphRunProperties91);

            textBody96.Append(bodyProperties98);
            textBody96.Append(listStyle98);
            textBody96.Append(paragraph132);
            A.TableCellProperties tableCellProperties16 = new A.TableCellProperties();

            tableCell16.Append(textBody96);
            tableCell16.Append(tableCellProperties16);

            tableRow8.Append(tableCell15);
            tableRow8.Append(tableCell16);

            A.TableRow tableRow9 = new A.TableRow() { Height = 304800L };

            A.TableCell tableCell17 = new A.TableCell();

            A.TextBody textBody97 = new A.TextBody();
            A.BodyProperties bodyProperties99 = new A.BodyProperties();
            A.ListStyle listStyle99 = new A.ListStyle();

            A.Paragraph paragraph133 = new A.Paragraph();

            A.Run run88 = new A.Run();

            A.RunProperties runProperties116 = new A.RunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };
            runProperties116.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text116 = new A.Text();
            text116.Text = "Related Forces";

            run88.Append(runProperties116);
            run88.Append(text116);
            A.EndParagraphRunProperties endParagraphRunProperties92 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };

            paragraph133.Append(run88);
            paragraph133.Append(endParagraphRunProperties92);

            textBody97.Append(bodyProperties99);
            textBody97.Append(listStyle99);
            textBody97.Append(paragraph133);
            A.TableCellProperties tableCellProperties17 = new A.TableCellProperties();

            tableCell17.Append(textBody97);
            tableCell17.Append(tableCellProperties17);

            A.TableCell tableCell18 = new A.TableCell();

            A.TextBody textBody98 = new A.TextBody();
            A.BodyProperties bodyProperties100 = new A.BodyProperties();
            A.ListStyle listStyle100 = new A.ListStyle();

            A.Paragraph paragraph134 = new A.Paragraph();

            A.Run run89 = new A.Run();

            A.RunProperties runProperties117 = new A.RunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };
            runProperties117.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text117 = new A.Text();
            text117.Text = "{forces}";

            run89.Append(runProperties117);
            run89.Append(text117);
            A.EndParagraphRunProperties endParagraphRunProperties93 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };

            paragraph134.Append(run89);
            paragraph134.Append(endParagraphRunProperties93);

            textBody98.Append(bodyProperties100);
            textBody98.Append(listStyle100);
            textBody98.Append(paragraph134);
            A.TableCellProperties tableCellProperties18 = new A.TableCellProperties();

            tableCell18.Append(textBody98);
            tableCell18.Append(tableCellProperties18);

            tableRow9.Append(tableCell17);
            tableRow9.Append(tableCell18);

            A.TableRow tableRow10 = new A.TableRow() { Height = 304800L };

            A.TableCell tableCell19 = new A.TableCell();

            A.TextBody textBody99 = new A.TextBody();
            A.BodyProperties bodyProperties101 = new A.BodyProperties();
            A.ListStyle listStyle101 = new A.ListStyle();

            A.Paragraph paragraph135 = new A.Paragraph();

            A.Run run90 = new A.Run();

            A.RunProperties runProperties118 = new A.RunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };
            runProperties118.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text118 = new A.Text();
            text118.Text = "Related Components";

            run90.Append(runProperties118);
            run90.Append(text118);
            A.EndParagraphRunProperties endParagraphRunProperties94 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };

            paragraph135.Append(run90);
            paragraph135.Append(endParagraphRunProperties94);

            textBody99.Append(bodyProperties101);
            textBody99.Append(listStyle101);
            textBody99.Append(paragraph135);
            A.TableCellProperties tableCellProperties19 = new A.TableCellProperties();

            tableCell19.Append(textBody99);
            tableCell19.Append(tableCellProperties19);

            A.TableCell tableCell20 = new A.TableCell();

            A.TextBody textBody100 = new A.TextBody();
            A.BodyProperties bodyProperties102 = new A.BodyProperties();
            A.ListStyle listStyle102 = new A.ListStyle();

            A.Paragraph paragraph136 = new A.Paragraph();

            A.Run run91 = new A.Run();

            A.RunProperties runProperties119 = new A.RunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };
            runProperties119.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text119 = new A.Text();
            text119.Text = "{traces}";

            run91.Append(runProperties119);
            run91.Append(text119);
            A.EndParagraphRunProperties endParagraphRunProperties95 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1000, Dirty = false };

            paragraph136.Append(run91);
            paragraph136.Append(endParagraphRunProperties95);

            textBody100.Append(bodyProperties102);
            textBody100.Append(listStyle102);
            textBody100.Append(paragraph136);
            A.TableCellProperties tableCellProperties20 = new A.TableCellProperties();

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

            Shape shape81 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties81 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties102 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Title 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties81 = new NonVisualShapeDrawingProperties() { TextBox = true };
            A.ShapeLocks shapeLocks79 = new A.ShapeLocks();

            nonVisualShapeDrawingProperties81.Append(shapeLocks79);
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties102 = new ApplicationNonVisualDrawingProperties();

            nonVisualShapeProperties81.Append(nonVisualDrawingProperties102);
            nonVisualShapeProperties81.Append(nonVisualShapeDrawingProperties81);
            nonVisualShapeProperties81.Append(applicationNonVisualDrawingProperties102);

            ShapeProperties shapeProperties84 = new ShapeProperties();

            A.Transform2D transform2D38 = new A.Transform2D();
            A.Offset offset58 = new A.Offset() { X = 533400L, Y = 152400L };
            A.Extents extents58 = new A.Extents() { Cx = 8042276L, Cy = 758732L };

            transform2D38.Append(offset58);
            transform2D38.Append(extents58);

            A.PresetGeometry presetGeometry12 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList12 = new A.AdjustValueList();

            presetGeometry12.Append(adjustValueList12);

            shapeProperties84.Append(transform2D38);
            shapeProperties84.Append(presetGeometry12);

            TextBody textBody101 = new TextBody();

            A.BodyProperties bodyProperties103 = new A.BodyProperties() { Vertical = A.TextVerticalValues.Horizontal, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, RightToLeftColumns = false, Anchor = A.TextAnchoringTypeValues.Bottom, AnchorCenter = false };
            A.NoAutoFit noAutoFit8 = new A.NoAutoFit();

            bodyProperties103.Append(noAutoFit8);

            A.ListStyle listStyle103 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties32 = new A.Level1ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Center, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore29 = new A.SpaceBefore();
            A.SpacingPercent spacingPercent10 = new A.SpacingPercent() { Val = 0 };

            spaceBefore29.Append(spacingPercent10);
            A.NoBullet noBullet98 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties182 = new A.DefaultRunProperties() { FontSize = 4600, Kerning = 1200 };

            A.SolidFill solidFill101 = new A.SolidFill();
            A.SchemeColor schemeColor138 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            solidFill101.Append(schemeColor138);
            A.LatinFont latinFont38 = new A.LatinFont() { Typeface = "+mj-lt" };
            A.EastAsianFont eastAsianFont38 = new A.EastAsianFont() { Typeface = "+mj-ea" };
            A.ComplexScriptFont complexScriptFont38 = new A.ComplexScriptFont() { Typeface = "+mj-cs" };

            defaultRunProperties182.Append(solidFill101);
            defaultRunProperties182.Append(latinFont38);
            defaultRunProperties182.Append(eastAsianFont38);
            defaultRunProperties182.Append(complexScriptFont38);

            level1ParagraphProperties32.Append(spaceBefore29);
            level1ParagraphProperties32.Append(noBullet98);
            level1ParagraphProperties32.Append(defaultRunProperties182);

            listStyle103.Append(level1ParagraphProperties32);

            A.Paragraph paragraph137 = new A.Paragraph();

            A.Run run92 = new A.Run();

            A.RunProperties runProperties120 = new A.RunProperties() { Language = "en-US", FontSize = 2200, Dirty = false };
            runProperties120.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text120 = new A.Text();
            text120.Text = "{name}";

            run92.Append(runProperties120);
            run92.Append(text120);
            A.EndParagraphRunProperties endParagraphRunProperties96 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 2200, Dirty = false };

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

            CommonSlideDataExtensionList commonSlideDataExtensionList5 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension5 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId5 = new P14.CreationId() { Val = (UInt32Value)331602207U };
            creationId5.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension5.Append(creationId5);

            commonSlideDataExtensionList5.Append(commonSlideDataExtension5);

            commonSlideData18.Append(shapeTree18);
            commonSlideData18.Append(commonSlideDataExtensionList5);

            ColorMapOverride colorMapOverride17 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping17 = new A.MasterColorMapping();

            colorMapOverride17.Append(masterColorMapping17);

            slide4.Append(commonSlideData18);
            slide4.Append(colorMapOverride17);

            slidePart4.Slide = slide4;
        }

        // Generates content of thumbnailPart1.
        private void GenerateThumbnailPart1Content(ThumbnailPart thumbnailPart1)
        {
            System.IO.Stream data = GetBinaryDataStream(thumbnailPart1Data);
            thumbnailPart1.FeedData(data);
            data.Close();
        }

        private void SetPackageProperties(OpenXmlPackage document)
        {
            document.PackageProperties.Creator = "Spyros";
            document.PackageProperties.Title = "PowerPoint Presentation";
            document.PackageProperties.Revision = "46";
            document.PackageProperties.Created = System.Xml.XmlConvert.ToDateTime("2013-07-27T17:27:29Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
            document.PackageProperties.Modified = System.Xml.XmlConvert.ToDateTime("2013-11-29T17:01:33Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
            document.PackageProperties.LastModifiedBy = "Christian Manteuffel";
        }

        #region Binary Data
        private string imagePart1Data = "/9j/4AAQSkZJRgABAgAAZABkAAD/7AARRHVja3kAAQAEAAAAPAAA/+4ADkFkb2JlAGTAAAAAAf/bAEMABgQEBAUEBgUFBgkGBQYJCwgGBggLDAoKCwoKDBAMDAwMDAwQDA4PEA8ODBMTFBQTExwbGxscHx8fHx8fHx8fH//bAEMBBwcHDQwNGBAQGBoVERUaHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fH//AABEIAwAEAAMBEQACEQEDEQH/xAAfAAABBQEBAQEBAQAAAAAAAAAAAQIDBAUGBwgJCgv/xAC1EAACAQMDAgQDBQUEBAAAAX0BAgMABBEFEiExQQYTUWEHInEUMoGRoQgjQrHBFVLR8CQzYnKCCQoWFxgZGiUmJygpKjQ1Njc4OTpDREVGR0hJSlNUVVZXWFlaY2RlZmdoaWpzdHV2d3h5eoOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4eLj5OXm5+jp6vHy8/T19vf4+fr/xAAfAQADAQEBAQEBAQEBAAAAAAAAAQIDBAUGBwgJCgv/xAC1EQACAQIEBAMEBwUEBAABAncAAQIDEQQFITEGEkFRB2FxEyIygQgUQpGhscEJIzNS8BVictEKFiQ04SXxFxgZGiYnKCkqNTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqCg4SFhoeIiYqSk5SVlpeYmZqio6Slpqeoqaqys7S1tre4ubrCw8TFxsfIycrS09TV1tfY2dri4+Tl5ufo6ery8/T19vf4+fr/2gAMAwEAAhEDEQA/APqGgAoAWgAoAWgAoAWgAoAKACgAoAKAFFABQAUAFABQAuKADFABigBaACgAoAKACgAoAKACgAoAKACgAoAKACgAFAC0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABigBMUAGKADFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUAFACUAFABQAUAFACUAFABQAUAFABQAlABQAUAJQAUAJQAUAJQAtAC0AFAC0AFABQAtABQAUAFABQAuKAFoAMUAGKACgBaACgAoAKACgAoAKACgAoAKACgAoAKAFxQAUAGKADFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAYoATFABigAxQAYoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKADFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAJQAUAJQAUAFABigBKACgAoAKACgBKACgAoAKAENACUAFACUALQAooAKAFoAKAFoAKACgAxQAuKAFoAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAMUAGKAExQAYoAMUAFABQAUAFABQAYoAXFABQAUAFACUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUAFABQAlABQAUAJQAUAFABQAUAJQAUAFACUABoASgAoAKAFoAWgAoAKAFxQAuKACgAoAWgAoAWgAoAKACgAoAKACgAoAKACgAoAKACgBcUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAlABQAUAFABQAUAFABQAUAFABQAUAFABQAUAJQAUAFACUAFABQAlABQAUAFABQAlABQAlABQAlABQAtAC0AGKAFoAWgAoAKACgAoAWgAoAWgAoAKACgAoAKACgAoAKACgAoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBDQAUAFABQAUAFABQAUAFABQAUAFABQAhoAKACgBKACgAoAKAEoAKACgAoASgAoAKAEoAKAEoAdigBaACgAoAWgAoAKACgBaACgBaACgAoAKACgAoAKACgAoAKACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAEoAKACgAoAKACgAoAKACgAoAKACgBKACgBKACgAoADQAlABQAUAFABQAlABQAUAJQAlAD6ACgAoAWgAoAKACgBaACgAoAWgAoAKACgAoAKACgAoAKACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAMUAJQAUAFABQAUAFABQAUAFABQAUAJQAUAJQAUAFABQAlABQAUAFACUAFABQAUAIaAHUAFABQAtABQAUAFACigBaACgAoAKACgAoAKACgAoAMUALigAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgAoAKACgAoAKACgAoAKAEoAKACgBKACgAoASgAoAKACgAoASgAoAKAEoAdQAUALQAUAFABQAtABQAtABQAUAFABQAYoAXFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAGKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAExQAUAFABQAUAFABQAUAFACUAFABQAlABQAUAJQAUAFABQAlABQAlABQA6gAoAWgAoAKAFoABQAtABQAUAFABQAtABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFAC0AFACUALQAlABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAJigAoAKACgAoAKACgAoAQ0AJQAUAFABQAlABQAUAFACGgAoAKAEoAdQAUALQAUALigAoAWgAoAKACgAoAAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAWgBKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAFoAMUAFABQAUAFABQAUAFABQAlAC0AJQAtACUAFABQAtABQAlABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAJigAoAKACgAoAKACgBDQAlABQAUAFACUAFABQAlABQAUAJQA/FABQAtABQAtABQAUAFABQAUAGKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBaAEoAWgAoASgAoAWgAoAKACgAoAKACgBKAFoAKACgBKAFoAKAEoAWgAoAKACgAoAKACgAoAKACgAoAMUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUALQAUAJQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACYoAKACgAoAKAEoAKAEoAKACgBKACgAoAKAEoAKAEoAfQAUALQAUALQAUAFABQAUAFAC0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUALQAlABQAtABQAlAC0AFACUALQAUAFABQAUAFABQAUAFABigAoAKACgAoASgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoASgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoASgAoAKACgBKACgBKACgAoASgAoAKACgBKACgAoAdQAUALQAtABQAUAFABQAUAFAC0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFAC0AFABQAlAC0AFABQAUAFABQAUAJQAtABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAlABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAYoATFABQAUAJQAlABQAUAFACGgAoAKACgBKACgAoAdQAUALQAtABQAUAFABQAUAAoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAWgAoASgBaACgAoASgBaAEoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoATFABigBKACgBKACgBKACgAoAKAEoAKAEoAfQAtABQAtABQAUAFABQAUALQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAtABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAlAC0AJQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUAFABQAmKAEoAKAEoAKACgBKACgBKAH0ALQAUAFAC0AFABQAUAKKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAEoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgAoAKACgBMUAJigBKAA0AJQAUAJQBJQAUAFAC0AFABQAUAFAC0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUALQAYoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAxQAUAFABQAUAJQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAJQAUAFABQAUAFACUAJQAlABigBKAEoAkoAKACgBaACgAoAKACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgAoAKACgAoASgAoASgBKACgBOKAH0AFABQAtABQAUAFABQAtABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFAC0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAGKADFABQAUAJQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUAFABQAUAFABQAUAJQAlABQAlACGgB9ABQACgBaACgAoAKACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgAoAKACgAoAKAEoASgAoAKAEIoAWgBaACgBaACgAoAKAAUALQAUAFABQAUAFABQAUAFABQAUAFABQAUALQAlAC0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAJQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAlABQAUAFABQAUAIaAEoAKACgAoASgB1ABQAUALQAUAFABQACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgAoAKACgAoASgBKACgAoAKAEoAWgBaACgBaACgAoAKADNAC0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAtABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAlABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACGgAoAKACgAoAKAEoASgAoAKAEoAKAFoAWgAoAWgAoAKACgAoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKAFoAKACgBKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBDQAUAFABQAUAFACUAJQAUABoASgAoAWgBaACgBaACgAoAKACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoADQAUAFABQAUAFABQAUAJQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAIaACgAoAKACgAoASgBKACgBKACgAoAWgBaAAUALQAUAFABQAUALQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACigAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKAFoASgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAENABQAUAFABQAUAJQAlABQAlABQAUALQAtAAKAFoAKACgAoABQAtABQAUAFABQAUAFABQAUAFABQAUAFABQAUALQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUAFAC0AJQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUABoASgAoAKACgAoASgAoASgAoASgAoAKAFoAKAFoAKAFoAKACgAoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoASgAoAKAFoASgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAEoAKACgAoAKACgBKAEoAKAA0AJQAUAFAC0AFAC0ALQAUAFABQAUAAoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAXNABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUALQAUAFABQAlABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAlABQAUAFABQAUAJQAlABQAGgBKACgAoAWgAoAWgAzQAtABQAUAFABQAooAKACgAoAKACgAoAKACgAoAKACgAoAKACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAEoAWgBKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAQ0AFABQAUAFABQAlABQAlABQAUAJQAUAJQA6gAoAKAFoAWgAoAKACgAoABQAtABQAUAFABQAUAFABQAUAFABQAUAFAC0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAZoAKACgAoAKACgAoASgBaACgBKAFoAKAEoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgAoAKACgAoAQ0AJQAUAFACUAFABQAlADqACgAoAWgBaACgAoAKACgAoAWgAoAKACgAoAKACgAoAKACgAoAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKADNACUALQAUAJQAUAFAC0AFACUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAlABQAUAFABQAlACUAFABQAUAJQAUAIaACgBaAFoAKACgBaAFoAKACgAoAKACgBaACgAoAKACgAoAKACgAoAKACgAoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgBaAEoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAEoAKACgAoAKAEoAKAEoAKACgBKACgANACUAFAC0AFAC0AFAC0ALQAUAFABQAUAFAC0AFABQAUAFABQAUAFABQAUAFABQAUAFAC5oAKACgAoAKADNABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABmgAoAKACgAoAKACgAoAKACgAoASgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgAoAKACgAoAQ0AJQAUAFAAaAEoAKACgBKAEoAdQAUALQAUAFAC0ALQAUAFABQAUAFAAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBaACgBKACgBaAEoAWgAzQAUAFABQAUAFABQAUAJQAUALQAlABQAUAFABQAUAFABQAUAFABQAUALQAlABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUAFABQAUAFABQAUAJQAlABQAUAJQAUAFACUAFACUAOoAKACgBaACgBaACgBaACgAoAKACgAoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoASgAoAKACgAoAKAEoAKAEoAKAA0AJQAUAFACUAFACUALQACgBaAFoAKACgBaAFoAKACgAoAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBM0AFABQAUAFABQAlACUAFAAaAEoAKACgBKACgBDQAlADqACgBaACgAoAWgAoAUUALQAUAFABQAtABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUAFABQAUAFABQAUAJQAlABQAUABoASgAoAKAEoASgAoASgB1ABQAtABQAUAKKACgBQKAFoAKACgAoAKACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAEoAKACgAoAKACgAoASgAoASgAoAKACgBKACgANACUAIaAEoAKAHUAFABQAtABQAtAC0AFAC0AFABQAUAFABQAUALQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAlABQAUAFABQAUAFACUAFABQAlABQAUAFACUAFABQAlABQAlACUAFAC5oAKAFoAUCgBaACgAoAWgAFAC0AFABQAUAFABQAUALQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUAFABQAUAFABQAUAJQAlABQAUAFAAaAEoAKACgBKACgBKAEoADQAlAC0AOAoAXigAoAWgAoAKACgBaACgBaACgAoAKACgAoAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAzQAmaACgAoAKACgAoAKAENACUAFABQAUAFABQAlABQAGgBKACgBDQAlACUAFAD6ACgAoAWgAoAWgAoAKACgBaAFoAKACgAoAKACgAoAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoATNABQAUAFABQAUAFABQAUAFABQAUAIaAEoAKACgAoAKAEoAKACgBDQAUAFACGgBDQAlABQA6gAoAWgAoAWgAoAWgAoAKAFoAKAFoAKACgAoAKACgAoAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAEoAKACgAoAKACgAoAKACgAoAKACgAoAKAEoAM0AFACUAFABQAUAFACUAFABQAlABQAlACUAJQAUAJQA6gBaAFoAKAFoAKACgAoAWgAoAWgAoAWgAoAKACgAoAKACgAoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAM0AGaADNABmgAzQAlABQAuaAEzQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAIaAEoAKACgAoADQAUAJQAUAFACUAFACUAJQAGgBKAEJoAKAHUAFAC0ALQAUALQAUAFAC0AFABQAtABmgAoAWgAoAKACgAoAKACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAzQAmaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAEoAKAEoAKACgAoAKAEoAKACgBDQAUAJQAUAJQAGgBDQAlACZoAfQAUALQAUALQAtABQAUAFAC0AFABQAUAFAC0AAoAWgAoAKACgAoAKACgBaADNABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAZoAM0AGaAEzQAZoAM0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUAFABQAlAAaAEoAKACgAoAKAA0AJQAUAIaAEoADQAlACUAIaAEoAfQAtABQAUALQAtAC0AFABQAUALQAUAFABQAUALQAZoAWgAoAKACgAoAKACgAoAKAFzQAUAFABQAUAFABQAUAFABQAUAFABQAZoAKACgAoAM0AFABQAUAGaADNABmgAzQAZoAM0AGaADNABmgBM0AGaADNABmgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoASgAoAKACgBKACgANACUAFABQAUAFACGgAoAKAENACUAJQAUAJQAlACUAPoAKAFoAKAFoAWgAoAWgAoAKACgBc0AFABQAUAFABQAooAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBKACgBKACgAoAKAEoAKACgAoAKACgBKACgBM0AJQAUAJQAlACUAFACUAOoAWgAoAWgAoAUGgBaACgAzQAtABQAUAKKACgAoAKACgAoAWgAoAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoATNABQAUAJQAUAFABQAUAFACUAFABQAUAFACUAFACGgBKACgANADc0AFACUAJmgBM0AOoAWgBaACgBc0AFACigBaACgBRQAUAFABQAZoAXNABQAUAFABQAooAKAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBDQAUAJQAUAFABQAUAFABQAlABQAUAFABQAlABQAUAIaAEoADQAhoASgBDQAlACGgAoAdQACgBaAFoAKAFzQAtAC0AFAAKAFzQAUAFABQAUALQAUAFABQAUAFABQAtABmgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAQ0AJQAtACUAFABQAUAHNACUAFABQAUAFACUAFABQAhNACUAFACUAJQAUAJQAhoASgAoAXNABQAtAC0AGaAFoAUUALQAUALQAUAGaAFoAKACgAoAKAFFABQAUAFABQAUALQAUAFAC0AFABQAlAC0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACUAFABQAUAFAC0AFABQAUAFACUAFAC0AFABQAUAJQAtACUALQAlAC0AJmgAoAWgAoAKACgAoAKACgAoAKACgAoASgBaACgAoAKACgAoAKACgBKACgAoASgAoAKACgAoAKAEoAKACgAoATNABQAUAFACUAJQAUAFACUAJQAhoASgBKACgBKAFoAWgAoAWgBaAFoABQAtABQAtAC0AFABQAtABQAUAFABQAUALQAUAFABQAUAFAC0AFABQAUAFABQAUALQAUAJQAtACUALQAlABQAtABQAlAC0AFABQAlAC0AJmgAoAKAA0AFABQAUAFABQAUAFABmgAoAKACgAoAKACgAoAKACgAoAKACgAzQAUAFABQAUAFABQAUAFABQAUAFABQAUAGaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAEoAKACgAoAKACgBKACgAoAKAENABQAUAFABQAlACUABoASgBDQAUAIaAEoASgBKAEoAXNAC0AKKACgBaAFzQAtABQAtABQAooAWgAoAKACgBaACgAoAKACgBc0AGaACgAoAKACgAoAKAFoASgBaACgAoAKACgAoAKADNABQAZoAKACgAoAM0AFABQAZoAKAEoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoASgAoAKACgAoAKAEoAKACgAoAKAEoASgANACE0AJQAlACUAJQAGgBKAENABQAooAWgBc0AFAC0ALQAtABQAtABQAuaAFoAKACgAoAWgAoAKACgAoAKACgBc0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAJQAUAFABQAUAFACUAFABQAUAJQAUAJQAUAJQAhoAKAEoASgBKAENACUAJQAZoAUGgBc0ALQAooAKAFoAWgBRQAooAKACgAoAXNAC0AFABQAZoAXNABQAUAFABQAUAFABQAtABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAGaACgAoAKACgAoAM0AFABQAUAAoAKACgAoAKACgAoAKACgAoAM0AFABmgAoAKACgAoAM0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAJQAUAFABQAUAFABQAmaAA0AFABQAhoAM0AJQAUAFACUAJQAGgBKAEoASgBM0AFADSaAEzQAmaAFBoAcDQAoNABmgBQaAFzQAuaADNAC5oAXNABmgBc0AGaAFzQAZoAM0AGaAFoABQAtABQAUAFABQAUAGaADNAC0AFABQAZoAM0AGaAEoAXNABmgAoAM0AGaADNABQAUAGaADNABmgAoASgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAXNABQAUAJQAUAFABQAUAGaACgAoAKAFzQAlABQAUAGaAFzQAmaAFoAM0AJQAUALmgAzQAmaACgAoAM0AGaAFzQAZoATNAC5oATNABQAUAFABQAUAFABQAZoAM0AITQAZoATNABmgAzQAmaADNABmgBM0AJmgAJoAQmgBM0AITQAZoAQmgBM0ANJoAQmgBM0AJmgBd1ACg0ALmgB2aACgBRQA4UAFABQAoNAC0AAoAWgBRQAUAFABQAtABQAtABQAUAFABQAUAFAC0AFABQAUAFABQAUAJmgBaACgAoAKACgAoAKACgAoAKACgAoAKACgBKAFoAKAEoAKACgAoAKADNABQAUAFABmgAoAKAFzQAmaACgAzQAUAGaADNABmgAzQAZoAKADNABmgAoAM0AGaACgAzQAZoAM0AGaACgAoAM0AGaACgAoAKACgAzQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACGgBKACgAoADQAlABQAZoASgBM0AJQAGgBKAEoATNACZoATNACEigBpNACZoATNABmgBwNACg0AKKAFoAUUAOBoAKAFzQAuaAFzQAZoAXNABmgBc0AGaAFzQAUAKKACgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAM0AGaACgAoAKACgAzQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABmgAoAKACgAoAKAEoAKAFoAKACgBKACgBaACgAoAKACgAzQAUAFABQAUAJQAtACUALQAlABmgAzQAZoAM0AGaAEoAM0ABNACZoATNABmgAJoATNABmgBM0AITQAmaAEoASgBKAEzQAlADSaAEzQAmaAG5oAWgBc0AOBoAXNAC5oAcDQAoPFAC5oAUGgAzQAoIoAXIoAM0ALmgAzQAtAC5oAM0AFAC5oAM0AFABQAUAFAC5oAM0AGaADNABmgAoAM0AGaADNABmgAzQAZoAM0AGaADNABmgAzQAZoAKACgAoASgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAWgAoASgAoAWgBKACgAoAKACgAoAKADNABmgAzQAZoATNABQAUAIaACgBKADNACZoAM0AJmgBM0AJmgAzQA0mgBM0AJmgBM0ANJoAQmgBuaAEJoAZuFAChqAHBqAFDUAO3UAOzQAoNAC5oAUGgBQaAFzQAoNABmgBc0ALmgBaACgBQaADNAADQAuaADNABk0AGaADNACg0ALmgAzQAZoAM0AGaADNABmgAzQAZoAM0AGaADNABmgAzQAZoAM0AGaADNABmgAzQAZoAM0AGaADNABmgAzQAZoAM0AGaADNABmgAzQAZoAM0AGaADNABmgBM0ALmgAzQAZoAM0AGaADNABmgAzQAZoAM0AGaADNABmgAzQAZoAM0AGaADNABmgAzQAZoAM0AGaADNABmgAzQAZoAM0AGaADNABmgAzQAZoAM0AGaADNABmgAzQAmaADNACZoAM0AGaADNABmgAzQAmaAEoAKAEoAM0AJQAUANzQAhNABmgBpNACZoATNADSaAEJoAbmgBCaAELUARbqAFBoAeDQAuaAHA0AOzQAoNACg0AOBoAUGgBc0ALmgAzQAuaAFzQAuaADNACg0ALmgAzQAuaADNABmgBaACgAoAWgAoAKADNABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABmgAoAKACgAoAKADNABQAUAFABQAUAFABmgAoAKACgAoAKACgAoAM0AFABQAUAFABQAUAFABmgAoAM0AGaACgAoAM0AFABQAUAFABQAUAFABQAZoASgAoAKAEzQAZoAM0AITQAZoATNABk0AJQAZoATNACZoATNACZoAM0AITQA0mgBM0ANzQAhNADSaAG5oAQtQA0mgCPdQAoagBwIoAcGoAcGoAcGoAXNADs0AKDQAoagB2aADNAC0AGaAHZoAXNABmgBQaAFzQAA0ALmgAzQAuaACgAoAWgBaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBM0ALQAUAFABQAUAFACUAGaAFoAKACgBKAFoAKACgAoAKACgAoASgAoAWgAoAKACgAoAKACgAoAKACgAoAKACgBDQAlABQAZoATdQAZoAM0AJmgBCaADNACZoAMmgBuaADNACUAJmgBCaAE3UANJoATNACE0ANLUAMLUAIWoAYWoATdQBGDQA4NQA4NxQAoagBwagBwagB26gB2eKADdQA7dQA4GgBQaAFzQAZoAXNACg0ALmgBQaADNACg0ALmgABoAWgBc0AGaADNAC5oAM0AGaADNAC5oAM0AGaAEzQAZoAXNABmgAzQAZoATNAC5oAKADNABmgBM0AGaADNAC5oAM0AGaAEzQAuaADNACZoAXNACUALmgBM0AGaADNABQAZoAXNACUALmgAoAM0AJmgAoAM0ALmgBKAFzQAmaADNABmgAzQAZoAM0AGaADNABmgAoAM0ALQAmaADNABmgAzQAZoAM0AGaA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";

        private string imagePart2Data = "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kbweCDQBHDOk8AlhIKHqfWpscccIeq+tc5JFcaNdebBmSyY8r6VvQXEd1Y+dEwIPX2oAmoo7UUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAN427Vp38WM0cjPFQTTRWto0src0ANurmO2tDJIQgXv61hW9tPqmoC8uQUtQfljNLBBPq16Lq6yLNT+7T+9XSKFVAFPH0oAAAqgAYFLRRQAUUUUAFFFFAHn3iz/kYof+vYf+hNRR4s/wCRih/69h/6E1FAHaab/wAi7Yf9eyf+girtUtN/5F2w/wCvZP8A0EVdoAKKKKACiiigBGRWhKOMg/ernJoJ9JvDc2uWsSfnSukz82e1NcKylSAwP8JoAitLmG5t/MjIYY+76VPk5wfvHpXNXFvcaXd/arLL22fnX0rbtbqK7txNGf8AeHpQBaooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKAE5LZNBIL0pJIqKedIIC7kDFACTzR21s0srYhHQVz8Ucmr3puJ8pZqflX+9SpHNrF/wCY5K2SHgf3q6FI0RAQu1FHCjtQA5VVUCqAFA4Ap1FFABRRRQAUUUUAFFFFAHn3iz/kYof+vYf+hNRR4s/5GKH/AK9h/wChNRQB2mm/8i7Yf9eyf+girtUtN/5F2w/69k/9BFXaACiiigAooooAKKKKAE2gqw4/2hXN3NrLp14b2yBMOfnQV0h+71w386TqMkA+qmgCpaXcd7AJIj9U9Ku4GMDmudvLOawuRe2JPq6CtayvoryANEfn/jFAFyiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiimu6ohZiAAM8mgBs0iRRMzsFVRnJrnF83Wr3cQUsUPT+/Q3m61e7ASlih6/366SGNIolVFCqo6CgBY41hjCqAFA4FO3Z70rck0nQUAFFFFABRRRQAUUUUAFFFFAHn3iz/AJGKH/r2H/oTUUeLP+Rih/69h/6E1FAHaab/AMi7Yf8AXsn/AKCKu1S03/kXbD/r2T/0EVdoAKKKKACiiigAooooAKKKKAGnGSpGVPWufu7OW0uDe2GQepUV0e75cryppuAAV7GgCjY30V5bq3SXuncVfb7455/nXP3tjLb3Bv7HIkH309avWN9HeQZBxN/GD1FAGlRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUU1mCoWYgADnNACSSIiEswUj+I9q5yR5tY1AwoGW0Q/Mf71JLLJq959lgLJbKfnf1robaGO3t1jiXCKMZ9aAFghSCAIoAwKlAJFAGXpOS2BQAtFFFABRRRQAUUUUAFFFFABRRRQB594s/wCRih/69h/6E1FHiz/kYof+vYf+hNRQB2mm/wDIu2H/AF7J/wCgirtUtN/5F2w/69k/9BFXaACiiigAooooAKKKKACiiigAooooACCTkdPSsG90+RZzf2Hyzjkgd63eCeDz3peCvBx60AZthfJeQkH5bhfvIe1aQO6LIPzDqfWsO/05hObuyJjuF5YD+KrOn6il3EUf93cLwyGgDTooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiikJAUsSAB3oAQsqIWk5T0rnJ7ibVbw2dtn7Mp+eT1ouLi41LUjaWpK23/LST0rctrWK2tBFGu1R+tACwQR2lusMKjpyasewOBR3IHSgBTGf71ABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFAHn3iz/kYof8Ar2H/AKE1FHiz/kYof+vYf+hNRQB2mm/8i7Yf9eyf+girtUtN/wCRdsP+vZP/AEEVdoAKKKKACiiigAooooAKKKKACiiigAooooACflyvUViahpxMv26y+W5HUDvW4evHBpD/AKzPT1oAyNO1FbpTFKPIuhwQe9a2GzgD6nNU2sbdrz7T5f7/AL4OKuBcY7J3FAC0UUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAIWXbnf06k1zt3cy6hffYrRikAPzMK6CaNZ4SjjKHriq8Ftb2qlIV2IerdaAFtbaGzsxHGPqfWrOR5igUHdjAWkyAP9qgB1FFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFAHn3iz/AJGKH/r2H/oTUUeLP+Rih/69h/6E1FAHaab/AMi7Yf8AXsn/AKCKu1S03/kXbD/r2T/0EVdoAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooA8+8Wf8AIxQ/9ew/9CaijxZ/yMUP/XsP/QmooA7TTf8AkXbD/r2T/wBBFXapab/yLth/17J/6CKu0AFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAefeLP+Rih/69h/6E1FHiz/AJGKH/r2H/oTUUAdppv/ACLth/17J/6CKu1S03/kXbD/AK9k/wDQRV2gAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigBjMsYLyOqJ6k4piTwMwRJ4pH7BWFcN8RSyfDm6ZHZH4wQcd68j+HE87/ABHs0knllTncCxPavjM24u+p5rSwPs78/Lre1rt9LHi4zOPY4uGH5L3trfu7dj6booor7M9oKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKAPPvFn/IxQ/9ew/9CaijxZ/yMUP/AF7D/wBCaigDtNN/5F2w/wCvZP8A0EVdqlpv/Iu2H/Xsn/oIq7QAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQB578Sv+SZ3f4fzryD4bf8lOs/x/lXsHxL/wCSZ3n4fzrx/wCG3/JTrP8AH+VfjPFX/JV4T/t38z4nNv8AkbUfl+bPp2RhHFJJ1RVJx68V5PbfFO2bxCbO7077NAjEed5mc/hXqtwf9AnAO4CNvl/Cvji7Xd4iljZiAZ8Y+pr3+PeIMdljoPDStdu6snfbTU9LiDMK+F9k6T3vf8D26++K9rDdstlp7XSD+IN1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MbAT0rtb+wttQ0uSzuow0Tj7x7V9Bjsvq57kvs68PZzetuzT0+TPRrYapj8Fy1I8sn+DR4F8OvFcGk3UtjfNsgbG0ntXu0mr6eNFkvPtURttufvDJryHVfhVKLzzdOu9yMSSm3GPxrPj+GGslkEl7KkfZMkivk8lxfEWVUPqjwnOl8L/AOD2PHwVXMcJT9jKjzW21OD8RXsF948uLq3bzIZHHNfQmmWA1L4PRWudqvGcd681f4V6kl0BHceainJO2vbdDspNO8L2tnK20xj0pcGZJj443ESxlLlU079nd6pFZJga6r1XWhbmX6nyptufD/jPLxtHPDJ1PcZr6Y0DxTpmtabEyXKR3IUB1Y4qt4l8Gad4ihMjgQXX/PUDrXmUvwv1a3vHFveP5XYrxU4HLM64exM1hqftaUn31/4DIw+Fx2W1n7KHNFns1/4g0nTIDJd3kafQ5q7YajZ6ppS3llIJYD/FXhsPwt1W4vkS5vpER/4yc16x4Y8PN4d0P7I9yb0DpxivsMmzXOMTin7fDezp273d/wBV8j2sDjMZWq/vafLH11ucL8WiTpNiRwOcVg/CbC6zeZOc4zXoHjjw5deIrG3jtnI8vPGPWs7wP4PvPDt9cy3Mmd+McV83i8nxsuK44qNN+zVtemx5lXA13m6q8vu9/keo0UUV+pn1YUUUUAFFFFABRRRQAUUUUAefeLP+Rih/69h/6E1FHiz/AJGKH/r2H/oTUUAdppv/ACLth/17J/6CKu1S03/kXbD/AK9k/wDQRV2gAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACjtiiigAooooAKKKKADvRRRQAUUUUAFFFFABRRRQAUUUUAHeiiigAooooAKKKKACiiigAooooAKKKKACiiigA70UUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAefeLP+Rih/69h/6E1FHiz/AJGKH/r2H/oTUUAdppv/ACLth/17J/6CKu1S03/kXbD/AK9k/wDQRV2gAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigDz7xZ/yMUP8A17D/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m/8AIu2H/Xsn/oIq7VLTf+RdsP8Ar2T/ANBFXaACiiigAI+QKtBwGHejp0qhe3y2dsWbl+woAL69Wzti7HMh+6g61Q0+zkmmN/fcyn7qn+GmWNlLcXn26+yzH7q/3a6BcBto6dhQAvaiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKAK88KTQGOVcxNWAHm0a92OGksWPFdP/ABktyvpUcsSzwlZEDDtQARyJJCJVbch6VIQCo3VjWVpc2WpsobfaHpmtnJBIPLdhQAUUUUAefeLP+Rih/wCvYf8AoTUUeLP+Rih/69h/6E1FAHaab/yLth/17J/6CKu1S03/AJF2w/69k/8AQRV2gAooooATnBPp92sWLT5ptYa8vG3YPyr2rbABHH3expOdvXLUALgAYHSiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigDz7xZ/wAjFD/17D/0JqKPFn/IxQ/9ew/9CaigDtNN/wCRdsP+vZP/AEEVdqlpv/Iu2H/Xsn/oIq7QAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQB594s/5GKH/r2H/oTUUeLP8AkYof+vYf+hNRQBDb+J7+CwghSGzKxxqoJRs4Ax/eqb/hLNR/542X/fDf/FUUUAH/AAlmo/8APGy/74b/AOKo/wCEs1H/AJ42X/fDf/FUUUAH/CWaj/zxsv8Avhv/AIqj/hLNR/542X/fDf8AxVFFAB/wlmo/88bL/vhv/iqP+Es1H/njZf8AfDf/ABVFFAB/wlmo/wDPGy/74b/4qj/hLNR/542X/fDf/FUUUAH/AAlmo/8APGy/74b/AOKo/wCEs1H/AJ42X/fDf/FUUUAH/CWaj/zxsv8Avhv/AIqj/hLNR/542X/fDf8AxVFFAB/wlmo/88bL/vhv/iqP+Es1H/njZf8AfDf/ABVFFAB/wlmo/wDPGy/74b/4qj/hLNR/542X/fDf/FUUUAH/AAlmo/8APGy/74b/AOKo/wCEs1H/AJ42X/fDf/FUUUAH/CWaj/zxsv8Avhv/AIqj/hLNR/542X/fDf8AxVFFAB/wlmo/88bL/vhv/iqP+Es1H/njZf8AfDf/ABVFFAB/wlmo/wDPGy/74b/4qj/hLNR/542X/fDf/FUUUAH/AAlmo/8APGy/74b/AOKo/wCEs1H/AJ42X/fDf/FUUUAH/CWaj/zxsv8Avhv/AIqj/hLNR/542X/fDf8AxVFFAB/wlmo/88bL/vhv/iqP+Es1H/njZf8AfDf/ABVFFAB/wlmo/wDPGy/74b/4qj/hLNR/542X/fDf/FUUUAH/AAlmo/8APGy/74b/AOKo/wCEs1H/AJ42X/fDf/FUUUAH/CWaj/zxsv8Avhv/AIqj/hLNR/542X/fDf8AxVFFAB/wlmo/88bL/vhv/iqP+Es1H/njZf8AfDf/ABVFFAB/wlmo/wDPGy/74b/4qj/hLNR/542X/fDf/FUUUAH/AAlmo/8APGy/74b/AOKo/wCEs1H/AJ42X/fDf/FUUUAH/CWaj/zxsv8Avhv/AIqj/hLNR/542X/fDf8AxVFFAB/wlmo/88bL/vhv/iqP+Es1H/njZf8AfDf/ABVFFAB/wlmo/wDPGy/74b/4qj/hLNR/542X/fDf/FUUUAH/AAlmo/8APGy/74b/AOKo/wCEs1H/AJ42X/fDf/FUUUAH/CWaj/zxsv8Avhv/AIqj/hLNR/542X/fDf8AxVFFAB/wlmo/88bL/vhv/iqP+Es1H/njZf8AfDf/ABVFFAB/wlmo/wDPGy/74b/4qj/hLNR/542X/fDf/FUUUAH/AAlmo/8APGy/74b/AOKo/wCEs1H/AJ42X/fDf/FUUUAH/CWaj/zxsv8Avhv/AIqj/hLNR/542X/fDf8AxVFFAGFqep3GoX6TTJCrLGFAQEDGSe5PrRRRQB//2Q==";

        private string extendedPart1Data = "AgAAAAEAAACVGQAAPD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz4KPCFET0NUWVBFIHBsaXN0IFBVQkxJQyAiLS8vQXBwbGUvL0RURCBQTElTVCAxLjAvL0VOIiAiaHR0cDovL3d3dy5hcHBsZS5jb20vRFREcy9Qcm9wZXJ0eUxpc3QtMS4wLmR0ZCI+CjxwbGlzdCB2ZXJzaW9uPSIxLjAiPgo8ZGljdD4KCTxrZXk+Y29tLmFwcGxlLnByaW50LlBhZ2VGb3JtYXQuUE1Ib3Jpem9udGFsUmVzPC9rZXk+Cgk8ZGljdD4KCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuY3JlYXRvcjwva2V5PgoJCTxzdHJpbmc+Y29tLmFwcGxlLmpvYnRpY2tldDwvc3RyaW5nPgoJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5pdGVtQXJyYXk8L2tleT4KCQk8YXJyYXk+CgkJCTxkaWN0PgoJCQkJPGtleT5jb20uYXBwbGUucHJpbnQuUGFnZUZvcm1hdC5QTUhvcml6b250YWxSZXM8L2tleT4KCQkJCTxyZWFsPjcyPC9yZWFsPgoJCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LnN0YXRlRmxhZzwva2V5PgoJCQkJPGludGVnZXI+MDwvaW50ZWdlcj4KCQkJPC9kaWN0PgoJCTwvYXJyYXk+Cgk8L2RpY3Q+Cgk8a2V5PmNvbS5hcHBsZS5wcmludC5QYWdlRm9ybWF0LlBNT3JpZW50YXRpb248L2tleT4KCTxkaWN0PgoJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5jcmVhdG9yPC9rZXk+CgkJPHN0cmluZz5jb20uYXBwbGUuam9idGlja2V0PC9zdHJpbmc+CgkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0Lml0ZW1BcnJheTwva2V5PgoJCTxhcnJheT4KCQkJPGRpY3Q+CgkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC5QYWdlRm9ybWF0LlBNT3JpZW50YXRpb248L2tleT4KCQkJCTxpbnRlZ2VyPjE8L2ludGVnZXI+CgkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuc3RhdGVGbGFnPC9rZXk+CgkJCQk8aW50ZWdlcj4wPC9pbnRlZ2VyPgoJCQk8L2RpY3Q+CgkJPC9hcnJheT4KCTwvZGljdD4KCTxrZXk+Y29tLmFwcGxlLnByaW50LlBhZ2VGb3JtYXQuUE1TY2FsaW5nPC9rZXk+Cgk8ZGljdD4KCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuY3JlYXRvcjwva2V5PgoJCTxzdHJpbmc+Y29tLmFwcGxlLmpvYnRpY2tldDwvc3RyaW5nPgoJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5pdGVtQXJyYXk8L2tleT4KCQk8YXJyYXk+CgkJCTxkaWN0PgoJCQkJPGtleT5jb20uYXBwbGUucHJpbnQuUGFnZUZvcm1hdC5QTVNjYWxpbmc8L2tleT4KCQkJCTxyZWFsPjE8L3JlYWw+CgkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuc3RhdGVGbGFnPC9rZXk+CgkJCQk8aW50ZWdlcj4wPC9pbnRlZ2VyPgoJCQk8L2RpY3Q+CgkJPC9hcnJheT4KCTwvZGljdD4KCTxrZXk+Y29tLmFwcGxlLnByaW50LlBhZ2VGb3JtYXQuUE1WZXJ0aWNhbFJlczwva2V5PgoJPGRpY3Q+CgkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LmNyZWF0b3I8L2tleT4KCQk8c3RyaW5nPmNvbS5hcHBsZS5qb2J0aWNrZXQ8L3N0cmluZz4KCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuaXRlbUFycmF5PC9rZXk+CgkJPGFycmF5PgoJCQk8ZGljdD4KCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LlBhZ2VGb3JtYXQuUE1WZXJ0aWNhbFJlczwva2V5PgoJCQkJPHJlYWw+NzI8L3JlYWw+CgkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuc3RhdGVGbGFnPC9rZXk+CgkJCQk8aW50ZWdlcj4wPC9pbnRlZ2VyPgoJCQk8L2RpY3Q+CgkJPC9hcnJheT4KCTwvZGljdD4KCTxrZXk+Y29tLmFwcGxlLnByaW50LlBhZ2VGb3JtYXQuUE1WZXJ0aWNhbFNjYWxpbmc8L2tleT4KCTxkaWN0PgoJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5jcmVhdG9yPC9rZXk+CgkJPHN0cmluZz5jb20uYXBwbGUuam9idGlja2V0PC9zdHJpbmc+CgkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0Lml0ZW1BcnJheTwva2V5PgoJCTxhcnJheT4KCQkJPGRpY3Q+CgkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC5QYWdlRm9ybWF0LlBNVmVydGljYWxTY2FsaW5nPC9rZXk+CgkJCQk8cmVhbD4xPC9yZWFsPgoJCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LnN0YXRlRmxhZzwva2V5PgoJCQkJPGludGVnZXI+MDwvaW50ZWdlcj4KCQkJPC9kaWN0PgoJCTwvYXJyYXk+Cgk8L2RpY3Q+Cgk8a2V5PmNvbS5hcHBsZS5wcmludC5zdWJUaWNrZXQucGFwZXJfaW5mb190aWNrZXQ8L2tleT4KCTxkaWN0PgoJCTxrZXk+UE1QUERQYXBlckNvZGVOYW1lPC9rZXk+CgkJPGRpY3Q+CgkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5jcmVhdG9yPC9rZXk+CgkJCTxzdHJpbmc+Y29tLmFwcGxlLmpvYnRpY2tldDwvc3RyaW5nPgoJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuaXRlbUFycmF5PC9rZXk+CgkJCTxhcnJheT4KCQkJCTxkaWN0PgoJCQkJCTxrZXk+UE1QUERQYXBlckNvZGVOYW1lPC9rZXk+CgkJCQkJPHN0cmluZz5BNDwvc3RyaW5nPgoJCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5zdGF0ZUZsYWc8L2tleT4KCQkJCQk8aW50ZWdlcj4wPC9pbnRlZ2VyPgoJCQkJPC9kaWN0PgoJCQk8L2FycmF5PgoJCTwvZGljdD4KCQk8a2V5PlBNUFBEVHJhbnNsYXRpb25TdHJpbmdQYXBlck5hbWU8L2tleT4KCQk8ZGljdD4KCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LmNyZWF0b3I8L2tleT4KCQkJPHN0cmluZz5jb20uYXBwbGUuam9idGlja2V0PC9zdHJpbmc+CgkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5pdGVtQXJyYXk8L2tleT4KCQkJPGFycmF5PgoJCQkJPGRpY3Q+CgkJCQkJPGtleT5QTVBQRFRyYW5zbGF0aW9uU3RyaW5nUGFwZXJOYW1lPC9rZXk+CgkJCQkJPHN0cmluZz5BNDwvc3RyaW5nPgoJCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5zdGF0ZUZsYWc8L2tleT4KCQkJCQk8aW50ZWdlcj4wPC9pbnRlZ2VyPgoJCQkJPC9kaWN0PgoJCQk8L2FycmF5PgoJCTwvZGljdD4KCQk8a2V5PlBNVGlvZ2FQYXBlck5hbWU8L2tleT4KCQk8ZGljdD4KCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LmNyZWF0b3I8L2tleT4KCQkJPHN0cmluZz5jb20uYXBwbGUuam9idGlja2V0PC9zdHJpbmc+CgkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5pdGVtQXJyYXk8L2tleT4KCQkJPGFycmF5PgoJCQkJPGRpY3Q+CgkJCQkJPGtleT5QTVRpb2dhUGFwZXJOYW1lPC9rZXk+CgkJCQkJPHN0cmluZz5pc28tYTQ8L3N0cmluZz4KCQkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuc3RhdGVGbGFnPC9rZXk+CgkJCQkJPGludGVnZXI+MDwvaW50ZWdlcj4KCQkJCTwvZGljdD4KCQkJPC9hcnJheT4KCQk8L2RpY3Q+CgkJPGtleT5jb20uYXBwbGUucHJpbnQuUGFnZUZvcm1hdC5QTUFkanVzdGVkUGFnZVJlY3Q8L2tleT4KCQk8ZGljdD4KCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LmNyZWF0b3I8L2tleT4KCQkJPHN0cmluZz5jb20uYXBwbGUuam9idGlja2V0PC9zdHJpbmc+CgkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5pdGVtQXJyYXk8L2tleT4KCQkJPGFycmF5PgoJCQkJPGRpY3Q+CgkJCQkJPGtleT5jb20uYXBwbGUucHJpbnQuUGFnZUZvcm1hdC5QTUFkanVzdGVkUGFnZVJlY3Q8L2tleT4KCQkJCQk8YXJyYXk+CgkJCQkJCTxpbnRlZ2VyPjA8L2ludGVnZXI+CgkJCQkJCTxpbnRlZ2VyPjA8L2ludGVnZXI+CgkJCQkJCTxyZWFsPjc4MzwvcmVhbD4KCQkJCQkJPHJlYWw+NTU5PC9yZWFsPgoJCQkJCTwvYXJyYXk+CgkJCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LnN0YXRlRmxhZzwva2V5PgoJCQkJCTxpbnRlZ2VyPjA8L2ludGVnZXI+CgkJCQk8L2RpY3Q+CgkJCTwvYXJyYXk+CgkJPC9kaWN0PgoJCTxrZXk+Y29tLmFwcGxlLnByaW50LlBhZ2VGb3JtYXQuUE1BZGp1c3RlZFBhcGVyUmVjdDwva2V5PgoJCTxkaWN0PgoJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuY3JlYXRvcjwva2V5PgoJCQk8c3RyaW5nPmNvbS5hcHBsZS5qb2J0aWNrZXQ8L3N0cmluZz4KCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0Lml0ZW1BcnJheTwva2V5PgoJCQk8YXJyYXk+CgkJCQk8ZGljdD4KCQkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC5QYWdlRm9ybWF0LlBNQWRqdXN0ZWRQYXBlclJlY3Q8L2tleT4KCQkJCQk8YXJyYXk+CgkJCQkJCTxyZWFsPi0xODwvcmVhbD4KCQkJCQkJPHJlYWw+LTE4PC9yZWFsPgoJCQkJCQk8cmVhbD44MjQ8L3JlYWw+CgkJCQkJCTxyZWFsPjU3NzwvcmVhbD4KCQkJCQk8L2FycmF5PgoJCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5zdGF0ZUZsYWc8L2tleT4KCQkJCQk8aW50ZWdlcj4wPC9pbnRlZ2VyPgoJCQkJPC9kaWN0PgoJCQk8L2FycmF5PgoJCTwvZGljdD4KCQk8a2V5PmNvbS5hcHBsZS5wcmludC5QYXBlckluZm8uUE1QYXBlck5hbWU8L2tleT4KCQk8ZGljdD4KCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LmNyZWF0b3I8L2tleT4KCQkJPHN0cmluZz5jb20uYXBwbGUuam9idGlja2V0PC9zdHJpbmc+CgkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5pdGVtQXJyYXk8L2tleT4KCQkJPGFycmF5PgoJCQkJPGRpY3Q+CgkJCQkJPGtleT5jb20uYXBwbGUucHJpbnQuUGFwZXJJbmZvLlBNUGFwZXJOYW1lPC9rZXk+CgkJCQkJPHN0cmluZz5pc28tYTQ8L3N0cmluZz4KCQkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuc3RhdGVGbGFnPC9rZXk+CgkJCQkJPGludGVnZXI+MDwvaW50ZWdlcj4KCQkJCTwvZGljdD4KCQkJPC9hcnJheT4KCQk8L2RpY3Q+CgkJPGtleT5jb20uYXBwbGUucHJpbnQuUGFwZXJJbmZvLlBNVW5hZGp1c3RlZFBhZ2VSZWN0PC9rZXk+CgkJPGRpY3Q+CgkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5jcmVhdG9yPC9rZXk+CgkJCTxzdHJpbmc+Y29tLmFwcGxlLmpvYnRpY2tldDwvc3RyaW5nPgoJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuaXRlbUFycmF5PC9rZXk+CgkJCTxhcnJheT4KCQkJCTxkaWN0PgoJCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LlBhcGVySW5mby5QTVVuYWRqdXN0ZWRQYWdlUmVjdDwva2V5PgoJCQkJCTxhcnJheT4KCQkJCQkJPGludGVnZXI+MDwvaW50ZWdlcj4KCQkJCQkJPGludGVnZXI+MDwvaW50ZWdlcj4KCQkJCQkJPHJlYWw+NzgzPC9yZWFsPgoJCQkJCQk8cmVhbD41NTk8L3JlYWw+CgkJCQkJPC9hcnJheT4KCQkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuc3RhdGVGbGFnPC9rZXk+CgkJCQkJPGludGVnZXI+MDwvaW50ZWdlcj4KCQkJCTwvZGljdD4KCQkJPC9hcnJheT4KCQk8L2RpY3Q+CgkJPGtleT5jb20uYXBwbGUucHJpbnQuUGFwZXJJbmZvLlBNVW5hZGp1c3RlZFBhcGVyUmVjdDwva2V5PgoJCTxkaWN0PgoJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuY3JlYXRvcjwva2V5PgoJCQk8c3RyaW5nPmNvbS5hcHBsZS5qb2J0aWNrZXQ8L3N0cmluZz4KCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0Lml0ZW1BcnJheTwva2V5PgoJCQk8YXJyYXk+CgkJCQk8ZGljdD4KCQkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC5QYXBlckluZm8uUE1VbmFkanVzdGVkUGFwZXJSZWN0PC9rZXk+CgkJCQkJPGFycmF5PgoJCQkJCQk8cmVhbD4tMTg8L3JlYWw+CgkJCQkJCTxyZWFsPi0xODwvcmVhbD4KCQkJCQkJPHJlYWw+ODI0PC9yZWFsPgoJCQkJCQk8cmVhbD41Nzc8L3JlYWw+CgkJCQkJPC9hcnJheT4KCQkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuc3RhdGVGbGFnPC9rZXk+CgkJCQkJPGludGVnZXI+MDwvaW50ZWdlcj4KCQkJCTwvZGljdD4KCQkJPC9hcnJheT4KCQk8L2RpY3Q+CgkJPGtleT5jb20uYXBwbGUucHJpbnQuUGFwZXJJbmZvLnBwZC5QTVBhcGVyTmFtZTwva2V5PgoJCTxkaWN0PgoJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuY3JlYXRvcjwva2V5PgoJCQk8c3RyaW5nPmNvbS5hcHBsZS5qb2J0aWNrZXQ8L3N0cmluZz4KCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0Lml0ZW1BcnJheTwva2V5PgoJCQk8YXJyYXk+CgkJCQk8ZGljdD4KCQkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC5QYXBlckluZm8ucHBkLlBNUGFwZXJOYW1lPC9rZXk+CgkJCQkJPHN0cmluZz5BNDwvc3RyaW5nPgoJCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5zdGF0ZUZsYWc8L2tleT4KCQkJCQk8aW50ZWdlcj4wPC9pbnRlZ2VyPgoJCQkJPC9kaWN0PgoJCQk8L2FycmF5PgoJCTwvZGljdD4KCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuQVBJVmVyc2lvbjwva2V5PgoJCTxzdHJpbmc+MDAuMjA8L3N0cmluZz4KCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQudHlwZTwva2V5PgoJCTxzdHJpbmc+Y29tLmFwcGxlLnByaW50LlBhcGVySW5mb1RpY2tldDwvc3RyaW5nPgoJPC9kaWN0PgoJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LkFQSVZlcnNpb248L2tleT4KCTxzdHJpbmc+MDAuMjA8L3N0cmluZz4KCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC50eXBlPC9rZXk+Cgk8c3RyaW5nPmNvbS5hcHBsZS5wcmludC5QYWdlRm9ybWF0VGlja2V0PC9zdHJpbmc+CjwvZGljdD4KPC9wbGlzdD4KAgAAAPUKAAA8P3htbCB2ZXJzaW9uPSIxLjAiIGVuY29kaW5nPSJVVEYtOCI/Pgo8IURPQ1RZUEUgcGxpc3QgUFVCTElDICItLy9BcHBsZS8vRFREIFBMSVNUIDEuMC8vRU4iICJodHRwOi8vd3d3LmFwcGxlLmNvbS9EVERzL1Byb3BlcnR5TGlzdC0xLjAuZHRkIj4KPHBsaXN0IHZlcnNpb249IjEuMCI+CjxkaWN0PgoJPGtleT5jb20uYXBwbGUucHJpbnQuRG9jdW1lbnRUaWNrZXQuUE1TcG9vbEZvcm1hdDwva2V5PgoJPGRpY3Q+CgkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LmNyZWF0b3I8L2tleT4KCQk8c3RyaW5nPmNvbS5hcHBsZS5qb2J0aWNrZXQ8L3N0cmluZz4KCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuaXRlbUFycmF5PC9rZXk+CgkJPGFycmF5PgoJCQk8ZGljdD4KCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LkRvY3VtZW50VGlja2V0LlBNU3Bvb2xGb3JtYXQ8L2tleT4KCQkJCTxzdHJpbmc+YXBwbGljYXRpb24vcGRmPC9zdHJpbmc+CgkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuc3RhdGVGbGFnPC9rZXk+CgkJCQk8aW50ZWdlcj4wPC9pbnRlZ2VyPgoJCQk8L2RpY3Q+CgkJPC9hcnJheT4KCTwvZGljdD4KCTxrZXk+Y29tLmFwcGxlLnByaW50LlByaW50U2V0dGluZ3MuUE1Db3BpZXM8L2tleT4KCTxkaWN0PgoJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5jcmVhdG9yPC9rZXk+CgkJPHN0cmluZz5jb20uYXBwbGUuam9idGlja2V0PC9zdHJpbmc+CgkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0Lml0ZW1BcnJheTwva2V5PgoJCTxhcnJheT4KCQkJPGRpY3Q+CgkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC5QcmludFNldHRpbmdzLlBNQ29waWVzPC9rZXk+CgkJCQk8aW50ZWdlcj4xPC9pbnRlZ2VyPgoJCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LnN0YXRlRmxhZzwva2V5PgoJCQkJPGludGVnZXI+MDwvaW50ZWdlcj4KCQkJPC9kaWN0PgoJCTwvYXJyYXk+Cgk8L2RpY3Q+Cgk8a2V5PmNvbS5hcHBsZS5wcmludC5QcmludFNldHRpbmdzLlBNQ29weUNvbGxhdGU8L2tleT4KCTxkaWN0PgoJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5jcmVhdG9yPC9rZXk+CgkJPHN0cmluZz5jb20uYXBwbGUuam9idGlja2V0PC9zdHJpbmc+CgkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0Lml0ZW1BcnJheTwva2V5PgoJCTxhcnJheT4KCQkJPGRpY3Q+CgkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC5QcmludFNldHRpbmdzLlBNQ29weUNvbGxhdGU8L2tleT4KCQkJCTx0cnVlLz4KCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5zdGF0ZUZsYWc8L2tleT4KCQkJCTxpbnRlZ2VyPjA8L2ludGVnZXI+CgkJCTwvZGljdD4KCQk8L2FycmF5PgoJPC9kaWN0PgoJPGtleT5jb20uYXBwbGUucHJpbnQuUHJpbnRTZXR0aW5ncy5QTUZpcnN0UGFnZTwva2V5PgoJPGRpY3Q+CgkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LmNyZWF0b3I8L2tleT4KCQk8c3RyaW5nPmNvbS5hcHBsZS5qb2J0aWNrZXQ8L3N0cmluZz4KCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuaXRlbUFycmF5PC9rZXk+CgkJPGFycmF5PgoJCQk8ZGljdD4KCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LlByaW50U2V0dGluZ3MuUE1GaXJzdFBhZ2U8L2tleT4KCQkJCTxpbnRlZ2VyPjE8L2ludGVnZXI+CgkJCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuc3RhdGVGbGFnPC9rZXk+CgkJCQk8aW50ZWdlcj4wPC9pbnRlZ2VyPgoJCQk8L2RpY3Q+CgkJPC9hcnJheT4KCTwvZGljdD4KCTxrZXk+Y29tLmFwcGxlLnByaW50LlByaW50U2V0dGluZ3MuUE1MYXN0UGFnZTwva2V5PgoJPGRpY3Q+CgkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LmNyZWF0b3I8L2tleT4KCQk8c3RyaW5nPmNvbS5hcHBsZS5qb2J0aWNrZXQ8L3N0cmluZz4KCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuaXRlbUFycmF5PC9rZXk+CgkJPGFycmF5PgoJCQk8ZGljdD4KCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LlByaW50U2V0dGluZ3MuUE1MYXN0UGFnZTwva2V5PgoJCQkJPGludGVnZXI+MjE0NzQ4MzY0NzwvaW50ZWdlcj4KCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LnRpY2tldC5zdGF0ZUZsYWc8L2tleT4KCQkJCTxpbnRlZ2VyPjA8L2ludGVnZXI+CgkJCTwvZGljdD4KCQk8L2FycmF5PgoJPC9kaWN0PgoJPGtleT5jb20uYXBwbGUucHJpbnQuUHJpbnRTZXR0aW5ncy5QTVBhZ2VSYW5nZTwva2V5PgoJPGRpY3Q+CgkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LmNyZWF0b3I8L2tleT4KCQk8c3RyaW5nPmNvbS5hcHBsZS5qb2J0aWNrZXQ8L3N0cmluZz4KCQk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuaXRlbUFycmF5PC9rZXk+CgkJPGFycmF5PgoJCQk8ZGljdD4KCQkJCTxrZXk+Y29tLmFwcGxlLnByaW50LlByaW50U2V0dGluZ3MuUE1QYWdlUmFuZ2U8L2tleT4KCQkJCTxhcnJheT4KCQkJCQk8aW50ZWdlcj4xPC9pbnRlZ2VyPgoJCQkJCTxpbnRlZ2VyPjIxNDc0ODM2NDc8L2ludGVnZXI+CgkJCQk8L2FycmF5PgoJCQkJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LnN0YXRlRmxhZzwva2V5PgoJCQkJPGludGVnZXI+MDwvaW50ZWdlcj4KCQkJPC9kaWN0PgoJCTwvYXJyYXk+Cgk8L2RpY3Q+Cgk8a2V5PmNvbS5hcHBsZS5wcmludC50aWNrZXQuQVBJVmVyc2lvbjwva2V5PgoJPHN0cmluZz4wMC4yMDwvc3RyaW5nPgoJPGtleT5jb20uYXBwbGUucHJpbnQudGlja2V0LnR5cGU8L2tleT4KCTxzdHJpbmc+Y29tLmFwcGxlLnByaW50LlByaW50U2V0dGluZ3NUaWNrZXQ8L3N0cmluZz4KPC9kaWN0Pgo8L3BsaXN0Pgo=";

        private string thumbnailPart1Data = "/9j/4AAQSkZJRgABAQEASABIAAD/4ge4SUNDX1BST0ZJTEUAAQEAAAeoYXBwbAIgAABtbnRyUkdCIFhZWiAH2QACABkACwAaAAthY3NwQVBQTAAAAABhcHBsAAAAAAAAAAAAAAAAAAAAAAAA9tYAAQAAAADTLWFwcGwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAtkZXNjAAABCAAAAG9kc2NtAAABeAAABWxjcHJ0AAAG5AAAADh3dHB0AAAHHAAAABRyWFlaAAAHMAAAABRnWFlaAAAHRAAAABRiWFlaAAAHWAAAABRyVFJDAAAHbAAAAA5jaGFkAAAHfAAAACxiVFJDAAAHbAAAAA5nVFJDAAAHbAAAAA5kZXNjAAAAAAAAABRHZW5lcmljIFJHQiBQcm9maWxlAAAAAAAAAAAAAAAUR2VuZXJpYyBSR0IgUHJvZmlsZQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAbWx1YwAAAAAAAAAeAAAADHNrU0sAAAAoAAABeGhySFIAAAAoAAABoGNhRVMAAAAkAAAByHB0QlIAAAAmAAAB7HVrVUEAAAAqAAACEmZyRlUAAAAoAAACPHpoVFcAAAAWAAACZGl0SVQAAAAoAAACem5iTk8AAAAmAAAComtvS1IAAAAWAAACyGNzQ1oAAAAiAAAC3mhlSUwAAAAeAAADAGRlREUAAAAsAAADHmh1SFUAAAAoAAADSnN2U0UAAAAmAAAConpoQ04AAAAWAAADcmphSlAAAAAaAAADiHJvUk8AAAAkAAADomVsR1IAAAAiAAADxnB0UE8AAAAmAAAD6G5sTkwAAAAoAAAEDmVzRVMAAAAmAAAD6HRoVEgAAAAkAAAENnRyVFIAAAAiAAAEWmZpRkkAAAAoAAAEfHBsUEwAAAAsAAAEpHJ1UlUAAAAiAAAE0GFyRUcAAAAmAAAE8mVuVVMAAAAmAAAFGGRhREsAAAAuAAAFPgBWAWEAZQBvAGIAZQBjAG4A/QAgAFIARwBCACAAcAByAG8AZgBpAGwARwBlAG4AZQByAGkBDQBrAGkAIABSAEcAQgAgAHAAcgBvAGYAaQBsAFAAZQByAGYAaQBsACAAUgBHAEIAIABnAGUAbgDoAHIAaQBjAFAAZQByAGYAaQBsACAAUgBHAEIAIABHAGUAbgDpAHIAaQBjAG8EFwQwBDMEMAQ7BEwEPQQ4BDkAIAQ/BEAEPgREBDAEOQQ7ACAAUgBHAEIAUAByAG8AZgBpAGwAIABnAOkAbgDpAHIAaQBxAHUAZQAgAFIAVgBCkBp1KAAgAFIARwBCACCCcl9pY8+P8ABQAHIAbwBmAGkAbABvACAAUgBHAEIAIABnAGUAbgBlAHIAaQBjAG8ARwBlAG4AZQByAGkAcwBrACAAUgBHAEIALQBwAHIAbwBmAGkAbMd8vBgAIABSAEcAQgAg1QS4XNMMx3wATwBiAGUAYwBuAP0AIABSAEcAQgAgAHAAcgBvAGYAaQBsBeQF6AXVBeQF2QXcACAAUgBHAEIAIAXbBdwF3AXZAEEAbABsAGcAZQBtAGUAaQBuAGUAcwAgAFIARwBCAC0AUAByAG8AZgBpAGwAwQBsAHQAYQBsAOEAbgBvAHMAIABSAEcAQgAgAHAAcgBvAGYAaQBsZm6QGgAgAFIARwBCACBjz4/wZYdO9k4AgiwAIABSAEcAQgAgMNcw7TDVMKEwpDDrAFAAcgBvAGYAaQBsACAAUgBHAEIAIABnAGUAbgBlAHIAaQBjA5MDtQO9A7kDugPMACADwAPBA78DxgOvA7sAIABSAEcAQgBQAGUAcgBmAGkAbAAgAFIARwBCACAAZwBlAG4A6QByAGkAYwBvAEEAbABnAGUAbQBlAGUAbgAgAFIARwBCAC0AcAByAG8AZgBpAGUAbA5CDhsOIw5EDh8OJQ5MACAAUgBHAEIAIA4XDjEOSA4nDkQOGwBHAGUAbgBlAGwAIABSAEcAQgAgAFAAcgBvAGYAaQBsAGkAWQBsAGUAaQBuAGUAbgAgAFIARwBCAC0AcAByAG8AZgBpAGkAbABpAFUAbgBpAHcAZQByAHMAYQBsAG4AeQAgAHAAcgBvAGYAaQBsACAAUgBHAEIEHgQxBEkEOAQ5ACAEPwRABD4ERAQ4BDsETAAgAFIARwBCBkUGRAZBACAGKgY5BjEGSgZBACAAUgBHAEIAIAYnBkQGOQYnBkUARwBlAG4AZQByAGkAYwAgAFIARwBCACAAUAByAG8AZgBpAGwAZQBHAGUAbgBlAHIAZQBsACAAUgBHAEIALQBiAGUAcwBrAHIAaQB2AGUAbABz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I/L7wdfXp91/y0G/2pjBLAg9h/jv/wA459zklcXtvNfcxv8AawHJbp3yOvP+0f8APPej2b8vx/yD261vJfc/XXX5iHVV9QT345/H5u3/ANbNHs35ff8A8Aft7bS791tv177h/a6AHLDjofQ/99d/zo9nLy+//gC9utXza9d+vd8239ajDrC8/OvXv37Z69vx70/ZS306de+wfWEuvp066/a7/l3KkutoAcP17D/I6898Z9KpUW9/6+f49zKWJXf1vpfrv3et9ShLro5GTjnnPrnIxuPHbHBq1Qe9m/LX9F/VzKWLj/N31vzPs938tvxM99aPILLx0yd35c9/p6/hqqPVLv2X9fqYyxfn93z7W/q76mZPrgHPm+vTpjnr3GeP6DOatUb76v53/D/gmE8X9/8AWr3d38jDu9eVVIL9dw6nP+PPPHBzx3reNHtH7+/ov60OSpi31l3/AK6u2vVo4jVvGVtbbk8zzZskCNW4U5z87cjAOPlGW6g7Sd1ddPCylq721v0/pvffz16+bXzCnTvG/NLstturTb/HfQ8e1/4gFWffL50gJ2xIW8qLn+Mg4znqv3zjDODyfVoYHqlyrq38T72/zsr9mfOYvN9XeXPJbR+zG/ezs3829Hd6a/OGmePFikBWW4t3z1DZHbPzLtbB7/IQfevdqYS6aajJeen+f47Hx1HNOV3UpQd0rp3Xq7NPproep6P8R42Cq80UvT5lcRSHB/uPhTjggBATj7x5NedVwFr2ur62fvRt6/g/e7M9zD50mlzSjPpdNqXrby/w38+/pmneNLWYLsuQjMANkrBGwfQsdhJ7Yckjr3rz6mEkrtwdtdY63t3X47b+p7dHM6crWnZ9m7b9um/zs35nY2vifKj9526nIzz1ByR64HeuWeH1a036/fp99ttPmelTx17av+n+f59XqzetvEykDMnB9yOeB/eOCTWEsO+z36a6d7efp8zphjV36+nX+u+u5tw6+hxiQn1+YHj8y2PoPf3rJ0Wr67d/+HW/9anSsSn17dn+P5t/f1NBNePH7wZHXdj8cnOOee/0qHRfZW9GjaOJd9JpPzfz7lldebON68/7YHPOTj6jGDnnrnIqXR6uK8t/v1777mixUv5k/mvnurk411snkdORkj8x/k1Psf7vptp6FLFT7p/Na9dUuxJ/brH+Ig8/xHB59xx0J9emOvC9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";

        private System.IO.Stream GetBinaryDataStream(string base64String)
        {
            return new System.IO.MemoryStream(System.Convert.FromBase64String(base64String));
        }

        #endregion

    }
}
