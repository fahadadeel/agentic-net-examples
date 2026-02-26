using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check if input and output file paths are provided
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ConvertToHtml <input-ppt-or-pptx> <output-html>");
                return;
            }

            // Input presentation file (PPT or PPTX)
            string inputPath = args[0];
            // Output HTML file
            string outputPath = args[1];

            // Load the presentation using fully-qualified Aspose.Slides type
            Presentation presentation = new Presentation(inputPath);

            // Save the presentation as HTML format
            presentation.Save(outputPath, SaveFormat.Html);

            // Dispose the presentation (handled by using statement or explicit call)
            presentation.Dispose();

            Console.WriteLine("Conversion completed: " + outputPath);
        }
    }
}