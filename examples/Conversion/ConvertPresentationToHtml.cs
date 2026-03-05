using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input presentation files (PPT and PPTX)
        string[] inputFiles = new string[] { "sample.ppt", "sample.pptx" };

        foreach (string inputFile in inputFiles)
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile);

            // Determine output HTML file name
            string outputFile = Path.ChangeExtension(inputFile, ".html");

            // Save the presentation as HTML
            presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Html);

            // Release resources
            presentation.Dispose();
        }
    }
}