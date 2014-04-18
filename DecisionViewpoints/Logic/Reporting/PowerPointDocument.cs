using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DecisionViewpointsCustomViews.Model;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using EAFacade;
using EAFacade.Model;
using A = DocumentFormat.OpenXml.Drawing;

namespace DecisionViewpoints.Logic.Reporting
{
    public class PowerPointDocument : IReportDocument
    {
        // These ids are read from the PowerPointTemplate. If the tempalte change then these need to be verified
        // that either remain the same, otherwise change them accordingly
        private const string DetailTemplateSlideId = "rId2";
        private const string ImageTemplateSlideId = "rId3";

        private const string NewSlideName = "newSlide";
        private const string NewImageName = "newImage";
        private readonly string _filename;
        private SlidePart _detailSlideTemplate;
        private PresentationDocument _doc;
        private SlidePart _imageSlideTemplate;
        private int _imgId;
        private int _slideId;

        public PowerPointDocument(string filename)
        {
            using (
                PresentationDocument ppDoc = PresentationDocument.Create(filename, PresentationDocumentType.Presentation)
                )
            {
                var pp = new PowerPointTemplate();
                pp.CreateParts(ppDoc);
            }
            _filename = filename;
        }

        public void Open()
        {
            string filepath = string.Format("{0}/{1}", Directory.GetCurrentDirectory(), _filename);
            _doc = PresentationDocument.Open(filepath, true);
            _detailSlideTemplate = _doc.PresentationPart.GetPartById(DetailTemplateSlideId) as SlidePart;
            _imageSlideTemplate = _doc.PresentationPart.GetPartById(ImageTemplateSlideId) as SlidePart;
        }

        public void InsertDecisionTable(IDecision decision)
        {
            var newSlidePart = _doc.PresentationPart.AddNewPart<SlidePart>(NewSlideName + _slideId);

            //copy the contents of the template slide to the new slide and attach the appropriate layout
            newSlidePart.FeedData(_detailSlideTemplate.GetStream(FileMode.Open));
            newSlidePart.AddPart(_detailSlideTemplate.SlideLayoutPart,
                                 _detailSlideTemplate.GetIdOfPart(_detailSlideTemplate.SlideLayoutPart));

            var relatedDecisionBuilder = new StringBuilder();
            foreach (EAConnector connector in decision.GetConnectors().Where(connector => connector.IsRelationship()))
            {
                relatedDecisionBuilder.AppendLine(connector.ClientId == decision.ID
                                                      ? string.Format("This <<{1}>> {0}", connector.GetSupplier().Name,
                                                                      connector.Stereotype)
                                                      : string.Format("{0} <<{1}>> This", connector.GetClient().Name,
                                                                      connector.Stereotype));
            }

            SetPlaceholder(newSlidePart, DecisionDataTags.Name, decision.Name);
            SetPlaceholder(newSlidePart, DecisionDataTags.State, decision.State);
            SetPlaceholder(newSlidePart, DecisionDataTags.Group, decision.Group);
            SetPlaceholder(newSlidePart, DecisionDataTags.Issue, decision.Issue);
            SetPlaceholder(newSlidePart, DecisionDataTags.DecisionText, decision.DecisionText);
            SetPlaceholder(newSlidePart, DecisionDataTags.Alternatives, decision.Alternatives);
            SetPlaceholder(newSlidePart, DecisionDataTags.Arguments, decision.Arguments);
            SetPlaceholder(newSlidePart, DecisionDataTags.RelatedDecisions, relatedDecisionBuilder.ToString());
            SetPlaceholder(newSlidePart, DecisionDataTags.RelatedRequirements, decision.RelatedRequirements);

            //save the changes to the slide
            newSlidePart.Slide.Save();

            AddNewSlide(newSlidePart);

            _slideId++;
        }

        public void InsertForcesTable(IForcesModel forces)
        {
            //throw new NotImplementedException();
        }

        public void InsertDiagramImage(EADiagram diagram)
        {
            var newSlidePart = _doc.PresentationPart.AddNewPart<SlidePart>(NewSlideName + _slideId);

            newSlidePart.FeedData(_imageSlideTemplate.GetStream(FileMode.Open));
            newSlidePart.AddPart(_imageSlideTemplate.SlideLayoutPart,
                                 _imageSlideTemplate.GetIdOfPart(_imageSlideTemplate.SlideLayoutPart));

            ImagePart imagePart = newSlidePart.AddImagePart(ImagePartType.Jpeg, NewImageName + _imgId);

            diagram.CopyToClipboard();

            Image image = null;
            if (Clipboard.ContainsImage())
            {
                image = Clipboard.GetImage();
            }
            imagePart.FeedData(Utilities.ImageToStream(image, ImageFormat.Jpeg));

            SwapPhoto(newSlidePart, newSlidePart.GetIdOfPart(imagePart));

            SetPlaceholder(newSlidePart, "{title}", diagram.Name);

            newSlidePart.Slide.Save();

            AddNewSlide(newSlidePart);

            _imgId++;
            _slideId++;
        }

        public void Close()
        {
            DeleteTemplateSlide(_detailSlideTemplate, DetailTemplateSlideId);
            DeleteTemplateSlide(_imageSlideTemplate, ImageTemplateSlideId);
            _doc.PresentationPart.Presentation.Save();
            _doc.Close();
        }

        private void AddNewSlide(SlidePart newSlidePart)
        {
            //need to assign an id to the new slide and add it to the slideIdList
            //first figure out the largest existing id
            SlideIdList slideIdList = _doc.PresentationPart.Presentation.SlideIdList;
            uint[] maxSlideId = {1};

            foreach (
                SlideId slideId in
                    slideIdList.ChildElements.Cast<SlideId>().Where(slideId => slideId.Id > maxSlideId[0]))
            {
                maxSlideId[0] = slideId.Id;
            }

            //assign an id and add the new slide at the end of the list
            var newSlideId = new SlideId
                {
                    Id = ++maxSlideId[0],
                    RelationshipId = _doc.PresentationPart.GetIdOfPart(newSlidePart)
                };
            slideIdList.AppendChild(newSlideId);
        }

        private static void SwapPhoto(SlidePart slidePart, string imgId)
        {
            //Find the placeholder image
            A.Blip blip = slidePart.Slide.Descendants<A.Blip>().First();
            //Swap out the placeholder image with the image
            blip.Embed = imgId;
            slidePart.Slide.Save();
        }

        private static void SetPlaceholder(SlidePart slidePart, string placeholder, string value)
        {
            List<A.Text> textList =
                slidePart.Slide.Descendants<A.Text>().Where(t => t.Text.Equals(placeholder)).ToList();
            foreach (A.Text text in textList) text.Text = value;
        }

        private void DeleteTemplateSlide(SlidePart slidePart, string id)
        {
            //delete the template slide and any references
            SlideIdList slideIdList = _doc.PresentationPart.Presentation.SlideIdList;

            foreach (
                SlideId slideId in
                    slideIdList.ChildElements.Cast<SlideId>()
                               .Where(slideId => slideId.RelationshipId.Value.Equals(id)))
            {
                slideIdList.RemoveChild(slideId);
            }

            _doc.PresentationPart.DeletePart(slidePart);
            _doc.PresentationPart.Presentation.Save();
        }
    }
}