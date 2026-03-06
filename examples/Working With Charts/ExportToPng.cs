using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportSlidesToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file
            System.String inputPath = "input.pptx";

            // Output file name format for PNG images
            System.String outputFormat = "slide_{0}.png";

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides and export each as PNG
            for (int index = 0; index < pres.Slides.Count; index++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[index];
                using (Aspose.Slides.IImage image = slide.GetImage())
                {
                    System.String outputPath = System.String.Format(outputFormat, index);
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                }
            }

            // Save the presentation before exiting (optional, can be same or new file)
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}