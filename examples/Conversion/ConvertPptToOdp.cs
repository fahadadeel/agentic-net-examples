using System;

class Program
{
    static void Main(string[] args)
    {
        // Verify that an input file path is provided
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the input PPT file path as a command‑line argument.");
            return;
        }

        // Input PPT file path
        string inputPath = args[0];
        // Output ODP file path (same name with .odp extension)
        string outputPath = System.IO.Path.ChangeExtension(inputPath, ".odp");

        // Load the presentation from the specified PPT file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Save the presentation in ODP format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Odp);
        }

        // Inform the user that conversion is complete
        Console.WriteLine("Conversion completed: " + outputPath);
    }
}