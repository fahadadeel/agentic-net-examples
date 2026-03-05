using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Input presentation files (PPT and PPTX)
        string[] inputFiles = new string[] { "sample.ppt", "sample.pptx" };

        foreach (string inputFile in inputFiles)
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputFile);

            // Create GIF export options (default settings)
            Aspose.Slides.Export.GifOptions options = new Aspose.Slides.Export.GifOptions();

            // Determine output GIF file name
            string outputFile = Path.ChangeExtension(inputFile, ".gif");

            // Save the presentation as an animated GIF
            pres.Save(outputFile, Aspose.Slides.Export.SaveFormat.Gif, options);

            // Release resources
            pres.Dispose();
        }
    }
}