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
using EAFacade;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Menu
{
    class CreateTraceMenu
    {

        public static void CreateAndTraceDecision()
        {
            IEARepository repository = EAFacade.EA.Repository;
            if (repository.GetContextItemType() == EANativeType.Element)
            {
                var eaelement = repository.GetContextObject<IEAElement>();
                if (eaelement != null && !eaelement.IsDecision() && !eaelement.IsTopic())
                {

                    var nameSuggestion = string.Format(Messages.NameSuggestionDecision, eaelement.Name);
                    var createDecisionView = new CreateDecision(nameSuggestion);
                    if (createDecisionView.ShowDialog() == DialogResult.OK)
                    {

                        var dvPackage = createDecisionView.GetDecisionViewPackage();
                        var decision = dvPackage.CreateElement(createDecisionView.GetName(), createDecisionView.GetState(), EAConstants.ActionMetaType);
                        decision.MetaType = EAConstants.DecisionMetaType;
                        decision.AddTaggedValue(EATaggedValueKeys.DecisionStateModifiedDate, DateTime.Now.ToString(CultureInfo.InvariantCulture));
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
            IEARepository repository = EAFacade.EA.Repository;
            if (repository.GetContextItemType() == EANativeType.Element)
            {
                var eaelement = repository.GetContextObject<IEAElement>();
                if (eaelement != null && !eaelement.IsDecision() && !eaelement.IsTopic())
                {
                    var nameSuggestion = string.Format(Messages.NameSuggestionTopic, eaelement.Name);
                    var createTopicView = new CreateTopic(nameSuggestion);
                    if (createTopicView.ShowDialog() == DialogResult.OK)
                    {
                        var dvPackage = createTopicView.GetDecisionViewPackage();
                        var topic = dvPackage.CreateElement(createTopicView.GetName(), EAConstants.TopicStereoType, EAConstants.ActivityMetaType);
                        topic.MetaType = EAConstants.TopicMetaType;
                        topic.AddTaggedValue(EATaggedValueKeys.DecisionStateModifiedDate, DateTime.Now.ToString(CultureInfo.InvariantCulture));
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
