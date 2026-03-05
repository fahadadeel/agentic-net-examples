using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RotatePictureFrameExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Load an image from file
            FileStream imageStream = new FileStream("sample_image.jpg", FileMode.Open, FileAccess.Read);
            Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);
            imageStream.Dispose();

            // Add a picture frame to the slide
            Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle, // shape type
                100,    // X position
                100,    // Y position
                200,    // Width
                200,    // Height
                image   // picture
            );

            // Rotate the picture frame by a positive angle (clockwise)
            pictureFrame.Rotation = 45f; // 45 degrees clockwise

            // Save the presentation
            presentation.Save("RotatedPicture.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}