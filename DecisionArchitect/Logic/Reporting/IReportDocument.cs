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

using DecisionArchitect.Model;
using EAFacade.Model;
using IDecision = DecisionArchitect.Model.New.IDecision;
using ITopic = DecisionArchitect.Model.New.ITopic;

namespace DecisionArchitect.Logic.Reporting
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