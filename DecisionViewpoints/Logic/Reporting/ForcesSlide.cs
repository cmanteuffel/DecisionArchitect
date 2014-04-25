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
using DecisionViewpoints.Model;
using DecisionViewpoints.Model.Reporting;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using EAFacade.Model;


namespace DecisionViewpoints.Logic.Reporting
{
    public class ForcesSlide : AbstractSlide
    {
        private readonly IForcesModel _forces;

        public ForcesSlide(PresentationDocument document, SlidePart templateSlide, IForcesModel forces)
            : base(document, templateSlide)
        {
            _forces = forces;
        }

        public override void FillContent()
        {
            SetPlaceholder(NewSlidePart, "{title}", _forces.DiagramName);

            Table tbl = NewSlidePart.Slide.Descendants<Table>().First();

            TableGrid tableGrid = tbl.TableGrid;
            for (int i = 0; i != _forces.GetDecisions().Length; i++)
            {
                var gc = new GridColumn {Width = 1234000L};
                tableGrid.AppendChild(gc);
            }

            // insert the concern header and the decisions names
            TableRow decRow = tbl.Descendants<TableRow>().First();
            foreach (
                TableCell decCell in
                    _forces.GetDecisions()
                           .Select(decision => CreateTextCell(decision.Name)))
            {
                decRow.AppendChild(decCell);
            }

            foreach (var concernsPerRequirement in _forces.GetConcernsPerRequirement())
            {
                IEAElement requirement = concernsPerRequirement.Key;
                List<IEAElement> concerns = concernsPerRequirement.Value;

                foreach (IEAElement concern in concerns)
                {
                    var reqRow = new TableRow {Height = 370840L};
                    reqRow.AppendChild(CreateTextCell(requirement.Name));
                    reqRow.AppendChild(CreateTextCell(concern.Name));

                    // insert ratings
                    foreach (Rating rating in _forces.GetRatings())
                    {
                        if (rating.RequirementGUID != requirement.GUID || rating.ConcernGUID != concern.GUID) continue;
                        if (_forces.GetDecisions().Any(decision => rating.DecisionGUID == decision.GUID))
                        {
                            reqRow.AppendChild(CreateTextCell(rating.Value));
                        }
                    }
                    tbl.AppendChild(reqRow);
                }
            }
        }

        private static TableCell CreateTextCell(string text)
        {
            var tc = new TableCell(
                new TextBody(
                    new BodyProperties(),
                    new Paragraph(
                        new Run(
                            new RunProperties {FontSize = 1200},
                            new Text(text)))),
                new TableCellProperties());
            return tc;
        }
    }
}
