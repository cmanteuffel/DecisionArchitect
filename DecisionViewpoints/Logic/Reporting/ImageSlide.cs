using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using DecisionViewpoints.Model.Reporting;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using EAFacade;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Reporting
{
    public class ImageSlide : AbstractSlide
    {
        private const string NewImageName = "newImage";
        private static int _imgId;
        private readonly EADiagram _diagram;

        public ImageSlide(PresentationDocument document, SlidePart templateSlide, EADiagram diagram)
            : base(document, templateSlide)
        {
            _diagram = diagram;
        }

        public override void FillContent()
        {
            ImagePart imagePart = NewSlidePart.AddImagePart(ImagePartType.Jpeg, NewImageName + _imgId++);
            _diagram.CopyToClipboard();
            Image image = null;
            if (Clipboard.ContainsImage())
            {
                image = Clipboard.GetImage();
            }
            imagePart.FeedData(Utilities.ImageToStream(image, ImageFormat.Jpeg));
            SwapPhoto(NewSlidePart, NewSlidePart.GetIdOfPart(imagePart));
            SetPlaceholder(NewSlidePart, "{title}", _diagram.Name);
        }

        private static void SwapPhoto(SlidePart slidePart, string imgId)
        {
            //Find the placeholder image
            Blip blip = slidePart.Slide.Descendants<Blip>().First();
            //Swap out the placeholder image with the image
            blip.Embed = imgId;
            slidePart.Slide.Save();
        }
    }
}