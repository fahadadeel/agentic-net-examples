using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Load an image from file
            using (FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read))
            {
                Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);

                // Add a picture frame to the slide
                Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                    ShapeType.Rectangle,   // shape type
                    50,                    // X position (points)
                    50,                    // Y position (points)
                    200,                   // width (points)
                    200,                   // height (points)
                    image);                // image to display

                // Set relative width and height (e.g., 150% width, 120% height)
                pictureFrame.RelativeScaleWidth = 1.5f;
                pictureFrame.RelativeScaleHeight = 1.2f;
            }

            // Save the presentation in PPTX format
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
    }
}