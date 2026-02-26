using System;

namespace ConvertPptToOdp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check if input file path is provided
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the path to the PPT file as an argument.");
                return;
            }

            // Input PPT file path
            string inputPath = args[0];

            // Determine output ODP file path (same name with .odp extension)
            string outputPath = System.IO.Path.ChangeExtension(inputPath, ".odp");

            // Load the presentation from the specified PPT file
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Save the presentation in ODP format
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Odp);
            }

            Console.WriteLine($"Conversion completed. ODP file saved at: {outputPath}");
        }
    }
}