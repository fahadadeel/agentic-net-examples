using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Input PPTX file path
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        // Output directory
        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);
        // Output PPT file path
        string outputPath = Path.Combine(outputDir, "output.ppt");

        // Load the PPTX presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Save as PPT format
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);

        // Dispose the presentation
        pres.Dispose();
    }
}