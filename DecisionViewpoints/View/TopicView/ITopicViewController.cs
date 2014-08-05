/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    Marc Holterman (University of Groningen)
*/

using DecisionViewpoints.Model;
using DecisionViewpoints.View.Controller;

namespace DecisionViewpoints.View
{
    public interface ITopicViewController : ICustomViewController
    {
        string TopicName { get; set; }
        string TopicDescription { get; set; }

        void setTopic(ITopic topic);
    }
}
