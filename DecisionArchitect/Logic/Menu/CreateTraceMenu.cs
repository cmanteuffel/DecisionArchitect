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
using System.Globalization;
using System.Windows.Forms;
using DecisionArchitect.View;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Logic.Menu
{
    internal class CreateTraceMenu
    {
        public static void CreateAndTraceDecision()
        {
            IEARepository repository = EAMain.Repository;
            if (repository.GetContextItemType() == EANativeType.Element)
            {
                var eaelement = repository.GetContextObject<IEAElement>();
                if (eaelement != null && !EAMain.IsDecision(eaelement) && !EAMain.IsTopic(eaelement))
                {
                    string nameSuggestion = string.Format(Messages.NameSuggestionDecision, eaelement.Name);
                    var createDecisionView = new CreateDecision(nameSuggestion);
                    if (createDecisionView.ShowDialog() == DialogResult.OK)
                    {
                        IEAPackage dvPackage = createDecisionView.GetDecisionViewPackage();
                        IEAElement decision = dvPackage.CreateElement(createDecisionView.GetName(),
                                                                      createDecisionView.GetState(),
                                                                      EAConstants.ActionMetaType);
                        decision.MetaType = EAConstants.DecisionMetaType;
                        decision.AddTaggedValue(EATaggedValueKeys.DecisionStateModifiedDate,
                                                DateTime.Now.ToString(CultureInfo.InvariantCulture));
                        eaelement.ConnectTo(decision, EAConstants.AbstractionMetaType, EAConstants.RelationTrace);
                        decision.Update();

                        dvPackage.RefreshElements();
                        repository.RefreshModelView(dvPackage.ID);
                        decision.ShowInProjectView();
                    }
                }
            }
        }

        public static void CreateAndTraceTopic()
        {
            IEARepository repository = EAMain.Repository;
            if (repository.GetContextItemType() == EANativeType.Element)
            {
                var eaelement = repository.GetContextObject<IEAElement>();
                if (eaelement != null && !EAMain.IsDecision(eaelement) && !EAMain.IsTopic(eaelement))
                {
                    string nameSuggestion = string.Format(Messages.NameSuggestionTopic, eaelement.Name);
                    var createTopicView = new CreateTopic(nameSuggestion);
                    if (createTopicView.ShowDialog() == DialogResult.OK)
                    {
                        IEAPackage dvPackage = createTopicView.GetDecisionViewPackage();
                        IEAElement topic = dvPackage.CreateElement(createTopicView.GetName(),
                                                                   EAConstants.TopicStereoType,
                                                                   EAConstants.ActivityMetaType);
                        topic.MetaType = EAConstants.TopicMetaType;
                        topic.AddTaggedValue(EATaggedValueKeys.DecisionStateModifiedDate,
                                             DateTime.Now.ToString(CultureInfo.InvariantCulture));
                        eaelement.ConnectTo(topic, EAConstants.AbstractionMetaType, EAConstants.RelationTrace);
                        topic.Update();

                        dvPackage.RefreshElements();
                        repository.RefreshModelView(dvPackage.ID);
                        topic.ShowInProjectView();
                    }
                }
            }
        }
    }
}