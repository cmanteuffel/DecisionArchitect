using System;
using DecisionViewpointsCustomViews.Model;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Reporting
{
    public class ExcelDocument : IReportDocument
    {
        private readonly string _filename;

        public ExcelDocument(string filename)
        {
            _filename = filename;
        }

        public void InsertDecisionTable(IDecision decision)
        {
            throw new NotImplementedException();
        }

        public void InsertForcesTable(IForcesModel forces)
        {
            throw new NotImplementedException();
        }

        public void InsertDiagramImage(EADiagram diagram)
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }
    }
}
