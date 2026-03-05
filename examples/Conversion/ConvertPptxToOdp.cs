using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        string inputPath = "input.pptx";

        // Path where the ODP file will be saved
        string outputPath = "output.odp";

        // Load the PPTX presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Save the presentation in ODP format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Odp);
        }

        // Indicate completion
        Console.WriteLine("Conversion completed.");
    }
}