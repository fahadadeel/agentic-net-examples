using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Load SVG content from a file
        string svgPath = "content.svg";
        Aspose.Slides.ISvgImage svgImage = new Aspose.Slides.SvgImage(svgPath);

        // Add the SVG image to the presentation's image collection
        Aspose.Slides.IPPImage addedImage = presentation.Images.AddImage(svgImage);

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Insert the SVG image into the slide as a picture frame
        Aspose.Slides.IShape picture = slide.Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle,
            50f, 50f, 400f, 300f,
            addedImage);

        // Save the presentation in PPTX format
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}