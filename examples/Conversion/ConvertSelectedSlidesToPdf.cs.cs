using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine input PPTX file path
        string inputPath;
        if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
        {
            inputPath = args[0];
        }
        else
        {
            inputPath = "sample.pptx"; // default path
        }

        // Determine output PDF file path
        string outputPath = Path.ChangeExtension(inputPath, ".pdf");

        // Define slide indices to convert (zero-based)
        int[] slides = new int[] { 0, 2 }; // example: first and third slides

        // Load presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Save selected slides to PDF
            presentation.Save(outputPath, slides, Aspose.Slides.Export.SaveFormat.Pdf);
        }
    }
}