using System;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory
            System.String outputDir = "Output";
            // Create directory if it does not exist
            if (!System.IO.Directory.Exists(outputDir))
                System.IO.Directory.CreateDirectory(outputDir);

            // Combine directory and file name to get full output path
            System.String outPath = System.IO.Path.Combine(outputDir, "SavedPresentation.pptx");

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Save the presentation in PPTX format
            presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();

            // Inform the user
            Console.WriteLine("Presentation saved to: " + outPath);
        }
    }
}