using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using Text = DocumentFormat.OpenXml.Drawing.Text;

namespace DecisionViewpoints.Model.Reporting
{
    public abstract class AbstractSlide : ISlide
    {
        private const string NewSlideName = "newSlide";
        private static int _slideId;
        private readonly PresentationDocument _doc;
        private readonly SlidePart _teplateSlide;
        protected SlidePart NewSlidePart;

        protected AbstractSlide(PresentationDocument document, SlidePart templateSlide)
        {
            _doc = document;
            _teplateSlide = templateSlide;
        }

        public void Create()
        {
            NewSlidePart = _doc.PresentationPart.AddNewPart<SlidePart>(NewSlideName + _slideId++);
            //copy the contents of the template slide to the new slide and attach the appropriate layout
            NewSlidePart.FeedData(_teplateSlide.GetStream(FileMode.Open));
            NewSlidePart.AddPart(_teplateSlide.SlideLayoutPart,
                                 _teplateSlide.GetIdOfPart(_teplateSlide.SlideLayoutPart));
        }

        public virtual void FillContent()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            NewSlidePart.Slide.Save();
        }

        public void Add()
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
                    RelationshipId = _doc.PresentationPart.GetIdOfPart(NewSlidePart)
                };
            slideIdList.AppendChild(newSlideId);
        }

        protected static void SetPlaceholder(SlidePart slidePart, string placeholder, string value)
        {
            List<Text> textList =
                slidePart.Slide.Descendants<Text>().Where(t => t.Text.Equals(placeholder)).ToList();
            foreach (Text text in textList) text.Text = value;
        }
    }
}