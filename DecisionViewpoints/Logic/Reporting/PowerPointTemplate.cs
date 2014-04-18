using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml;
using A = DocumentFormat.OpenXml.Drawing;
using A14 = DocumentFormat.OpenXml.Office2010.Drawing;
using P14 = DocumentFormat.OpenXml.Office2010.PowerPoint;
using Ap = DocumentFormat.OpenXml.ExtendedProperties;
using Vt = DocumentFormat.OpenXml.VariantTypes;

namespace DecisionViewpoints.Logic.Reporting
{
    public class PowerPointTemplate
    {
        // Adds child parts and generates content of the specified part.
        public void CreateParts(PresentationDocument document)
        {
            ThumbnailPart thumbnailPart1 = document.AddNewPart<ThumbnailPart>("image/jpeg", "rId2");
            GenerateThumbnailPart1Content(thumbnailPart1);

            PresentationPart presentationPart1 = document.AddPresentationPart();
            GeneratePresentationPart1Content(presentationPart1);

            TableStylesPart tableStylesPart1 = presentationPart1.AddNewPart<TableStylesPart>("rId8");
            GenerateTableStylesPart1Content(tableStylesPart1);

            SlidePart slidePart1 = presentationPart1.AddNewPart<SlidePart>("rId3");
            GenerateSlidePart1Content(slidePart1);

            ImagePart imagePart1 = slidePart1.AddNewPart<ImagePart>("image/png", "rId2");
            GenerateImagePart1Content(imagePart1);

            SlideLayoutPart slideLayoutPart1 = slidePart1.AddNewPart<SlideLayoutPart>("rId1");
            GenerateSlideLayoutPart1Content(slideLayoutPart1);

            SlideMasterPart slideMasterPart1 = slideLayoutPart1.AddNewPart<SlideMasterPart>("rId1");
            GenerateSlideMasterPart1Content(slideMasterPart1);

            SlideLayoutPart slideLayoutPart2 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId8");
            GenerateSlideLayoutPart2Content(slideLayoutPart2);

            slideLayoutPart2.AddPart(slideMasterPart1, "rId1");

            SlideLayoutPart slideLayoutPart3 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId3");
            GenerateSlideLayoutPart3Content(slideLayoutPart3);

            slideLayoutPart3.AddPart(slideMasterPart1, "rId1");

            SlideLayoutPart slideLayoutPart4 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId7");
            GenerateSlideLayoutPart4Content(slideLayoutPart4);

            slideLayoutPart4.AddPart(slideMasterPart1, "rId1");

            ThemePart themePart1 = slideMasterPart1.AddNewPart<ThemePart>("rId12");
            GenerateThemePart1Content(themePart1);

            slideMasterPart1.AddPart(slideLayoutPart1, "rId2");

            SlideLayoutPart slideLayoutPart5 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId1");
            GenerateSlideLayoutPart5Content(slideLayoutPart5);

            slideLayoutPart5.AddPart(slideMasterPart1, "rId1");

            SlideLayoutPart slideLayoutPart6 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId6");
            GenerateSlideLayoutPart6Content(slideLayoutPart6);

            slideLayoutPart6.AddPart(slideMasterPart1, "rId1");

            SlideLayoutPart slideLayoutPart7 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId11");
            GenerateSlideLayoutPart7Content(slideLayoutPart7);

            slideLayoutPart7.AddPart(slideMasterPart1, "rId1");

            SlideLayoutPart slideLayoutPart8 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId5");
            GenerateSlideLayoutPart8Content(slideLayoutPart8);

            slideLayoutPart8.AddPart(slideMasterPart1, "rId1");

            SlideLayoutPart slideLayoutPart9 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId10");
            GenerateSlideLayoutPart9Content(slideLayoutPart9);

            slideLayoutPart9.AddPart(slideMasterPart1, "rId1");

            SlideLayoutPart slideLayoutPart10 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId4");
            GenerateSlideLayoutPart10Content(slideLayoutPart10);

            slideLayoutPart10.AddPart(slideMasterPart1, "rId1");

            SlideLayoutPart slideLayoutPart11 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId9");
            GenerateSlideLayoutPart11Content(slideLayoutPart11);

            slideLayoutPart11.AddPart(slideMasterPart1, "rId1");

            presentationPart1.AddPart(themePart1, "rId7");

            SlidePart slidePart2 = presentationPart1.AddNewPart<SlidePart>("rId2");
            GenerateSlidePart2Content(slidePart2);

            slidePart2.AddPart(slideLayoutPart5, "rId1");

            presentationPart1.AddPart(slideMasterPart1, "rId1");

            ViewPropertiesPart viewPropertiesPart1 = presentationPart1.AddNewPart<ViewPropertiesPart>("rId6");
            GenerateViewPropertiesPart1Content(viewPropertiesPart1);

            PresentationPropertiesPart presentationPropertiesPart1 = presentationPart1.AddNewPart<PresentationPropertiesPart>("rId5");
            GeneratePresentationPropertiesPart1Content(presentationPropertiesPart1);

            SlidePart slidePart3 = presentationPart1.AddNewPart<SlidePart>("rId4");
            GenerateSlidePart3Content(slidePart3);

            slidePart3.AddPart(slideLayoutPart1, "rId1");

            ExtendedFilePropertiesPart extendedFilePropertiesPart1 = document.AddNewPart<ExtendedFilePropertiesPart>("rId4");
            GenerateExtendedFilePropertiesPart1Content(extendedFilePropertiesPart1);

            SetPackageProperties(document);
        }

        // Generates content of thumbnailPart1.
        private void GenerateThumbnailPart1Content(ThumbnailPart thumbnailPart1)
        {
            System.IO.Stream data = GetBinaryDataStream(thumbnailPart1Data);
            thumbnailPart1.FeedData(data);
            data.Close();
        }

        // Generates content of presentationPart1.
        private void GeneratePresentationPart1Content(PresentationPart presentationPart1)
        {
            Presentation presentation1 = new Presentation() { SaveSubsetFonts = true };
            presentation1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            presentation1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            presentation1.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            SlideMasterIdList slideMasterIdList1 = new SlideMasterIdList();
            SlideMasterId slideMasterId1 = new SlideMasterId() { Id = (UInt32Value)2147483648U, RelationshipId = "rId1" };

            slideMasterIdList1.Append(slideMasterId1);

            SlideIdList slideIdList1 = new SlideIdList();
            SlideId slideId1 = new SlideId() { Id = (UInt32Value)256U, RelationshipId = "rId2" };
            SlideId slideId2 = new SlideId() { Id = (UInt32Value)258U, RelationshipId = "rId3" };
            SlideId slideId3 = new SlideId() { Id = (UInt32Value)259U, RelationshipId = "rId4" };

            slideIdList1.Append(slideId1);
            slideIdList1.Append(slideId2);
            slideIdList1.Append(slideId3);
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

        // Generates content of tableStylesPart1.
        private void GenerateTableStylesPart1Content(TableStylesPart tableStylesPart1)
        {
            A.TableStyleList tableStyleList1 = new A.TableStyleList() { Default = "{5C22544A-7EE6-4342-B048-85BDC9FD1C3A}" };
            tableStyleList1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            A.TableStyleEntry tableStyleEntry1 = new A.TableStyleEntry() { StyleId = "{5C22544A-7EE6-4342-B048-85BDC9FD1C3A}", StyleName = "Medium Style 2 - Accent 1" };

            A.WholeTable wholeTable1 = new A.WholeTable();

            A.TableCellTextStyle tableCellTextStyle1 = new A.TableCellTextStyle();

            A.FontReference fontReference1 = new A.FontReference() { Index = A.FontCollectionIndexValues.Minor };
            A.PresetColor presetColor1 = new A.PresetColor() { Val = A.PresetColorValues.Black };

            fontReference1.Append(presetColor1);
            A.SchemeColor schemeColor10 = new A.SchemeColor() { Val = A.SchemeColorValues.Dark1 };

            tableCellTextStyle1.Append(fontReference1);
            tableCellTextStyle1.Append(schemeColor10);

            A.TableCellStyle tableCellStyle1 = new A.TableCellStyle();

            A.TableCellBorders tableCellBorders1 = new A.TableCellBorders();

            A.LeftBorder leftBorder1 = new A.LeftBorder();

            A.Outline outline1 = new A.Outline() { Width = 12700, CompoundLineType = A.CompoundLineValues.Single };

            A.SolidFill solidFill10 = new A.SolidFill();
            A.SchemeColor schemeColor11 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            solidFill10.Append(schemeColor11);

            outline1.Append(solidFill10);

            leftBorder1.Append(outline1);

            A.RightBorder rightBorder1 = new A.RightBorder();

            A.Outline outline2 = new A.Outline() { Width = 12700, CompoundLineType = A.CompoundLineValues.Single };

            A.SolidFill solidFill11 = new A.SolidFill();
            A.SchemeColor schemeColor12 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            solidFill11.Append(schemeColor12);

            outline2.Append(solidFill11);

            rightBorder1.Append(outline2);

            A.TopBorder topBorder1 = new A.TopBorder();

            A.Outline outline3 = new A.Outline() { Width = 12700, CompoundLineType = A.CompoundLineValues.Single };

            A.SolidFill solidFill12 = new A.SolidFill();
            A.SchemeColor schemeColor13 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            solidFill12.Append(schemeColor13);

            outline3.Append(solidFill12);

            topBorder1.Append(outline3);

            A.BottomBorder bottomBorder1 = new A.BottomBorder();

            A.Outline outline4 = new A.Outline() { Width = 12700, CompoundLineType = A.CompoundLineValues.Single };

            A.SolidFill solidFill13 = new A.SolidFill();
            A.SchemeColor schemeColor14 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            solidFill13.Append(schemeColor14);

            outline4.Append(solidFill13);

            bottomBorder1.Append(outline4);

            A.InsideHorizontalBorder insideHorizontalBorder1 = new A.InsideHorizontalBorder();

            A.Outline outline5 = new A.Outline() { Width = 12700, CompoundLineType = A.CompoundLineValues.Single };

            A.SolidFill solidFill14 = new A.SolidFill();
            A.SchemeColor schemeColor15 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            solidFill14.Append(schemeColor15);

            outline5.Append(solidFill14);

            insideHorizontalBorder1.Append(outline5);

            A.InsideVerticalBorder insideVerticalBorder1 = new A.InsideVerticalBorder();

            A.Outline outline6 = new A.Outline() { Width = 12700, CompoundLineType = A.CompoundLineValues.Single };

            A.SolidFill solidFill15 = new A.SolidFill();
            A.SchemeColor schemeColor16 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            solidFill15.Append(schemeColor16);

            outline6.Append(solidFill15);

            insideVerticalBorder1.Append(outline6);

            tableCellBorders1.Append(leftBorder1);
            tableCellBorders1.Append(rightBorder1);
            tableCellBorders1.Append(topBorder1);
            tableCellBorders1.Append(bottomBorder1);
            tableCellBorders1.Append(insideHorizontalBorder1);
            tableCellBorders1.Append(insideVerticalBorder1);

            A.FillProperties fillProperties1 = new A.FillProperties();

            A.SolidFill solidFill16 = new A.SolidFill();

            A.SchemeColor schemeColor17 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };
            A.Tint tint1 = new A.Tint() { Val = 20000 };

            schemeColor17.Append(tint1);

            solidFill16.Append(schemeColor17);

            fillProperties1.Append(solidFill16);

            tableCellStyle1.Append(tableCellBorders1);
            tableCellStyle1.Append(fillProperties1);

            wholeTable1.Append(tableCellTextStyle1);
            wholeTable1.Append(tableCellStyle1);

            A.Band1Horizontal band1Horizontal1 = new A.Band1Horizontal();

            A.TableCellStyle tableCellStyle2 = new A.TableCellStyle();
            A.TableCellBorders tableCellBorders2 = new A.TableCellBorders();

            A.FillProperties fillProperties2 = new A.FillProperties();

            A.SolidFill solidFill17 = new A.SolidFill();

            A.SchemeColor schemeColor18 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };
            A.Tint tint2 = new A.Tint() { Val = 40000 };

            schemeColor18.Append(tint2);

            solidFill17.Append(schemeColor18);

            fillProperties2.Append(solidFill17);

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

            A.SolidFill solidFill18 = new A.SolidFill();

            A.SchemeColor schemeColor19 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };
            A.Tint tint3 = new A.Tint() { Val = 40000 };

            schemeColor19.Append(tint3);

            solidFill18.Append(schemeColor19);

            fillProperties3.Append(solidFill18);

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

            A.FontReference fontReference2 = new A.FontReference() { Index = A.FontCollectionIndexValues.Minor };
            A.PresetColor presetColor2 = new A.PresetColor() { Val = A.PresetColorValues.Black };

            fontReference2.Append(presetColor2);
            A.SchemeColor schemeColor20 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            tableCellTextStyle2.Append(fontReference2);
            tableCellTextStyle2.Append(schemeColor20);

            A.TableCellStyle tableCellStyle6 = new A.TableCellStyle();
            A.TableCellBorders tableCellBorders6 = new A.TableCellBorders();

            A.FillProperties fillProperties4 = new A.FillProperties();

            A.SolidFill solidFill19 = new A.SolidFill();
            A.SchemeColor schemeColor21 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            solidFill19.Append(schemeColor21);

            fillProperties4.Append(solidFill19);

            tableCellStyle6.Append(tableCellBorders6);
            tableCellStyle6.Append(fillProperties4);

            lastColumn1.Append(tableCellTextStyle2);
            lastColumn1.Append(tableCellStyle6);

            A.FirstColumn firstColumn1 = new A.FirstColumn();

            A.TableCellTextStyle tableCellTextStyle3 = new A.TableCellTextStyle() { Bold = A.BooleanStyleValues.On };

            A.FontReference fontReference3 = new A.FontReference() { Index = A.FontCollectionIndexValues.Minor };
            A.PresetColor presetColor3 = new A.PresetColor() { Val = A.PresetColorValues.Black };

            fontReference3.Append(presetColor3);
            A.SchemeColor schemeColor22 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            tableCellTextStyle3.Append(fontReference3);
            tableCellTextStyle3.Append(schemeColor22);

            A.TableCellStyle tableCellStyle7 = new A.TableCellStyle();
            A.TableCellBorders tableCellBorders7 = new A.TableCellBorders();

            A.FillProperties fillProperties5 = new A.FillProperties();

            A.SolidFill solidFill20 = new A.SolidFill();
            A.SchemeColor schemeColor23 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            solidFill20.Append(schemeColor23);

            fillProperties5.Append(solidFill20);

            tableCellStyle7.Append(tableCellBorders7);
            tableCellStyle7.Append(fillProperties5);

            firstColumn1.Append(tableCellTextStyle3);
            firstColumn1.Append(tableCellStyle7);

            A.LastRow lastRow1 = new A.LastRow();

            A.TableCellTextStyle tableCellTextStyle4 = new A.TableCellTextStyle() { Bold = A.BooleanStyleValues.On };

            A.FontReference fontReference4 = new A.FontReference() { Index = A.FontCollectionIndexValues.Minor };
            A.PresetColor presetColor4 = new A.PresetColor() { Val = A.PresetColorValues.Black };

            fontReference4.Append(presetColor4);
            A.SchemeColor schemeColor24 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            tableCellTextStyle4.Append(fontReference4);
            tableCellTextStyle4.Append(schemeColor24);

            A.TableCellStyle tableCellStyle8 = new A.TableCellStyle();

            A.TableCellBorders tableCellBorders8 = new A.TableCellBorders();

            A.TopBorder topBorder2 = new A.TopBorder();

            A.Outline outline7 = new A.Outline() { Width = 38100, CompoundLineType = A.CompoundLineValues.Single };

            A.SolidFill solidFill21 = new A.SolidFill();
            A.SchemeColor schemeColor25 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            solidFill21.Append(schemeColor25);

            outline7.Append(solidFill21);

            topBorder2.Append(outline7);

            tableCellBorders8.Append(topBorder2);

            A.FillProperties fillProperties6 = new A.FillProperties();

            A.SolidFill solidFill22 = new A.SolidFill();
            A.SchemeColor schemeColor26 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            solidFill22.Append(schemeColor26);

            fillProperties6.Append(solidFill22);

            tableCellStyle8.Append(tableCellBorders8);
            tableCellStyle8.Append(fillProperties6);

            lastRow1.Append(tableCellTextStyle4);
            lastRow1.Append(tableCellStyle8);

            A.FirstRow firstRow1 = new A.FirstRow();

            A.TableCellTextStyle tableCellTextStyle5 = new A.TableCellTextStyle() { Bold = A.BooleanStyleValues.On };

            A.FontReference fontReference5 = new A.FontReference() { Index = A.FontCollectionIndexValues.Minor };
            A.PresetColor presetColor5 = new A.PresetColor() { Val = A.PresetColorValues.Black };

            fontReference5.Append(presetColor5);
            A.SchemeColor schemeColor27 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            tableCellTextStyle5.Append(fontReference5);
            tableCellTextStyle5.Append(schemeColor27);

            A.TableCellStyle tableCellStyle9 = new A.TableCellStyle();

            A.TableCellBorders tableCellBorders9 = new A.TableCellBorders();

            A.BottomBorder bottomBorder2 = new A.BottomBorder();

            A.Outline outline8 = new A.Outline() { Width = 38100, CompoundLineType = A.CompoundLineValues.Single };

            A.SolidFill solidFill23 = new A.SolidFill();
            A.SchemeColor schemeColor28 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            solidFill23.Append(schemeColor28);

            outline8.Append(solidFill23);

            bottomBorder2.Append(outline8);

            tableCellBorders9.Append(bottomBorder2);

            A.FillProperties fillProperties7 = new A.FillProperties();

            A.SolidFill solidFill24 = new A.SolidFill();
            A.SchemeColor schemeColor29 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            solidFill24.Append(schemeColor29);

            fillProperties7.Append(solidFill24);

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
            NonVisualDrawingProperties nonVisualDrawingProperties2 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties1 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks1 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties1.Append(shapeLocks1);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties2 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape1 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties2.Append(placeholderShape1);

            nonVisualShapeProperties1.Append(nonVisualDrawingProperties2);
            nonVisualShapeProperties1.Append(nonVisualShapeDrawingProperties1);
            nonVisualShapeProperties1.Append(applicationNonVisualDrawingProperties2);
            ShapeProperties shapeProperties1 = new ShapeProperties();

            TextBody textBody1 = new TextBody();
            A.BodyProperties bodyProperties1 = new A.BodyProperties();
            A.ListStyle listStyle1 = new A.ListStyle();

            A.Paragraph paragraph1 = new A.Paragraph();

            A.Run run1 = new A.Run();

            A.RunProperties runProperties1 = new A.RunProperties() { Language = "en-US", Dirty = false };
            runProperties1.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text1 = new A.Text();
            text1.Text = "{title}";

            run1.Append(runProperties1);
            run1.Append(text1);
            A.EndParagraphRunProperties endParagraphRunProperties1 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph1.Append(run1);
            paragraph1.Append(endParagraphRunProperties1);

            textBody1.Append(bodyProperties1);
            textBody1.Append(listStyle1);
            textBody1.Append(paragraph1);

            shape1.Append(nonVisualShapeProperties1);
            shape1.Append(shapeProperties1);
            shape1.Append(textBody1);

            Picture picture1 = new Picture();

            NonVisualPictureProperties nonVisualPictureProperties1 = new NonVisualPictureProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties3 = new NonVisualDrawingProperties() { Id = (UInt32Value)1026U, Name = "Picture 2" };

            NonVisualPictureDrawingProperties nonVisualPictureDrawingProperties1 = new NonVisualPictureDrawingProperties();
            A.PictureLocks pictureLocks1 = new A.PictureLocks() { NoChangeAspect = true, NoChangeArrowheads = true };

            nonVisualPictureDrawingProperties1.Append(pictureLocks1);
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties3 = new ApplicationNonVisualDrawingProperties();

            nonVisualPictureProperties1.Append(nonVisualDrawingProperties3);
            nonVisualPictureProperties1.Append(nonVisualPictureDrawingProperties1);
            nonVisualPictureProperties1.Append(applicationNonVisualDrawingProperties3);

            BlipFill blipFill1 = new BlipFill();

            A.Blip blip1 = new A.Blip() { Embed = "rId2" };

            A.BlipExtensionList blipExtensionList1 = new A.BlipExtensionList();

            A.BlipExtension blipExtension1 = new A.BlipExtension() { Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}" };

            A14.UseLocalDpi useLocalDpi1 = new A14.UseLocalDpi() { Val = false };
            useLocalDpi1.AddNamespaceDeclaration("a14", "http://schemas.microsoft.com/office/drawing/2010/main");

            blipExtension1.Append(useLocalDpi1);

            blipExtensionList1.Append(blipExtension1);

            blip1.Append(blipExtensionList1);
            A.SourceRectangle sourceRectangle1 = new A.SourceRectangle();

            A.Stretch stretch1 = new A.Stretch();
            A.FillRectangle fillRectangle1 = new A.FillRectangle();

            stretch1.Append(fillRectangle1);

            blipFill1.Append(blip1);
            blipFill1.Append(sourceRectangle1);
            blipFill1.Append(stretch1);

            ShapeProperties shapeProperties2 = new ShapeProperties() { BlackWhiteMode = A.BlackWhiteModeValues.Auto };

            A.Transform2D transform2D1 = new A.Transform2D();
            A.Offset offset2 = new A.Offset() { X = 1295400L, Y = 1447800L };
            A.Extents extents2 = new A.Extents() { Cx = 6553200L, Cy = 4932783L };

            transform2D1.Append(offset2);
            transform2D1.Append(extents2);

            A.PresetGeometry presetGeometry1 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList1 = new A.AdjustValueList();

            presetGeometry1.Append(adjustValueList1);
            A.NoFill noFill1 = new A.NoFill();

            A.Outline outline9 = new A.Outline();
            A.NoFill noFill2 = new A.NoFill();

            outline9.Append(noFill2);

            A.ShapePropertiesExtensionList shapePropertiesExtensionList1 = new A.ShapePropertiesExtensionList();

            A.ShapePropertiesExtension shapePropertiesExtension1 = new A.ShapePropertiesExtension() { Uri = "{909E8E84-426E-40DD-AFC4-6F175D3DCCD1}" };

            A14.HiddenFillProperties hiddenFillProperties1 = new A14.HiddenFillProperties();
            hiddenFillProperties1.AddNamespaceDeclaration("a14", "http://schemas.microsoft.com/office/drawing/2010/main");

            A.SolidFill solidFill25 = new A.SolidFill();
            A.SchemeColor schemeColor30 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            solidFill25.Append(schemeColor30);

            hiddenFillProperties1.Append(solidFill25);

            shapePropertiesExtension1.Append(hiddenFillProperties1);

            A.ShapePropertiesExtension shapePropertiesExtension2 = new A.ShapePropertiesExtension() { Uri = "{91240B29-F687-4F45-9708-019B960494DF}" };

            A14.HiddenLineProperties hiddenLineProperties1 = new A14.HiddenLineProperties() { Width = 9525 };
            hiddenLineProperties1.AddNamespaceDeclaration("a14", "http://schemas.microsoft.com/office/drawing/2010/main");

            A.SolidFill solidFill26 = new A.SolidFill();
            A.SchemeColor schemeColor31 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill26.Append(schemeColor31);
            A.Miter miter1 = new A.Miter() { Limit = 800000 };
            A.HeadEnd headEnd1 = new A.HeadEnd();
            A.TailEnd tailEnd1 = new A.TailEnd();

            hiddenLineProperties1.Append(solidFill26);
            hiddenLineProperties1.Append(miter1);
            hiddenLineProperties1.Append(headEnd1);
            hiddenLineProperties1.Append(tailEnd1);

            shapePropertiesExtension2.Append(hiddenLineProperties1);

            shapePropertiesExtensionList1.Append(shapePropertiesExtension1);
            shapePropertiesExtensionList1.Append(shapePropertiesExtension2);

            shapeProperties2.Append(transform2D1);
            shapeProperties2.Append(presetGeometry1);
            shapeProperties2.Append(noFill1);
            shapeProperties2.Append(outline9);
            shapeProperties2.Append(shapePropertiesExtensionList1);

            picture1.Append(nonVisualPictureProperties1);
            picture1.Append(blipFill1);
            picture1.Append(shapeProperties2);

            shapeTree1.Append(nonVisualGroupShapeProperties1);
            shapeTree1.Append(groupShapeProperties1);
            shapeTree1.Append(shape1);
            shapeTree1.Append(picture1);

            CommonSlideDataExtensionList commonSlideDataExtensionList1 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension1 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId1 = new P14.CreationId() { Val = (UInt32Value)3486677695U };
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

        // Generates content of imagePart1.
        private void GenerateImagePart1Content(ImagePart imagePart1)
        {
            System.IO.Stream data = GetBinaryDataStream(imagePart1Data);
            imagePart1.FeedData(data);
            data.Close();
        }

        // Generates content of slideLayoutPart1.
        private void GenerateSlideLayoutPart1Content(SlideLayoutPart slideLayoutPart1)
        {
            SlideLayout slideLayout1 = new SlideLayout() { Type = SlideLayoutValues.Object, Preserve = true };
            slideLayout1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout1.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData2 = new CommonSlideData() { Name = "Title and Content" };

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
            A.Offset offset3 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents3 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset2 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents2 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup2.Append(offset3);
            transformGroup2.Append(extents3);
            transformGroup2.Append(childOffset2);
            transformGroup2.Append(childExtents2);

            groupShapeProperties2.Append(transformGroup2);

            Shape shape2 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties2 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties5 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties2 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks2 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties2.Append(shapeLocks2);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties5 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape2 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties5.Append(placeholderShape2);

            nonVisualShapeProperties2.Append(nonVisualDrawingProperties5);
            nonVisualShapeProperties2.Append(nonVisualShapeDrawingProperties2);
            nonVisualShapeProperties2.Append(applicationNonVisualDrawingProperties5);
            ShapeProperties shapeProperties3 = new ShapeProperties();

            TextBody textBody2 = new TextBody();
            A.BodyProperties bodyProperties2 = new A.BodyProperties();
            A.ListStyle listStyle2 = new A.ListStyle();

            A.Paragraph paragraph2 = new A.Paragraph();

            A.Run run2 = new A.Run();

            A.RunProperties runProperties2 = new A.RunProperties() { Language = "en-US" };
            runProperties2.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text2 = new A.Text();
            text2.Text = "Click to edit Master title style";

            run2.Append(runProperties2);
            run2.Append(text2);
            A.EndParagraphRunProperties endParagraphRunProperties2 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph2.Append(run2);
            paragraph2.Append(endParagraphRunProperties2);

            textBody2.Append(bodyProperties2);
            textBody2.Append(listStyle2);
            textBody2.Append(paragraph2);

            shape2.Append(nonVisualShapeProperties2);
            shape2.Append(shapeProperties3);
            shape2.Append(textBody2);

            Shape shape3 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties3 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties6 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Content Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties3 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks3 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties3.Append(shapeLocks3);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties6 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape3 = new PlaceholderShape() { Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties6.Append(placeholderShape3);

            nonVisualShapeProperties3.Append(nonVisualDrawingProperties6);
            nonVisualShapeProperties3.Append(nonVisualShapeDrawingProperties3);
            nonVisualShapeProperties3.Append(applicationNonVisualDrawingProperties6);
            ShapeProperties shapeProperties4 = new ShapeProperties();

            TextBody textBody3 = new TextBody();
            A.BodyProperties bodyProperties3 = new A.BodyProperties();
            A.ListStyle listStyle3 = new A.ListStyle();

            A.Paragraph paragraph3 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties1 = new A.ParagraphProperties() { Level = 0 };

            A.Run run3 = new A.Run();

            A.RunProperties runProperties3 = new A.RunProperties() { Language = "en-US" };
            runProperties3.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text3 = new A.Text();
            text3.Text = "Click to edit Master text styles";

            run3.Append(runProperties3);
            run3.Append(text3);

            paragraph3.Append(paragraphProperties1);
            paragraph3.Append(run3);

            A.Paragraph paragraph4 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties2 = new A.ParagraphProperties() { Level = 1 };

            A.Run run4 = new A.Run();

            A.RunProperties runProperties4 = new A.RunProperties() { Language = "en-US" };
            runProperties4.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text4 = new A.Text();
            text4.Text = "Second level";

            run4.Append(runProperties4);
            run4.Append(text4);

            paragraph4.Append(paragraphProperties2);
            paragraph4.Append(run4);

            A.Paragraph paragraph5 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties3 = new A.ParagraphProperties() { Level = 2 };

            A.Run run5 = new A.Run();

            A.RunProperties runProperties5 = new A.RunProperties() { Language = "en-US" };
            runProperties5.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text5 = new A.Text();
            text5.Text = "Third level";

            run5.Append(runProperties5);
            run5.Append(text5);

            paragraph5.Append(paragraphProperties3);
            paragraph5.Append(run5);

            A.Paragraph paragraph6 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties4 = new A.ParagraphProperties() { Level = 3 };

            A.Run run6 = new A.Run();

            A.RunProperties runProperties6 = new A.RunProperties() { Language = "en-US" };
            runProperties6.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text6 = new A.Text();
            text6.Text = "Fourth level";

            run6.Append(runProperties6);
            run6.Append(text6);

            paragraph6.Append(paragraphProperties4);
            paragraph6.Append(run6);

            A.Paragraph paragraph7 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties5 = new A.ParagraphProperties() { Level = 4 };

            A.Run run7 = new A.Run();

            A.RunProperties runProperties7 = new A.RunProperties() { Language = "en-US" };
            runProperties7.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text7 = new A.Text();
            text7.Text = "Fifth level";

            run7.Append(runProperties7);
            run7.Append(text7);
            A.EndParagraphRunProperties endParagraphRunProperties3 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph7.Append(paragraphProperties5);
            paragraph7.Append(run7);
            paragraph7.Append(endParagraphRunProperties3);

            textBody3.Append(bodyProperties3);
            textBody3.Append(listStyle3);
            textBody3.Append(paragraph3);
            textBody3.Append(paragraph4);
            textBody3.Append(paragraph5);
            textBody3.Append(paragraph6);
            textBody3.Append(paragraph7);

            shape3.Append(nonVisualShapeProperties3);
            shape3.Append(shapeProperties4);
            shape3.Append(textBody3);

            Shape shape4 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties4 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties7 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Date Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties4 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks4 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties4.Append(shapeLocks4);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties7 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape4 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties7.Append(placeholderShape4);

            nonVisualShapeProperties4.Append(nonVisualDrawingProperties7);
            nonVisualShapeProperties4.Append(nonVisualShapeDrawingProperties4);
            nonVisualShapeProperties4.Append(applicationNonVisualDrawingProperties7);
            ShapeProperties shapeProperties5 = new ShapeProperties();

            TextBody textBody4 = new TextBody();
            A.BodyProperties bodyProperties4 = new A.BodyProperties();
            A.ListStyle listStyle4 = new A.ListStyle();

            A.Paragraph paragraph8 = new A.Paragraph();

            A.Field field1 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties8 = new A.RunProperties() { Language = "en-US" };
            runProperties8.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text8 = new A.Text();
            text8.Text = "7/28/2013";

            field1.Append(runProperties8);
            field1.Append(text8);
            A.EndParagraphRunProperties endParagraphRunProperties4 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph8.Append(field1);
            paragraph8.Append(endParagraphRunProperties4);

            textBody4.Append(bodyProperties4);
            textBody4.Append(listStyle4);
            textBody4.Append(paragraph8);

            shape4.Append(nonVisualShapeProperties4);
            shape4.Append(shapeProperties5);
            shape4.Append(textBody4);

            Shape shape5 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties5 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties8 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Footer Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties5 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks5 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties5.Append(shapeLocks5);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties8 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape5 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties8.Append(placeholderShape5);

            nonVisualShapeProperties5.Append(nonVisualDrawingProperties8);
            nonVisualShapeProperties5.Append(nonVisualShapeDrawingProperties5);
            nonVisualShapeProperties5.Append(applicationNonVisualDrawingProperties8);
            ShapeProperties shapeProperties6 = new ShapeProperties();

            TextBody textBody5 = new TextBody();
            A.BodyProperties bodyProperties5 = new A.BodyProperties();
            A.ListStyle listStyle5 = new A.ListStyle();

            A.Paragraph paragraph9 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties5 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph9.Append(endParagraphRunProperties5);

            textBody5.Append(bodyProperties5);
            textBody5.Append(listStyle5);
            textBody5.Append(paragraph9);

            shape5.Append(nonVisualShapeProperties5);
            shape5.Append(shapeProperties6);
            shape5.Append(textBody5);

            Shape shape6 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties6 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties9 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Slide Number Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties6 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks6 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties6.Append(shapeLocks6);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties9 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape6 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties9.Append(placeholderShape6);

            nonVisualShapeProperties6.Append(nonVisualDrawingProperties9);
            nonVisualShapeProperties6.Append(nonVisualShapeDrawingProperties6);
            nonVisualShapeProperties6.Append(applicationNonVisualDrawingProperties9);
            ShapeProperties shapeProperties7 = new ShapeProperties();

            TextBody textBody6 = new TextBody();
            A.BodyProperties bodyProperties6 = new A.BodyProperties();
            A.ListStyle listStyle6 = new A.ListStyle();

            A.Paragraph paragraph10 = new A.Paragraph();

            A.Field field2 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties9 = new A.RunProperties() { Language = "en-US" };
            runProperties9.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text9 = new A.Text();
            text9.Text = "‹#›";

            field2.Append(runProperties9);
            field2.Append(text9);
            A.EndParagraphRunProperties endParagraphRunProperties6 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph10.Append(field2);
            paragraph10.Append(endParagraphRunProperties6);

            textBody6.Append(bodyProperties6);
            textBody6.Append(listStyle6);
            textBody6.Append(paragraph10);

            shape6.Append(nonVisualShapeProperties6);
            shape6.Append(shapeProperties7);
            shape6.Append(textBody6);

            shapeTree2.Append(nonVisualGroupShapeProperties2);
            shapeTree2.Append(groupShapeProperties2);
            shapeTree2.Append(shape2);
            shapeTree2.Append(shape3);
            shapeTree2.Append(shape4);
            shapeTree2.Append(shape5);
            shapeTree2.Append(shape6);

            CommonSlideDataExtensionList commonSlideDataExtensionList2 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension2 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId2 = new P14.CreationId() { Val = (UInt32Value)3391662222U };
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

            BackgroundStyleReference backgroundStyleReference1 = new BackgroundStyleReference() { Index = (UInt32Value)1001U };
            A.SchemeColor schemeColor32 = new A.SchemeColor() { Val = A.SchemeColorValues.Background1 };

            backgroundStyleReference1.Append(schemeColor32);

            background1.Append(backgroundStyleReference1);

            ShapeTree shapeTree3 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties3 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties10 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties3 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties10 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties3.Append(nonVisualDrawingProperties10);
            nonVisualGroupShapeProperties3.Append(nonVisualGroupShapeDrawingProperties3);
            nonVisualGroupShapeProperties3.Append(applicationNonVisualDrawingProperties10);

            GroupShapeProperties groupShapeProperties3 = new GroupShapeProperties();

            A.TransformGroup transformGroup3 = new A.TransformGroup();
            A.Offset offset4 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents4 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset3 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents3 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup3.Append(offset4);
            transformGroup3.Append(extents4);
            transformGroup3.Append(childOffset3);
            transformGroup3.Append(childExtents3);

            groupShapeProperties3.Append(transformGroup3);

            Shape shape7 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties7 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties11 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title Placeholder 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties7 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks7 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties7.Append(shapeLocks7);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties11 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape7 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties11.Append(placeholderShape7);

            nonVisualShapeProperties7.Append(nonVisualDrawingProperties11);
            nonVisualShapeProperties7.Append(nonVisualShapeDrawingProperties7);
            nonVisualShapeProperties7.Append(applicationNonVisualDrawingProperties11);

            ShapeProperties shapeProperties8 = new ShapeProperties();

            A.Transform2D transform2D2 = new A.Transform2D();
            A.Offset offset5 = new A.Offset() { X = 457200L, Y = 274638L };
            A.Extents extents5 = new A.Extents() { Cx = 8229600L, Cy = 1143000L };

            transform2D2.Append(offset5);
            transform2D2.Append(extents5);

            A.PresetGeometry presetGeometry2 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList2 = new A.AdjustValueList();

            presetGeometry2.Append(adjustValueList2);

            shapeProperties8.Append(transform2D2);
            shapeProperties8.Append(presetGeometry2);

            TextBody textBody7 = new TextBody();

            A.BodyProperties bodyProperties7 = new A.BodyProperties() { Vertical = A.TextVerticalValues.Horizontal, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, RightToLeftColumns = false, Anchor = A.TextAnchoringTypeValues.Center };
            A.NormalAutoFit normalAutoFit1 = new A.NormalAutoFit();

            bodyProperties7.Append(normalAutoFit1);
            A.ListStyle listStyle7 = new A.ListStyle();

            A.Paragraph paragraph11 = new A.Paragraph();

            A.Run run8 = new A.Run();

            A.RunProperties runProperties10 = new A.RunProperties() { Language = "en-US" };
            runProperties10.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text10 = new A.Text();
            text10.Text = "Click to edit Master title style";

            run8.Append(runProperties10);
            run8.Append(text10);
            A.EndParagraphRunProperties endParagraphRunProperties7 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph11.Append(run8);
            paragraph11.Append(endParagraphRunProperties7);

            textBody7.Append(bodyProperties7);
            textBody7.Append(listStyle7);
            textBody7.Append(paragraph11);

            shape7.Append(nonVisualShapeProperties7);
            shape7.Append(shapeProperties8);
            shape7.Append(textBody7);

            Shape shape8 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties8 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties12 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Text Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties8 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks8 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties8.Append(shapeLocks8);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties12 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape8 = new PlaceholderShape() { Type = PlaceholderValues.Body, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties12.Append(placeholderShape8);

            nonVisualShapeProperties8.Append(nonVisualDrawingProperties12);
            nonVisualShapeProperties8.Append(nonVisualShapeDrawingProperties8);
            nonVisualShapeProperties8.Append(applicationNonVisualDrawingProperties12);

            ShapeProperties shapeProperties9 = new ShapeProperties();

            A.Transform2D transform2D3 = new A.Transform2D();
            A.Offset offset6 = new A.Offset() { X = 457200L, Y = 1600200L };
            A.Extents extents6 = new A.Extents() { Cx = 8229600L, Cy = 4525963L };

            transform2D3.Append(offset6);
            transform2D3.Append(extents6);

            A.PresetGeometry presetGeometry3 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList3 = new A.AdjustValueList();

            presetGeometry3.Append(adjustValueList3);

            shapeProperties9.Append(transform2D3);
            shapeProperties9.Append(presetGeometry3);

            TextBody textBody8 = new TextBody();

            A.BodyProperties bodyProperties8 = new A.BodyProperties() { Vertical = A.TextVerticalValues.Horizontal, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, RightToLeftColumns = false };
            A.NormalAutoFit normalAutoFit2 = new A.NormalAutoFit();

            bodyProperties8.Append(normalAutoFit2);
            A.ListStyle listStyle8 = new A.ListStyle();

            A.Paragraph paragraph12 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties6 = new A.ParagraphProperties() { Level = 0 };

            A.Run run9 = new A.Run();

            A.RunProperties runProperties11 = new A.RunProperties() { Language = "en-US" };
            runProperties11.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text11 = new A.Text();
            text11.Text = "Click to edit Master text styles";

            run9.Append(runProperties11);
            run9.Append(text11);

            paragraph12.Append(paragraphProperties6);
            paragraph12.Append(run9);

            A.Paragraph paragraph13 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties7 = new A.ParagraphProperties() { Level = 1 };

            A.Run run10 = new A.Run();

            A.RunProperties runProperties12 = new A.RunProperties() { Language = "en-US" };
            runProperties12.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text12 = new A.Text();
            text12.Text = "Second level";

            run10.Append(runProperties12);
            run10.Append(text12);

            paragraph13.Append(paragraphProperties7);
            paragraph13.Append(run10);

            A.Paragraph paragraph14 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties8 = new A.ParagraphProperties() { Level = 2 };

            A.Run run11 = new A.Run();

            A.RunProperties runProperties13 = new A.RunProperties() { Language = "en-US" };
            runProperties13.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text13 = new A.Text();
            text13.Text = "Third level";

            run11.Append(runProperties13);
            run11.Append(text13);

            paragraph14.Append(paragraphProperties8);
            paragraph14.Append(run11);

            A.Paragraph paragraph15 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties9 = new A.ParagraphProperties() { Level = 3 };

            A.Run run12 = new A.Run();

            A.RunProperties runProperties14 = new A.RunProperties() { Language = "en-US" };
            runProperties14.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text14 = new A.Text();
            text14.Text = "Fourth level";

            run12.Append(runProperties14);
            run12.Append(text14);

            paragraph15.Append(paragraphProperties9);
            paragraph15.Append(run12);

            A.Paragraph paragraph16 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties10 = new A.ParagraphProperties() { Level = 4 };

            A.Run run13 = new A.Run();

            A.RunProperties runProperties15 = new A.RunProperties() { Language = "en-US" };
            runProperties15.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text15 = new A.Text();
            text15.Text = "Fifth level";

            run13.Append(runProperties15);
            run13.Append(text15);
            A.EndParagraphRunProperties endParagraphRunProperties8 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph16.Append(paragraphProperties10);
            paragraph16.Append(run13);
            paragraph16.Append(endParagraphRunProperties8);

            textBody8.Append(bodyProperties8);
            textBody8.Append(listStyle8);
            textBody8.Append(paragraph12);
            textBody8.Append(paragraph13);
            textBody8.Append(paragraph14);
            textBody8.Append(paragraph15);
            textBody8.Append(paragraph16);

            shape8.Append(nonVisualShapeProperties8);
            shape8.Append(shapeProperties9);
            shape8.Append(textBody8);

            Shape shape9 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties9 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties13 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Date Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties9 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks9 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties9.Append(shapeLocks9);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties13 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape9 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)2U };

            applicationNonVisualDrawingProperties13.Append(placeholderShape9);

            nonVisualShapeProperties9.Append(nonVisualDrawingProperties13);
            nonVisualShapeProperties9.Append(nonVisualShapeDrawingProperties9);
            nonVisualShapeProperties9.Append(applicationNonVisualDrawingProperties13);

            ShapeProperties shapeProperties10 = new ShapeProperties();

            A.Transform2D transform2D4 = new A.Transform2D();
            A.Offset offset7 = new A.Offset() { X = 457200L, Y = 6356350L };
            A.Extents extents7 = new A.Extents() { Cx = 2133600L, Cy = 365125L };

            transform2D4.Append(offset7);
            transform2D4.Append(extents7);

            A.PresetGeometry presetGeometry4 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList4 = new A.AdjustValueList();

            presetGeometry4.Append(adjustValueList4);

            shapeProperties10.Append(transform2D4);
            shapeProperties10.Append(presetGeometry4);

            TextBody textBody9 = new TextBody();
            A.BodyProperties bodyProperties9 = new A.BodyProperties() { Vertical = A.TextVerticalValues.Horizontal, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, RightToLeftColumns = false, Anchor = A.TextAnchoringTypeValues.Center };

            A.ListStyle listStyle9 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties2 = new A.Level1ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Left };

            A.DefaultRunProperties defaultRunProperties11 = new A.DefaultRunProperties() { FontSize = 1200 };

            A.SolidFill solidFill27 = new A.SolidFill();

            A.SchemeColor schemeColor33 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint4 = new A.Tint() { Val = 75000 };

            schemeColor33.Append(tint4);

            solidFill27.Append(schemeColor33);

            defaultRunProperties11.Append(solidFill27);

            level1ParagraphProperties2.Append(defaultRunProperties11);

            listStyle9.Append(level1ParagraphProperties2);

            A.Paragraph paragraph17 = new A.Paragraph();

            A.Field field3 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties16 = new A.RunProperties() { Language = "en-US" };
            runProperties16.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text16 = new A.Text();
            text16.Text = "7/28/2013";

            field3.Append(runProperties16);
            field3.Append(text16);
            A.EndParagraphRunProperties endParagraphRunProperties9 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph17.Append(field3);
            paragraph17.Append(endParagraphRunProperties9);

            textBody9.Append(bodyProperties9);
            textBody9.Append(listStyle9);
            textBody9.Append(paragraph17);

            shape9.Append(nonVisualShapeProperties9);
            shape9.Append(shapeProperties10);
            shape9.Append(textBody9);

            Shape shape10 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties10 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties14 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Footer Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties10 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks10 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties10.Append(shapeLocks10);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties14 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape10 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)3U };

            applicationNonVisualDrawingProperties14.Append(placeholderShape10);

            nonVisualShapeProperties10.Append(nonVisualDrawingProperties14);
            nonVisualShapeProperties10.Append(nonVisualShapeDrawingProperties10);
            nonVisualShapeProperties10.Append(applicationNonVisualDrawingProperties14);

            ShapeProperties shapeProperties11 = new ShapeProperties();

            A.Transform2D transform2D5 = new A.Transform2D();
            A.Offset offset8 = new A.Offset() { X = 3124200L, Y = 6356350L };
            A.Extents extents8 = new A.Extents() { Cx = 2895600L, Cy = 365125L };

            transform2D5.Append(offset8);
            transform2D5.Append(extents8);

            A.PresetGeometry presetGeometry5 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList5 = new A.AdjustValueList();

            presetGeometry5.Append(adjustValueList5);

            shapeProperties11.Append(transform2D5);
            shapeProperties11.Append(presetGeometry5);

            TextBody textBody10 = new TextBody();
            A.BodyProperties bodyProperties10 = new A.BodyProperties() { Vertical = A.TextVerticalValues.Horizontal, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, RightToLeftColumns = false, Anchor = A.TextAnchoringTypeValues.Center };

            A.ListStyle listStyle10 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties3 = new A.Level1ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Center };

            A.DefaultRunProperties defaultRunProperties12 = new A.DefaultRunProperties() { FontSize = 1200 };

            A.SolidFill solidFill28 = new A.SolidFill();

            A.SchemeColor schemeColor34 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint5 = new A.Tint() { Val = 75000 };

            schemeColor34.Append(tint5);

            solidFill28.Append(schemeColor34);

            defaultRunProperties12.Append(solidFill28);

            level1ParagraphProperties3.Append(defaultRunProperties12);

            listStyle10.Append(level1ParagraphProperties3);

            A.Paragraph paragraph18 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties10 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph18.Append(endParagraphRunProperties10);

            textBody10.Append(bodyProperties10);
            textBody10.Append(listStyle10);
            textBody10.Append(paragraph18);

            shape10.Append(nonVisualShapeProperties10);
            shape10.Append(shapeProperties11);
            shape10.Append(textBody10);

            Shape shape11 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties11 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties15 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Slide Number Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties11 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks11 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties11.Append(shapeLocks11);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties15 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape11 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)4U };

            applicationNonVisualDrawingProperties15.Append(placeholderShape11);

            nonVisualShapeProperties11.Append(nonVisualDrawingProperties15);
            nonVisualShapeProperties11.Append(nonVisualShapeDrawingProperties11);
            nonVisualShapeProperties11.Append(applicationNonVisualDrawingProperties15);

            ShapeProperties shapeProperties12 = new ShapeProperties();

            A.Transform2D transform2D6 = new A.Transform2D();
            A.Offset offset9 = new A.Offset() { X = 6553200L, Y = 6356350L };
            A.Extents extents9 = new A.Extents() { Cx = 2133600L, Cy = 365125L };

            transform2D6.Append(offset9);
            transform2D6.Append(extents9);

            A.PresetGeometry presetGeometry6 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList6 = new A.AdjustValueList();

            presetGeometry6.Append(adjustValueList6);

            shapeProperties12.Append(transform2D6);
            shapeProperties12.Append(presetGeometry6);

            TextBody textBody11 = new TextBody();
            A.BodyProperties bodyProperties11 = new A.BodyProperties() { Vertical = A.TextVerticalValues.Horizontal, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, RightToLeftColumns = false, Anchor = A.TextAnchoringTypeValues.Center };

            A.ListStyle listStyle11 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties4 = new A.Level1ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Right };

            A.DefaultRunProperties defaultRunProperties13 = new A.DefaultRunProperties() { FontSize = 1200 };

            A.SolidFill solidFill29 = new A.SolidFill();

            A.SchemeColor schemeColor35 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint6 = new A.Tint() { Val = 75000 };

            schemeColor35.Append(tint6);

            solidFill29.Append(schemeColor35);

            defaultRunProperties13.Append(solidFill29);

            level1ParagraphProperties4.Append(defaultRunProperties13);

            listStyle11.Append(level1ParagraphProperties4);

            A.Paragraph paragraph19 = new A.Paragraph();

            A.Field field4 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties17 = new A.RunProperties() { Language = "en-US" };
            runProperties17.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text17 = new A.Text();
            text17.Text = "‹#›";

            field4.Append(runProperties17);
            field4.Append(text17);
            A.EndParagraphRunProperties endParagraphRunProperties11 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph19.Append(field4);
            paragraph19.Append(endParagraphRunProperties11);

            textBody11.Append(bodyProperties11);
            textBody11.Append(listStyle11);
            textBody11.Append(paragraph19);

            shape11.Append(nonVisualShapeProperties11);
            shape11.Append(shapeProperties12);
            shape11.Append(textBody11);

            shapeTree3.Append(nonVisualGroupShapeProperties3);
            shapeTree3.Append(groupShapeProperties3);
            shapeTree3.Append(shape7);
            shapeTree3.Append(shape8);
            shapeTree3.Append(shape9);
            shapeTree3.Append(shape10);
            shapeTree3.Append(shape11);

            CommonSlideDataExtensionList commonSlideDataExtensionList3 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension3 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId3 = new P14.CreationId() { Val = (UInt32Value)2982515936U };
            creationId3.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension3.Append(creationId3);

            commonSlideDataExtensionList3.Append(commonSlideDataExtension3);

            commonSlideData3.Append(background1);
            commonSlideData3.Append(shapeTree3);
            commonSlideData3.Append(commonSlideDataExtensionList3);
            ColorMap colorMap1 = new ColorMap() { Background1 = A.ColorSchemeIndexValues.Light1, Text1 = A.ColorSchemeIndexValues.Dark1, Background2 = A.ColorSchemeIndexValues.Light2, Text2 = A.ColorSchemeIndexValues.Dark2, Accent1 = A.ColorSchemeIndexValues.Accent1, Accent2 = A.ColorSchemeIndexValues.Accent2, Accent3 = A.ColorSchemeIndexValues.Accent3, Accent4 = A.ColorSchemeIndexValues.Accent4, Accent5 = A.ColorSchemeIndexValues.Accent5, Accent6 = A.ColorSchemeIndexValues.Accent6, Hyperlink = A.ColorSchemeIndexValues.Hyperlink, FollowedHyperlink = A.ColorSchemeIndexValues.FollowedHyperlink };

            SlideLayoutIdList slideLayoutIdList1 = new SlideLayoutIdList();
            SlideLayoutId slideLayoutId1 = new SlideLayoutId() { Id = (UInt32Value)2147483649U, RelationshipId = "rId1" };
            SlideLayoutId slideLayoutId2 = new SlideLayoutId() { Id = (UInt32Value)2147483650U, RelationshipId = "rId2" };
            SlideLayoutId slideLayoutId3 = new SlideLayoutId() { Id = (UInt32Value)2147483651U, RelationshipId = "rId3" };
            SlideLayoutId slideLayoutId4 = new SlideLayoutId() { Id = (UInt32Value)2147483652U, RelationshipId = "rId4" };
            SlideLayoutId slideLayoutId5 = new SlideLayoutId() { Id = (UInt32Value)2147483653U, RelationshipId = "rId5" };
            SlideLayoutId slideLayoutId6 = new SlideLayoutId() { Id = (UInt32Value)2147483654U, RelationshipId = "rId6" };
            SlideLayoutId slideLayoutId7 = new SlideLayoutId() { Id = (UInt32Value)2147483655U, RelationshipId = "rId7" };
            SlideLayoutId slideLayoutId8 = new SlideLayoutId() { Id = (UInt32Value)2147483656U, RelationshipId = "rId8" };
            SlideLayoutId slideLayoutId9 = new SlideLayoutId() { Id = (UInt32Value)2147483657U, RelationshipId = "rId9" };
            SlideLayoutId slideLayoutId10 = new SlideLayoutId() { Id = (UInt32Value)2147483658U, RelationshipId = "rId10" };
            SlideLayoutId slideLayoutId11 = new SlideLayoutId() { Id = (UInt32Value)2147483659U, RelationshipId = "rId11" };

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

            TextStyles textStyles1 = new TextStyles();

            TitleStyle titleStyle1 = new TitleStyle();

            A.Level1ParagraphProperties level1ParagraphProperties5 = new A.Level1ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Center, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore1 = new A.SpaceBefore();
            A.SpacingPercent spacingPercent1 = new A.SpacingPercent() { Val = 0 };

            spaceBefore1.Append(spacingPercent1);
            A.NoBullet noBullet1 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties14 = new A.DefaultRunProperties() { FontSize = 4400, Kerning = 1200 };

            A.SolidFill solidFill30 = new A.SolidFill();
            A.SchemeColor schemeColor36 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill30.Append(schemeColor36);
            A.LatinFont latinFont10 = new A.LatinFont() { Typeface = "+mj-lt" };
            A.EastAsianFont eastAsianFont10 = new A.EastAsianFont() { Typeface = "+mj-ea" };
            A.ComplexScriptFont complexScriptFont10 = new A.ComplexScriptFont() { Typeface = "+mj-cs" };

            defaultRunProperties14.Append(solidFill30);
            defaultRunProperties14.Append(latinFont10);
            defaultRunProperties14.Append(eastAsianFont10);
            defaultRunProperties14.Append(complexScriptFont10);

            level1ParagraphProperties5.Append(spaceBefore1);
            level1ParagraphProperties5.Append(noBullet1);
            level1ParagraphProperties5.Append(defaultRunProperties14);

            titleStyle1.Append(level1ParagraphProperties5);

            BodyStyle bodyStyle1 = new BodyStyle();

            A.Level1ParagraphProperties level1ParagraphProperties6 = new A.Level1ParagraphProperties() { LeftMargin = 342900, Indent = -342900, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore2 = new A.SpaceBefore();
            A.SpacingPercent spacingPercent2 = new A.SpacingPercent() { Val = 20000 };

            spaceBefore2.Append(spacingPercent2);
            A.BulletFont bulletFont1 = new A.BulletFont() { Typeface = "Arial", PitchFamily = 34, CharacterSet = 0 };
            A.CharacterBullet characterBullet1 = new A.CharacterBullet() { Char = "•" };

            A.DefaultRunProperties defaultRunProperties15 = new A.DefaultRunProperties() { FontSize = 3200, Kerning = 1200 };

            A.SolidFill solidFill31 = new A.SolidFill();
            A.SchemeColor schemeColor37 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill31.Append(schemeColor37);
            A.LatinFont latinFont11 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont11 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont11 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties15.Append(solidFill31);
            defaultRunProperties15.Append(latinFont11);
            defaultRunProperties15.Append(eastAsianFont11);
            defaultRunProperties15.Append(complexScriptFont11);

            level1ParagraphProperties6.Append(spaceBefore2);
            level1ParagraphProperties6.Append(bulletFont1);
            level1ParagraphProperties6.Append(characterBullet1);
            level1ParagraphProperties6.Append(defaultRunProperties15);

            A.Level2ParagraphProperties level2ParagraphProperties2 = new A.Level2ParagraphProperties() { LeftMargin = 742950, Indent = -285750, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore3 = new A.SpaceBefore();
            A.SpacingPercent spacingPercent3 = new A.SpacingPercent() { Val = 20000 };

            spaceBefore3.Append(spacingPercent3);
            A.BulletFont bulletFont2 = new A.BulletFont() { Typeface = "Arial", PitchFamily = 34, CharacterSet = 0 };
            A.CharacterBullet characterBullet2 = new A.CharacterBullet() { Char = "–" };

            A.DefaultRunProperties defaultRunProperties16 = new A.DefaultRunProperties() { FontSize = 2800, Kerning = 1200 };

            A.SolidFill solidFill32 = new A.SolidFill();
            A.SchemeColor schemeColor38 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill32.Append(schemeColor38);
            A.LatinFont latinFont12 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont12 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont12 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties16.Append(solidFill32);
            defaultRunProperties16.Append(latinFont12);
            defaultRunProperties16.Append(eastAsianFont12);
            defaultRunProperties16.Append(complexScriptFont12);

            level2ParagraphProperties2.Append(spaceBefore3);
            level2ParagraphProperties2.Append(bulletFont2);
            level2ParagraphProperties2.Append(characterBullet2);
            level2ParagraphProperties2.Append(defaultRunProperties16);

            A.Level3ParagraphProperties level3ParagraphProperties2 = new A.Level3ParagraphProperties() { LeftMargin = 1143000, Indent = -228600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore4 = new A.SpaceBefore();
            A.SpacingPercent spacingPercent4 = new A.SpacingPercent() { Val = 20000 };

            spaceBefore4.Append(spacingPercent4);
            A.BulletFont bulletFont3 = new A.BulletFont() { Typeface = "Arial", PitchFamily = 34, CharacterSet = 0 };
            A.CharacterBullet characterBullet3 = new A.CharacterBullet() { Char = "•" };

            A.DefaultRunProperties defaultRunProperties17 = new A.DefaultRunProperties() { FontSize = 2400, Kerning = 1200 };

            A.SolidFill solidFill33 = new A.SolidFill();
            A.SchemeColor schemeColor39 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill33.Append(schemeColor39);
            A.LatinFont latinFont13 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont13 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont13 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties17.Append(solidFill33);
            defaultRunProperties17.Append(latinFont13);
            defaultRunProperties17.Append(eastAsianFont13);
            defaultRunProperties17.Append(complexScriptFont13);

            level3ParagraphProperties2.Append(spaceBefore4);
            level3ParagraphProperties2.Append(bulletFont3);
            level3ParagraphProperties2.Append(characterBullet3);
            level3ParagraphProperties2.Append(defaultRunProperties17);

            A.Level4ParagraphProperties level4ParagraphProperties2 = new A.Level4ParagraphProperties() { LeftMargin = 1600200, Indent = -228600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore5 = new A.SpaceBefore();
            A.SpacingPercent spacingPercent5 = new A.SpacingPercent() { Val = 20000 };

            spaceBefore5.Append(spacingPercent5);
            A.BulletFont bulletFont4 = new A.BulletFont() { Typeface = "Arial", PitchFamily = 34, CharacterSet = 0 };
            A.CharacterBullet characterBullet4 = new A.CharacterBullet() { Char = "–" };

            A.DefaultRunProperties defaultRunProperties18 = new A.DefaultRunProperties() { FontSize = 2000, Kerning = 1200 };

            A.SolidFill solidFill34 = new A.SolidFill();
            A.SchemeColor schemeColor40 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill34.Append(schemeColor40);
            A.LatinFont latinFont14 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont14 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont14 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties18.Append(solidFill34);
            defaultRunProperties18.Append(latinFont14);
            defaultRunProperties18.Append(eastAsianFont14);
            defaultRunProperties18.Append(complexScriptFont14);

            level4ParagraphProperties2.Append(spaceBefore5);
            level4ParagraphProperties2.Append(bulletFont4);
            level4ParagraphProperties2.Append(characterBullet4);
            level4ParagraphProperties2.Append(defaultRunProperties18);

            A.Level5ParagraphProperties level5ParagraphProperties2 = new A.Level5ParagraphProperties() { LeftMargin = 2057400, Indent = -228600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore6 = new A.SpaceBefore();
            A.SpacingPercent spacingPercent6 = new A.SpacingPercent() { Val = 20000 };

            spaceBefore6.Append(spacingPercent6);
            A.BulletFont bulletFont5 = new A.BulletFont() { Typeface = "Arial", PitchFamily = 34, CharacterSet = 0 };
            A.CharacterBullet characterBullet5 = new A.CharacterBullet() { Char = "»" };

            A.DefaultRunProperties defaultRunProperties19 = new A.DefaultRunProperties() { FontSize = 2000, Kerning = 1200 };

            A.SolidFill solidFill35 = new A.SolidFill();
            A.SchemeColor schemeColor41 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill35.Append(schemeColor41);
            A.LatinFont latinFont15 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont15 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont15 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties19.Append(solidFill35);
            defaultRunProperties19.Append(latinFont15);
            defaultRunProperties19.Append(eastAsianFont15);
            defaultRunProperties19.Append(complexScriptFont15);

            level5ParagraphProperties2.Append(spaceBefore6);
            level5ParagraphProperties2.Append(bulletFont5);
            level5ParagraphProperties2.Append(characterBullet5);
            level5ParagraphProperties2.Append(defaultRunProperties19);

            A.Level6ParagraphProperties level6ParagraphProperties2 = new A.Level6ParagraphProperties() { LeftMargin = 2514600, Indent = -228600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore7 = new A.SpaceBefore();
            A.SpacingPercent spacingPercent7 = new A.SpacingPercent() { Val = 20000 };

            spaceBefore7.Append(spacingPercent7);
            A.BulletFont bulletFont6 = new A.BulletFont() { Typeface = "Arial", PitchFamily = 34, CharacterSet = 0 };
            A.CharacterBullet characterBullet6 = new A.CharacterBullet() { Char = "•" };

            A.DefaultRunProperties defaultRunProperties20 = new A.DefaultRunProperties() { FontSize = 2000, Kerning = 1200 };

            A.SolidFill solidFill36 = new A.SolidFill();
            A.SchemeColor schemeColor42 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill36.Append(schemeColor42);
            A.LatinFont latinFont16 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont16 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont16 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties20.Append(solidFill36);
            defaultRunProperties20.Append(latinFont16);
            defaultRunProperties20.Append(eastAsianFont16);
            defaultRunProperties20.Append(complexScriptFont16);

            level6ParagraphProperties2.Append(spaceBefore7);
            level6ParagraphProperties2.Append(bulletFont6);
            level6ParagraphProperties2.Append(characterBullet6);
            level6ParagraphProperties2.Append(defaultRunProperties20);

            A.Level7ParagraphProperties level7ParagraphProperties2 = new A.Level7ParagraphProperties() { LeftMargin = 2971800, Indent = -228600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore8 = new A.SpaceBefore();
            A.SpacingPercent spacingPercent8 = new A.SpacingPercent() { Val = 20000 };

            spaceBefore8.Append(spacingPercent8);
            A.BulletFont bulletFont7 = new A.BulletFont() { Typeface = "Arial", PitchFamily = 34, CharacterSet = 0 };
            A.CharacterBullet characterBullet7 = new A.CharacterBullet() { Char = "•" };

            A.DefaultRunProperties defaultRunProperties21 = new A.DefaultRunProperties() { FontSize = 2000, Kerning = 1200 };

            A.SolidFill solidFill37 = new A.SolidFill();
            A.SchemeColor schemeColor43 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill37.Append(schemeColor43);
            A.LatinFont latinFont17 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont17 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont17 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties21.Append(solidFill37);
            defaultRunProperties21.Append(latinFont17);
            defaultRunProperties21.Append(eastAsianFont17);
            defaultRunProperties21.Append(complexScriptFont17);

            level7ParagraphProperties2.Append(spaceBefore8);
            level7ParagraphProperties2.Append(bulletFont7);
            level7ParagraphProperties2.Append(characterBullet7);
            level7ParagraphProperties2.Append(defaultRunProperties21);

            A.Level8ParagraphProperties level8ParagraphProperties2 = new A.Level8ParagraphProperties() { LeftMargin = 3429000, Indent = -228600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore9 = new A.SpaceBefore();
            A.SpacingPercent spacingPercent9 = new A.SpacingPercent() { Val = 20000 };

            spaceBefore9.Append(spacingPercent9);
            A.BulletFont bulletFont8 = new A.BulletFont() { Typeface = "Arial", PitchFamily = 34, CharacterSet = 0 };
            A.CharacterBullet characterBullet8 = new A.CharacterBullet() { Char = "•" };

            A.DefaultRunProperties defaultRunProperties22 = new A.DefaultRunProperties() { FontSize = 2000, Kerning = 1200 };

            A.SolidFill solidFill38 = new A.SolidFill();
            A.SchemeColor schemeColor44 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill38.Append(schemeColor44);
            A.LatinFont latinFont18 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont18 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont18 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties22.Append(solidFill38);
            defaultRunProperties22.Append(latinFont18);
            defaultRunProperties22.Append(eastAsianFont18);
            defaultRunProperties22.Append(complexScriptFont18);

            level8ParagraphProperties2.Append(spaceBefore9);
            level8ParagraphProperties2.Append(bulletFont8);
            level8ParagraphProperties2.Append(characterBullet8);
            level8ParagraphProperties2.Append(defaultRunProperties22);

            A.Level9ParagraphProperties level9ParagraphProperties2 = new A.Level9ParagraphProperties() { LeftMargin = 3886200, Indent = -228600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.SpaceBefore spaceBefore10 = new A.SpaceBefore();
            A.SpacingPercent spacingPercent10 = new A.SpacingPercent() { Val = 20000 };

            spaceBefore10.Append(spacingPercent10);
            A.BulletFont bulletFont9 = new A.BulletFont() { Typeface = "Arial", PitchFamily = 34, CharacterSet = 0 };
            A.CharacterBullet characterBullet9 = new A.CharacterBullet() { Char = "•" };

            A.DefaultRunProperties defaultRunProperties23 = new A.DefaultRunProperties() { FontSize = 2000, Kerning = 1200 };

            A.SolidFill solidFill39 = new A.SolidFill();
            A.SchemeColor schemeColor45 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill39.Append(schemeColor45);
            A.LatinFont latinFont19 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont19 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont19 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties23.Append(solidFill39);
            defaultRunProperties23.Append(latinFont19);
            defaultRunProperties23.Append(eastAsianFont19);
            defaultRunProperties23.Append(complexScriptFont19);

            level9ParagraphProperties2.Append(spaceBefore10);
            level9ParagraphProperties2.Append(bulletFont9);
            level9ParagraphProperties2.Append(characterBullet9);
            level9ParagraphProperties2.Append(defaultRunProperties23);

            bodyStyle1.Append(level1ParagraphProperties6);
            bodyStyle1.Append(level2ParagraphProperties2);
            bodyStyle1.Append(level3ParagraphProperties2);
            bodyStyle1.Append(level4ParagraphProperties2);
            bodyStyle1.Append(level5ParagraphProperties2);
            bodyStyle1.Append(level6ParagraphProperties2);
            bodyStyle1.Append(level7ParagraphProperties2);
            bodyStyle1.Append(level8ParagraphProperties2);
            bodyStyle1.Append(level9ParagraphProperties2);

            OtherStyle otherStyle1 = new OtherStyle();

            A.DefaultParagraphProperties defaultParagraphProperties2 = new A.DefaultParagraphProperties();
            A.DefaultRunProperties defaultRunProperties24 = new A.DefaultRunProperties() { Language = "en-US" };

            defaultParagraphProperties2.Append(defaultRunProperties24);

            A.Level1ParagraphProperties level1ParagraphProperties7 = new A.Level1ParagraphProperties() { LeftMargin = 0, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties25 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill40 = new A.SolidFill();
            A.SchemeColor schemeColor46 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill40.Append(schemeColor46);
            A.LatinFont latinFont20 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont20 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont20 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties25.Append(solidFill40);
            defaultRunProperties25.Append(latinFont20);
            defaultRunProperties25.Append(eastAsianFont20);
            defaultRunProperties25.Append(complexScriptFont20);

            level1ParagraphProperties7.Append(defaultRunProperties25);

            A.Level2ParagraphProperties level2ParagraphProperties3 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties26 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill41 = new A.SolidFill();
            A.SchemeColor schemeColor47 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill41.Append(schemeColor47);
            A.LatinFont latinFont21 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont21 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont21 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties26.Append(solidFill41);
            defaultRunProperties26.Append(latinFont21);
            defaultRunProperties26.Append(eastAsianFont21);
            defaultRunProperties26.Append(complexScriptFont21);

            level2ParagraphProperties3.Append(defaultRunProperties26);

            A.Level3ParagraphProperties level3ParagraphProperties3 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties27 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill42 = new A.SolidFill();
            A.SchemeColor schemeColor48 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill42.Append(schemeColor48);
            A.LatinFont latinFont22 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont22 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont22 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties27.Append(solidFill42);
            defaultRunProperties27.Append(latinFont22);
            defaultRunProperties27.Append(eastAsianFont22);
            defaultRunProperties27.Append(complexScriptFont22);

            level3ParagraphProperties3.Append(defaultRunProperties27);

            A.Level4ParagraphProperties level4ParagraphProperties3 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties28 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill43 = new A.SolidFill();
            A.SchemeColor schemeColor49 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill43.Append(schemeColor49);
            A.LatinFont latinFont23 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont23 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont23 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties28.Append(solidFill43);
            defaultRunProperties28.Append(latinFont23);
            defaultRunProperties28.Append(eastAsianFont23);
            defaultRunProperties28.Append(complexScriptFont23);

            level4ParagraphProperties3.Append(defaultRunProperties28);

            A.Level5ParagraphProperties level5ParagraphProperties3 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties29 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill44 = new A.SolidFill();
            A.SchemeColor schemeColor50 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill44.Append(schemeColor50);
            A.LatinFont latinFont24 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont24 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont24 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties29.Append(solidFill44);
            defaultRunProperties29.Append(latinFont24);
            defaultRunProperties29.Append(eastAsianFont24);
            defaultRunProperties29.Append(complexScriptFont24);

            level5ParagraphProperties3.Append(defaultRunProperties29);

            A.Level6ParagraphProperties level6ParagraphProperties3 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties30 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill45 = new A.SolidFill();
            A.SchemeColor schemeColor51 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill45.Append(schemeColor51);
            A.LatinFont latinFont25 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont25 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont25 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties30.Append(solidFill45);
            defaultRunProperties30.Append(latinFont25);
            defaultRunProperties30.Append(eastAsianFont25);
            defaultRunProperties30.Append(complexScriptFont25);

            level6ParagraphProperties3.Append(defaultRunProperties30);

            A.Level7ParagraphProperties level7ParagraphProperties3 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties31 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill46 = new A.SolidFill();
            A.SchemeColor schemeColor52 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill46.Append(schemeColor52);
            A.LatinFont latinFont26 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont26 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont26 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties31.Append(solidFill46);
            defaultRunProperties31.Append(latinFont26);
            defaultRunProperties31.Append(eastAsianFont26);
            defaultRunProperties31.Append(complexScriptFont26);

            level7ParagraphProperties3.Append(defaultRunProperties31);

            A.Level8ParagraphProperties level8ParagraphProperties3 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties32 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill47 = new A.SolidFill();
            A.SchemeColor schemeColor53 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill47.Append(schemeColor53);
            A.LatinFont latinFont27 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont27 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont27 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties32.Append(solidFill47);
            defaultRunProperties32.Append(latinFont27);
            defaultRunProperties32.Append(eastAsianFont27);
            defaultRunProperties32.Append(complexScriptFont27);

            level8ParagraphProperties3.Append(defaultRunProperties32);

            A.Level9ParagraphProperties level9ParagraphProperties3 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties33 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill48 = new A.SolidFill();
            A.SchemeColor schemeColor54 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill48.Append(schemeColor54);
            A.LatinFont latinFont28 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont28 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont28 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties33.Append(solidFill48);
            defaultRunProperties33.Append(latinFont28);
            defaultRunProperties33.Append(eastAsianFont28);
            defaultRunProperties33.Append(complexScriptFont28);

            level9ParagraphProperties3.Append(defaultRunProperties33);

            otherStyle1.Append(defaultParagraphProperties2);
            otherStyle1.Append(level1ParagraphProperties7);
            otherStyle1.Append(level2ParagraphProperties3);
            otherStyle1.Append(level3ParagraphProperties3);
            otherStyle1.Append(level4ParagraphProperties3);
            otherStyle1.Append(level5ParagraphProperties3);
            otherStyle1.Append(level6ParagraphProperties3);
            otherStyle1.Append(level7ParagraphProperties3);
            otherStyle1.Append(level8ParagraphProperties3);
            otherStyle1.Append(level9ParagraphProperties3);

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
            SlideLayout slideLayout2 = new SlideLayout() { Type = SlideLayoutValues.ObjectText, Preserve = true };
            slideLayout2.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout2.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout2.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData4 = new CommonSlideData() { Name = "Content with Caption" };

            ShapeTree shapeTree4 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties4 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties16 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties4 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties16 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties4.Append(nonVisualDrawingProperties16);
            nonVisualGroupShapeProperties4.Append(nonVisualGroupShapeDrawingProperties4);
            nonVisualGroupShapeProperties4.Append(applicationNonVisualDrawingProperties16);

            GroupShapeProperties groupShapeProperties4 = new GroupShapeProperties();

            A.TransformGroup transformGroup4 = new A.TransformGroup();
            A.Offset offset10 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents10 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset4 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents4 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup4.Append(offset10);
            transformGroup4.Append(extents10);
            transformGroup4.Append(childOffset4);
            transformGroup4.Append(childExtents4);

            groupShapeProperties4.Append(transformGroup4);

            Shape shape12 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties12 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties17 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties12 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks12 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties12.Append(shapeLocks12);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties17 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape12 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties17.Append(placeholderShape12);

            nonVisualShapeProperties12.Append(nonVisualDrawingProperties17);
            nonVisualShapeProperties12.Append(nonVisualShapeDrawingProperties12);
            nonVisualShapeProperties12.Append(applicationNonVisualDrawingProperties17);

            ShapeProperties shapeProperties13 = new ShapeProperties();

            A.Transform2D transform2D7 = new A.Transform2D();
            A.Offset offset11 = new A.Offset() { X = 457200L, Y = 273050L };
            A.Extents extents11 = new A.Extents() { Cx = 3008313L, Cy = 1162050L };

            transform2D7.Append(offset11);
            transform2D7.Append(extents11);

            shapeProperties13.Append(transform2D7);

            TextBody textBody12 = new TextBody();
            A.BodyProperties bodyProperties12 = new A.BodyProperties() { Anchor = A.TextAnchoringTypeValues.Bottom };

            A.ListStyle listStyle12 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties8 = new A.Level1ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Left };
            A.DefaultRunProperties defaultRunProperties34 = new A.DefaultRunProperties() { FontSize = 2000, Bold = true };

            level1ParagraphProperties8.Append(defaultRunProperties34);

            listStyle12.Append(level1ParagraphProperties8);

            A.Paragraph paragraph20 = new A.Paragraph();

            A.Run run14 = new A.Run();

            A.RunProperties runProperties18 = new A.RunProperties() { Language = "en-US" };
            runProperties18.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text18 = new A.Text();
            text18.Text = "Click to edit Master title style";

            run14.Append(runProperties18);
            run14.Append(text18);
            A.EndParagraphRunProperties endParagraphRunProperties12 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph20.Append(run14);
            paragraph20.Append(endParagraphRunProperties12);

            textBody12.Append(bodyProperties12);
            textBody12.Append(listStyle12);
            textBody12.Append(paragraph20);

            shape12.Append(nonVisualShapeProperties12);
            shape12.Append(shapeProperties13);
            shape12.Append(textBody12);

            Shape shape13 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties13 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties18 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Content Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties13 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks13 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties13.Append(shapeLocks13);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties18 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape13 = new PlaceholderShape() { Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties18.Append(placeholderShape13);

            nonVisualShapeProperties13.Append(nonVisualDrawingProperties18);
            nonVisualShapeProperties13.Append(nonVisualShapeDrawingProperties13);
            nonVisualShapeProperties13.Append(applicationNonVisualDrawingProperties18);

            ShapeProperties shapeProperties14 = new ShapeProperties();

            A.Transform2D transform2D8 = new A.Transform2D();
            A.Offset offset12 = new A.Offset() { X = 3575050L, Y = 273050L };
            A.Extents extents12 = new A.Extents() { Cx = 5111750L, Cy = 5853113L };

            transform2D8.Append(offset12);
            transform2D8.Append(extents12);

            shapeProperties14.Append(transform2D8);

            TextBody textBody13 = new TextBody();
            A.BodyProperties bodyProperties13 = new A.BodyProperties();

            A.ListStyle listStyle13 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties9 = new A.Level1ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties35 = new A.DefaultRunProperties() { FontSize = 3200 };

            level1ParagraphProperties9.Append(defaultRunProperties35);

            A.Level2ParagraphProperties level2ParagraphProperties4 = new A.Level2ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties36 = new A.DefaultRunProperties() { FontSize = 2800 };

            level2ParagraphProperties4.Append(defaultRunProperties36);

            A.Level3ParagraphProperties level3ParagraphProperties4 = new A.Level3ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties37 = new A.DefaultRunProperties() { FontSize = 2400 };

            level3ParagraphProperties4.Append(defaultRunProperties37);

            A.Level4ParagraphProperties level4ParagraphProperties4 = new A.Level4ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties38 = new A.DefaultRunProperties() { FontSize = 2000 };

            level4ParagraphProperties4.Append(defaultRunProperties38);

            A.Level5ParagraphProperties level5ParagraphProperties4 = new A.Level5ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties39 = new A.DefaultRunProperties() { FontSize = 2000 };

            level5ParagraphProperties4.Append(defaultRunProperties39);

            A.Level6ParagraphProperties level6ParagraphProperties4 = new A.Level6ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties40 = new A.DefaultRunProperties() { FontSize = 2000 };

            level6ParagraphProperties4.Append(defaultRunProperties40);

            A.Level7ParagraphProperties level7ParagraphProperties4 = new A.Level7ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties41 = new A.DefaultRunProperties() { FontSize = 2000 };

            level7ParagraphProperties4.Append(defaultRunProperties41);

            A.Level8ParagraphProperties level8ParagraphProperties4 = new A.Level8ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties42 = new A.DefaultRunProperties() { FontSize = 2000 };

            level8ParagraphProperties4.Append(defaultRunProperties42);

            A.Level9ParagraphProperties level9ParagraphProperties4 = new A.Level9ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties43 = new A.DefaultRunProperties() { FontSize = 2000 };

            level9ParagraphProperties4.Append(defaultRunProperties43);

            listStyle13.Append(level1ParagraphProperties9);
            listStyle13.Append(level2ParagraphProperties4);
            listStyle13.Append(level3ParagraphProperties4);
            listStyle13.Append(level4ParagraphProperties4);
            listStyle13.Append(level5ParagraphProperties4);
            listStyle13.Append(level6ParagraphProperties4);
            listStyle13.Append(level7ParagraphProperties4);
            listStyle13.Append(level8ParagraphProperties4);
            listStyle13.Append(level9ParagraphProperties4);

            A.Paragraph paragraph21 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties11 = new A.ParagraphProperties() { Level = 0 };

            A.Run run15 = new A.Run();

            A.RunProperties runProperties19 = new A.RunProperties() { Language = "en-US" };
            runProperties19.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text19 = new A.Text();
            text19.Text = "Click to edit Master text styles";

            run15.Append(runProperties19);
            run15.Append(text19);

            paragraph21.Append(paragraphProperties11);
            paragraph21.Append(run15);

            A.Paragraph paragraph22 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties12 = new A.ParagraphProperties() { Level = 1 };

            A.Run run16 = new A.Run();

            A.RunProperties runProperties20 = new A.RunProperties() { Language = "en-US" };
            runProperties20.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text20 = new A.Text();
            text20.Text = "Second level";

            run16.Append(runProperties20);
            run16.Append(text20);

            paragraph22.Append(paragraphProperties12);
            paragraph22.Append(run16);

            A.Paragraph paragraph23 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties13 = new A.ParagraphProperties() { Level = 2 };

            A.Run run17 = new A.Run();

            A.RunProperties runProperties21 = new A.RunProperties() { Language = "en-US" };
            runProperties21.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text21 = new A.Text();
            text21.Text = "Third level";

            run17.Append(runProperties21);
            run17.Append(text21);

            paragraph23.Append(paragraphProperties13);
            paragraph23.Append(run17);

            A.Paragraph paragraph24 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties14 = new A.ParagraphProperties() { Level = 3 };

            A.Run run18 = new A.Run();

            A.RunProperties runProperties22 = new A.RunProperties() { Language = "en-US" };
            runProperties22.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text22 = new A.Text();
            text22.Text = "Fourth level";

            run18.Append(runProperties22);
            run18.Append(text22);

            paragraph24.Append(paragraphProperties14);
            paragraph24.Append(run18);

            A.Paragraph paragraph25 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties15 = new A.ParagraphProperties() { Level = 4 };

            A.Run run19 = new A.Run();

            A.RunProperties runProperties23 = new A.RunProperties() { Language = "en-US" };
            runProperties23.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text23 = new A.Text();
            text23.Text = "Fifth level";

            run19.Append(runProperties23);
            run19.Append(text23);
            A.EndParagraphRunProperties endParagraphRunProperties13 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph25.Append(paragraphProperties15);
            paragraph25.Append(run19);
            paragraph25.Append(endParagraphRunProperties13);

            textBody13.Append(bodyProperties13);
            textBody13.Append(listStyle13);
            textBody13.Append(paragraph21);
            textBody13.Append(paragraph22);
            textBody13.Append(paragraph23);
            textBody13.Append(paragraph24);
            textBody13.Append(paragraph25);

            shape13.Append(nonVisualShapeProperties13);
            shape13.Append(shapeProperties14);
            shape13.Append(textBody13);

            Shape shape14 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties14 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties19 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Text Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties14 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks14 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties14.Append(shapeLocks14);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties19 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape14 = new PlaceholderShape() { Type = PlaceholderValues.Body, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)2U };

            applicationNonVisualDrawingProperties19.Append(placeholderShape14);

            nonVisualShapeProperties14.Append(nonVisualDrawingProperties19);
            nonVisualShapeProperties14.Append(nonVisualShapeDrawingProperties14);
            nonVisualShapeProperties14.Append(applicationNonVisualDrawingProperties19);

            ShapeProperties shapeProperties15 = new ShapeProperties();

            A.Transform2D transform2D9 = new A.Transform2D();
            A.Offset offset13 = new A.Offset() { X = 457200L, Y = 1435100L };
            A.Extents extents13 = new A.Extents() { Cx = 3008313L, Cy = 4691063L };

            transform2D9.Append(offset13);
            transform2D9.Append(extents13);

            shapeProperties15.Append(transform2D9);

            TextBody textBody14 = new TextBody();
            A.BodyProperties bodyProperties14 = new A.BodyProperties();

            A.ListStyle listStyle14 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties10 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0 };
            A.NoBullet noBullet2 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties44 = new A.DefaultRunProperties() { FontSize = 1400 };

            level1ParagraphProperties10.Append(noBullet2);
            level1ParagraphProperties10.Append(defaultRunProperties44);

            A.Level2ParagraphProperties level2ParagraphProperties5 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0 };
            A.NoBullet noBullet3 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties45 = new A.DefaultRunProperties() { FontSize = 1200 };

            level2ParagraphProperties5.Append(noBullet3);
            level2ParagraphProperties5.Append(defaultRunProperties45);

            A.Level3ParagraphProperties level3ParagraphProperties5 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0 };
            A.NoBullet noBullet4 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties46 = new A.DefaultRunProperties() { FontSize = 1000 };

            level3ParagraphProperties5.Append(noBullet4);
            level3ParagraphProperties5.Append(defaultRunProperties46);

            A.Level4ParagraphProperties level4ParagraphProperties5 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0 };
            A.NoBullet noBullet5 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties47 = new A.DefaultRunProperties() { FontSize = 900 };

            level4ParagraphProperties5.Append(noBullet5);
            level4ParagraphProperties5.Append(defaultRunProperties47);

            A.Level5ParagraphProperties level5ParagraphProperties5 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0 };
            A.NoBullet noBullet6 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties48 = new A.DefaultRunProperties() { FontSize = 900 };

            level5ParagraphProperties5.Append(noBullet6);
            level5ParagraphProperties5.Append(defaultRunProperties48);

            A.Level6ParagraphProperties level6ParagraphProperties5 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0 };
            A.NoBullet noBullet7 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties49 = new A.DefaultRunProperties() { FontSize = 900 };

            level6ParagraphProperties5.Append(noBullet7);
            level6ParagraphProperties5.Append(defaultRunProperties49);

            A.Level7ParagraphProperties level7ParagraphProperties5 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0 };
            A.NoBullet noBullet8 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties50 = new A.DefaultRunProperties() { FontSize = 900 };

            level7ParagraphProperties5.Append(noBullet8);
            level7ParagraphProperties5.Append(defaultRunProperties50);

            A.Level8ParagraphProperties level8ParagraphProperties5 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0 };
            A.NoBullet noBullet9 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties51 = new A.DefaultRunProperties() { FontSize = 900 };

            level8ParagraphProperties5.Append(noBullet9);
            level8ParagraphProperties5.Append(defaultRunProperties51);

            A.Level9ParagraphProperties level9ParagraphProperties5 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0 };
            A.NoBullet noBullet10 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties52 = new A.DefaultRunProperties() { FontSize = 900 };

            level9ParagraphProperties5.Append(noBullet10);
            level9ParagraphProperties5.Append(defaultRunProperties52);

            listStyle14.Append(level1ParagraphProperties10);
            listStyle14.Append(level2ParagraphProperties5);
            listStyle14.Append(level3ParagraphProperties5);
            listStyle14.Append(level4ParagraphProperties5);
            listStyle14.Append(level5ParagraphProperties5);
            listStyle14.Append(level6ParagraphProperties5);
            listStyle14.Append(level7ParagraphProperties5);
            listStyle14.Append(level8ParagraphProperties5);
            listStyle14.Append(level9ParagraphProperties5);

            A.Paragraph paragraph26 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties16 = new A.ParagraphProperties() { Level = 0 };

            A.Run run20 = new A.Run();

            A.RunProperties runProperties24 = new A.RunProperties() { Language = "en-US" };
            runProperties24.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text24 = new A.Text();
            text24.Text = "Click to edit Master text styles";

            run20.Append(runProperties24);
            run20.Append(text24);

            paragraph26.Append(paragraphProperties16);
            paragraph26.Append(run20);

            textBody14.Append(bodyProperties14);
            textBody14.Append(listStyle14);
            textBody14.Append(paragraph26);

            shape14.Append(nonVisualShapeProperties14);
            shape14.Append(shapeProperties15);
            shape14.Append(textBody14);

            Shape shape15 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties15 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties20 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Date Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties15 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks15 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties15.Append(shapeLocks15);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties20 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape15 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties20.Append(placeholderShape15);

            nonVisualShapeProperties15.Append(nonVisualDrawingProperties20);
            nonVisualShapeProperties15.Append(nonVisualShapeDrawingProperties15);
            nonVisualShapeProperties15.Append(applicationNonVisualDrawingProperties20);
            ShapeProperties shapeProperties16 = new ShapeProperties();

            TextBody textBody15 = new TextBody();
            A.BodyProperties bodyProperties15 = new A.BodyProperties();
            A.ListStyle listStyle15 = new A.ListStyle();

            A.Paragraph paragraph27 = new A.Paragraph();

            A.Field field5 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties25 = new A.RunProperties() { Language = "en-US" };
            runProperties25.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text25 = new A.Text();
            text25.Text = "7/28/2013";

            field5.Append(runProperties25);
            field5.Append(text25);
            A.EndParagraphRunProperties endParagraphRunProperties14 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph27.Append(field5);
            paragraph27.Append(endParagraphRunProperties14);

            textBody15.Append(bodyProperties15);
            textBody15.Append(listStyle15);
            textBody15.Append(paragraph27);

            shape15.Append(nonVisualShapeProperties15);
            shape15.Append(shapeProperties16);
            shape15.Append(textBody15);

            Shape shape16 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties16 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties21 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Footer Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties16 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks16 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties16.Append(shapeLocks16);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties21 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape16 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties21.Append(placeholderShape16);

            nonVisualShapeProperties16.Append(nonVisualDrawingProperties21);
            nonVisualShapeProperties16.Append(nonVisualShapeDrawingProperties16);
            nonVisualShapeProperties16.Append(applicationNonVisualDrawingProperties21);
            ShapeProperties shapeProperties17 = new ShapeProperties();

            TextBody textBody16 = new TextBody();
            A.BodyProperties bodyProperties16 = new A.BodyProperties();
            A.ListStyle listStyle16 = new A.ListStyle();

            A.Paragraph paragraph28 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties15 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph28.Append(endParagraphRunProperties15);

            textBody16.Append(bodyProperties16);
            textBody16.Append(listStyle16);
            textBody16.Append(paragraph28);

            shape16.Append(nonVisualShapeProperties16);
            shape16.Append(shapeProperties17);
            shape16.Append(textBody16);

            Shape shape17 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties17 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties22 = new NonVisualDrawingProperties() { Id = (UInt32Value)7U, Name = "Slide Number Placeholder 6" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties17 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks17 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties17.Append(shapeLocks17);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties22 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape17 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties22.Append(placeholderShape17);

            nonVisualShapeProperties17.Append(nonVisualDrawingProperties22);
            nonVisualShapeProperties17.Append(nonVisualShapeDrawingProperties17);
            nonVisualShapeProperties17.Append(applicationNonVisualDrawingProperties22);
            ShapeProperties shapeProperties18 = new ShapeProperties();

            TextBody textBody17 = new TextBody();
            A.BodyProperties bodyProperties17 = new A.BodyProperties();
            A.ListStyle listStyle17 = new A.ListStyle();

            A.Paragraph paragraph29 = new A.Paragraph();

            A.Field field6 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties26 = new A.RunProperties() { Language = "en-US" };
            runProperties26.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text26 = new A.Text();
            text26.Text = "‹#›";

            field6.Append(runProperties26);
            field6.Append(text26);
            A.EndParagraphRunProperties endParagraphRunProperties16 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph29.Append(field6);
            paragraph29.Append(endParagraphRunProperties16);

            textBody17.Append(bodyProperties17);
            textBody17.Append(listStyle17);
            textBody17.Append(paragraph29);

            shape17.Append(nonVisualShapeProperties17);
            shape17.Append(shapeProperties18);
            shape17.Append(textBody17);

            shapeTree4.Append(nonVisualGroupShapeProperties4);
            shapeTree4.Append(groupShapeProperties4);
            shapeTree4.Append(shape12);
            shapeTree4.Append(shape13);
            shapeTree4.Append(shape14);
            shapeTree4.Append(shape15);
            shapeTree4.Append(shape16);
            shapeTree4.Append(shape17);

            CommonSlideDataExtensionList commonSlideDataExtensionList4 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension4 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId4 = new P14.CreationId() { Val = (UInt32Value)1134574186U };
            creationId4.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension4.Append(creationId4);

            commonSlideDataExtensionList4.Append(commonSlideDataExtension4);

            commonSlideData4.Append(shapeTree4);
            commonSlideData4.Append(commonSlideDataExtensionList4);

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
            SlideLayout slideLayout3 = new SlideLayout() { Type = SlideLayoutValues.SectionHeader, Preserve = true };
            slideLayout3.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout3.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout3.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData5 = new CommonSlideData() { Name = "Section Header" };

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
            A.Offset offset14 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents14 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset5 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents5 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup5.Append(offset14);
            transformGroup5.Append(extents14);
            transformGroup5.Append(childOffset5);
            transformGroup5.Append(childExtents5);

            groupShapeProperties5.Append(transformGroup5);

            Shape shape18 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties18 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties24 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties18 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks18 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties18.Append(shapeLocks18);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties24 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape18 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties24.Append(placeholderShape18);

            nonVisualShapeProperties18.Append(nonVisualDrawingProperties24);
            nonVisualShapeProperties18.Append(nonVisualShapeDrawingProperties18);
            nonVisualShapeProperties18.Append(applicationNonVisualDrawingProperties24);

            ShapeProperties shapeProperties19 = new ShapeProperties();

            A.Transform2D transform2D10 = new A.Transform2D();
            A.Offset offset15 = new A.Offset() { X = 722313L, Y = 4406900L };
            A.Extents extents15 = new A.Extents() { Cx = 7772400L, Cy = 1362075L };

            transform2D10.Append(offset15);
            transform2D10.Append(extents15);

            shapeProperties19.Append(transform2D10);

            TextBody textBody18 = new TextBody();
            A.BodyProperties bodyProperties18 = new A.BodyProperties() { Anchor = A.TextAnchoringTypeValues.Top };

            A.ListStyle listStyle18 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties11 = new A.Level1ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Left };
            A.DefaultRunProperties defaultRunProperties53 = new A.DefaultRunProperties() { FontSize = 4000, Bold = true, Capital = A.TextCapsValues.All };

            level1ParagraphProperties11.Append(defaultRunProperties53);

            listStyle18.Append(level1ParagraphProperties11);

            A.Paragraph paragraph30 = new A.Paragraph();

            A.Run run21 = new A.Run();

            A.RunProperties runProperties27 = new A.RunProperties() { Language = "en-US" };
            runProperties27.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text27 = new A.Text();
            text27.Text = "Click to edit Master title style";

            run21.Append(runProperties27);
            run21.Append(text27);
            A.EndParagraphRunProperties endParagraphRunProperties17 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph30.Append(run21);
            paragraph30.Append(endParagraphRunProperties17);

            textBody18.Append(bodyProperties18);
            textBody18.Append(listStyle18);
            textBody18.Append(paragraph30);

            shape18.Append(nonVisualShapeProperties18);
            shape18.Append(shapeProperties19);
            shape18.Append(textBody18);

            Shape shape19 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties19 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties25 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Text Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties19 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks19 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties19.Append(shapeLocks19);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties25 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape19 = new PlaceholderShape() { Type = PlaceholderValues.Body, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties25.Append(placeholderShape19);

            nonVisualShapeProperties19.Append(nonVisualDrawingProperties25);
            nonVisualShapeProperties19.Append(nonVisualShapeDrawingProperties19);
            nonVisualShapeProperties19.Append(applicationNonVisualDrawingProperties25);

            ShapeProperties shapeProperties20 = new ShapeProperties();

            A.Transform2D transform2D11 = new A.Transform2D();
            A.Offset offset16 = new A.Offset() { X = 722313L, Y = 2906713L };
            A.Extents extents16 = new A.Extents() { Cx = 7772400L, Cy = 1500187L };

            transform2D11.Append(offset16);
            transform2D11.Append(extents16);

            shapeProperties20.Append(transform2D11);

            TextBody textBody19 = new TextBody();
            A.BodyProperties bodyProperties19 = new A.BodyProperties() { Anchor = A.TextAnchoringTypeValues.Bottom };

            A.ListStyle listStyle19 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties12 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0 };
            A.NoBullet noBullet11 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties54 = new A.DefaultRunProperties() { FontSize = 2000 };

            A.SolidFill solidFill49 = new A.SolidFill();

            A.SchemeColor schemeColor55 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint7 = new A.Tint() { Val = 75000 };

            schemeColor55.Append(tint7);

            solidFill49.Append(schemeColor55);

            defaultRunProperties54.Append(solidFill49);

            level1ParagraphProperties12.Append(noBullet11);
            level1ParagraphProperties12.Append(defaultRunProperties54);

            A.Level2ParagraphProperties level2ParagraphProperties6 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0 };
            A.NoBullet noBullet12 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties55 = new A.DefaultRunProperties() { FontSize = 1800 };

            A.SolidFill solidFill50 = new A.SolidFill();

            A.SchemeColor schemeColor56 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint8 = new A.Tint() { Val = 75000 };

            schemeColor56.Append(tint8);

            solidFill50.Append(schemeColor56);

            defaultRunProperties55.Append(solidFill50);

            level2ParagraphProperties6.Append(noBullet12);
            level2ParagraphProperties6.Append(defaultRunProperties55);

            A.Level3ParagraphProperties level3ParagraphProperties6 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0 };
            A.NoBullet noBullet13 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties56 = new A.DefaultRunProperties() { FontSize = 1600 };

            A.SolidFill solidFill51 = new A.SolidFill();

            A.SchemeColor schemeColor57 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint9 = new A.Tint() { Val = 75000 };

            schemeColor57.Append(tint9);

            solidFill51.Append(schemeColor57);

            defaultRunProperties56.Append(solidFill51);

            level3ParagraphProperties6.Append(noBullet13);
            level3ParagraphProperties6.Append(defaultRunProperties56);

            A.Level4ParagraphProperties level4ParagraphProperties6 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0 };
            A.NoBullet noBullet14 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties57 = new A.DefaultRunProperties() { FontSize = 1400 };

            A.SolidFill solidFill52 = new A.SolidFill();

            A.SchemeColor schemeColor58 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint10 = new A.Tint() { Val = 75000 };

            schemeColor58.Append(tint10);

            solidFill52.Append(schemeColor58);

            defaultRunProperties57.Append(solidFill52);

            level4ParagraphProperties6.Append(noBullet14);
            level4ParagraphProperties6.Append(defaultRunProperties57);

            A.Level5ParagraphProperties level5ParagraphProperties6 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0 };
            A.NoBullet noBullet15 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties58 = new A.DefaultRunProperties() { FontSize = 1400 };

            A.SolidFill solidFill53 = new A.SolidFill();

            A.SchemeColor schemeColor59 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint11 = new A.Tint() { Val = 75000 };

            schemeColor59.Append(tint11);

            solidFill53.Append(schemeColor59);

            defaultRunProperties58.Append(solidFill53);

            level5ParagraphProperties6.Append(noBullet15);
            level5ParagraphProperties6.Append(defaultRunProperties58);

            A.Level6ParagraphProperties level6ParagraphProperties6 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0 };
            A.NoBullet noBullet16 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties59 = new A.DefaultRunProperties() { FontSize = 1400 };

            A.SolidFill solidFill54 = new A.SolidFill();

            A.SchemeColor schemeColor60 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint12 = new A.Tint() { Val = 75000 };

            schemeColor60.Append(tint12);

            solidFill54.Append(schemeColor60);

            defaultRunProperties59.Append(solidFill54);

            level6ParagraphProperties6.Append(noBullet16);
            level6ParagraphProperties6.Append(defaultRunProperties59);

            A.Level7ParagraphProperties level7ParagraphProperties6 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0 };
            A.NoBullet noBullet17 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties60 = new A.DefaultRunProperties() { FontSize = 1400 };

            A.SolidFill solidFill55 = new A.SolidFill();

            A.SchemeColor schemeColor61 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint13 = new A.Tint() { Val = 75000 };

            schemeColor61.Append(tint13);

            solidFill55.Append(schemeColor61);

            defaultRunProperties60.Append(solidFill55);

            level7ParagraphProperties6.Append(noBullet17);
            level7ParagraphProperties6.Append(defaultRunProperties60);

            A.Level8ParagraphProperties level8ParagraphProperties6 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0 };
            A.NoBullet noBullet18 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties61 = new A.DefaultRunProperties() { FontSize = 1400 };

            A.SolidFill solidFill56 = new A.SolidFill();

            A.SchemeColor schemeColor62 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint14 = new A.Tint() { Val = 75000 };

            schemeColor62.Append(tint14);

            solidFill56.Append(schemeColor62);

            defaultRunProperties61.Append(solidFill56);

            level8ParagraphProperties6.Append(noBullet18);
            level8ParagraphProperties6.Append(defaultRunProperties61);

            A.Level9ParagraphProperties level9ParagraphProperties6 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0 };
            A.NoBullet noBullet19 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties62 = new A.DefaultRunProperties() { FontSize = 1400 };

            A.SolidFill solidFill57 = new A.SolidFill();

            A.SchemeColor schemeColor63 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint15 = new A.Tint() { Val = 75000 };

            schemeColor63.Append(tint15);

            solidFill57.Append(schemeColor63);

            defaultRunProperties62.Append(solidFill57);

            level9ParagraphProperties6.Append(noBullet19);
            level9ParagraphProperties6.Append(defaultRunProperties62);

            listStyle19.Append(level1ParagraphProperties12);
            listStyle19.Append(level2ParagraphProperties6);
            listStyle19.Append(level3ParagraphProperties6);
            listStyle19.Append(level4ParagraphProperties6);
            listStyle19.Append(level5ParagraphProperties6);
            listStyle19.Append(level6ParagraphProperties6);
            listStyle19.Append(level7ParagraphProperties6);
            listStyle19.Append(level8ParagraphProperties6);
            listStyle19.Append(level9ParagraphProperties6);

            A.Paragraph paragraph31 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties17 = new A.ParagraphProperties() { Level = 0 };

            A.Run run22 = new A.Run();

            A.RunProperties runProperties28 = new A.RunProperties() { Language = "en-US" };
            runProperties28.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text28 = new A.Text();
            text28.Text = "Click to edit Master text styles";

            run22.Append(runProperties28);
            run22.Append(text28);

            paragraph31.Append(paragraphProperties17);
            paragraph31.Append(run22);

            textBody19.Append(bodyProperties19);
            textBody19.Append(listStyle19);
            textBody19.Append(paragraph31);

            shape19.Append(nonVisualShapeProperties19);
            shape19.Append(shapeProperties20);
            shape19.Append(textBody19);

            Shape shape20 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties20 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties26 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Date Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties20 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks20 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties20.Append(shapeLocks20);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties26 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape20 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties26.Append(placeholderShape20);

            nonVisualShapeProperties20.Append(nonVisualDrawingProperties26);
            nonVisualShapeProperties20.Append(nonVisualShapeDrawingProperties20);
            nonVisualShapeProperties20.Append(applicationNonVisualDrawingProperties26);
            ShapeProperties shapeProperties21 = new ShapeProperties();

            TextBody textBody20 = new TextBody();
            A.BodyProperties bodyProperties20 = new A.BodyProperties();
            A.ListStyle listStyle20 = new A.ListStyle();

            A.Paragraph paragraph32 = new A.Paragraph();

            A.Field field7 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties29 = new A.RunProperties() { Language = "en-US" };
            runProperties29.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text29 = new A.Text();
            text29.Text = "7/28/2013";

            field7.Append(runProperties29);
            field7.Append(text29);
            A.EndParagraphRunProperties endParagraphRunProperties18 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph32.Append(field7);
            paragraph32.Append(endParagraphRunProperties18);

            textBody20.Append(bodyProperties20);
            textBody20.Append(listStyle20);
            textBody20.Append(paragraph32);

            shape20.Append(nonVisualShapeProperties20);
            shape20.Append(shapeProperties21);
            shape20.Append(textBody20);

            Shape shape21 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties21 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties27 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Footer Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties21 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks21 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties21.Append(shapeLocks21);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties27 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape21 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties27.Append(placeholderShape21);

            nonVisualShapeProperties21.Append(nonVisualDrawingProperties27);
            nonVisualShapeProperties21.Append(nonVisualShapeDrawingProperties21);
            nonVisualShapeProperties21.Append(applicationNonVisualDrawingProperties27);
            ShapeProperties shapeProperties22 = new ShapeProperties();

            TextBody textBody21 = new TextBody();
            A.BodyProperties bodyProperties21 = new A.BodyProperties();
            A.ListStyle listStyle21 = new A.ListStyle();

            A.Paragraph paragraph33 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties19 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph33.Append(endParagraphRunProperties19);

            textBody21.Append(bodyProperties21);
            textBody21.Append(listStyle21);
            textBody21.Append(paragraph33);

            shape21.Append(nonVisualShapeProperties21);
            shape21.Append(shapeProperties22);
            shape21.Append(textBody21);

            Shape shape22 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties22 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties28 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Slide Number Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties22 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks22 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties22.Append(shapeLocks22);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties28 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape22 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties28.Append(placeholderShape22);

            nonVisualShapeProperties22.Append(nonVisualDrawingProperties28);
            nonVisualShapeProperties22.Append(nonVisualShapeDrawingProperties22);
            nonVisualShapeProperties22.Append(applicationNonVisualDrawingProperties28);
            ShapeProperties shapeProperties23 = new ShapeProperties();

            TextBody textBody22 = new TextBody();
            A.BodyProperties bodyProperties22 = new A.BodyProperties();
            A.ListStyle listStyle22 = new A.ListStyle();

            A.Paragraph paragraph34 = new A.Paragraph();

            A.Field field8 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties30 = new A.RunProperties() { Language = "en-US" };
            runProperties30.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text30 = new A.Text();
            text30.Text = "‹#›";

            field8.Append(runProperties30);
            field8.Append(text30);
            A.EndParagraphRunProperties endParagraphRunProperties20 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph34.Append(field8);
            paragraph34.Append(endParagraphRunProperties20);

            textBody22.Append(bodyProperties22);
            textBody22.Append(listStyle22);
            textBody22.Append(paragraph34);

            shape22.Append(nonVisualShapeProperties22);
            shape22.Append(shapeProperties23);
            shape22.Append(textBody22);

            shapeTree5.Append(nonVisualGroupShapeProperties5);
            shapeTree5.Append(groupShapeProperties5);
            shapeTree5.Append(shape18);
            shapeTree5.Append(shape19);
            shapeTree5.Append(shape20);
            shapeTree5.Append(shape21);
            shapeTree5.Append(shape22);

            CommonSlideDataExtensionList commonSlideDataExtensionList5 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension5 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId5 = new P14.CreationId() { Val = (UInt32Value)2261538752U };
            creationId5.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension5.Append(creationId5);

            commonSlideDataExtensionList5.Append(commonSlideDataExtension5);

            commonSlideData5.Append(shapeTree5);
            commonSlideData5.Append(commonSlideDataExtensionList5);

            ColorMapOverride colorMapOverride4 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping4 = new A.MasterColorMapping();

            colorMapOverride4.Append(masterColorMapping4);

            slideLayout3.Append(commonSlideData5);
            slideLayout3.Append(colorMapOverride4);

            slideLayoutPart3.SlideLayout = slideLayout3;
        }

        // Generates content of slideLayoutPart4.
        private void GenerateSlideLayoutPart4Content(SlideLayoutPart slideLayoutPart4)
        {
            SlideLayout slideLayout4 = new SlideLayout() { Type = SlideLayoutValues.Blank, Preserve = true };
            slideLayout4.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout4.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout4.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData6 = new CommonSlideData() { Name = "Blank" };

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
            A.Offset offset17 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents17 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset6 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents6 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup6.Append(offset17);
            transformGroup6.Append(extents17);
            transformGroup6.Append(childOffset6);
            transformGroup6.Append(childExtents6);

            groupShapeProperties6.Append(transformGroup6);

            Shape shape23 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties23 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties30 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Date Placeholder 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties23 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks23 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties23.Append(shapeLocks23);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties30 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape23 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties30.Append(placeholderShape23);

            nonVisualShapeProperties23.Append(nonVisualDrawingProperties30);
            nonVisualShapeProperties23.Append(nonVisualShapeDrawingProperties23);
            nonVisualShapeProperties23.Append(applicationNonVisualDrawingProperties30);
            ShapeProperties shapeProperties24 = new ShapeProperties();

            TextBody textBody23 = new TextBody();
            A.BodyProperties bodyProperties23 = new A.BodyProperties();
            A.ListStyle listStyle23 = new A.ListStyle();

            A.Paragraph paragraph35 = new A.Paragraph();

            A.Field field9 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties31 = new A.RunProperties() { Language = "en-US" };
            runProperties31.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text31 = new A.Text();
            text31.Text = "7/28/2013";

            field9.Append(runProperties31);
            field9.Append(text31);
            A.EndParagraphRunProperties endParagraphRunProperties21 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph35.Append(field9);
            paragraph35.Append(endParagraphRunProperties21);

            textBody23.Append(bodyProperties23);
            textBody23.Append(listStyle23);
            textBody23.Append(paragraph35);

            shape23.Append(nonVisualShapeProperties23);
            shape23.Append(shapeProperties24);
            shape23.Append(textBody23);

            Shape shape24 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties24 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties31 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Footer Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties24 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks24 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties24.Append(shapeLocks24);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties31 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape24 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties31.Append(placeholderShape24);

            nonVisualShapeProperties24.Append(nonVisualDrawingProperties31);
            nonVisualShapeProperties24.Append(nonVisualShapeDrawingProperties24);
            nonVisualShapeProperties24.Append(applicationNonVisualDrawingProperties31);
            ShapeProperties shapeProperties25 = new ShapeProperties();

            TextBody textBody24 = new TextBody();
            A.BodyProperties bodyProperties24 = new A.BodyProperties();
            A.ListStyle listStyle24 = new A.ListStyle();

            A.Paragraph paragraph36 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties22 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph36.Append(endParagraphRunProperties22);

            textBody24.Append(bodyProperties24);
            textBody24.Append(listStyle24);
            textBody24.Append(paragraph36);

            shape24.Append(nonVisualShapeProperties24);
            shape24.Append(shapeProperties25);
            shape24.Append(textBody24);

            Shape shape25 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties25 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties32 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Slide Number Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties25 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks25 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties25.Append(shapeLocks25);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties32 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape25 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties32.Append(placeholderShape25);

            nonVisualShapeProperties25.Append(nonVisualDrawingProperties32);
            nonVisualShapeProperties25.Append(nonVisualShapeDrawingProperties25);
            nonVisualShapeProperties25.Append(applicationNonVisualDrawingProperties32);
            ShapeProperties shapeProperties26 = new ShapeProperties();

            TextBody textBody25 = new TextBody();
            A.BodyProperties bodyProperties25 = new A.BodyProperties();
            A.ListStyle listStyle25 = new A.ListStyle();

            A.Paragraph paragraph37 = new A.Paragraph();

            A.Field field10 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties32 = new A.RunProperties() { Language = "en-US" };
            runProperties32.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text32 = new A.Text();
            text32.Text = "‹#›";

            field10.Append(runProperties32);
            field10.Append(text32);
            A.EndParagraphRunProperties endParagraphRunProperties23 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph37.Append(field10);
            paragraph37.Append(endParagraphRunProperties23);

            textBody25.Append(bodyProperties25);
            textBody25.Append(listStyle25);
            textBody25.Append(paragraph37);

            shape25.Append(nonVisualShapeProperties25);
            shape25.Append(shapeProperties26);
            shape25.Append(textBody25);

            shapeTree6.Append(nonVisualGroupShapeProperties6);
            shapeTree6.Append(groupShapeProperties6);
            shapeTree6.Append(shape23);
            shapeTree6.Append(shape24);
            shapeTree6.Append(shape25);

            CommonSlideDataExtensionList commonSlideDataExtensionList6 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension6 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId6 = new P14.CreationId() { Val = (UInt32Value)1781609794U };
            creationId6.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension6.Append(creationId6);

            commonSlideDataExtensionList6.Append(commonSlideDataExtension6);

            commonSlideData6.Append(shapeTree6);
            commonSlideData6.Append(commonSlideDataExtensionList6);

            ColorMapOverride colorMapOverride5 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping5 = new A.MasterColorMapping();

            colorMapOverride5.Append(masterColorMapping5);

            slideLayout4.Append(commonSlideData6);
            slideLayout4.Append(colorMapOverride5);

            slideLayoutPart4.SlideLayout = slideLayout4;
        }

        // Generates content of themePart1.
        private void GenerateThemePart1Content(ThemePart themePart1)
        {
            A.Theme theme1 = new A.Theme() { Name = "Office Theme" };
            theme1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            A.ThemeElements themeElements1 = new A.ThemeElements();

            A.ColorScheme colorScheme1 = new A.ColorScheme() { Name = "Office" };

            A.Dark1Color dark1Color1 = new A.Dark1Color();
            A.SystemColor systemColor1 = new A.SystemColor() { Val = A.SystemColorValues.WindowText, LastColor = "000000" };

            dark1Color1.Append(systemColor1);

            A.Light1Color light1Color1 = new A.Light1Color();
            A.SystemColor systemColor2 = new A.SystemColor() { Val = A.SystemColorValues.Window, LastColor = "FFFFFF" };

            light1Color1.Append(systemColor2);

            A.Dark2Color dark2Color1 = new A.Dark2Color();
            A.RgbColorModelHex rgbColorModelHex1 = new A.RgbColorModelHex() { Val = "1F497D" };

            dark2Color1.Append(rgbColorModelHex1);

            A.Light2Color light2Color1 = new A.Light2Color();
            A.RgbColorModelHex rgbColorModelHex2 = new A.RgbColorModelHex() { Val = "EEECE1" };

            light2Color1.Append(rgbColorModelHex2);

            A.Accent1Color accent1Color1 = new A.Accent1Color();
            A.RgbColorModelHex rgbColorModelHex3 = new A.RgbColorModelHex() { Val = "4F81BD" };

            accent1Color1.Append(rgbColorModelHex3);

            A.Accent2Color accent2Color1 = new A.Accent2Color();
            A.RgbColorModelHex rgbColorModelHex4 = new A.RgbColorModelHex() { Val = "C0504D" };

            accent2Color1.Append(rgbColorModelHex4);

            A.Accent3Color accent3Color1 = new A.Accent3Color();
            A.RgbColorModelHex rgbColorModelHex5 = new A.RgbColorModelHex() { Val = "9BBB59" };

            accent3Color1.Append(rgbColorModelHex5);

            A.Accent4Color accent4Color1 = new A.Accent4Color();
            A.RgbColorModelHex rgbColorModelHex6 = new A.RgbColorModelHex() { Val = "8064A2" };

            accent4Color1.Append(rgbColorModelHex6);

            A.Accent5Color accent5Color1 = new A.Accent5Color();
            A.RgbColorModelHex rgbColorModelHex7 = new A.RgbColorModelHex() { Val = "4BACC6" };

            accent5Color1.Append(rgbColorModelHex7);

            A.Accent6Color accent6Color1 = new A.Accent6Color();
            A.RgbColorModelHex rgbColorModelHex8 = new A.RgbColorModelHex() { Val = "F79646" };

            accent6Color1.Append(rgbColorModelHex8);

            A.Hyperlink hyperlink1 = new A.Hyperlink();
            A.RgbColorModelHex rgbColorModelHex9 = new A.RgbColorModelHex() { Val = "0000FF" };

            hyperlink1.Append(rgbColorModelHex9);

            A.FollowedHyperlinkColor followedHyperlinkColor1 = new A.FollowedHyperlinkColor();
            A.RgbColorModelHex rgbColorModelHex10 = new A.RgbColorModelHex() { Val = "800080" };

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

            A.FontScheme fontScheme1 = new A.FontScheme() { Name = "Office" };

            A.MajorFont majorFont1 = new A.MajorFont();
            A.LatinFont latinFont29 = new A.LatinFont() { Typeface = "Calibri" };
            A.EastAsianFont eastAsianFont29 = new A.EastAsianFont() { Typeface = "" };
            A.ComplexScriptFont complexScriptFont29 = new A.ComplexScriptFont() { Typeface = "" };
            A.SupplementalFont supplementalFont1 = new A.SupplementalFont() { Script = "Jpan", Typeface = "ＭＳ Ｐゴシック" };
            A.SupplementalFont supplementalFont2 = new A.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" };
            A.SupplementalFont supplementalFont3 = new A.SupplementalFont() { Script = "Hans", Typeface = "宋体" };
            A.SupplementalFont supplementalFont4 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };
            A.SupplementalFont supplementalFont5 = new A.SupplementalFont() { Script = "Arab", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont6 = new A.SupplementalFont() { Script = "Hebr", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont7 = new A.SupplementalFont() { Script = "Thai", Typeface = "Angsana New" };
            A.SupplementalFont supplementalFont8 = new A.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" };
            A.SupplementalFont supplementalFont9 = new A.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" };
            A.SupplementalFont supplementalFont10 = new A.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" };
            A.SupplementalFont supplementalFont11 = new A.SupplementalFont() { Script = "Khmr", Typeface = "MoolBoran" };
            A.SupplementalFont supplementalFont12 = new A.SupplementalFont() { Script = "Knda", Typeface = "Tunga" };
            A.SupplementalFont supplementalFont13 = new A.SupplementalFont() { Script = "Guru", Typeface = "Raavi" };
            A.SupplementalFont supplementalFont14 = new A.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" };
            A.SupplementalFont supplementalFont15 = new A.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" };
            A.SupplementalFont supplementalFont16 = new A.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" };
            A.SupplementalFont supplementalFont17 = new A.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" };
            A.SupplementalFont supplementalFont18 = new A.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" };
            A.SupplementalFont supplementalFont19 = new A.SupplementalFont() { Script = "Deva", Typeface = "Mangal" };
            A.SupplementalFont supplementalFont20 = new A.SupplementalFont() { Script = "Telu", Typeface = "Gautami" };
            A.SupplementalFont supplementalFont21 = new A.SupplementalFont() { Script = "Taml", Typeface = "Latha" };
            A.SupplementalFont supplementalFont22 = new A.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" };
            A.SupplementalFont supplementalFont23 = new A.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" };
            A.SupplementalFont supplementalFont24 = new A.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" };
            A.SupplementalFont supplementalFont25 = new A.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" };
            A.SupplementalFont supplementalFont26 = new A.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" };
            A.SupplementalFont supplementalFont27 = new A.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" };
            A.SupplementalFont supplementalFont28 = new A.SupplementalFont() { Script = "Viet", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont29 = new A.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" };
            A.SupplementalFont supplementalFont30 = new A.SupplementalFont() { Script = "Geor", Typeface = "Sylfaen" };

            majorFont1.Append(latinFont29);
            majorFont1.Append(eastAsianFont29);
            majorFont1.Append(complexScriptFont29);
            majorFont1.Append(supplementalFont1);
            majorFont1.Append(supplementalFont2);
            majorFont1.Append(supplementalFont3);
            majorFont1.Append(supplementalFont4);
            majorFont1.Append(supplementalFont5);
            majorFont1.Append(supplementalFont6);
            majorFont1.Append(supplementalFont7);
            majorFont1.Append(supplementalFont8);
            majorFont1.Append(supplementalFont9);
            majorFont1.Append(supplementalFont10);
            majorFont1.Append(supplementalFont11);
            majorFont1.Append(supplementalFont12);
            majorFont1.Append(supplementalFont13);
            majorFont1.Append(supplementalFont14);
            majorFont1.Append(supplementalFont15);
            majorFont1.Append(supplementalFont16);
            majorFont1.Append(supplementalFont17);
            majorFont1.Append(supplementalFont18);
            majorFont1.Append(supplementalFont19);
            majorFont1.Append(supplementalFont20);
            majorFont1.Append(supplementalFont21);
            majorFont1.Append(supplementalFont22);
            majorFont1.Append(supplementalFont23);
            majorFont1.Append(supplementalFont24);
            majorFont1.Append(supplementalFont25);
            majorFont1.Append(supplementalFont26);
            majorFont1.Append(supplementalFont27);
            majorFont1.Append(supplementalFont28);
            majorFont1.Append(supplementalFont29);
            majorFont1.Append(supplementalFont30);

            A.MinorFont minorFont1 = new A.MinorFont();
            A.LatinFont latinFont30 = new A.LatinFont() { Typeface = "Calibri" };
            A.EastAsianFont eastAsianFont30 = new A.EastAsianFont() { Typeface = "" };
            A.ComplexScriptFont complexScriptFont30 = new A.ComplexScriptFont() { Typeface = "" };
            A.SupplementalFont supplementalFont31 = new A.SupplementalFont() { Script = "Jpan", Typeface = "ＭＳ Ｐゴシック" };
            A.SupplementalFont supplementalFont32 = new A.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" };
            A.SupplementalFont supplementalFont33 = new A.SupplementalFont() { Script = "Hans", Typeface = "宋体" };
            A.SupplementalFont supplementalFont34 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };
            A.SupplementalFont supplementalFont35 = new A.SupplementalFont() { Script = "Arab", Typeface = "Arial" };
            A.SupplementalFont supplementalFont36 = new A.SupplementalFont() { Script = "Hebr", Typeface = "Arial" };
            A.SupplementalFont supplementalFont37 = new A.SupplementalFont() { Script = "Thai", Typeface = "Cordia New" };
            A.SupplementalFont supplementalFont38 = new A.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" };
            A.SupplementalFont supplementalFont39 = new A.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" };
            A.SupplementalFont supplementalFont40 = new A.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" };
            A.SupplementalFont supplementalFont41 = new A.SupplementalFont() { Script = "Khmr", Typeface = "DaunPenh" };
            A.SupplementalFont supplementalFont42 = new A.SupplementalFont() { Script = "Knda", Typeface = "Tunga" };
            A.SupplementalFont supplementalFont43 = new A.SupplementalFont() { Script = "Guru", Typeface = "Raavi" };
            A.SupplementalFont supplementalFont44 = new A.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" };
            A.SupplementalFont supplementalFont45 = new A.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" };
            A.SupplementalFont supplementalFont46 = new A.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" };
            A.SupplementalFont supplementalFont47 = new A.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" };
            A.SupplementalFont supplementalFont48 = new A.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" };
            A.SupplementalFont supplementalFont49 = new A.SupplementalFont() { Script = "Deva", Typeface = "Mangal" };
            A.SupplementalFont supplementalFont50 = new A.SupplementalFont() { Script = "Telu", Typeface = "Gautami" };
            A.SupplementalFont supplementalFont51 = new A.SupplementalFont() { Script = "Taml", Typeface = "Latha" };
            A.SupplementalFont supplementalFont52 = new A.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" };
            A.SupplementalFont supplementalFont53 = new A.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" };
            A.SupplementalFont supplementalFont54 = new A.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" };
            A.SupplementalFont supplementalFont55 = new A.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" };
            A.SupplementalFont supplementalFont56 = new A.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" };
            A.SupplementalFont supplementalFont57 = new A.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" };
            A.SupplementalFont supplementalFont58 = new A.SupplementalFont() { Script = "Viet", Typeface = "Arial" };
            A.SupplementalFont supplementalFont59 = new A.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" };
            A.SupplementalFont supplementalFont60 = new A.SupplementalFont() { Script = "Geor", Typeface = "Sylfaen" };

            minorFont1.Append(latinFont30);
            minorFont1.Append(eastAsianFont30);
            minorFont1.Append(complexScriptFont30);
            minorFont1.Append(supplementalFont31);
            minorFont1.Append(supplementalFont32);
            minorFont1.Append(supplementalFont33);
            minorFont1.Append(supplementalFont34);
            minorFont1.Append(supplementalFont35);
            minorFont1.Append(supplementalFont36);
            minorFont1.Append(supplementalFont37);
            minorFont1.Append(supplementalFont38);
            minorFont1.Append(supplementalFont39);
            minorFont1.Append(supplementalFont40);
            minorFont1.Append(supplementalFont41);
            minorFont1.Append(supplementalFont42);
            minorFont1.Append(supplementalFont43);
            minorFont1.Append(supplementalFont44);
            minorFont1.Append(supplementalFont45);
            minorFont1.Append(supplementalFont46);
            minorFont1.Append(supplementalFont47);
            minorFont1.Append(supplementalFont48);
            minorFont1.Append(supplementalFont49);
            minorFont1.Append(supplementalFont50);
            minorFont1.Append(supplementalFont51);
            minorFont1.Append(supplementalFont52);
            minorFont1.Append(supplementalFont53);
            minorFont1.Append(supplementalFont54);
            minorFont1.Append(supplementalFont55);
            minorFont1.Append(supplementalFont56);
            minorFont1.Append(supplementalFont57);
            minorFont1.Append(supplementalFont58);
            minorFont1.Append(supplementalFont59);
            minorFont1.Append(supplementalFont60);

            fontScheme1.Append(majorFont1);
            fontScheme1.Append(minorFont1);

            A.FormatScheme formatScheme1 = new A.FormatScheme() { Name = "Office" };

            A.FillStyleList fillStyleList1 = new A.FillStyleList();

            A.SolidFill solidFill58 = new A.SolidFill();
            A.SchemeColor schemeColor64 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill58.Append(schemeColor64);

            A.GradientFill gradientFill1 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList1 = new A.GradientStopList();

            A.GradientStop gradientStop1 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor65 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint16 = new A.Tint() { Val = 50000 };
            A.SaturationModulation saturationModulation1 = new A.SaturationModulation() { Val = 300000 };

            schemeColor65.Append(tint16);
            schemeColor65.Append(saturationModulation1);

            gradientStop1.Append(schemeColor65);

            A.GradientStop gradientStop2 = new A.GradientStop() { Position = 35000 };

            A.SchemeColor schemeColor66 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint17 = new A.Tint() { Val = 37000 };
            A.SaturationModulation saturationModulation2 = new A.SaturationModulation() { Val = 300000 };

            schemeColor66.Append(tint17);
            schemeColor66.Append(saturationModulation2);

            gradientStop2.Append(schemeColor66);

            A.GradientStop gradientStop3 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor67 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint18 = new A.Tint() { Val = 15000 };
            A.SaturationModulation saturationModulation3 = new A.SaturationModulation() { Val = 350000 };

            schemeColor67.Append(tint18);
            schemeColor67.Append(saturationModulation3);

            gradientStop3.Append(schemeColor67);

            gradientStopList1.Append(gradientStop1);
            gradientStopList1.Append(gradientStop2);
            gradientStopList1.Append(gradientStop3);
            A.LinearGradientFill linearGradientFill1 = new A.LinearGradientFill() { Angle = 16200000, Scaled = true };

            gradientFill1.Append(gradientStopList1);
            gradientFill1.Append(linearGradientFill1);

            A.GradientFill gradientFill2 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList2 = new A.GradientStopList();

            A.GradientStop gradientStop4 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor68 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade1 = new A.Shade() { Val = 51000 };
            A.SaturationModulation saturationModulation4 = new A.SaturationModulation() { Val = 130000 };

            schemeColor68.Append(shade1);
            schemeColor68.Append(saturationModulation4);

            gradientStop4.Append(schemeColor68);

            A.GradientStop gradientStop5 = new A.GradientStop() { Position = 80000 };

            A.SchemeColor schemeColor69 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade2 = new A.Shade() { Val = 93000 };
            A.SaturationModulation saturationModulation5 = new A.SaturationModulation() { Val = 130000 };

            schemeColor69.Append(shade2);
            schemeColor69.Append(saturationModulation5);

            gradientStop5.Append(schemeColor69);

            A.GradientStop gradientStop6 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor70 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade3 = new A.Shade() { Val = 94000 };
            A.SaturationModulation saturationModulation6 = new A.SaturationModulation() { Val = 135000 };

            schemeColor70.Append(shade3);
            schemeColor70.Append(saturationModulation6);

            gradientStop6.Append(schemeColor70);

            gradientStopList2.Append(gradientStop4);
            gradientStopList2.Append(gradientStop5);
            gradientStopList2.Append(gradientStop6);
            A.LinearGradientFill linearGradientFill2 = new A.LinearGradientFill() { Angle = 16200000, Scaled = false };

            gradientFill2.Append(gradientStopList2);
            gradientFill2.Append(linearGradientFill2);

            fillStyleList1.Append(solidFill58);
            fillStyleList1.Append(gradientFill1);
            fillStyleList1.Append(gradientFill2);

            A.LineStyleList lineStyleList1 = new A.LineStyleList();

            A.Outline outline10 = new A.Outline() { Width = 9525, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill59 = new A.SolidFill();

            A.SchemeColor schemeColor71 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade4 = new A.Shade() { Val = 95000 };
            A.SaturationModulation saturationModulation7 = new A.SaturationModulation() { Val = 105000 };

            schemeColor71.Append(shade4);
            schemeColor71.Append(saturationModulation7);

            solidFill59.Append(schemeColor71);
            A.PresetDash presetDash1 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

            outline10.Append(solidFill59);
            outline10.Append(presetDash1);

            A.Outline outline11 = new A.Outline() { Width = 25400, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill60 = new A.SolidFill();
            A.SchemeColor schemeColor72 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill60.Append(schemeColor72);
            A.PresetDash presetDash2 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

            outline11.Append(solidFill60);
            outline11.Append(presetDash2);

            A.Outline outline12 = new A.Outline() { Width = 38100, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill61 = new A.SolidFill();
            A.SchemeColor schemeColor73 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill61.Append(schemeColor73);
            A.PresetDash presetDash3 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

            outline12.Append(solidFill61);
            outline12.Append(presetDash3);

            lineStyleList1.Append(outline10);
            lineStyleList1.Append(outline11);
            lineStyleList1.Append(outline12);

            A.EffectStyleList effectStyleList1 = new A.EffectStyleList();

            A.EffectStyle effectStyle1 = new A.EffectStyle();

            A.EffectList effectList1 = new A.EffectList();

            A.OuterShadow outerShadow1 = new A.OuterShadow() { BlurRadius = 40000L, Distance = 20000L, Direction = 5400000, RotateWithShape = false };

            A.RgbColorModelHex rgbColorModelHex11 = new A.RgbColorModelHex() { Val = "000000" };
            A.Alpha alpha1 = new A.Alpha() { Val = 38000 };

            rgbColorModelHex11.Append(alpha1);

            outerShadow1.Append(rgbColorModelHex11);

            effectList1.Append(outerShadow1);

            effectStyle1.Append(effectList1);

            A.EffectStyle effectStyle2 = new A.EffectStyle();

            A.EffectList effectList2 = new A.EffectList();

            A.OuterShadow outerShadow2 = new A.OuterShadow() { BlurRadius = 40000L, Distance = 23000L, Direction = 5400000, RotateWithShape = false };

            A.RgbColorModelHex rgbColorModelHex12 = new A.RgbColorModelHex() { Val = "000000" };
            A.Alpha alpha2 = new A.Alpha() { Val = 35000 };

            rgbColorModelHex12.Append(alpha2);

            outerShadow2.Append(rgbColorModelHex12);

            effectList2.Append(outerShadow2);

            effectStyle2.Append(effectList2);

            A.EffectStyle effectStyle3 = new A.EffectStyle();

            A.EffectList effectList3 = new A.EffectList();

            A.OuterShadow outerShadow3 = new A.OuterShadow() { BlurRadius = 40000L, Distance = 23000L, Direction = 5400000, RotateWithShape = false };

            A.RgbColorModelHex rgbColorModelHex13 = new A.RgbColorModelHex() { Val = "000000" };
            A.Alpha alpha3 = new A.Alpha() { Val = 35000 };

            rgbColorModelHex13.Append(alpha3);

            outerShadow3.Append(rgbColorModelHex13);

            effectList3.Append(outerShadow3);

            A.Scene3DType scene3DType1 = new A.Scene3DType();

            A.Camera camera1 = new A.Camera() { Preset = A.PresetCameraValues.OrthographicFront };
            A.Rotation rotation1 = new A.Rotation() { Latitude = 0, Longitude = 0, Revolution = 0 };

            camera1.Append(rotation1);

            A.LightRig lightRig1 = new A.LightRig() { Rig = A.LightRigValues.ThreePoints, Direction = A.LightRigDirectionValues.Top };
            A.Rotation rotation2 = new A.Rotation() { Latitude = 0, Longitude = 0, Revolution = 1200000 };

            lightRig1.Append(rotation2);

            scene3DType1.Append(camera1);
            scene3DType1.Append(lightRig1);

            A.Shape3DType shape3DType1 = new A.Shape3DType();
            A.BevelTop bevelTop1 = new A.BevelTop() { Width = 63500L, Height = 25400L };

            shape3DType1.Append(bevelTop1);

            effectStyle3.Append(effectList3);
            effectStyle3.Append(scene3DType1);
            effectStyle3.Append(shape3DType1);

            effectStyleList1.Append(effectStyle1);
            effectStyleList1.Append(effectStyle2);
            effectStyleList1.Append(effectStyle3);

            A.BackgroundFillStyleList backgroundFillStyleList1 = new A.BackgroundFillStyleList();

            A.SolidFill solidFill62 = new A.SolidFill();
            A.SchemeColor schemeColor74 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill62.Append(schemeColor74);

            A.GradientFill gradientFill3 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList3 = new A.GradientStopList();

            A.GradientStop gradientStop7 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor75 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint19 = new A.Tint() { Val = 40000 };
            A.SaturationModulation saturationModulation8 = new A.SaturationModulation() { Val = 350000 };

            schemeColor75.Append(tint19);
            schemeColor75.Append(saturationModulation8);

            gradientStop7.Append(schemeColor75);

            A.GradientStop gradientStop8 = new A.GradientStop() { Position = 40000 };

            A.SchemeColor schemeColor76 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint20 = new A.Tint() { Val = 45000 };
            A.Shade shade5 = new A.Shade() { Val = 99000 };
            A.SaturationModulation saturationModulation9 = new A.SaturationModulation() { Val = 350000 };

            schemeColor76.Append(tint20);
            schemeColor76.Append(shade5);
            schemeColor76.Append(saturationModulation9);

            gradientStop8.Append(schemeColor76);

            A.GradientStop gradientStop9 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor77 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade6 = new A.Shade() { Val = 20000 };
            A.SaturationModulation saturationModulation10 = new A.SaturationModulation() { Val = 255000 };

            schemeColor77.Append(shade6);
            schemeColor77.Append(saturationModulation10);

            gradientStop9.Append(schemeColor77);

            gradientStopList3.Append(gradientStop7);
            gradientStopList3.Append(gradientStop8);
            gradientStopList3.Append(gradientStop9);

            A.PathGradientFill pathGradientFill1 = new A.PathGradientFill() { Path = A.PathShadeValues.Circle };
            A.FillToRectangle fillToRectangle1 = new A.FillToRectangle() { Left = 50000, Top = -80000, Right = 50000, Bottom = 180000 };

            pathGradientFill1.Append(fillToRectangle1);

            gradientFill3.Append(gradientStopList3);
            gradientFill3.Append(pathGradientFill1);

            A.GradientFill gradientFill4 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList4 = new A.GradientStopList();

            A.GradientStop gradientStop10 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor78 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint21 = new A.Tint() { Val = 80000 };
            A.SaturationModulation saturationModulation11 = new A.SaturationModulation() { Val = 300000 };

            schemeColor78.Append(tint21);
            schemeColor78.Append(saturationModulation11);

            gradientStop10.Append(schemeColor78);

            A.GradientStop gradientStop11 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor79 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade7 = new A.Shade() { Val = 30000 };
            A.SaturationModulation saturationModulation12 = new A.SaturationModulation() { Val = 200000 };

            schemeColor79.Append(shade7);
            schemeColor79.Append(saturationModulation12);

            gradientStop11.Append(schemeColor79);

            gradientStopList4.Append(gradientStop10);
            gradientStopList4.Append(gradientStop11);

            A.PathGradientFill pathGradientFill2 = new A.PathGradientFill() { Path = A.PathShadeValues.Circle };
            A.FillToRectangle fillToRectangle2 = new A.FillToRectangle() { Left = 50000, Top = 50000, Right = 50000, Bottom = 50000 };

            pathGradientFill2.Append(fillToRectangle2);

            gradientFill4.Append(gradientStopList4);
            gradientFill4.Append(pathGradientFill2);

            backgroundFillStyleList1.Append(solidFill62);
            backgroundFillStyleList1.Append(gradientFill3);
            backgroundFillStyleList1.Append(gradientFill4);

            formatScheme1.Append(fillStyleList1);
            formatScheme1.Append(lineStyleList1);
            formatScheme1.Append(effectStyleList1);
            formatScheme1.Append(backgroundFillStyleList1);

            themeElements1.Append(colorScheme1);
            themeElements1.Append(fontScheme1);
            themeElements1.Append(formatScheme1);
            A.ObjectDefaults objectDefaults1 = new A.ObjectDefaults();
            A.ExtraColorSchemeList extraColorSchemeList1 = new A.ExtraColorSchemeList();

            theme1.Append(themeElements1);
            theme1.Append(objectDefaults1);
            theme1.Append(extraColorSchemeList1);

            themePart1.Theme = theme1;
        }

        // Generates content of slideLayoutPart5.
        private void GenerateSlideLayoutPart5Content(SlideLayoutPart slideLayoutPart5)
        {
            SlideLayout slideLayout5 = new SlideLayout() { Preserve = true, UserDrawn = true };
            slideLayout5.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout5.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout5.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData7 = new CommonSlideData() { Name = "Title Slide" };

            ShapeTree shapeTree7 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties7 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties33 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties7 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties33 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties7.Append(nonVisualDrawingProperties33);
            nonVisualGroupShapeProperties7.Append(nonVisualGroupShapeDrawingProperties7);
            nonVisualGroupShapeProperties7.Append(applicationNonVisualDrawingProperties33);

            GroupShapeProperties groupShapeProperties7 = new GroupShapeProperties();

            A.TransformGroup transformGroup7 = new A.TransformGroup();
            A.Offset offset18 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents18 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset7 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents7 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup7.Append(offset18);
            transformGroup7.Append(extents18);
            transformGroup7.Append(childOffset7);
            transformGroup7.Append(childExtents7);

            groupShapeProperties7.Append(transformGroup7);

            Shape shape26 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties26 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties34 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties26 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks26 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties26.Append(shapeLocks26);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties34 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape26 = new PlaceholderShape() { Type = PlaceholderValues.CenteredTitle };

            applicationNonVisualDrawingProperties34.Append(placeholderShape26);

            nonVisualShapeProperties26.Append(nonVisualDrawingProperties34);
            nonVisualShapeProperties26.Append(nonVisualShapeDrawingProperties26);
            nonVisualShapeProperties26.Append(applicationNonVisualDrawingProperties34);

            ShapeProperties shapeProperties27 = new ShapeProperties();

            A.Transform2D transform2D12 = new A.Transform2D();
            A.Offset offset19 = new A.Offset() { X = 685800L, Y = 2130425L };
            A.Extents extents19 = new A.Extents() { Cx = 7772400L, Cy = 1470025L };

            transform2D12.Append(offset19);
            transform2D12.Append(extents19);

            shapeProperties27.Append(transform2D12);

            TextBody textBody26 = new TextBody();
            A.BodyProperties bodyProperties26 = new A.BodyProperties();
            A.ListStyle listStyle26 = new A.ListStyle();

            A.Paragraph paragraph38 = new A.Paragraph();

            A.Run run23 = new A.Run();

            A.RunProperties runProperties33 = new A.RunProperties() { Language = "en-US" };
            runProperties33.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text33 = new A.Text();
            text33.Text = "Click to edit Master title style";

            run23.Append(runProperties33);
            run23.Append(text33);
            A.EndParagraphRunProperties endParagraphRunProperties24 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph38.Append(run23);
            paragraph38.Append(endParagraphRunProperties24);

            textBody26.Append(bodyProperties26);
            textBody26.Append(listStyle26);
            textBody26.Append(paragraph38);

            shape26.Append(nonVisualShapeProperties26);
            shape26.Append(shapeProperties27);
            shape26.Append(textBody26);

            Shape shape27 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties27 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties35 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Subtitle 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties27 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks27 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties27.Append(shapeLocks27);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties35 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape27 = new PlaceholderShape() { Type = PlaceholderValues.SubTitle, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties35.Append(placeholderShape27);

            nonVisualShapeProperties27.Append(nonVisualDrawingProperties35);
            nonVisualShapeProperties27.Append(nonVisualShapeDrawingProperties27);
            nonVisualShapeProperties27.Append(applicationNonVisualDrawingProperties35);

            ShapeProperties shapeProperties28 = new ShapeProperties();

            A.Transform2D transform2D13 = new A.Transform2D();
            A.Offset offset20 = new A.Offset() { X = 1371600L, Y = 3886200L };
            A.Extents extents20 = new A.Extents() { Cx = 6400800L, Cy = 1752600L };

            transform2D13.Append(offset20);
            transform2D13.Append(extents20);

            shapeProperties28.Append(transform2D13);

            TextBody textBody27 = new TextBody();
            A.BodyProperties bodyProperties27 = new A.BodyProperties();

            A.ListStyle listStyle27 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties13 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet20 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties63 = new A.DefaultRunProperties();

            A.SolidFill solidFill63 = new A.SolidFill();

            A.SchemeColor schemeColor80 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint22 = new A.Tint() { Val = 75000 };

            schemeColor80.Append(tint22);

            solidFill63.Append(schemeColor80);

            defaultRunProperties63.Append(solidFill63);

            level1ParagraphProperties13.Append(noBullet20);
            level1ParagraphProperties13.Append(defaultRunProperties63);

            A.Level2ParagraphProperties level2ParagraphProperties7 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet21 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties64 = new A.DefaultRunProperties();

            A.SolidFill solidFill64 = new A.SolidFill();

            A.SchemeColor schemeColor81 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint23 = new A.Tint() { Val = 75000 };

            schemeColor81.Append(tint23);

            solidFill64.Append(schemeColor81);

            defaultRunProperties64.Append(solidFill64);

            level2ParagraphProperties7.Append(noBullet21);
            level2ParagraphProperties7.Append(defaultRunProperties64);

            A.Level3ParagraphProperties level3ParagraphProperties7 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet22 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties65 = new A.DefaultRunProperties();

            A.SolidFill solidFill65 = new A.SolidFill();

            A.SchemeColor schemeColor82 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint24 = new A.Tint() { Val = 75000 };

            schemeColor82.Append(tint24);

            solidFill65.Append(schemeColor82);

            defaultRunProperties65.Append(solidFill65);

            level3ParagraphProperties7.Append(noBullet22);
            level3ParagraphProperties7.Append(defaultRunProperties65);

            A.Level4ParagraphProperties level4ParagraphProperties7 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet23 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties66 = new A.DefaultRunProperties();

            A.SolidFill solidFill66 = new A.SolidFill();

            A.SchemeColor schemeColor83 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint25 = new A.Tint() { Val = 75000 };

            schemeColor83.Append(tint25);

            solidFill66.Append(schemeColor83);

            defaultRunProperties66.Append(solidFill66);

            level4ParagraphProperties7.Append(noBullet23);
            level4ParagraphProperties7.Append(defaultRunProperties66);

            A.Level5ParagraphProperties level5ParagraphProperties7 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet24 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties67 = new A.DefaultRunProperties();

            A.SolidFill solidFill67 = new A.SolidFill();

            A.SchemeColor schemeColor84 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint26 = new A.Tint() { Val = 75000 };

            schemeColor84.Append(tint26);

            solidFill67.Append(schemeColor84);

            defaultRunProperties67.Append(solidFill67);

            level5ParagraphProperties7.Append(noBullet24);
            level5ParagraphProperties7.Append(defaultRunProperties67);

            A.Level6ParagraphProperties level6ParagraphProperties7 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet25 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties68 = new A.DefaultRunProperties();

            A.SolidFill solidFill68 = new A.SolidFill();

            A.SchemeColor schemeColor85 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint27 = new A.Tint() { Val = 75000 };

            schemeColor85.Append(tint27);

            solidFill68.Append(schemeColor85);

            defaultRunProperties68.Append(solidFill68);

            level6ParagraphProperties7.Append(noBullet25);
            level6ParagraphProperties7.Append(defaultRunProperties68);

            A.Level7ParagraphProperties level7ParagraphProperties7 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet26 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties69 = new A.DefaultRunProperties();

            A.SolidFill solidFill69 = new A.SolidFill();

            A.SchemeColor schemeColor86 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint28 = new A.Tint() { Val = 75000 };

            schemeColor86.Append(tint28);

            solidFill69.Append(schemeColor86);

            defaultRunProperties69.Append(solidFill69);

            level7ParagraphProperties7.Append(noBullet26);
            level7ParagraphProperties7.Append(defaultRunProperties69);

            A.Level8ParagraphProperties level8ParagraphProperties7 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet27 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties70 = new A.DefaultRunProperties();

            A.SolidFill solidFill70 = new A.SolidFill();

            A.SchemeColor schemeColor87 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint29 = new A.Tint() { Val = 75000 };

            schemeColor87.Append(tint29);

            solidFill70.Append(schemeColor87);

            defaultRunProperties70.Append(solidFill70);

            level8ParagraphProperties7.Append(noBullet27);
            level8ParagraphProperties7.Append(defaultRunProperties70);

            A.Level9ParagraphProperties level9ParagraphProperties7 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet28 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties71 = new A.DefaultRunProperties();

            A.SolidFill solidFill71 = new A.SolidFill();

            A.SchemeColor schemeColor88 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint30 = new A.Tint() { Val = 75000 };

            schemeColor88.Append(tint30);

            solidFill71.Append(schemeColor88);

            defaultRunProperties71.Append(solidFill71);

            level9ParagraphProperties7.Append(noBullet28);
            level9ParagraphProperties7.Append(defaultRunProperties71);

            listStyle27.Append(level1ParagraphProperties13);
            listStyle27.Append(level2ParagraphProperties7);
            listStyle27.Append(level3ParagraphProperties7);
            listStyle27.Append(level4ParagraphProperties7);
            listStyle27.Append(level5ParagraphProperties7);
            listStyle27.Append(level6ParagraphProperties7);
            listStyle27.Append(level7ParagraphProperties7);
            listStyle27.Append(level8ParagraphProperties7);
            listStyle27.Append(level9ParagraphProperties7);

            A.Paragraph paragraph39 = new A.Paragraph();

            A.Run run24 = new A.Run();

            A.RunProperties runProperties34 = new A.RunProperties() { Language = "en-US" };
            runProperties34.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text34 = new A.Text();
            text34.Text = "Click to edit Master subtitle style";

            run24.Append(runProperties34);
            run24.Append(text34);
            A.EndParagraphRunProperties endParagraphRunProperties25 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph39.Append(run24);
            paragraph39.Append(endParagraphRunProperties25);

            textBody27.Append(bodyProperties27);
            textBody27.Append(listStyle27);
            textBody27.Append(paragraph39);

            shape27.Append(nonVisualShapeProperties27);
            shape27.Append(shapeProperties28);
            shape27.Append(textBody27);

            Shape shape28 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties28 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties36 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Date Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties28 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks28 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties28.Append(shapeLocks28);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties36 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape28 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties36.Append(placeholderShape28);

            nonVisualShapeProperties28.Append(nonVisualDrawingProperties36);
            nonVisualShapeProperties28.Append(nonVisualShapeDrawingProperties28);
            nonVisualShapeProperties28.Append(applicationNonVisualDrawingProperties36);
            ShapeProperties shapeProperties29 = new ShapeProperties();

            TextBody textBody28 = new TextBody();
            A.BodyProperties bodyProperties28 = new A.BodyProperties();
            A.ListStyle listStyle28 = new A.ListStyle();

            A.Paragraph paragraph40 = new A.Paragraph();

            A.Field field11 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties35 = new A.RunProperties() { Language = "en-US" };
            runProperties35.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text35 = new A.Text();
            text35.Text = "7/28/2013";

            field11.Append(runProperties35);
            field11.Append(text35);
            A.EndParagraphRunProperties endParagraphRunProperties26 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph40.Append(field11);
            paragraph40.Append(endParagraphRunProperties26);

            textBody28.Append(bodyProperties28);
            textBody28.Append(listStyle28);
            textBody28.Append(paragraph40);

            shape28.Append(nonVisualShapeProperties28);
            shape28.Append(shapeProperties29);
            shape28.Append(textBody28);

            Shape shape29 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties29 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties37 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Footer Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties29 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks29 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties29.Append(shapeLocks29);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties37 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape29 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties37.Append(placeholderShape29);

            nonVisualShapeProperties29.Append(nonVisualDrawingProperties37);
            nonVisualShapeProperties29.Append(nonVisualShapeDrawingProperties29);
            nonVisualShapeProperties29.Append(applicationNonVisualDrawingProperties37);
            ShapeProperties shapeProperties30 = new ShapeProperties();

            TextBody textBody29 = new TextBody();
            A.BodyProperties bodyProperties29 = new A.BodyProperties();
            A.ListStyle listStyle29 = new A.ListStyle();

            A.Paragraph paragraph41 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties27 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph41.Append(endParagraphRunProperties27);

            textBody29.Append(bodyProperties29);
            textBody29.Append(listStyle29);
            textBody29.Append(paragraph41);

            shape29.Append(nonVisualShapeProperties29);
            shape29.Append(shapeProperties30);
            shape29.Append(textBody29);

            Shape shape30 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties30 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties38 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Slide Number Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties30 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks30 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties30.Append(shapeLocks30);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties38 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape30 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties38.Append(placeholderShape30);

            nonVisualShapeProperties30.Append(nonVisualDrawingProperties38);
            nonVisualShapeProperties30.Append(nonVisualShapeDrawingProperties30);
            nonVisualShapeProperties30.Append(applicationNonVisualDrawingProperties38);
            ShapeProperties shapeProperties31 = new ShapeProperties();

            TextBody textBody30 = new TextBody();
            A.BodyProperties bodyProperties30 = new A.BodyProperties();
            A.ListStyle listStyle30 = new A.ListStyle();

            A.Paragraph paragraph42 = new A.Paragraph();

            A.Field field12 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties36 = new A.RunProperties() { Language = "en-US" };
            runProperties36.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text36 = new A.Text();
            text36.Text = "‹#›";

            field12.Append(runProperties36);
            field12.Append(text36);
            A.EndParagraphRunProperties endParagraphRunProperties28 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph42.Append(field12);
            paragraph42.Append(endParagraphRunProperties28);

            textBody30.Append(bodyProperties30);
            textBody30.Append(listStyle30);
            textBody30.Append(paragraph42);

            shape30.Append(nonVisualShapeProperties30);
            shape30.Append(shapeProperties31);
            shape30.Append(textBody30);

            Shape shape31 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties31 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties39 = new NonVisualDrawingProperties() { Id = (UInt32Value)9U, Name = "Text Placeholder 7" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties31 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks31 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties31.Append(shapeLocks31);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties39 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape31 = new PlaceholderShape() { Type = PlaceholderValues.Body, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)13U };

            applicationNonVisualDrawingProperties39.Append(placeholderShape31);

            nonVisualShapeProperties31.Append(nonVisualDrawingProperties39);
            nonVisualShapeProperties31.Append(nonVisualShapeDrawingProperties31);
            nonVisualShapeProperties31.Append(applicationNonVisualDrawingProperties39);

            ShapeProperties shapeProperties32 = new ShapeProperties();

            A.Transform2D transform2D14 = new A.Transform2D();
            A.Offset offset21 = new A.Offset() { X = 1828800L, Y = 838200L };
            A.Extents extents21 = new A.Extents() { Cx = 2895600L, Cy = 609600L };

            transform2D14.Append(offset21);
            transform2D14.Append(extents21);

            shapeProperties32.Append(transform2D14);

            TextBody textBody31 = new TextBody();
            A.BodyProperties bodyProperties31 = new A.BodyProperties();

            A.ListStyle listStyle31 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties14 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0 };
            A.NoBullet noBullet29 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties72 = new A.DefaultRunProperties();

            level1ParagraphProperties14.Append(noBullet29);
            level1ParagraphProperties14.Append(defaultRunProperties72);

            listStyle31.Append(level1ParagraphProperties14);

            A.Paragraph paragraph43 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties18 = new A.ParagraphProperties() { Level = 0 };
            A.EndParagraphRunProperties endParagraphRunProperties29 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph43.Append(paragraphProperties18);
            paragraph43.Append(endParagraphRunProperties29);

            textBody31.Append(bodyProperties31);
            textBody31.Append(listStyle31);
            textBody31.Append(paragraph43);

            shape31.Append(nonVisualShapeProperties31);
            shape31.Append(shapeProperties32);
            shape31.Append(textBody31);

            shapeTree7.Append(nonVisualGroupShapeProperties7);
            shapeTree7.Append(groupShapeProperties7);
            shapeTree7.Append(shape26);
            shapeTree7.Append(shape27);
            shapeTree7.Append(shape28);
            shapeTree7.Append(shape29);
            shapeTree7.Append(shape30);
            shapeTree7.Append(shape31);

            CommonSlideDataExtensionList commonSlideDataExtensionList7 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension7 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId7 = new P14.CreationId() { Val = (UInt32Value)3875837434U };
            creationId7.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension7.Append(creationId7);

            commonSlideDataExtensionList7.Append(commonSlideDataExtension7);

            commonSlideData7.Append(shapeTree7);
            commonSlideData7.Append(commonSlideDataExtensionList7);

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
            SlideLayout slideLayout6 = new SlideLayout() { Type = SlideLayoutValues.TitleOnly, Preserve = true };
            slideLayout6.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout6.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout6.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData8 = new CommonSlideData() { Name = "Title Only" };

            ShapeTree shapeTree8 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties8 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties40 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties8 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties40 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties8.Append(nonVisualDrawingProperties40);
            nonVisualGroupShapeProperties8.Append(nonVisualGroupShapeDrawingProperties8);
            nonVisualGroupShapeProperties8.Append(applicationNonVisualDrawingProperties40);

            GroupShapeProperties groupShapeProperties8 = new GroupShapeProperties();

            A.TransformGroup transformGroup8 = new A.TransformGroup();
            A.Offset offset22 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents22 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset8 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents8 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup8.Append(offset22);
            transformGroup8.Append(extents22);
            transformGroup8.Append(childOffset8);
            transformGroup8.Append(childExtents8);

            groupShapeProperties8.Append(transformGroup8);

            Shape shape32 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties32 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties41 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties32 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks32 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties32.Append(shapeLocks32);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties41 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape32 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties41.Append(placeholderShape32);

            nonVisualShapeProperties32.Append(nonVisualDrawingProperties41);
            nonVisualShapeProperties32.Append(nonVisualShapeDrawingProperties32);
            nonVisualShapeProperties32.Append(applicationNonVisualDrawingProperties41);
            ShapeProperties shapeProperties33 = new ShapeProperties();

            TextBody textBody32 = new TextBody();
            A.BodyProperties bodyProperties32 = new A.BodyProperties();
            A.ListStyle listStyle32 = new A.ListStyle();

            A.Paragraph paragraph44 = new A.Paragraph();

            A.Run run25 = new A.Run();

            A.RunProperties runProperties37 = new A.RunProperties() { Language = "en-US" };
            runProperties37.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text37 = new A.Text();
            text37.Text = "Click to edit Master title style";

            run25.Append(runProperties37);
            run25.Append(text37);
            A.EndParagraphRunProperties endParagraphRunProperties30 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph44.Append(run25);
            paragraph44.Append(endParagraphRunProperties30);

            textBody32.Append(bodyProperties32);
            textBody32.Append(listStyle32);
            textBody32.Append(paragraph44);

            shape32.Append(nonVisualShapeProperties32);
            shape32.Append(shapeProperties33);
            shape32.Append(textBody32);

            Shape shape33 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties33 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties42 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Date Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties33 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks33 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties33.Append(shapeLocks33);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties42 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape33 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties42.Append(placeholderShape33);

            nonVisualShapeProperties33.Append(nonVisualDrawingProperties42);
            nonVisualShapeProperties33.Append(nonVisualShapeDrawingProperties33);
            nonVisualShapeProperties33.Append(applicationNonVisualDrawingProperties42);
            ShapeProperties shapeProperties34 = new ShapeProperties();

            TextBody textBody33 = new TextBody();
            A.BodyProperties bodyProperties33 = new A.BodyProperties();
            A.ListStyle listStyle33 = new A.ListStyle();

            A.Paragraph paragraph45 = new A.Paragraph();

            A.Field field13 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties38 = new A.RunProperties() { Language = "en-US" };
            runProperties38.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text38 = new A.Text();
            text38.Text = "7/28/2013";

            field13.Append(runProperties38);
            field13.Append(text38);
            A.EndParagraphRunProperties endParagraphRunProperties31 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph45.Append(field13);
            paragraph45.Append(endParagraphRunProperties31);

            textBody33.Append(bodyProperties33);
            textBody33.Append(listStyle33);
            textBody33.Append(paragraph45);

            shape33.Append(nonVisualShapeProperties33);
            shape33.Append(shapeProperties34);
            shape33.Append(textBody33);

            Shape shape34 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties34 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties43 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Footer Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties34 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks34 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties34.Append(shapeLocks34);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties43 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape34 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties43.Append(placeholderShape34);

            nonVisualShapeProperties34.Append(nonVisualDrawingProperties43);
            nonVisualShapeProperties34.Append(nonVisualShapeDrawingProperties34);
            nonVisualShapeProperties34.Append(applicationNonVisualDrawingProperties43);
            ShapeProperties shapeProperties35 = new ShapeProperties();

            TextBody textBody34 = new TextBody();
            A.BodyProperties bodyProperties34 = new A.BodyProperties();
            A.ListStyle listStyle34 = new A.ListStyle();

            A.Paragraph paragraph46 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties32 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph46.Append(endParagraphRunProperties32);

            textBody34.Append(bodyProperties34);
            textBody34.Append(listStyle34);
            textBody34.Append(paragraph46);

            shape34.Append(nonVisualShapeProperties34);
            shape34.Append(shapeProperties35);
            shape34.Append(textBody34);

            Shape shape35 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties35 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties44 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Slide Number Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties35 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks35 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties35.Append(shapeLocks35);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties44 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape35 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties44.Append(placeholderShape35);

            nonVisualShapeProperties35.Append(nonVisualDrawingProperties44);
            nonVisualShapeProperties35.Append(nonVisualShapeDrawingProperties35);
            nonVisualShapeProperties35.Append(applicationNonVisualDrawingProperties44);
            ShapeProperties shapeProperties36 = new ShapeProperties();

            TextBody textBody35 = new TextBody();
            A.BodyProperties bodyProperties35 = new A.BodyProperties();
            A.ListStyle listStyle35 = new A.ListStyle();

            A.Paragraph paragraph47 = new A.Paragraph();

            A.Field field14 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties39 = new A.RunProperties() { Language = "en-US" };
            runProperties39.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text39 = new A.Text();
            text39.Text = "‹#›";

            field14.Append(runProperties39);
            field14.Append(text39);
            A.EndParagraphRunProperties endParagraphRunProperties33 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph47.Append(field14);
            paragraph47.Append(endParagraphRunProperties33);

            textBody35.Append(bodyProperties35);
            textBody35.Append(listStyle35);
            textBody35.Append(paragraph47);

            shape35.Append(nonVisualShapeProperties35);
            shape35.Append(shapeProperties36);
            shape35.Append(textBody35);

            shapeTree8.Append(nonVisualGroupShapeProperties8);
            shapeTree8.Append(groupShapeProperties8);
            shapeTree8.Append(shape32);
            shapeTree8.Append(shape33);
            shapeTree8.Append(shape34);
            shapeTree8.Append(shape35);

            CommonSlideDataExtensionList commonSlideDataExtensionList8 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension8 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId8 = new P14.CreationId() { Val = (UInt32Value)687955540U };
            creationId8.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension8.Append(creationId8);

            commonSlideDataExtensionList8.Append(commonSlideDataExtension8);

            commonSlideData8.Append(shapeTree8);
            commonSlideData8.Append(commonSlideDataExtensionList8);

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
            SlideLayout slideLayout7 = new SlideLayout() { Type = SlideLayoutValues.VerticalTitleAndText, Preserve = true };
            slideLayout7.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout7.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout7.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData9 = new CommonSlideData() { Name = "Vertical Title and Text" };

            ShapeTree shapeTree9 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties9 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties45 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties9 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties45 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties9.Append(nonVisualDrawingProperties45);
            nonVisualGroupShapeProperties9.Append(nonVisualGroupShapeDrawingProperties9);
            nonVisualGroupShapeProperties9.Append(applicationNonVisualDrawingProperties45);

            GroupShapeProperties groupShapeProperties9 = new GroupShapeProperties();

            A.TransformGroup transformGroup9 = new A.TransformGroup();
            A.Offset offset23 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents23 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset9 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents9 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup9.Append(offset23);
            transformGroup9.Append(extents23);
            transformGroup9.Append(childOffset9);
            transformGroup9.Append(childExtents9);

            groupShapeProperties9.Append(transformGroup9);

            Shape shape36 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties36 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties46 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Vertical Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties36 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks36 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties36.Append(shapeLocks36);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties46 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape36 = new PlaceholderShape() { Type = PlaceholderValues.Title, Orientation = DirectionValues.Vertical };

            applicationNonVisualDrawingProperties46.Append(placeholderShape36);

            nonVisualShapeProperties36.Append(nonVisualDrawingProperties46);
            nonVisualShapeProperties36.Append(nonVisualShapeDrawingProperties36);
            nonVisualShapeProperties36.Append(applicationNonVisualDrawingProperties46);

            ShapeProperties shapeProperties37 = new ShapeProperties();

            A.Transform2D transform2D15 = new A.Transform2D();
            A.Offset offset24 = new A.Offset() { X = 6629400L, Y = 274638L };
            A.Extents extents24 = new A.Extents() { Cx = 2057400L, Cy = 5851525L };

            transform2D15.Append(offset24);
            transform2D15.Append(extents24);

            shapeProperties37.Append(transform2D15);

            TextBody textBody36 = new TextBody();
            A.BodyProperties bodyProperties36 = new A.BodyProperties() { Vertical = A.TextVerticalValues.EastAsianVetical };
            A.ListStyle listStyle36 = new A.ListStyle();

            A.Paragraph paragraph48 = new A.Paragraph();

            A.Run run26 = new A.Run();

            A.RunProperties runProperties40 = new A.RunProperties() { Language = "en-US" };
            runProperties40.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text40 = new A.Text();
            text40.Text = "Click to edit Master title style";

            run26.Append(runProperties40);
            run26.Append(text40);
            A.EndParagraphRunProperties endParagraphRunProperties34 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph48.Append(run26);
            paragraph48.Append(endParagraphRunProperties34);

            textBody36.Append(bodyProperties36);
            textBody36.Append(listStyle36);
            textBody36.Append(paragraph48);

            shape36.Append(nonVisualShapeProperties36);
            shape36.Append(shapeProperties37);
            shape36.Append(textBody36);

            Shape shape37 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties37 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties47 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Vertical Text Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties37 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks37 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties37.Append(shapeLocks37);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties47 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape37 = new PlaceholderShape() { Type = PlaceholderValues.Body, Orientation = DirectionValues.Vertical, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties47.Append(placeholderShape37);

            nonVisualShapeProperties37.Append(nonVisualDrawingProperties47);
            nonVisualShapeProperties37.Append(nonVisualShapeDrawingProperties37);
            nonVisualShapeProperties37.Append(applicationNonVisualDrawingProperties47);

            ShapeProperties shapeProperties38 = new ShapeProperties();

            A.Transform2D transform2D16 = new A.Transform2D();
            A.Offset offset25 = new A.Offset() { X = 457200L, Y = 274638L };
            A.Extents extents25 = new A.Extents() { Cx = 6019800L, Cy = 5851525L };

            transform2D16.Append(offset25);
            transform2D16.Append(extents25);

            shapeProperties38.Append(transform2D16);

            TextBody textBody37 = new TextBody();
            A.BodyProperties bodyProperties37 = new A.BodyProperties() { Vertical = A.TextVerticalValues.EastAsianVetical };
            A.ListStyle listStyle37 = new A.ListStyle();

            A.Paragraph paragraph49 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties19 = new A.ParagraphProperties() { Level = 0 };

            A.Run run27 = new A.Run();

            A.RunProperties runProperties41 = new A.RunProperties() { Language = "en-US" };
            runProperties41.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text41 = new A.Text();
            text41.Text = "Click to edit Master text styles";

            run27.Append(runProperties41);
            run27.Append(text41);

            paragraph49.Append(paragraphProperties19);
            paragraph49.Append(run27);

            A.Paragraph paragraph50 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties20 = new A.ParagraphProperties() { Level = 1 };

            A.Run run28 = new A.Run();

            A.RunProperties runProperties42 = new A.RunProperties() { Language = "en-US" };
            runProperties42.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text42 = new A.Text();
            text42.Text = "Second level";

            run28.Append(runProperties42);
            run28.Append(text42);

            paragraph50.Append(paragraphProperties20);
            paragraph50.Append(run28);

            A.Paragraph paragraph51 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties21 = new A.ParagraphProperties() { Level = 2 };

            A.Run run29 = new A.Run();

            A.RunProperties runProperties43 = new A.RunProperties() { Language = "en-US" };
            runProperties43.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text43 = new A.Text();
            text43.Text = "Third level";

            run29.Append(runProperties43);
            run29.Append(text43);

            paragraph51.Append(paragraphProperties21);
            paragraph51.Append(run29);

            A.Paragraph paragraph52 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties22 = new A.ParagraphProperties() { Level = 3 };

            A.Run run30 = new A.Run();

            A.RunProperties runProperties44 = new A.RunProperties() { Language = "en-US" };
            runProperties44.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text44 = new A.Text();
            text44.Text = "Fourth level";

            run30.Append(runProperties44);
            run30.Append(text44);

            paragraph52.Append(paragraphProperties22);
            paragraph52.Append(run30);

            A.Paragraph paragraph53 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties23 = new A.ParagraphProperties() { Level = 4 };

            A.Run run31 = new A.Run();

            A.RunProperties runProperties45 = new A.RunProperties() { Language = "en-US" };
            runProperties45.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text45 = new A.Text();
            text45.Text = "Fifth level";

            run31.Append(runProperties45);
            run31.Append(text45);
            A.EndParagraphRunProperties endParagraphRunProperties35 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph53.Append(paragraphProperties23);
            paragraph53.Append(run31);
            paragraph53.Append(endParagraphRunProperties35);

            textBody37.Append(bodyProperties37);
            textBody37.Append(listStyle37);
            textBody37.Append(paragraph49);
            textBody37.Append(paragraph50);
            textBody37.Append(paragraph51);
            textBody37.Append(paragraph52);
            textBody37.Append(paragraph53);

            shape37.Append(nonVisualShapeProperties37);
            shape37.Append(shapeProperties38);
            shape37.Append(textBody37);

            Shape shape38 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties38 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties48 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Date Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties38 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks38 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties38.Append(shapeLocks38);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties48 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape38 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties48.Append(placeholderShape38);

            nonVisualShapeProperties38.Append(nonVisualDrawingProperties48);
            nonVisualShapeProperties38.Append(nonVisualShapeDrawingProperties38);
            nonVisualShapeProperties38.Append(applicationNonVisualDrawingProperties48);
            ShapeProperties shapeProperties39 = new ShapeProperties();

            TextBody textBody38 = new TextBody();
            A.BodyProperties bodyProperties38 = new A.BodyProperties();
            A.ListStyle listStyle38 = new A.ListStyle();

            A.Paragraph paragraph54 = new A.Paragraph();

            A.Field field15 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties46 = new A.RunProperties() { Language = "en-US" };
            runProperties46.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text46 = new A.Text();
            text46.Text = "7/28/2013";

            field15.Append(runProperties46);
            field15.Append(text46);
            A.EndParagraphRunProperties endParagraphRunProperties36 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph54.Append(field15);
            paragraph54.Append(endParagraphRunProperties36);

            textBody38.Append(bodyProperties38);
            textBody38.Append(listStyle38);
            textBody38.Append(paragraph54);

            shape38.Append(nonVisualShapeProperties38);
            shape38.Append(shapeProperties39);
            shape38.Append(textBody38);

            Shape shape39 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties39 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties49 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Footer Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties39 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks39 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties39.Append(shapeLocks39);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties49 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape39 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties49.Append(placeholderShape39);

            nonVisualShapeProperties39.Append(nonVisualDrawingProperties49);
            nonVisualShapeProperties39.Append(nonVisualShapeDrawingProperties39);
            nonVisualShapeProperties39.Append(applicationNonVisualDrawingProperties49);
            ShapeProperties shapeProperties40 = new ShapeProperties();

            TextBody textBody39 = new TextBody();
            A.BodyProperties bodyProperties39 = new A.BodyProperties();
            A.ListStyle listStyle39 = new A.ListStyle();

            A.Paragraph paragraph55 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties37 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph55.Append(endParagraphRunProperties37);

            textBody39.Append(bodyProperties39);
            textBody39.Append(listStyle39);
            textBody39.Append(paragraph55);

            shape39.Append(nonVisualShapeProperties39);
            shape39.Append(shapeProperties40);
            shape39.Append(textBody39);

            Shape shape40 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties40 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties50 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Slide Number Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties40 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks40 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties40.Append(shapeLocks40);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties50 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape40 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties50.Append(placeholderShape40);

            nonVisualShapeProperties40.Append(nonVisualDrawingProperties50);
            nonVisualShapeProperties40.Append(nonVisualShapeDrawingProperties40);
            nonVisualShapeProperties40.Append(applicationNonVisualDrawingProperties50);
            ShapeProperties shapeProperties41 = new ShapeProperties();

            TextBody textBody40 = new TextBody();
            A.BodyProperties bodyProperties40 = new A.BodyProperties();
            A.ListStyle listStyle40 = new A.ListStyle();

            A.Paragraph paragraph56 = new A.Paragraph();

            A.Field field16 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties47 = new A.RunProperties() { Language = "en-US" };
            runProperties47.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text47 = new A.Text();
            text47.Text = "‹#›";

            field16.Append(runProperties47);
            field16.Append(text47);
            A.EndParagraphRunProperties endParagraphRunProperties38 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph56.Append(field16);
            paragraph56.Append(endParagraphRunProperties38);

            textBody40.Append(bodyProperties40);
            textBody40.Append(listStyle40);
            textBody40.Append(paragraph56);

            shape40.Append(nonVisualShapeProperties40);
            shape40.Append(shapeProperties41);
            shape40.Append(textBody40);

            shapeTree9.Append(nonVisualGroupShapeProperties9);
            shapeTree9.Append(groupShapeProperties9);
            shapeTree9.Append(shape36);
            shapeTree9.Append(shape37);
            shapeTree9.Append(shape38);
            shapeTree9.Append(shape39);
            shapeTree9.Append(shape40);

            CommonSlideDataExtensionList commonSlideDataExtensionList9 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension9 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId9 = new P14.CreationId() { Val = (UInt32Value)3381178884U };
            creationId9.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension9.Append(creationId9);

            commonSlideDataExtensionList9.Append(commonSlideDataExtension9);

            commonSlideData9.Append(shapeTree9);
            commonSlideData9.Append(commonSlideDataExtensionList9);

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
            SlideLayout slideLayout8 = new SlideLayout() { Type = SlideLayoutValues.TwoTextAndTwoObjects, Preserve = true };
            slideLayout8.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout8.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout8.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData10 = new CommonSlideData() { Name = "Comparison" };

            ShapeTree shapeTree10 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties10 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties51 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties10 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties51 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties10.Append(nonVisualDrawingProperties51);
            nonVisualGroupShapeProperties10.Append(nonVisualGroupShapeDrawingProperties10);
            nonVisualGroupShapeProperties10.Append(applicationNonVisualDrawingProperties51);

            GroupShapeProperties groupShapeProperties10 = new GroupShapeProperties();

            A.TransformGroup transformGroup10 = new A.TransformGroup();
            A.Offset offset26 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents26 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset10 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents10 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup10.Append(offset26);
            transformGroup10.Append(extents26);
            transformGroup10.Append(childOffset10);
            transformGroup10.Append(childExtents10);

            groupShapeProperties10.Append(transformGroup10);

            Shape shape41 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties41 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties52 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties41 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks41 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties41.Append(shapeLocks41);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties52 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape41 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties52.Append(placeholderShape41);

            nonVisualShapeProperties41.Append(nonVisualDrawingProperties52);
            nonVisualShapeProperties41.Append(nonVisualShapeDrawingProperties41);
            nonVisualShapeProperties41.Append(applicationNonVisualDrawingProperties52);
            ShapeProperties shapeProperties42 = new ShapeProperties();

            TextBody textBody41 = new TextBody();
            A.BodyProperties bodyProperties41 = new A.BodyProperties();

            A.ListStyle listStyle41 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties15 = new A.Level1ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties73 = new A.DefaultRunProperties();

            level1ParagraphProperties15.Append(defaultRunProperties73);

            listStyle41.Append(level1ParagraphProperties15);

            A.Paragraph paragraph57 = new A.Paragraph();

            A.Run run32 = new A.Run();

            A.RunProperties runProperties48 = new A.RunProperties() { Language = "en-US" };
            runProperties48.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text48 = new A.Text();
            text48.Text = "Click to edit Master title style";

            run32.Append(runProperties48);
            run32.Append(text48);
            A.EndParagraphRunProperties endParagraphRunProperties39 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph57.Append(run32);
            paragraph57.Append(endParagraphRunProperties39);

            textBody41.Append(bodyProperties41);
            textBody41.Append(listStyle41);
            textBody41.Append(paragraph57);

            shape41.Append(nonVisualShapeProperties41);
            shape41.Append(shapeProperties42);
            shape41.Append(textBody41);

            Shape shape42 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties42 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties53 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Text Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties42 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks42 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties42.Append(shapeLocks42);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties53 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape42 = new PlaceholderShape() { Type = PlaceholderValues.Body, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties53.Append(placeholderShape42);

            nonVisualShapeProperties42.Append(nonVisualDrawingProperties53);
            nonVisualShapeProperties42.Append(nonVisualShapeDrawingProperties42);
            nonVisualShapeProperties42.Append(applicationNonVisualDrawingProperties53);

            ShapeProperties shapeProperties43 = new ShapeProperties();

            A.Transform2D transform2D17 = new A.Transform2D();
            A.Offset offset27 = new A.Offset() { X = 457200L, Y = 1535113L };
            A.Extents extents27 = new A.Extents() { Cx = 4040188L, Cy = 639762L };

            transform2D17.Append(offset27);
            transform2D17.Append(extents27);

            shapeProperties43.Append(transform2D17);

            TextBody textBody42 = new TextBody();
            A.BodyProperties bodyProperties42 = new A.BodyProperties() { Anchor = A.TextAnchoringTypeValues.Bottom };

            A.ListStyle listStyle42 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties16 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0 };
            A.NoBullet noBullet30 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties74 = new A.DefaultRunProperties() { FontSize = 2400, Bold = true };

            level1ParagraphProperties16.Append(noBullet30);
            level1ParagraphProperties16.Append(defaultRunProperties74);

            A.Level2ParagraphProperties level2ParagraphProperties8 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0 };
            A.NoBullet noBullet31 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties75 = new A.DefaultRunProperties() { FontSize = 2000, Bold = true };

            level2ParagraphProperties8.Append(noBullet31);
            level2ParagraphProperties8.Append(defaultRunProperties75);

            A.Level3ParagraphProperties level3ParagraphProperties8 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0 };
            A.NoBullet noBullet32 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties76 = new A.DefaultRunProperties() { FontSize = 1800, Bold = true };

            level3ParagraphProperties8.Append(noBullet32);
            level3ParagraphProperties8.Append(defaultRunProperties76);

            A.Level4ParagraphProperties level4ParagraphProperties8 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0 };
            A.NoBullet noBullet33 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties77 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level4ParagraphProperties8.Append(noBullet33);
            level4ParagraphProperties8.Append(defaultRunProperties77);

            A.Level5ParagraphProperties level5ParagraphProperties8 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0 };
            A.NoBullet noBullet34 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties78 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level5ParagraphProperties8.Append(noBullet34);
            level5ParagraphProperties8.Append(defaultRunProperties78);

            A.Level6ParagraphProperties level6ParagraphProperties8 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0 };
            A.NoBullet noBullet35 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties79 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level6ParagraphProperties8.Append(noBullet35);
            level6ParagraphProperties8.Append(defaultRunProperties79);

            A.Level7ParagraphProperties level7ParagraphProperties8 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0 };
            A.NoBullet noBullet36 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties80 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level7ParagraphProperties8.Append(noBullet36);
            level7ParagraphProperties8.Append(defaultRunProperties80);

            A.Level8ParagraphProperties level8ParagraphProperties8 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0 };
            A.NoBullet noBullet37 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties81 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level8ParagraphProperties8.Append(noBullet37);
            level8ParagraphProperties8.Append(defaultRunProperties81);

            A.Level9ParagraphProperties level9ParagraphProperties8 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0 };
            A.NoBullet noBullet38 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties82 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level9ParagraphProperties8.Append(noBullet38);
            level9ParagraphProperties8.Append(defaultRunProperties82);

            listStyle42.Append(level1ParagraphProperties16);
            listStyle42.Append(level2ParagraphProperties8);
            listStyle42.Append(level3ParagraphProperties8);
            listStyle42.Append(level4ParagraphProperties8);
            listStyle42.Append(level5ParagraphProperties8);
            listStyle42.Append(level6ParagraphProperties8);
            listStyle42.Append(level7ParagraphProperties8);
            listStyle42.Append(level8ParagraphProperties8);
            listStyle42.Append(level9ParagraphProperties8);

            A.Paragraph paragraph58 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties24 = new A.ParagraphProperties() { Level = 0 };

            A.Run run33 = new A.Run();

            A.RunProperties runProperties49 = new A.RunProperties() { Language = "en-US" };
            runProperties49.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text49 = new A.Text();
            text49.Text = "Click to edit Master text styles";

            run33.Append(runProperties49);
            run33.Append(text49);

            paragraph58.Append(paragraphProperties24);
            paragraph58.Append(run33);

            textBody42.Append(bodyProperties42);
            textBody42.Append(listStyle42);
            textBody42.Append(paragraph58);

            shape42.Append(nonVisualShapeProperties42);
            shape42.Append(shapeProperties43);
            shape42.Append(textBody42);

            Shape shape43 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties43 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties54 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Content Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties43 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks43 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties43.Append(shapeLocks43);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties54 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape43 = new PlaceholderShape() { Size = PlaceholderSizeValues.Half, Index = (UInt32Value)2U };

            applicationNonVisualDrawingProperties54.Append(placeholderShape43);

            nonVisualShapeProperties43.Append(nonVisualDrawingProperties54);
            nonVisualShapeProperties43.Append(nonVisualShapeDrawingProperties43);
            nonVisualShapeProperties43.Append(applicationNonVisualDrawingProperties54);

            ShapeProperties shapeProperties44 = new ShapeProperties();

            A.Transform2D transform2D18 = new A.Transform2D();
            A.Offset offset28 = new A.Offset() { X = 457200L, Y = 2174875L };
            A.Extents extents28 = new A.Extents() { Cx = 4040188L, Cy = 3951288L };

            transform2D18.Append(offset28);
            transform2D18.Append(extents28);

            shapeProperties44.Append(transform2D18);

            TextBody textBody43 = new TextBody();
            A.BodyProperties bodyProperties43 = new A.BodyProperties();

            A.ListStyle listStyle43 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties17 = new A.Level1ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties83 = new A.DefaultRunProperties() { FontSize = 2400 };

            level1ParagraphProperties17.Append(defaultRunProperties83);

            A.Level2ParagraphProperties level2ParagraphProperties9 = new A.Level2ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties84 = new A.DefaultRunProperties() { FontSize = 2000 };

            level2ParagraphProperties9.Append(defaultRunProperties84);

            A.Level3ParagraphProperties level3ParagraphProperties9 = new A.Level3ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties85 = new A.DefaultRunProperties() { FontSize = 1800 };

            level3ParagraphProperties9.Append(defaultRunProperties85);

            A.Level4ParagraphProperties level4ParagraphProperties9 = new A.Level4ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties86 = new A.DefaultRunProperties() { FontSize = 1600 };

            level4ParagraphProperties9.Append(defaultRunProperties86);

            A.Level5ParagraphProperties level5ParagraphProperties9 = new A.Level5ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties87 = new A.DefaultRunProperties() { FontSize = 1600 };

            level5ParagraphProperties9.Append(defaultRunProperties87);

            A.Level6ParagraphProperties level6ParagraphProperties9 = new A.Level6ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties88 = new A.DefaultRunProperties() { FontSize = 1600 };

            level6ParagraphProperties9.Append(defaultRunProperties88);

            A.Level7ParagraphProperties level7ParagraphProperties9 = new A.Level7ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties89 = new A.DefaultRunProperties() { FontSize = 1600 };

            level7ParagraphProperties9.Append(defaultRunProperties89);

            A.Level8ParagraphProperties level8ParagraphProperties9 = new A.Level8ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties90 = new A.DefaultRunProperties() { FontSize = 1600 };

            level8ParagraphProperties9.Append(defaultRunProperties90);

            A.Level9ParagraphProperties level9ParagraphProperties9 = new A.Level9ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties91 = new A.DefaultRunProperties() { FontSize = 1600 };

            level9ParagraphProperties9.Append(defaultRunProperties91);

            listStyle43.Append(level1ParagraphProperties17);
            listStyle43.Append(level2ParagraphProperties9);
            listStyle43.Append(level3ParagraphProperties9);
            listStyle43.Append(level4ParagraphProperties9);
            listStyle43.Append(level5ParagraphProperties9);
            listStyle43.Append(level6ParagraphProperties9);
            listStyle43.Append(level7ParagraphProperties9);
            listStyle43.Append(level8ParagraphProperties9);
            listStyle43.Append(level9ParagraphProperties9);

            A.Paragraph paragraph59 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties25 = new A.ParagraphProperties() { Level = 0 };

            A.Run run34 = new A.Run();

            A.RunProperties runProperties50 = new A.RunProperties() { Language = "en-US" };
            runProperties50.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text50 = new A.Text();
            text50.Text = "Click to edit Master text styles";

            run34.Append(runProperties50);
            run34.Append(text50);

            paragraph59.Append(paragraphProperties25);
            paragraph59.Append(run34);

            A.Paragraph paragraph60 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties26 = new A.ParagraphProperties() { Level = 1 };

            A.Run run35 = new A.Run();

            A.RunProperties runProperties51 = new A.RunProperties() { Language = "en-US" };
            runProperties51.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text51 = new A.Text();
            text51.Text = "Second level";

            run35.Append(runProperties51);
            run35.Append(text51);

            paragraph60.Append(paragraphProperties26);
            paragraph60.Append(run35);

            A.Paragraph paragraph61 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties27 = new A.ParagraphProperties() { Level = 2 };

            A.Run run36 = new A.Run();

            A.RunProperties runProperties52 = new A.RunProperties() { Language = "en-US" };
            runProperties52.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text52 = new A.Text();
            text52.Text = "Third level";

            run36.Append(runProperties52);
            run36.Append(text52);

            paragraph61.Append(paragraphProperties27);
            paragraph61.Append(run36);

            A.Paragraph paragraph62 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties28 = new A.ParagraphProperties() { Level = 3 };

            A.Run run37 = new A.Run();

            A.RunProperties runProperties53 = new A.RunProperties() { Language = "en-US" };
            runProperties53.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text53 = new A.Text();
            text53.Text = "Fourth level";

            run37.Append(runProperties53);
            run37.Append(text53);

            paragraph62.Append(paragraphProperties28);
            paragraph62.Append(run37);

            A.Paragraph paragraph63 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties29 = new A.ParagraphProperties() { Level = 4 };

            A.Run run38 = new A.Run();

            A.RunProperties runProperties54 = new A.RunProperties() { Language = "en-US" };
            runProperties54.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text54 = new A.Text();
            text54.Text = "Fifth level";

            run38.Append(runProperties54);
            run38.Append(text54);
            A.EndParagraphRunProperties endParagraphRunProperties40 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph63.Append(paragraphProperties29);
            paragraph63.Append(run38);
            paragraph63.Append(endParagraphRunProperties40);

            textBody43.Append(bodyProperties43);
            textBody43.Append(listStyle43);
            textBody43.Append(paragraph59);
            textBody43.Append(paragraph60);
            textBody43.Append(paragraph61);
            textBody43.Append(paragraph62);
            textBody43.Append(paragraph63);

            shape43.Append(nonVisualShapeProperties43);
            shape43.Append(shapeProperties44);
            shape43.Append(textBody43);

            Shape shape44 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties44 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties55 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Text Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties44 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks44 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties44.Append(shapeLocks44);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties55 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape44 = new PlaceholderShape() { Type = PlaceholderValues.Body, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)3U };

            applicationNonVisualDrawingProperties55.Append(placeholderShape44);

            nonVisualShapeProperties44.Append(nonVisualDrawingProperties55);
            nonVisualShapeProperties44.Append(nonVisualShapeDrawingProperties44);
            nonVisualShapeProperties44.Append(applicationNonVisualDrawingProperties55);

            ShapeProperties shapeProperties45 = new ShapeProperties();

            A.Transform2D transform2D19 = new A.Transform2D();
            A.Offset offset29 = new A.Offset() { X = 4645025L, Y = 1535113L };
            A.Extents extents29 = new A.Extents() { Cx = 4041775L, Cy = 639762L };

            transform2D19.Append(offset29);
            transform2D19.Append(extents29);

            shapeProperties45.Append(transform2D19);

            TextBody textBody44 = new TextBody();
            A.BodyProperties bodyProperties44 = new A.BodyProperties() { Anchor = A.TextAnchoringTypeValues.Bottom };

            A.ListStyle listStyle44 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties18 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0 };
            A.NoBullet noBullet39 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties92 = new A.DefaultRunProperties() { FontSize = 2400, Bold = true };

            level1ParagraphProperties18.Append(noBullet39);
            level1ParagraphProperties18.Append(defaultRunProperties92);

            A.Level2ParagraphProperties level2ParagraphProperties10 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0 };
            A.NoBullet noBullet40 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties93 = new A.DefaultRunProperties() { FontSize = 2000, Bold = true };

            level2ParagraphProperties10.Append(noBullet40);
            level2ParagraphProperties10.Append(defaultRunProperties93);

            A.Level3ParagraphProperties level3ParagraphProperties10 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0 };
            A.NoBullet noBullet41 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties94 = new A.DefaultRunProperties() { FontSize = 1800, Bold = true };

            level3ParagraphProperties10.Append(noBullet41);
            level3ParagraphProperties10.Append(defaultRunProperties94);

            A.Level4ParagraphProperties level4ParagraphProperties10 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0 };
            A.NoBullet noBullet42 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties95 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level4ParagraphProperties10.Append(noBullet42);
            level4ParagraphProperties10.Append(defaultRunProperties95);

            A.Level5ParagraphProperties level5ParagraphProperties10 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0 };
            A.NoBullet noBullet43 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties96 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level5ParagraphProperties10.Append(noBullet43);
            level5ParagraphProperties10.Append(defaultRunProperties96);

            A.Level6ParagraphProperties level6ParagraphProperties10 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0 };
            A.NoBullet noBullet44 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties97 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level6ParagraphProperties10.Append(noBullet44);
            level6ParagraphProperties10.Append(defaultRunProperties97);

            A.Level7ParagraphProperties level7ParagraphProperties10 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0 };
            A.NoBullet noBullet45 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties98 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level7ParagraphProperties10.Append(noBullet45);
            level7ParagraphProperties10.Append(defaultRunProperties98);

            A.Level8ParagraphProperties level8ParagraphProperties10 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0 };
            A.NoBullet noBullet46 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties99 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level8ParagraphProperties10.Append(noBullet46);
            level8ParagraphProperties10.Append(defaultRunProperties99);

            A.Level9ParagraphProperties level9ParagraphProperties10 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0 };
            A.NoBullet noBullet47 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties100 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level9ParagraphProperties10.Append(noBullet47);
            level9ParagraphProperties10.Append(defaultRunProperties100);

            listStyle44.Append(level1ParagraphProperties18);
            listStyle44.Append(level2ParagraphProperties10);
            listStyle44.Append(level3ParagraphProperties10);
            listStyle44.Append(level4ParagraphProperties10);
            listStyle44.Append(level5ParagraphProperties10);
            listStyle44.Append(level6ParagraphProperties10);
            listStyle44.Append(level7ParagraphProperties10);
            listStyle44.Append(level8ParagraphProperties10);
            listStyle44.Append(level9ParagraphProperties10);

            A.Paragraph paragraph64 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties30 = new A.ParagraphProperties() { Level = 0 };

            A.Run run39 = new A.Run();

            A.RunProperties runProperties55 = new A.RunProperties() { Language = "en-US" };
            runProperties55.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text55 = new A.Text();
            text55.Text = "Click to edit Master text styles";

            run39.Append(runProperties55);
            run39.Append(text55);

            paragraph64.Append(paragraphProperties30);
            paragraph64.Append(run39);

            textBody44.Append(bodyProperties44);
            textBody44.Append(listStyle44);
            textBody44.Append(paragraph64);

            shape44.Append(nonVisualShapeProperties44);
            shape44.Append(shapeProperties45);
            shape44.Append(textBody44);

            Shape shape45 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties45 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties56 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Content Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties45 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks45 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties45.Append(shapeLocks45);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties56 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape45 = new PlaceholderShape() { Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)4U };

            applicationNonVisualDrawingProperties56.Append(placeholderShape45);

            nonVisualShapeProperties45.Append(nonVisualDrawingProperties56);
            nonVisualShapeProperties45.Append(nonVisualShapeDrawingProperties45);
            nonVisualShapeProperties45.Append(applicationNonVisualDrawingProperties56);

            ShapeProperties shapeProperties46 = new ShapeProperties();

            A.Transform2D transform2D20 = new A.Transform2D();
            A.Offset offset30 = new A.Offset() { X = 4645025L, Y = 2174875L };
            A.Extents extents30 = new A.Extents() { Cx = 4041775L, Cy = 3951288L };

            transform2D20.Append(offset30);
            transform2D20.Append(extents30);

            shapeProperties46.Append(transform2D20);

            TextBody textBody45 = new TextBody();
            A.BodyProperties bodyProperties45 = new A.BodyProperties();

            A.ListStyle listStyle45 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties19 = new A.Level1ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties101 = new A.DefaultRunProperties() { FontSize = 2400 };

            level1ParagraphProperties19.Append(defaultRunProperties101);

            A.Level2ParagraphProperties level2ParagraphProperties11 = new A.Level2ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties102 = new A.DefaultRunProperties() { FontSize = 2000 };

            level2ParagraphProperties11.Append(defaultRunProperties102);

            A.Level3ParagraphProperties level3ParagraphProperties11 = new A.Level3ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties103 = new A.DefaultRunProperties() { FontSize = 1800 };

            level3ParagraphProperties11.Append(defaultRunProperties103);

            A.Level4ParagraphProperties level4ParagraphProperties11 = new A.Level4ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties104 = new A.DefaultRunProperties() { FontSize = 1600 };

            level4ParagraphProperties11.Append(defaultRunProperties104);

            A.Level5ParagraphProperties level5ParagraphProperties11 = new A.Level5ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties105 = new A.DefaultRunProperties() { FontSize = 1600 };

            level5ParagraphProperties11.Append(defaultRunProperties105);

            A.Level6ParagraphProperties level6ParagraphProperties11 = new A.Level6ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties106 = new A.DefaultRunProperties() { FontSize = 1600 };

            level6ParagraphProperties11.Append(defaultRunProperties106);

            A.Level7ParagraphProperties level7ParagraphProperties11 = new A.Level7ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties107 = new A.DefaultRunProperties() { FontSize = 1600 };

            level7ParagraphProperties11.Append(defaultRunProperties107);

            A.Level8ParagraphProperties level8ParagraphProperties11 = new A.Level8ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties108 = new A.DefaultRunProperties() { FontSize = 1600 };

            level8ParagraphProperties11.Append(defaultRunProperties108);

            A.Level9ParagraphProperties level9ParagraphProperties11 = new A.Level9ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties109 = new A.DefaultRunProperties() { FontSize = 1600 };

            level9ParagraphProperties11.Append(defaultRunProperties109);

            listStyle45.Append(level1ParagraphProperties19);
            listStyle45.Append(level2ParagraphProperties11);
            listStyle45.Append(level3ParagraphProperties11);
            listStyle45.Append(level4ParagraphProperties11);
            listStyle45.Append(level5ParagraphProperties11);
            listStyle45.Append(level6ParagraphProperties11);
            listStyle45.Append(level7ParagraphProperties11);
            listStyle45.Append(level8ParagraphProperties11);
            listStyle45.Append(level9ParagraphProperties11);

            A.Paragraph paragraph65 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties31 = new A.ParagraphProperties() { Level = 0 };

            A.Run run40 = new A.Run();

            A.RunProperties runProperties56 = new A.RunProperties() { Language = "en-US" };
            runProperties56.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text56 = new A.Text();
            text56.Text = "Click to edit Master text styles";

            run40.Append(runProperties56);
            run40.Append(text56);

            paragraph65.Append(paragraphProperties31);
            paragraph65.Append(run40);

            A.Paragraph paragraph66 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties32 = new A.ParagraphProperties() { Level = 1 };

            A.Run run41 = new A.Run();

            A.RunProperties runProperties57 = new A.RunProperties() { Language = "en-US" };
            runProperties57.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text57 = new A.Text();
            text57.Text = "Second level";

            run41.Append(runProperties57);
            run41.Append(text57);

            paragraph66.Append(paragraphProperties32);
            paragraph66.Append(run41);

            A.Paragraph paragraph67 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties33 = new A.ParagraphProperties() { Level = 2 };

            A.Run run42 = new A.Run();

            A.RunProperties runProperties58 = new A.RunProperties() { Language = "en-US" };
            runProperties58.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text58 = new A.Text();
            text58.Text = "Third level";

            run42.Append(runProperties58);
            run42.Append(text58);

            paragraph67.Append(paragraphProperties33);
            paragraph67.Append(run42);

            A.Paragraph paragraph68 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties34 = new A.ParagraphProperties() { Level = 3 };

            A.Run run43 = new A.Run();

            A.RunProperties runProperties59 = new A.RunProperties() { Language = "en-US" };
            runProperties59.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text59 = new A.Text();
            text59.Text = "Fourth level";

            run43.Append(runProperties59);
            run43.Append(text59);

            paragraph68.Append(paragraphProperties34);
            paragraph68.Append(run43);

            A.Paragraph paragraph69 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties35 = new A.ParagraphProperties() { Level = 4 };

            A.Run run44 = new A.Run();

            A.RunProperties runProperties60 = new A.RunProperties() { Language = "en-US" };
            runProperties60.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text60 = new A.Text();
            text60.Text = "Fifth level";

            run44.Append(runProperties60);
            run44.Append(text60);
            A.EndParagraphRunProperties endParagraphRunProperties41 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph69.Append(paragraphProperties35);
            paragraph69.Append(run44);
            paragraph69.Append(endParagraphRunProperties41);

            textBody45.Append(bodyProperties45);
            textBody45.Append(listStyle45);
            textBody45.Append(paragraph65);
            textBody45.Append(paragraph66);
            textBody45.Append(paragraph67);
            textBody45.Append(paragraph68);
            textBody45.Append(paragraph69);

            shape45.Append(nonVisualShapeProperties45);
            shape45.Append(shapeProperties46);
            shape45.Append(textBody45);

            Shape shape46 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties46 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties57 = new NonVisualDrawingProperties() { Id = (UInt32Value)7U, Name = "Date Placeholder 6" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties46 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks46 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties46.Append(shapeLocks46);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties57 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape46 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties57.Append(placeholderShape46);

            nonVisualShapeProperties46.Append(nonVisualDrawingProperties57);
            nonVisualShapeProperties46.Append(nonVisualShapeDrawingProperties46);
            nonVisualShapeProperties46.Append(applicationNonVisualDrawingProperties57);
            ShapeProperties shapeProperties47 = new ShapeProperties();

            TextBody textBody46 = new TextBody();
            A.BodyProperties bodyProperties46 = new A.BodyProperties();
            A.ListStyle listStyle46 = new A.ListStyle();

            A.Paragraph paragraph70 = new A.Paragraph();

            A.Field field17 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties61 = new A.RunProperties() { Language = "en-US" };
            runProperties61.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text61 = new A.Text();
            text61.Text = "7/28/2013";

            field17.Append(runProperties61);
            field17.Append(text61);
            A.EndParagraphRunProperties endParagraphRunProperties42 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph70.Append(field17);
            paragraph70.Append(endParagraphRunProperties42);

            textBody46.Append(bodyProperties46);
            textBody46.Append(listStyle46);
            textBody46.Append(paragraph70);

            shape46.Append(nonVisualShapeProperties46);
            shape46.Append(shapeProperties47);
            shape46.Append(textBody46);

            Shape shape47 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties47 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties58 = new NonVisualDrawingProperties() { Id = (UInt32Value)8U, Name = "Footer Placeholder 7" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties47 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks47 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties47.Append(shapeLocks47);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties58 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape47 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties58.Append(placeholderShape47);

            nonVisualShapeProperties47.Append(nonVisualDrawingProperties58);
            nonVisualShapeProperties47.Append(nonVisualShapeDrawingProperties47);
            nonVisualShapeProperties47.Append(applicationNonVisualDrawingProperties58);
            ShapeProperties shapeProperties48 = new ShapeProperties();

            TextBody textBody47 = new TextBody();
            A.BodyProperties bodyProperties47 = new A.BodyProperties();
            A.ListStyle listStyle47 = new A.ListStyle();

            A.Paragraph paragraph71 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties43 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph71.Append(endParagraphRunProperties43);

            textBody47.Append(bodyProperties47);
            textBody47.Append(listStyle47);
            textBody47.Append(paragraph71);

            shape47.Append(nonVisualShapeProperties47);
            shape47.Append(shapeProperties48);
            shape47.Append(textBody47);

            Shape shape48 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties48 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties59 = new NonVisualDrawingProperties() { Id = (UInt32Value)9U, Name = "Slide Number Placeholder 8" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties48 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks48 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties48.Append(shapeLocks48);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties59 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape48 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties59.Append(placeholderShape48);

            nonVisualShapeProperties48.Append(nonVisualDrawingProperties59);
            nonVisualShapeProperties48.Append(nonVisualShapeDrawingProperties48);
            nonVisualShapeProperties48.Append(applicationNonVisualDrawingProperties59);
            ShapeProperties shapeProperties49 = new ShapeProperties();

            TextBody textBody48 = new TextBody();
            A.BodyProperties bodyProperties48 = new A.BodyProperties();
            A.ListStyle listStyle48 = new A.ListStyle();

            A.Paragraph paragraph72 = new A.Paragraph();

            A.Field field18 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties62 = new A.RunProperties() { Language = "en-US" };
            runProperties62.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text62 = new A.Text();
            text62.Text = "‹#›";

            field18.Append(runProperties62);
            field18.Append(text62);
            A.EndParagraphRunProperties endParagraphRunProperties44 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph72.Append(field18);
            paragraph72.Append(endParagraphRunProperties44);

            textBody48.Append(bodyProperties48);
            textBody48.Append(listStyle48);
            textBody48.Append(paragraph72);

            shape48.Append(nonVisualShapeProperties48);
            shape48.Append(shapeProperties49);
            shape48.Append(textBody48);

            shapeTree10.Append(nonVisualGroupShapeProperties10);
            shapeTree10.Append(groupShapeProperties10);
            shapeTree10.Append(shape41);
            shapeTree10.Append(shape42);
            shapeTree10.Append(shape43);
            shapeTree10.Append(shape44);
            shapeTree10.Append(shape45);
            shapeTree10.Append(shape46);
            shapeTree10.Append(shape47);
            shapeTree10.Append(shape48);

            CommonSlideDataExtensionList commonSlideDataExtensionList10 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension10 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId10 = new P14.CreationId() { Val = (UInt32Value)752897712U };
            creationId10.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension10.Append(creationId10);

            commonSlideDataExtensionList10.Append(commonSlideDataExtension10);

            commonSlideData10.Append(shapeTree10);
            commonSlideData10.Append(commonSlideDataExtensionList10);

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
            SlideLayout slideLayout9 = new SlideLayout() { Type = SlideLayoutValues.VerticalText, Preserve = true };
            slideLayout9.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout9.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout9.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData11 = new CommonSlideData() { Name = "Title and Vertical Text" };

            ShapeTree shapeTree11 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties11 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties60 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties11 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties60 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties11.Append(nonVisualDrawingProperties60);
            nonVisualGroupShapeProperties11.Append(nonVisualGroupShapeDrawingProperties11);
            nonVisualGroupShapeProperties11.Append(applicationNonVisualDrawingProperties60);

            GroupShapeProperties groupShapeProperties11 = new GroupShapeProperties();

            A.TransformGroup transformGroup11 = new A.TransformGroup();
            A.Offset offset31 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents31 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset11 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents11 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup11.Append(offset31);
            transformGroup11.Append(extents31);
            transformGroup11.Append(childOffset11);
            transformGroup11.Append(childExtents11);

            groupShapeProperties11.Append(transformGroup11);

            Shape shape49 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties49 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties61 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties49 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks49 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties49.Append(shapeLocks49);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties61 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape49 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties61.Append(placeholderShape49);

            nonVisualShapeProperties49.Append(nonVisualDrawingProperties61);
            nonVisualShapeProperties49.Append(nonVisualShapeDrawingProperties49);
            nonVisualShapeProperties49.Append(applicationNonVisualDrawingProperties61);
            ShapeProperties shapeProperties50 = new ShapeProperties();

            TextBody textBody49 = new TextBody();
            A.BodyProperties bodyProperties49 = new A.BodyProperties();
            A.ListStyle listStyle49 = new A.ListStyle();

            A.Paragraph paragraph73 = new A.Paragraph();

            A.Run run45 = new A.Run();

            A.RunProperties runProperties63 = new A.RunProperties() { Language = "en-US" };
            runProperties63.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text63 = new A.Text();
            text63.Text = "Click to edit Master title style";

            run45.Append(runProperties63);
            run45.Append(text63);
            A.EndParagraphRunProperties endParagraphRunProperties45 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph73.Append(run45);
            paragraph73.Append(endParagraphRunProperties45);

            textBody49.Append(bodyProperties49);
            textBody49.Append(listStyle49);
            textBody49.Append(paragraph73);

            shape49.Append(nonVisualShapeProperties49);
            shape49.Append(shapeProperties50);
            shape49.Append(textBody49);

            Shape shape50 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties50 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties62 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Vertical Text Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties50 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks50 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties50.Append(shapeLocks50);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties62 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape50 = new PlaceholderShape() { Type = PlaceholderValues.Body, Orientation = DirectionValues.Vertical, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties62.Append(placeholderShape50);

            nonVisualShapeProperties50.Append(nonVisualDrawingProperties62);
            nonVisualShapeProperties50.Append(nonVisualShapeDrawingProperties50);
            nonVisualShapeProperties50.Append(applicationNonVisualDrawingProperties62);
            ShapeProperties shapeProperties51 = new ShapeProperties();

            TextBody textBody50 = new TextBody();
            A.BodyProperties bodyProperties50 = new A.BodyProperties() { Vertical = A.TextVerticalValues.EastAsianVetical };
            A.ListStyle listStyle50 = new A.ListStyle();

            A.Paragraph paragraph74 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties36 = new A.ParagraphProperties() { Level = 0 };

            A.Run run46 = new A.Run();

            A.RunProperties runProperties64 = new A.RunProperties() { Language = "en-US" };
            runProperties64.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text64 = new A.Text();
            text64.Text = "Click to edit Master text styles";

            run46.Append(runProperties64);
            run46.Append(text64);

            paragraph74.Append(paragraphProperties36);
            paragraph74.Append(run46);

            A.Paragraph paragraph75 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties37 = new A.ParagraphProperties() { Level = 1 };

            A.Run run47 = new A.Run();

            A.RunProperties runProperties65 = new A.RunProperties() { Language = "en-US" };
            runProperties65.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text65 = new A.Text();
            text65.Text = "Second level";

            run47.Append(runProperties65);
            run47.Append(text65);

            paragraph75.Append(paragraphProperties37);
            paragraph75.Append(run47);

            A.Paragraph paragraph76 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties38 = new A.ParagraphProperties() { Level = 2 };

            A.Run run48 = new A.Run();

            A.RunProperties runProperties66 = new A.RunProperties() { Language = "en-US" };
            runProperties66.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text66 = new A.Text();
            text66.Text = "Third level";

            run48.Append(runProperties66);
            run48.Append(text66);

            paragraph76.Append(paragraphProperties38);
            paragraph76.Append(run48);

            A.Paragraph paragraph77 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties39 = new A.ParagraphProperties() { Level = 3 };

            A.Run run49 = new A.Run();

            A.RunProperties runProperties67 = new A.RunProperties() { Language = "en-US" };
            runProperties67.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text67 = new A.Text();
            text67.Text = "Fourth level";

            run49.Append(runProperties67);
            run49.Append(text67);

            paragraph77.Append(paragraphProperties39);
            paragraph77.Append(run49);

            A.Paragraph paragraph78 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties40 = new A.ParagraphProperties() { Level = 4 };

            A.Run run50 = new A.Run();

            A.RunProperties runProperties68 = new A.RunProperties() { Language = "en-US" };
            runProperties68.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text68 = new A.Text();
            text68.Text = "Fifth level";

            run50.Append(runProperties68);
            run50.Append(text68);
            A.EndParagraphRunProperties endParagraphRunProperties46 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph78.Append(paragraphProperties40);
            paragraph78.Append(run50);
            paragraph78.Append(endParagraphRunProperties46);

            textBody50.Append(bodyProperties50);
            textBody50.Append(listStyle50);
            textBody50.Append(paragraph74);
            textBody50.Append(paragraph75);
            textBody50.Append(paragraph76);
            textBody50.Append(paragraph77);
            textBody50.Append(paragraph78);

            shape50.Append(nonVisualShapeProperties50);
            shape50.Append(shapeProperties51);
            shape50.Append(textBody50);

            Shape shape51 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties51 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties63 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Date Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties51 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks51 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties51.Append(shapeLocks51);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties63 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape51 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties63.Append(placeholderShape51);

            nonVisualShapeProperties51.Append(nonVisualDrawingProperties63);
            nonVisualShapeProperties51.Append(nonVisualShapeDrawingProperties51);
            nonVisualShapeProperties51.Append(applicationNonVisualDrawingProperties63);
            ShapeProperties shapeProperties52 = new ShapeProperties();

            TextBody textBody51 = new TextBody();
            A.BodyProperties bodyProperties51 = new A.BodyProperties();
            A.ListStyle listStyle51 = new A.ListStyle();

            A.Paragraph paragraph79 = new A.Paragraph();

            A.Field field19 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties69 = new A.RunProperties() { Language = "en-US" };
            runProperties69.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text69 = new A.Text();
            text69.Text = "7/28/2013";

            field19.Append(runProperties69);
            field19.Append(text69);
            A.EndParagraphRunProperties endParagraphRunProperties47 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph79.Append(field19);
            paragraph79.Append(endParagraphRunProperties47);

            textBody51.Append(bodyProperties51);
            textBody51.Append(listStyle51);
            textBody51.Append(paragraph79);

            shape51.Append(nonVisualShapeProperties51);
            shape51.Append(shapeProperties52);
            shape51.Append(textBody51);

            Shape shape52 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties52 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties64 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Footer Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties52 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks52 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties52.Append(shapeLocks52);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties64 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape52 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties64.Append(placeholderShape52);

            nonVisualShapeProperties52.Append(nonVisualDrawingProperties64);
            nonVisualShapeProperties52.Append(nonVisualShapeDrawingProperties52);
            nonVisualShapeProperties52.Append(applicationNonVisualDrawingProperties64);
            ShapeProperties shapeProperties53 = new ShapeProperties();

            TextBody textBody52 = new TextBody();
            A.BodyProperties bodyProperties52 = new A.BodyProperties();
            A.ListStyle listStyle52 = new A.ListStyle();

            A.Paragraph paragraph80 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties48 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph80.Append(endParagraphRunProperties48);

            textBody52.Append(bodyProperties52);
            textBody52.Append(listStyle52);
            textBody52.Append(paragraph80);

            shape52.Append(nonVisualShapeProperties52);
            shape52.Append(shapeProperties53);
            shape52.Append(textBody52);

            Shape shape53 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties53 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties65 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Slide Number Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties53 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks53 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties53.Append(shapeLocks53);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties65 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape53 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties65.Append(placeholderShape53);

            nonVisualShapeProperties53.Append(nonVisualDrawingProperties65);
            nonVisualShapeProperties53.Append(nonVisualShapeDrawingProperties53);
            nonVisualShapeProperties53.Append(applicationNonVisualDrawingProperties65);
            ShapeProperties shapeProperties54 = new ShapeProperties();

            TextBody textBody53 = new TextBody();
            A.BodyProperties bodyProperties53 = new A.BodyProperties();
            A.ListStyle listStyle53 = new A.ListStyle();

            A.Paragraph paragraph81 = new A.Paragraph();

            A.Field field20 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties70 = new A.RunProperties() { Language = "en-US" };
            runProperties70.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text70 = new A.Text();
            text70.Text = "‹#›";

            field20.Append(runProperties70);
            field20.Append(text70);
            A.EndParagraphRunProperties endParagraphRunProperties49 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph81.Append(field20);
            paragraph81.Append(endParagraphRunProperties49);

            textBody53.Append(bodyProperties53);
            textBody53.Append(listStyle53);
            textBody53.Append(paragraph81);

            shape53.Append(nonVisualShapeProperties53);
            shape53.Append(shapeProperties54);
            shape53.Append(textBody53);

            shapeTree11.Append(nonVisualGroupShapeProperties11);
            shapeTree11.Append(groupShapeProperties11);
            shapeTree11.Append(shape49);
            shapeTree11.Append(shape50);
            shapeTree11.Append(shape51);
            shapeTree11.Append(shape52);
            shapeTree11.Append(shape53);

            CommonSlideDataExtensionList commonSlideDataExtensionList11 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension11 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId11 = new P14.CreationId() { Val = (UInt32Value)1468866947U };
            creationId11.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension11.Append(creationId11);

            commonSlideDataExtensionList11.Append(commonSlideDataExtension11);

            commonSlideData11.Append(shapeTree11);
            commonSlideData11.Append(commonSlideDataExtensionList11);

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
            SlideLayout slideLayout10 = new SlideLayout() { Type = SlideLayoutValues.TwoObjects, Preserve = true };
            slideLayout10.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout10.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout10.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData12 = new CommonSlideData() { Name = "Two Content" };

            ShapeTree shapeTree12 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties12 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties66 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties12 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties66 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties12.Append(nonVisualDrawingProperties66);
            nonVisualGroupShapeProperties12.Append(nonVisualGroupShapeDrawingProperties12);
            nonVisualGroupShapeProperties12.Append(applicationNonVisualDrawingProperties66);

            GroupShapeProperties groupShapeProperties12 = new GroupShapeProperties();

            A.TransformGroup transformGroup12 = new A.TransformGroup();
            A.Offset offset32 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents32 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset12 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents12 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup12.Append(offset32);
            transformGroup12.Append(extents32);
            transformGroup12.Append(childOffset12);
            transformGroup12.Append(childExtents12);

            groupShapeProperties12.Append(transformGroup12);

            Shape shape54 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties54 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties67 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties54 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks54 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties54.Append(shapeLocks54);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties67 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape54 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties67.Append(placeholderShape54);

            nonVisualShapeProperties54.Append(nonVisualDrawingProperties67);
            nonVisualShapeProperties54.Append(nonVisualShapeDrawingProperties54);
            nonVisualShapeProperties54.Append(applicationNonVisualDrawingProperties67);
            ShapeProperties shapeProperties55 = new ShapeProperties();

            TextBody textBody54 = new TextBody();
            A.BodyProperties bodyProperties54 = new A.BodyProperties();
            A.ListStyle listStyle54 = new A.ListStyle();

            A.Paragraph paragraph82 = new A.Paragraph();

            A.Run run51 = new A.Run();

            A.RunProperties runProperties71 = new A.RunProperties() { Language = "en-US" };
            runProperties71.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text71 = new A.Text();
            text71.Text = "Click to edit Master title style";

            run51.Append(runProperties71);
            run51.Append(text71);
            A.EndParagraphRunProperties endParagraphRunProperties50 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph82.Append(run51);
            paragraph82.Append(endParagraphRunProperties50);

            textBody54.Append(bodyProperties54);
            textBody54.Append(listStyle54);
            textBody54.Append(paragraph82);

            shape54.Append(nonVisualShapeProperties54);
            shape54.Append(shapeProperties55);
            shape54.Append(textBody54);

            Shape shape55 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties55 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties68 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Content Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties55 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks55 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties55.Append(shapeLocks55);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties68 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape55 = new PlaceholderShape() { Size = PlaceholderSizeValues.Half, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties68.Append(placeholderShape55);

            nonVisualShapeProperties55.Append(nonVisualDrawingProperties68);
            nonVisualShapeProperties55.Append(nonVisualShapeDrawingProperties55);
            nonVisualShapeProperties55.Append(applicationNonVisualDrawingProperties68);

            ShapeProperties shapeProperties56 = new ShapeProperties();

            A.Transform2D transform2D21 = new A.Transform2D();
            A.Offset offset33 = new A.Offset() { X = 457200L, Y = 1600200L };
            A.Extents extents33 = new A.Extents() { Cx = 4038600L, Cy = 4525963L };

            transform2D21.Append(offset33);
            transform2D21.Append(extents33);

            shapeProperties56.Append(transform2D21);

            TextBody textBody55 = new TextBody();
            A.BodyProperties bodyProperties55 = new A.BodyProperties();

            A.ListStyle listStyle55 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties20 = new A.Level1ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties110 = new A.DefaultRunProperties() { FontSize = 2800 };

            level1ParagraphProperties20.Append(defaultRunProperties110);

            A.Level2ParagraphProperties level2ParagraphProperties12 = new A.Level2ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties111 = new A.DefaultRunProperties() { FontSize = 2400 };

            level2ParagraphProperties12.Append(defaultRunProperties111);

            A.Level3ParagraphProperties level3ParagraphProperties12 = new A.Level3ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties112 = new A.DefaultRunProperties() { FontSize = 2000 };

            level3ParagraphProperties12.Append(defaultRunProperties112);

            A.Level4ParagraphProperties level4ParagraphProperties12 = new A.Level4ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties113 = new A.DefaultRunProperties() { FontSize = 1800 };

            level4ParagraphProperties12.Append(defaultRunProperties113);

            A.Level5ParagraphProperties level5ParagraphProperties12 = new A.Level5ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties114 = new A.DefaultRunProperties() { FontSize = 1800 };

            level5ParagraphProperties12.Append(defaultRunProperties114);

            A.Level6ParagraphProperties level6ParagraphProperties12 = new A.Level6ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties115 = new A.DefaultRunProperties() { FontSize = 1800 };

            level6ParagraphProperties12.Append(defaultRunProperties115);

            A.Level7ParagraphProperties level7ParagraphProperties12 = new A.Level7ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties116 = new A.DefaultRunProperties() { FontSize = 1800 };

            level7ParagraphProperties12.Append(defaultRunProperties116);

            A.Level8ParagraphProperties level8ParagraphProperties12 = new A.Level8ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties117 = new A.DefaultRunProperties() { FontSize = 1800 };

            level8ParagraphProperties12.Append(defaultRunProperties117);

            A.Level9ParagraphProperties level9ParagraphProperties12 = new A.Level9ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties118 = new A.DefaultRunProperties() { FontSize = 1800 };

            level9ParagraphProperties12.Append(defaultRunProperties118);

            listStyle55.Append(level1ParagraphProperties20);
            listStyle55.Append(level2ParagraphProperties12);
            listStyle55.Append(level3ParagraphProperties12);
            listStyle55.Append(level4ParagraphProperties12);
            listStyle55.Append(level5ParagraphProperties12);
            listStyle55.Append(level6ParagraphProperties12);
            listStyle55.Append(level7ParagraphProperties12);
            listStyle55.Append(level8ParagraphProperties12);
            listStyle55.Append(level9ParagraphProperties12);

            A.Paragraph paragraph83 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties41 = new A.ParagraphProperties() { Level = 0 };

            A.Run run52 = new A.Run();

            A.RunProperties runProperties72 = new A.RunProperties() { Language = "en-US" };
            runProperties72.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text72 = new A.Text();
            text72.Text = "Click to edit Master text styles";

            run52.Append(runProperties72);
            run52.Append(text72);

            paragraph83.Append(paragraphProperties41);
            paragraph83.Append(run52);

            A.Paragraph paragraph84 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties42 = new A.ParagraphProperties() { Level = 1 };

            A.Run run53 = new A.Run();

            A.RunProperties runProperties73 = new A.RunProperties() { Language = "en-US" };
            runProperties73.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text73 = new A.Text();
            text73.Text = "Second level";

            run53.Append(runProperties73);
            run53.Append(text73);

            paragraph84.Append(paragraphProperties42);
            paragraph84.Append(run53);

            A.Paragraph paragraph85 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties43 = new A.ParagraphProperties() { Level = 2 };

            A.Run run54 = new A.Run();

            A.RunProperties runProperties74 = new A.RunProperties() { Language = "en-US" };
            runProperties74.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text74 = new A.Text();
            text74.Text = "Third level";

            run54.Append(runProperties74);
            run54.Append(text74);

            paragraph85.Append(paragraphProperties43);
            paragraph85.Append(run54);

            A.Paragraph paragraph86 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties44 = new A.ParagraphProperties() { Level = 3 };

            A.Run run55 = new A.Run();

            A.RunProperties runProperties75 = new A.RunProperties() { Language = "en-US" };
            runProperties75.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text75 = new A.Text();
            text75.Text = "Fourth level";

            run55.Append(runProperties75);
            run55.Append(text75);

            paragraph86.Append(paragraphProperties44);
            paragraph86.Append(run55);

            A.Paragraph paragraph87 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties45 = new A.ParagraphProperties() { Level = 4 };

            A.Run run56 = new A.Run();

            A.RunProperties runProperties76 = new A.RunProperties() { Language = "en-US" };
            runProperties76.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text76 = new A.Text();
            text76.Text = "Fifth level";

            run56.Append(runProperties76);
            run56.Append(text76);
            A.EndParagraphRunProperties endParagraphRunProperties51 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph87.Append(paragraphProperties45);
            paragraph87.Append(run56);
            paragraph87.Append(endParagraphRunProperties51);

            textBody55.Append(bodyProperties55);
            textBody55.Append(listStyle55);
            textBody55.Append(paragraph83);
            textBody55.Append(paragraph84);
            textBody55.Append(paragraph85);
            textBody55.Append(paragraph86);
            textBody55.Append(paragraph87);

            shape55.Append(nonVisualShapeProperties55);
            shape55.Append(shapeProperties56);
            shape55.Append(textBody55);

            Shape shape56 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties56 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties69 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Content Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties56 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks56 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties56.Append(shapeLocks56);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties69 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape56 = new PlaceholderShape() { Size = PlaceholderSizeValues.Half, Index = (UInt32Value)2U };

            applicationNonVisualDrawingProperties69.Append(placeholderShape56);

            nonVisualShapeProperties56.Append(nonVisualDrawingProperties69);
            nonVisualShapeProperties56.Append(nonVisualShapeDrawingProperties56);
            nonVisualShapeProperties56.Append(applicationNonVisualDrawingProperties69);

            ShapeProperties shapeProperties57 = new ShapeProperties();

            A.Transform2D transform2D22 = new A.Transform2D();
            A.Offset offset34 = new A.Offset() { X = 4648200L, Y = 1600200L };
            A.Extents extents34 = new A.Extents() { Cx = 4038600L, Cy = 4525963L };

            transform2D22.Append(offset34);
            transform2D22.Append(extents34);

            shapeProperties57.Append(transform2D22);

            TextBody textBody56 = new TextBody();
            A.BodyProperties bodyProperties56 = new A.BodyProperties();

            A.ListStyle listStyle56 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties21 = new A.Level1ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties119 = new A.DefaultRunProperties() { FontSize = 2800 };

            level1ParagraphProperties21.Append(defaultRunProperties119);

            A.Level2ParagraphProperties level2ParagraphProperties13 = new A.Level2ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties120 = new A.DefaultRunProperties() { FontSize = 2400 };

            level2ParagraphProperties13.Append(defaultRunProperties120);

            A.Level3ParagraphProperties level3ParagraphProperties13 = new A.Level3ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties121 = new A.DefaultRunProperties() { FontSize = 2000 };

            level3ParagraphProperties13.Append(defaultRunProperties121);

            A.Level4ParagraphProperties level4ParagraphProperties13 = new A.Level4ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties122 = new A.DefaultRunProperties() { FontSize = 1800 };

            level4ParagraphProperties13.Append(defaultRunProperties122);

            A.Level5ParagraphProperties level5ParagraphProperties13 = new A.Level5ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties123 = new A.DefaultRunProperties() { FontSize = 1800 };

            level5ParagraphProperties13.Append(defaultRunProperties123);

            A.Level6ParagraphProperties level6ParagraphProperties13 = new A.Level6ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties124 = new A.DefaultRunProperties() { FontSize = 1800 };

            level6ParagraphProperties13.Append(defaultRunProperties124);

            A.Level7ParagraphProperties level7ParagraphProperties13 = new A.Level7ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties125 = new A.DefaultRunProperties() { FontSize = 1800 };

            level7ParagraphProperties13.Append(defaultRunProperties125);

            A.Level8ParagraphProperties level8ParagraphProperties13 = new A.Level8ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties126 = new A.DefaultRunProperties() { FontSize = 1800 };

            level8ParagraphProperties13.Append(defaultRunProperties126);

            A.Level9ParagraphProperties level9ParagraphProperties13 = new A.Level9ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties127 = new A.DefaultRunProperties() { FontSize = 1800 };

            level9ParagraphProperties13.Append(defaultRunProperties127);

            listStyle56.Append(level1ParagraphProperties21);
            listStyle56.Append(level2ParagraphProperties13);
            listStyle56.Append(level3ParagraphProperties13);
            listStyle56.Append(level4ParagraphProperties13);
            listStyle56.Append(level5ParagraphProperties13);
            listStyle56.Append(level6ParagraphProperties13);
            listStyle56.Append(level7ParagraphProperties13);
            listStyle56.Append(level8ParagraphProperties13);
            listStyle56.Append(level9ParagraphProperties13);

            A.Paragraph paragraph88 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties46 = new A.ParagraphProperties() { Level = 0 };

            A.Run run57 = new A.Run();

            A.RunProperties runProperties77 = new A.RunProperties() { Language = "en-US" };
            runProperties77.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text77 = new A.Text();
            text77.Text = "Click to edit Master text styles";

            run57.Append(runProperties77);
            run57.Append(text77);

            paragraph88.Append(paragraphProperties46);
            paragraph88.Append(run57);

            A.Paragraph paragraph89 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties47 = new A.ParagraphProperties() { Level = 1 };

            A.Run run58 = new A.Run();

            A.RunProperties runProperties78 = new A.RunProperties() { Language = "en-US" };
            runProperties78.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text78 = new A.Text();
            text78.Text = "Second level";

            run58.Append(runProperties78);
            run58.Append(text78);

            paragraph89.Append(paragraphProperties47);
            paragraph89.Append(run58);

            A.Paragraph paragraph90 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties48 = new A.ParagraphProperties() { Level = 2 };

            A.Run run59 = new A.Run();

            A.RunProperties runProperties79 = new A.RunProperties() { Language = "en-US" };
            runProperties79.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text79 = new A.Text();
            text79.Text = "Third level";

            run59.Append(runProperties79);
            run59.Append(text79);

            paragraph90.Append(paragraphProperties48);
            paragraph90.Append(run59);

            A.Paragraph paragraph91 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties49 = new A.ParagraphProperties() { Level = 3 };

            A.Run run60 = new A.Run();

            A.RunProperties runProperties80 = new A.RunProperties() { Language = "en-US" };
            runProperties80.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text80 = new A.Text();
            text80.Text = "Fourth level";

            run60.Append(runProperties80);
            run60.Append(text80);

            paragraph91.Append(paragraphProperties49);
            paragraph91.Append(run60);

            A.Paragraph paragraph92 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties50 = new A.ParagraphProperties() { Level = 4 };

            A.Run run61 = new A.Run();

            A.RunProperties runProperties81 = new A.RunProperties() { Language = "en-US" };
            runProperties81.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text81 = new A.Text();
            text81.Text = "Fifth level";

            run61.Append(runProperties81);
            run61.Append(text81);
            A.EndParagraphRunProperties endParagraphRunProperties52 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph92.Append(paragraphProperties50);
            paragraph92.Append(run61);
            paragraph92.Append(endParagraphRunProperties52);

            textBody56.Append(bodyProperties56);
            textBody56.Append(listStyle56);
            textBody56.Append(paragraph88);
            textBody56.Append(paragraph89);
            textBody56.Append(paragraph90);
            textBody56.Append(paragraph91);
            textBody56.Append(paragraph92);

            shape56.Append(nonVisualShapeProperties56);
            shape56.Append(shapeProperties57);
            shape56.Append(textBody56);

            Shape shape57 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties57 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties70 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Date Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties57 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks57 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties57.Append(shapeLocks57);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties70 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape57 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties70.Append(placeholderShape57);

            nonVisualShapeProperties57.Append(nonVisualDrawingProperties70);
            nonVisualShapeProperties57.Append(nonVisualShapeDrawingProperties57);
            nonVisualShapeProperties57.Append(applicationNonVisualDrawingProperties70);
            ShapeProperties shapeProperties58 = new ShapeProperties();

            TextBody textBody57 = new TextBody();
            A.BodyProperties bodyProperties57 = new A.BodyProperties();
            A.ListStyle listStyle57 = new A.ListStyle();

            A.Paragraph paragraph93 = new A.Paragraph();

            A.Field field21 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties82 = new A.RunProperties() { Language = "en-US" };
            runProperties82.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text82 = new A.Text();
            text82.Text = "7/28/2013";

            field21.Append(runProperties82);
            field21.Append(text82);
            A.EndParagraphRunProperties endParagraphRunProperties53 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph93.Append(field21);
            paragraph93.Append(endParagraphRunProperties53);

            textBody57.Append(bodyProperties57);
            textBody57.Append(listStyle57);
            textBody57.Append(paragraph93);

            shape57.Append(nonVisualShapeProperties57);
            shape57.Append(shapeProperties58);
            shape57.Append(textBody57);

            Shape shape58 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties58 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties71 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Footer Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties58 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks58 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties58.Append(shapeLocks58);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties71 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape58 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties71.Append(placeholderShape58);

            nonVisualShapeProperties58.Append(nonVisualDrawingProperties71);
            nonVisualShapeProperties58.Append(nonVisualShapeDrawingProperties58);
            nonVisualShapeProperties58.Append(applicationNonVisualDrawingProperties71);
            ShapeProperties shapeProperties59 = new ShapeProperties();

            TextBody textBody58 = new TextBody();
            A.BodyProperties bodyProperties58 = new A.BodyProperties();
            A.ListStyle listStyle58 = new A.ListStyle();

            A.Paragraph paragraph94 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties54 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph94.Append(endParagraphRunProperties54);

            textBody58.Append(bodyProperties58);
            textBody58.Append(listStyle58);
            textBody58.Append(paragraph94);

            shape58.Append(nonVisualShapeProperties58);
            shape58.Append(shapeProperties59);
            shape58.Append(textBody58);

            Shape shape59 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties59 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties72 = new NonVisualDrawingProperties() { Id = (UInt32Value)7U, Name = "Slide Number Placeholder 6" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties59 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks59 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties59.Append(shapeLocks59);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties72 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape59 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties72.Append(placeholderShape59);

            nonVisualShapeProperties59.Append(nonVisualDrawingProperties72);
            nonVisualShapeProperties59.Append(nonVisualShapeDrawingProperties59);
            nonVisualShapeProperties59.Append(applicationNonVisualDrawingProperties72);
            ShapeProperties shapeProperties60 = new ShapeProperties();

            TextBody textBody59 = new TextBody();
            A.BodyProperties bodyProperties59 = new A.BodyProperties();
            A.ListStyle listStyle59 = new A.ListStyle();

            A.Paragraph paragraph95 = new A.Paragraph();

            A.Field field22 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties83 = new A.RunProperties() { Language = "en-US" };
            runProperties83.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text83 = new A.Text();
            text83.Text = "‹#›";

            field22.Append(runProperties83);
            field22.Append(text83);
            A.EndParagraphRunProperties endParagraphRunProperties55 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph95.Append(field22);
            paragraph95.Append(endParagraphRunProperties55);

            textBody59.Append(bodyProperties59);
            textBody59.Append(listStyle59);
            textBody59.Append(paragraph95);

            shape59.Append(nonVisualShapeProperties59);
            shape59.Append(shapeProperties60);
            shape59.Append(textBody59);

            shapeTree12.Append(nonVisualGroupShapeProperties12);
            shapeTree12.Append(groupShapeProperties12);
            shapeTree12.Append(shape54);
            shapeTree12.Append(shape55);
            shapeTree12.Append(shape56);
            shapeTree12.Append(shape57);
            shapeTree12.Append(shape58);
            shapeTree12.Append(shape59);

            CommonSlideDataExtensionList commonSlideDataExtensionList12 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension12 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId12 = new P14.CreationId() { Val = (UInt32Value)1940934208U };
            creationId12.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension12.Append(creationId12);

            commonSlideDataExtensionList12.Append(commonSlideDataExtension12);

            commonSlideData12.Append(shapeTree12);
            commonSlideData12.Append(commonSlideDataExtensionList12);

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
            SlideLayout slideLayout11 = new SlideLayout() { Type = SlideLayoutValues.PictureText, Preserve = true };
            slideLayout11.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout11.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout11.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData13 = new CommonSlideData() { Name = "Picture with Caption" };

            ShapeTree shapeTree13 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties13 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties73 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties13 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties73 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties13.Append(nonVisualDrawingProperties73);
            nonVisualGroupShapeProperties13.Append(nonVisualGroupShapeDrawingProperties13);
            nonVisualGroupShapeProperties13.Append(applicationNonVisualDrawingProperties73);

            GroupShapeProperties groupShapeProperties13 = new GroupShapeProperties();

            A.TransformGroup transformGroup13 = new A.TransformGroup();
            A.Offset offset35 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents35 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset13 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents13 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup13.Append(offset35);
            transformGroup13.Append(extents35);
            transformGroup13.Append(childOffset13);
            transformGroup13.Append(childExtents13);

            groupShapeProperties13.Append(transformGroup13);

            Shape shape60 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties60 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties74 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties60 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks60 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties60.Append(shapeLocks60);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties74 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape60 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties74.Append(placeholderShape60);

            nonVisualShapeProperties60.Append(nonVisualDrawingProperties74);
            nonVisualShapeProperties60.Append(nonVisualShapeDrawingProperties60);
            nonVisualShapeProperties60.Append(applicationNonVisualDrawingProperties74);

            ShapeProperties shapeProperties61 = new ShapeProperties();

            A.Transform2D transform2D23 = new A.Transform2D();
            A.Offset offset36 = new A.Offset() { X = 1792288L, Y = 4800600L };
            A.Extents extents36 = new A.Extents() { Cx = 5486400L, Cy = 566738L };

            transform2D23.Append(offset36);
            transform2D23.Append(extents36);

            shapeProperties61.Append(transform2D23);

            TextBody textBody60 = new TextBody();
            A.BodyProperties bodyProperties60 = new A.BodyProperties() { Anchor = A.TextAnchoringTypeValues.Bottom };

            A.ListStyle listStyle60 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties22 = new A.Level1ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Left };
            A.DefaultRunProperties defaultRunProperties128 = new A.DefaultRunProperties() { FontSize = 2000, Bold = true };

            level1ParagraphProperties22.Append(defaultRunProperties128);

            listStyle60.Append(level1ParagraphProperties22);

            A.Paragraph paragraph96 = new A.Paragraph();

            A.Run run62 = new A.Run();

            A.RunProperties runProperties84 = new A.RunProperties() { Language = "en-US" };
            runProperties84.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text84 = new A.Text();
            text84.Text = "Click to edit Master title style";

            run62.Append(runProperties84);
            run62.Append(text84);
            A.EndParagraphRunProperties endParagraphRunProperties56 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph96.Append(run62);
            paragraph96.Append(endParagraphRunProperties56);

            textBody60.Append(bodyProperties60);
            textBody60.Append(listStyle60);
            textBody60.Append(paragraph96);

            shape60.Append(nonVisualShapeProperties60);
            shape60.Append(shapeProperties61);
            shape60.Append(textBody60);

            Shape shape61 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties61 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties75 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Picture Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties61 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks61 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties61.Append(shapeLocks61);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties75 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape61 = new PlaceholderShape() { Type = PlaceholderValues.Picture, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties75.Append(placeholderShape61);

            nonVisualShapeProperties61.Append(nonVisualDrawingProperties75);
            nonVisualShapeProperties61.Append(nonVisualShapeDrawingProperties61);
            nonVisualShapeProperties61.Append(applicationNonVisualDrawingProperties75);

            ShapeProperties shapeProperties62 = new ShapeProperties();

            A.Transform2D transform2D24 = new A.Transform2D();
            A.Offset offset37 = new A.Offset() { X = 1792288L, Y = 612775L };
            A.Extents extents37 = new A.Extents() { Cx = 5486400L, Cy = 4114800L };

            transform2D24.Append(offset37);
            transform2D24.Append(extents37);

            shapeProperties62.Append(transform2D24);

            TextBody textBody61 = new TextBody();
            A.BodyProperties bodyProperties61 = new A.BodyProperties();

            A.ListStyle listStyle61 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties23 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0 };
            A.NoBullet noBullet48 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties129 = new A.DefaultRunProperties() { FontSize = 3200 };

            level1ParagraphProperties23.Append(noBullet48);
            level1ParagraphProperties23.Append(defaultRunProperties129);

            A.Level2ParagraphProperties level2ParagraphProperties14 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0 };
            A.NoBullet noBullet49 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties130 = new A.DefaultRunProperties() { FontSize = 2800 };

            level2ParagraphProperties14.Append(noBullet49);
            level2ParagraphProperties14.Append(defaultRunProperties130);

            A.Level3ParagraphProperties level3ParagraphProperties14 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0 };
            A.NoBullet noBullet50 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties131 = new A.DefaultRunProperties() { FontSize = 2400 };

            level3ParagraphProperties14.Append(noBullet50);
            level3ParagraphProperties14.Append(defaultRunProperties131);

            A.Level4ParagraphProperties level4ParagraphProperties14 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0 };
            A.NoBullet noBullet51 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties132 = new A.DefaultRunProperties() { FontSize = 2000 };

            level4ParagraphProperties14.Append(noBullet51);
            level4ParagraphProperties14.Append(defaultRunProperties132);

            A.Level5ParagraphProperties level5ParagraphProperties14 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0 };
            A.NoBullet noBullet52 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties133 = new A.DefaultRunProperties() { FontSize = 2000 };

            level5ParagraphProperties14.Append(noBullet52);
            level5ParagraphProperties14.Append(defaultRunProperties133);

            A.Level6ParagraphProperties level6ParagraphProperties14 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0 };
            A.NoBullet noBullet53 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties134 = new A.DefaultRunProperties() { FontSize = 2000 };

            level6ParagraphProperties14.Append(noBullet53);
            level6ParagraphProperties14.Append(defaultRunProperties134);

            A.Level7ParagraphProperties level7ParagraphProperties14 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0 };
            A.NoBullet noBullet54 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties135 = new A.DefaultRunProperties() { FontSize = 2000 };

            level7ParagraphProperties14.Append(noBullet54);
            level7ParagraphProperties14.Append(defaultRunProperties135);

            A.Level8ParagraphProperties level8ParagraphProperties14 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0 };
            A.NoBullet noBullet55 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties136 = new A.DefaultRunProperties() { FontSize = 2000 };

            level8ParagraphProperties14.Append(noBullet55);
            level8ParagraphProperties14.Append(defaultRunProperties136);

            A.Level9ParagraphProperties level9ParagraphProperties14 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0 };
            A.NoBullet noBullet56 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties137 = new A.DefaultRunProperties() { FontSize = 2000 };

            level9ParagraphProperties14.Append(noBullet56);
            level9ParagraphProperties14.Append(defaultRunProperties137);

            listStyle61.Append(level1ParagraphProperties23);
            listStyle61.Append(level2ParagraphProperties14);
            listStyle61.Append(level3ParagraphProperties14);
            listStyle61.Append(level4ParagraphProperties14);
            listStyle61.Append(level5ParagraphProperties14);
            listStyle61.Append(level6ParagraphProperties14);
            listStyle61.Append(level7ParagraphProperties14);
            listStyle61.Append(level8ParagraphProperties14);
            listStyle61.Append(level9ParagraphProperties14);

            A.Paragraph paragraph97 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties57 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph97.Append(endParagraphRunProperties57);

            textBody61.Append(bodyProperties61);
            textBody61.Append(listStyle61);
            textBody61.Append(paragraph97);

            shape61.Append(nonVisualShapeProperties61);
            shape61.Append(shapeProperties62);
            shape61.Append(textBody61);

            Shape shape62 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties62 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties76 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Text Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties62 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks62 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties62.Append(shapeLocks62);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties76 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape62 = new PlaceholderShape() { Type = PlaceholderValues.Body, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)2U };

            applicationNonVisualDrawingProperties76.Append(placeholderShape62);

            nonVisualShapeProperties62.Append(nonVisualDrawingProperties76);
            nonVisualShapeProperties62.Append(nonVisualShapeDrawingProperties62);
            nonVisualShapeProperties62.Append(applicationNonVisualDrawingProperties76);

            ShapeProperties shapeProperties63 = new ShapeProperties();

            A.Transform2D transform2D25 = new A.Transform2D();
            A.Offset offset38 = new A.Offset() { X = 1792288L, Y = 5367338L };
            A.Extents extents38 = new A.Extents() { Cx = 5486400L, Cy = 804862L };

            transform2D25.Append(offset38);
            transform2D25.Append(extents38);

            shapeProperties63.Append(transform2D25);

            TextBody textBody62 = new TextBody();
            A.BodyProperties bodyProperties62 = new A.BodyProperties();

            A.ListStyle listStyle62 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties24 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0 };
            A.NoBullet noBullet57 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties138 = new A.DefaultRunProperties() { FontSize = 1400 };

            level1ParagraphProperties24.Append(noBullet57);
            level1ParagraphProperties24.Append(defaultRunProperties138);

            A.Level2ParagraphProperties level2ParagraphProperties15 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0 };
            A.NoBullet noBullet58 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties139 = new A.DefaultRunProperties() { FontSize = 1200 };

            level2ParagraphProperties15.Append(noBullet58);
            level2ParagraphProperties15.Append(defaultRunProperties139);

            A.Level3ParagraphProperties level3ParagraphProperties15 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0 };
            A.NoBullet noBullet59 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties140 = new A.DefaultRunProperties() { FontSize = 1000 };

            level3ParagraphProperties15.Append(noBullet59);
            level3ParagraphProperties15.Append(defaultRunProperties140);

            A.Level4ParagraphProperties level4ParagraphProperties15 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0 };
            A.NoBullet noBullet60 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties141 = new A.DefaultRunProperties() { FontSize = 900 };

            level4ParagraphProperties15.Append(noBullet60);
            level4ParagraphProperties15.Append(defaultRunProperties141);

            A.Level5ParagraphProperties level5ParagraphProperties15 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0 };
            A.NoBullet noBullet61 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties142 = new A.DefaultRunProperties() { FontSize = 900 };

            level5ParagraphProperties15.Append(noBullet61);
            level5ParagraphProperties15.Append(defaultRunProperties142);

            A.Level6ParagraphProperties level6ParagraphProperties15 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0 };
            A.NoBullet noBullet62 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties143 = new A.DefaultRunProperties() { FontSize = 900 };

            level6ParagraphProperties15.Append(noBullet62);
            level6ParagraphProperties15.Append(defaultRunProperties143);

            A.Level7ParagraphProperties level7ParagraphProperties15 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0 };
            A.NoBullet noBullet63 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties144 = new A.DefaultRunProperties() { FontSize = 900 };

            level7ParagraphProperties15.Append(noBullet63);
            level7ParagraphProperties15.Append(defaultRunProperties144);

            A.Level8ParagraphProperties level8ParagraphProperties15 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0 };
            A.NoBullet noBullet64 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties145 = new A.DefaultRunProperties() { FontSize = 900 };

            level8ParagraphProperties15.Append(noBullet64);
            level8ParagraphProperties15.Append(defaultRunProperties145);

            A.Level9ParagraphProperties level9ParagraphProperties15 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0 };
            A.NoBullet noBullet65 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties146 = new A.DefaultRunProperties() { FontSize = 900 };

            level9ParagraphProperties15.Append(noBullet65);
            level9ParagraphProperties15.Append(defaultRunProperties146);

            listStyle62.Append(level1ParagraphProperties24);
            listStyle62.Append(level2ParagraphProperties15);
            listStyle62.Append(level3ParagraphProperties15);
            listStyle62.Append(level4ParagraphProperties15);
            listStyle62.Append(level5ParagraphProperties15);
            listStyle62.Append(level6ParagraphProperties15);
            listStyle62.Append(level7ParagraphProperties15);
            listStyle62.Append(level8ParagraphProperties15);
            listStyle62.Append(level9ParagraphProperties15);

            A.Paragraph paragraph98 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties51 = new A.ParagraphProperties() { Level = 0 };

            A.Run run63 = new A.Run();

            A.RunProperties runProperties85 = new A.RunProperties() { Language = "en-US" };
            runProperties85.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text85 = new A.Text();
            text85.Text = "Click to edit Master text styles";

            run63.Append(runProperties85);
            run63.Append(text85);

            paragraph98.Append(paragraphProperties51);
            paragraph98.Append(run63);

            textBody62.Append(bodyProperties62);
            textBody62.Append(listStyle62);
            textBody62.Append(paragraph98);

            shape62.Append(nonVisualShapeProperties62);
            shape62.Append(shapeProperties63);
            shape62.Append(textBody62);

            Shape shape63 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties63 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties77 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Date Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties63 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks63 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties63.Append(shapeLocks63);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties77 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape63 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties77.Append(placeholderShape63);

            nonVisualShapeProperties63.Append(nonVisualDrawingProperties77);
            nonVisualShapeProperties63.Append(nonVisualShapeDrawingProperties63);
            nonVisualShapeProperties63.Append(applicationNonVisualDrawingProperties77);
            ShapeProperties shapeProperties64 = new ShapeProperties();

            TextBody textBody63 = new TextBody();
            A.BodyProperties bodyProperties63 = new A.BodyProperties();
            A.ListStyle listStyle63 = new A.ListStyle();

            A.Paragraph paragraph99 = new A.Paragraph();

            A.Field field23 = new A.Field() { Id = "{3EC25210-86F0-4E6C-AD5E-B8BB5E189FC5}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties86 = new A.RunProperties() { Language = "en-US" };
            runProperties86.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text86 = new A.Text();
            text86.Text = "7/28/2013";

            field23.Append(runProperties86);
            field23.Append(text86);
            A.EndParagraphRunProperties endParagraphRunProperties58 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph99.Append(field23);
            paragraph99.Append(endParagraphRunProperties58);

            textBody63.Append(bodyProperties63);
            textBody63.Append(listStyle63);
            textBody63.Append(paragraph99);

            shape63.Append(nonVisualShapeProperties63);
            shape63.Append(shapeProperties64);
            shape63.Append(textBody63);

            Shape shape64 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties64 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties78 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Footer Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties64 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks64 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties64.Append(shapeLocks64);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties78 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape64 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties78.Append(placeholderShape64);

            nonVisualShapeProperties64.Append(nonVisualDrawingProperties78);
            nonVisualShapeProperties64.Append(nonVisualShapeDrawingProperties64);
            nonVisualShapeProperties64.Append(applicationNonVisualDrawingProperties78);
            ShapeProperties shapeProperties65 = new ShapeProperties();

            TextBody textBody64 = new TextBody();
            A.BodyProperties bodyProperties64 = new A.BodyProperties();
            A.ListStyle listStyle64 = new A.ListStyle();

            A.Paragraph paragraph100 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties59 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph100.Append(endParagraphRunProperties59);

            textBody64.Append(bodyProperties64);
            textBody64.Append(listStyle64);
            textBody64.Append(paragraph100);

            shape64.Append(nonVisualShapeProperties64);
            shape64.Append(shapeProperties65);
            shape64.Append(textBody64);

            Shape shape65 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties65 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties79 = new NonVisualDrawingProperties() { Id = (UInt32Value)7U, Name = "Slide Number Placeholder 6" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties65 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks65 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties65.Append(shapeLocks65);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties79 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape65 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties79.Append(placeholderShape65);

            nonVisualShapeProperties65.Append(nonVisualDrawingProperties79);
            nonVisualShapeProperties65.Append(nonVisualShapeDrawingProperties65);
            nonVisualShapeProperties65.Append(applicationNonVisualDrawingProperties79);
            ShapeProperties shapeProperties66 = new ShapeProperties();

            TextBody textBody65 = new TextBody();
            A.BodyProperties bodyProperties65 = new A.BodyProperties();
            A.ListStyle listStyle65 = new A.ListStyle();

            A.Paragraph paragraph101 = new A.Paragraph();

            A.Field field24 = new A.Field() { Id = "{302C726E-FB28-4EB3-B2FA-7AE9B707067F}", Type = "slidenum" };

            A.RunProperties runProperties87 = new A.RunProperties() { Language = "en-US" };
            runProperties87.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text87 = new A.Text();
            text87.Text = "‹#›";

            field24.Append(runProperties87);
            field24.Append(text87);
            A.EndParagraphRunProperties endParagraphRunProperties60 = new A.EndParagraphRunProperties() { Language = "en-US" };

            paragraph101.Append(field24);
            paragraph101.Append(endParagraphRunProperties60);

            textBody65.Append(bodyProperties65);
            textBody65.Append(listStyle65);
            textBody65.Append(paragraph101);

            shape65.Append(nonVisualShapeProperties65);
            shape65.Append(shapeProperties66);
            shape65.Append(textBody65);

            shapeTree13.Append(nonVisualGroupShapeProperties13);
            shapeTree13.Append(groupShapeProperties13);
            shapeTree13.Append(shape60);
            shapeTree13.Append(shape61);
            shapeTree13.Append(shape62);
            shapeTree13.Append(shape63);
            shapeTree13.Append(shape64);
            shapeTree13.Append(shape65);

            CommonSlideDataExtensionList commonSlideDataExtensionList13 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension13 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId13 = new P14.CreationId() { Val = (UInt32Value)10562102U };
            creationId13.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension13.Append(creationId13);

            commonSlideDataExtensionList13.Append(commonSlideDataExtension13);

            commonSlideData13.Append(shapeTree13);
            commonSlideData13.Append(commonSlideDataExtensionList13);

            ColorMapOverride colorMapOverride12 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping12 = new A.MasterColorMapping();

            colorMapOverride12.Append(masterColorMapping12);

            slideLayout11.Append(commonSlideData13);
            slideLayout11.Append(colorMapOverride12);

            slideLayoutPart11.SlideLayout = slideLayout11;
        }

        // Generates content of slidePart2.
        private void GenerateSlidePart2Content(SlidePart slidePart2)
        {
            Slide slide2 = new Slide();
            slide2.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slide2.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slide2.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData14 = new CommonSlideData();

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
            A.Offset offset39 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents39 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset14 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents14 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup14.Append(offset39);
            transformGroup14.Append(extents39);
            transformGroup14.Append(childOffset14);
            transformGroup14.Append(childExtents14);

            groupShapeProperties14.Append(transformGroup14);

            GraphicFrame graphicFrame1 = new GraphicFrame();

            NonVisualGraphicFrameProperties nonVisualGraphicFrameProperties1 = new NonVisualGraphicFrameProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties81 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Table 3" };

            NonVisualGraphicFrameDrawingProperties nonVisualGraphicFrameDrawingProperties1 = new NonVisualGraphicFrameDrawingProperties();
            A.GraphicFrameLocks graphicFrameLocks1 = new A.GraphicFrameLocks() { NoGrouping = true };

            nonVisualGraphicFrameDrawingProperties1.Append(graphicFrameLocks1);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties81 = new ApplicationNonVisualDrawingProperties();

            ApplicationNonVisualDrawingPropertiesExtensionList applicationNonVisualDrawingPropertiesExtensionList1 = new ApplicationNonVisualDrawingPropertiesExtensionList();

            ApplicationNonVisualDrawingPropertiesExtension applicationNonVisualDrawingPropertiesExtension1 = new ApplicationNonVisualDrawingPropertiesExtension() { Uri = "{D42A27DB-BD31-4B8C-83A1-F6EECF244321}" };

            P14.ModificationId modificationId1 = new P14.ModificationId() { Val = (UInt32Value)3251908189U };
            modificationId1.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            applicationNonVisualDrawingPropertiesExtension1.Append(modificationId1);

            applicationNonVisualDrawingPropertiesExtensionList1.Append(applicationNonVisualDrawingPropertiesExtension1);

            applicationNonVisualDrawingProperties81.Append(applicationNonVisualDrawingPropertiesExtensionList1);

            nonVisualGraphicFrameProperties1.Append(nonVisualDrawingProperties81);
            nonVisualGraphicFrameProperties1.Append(nonVisualGraphicFrameDrawingProperties1);
            nonVisualGraphicFrameProperties1.Append(applicationNonVisualDrawingProperties81);

            Transform transform1 = new Transform();
            A.Offset offset40 = new A.Offset() { X = 838200L, Y = 685800L };
            A.Extents extents40 = new A.Extents() { Cx = 7391401L, Cy = 2743201L };

            transform1.Append(offset40);
            transform1.Append(extents40);

            A.Graphic graphic1 = new A.Graphic();

            A.GraphicData graphicData1 = new A.GraphicData() { Uri = "http://schemas.openxmlformats.org/drawingml/2006/table" };

            A.Table table1 = new A.Table();

            A.TableProperties tableProperties1 = new A.TableProperties() { FirstRow = true, BandRow = true };
            A.TableStyleId tableStyleId1 = new A.TableStyleId();
            tableStyleId1.Text = "{5C22544A-7EE6-4342-B048-85BDC9FD1C3A}";

            tableProperties1.Append(tableStyleId1);

            A.TableGrid tableGrid1 = new A.TableGrid();
            A.GridColumn gridColumn1 = new A.GridColumn() { Width = 1676400L };
            A.GridColumn gridColumn2 = new A.GridColumn() { Width = 5715001L };

            tableGrid1.Append(gridColumn1);
            tableGrid1.Append(gridColumn2);

            A.TableRow tableRow1 = new A.TableRow() { Height = 304801L };

            A.TableCell tableCell1 = new A.TableCell();

            A.TextBody textBody66 = new A.TextBody();
            A.BodyProperties bodyProperties66 = new A.BodyProperties();
            A.ListStyle listStyle66 = new A.ListStyle();

            A.Paragraph paragraph102 = new A.Paragraph();

            A.Run run64 = new A.Run();

            A.RunProperties runProperties88 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties88.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text88 = new A.Text();
            text88.Text = "Name";

            run64.Append(runProperties88);
            run64.Append(text88);
            A.EndParagraphRunProperties endParagraphRunProperties61 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph102.Append(run64);
            paragraph102.Append(endParagraphRunProperties61);

            textBody66.Append(bodyProperties66);
            textBody66.Append(listStyle66);
            textBody66.Append(paragraph102);
            A.TableCellProperties tableCellProperties1 = new A.TableCellProperties();

            tableCell1.Append(textBody66);
            tableCell1.Append(tableCellProperties1);

            A.TableCell tableCell2 = new A.TableCell();

            A.TextBody textBody67 = new A.TextBody();
            A.BodyProperties bodyProperties67 = new A.BodyProperties();
            A.ListStyle listStyle67 = new A.ListStyle();

            A.Paragraph paragraph103 = new A.Paragraph();

            A.Run run65 = new A.Run();

            A.RunProperties runProperties89 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties89.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text89 = new A.Text();
            text89.Text = "{name}";

            run65.Append(runProperties89);
            run65.Append(text89);
            A.EndParagraphRunProperties endParagraphRunProperties62 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph103.Append(run65);
            paragraph103.Append(endParagraphRunProperties62);

            textBody67.Append(bodyProperties67);
            textBody67.Append(listStyle67);
            textBody67.Append(paragraph103);
            A.TableCellProperties tableCellProperties2 = new A.TableCellProperties();

            tableCell2.Append(textBody67);
            tableCell2.Append(tableCellProperties2);

            tableRow1.Append(tableCell1);
            tableRow1.Append(tableCell2);

            A.TableRow tableRow2 = new A.TableRow() { Height = 304800L };

            A.TableCell tableCell3 = new A.TableCell();

            A.TextBody textBody68 = new A.TextBody();
            A.BodyProperties bodyProperties68 = new A.BodyProperties();
            A.ListStyle listStyle68 = new A.ListStyle();

            A.Paragraph paragraph104 = new A.Paragraph();

            A.Run run66 = new A.Run();

            A.RunProperties runProperties90 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties90.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text90 = new A.Text();
            text90.Text = "State";

            run66.Append(runProperties90);
            run66.Append(text90);
            A.EndParagraphRunProperties endParagraphRunProperties63 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph104.Append(run66);
            paragraph104.Append(endParagraphRunProperties63);

            textBody68.Append(bodyProperties68);
            textBody68.Append(listStyle68);
            textBody68.Append(paragraph104);
            A.TableCellProperties tableCellProperties3 = new A.TableCellProperties();

            tableCell3.Append(textBody68);
            tableCell3.Append(tableCellProperties3);

            A.TableCell tableCell4 = new A.TableCell();

            A.TextBody textBody69 = new A.TextBody();
            A.BodyProperties bodyProperties69 = new A.BodyProperties();
            A.ListStyle listStyle69 = new A.ListStyle();

            A.Paragraph paragraph105 = new A.Paragraph();

            A.Run run67 = new A.Run();

            A.RunProperties runProperties91 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties91.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text91 = new A.Text();
            text91.Text = "{state}";

            run67.Append(runProperties91);
            run67.Append(text91);
            A.EndParagraphRunProperties endParagraphRunProperties64 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph105.Append(run67);
            paragraph105.Append(endParagraphRunProperties64);

            textBody69.Append(bodyProperties69);
            textBody69.Append(listStyle69);
            textBody69.Append(paragraph105);
            A.TableCellProperties tableCellProperties4 = new A.TableCellProperties();

            tableCell4.Append(textBody69);
            tableCell4.Append(tableCellProperties4);

            tableRow2.Append(tableCell3);
            tableRow2.Append(tableCell4);

            A.TableRow tableRow3 = new A.TableRow() { Height = 304800L };

            A.TableCell tableCell5 = new A.TableCell();

            A.TextBody textBody70 = new A.TextBody();
            A.BodyProperties bodyProperties70 = new A.BodyProperties();
            A.ListStyle listStyle70 = new A.ListStyle();

            A.Paragraph paragraph106 = new A.Paragraph();

            A.Run run68 = new A.Run();

            A.RunProperties runProperties92 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties92.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text92 = new A.Text();
            text92.Text = "Group";

            run68.Append(runProperties92);
            run68.Append(text92);
            A.EndParagraphRunProperties endParagraphRunProperties65 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph106.Append(run68);
            paragraph106.Append(endParagraphRunProperties65);

            textBody70.Append(bodyProperties70);
            textBody70.Append(listStyle70);
            textBody70.Append(paragraph106);
            A.TableCellProperties tableCellProperties5 = new A.TableCellProperties();

            tableCell5.Append(textBody70);
            tableCell5.Append(tableCellProperties5);

            A.TableCell tableCell6 = new A.TableCell();

            A.TextBody textBody71 = new A.TextBody();
            A.BodyProperties bodyProperties71 = new A.BodyProperties();
            A.ListStyle listStyle71 = new A.ListStyle();

            A.Paragraph paragraph107 = new A.Paragraph();

            A.Run run69 = new A.Run();

            A.RunProperties runProperties93 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties93.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text93 = new A.Text();
            text93.Text = "{group}";

            run69.Append(runProperties93);
            run69.Append(text93);
            A.EndParagraphRunProperties endParagraphRunProperties66 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph107.Append(run69);
            paragraph107.Append(endParagraphRunProperties66);

            textBody71.Append(bodyProperties71);
            textBody71.Append(listStyle71);
            textBody71.Append(paragraph107);
            A.TableCellProperties tableCellProperties6 = new A.TableCellProperties();

            tableCell6.Append(textBody71);
            tableCell6.Append(tableCellProperties6);

            tableRow3.Append(tableCell5);
            tableRow3.Append(tableCell6);

            A.TableRow tableRow4 = new A.TableRow() { Height = 304800L };

            A.TableCell tableCell7 = new A.TableCell();

            A.TextBody textBody72 = new A.TextBody();
            A.BodyProperties bodyProperties72 = new A.BodyProperties();
            A.ListStyle listStyle72 = new A.ListStyle();

            A.Paragraph paragraph108 = new A.Paragraph();

            A.Run run70 = new A.Run();

            A.RunProperties runProperties94 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties94.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text94 = new A.Text();
            text94.Text = "Problem/Issue";

            run70.Append(runProperties94);
            run70.Append(text94);
            A.EndParagraphRunProperties endParagraphRunProperties67 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph108.Append(run70);
            paragraph108.Append(endParagraphRunProperties67);

            textBody72.Append(bodyProperties72);
            textBody72.Append(listStyle72);
            textBody72.Append(paragraph108);
            A.TableCellProperties tableCellProperties7 = new A.TableCellProperties();

            tableCell7.Append(textBody72);
            tableCell7.Append(tableCellProperties7);

            A.TableCell tableCell8 = new A.TableCell();

            A.TextBody textBody73 = new A.TextBody();
            A.BodyProperties bodyProperties73 = new A.BodyProperties();
            A.ListStyle listStyle73 = new A.ListStyle();

            A.Paragraph paragraph109 = new A.Paragraph();

            A.Run run71 = new A.Run();

            A.RunProperties runProperties95 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties95.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text95 = new A.Text();
            text95.Text = "{issue}";

            run71.Append(runProperties95);
            run71.Append(text95);
            A.EndParagraphRunProperties endParagraphRunProperties68 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph109.Append(run71);
            paragraph109.Append(endParagraphRunProperties68);

            textBody73.Append(bodyProperties73);
            textBody73.Append(listStyle73);
            textBody73.Append(paragraph109);
            A.TableCellProperties tableCellProperties8 = new A.TableCellProperties();

            tableCell8.Append(textBody73);
            tableCell8.Append(tableCellProperties8);

            tableRow4.Append(tableCell7);
            tableRow4.Append(tableCell8);

            A.TableRow tableRow5 = new A.TableRow() { Height = 304800L };

            A.TableCell tableCell9 = new A.TableCell();

            A.TextBody textBody74 = new A.TextBody();
            A.BodyProperties bodyProperties74 = new A.BodyProperties();
            A.ListStyle listStyle74 = new A.ListStyle();

            A.Paragraph paragraph110 = new A.Paragraph();

            A.Run run72 = new A.Run();

            A.RunProperties runProperties96 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties96.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text96 = new A.Text();
            text96.Text = "Decision";

            run72.Append(runProperties96);
            run72.Append(text96);
            A.EndParagraphRunProperties endParagraphRunProperties69 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph110.Append(run72);
            paragraph110.Append(endParagraphRunProperties69);

            textBody74.Append(bodyProperties74);
            textBody74.Append(listStyle74);
            textBody74.Append(paragraph110);
            A.TableCellProperties tableCellProperties9 = new A.TableCellProperties();

            tableCell9.Append(textBody74);
            tableCell9.Append(tableCellProperties9);

            A.TableCell tableCell10 = new A.TableCell();

            A.TextBody textBody75 = new A.TextBody();
            A.BodyProperties bodyProperties75 = new A.BodyProperties();
            A.ListStyle listStyle75 = new A.ListStyle();

            A.Paragraph paragraph111 = new A.Paragraph();

            A.Run run73 = new A.Run();

            A.RunProperties runProperties97 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties97.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text97 = new A.Text();
            text97.Text = "{decision}";

            run73.Append(runProperties97);
            run73.Append(text97);
            A.EndParagraphRunProperties endParagraphRunProperties70 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph111.Append(run73);
            paragraph111.Append(endParagraphRunProperties70);

            textBody75.Append(bodyProperties75);
            textBody75.Append(listStyle75);
            textBody75.Append(paragraph111);
            A.TableCellProperties tableCellProperties10 = new A.TableCellProperties();

            tableCell10.Append(textBody75);
            tableCell10.Append(tableCellProperties10);

            tableRow5.Append(tableCell9);
            tableRow5.Append(tableCell10);

            A.TableRow tableRow6 = new A.TableRow() { Height = 304800L };

            A.TableCell tableCell11 = new A.TableCell();

            A.TextBody textBody76 = new A.TextBody();
            A.BodyProperties bodyProperties76 = new A.BodyProperties();
            A.ListStyle listStyle76 = new A.ListStyle();

            A.Paragraph paragraph112 = new A.Paragraph();

            A.Run run74 = new A.Run();

            A.RunProperties runProperties98 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties98.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text98 = new A.Text();
            text98.Text = "Alternatives";

            run74.Append(runProperties98);
            run74.Append(text98);
            A.EndParagraphRunProperties endParagraphRunProperties71 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph112.Append(run74);
            paragraph112.Append(endParagraphRunProperties71);

            textBody76.Append(bodyProperties76);
            textBody76.Append(listStyle76);
            textBody76.Append(paragraph112);
            A.TableCellProperties tableCellProperties11 = new A.TableCellProperties();

            tableCell11.Append(textBody76);
            tableCell11.Append(tableCellProperties11);

            A.TableCell tableCell12 = new A.TableCell();

            A.TextBody textBody77 = new A.TextBody();
            A.BodyProperties bodyProperties77 = new A.BodyProperties();
            A.ListStyle listStyle77 = new A.ListStyle();

            A.Paragraph paragraph113 = new A.Paragraph();

            A.Run run75 = new A.Run();

            A.RunProperties runProperties99 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties99.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text99 = new A.Text();
            text99.Text = "{alternatives}";

            run75.Append(runProperties99);
            run75.Append(text99);
            A.EndParagraphRunProperties endParagraphRunProperties72 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph113.Append(run75);
            paragraph113.Append(endParagraphRunProperties72);

            textBody77.Append(bodyProperties77);
            textBody77.Append(listStyle77);
            textBody77.Append(paragraph113);
            A.TableCellProperties tableCellProperties12 = new A.TableCellProperties();

            tableCell12.Append(textBody77);
            tableCell12.Append(tableCellProperties12);

            tableRow6.Append(tableCell11);
            tableRow6.Append(tableCell12);

            A.TableRow tableRow7 = new A.TableRow() { Height = 304800L };

            A.TableCell tableCell13 = new A.TableCell();

            A.TextBody textBody78 = new A.TextBody();
            A.BodyProperties bodyProperties78 = new A.BodyProperties();
            A.ListStyle listStyle78 = new A.ListStyle();

            A.Paragraph paragraph114 = new A.Paragraph();

            A.Run run76 = new A.Run();

            A.RunProperties runProperties100 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties100.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text100 = new A.Text();
            text100.Text = "Arguments";

            run76.Append(runProperties100);
            run76.Append(text100);
            A.EndParagraphRunProperties endParagraphRunProperties73 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph114.Append(run76);
            paragraph114.Append(endParagraphRunProperties73);

            textBody78.Append(bodyProperties78);
            textBody78.Append(listStyle78);
            textBody78.Append(paragraph114);
            A.TableCellProperties tableCellProperties13 = new A.TableCellProperties();

            tableCell13.Append(textBody78);
            tableCell13.Append(tableCellProperties13);

            A.TableCell tableCell14 = new A.TableCell();

            A.TextBody textBody79 = new A.TextBody();
            A.BodyProperties bodyProperties79 = new A.BodyProperties();
            A.ListStyle listStyle79 = new A.ListStyle();

            A.Paragraph paragraph115 = new A.Paragraph();

            A.Run run77 = new A.Run();

            A.RunProperties runProperties101 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties101.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text101 = new A.Text();
            text101.Text = "{arguments}";

            run77.Append(runProperties101);
            run77.Append(text101);
            A.EndParagraphRunProperties endParagraphRunProperties74 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph115.Append(run77);
            paragraph115.Append(endParagraphRunProperties74);

            textBody79.Append(bodyProperties79);
            textBody79.Append(listStyle79);
            textBody79.Append(paragraph115);
            A.TableCellProperties tableCellProperties14 = new A.TableCellProperties();

            tableCell14.Append(textBody79);
            tableCell14.Append(tableCellProperties14);

            tableRow7.Append(tableCell13);
            tableRow7.Append(tableCell14);

            A.TableRow tableRow8 = new A.TableRow() { Height = 304800L };

            A.TableCell tableCell15 = new A.TableCell();

            A.TextBody textBody80 = new A.TextBody();
            A.BodyProperties bodyProperties80 = new A.BodyProperties();
            A.ListStyle listStyle80 = new A.ListStyle();

            A.Paragraph paragraph116 = new A.Paragraph();

            A.Run run78 = new A.Run();

            A.RunProperties runProperties102 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties102.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text102 = new A.Text();
            text102.Text = "Related Decision";

            run78.Append(runProperties102);
            run78.Append(text102);
            A.EndParagraphRunProperties endParagraphRunProperties75 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph116.Append(run78);
            paragraph116.Append(endParagraphRunProperties75);

            textBody80.Append(bodyProperties80);
            textBody80.Append(listStyle80);
            textBody80.Append(paragraph116);
            A.TableCellProperties tableCellProperties15 = new A.TableCellProperties();

            tableCell15.Append(textBody80);
            tableCell15.Append(tableCellProperties15);

            A.TableCell tableCell16 = new A.TableCell();

            A.TextBody textBody81 = new A.TextBody();
            A.BodyProperties bodyProperties81 = new A.BodyProperties();
            A.ListStyle listStyle81 = new A.ListStyle();

            A.Paragraph paragraph117 = new A.Paragraph();

            A.Run run79 = new A.Run();

            A.RunProperties runProperties103 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties103.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text103 = new A.Text();
            text103.Text = "{decisions}";

            run79.Append(runProperties103);
            run79.Append(text103);
            A.EndParagraphRunProperties endParagraphRunProperties76 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph117.Append(run79);
            paragraph117.Append(endParagraphRunProperties76);

            textBody81.Append(bodyProperties81);
            textBody81.Append(listStyle81);
            textBody81.Append(paragraph117);
            A.TableCellProperties tableCellProperties16 = new A.TableCellProperties();

            tableCell16.Append(textBody81);
            tableCell16.Append(tableCellProperties16);

            tableRow8.Append(tableCell15);
            tableRow8.Append(tableCell16);

            A.TableRow tableRow9 = new A.TableRow() { Height = 304800L };

            A.TableCell tableCell17 = new A.TableCell();

            A.TextBody textBody82 = new A.TextBody();
            A.BodyProperties bodyProperties82 = new A.BodyProperties();
            A.ListStyle listStyle82 = new A.ListStyle();

            A.Paragraph paragraph118 = new A.Paragraph();

            A.Run run80 = new A.Run();

            A.RunProperties runProperties104 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties104.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text104 = new A.Text();
            text104.Text = "Related Requirements";

            run80.Append(runProperties104);
            run80.Append(text104);
            A.EndParagraphRunProperties endParagraphRunProperties77 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph118.Append(run80);
            paragraph118.Append(endParagraphRunProperties77);

            textBody82.Append(bodyProperties82);
            textBody82.Append(listStyle82);
            textBody82.Append(paragraph118);
            A.TableCellProperties tableCellProperties17 = new A.TableCellProperties();

            tableCell17.Append(textBody82);
            tableCell17.Append(tableCellProperties17);

            A.TableCell tableCell18 = new A.TableCell();

            A.TextBody textBody83 = new A.TextBody();
            A.BodyProperties bodyProperties83 = new A.BodyProperties();
            A.ListStyle listStyle83 = new A.ListStyle();

            A.Paragraph paragraph119 = new A.Paragraph();

            A.Run run81 = new A.Run();

            A.RunProperties runProperties105 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties105.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text105 = new A.Text();
            text105.Text = "{requirements}";

            run81.Append(runProperties105);
            run81.Append(text105);
            A.EndParagraphRunProperties endParagraphRunProperties78 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph119.Append(run81);
            paragraph119.Append(endParagraphRunProperties78);

            textBody83.Append(bodyProperties83);
            textBody83.Append(listStyle83);
            textBody83.Append(paragraph119);
            A.TableCellProperties tableCellProperties18 = new A.TableCellProperties();

            tableCell18.Append(textBody83);
            tableCell18.Append(tableCellProperties18);

            tableRow9.Append(tableCell17);
            tableRow9.Append(tableCell18);

            table1.Append(tableProperties1);
            table1.Append(tableGrid1);
            table1.Append(tableRow1);
            table1.Append(tableRow2);
            table1.Append(tableRow3);
            table1.Append(tableRow4);
            table1.Append(tableRow5);
            table1.Append(tableRow6);
            table1.Append(tableRow7);
            table1.Append(tableRow8);
            table1.Append(tableRow9);

            graphicData1.Append(table1);

            graphic1.Append(graphicData1);

            graphicFrame1.Append(nonVisualGraphicFrameProperties1);
            graphicFrame1.Append(transform1);
            graphicFrame1.Append(graphic1);

            shapeTree14.Append(nonVisualGroupShapeProperties14);
            shapeTree14.Append(groupShapeProperties14);
            shapeTree14.Append(graphicFrame1);

            CommonSlideDataExtensionList commonSlideDataExtensionList14 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension14 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId14 = new P14.CreationId() { Val = (UInt32Value)331602207U };
            creationId14.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension14.Append(creationId14);

            commonSlideDataExtensionList14.Append(commonSlideDataExtension14);

            commonSlideData14.Append(shapeTree14);
            commonSlideData14.Append(commonSlideDataExtensionList14);

            ColorMapOverride colorMapOverride13 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping13 = new A.MasterColorMapping();

            colorMapOverride13.Append(masterColorMapping13);

            slide2.Append(commonSlideData14);
            slide2.Append(colorMapOverride13);

            slidePart2.Slide = slide2;
        }
        // Generates content of slidePart5.
        private void GenerateSlidePart5ContentTopic(SlidePart slidePart5)
        {
            Slide slide2 = new Slide();
            slide2.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slide2.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slide2.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData14 = new CommonSlideData();

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
            A.Offset offset39 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents39 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset14 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents14 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup14.Append(offset39);
            transformGroup14.Append(extents39);
            transformGroup14.Append(childOffset14);
            transformGroup14.Append(childExtents14);

            groupShapeProperties14.Append(transformGroup14);

            GraphicFrame graphicFrame1 = new GraphicFrame();

            NonVisualGraphicFrameProperties nonVisualGraphicFrameProperties1 = new NonVisualGraphicFrameProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties81 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Table 3" };

            NonVisualGraphicFrameDrawingProperties nonVisualGraphicFrameDrawingProperties1 = new NonVisualGraphicFrameDrawingProperties();
            A.GraphicFrameLocks graphicFrameLocks1 = new A.GraphicFrameLocks() { NoGrouping = true };

            nonVisualGraphicFrameDrawingProperties1.Append(graphicFrameLocks1);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties81 = new ApplicationNonVisualDrawingProperties();

            ApplicationNonVisualDrawingPropertiesExtensionList applicationNonVisualDrawingPropertiesExtensionList1 = new ApplicationNonVisualDrawingPropertiesExtensionList();

            ApplicationNonVisualDrawingPropertiesExtension applicationNonVisualDrawingPropertiesExtension1 = new ApplicationNonVisualDrawingPropertiesExtension() { Uri = "{D42A27DB-BD31-4B8C-83A1-F6EECF244321}" };

            P14.ModificationId modificationId1 = new P14.ModificationId() { Val = (UInt32Value)3251908189U };
            modificationId1.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            applicationNonVisualDrawingPropertiesExtension1.Append(modificationId1);

            applicationNonVisualDrawingPropertiesExtensionList1.Append(applicationNonVisualDrawingPropertiesExtension1);

            applicationNonVisualDrawingProperties81.Append(applicationNonVisualDrawingPropertiesExtensionList1);

            nonVisualGraphicFrameProperties1.Append(nonVisualDrawingProperties81);
            nonVisualGraphicFrameProperties1.Append(nonVisualGraphicFrameDrawingProperties1);
            nonVisualGraphicFrameProperties1.Append(applicationNonVisualDrawingProperties81);

            Transform transform1 = new Transform();
            A.Offset offset40 = new A.Offset() { X = 838200L, Y = 685800L };
            A.Extents extents40 = new A.Extents() { Cx = 7391401L, Cy = 2743201L };

            transform1.Append(offset40);
            transform1.Append(extents40);

            A.Graphic graphic1 = new A.Graphic();

            A.GraphicData graphicData1 = new A.GraphicData() { Uri = "http://schemas.openxmlformats.org/drawingml/2006/table" };

            A.Table table1 = new A.Table();

            A.TableProperties tableProperties1 = new A.TableProperties() { FirstRow = true, BandRow = true };
            A.TableStyleId tableStyleId1 = new A.TableStyleId();
            tableStyleId1.Text = "{5C22544A-7EE6-4342-B048-85BDC9FD1C3A}";

            tableProperties1.Append(tableStyleId1);

            A.TableGrid tableGrid1 = new A.TableGrid();
            A.GridColumn gridColumn1 = new A.GridColumn() { Width = 1676400L };
            A.GridColumn gridColumn2 = new A.GridColumn() { Width = 5715001L };

            tableGrid1.Append(gridColumn1);
            tableGrid1.Append(gridColumn2);

            A.TableRow tableRow1 = new A.TableRow() { Height = 304801L };

            A.TableCell tableCell1 = new A.TableCell();

            A.TextBody textBody66 = new A.TextBody();
            A.BodyProperties bodyProperties66 = new A.BodyProperties();
            A.ListStyle listStyle66 = new A.ListStyle();

            A.Paragraph paragraph102 = new A.Paragraph();

            A.Run run64 = new A.Run();

            A.RunProperties runProperties88 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties88.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text88 = new A.Text();
            text88.Text = "Name";

            run64.Append(runProperties88);
            run64.Append(text88);
            A.EndParagraphRunProperties endParagraphRunProperties61 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph102.Append(run64);
            paragraph102.Append(endParagraphRunProperties61);

            textBody66.Append(bodyProperties66);
            textBody66.Append(listStyle66);
            textBody66.Append(paragraph102);
            A.TableCellProperties tableCellProperties1 = new A.TableCellProperties();

            tableCell1.Append(textBody66);
            tableCell1.Append(tableCellProperties1);

            A.TableCell tableCell2 = new A.TableCell();

            A.TextBody textBody67 = new A.TextBody();
            A.BodyProperties bodyProperties67 = new A.BodyProperties();
            A.ListStyle listStyle67 = new A.ListStyle();

            A.Paragraph paragraph103 = new A.Paragraph();

            A.Run run65 = new A.Run();

            A.RunProperties runProperties89 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties89.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text89 = new A.Text();
            text89.Text = "{name}";

            run65.Append(runProperties89);
            run65.Append(text89);
            A.EndParagraphRunProperties endParagraphRunProperties62 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph103.Append(run65);
            paragraph103.Append(endParagraphRunProperties62);

            textBody67.Append(bodyProperties67);
            textBody67.Append(listStyle67);
            textBody67.Append(paragraph103);
            A.TableCellProperties tableCellProperties2 = new A.TableCellProperties();

            tableCell2.Append(textBody67);
            tableCell2.Append(tableCellProperties2);

            tableRow1.Append(tableCell1);
            tableRow1.Append(tableCell2);

            A.TableRow tableRow2 = new A.TableRow() { Height = 304800L };

            A.TableCell tableCell3 = new A.TableCell();

            A.TextBody textBody68 = new A.TextBody();
            A.BodyProperties bodyProperties68 = new A.BodyProperties();
            A.ListStyle listStyle68 = new A.ListStyle();

            A.Paragraph paragraph104 = new A.Paragraph();

            A.Run run66 = new A.Run();

            A.RunProperties runProperties90 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties90.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text90 = new A.Text();
            text90.Text = "Description";

            run66.Append(runProperties90);
            run66.Append(text90);
            A.EndParagraphRunProperties endParagraphRunProperties63 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph104.Append(run66);
            paragraph104.Append(endParagraphRunProperties63);

            textBody68.Append(bodyProperties68);
            textBody68.Append(listStyle68);
            textBody68.Append(paragraph104);
            A.TableCellProperties tableCellProperties3 = new A.TableCellProperties();

            tableCell3.Append(textBody68);
            tableCell3.Append(tableCellProperties3);

            A.TableCell tableCell4 = new A.TableCell();

            A.TextBody textBody69 = new A.TextBody();
            A.BodyProperties bodyProperties69 = new A.BodyProperties();
            A.ListStyle listStyle69 = new A.ListStyle();

            A.Paragraph paragraph105 = new A.Paragraph();

            A.Run run67 = new A.Run();

            A.RunProperties runProperties91 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties91.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text91 = new A.Text();
            text91.Text = "{description}";

            run67.Append(runProperties91);
            run67.Append(text91);
            A.EndParagraphRunProperties endParagraphRunProperties64 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph105.Append(run67);
            paragraph105.Append(endParagraphRunProperties64);

            textBody69.Append(bodyProperties69);
            textBody69.Append(listStyle69);
            textBody69.Append(paragraph105);
            A.TableCellProperties tableCellProperties4 = new A.TableCellProperties();

            tableCell4.Append(textBody69);
            tableCell4.Append(tableCellProperties4);

            tableRow2.Append(tableCell3);
            tableRow2.Append(tableCell4);

            

         

            table1.Append(tableProperties1);
            table1.Append(tableGrid1);
            table1.Append(tableRow1);
            table1.Append(tableRow2);

            graphicData1.Append(table1);

            graphic1.Append(graphicData1);

            graphicFrame1.Append(nonVisualGraphicFrameProperties1);
            graphicFrame1.Append(transform1);
            graphicFrame1.Append(graphic1);

            shapeTree14.Append(nonVisualGroupShapeProperties14);
            shapeTree14.Append(groupShapeProperties14);
            shapeTree14.Append(graphicFrame1);

            CommonSlideDataExtensionList commonSlideDataExtensionList14 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension14 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId14 = new P14.CreationId() { Val = (UInt32Value)331602207U };
            creationId14.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension14.Append(creationId14);

            commonSlideDataExtensionList14.Append(commonSlideDataExtension14);

            commonSlideData14.Append(shapeTree14);
            commonSlideData14.Append(commonSlideDataExtensionList14);

            ColorMapOverride colorMapOverride13 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping13 = new A.MasterColorMapping();

            colorMapOverride13.Append(masterColorMapping13);

            slide2.Append(commonSlideData14);
            slide2.Append(colorMapOverride13);

            slidePart5.Slide = slide2;
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
            A.ScaleX scaleX1 = new A.ScaleX() { Numerator = 91, Denominator = 100 };
            A.ScaleY scaleY1 = new A.ScaleY() { Numerator = 91, Denominator = 100 };

            scaleFactor1.Append(scaleX1);
            scaleFactor1.Append(scaleY1);
            Origin origin1 = new Origin() { X = -980L, Y = -45L };

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

        // Generates content of slidePart3.
        private void GenerateSlidePart3Content(SlidePart slidePart3)
        {
            Slide slide3 = new Slide();
            slide3.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slide3.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slide3.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData15 = new CommonSlideData();

            ShapeTree shapeTree15 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties15 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties82 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties15 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties82 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties15.Append(nonVisualDrawingProperties82);
            nonVisualGroupShapeProperties15.Append(nonVisualGroupShapeDrawingProperties15);
            nonVisualGroupShapeProperties15.Append(applicationNonVisualDrawingProperties82);

            GroupShapeProperties groupShapeProperties15 = new GroupShapeProperties();

            A.TransformGroup transformGroup15 = new A.TransformGroup();
            A.Offset offset41 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents41 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset15 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents15 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup15.Append(offset41);
            transformGroup15.Append(extents41);
            transformGroup15.Append(childOffset15);
            transformGroup15.Append(childExtents15);

            groupShapeProperties15.Append(transformGroup15);

            Shape shape66 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties66 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties83 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties66 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks66 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties66.Append(shapeLocks66);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties83 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape66 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties83.Append(placeholderShape66);

            nonVisualShapeProperties66.Append(nonVisualDrawingProperties83);
            nonVisualShapeProperties66.Append(nonVisualShapeDrawingProperties66);
            nonVisualShapeProperties66.Append(applicationNonVisualDrawingProperties83);
            ShapeProperties shapeProperties67 = new ShapeProperties();

            TextBody textBody84 = new TextBody();
            A.BodyProperties bodyProperties84 = new A.BodyProperties();
            A.ListStyle listStyle84 = new A.ListStyle();

            A.Paragraph paragraph120 = new A.Paragraph();

            A.Run run82 = new A.Run();
            A.RunProperties runProperties106 = new A.RunProperties() { Language = "en-US", Dirty = false };
            A.Text text106 = new A.Text();
            text106.Text = "{title}";

            run82.Append(runProperties106);
            run82.Append(text106);

            paragraph120.Append(run82);

            textBody84.Append(bodyProperties84);
            textBody84.Append(listStyle84);
            textBody84.Append(paragraph120);

            shape66.Append(nonVisualShapeProperties66);
            shape66.Append(shapeProperties67);
            shape66.Append(textBody84);

            GraphicFrame graphicFrame2 = new GraphicFrame();

            NonVisualGraphicFrameProperties nonVisualGraphicFrameProperties2 = new NonVisualGraphicFrameProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties84 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Table 3" };

            NonVisualGraphicFrameDrawingProperties nonVisualGraphicFrameDrawingProperties2 = new NonVisualGraphicFrameDrawingProperties();
            A.GraphicFrameLocks graphicFrameLocks2 = new A.GraphicFrameLocks() { NoGrouping = true };

            nonVisualGraphicFrameDrawingProperties2.Append(graphicFrameLocks2);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties84 = new ApplicationNonVisualDrawingProperties();

            ApplicationNonVisualDrawingPropertiesExtensionList applicationNonVisualDrawingPropertiesExtensionList2 = new ApplicationNonVisualDrawingPropertiesExtensionList();

            ApplicationNonVisualDrawingPropertiesExtension applicationNonVisualDrawingPropertiesExtension2 = new ApplicationNonVisualDrawingPropertiesExtension() { Uri = "{D42A27DB-BD31-4B8C-83A1-F6EECF244321}" };

            P14.ModificationId modificationId2 = new P14.ModificationId() { Val = (UInt32Value)2079796323U };
            modificationId2.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            applicationNonVisualDrawingPropertiesExtension2.Append(modificationId2);

            applicationNonVisualDrawingPropertiesExtensionList2.Append(applicationNonVisualDrawingPropertiesExtension2);

            applicationNonVisualDrawingProperties84.Append(applicationNonVisualDrawingPropertiesExtensionList2);

            nonVisualGraphicFrameProperties2.Append(nonVisualDrawingProperties84);
            nonVisualGraphicFrameProperties2.Append(nonVisualGraphicFrameDrawingProperties2);
            nonVisualGraphicFrameProperties2.Append(applicationNonVisualDrawingProperties84);

            Transform transform2 = new Transform();
            A.Offset offset42 = new A.Offset() { X = 304800L, Y = 1600200L };
            A.Extents extents42 = new A.Extents() { Cx = 3124200L, Cy = 274320L };

            transform2.Append(offset42);
            transform2.Append(extents42);

            A.Graphic graphic2 = new A.Graphic();

            A.GraphicData graphicData2 = new A.GraphicData() { Uri = "http://schemas.openxmlformats.org/drawingml/2006/table" };

            A.Table table2 = new A.Table();

            A.TableProperties tableProperties2 = new A.TableProperties() { FirstRow = true, BandRow = true };
            A.TableStyleId tableStyleId2 = new A.TableStyleId();
            tableStyleId2.Text = "{5C22544A-7EE6-4342-B048-85BDC9FD1C3A}";

            tableProperties2.Append(tableStyleId2);

            A.TableGrid tableGrid2 = new A.TableGrid();
            A.GridColumn gridColumn3 = new A.GridColumn() { Width = 1562100L };
            A.GridColumn gridColumn4 = new A.GridColumn() { Width = 1562100L };

            tableGrid2.Append(gridColumn3);
            tableGrid2.Append(gridColumn4);

            A.TableRow tableRow10 = new A.TableRow() { Height = 228600L };

            A.TableCell tableCell19 = new A.TableCell();

            A.TextBody textBody85 = new A.TextBody();
            A.BodyProperties bodyProperties85 = new A.BodyProperties();
            A.ListStyle listStyle85 = new A.ListStyle();

            A.Paragraph paragraph121 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties79 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph121.Append(endParagraphRunProperties79);

            textBody85.Append(bodyProperties85);
            textBody85.Append(listStyle85);
            textBody85.Append(paragraph121);
            A.TableCellProperties tableCellProperties19 = new A.TableCellProperties();

            tableCell19.Append(textBody85);
            tableCell19.Append(tableCellProperties19);

            A.TableCell tableCell20 = new A.TableCell();

            A.TextBody textBody86 = new A.TextBody();
            A.BodyProperties bodyProperties86 = new A.BodyProperties();
            A.ListStyle listStyle86 = new A.ListStyle();

            A.Paragraph paragraph122 = new A.Paragraph();

            A.Run run83 = new A.Run();

            A.RunProperties runProperties107 = new A.RunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };
            runProperties107.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text107 = new A.Text();
            text107.Text = "Concerns";

            run83.Append(runProperties107);
            run83.Append(text107);
            A.EndParagraphRunProperties endParagraphRunProperties80 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 1200, Dirty = false };

            paragraph122.Append(run83);
            paragraph122.Append(endParagraphRunProperties80);

            textBody86.Append(bodyProperties86);
            textBody86.Append(listStyle86);
            textBody86.Append(paragraph122);
            A.TableCellProperties tableCellProperties20 = new A.TableCellProperties();

            tableCell20.Append(textBody86);
            tableCell20.Append(tableCellProperties20);

            tableRow10.Append(tableCell19);
            tableRow10.Append(tableCell20);

            table2.Append(tableProperties2);
            table2.Append(tableGrid2);
            table2.Append(tableRow10);

            graphicData2.Append(table2);

            graphic2.Append(graphicData2);

            graphicFrame2.Append(nonVisualGraphicFrameProperties2);
            graphicFrame2.Append(transform2);
            graphicFrame2.Append(graphic2);

            shapeTree15.Append(nonVisualGroupShapeProperties15);
            shapeTree15.Append(groupShapeProperties15);
            shapeTree15.Append(shape66);
            shapeTree15.Append(graphicFrame2);

            CommonSlideDataExtensionList commonSlideDataExtensionList15 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension15 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId15 = new P14.CreationId() { Val = (UInt32Value)1849363573U };
            creationId15.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension15.Append(creationId15);

            commonSlideDataExtensionList15.Append(commonSlideDataExtension15);

            commonSlideData15.Append(shapeTree15);
            commonSlideData15.Append(commonSlideDataExtensionList15);

            ColorMapOverride colorMapOverride14 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping14 = new A.MasterColorMapping();

            colorMapOverride14.Append(masterColorMapping14);

            slide3.Append(commonSlideData15);
            slide3.Append(colorMapOverride14);

            slidePart3.Slide = slide3;
        }

        // Generates content of extendedFilePropertiesPart1.
        private void GenerateExtendedFilePropertiesPart1Content(ExtendedFilePropertiesPart extendedFilePropertiesPart1)
        {
            Ap.Properties properties1 = new Ap.Properties();
            properties1.AddNamespaceDeclaration("vt", "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");
            Ap.TotalTime totalTime1 = new Ap.TotalTime();
            totalTime1.Text = "9";
            Ap.Words words1 = new Ap.Words();
            words1.Text = "45";
            Ap.Application application1 = new Ap.Application();
            application1.Text = "Microsoft Office PowerPoint";
            Ap.PresentationFormat presentationFormat1 = new Ap.PresentationFormat();
            presentationFormat1.Text = "On-screen Show (4:3)";
            Ap.Paragraphs paragraphs1 = new Ap.Paragraphs();
            paragraphs1.Text = "21";
            Ap.Slides slides1 = new Ap.Slides();
            slides1.Text = "3";
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
            vTInt322.Text = "3";

            variant4.Append(vTInt322);

            vTVector1.Append(variant1);
            vTVector1.Append(variant2);
            vTVector1.Append(variant3);
            vTVector1.Append(variant4);

            headingPairs1.Append(vTVector1);

            Ap.TitlesOfParts titlesOfParts1 = new Ap.TitlesOfParts();

            Vt.VTVector vTVector2 = new Vt.VTVector() { BaseType = Vt.VectorBaseValues.Lpstr, Size = (UInt32Value)4U };
            Vt.VTLPSTR vTLPSTR3 = new Vt.VTLPSTR();
            vTLPSTR3.Text = "Office Theme";
            Vt.VTLPSTR vTLPSTR4 = new Vt.VTLPSTR();
            vTLPSTR4.Text = "PowerPoint Presentation";
            Vt.VTLPSTR vTLPSTR5 = new Vt.VTLPSTR();
            vTLPSTR5.Text = "{title}";
            Vt.VTLPSTR vTLPSTR6 = new Vt.VTLPSTR();
            vTLPSTR6.Text = "{title}";

            vTVector2.Append(vTLPSTR3);
            vTVector2.Append(vTLPSTR4);
            vTVector2.Append(vTLPSTR5);
            vTVector2.Append(vTLPSTR6);

            titlesOfParts1.Append(vTVector2);
            Ap.LinksUpToDate linksUpToDate1 = new Ap.LinksUpToDate();
            linksUpToDate1.Text = "false";
            Ap.SharedDocument sharedDocument1 = new Ap.SharedDocument();
            sharedDocument1.Text = "false";
            Ap.HyperlinksChanged hyperlinksChanged1 = new Ap.HyperlinksChanged();
            hyperlinksChanged1.Text = "false";
            Ap.ApplicationVersion applicationVersion1 = new Ap.ApplicationVersion();
            applicationVersion1.Text = "14.0000";

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

        private void SetPackageProperties(OpenXmlPackage document)
        {
            document.PackageProperties.Creator = "Spyros";
            document.PackageProperties.Title = "PowerPoint Presentation";
            document.PackageProperties.Revision = "29";
            document.PackageProperties.Created = System.Xml.XmlConvert.ToDateTime("2013-07-27T17:27:29Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
            document.PackageProperties.Modified = System.Xml.XmlConvert.ToDateTime("2013-07-28T17:10:02Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
            document.PackageProperties.LastModifiedBy = "Spyros";
        }

        #region Binary Data
        private string thumbnailPart1Data = "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AIT+rf8AyJX0j9jvP+fS5/78S/8AxFH2O8/59Ln/AL8S/wDxFH9pVf5aX/k3/wAn6/0tT6vHtU/D/wCR9f6Wvmnwl8LeJ9N+IPh+91Hw5r1hZw/2r513e6PqFrbReZompRR+bPPbxxR+ZLIkSbnG6R0RcswB+0q8a8KW1zHr9g8lvOiD7VlnikVRmyuQMsVAGSQBk8kgV7LXg5nXliMRCclFNUYx929tJ1H1b1u38rHo4OHJSklf+I3rv8MF2XYKKKK846wooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigD/2QAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==";

        private string imagePart1Data = "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";

        private System.IO.Stream GetBinaryDataStream(string base64String)
        {
            return new System.IO.MemoryStream(System.Convert.FromBase64String(base64String));
        }

        #endregion
    }
}