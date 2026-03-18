using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input and output presentations
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            // Load the presentation
            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Access document properties
                var docProps = presentation.DocumentProperties;

                // Display some built‑in properties
                Console.WriteLine("Author: " + docProps.Author);
                Console.WriteLine("Title: " + docProps.Title);
                Console.WriteLine("Created: " + docProps.CreatedTime);

                // Modify built‑in properties
                docProps.Author = "Aspose.Slides for .NET";
                docProps.Title = "Updated Presentation";
                docProps.Subject = "Metadata Example";

                // Add or update a custom property using the indexer
                docProps["CustomProperty"] = "CustomValue";

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}