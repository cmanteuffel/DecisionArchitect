using System.Linq;
using System.Text;
using DecisionViewpointsCustomViews.Model;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using EAFacade.Model;

namespace DecisionViewpoints.Model.Reporting
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
            SetPlaceholder(NewSlidePart, "{title}", _forces.Name);

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

            // insert the requirement name, concern(s), and ratings
            foreach (EAElement requirement in _forces.GetRequirements())
            {
                var reqRow = new TableRow {Height = 370840L};
                reqRow.AppendChild(CreateTextCell(requirement.Name));
                // insert concern(s)
                var concCellText = new StringBuilder();
                foreach (var concern in _forces.GetConcerns())
                {
                    if (concern.Key.GUID != requirement.GUID) continue;
                    int concernIndex = 0;
                    foreach (EAElement concernText in concern.Value)
                    {
                        if (concernIndex++ > 0)
                        {
                            concCellText.Append(", ");
                        }
                        concCellText.Append(concernText.Name);
                    }
                    break;
                }
                reqRow.AppendChild(CreateTextCell(concCellText.ToString()));
                // insert ratings
                foreach (Rating rating in _forces.GetRatings())
                {
                    if (rating.RequirementGUID != requirement.GUID) continue;
                    if (_forces.GetDecisions().Any(decision => rating.DecisionGUID == decision.GUID))
                    {
                        reqRow.AppendChild(CreateTextCell(rating.Value));
                    }
                }
                tbl.AppendChild(reqRow);
            }
        }

        private static TableCell CreateTextCell(string text)
        {
            var tc = new TableCell(
                new TextBody(
                    new BodyProperties(),
                    new Paragraph(
                        new Run(
                            new Text(text)))),
                new TableCellProperties());
            return tc;
        }
    }
}