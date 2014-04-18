using DecisionViewpoints.Model.Reporting;

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
            try
            {
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
            }
            catch (System.IO.IOException)
            {
                return null;
            }
            return reportDocument;
        }
    }
}