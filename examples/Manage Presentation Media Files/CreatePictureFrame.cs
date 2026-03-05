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
        FileStream imageStream = new FileStream("example.jpg", FileMode.Open, FileAccess.Read);
        // Add image to the presentation's image collection
        Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);
        // Close the image stream
        imageStream.Close();

        // Add a picture frame to the slide
        Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle,
            50f,   // X position
            50f,   // Y position
            300f,  // Width
            200f,  // Height
            image);

        // Save the presentation
        presentation.Save("PictureFrameExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}