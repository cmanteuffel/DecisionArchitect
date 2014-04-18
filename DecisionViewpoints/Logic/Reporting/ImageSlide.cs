using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
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
        private readonly IEADiagram _diagram;


        public ImageSlide(PresentationDocument document, SlidePart templateSlide, IEADiagram diagram)
            : base(document, templateSlide)
        {
            _diagram = diagram;
        }

        public override void FillContent()
        {
            ImagePart imagePart = NewSlidePart.AddImagePart(ImagePartType.Emf, NewImageName + _imgId++);
            FileStream fs = _diagram.DiagramToStream();

            imagePart.FeedData(fs);
            SwapPhoto(NewSlidePart, NewSlidePart.GetIdOfPart(imagePart));
            SetPlaceholder(NewSlidePart, "{title}", _diagram.Name);

            //cleanup:
            fs.Close();
            File.Delete(fs.Name);
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