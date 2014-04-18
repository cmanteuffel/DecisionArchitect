using System.Linq;
using System.Text;
using DecisionViewpoints.Model.Reporting;
using DecisionViewpointsCustomViews.Model;
using DocumentFormat.OpenXml.Packaging;
using EAFacade.Model;
using System;

namespace DecisionViewpoints.Logic.Reporting
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
            var relatedDecisions = new StringBuilder();
            var alternativeDecisions = new StringBuilder();
            foreach (EAConnector connector in _decision.GetConnectors().Where(connector => connector.IsRelationship()))
            {
                // Related Decisions
                if (!connector.Stereotype.Equals("alternative for"))
                {
                    relatedDecisions.AppendLine(connector.ClientId == _decision.ID
                        ? "<<this>> " + _decision.Name + " - " + connector.Stereotype + " - " + connector.GetSupplier().Name
                        : "" + connector.GetClient().Name + " - " + connector.Stereotype + " - <<this>> " + _decision.Name);
                }
                // Alternative Decisions
                else if (connector.Stereotype.Equals("alternative for"))
                {
                    alternativeDecisions.AppendLine(connector.ClientId == _decision.ID
                        ? "<<this>> " + _decision.Name + " - " + connector.Stereotype + " - " + connector.GetSupplier().Name
                        : connector.GetClient().Name + " - " + connector.Stereotype + " - <<this>> " + _decision.Name);
                }
            }

            // Related Requirements
            var relatedRequirements = new StringBuilder();
            var forces = _decision.GetForces();
            foreach (var rating in forces)
            {
                var req = EARepository.Instance.GetElementByGUID(rating.RequirementGUID);
                var concern = EARepository.Instance.GetElementByGUID(rating.ConcernGUID);
                relatedRequirements.AppendLine(req.Name + " - " + req.Notes);
            }

            //Traces Componenets
            var traces = new StringBuilder();
            foreach (var element in _decision.GetTraces())
            {
                var trace = element.GetProjectPath() + "/" + element.Name;
                traces.AppendLine(trace);
            }


            SetPlaceholder(NewSlidePart, DecisionDataTags.Name, _decision.Name);
            SetPlaceholder(NewSlidePart, DecisionDataTags.State, _decision.State);
            SetPlaceholder(NewSlidePart, DecisionDataTags.Topic, _decision.HasTopic() ? _decision.GetTopic().Name : "");
            SetPlaceholder(NewSlidePart, DecisionDataTags.Issue, _decision.Issue);
            SetPlaceholder(NewSlidePart, DecisionDataTags.DecisionText, _decision.DecisionText);
            SetPlaceholder(NewSlidePart, DecisionDataTags.Arguments, _decision.Arguments);
            SetPlaceholder(NewSlidePart, DecisionDataTags.Alternatives, alternativeDecisions.ToString());
            SetPlaceholder(NewSlidePart, DecisionDataTags.RelatedDecisions, relatedDecisions.ToString());
            SetPlaceholder(NewSlidePart, DecisionDataTags.RelatedRequirements, relatedRequirements.ToString());
            SetPlaceholder(NewSlidePart, DecisionDataTags.Traces, traces.ToString());
        }
    }
}