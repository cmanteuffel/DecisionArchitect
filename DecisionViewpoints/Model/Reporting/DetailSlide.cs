using System.Linq;
using System.Text;
using DecisionViewpointsCustomViews.Model;
using DocumentFormat.OpenXml.Packaging;
using EAFacade.Model;

namespace DecisionViewpoints.Model.Reporting
{
    public class DetailSlide : AbstractSlide
    {
        private readonly IDecision _decision;

        public DetailSlide(PresentationDocument document, SlidePart templateSlide, IDecision decision)
            : base(document, templateSlide)
        {
            _decision = decision;
        }

        public override void FillContent()
        {
            var relatedDecisionBuilder = new StringBuilder();
            foreach (EAConnector connector in _decision.GetConnectors().Where(connector => connector.IsRelationship()))
            {
                relatedDecisionBuilder.AppendLine(connector.ClientId == _decision.ID
                                                      ? string.Format("This <<{1}>> {0}", connector.GetSupplier().Name,
                                                                      connector.Stereotype)
                                                      : string.Format("{0} <<{1}>> This", connector.GetClient().Name,
                                                                      connector.Stereotype));
            }
            SetPlaceholder(NewSlidePart, DecisionDataTags.Name, _decision.Name);
            SetPlaceholder(NewSlidePart, DecisionDataTags.State, _decision.State);
            SetPlaceholder(NewSlidePart, DecisionDataTags.Group, _decision.Group);
            SetPlaceholder(NewSlidePart, DecisionDataTags.Issue, _decision.Issue);
            SetPlaceholder(NewSlidePart, DecisionDataTags.DecisionText, _decision.DecisionText);
            SetPlaceholder(NewSlidePart, DecisionDataTags.Alternatives, _decision.Alternatives);
            SetPlaceholder(NewSlidePart, DecisionDataTags.Arguments, _decision.Arguments);
            SetPlaceholder(NewSlidePart, DecisionDataTags.RelatedDecisions, relatedDecisionBuilder.ToString());
            SetPlaceholder(NewSlidePart, DecisionDataTags.RelatedRequirements, _decision.RelatedRequirements);
        }
    }
}