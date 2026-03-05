using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Load an image from file and add it to the presentation's image collection
        using (FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read))
        {
            Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);

            // Add a picture frame to the slide
            Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,   // shape type
                100f,                               // X position (points)
                100f,                               // Y position (points)
                200f,                               // Width (points)
                150f,                               // Height (points)
                image                               // image to display
            );

            // Set relative scaling (e.g., 50% width, 75% height of the original image)
            pictureFrame.RelativeScaleWidth = 0.5f;
            pictureFrame.RelativeScaleHeight = 0.75f;
        }

        // Save the presentation to disk
        presentation.Save("PictureFrameRelativeScale.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}