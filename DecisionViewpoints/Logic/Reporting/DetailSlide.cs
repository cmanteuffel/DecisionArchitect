using System.Collections.Generic;
using System.Linq;
using System.Text;
using DecisionViewpoints.Model;
using DecisionViewpoints.Model.Reporting;
using DocumentFormat.OpenXml.Packaging;
using EAFacade.Model;


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
            foreach (IEAConnector connector in _decision.Connectors.Where(connector => connector.IsRelationship()))
            {
                // Related Decisions
                if (!connector.Stereotype.Equals("alternative for"))
                {
                    relatedDecisions.AppendLine(connector.ClientId == _decision.ID
                                                    ? "<<this>> " + _decision.Name + " - " + connector.Stereotype +
                                                      " - " + connector.GetSupplier().Name
                                                    : "" + connector.GetClient().Name + " - " + connector.Stereotype +
                                                      " - <<this>> " + _decision.Name);
                }
                    // Alternative Decisions
                else if (connector.Stereotype.Equals("alternative for"))
                {
                    alternativeDecisions.AppendLine(connector.ClientId == _decision.ID
                                                        ? "<<this>> " + _decision.Name + " - " + connector.Stereotype +
                                                          " - " + connector.GetSupplier().Name
                                                        : connector.GetClient().Name + " - " + connector.Stereotype +
                                                          " - <<this>> " + _decision.Name);
                }
            }

            // Related Requirements
            var relatedRequirements = new StringBuilder();
            IEnumerable<Rating> forces = _decision.GetForces();
            foreach (Rating rating in forces)
            {
                IEAElement req = EAFacade.EA.Repository.GetElementByGUID(rating.RequirementGUID);
                IEAElement concern = EAFacade.EA.Repository.GetElementByGUID(rating.ConcernGUID);
                relatedRequirements.AppendLine(req.Name + " - " + req.Notes);
            }

            //Traces Componenets
            var traces = new StringBuilder();
            foreach (IEAElement element in _decision.GetTraces())
            {
                string trace = element.GetProjectPath() + "/" + element.Name;
                traces.AppendLine(trace);
            }


            SetPlaceholder(NewSlidePart, DecisionDataTags.Name, _decision.Name);
            SetPlaceholder(NewSlidePart, DecisionDataTags.State, _decision.State);
            SetPlaceholder(NewSlidePart, DecisionDataTags.Topic, _decision.HasTopic() ? _decision.Topic.Name : "");
            SetPlaceholder(NewSlidePart, DecisionDataTags.Issue, _decision.Problem);
            SetPlaceholder(NewSlidePart, DecisionDataTags.DecisionText, _decision.Solution);
            SetPlaceholder(NewSlidePart, DecisionDataTags.Arguments, _decision.Argumentation);
            SetPlaceholder(NewSlidePart, DecisionDataTags.Alternatives, alternativeDecisions.ToString());
            SetPlaceholder(NewSlidePart, DecisionDataTags.RelatedDecisions, relatedDecisions.ToString());
            SetPlaceholder(NewSlidePart, DecisionDataTags.RelatedRequirements, relatedRequirements.ToString());
            SetPlaceholder(NewSlidePart, DecisionDataTags.Traces, traces.ToString());
        }
    }
}