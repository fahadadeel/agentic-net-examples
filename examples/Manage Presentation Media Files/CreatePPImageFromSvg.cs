using System;
using System.IO;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the SVG file to be added to the presentation
            string svgFilePath = "example.svg";

            // Create a new presentation instance
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Create an ISvgImage object from the SVG file content
                Aspose.Slides.ISvgImage svgImage = new Aspose.Slides.SvgImage(svgFilePath);

                // Add the SVG image to the presentation's image collection
                Aspose.Slides.IPPImage ppImage = presentation.Images.AddImage(svgImage);

                // Insert the image onto the first slide as a picture frame
                presentation.Slides[0].Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    0,
                    0,
                    ppImage.Width,
                    ppImage.Height,
                    ppImage);

                // Save the presentation to a PPTX file
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}