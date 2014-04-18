using DecisionViewpoints.Model.Reporting;
using DecisionViewpointsCustomViews.Model;
using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionViewpoints.Logic.Reporting
{
    class TopicDetailSlide: AbstractSlide
    {
        private readonly ITopic _topic;

        public TopicDetailSlide(PresentationDocument document, SlidePart templateSlide, ITopic topic)
            : base(document, templateSlide)
        {
            _topic = topic;
        }

        public override void FillContent()
        {
            SetPlaceholder(NewSlidePart, TopicDataTags.Name, _topic.Name);
            SetPlaceholder(NewSlidePart, TopicDataTags.Description, _topic.Description);
        }
    }
}
