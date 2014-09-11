/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    Antonis Gkortzis (University of Groningen)
    Marc Holterman (University of Groningen)
*/

using System;
using System.Windows.Forms;
using DecisionArchitect.Logic.Detail;
using DecisionArchitect.Model.New;
using DecisionArchitect.View;
using DecisionArchitect.View.DetailView;
using DecisionArchitect.View.TopicView;
using EAFacade;
using EAFacade.Model;

/**
 * This Handler is invoked when you click on an entity in the Views. 
 * When you click on something in the Relationship, chronological or Stakeholdersview the message ends up here.
 */

namespace DecisionArchitect.Logic.EventHandler
{
    public class DetailHandler : RepositoryAdapter
    {
        private static DetailHandler _instance;

        public static DetailHandler Instance
        {
            get { return _instance ?? (_instance = new DetailHandler()); }
        }

        /********************************************************************************************
        ** EAMain Callbacks
        ********************************************************************************************/

        /// <summary>
        ///     This method is called when double clicking an element in the view pane. It opens the respective View.
        /// </summary>
        /// <param name="guid">
        ///     A string holding the GUID of the EAElement clicked by the user.
        /// </param>
        /// <param name="type">
        ///     The EANativeType of the element clicked by the user.
        /// </param>
        /// <returns></returns>
        public override bool OnContextItemDoubleClicked(string guid, EANativeType type)
        {
            // If the type is not an Element 
            if (type != EANativeType.Element)
            {
                return false;
            }
            // Get the element
            IEAElement element = EAMain.Repository.GetElementByGUID(guid);

            // If it is not a decision or a topic, leave!
            if (!(EAMain.IsDecision(element) || EAMain.IsTopic(element)))
            {
                return false;
            }
            // Check if the tab is already open.


            if (EAMain.IsDecision(element))
            {
                OpenDecisionDetailView(Decision.Load(element));
                return true;
            }
            if (EAMain.IsTopic(element))
            {
                if (IsOpenTab(element))
                {
                    FocusTab(element);
                    return true;
                }
                OpenNewTopicTab(element);
                return true;
            }
            return false;
        }

        /// <summary>
        ///     This method is called when dragging in an element. It overrides the standard popup fro EAMain.
        /// </summary>
        /// <param name="element">
        ///     The EAElement dragged into the view pane
        /// </param>
        /// <returns></returns>
        public override bool OnPostNewElement(IEAElement element)
        {
            if (!EAMain.IsDecision(element) && !EAMain.IsTopic(element))
            {
                return false;
            }
            // suppress properties window
            EAMain.Repository.SuppressDefaultDialogs(true);
            // Check if the tab is already open.
            if (EAMain.IsDecision(element))
            {
                OpenDecisionDetailView(Decision.Load(element));
                return true;
            }
            if (EAMain.IsTopic(element))
            {
                if (IsOpenTab(element))
                {
                    FocusTab(element);
                    return true;
                }
                OpenNewTopicTab(element);
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Method that is called when the user changes tabs.
        /// </summary>
        /// <param name="tabname"></param>
        /// String holding the name of the tab that is clicked by the user
        /// <param name="diagramId"></param>
        public override void OnTabChanged(string tabname, int diagramId)
        {
            try
            {
                SynchronizationManager.Instance.SetActiveTab(tabname);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /********************************************************************************************
        ** Auxiliary methods
        ********************************************************************************************/

        private void OpenNewTopicTab(IEAElement element)
        {
            ITopicViewController topicViewController = EAMain.Repository.AddTab(element.Name,
                                                                                "DecisionViewpoints.TopicViewController");
            ITopic topic = Topic.Load(element);
            topicViewController.Topic = topic;
            SynchronizationManager.Instance.Subscribe(element.GUID, topicViewController, element.Name);
        }

        public bool IsOpenTab(IEAElement element)
        {
            return EAMain.Repository.IsTabOpen(element.Name) > 0;
        }

        public void FocusTab(IEAElement element)
        {
            EAMain.Repository.ActivateTab(element.Name);
            SynchronizationManager.Instance.Update(element.GUID);
        }

        public void CloseTab(IEAElement element)
        {
            // EAFacade.EAMain.Repository.C
        }

        /********************************************************************************************
        ** Invoke View Change methods
        ********************************************************************************************/

        internal static void InvokeViewChange(string elementGUID, EANativeType eANativeType)
        {
            if (eANativeType == EANativeType.Diagram)
            {
                IEAElement element = EAMain.Repository.GetElementByGUID(elementGUID);
                IEADiagram[] diagrams = element.GetDiagrams();
                if (diagrams.Length == 1)
                {
                    IEADiagram diagram = diagrams[0];
                    diagram.OpenAndSelectElement(element);
                }
                else if (diagrams.Length >= 2)
                {
                    var selectForm = new SelectDiagram(diagrams);
                    if (selectForm.ShowDialog() == DialogResult.OK)
                    {
                        IEADiagram diagram = selectForm.GetSelectedDiagram();
                        diagram.OpenAndSelectElement(element);
                    }
                }
            }
            else if (eANativeType == EANativeType.Element)
            {
                Instance.OnContextItemDoubleClicked(elementGUID, eANativeType);
            }
        }


        //void OpenHistoryDecisionTab(IEAElement element)
        //{
        //    DialogResult dialogResult =
        //       MessageBox.Show(
        //           Messages.DialogOpenLatestDecision,
        //           Messages.DialogOpenLatestDecisionTitle,
        //           MessageBoxButtons.YesNo,
        //           MessageBoxIcon.Information);

        //    if (dialogResult == DialogResult.Yes)
        //    {                        
        //        string originalguid = element.GetTaggedValueByName(EATaggedValueKeys.OriginalDecisionGuid);
        //        IEAElement originalElement = EAFacade.EAMain.Repository.GetElementByGUID(originalguid);
        //        IDetailView detailView = EAFacade.EAMain.Repository.AddTab(originalElement.Name, "DecisionViewpoints.DetailView");
        //        IDecision decision = new Decision(originalElement);

        //        InitializeNewOpenedTab(originalElement.GUID, detailView, decision);
        //    }
        //}
        public void OpenDecisionDetailView(IDecision decision)
        {
            IEARepository _repository = EAMain.Repository;
            IEAElement _element = _repository.GetElementByGUID(decision.GUID);
            IEARepository repository = EAMain.Repository;
            if (repository.IsTabOpen(decision.Name) > 0)
            {
                EAMain.Repository.ActivateTab(decision.Name);
                SynchronizationManager.Instance.Update(_element.GUID);
            }
            else
            {
                IDetailViewController detailViewController = _repository.AddTab(decision.Name,
                                                                                "DecisionViewpoints.DetailViewController");
                detailViewController.Decision = decision;
                SynchronizationManager.Instance.Subscribe(_element.GUID, detailViewController, decision.Name);
            }
        }
    }
}