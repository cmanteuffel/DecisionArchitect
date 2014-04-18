using System.Collections.Generic;
using System.IO;
using System.Linq;
using DecisionViewpointsCustomViews.Model;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using EAFacade.Model;
using A = DocumentFormat.OpenXml.Drawing;

namespace DecisionViewpoints.Logic.Reporting
{
    public class PowerPointDocument : IReportDocument
    {
        private const string TemplateSlideId = "rId2";
        private const string NewSlideName = "newSlide";
        private readonly string _filename;
        private PresentationDocument _doc;
        private int _slideId;
        private SlidePart _slideTemplate;

        public PowerPointDocument(string filename)
        {
            using (
                PresentationDocument ppDoc = PresentationDocument.Create(filename, PresentationDocumentType.Presentation)
                )
            {
                var pp = new PowerPoint();
                pp.CreateParts(ppDoc);
            }
            _filename = filename;
        }

        public void Open()
        {
            string filepath = string.Format("{0}/{1}", Directory.GetCurrentDirectory(), _filename);
            _doc = PresentationDocument.Open(filepath, true);
            _slideTemplate = _doc.PresentationPart.GetPartById(TemplateSlideId) as SlidePart;
        }

        public void InsertDecisionTable(IDecision decision)
        {
            var newSlidePart = _doc.PresentationPart.AddNewPart<SlidePart>(NewSlideName + _slideId);

            //copy the contents of the template slide to the new slide and attach the appropriate layout
            newSlidePart.FeedData(_slideTemplate.GetStream(FileMode.Open));
            newSlidePart.AddPart(_slideTemplate.SlideLayoutPart,
                                 _slideTemplate.GetIdOfPart(_slideTemplate.SlideLayoutPart));

            SetPlaceholder(newSlidePart, DecisionDataTags.Name, decision.Name);
            SetPlaceholder(newSlidePart, DecisionDataTags.State, decision.State);
            SetPlaceholder(newSlidePart, DecisionDataTags.Group, decision.Group);
            SetPlaceholder(newSlidePart, DecisionDataTags.Issue, decision.Issue);
            SetPlaceholder(newSlidePart, DecisionDataTags.DecisionText, decision.DecisionText);
            SetPlaceholder(newSlidePart, DecisionDataTags.Alternatives, decision.Alternatives);
            SetPlaceholder(newSlidePart, DecisionDataTags.Arguments, decision.Arguments);
            SetPlaceholder(newSlidePart, DecisionDataTags.RelatedDecisions, "");
            SetPlaceholder(newSlidePart, DecisionDataTags.RelatedRequirements, decision.RelatedRequirements);

            //save the changes to the slide
            newSlidePart.Slide.Save();

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

            _slideId++;
        }

        public void InsertForcesTable(IForcesModel forces)
        {
            //throw new NotImplementedException();
        }

        public void InsertDiagramImage(EADiagram diagram)
        {
            //throw new NotImplementedException();
        }

        public void Close()
        {
            DeleteTemplateSlide();
            _doc.PresentationPart.Presentation.Save();
            _doc.Close();
        }

        private static void SetPlaceholder(SlidePart slidePart, string placeholder, string value)
        {
            List<A.Text> textList =
                slidePart.Slide.Descendants<A.Text>().Where(t => t.Text.Equals(placeholder)).ToList();
            foreach (A.Text text in textList) text.Text = value;
        }

        private void DeleteTemplateSlide()
        {
            //delete the template slide and any references
            SlideIdList slideIdList = _doc.PresentationPart.Presentation.SlideIdList;

            foreach (
                SlideId slideId in
                    slideIdList.ChildElements.Cast<SlideId>()
                               .Where(slideId => slideId.RelationshipId.Value.Equals(TemplateSlideId)))
            {
                slideIdList.RemoveChild(slideId);
            }

            _doc.PresentationPart.DeletePart(_slideTemplate);
            _doc.PresentationPart.Presentation.Save();
        }
    }
}