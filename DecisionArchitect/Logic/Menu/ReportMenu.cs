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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DecisionArchitect.Logic.Reporting;
using DecisionArchitect.Model;
using DecisionArchitect.View.Dialogs;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Logic.Menu
{
    internal class ReportMenu
    {
        public static void GenerateReport(IEAPackage decisionViewPackage, string filename, ReportType reportType)
        {
            IEARepository repository = EAMain.Repository;
            List<IDecision> decisions =
                decisionViewPackage.GetAllDecisions().Select(element => Decision.Load(element)).ToList();
            List<IEADiagram> diagrams = decisionViewPackage.GetAllDiagrams().ToList();

            IReportDocument report = null;
            try
            {
                string filenameExtension = filename.Substring(filename.IndexOf('.'));
                var saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Title = Messages.SaveReportAs;
                saveFileDialog1.Filter = "Microsoft " + reportType.ToString() + " (*" + filenameExtension + ")|*" +
                                         filenameExtension;
                saveFileDialog1.FilterIndex = 0;

                if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                saveFileDialog1.CheckFileExists = true;
                saveFileDialog1.CheckPathExists = true;
                string reportFilename = saveFileDialog1.FileName;
                report = ReportFactory.Create(reportType, reportFilename);
                //if the report cannot be created because is already used by another program a message will appear
                if (report == null)
                {
                    MessageBox.Show("Check if another program is using this file.",
                                    "Fail to create report",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
                report.Open();


                //Insert Decision Relationship Viewpoint
                foreach (IEADiagram diagram in diagrams.Where(diagram => diagram.IsRelationshipView()))
                {
                    report.InsertDiagramImage(diagram);
                }

                //Retrieve Topics
                List<ITopic> topics = (from IEAElement element in repository.GetAllElements()
                                       where EAMain.IsTopic(element)
                                       select Topic.Load(element)).ToList();

                report.InsertDecisionDetailViewMessage();

                // Insert Decisions that have a Topic
                foreach (ITopic topic in topics)
                {
                    report.InsertTopicTable(topic);
                    //Insert Decisions with parent element the current Topic
                    foreach (IDecision decision in decisions)
                    {
                        IEAElement parent = EAMain.Repository.GetElementByGUID(decision.Topic.GUID);
                        if (parent != null && EAMain.IsTopic(parent))
                        {
                            if (parent.GUID.Equals(topic.GUID))
                                report.InsertDecisionTable(decision);
                        }
                    }
                }

                // Insert an appropriate message before the decisions that are not included in a topic
                report.InsertDecisionWithoutTopicMessage();

                // Insert decisions without a Topic
                foreach (IDecision decision in decisions)
                {
                    IEAElement parent = EAMain.Repository.GetElementByID(decision.ID).ParentElement;
                    if (parent == null || !EAMain.IsTopic(parent))
                    {
                        report.InsertDecisionTable(decision);
                    }
                }

                foreach (
                    IEADiagram diagram in
                        diagrams.Where(diagram => !diagram.IsForcesView() && !diagram.IsRelationshipView()))
                {
                    report.InsertDiagramImage(diagram);
                }
                foreach (IEADiagram diagram in diagrams.Where(diagram => diagram.IsForcesView()))
                {
                    report.InsertForcesTable(new ForcesModel(diagram));
                }
                var customMessage = new ExportReportsCustomMessageBox(reportType.ToString(), reportFilename);
                customMessage.Show();
            }
            finally
            {
                if (report != null)
                    report.Close();
            }
        }

        public static void GenerateForcesReport(string filename, IEADiagram diagram)
        {
            IReportDocument report = null;
            try
            {
                string filenameExtension = filename.Substring(filename.IndexOf('.'));
                var saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Title = "SaveDescription report as..";
                saveFileDialog1.Filter = "Microsoft Excel (*" + filenameExtension + ")|*" + filenameExtension;
                saveFileDialog1.FilterIndex = 0;

                if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                saveFileDialog1.CheckFileExists = true;
                saveFileDialog1.CheckPathExists = true;
                string reportFilename = saveFileDialog1.FileName;
                report = ReportFactory.Create(ReportType.Excel, reportFilename);
                report.Open();
                if (diagram.IsForcesView())
                {
                    report.InsertForcesTable(new ForcesModel(diagram));
                }
                var customMessage = new ExportReportsCustomMessageBox("Excel", reportFilename);
                customMessage.Show();
            }
            finally
            {
                if (report != null)
                    report.Close();
            }
        }


        public static void GenerateSelectedDecisionsReport(string filename, ReportType reportType)
        {
            throw new NotImplementedException("needs to be adapted to new model");
            /*
            IEARepository repository = EAFacade.EAMain.Repository;

            List<Model.New.IDecision> decisions =
                (from IEAElement element in repository.GetAllElements()
                 where element.IsDecision()
                 where !element.IsHistoryDecision()
                 select Model.New.Decision.Load(element)).ToList();
            List<IEADiagram> diagrams =
                (from IEAPackage package in repository.GetAllPackages()
                 from IEADiagram diagram in package.GetAllDiagrams()
                 select diagram).ToList();

            //Retrieve Topics
            List<Topic> topics = (from IEAElement element in repository.GetAllElements()
                                  where element.IsTopic()
                                  select new Topic(element)).ToList();

            //remove unselected decisions 
            IEnumerable<IEAElement> selectedTopicsAndDecisions =
                (from IEAElement element in repository.GetSelectedItems()
                 where (element.IsDecision() || element.IsTopic()) && !element.IsHistoryDecision()
                 select element);

            var selectedDecisionIDs = new List<int>();
            foreach (IEAElement elem in selectedTopicsAndDecisions)
            {
                if (elem.IsTopic())
                {
                    selectedDecisionIDs =
                        selectedDecisionIDs.Union(elem.GetDecisionsForTopic().Select(x => Model.New.Decision.Load(x).ID)).ToList();
                }
                else if (elem.IsDecision())
                {
                    selectedDecisionIDs.Add(Model.New.Decision.Load(elem).ID);
                }
            }
            Model.New.IDecision[] copy = decisions.ToArray();
            foreach (Model.New.IDecision d in copy)
            {
                if (!selectedDecisionIDs.Contains(d.ID))
                {
                    decisions.Remove(d);
                }
            }
            //remove unselected topics
            var topicIDs = new List<int>();
            foreach (Model.New.IDecision d in decisions)
            {
                topicIDs.Add(d.Topic.ID);
            }
            Topic[] topicsCopy = topics.ToArray();
            foreach (Topic t in topicsCopy)
            {
                if (!topicIDs.Contains(t.ID))
                {
                    topics.Remove(t);
                }
            }

            IEAElement[] allElements = decisions.Select(d => d.GetElement()).ToArray();
            allElements = allElements.Union(topics.Select(t => t.GetElement())).ToArray();

            IEADiagram[] diagramsCopy = diagrams.ToArray();
            foreach (IEADiagram d in diagramsCopy)
            {
                bool remove = true;
                foreach (IEAElement element in allElements)
                {
                    if (d.Contains(element))
                    {
                        remove = false;
                    }
                }
                if (remove)
                {
                    diagrams.Remove(d);
                }
            }


            IReportDocument report = null;
            try
            {
                string filenameExtension = filename.Substring(filename.IndexOf('.'));
                var saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Title = Messages.SaveReportAs;
                saveFileDialog1.Filter = "Microsoft " + reportType.ToString() + " (*" + filenameExtension + ")|*" +
                                         filenameExtension;
                saveFileDialog1.FilterIndex = 0;

                if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                saveFileDialog1.CheckFileExists = true;
                saveFileDialog1.CheckPathExists = true;
                string reportFilename = saveFileDialog1.FileName;
                report = ReportFactory.Create(reportType, reportFilename);
                //if the report cannot be created because is already used by another program a message will appear
                if (report == null)
                {
                    MessageBox.Show("Check if another program is using this file.",
                                    "Fail to create report",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
                report.Open();


                //Insert Decision Relationship Viewpoint
                foreach (IEADiagram diagram in diagrams.Where(diagram => diagram.IsRelationshipView()))
                {
                    report.InsertDiagramImage(diagram);
                }


                report.InsertDecisionDetailViewMessage();

                // Insert Decisions that have a Topic
                foreach (Model.New.ITopic topic in topics)
                {
                    report.InsertTopicTable(topic);
                    //Insert Decisions with parent element the current Topic
                    foreach (Model.New.IDecision decision in decisions)
                    {
                        IEAElement parent = EAFacade.EAMain.Repository.GetElementByID(decision.ID).ParentElement;
                        if (parent != null && parent.IsTopic())
                        {
                            if (parent.ID.Equals(topic.ID))
                                report.InsertDecisionTable(decision);
                        }
                    }
                }

                // Insert an appropriate message before the decisions that are not included in a topic
                report.InsertDecisionWithoutTopicMessage();

                // Insert decisions without a Topic
                foreach (Decision decision in decisions)
                {
                    IEAElement parent = EAFacade.EAMain.Repository.GetElementByID(decision.ID).ParentElement;
                    if (parent == null || !parent.IsTopic())
                    {
                        parent = EAFacade.EAMain.Repository.GetElementByID(decision.ID).ParentElement;
                        report.InsertDecisionTable(decision);
                    }
                }

                foreach (
                    IEADiagram diagram in
                        diagrams.Where(diagram => !diagram.IsForcesView() && !diagram.IsRelationshipView()))
                {
                    report.InsertDiagramImage(diagram);
                }
                foreach (IEADiagram diagram in diagrams.Where(diagram => diagram.IsForcesView()))
                {
                    report.InsertForcesTable(new ForcesModel(diagram));
                }
                var customMessage = new ExportReportsCustomMessageBox(reportType.ToString(), reportFilename);
                customMessage.Show();
            }
            finally
            {
                if (report != null)
                    report.Close();
            }
             */
        }
    }
}