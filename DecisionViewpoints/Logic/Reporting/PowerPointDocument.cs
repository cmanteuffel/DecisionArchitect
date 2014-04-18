using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DecisionViewpoints.Logic.Reporting;
using DecisionViewpointsCustomViews.Model;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using EAFacade;
using EAFacade.Model;

namespace DecisionViewpoints.Model.Reporting
{
    public class PowerPointDocument : IReportDocument
    {
        // These ids are read from the PowerPointTemplate. If the tempalte change then these need to be verified
        // that either remain the same, otherwise change them accordingly
        private const string DetailTemplateSlideId = "rId2";
        private const string ImageTemplateSlideId = "rId3";
        private const string ForcesTemplateSlideId = "rId4";

        private readonly string _filename;
        private SlidePart _detailSlideTemplate;
        private PresentationDocument _doc;
        private SlidePart _forcesSlideTemplate;
        private SlidePart _imageSlideTemplate;

        private int _topicCounter = 0;
        private int _decisionCounter = 0;

        public PowerPointDocument(string filename)
        {
            //_filename = String.Format("{0}\\{1}", Utilities.GetDocumentsDirectory(), filename);//original
            _filename = filename;//angor
            //MessageBox.Show("Document filename: " + _filename);//angor DEBUG
            using (
                PresentationDocument ppDoc = PresentationDocument.Create(_filename, PresentationDocumentType.Presentation)
                )
            {
                var pp = new PowerPointTemplate();
                pp.CreateParts(ppDoc);
            }
        }

        public void Open()
        {
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), _filename);
            _doc = PresentationDocument.Open(filepath, true);
            _detailSlideTemplate = (SlidePart) _doc.PresentationPart.GetPartById(DetailTemplateSlideId);
            _imageSlideTemplate = (SlidePart) _doc.PresentationPart.GetPartById(ImageTemplateSlideId);
            _forcesSlideTemplate = (SlidePart) _doc.PresentationPart.GetPartById(ForcesTemplateSlideId);
        }

        public void InsertTopicTable(ITopic topic)
        {
            ISlide topicdetailSlide = new TopicDetailSlide(_doc, _detailSlideTemplate, topic);
            topicdetailSlide.Create();
            topicdetailSlide.FillContent();
            topicdetailSlide.Save();
            topicdetailSlide.Add();
        }

        public void InsertDecisionWithoutTopicMessage() { }

        public void InsertDecisionTable(IDecision decision)
        {
            ISlide detailSlide = new DetailSlide(_doc, _detailSlideTemplate, decision);
            detailSlide.Create();
            detailSlide.FillContent();
            detailSlide.Save();
            detailSlide.Add();
        }

        public void InsertForcesTable(IForcesModel forces)
        {
            ISlide forcesSlide = new ForcesSlide(_doc, _forcesSlideTemplate, forces);
            forcesSlide.Create();
            forcesSlide.FillContent();
            forcesSlide.Save();
            forcesSlide.Add();
        }

        public void InsertDiagramImage(EADiagram diagram)
        {
            ISlide imageSlide = new ImageSlide(_doc, _imageSlideTemplate, diagram);
            imageSlide.Create();
            imageSlide.FillContent();
            imageSlide.Save();
            imageSlide.Add();
        }

        public void Close()
        {
            DeleteTemplateSlide(_detailSlideTemplate, DetailTemplateSlideId);
            DeleteTemplateSlide(_imageSlideTemplate, ImageTemplateSlideId);
            DeleteTemplateSlide(_forcesSlideTemplate, ForcesTemplateSlideId);
            _doc.PresentationPart.Presentation.Save();
            _doc.Close();
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