using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input PPTX file path
        string inputPath = "input.pptx";
        // Output PDF file path
        string outputPath = "output.pdf";

        // Load the PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Create PDF export options and set PDF/A-1b compliance
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
        pdfOptions.Compliance = Aspose.Slides.Export.PdfCompliance.PdfA1b;

        // Save the presentation as PDF with the specified options
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

        // Release resources
        presentation.Dispose();
    }
}