using System;

class Program
{
    static void Main(string[] args)
    {
        // Input PPT file path
        string inputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "input.ppt");
        // Output directory for PDF
        string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Output");
        if (!System.IO.Directory.Exists(outputDir))
        {
            System.IO.Directory.CreateDirectory(outputDir);
        }
        // Output PDF file path
        string outputPath = System.IO.Path.Combine(outputDir, "output.pdf");

        // Load the PPT presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
        // Save the presentation as PDF
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
        // Dispose the presentation object
        presentation.Dispose();
    }
}