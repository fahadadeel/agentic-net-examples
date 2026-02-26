using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Verify that a source file path is provided
        if (args.Length == 0)
        {
            Console.WriteLine("Please specify the path to the PPT file.");
            return;
        }

        string inputPath = args[0];
        string outputPath = Path.ChangeExtension(inputPath, ".pdf");

        // Load the presentation from the specified file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Save the presentation as PDF
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
        }

        Console.WriteLine("Conversion completed: " + outputPath);
    }
}