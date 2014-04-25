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

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DecisionViewpoints.Logic.Reporting;
using DecisionViewpoints.Model;
using EAFacade.Model;


namespace DecisionViewpoints.Logic.Menu
{
    internal class ReportMenu
    {
        public static void GenerateReport(IEAPackage decisionViewPackage, string filename, ReportType reportType)
        {
            IEARepository repository = EAFacade.EA.Repository;
            List<Decision> decisions =
                decisionViewPackage.GetAllDecisions().Select(element => new Decision(element)).ToList();
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
                List<Topic> topics = (from IEAElement element in repository.GetAllElements()
                                      where element.IsTopic()
                                      select new Topic(element)).ToList();

                report.InsertDecisionDetailViewMessage();

                // Insert Decisions that have a Topic
                foreach (Topic topic in topics)
                {
                    report.InsertTopicTable(topic);
                    //Insert Decisions with parent element the current Topic
                    foreach (Decision decision in decisions)
                    {
                        IEAElement parent = EAFacade.EA.Repository.GetElementByID(decision.ID).ParentElement;
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
                    IEAElement parent = EAFacade.EA.Repository.GetElementByID(decision.ID).ParentElement;
                    if (parent == null || !parent.IsTopic())
                    {
                        parent = EAFacade.EA.Repository.GetElementByID(decision.ID).ParentElement;
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
                saveFileDialog1.Title = "Save report as..";
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

        /* public static void GenerateSelectedDecisionsReport(string filename, ReportType reportType)
        {
            IEARepository repository = EAFacade.EA.Repository;

            IEnumerable<IEAElement> selectedDecisionsRepository = EAFacade.EA.Repository.GetSelectedItems();
            List<Decision> selectedDecisions =
                (from IEAElement element in selectedDecisionsRepository
                 where element.IsDecision()
                 where !element.IsHistoryDecision()
                 select new Decision(element)).ToList();

            List<IEAElement> selRepositoryList = selectedDecisionsRepository.ToList();

            for (int j = 0; j < selRepositoryList.Count; j++)
            {
                IEAElement d = selRepositoryList[j];
                if (d.IsTopic())
                {
                    //TODO: this does not consider yet elements which are groups themselves - this needs to be treated separately

                    //TODO: also add the diagrams for the topic, as there can be topics with no underlying alternative
                    List<IEAElement> elementList = d.GetElements().ToList();

                    for (int i = 0; i < elementList.Count; i++)
                    {
                        if (elementList[i].IsDecision())
                        {
                            selectedDecisions.Add(new Decision(elementList[i]));
                            //setSelectedDiagrams.UnionWith(i.GetDiagrams());
                        }
                    }
                }
            }

            List<Decision> decisions =
                (from IEAElement element in repository.GetAllElements()
                 where element.IsDecision()
                 where !element.IsHistoryDecision()
                 select new Decision(element)).ToList();

            List<IEADiagram> diagrams =
                (from IEAPackage package in repository.GetAllDecisionViewPackages()
                 from IEADiagram diagram in package.GetDiagrams()
                 select diagram).ToList();

            List<IEADiagram> selectedDiagrams =
                (from IEADiagram diagram in diagrams
                 from Decision dec in selectedDecisions
                 where diagram.Contains(dec.GetElement())
                 select diagram).Distinct().ToList();

            IReportDocument report = null;
            List<IEADiagram> finalSetOfDiagrams = selectedDiagrams;
            IEnumerable<IEAElement> finalRepositoryOfElements = selectedDecisionsRepository;
            List<Decision> finalSelectedDecisions = selectedDecisions;


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
                //foreach (IEADiagram diagram in finalSetOfDiagrams.Where(diagram => diagram.IsRelationshipView()))
                List<IEADiagram> relationshipDiagrams =
                    finalSetOfDiagrams.Where(diagram => diagram.IsRelationshipView()).ToList();
                for (int i = 0; i < relationshipDiagrams.Count(); i++)
                {
                    IEADiagram diagram = relationshipDiagrams[i];
                    report.InsertDiagramImage(diagram);
                }

                //Retrieve Topics
                List<Topic> topics = (from IEAElement element in finalRepositoryOfElements
                                      where element.IsTopic()
                                      select new Topic(element)).ToList();

                report.InsertDecisionDetailViewMessage();

                // Insert Decisions that have a Topic
                for (int i = 0; i < topics.Count; i++)
                {
                    Topic topic = topics[i];
                    report.InsertTopicTable(topic);
                    //Insert Decisions with parent element the current Topic
                    for (int j = 0; j < finalSelectedDecisions.Count; j++)
                    {
                        Decision decision = finalSelectedDecisions[j];
                        IEAElement parent = EAFacade.EA.Repository.GetElementByID(decision.ID).ParentElement;
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
                foreach (Decision decision in finalSelectedDecisions)
                {
                    IEAElement parent = EAFacade.EA.Repository.GetElementByID(decision.ID).ParentElement;
                    if (parent == null || !parent.IsTopic())
                    {
                        parent = EAFacade.EA.Repository.GetElementByID(decision.ID).ParentElement;
                        report.InsertDecisionTable(decision);
                    }
                }

                foreach (
                    IEADiagram diagram in
                        finalSetOfDiagrams.Where(diagram => !diagram.IsForcesView() && !diagram.IsRelationshipView()))
                {
                    report.InsertDiagramImage(diagram);
                }
                foreach (IEADiagram diagram in finalSetOfDiagrams.Where(diagram => diagram.IsForcesView()))
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
        }*/


        public static void GenerateSelectedDecisionsReport(string filename, ReportType reportType)
        {
            IEARepository repository = EAFacade.EA.Repository;

            List<Decision> decisions =
                (from IEAElement element in repository.GetAllElements()
                 where element.IsDecision()
                 where !element.IsHistoryDecision()
                 select new Decision(element)).ToList();
            List<IEADiagram> diagrams =
                (from IEAPackage package in repository.GetAllDecisionViewPackages()
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
                        selectedDecisionIDs.Union(elem.GetDecisionsForTopic().Select(x => new Decision(x).ID)).ToList();
                }
                else if (elem.IsDecision())
                {
                    selectedDecisionIDs.Add(new Decision(elem).ID);
                }
            }
            Decision[] copy = decisions.ToArray();
            foreach (Decision d in copy)
            {
                if (!selectedDecisionIDs.Contains(d.ID))
                {
                    decisions.Remove(d);
                }
            }
            //remove unselected topics
            var topicIDs = new List<int>();
            foreach (Decision d in decisions)
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
                foreach (Topic topic in topics)
                {
                    report.InsertTopicTable(topic);
                    //Insert Decisions with parent element the current Topic
                    foreach (Decision decision in decisions)
                    {
                        IEAElement parent = EAFacade.EA.Repository.GetElementByID(decision.ID).ParentElement;
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
                    IEAElement parent = EAFacade.EA.Repository.GetElementByID(decision.ID).ParentElement;
                    if (parent == null || !parent.IsTopic())
                    {
                        parent = EAFacade.EA.Repository.GetElementByID(decision.ID).ParentElement;
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
    }
}
