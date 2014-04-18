using DecisionViewpointsCustomViews.Model;
using DocumentFormat.OpenXml.Packaging;

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
        }
    }
}