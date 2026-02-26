using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the EMF image file
        string emfFilePath = "image.emf";

        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Load the EMF image into the presentation's image collection
            using (FileStream emfStream = new FileStream(emfFilePath, FileMode.Open, FileAccess.Read))
            {
                Aspose.Slides.IPPImage emfImage = presentation.Images.AddImage(emfStream);

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add the EMF image as a picture frame (acting as a heading)
                slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 20, 600, 100, emfImage);
            }

            // Save the presentation to a PPTX file
            presentation.Save("PresentationWithEmfHeading.pptx", SaveFormat.Pptx);
        }
    }
}