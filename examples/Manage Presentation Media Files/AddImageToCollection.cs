using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input image file path
            string inputImagePath = "input.jpg";
            // Output presentation file path
            string outputPath = "output.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Read image data into a byte array
            byte[] imageData = System.IO.File.ReadAllBytes(inputImagePath);

            // Add the image to the presentation's image collection, obtaining an IPPImage instance
            Aspose.Slides.IPPImage img = pres.Images.AddImage(imageData);

            // Add a picture frame to the first slide using the added image
            Aspose.Slides.ISlide slide = pres.Slides[0];
            slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 0, 0, img.Width, img.Height, img);

            // Save the presentation in PPTX format
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}