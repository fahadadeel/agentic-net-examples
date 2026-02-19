using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input PPTX file path
        string inputPath = "input.pptx";

        // Define output directory and ensure it exists
        string outputDir = "Output";
        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        // Define output ODP file path
        string outputPath = Path.Combine(outputDir, "output.odp");

        // Load the PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Save the presentation in ODP format
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Odp);

        // Release resources
        presentation.Dispose();
    }
}