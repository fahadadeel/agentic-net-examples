using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source ODP file
        string inputPath = "input.odp";

        // Directory to store generated SVG files
        string outputDir = "output_svg";

        // Ensure the output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load the ODP presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Convert each slide to an SVG file
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[i];
            string svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
            using (FileStream svgStream = File.Create(svgPath))
            {
                slide.WriteAsSvg(svgStream);
            }
        }

        // Save the presentation before exiting (optional conversion)
        string savedPath = "saved_output.pptx";
        presentation.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}