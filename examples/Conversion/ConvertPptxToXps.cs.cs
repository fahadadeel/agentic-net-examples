using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        string inputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sample.pptx");
        // Path for the generated XPS file
        string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sample.xps");

        // Load the PPTX presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Convert and save the presentation to XPS format
        pres.Save(outputPath, SaveFormat.Xps);

        // Release resources
        pres.Dispose();
    }
}