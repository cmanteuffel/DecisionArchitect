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
using DecisionArchitect.Utilities;
using DocumentFormat.OpenXml.Packaging;
using ITopic = DecisionArchitect.Model.New.ITopic;

namespace DecisionArchitect.Logic.Reporting
{
    internal class TopicDetailSlide : AbstractSlide
    {
        private readonly ITopic _topic;
        public static class TopicDataTags
        {
            public const string Name = "{topic}";
            public const string Description = "{description}";
        }
        public TopicDetailSlide(PresentationDocument document, SlidePart templateSlide, ITopic topic)
            : base(document, templateSlide)
        {
            _topic = topic;
        }

        public override void FillContent()
        {
            SetPlaceholder(NewSlidePart, TopicDataTags.Name, _topic.Name);
            SetPlaceholder(NewSlidePart, TopicDataTags.Description,
                           Utils.FormattedRtfToPlainText(_topic.Description));
        }
    }
}