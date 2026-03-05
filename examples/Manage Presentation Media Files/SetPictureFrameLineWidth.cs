using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Load an image file into the presentation's image collection
        using (FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read))
        {
            Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);

            // Add a picture frame to the slide
            Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle, 100f, 100f, 200f, 150f, image);

            // Set the line width of the picture frame (in points)
            pictureFrame.LineFormat.Width = 5.0;
        }

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}