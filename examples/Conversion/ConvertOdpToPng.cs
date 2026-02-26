using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source ODP file
            System.String inputPath = "sample.odp";

            // Output file name pattern for PNG images
            System.String outputFormat = "slide_{0}.png";

            // Load the ODP presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Iterate through each slide and save it as a PNG image
            for (int index = 0; index < pres.Slides.Count; index++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[index];
                using (Aspose.Slides.IImage image = slide.GetImage())
                {
                    System.String outputPath = System.String.Format(outputFormat, index);
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                }
            }

            // Save the presentation (required by authoring rules)
            pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Odp);

            // Release resources
            pres.Dispose();
        }
    }
}