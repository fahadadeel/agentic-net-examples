using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PPTX file path (contains macros)
        string inputPath = Path.Combine("input-folder", "presentation-with-macros.pptx");
        // Output PDF file path
        string outputPath = Path.Combine("output-folder", "output.pdf");
        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Set PDF options (e.g., PDF/A-2a compliance)
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
        pdfOptions.Compliance = Aspose.Slides.Export.PdfCompliance.PdfA2a;

        // Save the presentation as PDF
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

        // Dispose the presentation object
        pres.Dispose();
    }
}