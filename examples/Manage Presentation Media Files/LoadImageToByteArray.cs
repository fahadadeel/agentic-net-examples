using System;
using System.IO;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the image file
            string imagePath = "image.png";

            // Load image file into a byte array
            byte[] imageData = File.ReadAllBytes(imagePath);

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add the image to the presentation's image collection
            Aspose.Slides.IPPImage img = pres.Images.AddImage(imageData);

            // Get the first slide (or create a blank one if none exists)
            Aspose.Slides.ISlide slide;
            if (pres.Slides.Count > 0)
            {
                slide = pres.Slides[0];
            }
            else
            {
                slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank));
            }

            // Insert the image onto the slide as a picture frame
            slide.Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                0,
                0,
                pres.SlideSize.Size.Width,
                pres.SlideSize.Size.Height,
                img);

            // Save the presentation in PPTX format
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}