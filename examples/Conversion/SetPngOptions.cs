using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Input PPTX file
        System.String inputPath = "input.pptx";
        // Output PNG file for the first slide
        System.String outputImagePath = "slide0.png";

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Desired resolution in DPI
        System.Int32 desiredDpi = 300;
        // Default DPI used by Aspose.Slides when rendering is 96
        System.Single scaleFactor = (System.Single)desiredDpi / 96f;

        // Export the first slide with the calculated scale (resolution)
        using (Aspose.Slides.IImage image = pres.Slides[0].GetImage(scaleFactor, scaleFactor))
        {
            // Save the image as PNG (compression is handled internally by the PNG encoder)
            image.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);
        }

        // Save the presentation (even if unchanged) before exiting
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}