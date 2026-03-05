using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input PPTX file path
        string inputPath = "input.pptx";
        // Output PPTX file path
        string outputPath = "output.pptx";

        // Load the presentation from the input file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Access built‑in document properties
        Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

        // Display some built‑in properties
        Console.WriteLine("Author: " + documentProperties.Author);
        Console.WriteLine("Title: " + documentProperties.Title);
        Console.WriteLine("Subject: " + documentProperties.Subject);
        Console.WriteLine("Created Time: " + documentProperties.CreatedTime);

        // Save the presentation (even if unchanged) before exiting
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}