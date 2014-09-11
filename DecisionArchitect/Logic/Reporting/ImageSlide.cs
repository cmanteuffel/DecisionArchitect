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

using System.IO;
using System.Linq;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using EAFacade.Model;

namespace DecisionArchitect.Logic.Reporting
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