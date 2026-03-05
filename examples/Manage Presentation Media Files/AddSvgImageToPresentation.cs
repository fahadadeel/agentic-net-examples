using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Load SVG image from file
        Aspose.Slides.ISvgImage svgImage = new Aspose.Slides.SvgImage("example.svg");

        // Add SVG image to the presentation's image collection
        Aspose.Slides.IPPImage addedImage = presentation.Images.AddImage(svgImage);

        // Add the SVG image as a picture frame to the slide
        slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300, addedImage);

        // Save the presentation in PPTX format
        presentation.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}