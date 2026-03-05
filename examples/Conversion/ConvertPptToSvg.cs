using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input PowerPoint file
        string inputPath = "input.pptx";

        // Directory to store SVG files
        string outputDir = "output_svgs";
        Directory.CreateDirectory(outputDir);

        // Load presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Iterate through all slides
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                // Get slide
                Aspose.Slides.ISlide slide = presentation.Slides[i];

                // Define SVG file path for the current slide
                string svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");

                // Save slide as SVG
                using (FileStream fileStream = File.Create(svgPath))
                {
                    slide.WriteAsSvg(fileStream);
                }
            }

            // Save the presentation before exiting (as required)
            presentation.Save("saved_output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}