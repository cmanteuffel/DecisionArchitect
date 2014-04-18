using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DecisionViewpoints.Model.Reporting;
using DecisionViewpointsCustomViews.Model;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using EAFacade;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Reporting
{
    public class ExcelDocument : IReportDocument
    {
        private readonly string _filename;
        private SpreadsheetDocument _excelDoc;
        private WorkbookPart _mainPart;

        public ExcelDocument(string filename)
        {
            //_filename = String.Format("{0}\\{1}", Utilities.GetDocumentsDirectory(), filename);//original
            _filename = filename;//angor
            //MessageBox.Show("Document filename: " + _filename);// angor DEBUG
            using (SpreadsheetDocument excelDoc = SpreadsheetDocument.Create(_filename, SpreadsheetDocumentType.Workbook)
                )
            {
                _mainPart = excelDoc.AddWorkbookPart();
                _mainPart.Workbook = new Workbook();
                _mainPart.Workbook.AppendChild(new Sheets());
            }
        }

        public void InsertTopicTable(ITopic topic) { }
        public void InsertDecisionWithoutTopicMessage() { }
        public void InsertDecisionTable(IDecision decision)
        {
            // maybe here we need to create a sheet with the overview of the decisions
        }

        public void InsertForcesTable(IForcesModel forces)
        {
            WorksheetPart worksheetPart = InsertWorksheet(forces.Name);
            const string forcesTableTopLeftColumn = "A";
            const uint forcesTopLeftRow = 1;

            InsertText(worksheetPart, forcesTableTopLeftColumn, forcesTopLeftRow, "Requirement");
            InsertText(worksheetPart, forcesTopLeftRow, "Concern");

            foreach (EAElement decision in forces.GetDecisions())
            {
                InsertText(worksheetPart, forcesTopLeftRow, decision.Name);
            }

            uint rowIndex = forcesTopLeftRow + 1;
            foreach (var concernsPerRequirement in forces.GetConcernsPerRequirement())
            {
                var requirement = concernsPerRequirement.Key;
                var concerns = concernsPerRequirement.Value;

                foreach (var concern in concerns)
                {
                    InsertText(worksheetPart, forcesTableTopLeftColumn, rowIndex, requirement.Name);
                    InsertText(worksheetPart, rowIndex, concern.Name);
                    foreach (Rating rating in forces.GetRatings())
                    {
                        if (rating.RequirementGUID != requirement.GUID || rating.ConcernGUID != concern.GUID) continue;
                        if (forces.GetDecisions().Any(decision => rating.DecisionGUID == decision.GUID))
                        {
                            InsertText(worksheetPart, rowIndex, rating.Value);
                        }
                    }
                    rowIndex++;
                }
            }



            worksheetPart.Worksheet.Save();
        }

        public void InsertDiagramImage(EADiagram diagram)
        {
            //throw new NotImplementedException();
        }

        public void Open()
        {
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), _filename);
            _excelDoc = SpreadsheetDocument.Open(filepath, true);
            _mainPart = _excelDoc.WorkbookPart;
        }

        public void Close()
        {
            _excelDoc.Close();
        }

        private WorksheetPart InsertWorksheet(string name)
        {
            var newWorksheetPart = _mainPart.AddNewPart<WorksheetPart>();
            newWorksheetPart.Worksheet = new Worksheet(new SheetData());
            newWorksheetPart.Worksheet.Save();

            // create the worksheet to workbook relation
            var sheets = _mainPart.Workbook.GetFirstChild<Sheets>();
            string relationshipId = _mainPart.GetIdOfPart(newWorksheetPart);

            // Get a unique ID for the new worksheet.
            uint sheetId = 1;
            if (sheets.Elements<Sheet>().Any())
            {
                sheetId = sheets.Elements<Sheet>().Select(s => s.SheetId.Value).Max() + 1;
            }

            var sheet = new Sheet
                {
                    Id = relationshipId,
                    SheetId = sheetId,
                    Name = name
                };
            sheets.AppendChild(sheet);
            _mainPart.Workbook.Save();
            return newWorksheetPart;
        }

        private void InsertText(WorksheetPart worksheetPart, string columnIndex, uint rowIndex, string text)
        {
            // Get the SharedStringTablePart. If it does not exist, create a new one.
            SharedStringTablePart shareStringPart = _excelDoc.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Any()
                                                        ? _excelDoc.WorkbookPart.GetPartsOfType<SharedStringTablePart>()
                                                                   .First()
                                                        : _excelDoc.WorkbookPart.AddNewPart<SharedStringTablePart>();

            // Insert the text into the SharedStringTablePart.
            int index = InsertSharedStringItem(text, shareStringPart);

            // Insert cell A1 into the new worksheet.
            Cell cell = InsertCell(worksheetPart, columnIndex, rowIndex);

            // Set the value of cell A1.
            cell.CellValue = new CellValue(index.ToString(CultureInfo.InvariantCulture));
            cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
        }

        private void InsertText(WorksheetPart worksheetPart, uint rowIndex, string text)
        {
            // Get the SharedStringTablePart. If it does not exist, create a new one.
            SharedStringTablePart shareStringPart = _excelDoc.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Any()
                                                        ? _excelDoc.WorkbookPart.GetPartsOfType<SharedStringTablePart>()
                                                                   .First()
                                                        : _excelDoc.WorkbookPart.AddNewPart<SharedStringTablePart>();

            // Insert the text into the SharedStringTablePart.
            int index = InsertSharedStringItem(text, shareStringPart);

            // Insert cell into the new worksheet.
            Cell cell = InsertCellAfter(worksheetPart, rowIndex);

            if (cell == null) return;
            cell.CellValue = new CellValue(index.ToString(CultureInfo.InvariantCulture));
            cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
        }

        // Given text and a SharedStringTablePart, creates a SharedStringItem with the specified text 
        // and inserts it into the SharedStringTablePart. If the item already exists, returns its index.
        private static int InsertSharedStringItem(string text, SharedStringTablePart shareStringPart)
        {
            // If the part does not contain a SharedStringTable, create one.
            if (shareStringPart.SharedStringTable == null)
            {
                shareStringPart.SharedStringTable = new SharedStringTable();
            }

            int i = 0;

            // Iterate through all the items in the SharedStringTable. If the text already exists, return its index.
            foreach (SharedStringItem item in shareStringPart.SharedStringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == text)
                {
                    return i;
                }

                i++;
            }

            // The text does not exist in the part. Create the SharedStringItem and return its index.
            shareStringPart.SharedStringTable.AppendChild(new SharedStringItem(new Text(text)));
            shareStringPart.SharedStringTable.Save();

            return i;
        }

        // Given a column name, a row index, and a WorksheetPart, inserts a cell into the worksheet. 
        // If the cell already exists, returns it. 
        private static Cell InsertCell(WorksheetPart worksheetPart, string columnIndex, uint rowIndex)
        {
            Worksheet worksheet = worksheetPart.Worksheet;
            var sheetData = worksheet.GetFirstChild<SheetData>();
            string cellRef = columnIndex + rowIndex;

            // If the worksheet does not contain a row with the specified row index, insert one.
            Row row;
            if (sheetData.Elements<Row>().Count(r => r.RowIndex == rowIndex) != 0)
            {
                row = sheetData.Elements<Row>().First(r => r.RowIndex == rowIndex);
            }
            else
            {
                row = new Row {RowIndex = rowIndex};
                sheetData.AppendChild(row);
            }

            // If there is a cell with the specified column name, modify it.  
            if (row.Elements<Cell>().Any(c => c.CellReference.Value == cellRef))
            {
                return row.Elements<Cell>().First(c => c.CellReference.Value == cellRef);
            }
            // Cells must be in sequential order according to CellReference. Determine where to insert the new cell.
            Cell refCell =
                row.Elements<Cell>()
                   .FirstOrDefault(
                       cell =>
                       String.Compare(cell.CellReference.Value, cellRef, StringComparison.OrdinalIgnoreCase) >
                       0);

            var newCell = new Cell {CellReference = cellRef};
            row.InsertBefore(newCell, refCell);

            worksheet.Save();

            return newCell;
        }

        private static Cell InsertCellAfter(WorksheetPart worksheetPart, uint rowIndex)
        {
            Worksheet worksheet = worksheetPart.Worksheet;
            var sheetData = worksheet.GetFirstChild<SheetData>();

            Row row = null;
            if (sheetData.Elements<Row>().Count(r => r.RowIndex == rowIndex) != 0)
            {
                row = sheetData.Elements<Row>().First(r => r.RowIndex == rowIndex);
            }

            if (row == null) return null;

            Cell prevCell = row.Elements<Cell>().Last();
            var newCell = new Cell();
            row.InsertAfter(newCell, prevCell);

            worksheet.Save();

            return newCell;
        }
    }
}