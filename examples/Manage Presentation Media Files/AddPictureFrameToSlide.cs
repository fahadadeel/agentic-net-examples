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

        // Load image file into a stream
        FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read);
        // Add image to the presentation's image collection
        Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream, LoadingStreamBehavior.KeepLocked);
        imageStream.Dispose();

        // Add a picture frame containing the image to the slide
        Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
            ShapeType.Rectangle, // shape type
            50,                  // X position (points)
            50,                  // Y position (points)
            300,                 // width (points)
            200,                 // height (points)
            image);              // image to display

        // Save the presentation to disk
        presentation.Save("output.pptx", SaveFormat.Pptx);
    }
}