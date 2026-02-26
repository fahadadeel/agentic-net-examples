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

        // Load an image file into the presentation
        using (FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read))
        {
            Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);

            // Add a picture frame to the slide
            Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 200, image);

            // Rotate the picture frame clockwise by 45 degrees
            pictureFrame.Rotation = 45f;

            // To rotate counterclockwise, assign a negative value, e.g., -30f
            // pictureFrame.Rotation = -30f;
        }

        // Save the presentation
        presentation.Save("RotatedPicture.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}