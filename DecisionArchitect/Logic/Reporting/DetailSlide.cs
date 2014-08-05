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

using System.Collections.Generic;
using System.Linq;
using System.Text;
using DecisionArchitect.Model;
using DocumentFormat.OpenXml.Packaging;
using EAFacade.Model;

namespace DecisionArchitect.Logic.Reporting
{
    public class DetailSlide : AbstractSlide
    {
        private readonly IDecision _decision;

        public static class Placeholder
        {
            public const string Name = "{name}";
            public const string State = "{state}";
            public const string Topic = "{topic}";
            public const string Issue = "{issue}";
            public const string DecisionText = "{decision}";
            public const string Alternatives = "{alternatives}";
            public const string Arguments = "{arguments}";
            public const string RelatedDecisions = "{decisions}";
            public const string RelatedForces = "{forces}";
            public const string Traces = "{traces}";
        }


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

            // Related Forces
            var relatedForces = new StringBuilder();
            IEnumerable<Rating> forces = _decision.GetForces();
            foreach (Rating rating in forces)
            {
                IEAElement force = EAFacade.EA.Repository.GetElementByGUID(rating.ForceGUID);
                IEAElement concern = EAFacade.EA.Repository.GetElementByGUID(rating.ConcernGUID);
                relatedForces.AppendLine(force.Name + " - " + force.Notes);
            }

            //Traces Componenets
            var traces = new StringBuilder();
            foreach (IEAElement element in _decision.GetTraces())
            {
                string trace = element.GetProjectPath() + "/" + element.Name;
                traces.AppendLine(trace);
            }


            SetPlaceholder(NewSlidePart, Placeholder.Name, _decision.Name);
            SetPlaceholder(NewSlidePart, Placeholder.State, _decision.State);
            SetPlaceholder(NewSlidePart, Placeholder.Topic, _decision.HasTopic() ? _decision.Topic.Name : "");
            SetPlaceholder(NewSlidePart, Placeholder.Issue, "");
            SetPlaceholder(NewSlidePart, Placeholder.DecisionText, "");
            SetPlaceholder(NewSlidePart, Placeholder.Arguments, _decision.Rationale);
            SetPlaceholder(NewSlidePart, Placeholder.Alternatives, alternativeDecisions.ToString());
            SetPlaceholder(NewSlidePart, Placeholder.RelatedDecisions, relatedDecisions.ToString());
            SetPlaceholder(NewSlidePart, Placeholder.RelatedForces, relatedForces.ToString());
            SetPlaceholder(NewSlidePart, Placeholder.Traces, traces.ToString());
        }
    }
}
