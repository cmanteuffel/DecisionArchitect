namespace DecisionViewpoints.Logic.Reporting
{
    public enum ReportType
    {
        Word,
        Excel,
        PowerPoint
    }

    public static class ReportFactory
    {
        public static IReportDocument Create(ReportType type, string filename)
        {
            IReportDocument reportDocument = null;
            switch (type)
            {
                case ReportType.Word:
                    reportDocument = new WordDocument(filename);
                    break;
                case ReportType.Excel:
                    reportDocument = new ExcelDocument(filename);
                    break;
                case ReportType.PowerPoint:
                    reportDocument = new PowerPointDocument(filename);
                    break;
            }
            return reportDocument;
        }
    }
}