﻿using System;
using DecisionViewpointsCustomViews.Model;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Reporting
{
    public class PowerPointDocument : IReportDocument
    {
        public PowerPointDocument(string filename)
        {
            
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

        public void Close()
        {
            throw new NotImplementedException();
        }
    }
}
