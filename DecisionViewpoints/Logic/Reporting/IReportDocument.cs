using DecisionViewpointsCustomViews.Model;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Reporting
{
    public interface IReportDocument
    {
        void InsertTopicTable(ITopic topic);
        void InsertDecisionWithoutTopicMessage();
        void InsertDecisionTable(IDecision decision);
        void InsertForcesTable(IForcesModel forces);
        void InsertDiagramImage(EADiagram diagram);
        void Open();
        void Close();
    }
}