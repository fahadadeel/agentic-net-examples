using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input ODP file and output directory
        string dataDir = "Data";
        string inputPath = Path.Combine(dataDir, "input.odp");
        string outputDir = Path.Combine(dataDir, "output");

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        // Load the ODP presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Convert each slide to an SVG file
        for (int i = 0; i < pres.Slides.Count; i++)
        {
            string svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
            using (FileStream outStream = new FileStream(svgPath, FileMode.Create, FileAccess.Write))
            {
                pres.Slides[i].WriteAsSvg(outStream);
            }
        }

        // Save the presentation (optional, as required before exit)
        string savedPptxPath = Path.Combine(outputDir, "output.pptx");
        pres.Save(savedPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}