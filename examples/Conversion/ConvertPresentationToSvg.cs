using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source PowerPoint file
        var inputPath = "input.pptx";

        // Directory where SVG files will be saved
        var outputDir = "output";
        Directory.CreateDirectory(outputDir);

        // Load the presentation
        using (var pres = new Aspose.Slides.Presentation(inputPath))
        {
            // Iterate through all slides and save each as an SVG file
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                var slide = pres.Slides[i];
                var svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
                using (var fileStream = File.Create(svgPath))
                {
                    slide.WriteAsSvg(fileStream);
                }
            }

            // Save the (potentially unchanged) presentation before exiting
            pres.Save("output.pptx", SaveFormat.Pptx);
        }
    }
}