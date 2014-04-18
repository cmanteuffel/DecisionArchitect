using DecisionViewpoints.Model;
using DecisionViewpoints.Model.Reporting;
using DocumentFormat.OpenXml.Packaging;

namespace DecisionViewpoints.Logic.Reporting
{
    internal class TopicDetailSlide : AbstractSlide
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