using System;
using System.IO;
using Aspose.Slides;

namespace ManagePresentationImport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define directories and file names
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Source presentation to import
            string sourcePath = Path.Combine(dataDir, "source.pptx");
            // Destination presentation after import
            string outputPath = Path.Combine(dataDir, "imported_output.pptx");

            // Load the source presentation
            Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation(sourcePath);

            // Save the loaded presentation to a new file (import tip demonstration)
            sourcePresentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            sourcePresentation.Dispose();

            Console.WriteLine("Presentation imported and saved to: " + outputPath);
        }
    }
}