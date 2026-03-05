using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Export;
using Aspose.Slides;
using Aspose.Slides;
using System.Drawing;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Load an image from file into the presentation's image collection
            FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read);
            IPPImage image = presentation.Images.AddImage(imageStream);
            imageStream.Dispose();

            // Determine image dimensions (width and height in points)
            // Assuming the image dimensions are in pixels, convert to points (1 point = 1/72 inch)
            // For simplicity, use the pixel dimensions directly as points
            float imageWidth = (float)image.Width;
            float imageHeight = (float)image.Height;

            // Add a picture frame to the slide using the image's dimensions
            IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                ShapeType.Rectangle,
                0f,               // X position
                0f,               // Y position
                imageWidth,       // Width
                imageHeight,      // Height
                image);

            // Save the presentation to disk
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
    }
}