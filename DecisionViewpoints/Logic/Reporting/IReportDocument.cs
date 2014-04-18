using DecisionViewpoints.Model;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Reporting
{
    public interface IReportDocument
    {
        void InsertTopicTable(ITopic topic);
        void InsertDecisionWithoutTopicMessage();
        void InsertDecisionDetailViewMessage();
        void InsertDecisionTable(IDecision decision);
        void InsertForcesTable(IForcesModel forces);
        void InsertDiagramImage(IEADiagram diagram);
        void Open();
        void Close();
    }
}