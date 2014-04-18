using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DecisionViewpoints.Logic.Reporting;
using DecisionViewpointsCustomViews.Model;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Menu
{
    internal class ReportMenu
    {
        public static void GenerateReport(EAPackage decisionViewPackage, string filename, ReportType reportType)
        {
            EARepository repository = EARepository.Instance;
            List<Decision> decisions =
                decisionViewPackage.GetAllDecisions().Select(element => new Decision(element)).ToList();
            List<EADiagram> diagrams = decisionViewPackage.GetAllDiagrams().ToList();
                
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
                foreach (EADiagram diagram in diagrams.Where(diagram => diagram.IsRelationshipView()))
                {
                    report.InsertDiagramImage(diagram);
                }

                //Retrieve Topics
                List<Topic> topics = (from EAElement element in repository.GetAllElements()
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
                        EAElement parent = EARepository.Instance.GetElementByID(decision.ID).ParentElement;
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
                    EAElement parent = EARepository.Instance.GetElementByID(decision.ID).ParentElement;
                    if (parent == null || !parent.IsTopic())
                    {
                        parent = EARepository.Instance.GetElementByID(decision.ID).ParentElement;
                        report.InsertDecisionTable(decision);
                    }
                }

                foreach (
                    EADiagram diagram in
                        diagrams.Where(diagram => !diagram.IsForcesView() && !diagram.IsRelationshipView()))
                {
                    report.InsertDiagramImage(diagram);
                }
                foreach (EADiagram diagram in diagrams.Where(diagram => diagram.IsForcesView()))
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

        public static void GenerateForcesReport(string filename, EADiagram diagram)
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
            EARepository repository = EARepository.Instance;

            IEnumerable<EAElement> selectedDecisionsRepository = EARepository.Instance.GetSelectedItems();
            List<Decision> selectedDecisions =
                (from EAElement element in selectedDecisionsRepository
                 where element.IsDecision()
                 where !element.IsHistoryDecision()
                 select new Decision(element)).ToList();

            List<EAElement> selRepositoryList = selectedDecisionsRepository.ToList();

            for (int j = 0; j < selRepositoryList.Count; j++)
            {
                EAElement d = selRepositoryList[j];
                if (d.IsTopic())
                {
                    //TODO: this does not consider yet elements which are groups themselves - this needs to be treated separately

                    //TODO: also add the diagrams for the topic, as there can be topics with no underlying alternative
                    List<EAElement> elementList = d.GetElements().ToList();

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
                (from EAElement element in repository.GetAllElements()
                 where element.IsDecision()
                 where !element.IsHistoryDecision()
                 select new Decision(element)).ToList();

            List<EADiagram> diagrams =
                (from EAPackage package in repository.GetAllDecisionViewPackages()
                 from EADiagram diagram in package.GetDiagrams()
                 select diagram).ToList();

            List<EADiagram> selectedDiagrams =
                (from EADiagram diagram in diagrams
                 from Decision dec in selectedDecisions
                 where diagram.Contains(dec.GetElement())
                 select diagram).Distinct().ToList();

            IReportDocument report = null;
            List<EADiagram> finalSetOfDiagrams = selectedDiagrams;
            IEnumerable<EAElement> finalRepositoryOfElements = selectedDecisionsRepository;
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
                //foreach (EADiagram diagram in finalSetOfDiagrams.Where(diagram => diagram.IsRelationshipView()))
                List<EADiagram> relationshipDiagrams =
                    finalSetOfDiagrams.Where(diagram => diagram.IsRelationshipView()).ToList();
                for (int i = 0; i < relationshipDiagrams.Count(); i++)
                {
                    EADiagram diagram = relationshipDiagrams[i];
                    report.InsertDiagramImage(diagram);
                }

                //Retrieve Topics
                List<Topic> topics = (from EAElement element in finalRepositoryOfElements
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
                        EAElement parent = EARepository.Instance.GetElementByID(decision.ID).ParentElement;
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
                    EAElement parent = EARepository.Instance.GetElementByID(decision.ID).ParentElement;
                    if (parent == null || !parent.IsTopic())
                    {
                        parent = EARepository.Instance.GetElementByID(decision.ID).ParentElement;
                        report.InsertDecisionTable(decision);
                    }
                }

                foreach (
                    EADiagram diagram in
                        finalSetOfDiagrams.Where(diagram => !diagram.IsForcesView() && !diagram.IsRelationshipView()))
                {
                    report.InsertDiagramImage(diagram);
                }
                foreach (EADiagram diagram in finalSetOfDiagrams.Where(diagram => diagram.IsForcesView()))
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
            EARepository repository = EARepository.Instance;

            List<Decision> decisions =
                (from EAElement element in repository.GetAllElements()
                 where element.IsDecision()
                 where !element.IsHistoryDecision()
                 select new Decision(element)).ToList();
            List<EADiagram> diagrams =
                (from EAPackage package in repository.GetAllDecisionViewPackages()
                 from EADiagram diagram in package.GetAllDiagrams()
                 select diagram).ToList();

            //Retrieve Topics
            List<Topic> topics = (from EAElement element in repository.GetAllElements()
                                  where element.IsTopic()
                                  select new Topic(element)).ToList();

            //remove unselected decisions 
            var selectedTopicsAndDecisions =
                (from EAElement element in repository.GetSelectedItems()
                 where (element.IsDecision() || element.IsTopic()) && !element.IsHistoryDecision()
                 select element);
                
            var selectedDecisionIDs = new List<int>();
            foreach (var elem in selectedTopicsAndDecisions)
            {
                if (elem.IsTopic())
                {
                    selectedDecisionIDs = selectedDecisionIDs.Union(elem.GetDecisionsForTopic().Select(x => new Decision(x).ID)).ToList();
                }  else if (elem.IsDecision())
                {
                    selectedDecisionIDs.Add(new Decision(elem).ID);
                }
            }
            var copy = decisions.ToArray();
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
                topicIDs.Add(d.GetTopic().ID);

            }
            var topicsCopy = topics.ToArray();
            foreach (var t in topicsCopy)
            {
                if (!topicIDs.Contains(t.ID))
                {
                    topics.Remove(t);
                }
            }

            var allElements = decisions.Select(d => d.GetElement()).ToArray();
            allElements = allElements.Union(topics.Select(t => t.GetElement())).ToArray();

            var diagramsCopy = diagrams.ToArray();
            foreach (var d in diagramsCopy)
            {
                bool remove = true;
                foreach (var element in allElements) {
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
                foreach (EADiagram diagram in diagrams.Where(diagram => diagram.IsRelationshipView()))
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
                        EAElement parent = EARepository.Instance.GetElementByID(decision.ID).ParentElement;
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
                    EAElement parent = EARepository.Instance.GetElementByID(decision.ID).ParentElement;
                    if (parent == null || !parent.IsTopic())
                    {
                        parent = EARepository.Instance.GetElementByID(decision.ID).ParentElement;
                        report.InsertDecisionTable(decision);
                    }
                }

                foreach (
                    EADiagram diagram in
                        diagrams.Where(diagram => !diagram.IsForcesView() && !diagram.IsRelationshipView()))
                {
                    report.InsertDiagramImage(diagram);
                }
                foreach (EADiagram diagram in diagrams.Where(diagram => diagram.IsForcesView()))
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