using System;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Access document properties
        Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

        // Display some built‑in properties
        Console.WriteLine("Author: " + documentProperties.Author);
        Console.WriteLine("Title: " + documentProperties.Title);
        Console.WriteLine("Subject: " + documentProperties.Subject);
        Console.WriteLine("Created Time: " + documentProperties.CreatedTime);
        Console.WriteLine("Last Saved By: " + documentProperties.LastSavedBy);
        Console.WriteLine("Number of Slides: " + documentProperties.Slides);

        // Save the presentation (required before exit)
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}