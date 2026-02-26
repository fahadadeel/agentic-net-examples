using System;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "AccessBuiltinProperties.pptx";
        string outputPath = "DocumentProperties_out.pptx";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Get built‑in document properties
            Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

            // Display current built‑in properties
            Console.WriteLine("Author : " + documentProperties.Author);
            Console.WriteLine("Title : " + documentProperties.Title);
            Console.WriteLine("Subject : " + documentProperties.Subject);
            Console.WriteLine("Comments : " + documentProperties.Comments);

            // Modify built‑in properties
            documentProperties.Author = "Aspose.Slides for .NET";
            documentProperties.Title = "Managing Presentation Properties";
            documentProperties.Subject = "Built‑in Properties Example";
            documentProperties.Comments = "Updated by example code";

            // Save the presentation (PPTX format)
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}