using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the PowerPoint presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Create PDF export options
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

        // Set JPEG quality
        pdfOptions.JpegQuality = 90;

        // Convert metafiles to PNG
        pdfOptions.SaveMetafilesAsPng = true;

        // Apply text compression
        pdfOptions.TextCompression = Aspose.Slides.Export.PdfTextCompression.Flate;

        // Define PDF compliance level
        pdfOptions.Compliance = Aspose.Slides.Export.PdfCompliance.Pdf15;

        // Save the presentation as PDF with the specified options
        presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

        // Release resources
        presentation.Dispose();
    }
}